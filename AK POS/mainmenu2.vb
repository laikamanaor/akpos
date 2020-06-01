Imports AK_POS.pos2_class
Imports AK_POS.user_class
Imports AK_POS.customer_class
Imports AK_POS.discount_class
Imports AK_POS.connection_class
Imports AK_POS.received_class
Imports AK_POS.cashier_class
Imports System.Data.SqlClient
Public Class mainmenu2
    Dim posc As New pos2_class, uc As New user_class(), custc As New customer_class(), discc As New discount_class(), cc As New connection_class, transaction As SqlTransaction, recc As New received_class(), cashc As New cashier_class()

    Private catoffset As Integer = 0, catrowFetch As Integer = 4, cattotalCount As Integer = 0, cattotalPage As Integer = 0, catcurrentPage As Integer = 1,
        itemoffset As Integer = 0, itemrowFetch As Integer = 30, itemtotalCount As Integer = 0, itemtotalPage As Integer = 0, itemcurrentPage As Integer = 1

    Dim tendetype As String = "", cashierOrderNumber As Integer = 0, cashierPOSType As String = ""

    Public apdep As Double = 0.00, orderid As Integer = 0, isConfirm As Boolean = False
    Public Shared voidd As Boolean = False
    Private Sub mainmenu2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadSelectedTransaction()
        'check if user workgroup is sales,manager and cashier the datetimepicker is become visible
        If login2.wrkgrp = "Sales" Or login2.wrkgrp = "Manager" Or login2.wrkgrp = "Cashier" Then
            dtdate.Visible = False
            Label11.Visible = False
        Else
            dtdate.Visible = True
            Label11.Visible = True
        End If

        'assign datetimepicker to date now
        dtdate.Text = DateTime.Now.ToString("MM/dd/yyyy")
        'assign datetimepicker max date to date now add one day
        dtdate.MaxDate = DateTime.Now.AddDays(1)
        'get count of categories
        cattotalCount = catcountLoadItems()
        'assign total page to total count divided by rowfetch times one
        cattotalPage = Math.Ceiling(cattotalCount / catrowFetch) * 1
        'call loadcategories sub
        catloadCategories()

        'set item and datecreated to pos class
        posc.setItem(txtsearch.Text)
        posc.datecreated = dtdate.Text
        'get count of items
        itemtotalCount = itemcountLoadItems()
        'assign total page to total count divided by rowfetch times one
        itemtotalPage = Math.Ceiling(itemtotalCount / itemrowFetch) * 1
        'call loaditems sub
        loadItems("")
        'assign string collection from itemautocomplete function
        txtsearch.AutoCompleteCustomSource = ItemAutoComplete()
        'assign order number if user is cashier it return cashier want to transact if not return the latest order number
        lblordernumber.Text = IIf(login2.wrkgrp = "Cashier", cashierOrderNumber, 0)
        lblordernumber.Visible = IIf(login2.wrkgrp = "Cashier", True, False)
        Label44.Visible = IIf(login2.wrkgrp = "Cashier", True, False)
        btnlast10.Enabled = IIf(login2.wrkgrp = "Cashier", False, True)
        'load discounts
        loadDiscounts()

        confirm_modify()

        If login2.wrkgrp = "Cashier" Then
            loadSelectedTransaction()
        End If

    End Sub

    Public Sub loadSelectedTransaction()
        loadItemsWhereID()
        loadBillsWhereID()
    End Sub

    Public Sub loadItemsWhereID()
        Dim result As New DataTable()
        cashc.datee = Date.Now
        cashc.orderid = orderid
        dgv.Rows.Clear()
        result = cashc.loadItems()
        For Each r0w As DataRow In result.Rows
            dgv.Rows.Add(r0w("itemname"), CInt(r0w("qty")).ToString("N0"), CDbl(r0w("price")).ToString("n2"), CInt(r0w("dscnt")).ToString("N0"), CDbl(r0w("totalprice")).ToString("n2"), IIf(CInt(r0w("free")) = 0, False, True), CDbl(r0w("pricebefore")).ToString("n2"), CDbl(r0w("discamt")).ToString("n2"))
        Next
    End Sub

    Public Sub loadBillsWhereID()
        Dim result As New DataTable()
        cashc.orderid = orderid
        result = cashc.loadBills()
        If result.Rows.Count > 0 Then
            For Each r0w As DataRow In result.Rows
                lblsubtotalbefore.Text = CDbl(r0w("subtotal")).ToString("n2")
                cmbdisctype.Text = IIf(String.IsNullOrEmpty(r0w("disctype").ToString), "", r0w("disctype"))
                lbldiscpercent.Text = CInt(r0w("less")).ToString("N0") & "%"
                lbldiscamt.Text = CDbl(r0w("discamt")).ToString("n2")
                lblamountpayable.Text = CDbl(r0w("amtdue")).ToString("n2")
                txtamounttendered.Text = CDbl(r0w("tenderamt")).ToString("n2")
                lblchange.Text = CDbl(r0w("change")).ToString("n2")
            Next
        Else
            lblsubtotalbefore.Text = "0.00"
            cmbdisctype.Text = ""
            lbldiscpercent.Text = "0%"
            lbldiscamt.Text = "0.00"
            lblamountpayable.Text = "0.00"
            txtamounttendered.Text = "0.00"
            lblchange.Text = "0.00"
        End If
    End Sub

    Public Sub confirm_modify()
        btncancel.Enabled = IIf(isConfirm, False, True)
        rbcash.Enabled = IIf(isConfirm, False, True)
        rbcharge.Enabled = IIf(isConfirm, False, True)
        rbsales.Enabled = IIf(isConfirm, False, True)
        cmbdisctype.Enabled = IIf(isConfirm, False, True)
        btngcbrowse.Enabled = IIf(isConfirm, False, True)
        dgv.Columns("free").ReadOnly = IIf(isConfirm, True, False)
    End Sub

    ''' <summary>
    ''' get discount name from discount class
    ''' </summary>
    Public Sub loadDiscounts()
        Dim result As New DataTable()
        result = discc.loadDIscounts()
        cmbdisctype.Items.Clear()
        cmbdisctype.Items.Add("")
        For Each r0w As DataRow In result.Rows
            cmbdisctype.Items.Add(r0w("disname"))
        Next
        cmbdisctype.SelectedIndex = 0
    End Sub

    ''' <summary>
    ''' return the latest order number
    ''' </summary>
    ''' <returns></returns>
    Public Function returnOrderNumber() As Integer
        posc.datecreated = dtdate.Text
        Dim result As Integer = posc.returnLatestOrderNumber()
        Return result
    End Function

    ''' <summary>
    ''' return items and stored to string collection
    ''' </summary>
    ''' <returns></returns>
    Public Function ItemAutoComplete() As AutoCompleteStringCollection
        Dim result As New AutoCompleteStringCollection, dtResult As New DataTable()
        dtResult = posc.searchItemFill()
        If dtResult.Rows.Count > 0 Then
            For Each r0w As DataRow In dtResult.Rows
                result.Add(r0w("itemname"))
            Next
        End If
        Return result
    End Function

    ''' <summary>
    ''' category previous button
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btncatprev_Click(sender As Object, e As EventArgs) Handles btncatprev.Click
        If catoffset > 0 Then
            catoffset -= catrowFetch
            catcurrentPage -= 1
            catloadCategories()
            cattotalCount = catcountLoadItems()
            cattotalPage = Math.Ceiling(cattotalCount / catrowFetch) * 1
        Else
            catoffset = 0
            catcurrentPage = 1
        End If
    End Sub
    ''' <summary>
    ''' item previous button
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnitemprev_Click(sender As Object, e As EventArgs) Handles btnitemprev.Click
        'if offset is greater than zero, the offset is decrement on rowfetch, and currrent page decrement to one
        If itemoffset > 0 Then
            itemoffset -= itemrowFetch
            itemcurrentPage -= 1
            loadItems("")
            'set item and datecreated to pos class
            posc.setItem(txtsearch.Text)
            posc.datecreated = dtdate.Text
            'assign count of items
            itemtotalCount = itemcountLoadItems()
            'assign total page to total count divided by rowfetch times one
            itemtotalPage = Math.Ceiling(itemtotalCount / itemrowFetch) * 1
        Else
            'assign offset to zero and current page to one
            itemoffset = 0
            itemcurrentPage = 1
        End If
    End Sub
    ''' <summary>
    ''' item next button
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnitemnxt_Click(sender As Object, e As EventArgs) Handles btnitemnxt.Click
        'offset increament to rowfetch and current page increament to one
        itemoffset += itemrowFetch
        itemcurrentPage += 1
        'check if itemoffset is less than or equal to total count
        If itemoffset <= itemtotalCount Then
            'call loaditems sub
            loadItems("")
            'set item and datecreated to pos class
            posc.setItem(txtsearch.Text)
            posc.datecreated = dtdate.Text
            'assign count of items
            itemtotalCount = itemcountLoadItems()
            'assign total page to total count divided by rowfetch times one
            itemtotalPage = Math.Ceiling(itemtotalCount / itemrowFetch) * 1
        Else
            'decreament offset to rowfetch and current page decreament to one
            itemoffset -= itemrowFetch
            itemcurrentPage -= 1
        End If
    End Sub

    Private Sub dtdate_ValueChanged(sender As Object, e As EventArgs) Handles dtdate.ValueChanged
        'call item refresh sub
        itemsrefreshh("")
    End Sub

    Private Sub txtsearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsearch.KeyDown
        'check if user press enter
        If e.KeyCode = Keys.Enter Then
            'call item name refresh
            itemsrefreshh("")
        End If
    End Sub

    Private Sub btncatnxt_Click(sender As Object, e As EventArgs) Handles btncatnxt.Click
        'offset increament to rowfetch and current page increament to one
        catoffset += catrowFetch
        catcurrentPage += 1
        'check if itemoffset is less than or equal to total count
        If catoffset <= cattotalCount Then
            'call loadcategories sub
            catloadCategories()
            'assign count of categories
            cattotalCount = catcountLoadItems()
            'assign total page to total count divided by rowfetch times one
            cattotalPage = Math.Ceiling(cattotalCount / catrowFetch) * 1
        Else
            'decreament offset to rowfetch and current page decreament to one
            catoffset -= catrowFetch
            catcurrentPage -= 1
        End If
    End Sub

    Private Sub rbcash_CheckedChanged(sender As Object, e As EventArgs) Handles rbcash.CheckedChanged
        'check if user click cash
        If rbcash.Checked Then
            'call sub and assign parameter cash
            toggleTendertype("Cash")
        End If
    End Sub

    Private Sub rbsales_CheckedChanged(sender As Object, e As EventArgs) Handles rbsales.CheckedChanged
        'check if user click cash
        If rbsales.Checked Then
            'call sub and assign parameter ar sales
            toggleTendertype("A.R Sales")
            txtname.Focus()
        End If
    End Sub

    Public Function numbersValidation(ByVal value As String, columnName As String) As Boolean
        Dim result As Boolean = False
        If String.IsNullOrEmpty(value) Then
            MessageBox.Show("Please input quantity", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dgv.CurrentRow.Cells(columnName).Value = "0"
            dgv.CurrentRow.Cells(IIf(columnName = "discpercent", "discamt", columnName)).Value = "0.00"
            dgv.CurrentRow.Cells("amount").Value = (CDbl(dgv.CurrentRow.Cells("quantity").Value) * CDbl(dgv.CurrentRow.Cells("price").Value)).ToString("n2")
            result = True
        ElseIf Not IsNumeric(value) Then
            MessageBox.Show("Quantity must be a number", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dgv.CurrentRow.Cells(columnName).Value = "0"
            dgv.CurrentRow.Cells(IIf(columnName = "discpercent", "discamt", columnName)).Value = "0.00"
            dgv.CurrentRow.Cells("amount").Value = (CDbl(dgv.CurrentRow.Cells("quantity").Value) * CDbl(dgv.CurrentRow.Cells("price").Value)).ToString("n2")
            result = True
        ElseIf CDbl(value) <= 0 Then
            MessageBox.Show("Please input quantity", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dgv.CurrentRow.Cells(columnName).Value = "0"
            dgv.CurrentRow.Cells(IIf(columnName = "discpercent", "discamt", columnName)).Value = "0.00"
            dgv.CurrentRow.Cells("amount").Value = (CDbl(dgv.CurrentRow.Cells("quantity").Value) * CDbl(dgv.CurrentRow.Cells("price").Value)).ToString("n2")
            result = True
        End If
        Return result
    End Function

    Private Sub dgv_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellEndEdit
        If dgv.RowCount > 0 Then
            'quantity field
            If e.ColumnIndex = 1 Then
                If numbersValidation(dgv.CurrentRow.Cells("quantity").Value, "quantity") = True Then
                Else
                    '
                    Dim amount As Double = CDbl(dgv.CurrentRow.Cells("quantity").Value) * CDbl(dgv.CurrentRow.Cells("price").Value)
                    dgv.CurrentRow.Cells("pricebefore").Value = amount.ToString("n2")
                    Dim pricebefore As Double = CDbl(dgv.CurrentRow.Cells("pricebefore").Value)
                    Dim discpercent As Double = CDbl(dgv.CurrentRow.Cells("discpercent").Value)
                    dgv.CurrentRow.Cells("amount").Value = CDbl(amount.ToString("n2") - ((discpercent / 100) * pricebefore)).ToString("n2")
                    dgv.CurrentRow.Cells("discamt").Value = CDbl((discpercent / 100) * pricebefore).ToString("n2")
                End If
            ElseIf e.ColumnIndex = 3 And CInt(dgv.CurrentRow.Cells("quantity").Value) > 0 Then
                If numbersValidation(dgv.CurrentRow.Cells("discpercent").Value, "discpercent") = True Then
                ElseIf CInt(dgv.CurrentRow.Cells("discpercent").Value > 25) Then
                    MessageBox.Show("Up To 25% discount only", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Dim pricebefore As Double = CDbl(dgv.CurrentRow.Cells("quantity").Value) * CDbl(dgv.CurrentRow.Cells("price").Value)
                    dgv.CurrentRow.Cells("discpercent").Value = 25
                    dgv.CurrentRow.Cells("amount").Value = CDbl(pricebefore - ((25 / 100) * pricebefore)).ToString("n2")
                    dgv.CurrentRow.Cells("discamt").Value = CDbl((25 / 100) * pricebefore).ToString("n2")

                Else
                    Dim amount As Double = 0.00
                    amount = CDbl(dgv.CurrentRow.Cells("quantity").Value) * CDbl(dgv.CurrentRow.Cells("price").Value)
                    Dim pricebefore As Double = CDbl(dgv.CurrentRow.Cells("pricebefore").Value)
                    Dim discpercent As Double = CDbl(dgv.CurrentRow.Cells("discpercent").Value)
                    dgv.CurrentRow.Cells("amount").Value = CDbl(amount.ToString("n2") - ((discpercent / 100) * pricebefore)).ToString("n2")
                    dgv.CurrentRow.Cells("discamt").Value = CDbl((discpercent / 100) * pricebefore).ToString("n2")
                End If

            ElseIf e.ColumnIndex = 4 And CInt(dgv.CurrentRow.Cells("quantity").Value) > 0 Then
                If numbersValidation(dgv.CurrentRow.Cells("amount").Value, "amount") = True Then
                ElseIf CDbl(dgv.CurrentRow.Cells("amount").Value) > (CDbl(dgv.CurrentRow.Cells("price").Value) * CDbl(dgv.CurrentRow.Cells("quantity").Value)) Then
                    Dim amount As Double = CDbl(dgv.CurrentRow.Cells("quantity").Value) * CDbl(dgv.CurrentRow.Cells("price").Value)
                    dgv.CurrentRow.Cells("amount").Value = amount.ToString("n2")
                    Dim discpercent As Double = ((amount - dgv.CurrentRow.Cells("amount").Value) / amount) * 100
                    Dim pricebefore As Double = CDbl(dgv.CurrentRow.Cells("pricebefore").Value)
                    dgv.CurrentRow.Cells("discpercent").Value = discpercent.ToString("n2")
                    dgv.CurrentRow.Cells("discamt").Value = CDbl((discpercent / 100) * pricebefore).ToString("n2")
                Else
                    Dim amount As Double = CDbl(dgv.CurrentRow.Cells("quantity").Value) * CDbl(dgv.CurrentRow.Cells("price").Value)
                    Dim discpercent As Double = ((amount - dgv.CurrentRow.Cells("amount").Value) / amount) * 100
                    Dim pricebefore As Double = CDbl(dgv.CurrentRow.Cells("pricebefore").Value)
                    dgv.CurrentRow.Cells("discpercent").Value = discpercent.ToString("n2")
                    dgv.CurrentRow.Cells("discamt").Value = CDbl((discpercent / 100) * pricebefore).ToString("n2")
                    dgv.CurrentRow.Cells("amount").Value = CDbl(dgv.CurrentRow.Cells("amount").Value).ToString("n2")
                End If
            ElseIf e.ColumnIndex = 5 Then
                If dgv.CurrentRow.Cells("free").Value = True Then
                    If pos_dialog.ans <> "Coffee Shop" Then
                        confirm.ShowDialog()
                        If voidd Then
                            dgv.CurrentRow.Cells("quantity").Value = 0
                            dgv.CurrentRow.Cells("discpercent").Value = 0
                            dgv.CurrentRow.Cells("amount").Value = "0.00"
                            dgv.CurrentRow.Cells("pricebefore").Value = "0.00"
                            dgv.CurrentRow.Cells("discamt").Value = "0.00"
                        End If
                    Else
                        dgv.CurrentRow.Cells("quantity").Value = 0
                        dgv.CurrentRow.Cells("discpercent").Value = 0
                        dgv.CurrentRow.Cells("amount").Value = "0.00"
                        dgv.CurrentRow.Cells("pricebefore").Value = "0.00"
                        dgv.CurrentRow.Cells("discamt").Value = "0.00"
                    End If
                End If
            End If
                'call computeTotal sub
                computeTotal()
        End If
    End Sub

    Private Sub btncat1_Click(sender As Object, e As EventArgs) Handles btncat1.Click
        If isConfirm = False Then
            itemsrefreshh(btncat1.Text)
        End If
    End Sub

    Private Sub btncat2_Click(sender As Object, e As EventArgs) Handles btncat2.Click
        If isConfirm = False Then
            itemsrefreshh(btncat2.Text)
        End If
    End Sub

    Private Sub btncat3_Click(sender As Object, e As EventArgs) Handles btncat3.Click
        If isConfirm = False Then
            itemsrefreshh(btncat3.Text)
        End If
    End Sub

    Private Sub btncat4_Click(sender As Object, e As EventArgs) Handles btncat4.Click
        If isConfirm = False Then
            itemsrefreshh(btncat4.Text)
        End If
    End Sub

    Private Sub dgv_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellEnter
        dgv.Focus()
    End Sub

    Private Sub mainmenu2_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub cmbdisctype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbdisctype.SelectedIndexChanged
        If dgv.RowCount > 0 Then
            If cmbdisctype.Text <> "" Then
                'insert info there
                If login2.wrkgrp <> "Cashier" And cmbdisctype.SelectedItem <> "Ar Discount Pullout" Then
                    senior.txtidno.Clear()
                    senior.txtname.Clear()
                    senior.ShowDialog()
                    If senior.add Then
                        discc.discountName = cmbdisctype.Text
                        lbldiscpercent.Text = discc.returnAmount() & "%"
                        lbldiscamt.Text = CDbl(CDbl(lblsubtotalbefore.Text) * CDbl(lbldiscpercent.Text.Replace("%", "") / 100)).ToString("n2")
                    Else
                        cmbdisctype.SelectedIndex = 0
                        lbldiscpercent.Text = "0%"
                        lbldiscamt.Text = "0.00"
                    End If
                End If
            Else
                lbldiscamt.Text = "0.00"
                lbldiscpercent.Text = "0%"
            End If
            computeTotal()
        End If
    End Sub

    Private Sub btngcbrowse_Click(sender As Object, e As EventArgs) Handles btngcbrowse.Click
        If dgv.RowCount > 0 Then
            gcform.ShowDialog()
            If gcform.gccnf Then
                lblgc.Text = gcform.lblgctotal.Text
            Else
                lblgc.Text = "0.00"
            End If
            computeTotal()
        Else
            MessageBox.Show("Enter item first", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub txtamounttendered_TextChanged(sender As Object, e As EventArgs) Handles txtamounttendered.TextChanged
        Try
            lblchange.Text = IIf(CDbl(lblamountpayable.Text) < CDbl(txtamounttendered.Text), CDbl(CDbl(txtamounttendered.Text) - CDbl(lblamountpayable.Text)).ToString("n2"), "0.00")
            lblchange.Text = IIf(String.IsNullOrEmpty(Trim(txtamounttendered.Text)), "0.00", lblchange.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtamounttendered_Leave(sender As Object, e As EventArgs) Handles txtamounttendered.Leave
        If String.IsNullOrEmpty(Trim(txtamounttendered.Text)) Then
            txtamounttendered.Text = "0.00"
        Else
            txtamounttendered.Text = CDbl(txtamounttendered.Text).ToString("n2")
        End If

    End Sub

    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        If dgv.Rows.Count > 0 Then
            If e.ColumnIndex = 8 And isConfirm = False Then
                Dim a As String = MsgBox("Are you sure you want To remove this item?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atlantic Bakery")
                If a = vbYes Then
                    dgv.Rows.RemoveAt(e.RowIndex)
                    computeTotal()
                    lblitemscount.Text = dgv.RowCount.ToString("N0")
                End If
            End If
        End If
    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs) Handles Panel6.Paint

    End Sub

    Private Sub txtamounttendered_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtamounttendered.KeyPress
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        If dgv.RowCount > 0 Then
            Dim a As String = MsgBox("Are you sure you want To cancel?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atlantic Bakery")
            If a = vbYes Then
                dgv.Rows.Clear()
                lblitemscount.Text = dgv.RowCount.ToString("N0")
                computeTotal()
            End If
        Else
            MessageBox.Show("No item found", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnpay_Click(sender As Object, e As EventArgs) Handles btnpay.Click
        If uc.checkCutOff() Then
            MessageBox.Show("POS already cut off", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)

        ElseIf posc.checkQuantity(dgv) <> "" Then
            MessageBox.Show("The item(s) below are 0 quantity. Please enter valid input" & Environment.NewLine & posc.checkQuantity(dgv), "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)

        ElseIf posc.checkQuantityLevel2(dgv) <> "" Then
            MessageBox.Show("The item(s) below are 0 quantity. Please enter valid input" & Environment.NewLine & posc.checkQuantityLevel2(dgv), "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)

        ElseIf posc.checkCSFree(dgv) <> "" Then
            MessageBox.Show("The item(s) below have free bread(s). Please enter valid input" & Environment.NewLine & posc.checkCSFree(dgv), "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)

        ElseIf posc.checkItemAmount(dgv) <> "" Then
            MessageBox.Show("Please input amount In item. Please enter valid input" & Environment.NewLine & posc.checkCSFree(dgv), "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)

        ElseIf posc.checkOrderNumber(cashierOrderNumber.ToString) = True And login2.wrkgrp = "Cashier" Then
            MessageBox.Show("Order # " & lblordernumber.Text & " Is already transact", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)

        ElseIf dgv.RowCount = 0 Then
            MessageBox.Show("No orders entered", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        ElseIf String.IsNullOrEmpty(Trim(txtamounttendered.Text)) OrElse CDbl(txtamounttendered.Text) < (CDbl(lblamountpayable.Text)) And rbcash.Checked And login2.wrkgrp = "Cashier" Then
            computeTotal()
            MsgBox("Amount tendered Is Not enough To pay the bill. Enter amount.", MsgBoxStyle.Exclamation, "")
            txtamounttendered.Focus()

        ElseIf String.IsNullOrEmpty(txtname.Text) Then
            MessageBox.Show("Please enter name", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtname.Focus()

        ElseIf posc.checkCustomer(txtname.Text, IIf(tendetype = "A.R Sales", "Customer", "Employee")) = False And rbcash.Checked = False Then
            MessageBox.Show("Name '" & txtname.Text & "' not found", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtname.Focus()

        ElseIf posc.checkCoffeeShopItem(pos_dialog.ans, dgv).ToLower <> "Below item Is invalid for ".ToLower & pos_dialog.ans.ToLower & Environment.NewLine Then
            MessageBox.Show(posc.checkCoffeeShopItem(pos_dialog.ans, dgv), "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)

        ElseIf Trim(txtamounttendered.Text) = "" Or Val(txtamounttendered.Text) = 0 And login2.wrkgrp = "Cashier" And rbcash.Checked Then

            If String.IsNullOrEmpty(lblchange.Text) And rbcash.Checked Then
                computeTotal()
                MsgBox("Amount tendered is empty. Enter amount first.", MsgBoxStyle.Exclamation, "")
                txtamounttendered.Focus()
            Else

                If posc.checkStocks(dgv, dtdate.Text) <> "" Then
                    Dim a As String = MsgBox("Insufficient supply of item below. Are you sure you want to proceed?" & Environment.NewLine & posc.checkStocks(dgv, dtdate.Text), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atlantic Bakery")

                    If a = vbYes Then
                        confirm.ShowDialog()

                        If voidd Then
                            query()
                        End If

                    End If

                Else
                    query()
                End If

            End If

        Else

            If posc.checkStocks(dgv, dtdate.Text) <> "" Then
                Dim a As String = MsgBox("Insufficient supply of item below. Are you sure you want to proceed?" & Environment.NewLine & posc.checkStocks(dgv, dtdate.Text), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atlantic Bakery")

                If a = vbYes Then

                    confirm.ShowDialog()

                    If voidd Then
                        query()
                    End If

                End If

            Else
                query()
            End If

        End If

    End Sub

    Public Sub query()
        Try
            Using connection As New SqlConnection(cc.conString)
                Dim command As New SqlCommand(),
                 addStock As Double = 0.00, seniorResult As Boolean = False, tayp As String = "", resultNo As Double = 0.00
                command.Connection = connection

                recc.headerText = "Received from Production"
                Dim transactionNumber As String = recc.returnTransactionNumber(True)
                Dim dateParameter As Date = posc.getDateParameterResult()

                connection.Open()
                transaction = connection.BeginTransaction()

                command.Transaction = transaction
                If cashierPOSType = "Coffee Shop" And login2.wrkgrp = "Cashier" Then
                    posc.datecreated = dtdate.Text
                    For i As Integer = 0 To dgv.RowCount - 1
                        posc.setItem(dgv.Rows(i).Cells("item").Value)
                        Dim currentEndbal As Double = posc.returnEndingBalance()
                        If CDbl(dgv.Rows(i).Cells("quantity").Value) > currentEndbal And posc.returnCategory() = "Coffee Shop" Then
                            addStock = CDbl(dgv.Rows(i).Cells("quantity").Value) - currentEndbal
                        End If
                        If currentEndbal < addStock And posc.returnCategory() = "Coffee Shop" Then
                            command.Parameters.Clear()
                            command.CommandText = "insertCSItemsVersion2"
                            command.CommandType = CommandType.StoredProcedure
                            command.Parameters.Add(New SqlParameter("@itemname", dgv.Rows(i).Cells("item").Value))
                            command.Parameters.Add(New SqlParameter("@quantity", addStock))
                            command.Parameters.Add(New SqlParameter("@date", dateParameter))
                            command.Parameters.Add(New SqlParameter("@transnum", transactionNumber))
                            command.Parameters.Add(New SqlParameter("@username", login2.username))
                            command.ExecuteNonQuery()
                        End If
                    Next
                End If
                If login2.wrkgrp <> "Cashier" Then
                    posc.datecreated = dateParameter
                    Dim ordernum As Integer = posc.returnLatestOrderNumber()
                    command.Parameters.Clear()
                    command.CommandText = "INSERT INTO tbltransaction2 (ornum, ordernum, transdate, cashier, tendertype, servicetype, delcharge, subtotal, disctype, less, vatsales, vat, amtdue, tenderamt, change, refund, comment, remarks, customer, tinnum, tablenum, pax, createdby, datecreated, datemodified, status, status2, area, gctotal, typez, discamt) VALUES ('000',@ordernum,@transdate,@cashier,@tendertype,@servicetype,@delcharge,@subtotal,@disctype,@less,@vatsales,@vat,@amtdue,@tenderamt,@change,@refund,@comment,@remarks,@customer,@tinum,0,0,@createdby,@date,@date,1,'Unpaid','Sales',@gctotal,@type,@discamt);"
                    command.CommandType = CommandType.Text
                    command.Parameters.AddWithValue("@ordernum", ordernum)
                    command.Parameters.AddWithValue("@transdate", dateParameter)
                    command.Parameters.AddWithValue("@date", dateParameter)
                    command.Parameters.AddWithValue("@cashier", login2.username)
                    command.Parameters.AddWithValue("@tendertype", tendetype)
                    command.Parameters.AddWithValue("@servicetype", "Take Out")
                    command.Parameters.AddWithValue("@delcharge", 0)
                    command.Parameters.AddWithValue("@subtotal", CDbl(lblsubtotalbefore.Text))
                    command.Parameters.AddWithValue("@disctype", cmbdisctype.Text)
                    command.Parameters.AddWithValue("@less", CDbl(lbldiscpercent.Text.Replace("%", "")))
                    command.Parameters.AddWithValue("@vatsales", 0)
                    command.Parameters.AddWithValue("@vat", 0)
                    command.Parameters.AddWithValue("@amtdue", CDbl(lblamountpayable.Text))
                    command.Parameters.AddWithValue("@tenderamt", CDbl(txtamounttendered.Text))
                    command.Parameters.AddWithValue("@change", CDbl(lblchange.Text))
                    command.Parameters.AddWithValue("@refund", 0)
                    command.Parameters.AddWithValue("@comment", "")
                    command.Parameters.AddWithValue("@remarks", "")
                    command.Parameters.AddWithValue("@customer", txtname.Text)
                    command.Parameters.AddWithValue("@tinum", "0")
                    command.Parameters.AddWithValue("@createdby", login2.username)
                    command.Parameters.AddWithValue("@gctotal", CDbl(lblgc.Text))
                    command.Parameters.AddWithValue("@type", pos_dialog.ans)
                    command.Parameters.AddWithValue("@discamt", CDbl(lbldiscamt.Text))
                    command.ExecuteNonQuery()
                    If cmbdisctype.Text <> "" Then
                        command.Parameters.Clear()
                        command.CommandText = "INSERT INTO tblsenior (transnum,idno,name,disctype,datedisc,status) VALUES (@transnum,@idno,@name,@disctype,@date,3)"
                        command.Parameters.AddWithValue("@transnum", ordernum)
                        command.Parameters.AddWithValue("@date", dateParameter)
                        command.Parameters.AddWithValue("@idno", senior.txtidno.Text)
                        command.Parameters.AddWithValue("@name", senior.txtname.Text)
                        command.Parameters.AddWithValue("@disctype", cmbdisctype.Text)
                        command.ExecuteNonQuery()
                    End If


                    For index As Integer = 0 To dgv.Rows.Count - 1

                        Dim dscntprice As Double = CDbl(dgv.Rows(index).Cells("price").Value - ((dgv.Rows(index).Cells("discpercent").Value / 100) * dgv.Rows(index).Cells("price").Value))
                        Dim ifree As Double = If(CBool(dgv.Rows(index).Cells("free").Value) = True, 1, 0)

                        command.Parameters.Clear()

                        command.CommandText = "Insert into tblorder2 (ordernum, category, itemname, qty, price, totalprice, dscnt, free, request, status, discprice, disctrans,area,gc,less,deliver,datecreated,pricebefore,discamt)values(@ordernum,(SELECT category FROM tblitems WHERE itemname=@itemname),@itemname,@quantity,@price,@amount,@dispercent,@free,'',@status,@disprice,0,@area,0,0,0,@date,@pricebefore,@discamt)"
                        command.CommandType = CommandType.Text
                        command.Parameters.AddWithValue("@ordernum", ordernum)
                        command.Parameters.AddWithValue("@itemname", dgv.Rows(index).Cells("item").Value)
                        command.Parameters.AddWithValue("@quantity", CDbl(dgv.Rows(index).Cells("quantity").Value))
                        command.Parameters.AddWithValue("@price", CDbl(dgv.Rows(index).Cells("price").Value))
                        command.Parameters.AddWithValue("@amount", CDbl(dgv.Rows(index).Cells("amount").Value))
                        command.Parameters.AddWithValue("@dispercent", CDbl(dgv.Rows(index).Cells("discpercent").Value))
                        command.Parameters.AddWithValue("@free", ifree)
                        command.Parameters.AddWithValue("@status", 1)
                        command.Parameters.AddWithValue("@disprice", dscntprice)
                        command.Parameters.AddWithValue("@area", "Sales")
                        command.Parameters.AddWithValue("@date", dateParameter)
                        command.Parameters.AddWithValue("@pricebefore", CDbl(dgv.Rows(index).Cells("pricebefore").Value))
                        command.Parameters.AddWithValue("@discamt", CDbl(dgv.Rows(index).Cells("discamt").Value))
                        command.ExecuteNonQuery()
                    Next
                End If
                transaction.Commit()
                MessageBox.Show("Transaction Complete", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Try
                transaction.Rollback()
            Catch ex2 As Exception
                MessageBox.Show(ex2.ToString)
            End Try
        End Try
    End Sub

    Private Sub rbcharge_CheckedChanged(sender As Object, e As EventArgs) Handles rbcharge.CheckedChanged
        'check if user click cash
        If rbcharge.Checked Then
            'call sub and assign parameter ar charge
            toggleTendertype("A.R Charge")
            txtname.Focus()
        End If
    End Sub


    ''' <summary>
    ''' this sub assign tendertype and other property of txtname
    ''' </summary>
    ''' <param name="tendertypeValue"></param>
    Public Sub toggleTendertype(ByVal tendertypeValue As String)
        'assign tendertype to parameter
        tendetype = tendertypeValue
        'assign and check if tendertype is true then the txtname become disabled or readonly
        txtname.ReadOnly = IIf(tendertypeValue = "Cash", True, False)
        'assign and check if tendertype is true then the txtname cursor become default or ibeam
        txtname.Cursor = IIf(tendertypeValue = "Cash", Cursors.Default, Cursors.IBeam)
        'assign and check if tendertype is true then the txtname backcolor become 244,244,244 or white
        txtname.BackColor = IIf(tendertypeValue = "Cash", Color.FromArgb(244, 244, 244), Color.White)
        'assign and check if tendertype is true then the txtname text become cash or clear
        txtname.Text = IIf(tendertypeValue = "Cash", "CASH", "")
        'fill customer or employee
        Dim result As New DataTable(), auto As New AutoCompleteStringCollection
        'check if tendertype is ar sales and archarge
        If tendertypeValue = "A.R Sales" Or tendertypeValue = "A.R Charge" Then
            'set type if tendertype is arsales or not
            custc.typee = IIf(tendertypeValue = "A.R Sales", "Customer", "Employee")
            'get result of name
            result = custc.returnName()
            'loop through
            For Each r0w As DataRow In result.Rows
                'add string collection
                auto.Add(r0w("name"))
            Next
            'assign string collection
            txtname.AutoCompleteCustomSource = auto
        Else
            'assign string collection to nothing or null
            txtname.AutoCompleteCustomSource = Nothing
        End If
    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        'close the form
        Me.Close()
    End Sub
    ''' <summary>
    ''' clear sub for categories button
    ''' </summary>
    Public Sub clearBtnCategories()
        btncat1.Text = ""
        btncat2.Text = ""
        btncat3.Text = ""
        btncat4.Text = ""
    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        'call item refresh sub
        itemsrefreshh("")
    End Sub
    ''' <summary>
    ''' sub for load categories to buttons
    ''' </summary>
    Public Sub catloadCategories()
        'assign variables
        Dim result As New DataTable(), catCounter As Integer = 1
        'set parameters to pos class
        posc.catsetOffset(catoffset)
        posc.catsetrowFetch(catrowFetch)
        'get categories result
        result = posc.loadCategories()
        'call categories clear sub first
        clearBtnCategories()
        'loop through
        For Each r0w As DataRow In result.Rows
            'find button control
            Dim btn As Button = Me.Controls.Find("btncat" & catCounter, True).FirstOrDefault
            'assign text
            btn.Text = r0w(0)
            'increament counter to one
            catCounter += 1
        Next
        btncat1.Enabled = IIf(isConfirm, False, True)
        btncat2.Enabled = IIf(isConfirm, False, True)
        btncat3.Enabled = IIf(isConfirm, False, True)
        btncat4.Enabled = IIf(isConfirm, False, True)
    End Sub
    ''' <summary>
    ''' return count of items
    ''' </summary>
    ''' <returns></returns>
    Public Function catcountLoadItems() As Integer
        'get count of categories from pos class
        Dim result As Integer = posc.getCategoriesCount
        'return result
        Return result
    End Function
    ''' <summary>
    ''' categories sub set to default
    ''' </summary>
    Public Sub catrefreshh()
        'assign variables to default
        catcurrentPage = 1
        catoffset = 0
        cattotalCount = catcountLoadItems()
        cattotalPage = Math.Ceiling(cattotalCount / catrowFetch) * 1
        catloadCategories()
    End Sub
    ''' <summary>
    ''' items sub set to default
    ''' </summary>
    Public Sub itemsrefreshh(ByVal category As String)
        'assign variables to default
        itemcurrentPage = 1
        itemoffset = 0
        posc.setItem(txtsearch.Text)
        posc.datecreated = dtdate.Text
        itemtotalCount = itemcountLoadItems()
        itemtotalPage = Math.Ceiling(itemtotalCount / itemrowFetch) * 1
        loadItems(category)
    End Sub

    ''' <summary>
    ''' load items sub
    ''' </summary>
    Public Sub loadItems(ByVal category As String)
        'clear panel first
        panelitems.Controls.Clear()
        'assign width and height for button and result 
        Dim btnWidth As Integer = 104, btnHeight As Integer = 93, result As DataTable
        'set varibales
        posc.setItemOffset(itemoffset)
        posc.setItemrowFetch(itemrowFetch)
        posc.setItem(txtsearch.Text)
        posc.category = category
        posc.datecreated = dtdate.Text
        'get result of load items sub
        result = posc.loadItems()
        'loop through
        For Each r0w As DataRow In result.Rows
            'assign property button
            Dim btn As New Button
            btn.Width = btnWidth
            btn.Height = btnHeight
            btn.FlatStyle = FlatStyle.Flat
            btn.FlatAppearance.BorderSize = 0
            btn.Font = New Font("Arial", 9.75, FontStyle.Bold)
            btn.BackColor = Color.FromArgb(244, 244, 244)
            btn.Cursor = Cursors.Hand
            btn.Name = "btnitem" & r0w("itemid")
            btn.Tag = r0w("itemid")
            btn.Enabled = IIf(isConfirm, False, True)
            'check if ending balance is zero then add - N/A to button text
            btn.Text = IIf(CInt(r0w("endbal")) <= 0, r0w("itemname") & " - N/A", r0w("itemname"))
            'check if ending balance is zero then assign color of button
            btn.ForeColor = IIf(CInt(r0w("endbal")) <= 0, Color.Red, Color.Black)
            'add button to panel
            panelitems.Controls.Add(btn)
            'add event listerner to each button
            AddHandler btn.Click, AddressOf ItemClicked
        Next
    End Sub
    ''' <summary>
    ''' event listener for each item
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ItemClicked(sender As Object, e As EventArgs)
        'set itemid to pos class
        posc.itemid = CInt(sender.tag)
        If isConfirm = False Then
            If posc.checkInventoryStock() = False And uc.returnPOSType() <> "Coffee Shop" Then
                'remove the N/A if item is not available
                Dim itemname As String = sender.text.ToString.Substring(0, sender.text.length - 6)
                MessageBox.Show("'" & itemname & "' is not available", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                'get price of item
                Dim itemPrice As Double = posc.getItemPrice()
                Dim itemname As String = IIf(posc.checkInventoryStock() = False, sender.text.ToString.Substring(0, sender.text.length - 6), sender.text)
                dgv.Rows.Add(itemname, 0, itemPrice.ToString("n2"), 0, "0.00", False, "0.00", "0.00")
                dgv.Rows(dgv.RowCount - 1).Cells("quantity").Selected = True
                lblitemscount.Text = dgv.RowCount.ToString("N0")
                computeTotal()
                'if item is avaialble, it add to cart
            End If
        End If
    End Sub

    ''' <summary>
    ''' return count of items
    ''' </summary>
    ''' <returns></returns>
    Public Function itemcountLoadItems() As Integer
        'assing and get the result of item count function from pos class
        Dim result As Integer = posc.getItemsCount
        'return result
        Return result
    End Function
    Public Sub computeTotal()
        Dim pricebefore As Double = 0.00
        For i As Integer = 0 To dgv.RowCount - 1
            pricebefore += CDbl(dgv.Rows(i).Cells("amount").Value)
        Next
        lblsubtotalbefore.Text = IIf(dgv.Rows.Count < 0, "0.00", pricebefore.ToString("n2"))
        lblsubtotalafter.Text = CDbl(pricebefore - CDbl(lbldiscamt.Text)).ToString("n2")

        If CDbl(lblsubtotalafter.Text) < (CDbl(lblgc.Text) + apdep) Then
            lblamountpayable.Text = "0.00"
            lblgrandtotal.Text = "0.00"
            lblchange.Text = "0.00"
        Else
            lblamountpayable.Text = (CDbl(lblsubtotalafter.Text) - (CDbl(lblgc.Text) + apdep)).ToString("n2")
            lblgrandtotal.Text = lblamountpayable.Text
            If txtamounttendered.Text <> "" Then
                lblchange.Text = IIf(CDbl(lblamountpayable.Text) < CDbl(txtamounttendered.Text), CDbl(CDbl(txtamounttendered.Text) - CDbl(lblamountpayable.Text)).ToString("n2"), "0.00")
            End If
        End If
    End Sub
End Class