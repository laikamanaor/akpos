Imports System.Data.SqlClient
Imports System.Text
Imports System.IO
Imports AK_POS.received_class
Imports AK_POS.connection_class
Public Class received_item
    Dim cc As New connection_class
    Dim con As New SqlConnection(cc.conString)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim transaction As SqlTransaction

    Dim transid As String = ""
    Dim selectedQuantity As String = ""
    Dim prodcurrentinv As String = ""
    Dim lastin As Double, lasttotal As Double, lastpull As Double, lastout As Double, lastend As Double, lastactual As Double, rems As String
    Public type As String = "", ar_number As String = "", trnum As String = "", received_type As String = "", lcacc As String = ""

    'class extension
    Dim rc As New received_class()
    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function

    Private Sub lblClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClose.Click
        panelQuantity.Visible = False
        txtboxQuantity.Text = ""
    End Sub
    Public Function checkProdProduce() As Boolean
        If cmbranches.Text = "Production" Then
            Dim prod_quantity As Double = 0.0
            con.Open()
            cmd = New SqlCommand("SELECT quantity FROM tblproduction WHERE transfer_from='Production' AND type='Received Item' AND item_name='" & dgvListItem.CurrentRow.Cells("itemname").Value & "' AND item_code='" & dgvListItem.CurrentRow.Cells("itemcode").Value & "' AND inv_id='" & prodcurrentinv & "';", con)
            rdr = cmd.ExecuteReader()
            While rdr.Read
                prod_quantity = prod_quantity + rdr("quantity")
            End While
            con.Close()
            Dim inv_quantity As Double = 0.0
            con.Open()
            cmd = New SqlCommand("SELECT produce FROM tblinvitems WHERE itemcode='" & dgvListItem.CurrentRow.Cells("itemcode").Value & "' AND itemname='" & dgvListItem.CurrentRow.Cells("itemname").Value & "' AND invnum='" & lblID.Text & "' AND area='" & lcacc & "';", con)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                inv_quantity = inv_quantity + rdr("produce")
            End If
            con.Close()
            Dim tots As Double = 0.0
            tots = prod_quantity + Val(txtboxQuantity.Text)
            If tots > inv_quantity Then
                MessageBox.Show("Insufficient Supply", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return True
            End If
        End If
    End Function

    Public Sub addquantity()
        If selectedQuantity = "Add Quantity" Then
            Dim get_itemname As String = lblQuantityItemName.Text.Replace("Item Name: ", "")
            Dim get_itemcode As String = lblQuantityItemCode.Text.Replace("Item Code: ", "")
            Dim get_category As String = lblQuantityCategory.Text.Replace("Category: ", "")
            If checkRowsExist() Then
                Return
            End If
            'If checkProdProduce() Then
            '    Return
            'End If
            Dim z As Boolean = False
            If cmbranches.Text = "" Then
                z = False
            Else
                z = True
            End If
            If String.IsNullOrEmpty(txtboxQuantity.Text) And String.IsNullOrEmpty(txtreject.Text) And String.IsNullOrEmpty(txtcharge.Text) Then
                MessageBox.Show("Please fill all fields", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            ElseIf String.IsNullOrEmpty(txtboxQuantity.Text) Then
                MessageBox.Show("Quantity is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            ElseIf String.IsNullOrEmpty(txtreject.Text) And z = False And Me.Text = "Produce Item" Then
                MessageBox.Show("Reject is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
                'ElseIf String.IsNullOrEmpty(txtcharge.Text) And Me.Text <> "Received From Adjustment" Then
                '    MessageBox.Show("Charge is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    Exit Sub
            Else
                Me.Cursor = Cursors.WaitCursor
                panelQuantity.Visible = False
                Dim r As String = "", c As String = ""
                If String.IsNullOrEmpty(txtreject.Text) Then
                    r = "0"
                Else
                    r = txtreject.Text
                End If
                If Me.Text = "Received From Adjustment" Then
                    c = "0"
                Else
                    c = txtcharge.Text
                End If
                dgvSelectedItem.Rows.Add(get_itemcode, get_itemname, get_category, txtboxQuantity.Text, r, c, "", "")
                lblQuantityItemCode.Text = "Item Code: N/A"
                lblQuantityItemName.Text = "Item Name: N/A"
                lblQuantityCategory.Text = "Category: N/A"
                Me.Cursor = Cursors.Default
                txtboxQuantity.Text = ""
                txtreject.Text = ""
                txtcharge.Text = ""
                dgvSelectedItem.ClearSelection()
                dgvSelectedItem.Rows(dgvSelectedItem.Rows.Count - 1).Selected = True
                dgvCount()
                load_selecteditems()

                txtboxListItemSearch.Text = ""
                search()
                Return
            End If
        ElseIf selectedQuantity = "Update Quantity" Then
            Dim get_itemname As String = lblQuantityItemName.Text.Replace("Item Name: ", "")
            Dim get_itemcode As String = lblQuantityItemCode.Text.Replace("Item Code: ", "")
            For i As Integer = 0 To dgvSelectedItem.Rows.Count - 1
                If get_itemcode = dgvSelectedItem.Rows(i).Cells(0).Value And get_itemname = dgvSelectedItem.Rows(i).Cells(1).Value Then
                    dgvSelectedItem.Rows(i).Cells("quantityy").Value = txtboxQuantity.Text
                    Dim r As String = ""
                    If String.IsNullOrEmpty(txtreject.Text) Then
                        r = "0"
                    Else
                        r = txtreject.Text
                    End If
                    dgvSelectedItem.Rows(i).Cells("reject").Value = r
                    dgvSelectedItem.Rows(i).Cells("charge").Value = txtcharge.Text
                    txtboxQuantity.Text = ""
                    txtreject.Text = ""
                    txtcharge.Text = ""
                    panelQuantity.Visible = False

                    txtboxListItemSearch.Text = ""
                    search()

                End If
            Next
        End If
    End Sub

    Private Sub btnQuantity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuantity.Click
        addquantity()
    End Sub
    Public Function checkRowsExist() As Boolean
        Dim get_itemname As String = lblQuantityItemName.Text.Replace("Item Name: ", "")
        Dim get_itemcode As String = lblQuantityItemCode.Text.Replace("Item Code: ", "")
        For i As Integer = 0 To dgvSelectedItem.Rows.Count - 1
            If get_itemcode = dgvSelectedItem.Rows(i).Cells(0).Value And get_itemname = dgvSelectedItem.Rows(i).Cells(1).Value Then
                Dim quantity_add As Integer = Val(dgvSelectedItem.Rows(i).Cells(3).Value) + Val(txtboxQuantity.Text)
                Dim quantity_reject As Integer = Val(dgvSelectedItem.Rows(i).Cells(4).Value) + Val(txtreject.Text)
                Dim quantity_charge As Integer = Val(dgvSelectedItem.Rows(i).Cells(5).Value) + Val(txtcharge.Text)
                dgvSelectedItem.Rows(i).Cells(3).Value = quantity_add
                dgvSelectedItem.Rows(i).Cells(4).Value = quantity_reject
                dgvSelectedItem.Rows(i).Cells(5).Value = quantity_charge
                Me.Cursor = Cursors.WaitCursor
                panelQuantity.Visible = False
                Me.Cursor = Cursors.Default
                txtboxQuantity.Text = ""
                dgvSelectedItem.ClearSelection()
                dgvSelectedItem.Rows(dgvSelectedItem.Rows.Count - 1).Selected = True
                dgvCount()
                load_selecteditems()
                Return True
            End If
        Next
    End Function
    Public Sub load_items(ByVal query As String)
        dgvListItem.Rows.Clear()
        Dim auto As New AutoCompleteStringCollection()
        con.Open()
        cmd = New SqlCommand(query, con)
        rdr = cmd.ExecuteReader()
        While rdr.Read()
            If Me.Text = "Received From Adjustment" Then
                dgvListItem.Rows.Add(rdr("itemcode").ToString(), rdr("itemname").ToString(), rdr("category").ToString(), "")
            Else
                dgvListItem.Rows.Add(rdr("itemcode").ToString(), rdr("itemname").ToString(), rdr("category").ToString(), "")
            End If
            auto.Add(rdr("itemcode"))
            auto.Add(rdr("itemname"))
        End While
        con.Close()
        txtboxListItemSearch.AutoCompleteCustomSource = auto
        dgvCount()
    End Sub
    Public Sub dgvCount()
        lblListItemCount.Text = CStr(dgvListItem.Rows.Count)
        lblSelectedItemCount.Text = CStr(dgvSelectedItem.Rows.Count)
    End Sub
    Public Sub load_selecteditems()
        Dim auto As New AutoCompleteStringCollection()
        For i As Integer = 0 To dgvSelectedItem.Rows.Count - 1
            auto.Add(dgvSelectedItem.Rows(i).Cells(0).Value)
            auto.Add(dgvSelectedItem.Rows(i).Cells(1).Value)
        Next
        txtboxSelectedItem.AutoCompleteCustomSource = auto
    End Sub
    Public Sub categories()
        Try
            cmbCategoryListItem.Items.Clear()
            Dim q As String = ""
            If lcacc = "Production" Then
                q = "SELECT category FROM tblcat WHERE  status='1' AND Not category='Noodles' AND Not category='Packaging' AND not category='Drinks' AND NOT category='Meal' AND NOT category='Combo'"
            Else
                q = "Select category from tblcat where status='1' order by category"
            End If
            con.Open()
            cmd = New SqlCommand(q, con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                cmbCategoryListItem.Items.Add(rdr("category"))
            End While
            con.Close()
            If cmbCategoryListItem.Items.Count <> 0 Then
                cmbCategoryListItem.Items.Add("All")
            End If

        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub received_item_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtdate.Value = getSystemDate()
        dtdate.MaxDate = getSystemDate()
        lblheader.Text = Me.Text
        Label7.Visible = IIf(Me.Text.ToLower = "Received From Adjustment".ToLower, True, False)
        dtdate.Visible = IIf(Me.Text.ToLower = "Received From Adjustment".ToLower, True, False)
        load_selecteditems()
        categories()
        cmbCategoryListItem.SelectedIndex = cmbCategoryListItem.Items.IndexOf("All")
        lblheader.Text = Me.Text
        cmbranches.Sorted = True
        getLastInvProdID()

        load_cb()
        If lcacc = "Production" Or Me.Text = "Received From Adjustment" Or Me.Text = "Received From Production" Then
            cmbranches.Visible = False
            Label10.Visible = False
        ElseIf lcacc = "Sales" Then
            cmbranches.Visible = True
            Label10.Visible = True
        End If

        If Me.Text.ToLower = "Received From Other Branch".ToLower Then
            dgvSelectedItem.Columns("reject").Visible = False
            Label12.Visible = False
            txtreject.Visible = False
            txttransnum.Visible = True
        End If
    End Sub

    'Public Sub getID()
    '    Dim id As String = ""
    '    Dim date_ As New DateTime()
    '    con.Open()
    '    cmd = New SqlCommand("Select TOP 1 invnum,datecreated from tblinvsum WHERE area='" & lcacc & "' order by invsumid DESC", con)
    '    rdr = cmd.ExecuteReader()
    '    If rdr.Read() Then
    '        id = rdr("invnum")
    '        date_ = CDate(rdr("datecreated"))
    '    End If
    '    con.Close()
    '    If date_.ToString("MM/dd/yyyy") = getSystemDate.ToString("MM/dd/yyyy") Then
    '        lblID.Text = id
    '    Else
    '        lblID.Text = "N/A"
    '    End If
    'End Sub

    Public Function getID() As Boolean
        Dim result As Boolean = False, verify As Integer = 0, invdate As New Date(), invnum As String = ""
        con.Open()
        cmd = New SqlCommand("Select TOP 1 verify,invdate,invnum,datecreated from tblinvsum WHERE area='" & "Sales" & "' " & IIf(Me.Text.ToLower = "Received From Adjustment".ToLower, "AND CAST(datecreated AS date)='" & dtdate.Text & "'", "") & " order by invsumid DESC", con)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            result = True
            verify = rdr("verify")
            invdate = CDate(rdr("invdate"))
            invnum = CStr(rdr("invnum"))
        End If
        con.Close()

        If Me.Text.ToLower = "Received From Adjustment".ToLower Then
            lblID.Text = invnum
            Return True
        Else
            If verify = 1 Then
                If invdate = getSystemDate.ToString("MM/dd/yyyy") Then
                    MsgBox("Inventory end for this day.", MsgBoxStyle.Critical, "")
                    Return False
                Else
                    MessageBox.Show("Created New Inventory First", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If
            Else
                'If invdate.ToString("MM/dd/yyyy") = getSystemDate.ToString("MM/dd/yyyy") Then
                lblID.Text = invnum
                    Return True
                'Else
                '    MessageBox.Show("Created New Inventory First", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    Return False
                'End If
            End If
        End If
    End Function
    Public Function removeVowels(ByVal workgrp As String) As String
        Dim result = New StringBuilder
        For Each c In workgrp
            If Not "aeiou".Contains(c.ToString.ToLower) Then
                result.Append(c)
            End If
        Next
        Return result.ToString
    End Function
    Public Sub getLastInvProdID()
        con.Open()
        cmd = New SqlCommand("SELECT TOP 1 invnum FROM tblinvsum WHERE area='" & lcacc & "' and verify='0' order by invsumid DESC", con)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            prodcurrentinv = rdr("invnum")
        End If
        con.Close()
    End Sub

    Public Sub GetTransID()
        Try
            Dim selectcount_result As Integer = 0
            Dim get_area As String = "", temp As String = "0"
            Dim area_format As String = ""
            con.Open()
            Dim taypz As String = ""
            If lcacc = "Production" Then
                taypz = "Produce Item"
            Else
                If Me.Text = "Received From Adjustment" Then
                    taypz = "Adjustment Item"
                Else
                    taypz = "Received Item"
                End If
            End If
            Dim type2 As String = ""
            If Me.Text = "Received from Other Branch" Then
                type2 = Me.Text
            ElseIf Me.Text = "Received from Direct Supplier" Then
                type2 = Me.Text
            ElseIf Me.Text = "Received From Adjustment" Then
                type2 = "Adjustment"
            ElseIf Me.Text = "Received From Production" Then
                type2 = "Received From Production"
            End If
            cmd = New SqlCommand("Select ISNULL(MAX(transaction_id),0)  from tblproduction WHERE area='" & If(Me.Text = "Received From Adjustment", "Sales", lcacc) & "' AND type='" & taypz & "' AND type2='" & type2 & "';", con)
            selectcount_result = cmd.ExecuteScalar + 1
            con.Close()
            Dim branchcode As String = ""
            con.Open()
            cmd = New SqlCommand("SELECT branchcode FROM tblbranch WHERE main='1';", con)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                branchcode = rdr("branchcode")
            End If
            con.Close()
            If lcacc = "Sales" Then
                If Me.Text = "Received from Other Branch" Then
                    area_format = "RECBRA - " & branchcode & " - "
                ElseIf Me.Text = "Received from Direct Supplier" Then
                    area_format = "RECSUPP - " & branchcode & " - "
                ElseIf Me.Text = "Received From Adjustment" Then
                    area_format = "ADJIN - " & branchcode & " - "
                ElseIf Me.Text = "Received From Production" Then
                    area_format = "RECPROD - " & branchcode & " - "
                End If
            ElseIf lcacc = "Production" Then
                If Me.Text = "Received From Adjustment" Then
                    area_format = "PRODADJIN - " & branchcode & " - "
                Else
                    area_format = "PROD - " & branchcode & " - "
                End If
            End If

            If selectcount_result < 1000000 Then
                Dim cselectcount_result As String = CStr(selectcount_result)
                For vv As Integer = 0 To 6 - cselectcount_result.Length
                    temp += "0"
                Next
                lblTransactionID.Text = area_format & temp & selectcount_result
                If lcacc = "Production" Then
                    txttransnum.Text = lblTransactionID.Text
                    txttransnum.ReadOnly = True
                Else
                    txttransnum.Text = ""
                    txttransnum.ReadOnly = False
                End If
            Else
                lblTransactionID.Text = area_format & temp & selectcount_result
            End If
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information, "")
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub dgvListItem_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListItem.CellContentClick
        If e.ColumnIndex = 3 Then
            If Me.Text = "Received from Direct Supplier" And cmbranches.Text = "" Then
                MessageBox.Show("Select branch first", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                txtboxQuantity.Focus()
                lblQuantityItemCode.Text = "Item Code: " & dgvListItem.CurrentRow.Cells(0).Value.ToString
                lblQuantityItemName.Text = "Item Name: " & dgvListItem.CurrentRow.Cells(1).Value.ToString
                lblQuantityCategory.Text = "Category: " & dgvListItem.CurrentRow.Cells(2).Value.ToString
                panelQuantity.Visible = True
                panelQuantity.BringToFront()
                selectedQuantity = "Add Quantity"
                txtboxQuantity.Focus()
            End If
        End If
    End Sub
    Public Sub search()
        If Not String.IsNullOrEmpty(txtboxListItemSearch.Text) Then
            con.Open()
            dgvListItem.Rows.Clear()
            cmd = New SqlCommand("SELECT itemcode,itemname,category FROM tblitems WHERE itemname LIKE @name AND discontinued =0", con)
            cmd.Parameters.AddWithValue("@name", "%" & txtboxListItemSearch.Text & "%")
            rdr = cmd.ExecuteReader()
            While rdr.Read
                dgvListItem.Rows.Add(rdr("itemcode"), rdr("itemname"), rdr("category"))
            End While
            con.Close()

            If Me.Text = "Received from Direct Supplier" And cmbranches.Text = "" Then
                MessageBox.Show("Select branch first", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                If dgvListItem.RowCount <> 0 Then
                    txtboxQuantity.Focus()
                    lblQuantityItemCode.Text = "Item Code: " & dgvListItem.CurrentRow.Cells(0).Value.ToString
                    lblQuantityItemName.Text = "Item Name: " & dgvListItem.CurrentRow.Cells(1).Value.ToString
                    lblQuantityCategory.Text = "Category: " & dgvListItem.CurrentRow.Cells(2).Value.ToString
                    panelQuantity.Visible = True
                    panelQuantity.BringToFront()
                    selectedQuantity = "Add Quantity"
                    txtboxQuantity.Focus()
                End If
            End If

        Else
            cmbCategoryListItem.SelectedIndex = -1
            cmbCategoryListItem.SelectedItem = "All"
        End If
    End Sub
    Private Sub btnSearchListItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchListItem.Click
        search()
    End Sub

    Private Sub txtboxQuantity_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtboxQuantity.KeyPress, txtreject.KeyPress, txtcharge.KeyPress
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub dgvSelectedItem_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSelectedItem.CellContentClick
        If e.ColumnIndex = 6 Then
            lblQuantityItemCode.Text = "Item Code: " & dgvSelectedItem.CurrentRow.Cells(0).Value.ToString
            lblQuantityItemName.Text = "Item Name: " & dgvSelectedItem.CurrentRow.Cells(1).Value.ToString
            panelQuantity.Visible = True
            panelQuantity.BringToFront()
            selectedQuantity = "Update Quantity"
            txtboxQuantity.Text = dgvSelectedItem.CurrentRow.Cells(3).Value
            txtreject.Text = dgvSelectedItem.CurrentRow.Cells(4).Value
            txtcharge.Text = dgvSelectedItem.CurrentRow.Cells(5).Value
            txtboxQuantity.Focus()
        ElseIf e.ColumnIndex = 7 Then
            Dim a As String = MsgBox("Are you sure you want to delete?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "")
            If a = vbYes Then
                dgvSelectedItem.Rows.RemoveAt(e.RowIndex)
            End If
        End If
    End Sub
    Public Sub search2()
        con.Open()
        cmd = New SqlCommand("SELECT itemcode,itemname FROM tblitems WHERE itemname=@name", con)
        cmd.Parameters.AddWithValue("@name", txtboxSelectedItem.Text)
        rdr = cmd.ExecuteReader()
        If rdr.Read() Then

            For i As Integer = 0 To dgvSelectedItem.Rows.Count - 1
                If dgvSelectedItem.Rows(i).Cells(1).Value = rdr("itemname") Then
                    dgvSelectedItem.Rows(i).Selected = True
                    dgvSelectedItem.CurrentCell = dgvSelectedItem.Rows(i).Cells(1)
                Else
                    dgvSelectedItem.Rows(i).Selected = False
                End If
            Next
        End If
        con.Close()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        search2()
    End Sub
    Public Sub cmbcat()
        If Me.Text = "Received From Production" Then
            If cmbCategoryListItem.Text = "All" Then
                load_items("SELECT itemcode,itemname,category FROM tblitems WHERE discontinued='0'  and Not category='Noodles' AND Not category='Packaging' AND not category='Drinks' AND NOT category='Meal' AND NOT category='Combo' AND NOT category='Spreads' ORDER BY itemcode")
            Else
                load_items("SELECT itemcode,itemname,category FROM tblitems WHERE discontinued='0'  and Not category='Noodles' AND Not category='Packaging' AND not category='Drinks' AND NOT category='Meal' AND NOT category='Combo' AND NOT category='Spreads' AND category='" & cmbCategoryListItem.Text & "' ORDER BY itemcode")
            End If
        ElseIf Me.Text.ToLower = "Received From Direct Supplier".ToLower Then
            If cmbCategoryListItem.Text = "All" Then
                load_items("SELECT itemcode,itemname,category FROM tblitems WHERE discontinued='0'  and Not category='Noodles' AND Not category='Cake' AND not category='Breads' AND NOT category='Meal' AND NOT category='Combo' ORDER BY itemcode")
            Else
                load_items("SELECT itemcode,itemname,category FROM tblitems WHERE discontinued='0'  and Not category='Noodles' AND Not category='Cake' AND not category='Breads' AND NOT category='Meal' AND NOT category='Combo' AND category='" & cmbCategoryListItem.Text & "' ORDER BY itemcode")
            End If
        Else
            If cmbCategoryListItem.Text = "All" Then
                load_items("SELECT itemcode,itemname,category FROM tblitems WHERE discontinued='0'  ORDER BY itemcode")
            Else
                load_items("SELECT itemcode,itemname,category FROM tblitems WHERE discontinued='0' AND category='" & cmbCategoryListItem.Text & "' ORDER BY itemcode")
            End If
        End If
    End Sub
    Private Sub cmbCategoryListItem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCategoryListItem.SelectedIndexChanged
        cmbcat()
    End Sub
    Public Sub loadz()
        If Me.Text = "Received From Production" Then
            load_items("SELECT itemcode,itemname,category FROM tblitems WHERE discontinued='0'  and Not category='Noodles' AND Not category='Packaging' AND not category='Drinks' AND NOT category='Meal' AND NOT category='Combo' ORDER BY itemcode")
        ElseIf lcacc <> "Production" And cmbCategoryListItem.Text = "All" Then
            load_items("SELECT itemcode,itemname,category FROM tblitems WHERE discontinued='0' ORDER BY itemcode")
        ElseIf cmbranches.SelectedIndex <> 0 Then

            load_items("SELECT itemcode,itemname,category FROM tblitems WHERE discontinued='0' AND category='" & cmbCategoryListItem.Text & "' ORDER BY itemcode")
        End If
    End Sub
    Public Sub query()
        Dim a As String = MsgBox("Are you sure you want to add?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MessageBoxDefaultButton.Button2, "")
        If a = vbYes Then
            chckSAP.Checked = True
            chckSAP.Checked = False
            If Me.Text = "Received From Adjustment" Then
                chckSAP.Visible = True
            Else
                chckSAP.Visible = False
            End If
            PanelProduction.Visible = True
            txtboxRemarks.Focus()
        End If
    End Sub
    Public Function checkCutOff() As Boolean
        Try
            Dim status As String = "", date_from As New DateTime()
            con.Open()
            cmd = New SqlCommand("SELECT status,date FROM tblcutoff WHERE userid=(SELECT systemid FROM tblusers WHERE username=@username) ORDER BY cid DESC;", con)
            cmd.Parameters.AddWithValue("@username", login2.username)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                status = rdr("status")
                date_from = CDate(rdr("date"))
            End If
            con.Close()
            If status = "In Active" And date_from.ToString("MM/dd/yyyy") = getSystemDate.ToString("MM/dd/yyyy") Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function

    Public Sub proceed()
        Try
            GetTransID()
            If checkCutOff() Then
                MessageBox.Show("Your account is already cut off", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If String.IsNullOrEmpty(Trim(txtboxSAPNo.Text)) And checkfollowup.Checked = False Then
                If chckSAP.Checked = True And Me.Text = "Received From Adjustment" And checkfollowup.Checked = False Then
                    MessageBox.Show("# is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                ElseIf Me.Text <> "Received From Adjustment" And checkfollowup.Checked = False Then
                    MessageBox.Show("# is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            ElseIf txtboxSAPNo.TextLength <= 5 And chckSAP.Checked = False Then
                If chckSAP.Checked = True And Me.Text = "Received From Adjustment" And checkfollowup.Checked = False Then
                    MessageBox.Show("# must be at least 6 numbers", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                ElseIf Me.Text <> "Received From Adjustment" And checkfollowup.Checked = False Then
                    MessageBox.Show("# must be at least 6 numbers", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

            ElseIf String.IsNullOrEmpty(Trim(txtboxRemarks.Text)) And chckSAP.Checked Then
                MessageBox.Show("Remarks is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
                'ElseIf String.IsNullOrEmpty(txttransnum.Text) And lcacc <> "Production" And chckSAP.Checked Then
                '    MessageBox.Show("Transaction # is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    Exit Sub
            End If
            rc.setSAPNumber(txtboxSAPNo.Text)
            If chckSAP.Checked = False And rc.checkSAPNumber() Then
                MessageBox.Show("SAP Number '" & txtboxSAPNo.Text & "' is already exist", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            Dim mahBranch As String = ""
            con.Open()
            cmd = New SqlCommand("SELECT branchcode FROM tblbranch WHERE main='1';", con)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                mahBranch = rdr("branchcode")
            End If
            con.Close()

            If lblID.Text = "" Then
                MessageBox.Show("No Inventory found", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim sap_number As String = txtboxSAPNo.Text
            Dim remarks As String = txtboxRemarks.Text
            'Dim produce As Double = 0.0
            Dim inn As String = ""
            If type = "Direct" Then
                inn = "supin"
            Else
                If cmbranches.Text <> mahBranch And lcacc <> "Production" Then
                    inn = "itemin"
                Else
                    inn = "productionin"
                End If
                If Me.Text = "Received From Adjustment" Then
                    inn = "adjustmentin"
                End If
                If Me.Text = "Received From Production" Then
                    inn = "productionin"
                End If
            End If
            Try
                Using connection As New SqlConnection(cc.conString)
                    Dim cmdd As New SqlCommand()
                    cmdd.Connection = connection
                    connection.Open()
                    transaction = connection.BeginTransaction()
                    cmdd.Transaction = transaction
                    For Each r0w As DataGridViewRow In dgvSelectedItem.Rows
                        Dim que As String = "", qty As Double = CDbl(dgvSelectedItem.Rows(r0w.Index).Cells("quantityy").Value)
                        If lcacc = "Sales" Then
                            que = "Update tblinvitems set " & inn & "+='" & qty & "',good+='" & qty & "', totalav+='" & qty & "', endbal+='" & qty & "', variance-='" & qty & "' where itemname='" & dgvSelectedItem.Rows(r0w.Index).Cells("itemnamee").Value & "' and invnum='" & lblID.Text & "' AND area='" & lcacc & "'"
                        ElseIf lcacc = "Production" And Me.Text <> "Received From Adjustment" Then
                            que = "Update tblinvitems set " & inn & "+='" & qty & "',produce+='" & qty & "',good+='" & qty & "', totalav+='" & qty & "', endbal+='" & qty & "', variance-='" & qty & "' where itemname='" & dgvSelectedItem.Rows(r0w.Index).Cells("itemnamee").Value & "' and invnum='" & lblID.Text & "' AND area='" & lcacc & "'"
                        ElseIf lcacc = "Production" And Me.Text = "Received From Adjustment" Then
                            que = "Update tblinvitems set " & inn & "+='" & qty & "', totalav+='" & qty & "', endbal+='" & qty & "', variance-='" & qty & "' where itemname='" & dgvSelectedItem.Rows(r0w.Index).Cells("itemnamee").Value & "' and invnum='" & lblID.Text & "' AND area='" & lcacc & "'"
                        End If
                        cmdd.Parameters.Clear()
                        cmdd.CommandText = que
                        cmdd.ExecuteNonQuery()
                        'End If

                        cmdd.Parameters.Clear()
                        cmdd.CommandText = "Update tblitems set status='1' where itemname='" & dgvSelectedItem.Rows(r0w.Index).Cells("itemnamee").Value & "'"
                        cmdd.ExecuteNonQuery()

                        Dim valval As String = "", typee As String = ""
                        If cmbranches.Text = "" Then
                            If Me.Text = "Produce Item" Then
                                valval = mahBranch
                                typee = "Produce Item"
                            Else
                                typee = "Adjustment Item"
                            End If
                        Else
                            If cmbranches.Visible = True Then
                                valval = cmbranches.Text
                                typee = "Received Item"
                            Else
                                typee = "Adjustment Item"
                            End If
                        End If

                        If Me.Text = "Received From Production" Then
                            typee = "Received Item"
                        End If
                        Dim query As String = ""
                        Dim ms As New MemoryStream
                        If txtboxpath.Text <> "N/A" Then
                            PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
                            query = "INSERT INTO tblproduction (transaction_number,inv_id,item_code,item_name,category,quantity,reject,charge,sap_number,remarks,date,processed_by,type,area,status,transfer_from,transfer_to,from_transnum,attachment,typenum,type2) VALUES (@trans_id,@id, @code,@name,@cat,@qty,@reject,@charge,@sap,@remarks,(SELECT GETDATE()),@processed_by,@type,@area,@status,@from,@to,@from_transnum,@image,@typenum,@type2)"
                        Else
                            query = "INSERT INTO tblproduction (transaction_number,inv_id,item_code,item_name,category,quantity,reject,charge,sap_number,remarks,date,processed_by,type,area,status,transfer_from,transfer_to,from_transnum,typenum,type2) VALUES (@trans_id,@id, @code,@name,@cat,@qty,@reject,@charge,@sap,@remarks,(SELECT GETDATE()),@processed_by,@type,@area,@status,@from,@to,@from_transnum,@typenum,@type2)"
                        End If
                        cmdd.Parameters.Clear()
                        cmdd.CommandText = query
                        cmdd.Parameters.AddWithValue("@trans_id", lblTransactionID.Text)
                        cmdd.Parameters.AddWithValue("@id", lblID.Text)
                        cmdd.Parameters.AddWithValue("@code", dgvSelectedItem.Rows(r0w.Index).Cells(0).Value)
                        cmdd.Parameters.AddWithValue("@name", dgvSelectedItem.Rows(r0w.Index).Cells(1).Value)
                        cmdd.Parameters.AddWithValue("@cat", dgvSelectedItem.Rows(r0w.Index).Cells(2).Value)
                        cmdd.Parameters.AddWithValue("@qty", dgvSelectedItem.Rows(r0w.Index).Cells(3).Value)
                        cmdd.Parameters.AddWithValue("@reject", 0)
                        cmdd.Parameters.AddWithValue("@charge", 0)
                        If checkfollowup.Checked = True Or chckSAP.Checked Then
                            sap_number = "To Follow"
                        End If
                        cmdd.Parameters.AddWithValue("@sap", sap_number)
                        cmdd.Parameters.AddWithValue("@remarks", remarks)
                        cmdd.Parameters.AddWithValue("@processed_by", login2.username)
                        cmdd.Parameters.AddWithValue("@type", typee)
                        cmdd.Parameters.AddWithValue("@area", lcacc)
                        cmdd.Parameters.AddWithValue("@status", "Completed")
                        cmdd.Parameters.AddWithValue("@typenum", lblsapdoc.Text)
                        Dim fromBranch As String = "", toBranch As String = ""
                        If mahBranch = cmbranches.Text Then
                            If lcacc = "Production" Then
                                fromBranch = mahBranch & "(PRD)"
                                toBranch = mahBranch & "(PRD)"
                            ElseIf lcacc = "Sales" Then
                                fromBranch = mahBranch & "(PRD)"
                                toBranch = mahBranch & "(SLS)"
                            End If
                        Else
                            fromBranch = valval
                            toBranch = mahBranch
                        End If
                        Dim type2 As String = ""

                        If Me.Text = "Received From Adjustment" Then
                            type2 = "Adjustment"
                        Else
                            type2 = Me.Text
                        End If
                        cmdd.Parameters.AddWithValue("@type2", type2)
                        cmdd.Parameters.AddWithValue("@from", fromBranch)
                        cmdd.Parameters.AddWithValue("@to", toBranch)
                        cmdd.Parameters.AddWithValue("@from_transnum", txttransnum.Text)

                        If txtboxpath.Text <> "" Then
                            cmdd.Parameters.AddWithValue("@image", SqlDbType.Image).Value = ms.ToArray()
                        End If
                        cmdd.ExecuteNonQuery()
                    Next
                    transaction.Commit()
                End Using
            Catch ex As Exception
                Try
                    transaction.Rollback()
                Catch ex2 As Exception
                    MessageBox.Show(ex2.ToString)
                End Try
            End Try
            Dim frm As New show_trans()
            frm.lbltr.Text = lblTransactionID.Text
            frm.ShowDialog()

            MessageBox.Show("Added", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            lblsapdoc.Text = "N/A"
            txtboxpath.Text = "N/A"
            txtboxRemarks.Text = ""
            checkfollowup.Checked = False
            txtboxSAPNo.Text = ""
            PanelProduction.Visible = False
            PictureBox1.Image = Nothing
            dgvSelectedItem.Rows.Clear()
            loadz()
            dgvCount()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btnProceed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProceed.Click
        proceed()
    End Sub
    Public Sub loadtransnum()
        Try
            Dim area As String = ""
            If lcacc = "Cashier" Or lcacc = "Sales" Then
                area = "Sales"
            Else
                area = lcacc
            End If
            Dim selectcount_result As Integer = 0
            Dim branchcode As String = "", temp As String = "0", area_format As String = ""
            con.Open()
            cmd = New SqlCommand("Select ISNULL(MAX(transnum),0)  FROM tbltransaction WHERE area='" & area & "';", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                selectcount_result += 1
            End While
            selectcount_result += 1
            con.Close()

            con.Open()
            cmd = New SqlCommand("Select branchcode FROM tblbranch WHERE main='1';", con)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                branchcode = rdr("branchcode")
            End If
            con.Close()
            area_format = "TR - " & branchcode & " - "
            If selectcount_result < 1000000 Then
                Dim cselectcount_result As String = CStr(selectcount_result)
                For vv As Integer = 1 To 6 - cselectcount_result.Length
                    temp += "0"
                Next
                trnum = area_format & temp & selectcount_result
            End If
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information, "")
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub getARNum(ByVal typee As String, ByVal formatsu As String)
        Try
            Dim temp As String = "0", area_format As String = "", selectcount_result As Integer = 0
            con.Open()
            cmd = New SqlCommand("Select COUNT(*)  from tblars1 WHERE area='" & lcacc & "' AND type=@type;", con)
            cmd.Parameters.AddWithValue("@type", typee)
            selectcount_result = cmd.ExecuteScalar() + 1
            con.Close()

            Dim branchcode As String = ""
            con.Open()
            cmd = New SqlCommand("SELECT branchcode FROM tblbranch WHERE main='1';", con)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                branchcode = rdr("branchcode")
            End If
            con.Close()


            Dim format As String = ""
            If lcacc = "Production" Then
                format = "PRODAR" & formatsu & " - "
            ElseIf lcacc = "Sales" Then
                format = "SALAR" & formatsu & " - "
            End If

            area_format = format & branchcode & " - "

            If selectcount_result < 1000000 Then
                Dim cselectcount_result As String = CStr(selectcount_result)
                For vv As Integer = 1 To 6 - cselectcount_result.Length
                    temp += "0"
                Next
                ar_number = area_format & temp & selectcount_result
            End If
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information, "")
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If getID() Then
            getID()
        Else
            Exit Sub
        End If
        If dgvSelectedItem.Rows.Count = 0 Then
            MessageBox.Show("Please select item first", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf Me.Text = "Received from Direct Supplier" And cmbranches.Text = "" Then
            MessageBox.Show("Please select branch first", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf Me.Text = "Received from Other Branch" And cmbranches.Text = "" Then
            MessageBox.Show("Please select branch first", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf lblID.Text = "N/A" Then
            MessageBox.Show("Create New Inventory before adding item", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If received_type = "Branch" Then
            lblsapdoc.Text = "IT"
        ElseIf received_type = "Produce" Or Me.Text = "Received From Adjustment" Then
            lblsapdoc.Text = "GR"
        ElseIf received_type = "Production" Then
            lblsapdoc.Text = "IT"
        ElseIf received_type = "Direct" Then
            lblsapdoc.Text = "GRPO"
        End If
        query()
    End Sub

    Private Sub lblListItemCount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblListItemCount.Click

    End Sub

    Private Sub lblSAPClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSAPClose.Click
        PanelProduction.Visible = False
        txtboxRemarks.Text = ""
        txtboxSAPNo.Text = ""
        lblsapdoc.Text = "N/A"
    End Sub

    Private Sub cmbranches_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbranches.SelectedIndexChanged
        txtboxQuantity.Text = ""
        txtcharge.Text = ""
        txtreject.Text = ""
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub txtboxListItemSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtboxListItemSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            search()
        End If
    End Sub

    Private Sub txtboxSelectedItem_KeyDown(sender As Object, e As KeyEventArgs) Handles txtboxSelectedItem.KeyDown
        If e.KeyCode = Keys.Enter Then
            search2()
        End If
    End Sub

    Private Sub txtboxQuantity_KeyDown(sender As Object, e As KeyEventArgs) Handles txtboxQuantity.KeyDown
        If e.KeyCode = Keys.Enter Then
            addquantity()
        End If
    End Sub

    Private Sub txtreject_KeyDown(sender As Object, e As KeyEventArgs) Handles txtreject.KeyDown
        If e.KeyCode = Keys.Enter Then
            addquantity()
        End If
    End Sub

    Private Sub txtcharge_KeyDown(sender As Object, e As KeyEventArgs) Handles txtcharge.KeyDown
        If e.KeyCode = Keys.Enter Then
            addquantity()
        End If
    End Sub

    Private Sub PanelProduction_Paint(sender As Object, e As PaintEventArgs) Handles PanelProduction.Paint

    End Sub

    Private Sub txtboxSAPNo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtboxSAPNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            proceed()
        End If
    End Sub

    Private Sub txtboxRemarks_KeyDown(sender As Object, e As KeyEventArgs) Handles txtboxRemarks.KeyDown
        If e.KeyCode = Keys.Enter Then
            proceed()
        End If
    End Sub

    Private Sub txttransnum_KeyDown(sender As Object, e As KeyEventArgs) Handles txttransnum.KeyDown
        If e.KeyCode = Keys.Enter Then
            proceed()
        End If
    End Sub

    Private Sub chckSAP_KeyDown(sender As Object, e As KeyEventArgs) Handles chckSAP.KeyDown
        If e.KeyCode = Keys.Enter Then
            proceed()
        End If
    End Sub

    Private Sub checkfollowup_KeyDown(sender As Object, e As KeyEventArgs) Handles checkfollowup.KeyDown
        If e.KeyCode = Keys.Enter Then
            proceed()
        End If
    End Sub

    Private Sub dtdate_ValueChanged(sender As Object, e As EventArgs) Handles dtdate.ValueChanged
        getID()
        cmbcat()
    End Sub

    Private Sub chckSAP_CheckedChanged(sender As Object, e As EventArgs) Handles chckSAP.CheckedChanged
        If chckSAP.Checked Then
            txtboxSAPNo.Enabled = True
            txtboxRemarks.Enabled = True
            txttransnum.Enabled = True
            checkfollowup.Enabled = True
        Else
            If Me.Text = "Received From Adjustment" Then
                txtboxSAPNo.Text = ""
                txtboxRemarks.Text = ""
                txttransnum.Text = ""
                checkfollowup.Checked = False
                checkfollowup.Enabled = False
                txtboxSAPNo.Enabled = False
                txttransnum.Enabled = False
                txtboxRemarks.Enabled = True
            Else
                txtboxSAPNo.Enabled = True
                txtboxRemarks.Enabled = True
                txttransnum.Enabled = True
            End If
        End If
    End Sub

    Private Sub btnbrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbrowse.Click
        OpenFileDialog1.InitialDirectory = "C:\"
        OpenFileDialog1.Title = "Open a Picture File"
        OpenFileDialog1.Filter = "Picture File|*.jpg;*.png;*.jpeg"
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtboxpath.Text = OpenFileDialog1.FileName
            PictureBox1.ImageLocation = txtboxpath.Text
        End If
    End Sub

    Private Sub txtboxpath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtboxpath.Click
        pictures.PictureBox1.ImageLocation = txtboxpath.Text
        pictures.ShowDialog()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        pictures.PictureBox1.Image = PictureBox1.Image
        pictures.ShowDialog()
    End Sub

    Private Sub received_item_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Me.WindowState = FormWindowState.Maximized
        load_cb()
        If lcacc = "Production" Or Me.Text = "Received From Adjustment" Or Me.Text = "Received From Production" Then
            cmbranches.Visible = False
            Label10.Visible = False
        ElseIf lcacc = "Sales" Then
            cmbranches.Visible = True
            Label10.Visible = True
        End If
    End Sub
    Public Sub load_cb()
        Dim query As String = ""
        cmbranches.Items.Clear()
        If type = "" Then
            If lcacc = "Sales" Then
                query = "SELECT branchcode FROM tblbranch WHERE main='0' AND status=1;"
            ElseIf lcacc = "Production" Then
                query = "SELECT branchcode FROM tblbranch WHERE status=1;"
            End If
            con.Open()
            cmd = New SqlCommand(query, con)
            rdr = cmd.ExecuteReader()
            While rdr.Read
                cmbranches.Items.Add(rdr("branchcode"))
            End While
            con.Close()
        Else
            con.Open()
            cmd = New SqlCommand("SELECT name FROM tblcustomers WHERE type='Supplier' AND status='1';", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                cmbranches.Items.Add(rdr("name"))
            End While
            con.Close()
        End If
        If Me.Text = "Received From Adjustment" Or Me.Text = "Received From Production" Then
            cmbranches.Visible = False
            Label5.Text = "Enter Quantity"

            dgvSelectedItem.Columns("quantityy").HeaderText = "Quantity"
            dgvSelectedItem.Columns("reject").Visible = False
        Else
            Label5.Text = "Enter Good"
            cmbranches.Visible = True
            dgvSelectedItem.Columns("quantityy").HeaderText = "Good"
        End If
    End Sub
    Private Sub cmbranches_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbranches.SelectedValueChanged
    End Sub

    Private Sub txtboxSAPNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtboxSAPNo.KeyPress
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub checkfollowup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkfollowup.CheckedChanged
        If checkfollowup.Checked Then
            txtboxSAPNo.Text = ""
            txtboxSAPNo.Enabled = False
        Else
            txtboxSAPNo.Enabled = True
        End If
    End Sub
    Public Function getSystemDate() As DateTime
        Try
            Dim dt As New DateTime()
            con.Open()
            cmd = New SqlCommand("SELECT GETDATE()", con)
            rdr = cmd.ExecuteReader()
            While rdr.Read
                dt = CDate(rdr(0).ToString)
            End While
            con.Close()
            Return dt
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Function
End Class