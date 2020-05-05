Imports System.IO
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Public Class importbranch

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
                path = opf.FileName
                dgvitems.Rows.Clear()
                con = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" & path & "; Extended Properties=Excel 12.0;")


                con.Open()
                cmd = New OleDbCommand("SELECT * FROM [Sheet1$]", con)
                rdr = cmd.ExecuteReader
                While rdr.Read
                    dgvitems.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5))
                End While
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btnsubmit_Click(sender As Object, e As EventArgs) Handles btnsubmit.Click
        For index As Integer = 0 To dgvitems.RowCount - 1
            con.Open()
            cmd = New SqlCommand("INSERT INTO tblbranch (branchcode,branch,gr,sales,address,remarks,datecreated,createdby,datemodified,modifiedby,status,main) VALUES (@code,@branch,@gr,@sales,@address,@remarks,(SELECT GETDATE()), @createdby,(SELECT GETDATE()), @modifiedby,1,0);", con)
            cmd.Parameters.AddWithValue("@code", dgvitems.Rows(index).Cells("branchcode").Value)
            cmd.Parameters.AddWithValue("@branch", dgvitems.Rows(index).Cells("branchname").Value)
            cmd.Parameters.AddWithValue("@gr", dgvitems.Rows(index).Cells("gr").Value)
            cmd.Parameters.AddWithValue("@sales", dgvitems.Rows(index).Cells("sales").Value)
            cmd.Parameters.AddWithValue("@address", dgvitems.Rows(index).Cells("address").Value)
            cmd.Parameters.AddWithValue("@remarks", dgvitems.Rows(index).Cells("remarks").Value)
            cmd.Parameters.AddWithValue("@createdby", login.username)
            cmd.Parameters.AddWithValue("@modifiedby", login.username)
            cmd.ExecuteNonQuery()
            con.Close()
            MessageBox.Show("Transaction Completed", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Next
    End Sub
End Class