Imports System.Data.SqlClient
Imports System.Text
Imports System.IO
Imports AK_POS.connection_class
Public Class transfer
    Dim cc As New connection_class
    Dim con As New SqlConnection(cc.conString)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim transaction As SqlTransaction
    Dim transid As String = ""
    Dim selectedQuantity As String = ""

    Public lcacc As String = ""

    Public Shared cnfrm As Boolean = False
    Dim lastin As Double, lasttotal As Double, lastpull As Double, lastout As Double, lastend As Double, lastactual As Double, mainBranch As Integer = 0

    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function
    Public Sub lakuXTrans()
        If lcacc = "Production" Then
            GetTransID()
        Else
            If rblakus.Checked Then
                getLakuID()
            Else
                GetTransID()
            End If
        End If
    End Sub
    Private Sub transfer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, rbranches.CheckedChanged, rblakus.CheckedChanged
        dtdate.Text = getSystemDate().ToString("MM/dd/yyyy")
        dtdate.MaxDate = getSystemDate()
        Label6.Visible = IIf(login.wrkgrp = "LC Accounting", True, False)
        dtdate.Visible = IIf(login.wrkgrp = "LC Accounting", True, False)
        getID()
        load_selecteditems()
        categories()
        'GetTransID()
        cmbCategoryListItem.SelectedIndex = cmbCategoryListItem.Items.IndexOf("All")
        If lcacc = "Production" Then
            cmbTransferto.Items.Clear()
            con.Open()
            cmd = New SqlCommand("SELECT branchcode,main FROM tblbranch WHERE main='1';", con)
            rdr = cmd.ExecuteReader()
            While rdr.Read
                cmbTransferto.Items.Add(rdr("branchcode"))
                mainBranch = rdr("main")
            End While
            con.Close()
            'rblakus.Visible = False
            rbranches.Visible = False
            lakuXTrans()
        Else
            'rblakus.Visible = True
            rbranches.Visible = True
            lakuXTrans()
            If rblakus.Checked Then
                cmbTransferto.Items.Clear()
                con.Open()
                cmd = New SqlCommand("SELECT name FROM tblcustomers WHERE type='Laku';", con)
                rdr = cmd.ExecuteReader()
                While rdr.Read
                    cmbTransferto.Items.Add(rdr("name"))
                    mainBranch = 0
                End While
                con.Close()
            Else
                cmbTransferto.Items.Clear()
                con.Open()
                cmd = New SqlCommand("SELECT branchcode,main FROM tblbranch WHERE main=0", con)
                rdr = cmd.ExecuteReader()
                While rdr.Read
                    cmbTransferto.Items.Add(rdr("branchcode"))
                    mainBranch = rdr("main")
                End While
                con.Close()
            End If
        End If
        cmbTransferto.Sorted = True
    End Sub
    Private Sub lblClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClose.Click
        panelQuantity.Visible = False
    End Sub
    Public Sub addquantity2()
        getID()
        Dim get_itemname1 As String = lblQuantityItemName.Text.Replace("Item Name: ", "")
        Dim get_itemcode1 As String = lblQuantityItemCode.Text.Replace("Item Code: ", "")
        Dim getendBal As Double
        con.Open()
        cmd = New SqlCommand("SELECT endbal FROM tblinvitems WHERE itemcode=@itemcode AND itemname=@itemname AND invnum=@invnum AND area='" & lcacc & "'", con)
        cmd.Parameters.AddWithValue("@itemcode", get_itemcode1)
        cmd.Parameters.AddWithValue("@itemname", get_itemname1)
        cmd.Parameters.AddWithValue("@invnum", lblID.Text)
        rdr = cmd.ExecuteReader()
        While rdr.Read()
            getendBal = CDbl(rdr("endbal"))
        End While
        con.Close()
        If getendBal < CDbl(txtboxQuantity.Text) Then
            MessageBox.Show("Insufficient Supply", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        If selectedQuantity = "Add Quantity" Then
            Dim get_itemname As String = lblQuantityItemName.Text.Replace("Item Name: ", "")
            Dim get_itemcode As String = lblQuantityItemCode.Text.Replace("Item Code: ", "")
            Dim get_category As String = lblQuantityCategory.Text.Replace("Category: ", "")
            If checkRowsExist() Then
                Return
            End If
            If String.IsNullOrEmpty(txtboxQuantity.Text) OrElse CInt(txtboxQuantity.Text) = 0 Then
                MessageBox.Show("Quantity is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            ElseIf Not IsNumeric(txtboxQuantity.Text) Then
                MessageBox.Show("Quantity is must be a number", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            Else
                Me.Cursor = Cursors.WaitCursor
                panelQuantity.Visible = False
                dgvSelectedItem.Rows.Add(get_itemcode, get_itemname, get_category, txtboxQuantity.Text, "", "")
                lblQuantityItemCode.Text = "Item Code: N/A"
                lblQuantityItemName.Text = "Item Name: N/A"
                lblQuantityCategory.Text = "Category: N/A"
                Me.Cursor = Cursors.Default
                txtboxQuantity.Text = ""
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
                    dgvSelectedItem.Rows(i).Cells(3).Value = txtboxQuantity.Text
                    txtboxQuantity.Text = ""
                    panelQuantity.Visible = False

                    txtboxListItemSearch.Text = ""
                    search()
                End If
            Next
        End If
    End Sub
    Private Sub btnQuantity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuantity.Click
        addquantity2()
    End Sub
    Public Function checkRowsExist() As Boolean
        Dim get_itemname As String = lblQuantityItemName.Text.Replace("Item Name: ", "")
        Dim get_itemcode As String = lblQuantityItemCode.Text.Replace("Item Code: ", "")
        For i As Integer = 0 To dgvSelectedItem.Rows.Count - 1
            If get_itemcode = dgvSelectedItem.Rows(i).Cells(0).Value And get_itemname = dgvSelectedItem.Rows(i).Cells(1).Value Then
                Dim quantity_add As Integer = CInt(dgvSelectedItem.Rows(i).Cells(3).Value) + CInt(txtboxQuantity.Text)
                dgvSelectedItem.Rows(i).Cells(3).Value = quantity_add
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
        Try
            dgvListItem.Rows.Clear()

            query &= " AND a.status=1  ORDER BY b.itemcode"


            Dim auto As New AutoCompleteStringCollection()
            con.Open()
            cmd = New SqlCommand(query, con)
            TextBox1.Text = query
            rdr = cmd.ExecuteReader()
            While rdr.Read()
                dgvListItem.Rows.Add(rdr("itemcode").ToString(), rdr("itemname").ToString(), rdr("category").ToString(), "")
                auto.Add(rdr("itemcode"))
                auto.Add(rdr("itemname"))
            End While
            con.Close()
            txtboxListItemSearch.AutoCompleteCustomSource = auto
            dgvCount()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
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
            Dim q As String = ""
            cmbCategoryListItem.Items.Clear()

            If lcacc = "Production" Then
                q = "SELECT category FROM tblcat WHERE status='1' AND Not category='Noodles' AND Not category='Packaging' AND not category='Drinks' AND NOT category='Meal' AND NOT category='Combo'"
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
    Public Sub getID()
        Dim id As String = ""
        Dim date_ As New DateTime()
        con.Open()
        cmd = New SqlCommand("Select TOP 1 invnum,datecreated from tblinvsum WHERE area='" & lcacc & "' " & IIf(login.wrkgrp = "LC Accounting", " AND CAST(datecreated AS date)='" & dtdate.Text & "'", "") & " order by invsumid DESC", con)
        rdr = cmd.ExecuteReader()
        If rdr.Read() Then
            id = rdr("invnum")
            date_ = CDate(rdr("datecreated"))
        End If
        con.Close()
        lblID.Text = id
    End Sub
    Public Function getSystemDate() As DateTime
        Try
            Dim dt As New DateTime()
            con.Open()
            cmd = New SqlCommand("Select GETDATE()", con)
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
    Public Sub addquantity()
        Dim c As Boolean = False
        con.Open()
        cmd = New SqlCommand("Select invid FROM tblinvitems WHERE itemname=@inamee And itemcode=@icodee And invnum=@inv And area='" & lcacc & "' AND tblinvitems.begbal =0 AND tblinvitems.produce =0 AND tblinvitems.good = 0 AND tblinvitems.reject = 0 AND tblinvitems.charge = 0 AND tblinvitems.productionin = 0 AND tblinvitems.itemin = 0 AND tblinvitems.supin = 0 AND tblinvitems.totalav = 0 AND tblinvitems.transfer = 0 AND tblinvitems.ctrout = 0 AND tblinvitems.arreject = 0 AND tblinvitems.archarge =0 AND tblinvitems.arsales = 0 AND tblinvitems.convout = 0 AND tblinvitems.pullout = 0 AND tblinvitems.endbal = 0 AND tblinvitems.actualendbal =0 AND tblinvitems.variance = 0;", con)
        cmd.Parameters.AddWithValue("@inamee", dgvListItem.CurrentRow.Cells(1).Value.ToString)
        cmd.Parameters.AddWithValue("@icodee", dgvListItem.CurrentRow.Cells(0).Value.ToString)
        cmd.Parameters.AddWithValue("@inv", lblID.Text)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            c = True
        End If
        con.Close()
        If c Then
            MessageBox.Show("This item has 0 stock", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If


        lblQuantityItemCode.Text = "Item Code: " & dgvListItem.CurrentRow.Cells(0).Value.ToString
        lblQuantityItemName.Text = "Item Name: " & dgvListItem.CurrentRow.Cells(1).Value.ToString
        lblQuantityCategory.Text = "Category: " & dgvListItem.CurrentRow.Cells(2).Value.ToString
        panelQuantity.Visible = True
        panelQuantity.BringToFront()
        selectedQuantity = "Add Quantity"
        txtboxQuantity.Focus()
    End Sub
    Private Sub dgvListItem_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListItem.CellContentClick
        If e.ColumnIndex = 3 Then
            addquantity()
        End If
    End Sub
    Public Sub search()
        Try
            If Not String.IsNullOrEmpty(txtboxListItemSearch.Text) Then
                dgvListItem.Rows.Clear()
                con.Open()
                cmd = New SqlCommand("SELECT tblinvitems.itemcode,tblinvitems.itemname,tblitems.category,tblinvitems.endbal FROM tblitems JOIN tblinvitems ON tblitems.itemcode = tblinvitems.itemcode AND tblitems.itemname = tblinvitems.itemname  WHERE tblitems.discontinued='0'  and Not tblitems.category='Noodles' AND Not tblitems.category='Packaging' AND not tblitems.category='Drinks' AND NOT tblitems.category='Meal' AND NOT tblitems.category='Combo' AND tblinvitems.area='" & lcacc & "' AND invnum='" & lblID.Text & "' AND  tblinvitems.itemname LIKE @name AND tblinvitems.endbal !=0", con)
                cmd.Parameters.AddWithValue("@name", "%" & txtboxListItemSearch.Text & "%")
                rdr = cmd.ExecuteReader()
                While rdr.Read
                    dgvListItem.Rows.Add(rdr("itemcode"), rdr("itemname"), rdr("category"))
                End While
                con.Close()

                If dgvListItem.RowCount <> 0 Then
                    addquantity()

                    txtboxListItemSearch.Text = ""
                    loadd()
                End If

            Else
                loadd()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
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
        If e.ColumnIndex = 4 Then
            lblQuantityItemCode.Text = "Item Code: " & dgvSelectedItem.CurrentRow.Cells(0).Value.ToString
            lblQuantityItemName.Text = "Item Name: " & dgvSelectedItem.CurrentRow.Cells(1).Value.ToString
            panelQuantity.Visible = True
            panelQuantity.BringToFront()
            selectedQuantity = "Update Quantity"
            txtboxQuantity.Text = dgvSelectedItem.CurrentRow.Cells(3).Value
            txtboxQuantity.Focus()
        ElseIf e.ColumnIndex = 5 Then
            Dim a As String = MsgBox("Are you sure you want to delete?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "")
            If a = vbYes Then
                dgvSelectedItem.Rows.RemoveAt(e.RowIndex)
            End If
        End If
    End Sub
    Public Sub search2()
        con.Open()
        cmd = New SqlCommand("SELECT itemcode,itemname FROM tblitems WHERE  itemname=@name", con)
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

    Private Sub cmbCategoryListItem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCategoryListItem.SelectedIndexChanged
        getID()
        loadd()
    End Sub
    Public Sub loadd()
        If cmbCategoryListItem.Text = "All" Then
            load_items("SELECT a.itemcode,a.itemname,b.category FROM tblinvitems a INNER JOIN tblitems b ON a.itemname = b.itemname WHERE a.invnum='" & lblID.Text & "' AND a.endbal !=0")
        Else
            load_items("SELECT a.itemcode,a.itemname,b.category FROM tblinvitems a INNER JOIN tblitems b ON a.itemname = b.itemname WHERE a.invnum='" & lblID.Text & "' AND a.endbal !=0 AND b.category='" & cmbCategoryListItem.Text & "'")
        End If
    End Sub
    Public Sub query()
        Dim a As String = MsgBox("Are you sure you want to transfer item?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MessageBoxDefaultButton.Button2, "")
        If a = vbYes Then
            PanelProduction.Visible = True
            txtboxRemarks.Focus()
        End If
    End Sub
    Public Function checkCutOff() As Boolean
        Try
            Dim status As String = "", date_from As New DateTime()
            con.Open()
            cmd = New SqlCommand("SELECT status,date FROM tblcutoff WHERE userid=(SELECT systemid FROM tblusers WHERE username=@username) ORDER BY cid DESC;", con)
            cmd.Parameters.AddWithValue("@username", login.username)
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
    Private Sub btnProceed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProceed.Click
        If checkCutOff() Then
            MessageBox.Show("Your account is already cut off", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If String.IsNullOrEmpty(Trim(txtboxSAPNo.Text)) And checkfollowup.Checked = False And rbranches.Checked Then
            MessageBox.Show("SAP # is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf txtboxSAPNo.TextLength <= 5 And checkfollowup.Checked = False And rbranches.Checked Then
            MessageBox.Show("# must be at least 6 numbers", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf String.IsNullOrEmpty(Trim(txtboxRemarks.Text)) Then
            MessageBox.Show("Remarks is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim sap_number As String = txtboxSAPNo.Text
        Dim remarks As String = txtboxRemarks.Text
        getID()
        GetTransID()
        If lblID.Text = "" Then
            MessageBox.Show("No Inventory found", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        confirm.ShowDialog()
        If cnfrm = False Then
            Exit Sub
        End If
        Try
            Dim mahBranch As String = ""
            con.Open()
            cmd = New SqlCommand("SELECT branchcode FROM tblbranch WHERE main='1';", con)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                mahBranch = rdr("branchcode")
            End If
            con.Close()
            Dim fromBranch As String = "", toBranch As String = ""
            If mahBranch = cmbTransferto.Text Then
                If lcacc = "Production" Then
                    fromBranch = mahBranch & "(SLS)"
                    toBranch = mahBranch & "(PRD)"
                ElseIf lcacc = "Sales" Then
                    fromBranch = mahBranch & "(PRD)"
                    toBranch = mahBranch & "(SLS)"
                End If
            Else
                fromBranch = cmbTransferto.Text
                toBranch = mahBranch
            End If
            Using connection As New SqlConnection(cc.conString)
                Dim cmdd As New SqlCommand()
                cmdd.Connection = connection
                connection.Open()
                transaction = connection.BeginTransaction()
                cmdd.Transaction = transaction
                For Each r0w As DataGridViewRow In dgvSelectedItem.Rows
                    cmdd.Parameters.Clear()
                    cmdd.CommandText = "Update tblinvitems set transfer+='" & CDbl(dgvSelectedItem.Rows(r0w.Index).Cells("quantityy").Value) & "', endbal-='" & CDbl(dgvSelectedItem.Rows(r0w.Index).Cells("quantityy").Value) & "', variance+='" & CDbl(dgvSelectedItem.Rows(r0w.Index).Cells("quantityy").Value) & "' where invnum='" & lblID.Text & "' AND area='" & lcacc & "' AND itemname='" & dgvSelectedItem.Rows(r0w.Index).Cells("itemnamee").Value & "';"
                    cmdd.ExecuteNonQuery()

                    cmdd.Parameters.Clear()
                    cmdd.CommandText = "INSERT INTO tblproduction (transaction_number,inv_id,item_code,item_name,category,quantity,sap_number,remarks,date,processed_by,type,transfer_to,transfer_from,status,area,from_transnum,reject,charge,typenum,type2) VALUES (@trans_id,@id, @code,@name,@cat,@qty,@sap,@remarks,(SELECT GETDATE()),@processed_by,@type,@transfer_to,@transfer_from,@status,@area,@from_transnum,@reject,@charge,@typenum,@type2)"
                    cmdd.Parameters.AddWithValue("@trans_id", lblTransactionID.Text)
                    cmdd.Parameters.AddWithValue("@id", lblID.Text)
                    cmdd.Parameters.AddWithValue("@code", dgvSelectedItem.Rows(r0w.Index).Cells("itemcodee").Value)
                    cmdd.Parameters.AddWithValue("@name", dgvSelectedItem.Rows(r0w.Index).Cells("itemnamee").Value)
                    cmdd.Parameters.AddWithValue("@cat", dgvSelectedItem.Rows(r0w.Index).Cells("categoryy").Value)
                    cmdd.Parameters.AddWithValue("@qty", CDbl(dgvSelectedItem.Rows(r0w.Index).Cells("quantityy").Value))
                    If checkfollowup.Checked = True Then
                        sap_number = "To Follow"
                    End If
                    cmdd.Parameters.AddWithValue("@sap", sap_number)
                    cmdd.Parameters.AddWithValue("@remarks", remarks)
                    cmdd.Parameters.AddWithValue("@processed_by", login.username)
                    cmdd.Parameters.AddWithValue("@type", "Transfer Item")
                    cmdd.Parameters.AddWithValue("@transfer_to", fromBranch)
                    cmdd.Parameters.AddWithValue("@transfer_from", toBranch)
                    cmdd.Parameters.AddWithValue("@status", "Completed")
                    cmdd.Parameters.AddWithValue("@area", lcacc)
                    cmdd.Parameters.AddWithValue("@from_transnum", txttransnum.Text)
                    cmdd.Parameters.AddWithValue("@reject", "0")
                    cmdd.Parameters.AddWithValue("@charge", "0")
                    cmdd.Parameters.AddWithValue("@typenum", lbltype.Text)
                    cmdd.Parameters.AddWithValue("@type2", "Transfer")
                    cmdd.ExecuteNonQuery()
                Next
                transaction.Commit()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Try
                transaction.Rollback()
            Catch ex2 As Exception
                MessageBox.Show(ex2.ToString)
            End Try
        End Try
        Dim frm As New show_trans()
        frm.lbltr.Text = lblTransactionID.Text
        frm.ShowDialog()

        dgvSelectedItem.Rows.Clear()
        MessageBox.Show("Added", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        loadd()
        lakuXTrans()
        txtboxRemarks.Text = ""
        txtboxSAPNo.Text = ""
        PanelProduction.Visible = False
        dgvCount()
        'GetTransID()
    End Sub


    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If dgvSelectedItem.Rows.Count = 0 Then
            MessageBox.Show("Please select item first", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf cmbTransferto.Text = "" Then
            MessageBox.Show("Please select branch first", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf lblID.Text = "N/A" Then
            MessageBox.Show("Create New Inventory before transfer item", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        query()
    End Sub
    Public Function removeVowels(ByVal workgrp As String) As String
        Dim result = New StringBuilder
        For Each c In workgrp
            If Not "aeiou".Contains(c.ToString.ToLower) Then
                result.Append(c)
            End If
        Next
        Return result.ToString
    End Function
    Public Sub GetTransID()
        Try
            Dim selectcount_result As Integer = 0
            Dim get_area As String = "", temp As String = "0"
            Dim area_format As String = ""
            con.Open()
            cmd = New SqlCommand("Select ISNULL(MAX(transaction_id),0) transaction_number  from tblproduction WHERE area='" & lcacc & "' AND type='Transfer Item' AND type2='Transfer';", con)
            selectcount_result = cmd.ExecuteScalar + 1
            con.Close()
            Dim branchcode As String = ""
            con.Open()
            cmd = New SqlCommand("SELECT branchcode FROM tblbranch WHERE main='1';", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                branchcode = rdr("branchcode")
            End While
            con.Close()

            If rblakus.Checked Then
                area_format = "LAKU - " & branchcode & " - "
            Else
                area_format = "TRA - " & branchcode & " - "
            End If

            If selectcount_result < 1000000 Then
                Dim cselectcount_result As String = CStr(selectcount_result)
                For vv As Integer = 1 To 6 - cselectcount_result.Length
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

    Private Sub cmbTransferto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTransferto.SelectedIndexChanged

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
            addquantity2()
        End If
    End Sub

    Private Sub dtdate_ValueChanged(sender As Object, e As EventArgs) Handles dtdate.ValueChanged
        getID()
        loadd()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Public Sub getLakuID()
        Try
            Dim selectcount_result As Integer = 0
            Dim get_area As String = "", temp As String = "0"
            Dim area_format As String = ""
            con.Open()
            cmd = New SqlCommand("Select COUNT(*) transnum from tblakutrans", con)
            selectcount_result = cmd.ExecuteScalar() + 1
            con.Close()
            Dim branchcode As String = ""
            con.Open()
            cmd = New SqlCommand("SELECT branchcode FROM tblbranch WHERE main='1';", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                branchcode = rdr("branchcode")
            End While
            con.Close()

            area_format = "LAKU - " & branchcode & " - "

            If selectcount_result < 1000000 Then
                Dim cselectcount_result As String = CStr(selectcount_result)
                For vv As Integer = 1 To 6 - cselectcount_result.Length
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
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lblDateNow.Text = "Date: " & getSystemDate.ToString("MM/dd/yyyy hh:mm tt")
    End Sub

    Private Sub lblProductionClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblProductionClose.Click
        PanelProduction.Visible = False
        txtboxRemarks.Text = ""
        txtboxSAPNo.Text = ""
    End Sub
    Private Sub transfer_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        loadd()
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub cmbTransferto_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTransferto.SelectedValueChanged
        lakuXTrans()
    End Sub

    Private Sub checkfollowup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkfollowup.CheckedChanged
        If checkfollowup.Checked Then
            txtboxSAPNo.Text = ""
            txtboxSAPNo.Enabled = False
        Else
            txtboxSAPNo.Enabled = True
        End If
    End Sub
End Class