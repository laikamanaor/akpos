Imports System.Data.SqlClient
Imports System.IO
Public Class cashoutsap

    Dim strconn As String = login.ss
    Dim con As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim adptr As New SqlDataAdapter

    Public creditnum As String = ""

    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function

    Private Sub cashoutsap_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            con.Open()
            cmd = New SqlCommand("SELECT sap,remarks FROM tblcreditslogs WHERE creditnum=@creditnum", con)
            cmd.Parameters.AddWithValue("@creditnum", creditnum)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                lblsap.Text = CStr(rdr("sap"))
                txtremarks.Text = CStr(rdr("remarks"))
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class