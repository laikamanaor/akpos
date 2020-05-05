Imports System.Data.SqlClient
Imports System.IO
Imports AK_POS.connection_class
Public Class cancel_apdep
    Dim cc As New connection_class
    Dim con As New SqlConnection(cc.conString)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader

    Public num As String = ""

    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub cancel_apdep_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Try
            Dim c_by As String = "", c_date As String = "", c_reason As String = ""
            con.Open()
            cmd = New SqlCommand("SELECT date_cancelled,cancelled_by,remarks FROM tbladvancepayment WHERE apnum=@num", con)
            cmd.Parameters.AddWithValue("@num", num)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                c_by = rdr("cancelled_by")
                c_date = rdr("date_cancelled")
                c_reason = rdr("remarks")
            End If
            con.Close()
            lblby.Text = "- " & c_by
            lbldate.Text = "- " & c_date
            lblreason.Text = "- " & c_reason
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub cancel_apdep_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class