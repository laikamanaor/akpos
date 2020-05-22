Imports AK_POS.received_class
Imports AK_POS.items_class
Public Class received_item2
    ''' <summary>
    ''' type of received
    ''' </summary>
    Public received_type As String = ""
    Public Shared cnfrm As Boolean = False
    ''' <summary>
    ''' class libraries used
    ''' </summary>
    Dim recc As New received_class(), itemc As New items_class()
    Private Sub received_item2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''default view when form appear
        lblheader.Text = received_type
        loadCategories()
        loadListItems()
        If received_type = "Received from Other Branch" Or received_type = "Received from Direct Supplier" Or received_type = "Transfer Out" Then
            loadBranchesCustomers()
            cmbranches.Visible = True
            Label10.Visible = True
        Else
            cmbranches.Visible = False
            Label10.Visible = False
        End If
        btnconvin.Visible = IIf(lblheader.Text = "Conversion Out", True, False)
    End Sub


    ''' <summary>
    ''' load branchcode and supplier to combobox
    ''' </summary>
    Public Sub loadBranchesCustomers()
        Dim query As String = "", result As New DataTable(),
            otherBranchQuery As String = "SELECT branchcode AS result FROM vLoadBranches WHERE status=1",
                directSupplierQuery As String = "SELECT name  AS result FROM tblcustomers WHERE type='Supplier' AND status=1"
        If received_type = "Received from Other Branch" Or received_type = "Transfer Out" Then
            query = otherBranchQuery
        Else
            query = directSupplierQuery
        End If
        result = recc.loadBranchesCustomers(query)
        cmbranches.Items.Clear()
        For Each r0w As DataRow In result.Rows
            cmbranches.Items.Add(r0w("result"))
        Next
        'cmbranches.SelectedIndex = IIf(cmbranches.Items.Count <> 0, 0, Nothing)
    End Sub

    ''' <summary>
    ''' load categories to combobox
    ''' </summary>
    Public Sub loadCategories()
        Dim result As New DataTable()
        result = recc.loadCategories()
        cmbCategoryListItem.Items.Clear()
        cmbCategoryListItem.Items.Add("All")
        For Each r0w As DataRow In result.Rows
            cmbCategoryListItem.Items.Add(r0w("result"))
        Next
        cmbCategoryListItem.SelectedIndex = 0
    End Sub


    ''' <summary>
    ''' load items available
    ''' </summary>
    Public Sub loadListItems()
        recc.setDateCreated(DateTime.Now.ToString("MM/dd/yyy"))
        recc.setItemName(txtboxListItemSearch.Text)
        recc.setCategory(cmbCategoryListItem.Text)
        Dim result As New DataTable()
        'result = recc.loadAvailableItems(IIf(lblheader.Text = "Transfer Out", "trans", "rec"))
        If lblheader.Text = "Transfer Out" Or lblheader.Text = "Conversion Out" Then
            result = recc.loadAvailableItems("trans")
        Else
            result = recc.loadAvailableItems("rec")
        End If
        dgvListItem.Rows.Clear()
        For Each r0w As DataRow In result.Rows
            dgvListItem.Rows.Add(r0w("itemcode"), r0w("itemname"), r0w("category"))
        Next
        txtboxListItemSearch.AutoCompleteCustomSource = fillAutocomplete(dgvListItem, "itemname")
        lblListItemCount.Text = dgvListItem.RowCount.ToString("N0")
    End Sub

    Private Sub cmbCategoryListItem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategoryListItem.SelectedIndexChanged
        loadListItems()
    End Sub

    Private Sub txtboxListItemSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtboxListItemSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            loadListItems()
            If dgvListItem.RowCount <> 0 And Not String.IsNullOrEmpty(txtboxListItemSearch.Text) Then
                addQuantityValidation()
            End If
        End If
    End Sub

    Private Sub dgvListItem_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListItem.CellClick
        If dgvListItem.Rows.Count <> 0 Then
            If e.ColumnIndex = 3 And panelSAP.Visible = False Then
                addQuantityValidation()
            End If
        End If
    End Sub
    Public Sub addQuantityValidation()
        Dim checkError As Integer = 0
        For index As Integer = 0 To dgvSelectedItem.RowCount - 1
            If dgvSelectedItem.Rows(index).Cells("itemnamee").Value.ToString.ToLower = dgvListItem.CurrentRow.Cells("itemname").Value.ToString.ToLower Then
                checkError += 1
            End If
        Next
        If checkError <> 0 Then
            MessageBox.Show("'" & dgvListItem.CurrentRow.Cells("itemname").Value & "' has already exist in Selected Item", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim itemcode As String = dgvListItem.CurrentRow.Cells("itemcode").Value,
                 itemname As String = dgvListItem.CurrentRow.Cells("itemname").Value,
                  category As String = dgvListItem.CurrentRow.Cells("category").Value,
                  quantity As String = 0
            addEdit(dgvSelectedItem, itemcode, itemname, category, quantity, "ADD")
        End If
    End Sub
    Public Sub addEdit(ByVal dgv As DataGridView, ByVal icode As String, ByVal iname As String, ByVal icat As String, iquantity As Double, ByVal typee As String)
        receivedItem_add.txtitemcode.Text = icode
        receivedItem_add.txtitemname.Text = iname
        receivedItem_add.txtcategory.Text = icat
        receivedItem_add.txtquantity.Text = iquantity
        receivedItem_add.lblheader.Text = typee & " QUANTITY"
        receivedItem_add.txtquantity.Focus()
        receivedItem_add.ShowDialog()
        If receivedItem_add.isSuccess Then
            Dim itemname As String = "", itemcode As String = "", category As String = "", quantity As Double = 0.00
            itemname = receivedItem_add.txtitemname.Text
            itemcode = receivedItem_add.txtitemcode.Text
            category = receivedItem_add.txtcategory.Text
            quantity = receivedItem_add.txtquantity.Text
            receivedItem_add.txtquantity.Focus()
            If typee = "ADD" Then
                dgv.Rows.Add(itemcode, itemname, category, quantity)
            Else
                dgv.CurrentRow.Cells("quantityy").Value = quantity
            End If
            txtboxSelectedItem.AutoCompleteCustomSource = fillAutocomplete(dgvSelectedItem, "itemnamee")
            lblSelectedItemCount.Text = CInt(dgvSelectedItem.Rows.Count).ToString("N0")
        End If
    End Sub

    Public Function fillAutocomplete(ByVal dgv As DataGridView, cellName As String) As AutoCompleteStringCollection
        Dim auto As New AutoCompleteStringCollection
        For i As Integer = 0 To dgv.RowCount - 1
            auto.Add(dgv.Rows(i).Cells(cellName).Value)
        Next
        Return auto
    End Function

    Private Sub btnSearchListItem_Click(sender As Object, e As EventArgs) Handles btnSearchListItem.Click
        loadListItems()
        If dgvListItem.RowCount <> 0 And Not String.IsNullOrEmpty(txtboxListItemSearch.Text) Then
            addQuantityValidation()
        End If
    End Sub

    Private Sub dgvSelectedItem_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSelectedItem.CellClick
        If dgvSelectedItem.RowCount <> 0 Then
            If e.ColumnIndex = 4 And panelSAP.Visible = False Then
                Dim itemcode As String = dgvSelectedItem.CurrentRow.Cells("itemcodee").Value,
                 itemname As String = dgvSelectedItem.CurrentRow.Cells("itemnamee").Value,
                  category As String = dgvSelectedItem.CurrentRow.Cells("categoryy").Value,
                  quantity As String = dgvSelectedItem.CurrentRow.Cells("quantityy").Value
                addEdit(dgvSelectedItem, itemcode, itemname, category, quantity, "EDIT")
            ElseIf e.ColumnIndex = 5 And panelSAP.Visible = False Then
                Dim a As String = MsgBox("Are you sure you want to remove?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MessageBoxDefaultButton.Button2, "Atlantic Bakery")
                If a = vbYes Then
                    dgvSelectedItem.Rows.RemoveAt(e.RowIndex)
                    lblSelectedItemCount.Text = CInt(dgvSelectedItem.Rows.Count).ToString("N0")
                    txtboxSelectedItem.AutoCompleteCustomSource = fillAutocomplete(dgvSelectedItem, "itemnamee")
                End If
            End If
        End If
    End Sub

    Public Sub searchSelected()
        For i As Integer = 0 To dgvSelectedItem.Rows.Count - 1
            If dgvSelectedItem.Rows(i).Cells("itemnamee").Value.ToString.ToLower = txtboxSelectedItem.Text.ToLower Then
                dgvSelectedItem.Rows(i).Selected = True
                dgvSelectedItem.CurrentCell = dgvSelectedItem.Rows(i).Cells("itemnamee")
            Else
                dgvSelectedItem.Rows(i).Selected = False
            End If
        Next
        If dgvSelectedItem.RowCount <> 0 And Not String.IsNullOrEmpty(Trim(txtboxSelectedItem.Text)) Then
            Dim itemcode As String = dgvSelectedItem.CurrentRow.Cells("itemcodeE").Value,
                 itemname As String = dgvSelectedItem.CurrentRow.Cells("itemnamee").Value,
                  category As String = dgvSelectedItem.CurrentRow.Cells("categoryy").Value,
                  quantity As String = dgvSelectedItem.CurrentRow.Cells("quantityy").Value
            addEdit(dgvSelectedItem, itemcode, itemname, category, quantity, "EDIT")
            lblSelectedItemCount.Text = CInt(dgvSelectedItem.Rows.Count).ToString("N0")
        End If
    End Sub

    Private Sub btnselected_Click(sender As Object, e As EventArgs) Handles btnselected.Click
        searchSelected()
    End Sub

    Private Sub txtboxSelectedItem_KeyDown(sender As Object, e As KeyEventArgs) Handles txtboxSelectedItem.KeyDown
        If e.KeyCode = Keys.Enter Then
            searchSelected()
        End If
    End Sub

    Public Sub clearSAPDialog()
        panelSAP.Visible = False
        txtsap.Text = ""
        txtremarks.Text = ""
        checkfollowup.Checked = False
        chckSAP.Checked = True
    End Sub

    Private Sub lblSAPClose_Click(sender As Object, e As EventArgs) Handles lblSAPClose.Click
        clearSAPDialog()
    End Sub

    Private Sub chckSAP_CheckedChanged(sender As Object, e As EventArgs) Handles chckSAP.CheckedChanged
        If chckSAP.Checked Then
            checkfollowup.Checked = False
            checkfollowup.Enabled = True
            txtsap.Enabled = True
            txtsap.Text = ""
        Else
            checkfollowup.Checked = False
            checkfollowup.Enabled = False
            txtsap.Enabled = False
            txtsap.Text = ""
        End If
    End Sub

    Private Sub checkfollowup_CheckedChanged(sender As Object, e As EventArgs) Handles checkfollowup.CheckedChanged
        If checkfollowup.Checked Then
            txtsap.Text = ""
            txtsap.Enabled = False
        Else
            txtsap.Text = ""
            txtsap.Enabled = True
        End If
    End Sub

    Private Sub txtremarks_KeyDown(sender As Object, e As KeyEventArgs) Handles txtremarks.KeyDown, txtsap.KeyDown
        If e.KeyCode = Keys.Escape Then
            clearSAPDialog()
        End If
    End Sub

    Private Sub btnProceed_Click(sender As Object, e As EventArgs) Handles btnProceed.Click
        If String.IsNullOrEmpty(txtsap.Text) And checkfollowup.Checked = False And chckSAP.Checked Then
            MessageBox.Show("Please input SAP #", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf Not IsNumeric(txtsap.Text) And checkfollowup.Checked = False And chckSAP.Checked Then
            MessageBox.Show("SAP # must be a number", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf Trim(txtsap.Text).Length <= 5 And checkfollowup.Checked = False And chckSAP.Checked Then
            MessageBox.Show("SAP # must be a 6 numbers", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If lblheader.Text = "Transfer Out" Then
                confirm.ShowDialog()
                If cnfrm = False Then
                    addInventory()
                    loadListItems()
                End If
            Else
                addInventory()
            End If
        End If
    End Sub
    Public Sub addInventory()
        Dim tableName As String = "", dtItems As New DataTable(), transactionNumber As String = ""
        Select Case lblheader.Text
            Case "Received from Production"
                tableName = "productionin"
            Case "Received from Other Branch"
                tableName = "itemin"
            Case "Received from Direct Supplier"
                tableName = "supin"
            Case "Received from Adjustment"
                tableName = "adjustmentin"
            Case "Transfer Out"
                tableName = "transfer"
            Case "Conversio Out"
                tableName = "convout"
        End Select
        dtItems.Columns.Add("item")
        dtItems.Columns.Add("quantity")
        For i As Integer = 0 To dgvSelectedItem.RowCount - 1
            dtItems.Rows.Add(dgvSelectedItem.Rows(i).Cells("itemnamee").Value, dgvSelectedItem.Rows(i).Cells("quantityy").Value)
        Next
        If lblheader.Text <> "Received from Production" Or lblheader.Text <> "Received from Adjustment" Then
            recc.fromBranchSupplier = cmbranches.Text
        End If
        recc.inventoryNumber = itemc.getInvID()
        recc.headerText = lblheader.Text
        recc.tableName = tableName
        recc.sapDocument = lblsapdoc.Text
        recc.remarks = txtremarks.Text
        recc.sapNumber = IIf(String.IsNullOrEmpty(Trim(txtsap.Text)), 0, txtsap.Text)
        transactionNumber = recc.returnTransactionNumber(IIf(lblheader.Text = "Conversion Out", False, True))
        recc.transactionNumber = transactionNumber
        recc.updateInventory(dtItems)
        dgvSelectedItem.Rows.Clear()
        clearSAPDialog()
    End Sub

    Private Sub txtsap_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtsap.KeyPress
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnconvin_Click(sender As Object, e As EventArgs) Handles btnconvin.Click
        Dim conversion2 As New conversions2()
        conversion2.ShowDialog()
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If itemc.getInvID() = "N/A" Then
            MessageBox.Show("Created New Inventory first", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf dgvSelectedItem.RowCount = 0 Then
            MessageBox.Show("Pick item(s) first", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf received_type = "Received from Other Branch" And cmbranches.Text = "" Then
            MessageBox.Show("Pick branch first", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf received_type = "Transfer Out" And cmbranches.Text = "" Then
            MessageBox.Show("Pick branch first", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf received_type = "Received from Direct Supplier" And cmbranches.Text = "" Then
            MessageBox.Show("Pick supplier first", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            chckSAP.Visible = IIf(lblheader.Text = "Received from Adjustment", True, False)
            Select Case lblheader.Text
                Case "Received from Adjustment"
                    lblsapdoc.Text = "GR"
                Case "Received from Production"
                    lblsapdoc.Text = "IT"
                Case "Received from Other Branch"
                    lblsapdoc.Text = "IT"
                Case "Transfer Out"
                    lblsapdoc.Text = "IT"
                Case "Received from Direct Supplier"
                    lblsapdoc.Text = "GRPO"
                Case "Conversion Out"
                    lblsapdoc.Text = "GI"
            End Select
            panelSAP.Visible = True
        End If
    End Sub
End Class