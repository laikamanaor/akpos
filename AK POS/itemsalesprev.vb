Imports System.IO
Imports System.Data.SqlClient
Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Windows.Forms

Public Class itemsalesprev
    Dim strconn As String = login.ss
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim sql As String, sqlfrst As String

    Dim objRpt As New crisales, ds As New DataSet1
    Dim sqlquery As String, dscmd As SqlDataAdapter
    Public condition As String, cashr As String, isales As Boolean = False
    Public d1 As String, d2 As String

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

    Private Sub itemsalesprev_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ds = New DataSet1

        Try
            sqlfrst = "Select * from tbltransaction where" & condition
            connect()
            cmd = New SqlCommand(sqlfrst, conn)
            dr = cmd.ExecuteReader
            While dr.Read
                sqlquery = "SELECT itemname,qty,totalprice FROM tblorder where transnum='" & dr("transnum") & "'"
                sql = procesSQL()
                dscmd = New SqlDataAdapter(sql, conn)
                dscmd.Fill(ds.DataTable6)
            End While
            dr.Dispose()
            cmd.Dispose()

            Me.Cursor = Cursors.WaitCursor

            'MsgBox(ds.Tables(5).Rows.Count)
            disconnect()

            objRpt.SetDataSource(Me.ds.Tables(5))
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
            MsgBox(ex.Message, MsgBoxStyle.Information)
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
                If MyText.Text = "qty" Then
                    MyText.Text = "Quantity"
                ElseIf MyText.Text = "totalprice" Then
                    MyText.Text = "Sales Amount"
                ElseIf MyText.Text = "disctype" Then
                    MyText.Text = "Discount Type"
                ElseIf MyText.Text = "delcharge" Then
                    MyText.Text = "Delivery Charge"
                ElseIf MyText.Text = "less" Then
                    MyText.Text = "Disc %"
                ElseIf MyText.Text = "vat" Then
                    MyText.Text = "Vat"
                ElseIf MyText.Text = "amtdue" Then
                    MyText.Text = "Total Amount Due"
                ElseIf MyText.Text = "remarks" Then
                    MyText.Text = "Remarks"
                End If
            Else
                firstPart = firstPart & fields(i).ToString() & " as DataColumn" & i + 1
                MyText = CType(objRpt.ReportDefinition.ReportObjects("Text" & i + 1), TextObject)
                MyText.Text = Trim(fields(i).ToString())
                If MyText.Text = "itemname" Then
                    MyText.Text = "Item Name"
                End If
            End If
        Next

        MyText = CType(objRpt.ReportDefinition.ReportObjects("Text5"), TextObject)
        MyText.Text = d1 & " - " & d2

        sql = "SELECT " & firstPart & " " & lastPart

        Return sql
    End Function
End Class