Imports AK_POS.pullout_class
Public Class over_pullout_dialog
    Public Shared invid As Integer = 0, datee As String = ""
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Dim current_qty As Integer = 0
    Dim poc As New pullout_class()
    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub over_pullout_dialog_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub over_pullout_dialog_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, Panel1.MouseDown, lblitemname.MouseDown, lblcategory.MouseDown, Label3.MouseDown, Label2.MouseDown, Label1.MouseDown
        drag = True 'Sets the variable drag to true.
        mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'Sets variable mousey
    End Sub

    Private Sub over_pullout_dialog_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove, Panel1.MouseMove, lblitemname.MouseMove, lblcategory.MouseMove, Label3.MouseMove, Label2.MouseMove, Label1.MouseMove
        'If drag is set to true then move the form accordingly.
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub over_pullout_dialog_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp, Panel1.MouseUp, lblitemname.MouseUp, lblcategory.MouseUp, Label3.MouseUp, Label2.MouseUp, Label1.MouseUp
        drag = False 'Sets drag to false, so the form does not move according to the code in MouseMove
    End Sub

    Private Sub over_pullout_dialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadData()
        Dim dtBranches As New DataTable()
        dtBranches = poc.getMainBranch(0)
        cmbbranches.Items.Clear()
        For Each r0w As DataRow In dtBranches.Rows
            cmbbranches.Items.Add(r0w("branchcode"))
        Next
        If cmbbranches.Items.Count <> 0 Then
            cmbbranches.SelectedIndex = 0
        End If
    End Sub
    Public Sub loadData()
        poc.setInvID(invid)
        Dim dt As New DataTable()
        dt = poc.showInventory()
        For Each r0w As DataRow In dt.Rows
            lblitemname.Text = r0w("itemname")
            lblcategory.Text = r0w("category")
            txtquantity.Text = r0w("qty")
            current_qty = r0w("qty")
        Next
    End Sub

    Private Sub btnsubmit_Click(sender As Object, e As EventArgs) Handles btnsubmit.Click
        If String.IsNullOrEmpty(Trim(cmbbranches.Text)) Then
            MessageBox.Show("Branch field is required", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbbranches.Focus()
        ElseIf poc.checkBranch(cmbbranches.Text) = False Then
            MessageBox.Show("Branch is not exist", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbbranches.Focus()
        ElseIf String.IsNullOrEmpty(Trim(txtquantity.Text)) Then
            MessageBox.Show("Quantity field is required", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtquantity.Focus()
        ElseIf Not IsNumeric(txtquantity.Text) Then
            MessageBox.Show("Quantity field must be a number", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtquantity.Focus()
        ElseIf CDbl(txtquantity.Text) = 0 Then
            MessageBox.Show("0 quantity is invalid", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtquantity.Focus()
        ElseIf CDbl(txtquantity.Text) > current_qty Then
            MessageBox.Show("Maximum quantity is " & current_qty, "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtquantity.Focus()
        Else
            poc.setCategory(lblcategory.Text)
            poc.setItemName(lblitemname.Text)
            poc.setQty(txtquantity.Text)
            poc.setDatee(datee)
            poc.setToBanch(cmbbranches.Text)
            poc.POTransaction()
            Me.Close()
        End If
    End Sub

    Private Sub txtquantity_KeyDown(sender As Object, e As KeyEventArgs) Handles txtquantity.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnsubmit.PerformClick()
        End If
    End Sub
End Class