Imports System.Data.SqlClient
Imports CrystalDecisions
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows.Forms

Public Class receiptkit
    Dim strconn As String = login.ss
    Dim sql As String
    Dim conn As SqlConnection
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Dim dscmd As New SqlDataAdapter
    Public objRpt As New crkitchen
    Public ds As New DataSet1
    Public sqlquery As String
    Public constring As String
    Dim trnum As String = "", servicetype As String = ""

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

    Private Sub receiptprev_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ds = New DataSet1
        Try
            sqlquery = "SELECT TOP 1 * FROM tbltransaction order by transid DESC"
            connect()
            cmd = New SqlCommand(sqlquery, conn)
            dr = cmd.ExecuteReader
            If dr.Read Then
                trnum = dr("transnum")
            End If
            dr.Dispose()
            cmd.Dispose()


            sqlquery = "SELECT tbltransaction.transnum,tblorder.qty,tblorder.itemname,tblorder.request  FROM tbltransaction RIGHT OUTER JOIN tblorder ON tbltransaction.transnum=tblorder.transnum where tbltransaction.transnum='" & trnum & "' and (tblorder.category='Noodles' or tblorder.category='Combo' or tblorder.category='Meal') order by tbltransaction.transid DESC"
            connect()
            sql = procesSQL()
            Me.Cursor = Cursors.WaitCursor
            dscmd = New SqlDataAdapter(sql, conn)
            dscmd.Fill(ds.DataTable13)
            'MsgBox(ds.Tables(0).Rows.Count)
            disconnect()

            objRpt.SetDataSource(Me.ds.Tables(12))
            CrystalReportViewer1.ReportSource = objRpt
            CrystalReportViewer1.Refresh()

            Me.Cursor = Cursors.Default

            'Dim a As String = MsgBox("Do you want to print receipt?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "")
            If ds.Tables(12).Rows.Count > 0 Then
                'MsgBox(ds.Tables(12).Rows(0).Item(0))
                objRpt.PrintToPrinter(1, False, 0, 0)
            End If

            Me.Close()

        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
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
                'MyText = CType(objRpt.ReportDefinition.ReportObjects("Text" & i + 1), TextObject)
                'MyText.Text = Trim(fields(i).ToString())
            Else
                firstPart = firstPart & fields(i).ToString() & " as DataColumn" & i + 1
                'MyText = CType(objRpt.ReportDefinition.ReportObjects("Text" & i + 1), TextObject)
                'MyText.Text = Trim(fields(i).ToString())
            End If
        Next


        sql = "SELECT " & firstPart & " " & lastPart

        Return sql
    End Function
End Class