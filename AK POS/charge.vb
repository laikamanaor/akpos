Imports System.IO
Imports System.Data.SqlClient
Imports System.Drawing

Public Class charge
    Dim strconn As String = login.ss
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim sql As String

    Public sn As Boolean = False, add As Boolean = False

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

    Private Sub senior_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        txtidno.Text = ""
        txtname.Text = ""
        txtclient.Text = ""
        cmbname.Items.Clear()
        cmbname.Text = ""
        txtidno.Focus()
        If add = False Then
            mainmenu.cmbdis.SelectedIndex = 0
        End If
    End Sub

    Private Sub senior_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtidno_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtidno.Leave
        Try
            cmbname.Items.Clear()
            If Trim(txtidno.Text) <> "" Then
                sql = "Select * from tblcharge where empid='" & Trim(txtidno.Text) & "' order by empname"
                connect()
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                While dr.Read
                    If Not cmbname.Items.Contains(dr("empname")) Then
                        cmbname.Items.Add(dr("empname"))
                    End If
                End While
                dr.Dispose()
                cmd.Dispose()
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Private Sub txtidno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtidno.TextChanged
        Dim charactersDisallowed As String = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ 0123456789.-/"
        Dim theText As String = txtidno.Text
        Dim Letter As String
        Dim SelectionIndex As Integer = txtidno.SelectionStart
        Dim Change As Integer

        For x As Integer = 0 To txtidno.Text.Length - 1
            Letter = txtidno.Text.Substring(x, 1)
            If Not charactersDisallowed.Contains(Letter) Then
                theText = theText.Replace(Letter, String.Empty)
                Change = 1
            End If
        Next

        txtidno.Text = theText
        txtidno.Select(SelectionIndex - Change, 0)
    End Sub

    Private Sub txtname_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtname.Leave
        txtname.Text = StrConv(txtname.Text, VbStrConv.ProperCase)
    End Sub

    Private Sub txtname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtname.TextChanged
        Dim charactersDisallowed As String = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ 0123456789.-/"
        Dim theText As String = txtname.Text
        Dim Letter As String
        Dim SelectionIndex As Integer = txtname.SelectionStart
        Dim Change As Integer

        For x As Integer = 0 To txtname.Text.Length - 1
            Letter = txtname.Text.Substring(x, 1)
            If Not charactersDisallowed.Contains(Letter) Then
                theText = theText.Replace(Letter, String.Empty)
                Change = 1
            End If
        Next

        txtname.Text = theText
        txtname.Select(SelectionIndex - Change, 0)
    End Sub

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        Try
            txtname.Text = Trim(cmbname.Text)
            If Trim(txtidno.Text) <> "" And Trim(txtname.Text) <> "" And Trim(txtclient.Text) <> "" Then
                chargeform.lblidno.Text = Trim(txtidno.Text)
                chargeform.lblname.Text = Trim(cmbname.Text)
                chargeform.lblclient.Text = Trim(txtclient.Text)
                add = True
                sn = False
                Me.Cursor = Cursors.Default
                cmbname.Items.Clear()
                cmbname.Text = ""
                Me.Close()
            Else
                MsgBox("Complete the fields.", MsgBoxStyle.Exclamation, "")
                txtidno.Focus()
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        mainmenu.cmbdis.SelectedIndex = 0
        chargeform.lblidno.Text = ""
        chargeform.lblname.Text = ""
        chargeform.lblclient.Text = ""

        Me.Close()
    End Sub

    Private Sub cmbname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbname.KeyPress
        If Asc(e.KeyChar) = Windows.Forms.Keys.Enter Then
            txtname.Text = Trim(cmbname.Text)
            btnadd.PerformClick()
        End If
    End Sub

    Private Sub cmbname_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Leave
        txtname.Text = Trim(cmbname.Text)
    End Sub

    Private Sub cmbname_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.SelectedValueChanged
        txtname.Text = Trim(cmbname.Text)
    End Sub

    Private Sub cmbname_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbname.SelectedIndexChanged

    End Sub

    Private Sub cmbname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.TextChanged
        Dim charactersDisallowed As String = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ 0123456789.-/"
        Dim theText As String = txtidno.Text
        Dim Letter As String
        Dim SelectionIndex As Integer = txtidno.SelectionStart
        Dim Change As Integer

        For x As Integer = 0 To txtidno.Text.Length - 1
            Letter = txtidno.Text.Substring(x, 1)
            If Not charactersDisallowed.Contains(Letter) Then
                theText = theText.Replace(Letter, String.Empty)
                Change = 1
            End If
        Next

        txtidno.Text = theText
        txtidno.Select(SelectionIndex - Change, 0)
    End Sub

    Private Sub txtclient_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtclient.TextChanged
        Dim charactersDisallowed As String = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ 0123456789.-/"
        Dim theText As String = txtclient.Text
        Dim Letter As String
        Dim SelectionIndex As Integer = txtclient.SelectionStart
        Dim Change As Integer

        For x As Integer = 0 To txtclient.Text.Length - 1
            Letter = txtclient.Text.Substring(x, 1)
            If Not charactersDisallowed.Contains(Letter) Then
                theText = theText.Replace(Letter, String.Empty)
                Change = 1
            End If
        Next

        txtclient.Text = theText
        txtclient.Select(SelectionIndex - Change, 0)
    End Sub
End Class