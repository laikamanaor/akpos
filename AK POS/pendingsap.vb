Imports System.IO
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Globalization
Imports Microsoft.Office.Core
Imports Excel = Microsoft.Office.Interop.Excel
Imports ExcelAutoFormat = Microsoft.Office.Interop.Excel.XlRangeAutoFormat
Imports Microsoft.Office.Interop
Imports System.Xml.XPath
Imports System.Data
Imports System.Xml

Public Class pendingsap
    Dim strconn As String = login.ss
    Dim con As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim adptr As New SqlDataAdapter

    Dim tayp As String = ""
    Public manager As String = ""

    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function

    Private Sub pendingsap_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Public Sub loadNames()
        con.Open()

        con.Close()
    End Sub

    Public Sub loadLists(ByVal tbl As String, ByVal cmtype As String, ByVal type As String, ByVal transnum As String, ByVal typenum As String, ByVal sap As String, ByVal remarks As String, ByVal datecreated As String, ByVal whrtype As String)
        Try
            Dim query As String = ""
            Dim auto As New AutoCompleteStringCollection()
            dgvlists.Rows.Clear()
            If whrtype = "AR Sales" Or whrtype = "Cash" Or whrtype = "AR Charge" Or whrtype = "AR Cash" Or whrtype = "AR Reject" Then
                If manager = "Production" Then
                    query = "SELECT DISTINCT * FROM " & tbl & " WHERE " & type & "='" & whrtype & "' AND area='" & manager & "' AND " & sap & "='To Follow'"
                Else
                    query = "SELECT DISTINCT  * FROM " & tbl & " WHERE " & type & "='" & whrtype & "' AND area='" & "Sales" & "' AND " & sap & "='To Follow'"
                End If
            Else
                If manager = "Production" Then
                    If tbl <> "tblproduction" Then
                        query = "SELECT DISTINCT " & transnum & "," & typenum & "," & sap & "," & remarks & "," & datecreated & "," & type & ",marks FROM " & tbl & " WHERE " & type & "='" & whrtype & "' AND area='" & manager & "' AND " & sap & "='To Follow'"
                    Else
                        query = "SELECT DISTINCT " & transnum & "," & typenum & "," & sap & "," & remarks & "," & datecreated & "," & type & ",type2 FROM " & tbl & " WHERE " & type & "='" & whrtype & "' AND area='" & manager & "' AND " & sap & "='To Follow'"
                    End If

                ElseIf cmbtype.SelectedItem = "Transfer Item" Or cmbtype.SelectedItem = "Received Item" And manager = "Sales" Or cmbtype.SelectedItem = "Adjustment Item" Then
                    If cmbtype.SelectedItem = "Adjustment Item" Then
                        query = "SELECT DISTINCT " & transnum & "," & typenum & "," & sap & "," & remarks & "," & datecreated & "," & type & "  FROM " & tbl & " WHERE " & type & "='" & whrtype & "' AND area='" & manager & "' AND " & sap & "='To Follow'"
                    Else
                        query = "SELECT DISTINCT " & transnum & "," & typenum & "," & sap & "," & remarks & "," & datecreated & "," & type & ",type2  FROM " & tbl & " WHERE " & type & "='" & whrtype & "' AND area='" & manager & "' AND " & sap & "='To Follow'"
                    End If
                Else
                    query = "SELECT DISTINCT * FROM " & tbl & " WHERE " & type & "='" & whrtype & "' AND area='" & manager & "' AND " & sap & "='To Follow'"
                End If
            End If
            If cmtype = "Cash Out For Deposit" Then
                query = "SELECT DISTINCT * FROM " & tbl & " WHERE " & type & "='" & whrtype & "' AND " & sap & "='To Follow'"
            End If
            query &= " AND CAST(" & datecreated & " AS date)='" & DateTimePicker1.Text & "'"

            If cmbtype.SelectedItem = "Received Item" Or cmbtype.SelectedItem = "Transfer Item" Or cmbtype.SelectedItem = "Adjustment Item" Or cmbtype.SelectedItem = "Produce Item" Then
                query &= " AND transaction_id IN (SELECT MAX(transaction_id) FROM " & tbl & " GROUP BY " & transnum & ")"
            End If

            TextBox1.Text = query
            con.Open()
            cmd = New SqlCommand(query, con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                Dim ty As String = ""
                If rdr(type) = "Parent" Then
                    ty = "Conversion OUT"
                ElseIf rdr(type) = "Child" Then
                    ty = "Conversion In"
                Else
                    ty = rdr(type)
                End If
                If cmtype = "AR Charge" Or cmtype = "AR Sales" Then
                    dgvlists.Rows.Add(False, ty, rdr(transnum), rdr("name"), rdr(typenum), rdr(sap), rdr("_from"), rdr(remarks), rdr(datecreated))
                    If cmtype = "AR Charge" Then
                        dgvlists.Columns("from").Visible = True
                    Else
                        dgvlists.Columns("from").Visible = False
                    End If
                Else
                    If tbl <> "tblproduction" Then
                        If tbl = "tblconversion" Then
                            dgvlists.Rows.Add(False, ty, rdr(transnum), "", rdr(typenum), rdr(sap), IIf(rdr("marks") = "", "Conversion", "Rejects"), rdr(remarks), rdr(datecreated))
                        ElseIf tbl = "tblars1" Then
                            dgvlists.Rows.Add(False, ty, rdr(transnum), rdr("name"), rdr(typenum), rdr(sap), "", rdr(remarks), rdr(datecreated))
                        Else
                            dgvlists.Rows.Add(False, ty, rdr(transnum), "", rdr(typenum), rdr(sap), "", rdr(remarks), rdr(datecreated))
                        End If
                    Else
                        If tbl = "tblconversion" Or cmtype = "Adjustment Item" Then
                            dgvlists.Rows.Add(False, ty, rdr(transnum), "", rdr(typenum), rdr(sap), "", rdr(remarks), rdr(datecreated))
                        Else
                            dgvlists.Rows.Add(False, ty, rdr(transnum), "", rdr(typenum), rdr(sap), rdr("type2"), rdr(remarks), rdr(datecreated))
                        End If
                    End If
                    dgvlists.Columns("from").Visible = False
                End If

                If cmtype = "AR Charge" Or cmtype = "AR Sales" Or cmtype = "AR Cash" Then
                    auto.Add(rdr("name"))
                    auto.Add(rdr("transnum"))
                End If

            End While
            con.Close()
            If cmtype = "AR Charge" Or cmtype = "AR Sales" Or cmtype = "AR Cash" Then
                txtsearch.AutoCompleteCustomSource = auto
            End If
            lblcount1.Text = dgvlists.RowCount.ToString
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub loadTypes()
        If manager = "Production" Then
            cmbtype.Items.Clear()
            cmbtype.Items.Add("---")
            cmbtype.Items.Add("Produce Item")
            cmbtype.Items.Add("Adjustment Item")
            cmbtype.Items.Add("Transfer Item")
            cmbtype.Items.Add("AR Reject")
            cmbtype.Items.Add("AR Charge")
            cmbtype.Items.Add("Conversion In")
            cmbtype.Items.Add("Conversion OUT")
        ElseIf manager = "Sales" Then
            cmbtype.Items.Clear()
            cmbtype.Items.Add("---")
            cmbtype.Items.Add("Received Item")
            cmbtype.Items.Add("Adjustment Item")
            cmbtype.Items.Add("Transfer Item")
            cmbtype.Items.Add("AR Charge")
            cmbtype.Items.Add("AR Sales")
            cmbtype.Items.Add("AR Cash")
            cmbtype.Items.Add("Conversion In")
            cmbtype.Items.Add("Conversion OUT")
            cmbtype.Items.Add("Cash Out For Deposit")
            'ElseIf login.wrkgrp = "Manager" Or login.wrkgrp = "LC Accounting" Then
            '    cmbtype.Items.Clear()
            '    cmbtype.Items.Add("---")
            '    cmbtype.Items.Add("Produce Item")
            '    cmbtype.Items.Add("Received Item")
            '    cmbtype.Items.Add("Transfer Item")
            '    cmbtype.Items.Add("AR Reject")
            '    cmbtype.Items.Add("AR Charge")
            '    cmbtype.Items.Add("AR Sales")
            '    cmbtype.Items.Add("AR Cash")
            '    cmbtype.Items.Add("Conversion In")
            '    cmbtype.Items.Add("Conversion OUT")
            '    'dgvlists.Columns("btnupdate").Visible = False
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

    Private Sub pendingsap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'loadTypes()
        'cmbtype.SelectedIndex = 0
        DateTimePicker1.Text = getSystemDate.ToString("MM/dd/yyyy")
    End Sub

    Private Sub cmbtype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtype.SelectedIndexChanged
        type_selectedindexchanged()
    End Sub
    Public Sub type_selectedindexchanged()
        dgvitems.Rows.Clear()
        lblcount1.Text = 0
        lblcount2.Text = 0
        Select Case cmbtype.SelectedItem
            Case "---"
                dgvlists.Rows.Clear()
            Case "Produce Item"
                loadLists("tblproduction", "Received Item", "type", "transaction_number", "typenum", "sap_number", "remarks", "Date", "Produce Item")
                txtsearch.Enabled = False
                btnsearch.Enabled = False
                dgvlists.Columns("sapdocument").Visible = True
                dgvlists.Columns("namee").Visible = False
                dgvlists.Columns("from").Visible = True
            Case "Received Item"
                loadLists("tblproduction", "Received Item", "type", "transaction_number", "typenum", "sap_number", "remarks", "Date", "Received Item")
                txtsearch.Enabled = False
                btnsearch.Enabled = False
                dgvlists.Columns("sapdocument").Visible = True
                dgvlists.Columns("namee").Visible = False
                dgvlists.Columns("from").Visible = True
            Case "Adjustment Item"
                loadLists("tblproduction", "Adjustment Item", "type", "transaction_number", "typenum", "sap_number", "remarks", "Date", "Adjustment Item")
                txtsearch.Enabled = False
                btnsearch.Enabled = False
                dgvlists.Columns("sapdocument").Visible = True
                dgvlists.Columns("namee").Visible = False
                dgvlists.Columns("from").Visible = False
            Case "Transfer Item"
                loadLists("tblproduction", "Transfer Item", "type", "transaction_number", "typenum", "sap_number", "remarks", "Date", "Transfer Item")
                txtsearch.Enabled = False
                btnsearch.Enabled = False
                dgvlists.Columns("sapdocument").Visible = True
                dgvlists.Columns("namee").Visible = False
                dgvlists.Columns("from").Visible = False
            Case "AR Reject"
                loadLists("tblars1", "AR Reject", "type", "transnum", "typenum", "sap_no", "remarks", "date_created", "AR Reject")
                txtsearch.Enabled = False
                btnsearch.Enabled = False
                dgvlists.Columns("sapdocument").Visible = True
                dgvlists.Columns("namee").Visible = False
                dgvlists.Columns("from").Visible = False
            Case "AR Charge"
                loadLists("tblars1", "AR Charge", "type", "transnum", "typenum", "sap_no", "remarks", "date_created", "AR Charge")
                txtsearch.Enabled = True
                btnsearch.Enabled = True
                dgvlists.Columns("sapdocument").Visible = False
                dgvlists.Columns("namee").Visible = True
                dgvlists.Columns("from").Visible = True
            Case "AR Sales"
                loadLists("tblars1", "AR Sales", "type", "transnum", "typenum", "sap_no", "remarks", "date_created", "AR Sales")
                txtsearch.Enabled = True
                btnsearch.Enabled = True
                dgvlists.Columns("sapdocument").Visible = False
                dgvlists.Columns("namee").Visible = True
                dgvlists.Columns("from").Visible = False
            Case "AR Cash"
                loadLists("tblars1", "AR Cash", "type", "transnum", "typenum", "sap_no", "remarks", "date_created", "AR Cash")
                txtsearch.Enabled = True
                btnsearch.Enabled = True
                dgvlists.Columns("sapdocument").Visible = False
                dgvlists.Columns("namee").Visible = False
                dgvlists.Columns("from").Visible = False
            Case "Conversion OUT"
                loadLists("tblconversion", "Conversion OUT", "type", "conv_number", "typenum", "sap_id", "remarks", "date_created", "Parent")
                txtsearch.Enabled = False
                btnsearch.Enabled = False
                dgvlists.Columns("sapdocument").Visible = True
                dgvlists.Columns("namee").Visible = False
                dgvlists.Columns("from").Visible = True
            Case "Conversion In"
                loadLists("tblconversion", "Conversion In", "type", "conv_number", "typenum", "sap_id", "remarks", "date_created", "Child")
                txtsearch.Enabled = False
                btnsearch.Enabled = False
                dgvlists.Columns("sapdocument").Visible = True
                dgvlists.Columns("namee").Visible = False
                dgvlists.Columns("from").Visible = True
            Case "Cash Out For Deposit"
                loadLists("tblcreditslogs", "Cash Out For Deposit", "type", "creditnum", "sapdoc", "sap", "remarks", "datecreated", "Cash Out")
                dgvlists.Columns("sapdocument").Visible = True
                dgvlists.Columns("namee").Visible = False
                dgvlists.Columns("from").Visible = False
        End Select
        txtsearch.Text = ""
    End Sub
    Private Sub dgvlists_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvlists.CellContentClick
        Try
            loadItems()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub loadItems()
        Try
            If cmbtype.SelectedItem = "Produce Item" Or cmbtype.SelectedItem = "Received Item" Or cmbtype.SelectedItem = "Transfer Item" Or cmbtype.SelectedItem = "Adjustment Item" Then
                dgvitems.Rows.Clear()
                dgvitems.Columns("quantity").Visible = True
                dgvitems.Columns("reject").Visible = True
                dgvitems.Columns("charge").Visible = True
                dgvitems.Columns("quantity").HeaderText = "Good"
                con.Open()
                cmd = New SqlCommand("Select item_code,item_name,category,quantity,reject,charge FROM tblproduction WHERE transaction_number=@tnum", con)
                cmd.Parameters.AddWithValue("@tnum", dgvlists.CurrentRow.Cells("transnum").Value)
                rdr = cmd.ExecuteReader
                While rdr.Read
                    dgvitems.Rows.Add(rdr("item_code"), rdr("item_name"), rdr("category"), rdr("quantity"), rdr("reject"), rdr("charge"))
                End While
                con.Close()
            ElseIf cmbtype.SelectedItem = "AR Sales" Or cmbtype.SelectedItem = "AR Charge" Or cmbtype.SelectedItem = "AR Reject" Or cmbtype.Text = "AR Cash" Then
                dgvitems.Rows.Clear()
                dgvitems.Columns("reject").Visible = False
                dgvitems.Columns("charge").Visible = False
                dgvitems.Columns("quantity").HeaderText = "Quantity"
                con.Open()
                cmd = New SqlCommand("Select description,quantity FROM tblars2 WHERE transnum=@tnum", con)
                cmd.Parameters.AddWithValue("@tnum", dgvlists.CurrentRow.Cells("transnum").Value)
                adptr.SelectCommand = cmd
                Dim dt As New DataTable()
                adptr.Fill(dt)
                con.Close()
                For Each row As DataRow In dt.Rows
                    con.Open()
                    cmd = New SqlCommand("Select itemcode,category FROM tblitems WHERE itemname=@itemname;", con)
                    cmd.Parameters.AddWithValue("@itemname", row("description"))
                    rdr = cmd.ExecuteReader
                    While rdr.Read
                        dgvitems.Rows.Add(rdr("itemcode"), row("description"), rdr("category"), row("quantity"), "0", "0")
                    End While
                    con.Close()
                Next
            ElseIf cmbtype.SelectedItem = "Cash Sales" Then
                dgvitems.Rows.Clear()
                dgvitems.Columns("reject").Visible = False
                dgvitems.Columns("charge").Visible = False
                dgvitems.Columns("quantity").HeaderText = "Quantity"
                con.Open()
                cmd = New SqlCommand("Select category,itemname,qty FROM tblorder WHERE transnum=@tnum", con)
                cmd.Parameters.AddWithValue("@tnum", dgvlists.CurrentRow.Cells("transnum").Value)
                adptr.SelectCommand = cmd
                Dim datatable As New DataTable()
                adptr.Fill(datatable)
                con.Close()
                For Each row As DataRow In datatable.Rows
                    con.Open()
                    cmd = New SqlCommand("Select itemcode FROM tblitems WHERE itemname=@itemname And category=@category;", con)
                    cmd.Parameters.AddWithValue("@itemname", row("itemname"))
                    cmd.Parameters.AddWithValue("@category", row("category"))
                    rdr = cmd.ExecuteReader
                    While rdr.Read
                        dgvitems.Rows.Add(rdr("itemcode"), row("itemname"), row("category"), row("qty"), "0", "0")
                    End While
                    con.Close()
                Next
            Else
                dgvitems.Rows.Clear()
                dgvitems.Columns("reject").Visible = False
                dgvitems.Columns("charge").Visible = False
                dgvitems.Columns("quantity").HeaderText = "Quantity"
                con.Open()
                cmd = New SqlCommand("Select item_code,item_name,category,quantity FROM tblconversion WHERE conv_number=@convnum", con)
                cmd.Parameters.AddWithValue("@convnum", dgvlists.CurrentRow.Cells("transnum").Value)
                rdr = cmd.ExecuteReader
                While rdr.Read
                    dgvitems.Rows.Add(rdr("item_code"), rdr("item_name"), rdr("category"), rdr("quantity"), "0", "0")
                End While
                con.Close()
            End If
            lblcount2.Text = dgvitems.RowCount.ToString
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub lblProductionClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblProductionClose.Click
        PanelSAP.Visible = False
        txtboxRemarks.Text = ""
        txtboxSAPNo.Text = ""
        tayp = ""
    End Sub

    Private Sub txtboxSAPNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtboxSAPNo.KeyPress, txtsap.KeyPress
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnProceed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProceed.Click
        Try
            If String.IsNullOrEmpty(Trim(txtboxSAPNo.Text)) Then
                MessageBox.Show("# Is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            ElseIf String.IsNullOrEmpty(Trim(txtboxRemarks.Text)) Then
                MessageBox.Show("Remarks Is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                tayp = cmbtype.SelectedItem
                Select Case tayp
                    Case "Produce Item"
                        updateLists("tblproduction", "Produce Item", "type", "transaction_number", "sap_number", "remarks", "Date", "Produce Item")
                    Case "Received Item"
                        updateLists("tblproduction", "Received Item", "type", "transaction_number", "sap_number", "remarks", "Date", "Received Item")
                    Case "Transfer Item"
                        updateLists("tblproduction", "Transfer Item", "type", "transaction_number", "sap_number", "remarks", "Date", "Transfer Item")
                    Case "AR Reject"
                        updateLists("tblars1", "AR Reject", "type", "transnum", "sap_no", "remarks", "date_created", "AR Reject")
                    Case "AR Charge"
                        updateLists("tblars1", "AR Charge", "type", "transnum", "sap_no", "remarks", "date_created", "AR Charge")
                    Case "AR Sales"
                        updateLists("tblars1", "AR Sales", "type", "transnum", "sap_no", "remarks", "date_created", "AR Sales")
                    Case "AR Cash"
                        updateLists("tblars1", "AR Cash", "type", "transnum", "sap_no", "remarks", "date_created", "AR Cash")
                    Case "Conversion In"
                        updateLists("tblconversion", "Conversion In", "type", "conv_number", "sap_id", "remarks", "date_created", "Parent")
                    Case "Conversion OUT"
                        updateLists("tblconversion", "Conversion OUT", "type", "conv_number", "sap_id", "remarks", "date_created", "Child")
                End Select
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub updateLists(ByVal tbl As String, ByVal cmtype As String, ByVal type As String, ByVal transnum As String, ByVal sap As String, ByVal remarks As String, ByVal datecreated As String, ByVal whrtype As String)
        Dim query As String = ""
        For index As Integer = 0 To dgvlists.Rows.Count - 1S
            If CBool(dgvlists.Rows(index).Cells("chck").Value) = True Then
                If cmtype = "AR Sales" Or cmtype = "AR Charge" Or cmtype = "AR Reject" Or cmtype = "AR Cash" Then
                    If cmtype = "AR Sales" Then
                        query = "UPDATE " & tbl & " Set " & sap & "='" & txtsap.Text & "'," & remarks & "='" & txtremarks.Text & "' WHERE " & transnum & "='" & dgvlists.Rows(index).Cells("transnum").Value & "';"
                    Else
                        query = "UPDATE " & tbl & " SET " & sap & "='" & txtsap.Text & "'," & remarks & "='" & txtremarks.Text & "',status='Paid' WHERE " & transnum & "='" & dgvlists.Rows(index).Cells("transnum").Value & "';"
                    End If
                Else
                    query = "UPDATE " & tbl & " SET " & sap & "='" & txtsap.Text & "'," & remarks & "='" & txtremarks.Text & "' WHERE " & transnum & "='" & dgvlists.Rows(index).Cells("transnum").Value & "';"
                End If
                con.Open()
                cmd = New SqlCommand(query, con)
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next
        MessageBox.Show("Transaction Updated", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        panelsap2.Visible = False
        txtsap.Text = ""
        txtremarks.Text = ""
        type_selectedindexchanged()
    End Sub

    Private Sub dgvlists_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvlists.DataError
        e.Cancel = True
    End Sub

    Private Sub btnsubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsubmit.Click
        Dim isError As Integer = 0
        For index As Integer = 0 To dgvlists.Rows.Count - 1
            If CBool(dgvlists.Rows(index).Cells("chck").Value) = True Then
                isError += 1
            End If
        Next
        If isError = 0 Or dgvlists.Rows.Count = 0 Then
            MessageBox.Show("Please select transaction #", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            panelsap2.Visible = True
        End If
    End Sub

    Private Sub btnexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexport.Click
        Try
            Dim isError As Integer = 0
            For index As Integer = 0 To dgvlists.Rows.Count - 1
                If CBool(dgvlists.Rows(index).Cells("chck").Value) = True Then
                    isError += 1
                End If
            Next
            If isError = 0 Or dgvlists.Rows.Count = 0 Then
                MessageBox.Show("Please select transaction #", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim r1 As New Random(), r2 As New Random(), r3 As New Random()

            SaveFileDialog1.Title = "Save as Excel File"
            SaveFileDialog1.Filter = "Excel Document (*.xlsx) | *.xlsx"

            Dim x As String = cmbtype.Text.Replace(" ", "_")

            SaveFileDialog1.FileName = r1.Next(0, 10).ToString & r2.Next(200, 300) & r3.Next(500, 1000) & "_Pending_SAP_" & x.ToString & "_" & getSystemDate.ToString("MM_dd_yyyy_HH_mm")
            If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                btnexport.Text = "Please Wait..."
                btnexport.Enabled = False
                Me.Cursor = Cursors.WaitCursor
                Dim objExcel As New Excel.Application
                Dim bkWorkBook As Excel.Workbook
                Dim shWorkSheet As Excel.Worksheet
                Dim shWorkSheet1 As Excel.Worksheet
                Dim misValue As Object = System.Reflection.Missing.Value

                objExcel = New Excel.Application
                bkWorkBook = objExcel.Workbooks.Add
                shWorkSheet = CType(bkWorkBook.ActiveSheet, Excel.Worksheet)

                Dim dt As New DataTable()
                dt.Columns.Add("DocNum")
                dt.Columns.Add("DocType")
                dt.Columns.Add("DocDate")
                dt.Columns.Add("DocDueDate")
                dt.Columns.Add("CardCode")
                dt.Columns.Add("CardName")
                dt.Columns.Add("Comments")
                dt.Columns.Add("#")
                dt.Columns.Add("Remarks")

                Dim gr As String = "", sales As String = "", code As String = "", br_out As String = login.braout.Substring(login.braout.Length - 6), new_code As String = "", gl_account As String = ""

                con.Open()
                cmd = New SqlCommand("SELECT gr,sales,branchcode FROM tblbranch WHERE branch=@branch;", con)
                cmd.Parameters.AddWithValue("@branch", login.braout)
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    gr = CStr(rdr("gr"))
                    sales = CStr(rdr("sales"))
                    code = CStr(rdr("branchcode"))
                End If
                con.Close()

                If br_out = "Branch" Then
                    If manager = "Production" Then
                        code &= " P-FG"
                        gl_account = gr
                    ElseIf manager = "Sales" Then
                        code &= " S-FG"
                        gl_account = sales
                    End If
                ElseIf br_out = "Outlet" Then
                    code &= "-O"
                    gl_account = sales
                End If

                If cmbtype.SelectedItem = "Received Item" Or cmbtype.SelectedItem = "Transfer Item" Or cmbtype.SelectedItem = "Produce Item" Then
                    Dim id1 As Integer = 0, ref As String = ""
                    For index As Integer = 0 To dgvlists.Rows.Count - 1
                        If CBool(dgvlists.Rows(index).Cells("chck").Value) = True Then
                            If cmbtype.SelectedItem = "Received Item" Then
                                ref = "transfer_to"
                            ElseIf cmbtype.SelectedItem = "Transfer Item" Then
                                ref = "transfer_from"
                            ElseIf cmbtype.SelectedItem = "Produce Item" Then
                                ref = "transfer_to"
                            End If
                            id1 += 1
                            con.Open()
                            cmd = New SqlCommand("SELECT " & ref & " FROM tblproduction WHERE transaction_number=@tr", con)
                            cmd.Parameters.AddWithValue("@tr", dgvlists.Rows(index).Cells("transnum").Value)
                            rdr = cmd.ExecuteReader
                            If rdr.Read Then
                                dt.Rows.Add(id1, "dbDocument_Items", CDate(dgvlists.Rows(index).Cells("datecreated").Value).ToString("yyyyMMdd"), CDate(dgvlists.Rows(index).Cells("datecreated").Value).ToString("yyyyMMdd"), dgvlists.Rows(index).Cells("type").Value, rdr(ref), dgvlists.Rows(index).Cells("transnum").Value, "", dgvlists.Rows(index).Cells("remarks").Value)
                            End If
                            'dt.Rows.Add(grd.Rows(index).Cells("id").Value, "dbDocument_Items", CDate(dr("datecreated")).ToString("yyyyMMdd"), CDate(dr("datecreated")).ToString("yyyyMMdd"), dr("tendertype"), dr("customer"), dr("transnum"))
                            con.Close()
                        End If
                    Next
                ElseIf cmbtype.SelectedItem = "AR Charge" Or cmbtype.SelectedItem = "AR Sales" Or cmbtype.SelectedItem = "AR Reject" Or cmbtype.SelectedItem = "AR Cash" Then

                    If cmbtype.SelectedItem = "AR Cash" Then
                        dt.Columns.Add("zxc")
                    End If



                    Dim id2 As Integer = 0
                    For index As Integer = 0 To dgvlists.Rows.Count - 1
                        If CBool(dgvlists.Rows(index).Cells("chck").Value) = True Then
                            id2 += 1
                            con.Open()
                            cmd = New SqlCommand("SELECT DISTINCT name FROM tblars1 WHERE name='" & dgvlists.Rows(index).Cells("namee").Value & "';", con)
                            Dim dd As New DataTable()
                            Dim adptrs As New SqlDataAdapter()
                            adptrs.SelectCommand = cmd
                            adptrs.Fill(dd)
                            con.Close()
                            For Each r0w As DataRow In dd.Rows
                                Dim result As Double = 0.00
                                con.Open()
                                cmd = New SqlCommand("SELECT ISNULL(SUM(quantity),0) FROM tblars2 WHERE name=@namee;", con)
                                cmd.Parameters.AddWithValue("@namee", r0w("name"))
                                result = cmd.ExecuteScalar()
                                con.Close()
                                If cmbtype.SelectedItem = "AR Cash" Then
                                    dt.Rows.Add(id2, "dbDocument_Items", CDate(dgvlists.Rows(index).Cells("datecreated").Value).ToString("yyyyMMdd"), CDate(dgvlists.Rows(index).Cells("datecreated").Value).ToString("yyyyMMdd"), "Cash Sales", r0w("name"), result.ToString, "", dgvlists.Rows(index).Cells("remarks").Value, dgvlists.Rows(index).Cells("transnum").Value)
                                Else
                                    dt.Rows.Add(id2, "dbDocument_Items", CDate(dgvlists.Rows(index).Cells("datecreated").Value).ToString("yyyyMMdd"), CDate(dgvlists.Rows(index).Cells("datecreated").Value).ToString("yyyyMMdd"), dgvlists.Rows(index).Cells("type").Value, r0w("name"), dgvlists.Rows(index).Cells("transnum").Value, "", dgvlists.Rows(index).Cells("remarks").Value)
                                End If
                            Next
                        End If
                    Next
                ElseIf cmbtype.SelectedItem = "Conversion IN" Or cmbtype.SelectedItem = "Conversion OUT" Then
                    Dim id3 As Integer = 0
                    For index As Integer = 0 To dgvlists.Rows.Count - 1
                        If CBool(dgvlists.Rows(index).Cells("chck").Value) = True Then
                            id3 += 1
                            dt.Rows.Add(id3, "dbDocument_Items", CDate(dgvlists.Rows(index).Cells("datecreated").Value).ToString("yyyyMMdd"), CDate(dgvlists.Rows(index).Cells("datecreated").Value).ToString("yyyyMMdd"), dgvlists.Rows(index).Cells("type").Value, code, dgvlists.Rows(index).Cells("transnum").Value, "", dgvlists.Rows(index).Cells("remarks").Value)
                            con.Close()
                        End If
                    Next
                End If

                For i As Integer = 0 To dt.Columns.Count - 1
                    shWorkSheet.Cells(1, i + 1) = dt.Columns(i).ToString
                Next
                For i As Integer = 0 To dt.Rows.Count - 1
                    For j = 0 To dt.Columns.Count - 1
                        shWorkSheet.Cells(i + 2, j + 1) = dt.Rows(i)(j).ToString
                    Next
                Next

                With shWorkSheet
                    .Range("A1", misValue).EntireRow.Font.Bold = True
                    .Range("A1:I1").EntireRow.WrapText = True

                    .Range("A1:I1").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DodgerBlue)
                    .Range("A1:I1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)

                    .Range("A1:I" & dt.Rows.Count + 1).HorizontalAlignment = -4108
                    .Range("A1:I" & dt.Rows.Count + 1).VerticalAlignment = -4108
                    .Range("A1:I1").Font.Size = 12


                    .Range("A2:A" & dt.Rows.Count + 1).RowHeight = 40
                    .Range("A2:B" & dt.Rows.Count + 1).RowHeight = 40
                    .Range("A2:C" & dt.Rows.Count + 1).RowHeight = 40
                    .Range("A2:D" & dt.Rows.Count + 1).RowHeight = 40
                    .Range("A2:E" & dt.Rows.Count + 1).RowHeight = 40
                    .Range("A2:F" & dt.Rows.Count + 1).RowHeight = 40
                    .Range("A2:I" & dt.Rows.Count + 1).RowHeight = 40

                    .Range("A2:A" & dt.Rows.Count + 1).ColumnWidth = 10
                    .Range("A2:B" & dt.Rows.Count + 1).ColumnWidth = 20
                    .Range("A2:C" & dt.Rows.Count + 1).ColumnWidth = 20
                    .Range("A2:D" & dt.Rows.Count + 1).ColumnWidth = 20
                    .Range("A2:E" & dt.Rows.Count + 1).ColumnWidth = 15
                    .Range("A2:F" & dt.Rows.Count + 1).ColumnWidth = 20
                    .Range("A2:I" & dt.Rows.Count + 1).ColumnWidth = 22

                End With

                If cmbtype.SelectedItem = "AR Cash" Then
                    shWorkSheet.Columns("J").entirecolumn.delete
                End If

                shWorkSheet = bkWorkBook.Sheets(1)
                shWorkSheet.Name = "OINV"


                Dim dt1 As New DataTable()
                dt1.Columns.Add("DocNum")
                dt1.Columns.Add("ItemCode")
                dt1.Columns.Add("ItemDescription")
                dt1.Columns.Add("Quantity")
                dt1.Columns.Add("Price")
                dt1.Columns.Add("WarehouseCode")
                dt1.Columns.Add("AccountCode")
                'dt1.Rows.Add(grd.Rows(index).Cells("id").Value, rdr("itemcode"), r0w("itemname"), r0w("qty"), r0w("price"), "", "")

                If cmbtype.SelectedItem = "Received Item" Or cmbtype.SelectedItem = "Transfer Item" Or cmbtype.SelectedItem = "Produce Item" Then
                    For index As Integer = 0 To dgvlists.Rows.Count - 1
                        If CBool(dgvlists.Rows(index).Cells("chck").Value) = True Then
                            con.Open()
                            cmd = New SqlCommand("SELECT item_code,item_name,category,quantity FROM tblproduction WHERE transaction_number=@transnum", con)
                            cmd.Parameters.AddWithValue("@transnum", dgvlists.Rows(index).Cells("transnum").Value)
                            adptr.SelectCommand = cmd
                            Dim dtt As New DataTable()
                            adptr.Fill(dtt)
                            con.Close()

                            For Each r0w As DataRow In dtt.Rows
                                Dim foundrows() As DataRow
                                foundrows = dt.Select("Comments='" & dgvlists.Rows(index).Cells("transnum").Value & "'")
                                For index1 As Integer = 0 To foundrows.Length - 1
                                    con.Open()
                                    cmd = New SqlCommand("SELECT price FROM tblitems WHERE itemname=@iname AND itemcode=@icode AND category=@cat;", con)
                                    cmd.Parameters.AddWithValue("@icode", r0w("item_code"))
                                    cmd.Parameters.AddWithValue("@iname", r0w("item_name"))
                                    cmd.Parameters.AddWithValue("@cat", r0w("category"))
                                    rdr = cmd.ExecuteReader
                                    If rdr.Read Then
                                        dt1.Rows.Add(foundrows(index1)(0), r0w("item_code"), r0w("item_name"), r0w("quantity"), CDbl(rdr("price")).ToString("n2"), code, gl_account)
                                    End If
                                    con.Close()
                                Next
                            Next
                        End If
                    Next
                ElseIf cmbtype.SelectedItem = "AR Charge" Or cmbtype.SelectedItem = "AR Sales" Or cmbtype.SelectedItem = "AR Reject" Or cmbtype.SelectedItem = "AR Cash" Then
                    For index As Integer = 0 To dgvlists.Rows.Count - 1
                        If CBool(dgvlists.Rows(index).Cells("chck").Value) = True Then
                            con.Open()
                            cmd = New SqlCommand("SELECT tblars2.description,tblars2.quantity,tblars2.price,tblitems.itemcode,tblars2.name FROM tblars2 JOIN tblitems ON tblars2.description= tblitems.itemname WHERE tblars2.transnum=@transnum;", con)
                            cmd.Parameters.AddWithValue("@transnum", dgvlists.Rows(index).Cells("transnum").Value)
                            adptr.SelectCommand = cmd
                            Dim dtt As New DataTable()
                            adptr.Fill(dtt)
                            con.Close()

                            For Each r0w As DataRow In dtt.Rows
                                Dim foundrows() As DataRow
                                foundrows = dt.Select("CardName='" & r0w("name") & "'")
                                For index1 As Integer = 0 To foundrows.Length - 1
                                    dt1.Rows.Add(foundrows(index1)(0), r0w("itemcode"), r0w("description"), r0w("quantity"), CDbl(r0w("price")).ToString("n2"), code, gl_account)
                                Next
                            Next
                        End If
                    Next
                ElseIf cmbtype.SelectedItem = "Conversion IN" Or cmbtype.SelectedItem = "Conversion OUT" Then
                    For index As Integer = 0 To dgvlists.Rows.Count - 1
                        If CBool(dgvlists.Rows(index).Cells("chck").Value) = True Then
                            con.Open()
                            cmd = New SqlCommand("SELECT item_code,item_name,quantity,tblitems.price FROM tblconversion JOIN tblitems ON tblconversion.item_name= tblitems.itemname WHERE conv_number=@transnum;", con)
                            cmd.Parameters.AddWithValue("@transnum", dgvlists.Rows(index).Cells("transnum").Value)
                            adptr.SelectCommand = cmd
                            Dim dtt As New DataTable()
                            adptr.Fill(dtt)
                            con.Close()

                            For Each r0w As DataRow In dtt.Rows
                                Dim foundrows() As DataRow
                                foundrows = dt.Select("Comments='" & dgvlists.Rows(index).Cells("transnum").Value & "'")
                                For index1 As Integer = 0 To foundrows.Length - 1
                                    dt1.Rows.Add(foundrows(index1)(0), r0w("item_code"), r0w("item_name"), r0w("quantity"), CDbl(r0w("price")).ToString("n2"), code, gl_account)
                                Next
                            Next
                        End If
                    Next
                End If


                shWorkSheet1 = bkWorkBook.Worksheets.Add(, shWorkSheet, , )
                For i As Integer = 0 To dt1.Columns.Count - 1
                    shWorkSheet1.Cells(1, i + 1) = dt1.Columns(i).ToString
                Next
                For i As Integer = 0 To dt1.Rows.Count - 1
                    For j = 0 To dt1.Columns.Count - 1
                        shWorkSheet1.Cells(i + 2, j + 1) = dt1.Rows(i)(j).ToString
                    Next
                Next

                With shWorkSheet1
                    .Range("A1", misValue).EntireRow.Font.Bold = True
                    .Range("A1:G1").EntireRow.WrapText = True

                    .Range("A1:G1").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Orange)
                    .Range("A1:G1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)

                    .Range("A1:G" & dt1.Rows.Count + 1).HorizontalAlignment = -4108
                    .Range("A1:G" & dt1.Rows.Count + 1).VerticalAlignment = -4108
                    .Range("A1:G1").Font.Size = 12


                    .Range("A2:A" & dt1.Rows.Count + 1).RowHeight = 40
                    .Range("A2:B" & dt1.Rows.Count + 1).RowHeight = 40
                    .Range("A2:C" & dt1.Rows.Count + 1).RowHeight = 40
                    .Range("A2:D" & dt1.Rows.Count + 1).RowHeight = 40
                    .Range("A2:E" & dt1.Rows.Count + 1).RowHeight = 40
                    .Range("A2:F" & dt1.Rows.Count + 1).RowHeight = 40
                    .Range("A2:G" & dt1.Rows.Count + 1).RowHeight = 40

                    .Range("A2:A" & dt1.Rows.Count + 1).ColumnWidth = 10
                    .Range("A2:B" & dt1.Rows.Count + 1).ColumnWidth = 20
                    .Range("A2:C" & dt1.Rows.Count + 1).ColumnWidth = 30
                    .Range("A2:D" & dt1.Rows.Count + 1).ColumnWidth = 20
                    .Range("A2:E" & dt1.Rows.Count + 1).ColumnWidth = 15
                    .Range("A2:F" & dt1.Rows.Count + 1).ColumnWidth = 15
                    .Range("A2:G" & dt1.Rows.Count + 1).ColumnWidth = 20

                End With

                shWorkSheet1 = bkWorkBook.Sheets(2)
                shWorkSheet1.Name = "INV1"
                objExcel.Visible = False
                objExcel.Application.DisplayAlerts = False

                objExcel.ActiveWorkbook.Password = "qwe123"

                Dim path As String = IO.Path.GetDirectoryName(SaveFileDialog1.FileName)

                objExcel.ActiveWorkbook.SaveAs(SaveFileDialog1.FileName.ToString())
                objExcel.Quit()

                objExcel = Nothing
                btnexport.Text = "Export"
                btnexport.Enabled = True
                Me.Cursor = Cursors.Default
                MessageBox.Show("Saved" & Environment.NewLine & "Path: " & path, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            btnexport.Text = "Export"
            btnexport.Enabled = True
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString)
        End Try

        Dim proc As System.Diagnostics.Process
        For Each proc In System.Diagnostics.Process.GetProcessesByName("EXCEL")
            proc.Kill()
        Next
    End Sub

    Private Sub btnimport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnimport.Click
        Dim im As New importsap()
        im.ShowDialog()
        cmbtype.SelectedIndex = 0
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        If String.IsNullOrEmpty(txtsearch.Text) Then
            type_selectedindexchanged()
        Else
            btnsearch.PerformClick()
        End If
    End Sub
    Public Sub search()
        Try
            If String.IsNullOrEmpty(txtsearch.Text) Then
                type_selectedindexchanged()
            Else
                dgvlists.Rows.Clear()
                con.Open()
                cmd = New SqlCommand("Select transnum, sap_no, _from, remarks, date_created, typenum, Name FROM tblars1 WHERE transnum=@search Or name=@search And sap_no='To Follow' AND CAST(date_created AS date)='" & DateTimePicker1.Text & "';", con)
                cmd.Parameters.AddWithValue("@search", txtsearch.Text)
                rdr = cmd.ExecuteReader
                While rdr.Read
                    dgvlists.Rows.Add(False, cmbtype.Text, rdr("transnum"), rdr("name"), rdr("typenum"), rdr("sap_no"), rdr("_from"), rdr("remarks"), rdr("date_created"))
                End While
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        search()
    End Sub

    Private Sub btnproc_Click(sender As Object, e As EventArgs) Handles btnproc.Click
        Try
            If String.IsNullOrEmpty(Trim(txtsap.Text)) Then
                MessageBox.Show("# is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            ElseIf String.IsNullOrEmpty(Trim(txtremarks.Text)) Then
                MessageBox.Show("Remarks is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                tayp = cmbtype.SelectedItem
                Select Case tayp
                    Case "Produce Item"
                        updateLists("tblproduction", "Produce Item", "type", "transaction_number", "sap_number", "remarks", "date", "Produce Item")
                    Case "Received Item"
                        updateLists("tblproduction", "Received Item", "type", "transaction_number", "sap_number", "remarks", "date", "Received Item")
                    Case "Transfer Item"
                        updateLists("tblproduction", "Transfer Item", "type", "transaction_number", "sap_number", "remarks", "date", "Transfer Item")
                    Case "Adjustment Item"
                        updateLists("tblproduction", "Adjustment Item", "type", "transaction_number", "sap_number", "remarks", "date", "Adjustment Item")
                    Case "AR Reject"
                        updateLists("tblars1", "AR Reject", "type", "transnum", "sap_no", "remarks", "date_created", "AR Reject")
                    Case "AR Charge"
                        updateLists("tblars1", "AR Charge", "type", "transnum", "sap_no", "remarks", "date_created", "AR Charge")
                    Case "AR Sales"
                        updateLists("tblars1", "AR Sales", "type", "transnum", "sap_no", "remarks", "date_created", "AR Sales")
                    Case "AR Cash"
                        updateLists("tblars1", "AR Cash", "type", "transnum", "sap_no", "remarks", "date_created", "AR Cash")
                    Case "Conversion IN"
                        updateLists("tblconversion", "Conversion IN", "type", "conv_number", "sap_id", "remarks", "date_created", "Parent")
                    Case "Conversion OUT"
                        updateLists("tblconversion", "Conversion OUT", "type", "conv_number", "sap_id", "remarks", "date_created", "Child")
                    Case "Cash Out For Deposit"
                        updateLists("tblcreditslogs", "Cash Out For Deposit", "type", "creditnum", "sap", "remarks", "datecreated", "Cash Out")
                End Select
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub lblclose_Click(sender As Object, e As EventArgs) Handles lblclose.Click
        panelsap2.Visible = False
        txtsap.Text = ""
        txtremarks.Text = ""
    End Sub

    Private Sub txtsearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            search()
        End If
    End Sub
End Class