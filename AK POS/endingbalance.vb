Imports System.Data.SqlClient
Imports System.Text
Imports System.IO
Imports AK_POS.connection_class
Public Class endingbalance
    Dim cc As New connection_class
    Dim strconn As String = cc.conString
    Dim con As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim transaction As SqlTransaction
    Dim selectedQuantity As String = ""
    Dim trans_num As String = "", ar_number As String = 0
    Public Sub GetTransID()
        Try
            Dim selectcount_result As Integer = 0
            Dim get_area As String = "", temp As String = ""
            Dim area_format As String = ""
            con.Open()
            cmd = New SqlCommand("Select ISNULL(MAX(transaction_id),0)+1 transaction_number  from tblproduction WHERE area='Sales' AND type='Actual Ending Balance';", con)
            selectcount_result = cmd.ExecuteScalar
            con.Close()

            Dim branchcode As String = ""
            con.Open()
            cmd = New SqlCommand("SELECT branchcode FROM tblbranch WHERE main='1';", con)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                branchcode = rdr("branchcode")
            End If
            con.Close()

            If selectcount_result < 1000000 Then
                Dim cselectcount_result As String = CStr(selectcount_result)
                For vv As Integer = 1 To 6 - cselectcount_result.Length
                    temp += "0"
                Next
                area_format = "AEB - " & branchcode & " - " & temp & selectcount_result
            End If
            trans_num = area_format
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
    Private Sub lblClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClose.Click
        panelQuantity.Visible = False
        lblQuantityItemCode.Text = "Item Code N/ A"
        lblQuantityItemName.Text = "Item Name N/ A"
        lblQuantityCategory.Text = "Category N/ A"
        txtname.Text = ""
        txtboxQuantity.Text = ""
    End Sub

    Public Function checkEndbal(ByVal invnum As String, ByVal itemname As String, ByVal itemcode As String) As Double
        Dim endbal2 As Double = 0.0

        con.Open()
        cmd = New SqlCommand("Select endbal FROM tblinvitems WHERE invnum=@invnum And itemname=@itemname And itemcode=@itemcode;", con)
        cmd.Parameters.AddWithValue("@invnum", invnum)
        cmd.Parameters.AddWithValue("@itemname", itemname)
        cmd.Parameters.AddWithValue("@itemcode", itemcode)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            endbal2 = CDbl(rdr("endbal"))
        End If
        con.Close()
        Return endbal2
    End Function
    Public Sub addquantity()
        Dim get_itemname As String = lblQuantityItemName.Text.Replace("Item Name: ", "")
        Dim get_itemcode As String = lblQuantityItemCode.Text.Replace("Item Code: ", "")
        Dim get_category As String = lblQuantityCategory.Text.Replace("Category: ", "")
        If selectedQuantity = "Add Quantity" Then
            If checkRowsExist() Then
                Return
            End If
            If String.IsNullOrEmpty(txtboxQuantity.Text) Then
                MessageBox.Show("Quantity Is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            Else
                Dim isExist As Integer = 0
                For index As Integer = 0 To dgvSelectedItem.RowCount - 1
                    If get_itemname = dgvSelectedItem.Rows(index).Cells("itemname").Value Then
                        isExist += 1
                    End If
                Next

                If isExist <> 0 Then
                    MessageBox.Show("This Item is already exist", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                Dim endbal As Double = 0.0
                con.Open()
                cmd = New SqlCommand("SELECT endbal FROM tblinvitems WHERE invnum=@invnum And itemname=@itemname And itemcode=@itemcode; ", con)
                cmd.Parameters.AddWithValue("@invnum", lblID.Text)
                cmd.Parameters.AddWithValue("@itemname", get_itemname)
                cmd.Parameters.AddWithValue("@itemcode", get_itemcode)
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    endbal = CDbl(rdr("endbal"))
                End If
                con.Close()
                If endbal > CDbl(txtboxQuantity.Text) Then
                    Dim b As Boolean = False
                    con.Open()
                    cmd = New SqlCommand("SELECT customer_Id  FROM tblcustomers WHERE name=@name", con)
                    cmd.Parameters.AddWithValue("@name", txtname.Text)
                    rdr = cmd.ExecuteReader
                    If rdr.Read Then
                        b = True
                    End If
                    con.Close()
                    If b Then
                        dgvSelectedItem.Rows.Add(get_itemcode, get_itemname, get_category, txtboxQuantity.Text, lblcharge.Text, txtname.Text, "", "")
                    Else
                        MessageBox.Show("Employee name Is Not found", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                Else
                    dgvSelectedItem.Rows.Add(get_itemcode, get_itemname, get_category, txtboxQuantity.Text, "0", "")
                End If
                Me.Cursor = Cursors.WaitCursor
                panelQuantity.Visible = False
                lblQuantityItemCode.Text = "Item Code N/ A"
                lblQuantityItemName.Text = "Item Name N/ A"
                lblQuantityCategory.Text = "Category N/ A"
                txtboxQuantity.Text = 0
                txtname.Text = ""
                Me.Cursor = Cursors.Default
                txtboxQuantity.Text = ""
                dgvSelectedItem.ClearSelection()
                dgvSelectedItem.Rows(dgvSelectedItem.Rows.Count - 1).Selected = True
                dgvCount()
                load_selecteditems()

                'txtboxListItemSearch.Text = ""
                'search()

                Return
            End If
        ElseIf selectedQuantity = "Update Quantity" Then
            If String.IsNullOrEmpty(txtboxQuantity.Text) Then
                MessageBox.Show("Quantity Is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            For i As Integer = 0 To dgvSelectedItem.Rows.Count - 1
                If get_itemcode = dgvSelectedItem.Rows(i).Cells(0).Value And get_itemname = dgvSelectedItem.Rows(i).Cells(1).Value Then


                    Dim endbal As Double = 0.0
                    con.Open()
                    cmd = New SqlCommand("SELECT endbal FROM tblinvitems WHERE invnum=@invnum And itemname=@itemname And itemcode=@itemcode; ", con)
                    cmd.Parameters.AddWithValue("@invnum", lblID.Text)
                    cmd.Parameters.AddWithValue("@itemname", get_itemname)
                    cmd.Parameters.AddWithValue("@itemcode", get_itemcode)
                    rdr = cmd.ExecuteReader
                    If rdr.Read Then
                        endbal = CDbl(rdr("endbal"))
                    End If
                    con.Close()
                    If endbal > CDbl(txtboxQuantity.Text) Then
                        If String.IsNullOrEmpty(txtname.Text) Then
                            MessageBox.Show("Employee name field Is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        Else
                            Dim b As Boolean = False
                            con.Open()
                            cmd = New SqlCommand("SELECT customer_Id  FROM tblcustomers WHERE name=@name", con)
                            cmd.Parameters.AddWithValue("@name", txtname.Text)
                            rdr = cmd.ExecuteReader
                            If rdr.Read Then
                                b = True
                            End If
                            con.Close()
                            If b Then
                                dgvSelectedItem.Rows(i).Cells(3).Value = txtboxQuantity.Text
                                dgvSelectedItem.Rows(i).Cells("charge").Value = lblcharge.Text
                                dgvSelectedItem.Rows(i).Cells("employee").Value = txtname.Text
                            Else
                                MessageBox.Show("Employee name Is Not found", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If
                        End If
                    Else
                        dgvSelectedItem.Rows(i).Cells(3).Value = txtboxQuantity.Text
                        dgvSelectedItem.Rows(i).Cells("charge").Value = "0"
                        dgvSelectedItem.Rows(i).Cells("employee").Value = ""
                    End If
                    txtboxQuantity.Text = ""
                    panelQuantity.Visible = False
                    'txtboxListItemSearch.Text = ""
                    'search()
                End If
            Next
        End If
    End Sub

    Private Sub btnQuantity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuantity.Click
        addquantity()
    End Sub
    Public Function checkRowsExist() As Boolean
        Dim get_itemname As String = lblQuantityItemName.Text.Replace("Item Name ", "")
        Dim get_itemcode As String = lblQuantityItemCode.Text.Replace("Item Code ", "")
        For i As Integer = 0 To dgvSelectedItem.Rows.Count - 1
            If get_itemcode = dgvSelectedItem.Rows(i).Cells(0).Value And get_itemname = dgvSelectedItem.Rows(i).Cells(1).Value Then
                Dim quantity_add As Integer = CInt(txtboxQuantity.Text)
                Dim charge_add As Integer = CInt(lblcharge.Text)
                dgvSelectedItem.Rows(i).Cells(3).Value = quantity_add
                dgvSelectedItem.Rows(i).Cells(4).Value = charge_add
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
    Public Sub load_items()
        Try
            dgvListItem.Rows.Clear()
            con.Open()
            cmd = New SqlCommand("SELECT a.itemcode,a.itemname,b.category FROM tblinvitems a INNER JOIN tblitems b ON a.itemname = b.itemname WHERE a.totalav !=0 AND a.invnum=@invnum", con)
            cmd.Parameters.AddWithValue("@invnum", lblID.Text)
            Dim adptr As New SqlDataAdapter()
            Dim dt As New DataTable()
            adptr.SelectCommand = cmd
            adptr.Fill(dt)
            con.Close()
            For Each r0w As DataRow In dt.Rows
                con.Open()
                cmd = New SqlCommand("SELECT inv_id FROM tblproduction a WHERE a.inv_id=@invnum AND a.type='Actual Ending Balance' AND a.item_name=@itemname;", con)
                cmd.Parameters.AddWithValue("@invnum", lblID.Text)
                cmd.Parameters.AddWithValue("@itemname", r0w("itemname"))
                rdr = cmd.ExecuteReader
                If Not rdr.Read Then
                    dgvListItem.Rows.Add(r0w("itemcode"), r0w("itemname"), r0w("category"))
                End If
                con.Close()
            Next

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
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

            con.Open()
            cmd = New SqlCommand("Select category from tblcat where status='1' order by category", con)
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
    Public Sub getID()
        Dim id As String = ""
        Dim date_ As New DateTime()
        con.Open()
        cmd = New SqlCommand("Select TOP 1 invnum,datecreated from tblinvsum WHERE area='Sales' order by invsumid DESC", con)
        rdr = cmd.ExecuteReader()
        If rdr.Read() Then
            id = rdr("invnum")
            date_ = CDate(rdr("datecreated"))
        End If
        con.Close()
        lblID.Text = id
    End Sub
    Public Sub cellclick()
        Dim c As Boolean = False
        con.Open()
        cmd = New SqlCommand("SELECT tblproduction.item_name FROM tblproduction JOIN tblitems ON tblproduction.item_name= tblitems.itemname WHERE inv_id=@inv AND tblproduction.item_name=@inamee AND tblproduction.item_code=@icodee AND type='Actual Ending Balance';", con)
        cmd.Parameters.AddWithValue("@inamee", dgvListItem.CurrentRow.Cells(1).Value.ToString)
        cmd.Parameters.AddWithValue("@icodee", dgvListItem.CurrentRow.Cells(0).Value.ToString)
        cmd.Parameters.AddWithValue("@inv", lblID.Text)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            c = True
        End If
        con.Close()
        If c Then
            MessageBox.Show("This item has already Actual Ending Balance", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        txtboxQuantity.Text = ""
        lblQuantityItemCode.Text = "Item Code: " & dgvListItem.CurrentRow.Cells(0).Value.ToString
        lblQuantityItemName.Text = "Item Name: " & dgvListItem.CurrentRow.Cells(1).Value.ToString
        lblQuantityCategory.Text = "Category: " & dgvListItem.CurrentRow.Cells(2).Value.ToString
        quantity_txt()
        panelQuantity.Visible = True
        panelQuantity.BringToFront()
        selectedQuantity = "Add Quantity"
        txtboxQuantity.Focus()
    End Sub
    Private Sub dgvListItem_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListItem.CellContentClick
        If e.ColumnIndex = 3 Then

            cellclick()
        End If
    End Sub
    Public Sub search()
        If Not String.IsNullOrEmpty(txtboxListItemSearch.Text) Then
            dgvListItem.Rows.Clear()
            con.Open()
            cmd = New SqlCommand("SELECT DISTINCT tblinvitems.itemcode,tblinvitems.itemname,tblitems.category from tblinvitems JOIN tblitems ON tblinvitems.itemname = tblitems.itemname AND tblinvitems.itemcode = tblitems.itemcode  WHERE tblinvitems.totalav != 0  AND tblinvitems.invnum='" & lblID.Text & "' AND tblinvitems.itemname LIKE @name ORDER BY tblinvitems.itemname;", con)
            cmd.Parameters.AddWithValue("@name", "%" & txtboxListItemSearch.Text & "%")
            rdr = cmd.ExecuteReader
            While rdr.Read
                dgvListItem.Rows.Add(rdr("itemcode"), rdr("itemname"), rdr("category"))
            End While
            con.Close()

            If dgvListItem.RowCount <> 0 Then
                cellclick()
            End If
        Else
            load_items()
        End If
    End Sub
    Private Sub btnSearchListItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchListItem.Click
        search()
    End Sub

    Private Sub txtboxQuantity_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtboxQuantity.KeyPress
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
            lblcharge.Text = dgvSelectedItem.CurrentRow.Cells("charge").Value
            txtname.Text = dgvSelectedItem.CurrentRow.Cells("employee").Value
            txtboxQuantity.Text = dgvSelectedItem.CurrentRow.Cells(3).Value
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
    'Public Sub loadd()
    '    If cmbCategoryListItem.Text = "All" Then
    '        If rb1.Checked Then
    '            load_items("SELECT DISTINCT tblinvitems.itemcode,tblinvitems.itemname,tblitems.category from tblinvitems JOIN tblitems ON tblinvitems.itemname = tblitems.itemname  WHERE tblinvitems.invnum='" & lblID.Text & "' AND tblinvitems.actualendbal !=0 AND tblinvitems.totalav !=0")
    '        ElseIf rb2.Checked Then
    '            load_items("SELECT DISTINCT tblinvitems.itemcode,tblinvitems.itemname,tblitems.category from tblinvitems JOIN tblitems ON tblinvitems.itemname = tblitems.itemname  WHERE  tblinvitems.invnum='" & lblID.Text & "' AND tblinvitems.actualendbal =0 AND tblinvitems.totalav !=0")
    '        End If
    '    ElseIf cmbCategoryListItem.Text <> "All" Then
    '        If rb1.Checked Then
    '            load_items("SELECT DISTINCT tblinvitems.itemcode,tblinvitems.itemname,tblitems.category from tblinvitems JOIN tblitems ON tblinvitems.itemname = tblitems.itemname  WHERE  tblinvitems.invnum='" & lblID.Text & "' AND tblitems.category='" & cmbCategoryListItem.Text & "' AND tblinvitems.actualendbal !=0 AND tblinvitems.totalav !=0")
    '        ElseIf rb2.Checked Then
    '            load_items("SELECT DISTINCT tblinvitems.itemcode,tblinvitems.itemname,tblitems.category from tblinvitems JOIN tblitems ON tblinvitems.itemname = tblitems.itemname  WHERE  tblinvitems.invnum='" & lblID.Text & "' AND tblitems.category='" & cmbCategoryListItem.Text & "' AND tblinvitems.actualendbal =0 AND tblinvitems.totalav !=0")
    '        End If

    '    End If
    'End Sub
    Private Sub cmbCategoryListItem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCategoryListItem.SelectedIndexChanged
        load_items()
    End Sub

    Public Function getOrdernum() As Integer
        Dim selectcount_result As Integer = 0
        con.Open()
        cmd = New SqlCommand("Select ISNULL(MAX(ordernum),0) from tbltransaction2 WHERE area='" & "Sales" & "' AND CAST(datecreated AS date)='" & DateTime.Now.ToString("MM/dd/yyyy") & "';", con)
        selectcount_result = cmd.ExecuteScalar() + 1
        con.Close()

        con.Open()
        cmd = New SqlCommand("SELECT ordernum FROM tbltransaction2 WHERE ordernum=@ordernum AND CAST(datecreated AS date)='" & DateTime.Now.ToString("MM/dd/yyyy") & "';", con)
        cmd.Parameters.AddWithValue("@ordernum", selectcount_result)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            selectcount_result += 1
        End If
        con.Close()

        Return selectcount_result
    End Function


    Public Sub query()
        Try
            If String.IsNullOrEmpty(Trim(txtboxremarks.Text)) Then
            Else
                Dim a As String = MsgBox("Are you sure you want to update?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MessageBoxDefaultButton.Button2, "")
                If a = vbYes Then
                    Dim ordernum As Integer = getOrdernum()
                    GetTransID()
                    Dim dt As New DataTable()
                    For Each column As DataGridViewColumn In dgvSelectedItem.Columns
                        dt.Columns.Add(column.Name)
                    Next
                    For Each row As DataGridViewRow In dgvSelectedItem.Rows
                        dt.Rows.Add(row.Cells("itemcode").Value, row.Cells("itemname").Value, row.Cells("category").Value, row.Cells("quantity").Value, row.Cells("charge").Value, row.Cells("employee").Value, "", "")
                    Next
                    Using connection As New SqlConnection(cc.conString)
                        Dim cmdd As New SqlCommand()
                        cmdd.Connection = connection

                        connection.Open()
                        transaction = connection.BeginTransaction()

                        cmdd.Transaction = transaction
                        For Each index As DataRow In dt.Rows
                            cmdd.Parameters.Clear()
                            cmdd.CommandText = "Update tblinvitems set endbal-=" & index("charge") & ", actualendbal=" & index("quantity") & ", variance=0,archarge+=" & index("charge") & " where itemcode='" & index("itemcode") & "' and invnum='" & lblID.Text & "'"
                            cmdd.ExecuteNonQuery()

                            cmdd.Parameters.Clear()
                            cmdd.CommandText = "INSERT INTO tblproduction (transaction_number,inv_id,item_code,item_name,category,quantity,charge,date,processed_by,type,area,status,remarks) VALUES ('" & trans_num & "','" & lblID.Text & "','" & index("itemcode") & "','" & index("itemname") & "','" & index("category") & "','" & index("quantity") & "','" & index("charge") & "',(SELECT GETDATE()),'" & login2.username & "','Actual Ending Balance', 'Sales', 'Completed',@remarks);"
                            cmdd.Parameters.AddWithValue("@remarks", txtboxremarks.Text)
                            cmdd.ExecuteNonQuery()
                        Next
                        Dim amount As Double = 0.0, price As Double = 0.0
                        Dim names = From row In dt.AsEnumerable()
                                    Select row.Field(Of String)("employee").ToLower Distinct
                        For Each itemz As String In names
                            amount = 0
                            getARNum("AR Charge", "CH")
                            If Not String.IsNullOrEmpty(itemz) Then

                                Dim employeeName = From row In dt.AsEnumerable()
                                                   Select row.Field(Of String)("employee").ToLower Distinct
                                Dim results() As DataRow = dt.Select("employee='" & itemz.ToLower & "'")

                                For Each _res As DataRow In results
                                    Dim totalprice As Double = 0.00
                                    cmdd.Parameters.Clear()
                                    cmdd.CommandText = "SELECT price FROM tblitems WHERE itemname=@itemname AND itemcode=@itemcode AND category=@category"
                                    cmdd.Parameters.AddWithValue("@itemcode", _res("itemcode"))
                                    cmdd.Parameters.AddWithValue("@itemname", _res("itemname"))
                                    cmdd.Parameters.AddWithValue("@category", _res("category"))
                                    rdr = cmdd.ExecuteReader
                                    While rdr.Read
                                        amount += (CInt(_res("charge")) * CDbl(rdr("price")))
                                        totalprice = (CInt(_res("charge")) * CDbl(rdr("price")))
                                        price = CDbl(rdr("price"))
                                    End While
                                    rdr.Close()

                                    cmdd.Parameters.Clear()
                                    cmdd.CommandText = "Insert into tblorder (transnum, category, itemname, qty, price, totalprice, dscnt, free, request, status, discprice, disctrans,area,invnum,type)values('" & ar_number & "','" & _res("category") & "','" & _res("itemname") & "','" & _res("charge") & "','" & price & "','" & totalprice & "','0','0','0','1','0','0','Sales','" & lblID.Text & "','" & "A.R Charge" & "')"
                                    cmdd.ExecuteNonQuery()

                                    cmdd.Parameters.Clear()
                                    cmdd.CommandText = "Insert into tblorder2 (ordernum, category, itemname, qty, price, totalprice, dscnt, free, request, status, discprice, disctrans,area,datecreated)values('" & ordernum & "','" & _res("category") & "','" & _res("itemname") & "','" & _res("charge") & "','" & price & "','" & totalprice & "','0','0','0','1','0','0','Sales','" & DateTime.Now & "')"
                                    cmdd.ExecuteNonQuery()

                                    cmdd.Parameters.Clear()
                                    cmdd.CommandText = "INSERT INTO tblars2 (transnum,description,quantity,price,amount,area,name) VALUES (@tnum, @des,@qua,@price,@am,@area,@name)"
                                    cmdd.Parameters.AddWithValue("@tnum", ar_number)
                                    cmdd.Parameters.AddWithValue("@des", _res("itemname"))
                                    cmdd.Parameters.AddWithValue("@qua", _res("charge"))
                                    cmdd.Parameters.AddWithValue("@price", price)
                                    cmdd.Parameters.AddWithValue("@am", totalprice)
                                    cmdd.Parameters.AddWithValue("@area", "Sales")
                                    cmdd.Parameters.AddWithValue("@name", _res("employee"))
                                    cmdd.ExecuteNonQuery()
                                Next
                                cmdd.Parameters.Clear()
                                cmdd.CommandText = "Insert into tbltransaction (ornum, transnum, transdate, cashier, tendertype, servicetype, delcharge, subtotal, disctype, less, vatsales, vat, amtdue, gctotal, tenderamt, change, refund, comment, remarks, customer, tinnum, tablenum, pax, datecreated, datemodified, status, area, invnum, partialamt,typenum,sap_number,sap_remarks,typez,discamt,salesname) values ('0', '" & ar_number & "', '" & Format(Date.Now, "MM/dd/yyyy") & "','" & login.cashier & "','A.R Charge','N/A','0', '" & amount & "', 'N/A', '0', '0', '0', '" & amount & "', '0', '0', '0', '0', '', '','" & itemz & "' , 'N/A', '0','1', '" & Date.Now & "', '" & Date.Now & "', '1','Sales','" & lblID.Text & "','0','AR','To Follow','','Retail',0,'" & login2.username & "')"
                                cmdd.ExecuteNonQuery()

                                cmdd.Parameters.Clear()
                                cmdd.CommandText = "Insert into tbltransaction2 (ornum, ordernum, transdate, cashier, tendertype, servicetype, delcharge, subtotal, disctype, less, vatsales, vat, amtdue, gctotal, tenderamt, change, refund, comment, remarks, customer, tinnum, tablenum, pax, datecreated, datemodified, status, area,transnum) values ('0', '" & ordernum & "', '" & Format(Date.Now, "MM/dd/yyyy") & "','" & login.cashier & "','A.R Charge','N/A','0', '" & amount & "', 'N/A', '0', '0', '0', '" & amount & "', '0', '0', '0', '0', '', '','" & itemz & "' , 'N/A', '0','1', '" & Date.Now & "', '" & Date.Now & "', '1','Sales','" & ar_number & "')"
                                cmdd.ExecuteNonQuery()

                                cmdd.Parameters.Clear()
                                cmdd.CommandText = "INSERT INTO tblars1 (arnum,transnum,amountdue,name,status,date_created,created_by,area,invnum,type,typenum,sap_no,remarks,_from) VALUES (@arnum,@transnum, @amountdue, @name, @status,(SELECT GETDATE()), @createdby,@area,@invnum,@tayp,@typenum,@sap_no,@remarks,@_from)"
                                cmdd.Parameters.AddWithValue("@arnum", ar_number)
                                cmdd.Parameters.AddWithValue("@transnum", ar_number)
                                cmdd.Parameters.AddWithValue("@amountdue", amount)
                                cmdd.Parameters.AddWithValue("@name", itemz)
                                cmdd.Parameters.AddWithValue("@status", "Unpaid")
                                cmdd.Parameters.AddWithValue("@createdby", login2.username)
                                cmdd.Parameters.AddWithValue("@area", "Sales")
                                cmdd.Parameters.AddWithValue("@invnum", lblID.Text)
                                cmdd.Parameters.AddWithValue("@tayp", "AR Charge")
                                cmdd.Parameters.AddWithValue("@typenum", "AR")
                                cmdd.Parameters.AddWithValue("@sap_no", "To Follow")
                                cmdd.Parameters.AddWithValue("@remarks", "")
                                cmdd.Parameters.AddWithValue("@_from", "Actual Ending Balance")
                                cmdd.ExecuteNonQuery()
                            End If
                        Next
                        transaction.Commit()
                        MessageBox.Show("Transaction Completed", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtboxremarks.Text = ""
                        panelremarks.Visible = False
                        load_items()
                        dgvSelectedItem.Rows.Clear()
                        dgvCount()
                    End Using
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Try
                transaction.Rollback()
            Catch ex2 As Exception
                MessageBox.Show(ex2.ToString)
            End Try
        End Try
    End Sub

    Public Function cash(ByVal typee As String) As Double
        Try
            Dim totalprice As Double = 0.0
            Dim query As String = "Select ISNULL(SUM(tbltransaction.amtdue),0) from tbltransaction JOIN tbltransaction2 On tbltransaction2.transnum = tbltransaction.transnum WHERE tbltransaction.tendertype='" & typee & "' AND tbltransaction.status=1 AND CAST(tbltransaction.datecreated AS date)=(select cast(getdate() as date))"
            con.Open()
            cmd = New SqlCommand(query, con)
            totalprice = cmd.ExecuteScalar
            con.Close()
            totalprice = Math.Abs(totalprice)
            Return totalprice
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Function
    Public Function apcash(ByVal typee As String) As Double
        Try
            Dim totalprice As Double = 0.0
            Dim query As String = "select ISNULL(SUM(tbltransaction.amtdue),0) from tbltransaction WHERE tbltransaction.tendertype='" & typee & "' AND tbltransaction.status=1 AND CAST(tbltransaction.datecreated AS date)=(select cast(getdate() as date))"
            con.Open()
            cmd = New SqlCommand(query, con)
            totalprice = cmd.ExecuteScalar
            con.Close()
            totalprice = Math.Abs(totalprice)
            Return totalprice
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Function
    Public Sub getARNum(ByVal typee As String, ByVal formatsu As String)
        Try
            Dim temp As String = "1", area_format As String = "", selectcount_result As Integer = 0
            con.Open()

            cmd = New SqlCommand("Select COUNT(*)  from tblars1 WHERE area='Sales' AND type=@type;", con)
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


            Dim format As String = "SALAR" & formatsu & " - "
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
        If dgvSelectedItem.Rows.Count = 0 Then
            MessageBox.Show("Please Select item first", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf lblID.Text = "N/A" Then
            MessageBox.Show("Create New Inventory before adding item", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        panelremarks.Visible = True
        txtboxremarks.Text = ""
        txtboxremarks.Focus()
    End Sub

    Private Sub endingbalance_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        'load_items("Select itemcode,itemname,category FROM tblitems WHERE discontinued='0'")
        load_selecteditems()
        categories()
        getID()
        cmbCategoryListItem.SelectedIndex = cmbCategoryListItem.Items.IndexOf("All")
        loadEmployeeNames()
        load_items()
    End Sub

    Public Sub quantity_txt()
        Try
            Dim get_itemname As String = lblQuantityItemName.Text.Replace("Item Name: ", "")
            Dim get_itemcode As String = lblQuantityItemCode.Text.Replace("Item Code: ", "")
            Dim get_category As String = lblQuantityCategory.Text.Replace("Category: ", "")
            Dim endbal As Double = 0.0
            con.Open()
            cmd = New SqlCommand("SELECT endbal FROM tblinvitems WHERE invnum=@invnum AND itemname=@itemname AND itemcode=@itemcode; ", con)
            cmd.Parameters.AddWithValue("@invnum", lblID.Text)
            cmd.Parameters.AddWithValue("@itemname", get_itemname)
            cmd.Parameters.AddWithValue("@itemcode", get_itemcode)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                endbal = CDbl(rdr("endbal"))
            End If
            con.Close()

            If String.IsNullOrEmpty(txtboxQuantity.Text) Then
                lblcharge.Text = "0"
                txtname.Text = ""
                lblcharge.Text = endbal
                Label4.Visible = True
                lblcharge.Visible = True
                Label10.Visible = True
                txtname.Visible = True
            End If

            If endbal <= CDbl(txtboxQuantity.Text) Then
                lblcharge.Text = "0"
                txtname.Text = ""
                Label4.Visible = False
                lblcharge.Visible = False
                Label10.Visible = False
                txtname.Visible = False
            Else
                lblcharge.Text = (endbal - CDbl(txtboxQuantity.Text))
                Label4.Visible = True
                lblcharge.Visible = True
                Label10.Visible = True
                txtname.Visible = True
            End If

        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtboxQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtboxQuantity.TextChanged
        quantity_txt()
    End Sub

    Private Sub endingbalance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_selecteditems()
        categories()
        getID()
        cmbCategoryListItem.SelectedIndex = cmbCategoryListItem.Items.IndexOf("All")
        loadEmployeeNames()
        load_items()
    End Sub

    Private Sub rb1_CheckedChanged(sender As Object, e As EventArgs) Handles rb1.CheckedChanged

        load_items()
    End Sub

    Private Sub rb2_CheckedChanged(sender As Object, e As EventArgs) Handles rb2.CheckedChanged

        load_items()
    End Sub

    Private Sub btnimport_Click(sender As Object, e As EventArgs) Handles btnimport.Click
        Dim frm As New import_actualend()
        frm.ShowDialog()
    End Sub
    Public Sub ok()
        query()
    End Sub
    Private Sub btnok_Click(sender As Object, e As EventArgs) Handles btnok.Click
        ok()
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

    Private Sub txtname_KeyDown(sender As Object, e As KeyEventArgs) Handles txtname.KeyDown
        If e.KeyCode = Keys.Enter Then
            addquantity()
        End If
    End Sub

    Private Sub panelremarks_Paint(sender As Object, e As PaintEventArgs) Handles panelremarks.Paint

    End Sub

    Private Sub txtboxremarks_KeyDown(sender As Object, e As KeyEventArgs) Handles txtboxremarks.KeyDown
        If e.KeyCode = Keys.Enter Then
            ok()
        End If
    End Sub

    Private Sub txtactual_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            ok()
        End If
    End Sub

    Private Sub lblcloseremarks_Click(sender As Object, e As EventArgs) Handles lblcloseremarks.Click
        panelremarks.Visible = False
        txtboxremarks.Text = ""
    End Sub

    Public Sub loadEmployeeNames()
        Try
            Dim auto As New AutoCompleteStringCollection()
            con.Open()
            cmd = New SqlCommand("SELECT name FROM tblcustomers WHERE type=@type", con)
            cmd.Parameters.AddWithValue("@type", "Employee")
            rdr = cmd.ExecuteReader
            While rdr.Read
                auto.Add(rdr("name"))
            End While
            con.Close()
            txtname.AutoCompleteCustomSource = auto
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class