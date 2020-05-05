Imports System.IO
Imports System.Data.SqlClient
Public Class est

    Dim strconn As String = login.ss
    Dim con As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader

    Dim path As String = ""
    Private Sub btnbrowse_Click(sender As Object, e As EventArgs) Handles btnbrowse.Click
        OpenFileDialog1.Filter = "PDF Files |*.pdf"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then

            con.Open()
            cmd = New SqlCommand("", con)
            con.Close()

            path = OpenFileDialog1.FileName
            AxAcroPDF1.src = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub est_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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


        'insert into database
        con.Open()
        cmd = New SqlCommand("INSERT INTO tblfiles (filename,[file]) VALUES (@fname,@file);", con)
        cmd.Parameters.AddWithValue("@fname", fname)
        cmd.Parameters.AddWithValue("@file", fileContent)
        cmd.ExecuteNonQuery()
        con.Close()

        MessageBox.Show(fname & " is saved", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnretrieve_Click(sender As Object, e As EventArgs) Handles btnretrieve.Click
        'select data
        Dim fname As String = ""
        con.Open()
        cmd = New SqlCommand("SELECT * FROM tblfiles", con)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            'get bytes
            Dim fileBytes() As Byte = CType(rdr(2), Byte())

            'write file from bytes
            fname = rdr("filename")
            Dim FStream As New FileStream(rdr("filename"), FileMode.Create, FileAccess.Write)
            FStream.Write(fileBytes, 0, fileBytes.Length)
            FStream.Close()
        End If
        con.Close()

        Dim path As String = My.Application.Info.DirectoryPath
        AxAcroPDF1.src = path & "\" & fname

    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click

        Dim path As String = My.Application.Info.DirectoryPath
        My.Computer.FileSystem.DeleteFile(path & "\02122020.pdf",
        Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs,
        Microsoft.VisualBasic.FileIO.RecycleOption.DeletePermanently,
        Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
    End Sub

    Private Sub btnopen_Click(sender As Object, e As EventArgs) Handles btnopen.Click

    End Sub

    Private Sub btnbrowse2_Click(sender As Object, e As EventArgs) Handles btnbrowse2.Click
        OpenFileDialog1.Filter = "Excel Files |*.xlsx"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then

            path = OpenFileDialog1.FileName

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


            'insert into database
            con.Open()
            cmd = New SqlCommand("INSERT INTO tblfiles (filename,[file]) VALUES (@fname,@file);", con)
            cmd.Parameters.AddWithValue("@fname", fname)
            cmd.Parameters.AddWithValue("@file", fileContent)
            cmd.ExecuteNonQuery()
            con.Close()

            MessageBox.Show(fname & " is saved", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class