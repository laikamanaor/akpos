Imports AK_POS.pos2_class
Imports AK_POS.user_class
Imports AK_POS.customer_class
Public Class mainmenu2
    Dim posc As New pos2_class, uc As New user_class(), custc As New customer_class()
    Private catoffset As Integer = 0, catrowFetch As Integer = 4, cattotalCount As Integer = 0, cattotalPage As Integer = 0, catcurrentPage As Integer = 1,
        itemoffset As Integer = 0, itemrowFetch As Integer = 30, itemtotalCount As Integer = 0, itemtotalPage As Integer = 0, itemcurrentPage As Integer = 1
    Dim tendetype As String = "", cashierOrderNumber As Integer = 0
    Private Sub mainmenu2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
        loadItems()
        'assign string collection from itemautocomplete function
        txtsearch.AutoCompleteCustomSource = ItemAutoComplete()
        'assign order number if user is cashier it return cashier want to transact if not return the latest order number
        lblordernumber.Text = IIf(login2.wrkgrp = "Cashier", cashierOrderNumber, IIf(returnOrderNumber() = 0, "N/A", returnOrderNumber))

        lbltransnum.Visible = IIf(login2.wrkgrp = "Cashier", True, False)
        Label3.Visible = IIf(login2.wrkgrp = "Cashier", True, False)
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
            loadItems()
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
            loadItems()
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
        itemsrefreshh()
    End Sub

    Private Sub txtsearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsearch.KeyDown
        'check if user press enter
        If e.KeyCode = Keys.Enter Then
            'call item name refresh
            itemsrefreshh()
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
            ElseIf e.ColumnIndex = 3 Then
                If numbersValidation(dgv.CurrentRow.Cells("discpercent").Value, "discpercent") = True Then
                ElseIf CInt(dgv.CurrentRow.Cells("discpercent").Value > 25) Then
                    MessageBox.Show("Up to 25% discount only", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Dim pricebefore As Double = CDbl(dgv.CurrentRow.Cells("quantity").Value) * CDbl(dgv.CurrentRow.Cells("price").Value)
                    Dim amount As Double = CDbl(dgv.CurrentRow.Cells("amount").Value)
                    dgv.CurrentRow.Cells("discpercent").Value = 25
                    dgv.CurrentRow.Cells("amount").Value = CDbl(amount - ((25 / 100) * pricebefore)).ToString("n2")
                    dgv.CurrentRow.Cells("discamt").Value = CDbl((25 / 100) * pricebefore).ToString("n2")

                Else
                    Dim amount As Double = 0.00
                    amount = CDbl(dgv.CurrentRow.Cells("quantity").Value) * CDbl(dgv.CurrentRow.Cells("price").Value)
                    Dim pricebefore As Double = CDbl(dgv.CurrentRow.Cells("pricebefore").Value)
                    Dim discpercent As Double = CDbl(dgv.CurrentRow.Cells("discpercent").Value)
                    dgv.CurrentRow.Cells("amount").Value = CDbl(amount.ToString("n2") - ((discpercent / 100) * pricebefore)).ToString("n2")
                    dgv.CurrentRow.Cells("discamt").Value = CDbl((discpercent / 100) * pricebefore).ToString("n2")
                End If

            ElseIf e.ColumnIndex = 4 Then
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
                End If
            End If
        End If
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
        'assign and check if tendertype is true then the txtname backcolor become gainsboro or white
        txtname.BackColor = IIf(tendertypeValue = "Cash", Color.Gainsboro, Color.White)
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
        itemsrefreshh()
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
    Public Sub itemsrefreshh()
        'assign variables to default
        itemcurrentPage = 1
        itemoffset = 0
        posc.setItem(txtsearch.Text)
        posc.datecreated = dtdate.Text
        itemtotalCount = itemcountLoadItems()
        itemtotalPage = Math.Ceiling(itemtotalCount / itemrowFetch) * 1
        loadItems()
    End Sub

    ''' <summary>
    ''' load items sub
    ''' </summary>
    Public Sub loadItems()
        'clear panel first
        panelitems.Controls.Clear()
        'assign width and height for button and result 
        Dim btnWidth As Integer = 104, btnHeight As Integer = 93, result As DataTable
        'set varibales
        posc.setItemOffset(itemoffset)
        posc.setItemrowFetch(itemrowFetch)
        posc.setItem(txtsearch.Text)
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
            btn.BackColor = Color.Gainsboro
            btn.Cursor = Cursors.Hand
            btn.Name = "btnitem" & r0w("itemid")
            btn.Tag = r0w("itemid")

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
    ''' event listner for each item
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ItemClicked(sender As Object, e As EventArgs)
        'set itemid to pos class
        posc.itemid = CInt(sender.tag)
        If posc.checkInventoryStock() = False And uc.returnPOSType() <> "Coffee Shop" Then
            'remove the N/A if item is not available
            Dim itemname As String = sender.text.ToString.Substring(0, sender.text.length - 6)
            MessageBox.Show("'" & itemname & "' is not available", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            'get price of item
            Dim itemPrice As Double = posc.getItemPrice()
            dgv.Rows.Add(sender.text, 0, itemPrice.ToString("n2"), 0, "0.00", False, itemPrice.ToString("n2"), 0.00)
            'if item is avaialble, it add to cart
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
End Class