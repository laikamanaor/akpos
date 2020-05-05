Imports AK_POS.received_class
Public Class received_item2
    ''' <summary>
    ''' type of received
    ''' </summary>
    Public received_type As String = ""
    Private datecreated As String = ""
    ''' <summary>
    ''' class libraries used
    ''' </summary>
    Dim recc As New received_class()
    Private Sub received_item2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''default view when form appear
        dtdate.Value = DateTime.Now
        dtdate.MaxDate = DateTime.Now
        datecreated = dtdate.Text
        dtdate.Visible = IIf(login2.wrkgrp = "LC Accounting", True, False)
        lblheader.Text = received_type
        loadCategories()
        loadListItems()
        If received_type = "RECEIVED FROM OTHER BRANCH" Or received_type = "RECEIVED FROM DIRECT SUPPLIER" Then
            loadBranchesCustomers()
            cmbranches.Visible = True
            Label10.Visible = True
        Else
            cmbranches.Visible = False
            Label10.Visible = False
        End If
    End Sub

    ''' <summary>
    ''' load branchcode and supplier to combobox
    ''' </summary>
    Public Sub loadBranchesCustomers()
        Dim query As String = "", result As New DataTable(),
            otherBranchQuery As String = "SELECT name  AS result FROM tblcustomers WHERE type='Supplier' AND status=1",
                directSupplierQuery As String = "SELECT branchcode AS result FROM vLoadBranches WHERE status=1"
        query = IIf(received_type = "RECEIVED FROM OTHER BRANCH", otherBranchQuery, directSupplierQuery)
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
        recc.setDateCreated(datecreated)
        recc.setItemName(txtboxListItemSearch.Text)
        recc.setCategory(cmbCategoryListItem.Text)
        Dim result As New DataTable()
        result = recc.loadAvailableItems()
        dgvListItem.Rows.Clear()
        Dim auto As New AutoCompleteStringCollection()
        For Each r0w As DataRow In result.Rows
            dgvListItem.Rows.Add(r0w("itemcode"), r0w("itemname"), r0w("category"))
            auto.Add(r0w("itemname"))
        Next
        txtboxListItemSearch.AutoCompleteCustomSource = auto
        lblListItemCount.Text = dgvListItem.RowCount.ToString("N0")
    End Sub

    Private Sub dtdate_ValueChanged(sender As Object, e As EventArgs) Handles dtdate.ValueChanged
        datecreated = dtdate.Text
    End Sub

    Private Sub cmbCategoryListItem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategoryListItem.SelectedIndexChanged, btnSearchListItem.Click
        loadListItems()
    End Sub

    Private Sub txtboxListItemSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtboxListItemSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            loadListItems()
        End If
    End Sub

    Private Sub dgvListItem_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListItem.CellClick
        If dgvListItem.Rows.Count <> 0 Then
            If e.ColumnIndex = 3 Then
                receivedItem_add.txtitemcode.Text = dgvListItem.CurrentRow.Cells("itemcode").Value
                receivedItem_add.txtitemname.Text = dgvListItem.CurrentRow.Cells("itemname").Value
                receivedItem_add.txtcategory.Text = dgvListItem.CurrentRow.Cells("category").Value
                receivedItem_add.txtquantity.Text = ""
                receivedItem_add.ShowDialog()
                If receivedItem_add.isSuccess Then
                    Dim itemname As String = "", itemcode As String = "", category As String = "", quantity As Double = 0.00
                    itemname = receivedItem_add.txtitemname.Text
                    itemcode = receivedItem_add.txtitemcode.Text
                    category = receivedItem_add.txtcategory.Text
                    quantity = receivedItem_add.txtquantity.Text
                    receivedItem_add.txtquantity.Focus()
                    If dgvSelectedItem.Rows.Count = 0 Then
                        dgvSelectedItem.Rows.Add(itemcode, itemname, category, quantity)
                    Else
                        For index As Integer = 0 To dgvSelectedItem.RowCount - 1
                            If dgvSelectedItem.Rows(index).Cells("itemnamee").Value = itemname Then
                                dgvSelectedItem.Rows(index).Cells("quantityy").Value += quantity
                                Return
                            Else
                                dgvSelectedItem.Rows.Add(itemcode, itemname, category, quantity)
                                Return
                            End If
                        Next
                    End If
            End If
        End If
        End If
    End Sub
End Class