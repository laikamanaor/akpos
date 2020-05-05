Imports System.Data.SqlClient
Imports Microsoft.Office.Core
Imports Excel = Microsoft.Office.Interop.Excel
Imports ExcelAutoFormat = Microsoft.Office.Interop.Excel.XlRangeAutoFormat
Imports Microsoft.Office.Interop
Imports System.Xml.XPath
Imports System.Data
Imports System.Xml
Imports AK_POS.items_class
Imports AK_POS.connection_class
Public Class items2
    Dim itemc As New items_class, cc As New connection_class
    Dim strconn As String = cc.conString
    Dim con As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim transaction As SqlTransaction
    Public Shared cnfrm As Boolean = False
    Dim offset As Integer = 0, totalCount As Integer = 0, totalPage As Integer = 0, currentPage As Integer = 1, rowsFetch As Integer = 50
    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Dim frm As New additem()
        frm.lblheader.Text = "ADD ITEM"
        frm.ShowDialog()
        btnrefresh.PerformClick()
    End Sub
    Private Sub items2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblcount.Text = totalPage
        loadCategories()
        totalCount = countLoadItems()
        totalPage = Math.Ceiling(totalCount / rowsFetch) * 1
        loadItems()
    End Sub

    Public Sub loadCategories()
        Try
            cmbcategory.Items.Clear()
            cmbcategory.Items.Add("All")
            Dim dtResult As New DataTable()
            dtResult = itemc.loadCategories()
            For Each r0w As DataRow In dtResult.Rows
                cmbcategory.Items.Add(r0w("category"))
            Next
            cmbcategory.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Public Sub loadItems()
        Try
            Dim dtResult As New DataTable(), auto As New AutoCompleteStringCollection
            itemc.setDiscontinued(IIf(chck.Checked, 1, 0))
            itemc.setCategory(cmbcategory.Text)
            itemc.setICategory(cmbcategory.SelectedIndex)
            itemc.setItem(txtsearch.Text)
            dtResult = itemc.loadItems(offset, rowsFetch)
            dgv.Rows.Clear()
            For Each r0w As DataRow In dtResult.Rows
                auto.Add(r0w("itemname"))
                dgv.Rows.Add(r0w("itemid"), r0w("category"), r0w("itemcode"), r0w("itemname"), r0w("description"), CDbl(r0w("price")).ToString("n2"), r0w("deposit"), CDbl(r0w("deposit_price")).ToString("n2"))
            Next
            txtsearch.AutoCompleteCustomSource = auto
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Public Function countLoadItems() As Integer
        itemc.setDiscontinued(IIf(chck.Checked, 1, 0))
        itemc.setCategory(cmbcategory.Text)
        itemc.setICategory(cmbcategory.SelectedIndex)
        itemc.setItem(txtsearch.Text)
        Dim result As Integer = itemc.countItems
        Return result
    End Function
    Private Sub chck_CheckedChanged(sender As Object, e As EventArgs) Handles chck.CheckedChanged
        refreshh()
    End Sub

    Private Sub btnrefresh_Click(sender As Object, e As EventArgs) Handles btnrefresh.Click
        txtsearch.Text = ""
        cmbcategory.SelectedIndex = 0
        refreshh()
    End Sub

    Private Sub cmbcategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbcategory.SelectedIndexChanged
        refreshh()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        refreshh()
    End Sub
    Public Sub refreshh()
        currentPage = 1
        offset = 0
        totalCount = countLoadItems()
        totalPage = Math.Ceiling(totalCount / rowsFetch) * 1
        lblcount.Text = "Page: " & currentPage & "/" & totalPage
        loadItems()
    End Sub
    Private Sub txtsearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            refreshh()
        End If
    End Sub

    Private Sub items2_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F5 Then
            loadItems()
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    ''' <summary>
    '''  get latest inventory number
    ''' </summary>
    Public Function getInvID() As String
        Dim id As String = ""
        Dim date_ As New DateTime()
        con.Open()
        cmd = New SqlCommand("Select TOP 1 invnum, datecreated from tblinvsum WHERE area='" & "Sales" & "' order by invsumid DESC", con)
        rdr = cmd.ExecuteReader()
        If rdr.Read() Then
            id = rdr("invnum")
            date_ = CDate(rdr("datecreated"))
        End If
        con.Close()
        Return id
    End Function
    ''' <summary>
    ''' check stock of item before update discontinue column
    ''' </summary>
    ''' <returns></returns>
    Public Function checkStock() As Boolean
        Try
            Dim invnum As String = getInvID(), result As Boolean = False, endbal As Double = 0.00
            con.Open()
            cmd = New SqlCommand("SELECT endbal FROM tblinvitems WHERE invnum=@invnum AND itemname=@itemname;", con)
            cmd.Parameters.AddWithValue("@invnum", invnum)
            cmd.Parameters.AddWithValue("@itemname", dgv.CurrentRow.Cells("itemname").Value)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                endbal = CDbl(rdr("endbal"))
            End If
            con.Close()
            If endbal <> 0 Then
                Result = True
            Else
                Result = False
            End If
            Return result
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function
    ''' <summary>
    ''' add to inventory
    ''' </summary>
    Public Sub addInventory()
        Try
            Dim invnum As String = getInvID(), result As Boolean = False
            Using connection As New SqlConnection(cc.conString)
                Dim cmdd As New SqlCommand()
                cmdd.Connection = connection
                connection.Open()
                transaction = connection.BeginTransaction()
                cmdd.Transaction = transaction

                cmdd.Parameters.Clear()
                cmdd.CommandText = "updateDiscontinued"
                cmdd.CommandType = CommandType.StoredProcedure
                cmdd.Parameters.AddWithValue("@itemid", dgv.CurrentRow.Cells("itemid").Value)
                cmdd.Parameters.AddWithValue("@discontinued", IIf(chck.Checked = True, 0, 1))
                cmdd.ExecuteNonQuery()

                cmdd.Parameters.Clear()
                cmdd.CommandText = "SELECT invid FROM tblinvitems WHERE invnum=@invnum AND itemname=@itemname;"
                cmdd.CommandType = CommandType.Text
                cmdd.Parameters.AddWithValue("@invnum", invnum)
                cmdd.Parameters.AddWithValue("@itemname", dgv.CurrentRow.Cells("itemname").Value)
                rdr = cmdd.ExecuteReader
                If rdr.Read Then
                    result = True
                Else
                    result = False
                End If
                rdr.Close()

                If result Then
                    cmdd.Parameters.Clear()
                    cmdd.CommandText = "updateInvStatus"
                    cmdd.CommandType = CommandType.StoredProcedure
                    cmdd.Parameters.AddWithValue("@itemid", dgv.CurrentRow.Cells("itemid").Value)
                    cmdd.Parameters.AddWithValue("@status", IIf(chck.Checked = True, 1, 0))
                    cmdd.ExecuteNonQuery()
                Else
                    cmdd.Parameters.Clear()
                    cmdd.CommandText = "insertContinueInvitems"
                    cmdd.CommandType = CommandType.StoredProcedure
                    cmdd.Parameters.AddWithValue("@itemid", dgv.CurrentRow.Cells("itemid").Value)
                    cmdd.ExecuteNonQuery()
                End If
                transaction.Commit()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Try
                transaction.Rollback()
            Catch ex2 As Exception
                MessageBox.Show(ex2.ToString)
            End Try
        End Try
    End Sub

    Private Sub btnprev_Click(sender As Object, e As EventArgs) Handles btnprev.Click
        If offset > 0 Then
            offset -= rowsFetch
            currentPage -= 1
            loadItems()
            totalCount = countLoadItems()
            totalPage = Math.Ceiling(totalCount / rowsFetch) * 1
            lblcount.Text = "Page: " & currentPage & "/" & totalPage
        Else
            offset = 0
            currentPage = 1
            lblcount.Text = "Page: " & currentPage & "/" & totalPage
        End If
    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        If e.ColumnIndex = 8 Then
            If checkStock() And chck.Checked = False Then
                MessageBox.Show("You can't discontinue item that have stock", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            Dim a As String = MsgBox("Are you sure you want to " & IIf(chck.Checked, "continue", "discontinue") & " this item?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Add Item")
            If a = vbYes Then
                confirm.ShowDialog()
                If cnfrm Then
                    addInventory()
                    cnfrm = False
                    MessageBox.Show("Item Updated", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    chck.Checked = False
                    refreshh()
                End If
            End If
        ElseIf e.ColumnIndex = 9 Then
            Dim frm As New additem()
            frm.itemid = CInt(dgv.CurrentRow.Cells("itemid").Value)
            frm.current_itemname = CStr(dgv.CurrentRow.Cells("itemname").Value)
            frm.lblheader.Text = "EDIT ITEM"
            frm.ShowDialog()
            chck.Checked = False
            refreshh()
        End If
    End Sub

    Private Sub btnimport_Click(sender As Object, e As EventArgs) Handles btnimport.Click
        importitems2.ShowDialog()
        btnrefresh.PerformClick()
    End Sub

    Private Sub btnexport_Click(sender As Object, e As EventArgs) Handles btnexport.Click
        Try
            Dim r1 As New Random(), r2 As New Random(), r3 As New Random()

            SaveFileDialog1.Title = "Save As Excel File"
            SaveFileDialog1.Filter = "Excel Document (*.xlsx) | *.xlsx"

            SaveFileDialog1.FileName = r1.Next(0, 10).ToString & r2.Next(200, 300) & r3.Next(500, 1000) & "_Items" & IIf(chck.Checked, "_Discontinued", "") & "_" & DateTime.Now.ToString("MMddyyyy_items")
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
                dt.Columns.Add("Category")
                dt.Columns.Add("ItemCode")
                dt.Columns.Add("ItemName")
                dt.Columns.Add("Description")
                dt.Columns.Add("Price")
                dt.Columns.Add("HaveDeposit")
                dt.Columns.Add("DepositPrice")

                For index As Integer = 0 To dgv.RowCount - 1
                    dt.Rows.Add(dgv.Rows(index).Cells("category").Value, dgv.Rows(index).Cells("itemcode").Value, dgv.Rows(index).Cells("itemname").Value, dgv.Rows(index).Cells("description").Value, dgv.Rows(index).Cells("price").Value, dgv.Rows(index).Cells("havedeposit").Value, dgv.Rows(index).Cells("depositprice").Value)
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
                MessageBox.Show("Saved" & Environment.NewLine & "Path: " & path, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btnnext_Click(sender As Object, e As EventArgs) Handles btnnext.Click
        offset += rowsFetch
        currentPage += 1
        If offset <= totalCount Then
            loadItems()
            totalCount = countLoadItems()
            totalPage = Math.Ceiling(totalCount / rowsFetch) * 1
            lblcount.Text = "Page: " & currentPage & "/" & totalPage
        Else
            offset -= rowsFetch
            currentPage -= 1
            lblcount.Text = "Page: " & currentPage & "/" & totalPage
        End If
    End Sub
End Class