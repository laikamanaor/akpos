Imports AK_POS.inventory_class
Imports AK_POS.received_class
Public Class inv_logs2
    Dim invc As New inventory_class(), recc As New received_class()
    Dim offset As Integer = 0, totalCount As Integer = 0, totalPage As Integer = 0, currentPage As Integer = 1, rowsFetch As Integer = 50, typee As String = ""

    Private Sub btnreceived_Click(sender As Object, e As EventArgs) Handles btnreceived.Click
        typee = "Received Item"
        refreshh()
        btnreceived.ForeColor = Color.Black
        btnTransfer.ForeColor = Color.White
        btnActualEndingBalance.ForeColor = Color.White
        btnadjin.ForeColor = Color.White
        btnAdjustmentOut.ForeColor = Color.White
        btnPullOut.ForeColor = Color.White
        dgvtrans.Columns("sapnum").Visible = True
        dgvtrans.Columns("fromreceived").Visible = True
        dgvtrans.Columns("toreceived").Visible = True

        dgvtrans.Columns("fromreceived").HeaderText = "Received From"
        dgvtrans.Columns("toreceived").HeaderText = "Received To"
    End Sub

    Private Sub btnTransfer_Click(sender As Object, e As EventArgs) Handles btnTransfer.Click
        typee = "Transfer Item"
        refreshh()
        btnreceived.ForeColor = Color.White
        btnTransfer.ForeColor = Color.Black
        btnActualEndingBalance.ForeColor = Color.White
        btnadjin.ForeColor = Color.White
        btnAdjustmentOut.ForeColor = Color.White
        btnPullOut.ForeColor = Color.White
        dgvtrans.Columns("sapnum").Visible = True
        dgvtrans.Columns("fromreceived").Visible = True
        dgvtrans.Columns("toreceived").Visible = True

        dgvtrans.Columns("fromreceived").HeaderText = "Transfer To"
        dgvtrans.Columns("toreceived").HeaderText = "Transfer From"
    End Sub

    Private Sub btnActualEndingBalance_Click(sender As Object, e As EventArgs) Handles btnActualEndingBalance.Click
        typee = btnActualEndingBalance.Text
        refreshh()
        btnreceived.ForeColor = Color.White
        btnTransfer.ForeColor = Color.White
        btnadjin.ForeColor = Color.White
        btnAdjustmentOut.ForeColor = Color.White
        btnPullOut.ForeColor = Color.White
        btnActualEndingBalance.ForeColor = Color.Black
        dgvtrans.Columns("sapnum").Visible = False
        dgvtrans.Columns("fromreceived").Visible = False
        dgvtrans.Columns("toreceived").Visible = False
    End Sub

    Private Sub txttrans_KeyDown(sender As Object, e As KeyEventArgs) Handles txttrans.KeyDown
        If e.KeyCode = Keys.Enter Then
            refreshh()
        End If
    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        refreshh()
    End Sub

    Private Sub dtdate_ValueChanged(sender As Object, e As EventArgs) Handles dtdate.ValueChanged
        refreshh()
    End Sub

    Private Sub dgvtrans_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvtrans.CellClick
        If dgvtrans.RowCount <> 0 Then
            ''
        End If
    End Sub

    Private Sub btnnext_Click(sender As Object, e As EventArgs) Handles btnnext.Click
        offset += rowsFetch
        currentPage += 1
        If offset <= totalCount Then
            tt()
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
            tt()
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


    Private Sub dgvtrans_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvtrans.CellDoubleClick
        If dgvtrans.RowCount <> 0 Then
            Dim frm As New inv_logs_items()
            frm.transnum = dgvtrans.CurrentRow.Cells("transnum").Value
            frm.ShowDialog()
        End If
    End Sub

    Private Sub btnPullOut_Click(sender As Object, e As EventArgs) Handles btnAdjustmentOut.Click
        typee = "Adjustment Out Item"
        refreshh()
        btnreceived.ForeColor = Color.White
        btnTransfer.ForeColor = Color.White
        btnActualEndingBalance.ForeColor = Color.White
        btnadjin.ForeColor = Color.White
        btnAdjustmentOut.ForeColor = Color.Black
        btnPullOut.ForeColor = Color.White
        dgvtrans.Columns("sapnum").Visible = True
        dgvtrans.Columns("fromreceived").Visible = False
        dgvtrans.Columns("toreceived").Visible = False
    End Sub

    Private Sub btnadjin_Click(sender As Object, e As EventArgs) Handles btnadjin.Click
        typee = "Adjustment Item"
        refreshh()
        btnreceived.ForeColor = Color.White
        btnTransfer.ForeColor = Color.White
        btnActualEndingBalance.ForeColor = Color.White
        btnadjin.ForeColor = Color.Black
        btnAdjustmentOut.ForeColor = Color.White
        btnPullOut.ForeColor = Color.White
        dgvtrans.Columns("sapnum").Visible = True
        dgvtrans.Columns("fromreceived").Visible = False
        dgvtrans.Columns("toreceived").Visible = False
    End Sub

    Private Sub btnPullOut_Click_1(sender As Object, e As EventArgs) Handles btnPullOut.Click
        typee = "Pull Out"
        refreshh()
        btnreceived.ForeColor = Color.White
        btnTransfer.ForeColor = Color.White
        btnActualEndingBalance.ForeColor = Color.White
        btnadjin.ForeColor = Color.White
        btnAdjustmentOut.ForeColor = Color.Wheat
        dgvtrans.Columns("sapnum").Visible = True
        btnPullOut.ForeColor = Color.Black
        dgvtrans.Columns("fromreceived").HeaderText = "Transfer To"
        dgvtrans.Columns("toreceived").HeaderText = "Transfer From"
    End Sub

    Private Sub inv_logs2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        invc.transnum = txttrans.Text
        invc.datecreated = dtdate.Text
        invc.typee = typee
        totalCount = invc.countTransaction()
        totalPage = Math.Ceiling(totalCount / rowsFetch) * 1
        btnreceived.PerformClick()
    End Sub

    Public Sub loadTransaction()
        spinner.Visible = True
        dgvtrans.DefaultCellStyle.ForeColor = Color.Black
        Try
            Dim result As New DataTable()
            invc.transnum = txttrans.Text
            invc.datecreated = dtdate.Text
            invc.typee = typee
            result = invc.loadTransaction(offset, rowsFetch)
            dgvtrans.Rows.Clear()
            For Each r0w As DataRow In result.Rows
                dgvtrans.Rows.Add(r0w("transaction_number"), IIf(typee = "Received Item", r0w("transfer_from"), r0w("transfer_to")), IIf(typee = "Received Item", r0w("transfer_to"), r0w("transfer_from")), r0w("sap_number"), r0w("remarks"), r0w("processed_by"), CDate(r0w("date")).ToString("hh:mm tt"))
            Next


            'For index As Integer = 0 To dgvtrans.Rows.Count - 1
            '    Dim transnum As String = dgvtrans.Rows(index).Cells("transnum").Value
            '    If Not recc.toFollowSAPNumber(transnum) Then
            '        If recc.checkItems(transnum, "EQUAL") Then
            '            dgvtrans.Rows(index).DefaultCellStyle.BackColor = Color.Green
            '        ElseIf recc.checkItems(transnum, "GREATER THAN") Then
            '            dgvtrans.Rows(index).DefaultCellStyle.BackColor = Color.Blue
            '        ElseIf recc.checkItems(transnum, "LESS THAN") Then
            '            dgvtrans.Rows(index).DefaultCellStyle.BackColor = Color.Red
            '        Else
            '            dgvtrans.Rows(index).DefaultCellStyle.BackColor = Color.Orange
            '        End If
            '    Else
            '        dgvtrans.Rows(index).DefaultCellStyle.BackColor = Color.Brown
            '    End If
            '    dgvtrans.DefaultCellStyle.ForeColor = Color.White
            'Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        spinner.Visible = False
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
        tt()
    End Sub

    Public Sub tt()
        Control.CheckForIllegalCrossThreadCalls = False
        Dim th As New Threading.Thread(AddressOf loadTransaction)
        th.Start()
    End Sub
End Class