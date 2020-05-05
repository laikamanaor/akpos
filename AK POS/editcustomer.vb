Imports System.Data.SqlClient
Imports System.IO
Imports AK_POS.connection_class
Public Class editcustomer
    Dim cc As New connection_class
    Dim strconn As String = cc.conString
    Dim con As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim adptr As New SqlDataAdapter
    Public id As Integer = 0
    Dim current_name As String = ""

    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function
    Public Sub edit()
        If txtname.Text = "" And txtboxContactNo.Text = "" And txtboxAddress.Text = "" Then
            MessageBox.Show("Fields is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf txtname.Text = "" Then
            MessageBox.Show("Name is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf txtboxContactNo.Text = "" Then
            MessageBox.Show("Contact No. is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf txtboxAddress.Text = "" Then
            MessageBox.Show("Address is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        con.Open()
        cmd = New SqlCommand("SELECT name FROM tblcustomers WHERE name=@name", con)
        cmd.Parameters.AddWithValue("@name", txtname.Text)
        rdr = cmd.ExecuteReader()
        If rdr.Read() Then
            If current_name <> rdr("name") Then
                MessageBox.Show("Name is already registered", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                con.Close()
                Exit Sub
            End If
        End If
        con.Close()
        Dim q As String = ""
        If cmbStatus.Text = "Active" Then
            q = "1"
        ElseIf cmbStatus.Text = "In Active" Then
            q = "0"
        End If
        con.Open()
        cmd = New SqlCommand("UPDATE tblcustomers SET name=@neym,contact_number=@contact,code=@code, address=@address, status=@status WHERE customer_id=@cus_id", con)
        cmd.Parameters.AddWithValue("@code", txtcode.Text)
        cmd.Parameters.AddWithValue("@neym", txtname.Text)
        cmd.Parameters.AddWithValue("@contact", txtboxContactNo.Text)
        cmd.Parameters.AddWithValue("@address", txtboxAddress.Text)
        cmd.Parameters.AddWithValue("@cus_id", id)
        cmd.Parameters.AddWithValue("@status", q)
        cmd.ExecuteNonQuery()
        con.Close()
        MessageBox.Show("Info updated", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        edit()
    End Sub

    Private Sub editcustomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        current_name = txtname.Text
    End Sub

    Private Sub txtboxContactNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtboxContactNo.KeyPress
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub editcustomer_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub txtname_KeyDown(sender As Object, e As KeyEventArgs) Handles txtname.KeyDown, txtcode.KeyDown, txtboxContactNo.KeyDown, txtboxAddress.KeyDown, cmbStatus.KeyDown
        If e.KeyCode = Keys.Enter Then
            edit()
        End If
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown, MyBase.MouseDown, lblheader.MouseDown
        drag = True 'Sets the variable drag to true.
        mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'Sets variable mousey
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove, MyBase.MouseMove, lblheader.MouseMove
        'If drag is set to true then move the form accordingly.
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp, MyBase.MouseUp, lblheader.MouseUp
        drag = False 'Sets drag to false, so the form does not move according to the code in MouseMove
    End Sub

    Private Sub lblclose_Click(sender As Object, e As EventArgs) Handles lblclose.Click
        Me.Close()
    End Sub
End Class