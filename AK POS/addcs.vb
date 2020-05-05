Imports System.Data.SqlClient
Public Class addcs

    Dim strconn As String = login.ss
    Dim con As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim adptr As New SqlDataAdapter

    Public csid As Integer = 0
    Private Sub addcs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblheader.Text = Me.Text
        Try
            Dim auto As New AutoCompleteStringCollection()
            con.Open()
            cmd = New SqlCommand("SELECT itemname FROM tblitems WHERE discontinued=0 AND category='Coffee Shop';", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                auto.Add(rdr("itemname"))
            End While
            con.Close()
            txt.AutoCompleteCustomSource = auto
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub


    Public Function isCheckedItem() As Boolean
        Dim result As Boolean = False
        con.Open()
        cmd = New SqlCommand("SELECT itemid FROM tblitems WHERE itemname=@itemname AND category='Coffee Shop';", con)
        cmd.Parameters.AddWithValue("@itemname", Trim(txt.Text))
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            result = True
        End If
        con.Close()
        Return result
    End Function

    Public Function isCheckCS() As Boolean
        Dim result As Boolean = False
        con.Open()
        cmd = New SqlCommand("SELECT itemid FROM tblcsitems WHERE itemid=(SELECT itemid FROM tblitems WHERE itemname=@itemname AND category='Coffee Shop');", con)
        cmd.Parameters.AddWithValue("@itemname", Trim(txt.Text))
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            result = True
        End If
        con.Close()
        Return result
    End Function
    Public Sub add()
        Try
            If String.IsNullOrEmpty(txt.Text) Then
                MessageBox.Show("Item field is required", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt.Focus()
            ElseIf isCheckedItem() = False Then
                MessageBox.Show(txt.Text & " not found", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt.Focus()
            ElseIf isCheckCS() = True Then
                MessageBox.Show(txt.Text & " is already exist", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt.Focus()
            ElseIf String.IsNullOrEmpty(txtfree.Text) Then
                MessageBox.Show("Free quantity field is required", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtfree.Focus()
            ElseIf CInt(txtfree.Text) < 0 Then
                MessageBox.Show("Miminum free quantity is 1", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtfree.Focus()
            ElseIf CInt(txtfree.Text) > 10 Then
                MessageBox.Show("Maximum free quantity is 10", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtfree.Focus()
            Else
                con.Open()
                cmd = New SqlCommand("INSERT INTO tblcsitems (itemid,free,datecreated,datemodified,createdby,modifiedby) VALUES ((SELECT itemid FROM tblitems WHERE itemname=@itemname),@free,(SELECT GETDATE()),(SELECT GETDATE()),(SELECT systemid FROM tblusers WHERE username=@username),(SELECT systemid FROM tblusers WHERE username=@username) );", con)
                cmd.Parameters.AddWithValue("@itemname", Trim(txt.Text))
                cmd.Parameters.AddWithValue("@username", login.username)
                cmd.Parameters.AddWithValue("@free", txtfree.text)
                cmd.ExecuteNonQuery()
                con.Close()

                MessageBox.Show("Item " & IIf(Me.Text = "Add", "Added", "Saved"), "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txt.Text = ""
                txtfree.Text = ""
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Sub updatequantity()
        Try

            If CInt(txtfree.Text) < 0 Then
                MessageBox.Show("Miminum free quantity is 1", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtfree.Focus()
            ElseIf CInt(txtfree.Text) > 10 Then
                MessageBox.Show("Maximum free quantity is 10", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtfree.Focus()
            Else
                con.Open()
                cmd = New SqlCommand("UPDATE tblcsitems SET free=@free WHERE csid=@csid", con)
                cmd.Parameters.AddWithValue("@free", txtfree.Text)
                cmd.Parameters.AddWithValue("@csid", csid)
                cmd.ExecuteNonQuery()
                con.Close()


                MessageBox.Show("Item " & IIf(Me.Text = "Add", "Added", "Saved"), "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txt.Text = ""
                txtfree.Text = ""
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub final()
        If Me.Text = "Add" Then
            add()
        Else
            updatequantity()
        End If
    End Sub
    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        final()
    End Sub

    Private Sub txt_KeyDown(sender As Object, e As KeyEventArgs) Handles txt.KeyDown
        If e.KeyCode = Keys.Enter Then
            final()
        End If
    End Sub

    Private Sub txtfree_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtfree.KeyPress
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtfree_KeyDown(sender As Object, e As KeyEventArgs) Handles txtfree.KeyDown
        If e.KeyCode = Keys.Enter Then
            final()
        End If
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Me.Close()
    End Sub
End Class