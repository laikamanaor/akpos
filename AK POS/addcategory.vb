Imports AK_POS.category_class
Public Class addcategory
    'init classes
    Dim catc As New category_class
    'init variables
    Public Shared catid As Integer = 0, current_category As String = ""
    'init variables to drag form realtime
    Dim drag As Boolean, mousex As Integer, mousey As Integer
    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub
    Private Sub addcategory_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        'check if user press ESC button
        If e.KeyCode = Keys.Escape Then
            'close the form
            Me.Close()
        End If
    End Sub
    Private Sub Panel5_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel5.MouseDown, MyBase.MouseDown, lblheader.MouseDown, Label7.MouseDown, Label2.MouseDown
        drag = True 'Sets the variable drag to true.
        mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'Sets variable mousey
    End Sub
    Private Sub Panel5_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel5.MouseMove, MyBase.MouseMove, lblheader.MouseMove, Label7.MouseMove, Label2.MouseMove
        'If drag is set to true then move the form accordingly.
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub addcategory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'check header text
        If lblheader.Text = "ADD CATEGORY" Then
            'assign status index to zero
            cmbstatus.SelectedIndex = 0
        ElseIf lblheader.Text = "EDIT CATEGORY" Then
            'assign catid to category class
            catc.catid = catid
            'init datatable to get category data
            Dim dt As New DataTable()
            'get data from category class
            dt = catc.loadDataWhereID()
            'loop through
            For Each r0w As DataRow In dt.Rows
                'assign values
                current_category = r0w("category")
                txtcategory.Text = r0w("category")
                cmbstatus.Text = IIf(r0w("status") = 1, "Active", "In Active")
            Next
        End If
    End Sub
    ''' <summary>
    ''' sub to create category
    ''' </summary>
    Public Sub add()
        'assign category
        catc.category = txtcategory.Text
        'assign status depends on expression
        catc.status = IIf(cmbstatus.SelectedIndex = 0, 1, 0)
        'call insert category sub to insert query
        catc.insertCategory()
        'message
        MessageBox.Show("Transaction Completed", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    ''' <summary>
    ''' sub to update category
    ''' </summary>
    Public Sub edit()
        'assign catid
        catc.catid = catid
        'assign category
        catc.category = txtcategory.Text
        'assign status depends on expression
        catc.status = IIf(cmbstatus.SelectedIndex = 0, 1, 0)
        'call update category sub to update query
        catc.updateCategory()
        'message
        MessageBox.Show("Transaction Completed", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    ''' <summary>
    ''' sub to submit button
    ''' </summary>
    Public Sub submit()
        'assign category
        catc.category = txtcategory.Text
        'check category if empty
        If String.IsNullOrEmpty(Trim(txtcategory.Text)) Then
            'message
            MessageBox.Show("Category field is empty", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'focus on category
            txtcategory.Focus()
            'check category is exist
        ElseIf catc.checkCategory() And txtcategory.Text <> current_category Then
            'message
            MessageBox.Show("Category '" & txtcategory.Text & "' is already exist", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'focus on category
            txtcategory.Focus()
        Else
            'check header text
            If lblheader.Text = "ADD CATEGORY" Then
                'call add sub
                add()
                'close the form
                Me.Close()
            ElseIf lblheader.Text = "EDIT CATEGORY" Then
                'call edit sub
                edit()
                'close the form
                Me.Close()
            End If
        End If
    End Sub
    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        'call submit sub
        submit()
    End Sub
    Private Sub Panel5_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel5.MouseUp, MyBase.MouseUp, lblheader.MouseUp, Label7.MouseUp, Label2.MouseUp
        drag = False 'Sets drag to false, so the form does not move according to the code in MouseMove
    End Sub
End Class