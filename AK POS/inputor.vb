Imports System.IO
Imports System.Data.SqlClient

Public Class inputor
    Dim strconn As String = login.ss
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim sql As String

    Public cncel As Boolean = False

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

    Private Sub inputor_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        txt.Text = ""
        txt.Focus()
    End Sub

    Private Sub inputor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txt.Text = ""
        txt.Focus()
        cncel = False
    End Sub

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt.KeyPress
        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And Asc(e.KeyChar) <> 8 And Asc(e.KeyChar) <> 127 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt.TextChanged
        If Trim(txt.Text) <> "" And IsNumeric(Trim(txt.Text)) = True Then
            btnok.Enabled = True
        Else
            btnok.Enabled = False
        End If
    End Sub

    Private Sub btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
        'check first if existing na yung or number sa database
        sql = "Select ornum from tbltransaction where ornum='" & Trim(txt.Text) & "'"
        connect()
        cmd = New SqlCommand(sql, conn)
        dr = cmd.ExecuteReader
        If dr.Read Then
            MsgBox("OR# " & Trim(txt.Text) & " is already exist!", MsgBoxStyle.Exclamation, "")
            txt.Text = ""
            txt.Focus()
        Else
            cncel = False
            mainmenu.txtor.Text = Trim(txt.Text)
            Me.Close()
        End If
        dr.Dispose()
        cmd.Dispose()

        disconnect()
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        txt.Text = ""
        txt.Focus()
        cncel = True
        Me.Close()
    End Sub
End Class