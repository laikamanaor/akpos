Imports System.IO
Imports System.Data.SqlClient
Imports System.Drawing
Imports AK_POS.connection_class
Public Class version
    Dim cc As New connection_class
    Dim strconn As String = cc.conString
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim sql As String

    Dim stat As String
    Public compscnf As Boolean = False

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
        If conn.State <> ConnectionState.Open Then
            conn.Close()
        End If
    End Sub

    Private Sub btnsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        Try
            If Trim(txtver.Text) = "" Then
                grdver.Rows.Clear()
                MsgBox("Input Version first.", MsgBoxStyle.Exclamation, "")
                txtver.Focus()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            grdver.Rows.Clear()
            sql = "Select * from tblversion where version like '" & Trim(txtver.Text) & "%'"
            connect()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            While dr.Read
                If dr("status") = 1 Then
                    stat = "Active"
                Else
                    stat = "Deactivated"
                End If
                grdver.Rows.Add(dr("systemid"), dr("version"), stat)
                txtver.Text = ""
            End While
            dr.Dispose()
            cmd.Dispose()
            conn.Close()

            If grdver.Rows.Count = 0 Then
                MsgBox("Cannot found " & Trim(txtver.Text), MsgBoxStyle.Critical, "")
                txtver.Text = ""
                txtver.Focus()
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

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        Try
            If login.neym <> "Administrator" And login.neym <> "Supervisor" And login.neym <> "Logistics Staff" Then
                MsgBox("Access denied!", MsgBoxStyle.Critical, "")
                Exit Sub
            End If

            If Trim(txtver.Text) <> "" Then
                sql = "Select * from tblversion where version='" & Trim(txtver.Text) & "'"
                connect()
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    MsgBox(Trim(txtver.Text) & " is already exist", MsgBoxStyle.Information, "")
                    btnupdate.Text = "&Update"
                    txtver.Text = ""
                    txtver.Focus()
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                dr.Dispose()
                cmd.Dispose()
                conn.Close()

                compscnf = False
                confirm.ShowDialog()
                If compscnf = True Then
                    sql = "Insert into tblversion (version, datecreated, createdby, datemodified, modifiedby, status) values('" & Trim(txtver.Text) & "',GetDate(),'" & login.cashier & "',GetDate(),'" & login.cashier & "','1')"
                    connect()
                    cmd = New SqlCommand(sql, conn)
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()
                    conn.Close()

                    MsgBox("Successfully Added", MsgBoxStyle.Information, "")
                    btnview.PerformClick()
                End If

                txtver.Text = ""
                txtver.Focus()
                compscnf = False
            Else
                MsgBox("Input version first", MsgBoxStyle.Exclamation, "")
                txtver.Focus()
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

    Private Sub btnview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.Click
        Try
            grdver.Rows.Clear()
            Dim stat As String = ""

            sql = "Select * from tblversion"
            connect()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            While dr.Read
                If dr("status") = 1 Then
                    stat = "Active"
                Else
                    stat = "Deactivated"
                End If
                grdver.Rows.Add(dr("systemid"), dr("version"), stat)
            End While
            dr.Dispose()
            cmd.Dispose()
            conn.Close()

            If grdver.Rows.Count = 0 Then
                btnupdate.Enabled = False
            Else
                btnupdate.Enabled = True
            End If

            btncancel.PerformClick()

        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Private Sub txtver_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtver.Leave
        txtver.Text = StrConv(txtver.Text, VbStrConv.ProperCase)
    End Sub

    Private Sub txtver_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtver.TextChanged
        If (Trim(txtver.Text) <> "") Then
            btncancel.Enabled = True
        ElseIf (Trim(txtver.Text) = "") And btnupdate.Text = "&Save" Then
            btncancel.Enabled = True
        Else
            btncancel.Enabled = False
        End If

        Dim charactersDisallowed As String = "'"
        Dim theText As String = txtver.Text
        Dim Letter As String
        Dim SelectionIndex As Integer = txtver.SelectionStart
        Dim Change As Integer

        For x As Integer = 0 To txtver.Text.Length - 1
            Letter = txtver.Text.Substring(x, 1)
            If charactersDisallowed.Contains(Letter) Then
                theText = theText.Replace(Letter, String.Empty)
                Change = 1
            End If
        Next

        txtver.Text = theText
        txtver.Select(SelectionIndex - Change, 0)
    End Sub

    Private Sub comps_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim a As String = MsgBox("Are you sure you want to close?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "")
        If a = vbYes Then
            'mdiform.Show()
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub comps_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnview.PerformClick()
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        txtver.Text = ""
        btnupdate.Text = "&Update"
        btnsearch.Enabled = True
        btndeactivate.Enabled = True
        btnadd.Enabled = True
        btncancel.Enabled = False
    End Sub

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        Try
            If login.neym <> "Administrator" And login.neym <> "Supervisor" And login.neym <> "Logistics Staff" Then
                MsgBox("Access denied!", MsgBoxStyle.Critical, "")
                Exit Sub
            End If

            If grdver.SelectedRows.Count = 1 Or grdver.SelectedCells.Count = 1 Then
                If btnupdate.Text = "&Update" Then
                    If grdver.Rows(grdver.CurrentRow.Index).Cells(2).Value = "Deactivated" Then
                        MsgBox("Cannot update deactivated version.", MsgBoxStyle.Exclamation, "")
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    lblcat.Text = grdver.Rows(grdver.CurrentRow.Index).Cells(1).Value
                    txtver.Text = grdver.Rows(grdver.CurrentRow.Index).Cells(1).Value
                    lblid.Text = grdver.Rows(grdver.CurrentRow.Index).Cells(0).Value
                    btnsearch.Enabled = False
                    btnadd.Enabled = False
                    btnupdate.Text = "&Save"
                    btncancel.Enabled = True
                    btndeactivate.Enabled = False
                Else
                    'update
                    If Trim(txtver.Text) = "" Then
                        Me.Cursor = Cursors.Default
                        MsgBox("version should not be empty.", MsgBoxStyle.Exclamation, "")
                        Exit Sub
                    End If

                    sql = "Select * from tblversion where version='" & Trim(txtver.Text) & "'"
                    connect()
                    cmd = New SqlCommand(sql, conn)
                    dr = cmd.ExecuteReader
                    If dr.Read Then
                        Me.Cursor = Cursors.Default
                        MsgBox(Trim(txtver.Text) & " is already exist", MsgBoxStyle.Information, "")
                        Exit Sub
                    End If
                    dr.Dispose()
                    cmd.Dispose()
                    conn.Close()

                    compscnf = False
                    confirm.ShowDialog()
                    If compscnf = True Then
                        If Trim(txtver.Text) <> Trim(lblcat.Text) Then
                            sql = "Update tblversion set version='" & Trim(txtver.Text) & "', datemodified=GetDate(), modifiedby='" & login.cashier & "' where systemid='" & lblid.Text & "'"
                            connect()
                            cmd = New SqlCommand(sql, conn)
                            cmd.ExecuteNonQuery()
                            cmd.Dispose()
                            conn.Close()

                            'update other tbl in database
                            sql = "Update tbllogin set version='" & Trim(txtver.Text) & "' where version='" & lblcat.Text & "'"
                            connect()
                            cmd = New SqlCommand(sql, conn)
                            cmd.ExecuteNonQuery()
                            cmd.Dispose()
                            conn.Close()

                        End If

                        MsgBox("Successfully Saved", MsgBoxStyle.Information, "")
                        btnview.PerformClick()
                    End If

                    btnupdate.Text = "&Update"
                    btnsearch.Enabled = True
                    btnadd.Enabled = True
                    btndeactivate.Enabled = True
                    btncancel.Enabled = False
                    txtver.Text = ""
                    txtver.Focus()
                    compscnf = False
                End If
            Else
                MsgBox("Select only one", MsgBoxStyle.Exclamation, "")
                btnview.PerformClick()
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

    Private Sub btndeactivate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndeactivate.Click
        Try
            If login.neym <> "Administrator" And login.neym <> "Supervisor" And login.neym <> "Logistics Staff" Then
                MsgBox("Access denied!", MsgBoxStyle.Critical, "")
                Exit Sub
            End If

            If grdver.SelectedRows.Count = 1 Or grdver.SelectedCells.Count = 1 Then
                lblid.Text = grdver.Rows(grdver.CurrentRow.Index).Cells(0).Value
                If btndeactivate.Text = "&Deactivate" Then
                    'check if theres item available status

                    compscnf = False
                    confirm.ShowDialog()
                    If compscnf = True Then
                        sql = "Update tblversion set status='0', datemodified=GetDate(), modifiedby='" & login.cashier & "' where systemid='" & lblid.Text & "'"
                        connect()
                        cmd = New SqlCommand(sql, conn)
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()
                        conn.Close()

                        MsgBox("Successfully Saved", MsgBoxStyle.Information, "")
                        btnview.PerformClick()
                    End If

                    compscnf = False
                Else
                    compscnf = False
                    confirm.ShowDialog()
                    If compscnf = True Then
                        sql = "Update tblversion set status='1', datemodified=GetDate(), modifiedby='" & login.cashier & "' where systemid='" & lblid.Text & "'"
                        connect()
                        cmd = New SqlCommand(sql, conn)
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()
                        conn.Close()

                        MsgBox("Successfully Saved", MsgBoxStyle.Information, "")
                        btnview.PerformClick()
                    End If

                    compscnf = False
                End If
            Else
                MsgBox("Select only one", MsgBoxStyle.Exclamation, "")
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

    Private Sub grdcomps_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdver.SelectionChanged
        If grdver.Rows(grdver.CurrentRow.Index).Cells(2).Value = "Active" Then
            btndeactivate.Text = "&Deactivate"
        Else
            btndeactivate.Text = "A&ctivate"
        End If
    End Sub
End Class