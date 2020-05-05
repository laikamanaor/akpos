Imports System.Data.SqlClient
Public Class samplee
    Dim lines = System.IO.File.ReadAllLines("connectionstring.txt")
    Dim strconn As String = lines(0)
    Dim con As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim adptr As New SqlDataAdapter
    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Try
            con.Open()
            cmd = New SqlCommand("SELECT itemname FROM tblorder GROUP BY itemname", con)
            adptr.SelectCommand = cmd
            Dim dt As New DataTable()
            adptr.Fill(dt)
            con.Close()
            For Each r0w As DataRow In dt.Rows
                con.Open()
                cmd = New SqlCommand("SELECT SUM(qty) FROM tblorder WHERE itemname='" & r0w("itemname") & "';", con)
                rdr = cmd.ExecuteReader
                While rdr.Read

                End While
                con.Close()
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class