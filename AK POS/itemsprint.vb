Imports System.Data.SqlClient
Imports CrystalDecisions
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows.Forms

Public Class itemsprint
    Dim strconn As String = login.ss
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim sql As String

    Dim dscmd As SqlDataAdapter
    Dim sqlquery As String

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

    Private Sub itemsprint_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        btnok.Focus()
    End Sub

    Private Sub itemsprint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmb.SelectedIndex = 1
    End Sub

    Private Sub btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            If cmb.SelectedIndex = 0 Then
                itemsprintprev.condition = " order by category,itemcode"
            ElseIf cmb.SelectedIndex = 1 Then
                itemsprintprev.condition = " where discontinued='0' order by category,itemcode"
            ElseIf cmb.SelectedIndex = 2 Then
                itemsprintprev.condition = " where discontinued='1' order by category,itemcode"
            End If

            sql = "Select * from tblitems " & itemsprintprev.condition
            connect()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            If dr.Read Then
                Me.Cursor = Cursors.WaitCursor
                '     itemsprintprev.MdiParent = mdiform
                itemsprintprev.Show()
                itemsprintprev.WindowState = FormWindowState.Maximized
                Me.Cursor = Cursors.Default
                Me.Close()
            Else
                MsgBox("No Found Record.", MsgBoxStyle.Critical, "")
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

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        cmb.SelectedIndex = 1
        Me.Close()
    End Sub
End Class