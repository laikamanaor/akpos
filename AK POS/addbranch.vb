Imports AK_POS.branch_class
Public Class addbranch
    Dim brc As New branch_class
    Public Shared brid As Integer = 0, current_branchcode As String = ""
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub addbranch_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown, MyBase.MouseDown, Label6.MouseDown, Label5.MouseDown, Label4.MouseDown, Label3.MouseDown, Label2.MouseDown, lblheader.MouseDown, Label1.MouseDown, Label7.MouseDown
        drag = True 'Sets the variable drag to true.
        mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'Sets variable mousey
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove, MyBase.MouseMove, Label6.MouseMove, Label5.MouseMove, Label4.MouseMove, Label3.MouseMove, Label2.MouseMove, lblheader.MouseMove, Label1.MouseMove, Label7.MouseMove
        'If drag is set to true then move the form accordingly.
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp, MyBase.MouseUp, Label6.MouseUp, Label5.MouseUp, Label4.MouseUp, Label3.MouseUp, Label2.MouseUp, lblheader.MouseUp, Label1.MouseUp, Label7.MouseUp
        drag = False 'Sets drag to false, so the form does not move according to the code in MouseMove
    End Sub

    Public Sub add()
        brc.setBranchCode(txtcode.Text)
        brc.setBranchName(txtname.Text)
        brc.setGR(txtgr.Text)
        brc.setSales(txtsales.Text)
        brc.setAddress(txtaddress.Text)
        brc.setRemarks(txtremarks.Text)
        brc.setStatus(IIf(cmbstatus.SelectedIndex = 0, 1, 0))
        brc.insertBranch()
    End Sub
    Public Sub edit()
        brc.setID(brid)
        brc.setBranchCode(txtcode.Text)
        brc.setBranchName(txtname.Text)
        brc.setGR(txtgr.Text)
        brc.setSales(txtsales.Text)
        brc.setAddress(txtaddress.Text)
        brc.setRemarks(txtremarks.Text)
        brc.setStatus(IIf(cmbstatus.SelectedIndex = 0, 1, 0))
        brc.updateBranch()
    End Sub
    Public Sub submit()
        brc.setBranchCode(txtcode.Text)
        If String.IsNullOrEmpty(Trim(txtcode.Text)) Then
            MessageBox.Show("Code field is required", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtcode.Focus()
        ElseIf brc.checkCode() And current_branchcode <> txtcode.Text Then
            MessageBox.Show("Code '" & txtcode.Text.ToUpper & "' is already exist", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtcode.Focus()
        ElseIf String.IsNullOrEmpty(Trim(txtname.Text)) Then
            MessageBox.Show("Name field is required", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtname.Focus()
        ElseIf String.IsNullOrEmpty(Trim(txtgr.Text)) Then
            MessageBox.Show("GR field is required", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtgr.Focus()
        ElseIf String.IsNullOrEmpty(Trim(txtsales.Text)) Then
            MessageBox.Show("Sales field is required", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtsales.Focus()
        ElseIf String.IsNullOrEmpty(Trim(txtaddress.Text)) Then
            MessageBox.Show("Address field is required", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtaddress.Focus()
        ElseIf String.IsNullOrEmpty(Trim(txtremarks.Text)) Then
            MessageBox.Show("Remarks field is required", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtremarks.Focus()
        Else
            If lblheader.Text = "ADD BRANCH" Then
                add()
                Me.Close()
            ElseIf lblheader.Text = "EDIT BRANCH" Then
                edit()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub txtcode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtcode.KeyDown, txtsales.KeyDown, txtremarks.KeyDown, txtname.KeyDown, txtgr.KeyDown, txtaddress.KeyDown
        If e.KeyCode = Keys.Enter Then
            submit()
        End If
    End Sub

    Private Sub addbranch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If lblheader.Text = "ADD BRANCH" Then
            cmbstatus.SelectedIndex = 0
        ElseIf lblheader.Text = "EDIT BRANCH" Then
            brc.setID(brid)
            Dim dt As New DataTable()
            dt = brc.loadDataWhereID()
            For Each r0w As DataRow In dt.Rows
                current_branchcode = r0w("branchcode")
                txtcode.Text = r0w("branchcode")
                txtname.Text = r0w("branch")
                txtgr.Text = r0w("gr")
                txtsales.Text = r0w("sales")
                txtaddress.Text = r0w("address")
                txtremarks.Text = r0w("remarks")
                cmbstatus.Text = IIf(r0w("status") = 1, "Active", "In Active")
            Next
        End If
    End Sub
    Public Sub clear()
        txtcode.Text = ""
        txtname.Text = ""
        txtgr.Text = ""
        txtsales.Text = ""
        txtaddress.Text = ""
        txtremarks.Text = ""
    End Sub
    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        submit()
    End Sub
End Class