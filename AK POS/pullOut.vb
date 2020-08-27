Public Class pullOut
    Dim rec As New received_class()
    Dim cc As New connection_class()
    Dim itemc As New items_class
    Public Sub loadData()
        spinner.Visible = True
        Dim serverDate As Date
        serverDate = cc.getSystemDate()
        rec.setDateCreated(serverDate.ToString("MM/dd/yyyy"))
        rec.setItemName(txtList.Text)
        rec.setCategory("All")
        Dim auto As New AutoCompleteStringCollection()
        Dim result As New DataTable()
        result = rec.loadAvailableItems("trans")
        dgvList.Rows.Clear()
        For Each r0w As DataRow In result.Rows
            dgvList.Rows.Add(r0w("itemname"))
            auto.Add(r0w("itemname"))
        Next
        spinner.Visible = False
    End Sub

    Public Function fillTextList() As AutoCompleteStringCollection
        Dim auto As New AutoCompleteStringCollection()
        Dim serverDate As Date
        serverDate = cc.getSystemDate()
        rec.setDateCreated(serverDate.ToString("MM/dd/yyyy"))
        rec.setItemName(txtList.Text)
        rec.setCategory("All")
        Dim result As New DataTable()
        result = rec.loadAvailableItems("trans")
        For Each r0w As DataRow In result.Rows
            dgvList.Rows.Add(r0w("itemname"))
            auto.Add(r0w("itemname"))
        Next
        Return auto
    End Function

    Private Sub pullOut_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Control.CheckForIllegalCrossThreadCalls = False
        Dim th As New Threading.Thread(AddressOf loadData)
        th.Start()
    End Sub

    Private Sub txtList_KeyDown(sender As Object, e As KeyEventArgs) Handles txtList.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub pullOut_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtList.AutoCompleteCustomSource = fillTextList()
        loadBranches()
    End Sub

    Private Sub dgvList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellClick
        If dgvList.Rows.Count <> 0 And e.ColumnIndex = 1 Then
            addQuantityValidation()
        End If
    End Sub

    Public Sub addQuantityValidation()
        Dim checkError As Integer = 0
        For index As Integer = 0 To dgvSelected.RowCount - 1
            If dgvSelected.Rows(index).Cells("itemNamee").Value.ToString.ToLower = dgvList.CurrentRow.Cells("itemName").Value.ToString.ToLower Then
                checkError += 1
            End If
        Next
        If checkError <> 0 Then
            MessageBox.Show("'" & dgvList.CurrentRow.Cells("itemName").Value & "' has already exist in Selected Item", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim resultItemInfo As New DataTable()
            resultItemInfo = loadItemInfo(dgvList.CurrentRow.Cells("itemName").Value)
            If resultItemInfo.Rows.Count > 0 Then
                For Each r0w As DataRow In resultItemInfo.Rows
                    Dim itemcode As String = r0w("itemcode"),
                    itemName As String = r0w("itemname"),
                    category As String = r0w("category"),
                    quantity As String = 0
                    addEdit(dgvSelected, itemcode, itemName, category, quantity, "ADD")
                Next
            End If
        End If
    End Sub

    Public Function loadItemInfo(ByVal itemname As String) As DataTable
        Dim result As New DataTable()
        result.Columns.Add("itemcode")
        result.Columns.Add("itemname")
        result.Columns.Add("category")
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT itemcode,itemname,category FROM tblitems WHERE itemname=@itemname;", cc.con)
        cc.cmd.Parameters.AddWithValue("@itemname", itemname)
        cc.rdr = cc.cmd.ExecuteReader
        While cc.rdr.Read
            Dim itemCode As String = cc.rdr("itemcode")
            Dim itemNamee As String = cc.rdr("itemname")
            Dim category As String = cc.rdr("category")
            result.Rows.Add(itemCode, itemNamee, category)
        End While
        cc.con.Close()
        Return result
    End Function

    Public Sub addEdit(ByVal dgv As DataGridView, ByVal icode As String, ByVal iname As String, ByVal icat As String, iquantity As Double, ByVal typee As String)
        receivedItem_add.txtitemcode.Text = icode
        receivedItem_add.txtitemname.Text = iname
        receivedItem_add.txtcategory.Text = icat
        receivedItem_add.txtquantity.Text = iquantity
        receivedItem_add.lblheader.Text = typee & " QUANTITY"
        receivedItem_add.txtquantity.Focus()
        receivedItem_add.ShowDialog()
        If receivedItem_add.isSuccess Then
            Dim itemname As String = "", itemcode As String = "", category As String = "", quantity As Integer = 0
            itemname = receivedItem_add.txtitemname.Text
            itemcode = receivedItem_add.txtitemcode.Text
            category = receivedItem_add.txtcategory.Text
            quantity = receivedItem_add.txtquantity.Text
            receivedItem_add.txtquantity.Focus()
            If typee = "ADD" Then
                dgvSelected.Rows.Add(itemname, quantity.ToString("N0"))
            Else
                dgvSelected.CurrentRow.Cells("quantity").Value = quantity.ToString("N0")
            End If
            txtSelected.AutoCompleteCustomSource = fillAutocomplete(dgvSelected, "itemnamee")
            'lblSelectedItemCount.Text = CInt(dgvSelectedItem.Rows.Count).ToString("N0")
        End If
    End Sub

    Public Function fillAutocomplete(ByVal dgv As DataGridView, cellName As String) As AutoCompleteStringCollection
        Dim auto As New AutoCompleteStringCollection
        For i As Integer = 0 To dgv.RowCount - 1
            auto.Add(dgv.Rows(i).Cells(cellName).Value)
        Next
        Return auto
    End Function

    Private Sub dgvSelected_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSelected.CellClick
        If dgvSelected.RowCount <> 0 Then
            If e.ColumnIndex = 2 And panelSAP.Visible = False Then

                Dim resultItemInfo As New DataTable()
                resultItemInfo = loadItemInfo(dgvSelected.CurrentRow.Cells("itemNamee").Value)
                If resultItemInfo.Rows.Count > 0 Then
                    For Each r0w As DataRow In resultItemInfo.Rows
                        Dim itemcode As String = r0w("itemcode"),
                    itemName As String = r0w("itemname"),
                    category As String = r0w("category"),
                    quantity As Integer = dgvSelected.CurrentRow.Cells("quantity").Value
                        addEdit(dgvSelected, itemcode, itemName, category, quantity.ToString("N0"), "EDIT")
                    Next
                End If
            ElseIf e.ColumnIndex = 3 And panelSAP.Visible = False Then
                Dim a As String = MsgBox("Are you sure you want to remove?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MessageBoxDefaultButton.Button2, "Atlantic Bakery")
                If a = vbYes Then
                    dgvSelected.Rows.RemoveAt(e.RowIndex)
                    'lblSelectedItemCount.Text = CInt(dgvSelectedItem.Rows.Count).ToString("N0")
                    txtSelected.AutoCompleteCustomSource = fillAutocomplete(dgvSelected, "itemNamee")
                End If
            End If
        End If
    End Sub

    Private Sub btnProceed_Click(sender As Object, e As EventArgs) Handles btnProceed.Click
        If dgvSelected.Rows.Count = 0 Then
            MessageBox.Show("No Item Selected", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            clearSAPDialog(True)
        End If
    End Sub

    Public Sub loadBranches()
        Dim result As New DataTable(),
            query As String = "SELECT branchcode AS result FROM vLoadBranches WHERE status=1 AND main !=1"
        result = rec.loadBranchesCustomers(query)
        cmbranches.Items.Clear()
        For Each r0w As DataRow In result.Rows
            cmbranches.Items.Add(r0w("result"))
        Next
    End Sub

    Public Sub clearSAPDialog(isVisible)
        panelSAP.Visible = isVisible
        txtsap.Text = ""
        txtremarks.Text = ""
        cmbStatus.SelectedIndex = 0
        cmbranches.SelectedIndex = -1
    End Sub
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If String.IsNullOrEmpty(txtsap.Text) And cmbStatus.SelectedIndex.Equals(1) Then
            MessageBox.Show("Please input SAP #", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf Not IsNumeric(txtsap.Text) And cmbStatus.SelectedIndex.Equals(1) Then
            MessageBox.Show("SAP # must be a number", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf Trim(txtsap.Text).Length <= 5 And cmbStatus.SelectedIndex.Equals(1) Then
            MessageBox.Show("SAP # must be a 6 numbers", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf String.IsNullOrEmpty(cmbranches.Text) Then
            MessageBox.Show("Branch field is empty", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf String.IsNullOrEmpty(txtremarks.Text) Then
            MessageBox.Show("Remarks field is empty", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim dtItems As New DataTable()
            dtItems.Columns.Add("item")
            dtItems.Columns.Add("quantity")
            For i As Integer = 0 To dgvSelected.RowCount - 1
                dtItems.Rows.Add(dgvSelected.Rows(i).Cells("itemNamee").Value, dgvSelected.Rows(i).Cells("quantity").Value)
            Next

            rec.inventoryNumber = itemc.getInvID()
            rec.tableName = "pullout2"
            rec.sapDocument = lblsapdoc.Text
            rec.headerText = "Pull Out"
            rec.remarks = txtremarks.Text
            rec.fromBranchSupplier = cmbranches.Text
            rec.sapNumber = IIf(String.IsNullOrEmpty(Trim(txtsap.Text)), 0, txtsap.Text)
            rec.type = "Pull Out"
            rec.type2 = "Pull Out"
            Dim transactionNumber As String = rec.returnTransactionNumber(True)
            rec.transactionNumber = transactionNumber
            rec.updatePullOut(dtItems)
            clearSAPDialog(False)
            dgvSelected.Rows.Clear()
            Control.CheckForIllegalCrossThreadCalls = False
            Dim th As New Threading.Thread(AddressOf loadData)
            th.Start()
        End If
    End Sub

    Private Sub btnSelected_Click(sender As Object, e As EventArgs) Handles btnSelected.Click
        searchSelected()
    End Sub

    Public Sub searchSelected()
        For i As Integer = 0 To dgvSelected.Rows.Count - 1
            If dgvSelected.Rows(i).Cells("itemnamee").Value.ToString.ToLower = txtSelected.Text.ToLower Then
                dgvSelected.Rows(i).Selected = True
                dgvSelected.CurrentCell = dgvSelected.Rows(i).Cells("itemNamee")
            Else
                dgvSelected.Rows(i).Selected = False
            End If
        Next
        If dgvSelected.RowCount <> 0 And Not String.IsNullOrEmpty(Trim(txtSelected.Text)) Then

            Dim resultItemInfo As New DataTable()
            resultItemInfo = loadItemInfo(dgvSelected.CurrentRow.Cells("itemNamee").Value)
            If resultItemInfo.Rows.Count > 0 Then
                For Each r0w As DataRow In resultItemInfo.Rows
                    Dim itemcode As String = r0w("itemcode"),
                    itemName As String = r0w("itemname"),
                    category As String = r0w("category"),
                    quantity As Integer = dgvSelected.CurrentRow.Cells("quantity").Value
                    addEdit(dgvSelected, itemcode, itemName, category, quantity.ToString("N0"), "EDIT")
                Next
            End If
            'lblSelectedItemCount.Text = CInt(dgvSelectedItem.Rows.Count).ToString("N0")
        End If
    End Sub

    Private Sub txtSelected_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSelected.KeyDown
        If e.KeyCode = Keys.Enter Then
            searchSelected()
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        addQuantityValidation()
    End Sub

    Private Sub lblSAPClose_Click(sender As Object, e As EventArgs) Handles lblSAPClose.Click
        clearSAPDialog(False)
    End Sub

    Private Sub cmbStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStatus.SelectedIndexChanged
        txtsap.Text = ""
        txtsap.Enabled = IIf(cmbStatus.SelectedIndex.Equals(1), True, False)
    End Sub
End Class