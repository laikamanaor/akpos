Imports System.IO
Imports System.Data.SqlClient

Public Class bundle
    Dim strconn As String = login.ss
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim sql As String

    Public yez As Boolean = False


    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function
    Public Function getSystemDate() As DateTime
        Try
            Dim dt As New DateTime()
            connect()
            cmd = New SqlCommand("SELECT GETDATE()", conn)
            dr = cmd.ExecuteReader()
            While dr.Read
                dt = CDate(dr(0).ToString)
            End While
            disconnect()
            Return dt
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            disconnect()
        End Try
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

    Private Sub bundle_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        txtname.Text = ""
        txtbased.Text = ""
        lblcode.Text = ""
        lblid.Text = ""
        lblprice.Text = ""
        Me.Dispose()
    End Sub

    Private Sub bundle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnrefresh.PerformClick()
        If grdgroup.Rows.Count = 0 Then
            btnupdate.Enabled = False
            btndeactivate.Enabled = False
        Else
            btnupdate.Enabled = True
            btndeactivate.Enabled = True
        End If
    End Sub

    Private Sub btnname_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnname.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            bundletxt.btn = "btnname"
            bundletxt.cmbcat.Focus()
            bundletxt.ShowDialog()

            If txtname.Text <> "" Or txtbased.Text <> "" Then
                btncancel.Enabled = True
            Else
                btncancel.Enabled = False
            End If


            sql = "Select * from tblgroupdisc where itemname='" & txtname.Text & "'"
            connect()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            If dr.Read Then
                MsgBox(txtname.Text & " is already exist.", MsgBoxStyle.Exclamation, "")
                lblcode.Text = ""
                txtname.Text = ""
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            dr.Dispose()
            cmd.Dispose()

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

    Private Sub btnbased_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbased.Click
        bundletxt.btn = "btnbased"
        bundletxt.ShowDialog()
    End Sub

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If txtname.Text <> "" And txtbased.Text <> "" Then
                'check dapat di magkaparehas
                If txtname.Text = txtbased.Text Then
                    MsgBox("Invalid input.", MsgBoxStyle.Critical, "")
                    btncancel.PerformClick()
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If

                Dim a As String = MsgBox("Are you sure you want to add?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "")
                If a = vbYes Then
                    Me.Cursor = Cursors.WaitCursor
                    confirm.ShowDialog()
                    If yez = True Then
                        sql = "Insert into tblgroupdisc (itemcode,itemname,basedname,basedprice,datecreated,createdby,datemodified,modifiedby,status)values('" & lblcode.Text & "','" & txtname.Text & "','" & txtbased.Text & "','" & lblprice.Text & "',(SELECT GETDATE()),'" & login.cashier & "',(SELECT GETDATE()),'" & login.cashier & "','1')"
                        connect()
                        cmd = New SqlCommand(sql, conn)
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()

                        MsgBox("Successfully Added.", MsgBoxStyle.Information, "")

                        btnrefresh.PerformClick()
                    End If
                    yez = False
                End If
                btncancel.PerformClick()

            Else
                MsgBox("Complete the fields.", MsgBoxStyle.Exclamation, "")
                Me.Cursor = Cursors.Default
            End If

            Me.Cursor = Cursors.Default

            If grdgroup.Rows.Count = 0 Then
                btnupdate.Enabled = False
                btndeactivate.Enabled = False
            Else
                btnupdate.Enabled = True
                btndeactivate.Enabled = True
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

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            grdgroup.Rows.Clear()

            sql = "Select * from tblgroupdisc order by itemcode"
            connect()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            While dr.Read
                Dim stat As String = ""
                If dr("status").ToString = "1" Then
                    stat = "Active"
                Else
                    stat = "Deactivated"
                End If
                grdgroup.Rows.Add(dr("systemid"), dr("itemcode"), dr("itemname"), dr("basedname"), dr("basedprice"), stat)
            End While
            dr.Dispose()
            cmd.Dispose()

            btncancel.PerformClick()

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

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        txtname.Text = ""
        txtbased.Text = ""
        lblcode.Text = ""
        lblprice.Text = ""
        lblid.Text = ""
        btnupdate.Text = "&Update"
        btnadd.Enabled = True
        btndeactivate.Enabled = True
        btncancel.Enabled = False
        grdgroup.Enabled = True
    End Sub

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            If grdgroup.SelectedRows.Count = 1 Or grdgroup.SelectedCells.Count = 1 Then
                If btnupdate.Text = "&Update" Then
                    If grdgroup.Rows(grdgroup.CurrentRow.Index).Cells(5).Value.ToString = "Deactivated" Then
                        MsgBox("Cannot update if status is deactivated.", MsgBoxStyle.Exclamation, "")
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    lblid.Text = grdgroup.Rows(grdgroup.CurrentRow.Index).Cells(0).Value
                    lblcode.Text = grdgroup.Rows(grdgroup.CurrentRow.Index).Cells(1).Value
                    txtname.Text = grdgroup.Rows(grdgroup.CurrentRow.Index).Cells(2).Value
                    txtbased.Text = grdgroup.Rows(grdgroup.CurrentRow.Index).Cells(3).Value
                    lblprice.Text = grdgroup.Rows(grdgroup.CurrentRow.Index).Cells(4).Value

                    btnadd.Enabled = False
                    btndeactivate.Enabled = False
                    btnupdate.Text = "&Save"
                    btncancel.Enabled = True

                    grdgroup.Enabled = False
                Else
                    'check if complete fields
                    If txtname.Text = "" Or txtbased.Text = "" Then
                        MsgBox("Complete the fields.", MsgBoxStyle.Exclamation, "")
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If

                    If txtname.Text = txtbased.Text Then
                        MsgBox("Invalid input.", MsgBoxStyle.Critical, "")
                        lblcode.Text = grdgroup.Rows(grdgroup.CurrentRow.Index).Cells(1).Value
                        txtname.Text = grdgroup.Rows(grdgroup.CurrentRow.Index).Cells(2).Value
                        txtbased.Text = grdgroup.Rows(grdgroup.CurrentRow.Index).Cells(3).Value
                        lblprice.Text = grdgroup.Rows(grdgroup.CurrentRow.Index).Cells(4).Value
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If

                    'check first if meron ng itemname na ganun na iba ung systemid nya ibig sabihin ung itemname ung pinalitan
                    sql = "Select * from tblgroupdisc where itemname='" & txtname.Text & "' and systemid<>'" & lblid.Text & "'"
                    connect()
                    cmd = New SqlCommand(sql, conn)
                    dr = cmd.ExecuteReader
                    If dr.Read Then
                        MsgBox(txtname.Text & " is already exist.", MsgBoxStyle.Exclamation, "")
                        lblcode.Text = grdgroup.Rows(grdgroup.CurrentRow.Index).Cells(1).Value
                        txtname.Text = grdgroup.Rows(grdgroup.CurrentRow.Index).Cells(2).Value
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    dr.Dispose()
                    cmd.Dispose()

                    Dim a As String = MsgBox("Are you sure you want to update?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2)
                    If a = vbYes Then
                        confirm.ShowDialog()
                        If yez = True Then
                            sql = "Update tblgroupdisc set itemcode='" & lblcode.Text & "', itemname='" & txtname.Text & "', basedname='" & txtbased.Text & "', basedprice='" & lblprice.Text & "', datemodified='" & Date.Now & "', modifiedby='" & login.cashier & "' where systemid='" & lblid.Text & "'"
                            connect()
                            cmd = New SqlCommand(sql, conn)
                            cmd.ExecuteNonQuery()
                            cmd.Dispose()

                            MsgBox("Successfully Saved.", MsgBoxStyle.Information, "")
                            btnrefresh.PerformClick()

                        End If
                        yez = False
                    End If


                    btncancel.PerformClick()
                End If

            Else
                MsgBox("Select only one", MsgBoxStyle.Exclamation, "")
                btnrefresh.PerformClick()
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
            If grdgroup.SelectedRows.Count = 1 Or grdgroup.SelectedCells.Count = 1 Then
                lblid.Text = grdgroup.Rows(grdgroup.CurrentRow.Index).Cells(0).Value
                If btndeactivate.Text = "&Deactivate" Then
                    Dim a As String = MsgBox("Are you sure you want to deactivate?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2)
                    If a = vbYes Then
                        confirm.ShowDialog()
                        If yez = True Then
                            sql = "Update tblgroupdisc set status='0', datemodified='" & Date.Now & "', modifiedby='" & login.cashier & "' where systemid='" & lblid.Text & "'"
                            connect()
                            cmd = New SqlCommand(sql, conn)
                            cmd.ExecuteNonQuery()
                            cmd.Dispose()

                            MsgBox("Successfully Saved.", MsgBoxStyle.Information, "")
                            btnrefresh.PerformClick()
                        End If
                        yez = False
                    End If
                Else
                    'check first if ung itemname and basedname are all active / not discontinued item
                    Dim iname As String = grdgroup.Rows(grdgroup.CurrentRow.Index).Cells(2).Value
                    Dim bname As String = grdgroup.Rows(grdgroup.CurrentRow.Index).Cells(3).Value
                    sql = "Select * from tblitems where itemname='" & iname & "' and discontinued='1'"
                    connect()
                    cmd = New SqlCommand(sql, conn)
                    dr = cmd.ExecuteReader
                    If dr.Read Then
                        MsgBox("Cannot Activate. " & iname & " is slready discontinued item.", MsgBoxStyle.Exclamation, "")
                        Exit Sub
                    End If
                    dr.Dispose()
                    cmd.Dispose()

                    sql = "Select * from tblitems where itemname='" & bname & "' and discontinued='1'"
                    connect()
                    cmd = New SqlCommand(sql, conn)
                    dr = cmd.ExecuteReader
                    If dr.Read Then
                        MsgBox("Cannot Activate. " & bname & " is slready discontinued item.", MsgBoxStyle.Exclamation, "")
                        Exit Sub
                    End If
                    dr.Dispose()
                    cmd.Dispose()


                    Dim a As String = MsgBox("Are you sure you want to activate?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2)
                    If a = vbYes Then
                        confirm.ShowDialog()
                        If yez = True Then
                            sql = "Update tblgroupdisc set status='1', datemodified='" & Date.Now & "', modifiedby='" & login.cashier & "' where systemid='" & lblid.Text & "'"
                            connect()
                            cmd = New SqlCommand(sql, conn)
                            cmd.ExecuteNonQuery()
                            cmd.Dispose()

                            MsgBox("Successfully Saved.", MsgBoxStyle.Information, "")
                            btnrefresh.PerformClick()
                        End If
                        yez = False
                    End If
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

    Private Sub grdgroup_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdgroup.SelectionChanged
        If grdgroup.Rows(grdgroup.CurrentRow.Index).Cells(5).Value = "Active" Then
            btndeactivate.Text = "&Deactivate"
        Else
            btndeactivate.Text = "A&ctivate"
        End If
    End Sub
End Class