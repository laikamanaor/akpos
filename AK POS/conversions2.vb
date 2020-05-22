Imports System.Data.SqlClient
Imports System.IO
Imports AK_POS.connection_class
Imports AK_POS.received_class
Public Class conversions2
    Dim cc As New connection_class(), recc As New received_class()
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Dim strconn As String = cc.conString
    Dim con As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim transaction As SqlTransaction

    Dim conv_number As String = ""

    Private Sub conversions2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_convesions()
        loadCategories()
        cmbCategoryListItem.SelectedIndex = cmbCategoryListItem.Items.IndexOf("All")
    End Sub

    Public Sub load_convesions()
        Dim result As New DataTable()
        result = recc.loadPendingConvOut()
        dgvConversions.Rows.Clear()
        For Each r0w As DataRow In result.Rows
            dgvConversions.Rows.Add(r0w("conv_number"))
        Next
    End Sub
    Public Sub dgvCount()
        lblListItemCount.Text = CStr(dgvListItem.Rows.Count)
        lblSelectedItemCount.Text = CStr(dgvSelectedItem.Rows.Count)
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
    Private Sub dgvListItem_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListItem.CellContentClick
        If dgvListItem.Rows.Count <> 0 Then
            If e.ColumnIndex = 3 Then
                addQty()
            End If
        End If
    End Sub

    Private Sub btnSearchListItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchListItem.Click
        'loop dgv items
        For i As Integer = 0 To dgvListItem.Rows.Count - 1
            'check if row is equal to search bar
            If dgvListItem.Rows(i).Cells("itemname").Value.ToString.ToLower = txtboxListItemSearch.Text.ToLower Then
                'assign row to be selected
                dgvListItem.Rows(i).Selected = True
                dgvListItem.CurrentCell = dgvListItem.Rows(i).Cells("itemname")
            Else
                'assign row to be unselected if row and search it not match
                dgvListItem.Rows(i).Selected = False
            End If
        Next

        If dgvListItem.RowCount <> 0 And Not String.IsNullOrEmpty(txtboxListItemSearch.Text) Then
            addQty()
        End If
    End Sub
    Public Sub addQty()

        Dim checkError As Integer = 0
        For index As Integer = 0 To dgvSelectedItem.RowCount - 1
            If dgvSelectedItem.Rows(index).Cells("itemnamee").Value.ToString.ToLower = dgvListItem.CurrentRow.Cells("itemname").Value.ToString.ToLower Then
                checkError += 1
            End If
        Next

        Dim count As Integer = 0
        For index As Integer = 0 To dgvitems.RowCount - 1
            If dgvitems.Rows(index).Cells("item_name").Value.ToString.ToLower = dgvListItem.CurrentRow.Cells("itemname").Value.ToString.ToLower Then
                count += 1
            End If
        Next

        If checkError > 0 Then
            MessageBox.Show("'" & dgvListItem.CurrentRow.Cells("itemname").Value & "' has already exist in Selected Item", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf count > 0 Then
            MessageBox.Show("Can't convert to same item", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf lblConvID.Text = "N/A" Then
            MessageBox.Show("Pick Conversion Out first", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            receivedItem_add.txtitemcode.Text = dgvListItem.CurrentRow.Cells("itemcode").Value
            receivedItem_add.txtitemname.Text = dgvListItem.CurrentRow.Cells("itemname").Value
            receivedItem_add.txtcategory.Text = dgvListItem.CurrentRow.Cells("categoory").Value
            receivedItem_add.txtquantity.Text = 0
            receivedItem_add.lblheader.Text = "ADD QUANTITY"
            receivedItem_add.txtquantity.Focus()
            receivedItem_add.ShowDialog()
            If receivedItem_add.isSuccess Then
                Dim itemname As String = "", itemcode As String = "", category As String = "", quantity As Double = 0.00
                itemname = receivedItem_add.txtitemname.Text
                itemcode = receivedItem_add.txtitemcode.Text
                category = receivedItem_add.txtcategory.Text
                quantity = receivedItem_add.txtquantity.Text
                receivedItem_add.txtquantity.Focus()
                dgvSelectedItem.Rows.Add(itemcode, itemname, category, quantity)
            End If
        End If
    End Sub
    Public Sub updateQty()
        receivedItem_add.txtitemcode.Text = dgvSelectedItem.CurrentRow.Cells("itemcodee").Value
        receivedItem_add.txtitemname.Text = dgvSelectedItem.CurrentRow.Cells("itemnamee").Value
        receivedItem_add.txtcategory.Text = dgvSelectedItem.CurrentRow.Cells("categoryy").Value
        receivedItem_add.txtquantity.Text = 0
        receivedItem_add.lblheader.Text = "EDIT QUANTITY"
        receivedItem_add.txtquantity.Focus()
        receivedItem_add.ShowDialog()
        If receivedItem_add.isSuccess Then
            Dim itemname As String = "", itemcode As String = "", category As String = "", quantity As Double = 0.00
            itemname = receivedItem_add.txtitemname.Text
            itemcode = receivedItem_add.txtitemcode.Text
            category = receivedItem_add.txtcategory.Text
            quantity = receivedItem_add.txtquantity.Text
            receivedItem_add.txtquantity.Focus()
            dgvSelectedItem.CurrentRow.Cells("quantityy").Value = quantity
        End If
    End Sub

    Private Sub dgvSelectedItem_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSelectedItem.CellContentClick
        If dgvSelectedItem.RowCount <> 0 Then
            If e.ColumnIndex = 4 Then
                updateQty()
            ElseIf e.ColumnIndex = 5 Then
                Dim a As String = MsgBox("Are you sure you want to remove?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Atlantic Bakery")
                If a = vbYes Then
                    dgvSelectedItem.Rows.RemoveAt(e.RowIndex)
                End If
            End If
        End If
    End Sub

    Public Sub loadAvailableItems()
        recc.setDateCreated(DateTime.Now.ToString("MM/dd/yyy"))
        recc.setItemName(txtboxListItemSearch.Text)
        recc.setCategory(cmbCategoryListItem.Text)
        Dim result As New DataTable()
        result = recc.loadAvailableItems("rec")
        dgvListItem.Rows.Clear()
        For Each r0w As DataRow In result.Rows
            dgvListItem.Rows.Add(r0w("itemcode"), r0w("itemname"), r0w("category"))
        Next
        txtboxListItemSearch.AutoCompleteCustomSource = fillAutoComplete(dgvListItem, "itemname")
        lblListItemCount.Text = dgvListItem.RowCount.ToString("N0")
    End Sub

    Private Sub cmbCategoryListItem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCategoryListItem.SelectedIndexChanged
        loadAvailableItems()
    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim count As Integer = 0
        For index As Integer = 0 To dgvitems.RowCount - 1
            If dgvitems.Rows(index).Cells("item_name").Value = dgvListItem.CurrentRow.Cells("itemname").Value Then
                count += 1
            End If
        Next
        If dgvSelectedItem.Rows.Count = 0 Then
            MessageBox.Show("Please select item first", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf count > 0 Then
            MessageBox.Show("Can't convert to same item", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            PanelProduction.Visible = True
        End If
    End Sub
    Private Sub btnProceed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProceed.Click
        Try
            Dim count As Integer = 0, err As String = ""
            For index As Integer = 0 To dgvitems.RowCount - 1
                If dgvitems.Rows(index).Cells("item_name").Value = dgvListItem.CurrentRow.Cells("itemname").Value Then
                    count += 1
                End If
            Next
            For index As Integer = 0 To dgvitems.RowCount - 1
                Dim endbal As Double = 0.00
                con.Open()
                cmd = New SqlCommand("SELECT dbo.checkStock(@itemname)", con)
                cmd.Parameters.AddWithValue("@itemname", dgvitems.Rows(index).Cells("item_name").Value)
                endbal = cmd.ExecuteScalar
                con.Close()

                If endbal < CDbl(dgvitems.Rows(index).Cells("quantity").Value) Then
                    err &= dgvitems.Rows(index).Cells("item_name").Value & "(" & endbal & ")" & Environment.NewLine
                End If
            Next
            If lblConvID.Text = "N/A" Then
                MessageBox.Show("Please select to convert", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf count > 0 Then
                MessageBox.Show("Can't convert to same item", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf err <> "" Then
                MessageBox.Show("Below Item is insufficient stock" & Environment.NewLine & err, "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf String.IsNullOrEmpty(txtboxSAPNo.Text) And String.IsNullOrEmpty(txtboxRemarks.Text) Then
                MessageBox.Show("Please fill all fields", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf String.IsNullOrEmpty(txtboxSAPNo.Text) And checkfollowup.Checked = False Then
                MessageBox.Show("Please enter #", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf String.IsNullOrEmpty(txtboxRemarks.Text) Then
                MessageBox.Show("Please enter remarks", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Dim dtConvOut As New DataTable(), dtConvIn As New DataTable()
                dtConvOut.Columns.Add("quantity")
                dtConvOut.Columns.Add("itemname")
                dtConvOut.Columns.Add("conv_number")

                dtConvIn.Columns.Add("quantity")
                dtConvIn.Columns.Add("itemname")
                dtConvIn.Columns.Add("reference_number")

                For i As Integer = 0 To dgvitems.Rows.Count - 1
                    dtConvOut.Rows.Add(CDbl(dgvitems.Rows(i).Cells("quantity").Value), dgvitems.Rows(i).Cells("item_name").Value, lblConvID.Text)
                Next

                For i As Integer = 0 To dgvSelectedItem.Rows.Count - 1
                    dtConvIn.Rows.Add(CDbl(dgvSelectedItem.Rows(i).Cells("quantityy").Value), dgvSelectedItem.Rows(i).Cells("itemnamee").Value, lblConvID.Text)
                Next
                recc.sapDocument = lbltype.Text
                recc.headerText = "Conversion In"
                recc.convNumber = recc.returnTransactionNumber(False)
                recc.sapNumber = IIf(String.IsNullOrEmpty(Trim(txtboxSAPNo.Text)), 0, txtboxSAPNo.Text)
                recc.remarks = txtboxRemarks.Text
                recc.conversionFunction(dtConvOut, dtConvIn)
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub lblSAPClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSAPClose.Click
        PanelProduction.Visible = False
        txtboxRemarks.Text = ""
        txtboxSAPNo.Text = ""
    End Sub

    ''' <summary>
    ''' return auto complete string collection of datagridview cells that u want to get
    ''' </summary>
    ''' <param name="dgv"></param>
    ''' <param name="cellName"></param>
    ''' <returns></returns>
    Public Function fillAutoComplete(ByVal dgv As DataGridView, cellName As String) As AutoCompleteStringCollection
        Dim result As New AutoCompleteStringCollection
        For i As Integer = 0 To dgv.RowCount - 1
            result.Add(dgv.Rows(i).Cells(cellName).Value)
        Next
        Return result
    End Function

    Private Sub dgvConversions_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvConversions.CellContentClick
        Try
            'check if dgv has row
            If dgvConversions.Rows.Count <> 0 Then
                'check if user click column index one
                If e.ColumnIndex = 1 Then
                    'assign conversion number to label
                    lblConvID.Text = CStr(dgvConversions.CurrentRow.Cells("convnum").Value)
                    'assign conversion number to received item class
                    recc.convNumber = CStr(dgvConversions.CurrentRow.Cells("convnum").Value)
                    'init datatable that hold items
                    Dim result As New DataTable()
                    'assign datatable to get items
                    result = recc.loadConvOutItems()
                    'clear dgv items first
                    dgvitems.Rows.Clear()
                    'loop through
                    For Each r0w As DataRow In result.Rows
                        'assign every data to dgv items
                        dgvitems.Rows.Add(r0w("item_name"), r0w("category"), CInt(r0w("quantity")).ToString("N0"))
                    Next
                    txtselectedseach.AutoCompleteCustomSource = fillAutoComplete(dgvitems, "item_name")
                ElseIf e.ColumnIndex = 2 Then
                    Dim a As String = MsgBox("Are you sure you want to cancel?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Atlantic Bakery")
                    If a = vbYes Then
                        con.Open()
                        cmd = New SqlCommand("DELETE FROM tblconversion WHERE conv_number=@convnum", con)
                        cmd.Parameters.AddWithValue("@convnum", dgvConversions.CurrentRow.Cells("convnum").Value)
                        cmd.ExecuteNonQuery()
                        con.Close()

                        MessageBox.Show("Item Cancelled", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        load_convesions()
                        dgvitems.Rows.Clear()
                        lblConvID.Text = "N/A"
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub checkfollowup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkfollowup.CheckedChanged
        txtboxSAPNo.Text = IIf(checkfollowup.Checked, "", txtboxSAPNo.Text)
        txtboxSAPNo.Enabled = IIf(checkfollowup.Checked, False, True)
    End Sub

    Private Sub Panel5_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel5.MouseDown, MyBase.MouseDown
        drag = True 'Sets the variable drag to true.
        mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'Sets variable mousey
    End Sub

    Private Sub Panel5_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel5.MouseMove, MyBase.MouseMove
        'If drag is set to true then move the form accordingly.
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Panel5_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel5.MouseUp, MyBase.MouseUp
        drag = False 'Sets drag to false, so the form does not move according to the code in MouseMove
    End Sub

    Private Sub conversions2_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub lblcloseform_Click(sender As Object, e As EventArgs) Handles lblcloseform.Click
        Me.Close()
    End Sub

    Private Sub txtboxListItemSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtboxListItemSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearchListItem.PerformClick()
        End If
    End Sub

    Private Sub btnselectedsearch_Click(sender As Object, e As EventArgs) Handles btnselectedsearch.Click
        'loop dgv items
        For i As Integer = 0 To dgvitems.Rows.Count - 1
            'check if row is equal to search bar
            If dgvitems.Rows(i).Cells("item_name").Value.ToString.ToLower = txtselectedseach.Text.ToLower Then
                'assign row to be selected
                dgvitems.Rows(i).Selected = True
                dgvitems.CurrentCell = dgvitems.Rows(i).Cells("item_name")
            Else
                'assign row to be unselected if row and search it not match
                dgvitems.Rows(i).Selected = False
            End If
        Next
    End Sub

    Private Sub txtselectedseach_KeyDown(sender As Object, e As KeyEventArgs) Handles txtselectedseach.KeyDown
        'check if user pressed ENTER button
        If e.KeyCode = Keys.Enter Then
            btnselectedsearch.PerformClick()
        End If
    End Sub

    Private Sub txtboxSelectedItem_TextChanged(sender As Object, e As EventArgs) Handles txtselectedseach.TextChanged

    End Sub


    Private Sub txtboxSAPNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtboxSAPNo.KeyPress
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class