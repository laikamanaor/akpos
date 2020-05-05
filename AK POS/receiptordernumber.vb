Public Class receiptordernumber
    Public ordernum As String = ""
    Private Sub receiptordernumber_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim c_form As New crordernumber()
        c_form.SetParameterValue("order_number", ordernum)
        CrystalReportViewer1.ReportSource = c_form
        CrystalReportViewer1.Refresh()
    End Sub
End Class