Imports AK_POS.category_class
Public Class addcategory
    Dim catc As New category_class
    Public Shared catid As Integer = 0, current_category As String = ""
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub
    Private Sub addcategory_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
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
        If lblheader.Text = "ADD CATEGORY" Then
            cmbstatus.SelectedIndex = 0
        ElseIf lblheader.Text = "EDIT CATEGORY" Then
            catc.setID(catid)
            Dim dt As New DataTable()
            dt = catc.loadDataWhereID()
            For Each r0w As DataRow In dt.Rows
                current_category = r0w("category")
                txtcategory.Text = r0w("category")
                cmbstatus.Text = IIf(r0w("status") = 1, "Active", "In Active")
            Next
        End If
    End Sub
    Public Sub add()
        catc.setCategory(txtcategory.Text)
        catc.setStatus(IIf(cmbstatus.SelectedIndex = 0, 1, 0))
        catc.insertCategory()
    End Sub
    Public Sub edit()
        catc.setID(catid)
        catc.setCategory(txtcategory.Text)
        catc.setStatus(IIf(cmbstatus.SelectedIndex = 0, 1, 0))
        catc.updateBranch()
    End Sub
    Public Sub submit()
        catc.setCategory(txtcategory.Text)
        If String.IsNullOrEmpty(Trim(txtcategory.Text)) Then
            MessageBox.Show("Category field is empty", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtcategory.Focus()
        ElseIf catc.checkCategory() And txtcategory.Text <> current_category Then
            MessageBox.Show("Category '" & txtcategory.Text & "' is already exist", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtcategory.Focus()
        Else
            If lblheader.Text = "ADD CATEGORY" Then
                add()
                Me.Close()
            ElseIf lblheader.Text = "EDIT CATEGORY" Then
                edit()
                Me.Close()
            End If
        End If
    End Sub
    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        submit()
    End Sub

    Private Sub Panel5_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel5.MouseUp, MyBase.MouseUp, lblheader.MouseUp, Label7.MouseUp, Label2.MouseUp
        drag = False 'Sets drag to false, so the form does not move according to the code in MouseMove
    End Sub
End Class