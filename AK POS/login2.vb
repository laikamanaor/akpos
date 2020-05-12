Imports AK_POS.ui_class
Imports AK_POS.login_class
Public Class login2
    Dim uic As New ui_class, loginc As New login_class
    Public Shared wrkgrp As String = "", username As String = ""
    Private Sub btnminimize_Click(sender As Object, e As EventArgs) Handles btnminimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnexit_Click(sender As Object, e As EventArgs) Handles btnexit.Click
        Application.Exit()
    End Sub

    Private Sub Panel7_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel7.MouseDown, PictureBox3.MouseDown, PictureBox2.MouseDown, PictureBox1.MouseDown, MyBase.MouseDown, Label9.MouseDown, Label8.MouseDown, Label6.MouseDown, Label5.MouseDown, Label3.MouseDown, Label10.MouseDown
        uic.mouse_down(Me)
    End Sub

    Private Sub Panel7_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel7.MouseMove, PictureBox3.MouseMove, PictureBox2.MouseMove, PictureBox1.MouseMove, MyBase.MouseMove, Label9.MouseMove, Label8.MouseMove, Label6.MouseMove, Label5.MouseMove, Label3.MouseMove, Label10.MouseMove
        uic.mouse_move(Me)
    End Sub

    Private Sub Panel7_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel7.MouseUp, PictureBox3.MouseUp, PictureBox2.MouseUp, PictureBox1.MouseUp, MyBase.MouseUp, Label9.MouseUp, Label8.MouseUp, Label6.MouseUp, Label5.MouseUp, Label3.MouseUp, Label10.MouseUp
        uic.mouse_up()
    End Sub

    Private Sub txtusername_Enter(sender As Object, e As EventArgs) Handles txtusername.Enter
        txt_enter(txtusername, "Username")
    End Sub

    Private Sub txtusername_Leave(sender As Object, e As EventArgs) Handles txtusername.Leave
        txt_leave(txtusername, "Username")
    End Sub

    Private Sub txtpass_Enter(sender As Object, e As EventArgs) Handles txtpass.Enter
        txt_enter(txtpass, "Password")
    End Sub

    Private Sub txtpass_Leave(sender As Object, e As EventArgs) Handles txtpass.Leave
        txt_leave(txtpass, "Password")
    End Sub
    Public Sub txt_enter(ByVal txtbox As Control, txt As String)
        If txtbox.Text = txt Then
            txtbox.Text = ""
            txtbox.ForeColor = Color.Black
        End If
    End Sub
    Public Sub txt_leave(ByVal txtbox As Control, txt As String)
        If txtbox.Text = "" Then
            txtbox.Text = txt
            txtbox.ForeColor = Color.LightGray
        End If
    End Sub

    Private Sub txtusername_KeyDown(sender As Object, e As KeyEventArgs) Handles txtusername.KeyDown, txtpass.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnlogin.PerformClick()
        End If
    End Sub

    Private Sub checkseepass_CheckedChanged(sender As Object, e As EventArgs) Handles checkseepass.CheckedChanged
        txtpass.PasswordChar = IIf(checkseepass.Checked, "", "*")
        txtpass.Font = IIf(checkseepass.Checked, New Font("Arial", 12, FontStyle.Bold), New Font("Arial", 18, FontStyle.Bold))
    End Sub

    Private Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click
        loginc.setUsername(txtusername.Text)
        loginc.setPassword(txtpass.Text)
        If Trim(txtusername.Text).ToLower = "username".ToLower Or String.IsNullOrEmpty(Trim(txtusername.Text)) Then
            MessageBox.Show("Username is required", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtpass.Text = ""
            txtusername.Focus()
        ElseIf loginc.checkUserStatus() = False Then
            MessageBox.Show("Your Account is Deactivate", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtpass.Text = ""
            txtpass.Focus()
        ElseIf loginc.checkLogin() = False Then
            MessageBox.Show("Wrong Credentials", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtpass.Text = ""
            txtpass.Focus()
        Else
            username = txtusername.Text
            Dim sa As New pos_dialog()
            sa.ShowDialog()
            loginc.setUsername(txtusername.Text)
            loginc.insertCutOff()
            loginc.insertLogs()
            wrkgrp = loginc.getWorkgroup()
            Me.Hide()
            Dim frm As New main()
            frm.ShowDialog()
        End If
    End Sub
End Class