Imports System.Data.SqlClient
Imports System.IO
Imports AK_POS.connection_class
Public Class downloadss
    Dim cc As New connection_class
    Dim strconn As String = cc.conString
    Dim con As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader

    Dim excel_path As String = "", selected_ As String = ""
    Dim pdf_path As String = ""
    Private Sub downloadss_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadReports()
    End Sub
    Public Sub loadReports()
        Try
            dgv.Rows.Clear()
            con.Open()
            cmd = New SqlCommand("SELECT description FROM tblreports WHERE status=1;", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                dgv.Rows.Add(rdr("description"))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub btnbrowse_Click(sender As Object, e As EventArgs) Handles btnbrowse.Click
        OpenFileDialog1.InitialDirectory = "C:\"
        OpenFileDialog1.Title = "Excel File"
        OpenFileDialog1.Filter = "Excel File|*.xlsx"
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            excel_path = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub btnupload_Click(sender As Object, e As EventArgs) Handles btnupload.Click
        upload("Excel", excel_path)
        loadReports()
    End Sub

    Public Sub upload(ByVal tayp As String, ByVal path As String)
        Try
            If String.IsNullOrEmpty(path) Then
                MessageBox.Show("Browse file first", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                'extract file name
                Dim filename() As String = OpenFileDialog1.FileName.Split("\")
                Dim fname As String = filename.Last.ToString

                'read file data
                Dim fileContent() As Byte

                Dim FStream As New FileStream(OpenFileDialog1.FileName, FileMode.Open)
                Dim BReader As New BinaryReader(FStream)

                fileContent = BReader.ReadBytes(FStream.Length)
                FStream.Close()
                BReader.Close()

                Dim serverDate As String = getSystemDate.ToString("MM/dd/yyyy"), result As Boolean = False

                con.Open()
                cmd = New SqlCommand("SELECT id FROM tblfiles WHERE subtype=@subtype AND type=@type AND CAST(datecreated AS date)=@date", con)
                cmd.Parameters.AddWithValue("@subtype", selected_)
                cmd.Parameters.AddWithValue("@type", tayp)
                cmd.Parameters.AddWithValue("@date", serverDate)
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    result = True
                End If
                con.Close()

                If result Then
                    MessageBox.Show(selected_ & " is aready upload", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    clear_path()
                    path = ""
                Else
                    'insert into database
                    con.Open()
                    cmd = New SqlCommand("INSERT INTO tblfiles (filename,[file],subtype,type,datecreated,createdby) VALUES (@fname,@file,@subtype,@type,(SELECT GETDATE()),@createdby);", con)
                    cmd.Parameters.AddWithValue("@fname", fname)
                    cmd.Parameters.AddWithValue("@file", fileContent)
                    cmd.Parameters.AddWithValue("@subtype", selected_)
                    cmd.Parameters.AddWithValue("@type", tayp)
                    cmd.Parameters.AddWithValue("@createdby", login.username)
                    cmd.ExecuteNonQuery()
                    con.Close()
                    MessageBox.Show(fname & " is saved", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    clear_path()
                    path = ""
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub clear_path()
        excel_path = ""
        pdf_path = ""
    End Sub
    Public Function getSystemDate() As DateTime
        Try
            Dim dt As New DateTime()
            con.Open()
            cmd = New SqlCommand("SELECT GETDATE()", con)
            rdr = cmd.ExecuteReader()
            While rdr.Read
                dt = CDate(rdr(0).ToString)
            End While
            con.Close()
            Return dt
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Function
    Private Sub rbendingbal_CheckedChanged(sender As Object, e As EventArgs) Handles rbendingbal.CheckedChanged
        selected_ = "Ending Balance Short"
    End Sub

    Private Sub rbconv_CheckedChanged(sender As Object, e As EventArgs) Handles rbconv.CheckedChanged
        selected_ = "Conversion"
    End Sub

    Private Sub btnuploadpdf_Click(sender As Object, e As EventArgs) Handles btnuploadpdf.Click
        If selected_ = "SAP" Or selected_ = "Ending Balance Short" Or selected_ = "Conversion" Then
            selected_ = ""
        End If
        upload("PDF", pdf_path)
    End Sub

    Private Sub btnbrowsepdf_Click(sender As Object, e As EventArgs) Handles btnbrowsepdf.Click
        OpenFileDialog1.InitialDirectory = "C:\"
        OpenFileDialog1.Title = "PDF File"
        OpenFileDialog1.Filter = "PDF File|*.pdf"
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            pdf_path = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick, dgv.CellContentClick
        If e.ColumnIndex = 0 Then
            selected_ = dgv.CurrentRow.Cells("description").Value
            lblselected.Text = selected_
        End If
    End Sub
    Public Sub loadFiles()
        Try
            dgvdownloads.Rows.Clear()
            con.Open()
            cmd = New SqlCommand("SELECT id,filename,subtype FROM tblfiles WHERE CAST(datecreated AS date)=@date AND type=@type;", con)
            cmd.Parameters.AddWithValue("@date", datee.Text)
            cmd.Parameters.AddWithValue("@type", IIf(rbexcel.Checked, "Excel", "PDF"))
            rdr = cmd.ExecuteReader
            While rdr.Read
                dgvdownloads.Rows.Add(rdr("id"), rdr("filename"), rdr("subtype"))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub TabControl1_Selected(sender As Object, e As TabControlEventArgs) Handles TabControl1.Selected
        If TabControl1.SelectedIndex = 1 Then
            loadFiles()
        End If
    End Sub

    Private Sub rbexcel_CheckedChanged(sender As Object, e As EventArgs) Handles rbexcel.CheckedChanged
        loadFiles()
    End Sub

    Private Sub rbpdf_CheckedChanged(sender As Object, e As EventArgs) Handles rbpdf.CheckedChanged
        loadFiles()
    End Sub

    Private Sub dgvdownloads_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvdownloads.CellContentClick
        If e.ColumnIndex = 3 Then
            SaveFileDialog1.Title = "Save As " & IIf(rbexcel.Checked = True, "Excel", "PDF") & " File"
            SaveFileDialog1.Filter = IIf(rbexcel.Checked = True, "Excel", "PDF") & "Document (*." & IIf(rbexcel.Checked = True, "xlsx", "pdf") & ") | *." & IIf(rbexcel.Checked = True, "xlsx", "pdf")
            Dim reportData() As Byte = Nothing

            con.Open()
            cmd = New SqlCommand("SELECT [file],filename FROM tblfiles WHERE id=@id", con)
            cmd.Parameters.AddWithValue("@id", dgvdownloads.CurrentRow.Cells("id").Value)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                SaveFileDialog1.FileName = rdr("filename")
                reportData = rdr("file")
                If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                    System.IO.File.WriteAllBytes(SaveFileDialog1.FileName, reportData)
                    MessageBox.Show("Downloaded", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
            con.Close()
        End If
    End Sub

    Private Sub rbcs_CheckedChanged(sender As Object, e As EventArgs) Handles rbcs.CheckedChanged
        selected_ = "Coffee Shop"
    End Sub

    Private Sub datee_ValueChanged(sender As Object, e As EventArgs) Handles datee.ValueChanged
        loadFiles()
    End Sub

    Private Sub rbsap_CheckedChanged(sender As Object, e As EventArgs) Handles rbsap.CheckedChanged
        selected_ = "SAP"
    End Sub
End Class