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
Imports System.Reflection
Imports ClosedXML.Excel
Imports AK_POS.connection_class
Imports AK_POS.sap_class
Public Class sap_uploading
    Dim cc As New connection_class, sapc As New sap_class
    Dim strconn As String = cc.conString
    Dim con As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim adptr As New SqlDataAdapter

    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Public Sub connect()
        con = New SqlConnection
        con.ConnectionString = strconn
        If con.State <> ConnectionState.Open Then
            con.Open()
        End If
    End Sub

    Public Sub disconnect()
        con = New SqlConnection
        con.ConnectionString = strconn
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
    End Sub

    ''' <summary>
    ''' for summary report generated in excel
    ''' </summary>
    Public Sub sap()
        Try
            'datatable to hold data from sheet 1
            Dim dt As New DataTable()
            dt.Columns.Add("DocNum")
            dt.Columns.Add("DocType")
            dt.Columns.Add("DocDate")
            dt.Columns.Add("DocDueDate")
            dt.Columns.Add("CardCode")
            dt.Columns.Add("CardName")
            dt.Columns.Add("#")
            dt.Rows.Add("DocNum", "DocType", "DocDate", "DocDueDate", "CardCode", "CardName", "SAP #")

            'variables to hold gr and sales from main branch
            Dim gr As String = "", sales As String = "", br_out As String = login.braout, dtBranches As New DataTable

            'get branch info from sap_class
            dtBranches = sapc.getBranchInfo()

            ''loop gr and sales from tblbranch
            For Each r0w As DataRow In dtBranches.Rows
                gr = CStr(r0w("gr"))
                sales = CStr(r0w("branchcode"))
            Next

            'docnum and datatabe for name 
            Dim docid As Integer = 0, dtName As New DataTable()
            sapc.setDateParameter(datee.Value)
            dtName = sapc.SgetName()

            'loop name and insert to datatable sheet 1
            For Each r0w As DataRow In dtName.Rows
                'increament docid every rows
                docid += 1

                'if name is CASH the name is A1 Main Cash Sales, if not display the customer name
                dt.Rows.Add(docid, "dDocument_Items", CDate(datee.Value).ToString("yyyyMMdd"), CDate(datee.Value).ToString("yyyyMMdd"), IIf(r0w("name") = "CASH", "A1_01", r0w("code")), IIf(r0w("name") = "CASH", "A1 Main Cash Sales", r0w("name")), "To Follow")
            Next

            'insert row for coffee shop
            dt.Rows.Add(docid + 1, "dDocument_Items", CDate(datee.Value).ToString("yyyyMMdd"), CDate(datee.Value).ToString("yyyyMMdd"), "A1_07", "A1 Main Coffee Shop", "To Follow")

            'datatable for items sheet 2
            Dim dt1 As New DataTable()
            dt1.Columns.Add("ParentKey")
            dt1.Columns.Add("LineNum")
            dt1.Columns.Add("ItemCode")
            dt1.Columns.Add("ItemDescription")
            dt1.Columns.Add("Quantity")
            dt1.Columns.Add("Price")
            dt1.Columns.Add("WarehouseCode")
            dt1.Columns.Add("AccountCode")
            dt1.Columns.Add("CardCode")
            dt1.Columns.Add("CardName")
            dt1.Columns.Add("Total Amount")
            dt1.Columns.Add("Remarks")
            'add new row default
            dt1.Rows.Add("DocNum", "LineNum", "ItemCode", "ItemDescription", "Quantity", "Price", "WhsCode", "AcctCode", "CardCode", "CardName", "", "")

            'datatable items for coffee shop
            Dim dataCs As New DataTable()
            dataCs.Columns.Add("itemcode")
            dataCs.Columns.Add("itemname")
            dataCs.Columns.Add("price")
            dataCs.Columns.Add("sold")

            'loop from datatable sheet 1
            For Each r0w As DataRow In dt.Rows
                'init type for customer
                Dim type As String = ""

                'get type of customer
                con.Open()
                cmd = New SqlCommand("SELECT type FROM tblcustomers WHERE name=@name;", con)
                cmd.Parameters.AddWithValue("@name", IIf(r0w("CardName") = "A1 Main Cash Sales", "CASH", r0w("CardName")))
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    type = CStr(rdr("type"))
                End If
                con.Close()

                'switch case define the type
                Dim dbtype As String = ""
                Select Case type
                    Case "Customer"
                        dbtype = "ar_sales_free"
                    Case "Employee"
                        dbtype = "ar_charged_free"
                    Case Else
                        dbtype = "cash_free"
                End Select

                'syntax to display items information
                con.Open()
                cmd = New SqlCommand("select a.description, sum(quantity)-isnull(x." & dbtype & ",0)[sold],ISNULL(x.cash_free,0)[cash_free],ISNULL(x.ar_charged_free,0)[ar_charged_free],ISNULL(x.ar_sales_free,0)[ar_sales_free],i3.itemcode,i3.price,x.ar_sales_free2,x.ar_charged_free2,b.remarks from tblars2 a left join tblars1 b on a.transnum=b.transnum LEFT JOIN tblitems i3 ON a.description = i3.itemname outer apply (SELECT a1.itemname,ISNULL(SUM(CASE WHEN a2.tendertype = 'CASH' THEN a1.qty END),0)[cash_free],ISNULL(SUM(CASE WHEN a2.tendertype = 'A.R Sales'  AND a2.customer='" & IIf(r0w("CardName") = "A1 Main Cash Sales", "CASH", r0w("CardName")) & "' THEN a1.qty END),0)[ar_sales_free],ISNULL(SUM(CASE WHEN a2.tendertype = 'A.R Charge' AND a2.customer='" & IIf(r0w("CardName") = "A1 Main Cash Sales", "CASH", r0w("CardName")) & "' THEN a1.qty END),0)[ar_charged_free],ISNULL(SUM(CASE WHEN a2.tendertype = 'A.R Charge'  THEN a1.qty END),0)[ar_charged_free2],ISNULL(SUM(CASE WHEN a2.tendertype = 'A.R Sales'  THEN a1.qty END),0)[ar_sales_free2]  FROM tblorder a1 LEFT JOIN tbltransaction a2 on a1.transnum=a2.transnum WHERE a.description = a1.itemname AND a1.free = 1 AND CAST(a2.datecreated AS date)='" & datee.Text & "' AND a2.status=1 GROUP BY a1.itemname)x where cast(b.date_created As Date) ='" & datee.Text & "' AND a.name='" & IIf(r0w("CardName") = "A1 Main Cash Sales", "CASH", r0w("CardName")) & "' GROUP BY a.description ,x.ar_charged_free, x.ar_sales_free,x.cash_free,i3.itemcode,i3.price,x.ar_sales_free2,x.ar_charged_free2,b.remarks", con)

                Dim dtitemResult As New DataTable()
                adptr.SelectCommand = cmd
                adptr.Fill(dtitemResult)
                con.Close()

                For Each row As DataRow In dtitemResult.Rows
                    'init coffee shop quantity,archarge and arsales variables
                    Dim cs_quantity As Double = 0.00, archarged As Double = 0.00, arsales As Double = 0.00

                    'check if column is null
                    If IsDBNull(row("ar_charged_free2")) Then
                        archarged = 0
                    Else
                        archarged = row("ar_charged_free2")
                    End If
                    'check if column is null
                    If IsDBNull(row("ar_sales_free2")) Then
                        arsales = 0
                    Else
                        arsales = row("ar_sales_free2")
                    End If

                    'add cash,archarge and arsales quantity
                    cs_quantity = (row("cash_free") + archarged + arsales)
                    'check if quantity is less than zero then insert new row
                    If cs_quantity > 0 Then
                        dataCs.Rows.Add(row("itemcode"), row("description"), row("price"), cs_quantity)
                    End If
                    'check if quantity is less than zero then insert new row
                    If CDbl(row("sold")) > 0 Then
                        dt1.Rows.Add(r0w("DocNum"), "LineNum", row("itemcode"), row("description"), row("sold"), row("price"), gr, sales, r0w("CardCode"), r0w("CardName"), (CDbl(row("sold")) * CDbl(row("price"))), row("remarks"))
                    End If
                Next
                'check if name is coffee shop
                If CStr(r0w("CardName")).ToLower = "A1 Main Coffee Shop".ToLower Then
                    Dim distinctTable As New DataTable()

                    'distinct datatable coffeeshop
                    distinctTable = dataCs.DefaultView.ToTable("itemname", True)
                    'loop through datatatble coffee shop
                    For Each cs As DataRow In distinctTable.Rows
                        'add new row for coffee shop in sheet 2
                        dt1.Rows.Add(r0w("DocNum"), "", cs("itemcode"), cs("itemname"), cs("sold"), cs("price"), gr, sales, r0w("CardCode"), r0w("CardName"))
                    Next
                End If
            Next

            Dim dsCount As New DataTable()
            dsCount = dt1.DefaultView.ToTable("ParentKey", True)

            Dim dsCount2 As New DataTable()
            dsCount2.Columns.Add("id")
            dsCount2.Columns.Add("quantity")
            For Each c As DataRow In dsCount.Rows
                Dim count As Integer = 0
                For Each x As DataRow In dt1.Rows
                    If c("ParentKey") = x("ParentKey") Then
                        count += 1
                        dsCount2.Rows.Add(c("ParentKey"), count)
                    End If
                Next
            Next

            Dim dsDistinct As New DataTable()
            dsDistinct = dsCount2.DefaultView.ToTable("id", True)
            Dim distinctFinal As New DataTable()
            distinctFinal.Columns.Add("id")
            distinctFinal.Columns.Add("quantity")
            For Each dd As DataRow In dsDistinct.Rows
                distinctFinal.Rows.Add(dd("id"), dd("quantity"))
            Next

            For index As Integer = 1 To dt1.Rows.Count - 1
                dt1(index)("LineNum") = distinctFinal(index)("quantity")
            Next

            'config to save
            SaveFileDialog1.Title = "Save As Excel File"
            SaveFileDialog1.Filter = "Excel Document (*.xlsx) | *.xlsx"
            SaveFileDialog1.FileName = datee.Value.ToString("MMddyyyy")

            'check if user click ok
            If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.Cursor = Cursors.WaitCursor
                'init excel config
                Dim objExcel As New Excel.Application
                Dim bkWorkBook As Excel.Workbook
                Dim shWorkSheet As Excel.Worksheet
                Dim shWorkSheet1 As Excel.Worksheet
                Dim misValue As Object = System.Reflection.Missing.Value

                objExcel = New Excel.Application
                bkWorkBook = objExcel.Workbooks.Add
                shWorkSheet = CType(bkWorkBook.ActiveSheet, Excel.Worksheet)

                'loop through datatable sheet 1 columns
                For i As Integer = 0 To dt.Columns.Count - 1
                    shWorkSheet.Cells(1, i + 1) = dt.Columns(i).ToString
                Next
                'loop through datatable sheet 1 rows
                For i As Integer = 0 To dt.Rows.Count - 1
                    For j = 0 To dt.Columns.Count - 1
                        shWorkSheet.Cells(i + 2, j + 1) = dt.Rows(i)(j).ToString
                    Next
                Next

                'sheet 1 worksheet config
                With shWorkSheet
                    .Range("A1", misValue).EntireRow.Font.Bold = True
                    .Range("A1:G1").EntireRow.WrapText = True

                    .Range("A1:G1").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DodgerBlue)
                    .Range("A1:G1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)

                    .Range("A1:G" & dt.Rows.Count + 1).HorizontalAlignment = -4108
                    .Range("A1:G" & dt.Rows.Count + 1).VerticalAlignment = -4108
                    .Range("A1:G1").Font.Size = 12

                    .Range("A2:A" & dt.Rows.Count + 1).RowHeight = 40
                    .Range("A2:B" & dt.Rows.Count + 1).RowHeight = 40
                    .Range("A2:C" & dt.Rows.Count + 1).RowHeight = 40
                    .Range("A2:D" & dt.Rows.Count + 1).RowHeight = 40
                    .Range("A2:E" & dt.Rows.Count + 1).RowHeight = 40
                    .Range("A2:F" & dt.Rows.Count + 1).RowHeight = 40
                    .Range("A2:G" & dt.Rows.Count + 1).RowHeight = 40

                    .Range("A2:A" & dt.Rows.Count + 1).ColumnWidth = 10
                    .Range("A2:B" & dt.Rows.Count + 1).ColumnWidth = 20
                    .Range("A2:C" & dt.Rows.Count + 1).ColumnWidth = 20
                    .Range("A2:D" & dt.Rows.Count + 1).ColumnWidth = 20
                    .Range("A2:E" & dt.Rows.Count + 1).ColumnWidth = 15
                    .Range("A2:F" & dt.Rows.Count + 1).ColumnWidth = 20
                    .Range("A2:G" & dt.Rows.Count + 1).ColumnWidth = 22

                End With

                'sheet 1 name
                shWorkSheet = bkWorkBook.Sheets(1)
                shWorkSheet.Name = "OINV"

                'sheet 2 config
                shWorkSheet1 = bkWorkBook.Worksheets.Add(, shWorkSheet, , )
                'loop through datatable sheet 2 columns
                For i As Integer = 0 To dt1.Columns.Count - 1
                    shWorkSheet1.Cells(1, i + 1) = dt1.Columns(i).ToString
                Next
                'loop through datatable sheet 2 rows
                For i As Integer = 0 To dt1.Rows.Count - 1
                    For j = 0 To dt1.Columns.Count - 1
                        shWorkSheet1.Cells(i + 2, j + 1) = dt1.Rows(i)(j).ToString
                    Next
                Next

                'sheet 2 config
                With shWorkSheet1
                    .Range("A1", misValue).EntireRow.Font.Bold = True
                    .Range("A1:L1").EntireRow.WrapText = True

                    .Range("A1:L1").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Orange)
                    .Range("A1:L1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)

                    .Range("A1:L" & dt1.Rows.Count + 1).HorizontalAlignment = -4108
                    .Range("A1:L" & dt1.Rows.Count + 1).VerticalAlignment = -4108
                    .Range("A1:L1").Font.Size = 12


                    .Range("A2:A" & dt1.Rows.Count + 1).RowHeight = 40
                    .Range("A2:B" & dt1.Rows.Count + 1).RowHeight = 40
                    .Range("A2:C" & dt1.Rows.Count + 1).RowHeight = 40
                    .Range("A2:D" & dt1.Rows.Count + 1).RowHeight = 40
                    .Range("A2:E" & dt1.Rows.Count + 1).RowHeight = 40
                    .Range("A2:F" & dt1.Rows.Count + 1).RowHeight = 40
                    .Range("A2:G" & dt1.Rows.Count + 1).RowHeight = 40
                    .Range("A2:H" & dt1.Rows.Count + 1).RowHeight = 40
                    .Range("A2:I" & dt1.Rows.Count + 1).RowHeight = 40
                    .Range("A2:J" & dt1.Rows.Count + 1).RowHeight = 40
                    .Range("A2:K" & dt1.Rows.Count + 1).RowHeight = 40
                    .Range("A2:L" & dt1.Rows.Count + 1).RowHeight = 40

                    .Range("A2:A" & dt1.Rows.Count + 1).ColumnWidth = 10
                    .Range("A2:B" & dt1.Rows.Count + 1).ColumnWidth = 20
                    .Range("A2:C" & dt1.Rows.Count + 1).ColumnWidth = 30
                    .Range("A2:D" & dt1.Rows.Count + 1).ColumnWidth = 20
                    .Range("A2:E" & dt1.Rows.Count + 1).ColumnWidth = 15
                    .Range("A2:F" & dt1.Rows.Count + 1).ColumnWidth = 15
                    .Range("A2:G" & dt1.Rows.Count + 1).ColumnWidth = 20
                    .Range("A2:H" & dt1.Rows.Count + 1).ColumnWidth = 20
                    .Range("A2:I" & dt1.Rows.Count + 1).ColumnWidth = 20
                    .Range("A2:J" & dt1.Rows.Count + 1).ColumnWidth = 20
                    .Range("A2:K" & dt1.Rows.Count + 1).ColumnWidth = 20
                    .Range("A2:L" & dt1.Rows.Count + 1).ColumnWidth = 20
                End With

                'sheet 2 name
                shWorkSheet1 = bkWorkBook.Sheets(2)
                shWorkSheet1.Name = "INV1"

                'lock sheet 2 A1 
                shWorkSheet.Range("A1").Locked = False
                shWorkSheet1.Range("A1").Locked = False

                'protect password for sheet 1 and sheet 2
                shWorkSheet.Protect("atlantic")
                shWorkSheet1.Protect("atlantic")

                'excel config
                objExcel.Visible = False
                objExcel.Application.DisplayAlerts = False

                'workbook password for excel
                objExcel.ActiveWorkbook.Password = "atlantic"

                'init and save path 
                Dim path As String = IO.Path.GetDirectoryName(SaveFileDialog1.FileName)
                objExcel.ActiveWorkbook.SaveAs(SaveFileDialog1.FileName.ToString())
                objExcel.Quit()

                'clear object excel
                objExcel = Nothing
                'when all is success, this message is pop up and cursor is back to normal
                Me.Cursor = Cursors.Default
                MessageBox.Show("Saved" & Environment.NewLine & "Path: " & path, "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            disconnect()
        End Try
    End Sub
    Public Sub endingbalance()
        Try
            'savedialog format
            SaveFileDialog1.Title = "Save As Excel File"
            SaveFileDialog1.Filter = "Excel Document (*.xlsx) | *.xlsx"
            SaveFileDialog1.FileName = datee.Value.ToString("MMddyyyy") & "_endbal"

            'check if user click ok
            If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                'cursor ui change to loading
                Me.Cursor = Cursors.WaitCursor

                'init excel variables
                Dim objExcel As New Excel.Application
                Dim bkWorkBook As Excel.Workbook
                Dim shWorkSheet As Excel.Worksheet
                Dim shWorkSheet1 As Excel.Worksheet
                Dim misValue As Object = System.Reflection.Missing.Value
                objExcel = New Excel.Application
                bkWorkBook = objExcel.Workbooks.Add
                shWorkSheet = CType(bkWorkBook.ActiveSheet, Excel.Worksheet)

                'init datatable for sheet 1
                Dim dt As New DataTable()
                dt.Columns.Add("ItemCode")
                dt.Columns.Add("ItemName")
                dt.Columns.Add("Quantity")
                dt.Columns.Add("Price")
                dt.Columns.Add("AccountCode")
                dt.Columns.Add("WarehouseCode")

                'init gr, branchcode, and datatable branches info
                Dim acct As String = "", warehouse As String = "", dtBranchesInfo As New DataTable
                'return datatable from sap_class
                dtBranchesInfo = sapc.getBranchInfo()

                'loop through datatable branches info
                For Each r0w As DataRow In dtBranchesInfo.Rows
                    'assign gr and branch code
                    acct = CStr(r0w("gr"))
                    warehouse = CStr(r0w("branchcode"))
                Next

                'short
                Dim dtgetEBShort As New DataTable()
                sapc.setDateParameter(datee.Text)
                dtgetEBShort = sapc.getendingBalanceShort()
                For Each r0w As DataRow In dtgetEBShort.Rows
                    dt.Rows.Add(r0w("itemcode"), r0w("itemname"), r0w("charge"), CDbl(r0w("price")).ToString("n2"), acct, warehouse)
                Next


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
                    .Range("A1:F1").EntireRow.WrapText = True

                    .Range("A1:F1").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DodgerBlue)
                    .Range("A1:F1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)

                    .Range("A1:F" & dt.Rows.Count + 1).HorizontalAlignment = -4108
                    .Range("A1:F" & dt.Rows.Count + 1).VerticalAlignment = -4108
                    .Range("A1:F1").Font.Size = 12


                    .Range("A2:A" & dt.Rows.Count + 1).RowHeight = 40

                    .Range("A2:B" & dt.Rows.Count + 1).RowHeight = 40
                    .Range("A2:C" & dt.Rows.Count + 1).RowHeight = 40
                    .Range("A2:D" & dt.Rows.Count + 1).RowHeight = 40
                    .Range("A2:E" & dt.Rows.Count + 1).RowHeight = 40
                    .Range("A2:F" & dt.Rows.Count + 1).RowHeight = 40

                    .Range("A2:A" & dt.Rows.Count + 1).ColumnWidth = 10
                    .Range("A2:B" & dt.Rows.Count + 1).ColumnWidth = 20
                    .Range("A2:C" & dt.Rows.Count + 1).ColumnWidth = 20
                    .Range("A2:D" & dt.Rows.Count + 1).ColumnWidth = 20
                    .Range("A2:E" & dt.Rows.Count + 1).ColumnWidth = 15
                    .Range("A2:F" & dt.Rows.Count + 1).ColumnWidth = 20
                End With

                shWorkSheet = bkWorkBook.Sheets(1)
                shWorkSheet.Name = "Short"

                Dim dt2 As New DataTable()
                dt2.Columns.Add("ItemCode")
                dt2.Columns.Add("ItemName")
                dt2.Columns.Add("Quantity")
                dt2.Columns.Add("Price")
                dt2.Columns.Add("AccountCode")
                dt2.Columns.Add("WarehouseCode")

                con.Open()
                cmd = New SqlCommand("SELECT b.itemcode,b.itemname,ISNULL(SUM(CASE WHEN a.endbal < a.actualendbal THEN a.actualendbal - a.endbal END),0) [over],b.price FROM tblinvitems a INNER JOIN tblitems b ON a.itemname = b.itemname AND a.invnum=(SELECT invnum FROM tblinvsum WHERE CAST(tblinvsum.datecreated AS date)='" & datee.Text & "') AND a.totalav !=0 AND b.category !='Coffee Shop' GROUP BY b.itemcode,b.itemname,b.price HAVING ISNULL(SUM(CASE WHEN a.endbal < a.actualendbal THEN a.actualendbal - a.endbal END),0) !=0", con)
                rdr = cmd.ExecuteReader
                While rdr.Read
                    dt2.Rows.Add(rdr("itemcode"), rdr("itemname"), rdr("over"), CDbl(rdr("price")).ToString("n2"), acct, warehouse)
                End While
                con.Close()

                shWorkSheet1 = bkWorkBook.Worksheets.Add(, shWorkSheet, , )
                For i As Integer = 0 To dt2.Columns.Count - 1
                    shWorkSheet1.Cells(1, i + 1) = dt2.Columns(i).ToString
                Next
                For i As Integer = 0 To dt2.Rows.Count - 1
                    For j = 0 To dt2.Columns.Count - 1
                        shWorkSheet1.Cells(i + 2, j + 1) = dt2.Rows(i)(j).ToString
                    Next
                Next

                With shWorkSheet1
                    .Range("A1", misValue).EntireRow.Font.Bold = True
                    .Range("A1:F1").EntireRow.WrapText = True

                    .Range("A1:F1").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DodgerBlue)
                    .Range("A1:F1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)

                    .Range("A1:F" & dt2.Rows.Count + 1).HorizontalAlignment = -4108
                    .Range("A1:F" & dt2.Rows.Count + 1).VerticalAlignment = -4108
                    .Range("A1:F1").Font.Size = 12


                    .Range("A2:A" & dt2.Rows.Count + 1).RowHeight = 40


                    .Range("A2:B" & dt2.Rows.Count + 1).RowHeight = 40
                    .Range("A2:C" & dt2.Rows.Count + 1).RowHeight = 40
                    .Range("A2:D" & dt2.Rows.Count + 1).RowHeight = 40
                    .Range("A2:E" & dt2.Rows.Count + 1).RowHeight = 40
                    .Range("A2:F" & dt2.Rows.Count + 1).RowHeight = 40

                    .Range("A2:A" & dt2.Rows.Count + 1).ColumnWidth = 10
                    .Range("A2:B" & dt2.Rows.Count + 1).ColumnWidth = 20
                    .Range("A2:C" & dt2.Rows.Count + 1).ColumnWidth = 20
                    .Range("A2:D" & dt2.Rows.Count + 1).ColumnWidth = 20
                    .Range("A2:E" & dt2.Rows.Count + 1).ColumnWidth = 15
                    .Range("A2:F" & dt2.Rows.Count + 1).ColumnWidth = 20
                End With

                shWorkSheet1 = bkWorkBook.Sheets(2)
                shWorkSheet1.Name = "Over"

                shWorkSheet.Range("A1").Locked = False

                shWorkSheet.Protect("atlantic")

                objExcel.Visible = False
                objExcel.Application.DisplayAlerts = False

                objExcel.ActiveWorkbook.Password = "atlantic"

                Dim path As String = IO.Path.GetDirectoryName(SaveFileDialog1.FileName)
                objExcel.ActiveWorkbook.SaveAs(SaveFileDialog1.FileName.ToString())
                objExcel.Quit()

                objExcel = Nothing
                Me.Cursor = Cursors.Default
                MessageBox.Show("Saved" & Environment.NewLine & "Path: " & path, "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Public Sub conversion()
        Try
            Dim r1 As New Random(), r2 As New Random(), r3 As New Random()

            SaveFileDialog1.Title = "Save As Excel File"
            SaveFileDialog1.Filter = "Excel Document (*.xlsx) | *.xlsx"

            SaveFileDialog1.FileName = datee.Value.ToString("MMddyyyy") & "_conversion"
            If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
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
                dt.Columns.Add("Num")
                dt.Columns.Add("ItemCode")
                dt.Columns.Add("ItemName")
                dt.Columns.Add("Quantity")
                dt.Columns.Add("AccountCode")
                dt.Columns.Add("WarehouseCode")
                dt.Columns.Add("Remarks")

                Dim acct As String = "", warehouse As String = ""

                con.Open()
                cmd = New SqlCommand("Select gr,branchcode FROM tblbranch WHERE main=1;", con)
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    acct = CStr(rdr("gr"))
                    warehouse = CStr(rdr("branchcode"))
                End If
                con.Close()

                Dim convin_count As Integer = 0
                ''query convin
                con.Open()
                cmd = New SqlCommand("SELECT a.item_code,a.item_name,ISNULL(SUM(a.quantity),0)[quantity],MAX(a.remarks)[remarks] FROM tblconversion a INNER JOIN tblitems b ON a.item_name = b.itemname WHERE a.type='Parent' AND a.status='Closed' AND CAST(a.date_created AS date)='" & datee.Text & "' GROUP BY a.item_code,a.item_name,b.price;", con)
                rdr = cmd.ExecuteReader
                While rdr.Read
                    convin_count += 1
                    dt.Rows.Add(convin_count, rdr("item_code"), rdr("item_name"), rdr("quantity"), acct, warehouse, rdr("remarks"))
                End While
                con.Close()

                Dim dt2 As New DataTable()
                dt2.Columns.Add("Num")
                dt2.Columns.Add("ItemCode")
                dt2.Columns.Add("ItemName")
                dt2.Columns.Add("Quantity")
                dt2.Columns.Add("AccountCode")
                dt2.Columns.Add("WarehouseCode")
                dt2.Columns.Add("Remarks")

                Dim convout_count As Integer = 0
                con.Open()
                cmd = New SqlCommand("SELECT a.item_code,a.item_name,ISNULL(SUM(a.quantity),0)[quantity],MAX(a.remarks)[remarks] FROM tblconversion a INNER JOIN tblitems b ON a.item_name = b.itemname WHERE type='Child' AND a.status='Closed' AND CAST(a.date_created AS date)='" & datee.Text & "' GROUP BY a.item_code,a.item_name,b.price;", con)
                rdr = cmd.ExecuteReader
                While rdr.Read
                    convout_count += 1
                    dt2.Rows.Add(convout_count, rdr("item_code"), rdr("item_name"), rdr("quantity"), acct, warehouse, rdr("remarks"))
                End While
                con.Close()

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
                    .Range("A1:G1").EntireRow.WrapText = True

                    .Range("A1:G1").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DodgerBlue)
                    .Range("A1:G1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)

                    .Range("A1:G" & dt.Rows.Count + 1).HorizontalAlignment = -4108
                    .Range("A1:G" & dt.Rows.Count + 1).VerticalAlignment = -4108
                    .Range("A1:G1").Font.Size = 12


                    .Range("A2:A" & dt.Rows.Count + 1).RowHeight = 50

                    .Range("A2:B" & dt.Rows.Count + 1).RowHeight = 50
                    .Range("A2:C" & dt.Rows.Count + 1).RowHeight = 50
                    .Range("A2:D" & dt.Rows.Count + 1).RowHeight = 50
                    .Range("A2:E" & dt.Rows.Count + 1).RowHeight = 50
                    .Range("A2:F" & dt.Rows.Count + 1).RowHeight = 50
                    .Range("A2:G" & dt.Rows.Count + 1).RowHeight = 50

                    .Range("A2:A" & dt.Rows.Count + 1).ColumnWidth = 30
                    .Range("A2:B" & dt.Rows.Count + 1).ColumnWidth = 30
                    .Range("A2:C" & dt.Rows.Count + 1).ColumnWidth = 30
                    .Range("A2:D" & dt.Rows.Count + 1).ColumnWidth = 30
                    .Range("A2:E" & dt.Rows.Count + 1).ColumnWidth = 30
                    .Range("A2:F" & dt.Rows.Count + 1).ColumnWidth = 30
                    .Range("A2:G" & dt.Rows.Count + 1).ColumnWidth = 30
                End With

                shWorkSheet = bkWorkBook.Sheets(1)
                shWorkSheet.Name = "Conversion Out"

                shWorkSheet.Range("A1").Locked = False

                shWorkSheet.Protect("atlantic")

                shWorkSheet1 = bkWorkBook.Worksheets.Add(, shWorkSheet, , )
                For i As Integer = 0 To dt2.Columns.Count - 1
                    shWorkSheet1.Cells(1, i + 1) = dt2.Columns(i).ToString
                Next
                For i As Integer = 0 To dt2.Rows.Count - 1
                    For j = 0 To dt2.Columns.Count - 1
                        shWorkSheet1.Cells(i + 2, j + 1) = dt2.Rows(i)(j).ToString
                    Next
                Next

                With shWorkSheet1
                    .Range("A1", misValue).EntireRow.Font.Bold = True
                    .Range("A1:G1").EntireRow.WrapText = True

                    .Range("A1:G1").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DodgerBlue)
                    .Range("A1:G1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)

                    .Range("A1:G" & dt2.Rows.Count + 1).HorizontalAlignment = -4108
                    .Range("A1:G" & dt2.Rows.Count + 1).VerticalAlignment = -4108
                    .Range("A1:G1").Font.Size = 12


                    .Range("A2:A" & dt2.Rows.Count + 1).RowHeight = 50

                    .Range("A2:B" & dt2.Rows.Count + 1).RowHeight = 50
                    .Range("A2:C" & dt2.Rows.Count + 1).RowHeight = 50
                    .Range("A2:D" & dt2.Rows.Count + 1).RowHeight = 50
                    .Range("A2:E" & dt2.Rows.Count + 1).RowHeight = 50
                    .Range("A2:F" & dt2.Rows.Count + 1).RowHeight = 50
                    .Range("A2:G" & dt2.Rows.Count + 1).RowHeight = 50

                    .Range("A2:A" & dt2.Rows.Count + 1).ColumnWidth = 30
                    .Range("A2:B" & dt2.Rows.Count + 1).ColumnWidth = 30
                    .Range("A2:C" & dt2.Rows.Count + 1).ColumnWidth = 30
                    .Range("A2:D" & dt2.Rows.Count + 1).ColumnWidth = 30
                    .Range("A2:E" & dt2.Rows.Count + 1).ColumnWidth = 30
                    .Range("A2:F" & dt2.Rows.Count + 1).ColumnWidth = 30
                    .Range("A2:G" & dt2.Rows.Count + 1).ColumnWidth = 30
                End With

                shWorkSheet1 = bkWorkBook.Sheets(2)
                shWorkSheet1.Name = "Conversion In"

                objExcel.Visible = False
                objExcel.Application.DisplayAlerts = False

                objExcel.ActiveWorkbook.Password = "atlantic"

                Dim path As String = IO.Path.GetDirectoryName(SaveFileDialog1.FileName)
                objExcel.ActiveWorkbook.SaveAs(SaveFileDialog1.FileName.ToString())
                objExcel.Quit()

                objExcel = Nothing
                Me.Cursor = Cursors.Default
                MessageBox.Show("Saved" & Environment.NewLine & "Path: " & path, "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Sub coffee_shop()
        Try
            Dim r1 As New Random(), r2 As New Random(), r3 As New Random()

            SaveFileDialog1.Title = "Save As Excel File"
            SaveFileDialog1.Filter = "Excel Document (*.xlsx) | *.xlsx"

            SaveFileDialog1.FileName = datee.Value.ToString("MMddyyyy") & "_coffeeshop"
            If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.Cursor = Cursors.WaitCursor
                Dim objExcel As New Excel.Application
                Dim bkWorkBook As Excel.Workbook
                Dim shWorkSheet As Excel.Worksheet
                Dim misValue As Object = System.Reflection.Missing.Value

                objExcel = New Excel.Application
                bkWorkBook = objExcel.Workbooks.Add
                shWorkSheet = CType(bkWorkBook.ActiveSheet, Excel.Worksheet)

                Dim dt As New DataTable()
                dt.Columns.Add("Num")
                dt.Columns.Add("ItemCode")
                dt.Columns.Add("ItemName")
                dt.Columns.Add("Quantity")
                dt.Columns.Add("AccountCode")
                dt.Columns.Add("WarehouseCode")
                dt.Columns.Add("Remarks")

                Dim acct As String = "", warehouse As String = ""

                con.Open()
                cmd = New SqlCommand("Select gr,branchcode FROM tblbranch WHERE main=1;", con)
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    acct = CStr(rdr("gr"))
                    warehouse = CStr(rdr("branchcode"))
                End If
                con.Close()

                'insert query here
                Dim num As Integer = 0
                con.Open()
                cmd = New SqlCommand("SELECT item_code,item_name,SUM(quantity) AS quantity FROM tblproduction WHERE CAST(date AS date)=@date AND category='Coffee Shop' AND type='Received Item' GROUP BY item_code,item_name;", con)
                cmd.Parameters.AddWithValue("@date", datee.Text)
                rdr = cmd.ExecuteReader
                While rdr.Read
                    num += 1
                    dt.Rows.Add(num, rdr("item_code"), rdr("item_name"), rdr("quantity"), acct, warehouse, "")
                End While
                con.Close()
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
                    .Range("A1:G1").EntireRow.WrapText = True

                    .Range("A1:G1").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DodgerBlue)
                    .Range("A1:G1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)

                    .Range("A1:G" & dt.Rows.Count + 1).HorizontalAlignment = -4108
                    .Range("A1:G" & dt.Rows.Count + 1).VerticalAlignment = -4108
                    .Range("A1:G1").Font.Size = 12


                    .Range("A2:A" & dt.Rows.Count + 1).RowHeight = 50

                    .Range("A2:B" & dt.Rows.Count + 1).RowHeight = 50
                    .Range("A2:C" & dt.Rows.Count + 1).RowHeight = 50
                    .Range("A2:D" & dt.Rows.Count + 1).RowHeight = 50
                    .Range("A2:E" & dt.Rows.Count + 1).RowHeight = 50
                    .Range("A2:F" & dt.Rows.Count + 1).RowHeight = 50
                    .Range("A2:G" & dt.Rows.Count + 1).RowHeight = 50

                    .Range("A2:A" & dt.Rows.Count + 1).ColumnWidth = 30
                    .Range("A2:B" & dt.Rows.Count + 1).ColumnWidth = 30
                    .Range("A2:C" & dt.Rows.Count + 1).ColumnWidth = 30
                    .Range("A2:D" & dt.Rows.Count + 1).ColumnWidth = 30
                    .Range("A2:E" & dt.Rows.Count + 1).ColumnWidth = 30
                    .Range("A2:F" & dt.Rows.Count + 1).ColumnWidth = 30
                    .Range("A2:G" & dt.Rows.Count + 1).ColumnWidth = 30
                End With

                objExcel.Visible = False
                objExcel.Application.DisplayAlerts = False

                objExcel.ActiveWorkbook.Password = "atlantic"

                Dim path As String = IO.Path.GetDirectoryName(SaveFileDialog1.FileName)
                objExcel.ActiveWorkbook.SaveAs(SaveFileDialog1.FileName.ToString())
                objExcel.Quit()

                objExcel = Nothing
                Me.Cursor = Cursors.Default
                MessageBox.Show("Saved" & Environment.NewLine & "Path: " & path, "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub po()
        Try
            Dim r1 As New Random(), r2 As New Random(), r3 As New Random()

            SaveFileDialog1.Title = "Save As Excel File"
            SaveFileDialog1.Filter = "Excel Document (*.xlsx) | *.xlsx"

            SaveFileDialog1.FileName = datee.Value.ToString("MMddyyyy") & "_pullout"
            If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

                Me.Cursor = Cursors.WaitCursor
                Dim objExcel As New Excel.Application
                Dim bkWorkBook As Excel.Workbook
                Dim shWorkSheet As Excel.Worksheet
                Dim misValue As Object = System.Reflection.Missing.Value

                objExcel = New Excel.Application
                bkWorkBook = objExcel.Workbooks.Add
                shWorkSheet = CType(bkWorkBook.ActiveSheet, Excel.Worksheet)
                shWorkSheet.Name = "Pull Out"
                Dim dt As New DataTable()
                dt.Columns.Add("Num")
                dt.Columns.Add("ItemCode")
                dt.Columns.Add("ItemName")
                dt.Columns.Add("Quantity")
                dt.Columns.Add("Price")
                dt.Columns.Add("TotalAmount")

                'insert query here
                Dim num As Integer = 0
                con.Open()
                cmd = New SqlCommand("SELECT prod.item_code,prod.item_name,ISNULL(SUM(prod.quantity),0) [pull_out],ISNULL(SUM(prod.quantity * i.price),0) [total],i.price FROM tblproduction prod INNER JOIN tblitems i ON prod.item_name = i.itemname WHERE CAST(prod.date AS date)='" & datee.Text & "' AND prod.type='Transfer Item' AND prod.status='Completed' AND (prod.remarks LIKE '%po%' OR prod.remarks LIKE '%pull%' OR prod.remarks LIKE '%p.o%') GROUP BY prod.item_code,prod.item_name,prod.remarks,i.price ORDER BY prod.item_name", con)
                rdr = cmd.ExecuteReader
                While rdr.Read
                    num += 1
                    dt.Rows.Add(num, rdr("item_code"), rdr("item_name"), rdr("pull_out"), rdr("price"), rdr("total"))
                End While
                con.Close()

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
                    .Range("A1:F1").EntireRow.WrapText = True

                    .Range("A1:F1").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DodgerBlue)
                    .Range("A1:F1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)

                    .Range("A1:F" & dt.Rows.Count + 1).HorizontalAlignment = -4108
                    .Range("A1:F" & dt.Rows.Count + 1).VerticalAlignment = -4108
                    .Range("A1:F1").Font.Size = 12


                    .Range("A2:A" & dt.Rows.Count + 1).RowHeight = 50

                    .Range("A2:B" & dt.Rows.Count + 1).RowHeight = 50
                    .Range("A2:C" & dt.Rows.Count + 1).RowHeight = 50
                    .Range("A2:D" & dt.Rows.Count + 1).RowHeight = 50
                    .Range("A2:E" & dt.Rows.Count + 1).RowHeight = 50
                    .Range("A2:F" & dt.Rows.Count + 1).RowHeight = 50
                    .Range("A2:G" & dt.Rows.Count + 1).RowHeight = 50

                    .Range("A2:A" & dt.Rows.Count + 1).ColumnWidth = 30
                    .Range("A2:B" & dt.Rows.Count + 1).ColumnWidth = 30
                    .Range("A2:C" & dt.Rows.Count + 1).ColumnWidth = 30
                    .Range("A2:D" & dt.Rows.Count + 1).ColumnWidth = 30
                    .Range("A2:E" & dt.Rows.Count + 1).ColumnWidth = 30
                    .Range("A2:F" & dt.Rows.Count + 1).ColumnWidth = 30
                End With

                objExcel.Visible = False
                objExcel.Application.DisplayAlerts = False

                objExcel.ActiveWorkbook.Password = "atlantic"

                Dim path As String = IO.Path.GetDirectoryName(SaveFileDialog1.FileName)
                objExcel.ActiveWorkbook.SaveAs(SaveFileDialog1.FileName.ToString())
                objExcel.Quit()

                objExcel = Nothing
                Me.Cursor = Cursors.Default
                MessageBox.Show("Saved" & Environment.NewLine & "Path: " & path, "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Sub actualendingbalance()
        Try
            Dim r1 As New Random(), r2 As New Random(), r3 As New Random()

            SaveFileDialog1.Title = "Save As Excel File"
            SaveFileDialog1.Filter = "Excel Document (*.xlsx) | *.xlsx"

            SaveFileDialog1.FileName = datee.Value.ToString("MMddyyyy") & "_actualendbal"
            If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.Cursor = Cursors.WaitCursor
                Dim objExcel As New Excel.Application
                Dim bkWorkBook As Excel.Workbook
                Dim shWorkSheet As Excel.Worksheet
                Dim misValue As Object = System.Reflection.Missing.Value

                objExcel = New Excel.Application
                bkWorkBook = objExcel.Workbooks.Add
                shWorkSheet = CType(bkWorkBook.ActiveSheet, Excel.Worksheet)


                Dim dt As New DataTable()
                dt.Columns.Add("ItemCode")
                dt.Columns.Add("ItemName")
                dt.Columns.Add("Quantity")
                dt.Columns.Add("Price")
                dt.Columns.Add("AccountCode")
                dt.Columns.Add("WarehouseCode")


                Dim acct As String = "", warehouse As String = ""

                con.Open()
                cmd = New SqlCommand("Select gr,branchcode FROM tblbranch WHERE main=1;", con)
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    acct = CStr(rdr("gr"))
                    warehouse = CStr(rdr("branchcode"))
                End If
                con.Close()

                con.Open()
                cmd = New SqlCommand("SELECT a.category,a.item_code,a.item_name,a.quantity,b.price FROM tblproduction a INNER JOIN tblitems b ON a.item_name = b.itemname WHERE CAST(date AS date)='" & datee.Text & "' AND type='Actual Ending Balance'", con)
                rdr = cmd.ExecuteReader
                While rdr.Read
                    dt.Rows.Add(rdr("item_code"), rdr("item_name"), rdr("quantity"), rdr("price"), acct, warehouse)
                End While
                con.Close()

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
                    .Range("A1:F1").EntireRow.WrapText = True

                    .Range("A1:F1").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DodgerBlue)
                    .Range("A1:F1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)

                    .Range("A1:F" & dt.Rows.Count + 1).HorizontalAlignment = -4108
                    .Range("A1:F" & dt.Rows.Count + 1).VerticalAlignment = -4108
                    .Range("A1:F1").Font.Size = 12


                    .Range("A2:A" & dt.Rows.Count + 1).RowHeight = 40

                    .Range("A2:B" & dt.Rows.Count + 1).RowHeight = 40
                    .Range("A2:C" & dt.Rows.Count + 1).RowHeight = 40
                    .Range("A2:D" & dt.Rows.Count + 1).RowHeight = 40
                    .Range("A2:E" & dt.Rows.Count + 1).RowHeight = 40
                    .Range("A2:F" & dt.Rows.Count + 1).RowHeight = 40

                    .Range("A2:A" & dt.Rows.Count + 1).ColumnWidth = 10
                    .Range("A2:B" & dt.Rows.Count + 1).ColumnWidth = 20
                    .Range("A2:C" & dt.Rows.Count + 1).ColumnWidth = 20
                    .Range("A2:D" & dt.Rows.Count + 1).ColumnWidth = 20
                    .Range("A2:E" & dt.Rows.Count + 1).ColumnWidth = 15
                    .Range("A2:F" & dt.Rows.Count + 1).ColumnWidth = 20
                End With

                shWorkSheet.Range("A1").Locked = False

                shWorkSheet.Protect("atlantic")

                objExcel.Visible = False
                objExcel.Application.DisplayAlerts = False

                objExcel.ActiveWorkbook.Password = "atlantic"

                Dim path As String = IO.Path.GetDirectoryName(SaveFileDialog1.FileName)
                objExcel.ActiveWorkbook.SaveAs(SaveFileDialog1.FileName.ToString())
                objExcel.Quit()

                objExcel = Nothing
                Me.Cursor = Cursors.Default
                MessageBox.Show("Saved" & Environment.NewLine & "Path: " & path, "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btnok_Click(sender As Object, e As EventArgs) Handles btnok.Click
        If btnsap.ForeColor = Color.Black Then
            sap()
        ElseIf btnendingbal.ForeColor = Color.Black Then
            endingbalance()
        ElseIf btnconversion.ForeColor = Color.Black Then
            conversion()
        ElseIf btncs.ForeColor = Color.Black Then
            coffee_shop()
        ElseIf btnpo.ForeColor = Color.Black Then
            po()
        ElseIf btnactualendingbalance.ForeColor = Color.Black Then
            actualendingbalance()
        End If
    End Sub

    Private Sub btnsap_Click(sender As Object, e As EventArgs) Handles btnsap.Click
        btnsap.ForeColor = Color.Black
        btnendingbal.ForeColor = Color.White
        btnconversion.ForeColor = Color.White
        btncs.ForeColor = Color.White
        btnpo.ForeColor = Color.White
        btnactualendingbalance.ForeColor = Color.White
    End Sub

    Private Sub btnendingbal_Click(sender As Object, e As EventArgs) Handles btnendingbal.Click
        btnsap.ForeColor = Color.White
        btnconversion.ForeColor = Color.White
        btnendingbal.ForeColor = Color.Black
        btncs.ForeColor = Color.White
        btnpo.ForeColor = Color.White
        btnactualendingbalance.ForeColor = Color.White
    End Sub

    Private Sub btnconversion_Click(sender As Object, e As EventArgs) Handles btnconversion.Click
        btnsap.ForeColor = Color.White
        btnconversion.ForeColor = Color.Black
        btnendingbal.ForeColor = Color.White
        btncs.ForeColor = Color.White
        btnpo.ForeColor = Color.White
        btnactualendingbalance.ForeColor = Color.White
    End Sub

    Private Sub btncs_Click(sender As Object, e As EventArgs) Handles btncs.Click
        btnsap.ForeColor = Color.White
        btnconversion.ForeColor = Color.White
        btnendingbal.ForeColor = Color.White
        btncs.ForeColor = Color.Black
        btnpo.ForeColor = Color.White
        btnactualendingbalance.ForeColor = Color.White
    End Sub

    Private Sub sap_uploading_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnpo_Click(sender As Object, e As EventArgs) Handles btnpo.Click
        btnsap.ForeColor = Color.White
        btnconversion.ForeColor = Color.White
        btnendingbal.ForeColor = Color.White
        btncs.ForeColor = Color.White
        btnpo.ForeColor = Color.Black
        btnactualendingbalance.ForeColor = Color.White
    End Sub

    Private Sub lblclose_Click(sender As Object, e As EventArgs) Handles lblclose.Click
        Me.Close()
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown, MyBase.MouseDown, Label2.MouseDown
        drag = True 'Sets the variable drag to true.
        mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'Sets variable mousey
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove, MyBase.MouseMove, Label2.MouseMove
        'If drag is set to true then move the form accordingly.
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp, MyBase.MouseUp, Label2.MouseUp
        drag = False 'Sets drag to false, so the form does not move according to the code in MouseMove
    End Sub

    Private Sub sap_uploading_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub btnactualendingbalance_Click(sender As Object, e As EventArgs) Handles btnactualendingbalance.Click
        btnsap.ForeColor = Color.White
        btnconversion.ForeColor = Color.White
        btnendingbal.ForeColor = Color.White
        btncs.ForeColor = Color.White
        btnpo.ForeColor = Color.White
        btnactualendingbalance.ForeColor = Color.Black
    End Sub
End Class