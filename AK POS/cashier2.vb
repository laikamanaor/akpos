Imports AK_POS.cashier_class
Public Class cashier2
    Dim cashc As New cashier_class()

    Public Sub refreshSub()
        dgvitems.Rows.Clear()
        loadSalesAgent()
        cmbtendertype.SelectedIndex = 0
        cmbsales.SelectedIndex = 0
        cmbtype.SelectedIndex = 0
        txtsearch.Text = ""
        loadOrders()

        lblsubtotal.Text = "0.00"
        lbldisctype.Text = "N/A"
        lblless.Text = "0%"
        lblamount.Text = "0.00"
        lbltenderamount.Text = "0.00"
        lblchange.Text = "0.00"
    End Sub
    Private Sub cashier2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        refreshSub()
    End Sub

    Public Sub loadOrders()
        Dim result As New DataTable()
        cashc.ordernum = IIf(String.IsNullOrEmpty(Trim(txtsearch.Text)), 0, txtsearch.Text)
        cashc.tendertype = cmbtendertype.Text
        cashc.sales = cmbsales.Text
        cashc.typee = cmbtype.Text
        cashc.datee = Date.Now
        result = cashc.loadPendingOrders()
        dgvorders.Rows.Clear()
        For Each r0w As DataRow In result.Rows
            dgvorders.Rows.Add(CInt(r0w("orderid")).ToString("n2"), CInt(r0w("ordernum")).ToString("N0"), CDbl(r0w("amtdue")).ToString("n2"), r0w("tendertype"), r0w("createdby"), r0w("typez"))
        Next
    End Sub

    Public Sub loadItems()
        Dim result As New DataTable()
        cashc.datee = Date.Now
        cashc.orderid = dgvorders.CurrentRow.Cells("orderid").Value
        dgvitems.Rows.Clear()
        result = cashc.loadItems()
        For Each r0w As DataRow In result.Rows
            dgvitems.Rows.Add(r0w("itemname"), CInt(r0w("qty")).ToString("N0"), CDbl(r0w("price")).ToString("n2"), CInt(r0w("dscnt")).ToString("N0"), CDbl(r0w("totalprice")).ToString("n2"), IIf(CInt(r0w("free")) = 0, False, True))
        Next
    End Sub

    Public Sub loadBills()
        Dim result As New DataTable()
        cashc.orderid = dgvorders.CurrentRow.Cells("orderid").Value
        result = cashc.loadBills()
        If result.Rows.Count > 0 Then
            For Each r0w As DataRow In result.Rows
                lblsubtotal.Text = CDbl(r0w("subtotal")).ToString("n2")
                lbldisctype.Text = IIf(String.IsNullOrEmpty(r0w("disctype").ToString), "N/A", r0w("disctype"))
                lblless.Text = CInt(r0w("less")).ToString("N0") & "%"
                lblamount.Text = CDbl(r0w("amtdue")).ToString("n2")
                lbltenderamount.Text = CDbl(r0w("tenderamt")).ToString("n2")
                lblchange.Text = CDbl(r0w("change")).ToString("n2")
            Next
        Else
            lblsubtotal.Text = "0.00"
            lbldisctype.Text = "N/A"
            lblless.Text = "0%"
            lblamount.Text = "0.00"
            lbltenderamount.Text = "0.00"
            lblchange.Text = "0.00"
        End If
    End Sub

    Public Sub loadSalesAgent()
        Dim result As New DataTable()
        cmbsales.Items.Clear()
        cmbsales.Items.Add("All")
        result = cashc.returnSalesAgent()
        For Each r0w As DataRow In result.Rows
            cmbsales.Items.Add(r0w("username"))
        Next
    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        loadOrders()
    End Sub

    Private Sub txtsearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            loadOrders()
        End If
    End Sub

    Private Sub cmbtendertype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbtendertype.SelectedIndexChanged
        loadOrders()
    End Sub

    Private Sub cmbtype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbtype.SelectedIndexChanged
        loadOrders()
    End Sub

    Private Sub cmbsales_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbsales.SelectedIndexChanged
        loadOrders()
    End Sub

    Private Sub btnrefresh_Click(sender As Object, e As EventArgs) Handles btnrefresh.Click
        refreshSub()
    End Sub

    Private Sub txtsearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtsearch.KeyPress
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub dgvorders_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvorders.CellClick
        If dgvorders.RowCount > 0 Then
            If e.ColumnIndex = 6 Then
                Dim frm As New void
                frm.orderid = CInt(dgvorders.CurrentRow.Cells("orderid").Value)
                frm.ShowDialog()
                refreshSub()
            ElseIf e.ColumnIndex = 7 Then
                Dim frm As New mainmenu2
                frm.orderid = dgvorders.CurrentRow.Cells("orderid").Value
                frm.isConfirm = False
                frm.ShowDialog()
            ElseIf e.ColumnIndex = 8 Then
                Dim frm As New mainmenu2
                frm.orderid = dgvorders.CurrentRow.Cells("orderid").Value
                frm.isConfirm = True
                frm.ShowDialog()
            Else
                loadItems()
                loadBills()
            End If
        End If
    End Sub


End Class