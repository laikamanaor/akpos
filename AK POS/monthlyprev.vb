Imports System.IO
Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Windows.Forms

Public Class monthlyprev
    Dim objRpt As New crmonthly
    Dim ds As New DataSet

    Private Sub monthlyprev_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim mytext As TextObject = CType(objRpt.ReportDefinition.ReportObjects("Text2"), TextObject)
        mytext.Text = "Year: " & salessum.cmbyear.SelectedItem

        Dim ds As New DataSet1
        Dim t As DataTable = ds.Tables.Add("Items")
        t.Columns.Add("No", Type.GetType("System.String"))
        t.Columns.Add("Month", Type.GetType("System.String"))
        t.Columns.Add("No. of Transaction (Take Out)", Type.GetType("System.Double"))
        t.Columns.Add("Sales Amount (Take Out)", Type.GetType("System.Double"))
        t.Columns.Add("No. of Transaction (Deliver)", Type.GetType("System.Double"))
        t.Columns.Add("Sales Amount (Deliver)", Type.GetType("System.Double"))
        t.Columns.Add("Total No. of Transaction", Type.GetType("System.Double"))
        t.Columns.Add("Total Sales Amount", Type.GetType("System.Double"))

        Dim r As DataRow
        For Each row As DataGridViewRow In salessum.grdmonth.Rows
            r = t.NewRow()
            r("No") = salessum.grdmonth.Rows(row.Index).Cells(0).Value
            r("Month") = salessum.grdmonth.Rows(row.Index).Cells(1).Value
            r("No. of Transaction (Take Out)") = salessum.grdmonth.Rows(row.Index).Cells(2).Value
            r("Sales Amount (Take Out)") = salessum.grdmonth.Rows(row.Index).Cells(3).Value
            r("No. of Transaction (Deliver)") = salessum.grdmonth.Rows(row.Index).Cells(4).Value
            r("Sales Amount (Deliver)") = salessum.grdmonth.Rows(row.Index).Cells(5).Value
            r("Total No. of Transaction") = salessum.grdmonth.Rows(row.Index).Cells(6).Value
            r("Total Sales Amount") = salessum.grdmonth.Rows(row.Index).Cells(7).Value
            t.Rows.Add(r)
        Next


        'MsgBox(ds.Tables("Items").Rows.Count)
        objRpt.SetDataSource(ds.Tables("Items"))
        objRpt.SetParameterValue("cashier", salessum.cmbCashiers3.Text)
        CrystalReportViewer1.ReportSource = objRpt
        CrystalReportViewer1.Refresh()
    End Sub
End Class