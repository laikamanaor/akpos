Imports AK_POS.mini_pos
Imports AK_POS.connection_class
Imports System.Globalization
Public Class add_pos
    Dim posc As New mini_pos(), posc_master As New pos_class(), userc As New user_class(), cc As New connection_class()
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Dim culture As CultureInfo = Nothing
    Dim tendertype As String = "", servicetype As String = "", typez As String = "", inv_id As String
    Public apdepamt As Double = 0.00
    Public Shared voidd As Boolean = False
    Private Sub lblclose_Click(sender As Object, e As EventArgs) Handles lblclose.Click
        Me.Close()
    End Sub

    Private Sub add_pos_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Panel5_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel5.MouseDown, MyBase.MouseDown, Label3.MouseDown
        drag = True 'Sets the variable drag to true.
        mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'Sets variable mousey
    End Sub

    Private Sub Panel5_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel5.MouseMove, MyBase.MouseMove, Label3.MouseMove
        'If drag is set to true then move the form accordingly.
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Panel5_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel5.MouseUp, MyBase.MouseUp, Label3.MouseUp
        drag = False 'Sets drag to false, so the form does not move according to the code in MouseMove
    End Sub
    Public Sub loadCategories()
        Dim dt As New DataTable()
        dt = posc.showCategories()
        cmbcategory.Items.Clear()
        For Each r0w As DataRow In dt.Rows
            cmbcategory.Items.Add(r0w(0))
        Next
        If cmbcategory.Items.Count > 1 Then
            cmbcategory.SelectedIndex = 0
        End If
    End Sub

    Private Sub dtdate_ValueChanged(sender As Object, e As EventArgs) Handles dtdate.ValueChanged
        loadData("a")
    End Sub
    Public Sub loadData(ByVal wtItems As String)
        posc.setCategory(cmbcategory.Text)
        posc.setItem(txtsearch1.Text)
        posc.setDatee(dtdate.Text)
        Dim auto As New AutoCompleteStringCollection()
        Dim dt As New DataTable()
        dt = posc.showItems(wtItems)
        dgvtrans.Rows.Clear()
        For Each r0w As DataRow In dt.Rows
            auto.Add(r0w("itemname"))
            dgvtrans.Rows.Add(r0w("itemid"), r0w("itemname"))
        Next
        txtsearch1.AutoCompleteCustomSource = auto

        For index As Integer = 0 To dgvtrans.Rows.Count - 1
            posc.setItem(dgvtrans.Rows(index).Cells("itemname").Value)
            posc.setDatee(dtdate.Text)
            If posc.checkStocks = False Then
                dgvtrans.Rows(index).Cells("itemname").Style.ForeColor = Color.Red
            Else
                dgvtrans.Rows(index).Cells("itemname").Style.ForeColor = Color.Black
            End If
        Next

    End Sub

    Private Sub cmbcategories_SelectedIndexChanged(sender As Object, e As EventArgs)
        loadData("a")
    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        loadData("")
        If Not String.IsNullOrEmpty(Trim(txtsearch1.Text)) Then
            addCartValidation()
        End If
    End Sub

    Private Sub txtsearch1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsearch1.KeyDown
        If e.KeyCode = Keys.Enter Then
            loadData("")
            If Not String.IsNullOrEmpty(Trim(txtsearch1.Text)) Then
                addCartValidation()
            End If
        End If
    End Sub

    Private Sub add_pos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadCategories()
        loadData("a")
    End Sub

    Private Sub cmbcategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbcategory.SelectedIndexChanged
        loadData("a")
    End Sub

    Private Sub dgvtrans_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvtrans.CellClick
        Try
            If dgvtrans.RowCount <> 0 Then
                If e.ColumnIndex = 2 Then
                    addCartValidation()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub addCartValidation()
        posc.setItem(dgvtrans.CurrentRow.Cells("itemname").Value)
        posc.setDatee(dtdate.Text)
        If posc.checkStocks() = False Then
            MessageBox.Show(dgvtrans.CurrentRow.Cells("itemname").Value & " is not available", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            addtoCart()
        End If
    End Sub

    Public Sub addtoCart()
        Dim dtAddCart As New DataTable()
        dtAddCart = posc.addCart(dgvtrans.CurrentRow.Cells("itemid").Value)
        For Each r0w As DataRow In dtAddCart.Rows
            grd.Rows.Add(r0w("category"), r0w("itemname"), 0, CDbl(r0w("price")).ToString("n2"), 0, CInt(r0w("price")).ToString("n2"), False, CInt(r0w("price")).ToString("N0"), 0)
        Next
        lblcountitems.Text = IIf(grd.Rows.Count = 0, "ITEMS(0)", "ITEMS (" & grd.Rows.Count & ")")
        If grd.Rows.Count <> 0 Then
            grd.Rows(grd.RowCount - 1).Cells("quantity").Selected = True
        End If
    End Sub

    Private Sub btnvoid_Click(sender As Object, e As EventArgs) Handles btnvoid.Click
        If grd.Rows.Count <> 0 Then
            grd.Rows.Remove(grd.CurrentRow)
        End If
        lblcountitems.Text = IIf(grd.Rows.Count = 0, "ITEMS(0)", "ITEMS (" & grd.Rows.Count & ")")
    End Sub

    Private Sub btnclear_Click(sender As Object, e As EventArgs) Handles btnclear.Click
        grd.Rows.Clear()
        lblcountitems.Text = IIf(grd.Rows.Count = 0, "ITEMS(0)", "ITEMS (" & grd.Rows.Count & ")")
    End Sub

    Public Sub getID()
        Try
            Dim id As String = ""
            Dim date_ As New DateTime()
            cc.con.Open()
            cc.cmd = New SqlClient.SqlCommand("Select TOP 1 invnum from tblinvsum WHERE area='Sales' order by invsumid DESC", cc.con)
            cc.rdr = cc.cmd.ExecuteReader()
            If cc.rdr.Read() Then
                id = cc.rdr("invnum")
            End If
            cc.con.Close()
            inv_id = id
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btnpay_Click(sender As Object, e As EventArgs) Handles btnpay.Click
        getID()
        If userc.checkCutOff() Then
            MessageBox.Show("POS already cut off", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf posc_master.checkQuantity(grd) <> "" Then
            MessageBox.Show("The item(s) below are 0 quantity. Please enter valid input" & Environment.NewLine & posc_master.checkQuantity(grd), "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf posc_master.checkQuantityLevel2(grd) <> "" Then
            MessageBox.Show("The item(s) below are 0 quantity. Please enter valid input" & Environment.NewLine & posc_master.checkQuantityLevel2(grd), "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf posc_master.checkCSFree(grd) <> "" Then
            MessageBox.Show("The item(s) below have free bread(s). Please enter valid input" & Environment.NewLine & posc_master.checkCSFree(grd), "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf posc_master.checkItemAmount(grd) <> "" Then
            MessageBox.Show("Please input amount In item. Please enter valid input" & Environment.NewLine & posc_master.checkCSFree(grd), "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf grd.RowCount = 0 Then
            MessageBox.Show("No orders entered", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf CDbl(txtamttendered.Text) < (CDbl(txtamtpayable.Text)) And rbcash.Checked And login.wrkgrp = "Cashier" Then
            'amount()
            MsgBox("Amount tendered Is Not enough To pay the bill. Enter amount.", MsgBoxStyle.Exclamation, "")
            txtamttendered.Focus()
        ElseIf String.IsNullOrEmpty(txtname.Text) Then
            MessageBox.Show("Please enter name", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtname.Focus()
        ElseIf posc_master.checkCustomer(txtname.Text, tendertype) = False And rbcash.Checked = False Then
            MessageBox.Show("Name '" & txtname.Text & "' not found", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtname.Focus()
        ElseIf checkCoffeeShopItem(pos_dialog.ans).ToLower <> "Below item Is invalid for ".ToLower & pos_dialog.ans.ToLower & Environment.NewLine Then
            MessageBox.Show(checkCoffeeShopItem(pos_dialog.ans), "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf posc_master.checkStocks(grd, inv_id) <> "" Then
            MessageBox.Show("Insufficient supply of item below. Please enter valid input" & Environment.NewLine & posc_master.checkStocks(grd, inv_id), "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf Trim(txtamttendered.Text) = "" Or Val(txtamttendered.Text) = 0 And login.wrkgrp = "Cashier" And rbcash.Checked Then
            If String.IsNullOrEmpty(txtchange.Text) And rbcash.Checked Then
                'amount()
                MsgBox("Amount tendered is empty. Enter amount first.", MsgBoxStyle.Exclamation, "")
                txtamttendered.Focus()
            Else
                'final()
            End If
        Else
            'final()
        End If
    End Sub

    Private Sub grd_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles grd.CellEndEdit
        Try
            If e.ColumnIndex = 2 Then
                Dim origPrice As Double = posc.returnPrice(grd.CurrentRow.Cells("item").Value.ToString)
                Dim endbal As Double = posc.returnStock(grd.CurrentRow.Cells("item").Value.ToString, dtdate.Text)
                If Not IsNumeric(grd.Rows(grd.CurrentRow.Index).Cells("quantity").Value) Then
                    MessageBox.Show("Invalid Input", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    grd.Rows(grd.CurrentRow.Index).Cells("quantity").Value = 0
                    computetotal()
                ElseIf grd.CurrentRow.Cells("quantity").Value = 0 Then
                    MessageBox.Show("Please input atleast 1", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    grd.Rows(grd.CurrentRow.Index).Cells("discpercent").Value = 0
                    grd.Rows(grd.CurrentRow.Index).Cells("amtdue").Value = 0.00
                    computetotal()
                ElseIf CBool(grd.CurrentRow.Cells("free").Value) = False Then
                    grd.Rows(grd.CurrentRow.Index).Cells("price").Value = origPrice.ToString("n2")
                    Dim q As Double = CDbl(grd.Rows(grd.CurrentRow.Index).Cells("quantity").Value)
                    Dim d As Double = (q * origPrice) * (CDbl(grd.Rows(grd.CurrentRow.Index).Cells("discpercent").Value / 100))
                    Dim amt As Double = (q * origPrice) - d
                    If endbal < CDbl(grd.CurrentRow.Cells("quantity").Value) And typez <> "Coffee Shop" Then
                        MessageBox.Show("Available stock only is " & endbal, "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        grd.CurrentRow.Cells("quantity").Value = endbal
                        Dim q2 As Double = CDbl(grd.Rows(grd.CurrentRow.Index).Cells("quantity").Value)
                        Dim d2 As Double = (q2 * origPrice) * (CDbl(grd.Rows(grd.CurrentRow.Index).Cells("discpercent").Value / 100))
                        Dim amt2 As Double = (q2 * origPrice) - d2
                        grd.Rows(grd.CurrentRow.Index).Cells("amtdue").Value = amt2.ToString("n2")
                        computetotal()
                    Else
                        grd.Rows(grd.CurrentRow.Index).Cells("amtdue").Value = amt.ToString("n2")
                        grd.CurrentRow.Cells("pricebefore").Value = (CDbl(grd.CurrentRow.Cells("price").Value) * CDbl(grd.CurrentRow.Cells("quantity").Value)).ToString("n2")
                        grd.CurrentRow.Cells("discamt").Value = (grd.CurrentRow.Cells("discpercent").Value / 100) * grd.CurrentRow.Cells("pricebefore").Value
                        computetotal()
                    End If
                End If
            ElseIf e.ColumnIndex = 4 Then
                If Not IsNumeric(grd.Rows(grd.CurrentRow.Index).Cells(3).Value) Then
                    MessageBox.Show("Invalid Input", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    grd.Rows(grd.CurrentRow.Index).Cells(3).Value = 0.00
                    computetotal()
                    Exit Sub
                End If

                Dim quantity As Double = CDbl(grd.CurrentRow.Cells("quantity").Value)
                Dim price As Double = CDbl(grd.CurrentRow.Cells("price").Value)
                Dim origPrice As Double = quantity * price
                Dim d As Double = (quantity * price) * (CDbl(grd.Rows(grd.CurrentRow.Index).Cells("discpercent").Value / 100))
                Dim legit As Double = 0.00
                If grd.Rows(grd.CurrentRow.Index).Cells("discpercent").Value >= 25 Then
                    Dim disk As Double = CDbl(50 / 100)
                    grd.Rows(grd.CurrentRow.Index).Cells("discpercent").Value = 25
                    d = (quantity * price) * (CDbl(grd.Rows(grd.CurrentRow.Index).Cells("discpercent").Value / 100))
                    legit = origPrice - d
                    grd.Rows(grd.CurrentRow.Index).Cells("amtdue").Value = legit.ToString("n2")
                    grd.CurrentRow.Cells("discamt").Value = (CDbl(grd.CurrentRow.Cells("discpercent").Value / 100) * CDbl(grd.CurrentRow.Cells("pricebefore").Value)).ToString("n2")
                Else
                    Dim disk As Double = CDbl(grd.Rows(grd.CurrentRow.Index).Cells("discpercent").Value / 100)
                    legit = origPrice - d
                    grd.Rows(grd.CurrentRow.Index).Cells("amtdue").Value = legit.ToString("n2")
                    grd.CurrentRow.Cells("discamt").Value = (grd.CurrentRow.Cells("discpercent").Value / 100) * grd.CurrentRow.Cells("pricebefore").Value
                End If
            ElseIf e.ColumnIndex = 5 Then

                If Not IsNumeric(grd.Rows(grd.CurrentRow.Index).Cells(4).Value) Then
                    MessageBox.Show("Invalid Input", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    grd.Rows(grd.CurrentRow.Index).Cells(4).Value = 0.00
                    grd.Rows(grd.CurrentRow.Index).Cells("discpercent").Value = "0.00"
                    grd.Rows(grd.CurrentRow.Index).Cells("discamt").Value = "0.00"
                    computetotal()
                    Exit Sub
                End If

                If grd.CurrentRow.Cells("amtdue").Value > (CDbl(grd.CurrentRow.Cells("quantity").Value) * CDbl(grd.CurrentRow.Cells("price").Value)) Then
                    MessageBox.Show("Invalid Input", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    grd.CurrentRow.Cells("amtdue").Value = CDbl(grd.CurrentRow.Cells("quantity").Value) * CDbl(grd.CurrentRow.Cells("price").Value)
                    grd.Rows(grd.CurrentRow.Index).Cells("discpercent").Value = "0.00"
                    grd.Rows(grd.CurrentRow.Index).Cells("discamt").Value = "0.00"
                    computetotal()
                    Exit Sub
                End If



                grd.Rows(grd.CurrentRow.Index).Cells(3).Value = 0.00


                Dim quantity As Double = CDbl(grd.CurrentRow.Cells("quantity").Value)
                Dim price As Double = CDbl(grd.CurrentRow.Cells("price").Value)
                Dim origPrice As Double = quantity * price

                Dim disc As Double = 0.00
                disc = ((origPrice - grd.CurrentRow.Cells(4).Value) / origPrice) * 100

                If disc < 0 Then
                    grd.CurrentRow.Cells("discpercent").Value = 0
                    grd.CurrentRow.Cells("discamt").Value = 0
                Else
                    grd.CurrentRow.Cells("discpercent").Value = disc.ToString("n2")
                    grd.CurrentRow.Cells("discpercent").Value = CDbl(grd.CurrentRow.Cells("discpercent").Value).ToString("n2")

                    grd.CurrentRow.Cells("discamt").Value = (grd.CurrentRow.Cells("discpercent").Value / 100) * grd.CurrentRow.Cells("pricebefore").Value
                End If
            ElseIf e.ColumnIndex = 6 Then
                If Not CBool(grd.CurrentRow.Cells("free").Value) = False And grd.RowCount <> 0 Then
                    Dim checkCell As DataGridViewCheckBoxCell = CType(grd.Rows(e.RowIndex).Cells(6), DataGridViewCheckBoxCell)
                    If checkCell.Value = True Then
                        If grd.CurrentRow.Cells("category").Value <> "Packaging" And pos_dialog.ans <> "Coffee Shop" Then
                            confirm.ShowDialog()
                        Else
                            grd.Rows(grd.CurrentRow.Index).Cells(2).Value = "0.00"
                            grd.Rows(grd.CurrentRow.Index).Cells(3).Value = "0.00"
                            grd.Rows(grd.CurrentRow.Index).Cells(4).Value = "0.00"
                            grd.CurrentRow.Cells("discamt").Value = "0.00"
                        End If

                        If voidd = True Then
                            grd.Rows(grd.CurrentRow.Index).Cells(2).Value = "0.00"
                            grd.Rows(grd.CurrentRow.Index).Cells(3).Value = "0.00"
                            grd.Rows(grd.CurrentRow.Index).Cells(4).Value = "0.00"
                            grd.CurrentRow.Cells("discamt").Value = "0.00"
                        Else
                            If grd.CurrentRow.Cells("cat").Value <> "Packaging" And pos_dialog.ans <> "Coffee Shop" Then
                                checkCell.Value = False
                            End If
                        End If
                        voidd = False
                    End If
                Else
                    'grd.CurrentRow.Cells("amtdue").Value = CDbl(CDbl(grd.CurrentRow.Cells("price").Value) * CDbl(grd.CurrentRow.Cells("quantity").Value)).ToString("n2")
                    If grd.RowCount <> 0 Then
                        Dim price As Double = 0.00
                        cc.con.Open()
                        cc.cmd = New SqlClient.SqlCommand("SELECT price FROM tblitems WHERE itemname=@itemname;", cc.con)
                        cc.cmd.Parameters.AddWithValue("@itemname", grd.CurrentRow.Cells("description").Value)
                        cc.rdr = cc.cmd.ExecuteReader
                        If cc.rdr.Read Then
                            price = CDbl(cc.rdr("price"))
                        End If
                        cc.con.Close()
                        grd.Rows(grd.CurrentRow.Index).Cells(1).Value = Val(grd.Rows(grd.CurrentRow.Index).Cells(1).Value)
                        grd.Rows(grd.CurrentRow.Index).Cells("discpercent").Value = "0.00"
                        grd.Rows(grd.CurrentRow.Index).Cells("discamt").Value = "0.00"
                        grd.CurrentRow.Cells("price").Value = price.ToString("n2")
                        Dim q As Double = CDbl(grd.Rows(grd.CurrentRow.Index).Cells("quantity").Value)
                        Dim d As Double = CDbl(grd.Rows(grd.CurrentRow.Index).Cells(3).Value)
                        Dim amt As Double = (q * price) - d
                        grd.Rows(grd.CurrentRow.Index).Cells(4).Value = amt.ToString("n2")
                    End If
                End If
                computetotal()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub computetotal()
        Try
            Dim sub_before As Double = 0.00
            For index As Integer = 0 To grd.Rows.Count - 1
                cc.con.Open()
                cc.cmd = New SqlClient.SqlCommand("SELECT SUM(price*" & grd.Rows(index).Cells("quantity").Value & ") FROM tblitems WHERE itemname=@itemname;", cc.con)
                cc.cmd.Parameters.AddWithValue("@itemname", grd.Rows(index).Cells("item").Value)
                sub_before = cc.cmd.ExecuteScalar
                cc.con.Close()
            Next
            txtsubbefore.Text = sub_before.ToString("n2")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        End Try
    End Sub
    Private Sub grd_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles grd.CellEnter
        grd.Focus()
    End Sub

    Public Function checkCoffeeShopItem(posdialog As String) As String
        Dim errorCategory As String = "Below item is invalid for " & posdialog & Environment.NewLine
        For index As Integer = 0 To grd.RowCount - 1
            Dim chckCategory As String = ""
            If pos_dialog.ans = posdialog Then
                cc.con.Open()
                cc.cmd = New SqlClient.SqlCommand("Select category FROM tblitems WHERE itemname=@iname;", cc.con)
                cc.cmd.Parameters.AddWithValue("@iname", grd.Rows(index).Cells("description").Value)
                cc.rdr = cc.cmd.ExecuteReader
                If cc.rdr.Read Then
                    chckCategory = cc.rdr("category")
                End If
                cc.con.Close()

                If posdialog = "Coffee Shop" Then
                    If chckCategory = "Breads" Or chckCategory = "Beverages" Or chckCategory = "Coffee Shop" Then
                        Continue For
                    Else
                        errorCategory &= grd.Rows(index).Cells("description").Value & Environment.NewLine
                    End If
                Else
                    If pos_dialog.ans <> posdialog Then
                        MessageBox.Show("b/" & chckCategory)
                        errorCategory &= grd.Rows(index).Cells("description").Value & Environment.NewLine
                    End If
                End If
            End If
        Next
        Dim hehe As String = ""
        If errorCategory <> "Below item Is invalid for " & posdialog & Environment.NewLine Then
            hehe = errorCategory
        End If
        Return hehe
    End Function
    Public Sub loadCustomers(ByVal typee As String)
        Dim dtCustomers As New DataTable()
        dtCustomers = posc.showCustomers(typee)
        Dim auto As New AutoCompleteStringCollection()
        For Each r0w As DataRow In dtCustomers.Rows
            auto.Add(r0w(0))
        Next
        txtname.AutoCompleteCustomSource = auto
    End Sub

    Private Sub rbAR_CheckedChanged(sender As Object, e As EventArgs) Handles rbAR.CheckedChanged
        If rbAR.Checked Then
            tendertype = "A.R Sales"
            rbEvents()
        End If
    End Sub

    Private Sub rbARCharge_CheckedChanged(sender As Object, e As EventArgs) Handles rbARCharge.CheckedChanged
        If rbARCharge.Checked Then
            tendertype = "A.R Charge"
            rbEvents()
        End If
    End Sub

    Public Sub rbEvents()
        Select Case tendertype
            Case "Cash"
                txtname.Text = "CASH"
                txtname.Enabled = False
            Case "A.R Sales"
                txtname.Text = ""
                txtname.Enabled = True
                loadCustomers("Customer")
                txtname.Focus()
            Case "A.R Charge"
                txtname.Text = ""
                txtname.Enabled = True
                loadCustomers("Employee")
                txtname.Focus()
        End Select

    End Sub

    Private Sub rbcash_CheckedChanged(sender As Object, e As EventArgs) Handles rbcash.CheckedChanged
        If rbcash.Checked Then
            tendertype = "Cash"
            rbEvents()
        End If
    End Sub
End Class