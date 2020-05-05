Imports System.Data.SqlClient
Imports AK_POS.connection_class
Public Class pos_dialog
    Dim cc As New connection_class
    Dim con As New SqlConnection(cc.conString)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Public Shared ans As String = ""

    Private Sub btnretail_Click(sender As Object, e As EventArgs) Handles btnretail.Click
        ans = "Retail"
        Me.Hide()
    End Sub

    Private Sub btnwholesale_Click(sender As Object, e As EventArgs) Handles btnwholesale.Click
        ans = "Wholesale"
        Me.Hide()
    End Sub

    Private Sub btncoffeeshop_Click(sender As Object, e As EventArgs) Handles btncoffeeshop.Click
        ans = "Coffee Shop"
        Me.Hide()
    End Sub

    Private Sub pos_dialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim result As String = ""
            con.Open()
            cmd = New SqlCommand("SELECT postype FROM tblusers WHERE username=@username;", con)
            cmd.Parameters.AddWithValue("@username", login.username)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                result = rdr("postype")
            End If
            con.Close()

            ans = result
            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class