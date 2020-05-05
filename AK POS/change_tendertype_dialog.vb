Imports AK_POS.connection_class
Imports System.Data.SqlClient
Public Class change_tendertype_dialog
    Dim cc As New connection_class()

    Dim transaction As SqlTransaction

    Public Shared transid As Integer = 0, orderid As Integer = 0, datee As String = "", transnum As String = "", current_tendertype As String = ""
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Private Sub change_tendertype_dialog_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, Label2.MouseDown, Label1.MouseDown
        drag = True 'Sets the variable drag to true.
        mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'Sets variable mousey
    End Sub

    Private Sub change_tendertype_dialog_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove, Label2.MouseMove, Label1.MouseMove
        'If drag is set to true then move the form accordingly.
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub change_tendertype_dialog_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp, Label2.MouseUp, Label1.MouseUp
        drag = False 'Sets drag to false, so the form does not move according to the code in MouseMove
    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub change_tendertype_dialog_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Public Function checkCustomer() As Boolean
        Dim result As Boolean = False
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT customer_id FROM tblcustomers WHERE name=@name AND type='" & IIf(cmbtendertype.Text = "A.R Sales", "Customer", "Employee") & "';", cc.con)
        cc.cmd.Parameters.AddWithValue("@name", txtcustomer.Text)
        cc.rdr = cc.cmd.ExecuteReader
        If cc.rdr.Read Then
            result = False
        Else
            result = True
        End If
        cc.con.Close()
        Return result
    End Function

    Private Sub change_tendertype_dialog_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT tendertype,customer FROM tbltransaction WHERE transid=" & transid & ";", cc.con)
        cc.rdr = cc.cmd.ExecuteReader
        If cc.rdr.Read Then
            Dim customer As String = cc.rdr("customer")
            cmbtendertype.Text = cc.rdr("tendertype")
            txtcustomer.Text = customer
            Label2.Text = IIf(cc.rdr("tendertype") = "A.R Charge", "Employee:", "Customer:")
            txtcustomer.Enabled = IIf(cc.rdr("tendertype").ToString.ToLower = "CASH".ToLower, False, True)
        End If
        cc.con.Close()
    End Sub

    Private Sub cmbtendertype_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbtendertype.SelectedValueChanged
        Try
            Label2.Text = IIf(cmbtendertype.Text = "A.R Charge", "Employee: ", "Customer:")
            txtcustomer.Enabled = IIf(cmbtendertype.Text.ToLower = "CASH".ToLower, False, True)

            Dim auto As New AutoCompleteStringCollection
            If cmbtendertype.Text.ToLower <> "CASH".ToLower Then
                auto.Clear()
                cc.con.Open()
                cc.cmd = New SqlClient.SqlCommand("SELECT name FROM tblcustomers WHERE type='" & IIf(cmbtendertype.Text = "A.R Sales", "Customer", "Employee") & "';", cc.con)
                cc.rdr = cc.cmd.ExecuteReader
                While cc.rdr.Read
                    auto.Add(cc.rdr("name"))
                End While
                cc.con.Close()
                txtcustomer.AutoCompleteCustomSource = auto
                txtcustomer.Text = ""
            Else
                auto.Clear()
                txtcustomer.Text = "CASH"
                txtcustomer.AutoCompleteCustomSource = auto
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btnsubmit_Click(sender As Object, e As EventArgs) Handles btnsubmit.Click
        If String.IsNullOrEmpty(Trim(txtcustomer.Text)) Then
            MessageBox.Show("Name field is empty", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtcustomer.Focus()
        ElseIf cmbtendertype.Text <> "CASH" And checkCustomer() Then
            MessageBox.Show("Name '" & txtcustomer.Text & "' not found", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtcustomer.Focus()
        Else
            saveTransaction()
        End If
    End Sub

    Public Sub saveTransaction()
        Try
            Using connection As New SqlConnection(login.ss)
                Dim cmdd As New SqlCommand(), rdr As SqlDataReader, tendertype As String = "", invnum_tendertype As String = "", invnum_current_tendertype As String = ""

                cmdd.Connection = connection

                connection.Open()
                transaction = connection.BeginTransaction()

                cmdd.Transaction = transaction

                Select Case cmbtendertype.Text
                    Case "A.R Sales"
                        tendertype = "AR Sales"
                        invnum_tendertype = "arsales"
                    Case "A.R Charge"
                        tendertype = "AR Charge"
                        invnum_tendertype = "archarge"
                    Case "CASH"
                        tendertype = "AR Cash"
                        invnum_tendertype = "ctrout"
                End Select

                Select Case current_tendertype
                    Case "A.R Sales"
                        invnum_current_tendertype = "arsales"
                    Case "A.R Charge"
                        invnum_current_tendertype = "archarge"
                    Case "CASH"
                        invnum_current_tendertype = "ctrout"
                End Select
                cmdd.Parameters.Clear()
                cmdd.CommandText = "UPDATE tbltransaction SET tendertype='" & IIf(cmbtendertype.Text = "AR Cash", "Cash", cmbtendertype.Text) & "',customer=@customer WHERE transid=" & transid & ";"
                cmdd.Parameters.AddWithValue("@customer", txtcustomer.Text)
                cmdd.ExecuteNonQuery()

                cmdd.Parameters.Clear()
                cmdd.CommandText = "UPDATE tbltransaction2 SET tendertype='" & IIf(cmbtendertype.Text = "AR Cash", "Cash", cmbtendertype.Text) & "',customer=@customer WHERE orderid=" & orderid & ";"
                cmdd.Parameters.AddWithValue("@customer", txtcustomer.Text)
                cmdd.ExecuteNonQuery()

                cmdd.Parameters.Clear()
                cmdd.CommandText = "UPDATE tblars1 SET type='" & tendertype & "',name=@customer WHERE transnum='" & transnum & "';"
                cmdd.Parameters.AddWithValue("@customer", txtcustomer.Text)
                cmdd.ExecuteNonQuery()

                cmdd.Parameters.Clear()
                cmdd.CommandText = "UPDATE tblars2 SET name=@customer WHERE transnum='" & transnum & "';"
                cmdd.Parameters.AddWithValue("@customer", txtcustomer.Text)
                cmdd.ExecuteNonQuery()

                If invnum_tendertype <> invnum_current_tendertype Then
                    cmdd.Parameters.Clear()
                    cmdd.CommandText = "SELECT itemname,qty FROM tblorder WHERE transnum='" & transnum & "';"
                    Dim adptr As New SqlDataAdapter()
                    Dim dt As New DataTable()
                    adptr.SelectCommand = cmdd
                    adptr.Fill(dt)

                    For Each r0w As DataRow In dt.Rows
                        cmdd.Parameters.Clear()
                        cmdd.CommandText = "UPDATE tblinvitems SET " & invnum_tendertype & "+=" & r0w("qty") & "," & invnum_current_tendertype & "-=" & r0w("qty") & "  WHERE invnum=(Select invnum FROM tblinvsum WHERE CAST(datecreated As Date)='" & datee & "') AND itemname='" & r0w("itemname") & "';"
                        cmdd.Parameters.AddWithValue("@customer", txtcustomer.Text)
                        cmdd.ExecuteNonQuery()
                    Next
                End If
                transaction.Commit()
                MessageBox.Show("Transaction Completed", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Try
                transaction.Rollback()
            Catch ex2 As Exception
                MessageBox.Show(ex2.ToString)
            End Try
        End Try
    End Sub
End Class