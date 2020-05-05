Imports System.IO
Imports System.Data.SqlClient

Public Class transferform
    Dim strconn As String = login.ss
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim sql As String

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

    Private Sub transferform_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dateto.MinDate = datefrom.Value
        dateto.MaxDate = Date.Now
        datefrom.MaxDate = Date.Now

        datefrom.Format = DateTimePickerFormat.Custom
        dateto.Format = DateTimePickerFormat.Custom

        datefrom.CustomFormat = "MM/dd/yyyy"
        dateto.CustomFormat = "MM/dd/yyyy"

        btnviewall.PerformClick()
    End Sub

    Private Sub btnviewall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewall.Click
        Try
            branch()

            grdtransfer.Rows.Clear()
            cmbtrans.Items.Clear()

            txttrans.Text = ""
            cmbbranch.SelectedItem = ""

            Dim dfrom As DateTime = CDate(Format(datefrom.Value, "MM/dd/yyyy"))
            Dim dto As DateTime = CDate(Format(dateto.Value, "MM/dd/yyyy"))

            sql = "Select * from tbltransaction where transdate>='" & dfrom & "' and transdate<='" & dto & "' and refund='0' and servicetype='Transfer'"
            connect()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            While dr.Read
                cmbtrans.Items.Add(dr("transnum"))
            End While
            dr.Dispose()
            cmd.Dispose()

            connect()
            For i = 0 To cmbtrans.Items.Count - 1
                cmbtrans.SelectedIndex = i
                sql = "Select * from tbltransfer where transnum='" & cmbtrans.SelectedItem & "' order by branch"
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    grdtransfer.Rows.Add(dr("trid"), dr("branch"), cmbtrans.SelectedItem, 0)
                End If
                dr.Dispose()
                cmd.Dispose()
            Next

            connect()
            For Each row As DataGridViewRow In grdtransfer.Rows
                sql = "Select * from tbltransaction where transnum='" & grdtransfer.Rows(row.Index).Cells(2).Value & "'"
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    grdtransfer.Rows(row.Index).Cells(3).Value = dr("amtdue")
                End If
                dr.Dispose()
                cmd.Dispose()
            Next

            total()

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

    Public Sub branch()
        Try
            cmbbranch.Items.Clear()
            cmbbranch.Items.Add("")

            sql = "Select * from tblbranch where status='1' order by branch"
            connect()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            While dr.Read
                cmbbranch.Items.Add(dr("branch"))
            End While
            dr.Dispose()
            cmd.Dispose()

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

    Public Sub total()
        Try
            If grdtransfer.Rows.Count <> 0 Then
                Dim temp As Double = 0
                For Each row As DataGridViewRow In grdtransfer.Rows
                    temp += grdtransfer.Rows(row.Index).Cells(3).Value
                Next

                totalsales.Text = temp.ToString("n2")
            Else
                totalsales.Text = "0.00"
                MsgBox("No Record Found.", MsgBoxStyle.Critical, "")
            End If
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
        dateto.MinDate = datefrom.Value
    End Sub

    Private Sub btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
        Try
            grdtransfer.Rows.Clear()
            cmbtrans.Items.Clear()

            Dim dfrom As DateTime = CDate(Format(datefrom.Value, "MM/dd/yyyy"))
            Dim dto As DateTime = CDate(Format(dateto.Value, "MM/dd/yyyy"))

            sql = "Select * from tbltransaction where transdate>='" & dfrom & "' and transdate<='" & dto & "' and refund='0' and servicetype='Transfer'"
            If Trim(txttrans.Text) <> "" Then
                sql = sql & " and transnum='" & Trim(txttrans.Text) & "'"
            End If
            connect()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            While dr.Read
                cmbtrans.Items.Add(dr("transnum"))
            End While
            dr.Dispose()
            cmd.Dispose()

            connect()
            For i = 0 To cmbtrans.Items.Count - 1
                cmbtrans.SelectedIndex = i
                sql = "Select * from tbltransfer where transnum='" & cmbtrans.SelectedItem & "'"
                If cmbbranch.SelectedItem <> "" Then
                    sql = sql & " and branch='" & cmbbranch.SelectedItem & "'"
                End If
                sql = sql & " order by branch"
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    grdtransfer.Rows.Add(dr("trid"), dr("branch"), cmbtrans.SelectedItem, 0)
                End If
                dr.Dispose()
                cmd.Dispose()
            Next

            connect()
            For Each row As DataGridViewRow In grdtransfer.Rows
                sql = "Select * from tbltransaction where transnum='" & grdtransfer.Rows(row.Index).Cells(2).Value & "'"
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    grdtransfer.Rows(row.Index).Cells(3).Value = dr("amtdue")
                End If
                dr.Dispose()
                cmd.Dispose()
            Next

            total()

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

    Private Sub txttrans_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttrans.TextChanged
        If Trim(txttrans.Text) = "" And cmbbranch.SelectedItem = "" Then
            btnok.Enabled = False
        Else
            btnok.Enabled = True
        End If
    End Sub

    Private Sub cmbbranch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbbranch.SelectedIndexChanged
        If Trim(txttrans.Text) = "" And cmbbranch.SelectedItem = "" Then
            btnok.Enabled = False
        Else
            btnok.Enabled = True
        End If
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        txttrans.Text = ""
        cmbbranch.SelectedItem = ""
        txttrans.Focus()
    End Sub
End Class