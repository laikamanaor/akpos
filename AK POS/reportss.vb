Imports System.Data.SqlClient
Imports AK_POS.connection_class
Public Class reportss
    Dim cc As New connection_class
    Dim con As New SqlConnection(cc.conString)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader



    Private Sub reportss_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv.Rows.Clear()
        con.Open()
        cmd = New SqlCommand("SELECT id,description FROM tblreports WHERE status=1;", con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            dgv.Rows.Add(rdr("id"), rdr("description"))
        End While
        con.Close()
    End Sub
    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick

        Dim user As String = "admin"
        Dim pass As String = "abC@43212020"
        Dim servername As String = "192.168.30.6"

        'Dim user As String = "admin"
        'Dim pass As String = "admin"
        'Dim servername As String = "DELL,1433"
        Dim dbName As String = "AKPOS"

        Dim databaseIndex As Integer = 0
        Dim fileName As String = ""

        con.Open()
        cmd = New SqlCommand("SELECT filename,rowindex FROM tblreports WHERE id=@id", con)
        cmd.Parameters.AddWithValue("@id", dgv.CurrentRow.Cells("id").Value)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            databaseIndex = CInt(rdr("rowindex"))
            fileName = CStr(rdr("filename"))
        End If
        con.Close()
        If e.RowIndex = databaseIndex And e.ColumnIndex = 2 Then
            Dim rptDoc As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            'rptDoc = New AB_Coffee_Shop
            'Dim strReportPath As String = "\\192.168.30.6\Atlantic Inv\Reports\" & fileName & ".rpt"
            Dim strReportPath As String = My.Application.Info.DirectoryPath & "\" & fileName & ".rpt"
            rptDoc.Load(strReportPath)
            rptDoc.SetDatabaseLogon(user, pass, servername, dbName)
            'cform_coffeeshop.CrystalReportViewer1.ReportSource = Nothing
            'cform_coffeeshop.CrystalReportViewer1.Refresh()
            cform_coffeeshop.CrystalReportViewer1.ReportSource = rptDoc
            cform_coffeeshop.CrystalReportViewer1.RefreshReport()
            cform_coffeeshop.ShowDialog()
        End If
    End Sub
End Class