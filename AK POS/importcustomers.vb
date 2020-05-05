Imports System.IO
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Public Class importcustomers
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
                cmd = New OleDbCommand("SELECT * FROM [123$]", con)
                rdr = cmd.ExecuteReader
                While rdr.Read
                    dgvitems.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4))
                End While
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btnsubmit_Click(sender As Object, e As EventArgs) Handles btnsubmit.Click
        Try
            For index As Integer = 0 To dgvitems.RowCount - 1
                con.Open()
                cmd = New SqlCommand("INSERT INTO tblcustomers (name,contact_number,address,date,created_by,status,type,code) VALUES (@name,@contactnumber,@address,(SELECT GETDATE()),@created,1,@type,@code);", con)
                cmd.Parameters.AddWithValue("@name", dgvitems.Rows(index).Cells("namee").Value)
                cmd.Parameters.AddWithValue("@contactnumber", CStr(dgvitems.Rows(index).Cells("contactnumber").Value))
                cmd.Parameters.AddWithValue("@address", dgvitems.Rows(index).Cells("address").Value)
                cmd.Parameters.AddWithValue("@created", login.username)
                cmd.Parameters.AddWithValue("@type", dgvitems.Rows(index).Cells("type").Value)
                cmd.Parameters.AddWithValue("@code", dgvitems.Rows(index).Cells("code").Value)
                cmd.ExecuteNonQuery()
                con.Close()
            Next
            MessageBox.Show("Import Success", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try

    End Sub
End Class