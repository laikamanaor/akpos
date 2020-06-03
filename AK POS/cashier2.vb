Imports AK_POS.cashier_class
Public Class cashier2
    Dim cashc As New cashier_class()
    Dim offset As Integer = 0, rowFetch As Integer = 50, totalCount As Integer = 0, totalPage As Integer = 0, currentPage As Integer = 1

    Public apdep As String = "", adpdep_amt As Double = 0.00
    Public Sub refreshSub()
        loadSalesAgent()
        cmbtendertype.SelectedIndex = 0
        cmbsales.SelectedIndex = 0
        cmbtype.SelectedIndex = 0
        txtsearch.Text = ""
        loadOrders()
        clear()
    End Sub

    Public Sub clear()
        dgvitems.Rows.Clear()
        lblsubtotal.Text = "0.00"
        lbldisctype.Text = "N/A"
        lblless.Text = "0%"
        lblamount.Text = "0.00"
        lbltenderamount.Text = "0.00"
        lblchange.Text = "0.00"
    End Sub

    Public Sub refreshh()
        currentPage = 1
        offset = 0


        cashc.ordernum = IIf(String.IsNullOrEmpty(Trim(txtsearch.Text)), 0, txtsearch.Text)
        cashc.tendertype = cmbtendertype.Text
        cashc.sales = cmbsales.Text
        cashc.typee = cmbtype.Text

        totalCount = cashc.countData()
        totalPage = Math.Ceiling(totalCount / rowFetch) * 1
        lblpendingorders.Text = "(" & dgvorders.RowCount.ToString("N0") & ") " & "Page: " & currentPage & "/" & totalPage
        loadOrders()
    End Sub

    Private Sub cashier2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadSalesAgent()
        cmbtendertype.SelectedIndex = 0
        cmbsales.SelectedIndex = 0
        cmbtype.SelectedIndex = 0

        cashc.ordernum = IIf(String.IsNullOrEmpty(Trim(txtsearch.Text)), 0, txtsearch.Text)
        cashc.tendertype = cmbtendertype.Text
        cashc.sales = cmbsales.Text
        cashc.typee = cmbtype.Text
        totalCount = cashc.countData()
        totalPage = Math.Ceiling(totalCount / rowFetch) * 1
        loadOrders()
    End Sub

    Public Sub loadOrders()
        Dim result As New DataTable(), totalAmount As Double = 0.00
        cashc.ordernum = IIf(String.IsNullOrEmpty(Trim(txtsearch.Text)), 0, txtsearch.Text)
        cashc.tendertype = cmbtendertype.Text
        cashc.sales = cmbsales.Text
        cashc.typee = cmbtype.Text

        result = cashc.loadPendingOrders(offset, rowFetch)
        clear()
        dgvorders.Rows.Clear()
        For Each r0w As DataRow In result.Rows
            dgvorders.Rows.Add(CInt(r0w("orderid")).ToString("n2"), CInt(r0w("ordernum")).ToString("N0"), CDbl(r0w("amtdue")).ToString("n2"), r0w("tendertype"), r0w("createdby"), r0w("typez"))
            totalAmount += CDbl(r0w("amtdue"))
        Next
        lblpendingamount.Text = "Pending Amount: " & totalAmount.ToString("n2")
        lblpendingorders.Text = "(" & dgvorders.RowCount.ToString("N0") & ") " & "Page: " & currentPage & "/" & totalPage
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
        refreshh()
        If Not String.IsNullOrEmpty(Trim(txtsearch.Text)) And IsNumeric(txtsearch.Text) And dgvorders.RowCount > 0 Then
            loadItems()
            loadBills()
        End If
    End Sub

    Private Sub txtsearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            refreshh()
            If Not String.IsNullOrEmpty(Trim(txtsearch.Text)) And IsNumeric(txtsearch.Text) And dgvorders.RowCount > 0 Then
                loadItems()
                loadBills()
            End If
        End If
    End Sub

    Private Sub cmbtendertype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbtendertype.SelectedIndexChanged
        refreshh()
    End Sub

    Private Sub cmbtype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbtype.SelectedIndexChanged
        refreshh()
    End Sub

    Private Sub cmbsales_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbsales.SelectedIndexChanged
        refreshh()
    End Sub

    Private Sub btnitemprev_Click(sender As Object, e As EventArgs) Handles btnitemprev.Click
        If offset > 0 Then
            offset -= rowFetch
            currentPage -= 1
            loadOrders()

            cashc.ordernum = IIf(String.IsNullOrEmpty(Trim(txtsearch.Text)), 0, txtsearch.Text)
            cashc.tendertype = cmbtendertype.Text
            cashc.sales = cmbsales.Text
            cashc.typee = cmbtype.Text

            totalCount = cashc.countData()
            totalPage = Math.Ceiling(totalCount / rowFetch) * 1
            lblpendingorders.Text = "(" & dgvorders.RowCount.ToString("N0") & ") " & "Page: " & currentPage & "/" & totalPage
        Else
            offset = 0
            currentPage = 1
            lblpendingorders.Text = "(" & dgvorders.RowCount.ToString("N0") & ") " & "Page: " & currentPage & "/" & totalPage
        End If
    End Sub

    Private Sub btnitemnxt_Click(sender As Object, e As EventArgs) Handles btnitemnxt.Click
        offset += rowFetch
        currentPage += 1
        If offset <= totalCount Then
            loadOrders()

            cashc.ordernum = IIf(String.IsNullOrEmpty(Trim(txtsearch.Text)), 0, txtsearch.Text)
            cashc.tendertype = cmbtendertype.Text
            cashc.sales = cmbsales.Text
            cashc.typee = cmbtype.Text

            totalCount = cashc.countData()
            totalPage = Math.Ceiling(totalCount / rowFetch) * 1
            lblpendingorders.Text = "(" & dgvorders.RowCount.ToString("N0") & ") " & "Page: " & currentPage & "/" & totalPage
        Else
            offset -= rowFetch
            currentPage -= 1
            lblpendingorders.Text = "(" & dgvorders.RowCount.ToString("N0") & ") " & "Page: " & currentPage & "/" & totalPage
        End If
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
                cashc.orderid = CInt(dgvorders.CurrentRow.Cells("orderid").Value)
                If cashc.haveDepositItem.Rows.Count > 0 Then
                    deposit()
                Else
                    Dim frm As New mainmenu2
                    frm.orderid = dgvorders.CurrentRow.Cells("orderid").Value
                    frm.isConfirm = False
                    frm.ShowDialog()
                    refreshSub()
                End If
            ElseIf e.ColumnIndex = 8 Then
                cashc.orderid = CInt(dgvorders.CurrentRow.Cells("orderid").Value)
                If cashc.haveDepositItem.Rows.Count > 0 Then
                    deposit()
                Else
                    Dim frm As New mainmenu2
                    frm.orderid = dgvorders.CurrentRow.Cells("orderid").Value
                    frm.isConfirm = True
                    frm.ShowDialog()
                    refreshSub()
                End If
            Else
                loadItems()
                loadBills()
            End If
        End If
    End Sub

    Public Sub deposit()
        Dim msg As String = "Below item have deposit" & Environment.NewLine
        Dim depositTotalAmount As Double = 0.00
        For Each r0w As DataRow In cashc.haveDepositItem.Rows
            msg &= r0w("itemname") & " (" & CDbl(r0w("price")) * CDbl(r0w("quantity")) & ")" & Environment.NewLine
            depositTotalAmount += CDbl(r0w("price")) * CDbl(r0w("quantity"))
        Next
        MessageBox.Show(msg & "Total Deposit Amount: " & depositTotalAmount.ToString("n2"), "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)

        apdep = ""
        adpdep_amt = 0.00
        Dim f As New add_spice()
        f.ShowDialog()
        If apdep <> "" Then

            apdep = apdep.Substring(0, apdep.Length - 1)


            If cashc.checkDepositTransnum(apdep, depositTotalAmount) Then
                adpdep_amt = cashc.returnDepositTransnumAmounts(apdep)
                Dim frm As New mainmenu2
                frm.orderid = dgvorders.CurrentRow.Cells("orderid").Value
                frm.apdep = adpdep_amt
                frm.lbladvancepayment.Text = apdep
                frm.isConfirm = False
                frm.ShowDialog()
                refreshSub()
            Else
                MessageBox.Show("Insufficient deposit", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        End If
    End Sub

    Private Sub cashier2_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        refreshSub()
    End Sub
End Class