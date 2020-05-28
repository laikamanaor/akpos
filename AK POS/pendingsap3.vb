Imports AK_POS.pendingsap_class
Public Class pendingsap3
    Dim sapc As New pendingsap_class()
    Dim offset As Integer = 0, totalCount As Integer = 0, totalPage As Integer = 0, currentPage As Integer = 1, rowsFetch As Integer = 50
    Private Sub pendingsap3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbtype.SelectedIndex = 0
        sapc.transnum = Trim(txtsearch.Text)
        sapc.datecreated = datee.Text
        sapc.typee = cmbtype.Text
        totalCount = sapc.countData()
        totalPage = Math.Ceiling(totalCount / rowsFetch) * 1
        loadTransaction()
    End Sub

    Public Sub loadTransaction()
        If cmbtype.SelectedIndex <> 0 Then
            sapc.transnum = Trim(txtsearch.Text)
            sapc.datecreated = datee.Text
            sapc.typee = cmbtype.Text
            Dim result As New DataTable(), auto As New AutoCompleteStringCollection
            result = sapc.loadTransactions(offset, rowsFetch)
            dgvtrans.Rows.Clear()
            dgvitems.Rows.Clear()
            If result.Rows.Count > 0 Then
                For Each r0w As DataRow In result.Rows
                    dgvtrans.Rows.Add(False, r0w("transnum"), r0w("name"), r0w("sapdoc"), r0w("sapnum"), r0w("remarks"), r0w("fromm"), CDate(r0w("time")).ToString("hh:mm tt"))
                    auto.Add(r0w("transnum"))
                Next
                txtsearch.AutoCompleteCustomSource = auto
            Else
                clear()
            End If
        Else
            clear()
        End If
    End Sub

    Public Sub loadItems(ByVal transnum As String)
        Dim result As New DataTable()
        sapc.typee = cmbtype.Text
        sapc.transnum = transnum
        result = sapc.loadItems()
        dgvitems.Rows.Clear()
        For Each r0w As DataRow In result.Rows
            dgvitems.Rows.Add(r0w("item_name"), CInt(r0w("quantity")).ToString("N0"))
        Next
    End Sub

    Private Sub datee_ValueChanged(sender As Object, e As EventArgs) Handles datee.ValueChanged
        refreshh()
    End Sub
    Public Sub clear()
        dgvtrans.Rows.Clear()
        dgvitems.Rows.Clear()
        txtsearch.Text = ""
        datee.Text = DateTime.Now.ToString("MM/dd/yyyy")
    End Sub

    Private Sub btnnext_Click(sender As Object, e As EventArgs) Handles btnnext.Click
        offset += rowsFetch
        currentPage += 1
        If offset <= totalCount Then
            loadTransaction()
            sapc.transnum = Trim(txtsearch.Text)
            sapc.datecreated = datee.Text
            sapc.typee = cmbtype.Text
            totalCount = sapc.countData()
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
            sapc.transnum = Trim(txtsearch.Text)
            sapc.datecreated = datee.Text
            sapc.typee = cmbtype.Text
            totalCount = sapc.countData()
            totalPage = Math.Ceiling(totalCount / rowsFetch) * 1
            lblcount.Text = "Page: " & currentPage & "/" & totalPage
        Else
            offset = 0
            currentPage = 1
            lblcount.Text = "Page: " & currentPage & "/" & totalPage
        End If
    End Sub
    Public Sub refreshh()
        currentPage = 1
        offset = 0
        sapc.transnum = Trim(txtsearch.Text)
        sapc.datecreated = datee.Text
        sapc.typee = cmbtype.Text
        totalCount = sapc.countData()
        totalPage = Math.Ceiling(totalCount / rowsFetch) * 1
        lblcount.Text = "Page: " & currentPage & "/" & totalPage
        loadTransaction()
    End Sub

    Private Sub btnsubmit_Click(sender As Object, e As EventArgs) Handles btnsubmit.Click
        Dim checkHasSelected_counter As Integer = 0
        For i As Integer = 0 To dgvtrans.Rows.Count - 1
            If dgvtrans.Rows(i).Cells("selectt").Value = True Then
                checkHasSelected_counter += 1
            End If
        Next
        If dgvtrans.RowCount < 0 Then
            MessageBox.Show("No transaction found", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf checkHasSelected_counter = 0 Then
            MessageBox.Show("Please select transaction first", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            disabled_enabled(True)
        End If
    End Sub

    Private Sub lblSAPClose_Click(sender As Object, e As EventArgs) Handles lblSAPClose.Click
        disabled_enabled(False)
    End Sub

    Public Sub disabled_enabled(ByVal expression As Boolean)
        dgvtrans.Columns("selectt").ReadOnly = IIf(expression, True, False)
        panelSAP.Visible = IIf(expression, True, False)
        txtsearch.Enabled = IIf(expression, False, True)
        cmbtype.Enabled = IIf(expression, False, True)
        datee.Enabled = IIf(expression, False, True)
        btnnext.Enabled = IIf(expression, False, True)
        btnprev.Enabled = IIf(expression, False, True)
    End Sub

    Private Sub btnProceed_Click(sender As Object, e As EventArgs) Handles btnProceed.Click
        If String.IsNullOrEmpty(Trim(txtsap.Text)) Then
            MessageBox.Show("SAP # field is required", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf Not IsNumeric(txtsap.Text) Then
            MessageBox.Show("SAP # must be a number", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf txtsap.TextLength < 6 Then
            MessageBox.Show("SAP # must be a 6 numbers", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf String.IsNullOrEmpty(txtremarks.Text) Then
            MessageBox.Show("Remarks field is required", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim toUpdate As New DataTable()
            toUpdate.Columns.Add("transnum")

            Dim checkHasSelected_counter As Integer = 0
            For i As Integer = 0 To dgvtrans.Rows.Count - 1
                If dgvtrans.Rows(i).Cells("selectt").Value = True Then
                    toUpdate.Rows.Add(dgvtrans.Rows(i).Cells("transnum").Value)
                End If
            Next

            sapc.sapnum = txtsap.Text
            sapc.remarks = txtremarks.Text
            sapc.updateSAPNumber(toUpdate)

            disabled_enabled(False)
            txtremarks.Clear()
            txtremarks.Clear()
            refreshh()
            txtsearch.Text = ""
            datee.Text = DateTime.Now.ToString("MM/dd/yyyy")
        End If
    End Sub

    Private Sub txtsap_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsap.KeyDown, txtremarks.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnProceed.PerformClick()
        End If
    End Sub

    Private Sub cmbtype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbtype.SelectedIndexChanged
        If cmbtype.SelectedIndex = 0 Then
            clear()
        Else
            refreshh()
            loadItems(txtsearch.Text)
        End If
    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        refreshh()
    End Sub

    Private Sub txtsearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            refreshh()
            loadItems(txtsearch.Text)
        End If
    End Sub

    Private Sub dgvtrans_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvtrans.CellClick
        If dgvtrans.RowCount > 0 Then
            loadItems(Trim(dgvtrans.CurrentRow.Cells("transnum").Value))
        Else
            dgvitems.Rows.Clear()
        End If
    End Sub
End Class