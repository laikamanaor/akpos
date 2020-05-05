Imports System.Data.SqlClient
Imports System.IO
Imports AK_POS.conversio
Public Class conversions
    Dim cc As New connection_class
    Dim strconn As String = cc.conString
    Dim con As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim transaction As SqlTransaction

    Dim selectedQuantity As String = ""
    Dim conv_number As String = ""

    Public lcacc As String = ""

    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function
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
    Private Sub lblClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClose.Click
        panelQuantity.Visible = False
    End Sub

    Private Sub btnQuantity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuantity.Click
        Dim get_itemname1 As String = lblQuantityItemName.Text.Replace("Item Name: ", "")
        Dim get_itemcode1 As String = lblQuantityItemCode.Text.Replace("Item Code: ", "")
        Dim cun As Integer = 0
        Dim getendBal As Double
        con.Open()
        cmd = New SqlCommand("SELECT endbal FROM tblinvitems  WHERE itemcode=@itemcode AND itemname=@itemname AND invnum=@invnum ", con)
        cmd.Parameters.AddWithValue("@itemcode", get_itemcode1)
        cmd.Parameters.AddWithValue("@itemname", get_itemname1)
        cmd.Parameters.AddWithValue("@invnum", lblID.Text)
        rdr = cmd.ExecuteReader()
        While rdr.Read()
            cun = 1
            getendBal = rdr("endbal")
        End While
        con.Close()
        If txtboxQuantity.Text = "" OrElse CDbl(txtboxQuantity.Text) = 0 Then
            MessageBox.Show("Quantity is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        If cun = 1 And getendBal < Val(txtboxQuantity.Text) Then
            MessageBox.Show("Invalid quantity", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
    Public Sub getID()
        Dim id As String = ""
        Dim date_ As New DateTime()
        con.Open()
        cmd = New SqlCommand("Select TOP 1 invnum,datecreated from tblinvsum WHERE area='" & lcacc & "' order by invsumid DESC", con)
        rdr = cmd.ExecuteReader()
        If rdr.Read() Then
            id = rdr("invnum")
            date_ = CDate(rdr("datecreated"))
        End If
        con.Close()
        If date_.ToString("MM/dd/yyyy") = getSystemDate.ToString("MM/dd/yyyy") Then
            lblID.Text = id
        Else
            lblID.Text = "N/A"
        End If
    End Sub

    Public Sub getConvNum()
        Try
            Dim temp As String = "0", area_format As String = "", selectcount_result As Integer = 0
            con.Open()
            cmd = New SqlCommand("Select ISNULL(MAX(conv_id),0)  from tblconversion WHERE area='" & lcacc & "' AND type='Parent';", con)
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
                format = "PRODCONVOUT - "
            ElseIf lcacc = "Sales" Then
                format = "SALCONVOUT - "
            End If

            area_format = format & branchcode & " - "

            If selectcount_result < 1000000 Then
                Dim cselectcount_result As String = CStr(selectcount_result)
                For vv As Integer = 1 To 6 - cselectcount_result.Length
                    temp += "0"
                Next
                conv_number = area_format & temp & selectcount_result
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

    Private Sub conversions_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'Dim a As String = MsgBox("Are you sure you want to close Coversion Item Form?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "")
        'If a = vbYes Then
        '    If mainmenu.counters = True Then
        '        mainmenu.counters = False
        '        mainmenu.Show()
        '        Me.Dispose()
        '        Me.Cursor = Cursors.Default
        '        Exit Sub
        '    End If
        '    mdiform.Show()
        '    Me.Dispose()
        'Else
        '    e.Cancel = True
        'End If

    End Sub
    Public Sub LISTADD()
        lblQuantityItemCode.Text = "Item Code: " & dgvListItem.CurrentRow.Cells(0).Value.ToString
        lblQuantityItemName.Text = "Item Name: " & dgvListItem.CurrentRow.Cells(1).Value.ToString
        lblQuantityCategory.Text = "Category: " & dgvListItem.CurrentRow.Cells(2).Value.ToString
        panelQuantity.Visible = True
        panelQuantity.BringToFront()
        selectedQuantity = "Add Quantity"
        txtboxQuantity.Focus()
    End Sub
    Private Sub dgvListItem_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListItem.CellContentClick
        If dgvListItem.Rows.Count <> 0 Then
            If e.ColumnIndex = 3 Then
                LISTADD()
            End If
        End If
    End Sub

    Private Sub btnSearchListItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchListItem.Click
        con.Open()
        cmd = New SqlCommand("SELECT itemcode,itemname FROM tblitems WHERE itemcode=@code OR itemname=@name", con)
        cmd.Parameters.AddWithValue("@code", txtboxListItemSearch.Text)
        cmd.Parameters.AddWithValue("@name", txtboxListItemSearch.Text)
        rdr = cmd.ExecuteReader()

        If rdr.Read() Then

            For i As Integer = 0 To dgvListItem.Rows.Count - 1
                If dgvListItem.Rows(i).Cells(1).Value = rdr("itemname") Then
                    dgvListItem.Rows(i).Selected = True
                    dgvListItem.CurrentCell = dgvListItem.Rows(i).Cells(1)
                Else
                    dgvListItem.Rows(i).Selected = False
                End If
            Next
            LISTADD()
        End If

        con.Close()
    End Sub

    Private Sub txtboxQuantity_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtboxQuantity.KeyPress
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Public Sub SelectedAdd()
        lblQuantityItemCode.Text = "Item Code: " & dgvSelectedItem.CurrentRow.Cells(0).Value.ToString
        lblQuantityItemName.Text = "Item Name: " & dgvSelectedItem.CurrentRow.Cells(1).Value.ToString
        panelQuantity.Visible = True
        panelQuantity.BringToFront()
        selectedQuantity = "Update Quantity"
        txtboxQuantity.Text = dgvSelectedItem.CurrentRow.Cells(3).Value
        txtboxQuantity.Focus()
    End Sub
    Private Sub dgvSelectedItem_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSelectedItem.CellContentClick
        If dgvSelectedItem.Rows.Count <> 0 Then
            If e.ColumnIndex = 4 Then
                SelectedAdd()
            ElseIf e.ColumnIndex = 5 Then
                Dim a As String = MsgBox("Are you sure you want to delete?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "")
                If a = vbYes Then
                    dgvSelectedItem.Rows.RemoveAt(e.RowIndex)
                End If
            End If
        End If
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
            SelectedAdd()
        End If

        con.Close()
    End Sub

    Private Sub cmbCategoryListItem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCategoryListItem.SelectedIndexChanged
        loadd()
    End Sub

    Public Sub loadd()
        If lcacc = "Production" And cmbCategoryListItem.Text = "All" Then
            load_items("SELECT tblinvitems.itemcode,tblinvitems.itemname,tblitems.category FROM tblitems JOIN tblinvitems ON tblitems.itemcode = tblinvitems.itemcode AND tblitems.itemname = tblinvitems.itemname  WHERE tblitems.discontinued='0'  and Not tblitems.category='Noodles' AND Not tblitems.category='Packaging' AND not tblitems.category='Drinks' AND NOT tblitems.category='Meal' AND NOT tblitems.category='Combo' AND tblinvitems.area='" & "Production" & "' AND tblinvitems.endbal !=0 AND invnum='" & lblID.Text & "' ORDER BY tblitems.itemcode")
        ElseIf lcacc = "Sales" And cmbCategoryListItem.Text = "All" Then
            load_items("SELECT tblinvitems.itemcode,tblinvitems.itemname,tblitems.category FROM tblitems JOIN tblinvitems ON tblitems.itemcode = tblinvitems.itemcode AND tblitems.itemname = tblinvitems.itemname  WHERE tblitems.discontinued='0'   AND tblinvitems.area='" & "Sales" & "' AND Not tblitems.category='Packaging' AND tblinvitems.endbal !=0 AND invnum='" & lblID.Text & "' ORDER BY tblitems.itemcode")
        ElseIf lcacc = "Production" And cmbCategoryListItem.Text <> "All" Then
            load_items("SELECT tblinvitems.itemcode,tblinvitems.itemname,tblitems.category FROM tblitems JOIN tblinvitems ON tblitems.itemcode = tblinvitems.itemcode AND tblitems.itemname = tblinvitems.itemname  WHERE tblitems.discontinued='0'  and Not tblitems.category='Noodles' AND Not tblitems.category='Packaging' AND not tblitems.category='Drinks' AND NOT tblitems.category='Meal' AND NOT tblitems.category='Combo' AND tblinvitems.area='" & lcacc & "' AND tblitems.category='" & cmbCategoryListItem.Text & "'  AND tblinvitems.endbal !=0 AND invnum='" & lblID.Text & "'  ORDER BY tblitems.itemcode")
        ElseIf lcacc = "Sales" And cmbCategoryListItem.Text <> "All" Then
            load_items("SELECT tblinvitems.itemcode,tblinvitems.itemname,tblitems.category FROM tblitems JOIN tblinvitems ON tblitems.itemcode = tblinvitems.itemcode AND tblitems.itemname = tblinvitems.itemname  WHERE tblitems.discontinued='0'  AND tblinvitems.area='" & lcacc & "' AND tblitems.category='" & cmbCategoryListItem.Text & "' AND Not tblitems.category='Packaging' AND tblinvitems.endbal !=0  AND invnum='" & lblID.Text & "' ORDER BY tblitems.itemcode")
        End If
    End Sub
    Public Sub query()
        Dim a As String = MsgBox("Are you sure you want to add?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MessageBoxDefaultButton.Button2, "")
        If a = vbYes Then
            PanelProduction.Visible = True
        End If
    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If dgvSelectedItem.Rows.Count = 0 Then
            MessageBox.Show("Please select item first", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf lblID.Text = "N/A" Then
            MessageBox.Show("Create New Inventory before adding item", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        query()
    End Sub


    Private Sub btnConvIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConvIn.Click
        Dim conversion2 As New conversions2()
        conversion2.lcacc = "Sales"
        'conversion2.btnfrom1.Visible = True
        'conversion2.btnfrom1.PerformClick()
        'conversion2.btnfrom1.Visible = False
        conversion2.ShowDialog()
        loadd()
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
        Try
            If checkCutOff() Then
                MessageBox.Show("Your account is already cut off", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If String.IsNullOrEmpty(Trim(txtboxSAPNo.Text)) And String.IsNullOrEmpty(txtboxRemarks.Text) Then
                MessageBox.Show("Fields is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf String.IsNullOrEmpty(Trim(txtboxSAPNo.Text)) And checkfollowup.Checked = False Then
                MessageBox.Show("SAP # is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf String.IsNullOrEmpty(Trim(txtboxRemarks.Text)) Then
                MessageBox.Show("Remarks is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else

                getConvNum()
                Try
                    Using connection As New SqlConnection(login.ss)
                        Dim cmdd As New SqlCommand()
                        cmdd.Connection = connection
                        connection.Open()
                        transaction = connection.BeginTransaction()
                        cmdd.Transaction = transaction
                        For index As Integer = 0 To dgvSelectedItem.Rows.Count - 1
                            cmdd.Parameters.Clear()
                            cmdd.CommandText = "INSERT INTO tblconversion (conv_number,inv_number,item_code,item_name,category,quantity,type,status,date_created,created_by,area,typenum,sap_id,remarks,reference_number,marks) VALUES (@conv_number,@inv_number,@code,@name,@category,@quantity,@type,@status,(SELECT GETDATE()),@created_by,@area,@typenum,@sap_id,@remarks,@reference,@marks)"
                            cmdd.Parameters.AddWithValue("@conv_number", conv_number)
                            cmdd.Parameters.AddWithValue("@inv_number", lblID.Text)
                            cmdd.Parameters.AddWithValue("@code", dgvSelectedItem.Rows(index).Cells(0).Value)
                            cmdd.Parameters.AddWithValue("@name", dgvSelectedItem.Rows(index).Cells(1).Value)
                            cmdd.Parameters.AddWithValue("@category", dgvSelectedItem.Rows(index).Cells(2).Value)
                            cmdd.Parameters.AddWithValue("@quantity", dgvSelectedItem.Rows(index).Cells(3).Value)
                            cmdd.Parameters.AddWithValue("@type", "Parent")
                            cmdd.Parameters.AddWithValue("@status", "Open")
                            cmdd.Parameters.AddWithValue("@created_by", login.username)
                            cmdd.Parameters.AddWithValue("@area", lcacc)
                            cmdd.Parameters.AddWithValue("@typenum", lbltype.Text)
                            Dim sap As String = ""
                            If checkfollowup.Checked = True Then
                                sap = "To Follow"
                            Else
                                sap = txtboxSAPNo.Text
                            End If
                            cmdd.Parameters.AddWithValue("@sap_id", sap)
                            cmdd.Parameters.AddWithValue("@remarks", txtboxRemarks.Text)
                            cmdd.Parameters.AddWithValue("@reference", conv_number)
                            cmdd.Parameters.AddWithValue("@marks", "")
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
                dgvSelectedItem.Rows.Clear()
                MessageBox.Show("Transaction Completed", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                loadd()
                PanelProduction.Visible = False
                txtboxSAPNo.Text = ""
                txtboxRemarks.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub lblSAPClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSAPClose.Click
        PanelProduction.Visible = False
    End Sub

    Private Sub conversions_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated, MyBase.Load
        If lcacc = "Production" Then
            load_items("SELECT itemcode,itemname,category FROM tblitems WHERE discontinued='0'  and Not category='Noodles' AND Not category='Packaging' AND not category='Drinks' AND NOT category='Meal' AND NOT category='Combo' ORDER BY itemcode")
        Else
            load_items("SELECT itemcode,itemname,category FROM tblitems WHERE discontinued='0' ORDER BY itemcode")
        End If
        load_selecteditems()
        categories()
        getID()
        cmbCategoryListItem.SelectedIndex = cmbCategoryListItem.Items.IndexOf("All")

    End Sub

    Private Sub checkfollowup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkfollowup.CheckedChanged
        If checkfollowup.Checked Then
            txtboxSAPNo.Text = ""
            txtboxSAPNo.Enabled = False
        Else
            txtboxSAPNo.Enabled = True
        End If
    End Sub

    Private Sub txtboxSAPNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtboxSAPNo.KeyPress
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtboxListItemSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtboxListItemSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearchListItem.PerformClick()
        End If
    End Sub

    Private Sub txtboxSelectedItem_KeyDown(sender As Object, e As KeyEventArgs) Handles txtboxSelectedItem.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button2.PerformClick()
        End If
    End Sub

    Private Sub txtboxQuantity_KeyDown(sender As Object, e As KeyEventArgs) Handles txtboxQuantity.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnQuantity.PerformClick()
        End If
    End Sub
End Class