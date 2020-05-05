Imports System.IO
Imports System.Data.SqlClient
Imports System.Drawing

Public Class dsalesreport
    Dim strconn As String = login.ss
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim sql As String

    Public ctr As Boolean = False

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

    Private Sub dsalesreport_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        'dailysalesprev.Close()
        Me.WindowState = FormWindowState.Normal
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
    Private Sub dsalesreport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            datefrom.MaxDate = getSystemDate()
            dateto.MaxDate = getSystemDate()
            dateto.MinDate = datefrom.Value

            datefrom.Format = DateTimePickerFormat.Custom
            dateto.Format = DateTimePickerFormat.Custom

            datefrom.CustomFormat = "MM/dd/yyyy"
            dateto.CustomFormat = "MM/dd/yyyy"

            cash()
            loaddisc()

            cmbservice.SelectedIndex = 0
            cmbdisc.SelectedIndex = 0
            cmbcashier.SelectedIndex = 0
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Private Sub datefrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles datefrom.ValueChanged
        dateto.MinDate = datefrom.Value
        cash()
    End Sub

    Private Sub dateto_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dateto.ValueChanged
        cash()
    End Sub

    Private Sub btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim strnone As String = ""

            dailysalesprev.condition = " transdate>='" & Format(datefrom.Value, "MM/dd/yyyy") & "' and transdate<='" & Format(dateto.Value, "MM/dd/yyyy") & "' and refund='0'"

            If cmbcashier.SelectedItem <> "All" Then
                dailysalesprev.condition = dailysalesprev.condition & " and cashier='" & cmbcashier.SelectedItem & "'"
                dailysalesprev.cashr = cmbcashier.SelectedItem
            End If

            If cmbservice.SelectedIndex <> 0 Then
                dailysalesprev.condition = dailysalesprev.condition & " and servicetype='" & cmbservice.SelectedItem & "'"
            End If

            If cmbdisc.SelectedIndex = 1 Then
                dailysalesprev.condition = dailysalesprev.condition & " and disctype<>'" & strnone & "'"
            ElseIf cmbdisc.SelectedIndex = 2 Then
                dailysalesprev.condition = dailysalesprev.condition & " and disctype='" & strnone & "'"
            End If

            If cmbtype.Visible = True Then
                If cmbtype.SelectedIndex <> 0 Then
                    dailysalesprev.condition = dailysalesprev.condition & " and disctype='" & cmbtype.SelectedItem & "'"
                End If
            End If


            sql = "Select * from tbltransaction where" & dailysalesprev.condition
            connect()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            If dr.Read Then
                Me.Cursor = Cursors.WaitCursor
                If dailysalesprev.ctr = True Then
                    dailysalesprev.ShowDialog()
                    dailysalesprev.WindowState = FormWindowState.Normal
                    Me.Cursor = Cursors.Default
                    Me.Close()
                    Exit Sub
                End If
                '     dailysalesprev.MdiParent = mdiform
                dailysalesprev.Show()
                dailysalesprev.WindowState = FormWindowState.Maximized
                Me.Cursor = Cursors.Default
                Me.Close()
            Else
                MsgBox("No Found Record.", MsgBoxStyle.Critical, "")
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
        Me.Dispose()
    End Sub

    Public Sub cash()
        Try
            Me.Cursor = Cursors.WaitCursor
            cmbcashier.Items.Clear()
            cmbcashier.Items.Add("All")
            sql = "Select * from tbltransaction where transdate>='" & Format(datefrom.Value, "MM/dd/yyyy") & "' and transdate<='" & Format(dateto.Value, "MM/dd/yyyy") & "' "
            connect()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            While dr.Read
                If Not cmbcashier.Items.Contains(dr("cashier")) Then
                    cmbcashier.Items.Add(dr("cashier"))
                End If
            End While
            dr.Dispose()
            cmd.Dispose()

            cmbcashier.SelectedIndex = 0
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

    Private Sub cmbdisc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbdisc.SelectedIndexChanged
        If cmbdisc.SelectedIndex = 1 Then
            cmbtype.Visible = True
            Label6.Visible = True
        Else
            cmbtype.Visible = False
            Label6.Visible = False
        End If
    End Sub

    Public Sub loaddisc()
        Try
            Me.Cursor = Cursors.WaitCursor
            cmbtype.Items.Clear()
            cmbtype.Items.Add("All")
            sql = "Select * from tbldiscount where status='1'"
            connect()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            While dr.Read
                cmbtype.Items.Add(dr("disname"))
            End While
            cmd.Dispose()
            dr.Dispose()

            cmbtype.SelectedIndex = 0
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
End Class