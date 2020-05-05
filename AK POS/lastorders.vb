Imports System.Data.SqlClient
Public Class lastorders

    Dim strconn As String = login.ss
    Dim sql As String
    Dim con As New SqlConnection(strconn)
    Dim rdr As SqlDataReader
    Dim cmd As SqlCommand

    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Public Function getSystemDate() As DateTime
        Try
            Dim dt As New DateTime()
            con.Open()
            cmd = New SqlCommand("SELECT GETDATE()", con)
            rdr = cmd.ExecuteReader()
            While rdr.Read
                dt = CDate(rdr(0).ToString)
            End While
            con.Close()
            Return dt
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Function
    Private Sub lastorders_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.KeyPreview = True
            Dim serverDate As String = getSystemDate.ToString("MM/dd/yyyy")

            con.Open()
            cmd = New SqlCommand("SELECT TOP 10 ordernum,tendertype,status2 FROM tbltransaction2 WHERE cashier=@cashier AND CAST(datecreated AS date)=@date ORDER BY ordernum DESC", con)
            cmd.Parameters.AddWithValue("@cashier", login.username)
            cmd.Parameters.AddWithValue("@date", serverDate)
            rdr = cmd.ExecuteReader
            While rdr.Read
                dgvorders.Rows.Add(rdr("ordernum"), rdr("tendertype"), rdr("status2"))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub dgvorders_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvorders.CellClick
        Try
            Dim serverDate As String = getSystemDate.ToString("MM/dd/yyyy")

            dgvitems.Rows.Clear()

            con.Open()
            cmd = New SqlCommand("SELECT itemname,qty,price,dscnt,totalprice,free FROM tblorder2 WHERE ordernum=@ordernum AND CAST(datecreated AS date)=@date", con)
            cmd.Parameters.AddWithValue("@ordernum", dgvorders.CurrentRow.Cells("ordernum").Value)
            cmd.Parameters.AddWithValue("@date", serverDate)
            rdr = cmd.ExecuteReader
            While rdr.Read
                dgvitems.Rows.Add(rdr("itemname"), rdr("qty"), CDbl(rdr("price")), rdr("dscnt"), CDbl(rdr("totalprice")), IIf(rdr("free") = 1, True, False))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub lastorders_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub lblclose_Click(sender As Object, e As EventArgs) Handles lblclose.Click
        Me.Close()
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown, MyBase.MouseDown, Label1.MouseDown
        drag = True 'Sets the variable drag to true.
        mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'Sets variable mousey
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove, MyBase.MouseMove, Label1.MouseMove
        'If drag is set to true then move the form accordingly.
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp, MyBase.MouseUp, Label1.MouseUp
        drag = False 'Sets drag to false, so the form does not move according to the code in MouseMove
    End Sub
End Class