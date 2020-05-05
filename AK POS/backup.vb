Imports System.IO
Imports System.Data.SqlClient
Imports System.Drawing

Public Class backup
    Dim strconn As String = login.ss
    Dim conn As New SqlConnection(strconn)

    Dim path As String
    Public bckup As Boolean = False

    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function

    Private Sub btnback_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnback.Click
        Try
            If txtpath.Text = "" And Trim(txtfile.Text) = "" Then
                MsgBox("Complete the fields.", MsgBoxStyle.Exclamation, "")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            confirm.ShowDialog()
            If bckup = False Then
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            conn.Open()

            If chkcopy.Checked = True Then
                Dim cmd1 As New SqlCommand
                cmd1.CommandType = CommandType.Text
                'cmd1.CommandText = "BACKUP DATABASE AKPOS TO DISK='" & txtpath.Text & "\" & Trim(txtfile.Text) & ".bak'"
                cmd1.CommandText = "BACKUP DATABASE pos TO DISK=N'" & txtpath.Text & "\" & Trim(txtfile.Text) & ".bak' WITH COPY_ONLY"
                cmd1.Connection = conn
                cmd1.ExecuteNonQuery()
            Else
                Dim cmd As New SqlCommand
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "BACKUP DATABASE pos TO DISK='" & Application.StartupPath & "\" & Trim(txtfile.Text) & ".bak'"
                cmd.Connection = conn
                cmd.ExecuteNonQuery()
            End If

            MsgBox("Backup Successfully.", MsgBoxStyle.Information, "")

            bckup = False
            Me.Close()
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btnbrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbrowse.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
                txtpath.Text = FolderBrowserDialog1.SelectedPath
            Else
                btncancel.PerformClick()
            End If
            Me.Cursor = Cursors.Default
            txtfile.Focus()
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub backup_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        txtpath.Text = ""
        txtfile.Text = ""
        btnbrowse.Focus()
    End Sub

    Private Sub backup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        path = (Microsoft.VisualBasic.Left(Application.StartupPath, Len(Application.StartupPath) - 9))
        btnbrowse.Focus()
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        txtpath.Text = ""
        txtfile.Text = ""
        btnbrowse.Focus()
    End Sub

    Private Sub txtfile_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfile.KeyPress
        If Asc(e.KeyChar) = Windows.Forms.Keys.Enter Then
            btnback.PerformClick()
        End If
    End Sub

    Private Sub txtfile_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtfile.Leave
        btnback.Focus()
    End Sub

    Private Sub txtfile_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtfile.TextChanged
        Dim charactersDisallowed As String = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ 0123456789"
        Dim theText As String = txtfile.Text
        Dim Letter As String
        Dim SelectionIndex As Integer = txtfile.SelectionStart
        Dim Change As Integer

        For x As Integer = 0 To txtfile.Text.Length - 1
            Letter = txtfile.Text.Substring(x, 1)
            If Not charactersDisallowed.Contains(Letter) Then
                theText = theText.Replace(Letter, String.Empty)
                Change = 1
            End If
        Next

        txtfile.Text = theText
        txtfile.Select(SelectionIndex - Change, 0)
    End Sub
End Class