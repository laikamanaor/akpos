Imports System.IO
Imports System.Data.SqlClient
Imports System.Drawing
Imports AK_POS.connection_class
Public Class discount
    Dim cc As New connection_class
    Dim strconn As String = cc.conString
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim sql As String

    Public Shared disc As Boolean = False
    Dim stat As String = ""

    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function

    Public Sub connect()
        conn = New SqlConnection
        conn.ConnectionString = strconn
        If conn.State <> ConnectionState.Open Then
            conn.Open()
        End If
    End Sub

    Public Sub disconnect()
        conn = New SqlConnection
        conn.ConnectionString = strconn
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
    End Sub

    Private Sub discount_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub discount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor
            btnview.PerformClick()
            chkrows()
            refdel()
            grddis.Columns(0).ReadOnly = True
            grddis.Columns(1).ReadOnly = True
            grddis.Columns(2).ReadOnly = True
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Private Sub btnview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            grddis.Rows.Clear()
            sql = "Select * from tbldiscount order by disname"
            connect()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            While dr.Read
                Me.Cursor = Cursors.WaitCursor
                If dr("status") = 1 Then
                    stat = "Active"
                Else
                    stat = "Deactivated"
                End If
                grddis.Rows.Add(dr("disid"), dr("disname"), dr("amount"), stat)
            End While
            dr.Dispose()
            cmd.Dispose()

            Me.Cursor = Cursors.Default

            txtamt.Text = ""
            txtdis.Text = ""
            btncancel.PerformClick()

            chkrows()
            Me.Cursor = Cursors.Default
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information, "")
        Finally
            disconnect()
        End Try
    End Sub

    Private Sub btnsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If Trim(txtdis.Text) = "" Then
                grddis.Rows.Clear()
                MsgBox("Input Discount Type first.", MsgBoxStyle.Exclamation, "")
                txtamt.Text = ""
                txtdis.Focus()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            sql = "Select * from tbldiscount where disname like '" & Trim(txtdis.Text) & "%'"
            connect()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            If dr.Read Then
                grddis.Rows.Clear()
                If dr("status") = 1 Then
                    stat = "Active"
                Else
                    stat = "Deactivated"
                End If
                grddis.Rows.Add(dr("disid"), dr("disname"), dr("amount"), stat)
            Else
                MsgBox("Cannot found " & Trim(txtdis.Text), MsgBoxStyle.Critical, "")
            End If
            dr.Dispose()
            cmd.Dispose()

            txtdis.Text = ""
            txtdis.Focus()
            Me.Cursor = Cursors.Default
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Private Sub txtdis_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdis.KeyPress
        If Asc(e.KeyChar) = Windows.Forms.Keys.Enter And Trim(txtamt.Text) = "" And Trim(txtdis.Text) <> "" Then
            btnsearch.PerformClick()
        ElseIf Asc(e.KeyChar) = Windows.Forms.Keys.Enter And Trim(txtamt.Text) <> "" And Trim(txtdis.Text) <> "" And btnupdate.Text = "&Update" Then
            btnadd.PerformClick()
        ElseIf Asc(e.KeyChar) = Windows.Forms.Keys.Enter And Trim(txtamt.Text) <> "" And Trim(txtdis.Text) <> "" And btnupdate.Text <> "&Update" Then
            btnupdate.PerformClick()
        End If
    End Sub

    Private Sub txtdis_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdis.Leave
        txtdis.Text = StrConv(txtdis.Text, VbStrConv.ProperCase)
    End Sub

    Private Sub txtdis_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdis.TextChanged
        Dim charactersDisallowed As String = "'"
        Dim theText As String = txtdis.Text
        Dim Letter As String
        Dim SelectionIndex As Integer = txtdis.SelectionStart
        Dim Change As Integer

        For x As Integer = 0 To txtdis.Text.Length - 1
            Letter = txtdis.Text.Substring(x, 1)
            If charactersDisallowed.Contains(Letter) Then
                theText = theText.Replace(Letter, String.Empty)
                Change = 1
            End If
        Next

        txtdis.Text = theText
        txtdis.Select(SelectionIndex - Change, 0)
    End Sub

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If Trim(txtdis.Text) <> "" And Trim(txtamt.Text) <> "" Then
                sql = "Select * from tbldiscount where disname='" & Trim(txtdis.Text) & "'"
                connect()
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    MsgBox(Trim(txtdis.Text) & " is already exist.", MsgBoxStyle.Information, "")
                    btnupdate.Text = "   &Update"
                    txtdis.Text = ""
                    txtamt.Text = ""
                    txtdis.Focus()
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                dr.Dispose()
                cmd.Dispose()

                Me.Cursor = Cursors.Default
                confirm.ShowDialog()
                If disc = True Then
                    sql = "Insert into tbldiscount (disname, amount, datecreated, createdby, datemodified, modifiedby, status) values('" & Trim(txtdis.Text) & "','" & Trim(txtamt.Text) & "',(SELECT GETDATE()),'" & login2.username & "',(SELECT GETDATE()),'" & login2.username & "','1')"
                    connect()
                    cmd = New SqlCommand(sql, conn)
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()

                    MsgBox("Successfully Saved.", MsgBoxStyle.Information, "")
                    btnview.PerformClick()
                End If

                disc = False
                txtdis.Text = ""
                txtamt.Text = ""
                txtdis.Focus()
                disc = False
            Else
                If Trim(txtdis.Text) = "" Then
                    MsgBox("Input Discount Type first.", MsgBoxStyle.Exclamation, "")
                    txtdis.Focus()
                Else
                    MsgBox("Complete the fieldst.", MsgBoxStyle.Exclamation, "")
                    txtdis.Focus()
                End If
            End If
            Me.Cursor = Cursors.Default
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If grddis.SelectedRows.Count = 1 Or grddis.SelectedCells.Count = 1 Then
                If btnupdate.Text = "   &Update" Then
                    If grddis.Rows(grddis.CurrentRow.Index).Cells(3).Value = "Deactivated" Then
                        MsgBox("Cannot update deactivated discount.", MsgBoxStyle.Exclamation, "")
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    txtdis.Text = grddis.Rows(grddis.CurrentRow.Index).Cells(1).Value
                    txtamt.Text = grddis.Rows(grddis.CurrentRow.Index).Cells(2).Value
                    lbldisid.Text = grddis.Rows(grddis.CurrentRow.Index).Cells(0).Value
                    lblname.Text = grddis.Rows(grddis.CurrentRow.Index).Cells(1).Value
                    btnsearch.Enabled = False
                    btnadd.Enabled = False
                    btndeactivate.Enabled = False
                    btnupdatedel.Enabled = False
                    btnupdate.Text = "   &Save"
                    btncancel.Enabled = True
                Else
                    'update
                    sql = "Select * from tbldiscount where disname='" & Trim(txtdis.Text) & "' and disid<>'" & Val(lbldisid.Text) & "'"
                    connect()
                    cmd = New SqlCommand(sql, conn)
                    dr = cmd.ExecuteReader
                    If dr.Read Then
                        MsgBox(Trim(txtdis.Text) & " is already exist.", MsgBoxStyle.Exclamation, "")
                        txtdis.Focus()
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    dr.Dispose()
                    cmd.Dispose()


                    confirm.ShowDialog()
                    If disc = True Then
                        sql = "Update tbldiscount set disname='" & Trim(txtdis.Text) & "', amount='" & Trim(txtamt.Text) & "', datemodified=(SELECT GETDATE()), modifiedby='" & login2.username & "' where disid='" & lbldisid.Text & "'"
                        connect()
                        cmd = New SqlCommand(sql, conn)
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()

                        If lblname.Text <> Trim(txtdis.Text) Then
                            sql = "Update tbltransaction set disctype='" & Trim(txtdis.Text) & "', datemodified=(SELECT GETDATE()) where disctype='" & lblname.Text & "'"
                            connect()
                            cmd = New SqlCommand(sql, conn)
                            cmd.ExecuteNonQuery()
                            cmd.Dispose()

                            sql = "Update tblsenior set disctype='" & Trim(txtdis.Text) & "' where disctype='" & lblname.Text & "'"
                            connect()
                            cmd = New SqlCommand(sql, conn)
                            cmd.ExecuteNonQuery()
                            cmd.Dispose()
                        End If

                        MsgBox("Successfully Saved.", MsgBoxStyle.Information, "")
                        btnview.PerformClick()
                    End If


                    btnupdate.Text = "   &Update"
                    btnsearch.Enabled = True
                    btnadd.Enabled = True
                    btndeactivate.Enabled = True
                    btnupdatedel.Enabled = True
                    btncancel.Enabled = False
                    txtdis.Text = ""
                    txtamt.Text = ""
                    lbldisid.Text = ""
                    txtdis.Focus()
                    disc = False
                End If
            Else
                MsgBox("Select only one.", MsgBoxStyle.Exclamation, "")
            End If
            Me.Cursor = Cursors.Default
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Private Sub btndeactivate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndeactivate.Click
        Try
            If grddis.SelectedRows.Count = 1 Or grddis.SelectedCells.Count = 1 Then
                lbldisid.Text = grddis.Rows(grddis.CurrentRow.Index).Cells(0).Value
                If btndeactivate.Text = " &Deactivate" Then

                    confirm.ShowDialog()
                    If disc = True Then
                        sql = "Update tbldiscount set status='0', datemodified=(SELECT GETDATE()), modifiedby='" & login2.username & "' where disid='" & lbldisid.Text & "'"
                        connect()
                        cmd = New SqlCommand(sql, conn)
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()

                        MsgBox("Successfully Saved.", MsgBoxStyle.Information, "")
                        btnview.PerformClick()
                    End If

                    disc = False
                Else

                    confirm.ShowDialog()
                    If disc = True Then
                        sql = "Update tbldiscount set status='1', datemodified=(SELECT GETDATE()), modifiedby='" & login2.username & "' where disid='" & lbldisid.Text & "'"
                        connect()
                        cmd = New SqlCommand(sql, conn)
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()

                        MsgBox("Successfully Saved.", MsgBoxStyle.Information, "")
                        btnview.PerformClick()
                    End If

                    disc = False
                End If
            Else
                MsgBox("Select only one.", MsgBoxStyle.Exclamation, "")
            End If

        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Public Sub selectchnged()
        If grddis.Rows(grddis.CurrentRow.Index).Cells(3).Value = "Active" Then
            btndeactivate.Text = " &Deactivate"
        Else
            btndeactivate.Text = " A&ctivate"
        End If
    End Sub

    Private Sub grddis_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grddis.SelectionChanged
        selectchnged()
    End Sub

    Public Sub chkrows()
        If grddis.Rows.Count = 0 Then
            btnupdate.Enabled = False
            btndeactivate.Enabled = False
        Else
            btnupdate.Enabled = True
            btndeactivate.Enabled = True
        End If
    End Sub

    Private Sub btnupdatedel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdatedel.Click
        Try
            If grddelch.SelectedRows.Count = 1 Or grddelch.SelectedCells.Count = 1 Then
                If btnupdatedel.Text = "   Update" Then
                    If grddelch.Rows(grddelch.CurrentRow.Index).Cells(3).Value = "Deactivated" Then
                        MsgBox("Cannot update deactivated range.", MsgBoxStyle.Exclamation, "")
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If

                    lbldelid.Text = grddelch.Rows(grddelch.CurrentRow.Index).Cells(0).Value
                    lblrange.Text = grddelch.Rows(grddelch.CurrentRow.Index).Cells(1).Value
                    txtrange.Text = grddelch.Rows(grddelch.CurrentRow.Index).Cells(1).Value
                    txtdel.Text = grddelch.Rows(grddelch.CurrentRow.Index).Cells(2).Value
                    grddelch.Enabled = False
                    btnupdatedel.Text = "   Save"
                    btncanceldel.Enabled = True
                    btnadddel.Enabled = False
                    btndeacdel.Enabled = False
                    btnviewdel.Enabled = False
                    btnsearchdel.Enabled = False
                    txtrange.Focus()
                Else
                    'update
                    If Trim(txtrange.Text) = "" Or Trim(txtdel.Text) = "" Then
                        MsgBox("Complate the fields.", MsgBoxStyle.Exclamation, "")
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If

                    sql = "Select * from tbldeliverych where range='" & Trim(txtrange.Text) & "' and delid<>'" & Trim(lbldelid.Text) & "'"
                    connect()
                    cmd = New SqlCommand(sql, conn)
                    dr = cmd.ExecuteReader
                    If dr.Read Then
                        MsgBox(Trim(txtrange.Text) & " is already exist.", MsgBoxStyle.Exclamation, "")
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    dr.Dispose()
                    cmd.Dispose()

                    confirm.ShowDialog()
                    If disc = True Then
                        sql = "Update tbldeliverych set range='" & Trim(txtrange.Text) & "',charge='" & Trim(txtdel.Text) & "', datemodified=(SELECT GETDATE())', modifiedby='" & login2.username & "' where delid='" & Val(lbldelid.Text) & "'"
                        connect()
                        cmd = New SqlCommand(sql, conn)
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()

                        MsgBox("Successfully Saved.", MsgBoxStyle.Information, "")
                    End If

                    btnupdatedel.Text = "   Update"
                    grddelch.Enabled = True
                    btncanceldel.PerformClick()
                    btncanceldel.Enabled = False
                    refdel()
                    disc = False
                End If
            End If
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Public Sub refdel()
        Try
            grddelch.Rows.Clear()
            txtdel.Text = ""
            txtrange.Text = ""

            sql = "Select * from tbldeliverych"
            connect()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            While dr.Read
                If dr("status") = 1 Then
                    stat = "Active"
                Else
                    stat = "Deactivated"
                End If
                grddelch.Rows.Add(dr("delid"), dr("range").ToString, dr("charge"), stat)
            End While
            dr.Dispose()
            cmd.Dispose()

            If grddelch.Rows.Count = 0 Then
                lbldelid.Text = ""
                txtdel.Text = ""
            End If

        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Private Sub btncanceldel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncanceldel.Click
        btnadddel.Enabled = True
        btndeacdel.Enabled = True
        btnviewdel.Enabled = True
        btnsearchdel.Enabled = True
        btnupdatedel.Text = "   Update"
        grddelch.Enabled = True
        disc = False
        refdel()
        btncanceldel.Enabled = False
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        btnupdate.Text = "   &Update"
        btnsearch.Enabled = True
        btnadd.Enabled = True
        btndeactivate.Enabled = True
        btnupdatedel.Enabled = True
        btncancel.Enabled = False
        txtdis.Text = ""
        txtamt.Text = ""
        txtdis.Focus()
    End Sub

    Private Sub txtamt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtamt.KeyPress
        If Asc(e.KeyChar) = Windows.Forms.Keys.Enter And Trim(txtdis.Text) <> "" And Trim(txtamt.Text) <> "" And btnupdate.Text = "&Update" Then
            btnadd.PerformClick()
        ElseIf Asc(e.KeyChar) = Windows.Forms.Keys.Enter And Trim(txtdis.Text) <> "" And Trim(txtamt.Text) <> "" And btnupdate.Text <> "&Update" Then
            btnupdate.PerformClick()
        End If
    End Sub

    Private Sub txtamt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtamt.Leave
        If IsNumeric(Trim(txtamt.Text)) = False And Trim(txtamt.Text) <> "" Then
            MsgBox("Invalid input.", MsgBoxStyle.Exclamation, "")
            txtamt.Text = ""
        End If
    End Sub

    Private Sub txtamt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtamt.TextChanged
        Dim charactersDisallowed As String = "0123456789."
        Dim theText As String = txtamt.Text
        Dim Letter As String
        Dim SelectionIndex As Integer = txtamt.SelectionStart
        Dim Change As Integer

        For x As Integer = 0 To txtamt.Text.Length - 1
            Letter = txtamt.Text.Substring(x, 1)
            If Not charactersDisallowed.Contains(Letter) Then
                theText = theText.Replace(Letter, String.Empty)
                Change = 1
            End If
        Next

        txtamt.Text = theText
        txtamt.Select(SelectionIndex - Change, 0)

        If Trim(txtamt.Text) <> "" Then
            btnsearch.Enabled = False
        Else
            btnsearch.Enabled = True
        End If
    End Sub

    Private Sub txtdel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdel.KeyPress
        If Asc(e.KeyChar) = Windows.Forms.Keys.Enter Then
            btnupdatedel.PerformClick()
        End If
    End Sub

    Private Sub txtdel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdel.TextChanged
        Dim charactersDisallowed As String = "0123456789."
        Dim theText As String = txtdel.Text
        Dim Letter As String
        Dim SelectionIndex As Integer = txtdel.SelectionStart
        Dim Change As Integer

        For x As Integer = 0 To txtdel.Text.Length - 1
            Letter = txtdel.Text.Substring(x, 1)
            If Not charactersDisallowed.Contains(Letter) Then
                theText = theText.Replace(Letter, String.Empty)
                Change = 1
            End If
        Next

        txtdel.Text = theText
        txtdel.Select(SelectionIndex - Change, 0)

        If (Trim(txtdel.Text) <> "" Or Trim(txtrange.Text) <> "") And btnupdatedel.Text = "Update" Then
            btncanceldel.Enabled = True
        ElseIf (Trim(txtdel.Text) = "" And Trim(txtrange.Text) = "") And btnupdatedel.Text = "Update" Then
            btncanceldel.Enabled = False
        End If
    End Sub

    Private Sub btnviewdel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewdel.Click
        refdel()
    End Sub

    Private Sub txtrange_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtrange.TextChanged
        Dim charactersDisallowed As String = "'"
        Dim theText As String = txtrange.Text
        Dim Letter As String
        Dim SelectionIndex As Integer = txtrange.SelectionStart
        Dim Change As Integer

        For x As Integer = 0 To txtrange.Text.Length - 1
            Letter = txtrange.Text.Substring(x, 1)
            If charactersDisallowed.Contains(Letter) Then
                theText = theText.Replace(Letter, String.Empty)
                Change = 1
            End If
        Next

        txtrange.Text = theText
        txtrange.Select(SelectionIndex - Change, 0)

        If (Trim(txtdel.Text) <> "" Or Trim(txtrange.Text) <> "") And btnupdatedel.Text = "Update" Then
            btncanceldel.Enabled = True
        ElseIf (Trim(txtdel.Text) = "" And Trim(txtrange.Text) = "") And btnupdatedel.Text = "Update" Then
            btncanceldel.Enabled = False
        End If
    End Sub

    Private Sub btnadddel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadddel.Click
        Try
            'check if complete fields
            If Trim(txtrange.Text) <> "" And Trim(txtdel.Text) <> "" Then
                confirm.ShowDialog()
                If disc = True Then
                    'insert
                    sql = "Insert into tbldeliverych (range, charge, datecreated, createdby, datemodified, modifiedby, status) values ('" & Trim(txtrange.Text) & "','" & Val(txtdel.Text) & "',(SELECT GETDATE()), '" & login2.username & "',(SELECT GETDATE()), '" & login2.username & "','1')"
                    connect()
                    cmd = New SqlCommand(sql, conn)
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()

                    MsgBox("Successfully Added.", MsgBoxStyle.Information, "")
                    btncanceldel.PerformClick()
                End If
            Else
                MsgBox("Complate the fields.", MsgBoxStyle.Exclamation, "")
                txtrange.Focus()
            End If
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Private Sub btnsearchdel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearchdel.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If Trim(txtrange.Text) = "" Then
                grddelch.Rows.Clear()
                MsgBox("Input Km range first.", MsgBoxStyle.Exclamation, "")
                txtrange.Text = ""
                txtrange.Focus()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            sql = "Select * from tbldeliverych where range like '" & Trim(txtrange.Text) & "%'"
            connect()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            If dr.Read Then
                grddelch.Rows.Clear()
                If dr("status") = 1 Then
                    stat = "Active"
                Else
                    stat = "Deactivated"
                End If
                grddelch.Rows.Add(dr("delid"), dr("range"), dr("charge"), stat)
            Else
                MsgBox("Cannot found " & Trim(txtdis.Text), MsgBoxStyle.Critical, "")
            End If
            dr.Dispose()
            cmd.Dispose()

            txtdel.Text = ""
            txtrange.Text = ""
            txtrange.Focus()
            Me.Cursor = Cursors.Default
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Private Sub btndeacdel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndeacdel.Click
        Try
            If grddelch.SelectedRows.Count = 1 Or grddelch.SelectedCells.Count = 1 Then
                lbldelid.Text = grddelch.Rows(grddelch.CurrentRow.Index).Cells(0).Value
                If btndeacdel.Text = "Deactivate" Then
                    confirm.ShowDialog()
                    If disc = True Then
                        sql = "Update tbldeliverych set status='0', datemodified=(SELECT GETDATE()), modifiedby='" & login2.username & "' where delid='" & lbldelid.Text & "'"
                        connect()
                        cmd = New SqlCommand(sql, conn)
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()

                        MsgBox("Successfully Saved.", MsgBoxStyle.Information, "")
                        btnviewdel.PerformClick()
                    End If

                    disc = False
                Else
                    confirm.ShowDialog()
                    If disc = True Then
                        sql = "Update tbldeliverych set status='1', datemodified=(SELECT GETDATE()), modifiedby='" & login2.username & "' where delid='" & lbldelid.Text & "'"
                        connect()
                        cmd = New SqlCommand(sql, conn)
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()

                        MsgBox("Successfully Saved.", MsgBoxStyle.Information, "")
                        btnviewdel.PerformClick()
                    End If

                    disc = False
                End If
            Else
                MsgBox("Select only one.", MsgBoxStyle.Exclamation, "")
            End If

        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Private Sub grddelch_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grddelch.SelectionChanged
        If grddelch.Rows(grddelch.CurrentRow.Index).Cells(3).Value = "Active" Then
            btndeacdel.Text = "&Deactivate"
        Else
            btndeacdel.Text = "A&ctivate"
        End If
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class