Imports System.Globalization
Imports System.IO
Imports System.Data.SqlClient
Imports AK_POS.connection_class
Public Class gcform
    Dim cc As New connection_class
    Dim strconn = cc.conString
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim sql As String

    Dim culture As CultureInfo = Nothing
    Public Shared gccnf As Boolean = False

    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function

    Public Sub connect()
        conn = New SqlConnection
        conn.ConnectionString = strconn
        If conn.State <> ConnectionState.Open Then
            conn.Open()
        End If
    End Sub

    Public Sub disconnect()
        conn = New SqlConnection
        conn.ConnectionString = strconn
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
    End Sub

    Private Sub gcform_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        If grdgc.Rows.Count <> 0 Then
            btnremove.Enabled = True
        Else
            btnremove.Enabled = False
        End If
    End Sub

    Private Sub btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
        If grdgc.Rows.Count <> 0 Then
            gccnf = False
            confirm.ShowDialog()
            If gccnf = True Then
                If Val(lblgctotal.Text) <> 0 Then
                    'merong gc
                    mainmenu.txtgc.Text = lblgctotal.Text
                    gccnf = True
                    Dim gcamt As Double = Double.Parse(grdgc.Rows(0).Cells(0).Value.ToString, culture)
                    'MsgBox(gcamt)
                    Me.Close()
                Else
                    gccnf = False
                    Me.Close()
                End If
            End If
        Else
            If (lblgctotal.Text.Equals("0.00")) Then
                mainmenu.txtgc.Text = "0.00"
            End If
            gccnf = False
            Me.Close()
        End If
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Dim a As String = MsgBox("Are you sure you want to cancel?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "")
        If a = vbYes Then
            grdgc.Rows.Clear()
            txtamt.Text = "100.00"
            txtserial.Text = ""
            lblgctotal.Text = "0.00"
            mainmenu.txtgc.Text = lblgctotal.Text
            gccnf = False
            Me.Close()
        End If
    End Sub

    Private Sub txtamt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtamt.KeyPress
        If Asc(e.KeyChar) = Windows.Forms.Keys.Enter Then
            btnadd.PerformClick()
        End If

        If Asc(e.KeyChar) <> 8 And Asc(e.KeyChar) <> 1 And Asc(e.KeyChar) <> 3 And Asc(e.KeyChar) <> 24 And Asc(e.KeyChar) <> 25 And Asc(e.KeyChar) <> 26 And Asc(e.KeyChar) <> 46 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            Else
                If Val(txtamt.Text) = 0 Then
                    If Asc(e.KeyChar) = 48 Then
                        e.Handled = True
                    Else
                        txtamt.Text = ""
                    End If
                End If
            End If
        Else
            If Asc(e.KeyChar) = 46 And Trim(txtamt.Text) <> "" And txtamt.Text.Contains(".") = False Then

            ElseIf Asc(e.KeyChar) = 46 And Trim(txtamt.Text) <> "" And txtamt.Text.Contains(".") = True Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtamt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtamt.Leave
        If txtamt.Text <> "" Then
            Dim num5 As Double = Double.Parse(txtamt.Text, culture)
            txtamt.Text = num5.ToString("n2")
        End If
    End Sub

    Private Sub txtserial_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtserial.KeyPress
        If Asc(e.KeyChar) = Windows.Forms.Keys.Enter Then
            btnadd.PerformClick()
        End If
    End Sub

    Private Sub txtserial_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtserial.Leave
        checkserial()
    End Sub

    Public Sub checkserial()
        Try
            If Trim(txtserial.Text) <> "" Then
                sql = "Select * from tblgctrans where serial='" & Trim(txtserial.Text) & "' and status='1'"
                connect()
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    MsgBox("Invalid Serial number.", MsgBoxStyle.Critical, "")
                    txtserial.Text = ""
                    txtserial.Focus()
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                dr.Dispose()
                cmd.Dispose()

                For Each row As DataGridViewRow In grdgc.Rows
                    If Trim(txtserial.Text) = grdgc.Rows(row.Index).Cells(1).Value Then
                        MsgBox("Serial number is already added.", MsgBoxStyle.Critical, "")
                        txtserial.Text = ""
                        txtserial.Focus()
                        Exit For
                    End If
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "")
        End Try
    End Sub

    Private Sub txtserial_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtserial.TextChanged
        Dim charactersDisallowed As String = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ 0123456789-"
        Dim theText As String = txtserial.Text
        Dim Letter As String
        Dim SelectionIndex As Integer = txtserial.SelectionStart
        Dim Change As Integer

        For x As Integer = 0 To txtserial.Text.Length - 1
            Letter = txtserial.Text.Substring(x, 1)
            If Not charactersDisallowed.Contains(Letter) Then
                theText = theText.Replace(Letter, String.Empty)
                Change = 1
            End If
        Next

        txtserial.Text = theText
        txtserial.Select(SelectionIndex - Change, 0)
    End Sub

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        If Trim(txtserial.Text) <> "" Then
            sql = "Select * from tblgctrans where serial='" & Trim(txtserial.Text) & "' and status='1'"
            connect()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            If dr.Read Then
                MsgBox("Invalid Serial number.", MsgBoxStyle.Critical, "")
                txtserial.Text = ""
                txtserial.Focus()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            dr.Dispose()
            cmd.Dispose()

            For Each row As DataGridViewRow In grdgc.Rows
                If Trim(txtserial.Text) = grdgc.Rows(row.Index).Cells(1).Value Then
                    MsgBox("Serial number is already added.", MsgBoxStyle.Critical, "")
                    txtserial.Text = ""
                    txtserial.Focus()
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
            Next
        End If


        If txtamt.Text <> "" And Trim(txtserial.Text) <> "" Then
            grdgc.Rows.Add(txtamt.Text, Trim(txtserial.Text))
            txtamt.Text = "100.00"
            txtserial.Text = ""
            txtserial.Focus()

            compute()
        Else
            MsgBox("Complete the fields.", MsgBoxStyle.Exclamation, "")
            txtamt.Focus()
        End If

        If grdgc.Rows.Count <> 0 Then
            btnremove.Enabled = True
        Else
            btnremove.Enabled = False
        End If
    End Sub

    Public Sub compute()
        Try
            Dim temp As Double = 0
            For Each row As DataGridViewRow In grdgc.Rows
                Dim num1 As Double = Double.Parse(grdgc.Rows(row.Index).Cells(0).Value.ToString, culture)
                temp = temp + Val(num1)
            Next

            lblgctotal.Text = temp.ToString("n2")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub btnclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclear.Click
        txtamt.Text = ""
        txtserial.Text = ""
        txtamt.Focus()
    End Sub

    Private Sub btnremove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnremove.Click
        grdgc.Rows.RemoveAt(grdgc.CurrentRow.Index)

        If grdgc.Rows.Count <> 0 Then
            btnremove.Enabled = True
        Else
            btnremove.Enabled = False
        End If

        compute()
        txtamt.Text = ""
    End Sub

    Private Sub gcform_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            btncancel.PerformClick()
        End If
    End Sub
End Class