Imports System.IO
Imports System.Data.SqlClient

Public Class branch
    Dim strconn As String = login.ss
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim sql As String

    Public Shared brncnf As Boolean = False

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

    Private Sub branch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If login.wrkgrp = "Administrator" Then
            checkbranch.Visible = True
        Else
            checkbranch.Visible = False
        End If

        btnview.PerformClick()
    End Sub

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        Try
            'check if complete or meron ung branch name
            If Trim(txtbranchcode.Text) = "" Then
                MsgBox("Input Branch Code.", MsgBoxStyle.Exclamation, "")
                txtbranchcode.Focus()
            ElseIf Trim(txtgr.Text) = "" Then
                MsgBox("Input GR Code.", MsgBoxStyle.Exclamation, "")
                txtgr.Focus()
            ElseIf Trim(txtsales.Text) = "" Then
                MsgBox("Input Sales Code.", MsgBoxStyle.Exclamation, "")
                txtgr.Focus()
            ElseIf Trim(txtbranch.Text) <> "" Then
                brncnf = False
                confirm.ShowDialog()
                If brncnf = True Then
                    connect()
                    Dim main As Boolean = False
                    cmd = New SqlCommand("SELECT main FROM tblbranch", conn)
                    dr = cmd.ExecuteReader
                    While dr.Read
                        If dr("main") = 1 Then
                            main = True
                        End If
                    End While
                    cmd.Dispose()
                    dr.Dispose()
                    If main And checkbranch.Checked Then
                        MsgBox("You have already branch", MsgBoxStyle.Exclamation, "")
                        Exit Sub
                    Else
                        Dim m As Integer = 0
                        If checkbranch.Checked Then
                            m = 1
                        Else
                            m = 0
                        End If

                        sql = "Insert into tblbranch (branchcode,branch, address, remarks, datecreated, createdby, datemodified, status,main,gr,sales) values ('" & Trim(txtbranchcode.Text) & "','" & Trim(txtbranch.Text) & "', '" & Trim(txtaddress.Text) & "', '" & Trim(txtrems.Text) & "', (SELECT GETDATE()), '" & login.cashier & "',(SELECT GETDATE()), '1','" & m & "','" & txtgr.Text & "','" & txtsales.Text & "')"
                        TextBox1.Text = sql
                        cmd = New SqlCommand(sql, conn)
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()
                    End If

                    btncancel.PerformClick()
                    MsgBox("Successfully Added.", MsgBoxStyle.Information, "")
                    btnview.PerformClick()
                    txtgr.Text = ""
                    txtsales.Text = ""
                End If
            Else
                MsgBox("Input Branch name.", MsgBoxStyle.Exclamation, "")
                txtbranch.Focus()
            End If
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Private Sub txtbranch_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtbranch.Leave
        txtbranch.Text = StrConv(Trim(txtbranch.Text), VbStrConv.ProperCase)
    End Sub

    Private Sub txtbranch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbranch.TextChanged
        Dim charactersDisallowed As String = "'"
        Dim theText As String = txtbranch.Text
        Dim Letter As String
        Dim SelectionIndex As Integer = txtbranch.SelectionStart
        Dim Change As Integer

        For x As Integer = 0 To txtbranch.Text.Length - 1
            Letter = txtbranch.Text.Substring(x, 1)
            If charactersDisallowed.Contains(Letter) Then
                theText = theText.Replace(Letter, String.Empty)
                Change = 1
            End If
        Next

        txtbranch.Text = theText
        txtbranch.Select(SelectionIndex - Change, 0)

        If Trim(txtbranch.Text) <> "" Or Trim(txtaddress.Text) <> "" Or Trim(txtrems.Text) <> "" Then
            btncancel.Enabled = True
        Else
            btncancel.Enabled = False
        End If
    End Sub

    Private Sub txtaddress_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtaddress.TextChanged
        Dim charactersDisallowed As String = "'"
        Dim theText As String = txtaddress.Text
        Dim Letter As String
        Dim SelectionIndex As Integer = txtaddress.SelectionStart
        Dim Change As Integer

        For x As Integer = 0 To txtaddress.Text.Length - 1
            Letter = txtaddress.Text.Substring(x, 1)
            If charactersDisallowed.Contains(Letter) Then
                theText = theText.Replace(Letter, String.Empty)
                Change = 1
            End If
        Next

        txtaddress.Text = theText
        txtaddress.Select(SelectionIndex - Change, 0)

        If Trim(txtbranch.Text) <> "" Or Trim(txtaddress.Text) <> "" Or Trim(txtrems.Text) <> "" Then
            btncancel.Enabled = True
        Else
            btncancel.Enabled = False
        End If
    End Sub

    Private Sub txtrems_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtrems.TextChanged
        Dim charactersDisallowed As String = "'"
        Dim theText As String = txtrems.Text
        Dim Letter As String
        Dim SelectionIndex As Integer = txtrems.SelectionStart
        Dim Change As Integer

        For x As Integer = 0 To txtrems.Text.Length - 1
            Letter = txtrems.Text.Substring(x, 1)
            If charactersDisallowed.Contains(Letter) Then
                theText = theText.Replace(Letter, String.Empty)
                Change = 1
            End If
        Next

        txtrems.Text = theText
        txtrems.Select(SelectionIndex - Change, 0)

        If Trim(txtbranch.Text) <> "" Or Trim(txtaddress.Text) <> "" Or Trim(txtrems.Text) <> "" Then
            btncancel.Enabled = True
        Else
            btncancel.Enabled = False
        End If
    End Sub

    Private Sub btnview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.Click
        Try
            grdbranch.Rows.Clear()

            sql = "Select * from tblbranch order by branch"
            connect()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            While dr.Read
                Dim stat As String = ""
                If dr("status") = 1 Then
                    stat = "Active"
                Else
                    stat = "Deactivated"
                End If

                grdbranch.Rows.Add(dr("brid"), dr("branchcode"), dr("branch"), dr("gr"), dr("sales"), dr("address"), dr("remarks"), stat, dr("main"))
            End While
            dr.Dispose()
            cmd.Dispose()

            If grdbranch.Rows.Count = 0 Then
                MsgBox("No Record Found.", MsgBoxStyle.Critical, "")
                btnupdate.Enabled = False
                btndeactivate.Enabled = False
                btnsearch.Enabled = False
            Else
                btnupdate.Enabled = True
                btndeactivate.Enabled = True
                btnsearch.Enabled = True
            End If


            For index As Integer = 0 To grdbranch.Rows.Count - 1
                cmd = New SqlCommand("SELECT brid  FROM tblbranch WHERE branch=@bcode AND main='1';", conn)
                cmd.Parameters.AddWithValue("@bcode", grdbranch.Rows(index).Cells("branchname").Value)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    grdbranch.Rows(index).Cells("branchcode").Style.ForeColor = Color.Green
                    grdbranch.Rows(index).Cells("branchname").Style.ForeColor = Color.Green
                    grdbranch.Rows(index).Cells("address").Style.ForeColor = Color.Green

                    grdbranch.Rows(index).Cells("gr").Style.ForeColor = Color.Green
                    grdbranch.Rows(index).Cells("sales").Style.ForeColor = Color.Green

                    grdbranch.Rows(index).Cells("remarks").Style.ForeColor = Color.Green
                    grdbranch.Rows(index).Cells("status").Style.ForeColor = Color.Green
                End If
            Next

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

    Private Sub btnsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        Try
            If Trim(txtbranch.Text) <> "" Then
                grdbranch.Rows.Clear()

                sql = "Select * from tblbranch where branch like '" & Trim(txtbranch.Text) & "%' order by branch"
                connect()
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                While dr.Read
                    Dim stat As String = ""
                    If dr("status") = 1 Then
                        stat = "Active"
                    Else
                        stat = "Deactivated"
                    End If

                    grdbranch.Rows.Add(dr("brid"), dr("branchcode"), dr("branch"), dr("gr"), dr("sales"), dr("address"), dr("remarks"), stat, dr("main"))
                End While
                dr.Dispose()
                cmd.Dispose()

                If grdbranch.Rows.Count = 0 Then
                    MsgBox("No Record Found.", MsgBoxStyle.Critical, "")
                    btnupdate.Enabled = False
                    btndeactivate.Enabled = False
                Else
                    btnupdate.Enabled = True
                    btndeactivate.Enabled = True
                End If

            Else
                MsgBox("Input Branch name.", MsgBoxStyle.Exclamation, "")
                txtbranch.Focus()
            End If

            For index As Integer = 0 To grdbranch.Rows.Count - 1
                cmd = New SqlCommand("SELECT brid  FROM tblbranch WHERE branchcode=@bcode AND main='1';", conn)
                cmd.Parameters.AddWithValue("@bcode", grdbranch.Rows(index).Cells("branchcode").Value)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    grdbranch.Rows(index).Cells("branchcode").Style.ForeColor = Color.Green
                    grdbranch.Rows(index).Cells("branchname").Style.ForeColor = Color.Green
                    grdbranch.Rows(index).Cells("address").Style.ForeColor = Color.Green
                    grdbranch.Rows(index).Cells("remarks").Style.ForeColor = Color.Green
                    grdbranch.Rows(index).Cells("status").Style.ForeColor = Color.Green
                End If
            Next
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

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        txtaddress.Text = ""
        lblid.Text = ""
        txtbranchcode.Text = ""
        txtbranch.Text = ""
        txtrems.Text = ""
        btnupdate.Text = "   Update"
        btnsearch.Enabled = True
        btnadd.Enabled = True
        btnupdate.Enabled = True
        btndeactivate.Enabled = True
        btnview.Enabled = True
        grdbranch.Enabled = True
        btncancel.Enabled = False
        brncnf = False
    End Sub

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        Try
            If grdbranch.SelectedCells.Count = 1 Or grdbranch.SelectedRows.Count = 1 Then
                Dim id As String = "", branchcode As String = "", branchname As String = ""
                If btnupdate.Text = "   &Update" Then
                    lblid.Text = grdbranch.Rows(grdbranch.CurrentRow.Index).Cells("id").Value
                    txtbranchcode.Text = grdbranch.Rows(grdbranch.CurrentRow.Index).Cells("branchcode").Value
                    lblbr.Text = grdbranch.Rows(grdbranch.CurrentRow.Index).Cells("branchname").Value
                    txtbranch.Text = grdbranch.Rows(grdbranch.CurrentRow.Index).Cells("branchname").Value
                    txtaddress.Text = grdbranch.Rows(grdbranch.CurrentRow.Index).Cells("address").Value
                    txtrems.Text = grdbranch.Rows(grdbranch.CurrentRow.Index).Cells("remarks").Value

                    txtgr.Text = grdbranch.Rows(grdbranch.CurrentRow.Index).Cells("gr").Value
                    txtsales.Text = grdbranch.Rows(grdbranch.CurrentRow.Index).Cells("sales").Value

                    If grdbranch.CurrentRow.Cells("main").Value = 1 Then
                        checkbranch.Checked = True
                    Else
                        checkbranch.Checked = False
                    End If

                    txtbranch.Focus()

                    btnupdate.Text = "   &Save"
                    grdbranch.Enabled = False
                    btnadd.Enabled = False
                    btnsearch.Enabled = False
                    btndeactivate.Enabled = False
                    btnview.Enabled = False
                Else
                    If Trim(txtbranch.Text) <> "" Then
                        'save 
                        'check if may branch name n ganyan pero ibang brid
                        sql = "Select * from tblbranch where branch='" & Trim(txtbranch.Text) & "' and brid<>'" & lblid.Text & "'"
                        connect()
                        cmd = New SqlCommand(sql, conn)
                        dr = cmd.ExecuteReader
                        If dr.Read Then
                            MsgBox("Branch name is already exist.", MsgBoxStyle.Exclamation, "")
                            Exit Sub
                        End If
                        dr.Dispose()
                        cmd.Dispose()

                        'cmd = New SqlCommand("SELECT brid FROM tblbranch WHERE branch != '" & txtbranch.Text & "' AND main=1;", conn)
                        'dr = cmd.ExecuteReader
                        'If dr.Read Then
                        '    MsgBox("You have already branch.", MsgBoxStyle.Exclamation, "")
                        '    Exit Sub
                        'End If

                        brncnf = False
                        confirm.ShowDialog()
                        If brncnf = True Then
                            Dim m As Integer = If(checkbranch.Checked, 1, 0)

                            sql = "Update tblbranch set branchcode='" & Trim(txtbranchcode.Text) & "', branch='" & Trim(txtbranch.Text) & "', address='" & Trim(txtaddress.Text) & "', remarks='" & Trim(txtrems.Text) & "', datemodified=(SELECT GETDATE()), modifiedby='" & login.cashier & "',main='" & m & "',gr='" & txtgr.Text & "',sales='" & txtsales.Text & "' where brid='" & lblid.Text & "'"
                            connect()
                            cmd = New SqlCommand(sql, conn)
                            cmd.ExecuteNonQuery()
                            cmd.Dispose()

                            sql = "Update tbltransfer set branch='" & Trim(txtbranch.Text) & "' where branch='" & lblbr.Text & "'"
                            connect()
                            cmd = New SqlCommand(sql, conn)
                            cmd.ExecuteNonQuery()
                            cmd.Dispose()

                            MsgBox("Successfully Saved.", MsgBoxStyle.Information, "")

                            btnupdate.Text = "   &Update"
                            txtgr.Text = ""
                            txtsales.Text = ""
                            btncancel.PerformClick()
                            btnview.PerformClick()
                            brncnf = False
                        End If
                    Else
                        MsgBox("Input Branch name.", MsgBoxStyle.Exclamation, "")
                    End If
                End If
            Else
                MsgBox("Select Only one.", MsgBoxStyle.Exclamation, "")
            End If
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Private Sub btndeactivate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndeactivate.Click
        Try
            If grdbranch.SelectedCells.Count = 1 Or grdbranch.SelectedRows.Count = 1 Then
                If btndeactivate.Text = " &Deactivate" Then
                    Dim a As String = MsgBox("Are you sure you want to deactivate branch name?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "")
                    If a = vbYes Then
                        brncnf = False
                        confirm.ShowDialog()
                        If brncnf = True Then
                            sql = "Update tblbranch set status='0', datemodified=(SELECT GETDATE()),modifiedby='" & login.cashier & "' where brid='" & grdbranch.Rows(grdbranch.CurrentRow.Index).Cells(0).Value & "'"
                            connect()
                            cmd = New SqlCommand(sql, conn)
                            cmd.ExecuteNonQuery()
                            cmd.Dispose()

                            MsgBox("Successfully deactivated.", MsgBoxStyle.Information, "")
                            btnview.PerformClick()
                        End If
                    End If
                Else
                    Dim a As String = MsgBox("Are you sure you want to activate branch name.", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "")
                    If a = vbYes Then
                        brncnf = False
                        confirm.ShowDialog()
                        If brncnf = True Then
                            sql = "Update tblbranch set status='1', datemodified=(SELECT GETDATE()), modifiedby='" & login.cashier & "' where brid='" & grdbranch.Rows(grdbranch.CurrentRow.Index).Cells(0).Value & "'"
                            connect()
                            cmd = New SqlCommand(sql, conn)
                            cmd.ExecuteNonQuery()
                            cmd.Dispose()

                            MsgBox("Successfully activated.", MsgBoxStyle.Information, "")
                            btnview.PerformClick()
                        End If
                    End If
                End If
            Else
                MsgBox("Select Only One.", MsgBoxStyle.Exclamation, "")
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

    Private Sub grdbranch_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdbranch.SelectionChanged
        If grdbranch.Rows(grdbranch.CurrentRow.Index).Cells(5).Value = "Active" Then
            btndeactivate.Text = " &Deactivate"
        Else
            btndeactivate.Text = " A&ctivate"
        End If
    End Sub

    Private Sub btnimport_Click(sender As Object, e As EventArgs) Handles btnimport.Click
        Try
            Dim frm As New importbranch()
            frm.ShowDialog()
            btnview.PerformClick()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class