Imports AK_POS.adjustment_class
Public Class cancel_rectrans
    Dim cc As New connection_class, adjc As New adjustment_class()
    Dim typee As String = "", status As String = ""
    Dim offset As Integer = 0, totalCount As Integer = 0, totalPage As Integer = 0, currentPage As Integer = 1, rowsFetch As Integer = 50
    Private Sub cancel_rectrans_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dt.MaxDate = DateTime.Now
        dt.Text = DateTime.Now.ToString("MM/dd/yyyy")
        btn1.PerformClick()
        cmbtype.SelectedIndex = 0

        adjc.datecreated = dt.Text
        adjc.typee = typee
        adjc.status = status
        adjc.transnum = Trim(txtsearch.Text)

        totalCount = adjc.countData()
        totalPage = Math.Ceiling(totalCount / rowsFetch) * 1

        lbltr.Text = "Page: " & currentPage & "/" & totalPage
        loadData()
    End Sub
    ''' <summary>
    ''' load transaction from adjustment class
    ''' </summary>
    Public Sub loadData()
        adjc.datecreated = dt.Text
        adjc.typee = typee
        adjc.status = status
        adjc.transnum = Trim(txtsearch.Text)
        Dim result As New DataTable()
        result = adjc.loadTransaction(offset, rowsFetch)
        dgvitems.Rows.Clear()
        lblitems.Text = "ITEMS (0)"
        dgvtrans.Rows.Clear()
        For Each r0w As DataRow In result.Rows
            dgvtrans.Rows.Add(r0w("inv_id"), r0w("transaction_number"), r0w("type2"), r0w("processed_by"))
        Next
        txtsearch.AutoCompleteCustomSource = fillAutoComplete(dgvtrans, "transnum")
    End Sub

    Public Function fillAutoComplete(ByVal dgv As DataGridView, ByVal columnName As String) As AutoCompleteStringCollection
        Dim result As New AutoCompleteStringCollection()
        If dgv.Rows.Count <> 0 Then
            For i As Integer = 0 To dgv.Rows.Count - 1
                result.Add(dgv.Rows(i).Cells(columnName).Value)
            Next
        End If
        Return result
    End Function

    Private Sub dgvtrans_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvtrans.CellClick
        loadItems()
        Try
            If dgvtrans.RowCount <> 0 Then
                If e.ColumnIndex = 4 Then

                    adjc.transnum = dgvtrans.CurrentRow.Cells("transnum").Value
                    adjc.invnum = dgvtrans.CurrentRow.Cells("invnum").Value

                    Dim result As New DataTable(), errMsg As String = "You can't cancel this transaction because the item(s) below of ending balance is less than the Received quantity:" & Environment.NewLine & Environment.NewLine
                    result = adjc.checkQuantity()

                    For Each r0w As DataRow In result.Rows
                        errMsg &= r0w("item_name") & "/Ending Balance: (" & CInt(r0w("endbal")).ToString("N0") & ")/ Received Item: (" & CInt(r0w("quantity")).ToString("N0") & ")" & Environment.NewLine
                    Next

                    If adjc.checkTransactionStatus() Then
                        MessageBox.Show("This transaction is already cancelled", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    ElseIf cmbtype.SelectedIndex = 0 And errMsg <> "You can't cancel this transaction because the item(s) below of ending balance is less than the Received quantity:" & Environment.NewLine & Environment.NewLine Then
                        MessageBox.Show(errMsg, "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    ElseIf cmbtype.SelectedIndex = 0 And errMsg = "You can't cancel this transaction because the item(s) below of ending balance is less than the Received quantity:" & Environment.NewLine & Environment.NewLine Then
                        Dim a As String = MsgBox("Are you sure you want to cancel this transaction?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Atlantic Bakery")
                        If a = vbYes Then
                            cancelTransation()
                        End If
                    ElseIf cmbtype.SelectedIndex <> 0 Then
                        Dim a As String = MsgBox("Are you sure you want to cancel this transaction?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Atlantic Bakery")
                        If a = vbYes Then
                            cancelTransation()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Sub cancelTransation()
        Dim columnName As String = ""
        Select Case dgvtrans.CurrentRow.Cells("typez").Value.ToString.ToLower
            Case "Received from Other Branch".ToLower
                columnName = "itemin"
            Case "Received From Production".ToLower
                columnName = "productionin"
            Case "Transfer Item".ToLower
                columnName = "transfer"
        End Select
        Dim result As New DataTable()
        adjc.transnum = dgvtrans.CurrentRow.Cells("transnum").Value
        result = adjc.loadItems()
        adjc.cancelTransaction(result, columnName)
        loadData()

        TextBox1.Text = "UPDATE tblinvitems SET " & columnName & "-=@quantity,charge-=@charge,archarge-=@charge" & IIf(columnName = "transfer", "", ",totalav-=@quantity") & ",endbal" & IIf(columnName = "transfer", "+", "-") & "=@quantity,variance" & IIf(columnName = "transfer", "-", "+") & "=@quantity WHERE invnum=@invnum AND itemname=@itemname;"

    End Sub

    Public Sub loadItems()
        If dgvtrans.RowCount <> 0 Then
            adjc.transnum = dgvtrans.CurrentRow.Cells("transnum").Value
            Dim result As New DataTable()
            result = adjc.loadItems()
            dgvitems.Rows.Clear()
            For Each r0w As DataRow In result.Rows
                dgvitems.Rows.Add(r0w("item_name"), r0w("category"), CInt(r0w("quantity")).ToString("N0"), CInt(r0w("charge")).ToString("N0"))
            Next
            lblitems.Text = "ITEMS (" & dgvitems.RowCount.ToString("N0") & ")"
        End If
    End Sub

    Private Sub btnnext_Click(sender As Object, e As EventArgs) Handles btnnext.Click
        offset += rowsFetch
        currentPage += 1
        If offset <= totalCount Then
            loadData()
            adjc.datecreated = dt.Text
            adjc.typee = typee
            adjc.status = status
            adjc.transnum = Trim(txtsearch.Text)
            totalCount = adjc.countData()
            totalPage = Math.Ceiling(totalCount / rowsFetch) * 1
            lbltr.Text = "Page: " & currentPage & "/" & totalPage
        Else
            offset -= rowsFetch
            currentPage -= 1
            lbltr.Text = "Page: " & currentPage & "/" & totalPage
        End If
    End Sub

    Private Sub btnprev_Click(sender As Object, e As EventArgs) Handles btnprev.Click
        If offset > 0 Then
            offset -= rowsFetch
            currentPage -= 1
            loadData()
            adjc.datecreated = dt.Text
            adjc.typee = typee
            adjc.status = status
            adjc.transnum = Trim(txtsearch.Text)
            totalCount = adjc.countData()
            totalPage = Math.Ceiling(totalCount / rowsFetch) * 1
            lbltr.Text = "Page: " & currentPage & "/" & totalPage
        Else
            offset = 0
            currentPage = 1
            lbltr.Text = "Page: " & currentPage & "/" & totalPage
        End If
    End Sub

    Private Sub cmbtype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbtype.SelectedIndexChanged
        typee = IIf(cmbtype.SelectedIndex = 0, "Received Item", "Transfer Item")
        refreshh()
    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        refreshh()
    End Sub

    Private Sub txtsearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            refreshh()
        End If
    End Sub

    Private Sub dt_ValueChanged(sender As Object, e As EventArgs) Handles dt.ValueChanged
        loadData()
    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        status = "Completed"
        btn1.ForeColor = Color.Black
        btn2.ForeColor = Color.White
        refreshh()
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        status = "Cancelled"
        btn1.ForeColor = Color.White
        btn2.ForeColor = Color.Black
        refreshh()
    End Sub

    Public Sub refreshh()
        currentPage = 1
        offset = 0
        adjc.datecreated = dt.Text
        adjc.typee = typee
        adjc.status = status
        adjc.transnum = Trim(txtsearch.Text)
        totalCount = adjc.countData()
        totalPage = Math.Ceiling(totalCount / rowsFetch) * 1
        lbltr.Text = "Page: " & currentPage & "/" & totalPage
        loadData()
    End Sub

End Class