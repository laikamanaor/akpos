Imports System.IO
Imports System.Data
Imports System.Reflection
Imports ClosedXML.Excel
Imports System.Windows
Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SaveFileDialog1.Title = "Save As Excel File"
        SaveFileDialog1.Filter = "Excel Document (*.xlsx) | *.xlsx"
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim dt As New DataTable()
            dt.Columns.Add("Name")
            dt.Columns.Add("Age")

            dt.Rows.Add("Gordon", "22")
            dt.Rows.Add("Joyce", "21")

            Dim folderpath As String = "C:\\Excel\\"
            If Not Directory.Exists(folderpath) Then
                Directory.CreateDirectory(folderpath)
            End If
            Using wb As New XLWorkbook
                wb.Worksheets.Add(dt, "Customers")
                wb.Worksheets.Add(dt, "Employee")
                wb.Worksheet(1).Protect("123")
                wb.Protect(True, True, "123")
                wb.SaveAs(SaveFileDialog1.FileName.ToString())
            End Using
            Dim path As String = IO.Path.GetDirectoryName(SaveFileDialog1.FileName)
            MessageBox.Show("Saved", "Path: " & path, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class