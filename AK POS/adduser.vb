Imports AK_POS.user_class
Imports AK_POS.connection_class
Public Class adduser
    Dim userc As New user_class, conc As New connection_class
    Public Shared userid As Integer = 0, current_username As String = ""
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub adduser_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Panel5_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel5.MouseDown, MyBase.MouseDown, lblheader.MouseDown, Label4.MouseDown, Label3.MouseDown, Label2.MouseDown, Label1.MouseDown
        drag = True 'Sets the variable drag to true.
        mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'Sets variable mousey
    End Sub

    Private Sub Panel5_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel5.MouseMove, MyBase.MouseMove, lblheader.MouseMove, Label4.MouseMove, Label3.MouseMove, Label2.MouseMove, Label1.MouseMove
        'If drag is set to true then move the form accordingly.
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Panel5_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel5.MouseUp, MyBase.MouseUp, lblheader.MouseUp, Label4.MouseUp, Label3.MouseUp, Label2.MouseUp, Label1.MouseUp
        drag = False 'Sets drag to false, so the form does not move according to the code in MouseMove
    End Sub

    Public Sub clear()
        txtname.Text = ""
        txtusername.Text = ""
        cmbstatus.SelectedIndex = 0
        cmbworkgroup.SelectedIndex = 0
        cmbpostype.SelectedIndex = 0
    End Sub
    Public Sub add()
        userc.setName(txtname.Text)
        userc.setUsername(txtusername.Text)
        userc.setPassword(txtpassword.Text)
        userc.setWorkgroup(cmbworkgroup.Text)
        userc.setStatus(IIf(cmbstatus.SelectedIndex = 0, 1, 0))
        userc.setBrout(cmbranches.Text)
        userc.setPOSType(cmbpostype.Text)
        userc.insertUser()
        Me.Close()
    End Sub
    Public Sub edit()
        userc.setName(txtname.Text)
        userc.setUsername(txtusername.Text)
        userc.setPassword(txtpassword.Text)
        userc.setWorkgroup(cmbworkgroup.Text)
        userc.setStatus(IIf(cmbstatus.SelectedIndex = 0, 1, 0))
        userc.setBrout(cmbranches.Text)
        userc.setPOSType(cmbpostype.Text)
        userc.setID(userid)
        userc.updateUser()
        Me.Close()
    End Sub
    Public Sub submit()
        Try
            userc.setUsername(txtusername.Text)
            If String.IsNullOrEmpty(Trim(txtname.Text)) Then
                MessageBox.Show("Name field is required", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtname.Focus()
            ElseIf String.IsNullOrEmpty(Trim(txtusername.Text)) Then
                MessageBox.Show("Username field is required", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtusername.Focus()
            ElseIf userc.checkUsername() And current_username <> txtusername.Text Then
                MessageBox.Show("Username '" & txtusername.Text & "' is already registered", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtusername.Focus()
            ElseIf String.IsNullOrEmpty(Trim(txtpassword.Text)) Then
                MessageBox.Show("Password field is required", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtpassword.Focus()
            ElseIf String.IsNullOrEmpty(Trim(txtpassword2.Text)) Then
                MessageBox.Show("Confirm Password field is required", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtpassword2.Focus()
            ElseIf Trim(txtpassword.Text).ToLower <> Trim(txtpassword2.Text).ToLower Then
                MessageBox.Show("Password did not match", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtpassword2.Focus()
            Else
                If lblheader.Text = "ADD USER" Then
                    add()
                ElseIf lblheader.Text = "EDIT USER" Then
                    edit()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub
    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        submit()
    End Sub

    Private Sub chck1_CheckedChanged(sender As Object, e As EventArgs) Handles chck1.CheckedChanged
        If chck1.Checked Then
            txtpassword.PasswordChar = ""
        Else
            txtpassword.PasswordChar = "*"
        End If
    End Sub

    Private Sub chck2_CheckedChanged(sender As Object, e As EventArgs) Handles chck2.CheckedChanged
        If chck2.Checked Then
            txtpassword2.PasswordChar = ""
        Else
            txtpassword2.PasswordChar = "*"
        End If
    End Sub

    Private Sub txtname_KeyDown(sender As Object, e As KeyEventArgs) Handles txtname.KeyDown, txtusername.KeyDown, txtpassword2.KeyDown, txtpassword.KeyDown, cmbworkgroup.KeyDown, cmbstatus.KeyDown, cmbranches.KeyDown, cmbpostype.KeyDown
        If e.KeyCode = Keys.Enter Then
            submit()
        End If
    End Sub

    Private Sub adduser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadBranches()
        If lblheader.Text = "ADD USER" Then
            clear()
        ElseIf lblheader.Text = "EDIT USER" Then
            loadByID()
        End If
    End Sub

    Public Sub loadBranches()
        Dim dtBranches As New DataTable()
        dtBranches = userc.loadBranches()
        cmbranches.Items.Clear()
        For Each r0w As DataRow In dtBranches.Rows
            cmbranches.Items.Add(r0w("branchcode"))
        Next
        If cmbranches.Items.Count <> 0 And lblheader.Text = "ADD USER" Then
            cmbranches.SelectedIndex = 0
        End If
    End Sub
    Public Sub loadByID()
        Dim dt As New DataTable()
        userc.setID(userid)
        dt = userc.loadDataWhereID()
        For Each r0w As DataRow In dt.Rows
            txtname.Text = r0w("fullname")
            txtusername.Text = r0w("username")
            current_username = r0w("username")
            txtpassword.Text = conc.Decrypt(r0w("password"))
            cmbworkgroup.Text = r0w("workgroup")
            cmbstatus.Text = IIf(r0w("status") = 1, "Active", "In Active")
            cmbranches.Text = r0w("branchcode")
            cmbpostype.Text = r0w("postype")
        Next
    End Sub
End Class