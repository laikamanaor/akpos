Imports AK_POS.inventory_class
Imports AK_POS.received_class
Public Class inv_logs2
    Dim invc As New inventory_class(), recc As New received_class()
    Private offset As Integer = 0, rowFetch As Integer = 30, typee As String = ""

    Private Sub btnreceived_Click(sender As Object, e As EventArgs) Handles btnreceived.Click
        typee = btnreceived.Text
        loadTransaction()
        dgvitems.Rows.Clear()
        btnreceived.ForeColor = Color.Black
        btnTransfer.ForeColor = Color.White
        btnActualEndingBalance.ForeColor = Color.White
        dgvtrans.Columns("fromreceived").Visible = True
        dgvtrans.Columns("toreceived").Visible = True
        dgvtrans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
    End Sub

    Private Sub btnTransfer_Click(sender As Object, e As EventArgs) Handles btnTransfer.Click
        typee = btnTransfer.Text
        loadTransaction()
        dgvitems.Rows.Clear()
        btnreceived.ForeColor = Color.White
        btnTransfer.ForeColor = Color.Black
        btnActualEndingBalance.ForeColor = Color.White
        dgvtrans.Columns("fromreceived").Visible = True
        dgvtrans.Columns("toreceived").Visible = True
        dgvtrans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
    End Sub

    Private Sub btnActualEndingBalance_Click(sender As Object, e As EventArgs) Handles btnActualEndingBalance.Click
        typee = btnActualEndingBalance.Text
        loadTransaction()
        dgvitems.Rows.Clear()
        btnreceived.ForeColor = Color.White
        btnTransfer.ForeColor = Color.White
        btnActualEndingBalance.ForeColor = Color.Black
        dgvtrans.Columns("fromreceived").Visible = False
        dgvtrans.Columns("toreceived").Visible = False
        dgvtrans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub txttrans_KeyDown(sender As Object, e As KeyEventArgs) Handles txttrans.KeyDown
        If e.KeyCode = Keys.Enter Then
            loadTransaction()
            loadItems()
        End If
    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        loadTransaction()
        loadItems()
    End Sub

    Private Sub dtdate_ValueChanged(sender As Object, e As EventArgs) Handles dtdate.ValueChanged
        loadTransaction()
    End Sub

    Private Sub dgvtrans_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvtrans.CellClick
        If dgvtrans.RowCount <> 0 Then
            loadItems()
        End If
    End Sub
    Public Sub loadItems()
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
    End Sub

    Private Sub cmbcategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbcategory.SelectedIndexChanged
        loadItems()
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
        result = invc.loadTransaction(offset, rowFetch)
        dgvtrans.Rows.Clear()
        For Each r0w As DataRow In result.Rows
            dgvtrans.Rows.Add(r0w("transaction_number"), IIf(typee = "Received Item", r0w("transfer_to"), r0w("transfer_from")), IIf(typee = "Received Item", r0w("transfer_from"), r0w("transfer_to")), r0w("processed_by"), CDate(r0w("date")).ToString("hh:mm tt"))
            auto.Add(r0w("transaction_number"))
        Next
        txttrans.AutoCompleteCustomSource = auto
    End Sub

End Class