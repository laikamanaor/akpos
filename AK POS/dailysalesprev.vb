Imports System.IO
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports System.Drawing.Printing

Public Class dailysalesprev
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
    Public printerneym As String

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
                ElseIf MyText.Text = "comment" Then
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
End Class