Imports System.Data.SqlClient
Imports System.IO

Public Class reprintor
    Dim strconn As String = login.ss
    Dim sql As String
    Dim conn As SqlConnection
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Dim dscmd As New SqlDataAdapter
    Public ds As New DataSet1
    Public sqlquery As String
    Public constring As String
    Dim trnum As String = ""
    Dim meron As Integer = 0, mali As Integer = 0
    Public yesprint As Boolean = False

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

    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function

    Private Sub txttrans_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttrans.KeyPress
        If Asc(e.KeyChar) = Windows.Forms.Keys.Enter And Trim(txttrans.Text) <> "" Then
            btnprint.PerformClick()
        End If
    End Sub

    Private Sub txttrans_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttrans.TextChanged
        Dim charactersDisallowed As String = "0123456789-"
        Dim theText As String = txttrans.Text
        Dim Letter As String
        Dim SelectionIndex As Integer = txttrans.SelectionStart
        Dim Change As Integer

        For x As Integer = 0 To txttrans.Text.Length - 1
            Letter = txttrans.Text.Substring(x, 1)
            If Not charactersDisallowed.Contains(Letter) Then
                theText = theText.Replace(Letter, String.Empty)
                Change = 1
            End If
        Next

        txttrans.Text = theText
        txttrans.Select(SelectionIndex - Change, 0)

        If Trim(txttrans.Text) <> "" Then
            datefrom.Enabled = False
            cmbcash.Enabled = False
            btnprint.Enabled = True
        Else
            datefrom.Enabled = True
            cmbcash.Enabled = True
            btnprint.Enabled = True
        End If
    End Sub

    Private Sub btnprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnprint.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If datefrom.Enabled = False Then
                'validate transnum first
                transnum()
                If mali = 1 Then
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                'MsgBox("single transaction")
                Dim a As String = MsgBox("Are you sure you want to re-print receipt of transaction " & Trim(txttrans.Text) & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "")
                If a <> vbYes Then
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                Me.Cursor = Cursors.Default
                '/ confirm.ShowDialog()
                '/ If yesprint = True Then
                'check muna if may tblorder sya
                Dim order As Boolean = False
                sql = "Select * from tblorder where transnum='" & Trim(txttrans.Text) & "'"
                connect()
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    order = True
                    Me.Cursor = Cursors.Default
                Else
                    reprintinvalid.sngle = True
                    reprintinvalid.condition = " where transnum='" & Trim(txttrans.Text) & "'"
                    reprintinvalid.ShowDialog()
                    Me.Cursor = Cursors.Default
                End If
                dr.Dispose()
                cmd.Dispose()

                If order = True Then
                    sql = "Select * from tbltransaction where transnum='" & Trim(txttrans.Text) & "' and gctotal<>'0'"
                    connect()
                    cmd = New SqlCommand(sql, conn)
                    dr = cmd.ExecuteReader
                    If dr.Read Then
                        reprintgc.sngle = True
                        reprintgc.condition = " where transnum='" & Trim(txttrans.Text) & "'"
                        reprintgc.ShowDialog()
                        Me.Cursor = Cursors.Default
                    Else
                        reprintnew.sngle = True
                        reprintnew.condition = " where transnum='" & Trim(txttrans.Text) & "'"
                        reprintnew.ShowDialog()
                        Me.Cursor = Cursors.Default
                    End If
                    dr.Dispose()
                    cmd.Dispose()
                End If

                '/End If
                '/yesprint = False
            Else
                If cmbcash.Items.Count = 0 Then
                    MsgBox("No Record Found.", MsgBoxStyle.Critical, "")
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                'MsgBox("multiple transaction")
                Dim a As String = MsgBox("Are you sure you want to re-print receipt of transactions of " & Format(datefrom.Value, "MM/dd/yyyy") & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "")
                If a <> vbYes Then
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                Me.Cursor = Cursors.Default
                confirm.ShowDialog()
                If yesprint = True Then
                    reprintnew.multiple = True
                    If cmbcash.SelectedItem = "All" Then
                        reprintnew.condition = " where transdate='" & Format(datefrom.Value, "MM/dd/yyyy") & "'"
                    Else
                        reprintnew.condition = " where transdate='" & Format(datefrom.Value, "MM/dd/yyyy") & "' and cashier='" & cmbcash.SelectedItem & "'"
                    End If
                    reprintnew.ShowDialog()
                    Me.Cursor = Cursors.Default
                End If
                yesprint = False
            End If
            Me.Cursor = Cursors.Default

            txttrans.Text = ""
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Private Sub reprintor_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cmbcash.Items.Clear()
        txttrans.Text = ""
        txttrans.Focus()
    End Sub
    Public Function getSystemDate() As DateTime
        Try
            Dim dt As New DateTime()
            connect()
            cmd = New SqlCommand("SELECT GETDATE()", conn)
            dr = cmd.ExecuteReader()
            While dr.Read
                dt = CDate(dr(0).ToString)
            End While
            disconnect()
            Return dt
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            disconnect()
        End Try
    End Function
    Private Sub reprintor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbcash.Items.Clear()
        datefrom.MaxDate = getSystemDate()

        datefrom.Format = DateTimePickerFormat.Custom
        datefrom.CustomFormat = "MM/dd/yyyy"

        loadcashier()
    End Sub

    Public Sub loadcashier()
        Try
            Me.Cursor = Cursors.WaitCursor
            cmbcash.Items.Clear()
            meron = 0
            sql = "Select * from tbltransaction where transdate='" & Format(datefrom.Value, "MM/dd/yyyy") & "' order by cashier"
            connect()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            While dr.Read
                If dr("cashier").ToString <> "" And Not cmbcash.Items.Contains(dr("cashier").ToString) Then
                    meron = 1
                    cmbcash.Items.Add(dr("cashier"))
                End If
            End While
            dr.Dispose()
            cmd.Dispose()

            If meron = 1 Then
                cmbcash.Items.Add("All")
                cmbcash.SelectedItem = "All"
                btnprint.Enabled = True
            End If

            Me.Cursor = Cursors.Default
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Private Sub datefrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles datefrom.ValueChanged
        cmbcash.Items.Clear()

        loadcashier()
        If cmbcash.Items.Count <> 0 Then
            cmbcash.SelectedItem = "All"
        End If
        If cmbcash.Text = "" Then
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        'btnprint.PerformClick()
    End Sub

    Private Sub cmbcash_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcash.SelectedIndexChanged
        'loadcashier()
        'btnprint.PerformClick()
    End Sub

    Public Sub transnum()
        Try
            Me.Cursor = Cursors.WaitCursor
            mali = 0
            sql = "Select * from tbltransaction where transnum='" & Trim(txttrans.Text) & "'"
            connect()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            If dr.Read Then

            Else
                mali = 1
                MsgBox("Invalid transaction number.", MsgBoxStyle.Exclamation, "")
                txttrans.Text = ""
            End If
            dr.Dispose()
            cmd.Dispose()
            Me.Cursor = Cursors.Default
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        txttrans.Text = ""
        Me.Close()
    End Sub
End Class