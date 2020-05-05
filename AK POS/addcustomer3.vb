Imports System.Data.SqlClient
Imports AK_POS.connection_class
Public Class addcustomer3
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Dim cc As New connection_class
    Dim con As New SqlConnection(cc.conString)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Private Sub lblclose_Click(sender As Object, e As EventArgs) Handles lblclose.Click
        Me.Close()
    End Sub

    Private Sub addcustomer3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbtype.SelectedIndex = 0
    End Sub

    Private Sub addcustomer3_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
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

    ''' <summary>
    ''' check column name value if exist
    ''' </summary>
    ''' <returns></returns>
    Public Function checkValue(ByVal columnName As String, ByVal txt As TextBox) As Boolean
        Dim nameExist As Boolean = False
        con.Open()
        cmd = New SqlCommand("SELECT customer_id FROM tblcustomers WHERE " & columnName & "=@name;", con)
        cmd.Parameters.AddWithValue("@name", txt.Text)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            nameExist = True
        End If
        con.Close()

        Return nameExist
    End Function

    ''' <summary>
    ''' add customer method
    ''' </summary>
    Public Sub add()
        Try
            If String.IsNullOrEmpty(txtname.Text) Then
                MessageBox.Show("Name field is empty", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtname.Focus()
            ElseIf String.IsNullOrEmpty(txtcode.Text) Then
                MessageBox.Show("Code field is empty", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtcode.Focus()
            ElseIf String.IsNullOrEmpty(txtcontactnum.Text) Then
                MessageBox.Show("Contact # field is empty", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtcontactnum.Focus()
            ElseIf String.IsNullOrEmpty(txtaddress.Text) Then
                MessageBox.Show("Address field is empty", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtaddress.Focus()
            ElseIf checkValue("name", txtname) Then
                MessageBox.Show("Name field is already exist", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtname.Focus()
            ElseIf checkValue("code", txtcode) Then
                MessageBox.Show("Code field is already exist", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtcode.Focus()
            Else
                con.Open()
                cmd = New SqlCommand("insertCustomers", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@name", txtname.Text)
                cmd.Parameters.AddWithValue("@code", txtcode.Text)
                cmd.Parameters.AddWithValue("@contact_number", txtcontactnum.Text)
                cmd.Parameters.AddWithValue("@address", txtaddress.Text)
                cmd.Parameters.AddWithValue("@createdby", login.username)
                cmd.Parameters.AddWithValue("@type", cmbtype.Text)
                cmd.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("Added", "Atantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub TextBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtcontactnum.KeyDown, txtaddress.KeyDown, txtcode.KeyDown, txtname.KeyDown, cmbtype.KeyDown
        If e.KeyCode = Keys.Enter Then
            add()
        End If
    End Sub

    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        add()
    End Sub
End Class