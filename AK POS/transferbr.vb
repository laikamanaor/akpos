Imports System.IO
Imports System.Data.SqlClient

Public Class transferbr
    Dim strconn As String = login.ss
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim sql As String


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

    Private Sub transferbr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cmbbranch.Items.Clear()

            sql = "Select * from tblbranch where status='1' order by branch"
            connect()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            While dr.Read
                cmbbranch.Items.Add(dr("branch"))
            End While
            dr.Dispose()
            cmd.Dispose()

            If cmbbranch.Items.Count = 0 Then
                MsgBox("No Record Found. Add branch name first.", MsgBoxStyle.Critical, "")
                mainmenu.rbtake.Checked = True
                Me.Close()
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

    Private Sub btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
        If cmbbranch.SelectedItem = "" Then
            MsgBox("Select branch name.", MsgBoxStyle.Exclamation, "")
        Else
            mainmenu.lblbranch.Text = cmbbranch.SelectedItem
            Me.Close()
        End If
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        mainmenu.rbdine.Checked = True
        Me.Close()
    End Sub
End Class