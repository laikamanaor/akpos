Imports System.IO
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows.Forms

Public Class itemsprintprev
    Dim strconn As String = login.ss
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim sql As String

    Dim sqlquery As String
    Dim objRpt As New critems
    Dim ds As New DataSet1
    Dim dscmd As SqlDataAdapter
    Public condition As String

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

    Private Sub itemsprintprev_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ds = New DataSet1
            sqlquery = "SELECT category,itemcode,itemname,description,price,discontinued FROM tblitems" & condition
            connect()
            sql = processSql()
            Me.Cursor = Cursors.WaitCursor


            dscmd = New SqlDataAdapter(sql, conn)
            dscmd.Fill(ds.DataTable4)

            For i = 0 To ds.Tables(3).Rows.Count - 1
                If ds.Tables(3).Rows(i).Item("DataColumn6") = "0" Then
                    ds.Tables(3).Rows(i).Item("DataColumn6") = "Active"
                ElseIf ds.Tables(3).Rows(i).Item("DataColumn6") = "1" Then
                    ds.Tables(3).Rows(i).Item("DataColumn6") = "Discontinued"
                End If
            Next
            'MsgBox(ds.Tables(3).Rows.Count)
            disconnect()

            objRpt.SetDataSource(Me.ds.Tables(3))
            CrystalReportViewer1.ReportSource = objRpt
            CrystalReportViewer1.Refresh()

            Me.Cursor = Cursors.Default

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

    Public Function processSql() As String

        Dim inSql As String
        Dim firstPart As String
        Dim lastPart As String
        Dim selectStart As Integer
        Dim fromStart As Integer
        Dim fields As String()
        Dim i As Integer
        Dim MyText As TextObject

        inSql = sqlquery
        selectStart = inSql.IndexOf("SELECT")
        fromStart = inSql.IndexOf("FROM")
        selectStart = selectStart + 6
        firstPart = inSql.Substring(selectStart, (fromStart - selectStart))
        lastPart = inSql.Substring(fromStart, inSql.Length - fromStart)

        fields = firstPart.Split(",")
        firstPart = ""

        For i = 0 To fields.Length - 1
            If i > 0 Then
                firstPart = firstPart & "," & fields(i).ToString() & " as DataColumn" & i + 1
                MyText = CType(objRpt.ReportDefinition.ReportObjects("Text" & i + 1), TextObject)
                MyText.Text = Trim(fields(i).ToString())
                If MyText.Text = "itemcode" Then
                    MyText.Text = "Item Code"
                ElseIf MyText.Text = "itemname" Then
                    MyText.Text = "Item Name"
                ElseIf MyText.Text = "description" Then
                    MyText.Text = "Description"
                ElseIf MyText.Text = "price" Then
                    MyText.Text = "Price"
                ElseIf MyText.Text = "discontinued" Then
                    MyText.Text = "Status"
                End If
            Else
                firstPart = firstPart & fields(i).ToString() & " as DataColumn" & i + 1
                MyText = CType(objRpt.ReportDefinition.ReportObjects("Text" & i + 1), TextObject)
                MyText.Text = Trim(fields(i).ToString())
                If MyText.Text = "category" Then
                    MyText.Text = "Category"
                End If
            End If
        Next

        sql = "SELECT " & firstPart & " " & lastPart
        Return sql

    End Function
End Class