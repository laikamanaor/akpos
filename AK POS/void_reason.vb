Imports System.Data.SqlClient
Imports System.IO
Imports AK_POS.connection_class
Public Class void_reason
    Dim cc As New connection_class
    Dim strconn As String = cc.conString
    Dim con As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader

    Public ordernum As String = ""

    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function

    Private Sub void_reason_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            con.Open()
            cmd = New SqlCommand("SELECT ISNULL(reason,'NA') AS reason FROM tbltransaction2 WHERE ordernum=@ordernum;", con)
            cmd.Parameters.AddWithValue("@ordernum", ordernum)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                txtreason.Text = "- " & CStr(rdr("reason"))
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class