Imports System.IO
Imports System.Data.SqlClient
Imports System.Globalization

Public Class salessum
    Dim strconn As String = login.ss
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim sql As String

    Dim culture As CultureInfo = Nothing
    Public ds As New DataSet

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
        If conn.State <> ConnectionState.Open Then
            conn.Close()
        End If
    End Sub

    Public Sub loadCashiers()
        Try
            cmbCashiers.Items.Clear()
            cmbCashiers.Items.Add("All")
            cmbCashiers2.Items.Add("All")
            cmbCashiers3.Items.Add("All")
            connect()
            cmd = New SqlCommand("Select * from tbltransaction where transdate>='" & Format(datefrom.Value, "MM/dd/yyyy") & "' and transdate<='" & Format(dateto.Value, "MM/dd/yyyy") & "' ", conn)
            dr = cmd.ExecuteReader()
            While dr.Read
                If Not cmbCashiers.Items.Contains(dr("cashier")) Then
                    cmbCashiers.Items.Add(dr("cashier"))
                End If
                If Not cmbCashiers2.Items.Contains(dr("cashier")) Then
                    cmbCashiers2.Items.Add(dr("cashier"))
                End If
                If Not cmbCashiers3.Items.Contains(dr("cashier")) Then
                    cmbCashiers3.Items.Add(dr("cashier"))
                End If
            End While
            cmd.Dispose()
        Catch ex As Exception
        Finally
            disconnect()
        End Try
    End Sub
    Private Sub salessum_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor
        grdhour.Columns.Add("asd", "SHAJ")
        grdhour.Columns("asd").Visible = False

        dateto1.MinDate = datefrom1.Value
        dateto1.MaxDate = Date.Now
        datefrom1.MaxDate = Date.Now

        datefrom1.Format = DateTimePickerFormat.Custom
        dateto1.Format = DateTimePickerFormat.Custom

        datefrom1.CustomFormat = "MM/dd/yyyy"
        dateto1.CustomFormat = "MM/dd/yyyy"

        '/////////////////////////////////////////////////////

        dateto.MinDate = datefrom.Value
        dateto.MaxDate = Date.Now
        datefrom.MaxDate = Date.Now

        datefrom.Format = DateTimePickerFormat.Custom
        dateto.Format = DateTimePickerFormat.Custom

        datefrom.CustomFormat = "MM/dd/yyyy"
        dateto.CustomFormat = "MM/dd/yyyy"

        grddaily.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grddaily.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grddaily.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grddaily.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grddaily.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grddaily.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        For Each col As DataGridViewColumn In grdhour.Columns
            grdhour.Columns(col.Index).ReadOnly = True
        Next

        grdhour.Columns(2).HeaderCell.Style.BackColor = Color.FromArgb(255, 255, 128)
        grdhour.Columns(3).HeaderCell.Style.BackColor = Color.FromArgb(255, 255, 128)
        grdhour.Columns(4).HeaderCell.Style.BackColor = Color.FromArgb(128, 255, 128)
        grdhour.Columns(5).HeaderCell.Style.BackColor = Color.FromArgb(128, 255, 128)
        grdhour.Columns(6).HeaderCell.Style.BackColor = Color.FromArgb(192, 192, 255)
        grdhour.Columns(7).HeaderCell.Style.BackColor = Color.FromArgb(192, 192, 255)

        grdmonth.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        hourly(cmbCashiers.Text)

        grddaily.Columns(1).HeaderCell.Style.BackColor = Color.FromArgb(255, 255, 128)
        grddaily.Columns(2).HeaderCell.Style.BackColor = Color.FromArgb(255, 255, 128)
        grddaily.Columns(3).HeaderCell.Style.BackColor = Color.FromArgb(128, 255, 128)
        grddaily.Columns(4).HeaderCell.Style.BackColor = Color.FromArgb(128, 255, 128)
        grddaily.Columns(5).HeaderCell.Style.BackColor = Color.FromArgb(192, 192, 255)
        grddaily.Columns(6).HeaderCell.Style.BackColor = Color.FromArgb(192, 192, 255)

        grdmonth.Columns(2).HeaderCell.Style.BackColor = Color.FromArgb(255, 255, 128)
        grdmonth.Columns(3).HeaderCell.Style.BackColor = Color.FromArgb(255, 255, 128)
        grdmonth.Columns(4).HeaderCell.Style.BackColor = Color.FromArgb(128, 255, 128)
        grdmonth.Columns(5).HeaderCell.Style.BackColor = Color.FromArgb(128, 255, 128)
        grdmonth.Columns(6).HeaderCell.Style.BackColor = Color.FromArgb(192, 192, 255)
        grdmonth.Columns(7).HeaderCell.Style.BackColor = Color.FromArgb(192, 192, 255)

        Me.Cursor = Cursors.Default
        loadCashiers()
        cmbCashiers.SelectedIndex = 0
        cmbCashiers2.SelectedIndex = 0
        cmbCashiers3.SelectedIndex = 0
    End Sub

    Private Sub TabControl1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TabControl1.MouseClick
        If TabControl1.SelectedTab Is Tab1 Then
            'MsgBox("tab1")
            hourly(cmbCashiers.Text)
        ElseIf TabControl1.SelectedTab Is Tab2 Then
            'MsgBox("tab2")
            datefrom1.Select()
            daily(cmbCashiers2.Text)
        ElseIf TabControl1.SelectedTab Is Tab3 Then
            'MsgBox("tab3")
            monthly()
        End If
    End Sub

    Private Sub TabControl1_TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.TabIndexChanged
        If TabControl1.SelectedTab Is Tab1 Then
            'MsgBox("tab1")
            ' hourly()
        ElseIf TabControl1.SelectedTab Is Tab2 Then
            'MsgBox("tab2")
            datefrom1.Select()
            daily(cmbCashiers2.Text)
        ElseIf TabControl1.SelectedTab Is Tab3 Then
            'MsgBox("tab3")
            monthly()
        End If
    End Sub

    Public Sub hourly(ByVal cshr As String)
        Try
            Me.Cursor = Cursors.WaitCursor

            cmbtrans.Items.Clear()
            Dim gtotal As Double = 0

            If grddaily.Rows.Count = 0 Then
                Me.Cursor = Cursors.Default
                'Exit Sub
            End If

            If transactions.chkrefund.Checked = True Then
                Me.Cursor = Cursors.Default
                'Exit Sub
            End If

            Dim ttemph1 As Integer = 0, ttemph2 As Integer = 0, ttemph3 As Integer = 0, ttemph4 As Integer = 0, ttemph5 As Integer = 0, ttemph6 As Integer = 0
            Dim ttemph7 As Integer = 0, ttemph8 As Integer = 0, ttemph9 As Integer = 0, ttemph10 As Integer = 0, ttemph11 As Integer = 0, ttemph12 As Integer = 0, ttemph13 As Integer = 0

            Dim otemph1 As Integer = 0, otemph2 As Integer = 0, otemph3 As Integer = 0, otemph4 As Integer = 0, otemph5 As Integer = 0, otemph6 As Integer = 0
            Dim otemph7 As Integer = 0, otemph8 As Integer = 0, otemph9 As Integer = 0, otemph10 As Integer = 0, otemph11 As Integer = 0, otemph12 As Integer = 0, otemph13 As Integer = 0

            Dim dtemph1 As Integer = 0, dtemph2 As Integer = 0, dtemph3 As Integer = 0, dtemph4 As Integer = 0, dtemph5 As Integer = 0, dtemph6 As Integer = 0
            Dim dtemph7 As Integer = 0, dtemph8 As Integer = 0, dtemph9 As Integer = 0, dtemph10 As Integer = 0, dtemph11 As Integer = 0, dtemph12 As Integer = 0, dtemph13 As Integer = 0

            Dim osalesh1 As Double = 0, osalesh2 As Double = 0, osalesh3 As Double = 0, osalesh4 As Double = 0, osalesh5 As Double = 0, osalesh6 As Double = 0
            Dim osalesh7 As Double = 0, osalesh8 As Double = 0, osalesh9 As Double = 0, osalesh10 As Double = 0, osalesh11 As Double = 0, osalesh12 As Double = 0, osalesh13 As Double = 0

            Dim dsalesh1 As Double = 0, dsalesh2 As Double = 0, dsalesh3 As Double = 0, dsalesh4 As Double = 0, dsalesh5 As Double = 0, dsalesh6 As Double = 0
            Dim dsalesh7 As Double = 0, dsalesh8 As Double = 0, dsalesh9 As Double = 0, dsalesh10 As Double = 0, dsalesh11 As Double = 0, dsalesh12 As Double = 0, dsalesh13 As Double = 0

            Dim salesh1 As Double = 0, salesh2 As Double = 0, salesh3 As Double = 0, salesh4 As Double = 0, salesh5 As Double = 0, salesh6 As Double = 0
            Dim salesh7 As Double = 0, salesh8 As Double = 0, salesh9 As Double = 0, salesh10 As Double = 0, salesh11 As Double = 0, salesh12 As Double = 0, salesh13 As Double = 0

            'Dim noarpayment1 As Double = 0, noarpaymentamt1 As Double = 0
            Dim noarpayment1 As Double = 0, noarpayment2 As Double = 0, noarpayment3 As Double = 0, noarpayment4 As Double = 0, noarpayment5 As Double = 0, noarpayment6 As Double = 0, noarpayment7 As Double = 0, noarpayment8 As Double = 0, noarpayment9 As Double = 0, noarpayment10 As Double = 0, noarpayment11 As Double = 0, noarpayment12 As Double = 0, noarpayment13 As Double = 0

            Dim noarpaymentamt1 As Double = 0, noarpaymentamt2 As Double = 0, noarpaymentamt3 As Double = 0, noarpaymentamt4 As Double = 0, noarpaymentamt5 As Double = 0, noarpaymentamt6 As Double = 0, noarpaymentamt7 As Double = 0, noarpaymentamt8 As Double = 0, noarpaymentamt9 As Double = 0, noarpaymentamt10 As Double = 0, noarpaymentamt11 As Double = 0, noarpaymentamt12 As Double = 0, noarpaymentamt13 As Double = 0

            Dim noarcash1 As Double = 0, noarcash2 As Double = 0, noarcash3 As Double = 0, noarcash4 As Double = 0, noarcash5 As Double = 0, noarcash6 As Double = 0, noarcash7 As Double = 0, noarcash8 As Double = 0, noarcash9 As Double = 0, noarcash10 As Double = 0, noarcash11 As Double = 0, noarcash12 As Double = 0, noarcash13 As Double = 0

            Dim noarcashamt1 As Double = 0, noarcashamt2 As Double = 0, noarcashamt3 As Double = 0, noarcashamt4 As Double = 0, noarcashamt5 As Double = 0, noarcashamt6 As Double = 0, noarcashamt7 As Double = 0, noarcashamt8 As Double = 0, noarcashamt9 As Double = 0, noarcashamt10 As Double = 0, noarcashamt11 As Double = 0, noarcashamt12 As Double = 0, noarcashamt13 As Double = 0

            Dim nocash1 As Double = 0, nocash2 As Double = 0, nocash3 As Double = 0, nocash4 As Double = 0, nocash5 As Double = 0, nocash6 As Double = 0, nocash7 As Double = 0, nocash8 As Double = 0, nocash9 As Double = 0, nocash10 As Double = 0, nocash11 As Double = 0, nocash12 As Double = 0, nocash13 As Double = 0

            Dim nocashamt1 As Double = 0, nocashamt2 As Double = 0, nocashamt3 As Double = 0, nocashamt4 As Double = 0, nocashamt5 As Double = 0, nocashamt6 As Double = 0, nocashamt7 As Double = 0, nocashamt8 As Double = 0, nocashamt9 As Double = 0, nocashamt10 As Double = 0, nocashamt11 As Double = 0, nocashamt12 As Double = 0, nocashamt13 As Double = 0

            'get all transnum in date range
            Me.Cursor = Cursors.WaitCursor
            If cshr = "All" Then
                sql = "Select * from tbltransaction where transdate>='" & Format(datefrom.Value, "MM/dd/yyyy") & "' and transdate<='" & Format(dateto.Value, "MM/dd/yyyy") & "' and refund='0'"
            Else
                sql = "Select * from tbltransaction where transdate>='" & Format(datefrom.Value, "MM/dd/yyyy") & "' and transdate<='" & Format(dateto.Value, "MM/dd/yyyy") & "' and refund='0' AND cashier='" & cmbCashiers.Text & "'"
            End If
            connect()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            While dr.Read
                cmbtrans.Items.Add(dr("transnum"))
                gtotal += Val(dr("amtdue"))
            End While
            dr.Dispose()
            cmd.Dispose()

            connect()
            For item = 0 To cmbtrans.Items.Count - 1
                cmbtrans.SelectedIndex = item
                MessageBox.Show(cmbtrans.SelectedItem)
                sql = "Select datecreated,amtdue,servicetype,tendertype from tbltransaction where transnum='" & cmbtrans.SelectedItem & "' and refund='0'"
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    MessageBox.Show(dr("tendertype"))
                    Dim time As DateTime = Format(dr("datecreated"), "HH:mm")
                    Dim h1 As DateTime = "08:00 AM"
                    Dim h11 As DateTime = "08:59 AM"
                    If h1 <= time And h11 >= time Then
                        ttemph1 += 1
                        salesh1 += dr("amtdue")
                        If dr("tendertype") = "A.R Cash" Then
                            noarcash1 += 1
                            noarcashamt1 += dr("amtdue")
                        End If
                        If dr("tendertype") = "A.R Payment" Then
                            noarpayment1 += 1
                            noarpaymentamt1 = dr("amtdue")
                        End If
                        If dr("tendertype") = "Cash" Then
                            nocash1 += 1
                            nocashamt1 += dr("amtdue")
                        End If
                        If dr("servicetype") = "Take out" Then
                            otemph1 += 1
                            osalesh1 += dr("amtdue")
                        ElseIf dr("servicetype") = "Deliver" Then
                            dtemph1 += 1
                            dsalesh1 += dr("amtdue")
                        End If
                        'MsgBox(salesh1)
                    End If

                    Dim h2 As DateTime = "09:00 AM"
                    Dim h22 As DateTime = "09:59 AM"
                    If h2 <= time And h22 >= time Then
                        ttemph2 += 1
                        salesh2 += dr("amtdue")
                        If dr("tendertype") = "A.R Payment" Then
                            noarpayment2 += 1
                            noarpaymentamt2 += dr("amtdue")
                        End If
                        If dr("tendertype") = "A.R Cash" Then
                            noarcash2 += 1
                            noarcashamt2 += dr("amtdue")
                        End If
                        If dr("tendertype") = "Cash" Then
                            nocash2 += 1
                            nocashamt2 += dr("amtdue")
                        End If
                        If dr("servicetype") = "Take out" Then
                            otemph2 += 1
                            osalesh2 += dr("amtdue")
                        ElseIf dr("servicetype") = "Deliver" Then
                            dtemph2 += 1
                            dsalesh2 += dr("amtdue")
                        End If
                        'MsgBox(salesh2)
                    End If
                    Dim h3 As DateTime = "10:00 AM"
                    Dim h33 As DateTime = "10:59 AM"
                    If h3 <= time And h33 >= time Then
                        ttemph3 += 1
                        salesh3 += dr("amtdue")
                        If dr("tendertype") = "A.R Payment" Then
                            noarpayment3 += 1
                            noarpaymentamt3 += dr("amtdue")
                        End If
                        If dr("tendertype") = "A.R Cash" Then
                            noarcash3 += 1
                            noarcashamt3 += dr("amtdue")
                        End If
                        If dr("tendertype") = "Cash" Then
                            nocash3 += 1
                            nocashamt3 += dr("amtdue")
                        End If
                        If dr("servicetype") = "Take out" Then
                            otemph3 += 1
                            osalesh3 += dr("amtdue")
                        ElseIf dr("servicetype") = "Deliver" Then
                            dtemph3 += 1
                            dsalesh3 += dr("amtdue")
                        End If
                    End If
                    'MsgBox(salesh3)

                    Dim h4 As DateTime = "11:00 AM"
                    Dim h44 As DateTime = "11:59 AM"
                    If h4 <= time And h44 >= time Then
                        ttemph4 += 1
                        salesh4 += dr("amtdue")
                        If dr("tendertype") = "A.R Payment" Then
                            noarpayment4 += 1
                            noarpaymentamt4 += dr("amtdue")
                        End If
                        If dr("tendertype") = "A.R Cash" Then
                            noarcash4 += 1
                            noarcashamt4 += dr("amtdue")
                        End If
                        If dr("tendertype") = "Cash" Then
                            nocash4 += 1
                            nocashamt4 += dr("amtdue")
                        End If
                        If dr("servicetype") = "Take out" Then
                            otemph4 += 1
                            osalesh4 += dr("amtdue")
                        ElseIf dr("servicetype") = "Deliver" Then
                            dtemph4 += 1
                            dsalesh4 += dr("amtdue")
                        End If
                        'MsgBox(salesh4)
                    End If

                    Dim h5 As DateTime = "12:00 PM"
                    Dim h55 As DateTime = "12:59 PM"
                    If h5 <= time And h55 >= time Then
                        ttemph5 += 1
                        salesh5 += dr("amtdue")
                        If dr("tendertype") = "A.R Payment" Then
                            noarpayment5 += 1
                            noarpaymentamt5 += dr("amtdue")
                        End If
                        If dr("tendertype") = "A.R Cash" Then
                            noarcash5 += 1
                            noarcashamt5 += dr("amtdue")
                        End If
                        If dr("tendertype") = "Cash" Then
                            nocash5 += 1
                            nocashamt5 += dr("amtdue")
                        End If
                        If dr("servicetype") = "Take out" Then
                            otemph5 += 1
                            osalesh5 += dr("amtdue")
                        ElseIf dr("servicetype") = "Deliver" Then
                            dtemph5 += 1
                            dsalesh5 += dr("amtdue")
                        End If
                        'MsgBox(salesh5)
                    End If

                    Dim h6 As DateTime = "01:00 PM"
                    Dim h66 As DateTime = "01:59 PM"
                    If h6 <= time And h66 >= time Then
                        ttemph6 += 1
                        salesh6 += dr("amtdue")
                        If dr("tendertype") = "A.R Payment" Then
                            noarpayment6 += 1
                            noarpaymentamt6 += dr("amtdue")
                        End If
                        If dr("tendertype") = "A.R Cash" Then
                            noarcash6 += 1
                            noarcashamt6 += dr("amtdue")
                        End If
                        If dr("tendertype") = "Cash" Then
                            nocash6 += 1
                            nocashamt6 += dr("amtdue")
                        End If
                        If dr("servicetype") = "Take out" Then
                            otemph6 += 1
                            osalesh6 += dr("amtdue")
                        ElseIf dr("servicetype") = "Deliver" Then
                            dtemph6 += 1
                            dsalesh6 += dr("amtdue")
                        End If
                        'MsgBox(salesh6)
                    End If

                    Dim h7 As DateTime = "02:00 PM"
                    Dim h77 As DateTime = "02:59 PM"
                    If h7 <= time And h77 >= time Then
                        ttemph7 += 1
                        salesh7 += dr("amtdue")
                        If dr("tendertype") = "A.R Payment" Then
                            noarpayment7 += 1
                            noarpaymentamt7 += dr("amtdue")
                        End If
                        If dr("tendertype") = "A.R Cash" Then
                            noarcash7 += 1
                            noarcashamt7 += dr("amtdue")
                        End If
                        If dr("tendertype") = "Cash" Then
                            nocash7 += 1
                            nocashamt7 += dr("amtdue")
                        End If
                        If dr("servicetype") = "Take out" Then
                            otemph7 += 1
                            osalesh7 += dr("amtdue")
                        ElseIf dr("servicetype") = "Deliver" Then
                            dtemph7 += 1
                            dsalesh7 += dr("amtdue")
                        End If
                        'MsgBox(salesh7)
                    End If

                    Dim h8 As DateTime = "03:00 PM"
                    Dim h88 As DateTime = "03:59 PM"
                    If h8 <= time And h88 >= time Then
                        'MessageBox.Show(nocash8 & Environment.NewLine & nocashamt8)
                        ttemph8 += 1
                        salesh8 += dr("amtdue")
                        If dr("tendertype") = "A.R Payment" Then
                            noarpayment8 += 1
                            noarpaymentamt8 += dr("amtdue")
                        End If
                        If dr("tendertype") = "A.R Cash" Then
                            noarcash8 += 1
                            noarcashamt8 += dr("amtdue")
                        End If
                        If dr("tendertype") = "Cash" Then
                            nocash8 += 1
                            nocashamt8 += dr("amtdue")
                        End If
                        If dr("servicetype") = "Take out" Then
                            otemph8 += 1
                            osalesh8 += dr("amtdue")
                        ElseIf dr("servicetype") = "Deliver" Then
                            dtemph8 += 1
                            dsalesh8 += dr("amtdue")
                        End If
                        'MsgBox(salesh8)
                    End If

                    Dim h9 As DateTime = "04:00 PM"
                    Dim h99 As DateTime = "04:59 PM"
                    If h9 <= time And h99 >= time Then
                        ttemph9 += 1
                        salesh9 += dr("amtdue")
                        If dr("tendertype") = "A.R Payment" Then
                            noarpayment9 += 1
                            noarpaymentamt9 += dr("amtdue")
                        End If
                        If dr("tendertype") = "A.R Cash" Then
                            noarcash9 += 1
                            noarcashamt9 += dr("amtdue")
                        End If
                        If dr("tendertype") = "Cash" Then
                            nocash9 += 1
                            nocashamt9 += dr("amtdue")
                        End If
                        If dr("servicetype") = "Take out" Then
                            otemph9 += 1
                            osalesh9 += dr("amtdue")
                        ElseIf dr("servicetype") = "Deliver" Then
                            dtemph9 += 1
                            dsalesh9 += dr("amtdue")
                        End If
                        'MsgBox(salesh9)
                    End If

                    Dim h10 As DateTime = "05:00 PM"
                    Dim h110 As DateTime = "05:59 PM"
                    If h10 <= time And h110 >= time Then
                        ttemph10 += 1
                        salesh10 += dr("amtdue")
                        If dr("tendertype") = "A.R Payment" Then
                            noarpayment10 += 1
                            noarpaymentamt10 += dr("amtdue")
                        End If
                        If dr("tendertype") = "A.R Cash" Then
                            noarcash10 += 1
                            noarcashamt10 += dr("amtdue")
                        End If
                        If dr("tendertype") = "Cash" Then
                            nocash10 += 1
                            nocashamt10 += dr("amtdue")
                        End If
                        If dr("servicetype") = "Take out" Then
                            otemph10 += 1
                            osalesh10 += dr("amtdue")
                        ElseIf dr("servicetype") = "Deliver" Then
                            dtemph10 += 1
                            dsalesh10 += dr("amtdue")
                        End If
                        'MsgBox(salesh10)
                    End If

                    Dim h11a As DateTime = "06:00 PM"
                    Dim h111 As DateTime = "06:59 PM"
                    If h11a <= time And h111 >= time Then
                        ttemph11 += 1
                        salesh11 += dr("amtdue")
                        If dr("tendertype") = "A.R Payment" Then
                            noarpayment11 += 1
                            noarpaymentamt11 += dr("amtdue")
                        End If
                        If dr("tendertype") = "A.R Cash" Then
                            noarcash11 += 1
                            noarcashamt11 += dr("amtdue")
                        End If
                        If dr("tendertype") = "Cash" Then
                            nocash11 += 1
                            nocashamt11 += dr("amtdue")
                        End If
                        If dr("servicetype") = "Take out" Then
                            otemph11 += 1
                            osalesh11 += dr("amtdue")
                        ElseIf dr("servicetype") = "Deliver" Then
                            dtemph11 += 1
                            dsalesh11 += dr("amtdue")
                        End If
                        'MsgBox(salesh11)
                    End If

                    Dim h12a As DateTime = "07:00 PM"
                    Dim h112 As DateTime = "07:59 PM"
                    If h12a <= time And h112 >= time Then
                        ttemph12 += 1
                        salesh12 += dr("amtdue")
                        If dr("tendertype") = "A.R Payment" Then
                            noarpayment12 += 1
                            noarpaymentamt12 += dr("amtdue")
                        End If
                        If dr("tendertype") = "A.R Cash" Then
                            noarcash12 += 1
                            noarcashamt12 += dr("amtdue")
                        End If
                        If dr("tendertype") = "Cash" Then
                            nocash12 += 1
                            nocashamt12 += dr("amtdue")
                        End If
                        If dr("servicetype") = "Take out" Then
                            otemph12 += 1
                            osalesh12 += dr("amtdue")
                        ElseIf dr("servicetype") = "Deliver" Then
                            dtemph12 += 1
                            dsalesh12 += dr("amtdue")
                        End If
                        'MsgBox(salesh12)
                    End If

                    Dim h13a As DateTime = "08:00 PM"
                    Dim h113 As DateTime = "08:59 PM"
                    If h13a <= time And h113 >= time Then
                        ttemph13 += 1
                        salesh13 += dr("amtdue")
                        If dr("tendertype") = "A.R Payment" Then
                            noarpayment13 += 1
                            noarpaymentamt13 += dr("amtdue")
                        End If
                        If dr("tendertype") = "A.R Cash" Then
                            noarcash13 += 1
                            noarcashamt13 += dr("amtdue")
                        End If
                        If dr("tendertype") = "Cash" Then
                            nocash13 += 1
                            nocashamt13 += dr("amtdue")
                        End If
                        If dr("servicetype") = "Take out" Then
                            otemph13 += 1
                            osalesh13 += dr("amtdue")
                        ElseIf dr("servicetype") = "Deliver" Then
                            dtemph13 += 1
                            dsalesh13 += dr("amtdue")
                        End If
                        'MsgBox(salesh13)
                    End If
                End If
                cmd.Dispose()
                dr.Dispose()
            Next

            If transactions.cmbcash.SelectedItem <> "All" Then
                ' transactions.lblcash.Text = transactions.cmbcash.SelectedItem
            End If
            If transactions.hfrom.SelectedItem <> "" And transactions.hto.SelectedItem <> "" Then
                'lbldate.Text = Format(datefrom1.Value, "MM/dd/yyyy") & "  " & hfrom.SelectedItem & " - " & Format(dateto1.Value, "MM/dd/yyyy" & "  " & hto.SelectedItem)
            Else
                'lbldate.Text = Format(datefrom1.Value, "MM/dd/yyyy") & " - " & Format(dateto1.Value, "MM/dd/yyyy")
            End If

            culture = CultureInfo.CreateSpecificCulture("en-US")
            Dim total As String = gtotal
            Dim sum As Double
            sum = Double.Parse(total, culture)
            totalsales.Text = sum.ToString("n2")

            grdhour.Rows.Clear()
            grdhour.Rows.Add("01", "08:00 - 08:59  AM", otemph1, osalesh1, dtemph1, dsalesh1, nocash1, nocashamt1, noarpayment1, noarpaymentamt1, noarcash1, noarcashamt1, "", "", ttemph1, salesh1)
            grdhour.Rows.Add("02", "09:00 - 09:59  AM", otemph2, osalesh2, dtemph2, dsalesh2, nocash2, nocashamt2, noarpayment2, noarpaymentamt2, noarcash2, noarcashamt2, "", "", ttemph2, salesh2)
            grdhour.Rows.Add("03", "10:00 - 10:59  AM", otemph3, osalesh3, dtemph3, dsalesh3, nocash3, nocashamt3, noarpayment3, noarpaymentamt3, noarcash3, noarcashamt3, "", "", ttemph3, salesh3)
            grdhour.Rows.Add("04", "11:00 - 11:59   AM", otemph4, osalesh4, dtemph4, dsalesh4, nocash4, nocashamt4, noarpayment4, noarpaymentamt4, noarcash4, noarcashamt4, "", "", ttemph4, salesh4)
            grdhour.Rows.Add("05", "12:00 - 12:59  PM", otemph5, osalesh5, dtemph5, dsalesh5, nocash5, nocashamt5, noarpayment5, noarpaymentamt5, noarcash5, noarcashamt5, "", "", ttemph5, salesh5)
            grdhour.Rows.Add("06", "01:00 - 01:59  PM", otemph6, osalesh6, dtemph6, dsalesh6, nocash6, nocashamt6, noarpayment6, noarpaymentamt6, noarcash6, noarcashamt6, "", "", ttemph6, salesh6)
            grdhour.Rows.Add("07", "02:00 - 02:59  PM", otemph7, osalesh7, dtemph7, dsalesh7, nocash7, nocashamt7, noarpayment7, noarpaymentamt7, noarcash7, noarcashamt7, "", "", ttemph7, salesh7)
            grdhour.Rows.Add("08", "03:00 - 03:59  PM", otemph8, osalesh8, dtemph8, dsalesh8, nocash8, nocashamt8, noarpayment8, noarpaymentamt8, noarcash8, noarcashamt8, "", "", ttemph8, salesh8)
            grdhour.Rows.Add("09", "04:00 - 04:59  PM", otemph9, osalesh9, dtemph9, dsalesh9, nocash9, nocashamt9, noarpayment9, noarpaymentamt9, noarcash9, noarcashamt9, "", "", ttemph9, salesh9)
            grdhour.Rows.Add("10", "05:00 - 05:59  PM", otemph10, osalesh10, dtemph10, dsalesh10, nocash10, nocashamt10, noarpayment10, noarpaymentamt10, noarcash10, noarcashamt10, "", "", ttemph10, salesh10)
            grdhour.Rows.Add("11", "06:00 - 06:59  PM", otemph11, osalesh11, dtemph11, dsalesh11, nocash11, nocashamt12, noarpayment11, noarpaymentamt11, noarcash11, noarcashamt11, "", "", ttemph11, salesh11)
            grdhour.Rows.Add("12", "07:00 - 07:59  PM", otemph12, osalesh12, dtemph12, dsalesh12, nocash12, nocashamt12, noarpayment12, noarpaymentamt12, noarcash12, noarcashamt12, "", "", ttemph12, salesh12)
            grdhour.Rows.Add("13", "08:00 - 08:59  PM", otemph13, osalesh13, dtemph13, dsalesh13, nocash13, nocashamt13, noarpayment13, noarpaymentamt13, noarcash13, noarcashamt13, "", "", ttemph13, salesh13)

            For i = 0 To grdhour.Rows.Count - 1
                grdhour.Item(2, i).Style.BackColor = Color.FromArgb(255, 255, 128)
                grdhour.Item(3, i).Style.BackColor = Color.FromArgb(255, 255, 128)
                grdhour.Item(4, i).Style.BackColor = Color.FromArgb(128, 255, 128)
                grdhour.Item(5, i).Style.BackColor = Color.FromArgb(128, 255, 128)
                grdhour.Item(6, i).Style.BackColor = Color.FromArgb(192, 192, 255)
                grdhour.Item(7, i).Style.BackColor = Color.FromArgb(192, 192, 255)
            Next


            Me.Cursor = Cursors.Default

        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles datefrom.ValueChanged
        grddaily.Rows.Clear()
        'Dim starttime As DateTime = dateto.Value.AddYears(+1)
        'Dim endtime As DateTime = datefrom.Value.AddDays(+1)
        'Dim elapsed As TimeSpan = starttime.Subtract(endtime)
        'MsgBox(elapsed.Days.ToString)
        'If Val(elapsed.Days.ToString) <= 365 Or Val(elapsed.Days.ToString) >= 366 Then
        dateto.MinDate = datefrom.Value
        hourly(cmbCashiers.Text)
        'End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dateto.ValueChanged
        hourly(cmbCashiers.Text)
    End Sub

    Public Sub daily(ByVal cshr As String)
        Try
            grddaily.Rows.Clear()

            Me.Cursor = Cursors.WaitCursor

            Dim currentDate As Date = datefrom1.Value
            While currentDate <= dateto1.Value
                Dim notransac As Integer = 0
                Dim totalsales As Double = 0
                Dim takeout As Double = 0
                Dim deliver As Double = 0
                Dim salestakeout As Double = 0
                Dim salesdeliver As Double = 0


                Dim nocash As Double = 0
                Dim cash As Double = 0
                Dim noarpayment As Double = 0
                Dim arpayment As Double = 0
                Dim noarcash As Double = 0
                Dim arcash As Double = 0
                'input code
                If cshr = "All" Then
                    sql = "Select * from tbltransaction where transdate='" & Format(currentDate, "MM/dd/yyyy") & "' and refund='0'"
                Else
                    sql = "Select * from tbltransaction where transdate='" & Format(currentDate, "MM/dd/yyyy") & "' and refund='0' AND cashier='" & cmbCashiers2.Text & "'"
                End If
                connect()
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                While dr.Read
                    notransac += 1
                    totalsales += Val(dr("amtdue"))
                    If dr("tendertype") = "Cash" Then
                        nocash += 1
                        cash += dr("amtdue")
                    End If
                    If dr("tendertype") = "A.R Payment" Then
                        noarpayment += 1
                        arpayment += dr("amtdue")
                    End If
                    If dr("tendertype") = "A.R Cash" Then
                        noarcash += 1
                        arcash += dr("amtdue")
                    End If
                    If dr("servicetype") = "Take out" Then
                        takeout += 1
                        salestakeout += Val(dr("amtdue"))
                    ElseIf dr("servicetype") = "Deliver" Then
                        deliver += 1
                        salesdeliver += Val(dr("amtdue"))
                    End If
                End While
                dr.Dispose()
                cmd.Dispose()

                grddaily.Rows.Add(Format(currentDate, "MM/dd/yyyy"), takeout, salestakeout, deliver, salesdeliver, nocash, cash, noarpayment, arpayment, noarcash, arcash, notransac, totalsales)

                currentDate = currentDate.AddDays(1)
            End While

            Dim gtotaldaily As Double = 0
            For Each row As DataGridViewRow In grddaily.Rows
                gtotaldaily += Val(grddaily.Rows(row.Index).Cells(12).Value)
                grddaily.Item(1, row.Index).Style.BackColor = Color.FromArgb(255, 255, 128)
                grddaily.Item(2, row.Index).Style.BackColor = Color.FromArgb(255, 255, 128)
                grddaily.Item(3, row.Index).Style.BackColor = Color.FromArgb(128, 255, 128)
                grddaily.Item(4, row.Index).Style.BackColor = Color.FromArgb(128, 255, 128)
                grddaily.Item(5, row.Index).Style.BackColor = Color.FromArgb(192, 192, 255)
                grddaily.Item(6, row.Index).Style.BackColor = Color.FromArgb(192, 192, 255)
            Next

            culture = CultureInfo.CreateSpecificCulture("en-US")
            Dim total As String = gtotaldaily
            Dim sum As Double
            sum = Double.Parse(total, culture)
            totalsales1.Text = sum.ToString("n2")


            Me.Cursor = Cursors.Default
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Private Sub datefrom1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles datefrom1.ValueChanged
        grddaily.Rows.Clear()
        dateto1.MinDate = datefrom1.Value
        daily(cmbCashiers2.Text)
    End Sub

    Private Sub dateto1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dateto1.ValueChanged
        daily(cmbCashiers2.Text)
    End Sub

    Private Sub DateTimePicker1_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        Dim DayNo As Integer = 0
        Dim DateNo As Integer = 0
        Dim StartingDay As Integer = 0
        Dim PayPerEndDate As Date = DateTimePicker1.Value
        Dim week As Integer = 1
        StartingDay = PayPerEndDate.AddDays(-(PayPerEndDate.Day - 1)).DayOfWeek
        DayNo = PayPerEndDate.DayOfWeek
        DateNo = PayPerEndDate.Day
        week = Fix(DateNo / 7)
        If DateNo Mod 7 > 0 Then
            week += 1
        End If
        If StartingDay > DayNo Then
            week += 1
        End If

        MsgBox(week)
    End Sub

    Public Sub monthly()
        Try
            Me.Cursor = Cursors.WaitCursor

            cmbyear.Items.Clear()


            'load year in combobox
            sql = "Select * from tbltransaction where refund='0'"
            connect()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            While dr.Read
                If Not cmbyear.Items.Contains(Format(dr("transdate"), "yyyy")) Then
                    cmbyear.Items.Add(Format(dr("transdate"), "yyyy"))
                End If
            End While
            dr.Dispose()
            cmd.Dispose()

            If cmbyear.Items.Count <> 0 Then
                'cmbyear.SelectedItem = Format(Date.Now, "yyyy")
            End If

            Me.Cursor = Cursors.Default
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub
    Public Sub monthyear()
        Try
            Me.Cursor = Cursors.WaitCursor

            'get all transaction per month
            cmbtransmon.Items.Clear()
            sql = "Select * from tbltransaction where refund='0'"
            connect()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            While dr.Read
                If Format(dr("transdate"), "yyyy") = cmbyear.SelectedItem Then
                    cmbtransmon.Items.Add(dr("transnum"))
                End If
            End While
            dr.Dispose()
            cmd.Dispose()

            disconnect()

            Dim m1 As String = "January", m2 As String = "February", m3 As String = "March", m4 As String = "April", m5 As String = "May", m6 As String = "June"
            Dim m7 As String = "July", m8 As String = "August", m9 As String = "September", m10 As String = "October", m11 As String = "November", m12 As String = "December"

            Dim tempm1 As Integer, tempm2 As Integer, tempm3 As Integer, tempm4 As Integer, tempm5 As Integer, tempm6 As Integer
            Dim tempm7 As Integer, tempm8 As Integer, tempm9 As Integer, tempm10 As Integer, tempm11 As Integer, tempm12 As Integer

            Dim salesm1 As Double, salesm2 As Double, salesm3 As Double, salesm4 As Double, salesm5 As Double, salesm6 As Double
            Dim salesm7 As Double, salesm8 As Double, salesm9 As Double, salesm10 As Double, salesm11 As Double, salesm12 As Double

            Dim otempm1 As Integer, otempm2 As Integer, otempm3 As Integer, otempm4 As Integer, otempm5 As Integer, otempm6 As Integer
            Dim otempm7 As Integer, otempm8 As Integer, otempm9 As Integer, otempm10 As Integer, otempm11 As Integer, otempm12 As Integer

            Dim osalesm1 As Double, osalesm2 As Double, osalesm3 As Double, osalesm4 As Double, osalesm5 As Double, osalesm6 As Double
            Dim osalesm7 As Double, osalesm8 As Double, osalesm9 As Double, osalesm10 As Double, osalesm11 As Double, osalesm12 As Double

            Dim dtempm1 As Integer, dtempm2 As Integer, dtempm3 As Integer, dtempm4 As Integer, dtempm5 As Integer, dtempm6 As Integer
            Dim dtempm7 As Integer, dtempm8 As Integer, dtempm9 As Integer, dtempm10 As Integer, dtempm11 As Integer, dtempm12 As Integer

            Dim dsalesm1 As Double, dsalesm2 As Double, dsalesm3 As Double, dsalesm4 As Double, dsalesm5 As Double, dsalesm6 As Double
            Dim dsalesm7 As Double, dsalesm8 As Double, dsalesm9 As Double, dsalesm10 As Double, dsalesm11 As Double, dsalesm12 As Double

            Dim noarpayment1 As Double = 0, noarpayment2 As Double = 0, noarpayment3 As Double = 0, noarpayment4 As Double = 0, noarpayment5 As Double = 0, noarpayment6 As Double = 0, noarpayment7 As Double = 0, noarpayment8 As Double = 0, noarpayment9 As Double = 0, noarpayment10 As Double = 0, noarpayment11 As Double = 0, noarpayment12 As Double = 0, noarpayment13 As Double = 0

            Dim noarpaymentamt1 As Double = 0, noarpaymentamt2 As Double = 0, noarpaymentamt3 As Double = 0, noarpaymentamt4 As Double = 0, noarpaymentamt5 As Double = 0, noarpaymentamt6 As Double = 0, noarpaymentamt7 As Double = 0, noarpaymentamt8 As Double = 0, noarpaymentamt9 As Double = 0, noarpaymentamt10 As Double = 0, noarpaymentamt11 As Double = 0, noarpaymentamt12 As Double = 0, noarpaymentamt13 As Double = 0

            Dim noarcash1 As Double = 0, noarcash2 As Double = 0, noarcash3 As Double = 0, noarcash4 As Double = 0, noarcash5 As Double = 0, noarcash6 As Double = 0, noarcash7 As Double = 0, noarcash8 As Double = 0, noarcash9 As Double = 0, noarcash10 As Double = 0, noarcash11 As Double = 0, noarcash12 As Double = 0, noarcash13 As Double = 0

            Dim noarcashamt1 As Double = 0, noarcashamt2 As Double = 0, noarcashamt3 As Double = 0, noarcashamt4 As Double = 0, noarcashamt5 As Double = 0, noarcashamt6 As Double = 0, noarcashamt7 As Double = 0, noarcashamt8 As Double = 0, noarcashamt9 As Double = 0, noarcashamt10 As Double = 0, noarcashamt11 As Double = 0, noarcashamt12 As Double = 0, noarcashamt13 As Double = 0

            Dim nocash1 As Double = 0, nocash2 As Double = 0, nocash3 As Double = 0, nocash4 As Double = 0, nocash5 As Double = 0, nocash6 As Double = 0, nocash7 As Double = 0, nocash8 As Double = 0, nocash9 As Double = 0, nocash10 As Double = 0, nocash11 As Double = 0, nocash12 As Double = 0, nocash13 As Double = 0

            Dim nocashamt1 As Double = 0, nocashamt2 As Double = 0, nocashamt3 As Double = 0, nocashamt4 As Double = 0, nocashamt5 As Double = 0, nocashamt6 As Double = 0, nocashamt7 As Double = 0, nocashamt8 As Double = 0, nocashamt9 As Double = 0, nocashamt10 As Double = 0, nocashamt11 As Double = 0, nocashamt12 As Double = 0, nocashamt13 As Double = 0

            connect()
            For i = 0 To cmbtransmon.Items.Count - 1
                cmbtransmon.SelectedIndex = i
                If cmbCashiers3.Text = "All" Then
                    sql = "Select * from tbltransaction where transnum='" & cmbtransmon.SelectedItem & "' and refund='0'"
                Else
                    sql = "Select * from tbltransaction where transnum='" & cmbtransmon.SelectedItem & "' and refund='0' AND cashier='" & cmbCashiers3.Text & "'"
                End If
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    'MsgBox(dr("refund"))
                    Dim month As String = Format(dr("transdate"), "MMMM")
                    'MsgBox(month)
                    If m1 = month Then
                        tempm1 += 1
                        salesm1 += Val(dr("amtdue"))
                        If dr("tendertype") = "A.R Cash" Then
                            noarcash1 += 1
                            noarcashamt1 += dr("amtdue")
                        End If
                        If dr("tendertype") = "A.R Payment" Then
                            noarpayment1 += 1
                            noarpaymentamt1 = dr("amtdue")
                        End If
                        If dr("tendertype") = "Cash" Then
                            nocash1 += 1
                            nocashamt1 += dr("amtdue")
                        End If
                        If dr("servicetype") = "Take out" Then
                            otempm1 += 1
                            osalesm1 += dr("amtdue")
                        ElseIf dr("servicetype") = "Deliver" Then
                            dtempm1 += 1
                            dsalesm1 += dr("amtdue")
                        End If
                    End If

                    If m2 = month Then
                        tempm2 += 1
                        salesm2 += Val(dr("amtdue"))
                        If dr("tendertype") = "A.R Cash" Then
                            noarcash2 += 1
                            noarcashamt2 += dr("amtdue")
                        End If
                        If dr("tendertype") = "A.R Payment" Then
                            noarpayment2 += 1
                            noarpaymentamt2 = dr("amtdue")
                        End If
                        If dr("tendertype") = "Cash" Then
                            nocash2 += 1
                            nocashamt2 += dr("amtdue")
                        End If
                        If dr("servicetype") = "Take out" Then
                            otempm2 += 1
                            osalesm2 += dr("amtdue")
                        ElseIf dr("servicetype") = "Deliver" Then
                            dtempm2 += 1
                            dsalesm2 += dr("amtdue")
                        End If
                    End If

                    If m3 = month Then
                        tempm3 += 1
                        salesm3 += Val(dr("amtdue"))
                        If dr("tendertype") = "A.R Cash" Then
                            noarcash3 += 1
                            noarcashamt3 += dr("amtdue")
                        End If
                        If dr("tendertype") = "A.R Payment" Then
                            noarpayment3 += 1
                            noarpaymentamt3 = dr("amtdue")
                        End If
                        If dr("tendertype") = "Cash" Then
                            nocash3 += 1
                            nocashamt3 += dr("amtdue")
                        End If
                        If dr("servicetype") = "Take out" Then
                            otempm3 += 1
                            osalesm3 += dr("amtdue")
                        ElseIf dr("servicetype") = "Deliver" Then
                            dtempm3 += 1
                            dsalesm3 += dr("amtdue")
                        End If
                    End If

                    If m4 = month Then
                        tempm4 += 1
                        salesm4 += Val(dr("amtdue"))
                        If dr("tendertype") = "A.R Cash" Then
                            noarcash4 += 1
                            noarcashamt4 += dr("amtdue")
                        End If
                        If dr("tendertype") = "A.R Payment" Then
                            noarpayment4 += 1
                            noarpaymentamt4 = dr("amtdue")
                        End If
                        If dr("tendertype") = "Cash" Then
                            nocash4 += 1
                            nocashamt4 += dr("amtdue")
                        End If
                        If dr("servicetype") = "Take out" Then
                            otempm4 += 1
                            osalesm4 += dr("amtdue")
                        ElseIf dr("servicetype") = "Deliver" Then
                            dtempm4 += 1
                            dsalesm4 += dr("amtdue")
                        End If
                    End If

                    If m5 = month Then
                        tempm5 += 1
                        salesm5 += Val(dr("amtdue"))
                        If dr("tendertype") = "A.R Cash" Then
                            noarcash5 += 1
                            noarcashamt5 += dr("amtdue")
                        End If
                        If dr("tendertype") = "A.R Payment" Then
                            noarpayment5 += 1
                            noarpaymentamt5 = dr("amtdue")
                        End If
                        If dr("tendertype") = "Cash" Then
                            nocash5 += 1
                            nocashamt5 += dr("amtdue")
                        End If
                        If dr("servicetype") = "Take out" Then
                            otempm5 += 1
                            osalesm5 += dr("amtdue")
                        ElseIf dr("servicetype") = "Deliver" Then
                            dtempm5 += 1
                            dsalesm5 += dr("amtdue")
                        End If
                    End If

                    If m6 = month Then
                        tempm6 += 1
                        salesm6 += Val(dr("amtdue"))
                        If dr("tendertype") = "A.R Cash" Then
                            noarcash6 += 1
                            noarcashamt6 += dr("amtdue")
                        End If
                        If dr("tendertype") = "A.R Payment" Then
                            noarpayment6 += 1
                            noarpaymentamt6 = dr("amtdue")
                        End If
                        If dr("tendertype") = "Cash" Then
                            nocash6 += 1
                            nocashamt6 += dr("amtdue")
                        End If
                        If dr("servicetype") = "Take out" Then
                            otempm6 += 1
                            osalesm6 += dr("amtdue")
                        ElseIf dr("servicetype") = "Deliver" Then
                            dtempm6 += 1
                            dsalesm6 += dr("amtdue")
                        End If
                    End If

                    If m7 = month Then
                        tempm7 += 1
                        salesm7 += Val(dr("amtdue"))
                        If dr("tendertype") = "A.R Cash" Then
                            noarcash7 += 1
                            noarcashamt7 += dr("amtdue")
                        End If
                        If dr("tendertype") = "A.R Payment" Then
                            noarpayment7 += 1
                            noarpaymentamt7 = dr("amtdue")
                        End If
                        If dr("tendertype") = "Cash" Then
                            nocash7 += 1
                            nocashamt7 += dr("amtdue")
                        End If
                        If dr("servicetype") = "Take out" Then
                            otempm7 += 1
                            osalesm7 += dr("amtdue")
                        ElseIf dr("servicetype") = "Deliver" Then
                            dtempm7 += 1
                            dsalesm7 += dr("amtdue")
                        End If
                    End If

                    If m8 = month Then
                        tempm8 += 1
                        salesm8 += Val(dr("amtdue"))
                        If dr("tendertype") = "A.R Cash" Then
                            noarcash8 += 1
                            noarcashamt8 += dr("amtdue")
                        End If
                        If dr("tendertype") = "A.R Payment" Then
                            noarpayment8 += 1
                            noarpaymentamt8 = dr("amtdue")
                        End If
                        If dr("tendertype") = "Cash" Then
                            nocash8 += 1
                            nocashamt8 += dr("amtdue")
                        End If
                        If dr("servicetype") = "Take out" Then
                            otempm8 += 1
                            osalesm8 += dr("amtdue")
                        ElseIf dr("servicetype") = "Deliver" Then
                            dtempm8 += 1
                            dsalesm8 += dr("amtdue")
                        End If
                    End If

                    If m9 = month Then
                        tempm9 += 1
                        salesm9 += Val(dr("amtdue"))
                        If dr("tendertype") = "A.R Cash" Then
                            noarcash9 += 1
                            noarcashamt9 += dr("amtdue")
                        End If
                        If dr("tendertype") = "A.R Payment" Then
                            noarpayment9 += 1
                            noarpaymentamt9 = dr("amtdue")
                        End If
                        If dr("tendertype") = "Cash" Then
                            nocash9 += 1
                            nocashamt9 += dr("amtdue")
                        End If
                        If dr("servicetype") = "Take out" Then
                            otempm9 += 1
                            osalesm9 += dr("amtdue")
                        ElseIf dr("servicetype") = "Deliver" Then
                            dtempm9 += 1
                            dsalesm9 += dr("amtdue")
                        End If
                    End If

                    If m10 = month Then
                        tempm10 += 1
                        salesm10 += Val(dr("amtdue"))
                        If dr("tendertype") = "A.R Cash" Then
                            noarcash10 += 1
                            noarcashamt10 += dr("amtdue")
                        End If
                        If dr("tendertype") = "A.R Payment" Then
                            noarpayment10 += 1
                            noarpaymentamt10 = dr("amtdue")
                        End If
                        If dr("tendertype") = "Cash" Then
                            nocash10 += 1
                            nocashamt10 += dr("amtdue")
                        End If
                        If dr("servicetype") = "Take out" Then
                            otempm10 += 1
                            osalesm10 += dr("amtdue")
                        ElseIf dr("servicetype") = "Deliver" Then
                            dtempm10 += 1
                            dsalesm10 += dr("amtdue")
                        End If
                    End If

                    If m11 = month Then
                        tempm11 += 1
                        salesm11 += Val(dr("amtdue"))
                        If dr("tendertype") = "A.R Cash" Then
                            noarcash11 += 1
                            noarcashamt11 += dr("amtdue")
                        End If
                        If dr("tendertype") = "A.R Payment" Then
                            noarpayment11 += 1
                            noarpaymentamt11 = dr("amtdue")
                        End If
                        If dr("tendertype") = "Cash" Then
                            nocash11 += 1
                            nocashamt11 += dr("amtdue")
                        End If
                        If dr("servicetype") = "Take out" Then
                            otempm11 += 1
                            osalesm11 += dr("amtdue")
                        ElseIf dr("servicetype") = "Deliver" Then
                            dtempm11 += 1
                            dsalesm11 += dr("amtdue")
                        End If
                    End If

                    If m12 = month Then
                        tempm12 += 1
                        salesm12 += Val(dr("amtdue"))
                        If dr("tendertype") = "A.R Cash" Then
                            noarcash12 += 1
                            noarcashamt12 += dr("amtdue")
                        End If
                        If dr("tendertype") = "A.R Payment" Then
                            noarpayment12 += 1
                            noarpaymentamt12 = dr("amtdue")
                        End If
                        If dr("tendertype") = "Cash" Then
                            nocash12 += 1
                            nocashamt12 += dr("amtdue")
                        End If
                        If dr("servicetype") = "Take out" Then
                            otempm12 += 1
                            osalesm12 += dr("amtdue")
                        ElseIf dr("servicetype") = "Deliver" Then
                            dtempm12 += 1
                            dsalesm12 += dr("amtdue")
                        End If
                    End If
                End If
                dr.Dispose()
                cmd.Dispose()
            Next

            grdmonth.Rows.Clear()

            grdmonth.Rows.Add("01", m1, otempm1, osalesm1, dtempm1, dsalesm1, nocash1, nocashamt1, noarpayment1, noarpaymentamt1, noarcash1, noarcashamt1, tempm1, salesm1)
            grdmonth.Rows.Add("02", m2, otempm2, osalesm2, dtempm2, dsalesm2, nocash2, nocashamt2, noarpayment2, noarpaymentamt2, noarcash2, noarcashamt2, tempm2, salesm2)
            grdmonth.Rows.Add("03", m3, otempm3, osalesm3, dtempm3, dsalesm3, nocash3, nocashamt3, noarpayment3, noarpaymentamt3, noarcash3, noarcashamt3, tempm3, salesm3)
            grdmonth.Rows.Add("04", m4, otempm4, osalesm4, dtempm4, dsalesm4, nocash4, nocashamt4, noarpayment4, noarpaymentamt4, noarcash4, noarcashamt4, tempm4, salesm4)
            grdmonth.Rows.Add("05", m5, otempm5, osalesm5, dtempm5, dsalesm5, nocash5, nocashamt5, noarpayment5, noarpaymentamt5, noarcash5, noarcashamt5, tempm5, salesm5)
            grdmonth.Rows.Add("06", m6, otempm6, osalesm6, dtempm6, dsalesm6, nocash6, nocashamt6, noarpayment6, noarpaymentamt6, noarcash6, noarcashamt6, tempm6, salesm6)
            grdmonth.Rows.Add("07", m7, otempm7, osalesm7, dtempm7, dsalesm7, nocash7, nocashamt7, noarpayment7, noarpaymentamt7, noarcash7, noarcashamt7, tempm7, salesm7)
            grdmonth.Rows.Add("08", m8, otempm8, osalesm8, dtempm8, dsalesm8, nocash8, nocashamt8, noarpayment8, noarpaymentamt8, noarcash8, noarcashamt8, tempm8, salesm8)
            grdmonth.Rows.Add("09", m9, otempm9, osalesm9, dtempm9, dsalesm9, nocash9, nocashamt9, noarpayment9, noarpaymentamt9, noarcash9, noarcashamt9, tempm9, salesm9)
            grdmonth.Rows.Add("10", m10, otempm10, osalesm10, dtempm10, dsalesm10, nocash10, nocashamt10, noarpayment10, noarpaymentamt10, noarcash10, noarcashamt10, tempm10, salesm10)
            grdmonth.Rows.Add("11", m11, otempm11, osalesm11, dtempm11, dsalesm11, nocash11, nocashamt11, noarpayment11, noarpaymentamt11, noarcash11, noarcashamt11, tempm11, salesm11)
            grdmonth.Rows.Add("12", m12, otempm12, osalesm12, dtempm12, dsalesm12, nocash12, nocashamt12, noarpayment12, noarpaymentamt12, noarcash12, noarcashamt12, tempm12, salesm12)

            Dim gtotalmon As Double = 0
            For Each row As DataGridViewRow In grdmonth.Rows
                gtotalmon += Val(grdmonth.Rows(row.Index).Cells(13).Value)
            Next

            culture = CultureInfo.CreateSpecificCulture("en-US")
            Dim total As String = gtotalmon
            Dim sum As Double
            sum = Double.Parse(total, culture)
            totalsales2.Text = sum.ToString("n2")

            For i = 0 To grdmonth.Rows.Count - 1
                grdmonth.Item(2, i).Style.BackColor = Color.FromArgb(255, 255, 128)
                grdmonth.Item(3, i).Style.BackColor = Color.FromArgb(255, 255, 128)
                grdmonth.Item(4, i).Style.BackColor = Color.FromArgb(128, 255, 128)
                grdmonth.Item(5, i).Style.BackColor = Color.FromArgb(128, 255, 128)
                grdmonth.Item(6, i).Style.BackColor = Color.FromArgb(192, 192, 255)
                grdmonth.Item(7, i).Style.BackColor = Color.FromArgb(192, 192, 255)
            Next

            Me.Cursor = Cursors.Default
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub
    Private Sub cmbyear_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbyear.SelectedValueChanged, cmbCashiers3.SelectedValueChanged
        monthyear()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Cursor = Cursors.WaitCursor
        hourlyprev.Dispose()
        'hourlyprev.MdiParent = 'mdiform
        hourlyprev.Show()
        hourlyprev.WindowState = FormWindowState.Maximized
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = Cursors.WaitCursor
        dailyprev.Dispose()
        '  dailyprev.MdiParent = mdiform
        dailyprev.Show()
        dailyprev.WindowState = FormWindowState.Maximized
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Cursor = Cursors.WaitCursor
        monthlyprev.Dispose()
        '  monthlyprev.MdiParent = mdiform
        monthlyprev.Show()
        monthlyprev.WindowState = FormWindowState.Maximized
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmbCashiers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCashiers.SelectedIndexChanged
        hourly(cmbCashiers.Text)
    End Sub

    Private Sub cmbCashiers2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCashiers2.SelectedIndexChanged
        daily(cmbCashiers2.Text)
    End Sub

    Private Sub cmbyear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbyear.SelectedIndexChanged
        monthyear()
    End Sub

    Private Sub cmbCashiers3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCashiers3.SelectedIndexChanged

    End Sub

    Private Sub Tab3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tab3.Click

    End Sub

    Private Sub grddaily_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grddaily.CellContentClick

    End Sub
End Class