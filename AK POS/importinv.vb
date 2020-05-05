Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Globalization

Public Class importinv
    Dim SheetList As New ArrayList
    Dim MyConnection As OleDbConnection
    Dim DtSet As System.Data.DataSet
    Dim MyCommand As OleDbDataAdapter
    Dim ii As Integer
    Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
    Dim ds As New DataSet
    Dim dv As DataView

    Dim strconn As String = login.ss
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim sql As String

    Dim derrors As Boolean = False
    Public importcnf As Boolean = False

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

    Private Sub importitems_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            DtSet.Clear()
            txtPath.Text = ""
            btnLoadData.Enabled = False
            btncheck.Enabled = False
            btnadd.Enabled = False
            dgvdata.Rows.Clear()
            dgvdata.Columns.Clear()
        Catch ex As Exception
            ' MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        With OpenFileDialog1
            .FileName = "Excel File"
            .Filter = "Excel Worksheets|*.xls;*.xlsx"
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                txtPath.Text = .FileName
                If txtPath.Text <> "" Then
                    btnLoadData.Enabled = True
                    btncheck.Enabled = False
                    btnadd.Enabled = False
                Else
                    btnLoadData.Enabled = False
                End If
            End If
        End With
    End Sub

    Private Sub btnLoadData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadData.Click
        Dim sheetName As String = ""
        Try
            MyConnection = New OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & txtPath.Text & "';Extended Properties=""Excel 8.0;HDR={1}""")

            Dim objExcel As Excel.Application
            Dim objWorkBook As Excel.Workbook
            Dim objWorkSheets As Excel.Worksheet
            Dim ExcelSheetName As String = ""

            objExcel = CreateObject("Excel.Application")
            objWorkBook = objExcel.Workbooks.Open(txtPath.Text)

            For Each objWorkSheets In objWorkBook.Worksheets
                SheetList.Add(objWorkSheets.Name)
            Next

            MyCommand = New OleDbDataAdapter("select * from [" & SheetList(0) & "$]", MyConnection)
            MyCommand.TableMappings.Add("Table", "Net-informations.com")
            'MsgBox(SheetList(0).ToString)
            DtSet = New System.Data.DataSet
            MyCommand.Fill(DtSet)
            dgvdata.DataSource = DtSet.Tables(0)
            ' MyCommand.Dispose()
            MyConnection.Close()

            objWorkBook.Close()
            objExcel.Quit()

            releaseObject(objWorkBook)
            releaseObject(objExcel)

            Me.Cursor = Cursors.Default

            dgvData.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True
            'dgvdata.ColumnHeadersHeight = 40
            dgvdata.Columns(0).Width = 200
            dgvdata.Columns(1).Width = 200

            If dgvdata.Rows.Count <> 0 Then
                btncheck.Enabled = True
            Else
                btncheck.Enabled = False
            End If

            derrors = False

            'remember: sa price kung nde sya numeric di sya iloload

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

    Private Sub btncheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncheck.Click
        Try
            'dito magaganap ung checking of errors
            '////check yung per column if wlng magkaparehas n item code and item name

            checkcode()
            checkqty()

            If derrors = False Then
                MsgBox("Click add button to continue.", MsgBoxStyle.Information, "")
                btnadd.Enabled = True
            Else
                MsgBox("Error occurred. Please correct the highlighted errors and try again.", MsgBoxStyle.Critical, "")
                btnadd.Enabled = False
            End If

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

    Public Sub checkcode()
        Try
            'check if category in the datagrid are in the tblcat
            connect()
            For Each row As DataGridViewRow In dgvdata.Rows
                'check if there's no apostrophe
                If dgvdata.Rows(row.Index).Cells(0).Value.ToString.Contains("'") Then
                    dgvdata.Rows(row.Index).Cells(0).Value = dgvdata.Rows(row.Index).Cells(0).Value.ToString.Replace("'", "")
                End If

                'check if null
                If dgvdata.Rows(row.Index).Cells(0).Value.ToString = "" Then
                    dgvdata.ClearSelection()
                    dgvdata.Rows(row.Index).Cells(0).ToolTipText = "Item Code should not be null."
                    dgvdata.Rows(row.Index).Cells(0).Selected = True
                    dgvdata.Rows(row.Index).Cells(0).Style.BackColor = Color.Yellow
                    dgvdata.ClearSelection()
                    derrors = True
                End If

                If dgvdata.Rows(row.Index).Cells(0).Value.ToString <> "" Then
                    sql = "Select * from tblitems where itemcode='" & dgvdata.Rows(row.Index).Cells(0).Value & "'"
                    cmd = New SqlCommand(sql, conn)
                    dr = cmd.ExecuteReader
                    If dr.Read Then
                        If dr("discontinued").ToString = "1" Then
                            'gawing tooltip ung mga msgbox
                            'kc iibahin ko nlng ng background color ung cells na may error
                            dgvdata.ClearSelection()
                            dgvdata.Rows(row.Index).Cells(0).ToolTipText = "Item " & dr("itemname") & " is discontinued."
                            dgvdata.Rows(row.Index).Cells(0).Selected = True
                            dgvdata.Rows(row.Index).Cells(0).Style.BackColor = Color.Yellow
                            dgvdata.ClearSelection()
                            derrors = True
                        Else
                            dgvdata.Rows(row.Index).Cells(0).Value = dgvdata.Rows(row.Index).Cells(0).Value.ToString.ToUpper
                        End If
                    Else
                        ' MsgBox("Cannot found category " & dgvdata.Rows(row.Index).Cells(0).Value.ToString & ".")
                        dgvdata.ClearSelection()
                        dgvdata.Rows(row.Index).Cells(0).ToolTipText = "Cannot found item code " & dgvdata.Rows(row.Index).Cells(0).Value.ToString & "."
                        dgvdata.Rows(row.Index).Cells(0).Selected = True
                        dgvdata.Rows(row.Index).Cells(0).Style.BackColor = Color.Yellow
                        dgvdata.ClearSelection()
                        derrors = True
                    End If
                    dr.Dispose()
                    cmd.Dispose()
                End If
            Next


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

    Public Sub checkqty()
        Try
            'check if category in the datagrid are in the tblcat
            connect()
            For Each row As DataGridViewRow In dgvdata.Rows
                'check if there's no apostrophe
                If dgvdata.Rows(row.Index).Cells(1).Value.ToString.Contains("'") Then
                    dgvdata.Rows(row.Index).Cells(1).Value = dgvdata.Rows(row.Index).Cells(1).Value.ToString.Replace("'", "")
                End If

                'check if null
                If dgvdata.Rows(row.Index).Cells(1).Value.ToString = "" Then
                    dgvdata.ClearSelection()
                    dgvdata.Rows(row.Index).Cells(1).ToolTipText = "Item in (Qty) should not be null."
                    dgvdata.Rows(row.Index).Cells(1).Selected = True
                    dgvdata.Rows(row.Index).Cells(1).Style.BackColor = Color.Yellow
                    dgvdata.ClearSelection()
                    derrors = True
                End If

                If dgvdata.Rows(row.Index).Cells(1).Value.ToString <> "" Then
                    'check if numeric
                    If IsNumeric(dgvdata.Rows(row.Index).Cells(1).Value.ToString) = False Then
                        dgvdata.ClearSelection()
                        dgvdata.Rows(row.Index).Cells(1).ToolTipText = "Qty " & dgvdata.Rows(row.Index).Cells(1).Value.ToString & " should be a number."
                        dgvdata.Rows(row.Index).Cells(1).Selected = True
                        dgvdata.Rows(row.Index).Cells(1).Style.BackColor = Color.Yellow
                        dgvdata.ClearSelection()
                        derrors = True
                    End If
                End If
            Next

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

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        Try
            If derrors = False Then
                confirm.ShowDialog()
                If importcnf = True Then
                    computeinv()
                    
                    MsgBox("Successfully Added.", MsgBoxStyle.Information, "")
                    Me.Close()
                End If
            End If
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

    Public Sub computeinv()
        Try
            connect()
            For Each row As DataGridViewRow In dgvdata.Rows
                Dim commd As String = ""
                Dim lastinvnum As String = "", lastin As Double, lastav As Double, lastendbal As Double, lastvar As Double, rems As String = ""
                Dim iname As String = "", qty As Double

                sql = "Select TOP 1 * from tblinvsum order by invsumid DESC"
                Dim cmd2 As SqlCommand = New SqlCommand(sql, conn)
                Dim dr2 As SqlDataReader = cmd2.ExecuteReader
                If dr2.Read Then
                    lastinvnum = dr2("invnum")
                    sql = "Select * from tblinvitems where itemcode='" & dgvdata.Rows(row.Index).Cells(0).Value & "' and invnum='" & dr2("invnum") & "'"
                    dr2.Dispose()
                    cmd2.Dispose()

                    Dim cmd1 As SqlCommand = New SqlCommand(sql, conn)
                    Dim dr1 As SqlDataReader = cmd1.ExecuteReader
                    If dr1.Read Then
                        'get the last value then update
                        lastin = dr1("itemin") + dgvdata.Rows(row.Index).Cells(1).Value
                        lastav = dr1("totalav") + dgvdata.Rows(row.Index).Cells(1).Value
                        lastendbal = dr1("endbal") + dgvdata.Rows(row.Index).Cells(1).Value
                        lastvar = dr1("actualendbal") - lastendbal
                        If lastvar < 0 Then
                            rems = "Short"
                        ElseIf lastvar > 0 Then
                            rems = "Over"
                        End If

                        commd = "Update"

                    Else
                        'insert
                        dr1.Dispose()
                        cmd1.Dispose()

                        'MsgBox(dgvdata.Rows(row.Index).Cells(1).Value.ToString)

                        qty = dgvdata.Rows(row.Index).Cells(1).Value.ToString

                        If dgvdata.Rows(row.Index).Cells(1).Value < 0 Then
                            rems = "Short"
                        ElseIf dgvdata.Rows(row.Index).Cells(1).Value > 0 Then
                            rems = "Over"
                        End If

                        sql = "Select * from tblitems where itemcode='" & dgvdata.Rows(row.Index).Cells(0).Value & "'"
                        cmd = New SqlCommand(sql, conn)
                        dr = cmd.ExecuteReader
                        If dr.Read Then
                            iname = dr("itemname")
                        End If
                        dr.Dispose()
                        cmd.Dispose()

                        commd = "Insert"
                    End If
                    dr1.Dispose()
                    cmd1.Dispose()
                End If
                dr2.Dispose()
                cmd2.Dispose()

                If commd = "Update" Then
                    'MsgBox(dgvdata.Rows(row.Index).Cells(0).Value.ToString)
                    sql = "Update tblinvitems set itemin='" & lastin & "',totalav='" & lastav & "',endbal='" & lastendbal & "',variance='" & lastvar & "',shortover='" & rems & "' where itemcode='" & dgvdata.Rows(row.Index).Cells(0).Value & "' and invnum='" & lastinvnum & "'"
                    cmd = New SqlCommand(sql, conn)
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()
                Else
                    'insert
                    sql = "Insert into tblinvitems (invnum, itemcode, itemname, begbal, itemin, totalav, ctrout, pullout, endbal, actualendbal, variance, shortover, status) values('" & lastinvnum & "', '" & dgvdata.Rows(row.Index).Cells(0).Value.ToString.ToUpper & "', '" & iname & "', '0', '" & qty & "', '" & qty & "', '0', '0', '" & qty & "', '0', '" & qty & "', '" & rems & "', '1')"
                    cmd = New SqlCommand(sql, conn)
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()
                End If
            Next

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

    Private Sub importinv_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class