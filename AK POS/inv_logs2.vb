Imports AK_POS.inventory_class
Imports AK_POS.received_class
Public Class inv_logs2
    Dim invc As New inventory_class(), recc As New received_class()
    Dim offset As Integer = 0, totalCount As Integer = 0, totalPage As Integer = 0, currentPage As Integer = 1, rowsFetch As Integer = 50, typee As String = ""

    Private Sub btnreceived_Click(sender As Object, e As EventArgs) Handles btnreceived.Click
        typee = "Received Item"
        refreshh()
        dgvitems.Rows.Clear()
        btnreceived.ForeColor = Color.Black
        btnTransfer.ForeColor = Color.White
        btnActualEndingBalance.ForeColor = Color.White
        btnadjin.ForeColor = Color.White
        btnAdjustmentOut.ForeColor = Color.White
        btnPullOut.ForeColor = Color.White
        dgvtrans.Columns("fromreceived").Visible = True
        dgvtrans.Columns("toreceived").Visible = True

        dgvtrans.Columns("fromreceived").HeaderText = "Received To"
        dgvtrans.Columns("toreceived").HeaderText = "Received From"

        dgvtrans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
    End Sub

    Private Sub btnTransfer_Click(sender As Object, e As EventArgs) Handles btnTransfer.Click
        typee = "Transfer Item"
        refreshh()
        dgvitems.Rows.Clear()
        btnreceived.ForeColor = Color.White
        btnTransfer.ForeColor = Color.Black
        btnActualEndingBalance.ForeColor = Color.White
        btnadjin.ForeColor = Color.White
        btnAdjustmentOut.ForeColor = Color.White
        btnPullOut.ForeColor = Color.White
        dgvtrans.Columns("fromreceived").Visible = True
        dgvtrans.Columns("toreceived").Visible = True

        dgvtrans.Columns("fromreceived").HeaderText = "Transfer From"
        dgvtrans.Columns("toreceived").HeaderText = "Transfer To"

        dgvtrans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
    End Sub

    Private Sub btnActualEndingBalance_Click(sender As Object, e As EventArgs) Handles btnActualEndingBalance.Click
        typee = btnActualEndingBalance.Text
        refreshh()
        dgvitems.Rows.Clear()
        btnreceived.ForeColor = Color.White
        btnTransfer.ForeColor = Color.White
        btnadjin.ForeColor = Color.White
        btnAdjustmentOut.ForeColor = Color.White
        btnPullOut.ForeColor = Color.White
        btnActualEndingBalance.ForeColor = Color.Black
        dgvtrans.Columns("fromreceived").Visible = False
        dgvtrans.Columns("toreceived").Visible = False

        dgvtrans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub txttrans_KeyDown(sender As Object, e As KeyEventArgs) Handles txttrans.KeyDown
        If e.KeyCode = Keys.Enter Then
            refreshh()
            loadItems()
        End If
    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        refreshh()
        loadItems()
    End Sub

    Private Sub dtdate_ValueChanged(sender As Object, e As EventArgs) Handles dtdate.ValueChanged
        refreshh()
    End Sub

    Private Sub dgvtrans_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvtrans.CellClick
        If dgvtrans.RowCount <> 0 Then
            loadItems()
        End If
    End Sub
    Public Sub loadItems()
        If dgvtrans.RowCount <> 0 Then
            invc.transnum = dgvtrans.CurrentRow.Cells("transnum").Value
            invc.itemname = txtitems.Text
            invc.category = cmbcategory.Text
            Dim result As New DataTable(), auto As New AutoCompleteStringCollection()
            result = invc.loadItems()
            dgvitems.Rows.Clear()
            For Each r0w As DataRow In result.Rows
                dgvitems.Rows.Add(r0w("itemname"), r0w("category"), CInt(r0w("quantity")).ToString("N0"))
                auto.Add(r0w("itemname"))
            Next
            txtitems.AutoCompleteCustomSource = auto
        Else
            dgvitems.Rows.Clear()
        End If
        lblitemscount.Text = "ITEMS (" & dgvitems.RowCount.ToString("N0") & ")"
    End Sub

    Private Sub btnnext_Click(sender As Object, e As EventArgs) Handles btnnext.Click
        offset += rowsFetch
        currentPage += 1
        If offset <= totalCount Then
            loadTransaction()
            invc.transnum = txttrans.Text
            invc.datecreated = dtdate.Text
            invc.typee = typee
            totalCount = invc.countTransaction()
            totalPage = Math.Ceiling(totalCount / rowsFetch) * 1
            lblcount.Text = "Page: " & currentPage & "/" & totalPage
        Else
            offset -= rowsFetch
            currentPage -= 1
            lblcount.Text = "Page: " & currentPage & "/" & totalPage
        End If
    End Sub

    Private Sub btnprev_Click(sender As Object, e As EventArgs) Handles btnprev.Click
        If offset > 0 Then
            offset -= rowsFetch
            currentPage -= 1
            loadTransaction()
            invc.transnum = txttrans.Text
            invc.datecreated = dtdate.Text
            invc.typee = typee
            totalCount = invc.countTransaction()
            totalPage = Math.Ceiling(totalCount / rowsFetch) * 1
            lblcount.Text = "Page: " & currentPage & "/" & totalPage
        Else
            offset = 0
            currentPage = 1
            lblcount.Text = "Page: " & currentPage & "/" & totalPage
        End If
    End Sub

    Private Sub cmbcategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbcategory.SelectedIndexChanged
        loadItems()
    End Sub

    Private Sub dgvtrans_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvtrans.CellDoubleClick
        If dgvtrans.RowCount <> 0 Then
            Dim frm As New showSAPNumber()
            frm.transnum = dgvtrans.CurrentRow.Cells("transnum").Value
            frm.ShowDialog()
        End If
    End Sub

    Private Sub btnPullOut_Click(sender As Object, e As EventArgs) Handles btnAdjustmentOut.Click
        typee = "Adjustment Out Item"
        refreshh()
        dgvitems.Rows.Clear()
        btnreceived.ForeColor = Color.White
        btnTransfer.ForeColor = Color.White
        btnActualEndingBalance.ForeColor = Color.White
        btnadjin.ForeColor = Color.White
        btnAdjustmentOut.ForeColor = Color.Black
        btnPullOut.ForeColor = Color.White
        dgvtrans.Columns("fromreceived").Visible = False
        dgvtrans.Columns("toreceived").Visible = False
        dgvtrans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub btnadjin_Click(sender As Object, e As EventArgs) Handles btnadjin.Click
        typee = "Adjustment Item"
        refreshh()
        dgvitems.Rows.Clear()
        btnreceived.ForeColor = Color.White
        btnTransfer.ForeColor = Color.White
        btnActualEndingBalance.ForeColor = Color.White
        btnadjin.ForeColor = Color.Black
        btnAdjustmentOut.ForeColor = Color.White
        btnPullOut.ForeColor = Color.White
        dgvtrans.Columns("fromreceived").Visible = False
        dgvtrans.Columns("toreceived").Visible = False
        dgvtrans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub btnPullOut_Click_1(sender As Object, e As EventArgs) Handles btnPullOut.Click
        typee = "Pull Out"
        refreshh()
        dgvitems.Rows.Clear()
        btnreceived.ForeColor = Color.White
        btnTransfer.ForeColor = Color.White
        btnActualEndingBalance.ForeColor = Color.White
        btnadjin.ForeColor = Color.White
        btnAdjustmentOut.ForeColor = Color.Wheat
        btnPullOut.ForeColor = Color.Black
    End Sub

    Private Sub btnsearch2_Click(sender As Object, e As EventArgs) Handles btnsearch2.Click
        loadItems()
    End Sub

    Private Sub txtitems_KeyDown(sender As Object, e As KeyEventArgs) Handles txtitems.KeyDown
        If e.KeyCode = Keys.Enter Then
            loadItems()
        End If
    End Sub


    Private Sub inv_logs2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        invc.transnum = txttrans.Text
        invc.datecreated = dtdate.Text
        invc.typee = typee
        totalCount = invc.countTransaction()
        totalPage = Math.Ceiling(totalCount / rowsFetch) * 1
        btnreceived.PerformClick()
        loadCategories()
    End Sub

    ''' <summary>
    ''' load categories to combobox
    ''' </summary>
    Public Sub loadCategories()
        Dim result As New DataTable()
        result = recc.loadCategories()
        cmbcategory.Items.Clear()
        cmbcategory.Items.Add("All")
        For Each r0w As DataRow In result.Rows
            cmbcategory.Items.Add(r0w("result"))
        Next
        cmbcategory.SelectedIndex = 0
    End Sub

    Public Sub loadTransaction()
        Dim result As New DataTable(), auto As New AutoCompleteStringCollection()
        invc.transnum = txttrans.Text
        invc.datecreated = dtdate.Text
        invc.typee = typee
        result = invc.loadTransaction(offset, rowsFetch)
        dgvtrans.Rows.Clear()
        dgvitems.Rows.Clear()
        For Each r0w As DataRow In result.Rows
            dgvtrans.Rows.Add(r0w("transaction_number"), IIf(typee = "Received Item", r0w("transfer_from"), r0w("transfer_to")), IIf(typee = "Received Item", r0w("transfer_to"), r0w("transfer_from")), r0w("processed_by"), CDate(r0w("date")).ToString("hh:mm tt"))
            auto.Add(r0w("transaction_number"))
        Next
        txttrans.AutoCompleteCustomSource = auto
    End Sub


    Public Sub refreshh()
        currentPage = 1
        offset = 0
        invc.transnum = txttrans.Text
        invc.datecreated = dtdate.Text
        invc.typee = typee
        totalCount = invc.countTransaction()
        totalPage = Math.Ceiling(totalCount / rowsFetch) * 1
        lblcount.Text = "Page: " & currentPage & "/" & totalPage
        lblitemscount.Text = "ITEMS (0)"
        loadTransaction()
    End Sub
End Class