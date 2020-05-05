Imports System.IO
Imports System.Data.SqlClient

Public Class invreport
    Dim strconn As String = login.ss
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim sql As String
    Public ctr As Boolean = False


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

    Private Sub invreport_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        invreportprev.Close()
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub invreport_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        ctr = False
    End Sub
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
    Private Sub invreport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dateday.MaxDate = getSystemDate()
    End Sub

    Private Sub btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            invreportprev.condition = " invdate='" & Format(dateday.Value, "MM/dd/yyyy") & "'"

            sql = "Select * from tblinvsum where" & invreportprev.condition
            connect()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            If dr.Read Then
                Me.Cursor = Cursors.WaitCursor
                If ctr = True Then
                    invreportprev.ShowDialog()
                    invreportprev.WindowState = FormWindowState.Normal
                    Me.Cursor = Cursors.Default
                    Me.Close()
                    Exit Sub
                End If
                '    invreportprev.MdiParent = mdiform
                invreportprev.Show()
                invreportprev.WindowState = FormWindowState.Maximized
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
        Me.Close()
    End Sub
End Class