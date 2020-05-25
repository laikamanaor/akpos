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
Imports AK_POS.connection_class
Public Class pendingsap2
    Dim cc As New connection_class
    Dim con As New SqlConnection(cc.conString)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim adptr As New SqlDataAdapter

    Public manager As String = ""

    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function
    Public Sub loadCustomerEmployee()
        Try
            Dim auto As New AutoCompleteStringCollection()
            If cmbtype.Text = "AR Charge" Then
                con.Open()
                cmd = New SqlCommand("SELECT name FROM tblcustomers WHERE type='Employee' AND status=1;", con)
                rdr = cmd.ExecuteReader
                While rdr.Read
                    auto.Add(rdr("name"))
                End While
                con.Close()
            ElseIf cmbtype.Text = "AR Sales" Then
                con.Open()
                cmd = New SqlCommand("SELECT name FROM tblcustomers WHERE type='Customer' AND status=1;", con)
                rdr = cmd.ExecuteReader
                While rdr.Read
                    auto.Add(rdr("name"))
                End While
                con.Close()
            End If
            txtsearch.AutoCompleteCustomSource = auto
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub pendingsap2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbtype.SelectedIndex = 0
    End Sub
    Public Sub loadCashOut()
        Try
            dgvlists.Rows.Clear()
            dgvitems.Rows.Clear()
            con.Open()
            cmd = New SqlCommand("SELECT creditnum,sapdoc,sap,datecreated FROM tblcreditslogs WHERE sap='To Follow';", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                dgvlists.Rows.Add(False, rdr("creditnum"), "", rdr("sapdoc"), rdr("sap"), "Cashier Logs", CDate(rdr("datecreated")).ToString("MM/dd/yyyy"))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub loadConversions()
        Try
            dgvlists.Rows.Clear()
            con.Open()
            cmd = New SqlCommand("SELECT conv_number, typenum,sap_id,type,date_created FROM tblconversion WHERE sap_id='To Follow' AND type='" & IIf(cmbtype.Text = "Conversion Out", "Parent", "Child") & "';", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                dgvlists.Rows.Add(False, rdr("conv_number"), "", rdr("typenum"), rdr("sap_id"), IIf(rdr("type") = "Parent", "Conversion Out", "Conversion In"), CDate(rdr("date_created")).ToString("MM/dd/yyyy"))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Sub loadtblproductions()
        Try
            dgvlists.Rows.Clear()
            dgvitems.Rows.Clear()
            con.Open()
            cmd = New SqlCommand("SELECT transaction_number FROM tblproduction WHERE sap_number IN ('To Follow','') AND type='" & cmbtype.Text & "' AND CAST(date AS date)='" & datee.Text & "' GROUP BY transaction_number;", con)
            Dim dt As New DataTable()
            adptr.SelectCommand = cmd
            adptr.Fill(dt)
            con.Close()
            For Each r0w As DataRow In dt.Rows
                con.Open()
                cmd = New SqlCommand("SELECT typenum,sap_number,date,type2 FROM tblproduction WHERE sap_number IN ('To Follow','') AND type='" & cmbtype.Text & "' AND transaction_number=@name AND CAST(date AS date)='" & datee.Text & "' ORDER BY transaction_number DESC;", con)
                cmd.Parameters.AddWithValue("@name", r0w("transaction_number"))
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    dgvlists.Rows.Add(False, r0w("transaction_number"), "", rdr("typenum"), rdr("sap_number"), rdr("type2"), rdr("Date"))
                End If
                con.Close()
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub loadd()
        Try
            dgvitems.Rows.Clear()
            Select Case cmbtype.SelectedItem
                Case "---"
                    txtsearch.Enabled = False
                    btnsearch.Enabled = False
                    dgvlists.Rows.Clear()
                    dgvitems.Rows.Clear()
                    txtsearch.Enabled = False
                    btnsearch.Enabled = False
                    dgvlists.Columns("nameee").Visible = False
                Case "Received Item"
                    loadtblproductions()
                    txtsearch.Enabled = False
                    btnsearch.Enabled = False
                    dgvlists.Columns("nameee").Visible = False
                Case "Transfer Item"
                    loadtblproductions()
                    txtsearch.Enabled = False
                    btnsearch.Enabled = False
                    dgvlists.Columns("nameee").Visible = False
                Case "Adjustment Item"
                    loadtblproductions()
                    txtsearch.Enabled = False
                    btnsearch.Enabled = False
                    dgvlists.Columns("nameee").Visible = False
                Case "AR Cash"
                    loaddd()
                    txtsearch.Enabled = False
                    btnsearch.Enabled = False
                    dgvlists.Columns("nameee").Visible = True
                Case "AR Charge"
                    loaddd()
                    txtsearch.Enabled = True
                    btnsearch.Enabled = True
                    dgvlists.Columns("nameee").Visible = True
                    loadCustomerEmployee()
                Case "AR Sales"
                    loaddd()
                    txtsearch.Enabled = True
                    btnsearch.Enabled = True
                    dgvlists.Columns("nameee").Visible = True
                    loadCustomerEmployee()
                Case "Conversion In"
                    loadConversions()
                    txtsearch.Enabled = False
                    btnsearch.Enabled = False
                    dgvlists.Columns("nameee").Visible = False
                Case "Conversion Out"
                    loadConversions()
                    txtsearch.Enabled = False
                    btnsearch.Enabled = False
                Case "Cash Out For Deposit"
                    loadCashOut()
                    txtsearch.Enabled = False
                    btnsearch.Enabled = False
                    dgvlists.Columns("nameee").Visible = False
            End Select
            txtsearch.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub loaddd()
        Try
            dgvlists.Rows.Clear()
            dgvitems.Rows.Clear()

            Dim query As String = ""

            If txtsearch.Enabled = False Or String.IsNullOrEmpty(txtsearch.Text) Then
                query = "Select transnum,name,typenum,sap_no,_from,date_created FROM tblars1 WHERE sap_no='To Follow' AND type='" & cmbtype.Text & "' AND CAST(date_created AS date)='" & datee.Text & "';"
            Else
                query = "SELECT transnum,name,typenum,sap_no,_from,date_created FROM tblars1 WHERE sap_no='To Follow' AND type='" & cmbtype.Text & "' AND name LIKE @name AND CAST(date_created AS date)='" & datee.Text & "';"
            End If
            TextBox1.Text = query
            con.Open()
            cmd = New SqlCommand(query, con)
            If Not String.IsNullOrEmpty(txtsearch.Text) Then
                cmd.Parameters.AddWithValue("@name", "%" & txtsearch.Text & "%")
            End If
            Dim dt As New DataTable()
            adptr.SelectCommand = cmd
            adptr.Fill(dt)
            con.Close()
            For Each r0w As DataRow In dt.Rows
                dgvlists.Rows.Add(False, r0w("transnum"), r0w("name"), r0w("typenum"), r0w("sap_no"), r0w("_from"), r0w("date_created"))
                con.Close()
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub cmbtype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbtype.SelectedIndexChanged
        loadd()
        lblitems_count.Text = "ITEMS (0)"
        lbltrans_count.Text = "TRANSACTIONS (" & dgvlists.RowCount & ")"
    End Sub
    Public Sub dgvlists_cellclick()
        Select Case cmbtype.SelectedItem
            Case "---"
                dgvitems.Rows.Clear()
                dgvlists.Rows.Clear()
            Case "Received Item"
                loadProduction2()
            Case "Transfer Item"
                loadProduction2()
            Case "Adjustment Item"
                loadProduction2()
            Case "AR Cash"
                loadARS2()
            Case "AR Sales"
                loadARS2()
            Case "AR Charge"
                loadARS2()
            Case "Conversion In"
                loadConversionsItems()
            Case "Conversion Out"
                loadConversionsItems()
        End Select
        lblitems_count.Text = "ITEMS (" & dgvitems.RowCount & ")"
    End Sub
    Private Sub dgvlists_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvlists.CellContentClick
        Try
            dgvlists_cellclick()
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Ocurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Sub loadConversionsItems()
        Try
            dgvitems.Rows.Clear()
            con.Open()
            cmd = New SqlCommand("SELECT item_name,SUM(quantity) AS b FROM tblconversion WHERE conv_number=@conv AND CAST(date_created AS date)='" & datee.Text & "' GROUP BY item_name;", con)
            cmd.Parameters.AddWithValue("@conv", dgvlists.CurrentRow.Cells("namee").Value)
            rdr = cmd.ExecuteReader
            While rdr.Read
                dgvitems.Rows.Add(rdr("item_name"), rdr("b"))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Sub loadProduction2()
        Try
            dgvitems.Rows.Clear()
            con.Open()
            cmd = New SqlCommand("SELECT item_name,SUM(quantity) AS b FROM tblproduction WHERE type='" & cmbtype.Text & "' AND transaction_number='" & dgvlists.CurrentRow.Cells("namee").Value & "' AND CAST(date AS date)='" & datee.Text & "' GROUP BY item_name;", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                dgvitems.Rows.Add(rdr("item_name"), rdr("b"))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub loadARS2()
        Try
            If dgvlists.RowCount <> 0 Then
                dgvitems.Rows.Clear()
                con.Open()
                cmd = New SqlCommand("SELECT b.description, SUM(b.quantity) AS quantity FROM tblars1 a JOIN tblars2 b ON a.transnum = b.transnum WHERE a.transnum=@namee AND CAST(a.date_created AS date)='" & datee.Text & "' GROUP BY b.description;", con)
                cmd.Parameters.AddWithValue("@namee", dgvlists.CurrentRow.Cells("namee").Value)
                rdr = cmd.ExecuteReader
                While rdr.Read
                    dgvitems.Rows.Add(rdr("description"), rdr("quantity"))
                End While
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub updateCashOut()
        Try
            For index As Integer = 0 To dgvlists.RowCount - 1
                If dgvlists.Rows(index).Cells("chck").Value.ToString = "True" Then
                    con.Open()
                    cmd = New SqlCommand("UPDATE tblcreditslogs Set sap=@sap, remarks =@remarks WHERE creditnum=@creditnum;", con)
                    cmd.Parameters.AddWithValue("@sap", txtsap.Text)
                    cmd.Parameters.AddWithValue("@remarks", txtsap.Text)
                    cmd.Parameters.AddWithValue("@creditnum", dgvlists.Rows(index).Cells("namee").Value)
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If
            Next
            MessageBox.Show("Transaction Completed", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
            panelsap2.Visible = False
            txtsap.Text = ""
            txtremarks.Text = ""
            loadd()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub btnsubmit_Click(sender As Object, e As EventArgs) Handles btnsubmit.Click
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
            txtsap.Text = ""
            txtremarks.Text = ""
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

    Private Sub btnexport_Click(sender As Object, e As EventArgs) Handles btnexport.Click
        Try
            Dim isError As Integer = 0
            For index As Integer = 0 To dgvlists.RowCount - 1
                If CBool(dgvlists.Rows(index).Cells("chck").Value) = True Then
                    isError += 1
                End If
            Next
            If isError = 0 Or dgvlists.Rows.Count = 0 Then
                MessageBox.Show("Please Select transaction #", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If


            Dim r1 As New Random(), r2 As New Random(), r3 As New Random()

            SaveFileDialog1.Title = "Save As Excel File"
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
                dt.Columns.Add("#")

                Dim gr As String = "", sales As String = "", br_out As String = login.braout

                con.Open()
                cmd = New SqlCommand("Select gr,sales,branchcode FROM tblbranch WHERE branch=@branch;", con)
                cmd.Parameters.AddWithValue("@branch", login.braout)
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    gr = CStr(rdr("gr"))
                    sales = CStr(rdr("sales"))
                End If
                con.Close()




                Select Case cmbtype.SelectedItem
                    Case "AR Sales"
                        Dim id1 As Integer = 0, transnum As String = ""
                        For index As Integer = 0 To dgvlists.RowCount - 1
                            If CBool(dgvlists.Rows(index).Cells("chck").Value) <> False Then
                                transnum &= "'" & dgvlists.Rows(index).Cells("namee").Value & "',"
                            End If
                        Next
                        transnum = transnum.Substring(0, transnum.Length - 1)
                        con.Open()
                        cmd = New SqlCommand("SELECT name FROM tblars1 WHERE CAST(date_created as date)='" & datee.Text & "' AND type='AR Sales' AND transnum IN (" & transnum & ") GROUP BY name", con)
                        Dim dtName As New DataTable()
                        adptr.SelectCommand = cmd
                        adptr.Fill(dtName)
                        con.Close()

                        For Each r0w As DataRow In dtName.Rows
                            id1 += 1
                            Dim code As String = ""
                            con.Open()
                            cmd = New SqlCommand("SELECT code FROM tblcustomers WHERE name=@name AND type='Customer';", con)
                            cmd.Parameters.AddWithValue("@name", r0w("name"))
                            rdr = cmd.ExecuteReader
                            If rdr.Read Then
                                code = CStr(rdr("code"))
                            End If
                            con.Close()

                            dt.Rows.Add(id1, "dbDocument_Items", CDate(datee.Value).ToString("yyyyMMdd"), CDate(datee.Value).ToString("yyyyMMdd"), code, r0w("name"), "To Follow")

                        Next
                End Select
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

                Select Case cmbtype.SelectedItem
                    Case "AR Sales"
                        Dim transnum As String = ""
                        For index As Integer = 0 To dgvlists.RowCount - 1
                            If CBool(dgvlists.Rows(index).Cells("chck").Value) <> False Then
                                transnum &= "'" & dgvlists.Rows(index).Cells("namee").Value & "',"
                            End If
                        Next
                        transnum = transnum.Substring(0, transnum.Length - 1)

                        con.Open()
                        cmd = New SqlCommand("SELECT name FROM tblars1 WHERE CAST(date_created as date)='" & datee.Text & "' AND type='AR Sales' AND transnum IN (" & transnum & ") GROUP BY name", con)
                        Dim dtName2 As New DataTable()
                        adptr.SelectCommand = cmd
                        adptr.Fill(dtName2)
                        con.Close()

                        For Each r0w As DataRow In dtName2.Rows

                        Next

                End Select

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

                shWorkSheet.Range("A1").Locked = False

                shWorkSheet.Protect("qwe")


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
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btnimport_Click(sender As Object, e As EventArgs) Handles btnimport.Click

    End Sub

    Private Sub lblclose_Click(sender As Object, e As EventArgs) Handles lblclose.Click
        panelsap2.Visible = False
        txtremarks.Text = ""
        txtsap.Text = ""
    End Sub

    Private Sub btnproc_Click(sender As Object, e As EventArgs) Handles btnproc.Click
        Try
            If String.IsNullOrEmpty(txtsap.Text) Then
                MessageBox.Show("# is emty", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf String.IsNullOrEmpty(txtremarks.Text) Then
                MessageBox.Show("# is emty", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else

                Select Case cmbtype.SelectedItem
                    Case "AR Cash"
                        updateARS()
                    Case "AR Charge"
                        updateARS()
                    Case "AR Sales"
                        updateARS()
                    Case "Received Item"
                        updateProductions()
                    Case "Transfer Item"
                        updateProductions()
                    Case "Conversion In"
                        updateConversions()
                    Case "Conversion Out"
                        updateConversions()
                    Case "Cash Out For Deposit"
                        updateCashOut()
                End Select
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub updateConversions()
        Try
            For index As Integer = 0 To dgvlists.RowCount - 1
                If dgvlists.Rows(index).Cells("chck").Value.ToString = "True" Then
                    con.Open()
                    cmd = New SqlCommand("UPDATE tblconversion SET sap_id=@sap_no,remarks=@remarks WHERE conv_number=@conv;", con)
                    cmd.Parameters.AddWithValue("@conv", dgvlists.Rows(index).Cells("namee").Value)
                    cmd.Parameters.AddWithValue("@sap_no", txtsap.Text)
                    cmd.Parameters.AddWithValue("@remarks", txtremarks.Text)
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If
            Next
            MessageBox.Show("Transaction Completed", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
            panelsap2.Visible = False
            txtsap.Text = ""
            txtremarks.Text = ""
            loadd()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub updateProductions()
        Try
            For index As Integer = 0 To dgvlists.Rows.Count - 1
                If dgvlists.Rows(index).Cells("chck").Value.ToString = "True" Then
                    con.Open()
                    cmd = New SqlCommand("UPDATE tblproduction Set sap_number=@sap, remarks =@remarks WHERE transaction_number=@name AND type='" & cmbtype.Text & "' AND sap_number='To Follow';", con)
                    cmd.Parameters.AddWithValue("@sap", txtsap.Text)
                    cmd.Parameters.AddWithValue("@remarks", txtremarks.Text)
                    cmd.Parameters.AddWithValue("name", dgvlists.Rows(index).Cells("namee").Value)
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If
            Next
            MessageBox.Show("Transaction Completed", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
            panelsap2.Visible = False
            txtsap.Text = ""
            txtremarks.Text = ""
            loadd()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Sub updateARS()
        Try
            For index As Integer = 0 To dgvlists.RowCount - 1
                If CBool(dgvlists.Rows(index).Cells("chck").Value) = True Then
                    Dim query As String = ""
                    If cmbtype.Text = "AR Charge" Then
                        query = "UPDATE tblars1 SET sap_no=@sapno, remarks=@remarks, status ='Paid' WHERE transnum=@name;"
                    Else
                        query = "UPDATE tblars1 SET sap_no=@sapno,remarks=@remarks WHERE transnum=@name;"
                    End If

                    con.Open()
                    cmd = New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@sapno", txtsap.Text)
                    cmd.Parameters.AddWithValue("@remarks", txtremarks.Text)
                    cmd.Parameters.AddWithValue("@name", dgvlists.Rows(index).Cells("namee").Value)
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If
            Next
            MessageBox.Show("Transaction Completed", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
            loaddd()
            txtremarks.Text = ""
            txtsap.Text = ""
            panelsap2.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        loaddd()
    End Sub

    Private Sub datee_ValueChanged(sender As Object, e As EventArgs) Handles datee.ValueChanged
        loadd()
        If dgvlists.RowCount <> 0 Then
            dgvlists_cellclick()
        End If
    End Sub

    Private Sub txtsearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            loadd()
        End If
    End Sub
End Class