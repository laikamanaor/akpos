Imports AK_POS.category_class
Imports Microsoft.Office.Interop
Public Class categories
    'init classes
    Dim catc As New category_class
    'init variables
    Dim offset As Integer = 0, totalCount As Integer = 0, totalPage As Integer = 0, currentPage As Integer = 1, rowsFetch As Integer = 50

    Private Sub btnprev_Click(sender As Object, e As EventArgs) Handles btnprev.Click
        'check offset
        If offset > 0 Then
            'decreament offset based on rowFetch
            offset -= rowsFetch
            'decreament currentPage to 1
            currentPage -= 1
            'load datagridview
            loadData()
            'assign category to category class
            catc.category = txtsearch.Text
            'assign status based on expression to category class
            catc.status = IIf(cmbstatus.SelectedIndex = 0, 1, 0)
            'get total count of category
            totalCount = catc.countData()
            'assign totalPage to totalcount / rowfetch (ex: (100/30) * 1)
            totalPage = Math.Ceiling(totalCount / rowsFetch) * 1
            'assign lblpage currentpage / totalpage (ex: 5/10)
            lblcount.Text = "Page: " & currentPage & "/" & totalPage
        Else
            'assign offset to zero
            offset = 0
            'assign current page to one
            currentPage = 1
            'assign lblpage currentpage / totalpage (ex: 0/10)
            lblcount.Text = "Page: " & currentPage & "/" & totalPage
        End If
    End Sub

    Private Sub txtsearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsearch.KeyDown
        'fire keydown when user press the enter button
        If e.KeyCode = Keys.Enter Then
            'load refresh
            refreshh()
        End If
    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        'load refresh
        refreshh()
    End Sub

    Private Sub cmbstatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbstatus.SelectedIndexChanged
        'load refresh
        refreshh()
    End Sub

    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        'clear textcategory on add category form
        addcategory.txtcategory.Text = ""
        'assign header to ADD category
        addcategory.lblheader.Text = "ADD CATEGORY"
        'show add category form
        addcategory.ShowDialog()
        'load refresh when form is closed
        refreshh()
    End Sub

    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        Try
            'check datagridview has row
            If dgv.RowCount <> 0 Then
                'event fire when user click column index 3
                If e.ColumnIndex = 3 Then
                    'assign header to EDIT category
                    addcategory.lblheader.Text = "EDIT CATEGORY"
                    'clear textbox category
                    addcategory.txtcategory.Text = ""
                    'assign catid
                    addcategory.catid = dgv.CurrentRow.Cells("catid").Value
                    'show edit category form
                    addcategory.ShowDialog()
                    'load refresh when form is closed
                    refreshh()
                End If
            End If
        Catch ex As Exception
            'show error message
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btnexport_Click(sender As Object, e As EventArgs) Handles btnexport.Click
        Try
            'assign title save dialog
            SaveFileDialog1.Title = "Save As Excel File"
            'assign filter save dialog
            SaveFileDialog1.Filter = "Excel Document (*.xlsx) | *.xlsx"

            SaveFileDialog1.FileName = DateTime.Now.ToString("MMddyyyy_hhmm") & "_categories" & IIf(cmbstatus.SelectedIndex = 0, "_Active", "_InActive") & IIf(txtsearch.Text = "", "", "_" & txtsearch.Text.ToLower)
            'check if user click ok
            If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                'assign values
                Me.Cursor = Cursors.WaitCursor
                Dim objExcel As New Excel.Application
                Dim bkWorkBook As Excel.Workbook
                Dim shWorkSheet As Excel.Worksheet
                Dim misValue As Object = System.Reflection.Missing.Value
                objExcel = New Excel.Application
                bkWorkBook = objExcel.Workbooks.Add
                shWorkSheet = CType(bkWorkBook.ActiveSheet, Excel.Worksheet)

                'init datatable and result from category class
                Dim dt As New DataTable(), result As New DataTable
                'add columns
                dt.Columns.Add("Category")
                dt.Columns.Add("Status")

                'assign category
                catc.category = txtsearch.Text
                'assign status
                catc.status = IIf(cmbstatus.SelectedIndex = 0, 1, 0)

                'get data from category class
                result = catc.loadDataExported()
                'loop through
                For Each r0w As DataRow In result.Rows
                    dt.Rows.Add(r0w("category"), IIf(r0w("status") = 1, "Active", "In Active"))
                Next

                'loop through datatable columns
                For i As Integer = 0 To dt.Columns.Count - 1
                    'assign worksheet
                    shWorkSheet.Cells(1, i + 1) = dt.Columns(i).ToString
                Next
                'loop through datatable rows
                For i As Integer = 0 To dt.Rows.Count - 1
                    For j = 0 To dt.Columns.Count - 1
                        'assign worksheet
                        shWorkSheet.Cells(i + 2, j + 1) = dt.Rows(i)(j).ToString
                    Next
                Next

                With shWorkSheet
                    'assign format
                    .Range("A1", misValue).EntireRow.Font.Bold = True
                    .Range("A1:B1").EntireRow.WrapText = True

                    .Range("A1:B1").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DodgerBlue)
                    .Range("A1:B1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)

                    .Range("A1:B" & dt.Rows.Count + 1).HorizontalAlignment = -4108
                    .Range("A1:B" & dt.Rows.Count + 1).VerticalAlignment = -4108
                    .Range("A1:B1").Font.Size = 12


                    .Range("A2:A" & dt.Rows.Count + 1).RowHeight = 40
                    .Range("A2:B" & dt.Rows.Count + 1).RowHeight = 40

                    .Range("A2:A" & dt.Rows.Count + 1).ColumnWidth = 20
                    .Range("A2:B" & dt.Rows.Count + 1).ColumnWidth = 20
                End With
                'set A1 to lock
                shWorkSheet.Range("A1").Locked = False
                'assign obj to default
                objExcel.Visible = False
                objExcel.Application.DisplayAlerts = False
                'get path and file name
                Dim path As String = IO.Path.GetDirectoryName(SaveFileDialog1.FileName)
                'save excel
                objExcel.ActiveWorkbook.SaveAs(SaveFileDialog1.FileName.ToString())
                'exit
                objExcel.Quit()
                'assign obj to null
                objExcel = Nothing
                'cursor back to default
                Me.Cursor = Cursors.Default
                'message when export is success
                MessageBox.Show("Saved" & Environment.NewLine & "Path: " & path, "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            'error message
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btnimport_Click(sender As Object, e As EventArgs) Handles btnimport.Click
        'call import category form
        Dim frm As New import_categories()
        frm.ShowDialog()
        'load refresh
        refreshh()
    End Sub

    Private Sub btnnext_Click(sender As Object, e As EventArgs) Handles btnnext.Click
        'increment offset based on rowFetch (ex: 30 + 30 = 60)
        offset += rowsFetch
        'increament currentpage to one
        currentPage += 1
        'check offset
        If offset <= totalCount Then
            'load data
            loadData()
            'assign category
            catc.category = txtsearch.Text
            'assign status
            catc.status = IIf(cmbstatus.SelectedIndex = 0, 1, 0)
            'get total count of category
            totalCount = catc.countData()
            'get totalpage based on total count and row fetch (ex: (100 / 30) * 1)
            totalPage = Math.Ceiling(totalCount / rowsFetch) * 1
            'assign current page and total page
            lblcount.Text = "Page: " & currentPage & "/" & totalPage
        Else
            'decrement offset based on rowFetch (ex: 30 + 30 = 60)
            offset -= rowsFetch
            'decrement currentpage to one
            currentPage -= 1
            'assign current page and total page
            lblcount.Text = "Page: " & currentPage & "/" & totalPage
        End If
    End Sub

    Private Sub categories_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'assign status index to zero
        cmbstatus.SelectedIndex = 0
        'get count of categories from category class
        totalCount = catc.countData()
        'get totalpage based on total count and row fetch (ex: (100 / 30) * 1)
        totalPage = Math.Ceiling(totalCount / rowsFetch) * 1
        'load data
        loadData()
    End Sub

    ''' <summary>
    ''' get data fom category class
    ''' </summary>
    Public Sub loadData()
        'assign category
        catc.category = txtsearch.Text
        'assign status
        catc.status = IIf(cmbstatus.SelectedIndex = 0, 1, 0)
        'init datatable to get data and autocomplete
        Dim dtData As New DataTable(), auto As New AutoCompleteStringCollection()
        'get data from category class
        dtData = catc.loadData(offset, rowsFetch)
        'clear datagridview rows before adding again
        dgv.Rows.Clear()
        'loop through
        For Each r0w As DataRow In dtData.Rows
            'add datagridview rows
            dgv.Rows.Add(r0w("catid"), r0w("category"), IIf(r0w("status") = 1, "Active", "In Active"))
            auto.Add(r0w("category"))
        Next
        'assign autocomplete
        txtsearch.AutoCompleteCustomSource = auto
    End Sub
    ''' <summary>
    ''' set all variables to zero or default
    ''' </summary>
    Public Sub refreshh()
        currentPage = 1
        offset = 0
        catc.category = txtsearch.Text
        catc.status = IIf(cmbstatus.SelectedIndex = 0, 1, 0)
        totalCount = catc.countData()
        totalPage = Math.Ceiling(totalCount / rowsFetch) * 1
        lblcount.Text = "Page: " & currentPage & "/" & totalPage
        loadData()
    End Sub
End Class