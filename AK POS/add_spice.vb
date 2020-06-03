Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports System.Security
Imports System.Security.Cryptography
Imports AK_POS.connection_class
Public Class add_spice
    Dim cc As New connection_class
    Dim con As New SqlConnection(cc.conString)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim adptr As New SqlDataAdapter

    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub
    Private Sub add_spice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dateap.Text = getSystemDate.ToString("MM/dd/yyyy")
        datedep.Text = getSystemDate.ToString("MM/dd/yyyy")
        dateap.MaxDate = getSystemDate()
        datedep.MaxDate = getSystemDate()
    End Sub

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

    Private Sub btnsubmit_Click(sender As Object, e As EventArgs) Handles btnsubmit.Click
        ' you want to split this input string
        Dim s As String = ""
        'loop 1
        For index As Integer = 0 To dgvap.Rows.Count - 1
            If CBool(dgvap.Rows(index).Cells("select1").Value) = True Then
                s &= CStr(dgvap.Rows(index).Cells("id1").Value) & ","
            End If
        Next
        'loop 2
        For index As Integer = 0 To dgvdep.Rows.Count - 1
            If CBool(dgvdep.Rows(index).Cells("select2").Value) = True Then
                s &= CStr(dgvdep.Rows(index).Cells("id2").Value) & ","
            End If
        Next
        ' Split string based on comma
        Dim words() As String = s.Split(New Char() {","c})

        ' Use For Each loop over words and display them

        If String.IsNullOrEmpty(s) Then
            MessageBox.Show("Please select alteast one.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim word As String
            For Each word In words
                If Not String.IsNullOrEmpty(word) Then
                    cashier.txtresult.Text &= word & ","
                    cashier2.apdep &= word & ","
                End If
            Next
            Me.Dispose()
        End If
    End Sub
    Public Sub loadAdvancePayment()
        Try
            Dim auto As New AutoCompleteStringCollection()
            dgvap.Rows.Clear()
            con.Open()
            cmd = New SqlCommand("SELECT apnum,name,amount,date FROM tbladvancepayment WHERE type='Advance Payment' AND status='Active' AND CAST (date AS date)='" & dateap.Text & "';", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                dgvap.Rows.Add(False, rdr("apnum"), rdr("name"), CDbl(rdr("amount")).ToString("n2"), CDate(rdr("date")).ToString("MM/dd/yyyy hh:mm"))
                auto.Add(rdr("apnum"))
                auto.Add(rdr("name"))
            End While
            con.Close()
            txtap.AutoCompleteCustomSource = auto
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub loadDeposit()
        Try
            Dim auto As New AutoCompleteStringCollection()
            dgvdep.Rows.Clear()
            con.Open()
            cmd = New SqlCommand("SELECT apnum, name, amount, Date FROM tbladvancepayment WHERE type='Deposit'  AND status='Active' AND CAST (date AS date)='" & datedep.Text & "';", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                dgvdep.Rows.Add(False, rdr("apnum"), rdr("name"), CDbl(rdr("amount")).ToString("n2"), CDate(rdr("date")).ToString("MM/dd/yyyy hh:mm"))
                auto.Add(rdr("apnum"))
                auto.Add(rdr("name"))
            End While
            con.Close()
            txtdep.AutoCompleteCustomSource = auto
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub add_spice_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        loadAdvancePayment()
        loadDeposit()
    End Sub

    Private Sub dateap_ValueChanged(sender As Object, e As EventArgs) Handles dateap.ValueChanged
        loadAdvancePayment()
        txtap.Text = ""
    End Sub

    Private Sub datedep_ValueChanged(sender As Object, e As EventArgs) Handles datedep.ValueChanged
        loadDeposit()
        txtdep.Text = ""
    End Sub

    Private Sub add_spice_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown, MyBase.MouseDown, Label1.MouseDown
        drag = True 'Sets the variable drag to true.
        mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'Sets variable mousey
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove, MyBase.MouseMove, Label1.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp, MyBase.MouseUp, Label1.MouseUp
        drag = False 'Sets drag to false, so the form does not move according to the code in MouseMove
    End Sub
End Class