Imports System.IO
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports System.Drawing.Printing
Imports Excel = Microsoft.Office.Interop.Excel
Public Class dsalesprevaccnt
    Dim strconn As String = login.ss
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim sql As String

    'Dim objRpt As New Copycrdsales, ds As New DataSet1
    'Dim objRpt As New CopyofCopycrdsales, ds As New DataSet1
    Dim objRpt As New crdsalesnew, ds As New DataSet1
    Dim sqlquery As String, dscmd As SqlDataAdapter
    Public condition As String, cashr As String, ctr As Boolean = False
    Public printerneym As String, daterange As String

    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function

    Public Sub connect()
        conn = New SqlConnection
        conn.ConnectionString = strconn
        If conn.State <> ConnectionState.Open Then
            conn.Open()
        End If
    End Sub

    Public Sub disconnect()
        conn = New SqlConnection
        conn.ConnectionString = strconn
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
    End Sub

    Private Sub dailysalesprev_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        'Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub dailysalesprev_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ds = New DataSet1

        lbldate.Text = daterange
        Exit Sub

        Try
            Me.Cursor = Cursors.WaitCursor
            sqlquery = "SELECT datecreated,transnum,servicetype,subtotal,disctype,less,delcharge,vat,amtdue,comment,vatsales,ornum,customer,tinnum FROM tbltransaction where" & condition
            connect()
            sql = procesSQL()
            Me.Cursor = Cursors.WaitCursor

            dscmd = New SqlDataAdapter(sql, conn)
            dscmd.Fill(ds.DataTable2)
            'MsgBox(ds.Tables(1).Rows.Count)
            disconnect()

            connect()
            For i = 0 To ds.Tables(1).Rows.Count - 1
                Dim tempprice As Double = 0

                ds.Tables(1).Rows(i).Item("DataColumn16") = Val(ds.Tables(1).Rows(i).Item("DataColumn4")) - (Val(ds.Tables(1).Rows(i).Item("DataColumn9")) - Val(ds.Tables(1).Rows(i).Item("DataColumn7")))

                sql = "Select * from tblorder where transnum='" & ds.Tables(1).Rows(i).Item("DataColumn2").ToString & "'"
                'sql = "Select * from tblorder where transnum='2017-0221000003'"
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                While dr.Read
                    tempprice += Val(dr("price")) * (Val(dr("dscnt")) / 100) * Val(dr("qty"))
                    'MsgBox(dr("price").ToString & " * " & (Val(dr("dscnt").ToString) * 100).ToString & " * " & dr("qty").ToString)

                End While
                dr.Dispose()
                cmd.Dispose()

                sql = "Select * from tbltransaction where transnum='" & ds.Tables(1).Rows(i).Item("DataColumn2").ToString & "'"
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                While dr.Read
                    ds.Tables(1).Rows(i).Item("DataColumn19") = dr("remarks")
                End While
                dr.Dispose()
                cmd.Dispose()

                ds.Tables(1).Rows(i).Item("DataColumn10") = ds.Tables(1).Rows(i).Item("DataColumn19") & ds.Tables(1).Rows(i).Item("DataColumn10")

                ds.Tables(1).Rows(i).Item("DataColumn15") = tempprice

                ds.Tables(1).Rows(i).Item("DataColumn17") = Val(ds.Tables(1).Rows(i).Item("DataColumn15")) + Val(ds.Tables(1).Rows(i).Item("DataColumn16"))

                'dinagdag for vat exempt sales
                If ds.Tables(1).Rows(i).Item("DataColumn5").ToString.Contains("Senior") Or ds.Tables(1).Rows(i).Item("DataColumn5").ToString.Contains("Pwd") Then
                    ds.Tables(1).Rows(i).Item("DataColumn18") = Val(Val(ds.Tables(1).Rows(i).Item("DataColumn4")) / 1.12).ToString("n2")
                    If Not ds.Tables(1).Rows(i).Item("DataColumn10").ToString.Contains("W/ GRPM") Then
                        ds.Tables(1).Rows(i).Item("DataColumn8") = 0
                        ds.Tables(1).Rows(i).Item("DataColumn11") = 0
                    Else
                        Dim based As Double = ds.Tables(1).Rows(i).Item("DataColumn8") + ds.Tables(1).Rows(i).Item("DataColumn11")
                        Dim vinclude As Double = ds.Tables(1).Rows(i).Item("DataColumn4") - based
                        ds.Tables(1).Rows(i).Item("DataColumn11") = vinclude / 1.12
                        ds.Tables(1).Rows(i).Item("DataColumn8") = vinclude - ds.Tables(1).Rows(i).Item("DataColumn11")
                        ds.Tables(1).Rows(i).Item("DataColumn18") = based / 1.12
                    End If

                    Dim sp As Double = ds.Tables(1).Rows(i).Item("DataColumn18") * 0.8
                    'If (ds.Tables(1).Rows(i).Item("DataColumn9") > ds.Tables(1).Rows(i).Item("DataColumn18")) Or (sp.ToString("n2") <> Val(ds.Tables(1).Rows(i).Item("DataColumn9"))) Then
                    'ds.Tables(1).Rows(i).Item("DataColumn17") = Val(ds.Tables(1).Rows(i).Item("DataColumn4")) - Val(ds.Tables(1).Rows(i).Item("DataColumn9"))
                    'Else
                    ds.Tables(1).Rows(i).Item("DataColumn17") = (Val(ds.Tables(1).Rows(i).Item("DataColumn18")) + Val(ds.Tables(1).Rows(i).Item("DataColumn11")) + Val(ds.Tables(1).Rows(i).Item("DataColumn8"))) - (Val(ds.Tables(1).Rows(i).Item("DataColumn9")) - Val(ds.Tables(1).Rows(i).Item("DataColumn7")))
                    'End If
                Else
                    ds.Tables(1).Rows(i).Item("DataColumn18") = 0
                End If

                If ds.Tables(1).Rows(i).Item("DataColumn10").ToString.Contains("% off") And ds.Tables(1).Rows(i).Item("DataColumn5") = "" Then
                    ds.Tables(1).Rows(i).Item("DataColumn5") = "Special Disc"
                End If
            Next

            Dim c As Integer
            Dim doctoprint As New System.Drawing.Printing.PrintDocument()
            doctoprint.PrinterSettings.PrinterName = GetDefaultPrinter() 'DefaultPrinterName() 'printerneym '
            Dim rawKind As Integer
            For c = 0 To doctoprint.PrinterSettings.PaperSizes.Count - 1
                If doctoprint.PrinterSettings.PaperSizes(c).PaperName = "Letter 8 1/2 x 13 in" Then
                    rawKind = CInt(doctoprint.PrinterSettings.PaperSizes(c).GetType().GetField("kind", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes(c)))
                    Exit For
                End If
            Next

            objRpt.PrintOptions.PaperOrientation = PaperOrientation.Landscape
            objRpt.PrintOptions.PaperSize = CType(rawKind, CrystalDecisions.Shared.PaperSize)

            objRpt.SetDataSource(Me.ds.Tables(1))
            CrystalReportViewer1.ReportSource = objRpt
            CrystalReportViewer1.Refresh()
            Me.Cursor = Cursors.Default
            'toprint
            '///objRpt.PrintToPrinter(1, False, 0, 0)

        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Public Function procesSQL() As String
        Dim inSql As String
        Dim firstPart As String
        Dim lastPart As String
        Dim selectStart As Integer
        Dim fromStart As Integer
        Dim fields As String()
        Dim i As Integer
        Dim MyText As TextObject
        'Dim mycol As FieldObject

        inSql = sqlquery
        'inSql = inSql.ToUpper

        selectStart = inSql.IndexOf("SELECT")
        fromStart = inSql.IndexOf("FROM")
        selectStart = selectStart + 6
        firstPart = inSql.Substring(selectStart, (fromStart - selectStart))
        lastPart = inSql.Substring(fromStart, inSql.Length - fromStart)

        fields = firstPart.Split(",")
        firstPart = ""
        'MsgBox(fields.Length)
        For i = 0 To fields.Length - 1
            If i > 0 Then
                firstPart = firstPart & " , " & fields(i).ToString() & " as DataColumn" & i + 1
                MyText = CType(objRpt.ReportDefinition.ReportObjects("Text" & i + 1), TextObject)
                MyText.Text = Trim(fields(i).ToString())
                If MyText.Text = "transnum" Then
                    MyText.Text = "Transaction #"
                ElseIf MyText.Text = "servicetype" Then
                    MyText.Text = "Service Type"
                ElseIf MyText.Text = "subtotal" Then
                    MyText.Text = "Subtotal"
                ElseIf MyText.Text = "disctype" Then
                    MyText.Text = "Discount Type"
                ElseIf MyText.Text = "delcharge" Then
                    MyText.Text = "Delivery Charge"
                ElseIf MyText.Text = "less" Then
                    MyText.Text = "Disc %"
                ElseIf MyText.Text = "vatsales" Then
                    MyText.Text = "Vat Sales"
                ElseIf MyText.Text = "vat" Then
                    MyText.Text = "Vat Amount"
                ElseIf MyText.Text = "amtdue" Then
                    MyText.Text = "Total Amount Due"
                ElseIf MyText.Text = "remarks" Then
                    MyText.Text = "Remarks"
                ElseIf MyText.Text = "ornum" Then
                    MyText.Text = "OR number"
                ElseIf MyText.Text = "customer" Then
                    MyText.Text = "Customer Name"
                ElseIf MyText.Text = "tinnum" Then
                    MyText.Text = "TIN #"
                End If
            Else
                firstPart = firstPart & fields(i).ToString() & " as DataColumn" & i + 1
                MyText = CType(objRpt.ReportDefinition.ReportObjects("Text" & i + 1), TextObject)
                MyText.Text = Trim(fields(i).ToString())
                If MyText.Text = "datecreated" Then
                    MyText.Text = "Date and Time"
                End If
            End If
        Next

        MyText = CType(objRpt.ReportDefinition.ReportObjects("TextCashier"), TextObject)
        MyText.Text = cashr
        If MyText.Text = "" Then
            ' MyTextc = CType(objRpt.ReportDefinition.ReportObjects("Textcheck"), TextObject)
            ' MyTextc.Text = ""
            ' MyTextn = CType(objRpt.ReportDefinition.ReportObjects("Textnoted"), TextObject)
            ' MyTextn.Text = ""
            MyText = CType(objRpt.ReportDefinition.ReportObjects("TextCashier1"), TextObject)
            MyText.Text = ""
        End If

        MyText = CType(objRpt.ReportDefinition.ReportObjects("Text17"), TextObject)
        MyText.Text = "Total Disc Amount"
        MyText = CType(objRpt.ReportDefinition.ReportObjects("Text18"), TextObject)
        MyText.Text = "Vat Exempt Sales"

        sql = "SELECT " & firstPart & " " & lastPart

        Return sql
    End Function

    Public Sub papersize()
        Dim c As Integer
        Dim doctoprint As New System.Drawing.Printing.PrintDocument()
        doctoprint.PrinterSettings.PrinterName = "EPSON L1300 Series"
        Dim rawKind As Integer
        For c = 0 To doctoprint.PrinterSettings.PaperSizes.Count - 1
            If doctoprint.PrinterSettings.PaperSizes(c).PaperName = "OR Receipts" Then
                rawKind = CInt(doctoprint.PrinterSettings.PaperSizes(c).GetType().GetField("kind", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes(c)))
                Exit For
            End If
        Next

        objRpt.PrintOptions.PaperSize = CType(rawKind, CrystalDecisions.Shared.PaperSize)

    End Sub

    Public Shared Function DefaultPrinterName() As String
        Dim oPS As New System.Drawing.Printing.PrinterSettings

        Try
            DefaultPrinterName = oPS.PrinterName
        Catch ex As System.Exception
            DefaultPrinterName = ""
        Finally
            oPS = Nothing
        End Try
    End Function

    Public Function GetDefaultPrinter() As String
        Dim settings As PrinterSettings = New PrinterSettings()
        Return settings.PrinterName
    End Function

    Private Sub btnview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            grd.Rows.Clear()

            sql = "Select * from tbltransaction where" & condition
            connect()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            While dr.Read
                grd.Rows.Add(dr("transid"), Format(dr("transdate"), "yyyy/MM/dd"), dr("transnum"), dr("subtotal"), 0, 0, dr("disctype"), dr("less"), 0, dr("delcharge"), dr("vatsales"), dr("vat"), 0, dr("amtdue"), dr("remarks") & dr("comment"), dr("remarks"), Format(dr("transdate"), "yyyyMMdd"))
                If Not cmbdate.Items.Contains(Format(dr("transdate"), "yyyyMMdd")) Then
                    cmbdate.Items.Add(Format(dr("transdate"), "yyyyMMdd"))
                End If
                If Not cmbdisc.Items.Contains(dr("disctype")) And dr("disctype") <> "" Then
                    cmbdisc.Items.Add(dr("disctype"))
                End If
            End While
            dr.Dispose()
            cmd.Dispose()

            For Each row In grd.Rows
                Dim tempprice As Double = 0
                Dim totalfree As Double = 0
                sql = "Select * from tblorder where transnum='" & grd.Rows(row.index).Cells(2).Value & "'"
                'sql = "Select * from tblorder where transnum='2017-0221000003'"
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                While dr.Read
                    tempprice += Val(dr("price")) * (Val(dr("dscnt")) / 100) * Val(dr("qty"))
                    totalfree += Val(dr("free"))
                End While
                dr.Dispose()
                cmd.Dispose()

                Dim temp1 As Double = Val(grd.Rows(row.index).Cells(3).Value) - (Val(grd.Rows(row.index).Cells(13).Value) - Val(grd.Rows(row.index).Cells(9).Value)) '3 '11 '8
                Dim temp2 As Double = tempprice
                'ds.Tables(1).Rows(i).Item("DataColumn17") = Val(ds.Tables(1).Rows(i).Item("DataColumn15")) + Val(ds.Tables(1).Rows(i).Item("DataColumn16"))
                Dim discamt As Double = temp1 + temp2

                grd.Rows(row.index).Cells(8).Value = discamt
                grd.Rows(row.index).Cells(5).Value = totalfree

                If grd.Rows(row.index).Cells(6).Value.ToString.Contains("Senior") Or grd.Rows(row.index).Cells(6).Value.ToString.Contains("Pwd") Then
                    grd.Rows(row.index).Cells(12).Value = Val(Val(grd.Rows(row.index).Cells(3).Value) / 1.12).ToString("n2")
                    If Not grd.Rows(row.index).Cells(15).Value.ToString.Contains("W/ GRPM") Then
                        grd.Rows(row.index).Cells(10).Value = 0
                        grd.Rows(row.index).Cells(11).Value = 0
                    Else
                        Dim based As Double = Val(grd.Rows(row.index).Cells(10).Value) + Val(grd.Rows(row.index).Cells(11).Value)
                        Dim vinclude As Double = Val(grd.Rows(row.index).Cells(3).Value) - based
                        grd.Rows(row.index).Cells(10).Value = vinclude / 1.12
                        grd.Rows(row.index).Cells(11).Value = vinclude - Val(grd.Rows(row.index).Cells(10).Value)
                        grd.Rows(row.index).Cells(12).Value = based / 1.12
                    End If

                    Dim sp As Double = Val(grd.Rows(row.index).Cells(12).Value) * 0.8
                    'If (ds.Tables(1).Rows(i).Item("DataColumn9") > ds.Tables(1).Rows(i).Item("DataColumn18")) Or (sp.ToString("n2") <> Val(ds.Tables(1).Rows(i).Item("DataColumn9"))) Then
                    'ds.Tables(1).Rows(i).Item("DataColumn17") = Val(ds.Tables(1).Rows(i).Item("DataColumn4")) - Val(ds.Tables(1).Rows(i).Item("DataColumn9"))
                    'Else
                    grd.Rows(row.index).Cells(8).Value = Val((Val(grd.Rows(row.index).Cells(12).Value) + Val(grd.Rows(row.index).Cells(10).Value) + Val(grd.Rows(row.index).Cells(11).Value)) - (Val(grd.Rows(row.index).Cells(13).Value) - Val(grd.Rows(row.index).Cells(9).Value))).ToString("n2")
                    'End If
                Else
                    grd.Rows(row.index).Cells(12).Value = 0
                End If


                If grd.Rows(row.index).Cells(15).Value.ToString.Contains("% off") Then
                    grd.Rows(row.index).Cells(6).Value = "Special Disc"
                    If Not cmbdisc.Items.Contains("Special Disc") Then
                        cmbdisc.Items.Add("Special Disc")
                    End If
                    grd.Rows(row.index).Cells(4).Value = Val(grd.Rows(row.index).Cells(8).Value)
                End If
                grd.Rows(row.index).Cells(4).Value = Val(grd.Rows(row.index).Cells(4).Value) + Val(grd.Rows(row.index).Cells(3).Value) + Val(grd.Rows(row.index).Cells(5).Value)
            Next

            grd.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grd.Columns(3).DefaultCellStyle.Format = "n2"
            grd.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grd.Columns(4).DefaultCellStyle.Format = "n2"
            grd.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grd.Columns(5).DefaultCellStyle.Format = "n2"
            grd.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grd.Columns(7).DefaultCellStyle.Format = "n2"
            grd.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grd.Columns(8).DefaultCellStyle.Format = "n2"
            grd.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grd.Columns(9).DefaultCellStyle.Format = "n2"
            grd.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grd.Columns(10).DefaultCellStyle.Format = "n2"
            grd.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grd.Columns(11).DefaultCellStyle.Format = "n2"
            grd.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grd.Columns(12).DefaultCellStyle.Format = "n2"
            grd.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grd.Columns(13).DefaultCellStyle.Format = "n2"

            If grd.RowCount <> 0 Then
                btnexport.Enabled = True
            End If

            Me.Cursor = Cursors.Default
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Private Sub btnexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexport.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim objExcel As New Excel.Application
            Dim bkWorkBook As Excel.Workbook
            Dim shWorkSheet As Excel.Worksheet
            Dim shWorkSheet1 As Excel.Worksheet
            Dim shWorkSheet2 As Excel.Worksheet
            Dim shWorkSheet3 As Excel.Worksheet
            Dim shWorkSheet4 As Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value

            Dim i As Integer = 0
            Dim j As Integer = 0

            Dim sfilename As String = "Sales" & "_" & daterange & ".xls"

            objExcel = New Excel.Application
            bkWorkBook = objExcel.Workbooks.Add
            shWorkSheet = CType(bkWorkBook.ActiveSheet, Excel.Worksheet)

            With shWorkSheet
                .Range("A1", misValue).EntireRow.Font.Bold = True
                .Range("A1:N1").EntireRow.WrapText = True
                .Range("A1:N" & grd.RowCount + 1).HorizontalAlignment = -4108
                .Range("A1:N" & grd.RowCount + 1).VerticalAlignment = -4108
                .Range("A1:N" & grd.RowCount + 1).Font.Size = 10
                'Set Clipboard Copy Mode     
                grd.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
                grd.SelectAll()
                grd.RowHeadersVisible = False

                'Get the content from Grid for Clipboard     
                'Dim str As String = TryCast(grd.GetClipboardContent().GetData(DataFormats.UnicodeText), String)
                Dim str As String = grd.GetClipboardContent().GetData(DataFormats.UnicodeText)

                'Set the content to Clipboard     
                Clipboard.SetText(str, TextDataFormat.UnicodeText) 'TextDataFormat.UnicodeText)

                'Identify and select the range of cells in Excel to paste the clipboard data.     
                .Range("A1:M1", misValue).Select()

                'Paste the clipboard data     
                .Paste()
                Clipboard.Clear()

            End With

            For i = 0 To grd.RowCount - 1
                'shWorkSheet.Cells(i + 2, 1) = grd.Rows(i).Cells(1).Value
                shWorkSheet.Cells(i + 2, 3).NumberFormat = "#,##0.00"   'SUBTOTAL
                shWorkSheet.Cells(i + 2, 4).NumberFormat = "#,##0.00"   'SUBPLUSPLUS
                shWorkSheet.Cells(i + 2, 5).NumberFormat = "#,##0.00"
                shWorkSheet.Cells(i + 2, 7).NumberFormat = "#,##0.00"
                shWorkSheet.Cells(i + 2, 8).NumberFormat = "#,##0.00"
                'sum
                'shWorkSheet.Cells(i + 2, 4).value = "=D" & i + 2 & & "+E" & i + 2 &
                shWorkSheet.Cells(i + 2, 4).value = "=SUMIF(F" & i + 2 & ":F" & i + 2 & ",""Special Disc"",H" & i + 2 & ":H" & i + 2 & ")+C" & i + 2 & "+E" & i + 2
                shWorkSheet.Cells(i + 2, 9).NumberFormat = "#,##0.00"
                shWorkSheet.Cells(i + 2, 10).NumberFormat = "#,##0.00"
                shWorkSheet.Cells(i + 2, 11).NumberFormat = "#,##0.00"
                shWorkSheet.Cells(i + 2, 12).NumberFormat = "#,##0.00"
                shWorkSheet.Cells(i + 2, 13).NumberFormat = "#,##0.00"
            Next
            'shWorkSheet.Range("C" & sumall).Value =


            'format alignment
            shWorkSheet.Range("C2", "C" & grd.RowCount + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            shWorkSheet.Range("D2", "D" & grd.RowCount + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            shWorkSheet.Range("E2", "E" & grd.RowCount + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            shWorkSheet.Range("G2", "G" & grd.RowCount + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            shWorkSheet.Range("H2", "H" & grd.RowCount + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            shWorkSheet.Range("I2", "I" & grd.RowCount + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            shWorkSheet.Range("J2", "J" & grd.RowCount + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            shWorkSheet.Range("K2", "K" & grd.RowCount + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            shWorkSheet.Range("L2", "L" & grd.RowCount + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            shWorkSheet.Range("M2", "M" & grd.RowCount + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight

            'sum
            shWorkSheet.Range("C" & (grd.RowCount + 4).ToString).Value = "=SUM(C1:C" & grd.RowCount + 1 & ")"
            shWorkSheet.Range("C" & grd.RowCount + 4, "C" & grd.RowCount + 4).Interior.Color = RGB(255, 255, 0)
            shWorkSheet.Range("C" & grd.RowCount + 4, "C" & grd.RowCount + 4).NumberFormat = "#,##0.00"

            shWorkSheet.Range("D" & (grd.RowCount + 4).ToString).Value = "=SUM(D1:D" & grd.RowCount + 1 & ")"
            shWorkSheet.Range("D" & grd.RowCount + 4, "D" & grd.RowCount + 4).Interior.Color = RGB(255, 255, 0)
            shWorkSheet.Range("D" & grd.RowCount + 4, "D" & grd.RowCount + 4).NumberFormat = "#,##0.00"

            shWorkSheet.Range("E" & (grd.RowCount + 4).ToString).Value = "=SUM(E1:E" & grd.RowCount + 1 & ")"
            shWorkSheet.Range("E" & grd.RowCount + 4, "E" & grd.RowCount + 4).Interior.Color = RGB(255, 255, 0)
            shWorkSheet.Range("E" & grd.RowCount + 4, "E" & grd.RowCount + 4).NumberFormat = "#,##0.00"

            shWorkSheet.Range("H" & (grd.RowCount + 4).ToString).Value = "=SUM(H1:H" & grd.RowCount + 1 & ")"
            shWorkSheet.Range("H" & grd.RowCount + 4, "H" & grd.RowCount + 4).Interior.Color = RGB(255, 255, 0)
            shWorkSheet.Range("H" & grd.RowCount + 4, "H" & grd.RowCount + 4).NumberFormat = "#,##0.00"

            shWorkSheet.Range("I" & (grd.RowCount + 4).ToString).Value = "=SUM(I1:I" & grd.RowCount + 1 & ")"
            shWorkSheet.Range("I" & grd.RowCount + 4, "I" & grd.RowCount + 4).Interior.Color = RGB(255, 255, 0)
            shWorkSheet.Range("I" & grd.RowCount + 4, "I" & grd.RowCount + 4).NumberFormat = "#,##0.00"

            shWorkSheet.Range("J" & (grd.RowCount + 4).ToString).Value = "=SUM(J1:J" & grd.RowCount + 1 & ")"
            shWorkSheet.Range("J" & grd.RowCount + 4, "J" & grd.RowCount + 4).Interior.Color = RGB(255, 255, 0)
            shWorkSheet.Range("J" & grd.RowCount + 4, "J" & grd.RowCount + 4).NumberFormat = "#,##0.00"

            shWorkSheet.Range("K" & (grd.RowCount + 4).ToString).Value = "=SUM(K1:K" & grd.RowCount + 1 & ")"
            shWorkSheet.Range("K" & grd.RowCount + 4, "K" & grd.RowCount + 4).Interior.Color = RGB(255, 255, 0)
            shWorkSheet.Range("K" & grd.RowCount + 4, "K" & grd.RowCount + 4).NumberFormat = "#,##0.00"

            shWorkSheet.Range("L" & (grd.RowCount + 4).ToString).Value = "=SUM(L1:L" & grd.RowCount + 1 & ")"
            shWorkSheet.Range("L" & grd.RowCount + 4, "L" & grd.RowCount + 4).Interior.Color = RGB(255, 255, 0)
            shWorkSheet.Range("L" & grd.RowCount + 4, "L" & grd.RowCount + 4).NumberFormat = "#,##0.00"

            shWorkSheet.Range("M" & (grd.RowCount + 4).ToString).Value = "=SUM(M1:M" & grd.RowCount + 1 & ")"
            shWorkSheet.Range("M" & grd.RowCount + 4, "M" & grd.RowCount + 4).Interior.Color = RGB(255, 255, 0)
            shWorkSheet.Range("M" & grd.RowCount + 4, "M" & grd.RowCount + 4).NumberFormat = "#,##0.00"

            'SUMMARY
            shWorkSheet.Cells(grd.RowCount + 8, 2) = "GL Accounts"
            shWorkSheet.Cells(grd.RowCount + 9, 2) = "Cash"
            shWorkSheet.Cells(grd.RowCount + 9, 3) = "=M" & (grd.RowCount + 4)
            shWorkSheet.Cells(grd.RowCount + 10, 2) = "Free"
            shWorkSheet.Cells(grd.RowCount + 10, 3) = "=E" & (grd.RowCount + 4)
            For c = 0 To cmbdisc.Items.Count - 1
                cmbdisc.SelectedIndex = c
                shWorkSheet.Cells(c + grd.RowCount + 11, 2) = cmbdisc.SelectedItem
                shWorkSheet.Cells(c + grd.RowCount + 11, 3) = "=SUMIF(F:F,B" & c + grd.RowCount + 11 & ",H:H)"
            Next

            shWorkSheet.Cells(cmbdisc.Items.Count + grd.RowCount + 11, 2) = "Other Income - Delivery Fee"
            shWorkSheet.Cells(cmbdisc.Items.Count + grd.RowCount + 11, 4) = "=I" & (grd.RowCount + 4)
            shWorkSheet.Cells(cmbdisc.Items.Count + grd.RowCount + 12, 2) = "Sales - Retail"                    'grd.RowCount + 10, 3
            If cmbdisc.Items.Contains("Special Disc") Then
                shWorkSheet.Cells(cmbdisc.Items.Count + grd.RowCount + 12, 4) = "=C" & grd.RowCount + 4 & "+C" & grd.RowCount + 10 & "+C" & cmbdisc.Items.Count + grd.RowCount + 10 & "-L" & grd.RowCount + 4   ' get the special disc kung anung pnt
            Else
                shWorkSheet.Cells(cmbdisc.Items.Count + grd.RowCount + 12, 4) = "=C" & grd.RowCount + 4 & "+C" & grd.RowCount + 10 & "-L" & grd.RowCount + 4   ' get the special disc kung anung pnt
            End If
            shWorkSheet.Cells(cmbdisc.Items.Count + grd.RowCount + 13, 2) = "Exempt Sales"
            shWorkSheet.Cells(cmbdisc.Items.Count + grd.RowCount + 13, 4) = "=L" & (grd.RowCount + 4)
            'SUM
            Dim sumall As Integer = (cmbdisc.Items.Count + grd.RowCount + 15)
            shWorkSheet.Range("C" & sumall).Value = "=SUM(C" & grd.RowCount + 8 & ":C" & sumall - 1 & ")"
            shWorkSheet.Range("C" & sumall, "C" & sumall).Interior.Color = RGB(255, 255, 0)
            shWorkSheet.Range("C" & sumall, "C" & sumall).NumberFormat = "#,##0.00"
            shWorkSheet.Range("D" & sumall).Value = "=SUM(D" & grd.RowCount + 8 & ":D" & sumall - 1 & ")"
            shWorkSheet.Range("D" & sumall, "D" & sumall).Interior.Color = RGB(255, 255, 0)
            shWorkSheet.Range("D" & sumall, "D" & sumall).NumberFormat = "#,##0.00"


            'SHEET2//////////////////////////////////////////////////////// 
            shWorkSheet1 = bkWorkBook.Worksheets.Add(, shWorkSheet, , )
            shWorkSheet1.Name = "OINV"

            shWorkSheet1.Cells(1, 1) = "DocNum"
            shWorkSheet1.Cells(2, 1) = ""
            shWorkSheet1.Cells(1, 2) = "DocType"
            shWorkSheet1.Cells(2, 2) = ""
            shWorkSheet1.Cells(1, 3) = "DocDate"
            shWorkSheet1.Cells(2, 3) = "DocDate"
            shWorkSheet1.Cells(1, 4) = "DocDueDate"
            shWorkSheet1.Cells(2, 4) = "DocDueDate"
            shWorkSheet1.Cells(1, 5) = "CardCode"
            shWorkSheet1.Cells(2, 5) = "Customer"
            shWorkSheet1.Cells(1, 6) = "NumAtCard"
            shWorkSheet1.Cells(2, 6) = "Customer Ref. No."
            shWorkSheet1.Cells(1, 7) = "Comments"
            shWorkSheet1.Cells(2, 7) = "Comments"
            Dim ctr As Integer = 0
            For i = 0 To grd.Rows.Count + 1
                If i > 2 Then
                    Dim cmbint As Integer = cmbdate.Items.Count
                    If ctr <> cmbint Then
                        ctr += 1
                        cmbdate.SelectedIndex = ctr - 1
                        shWorkSheet1.Cells(i, 1) = ctr
                        shWorkSheet1.Cells(i, 2) = "dDocument_Service"
                        shWorkSheet1.Cells(i, 3) = cmbdate.SelectedItem
                        shWorkSheet1.Cells(i, 4) = cmbdate.SelectedItem
                        shWorkSheet1.Cells(i, 5) = "Cash Customer"
                    End If
                End If
            Next


            'SHEET3/////////////////////////////////////////////////////
            shWorkSheet2 = bkWorkBook.Worksheets.Add(, shWorkSheet1, , )
            shWorkSheet2.Name = "INV1"


            shWorkSheet2.Cells(1, 1) = "ParentKey"
            shWorkSheet2.Cells(2, 1) = "DocNum"
            shWorkSheet2.Cells(1, 2) = "ItemDescription"
            shWorkSheet2.Cells(2, 2) = "Item No."
            shWorkSheet2.Cells(1, 3) = "AccountCode"
            shWorkSheet2.Cells(2, 3) = "G/L Account"
            shWorkSheet2.Cells(1, 4) = "UnitPrice"
            shWorkSheet2.Cells(2, 4) = "TotalAmount"
            shWorkSheet2.Cells(1, 5) = ""
            shWorkSheet2.Cells(2, 5) = ""
            shWorkSheet2.Cells(1, 6) = ""
            shWorkSheet2.Cells(2, 6) = ""
            shWorkSheet2.Cells(1, 7) = "VatGroup"
            shWorkSheet2.Cells(2, 7) = "Tax Code"
            shWorkSheet2.Cells(1, 8) = "WTLiable"
            shWorkSheet2.Cells(2, 8) = "Wtax Liable"

            ctr = 0
            Dim cnt As Integer = 0
            For c = 0 To cmbdate.Items.Count - 1
                cmbdate.SelectedIndex = c
                cnt += 1
                For i = 0 To grd.Rows.Count - 1
                    If grd.Rows(i).Cells(16).Value.ToString = cmbdate.SelectedItem Then
                        ctr += 1
                        shWorkSheet2.Cells(i + 3, 1) = cnt
                        shWorkSheet2.Cells(i + 3, 2) = "Trans no:" & grd.Rows(i).Cells(0).Value
                        shWorkSheet2.Cells(i + 3, 3) = "Sales - Retail"
                        shWorkSheet2.Cells(i + 3, 4) = "=Sheet1!D" & i + 2
                        shWorkSheet2.Cells(i + 3, 4).NumberFormat = "#,##0.00"
                        shWorkSheet2.Cells(i + 3, 5) = "=Sheet1!D" & i + 2
                        shWorkSheet2.Cells(i + 3, 5).NumberFormat = "#,##0.00"
                        shWorkSheet2.Cells(i + 3, 6) = "=D" & ctr + 2 & "-E" & ctr + 2
                        shWorkSheet2.Cells(i + 3, 6).NumberFormat = "-      "
                    End If
                Next
            Next

            'SUM
            shWorkSheet2.Range("D" & (grd.RowCount + 4).ToString).Value = "=SUM(D1:D" & grd.RowCount + 2 & ")"
            shWorkSheet2.Range("D" & grd.RowCount + 4, "D" & grd.RowCount + 4).Interior.Color = RGB(255, 255, 0)
            shWorkSheet2.Range("D" & grd.RowCount + 4, "D" & grd.RowCount + 4).NumberFormat = "#,##0.00"

            '=D801-Sheet1!E870
            shWorkSheet2.Range("D" & (grd.RowCount + 6).ToString).Value = "=D" & (grd.RowCount + 4).ToString & "-Sheet1!D" & (grd.RowCount + 4).ToString



            'SHEET4//////////////////////////////////////////////////////////
            shWorkSheet3 = bkWorkBook.Worksheets.Add(, shWorkSheet2, , )
            shWorkSheet3.Name = "DISC1"

            shWorkSheet3.Cells(1, 1) = "DocNum"
            shWorkSheet3.Cells(2, 1) = ""
            shWorkSheet3.Cells(1, 2) = "DocType"
            shWorkSheet3.Cells(2, 2) = ""
            shWorkSheet3.Cells(1, 3) = "DocDate"
            shWorkSheet3.Cells(2, 3) = "DocDate"
            shWorkSheet3.Cells(1, 4) = "DocDueDate"
            shWorkSheet3.Cells(2, 4) = "DocDueDate"
            shWorkSheet3.Cells(1, 5) = "CardCode"
            shWorkSheet3.Cells(2, 5) = "Customer"
            shWorkSheet3.Cells(1, 6) = "NumAtCard"
            shWorkSheet3.Cells(2, 6) = "Customer Ref. No."
            shWorkSheet3.Cells(1, 7) = "Comments"
            shWorkSheet3.Cells(2, 7) = "Comments"
            ctr = 0
            For i = 0 To grd.Rows.Count + 1
                If i > 2 Then
                    Dim cmbint As Integer = cmbdate.Items.Count
                    If ctr <> cmbint Then
                        ctr += 1
                        cmbdate.SelectedIndex = ctr - 1
                        shWorkSheet3.Cells(i, 1) = ctr
                        shWorkSheet3.Cells(i, 2) = "dDocument_Service"
                        shWorkSheet3.Cells(i, 3) = cmbdate.SelectedItem
                        shWorkSheet3.Cells(i, 4) = cmbdate.SelectedItem
                        shWorkSheet3.Cells(i, 5) = "Cash Customer"
                    End If
                End If
            Next


            'SHEET5///////////////////////////////////////////////////////
            shWorkSheet4 = bkWorkBook.Worksheets.Add(, shWorkSheet3, , )
            shWorkSheet4.Name = "DISC2"


            shWorkSheet4.Cells(1, 1) = "ParentKey"
            shWorkSheet4.Cells(2, 1) = "DocNum"
            shWorkSheet4.Cells(1, 2) = "ItemDescription"
            shWorkSheet4.Cells(2, 2) = "Item No."
            shWorkSheet4.Cells(1, 3) = "AccountCode"
            shWorkSheet4.Cells(2, 3) = "G/L Account"
            shWorkSheet4.Cells(1, 4) = "UnitPrice"
            shWorkSheet4.Cells(2, 4) = "TotalAmount"
            shWorkSheet4.Cells(1, 5) = ""
            shWorkSheet4.Cells(2, 5) = ""
            shWorkSheet4.Cells(1, 6) = ""
            shWorkSheet4.Cells(2, 6) = ""
            shWorkSheet4.Cells(1, 7) = "VatGroup"
            shWorkSheet4.Cells(2, 7) = "Tax Code"
            shWorkSheet4.Cells(1, 8) = "WTLiable"
            shWorkSheet4.Cells(2, 8) = "Wtax Liable"
            shWorkSheet4.Cells(1, 11) = "AccountCode"
            shWorkSheet4.Cells(2, 11) = "G/L Account"

            ctr = 0
            cnt = 0
            For c = 0 To cmbdate.Items.Count - 1
                cmbdate.SelectedIndex = c
                cnt += 1
                For i = 0 To grd.Rows.Count - 1
                    If grd.Rows(i).Cells(16).Value.ToString = cmbdate.SelectedItem Then
                        If grd.Rows(i).Cells(6).Value <> "" Then
                            ctr += 1
                            shWorkSheet4.Cells(ctr + 2, 1) = cnt
                            shWorkSheet4.Cells(ctr + 2, 2) = "Trans no:" & grd.Rows(i).Cells(0).Value
                            shWorkSheet4.Cells(ctr + 2, 3) = grd.Rows(i).Cells(6).Value
                            shWorkSheet4.Cells(ctr + 2, 4) = grd.Rows(i).Cells(8).Value
                            shWorkSheet4.Cells(ctr + 2, 4).NumberFormat = "#,##0.00"
                            shWorkSheet4.Cells(ctr + 2, 5) = grd.Rows(i).Cells(8).Value
                            shWorkSheet4.Cells(ctr + 2, 5).NumberFormat = "#,##0.00"
                            shWorkSheet4.Cells(ctr + 2, 6) = "=D" & ctr + 2 & "-E" & ctr + 2
                            shWorkSheet4.Cells(ctr + 2, 6).NumberFormat = "-      "
                        End If
                        If grd.Rows(i).Cells(5).Value <> 0 Then
                            ctr += 1
                            shWorkSheet4.Cells(ctr + 2, 1) = cnt
                            shWorkSheet4.Cells(ctr + 2, 2) = "Trans no:" & grd.Rows(i).Cells(0).Value
                            shWorkSheet4.Cells(ctr + 2, 3) = "Sales Adj"
                            shWorkSheet4.Cells(ctr + 2, 4) = grd.Rows(i).Cells(5).Value
                            shWorkSheet4.Cells(ctr + 2, 4).NumberFormat = "#,##0.00"
                            shWorkSheet4.Cells(ctr + 2, 5) = grd.Rows(i).Cells(5).Value
                            shWorkSheet4.Cells(ctr + 2, 5).NumberFormat = "#,##0.00"
                            shWorkSheet4.Cells(ctr + 2, 6) = "=D" & ctr + 2 & "-E" & ctr + 2
                            shWorkSheet4.Cells(ctr + 2, 6).NumberFormat = "-      "
                        End If
                    End If
                Next
            Next

            'SUM
            shWorkSheet4.Range("D" & (ctr + 4).ToString).Value = "=SUM(D1:D" & ctr + 2 & ")"
            shWorkSheet4.Range("D" & ctr + 4, "D" & ctr + 4).Interior.Color = RGB(255, 255, 0)
            shWorkSheet4.Range("D" & ctr + 4, "D" & ctr + 4).NumberFormat = "#,##0.00"

            '=D801-Sheet1!E870
            shWorkSheet4.Range("D" & (ctr + 6).ToString).Value = "=D" & (ctr + 4).ToString & "-Sheet1!H" & (grd.RowCount + 4).ToString & "-Sheet1!E" & (grd.RowCount + 4).ToString
            For c = 0 To cmbdisc.Items.Count - 1
                cmbdisc.SelectedIndex = c
                shWorkSheet4.Cells(c + 3, 11) = cmbdisc.SelectedItem
            Next
            shWorkSheet4.Cells(cmbdisc.Items.Count + 3, 11) = "Sales Adj"

            'lagyan ng title na red door kit tska ung date na sakop ng report
            shWorkSheet.Range("A1").EntireRow.Insert()
            shWorkSheet.Range("A2").EntireRow.Insert()
            shWorkSheet.Range("A3").EntireRow.Insert()
            shWorkSheet.Cells(1, 1) = "RED DOOR KITCHEN"
            shWorkSheet.Cells(2, 1) = "Sales_" & daterange
            shWorkSheet.Cells(1, 1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)

            Me.Cursor = Cursors.Default

            objExcel.Visible = False
            'objExcel.Application.DisplayAlerts = False

            Dim password As String = "RDKadmin"
            'objExcel.ActiveWorkbook.SaveAs(Application.StartupPath & "sample.xls", FileFormat:=51, )
            bkWorkBook.SaveAs(Filename:=Application.StartupPath & "\template\" & sfilename, FileFormat:=51, Password:=password, CreateBackup:=False)

            bkWorkBook.Close(True, misValue, misValue)
            objExcel.Quit()

            'objExcel = Nothing

            releaseObject(bkWorkBook)
            releaseObject(shWorkSheet)
            releaseObject(shWorkSheet1)
            releaseObject(objExcel)

            MessageBox.Show("Data Successfully Exported") ' & sfilename)
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As System.Runtime.InteropServices.COMException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
            MessageBox.Show("Exception Occured while releasing object " + ex.ToString())
        Finally
            GC.Collect()
        End Try
    End Sub
End Class