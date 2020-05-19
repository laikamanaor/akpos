Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Imports AK_POS.items_class
Imports AK_POS.connection_class
Public Class items2
    'init classes
    Dim itemc As New items_class, cc As New connection_class
    'init sql config
    Dim strconn As String = cc.conString, con As New SqlConnection(strconn), cmd As SqlCommand, rdr As SqlDataReader, transaction As SqlTransaction
    'confirm bool for confirm dialog form
    Public Shared cnfrm As Boolean = False
    'init to paginiation variables
    Dim offset As Integer = 0, totalCount As Integer = 0, totalPage As Integer = 0, currentPage As Integer = 1, rowsFetch As Integer = 50
    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        'call add item form
        Dim frm As New additem()
        'assign header to ADD
        frm.lblheader.Text = "ADD ITEM"
        'show form
        frm.ShowDialog()
        'btnrefresh button will fire when add item form is closed
        btnrefresh.PerformClick()
    End Sub
    Private Sub items2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'display totalpage to label
        lblcount.Text = totalPage
        'call loadcategories sub
        loadCategories()
        'get counts from items class
        totalCount = countLoadItems()
        'assign total page is equal to totalCount divided by rowFetch (ex: (100/30) * 1)
        totalPage = Math.Ceiling(totalCount / rowsFetch) * 1
        'call loaditems sub
        loadItems()
    End Sub
    ''' <summary>
    ''' get categories data from items class
    ''' </summary>
    Public Sub loadCategories()
        Try
            'clear combobox first
            cmbcategory.Items.Clear()
            'category item add 'All'
            cmbcategory.Items.Add("All")
            'init result datatable that hold data
            Dim dtResult As New DataTable()
            'get data from items class
            dtResult = itemc.loadCategories()
            'loop through
            For Each r0w As DataRow In dtResult.Rows
                'add to item category
                cmbcategory.Items.Add(r0w("category"))
            Next
            'check if category item count has row
            If cmbcategory.Items.Count <> 0 Then
                'assign selectedindex to zero
                cmbcategory.SelectedIndex = 0
            End If
        Catch ex As Exception
            'error message
            MessageBox.Show(ex.ToString)
        Finally
            'close connection
            con.Close()
        End Try
    End Sub
    ''' <summary>
    ''' get items data from item class
    ''' </summary>
    Public Sub loadItems()
        Try
            'init result and autocomplete
            Dim dtResult As New DataTable(), auto As New AutoCompleteStringCollection
            'assign values
            itemc.setDiscontinued(IIf(chck.Checked, 1, 0))
            itemc.setCategory(cmbcategory.Text)
            itemc.setICategory(cmbcategory.SelectedIndex)
            itemc.setItem(txtsearch.Text)
            dtResult = itemc.loadItems(offset, rowsFetch)
            'clear dgv rows first
            dgv.Rows.Clear()
            'loop through
            For Each r0w As DataRow In dtResult.Rows
                'autocomplete add itemname
                auto.Add(r0w("itemname"))
                'add data to dgv
                dgv.Rows.Add(r0w("itemid"), r0w("category"), r0w("itemcode"), r0w("itemname"), r0w("description"), CDbl(r0w("price")).ToString("n2"), r0w("deposit"), CDbl(r0w("deposit_price")).ToString("n2"))
            Next
            'assign txtsearch to autocomplete
            txtsearch.AutoCompleteCustomSource = auto
        Catch ex As Exception
            'error message
            MessageBox.Show(ex.ToString)
        Finally
            'close connection when dark error(s) comes
            con.Close()
        End Try
    End Sub
    ''' <summary>
    ''' get count of items
    ''' </summary>
    ''' <returns></returns>
    Public Function countLoadItems() As Integer
        'assign values
        itemc.setDiscontinued(IIf(chck.Checked, 1, 0))
        itemc.setCategory(cmbcategory.Text)
        itemc.setICategory(cmbcategory.SelectedIndex)
        itemc.setItem(txtsearch.Text)
        'get count result
        Dim result As Integer = itemc.countItems
        'return result
        Return result
    End Function
    Private Sub chck_CheckedChanged(sender As Object, e As EventArgs) Handles chck.CheckedChanged
        'load refresh sub
        refreshh()
    End Sub

    Private Sub btnrefresh_Click(sender As Object, e As EventArgs) Handles btnrefresh.Click
        'clear txtsearch text
        txtsearch.Text = ""
        'assign category selectedindex to zero
        cmbcategory.SelectedIndex = 0
        'call refresh sub
        refreshh()
    End Sub

    Private Sub cmbcategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbcategory.SelectedIndexChanged
        'call refresh sub
        refreshh()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        refreshh()
    End Sub

    ''' <summary>
    ''' sub that refresh data from beginning
    ''' </summary>
    Public Sub refreshh()
        'assign current page to one
        currentPage = 1
        'assign offset to zero
        offset = 0
        'get count of items
        totalCount = countLoadItems()
        'assign total page equal to totalCount divided by rowFetch (ex: (100/30) * 1)
        totalPage = Math.Ceiling(totalCount / rowsFetch) * 1
        'display current page / total page (ex: 3/10)
        lblcount.Text = "Page: " & currentPage & "/" & totalPage
        'call loaditems sub
        loadItems()
    End Sub
    Private Sub txtsearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsearch.KeyDown
        'check if user press enter button
        If e.KeyCode = Keys.Enter Then
            'call refresh sub
            refreshh()
        End If
    End Sub

    Private Sub items2_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        'check if user press f5 button
        If e.KeyCode = Keys.F5 Then
            'call loaditems sub
            loadItems()
            'check if user press ESC button
        ElseIf e.KeyCode = Keys.Escape Then
            'close form
            Me.Close()
        End If
    End Sub
    ''' <summary>
    '''  get latest inventory number
    ''' </summary>
    Public Function getInvID() As String
        'init variables
        Dim id As String = "", date_ As New DateTime()
        'open connection
        con.Open()
        'syntax
        cmd = New SqlCommand("Select TOP 1 invnum, datecreated from tblinvsum WHERE area='" & "Sales" & "' order by invsumid DESC", con)
        'read command
        rdr = cmd.ExecuteReader()
        'check read has row
        If rdr.Read() Then
            'assign values
            id = rdr("invnum")
            date_ = CDate(rdr("datecreated"))
        End If
        'close connection
        con.Close()
        'return result
        Return id
    End Function
    ''' <summary>
    ''' check stock of item before update discontinue column
    ''' </summary>
    ''' <returns></returns>
    Public Function checkStock() As Boolean
        Try
            'init variables
            Dim invnum As String = getInvID(), result As Boolean = False, endbal As Double = 0.00
            'open connection
            con.Open()
            'syntax
            cmd = New SqlCommand("SELECT endbal FROM tblinvitems WHERE invnum=@invnum AND itemname=@itemname;", con)
            cmd.Parameters.AddWithValue("@invnum", invnum)
            cmd.Parameters.AddWithValue("@itemname", dgv.CurrentRow.Cells("itemname").Value)
            'read command
            rdr = cmd.ExecuteReader
            'check read has row
            If rdr.Read Then
                'assign value
                endbal = CDbl(rdr("endbal"))
            End If
            'close connection
            con.Close()
            'assign result depends on expression
            result = IIf(endbal <> 0, True, False)
            'return result
            Return result
        Catch ex As Exception
            'message error
            MessageBox.Show(ex.ToString)
        End Try
    End Function
    ''' <summary>
    ''' add to inventory
    ''' </summary>
    Public Sub addInventory()
        Try
            'init variables
            Dim invnum As String = getInvID(), result As Boolean = False
            'create new connection
            Using connection As New SqlConnection(cc.conString)
                'init command
                Dim cmdd As New SqlCommand()
                'open connection
                cmdd.Connection = connection
                connection.Open()
                'begin sql transaction
                transaction = connection.BeginTransaction()
                cmdd.Transaction = transaction

                'clear parameters first
                cmdd.Parameters.Clear()
                'procedure name for updating discontinued status
                cmdd.CommandText = "updateDiscontinued"
                'command type
                cmdd.CommandType = CommandType.StoredProcedure
                'assign parameters
                cmdd.Parameters.AddWithValue("@itemid", dgv.CurrentRow.Cells("itemid").Value)
                cmdd.Parameters.AddWithValue("@discontinued", IIf(chck.Checked = True, 0, 1))
                'execute query
                cmdd.ExecuteNonQuery()

                'clear parameters first
                cmdd.Parameters.Clear()
                'command syntax
                cmdd.CommandText = "SELECT invid FROM tblinvitems WHERE invnum=@invnum AND itemname=@itemname;"
                'command type
                cmdd.CommandType = CommandType.Text
                'command parameters
                cmdd.Parameters.AddWithValue("@invnum", invnum)
                cmdd.Parameters.AddWithValue("@itemname", dgv.CurrentRow.Cells("itemname").Value)
                'read command
                rdr = cmdd.ExecuteReader
                'return result depends on expression
                If rdr.Read Then
                    result = True
                Else
                    result = False
                End If
                rdr.Close()
                'close read

                'check if result is true
                If result Then
                    'clear parameters
                    cmdd.Parameters.Clear()
                    'procedure name
                    cmdd.CommandText = "updateInvStatus"
                    'command type
                    cmdd.CommandType = CommandType.StoredProcedure
                    'assign parameters
                    cmdd.Parameters.AddWithValue("@itemid", dgv.CurrentRow.Cells("itemid").Value)
                    cmdd.Parameters.AddWithValue("@status", IIf(chck.Checked = True, 1, 0))
                    'execute query
                    cmdd.ExecuteNonQuery()
                Else
                    'clear parameters first
                    cmdd.Parameters.Clear()
                    'procedure name
                    cmdd.CommandText = "insertContinueInvitems"
                    'command type
                    cmdd.CommandType = CommandType.StoredProcedure
                    'assign parameters
                    cmdd.Parameters.AddWithValue("@itemid", dgv.CurrentRow.Cells("itemid").Value)
                    'execute query
                    cmdd.ExecuteNonQuery()
                End If
                'commit query
                transaction.Commit()
            End Using
        Catch ex As Exception
            'msg error
            MessageBox.Show(ex.ToString)
            Try
                'not updating items when have error(s)
                transaction.Rollback()
            Catch ex2 As Exception
                'sql msg error
                MessageBox.Show(ex2.ToString)
            End Try
        End Try
    End Sub

    Private Sub btnprev_Click(sender As Object, e As EventArgs) Handles btnprev.Click
        'check offset if greater than zero
        If offset > 0 Then
            'decreament offset to rowFetch
            offset -= rowsFetch
            'decreament currentPage to one
            currentPage -= 1
            'call loadItems sub
            loadItems()
            'get total count of items
            totalCount = countLoadItems()
            'assign total page into totalCount divided by rowFetch times 1
            totalPage = Math.Ceiling(totalCount / rowsFetch) * 1
            'display current page and totalpage
            lblcount.Text = "Page: " & currentPage & "/" & totalPage
        Else
            'assign offset to zero
            offset = 0
            'assign currentpage to one
            currentPage = 1
            'display current page and totalpage
            lblcount.Text = "Page: " & currentPage & "/" & totalPage
        End If
    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        'check dgv has row
        If dgv.RowCount <> 0 Then
            'check if user click column index 8
            If e.ColumnIndex = 8 Then
                'check item has stock
                If checkStock() And chck.Checked = False Then
                    'msg error
                    MessageBox.Show("You can't discontinue item that have stock", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    'confirm dialog
                    Dim a As String = MsgBox("Are you sure you want to " & IIf(chck.Checked, "continue", "discontinue") & " this item?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Add Item")
                    'check if user click ok button
                    If a = vbYes Then
                        'show auth dialog
                        confirm.ShowDialog()
                        'check if user enter correct password
                        If cnfrm Then
                            'call addInventory sub
                            addInventory()
                            'assign to false
                            cnfrm = False
                            'msg
                            MessageBox.Show("Item Updated", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            'assign check discontinued items to false
                            chck.Checked = False
                            'call refresh sub
                            refreshh()
                        End If
                    End If
                End If
                'check if user click column index 9
            ElseIf e.ColumnIndex = 9 Then
                'init edit item form
                Dim frm As New additem()
                'assign values
                frm.itemid = CInt(dgv.CurrentRow.Cells("itemid").Value)
                frm.current_itemname = CStr(dgv.CurrentRow.Cells("itemname").Value)
                frm.lblheader.Text = "EDIT ITEM"
                'show edit item form
                frm.ShowDialog()
                'assign to false and call sub when edit item form is closed
                chck.Checked = False
                refreshh()
            End If
        End If
    End Sub

    Private Sub btnimport_Click(sender As Object, e As EventArgs) Handles btnimport.Click
        'import item show form
        importitems2.ShowDialog()
        'btnrefresh fire when import item form is closed
        btnrefresh.PerformClick()
    End Sub

    Private Sub btnexport_Click(sender As Object, e As EventArgs) Handles btnexport.Click
        Try
            'init random variables
            Dim r1 As New Random(), r2 As New Random(), r3 As New Random()

            'assign title and filter
            SaveFileDialog1.Title = "Save As Excel File"
            SaveFileDialog1.Filter = "Excel Document (*.xlsx) | *.xlsx"
            'assign name of file
            SaveFileDialog1.FileName = r1.Next(0, 10).ToString & r2.Next(200, 300) & r3.Next(500, 1000) & "_Items" & IIf(chck.Checked, "_Discontinued", "") & "_" & DateTime.Now.ToString("MMddyyyy_items") & IIf(cmbcategory.Text = "All", "", "_" & cmbcategory.Text.ToLower) & IIf(txtsearch.Text = "", "", "_" & txtsearch.Text.ToLower)
            'check if user click ok button
            If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                'excel config
                Me.Cursor = Cursors.WaitCursor
                Dim objExcel As New Excel.Application
                Dim bkWorkBook As Excel.Workbook
                Dim shWorkSheet As Excel.Worksheet
                Dim misValue As Object = System.Reflection.Missing.Value
                objExcel = New Excel.Application
                bkWorkBook = objExcel.Workbooks.Add
                shWorkSheet = CType(bkWorkBook.ActiveSheet, Excel.Worksheet)

                'init datatable that hold data
                Dim dt As New DataTable()
                'columns
                dt.Columns.Add("Category")
                dt.Columns.Add("ItemCode")
                dt.Columns.Add("ItemName")
                dt.Columns.Add("Description")
                dt.Columns.Add("Price")
                dt.Columns.Add("HaveDeposit")
                dt.Columns.Add("DepositPrice")

                'loop through
                For index As Integer = 0 To dgv.RowCount - 1
                    'add datatatble rows
                    dt.Rows.Add(dgv.Rows(index).Cells("category").Value, dgv.Rows(index).Cells("itemcode").Value, dgv.Rows(index).Cells("itemname").Value, dgv.Rows(index).Cells("description").Value, dgv.Rows(index).Cells("price").Value, dgv.Rows(index).Cells("havedeposit").Value, dgv.Rows(index).Cells("depositprice").Value)
                Next
                'loop through dt columns
                For i As Integer = 0 To dt.Columns.Count - 1
                    'assign worksheet
                    shWorkSheet.Cells(1, i + 1) = dt.Columns(i).ToString
                Next
                'loop through dt rows
                For i As Integer = 0 To dt.Rows.Count - 1
                    For j = 0 To dt.Columns.Count - 1
                        'assign worksheet
                        shWorkSheet.Cells(i + 2, j + 1) = dt.Rows(i)(j).ToString
                    Next
                Next

                'worksheet cells design and format
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
                'assign obj to false
                objExcel.Visible = False
                objExcel.Application.DisplayAlerts = False
                'assign path
                Dim path As String = IO.Path.GetDirectoryName(SaveFileDialog1.FileName)
                'save excel
                objExcel.ActiveWorkbook.SaveAs(SaveFileDialog1.FileName.ToString())
                'assign obj to close
                objExcel.Quit()
                'assign object to null
                objExcel = Nothing
                'cursor back to normal
                Me.Cursor = Cursors.Default
                'msg when excel is success
                MessageBox.Show("Saved" & Environment.NewLine & "Path: " & path, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            'msg error
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btnnext_Click(sender As Object, e As EventArgs) Handles btnnext.Click
        'increment offset to rowFetch
        offset += rowsFetch
        'increment currentPage to one
        currentPage += 1
        'check offset less than or equal to totalCount
        If offset <= totalCount Then
            'call loadItems sub
            loadItems()
            'get total count of items
            totalCount = countLoadItems()
            'get totalpage equal to totalCount divided by rowFetch times 1
            totalPage = Math.Ceiling(totalCount / rowsFetch) * 1
            'display current page and totalpage
            lblcount.Text = "Page: " & currentPage & "/" & totalPage
        Else
            'decrement offset to rowFetch
            offset -= rowsFetch
            'decrement currentPage to one
            currentPage -= 1
            'display current page and totalpage
            lblcount.Text = "Page: " & currentPage & "/" & totalPage
        End If
    End Sub
End Class