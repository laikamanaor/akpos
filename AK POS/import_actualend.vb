Imports System.IO
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Public Class import_actualend

    Dim path As String = ""

    Dim strconn As String = login.ss
    Dim con As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim adptr As New SqlDataAdapter
    Private Sub btnbrowse_Click(sender As Object, e As EventArgs) Handles btnbrowse.Click
        Try
            Dim con As System.Data.OleDb.OleDbConnection
            Dim ds As New DataSet
            Dim cmd As OleDbCommand
            Dim rdr As OleDbDataReader
            Dim opf As New OpenFileDialog()

            If opf.ShowDialog = Windows.Forms.DialogResult.OK Then
                Path = opf.FileName
                dgv.Rows.Clear()
                con = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" & path & "; Extended Properties=Excel 12.0;")
                con.Open()
                cmd = New OleDbCommand("SELECT * FROM [Sheet1$]", con)
                rdr = cmd.ExecuteReader
                While rdr.Read
                    dgv.Rows.Add(rdr(0), rdr(1), rdr(2))
                End While
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class