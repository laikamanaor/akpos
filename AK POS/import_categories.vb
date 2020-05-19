Imports AK_POS.ui_class
Imports AK_POS.category_class
Imports System.IO
Imports System.Data.OleDb
Public Class import_categories
    'init classes
    Dim uic As New ui_class(), catc As New category_class
    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        'close form
        Me.Close()
    End Sub

    Private Sub import_categories_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        'check if user press the ESC button
        If e.KeyCode = Keys.Escape Then
            'close form
            Me.Close()
        End If
    End Sub

    Private Sub Panel6_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel6.MouseDown, MyBase.MouseDown, Label1.MouseDown
        uic.mouse_down(Me)
    End Sub

    Private Sub Panel6_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel6.MouseMove, MyBase.MouseMove, Label1.MouseMove
        uic.mouse_move(Me)
    End Sub

    Private Sub Panel6_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel6.MouseUp, MyBase.MouseUp, Label1.MouseUp
        uic.mouse_up()
    End Sub

    Private Sub btnbrowse_Click(sender As Object, e As EventArgs) Handles btnbrowse.Click
        Try
            'init connections
            Dim con As OleDbConnection, ds As New DataSet, cmd As OleDbCommand, rdr As OleDbDataReader, opf As New OpenFileDialog()
            'check if user click ok
            If opf.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.Cursor = Cursors.WaitCursor
                'call clear sub
                clear()
                'connection
                con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source='" & opf.FileName & "'; Extended Properties=Excel 12.0;")
                'open connection
                con.Open()
                'syntax
                cmd = New OleDbCommand("SELECT * FROM [Sheet1$]", con)
                'read
                rdr = cmd.ExecuteReader
                'loop through
                While rdr.Read
                    'add to datagridview and autocomplete
                    dgv.Rows.Add(rdr(0), rdr(1))
                End While
                'close connection
                con.Close()
                'assign autocomplete to textbox search
                txtsearch.AutoCompleteCustomSource = autoComplete()
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            'error message
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub search()
        'loop through
        For i As Integer = 0 To dgv.Rows.Count - 1
            'check if category from dgv is equal to txtsearch
            If dgv.Rows(i).Cells("category").Value.ToString.ToLower = txtsearch.Text.ToLower Then
                'dgv row become selected
                dgv.Rows(i).Selected = True
                'assign current cell to current datagridview
                dgv.CurrentCell = dgv.Rows(i).Cells("category")
            Else
                'dgv rows become unselected
                dgv.Rows(i).Selected = False
            End If
        Next
    End Sub
    Private Sub import_categories_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'call clear sub
        clear()
    End Sub
    ''' <summary>
    ''' clear dgv and txtsearch
    ''' </summary>
    Public Sub clear()
        dgv.Rows.Clear()
        txtsearch.Text = ""
    End Sub
    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        'call search sub
        search()
    End Sub

    Private Sub txtsearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsearch.KeyDown
        'check if user press enter button
        If e.KeyCode = Keys.Enter Then
            'call search sub
            search()
        End If
    End Sub


    Public Function validations() As Boolean
        'init result bool and result_int that holds how many errors
        Dim result As Boolean = False, result_int As Integer = 0
        'loop through
        For i As Integer = 0 To dgv.RowCount - 1
            'assign category
            catc.category = dgv.Rows(i).Cells("category").Value
            'check category if exist
            If catc.checkCategory() Then
                'row back color set to red
                dgv.Rows(i).Cells("category").Style.BackColor = Color.Red
                'assign tooltip text
                dgv.Rows(i).Cells("category").ToolTipText = "This category is already exist"
                'increment result_int to one
                result_int += 1
            Else
                'row back color set to white
                dgv.Rows(i).Cells("category").Style.BackColor = Color.White
                'clear tooltip text
                dgv.Rows(i).Cells("category").ToolTipText = ""
            End If
        Next
        'assign result depends on expression
        result = IIf(result_int = 0, True, False)
        'return result
        Return result
    End Function

    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        'check dgv has row
        If dgv.RowCount <> 0 Then
            'check if user clicked column index 2
            If e.ColumnIndex = 2 Then
                'show confirmation dialog
                Dim a As String = MsgBox("Are you sure you want to remove?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Atlantic Bakery")
                'check if user click yes
                If a = vbYes Then
                    'dgv remove current index
                    dgv.Rows.RemoveAt(e.RowIndex)
                    'assign txtsearch autocomplete
                    txtsearch.AutoCompleteCustomSource = autoComplete()
                End If
            End If
        End If
    End Sub
    ''' <summary>
    ''' get categories
    ''' </summary>
    ''' <returns></returns>
    Public Function autoComplete() As AutoCompleteStringCollection
        'init result
        Dim result As New AutoCompleteStringCollection
        'loop through dgv
        For i As Integer = 0 To dgv.RowCount - 1
            'add category to collection
            result.Add(dgv.Rows(i).Cells("category").Value)
        Next
        'return result
        Return result
    End Function
    Private Sub btnsubmit_Click(sender As Object, e As EventArgs) Handles btnsubmit.Click
        'check if validations is true or false,if true it means success
        If dgv.RowCount = 0 Then
            MessageBox.Show("Browse first", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf validations() Then
            For i As Integer = 0 To dgv.RowCount - 1
                'assign category
                catc.category = dgv.Rows(i).Cells("category").Value
                'assign status depends on expression
                catc.status = IIf(dgv.Rows(i).Cells("status").Value = "Active", 1, 0)
                'call insert category sub to insert query
                catc.insertCategory()
                'message
            Next
            MessageBox.Show("Transaction Completed", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dgv.Rows.Clear()
        End If
    End Sub
End Class