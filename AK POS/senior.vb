Imports System.IO
Imports System.Data.SqlClient
Imports System.Drawing
Imports AK_POS.connection_class
Imports AK_POS.ui_class
Public Class senior
    Dim cc As New connection_class, uic As New ui_class()
    Dim strconn As String = cc.conString
    Dim conn As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim sql As String

    Public sn As Boolean = False, add As Boolean = False
    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        If String.IsNullOrEmpty(Trim(txtidno.Text)) Then
            MessageBox.Show("ID Number is required", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf String.IsNullOrEmpty(Trim(txtname.Text)) Then
            MessageBox.Show("Name is required", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            add = True
            sn = False
            Me.Cursor = Cursors.Default
            Me.Hide()
        End If
    End Sub

    Private Sub senior_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown, MyBase.MouseDown, Label3.MouseDown, Label2.MouseDown, Label1.MouseDown
        uic.mouse_down(Me)
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove, MyBase.MouseMove, Label3.MouseMove, Label2.MouseMove, Label1.MouseMove
        uic.mouse_move(Me)
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp, MyBase.MouseUp, Label3.MouseUp, Label2.MouseUp, Label1.MouseUp
        uic.mouse_up()
    End Sub

    Private Sub senior_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            mainmenu.cmbdis.SelectedIndex = 0
            add = False
            Me.Hide()
        End If
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        mainmenu.cmbdis.SelectedIndex = 0
        add = False
        Me.Hide()
    End Sub
End Class