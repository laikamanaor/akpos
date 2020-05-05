Imports System.IO
Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Windows.Forms

Public Class dailyprev
    Dim objRpt As New crdaily
    Dim ds As New DataSet

    Private Sub dailyprev_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim mytext As TextObject = CType(objRpt.ReportDefinition.ReportObjects("Text2"), TextObject)
        mytext.Text = "Date: " & Format(salessum.datefrom1.Value, "MM/dd/yyyy") & " - " & Format(salessum.dateto1.Value, "MM/dd/yyyy")

        Dim ds As New DataSet1
        Dim t As DataTable = ds.Tables.Add("Items")
        t.Columns.Add("Date", Type.GetType("System.String"))
        t.Columns.Add("No. of Transaction (Take Out)", Type.GetType("System.Double"))
        t.Columns.Add("Sales Amount (Take Out)", Type.GetType("System.Double"))
        t.Columns.Add("No. of Transaction (Deliver)", Type.GetType("System.Double"))
        t.Columns.Add("Sales Amount (Deliver)", Type.GetType("System.Double"))
        t.Columns.Add("Total No. of Transaction", Type.GetType("System.Double"))
        t.Columns.Add("Total Sales Amount", Type.GetType("System.Double"))

        Dim r As DataRow
        For Each row As DataGridViewRow In salessum.grddaily.Rows
            r = t.NewRow()
            r("Date") = salessum.grddaily.Rows(row.Index).Cells(0).Value
            r("No. of Transaction (Take Out)") = salessum.grddaily.Rows(row.Index).Cells(1).Value
            r("Sales Amount (Take Out)") = salessum.grddaily.Rows(row.Index).Cells(2).Value
            r("No. of Transaction (Deliver)") = salessum.grddaily.Rows(row.Index).Cells(3).Value
            r("Sales Amount (Deliver)") = salessum.grddaily.Rows(row.Index).Cells(4).Value
            r("Total No. of Transaction") = salessum.grddaily.Rows(row.Index).Cells(5).Value
            r("Total Sales Amount") = salessum.grddaily.Rows(row.Index).Cells(6).Value
            t.Rows.Add(r)
        Next

        'MsgBox(ds.Tables("Items").Rows.Count)
        objRpt.SetDataSource(ds.Tables("Items"))
        objRpt.SetParameterValue("cashier", salessum.cmbCashiers2.Text)
        CrystalReportViewer1.ReportSource = objRpt
        CrystalReportViewer1.Refresh()
    End Sub
End Class