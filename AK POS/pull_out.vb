Imports System.Data.SqlClient
Imports System.IO
Imports AK_POS.connection_class
Public Class pull_out
    Dim cc As New connection_class
    Dim con As New SqlConnection(cc.conString)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim transaction As SqlTransaction
    Public lcacc As String = ""
    Dim selectedQuantity As String = ""
    Dim lastin As Double, lasttotal As Double, lastpull As Double, lastout As Double, lastend As Double, lastactual As Double, rems As String

    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function

    Private Sub pull_out_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtdate.Value = getSystemDate()
        dtdate.MaxDate = getSystemDate()
        load_selecteditems()
        categories()
        getID()
        GetTransID()
        cmbCategoryListItem.SelectedIndex = cmbCategoryListItem.Items.IndexOf("All")
    End Sub

    Private Sub lblClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClose.Click
        panelQuantity.Visible = False
    End Sub
    Public Sub addoredit()
        Try
            Dim get_itemname1 As String = lblQuantityItemName.Text.Replace("Item Name: ", "")
            Dim get_itemcode1 As String = lblQuantityItemCode.Text.Replace("Item Code: ", "")
            Dim cun As Integer = 0
            Dim getendBal As Double
            con.Open()
            cmd = New SqlCommand("SELECT endbal FROM tblinvitems WHERE itemcode=@itemcode AND itemname=@itemname AND invnum=@invnum", con)
            cmd.Parameters.AddWithValue("@itemcode", get_itemcode1)
            cmd.Parameters.AddWithValue("@itemname", get_itemname1)
            cmd.Parameters.AddWithValue("@invnum", lblID.Text)
            rdr = cmd.ExecuteReader()
            While rdr.Read()
                cun = 1
                getendBal = rdr("endbal")
            End While
            con.Close()
            If cun = 1 And getendBal < Val(txtboxQuantity.Text) Then
                MessageBox.Show("Insufficient quantity", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub btnQuantity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuantity.Click
        addoredit()
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
        dgvListItem.Rows.Clear()
        Dim auto As New AutoCompleteStringCollection()
        con.Open()
        cmd = New SqlCommand(query, con)
        rdr = cmd.ExecuteReader()
        While rdr.Read()
            dgvListItem.Rows.Add(rdr("itemcode").ToString(), rdr("itemname").ToString(), rdr("category").ToString(), "")
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
        cmd = New SqlCommand("Select TOP 1 a.invnum,a.datecreated from tblinvsum a WHERE a.area='" & lcacc & "' AND CAST(a.datecreated AS date)='" & dtdate.Text & "' ORDER BY a.invsumid DESC", con)
        rdr = cmd.ExecuteReader()
        If rdr.Read() Then
            id = rdr("invnum")
        End If
        con.Close()
        lblID.Text = id
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
    Public Sub GetTransID()
        Try
            Dim selectcount_result As Integer = 0
            Dim get_area As String = "", temp As String = "1"
            Dim area_format As String = ""
            con.Open()
            cmd = New SqlCommand("Select ISNULL(COUNT(transaction_id),0)+1  from tblproduction WHERE area='" & lcacc & "' AND type='Adjustment Out Item' AND type2='Adjustment Out';", con)
            selectcount_result = cmd.ExecuteScalar
            con.Close()

            Dim branchcode As String = ""
            con.Open()
            cmd = New SqlCommand("SELECT branchcode FROM tblbranch WHERE main='1';", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                branchcode = rdr("branchcode")
            End While
            con.Close()

            If lcacc = "Sales" Then
                area_format = "ADJOUT - " & branchcode & " - "
            Else
                area_format = "PRODADJOUT - " & branchcode & " - "
            End If

            If selectcount_result < 1000000 Then
                Dim cselectcount_result As String = CStr(selectcount_result)
                For vv As Integer = 1 To 6 - cselectcount_result.Length
                    temp += "0"
                Next
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
    Public Sub addquantity()
        Try
            Dim c As Boolean = False
            If con.State = ConnectionState.Closed Then
                con.Open()
            Else
                con.Close()
            End If
            cmd = New SqlCommand("SELECT invid FROM tblinvitems WHERE itemname=@inamee AND itemcode=@icodee AND invnum=@inv AND area='" & lcacc & "' AND tblinvitems.begbal =0 AND tblinvitems.produce =0 AND tblinvitems.good = 0 AND tblinvitems.reject = 0 AND tblinvitems.charge = 0 AND tblinvitems.productionin = 0 AND tblinvitems.itemin = 0 AND tblinvitems.supin = 0 AND tblinvitems.totalav = 0 AND tblinvitems.transfer = 0 AND tblinvitems.ctrout = 0 AND tblinvitems.arreject = 0 AND tblinvitems.archarge =0 AND tblinvitems.arsales = 0 AND tblinvitems.convout = 0 AND tblinvitems.pullout = 0 AND tblinvitems.endbal = 0 AND tblinvitems.actualendbal =0 AND tblinvitems.variance = 0;", con)
            cmd.Parameters.AddWithValue("@inamee", dgvListItem.CurrentRow.Cells(1).Value.ToString)
            cmd.Parameters.AddWithValue("@icodee", dgvListItem.CurrentRow.Cells(0).Value.ToString)
            cmd.Parameters.AddWithValue("@inv", lblID.Text)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                c = True
            End If
            If con.State = ConnectionState.Closed Then
                con.Open()
            Else
                con.Close()
            End If
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
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub dgvListItem_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListItem.CellContentClick
        If e.ColumnIndex = 3 Then
            addquantity()
        End If
    End Sub

    Private Sub btnSearchListItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchListItem.Click
        Dim itemname As String = ""
        con.Open()
        cmd = New SqlCommand("SELECT itemname FROM tblitems WHERE itemname=@name", con)
        cmd.Parameters.AddWithValue("@name", txtboxListItemSearch.Text)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            itemname = rdr("itemname")
        End If
        con.Close()
        For i As Integer = 0 To dgvListItem.Rows.Count - 1
            If dgvListItem.Rows(i).Cells(1).Value = itemname Then
                dgvListItem.Rows(i).Selected = True
                dgvListItem.CurrentCell = dgvListItem.Rows(i).Cells(1)
                addquantity()
            Else
                dgvListItem.Rows(i).Selected = False
            End If
        Next

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
        ElseIf e.ColumnIndex = 5 Then
            Dim a As String = MsgBox("Are you sure you want to delete?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "")
            If a = vbYes Then
                dgvSelectedItem.Rows.RemoveAt(e.RowIndex)
            End If
        End If
    End Sub
    Public Sub proceed()
        If String.IsNullOrEmpty(txtremarks.Text) Then
            MessageBox.Show("Remarks is empty", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim a As String = MsgBox("Are you sure you want to proceed?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "")
        If a = vbYes Then

            Dim err As String = "", endbal As Double = 0.00
            For index As Integer = 0 To dgvSelectedItem.RowCount - 1
                con.Open()
                cmd = New SqlCommand("SELECT endbal FROM tblinvitems WHERE itemcode=@itemcode AND itemname=@itemname AND invnum=@invnum AND area='" & lcacc & "'", con)
                cmd.Parameters.AddWithValue("@itemcode", dgvSelectedItem.Rows(index).Cells("itemcodee").Value)
                cmd.Parameters.AddWithValue("@itemname", dgvSelectedItem.Rows(index).Cells("itemnamee").Value)
                cmd.Parameters.AddWithValue("@invnum", lblID.Text)
                rdr = cmd.ExecuteReader()
                If rdr.Read Then
                    endbal = CDbl(rdr("endbal"))
                End If
                con.Close()
                If endbal < CDbl(dgvSelectedItem.Rows(index).Cells("quantityy").Value) Then
                    err &= dgvSelectedItem.Rows(index).Cells("itemnamee").Value & "(" & endbal & ")" & Environment.NewLine
                End If
            Next

            If err <> "" Then
                MessageBox.Show("Below Item is insufficient stock" & Environment.NewLine & err, "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            Try
                Using connection As New SqlConnection(cc.conString)
                    Dim command As New SqlCommand()
                    command.Connection = connection
                    connection.Open()
                    transaction = connection.BeginTransaction()
                    command.Transaction = transaction

                    For Each r0w As DataGridViewRow In dgvSelectedItem.Rows
                        command.CommandText = "Update tblinvitems set pullout+=@quantity, endbal-=@quantity, variance+=@quantity where invnum=(SELECT invnum FROM tblinvsum WHERE CAST(datecreated AS date)='" & dtdate.Text & "') AND area='Sales';"
                        command.Parameters.AddWithValue("@quantity", dgvSelectedItem.Rows(r0w.Index).Cells("quantityy").Value)
                        command.ExecuteNonQuery()

                        command.CommandText = "INSERT INTO tblproduction (transaction_number,inv_id,item_code,item_name,category,quantity,date,processed_by,type,status,area,reject,charge,typenum,type2,remarks) VALUES (@trans_id,@id, @code,@name,@cat,@qty,(SELECT GETDATE()),@processed_by,@type,@status,@area,@reject,@charge,@typenum,@type2,@remarks)"
                        command.Parameters.AddWithValue("@trans_id", lblTransactionID.Text)
                        command.Parameters.AddWithValue("@id", lblID.Text)
                        command.Parameters.AddWithValue("@code", dgvSelectedItem.Rows(r0w.Index).Cells("itemcodee").Value)
                        command.Parameters.AddWithValue("@name", dgvSelectedItem.Rows(r0w.Index).Cells("itemnamee").Value)
                        command.Parameters.AddWithValue("@cat", dgvSelectedItem.Rows(r0w.Index).Cells("categoryy").Value)
                        command.Parameters.AddWithValue("@qty", dgvSelectedItem.Rows(r0w.Index).Cells("quantityy").Value)
                        command.Parameters.AddWithValue("@sap", "")
                        command.Parameters.AddWithValue("@remarks", txtremarks.Text)
                        command.Parameters.AddWithValue("@processed_by", login2.username)
                        command.Parameters.AddWithValue("@type", "Adjustment Out Item")
                        command.Parameters.AddWithValue("@status", "Completed")
                        command.Parameters.AddWithValue("@area", "Sales")
                        command.Parameters.AddWithValue("@reject", "0")
                        command.Parameters.AddWithValue("@charge", "0")
                        command.Parameters.AddWithValue("@typenum", "")
                        command.Parameters.AddWithValue("@type2", "Adjustment Out")
                        command.ExecuteNonQuery()
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
        End If
        MessageBox.Show("Added", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        panelRemarks.Visible = False
        txtremarks.Text = ""
        dgvSelectedItem.Rows.Clear()
        dgvCount()
        GetTransID()
        loadd()
    End Sub
    Private Sub btnproceed_Click(sender As Object, e As EventArgs) Handles btnproceed.Click
        proceed()
    End Sub

    Private Sub txtboxListItemSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtboxListItemSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            addquantity()
        End If
    End Sub

    Private Sub panelQuantity_Paint(sender As Object, e As PaintEventArgs) Handles panelQuantity.Paint

    End Sub

    Private Sub txtboxQuantity_KeyDown(sender As Object, e As KeyEventArgs) Handles txtboxQuantity.KeyDown
        If e.KeyCode = Keys.Enter Then
            addoredit()
        End If
    End Sub

    Private Sub txtremarks_KeyDown(sender As Object, e As KeyEventArgs) Handles txtremarks.KeyDown
        If e.KeyCode = Keys.Enter Then
            proceed()
        End If
    End Sub

    Private Sub dtdate_ValueChanged(sender As Object, e As EventArgs) Handles dtdate.ValueChanged
        getID()
        loadd()
    End Sub

    Private Sub lblremarksclose_Click(sender As Object, e As EventArgs) Handles lblremarksclose.Click
        panelRemarks.Visible = False
        txtremarks.Text = ""
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
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
    Public Sub loadd()
        If lcacc = "Production" And cmbCategoryListItem.Text = "All" Then
            load_items("SELECT tblinvitems.itemcode,tblinvitems.itemname,tblitems.category,tblinvitems.endbal FROM tblitems JOIN tblinvitems ON tblitems.itemcode = tblinvitems.itemcode AND tblitems.itemname = tblinvitems.itemname  WHERE tblitems.discontinued='0'  AND tblinvitems.endbal != 0 AND tblinvitems.area='" & "Production" & "' AND invnum='" & lblID.Text & "'")
        ElseIf lcacc = "Sales" And cmbCategoryListItem.Text = "All" Then
            load_items("SELECT tblinvitems.itemcode,tblinvitems.itemname,tblitems.category,tblinvitems.endbal FROM tblitems JOIN tblinvitems ON tblitems.itemcode = tblinvitems.itemcode AND tblitems.itemname = tblinvitems.itemname  WHERE tblitems.discontinued='0'   AND tblinvitems.area='" & "Sales" & "' AND tblinvitems.endbal != 0 AND invnum='" & lblID.Text & "'")
        ElseIf lcacc = "Production" And cmbCategoryListItem.Text <> "All" Then
            load_items("SELECT tblinvitems.itemcode,tblinvitems.itemname,tblitems.category,tblinvitems.endbal FROM tblitems JOIN tblinvitems ON tblitems.itemcode = tblinvitems.itemcode AND tblitems.itemname = tblinvitems.itemname  WHERE tblitems.discontinued='0'  AND tblinvitems.endbal != 0 AND tblinvitems.area='" & lcacc & "' AND tblitems.category='" & cmbCategoryListItem.Text & "' AND invnum='" & lblID.Text & "'")
        ElseIf lcacc = "Sales" And cmbCategoryListItem.Text <> "All" Then
            load_items("SELECT tblinvitems.itemcode,tblinvitems.itemname,tblitems.category,tblinvitems.endbal FROM tblitems JOIN tblinvitems ON tblitems.itemcode = tblinvitems.itemcode AND tblitems.itemname = tblinvitems.itemname  WHERE tblitems.discontinued='0'  AND tblinvitems.area='" & lcacc & "' AND tblitems.category='" & cmbCategoryListItem.Text & "' AND invnum='" & lblID.Text & "' AND tblinvitems.endbal != 0")
        End If
    End Sub

    Private Sub cmbCategoryListItem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCategoryListItem.SelectedIndexChanged
        loadd()
    End Sub
    Public Sub query()
        Dim a As String = MsgBox("Are you sure you want to proceed?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MessageBoxDefaultButton.Button2, "")
        If a = vbYes Then
            panelRemarks.Visible = True
            txtremarks.Text = ""
            txtremarks.Focus()
        End If
    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If dgvSelectedItem.Rows.Count = 0 Then
            MessageBox.Show("Please select item first", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf lblID.Text = "N/A" Then
            MessageBox.Show("Create New Inventory before pull out item", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        query()
    End Sub
End Class