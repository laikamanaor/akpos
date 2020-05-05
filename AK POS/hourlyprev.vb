Imports System.IO
Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Windows.Forms
Public Class hourlyprev
    Dim objRpt As New crhourly
    Dim ds As New DataSet

    Private Sub hourlyprev_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim mytext As TextObject = CType(objRpt.ReportDefinition.ReportObjects("Text2"), TextObject)
        mytext.Text = "Date: " & Format(salessum.datefrom.Value, "MM/dd/yyyy") & " - " & Format(salessum.dateto.Value, "MM/dd/yyyy")

        Dim ds As New DataSet1
        Dim t As DataTable = ds.Tables.Add("Items")
        t.Columns.Add("No", Type.GetType("System.String"))
        t.Columns.Add("Time", Type.GetType("System.String"))
        t.Columns.Add("No. of Transaction (Take Out)", Type.GetType("System.Double"))
        t.Columns.Add("Sales Amount (Take Out)", Type.GetType("System.Double"))
        t.Columns.Add("No. of Transaction (Deliver)", Type.GetType("System.Double"))
        t.Columns.Add("Sales Amount (Deliver)", Type.GetType("System.Double"))
        t.Columns.Add("Total No. of Transaction", Type.GetType("System.Double"))
        t.Columns.Add("Total Sales Amount", Type.GetType("System.Double"))

        Dim r As DataRow
        For Each row As DataGridViewRow In salessum.grdhour.Rows
            r = t.NewRow()
            r("No") = salessum.grdhour.Rows(row.Index).Cells(0).Value
            r("Time") = salessum.grdhour.Rows(row.Index).Cells(1).Value
            r("No. of Transaction (Take Out)") = salessum.grdhour.Rows(row.Index).Cells(2).Value
            r("Sales Amount (Take Out)") = salessum.grdhour.Rows(row.Index).Cells(3).Value
            r("No. of Transaction (Deliver)") = salessum.grdhour.Rows(row.Index).Cells(4).Value
            r("Sales Amount (Deliver)") = salessum.grdhour.Rows(row.Index).Cells(5).Value
            r("Total No. of Transaction") = salessum.grdhour.Rows(row.Index).Cells(6).Value
            r("Total Sales Amount") = salessum.grdhour.Rows(row.Index).Cells(7).Value
            t.Rows.Add(r)
        Next

        'MsgBox(ds.Tables("Items").Rows.Count)
        objRpt.SetDataSource(ds.Tables("Items"))
        objRpt.SetParameterValue("cashier", salessum.cmbCashiers.Text)
        CrystalReportViewer1.ReportSource = objRpt
        CrystalReportViewer1.Refresh()
    End Sub
End Class