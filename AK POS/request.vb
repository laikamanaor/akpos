Imports System.Data.SqlClient
Imports System.Text
Imports System.IO
Imports AK_POS.connection_class
Public Class request
    Dim cc As New connection_class
    Dim con As New SqlConnection(cc.conString)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader

    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function

    Public Sub loadLC()
        Try
            Dim auto As New AutoCompleteStringCollection()
            con.Open()
            cmd = New SqlCommand("SELECT username FROM tblusers WHERE status=1 AND workgroup='LC Accounting';", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                auto.Add(rdr("username"))
            End While
            con.Close()
            txtto.AutoCompleteCustomSource = auto
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub request_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadLC()
    End Sub

    Private Sub btnsend_Click(sender As Object, e As EventArgs) Handles btnsend.Click
        Try
            If String.IsNullOrEmpty(txtto.Text) And String.IsNullOrEmpty(txtrequest.Text) Then
                MessageBox.Show("Please fill all fields", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf String.IsNullOrEmpty(txtto.Text) Then
                MessageBox.Show("Sending To field is empty.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf String.IsNullOrEmpty(txtrequest.Text) Then
                MessageBox.Show("Request field is empty.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Dim z As Boolean = False
                con.Open()
                cmd = New SqlCommand("SELECT systemid FROM tblusers WHERE username=@username AND status=1;", con)
                cmd.Parameters.AddWithValue("@username", txtto.Text)
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    z = True
                End If
                con.Close()

                If z Then
                    con.Open()
                    cmd = New SqlCommand("INSERT INTO tblrequests (fromid,toid,description,datecreated,status) VALUES ((SELECT systemid FROM tblusers WHERE username=@user1),(SELECT systemid FROM tblusers WHERE username=@user2),@description,(SELECT GETDATE()),@status);", con)
                    cmd.Parameters.AddWithValue("@user1", login.username)
                    cmd.Parameters.AddWithValue("@user2", txtto.Text)
                    cmd.Parameters.AddWithValue("@description", txtrequest.Text)
                    cmd.Parameters.AddWithValue("@status", "Pending")
                    cmd.ExecuteNonQuery()
                    con.Close()
                    MessageBox.Show("Sent", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtrequest.Text = ""
                    txtto.Text = ""
                Else
                    MessageBox.Show("Account not found!", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class