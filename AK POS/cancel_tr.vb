Imports System.Data.SqlClient
Imports AK_POS.connection_class
Public Class cancel_tr
    Dim cc As New connection_class
    Dim con As New SqlConnection(cc.conString)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim adptr As New SqlDataAdapter

    Dim inv_id As String = ""
    Dim transaction As SqlTransaction

    Public Shared cnfrm As Boolean = False, trans_num As String = ""

    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Private Sub cancel_tr_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Label3.Visible = IIf(login.wrkgrp = "Cashier", False, True)
        'dtdate.Visible = IIf(login.wrkgrp = "Cashier", False, True)
        dgvtrans.Columns("btncancel").Visible = IIf(login.wrkgrp = "Cashier", False, True)
        dtdate.MaxDate = getSystemDate()
        Me.KeyPreview = True
        loadSales()
        cmbtype.SelectedIndex = 0
    End Sub

    Public Sub loadSales()
        Try
            cmbsales.Items.Clear()
            cmbsales.Items.Add("All")
            con.Open()
            cmd = New SqlCommand("SELECT username FROM tblusers WHERE workgroup='Sales';", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                cmbsales.Items.Add(rdr("username"))
            End While
            con.Close()
            cmbsales.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Function getSystemDate() As DateTime
        Try
            con.Open()
            Dim dt As New DateTime()
            cmd = New SqlCommand("SELECT GETDATE()", con)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                dt = CDate(rdr(0).ToString)
            End If
            con.Close()
            Return dt
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Function
    Public Sub loadTrans()
        Try
            Dim serverDate As String = getSystemDate().ToString("MM/dd/yyyy")
            Dim query As String = "SELECT tbltransaction.transnum,tbltransaction2.ordernum,tbltransaction.amtdue,tbltransaction.partialamt,tbltransaction.tendertype,tbltransaction.servicetype,tbltransaction.typez FROM tbltransaction JOIN tbltransaction2 ON tbltransaction.transnum = tbltransaction2.transnum  WHERE CAST(tbltransaction.datecreated  AS date)='" & dtdate.Text & "' AND sap_number !='' AND tbltransaction.status=1 AND tbltransaction.tendertype !='Deposit' AND tbltransaction.tendertype != 'Cash Out'"

            If Not String.IsNullOrEmpty(txtsearch.Text) Then
                query &= " And tbltransaction2.ordernum Like @ordernum"
            ElseIf cmbsales.SelectedIndex <> 0 And cmbtype.SelectedIndex = 0 Then
                query &= " AND tbltransaction2.cashier='" & cmbsales.Text & "'"
            ElseIf cmbtype.SelectedIndex <> 0 And cmbsales.SelectedIndex = 0 Then
                query &= " AND tbltransaction.typez='" & cmbtype.Text & "'"
            ElseIf cmbtype.SelectedIndex <> 0 And cmbsales.SelectedIndex <> 0 Then
                query &= " AND tbltransaction.typez='" & cmbtype.Text & "' AND tbltransaction2.cashier='" & cmbsales.Text & "'"
            End If

            dgvtrans.Rows.Clear()
            dgvorders.Rows.Clear()
            lblitems_count.Text = "ITEMS (0)"
            con.Open()
            cmd = New SqlCommand(query, con)
            If Not String.IsNullOrEmpty(txtsearch.Text) Then
                cmd.Parameters.AddWithValue("@ordernum", "%" & txtsearch.Text & "%")
            End If
            rdr = cmd.ExecuteReader
            While rdr.Read
                dgvtrans.Rows.Add(rdr("transnum"), rdr("ordernum"), CDbl(rdr("amtdue")).ToString("n2"), rdr("partialamt"), rdr("tendertype"), rdr("servicetype"), rdr("typez"))
            End While
            con.Close()
            lbltrans_count.Text = "TRANSACTIONS (" & dgvtrans.RowCount & ")"
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub cmbtype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbtype.SelectedIndexChanged
        loadTrans()
    End Sub

    Private Sub cmbsales_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbsales.SelectedIndexChanged
        loadTrans()
    End Sub

    Private Sub dgvtrans_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvtrans.CellDoubleClick
        Try
            Dim query As String = "SELECT itemname,qty,price,dscnt,totalprice FROM tblorder WHERE transnum='" & dgvtrans.CurrentRow.Cells("transnum").Value & "'"

            dgvorders.Rows.Clear()
            con.Open()
            cmd = New SqlCommand(query, con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                dgvorders.Rows.Add(rdr("itemname"), rdr("qty"), CDbl(rdr("price")).ToString("n2"), rdr("dscnt"), CDbl(rdr("totalprice")).ToString("n2"))
            End While
            con.Close()
            lblitems_count.Text = "ITEMS (" & dgvorders.RowCount & ")"
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Sub getID()
        Dim id As String = ""
        Dim date_ As New DateTime()
        con.Open()
        cmd = New SqlCommand("Select TOP 1 invnum,datecreated from tblinvsum WHERE area='" & "Sales" & "' AND CAST(datecreated AS date)='" & dtdate.Text & "' order by invsumid DESC", con)
        rdr = cmd.ExecuteReader()
        If rdr.Read() Then
            id = rdr("invnum")
            date_ = CDate(rdr("datecreated"))
        End If
        con.Close()
        inv_id = id
    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        loadTrans()
    End Sub

    Private Sub dgvtrans_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvtrans.CellContentClick
        Try
            If dgvtrans.RowCount <> 0 Then
                If e.ColumnIndex = 7 Then
                    Dim a As String = MsgBox("Are you sure you want to cancel?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MessageBoxDefaultButton.Button2, "")
                    If a = vbYes Then

                        confirm.ShowDialog()

                        If cnfrm = False Then
                            Exit Sub
                        End If


                        Dim serverDate As String = getSystemDate.ToString("MM/dd/yyyy")

                        getID()
                        GetTransID()

                        con.Open()
                        cmd = New SqlCommand("SELECT itemname,qty,category FROM tblorder WHERE transnum=@transnum2;", con)
                        cmd.Parameters.AddWithValue("@transnum2", dgvtrans.CurrentRow.Cells("transnum").Value)
                        Dim dt As New DataTable()
                        adptr.SelectCommand = cmd
                        adptr.Fill(dt)
                        con.Close()
                        Dim iout As String = ""
                        If dgvtrans.CurrentRow.Cells("tendertype").Value = "Cash" Then
                            iout = "ctrout"
                        ElseIf dgvtrans.CurrentRow.Cells("tendertype").Value = "A.R Sales" Then
                            iout = "arsales"
                        ElseIf dgvtrans.CurrentRow.Cells("tendertype").Value = "A.R Charge" Then
                            iout = "archarge"
                        End If
                        Using connection As New SqlConnection(cc.conString)
                            Dim cmdd As New SqlCommand()
                            cmdd.Connection = connection
                            connection.Open()
                            transaction = connection.BeginTransaction()
                            cmdd.Transaction = transaction
                            Try
                                For Each r0w As DataRow In dt.Rows
                                    Dim query As String = ""
                                    If r0w("category") <> "Coffee Shop" Then
                                        cmdd.Parameters.Clear()
                                        query = "UPDATE tblinvitems SET " & iout & "-=@qty, endbal+=@qty,variance-=@qty WHERE itemname=@itemname AND invnum=(SELECT invnum FROM tblinvsum WHERE CAST(datecreated AS date)='" & dtdate.Value.ToString("MM/dd/yyyy") & "');"
                                        cmdd.CommandText = query
                                        cmdd.Parameters.AddWithValue("@qty", r0w("qty"))
                                        cmdd.Parameters.AddWithValue("@itemname", r0w("itemname"))
                                        cmdd.ExecuteNonQuery()
                                    Else
                                        cmdd.Parameters.Clear()
                                        query = "UPDATE tblinvitems Set " & iout & "-=@qty,productionin-=@qty,totalav-=@qty,endbal+=@qty,variance-=@qty WHERE itemname=@itemname And invnum=@invnum;"
                                        cmdd.CommandText = query
                                        cmdd.Parameters.AddWithValue("@qty", r0w("qty"))
                                        cmdd.Parameters.AddWithValue("@itemname", r0w("itemname"))
                                        cmdd.Parameters.AddWithValue("@invnum", inv_id)
                                        cmdd.ExecuteNonQuery()
                                    End If
                                Next
                                cmdd.Parameters.Clear()
                                cmdd.CommandText = "UPDATE tbltransaction SET status='0' WHERE transnum=@transnum AND CAST(datecreated AS date)='" & dtdate.Text & "';"
                                cmdd.Parameters.AddWithValue("@transnum", dgvtrans.CurrentRow.Cells("transnum").Value)
                                cmdd.ExecuteNonQuery()

                                cmdd.Parameters.Clear()
                                cmdd.CommandText = "UPDATE tbltransaction2 SET status=0, status2='Cancel' WHERE transnum=@transnum AND CAST(datecreated AS date)='" & dtdate.Text & "';"
                                cmdd.Parameters.AddWithValue("@transnum", dgvtrans.CurrentRow.Cells("transnum").Value)
                                cmdd.ExecuteNonQuery()

                                cmdd.Parameters.Clear()
                                cmdd.CommandText = "DELETE FROM tblars1 WHERE transnum=@transnum;"
                                cmdd.Parameters.AddWithValue("@transnum", dgvtrans.CurrentRow.Cells("transnum").Value)
                                cmdd.ExecuteNonQuery()

                                cmdd.Parameters.Clear()
                                cmdd.CommandText = "DELETE FROM tblars2 WHERE transnum=@transnum;"
                                cmdd.Parameters.AddWithValue("@transnum", dgvtrans.CurrentRow.Cells("transnum").Value)
                                cmdd.ExecuteNonQuery()

                                cmdd.Parameters.Clear()
                                cmdd.CommandText = "UPDATE tblgctrans Set status=0 WHERE transnum=@transnum;"
                                cmdd.Parameters.AddWithValue("@transnum", dgvtrans.CurrentRow.Cells("transnum").Value)
                                cmdd.ExecuteNonQuery()
                                transaction.Commit()
                            Catch ex As Exception
                                MessageBox.Show(ex.Message)
                                Try
                                    transaction.Rollback()
                                Catch ex2 As Exception
                                    MessageBox.Show(ex2.Message)
                                End Try
                            End Try
                            MessageBox.Show("Cancelled", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            loadTrans()
                        End Using
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub GetTransID()
        Try
            Dim selectcount_result As Integer = 0
            Dim get_area As String = "", temp As String = ""
            Dim area_format As String = ""
            con.Open()
            cmd = New SqlCommand("Select COUNT(*) transaction_number  from tblproduction WHERE area='" & "Sales" & "' AND type='Actual Ending Balance';", con)
            selectcount_result = cmd.ExecuteScalar + 1
            con.Close()

            Dim branchcode As String = ""
            con.Open()
            cmd = New SqlCommand("SELECT branchcode FROM tblbranch WHERE main='1';", con)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                branchcode = rdr("branchcode")
            End If
            con.Close()

            'Dim s As String = ""
            'If lcacc = "Sales" Then
            '    s = "(SLS) "
            'Else
            '    s = "(PRD) "
            'End If



            If selectcount_result < 1000000 Then
                Dim cselectcount_result As String = CStr(selectcount_result)
                For vv As Integer = 1 To 6 - cselectcount_result.Length
                    temp += "0"
                Next
                area_format = "AEB - " & branchcode & " - " & selectcount_result
            End If
            trans_num = area_format
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information, "")
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged

    End Sub

    Private Sub dtdate_ValueChanged(sender As Object, e As EventArgs) Handles dtdate.ValueChanged
        getID()
        loadTrans()
    End Sub

    Private Sub lblclose_Click(sender As Object, e As EventArgs) Handles lblclose.Click
        Me.Close()
    End Sub

    Private Sub cancel_tr_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown, MyBase.MouseDown, Label4.MouseDown
        drag = True 'Sets the variable drag to true.
        mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'Sets variable mousey
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove, MyBase.MouseMove, Label4.MouseMove
        'If drag is set to true then move the form accordingly.
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub cancel_tr_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp, MyBase.MouseUp, Label4.MouseUp
        drag = False 'Sets drag to false, so the form does not move according to the code in MouseMove
    End Sub
End Class