Public Class access_add
    Dim uic As New ui_class()
    Dim userc As New user_class()
    Dim modulec As New module_class()
    Dim accessc As New access_class
    Dim status As String = ""
    Private Sub access_add_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadCBs("Username", cmbusernames)
        loadCBs("Module", cmbmodules)
    End Sub

    Public Sub loadCBs(ByVal type As String, ByVal cmb As ComboBox)
        Dim result As New DataTable()
        result = IIf(type.Equals("Username"), userc.loadUsernames(), modulec.loadModules())
        cmb.Items.Clear()
        cmb.Items.Add("Select " & type)
        For Each r0w As DataRow In result.Rows
            cmb.Items.Add(r0w("result"))
        Next
        cmb.SelectedIndex = 0
    End Sub

    Private Sub Panel5_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel5.MouseDown, MyBase.MouseDown, Label3.MouseDown, Label24.MouseDown, Label2.MouseDown, Label1.MouseDown
        uic.mouse_down(Me)
    End Sub

    Private Sub Panel5_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel5.MouseMove, MyBase.MouseMove, Label3.MouseMove, Label24.MouseMove, Label2.MouseMove, Label1.MouseMove
        uic.mouse_move(Me)
    End Sub

    Private Sub Panel5_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel5.MouseUp, MyBase.MouseUp, Label3.MouseUp, Label24.MouseUp, Label2.MouseUp, Label1.MouseUp
        uic.mouse_up()
    End Sub

    Private Sub lblclose_Click(sender As Object, e As EventArgs) Handles lblclose.Click
        Me.Close()
    End Sub

    Private Sub access_add_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles rbActive.CheckedChanged
        status = "Active"
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles rbInActive.CheckedChanged
        status = "In Active"
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim username As String = cmbusernames.Text
        Dim modulee As String = cmbmodules.Text
        Dim status2 As Integer = IIf(status.Equals("Active"), 1, 0)
        Dim createdBy As String = login2.username
        If cmbusernames.SelectedIndex <= 0 Then
            MessageBox.Show("Please choose Username", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf cmbmodules.SelectedIndex <= 0 Then
            MessageBox.Show("Please choose Module", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf Not rbActive.Checked And Not rbInActive.Checked Then
            MessageBox.Show("Please choose Status", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf accessc.checkAccess(username, modulee) Then
            MessageBox.Show("'" & cmbmodules.Text & "' is already exist", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim isSuccess As Boolean = accessc.insertModule(username, modulee, status2, createdBy)
            If isSuccess Then
                MessageBox.Show("Access Added", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If
        End If
    End Sub
End Class