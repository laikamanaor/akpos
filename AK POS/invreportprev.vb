Imports System.IO
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows.Forms

Public Class invreportprev
    Dim strconn As String = login.ss
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim sql As String
    Dim objRpt As New crinv
    Dim crRpt As New crinv
    Dim dscmd As SqlDataAdapter
    Dim ds As New DataSet1
    Dim sqlquery As String
    Public condition As String, cashier As String, ctr As Boolean = False

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

    Private Sub invreportprev_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        'Me.WindowState = FormWindowState.Maximized
    End Sub
    Public Function getSystemDate() As DateTime
        Try
            Dim dt As New DateTime()
            connect()
            cmd = New SqlCommand("SELECT GETDATE()", conn)
            dr = cmd.ExecuteReader()
            While dr.Read
                dt = CDate(dr(0).ToString)
            End While
            disconnect()
            Return dt
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            disconnect()
        End Try
    End Function
    Private Sub invreportprev_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ds = New DataSet1
            Dim datenow As String = getSystemDate.ToString("MM/dd/yyyy")
            Dim verified As Integer = 0, invnum As String = ""

            'dito plng icheck n kung verified or not
            sql = "Select * from tblinvsum where" & condition
            connect()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            If dr.Read Then
                invnum = dr("invnum")
                If dr("verify") = 1 Then
                    verified = 1
                    sqlquery = "SELECT tblinvsum.cashier,tblinvsum.invnum,tblinvsum.rems,tblinvsum.invdate,tblinvitems.itemcode,tblinvitems.itemname,tblinvitems.begbal,tblinvitems.itemin,tblinvitems.totalav,tblinvitems.ctrout,tblinvitems.pullout,tblinvitems.endbal,tblinvitems.actualendbal,tblinvitems.variance,tblinvitems.shortover,tblinvitems.shortamt,tblinvitems.overamt FROM tblinvsum RIGHT OUTER JOIN tblinvitems ON tblinvsum.invnum=tblinvitems.invnum where" & condition & " order by tblinvitems.itemcode"
                Else
                    verified = 0
                    sqlquery = "SELECT tblinvsum.cashier,tblinvsum.invnum,tblinvsum.rems,tblinvsum.invdate,tblinvitems.itemcode,tblinvitems.itemname,tblinvitems.begbal,tblinvitems.itemin,tblinvitems.totalav,tblinvitems.ctrout,tblinvitems.pullout,tblinvitems.endbal,tblinvitems.actualendbal,tblinvitems.variance,tblinvitems.shortover FROM tblinvsum RIGHT OUTER JOIN tblinvitems ON tblinvsum.invnum=tblinvitems.invnum where" & condition & " order by tblinvitems.itemcode"
                End If
            End If
            dr.Dispose()
            cmd.Dispose()

            connect()
            sql = procesSQLcrRpt()
            Me.Cursor = Cursors.WaitCursor

            dscmd = New SqlDataAdapter(sql, conn)
            dscmd.Fill(ds.DataTable3)
            'MsgBox(ds.Tables(2).Rows.Count)
            disconnect()

            If verified = 0 Then
                If ds.Tables(2).Rows.Count > 0 Then
                    connect()
                    For i = 0 To ds.Tables(2).Rows.Count - 1
                        If ds.Tables(2).Rows(i).Item("DataColumn15") = "Short" Then
                            sql = "Select * from tblitems where itemcode='" & ds.Tables(2).Rows(i).Item("DataColumn5") & "'"
                            cmd = New SqlCommand(sql, conn)
                            dr = cmd.ExecuteReader
                            If dr.Read Then
                                ds.Tables(2).Rows(i).Item("DataColumn16") = Val(dr("price")) * Val(ds.Tables(2).Rows(i).Item("DataColumn14"))
                            End If
                            dr.Dispose()
                            cmd.Dispose()

                        ElseIf ds.Tables(2).Rows(i).Item("DataColumn15") = "Over" Then
                            sql = "Select * from tblitems where itemcode='" & ds.Tables(2).Rows(i).Item("DataColumn5") & "'"
                            cmd = New SqlCommand(sql, conn)
                            dr = cmd.ExecuteReader
                            If dr.Read Then
                                ds.Tables(2).Rows(i).Item("DataColumn17") = Val(dr("price")) * Val(ds.Tables(2).Rows(i).Item("DataColumn14"))
                            End If
                            dr.Dispose()
                            cmd.Dispose()
                        End If
                    Next
                End If
            Else
                If ds.Tables(2).Rows.Count > 0 Then
                    connect()
                    For i = 0 To ds.Tables(2).Rows.Count - 1
                        If ds.Tables(2).Rows(i).Item("DataColumn15") = "Short" Then
                            sql = "Select * from tblinvitems where invnum='" & invnum & "' and itemcode='" & ds.Tables(2).Rows(i).Item("DataColumn5") & "'"
                            cmd = New SqlCommand(sql, conn)
                            dr = cmd.ExecuteReader
                            If dr.Read Then
                                ds.Tables(2).Rows(i).Item("DataColumn16") = dr("shortamt")
                            End If
                            dr.Dispose()
                            cmd.Dispose()

                        ElseIf ds.Tables(2).Rows(i).Item("DataColumn15") = "Over" Then
                            sql = "Select * from tblinvitems where invnum='" & invnum & "' and itemcode='" & ds.Tables(2).Rows(i).Item("DataColumn5") & "'"
                            cmd = New SqlCommand(sql, conn)
                            dr = cmd.ExecuteReader
                            If dr.Read Then
                                ds.Tables(2).Rows(i).Item("DataColumn17") = dr("overamt")
                            End If
                            dr.Dispose()
                            cmd.Dispose()
                        End If
                    Next
                End If
            End If

            crRpt.SetDataSource(Me.ds.Tables(2))
            CrystalReportViewer1.ReportSource = crRpt
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

    Public Function procesSQLcrRpt() As String
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
                MyText = CType(crRpt.ReportDefinition.ReportObjects("Text" & i + 1), TextObject)
                MyText.Text = Trim(fields(i).ToString())
                If MyText.Text = "tblinvitems.itemcode" Then
                    MyText.Text = "Item Code"
                ElseIf MyText.Text = "tblinvitems.itemname" Then
                    MyText.Text = "Item Name"
                ElseIf MyText.Text = "tblinvitems.begbal" Then
                    MyText.Text = "Beginning  Balance"
                ElseIf MyText.Text = "tblinvitems.itemin" Then
                    MyText.Text = "Item In"
                ElseIf MyText.Text = "tblinvitems.totalav" Then
                    MyText.Text = "Total Quantity"
                ElseIf MyText.Text = "tblinvitems.ctrout" Then
                    MyText.Text = "Counter Out"
                ElseIf MyText.Text = "tblinvitems.pullout" Then
                    MyText.Text = "Pull Out"
                ElseIf MyText.Text = "tblinvitems.endbal" Then
                    MyText.Text = "Ending Balance"
                ElseIf MyText.Text = "tblinvitems.actualendbal" Then
                    MyText.Text = "Actual End Balance"
                ElseIf MyText.Text = "tblinvitems.variance" Then
                    MyText.Text = "Variance"
                ElseIf MyText.Text = "tblinvitems.shortover" Then
                    MyText.Text = "Short/Over"
                End If
            Else
                firstPart = firstPart & fields(i).ToString() & " as DataColumn" & i + 1
                MyText = CType(crRpt.ReportDefinition.ReportObjects("Text" & i + 1), TextObject)

                If MyText.Text = "tblinvsum.cashier" Then
                    MyText.Text = "Cashier"
                End If
            End If
        Next

        MyText = CType(crRpt.ReportDefinition.ReportObjects("Text16"), TextObject)
        MyText.Text = "Short Amount"
        MyText = CType(crRpt.ReportDefinition.ReportObjects("Text17"), TextObject)
        MyText.Text = "Over Amount"

        sql = "SELECT " & firstPart & " " & lastPart
        Return sql
    End Function
End Class