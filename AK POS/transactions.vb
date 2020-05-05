Imports System.IO
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Globalization
Imports Microsoft.Office.Core
Imports Excel = Microsoft.Office.Interop.Excel
Imports ExcelAutoFormat = Microsoft.Office.Interop.Excel.XlRangeAutoFormat
Imports Microsoft.Office.Interop
Imports System.Xml.XPath
Imports System.Data
Imports System.Xml

Public Class transactions
    Dim strconn As String = login.ss
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim adptr As New SqlDataAdapter
    Dim sql As String

    Dim meron As Integer = 0, two As Integer = 0, stap As Boolean = False
    Dim culture As CultureInfo = Nothing
    Public trans As Boolean = False

    'pagination variables
    Dim query As String
    Dim offset As Integer = 0
    Dim rows As Integer = 0
    Dim pageNumber As Integer = 1
    Dim pageTotal As Integer = 1
    Dim pageTotal2 As String
    Dim inv_id As String = ""

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

    Private Sub transactions_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If mainmenu.counters = True Then
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        btnok.PerformClick()

        Me.WindowState = FormWindowState.Maximized
        ButtonSSearch.PerformClick()

        checkCancelled("Advance Payment Cash")
        checkCancelled("Deposit")

        newGenerations("Cash", lblcash)
        newGenerations("A.R Sales", lblarpayment)
        newGenerations("A.R Cash", lblarcash)
        newGenerations("A.R Charge", lblarcharge)
        newGenerations("Deposit", lbldeposit)
        newGenerations("Cash Out", lblcashout)
        newGenerations("Advance Payment Cash", lbladvancepaymentcash)
        newGenerations("Advance Payment", lbladvancepayment)
        'delXGC("delcharge", lblcashout)
        newGenerations("Cash", lblcashsales)
    End Sub
    Public Sub checkCancelled(ByVal tendertype As String)
        For index As Integer = 0 To grd.Rows.Count - 1
            connect()
            If grd.Rows(index).Cells("tendertype").Value = tendertype Then
                Dim a As String = ""
                cmd = New SqlCommand("select tbltransaction.transnum from tbladvancepayment JOIN tbltransaction ON tbladvancepayment.date= tbltransaction.datecreated WHERE tbltransaction.tendertype='" & tendertype & "' AND tbladvancepayment.status='Cancelled';", conn)
                dr = cmd.ExecuteReader
                While dr.Read
                    a = dr("transnum")
                    If a = grd.Rows(index).Cells("trnum").Value Then
                        grd.Rows(index).DefaultCellStyle.BackColor = Color.Firebrick
                        grd.Rows(index).DefaultCellStyle.ForeColor = Color.White
                    End If
                End While
            End If
        Next
    End Sub
    Private Sub transactions_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim a As String = MsgBox("Are you sure you want to close Transactions Form?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "")
        If a = vbYes Then
            '    mdiform.Show()
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub
    Public Sub getID()
        Try
            connect()
            cmd = New SqlCommand("Select Top 1 invnum from tblinvsum WHERE area='" & "Administrator" & "'  order by invsumid DESC", conn)
            dr = cmd.ExecuteReader()
            If dr.Read Then
                inv_id = dr("invnum")
            End If
        Catch ex As Exception
        Finally
            disconnect()
        End Try
    End Sub
    Public Sub newGenerations(ByVal tenderType As String, ByVal lbl As Label)
        Dim total As Double = 0.0
        For index As Integer = 0 To grd.Rows.Count - 1
            If grd.Rows(index).Cells("tendertype").Value = tenderType Then
                If tenderType = "A.R Cash" Then
                    total += CDbl(grd.Rows(index).Cells("amtdue").Value) + CDbl(grd.Rows(index).Cells("partialamt").Value)
                Else
                    If grd.Rows(index).Cells("tendertype").Value = "Advance Payment Cash" Or grd.Rows(index).Cells("tendertype").Value = "Deposit" Then
                        If grd.Rows(index).DefaultCellStyle.BackColor <> Color.Firebrick Then
                            total += CDbl(grd.Rows(index).Cells("amtdue").Value)
                        End If
                    Else
                        total += CDbl(grd.Rows(index).Cells("amtdue").Value)
                    End If
                End If
            End If
        Next
        lbl.Text = total.ToString("n2")
        lblgtotal.Text = (CDbl(lblarcash.Text) + CDbl(lblcash.Text) + CDbl(lbladvancepaymentcash.Text) - CDbl(lblcashout.Text) + CDbl(lbldeposit.Text)).ToString("n2")
        lblcashonhand.Text = (CDbl(lblgtotal.Text)).ToString("n2")
        lblpaymenttotal.Text = (CDbl(lblarpayment.Text) + CDbl(lblcashsales.Text) + CDbl(lbladvancepayment.Text) + CDbl(lblarcharge.Text)).ToString("n2")
        totalsales.Text = (CDbl(lblgtotal.Text) + CDbl(lblpaymenttotal.Text)).ToString("n2")
    End Sub
    Public Sub delXGC(ByVal sumOf As String, ByVal lbl As Label)
        Try
            Dim total As Double = 0.0
            connect()
            For index As Integer = 0 To grd.Rows.Count - 1
                cmd = New SqlCommand("SELECT ISNULL(SUM(" & sumOf & "),0) FROM tbltransaction WHERE transnum='" & grd.Rows(index).Cells("trnum").Value & "';", conn)
                total += cmd.ExecuteScalar()
            Next
            lbl.Text = total.ToString("n2")
            lblgtotal.Text = (CDbl(lblarcash.Text) + CDbl(lblcash.Text) + CDbl(lbladvancepaymentcash.Text) + CDbl(lblcashout.Text) + CDbl(lbldeposit.Text)).ToString("n2")
            lblpaymenttotal.Text = (CDbl(lblarpayment.Text) + CDbl(lbladvancepayment.Text)).ToString("n2")
            totalsales.Text = (CDbl(lblgtotal.Text) + CDbl(lblpaymenttotal.Text)).ToString("n2")
        Catch ex As Exception
        Finally
            disconnect()
        End Try
    End Sub
    Private Sub transactions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            LabelTotalPage.Text = "Total Page: 1"
            Me.Cursor = Cursors.WaitCursor

            dateto1.MinDate = datefrom1.Value
            dateto1.MaxDate = Date.Now
            datefrom1.MaxDate = Date.Now

            datefrom1.Format = DateTimePickerFormat.Custom
            dateto1.Format = DateTimePickerFormat.Custom

            datefrom1.CustomFormat = "MM/dd/yyyy"
            dateto1.CustomFormat = "MM/dd/yyyy"

            grd.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grd.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            grdorders.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grdorders.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grdorders.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grdorders.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            loadcashier()
            If cmbcash.Items.Count > 1 Then
                cmbcash.SelectedItem = "All"
            End If

            If login.neym <> "Cashier" Then
                btnrefund.Visible = False
            Else
                btnrefund.Visible = True
            End If

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Public Sub loadcashier()
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim sql As String = ""
            If login.wrkgrp = "Cashier" Then
                cmbcash.Items.Clear()
                cmbcash.Items.Add(login.username)
                cmbcash.Items.Add("All")
            Else
                sql = "Select * from tbltransaction where transdate>='" & Format(datefrom1.Value, "MM/dd/yyyy") & "' and  transdate<='" & Format(dateto1.Value, "MM/dd/yyyy") & "' AND area='Sales' order by cashier"
                meron = 0
                connect()
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                While dr.Read
                    If dr("cashier").ToString <> "" And Not cmbcash.Items.Contains(dr("cashier").ToString) Then
                        meron = 1
                        cmbcash.Items.Add(dr("cashier"))
                    End If
                End While
                If meron = 1 Then
                    cmbcash.Items.Add("All")
                End If
                dr.Dispose()
                cmd.Dispose()
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

    Public Sub loadtransnum(ByVal workgroup As String)
        Try
            Me.Cursor = Cursors.WaitCursor
            grd.Rows.Clear()
            query = "Select * from tbltransaction LEFT OUTER JOIN tblsenior ON tbltransaction.transnum=tblsenior.transnum where (tbltransaction.customer like '%" & Trim(txtcus.Text) & "%' or tblsenior.name like '%" & Trim(txtcus.Text) & "%')"

            If cmbcash.SelectedItem = "All" Then
                If hfrom.SelectedItem <> "" And hfrom.SelectedItem <> "" And txttrans.Text <> "" And txtcus.Text <> "" Then
                    Dim dfrom As DateTime = CDate(Format(datefrom1.Value, "MM/dd/yyyy") & " " & hfrom.SelectedItem)
                    Dim dto As DateTime = CDate(Format(dateto1.Value, "MM/dd/yyyy") & " " & hto.SelectedItem)
                    query = query & " and tbltransaction.datecreated>='" & dfrom & "' and tbltransaction.datecreated<='" & dto & "'"
                ElseIf hfrom.Text = "" And hfrom.Text = "" Then
                    Dim dfrom As DateTime = CDate(Format(datefrom1.Value, "MM/dd/yyyy"))
                    Dim dto As DateTime = CDate(Format(dateto1.Value, "MM/dd/yyyy"))
                    query = query & " and tbltransaction.transdate>='" & dfrom & "' and tbltransaction.transdate<='" & dto & "'"
                ElseIf Not txttrans.Text.Equals("") Then
                    Dim dfrom As DateTime = CDate(Format(datefrom1.Value, "MM/dd/yyyy") & " " & hfrom.SelectedItem)
                    Dim dto As DateTime = CDate(Format(dateto1.Value, "MM/dd/yyyy") & " " & hto.SelectedItem)
                    query = query & " and tbltransaction.datecreated>='" & dfrom & "' and tbltransaction.datecreated<='" & dto & "' and tbltransaction.transnum='" + txttrans.Text + "'"
                ElseIf txtcus.Text.Equals("CASH") Or txtcus.Text.Equals("cash") Then
                    Dim dfrom As DateTime = CDate(Format(datefrom1.Value, "MM/dd/yyyy") & " " & hfrom.SelectedItem)
                    Dim dto As DateTime = CDate(Format(dateto1.Value, "MM/dd/yyyy") & " " & hto.SelectedItem)
                    query = query & " and tbltransaction.datecreated>='" & dfrom & "' and tbltransaction.datecreated<='" & dto & "' and tbltransaction.customer='" + txtcus.Text + "'"
                ElseIf Not txtcus.Text.Equals("") Then
                    Dim dfrom As DateTime = CDate(Format(datefrom1.Value, "MM/dd/yyyy") & " " & hfrom.SelectedItem)
                    Dim dto As DateTime = CDate(Format(dateto1.Value, "MM/dd/yyyy") & " " & hto.SelectedItem)
                    query = query & " and tbltransaction.datecreated>='" & dfrom & "' and tbltransaction.datecreated<='" & dto & "' and tbltransaction.customer='" + txtcus.Text + "'"
                Else
                    'cashier with date only without time
                    Dim dfrom As DateTime = CDate(Format(datefrom1.Value, "MM/dd/yyyy") & " " & hfrom.SelectedItem)
                    Dim dto As DateTime = CDate(Format(dateto1.Value, "MM/dd/yyyy") & " " & hto.Text)
                    query = query & " and tbltransaction.datecreated BETWEEN '" & dfrom & "' AND '" & dto & "' and tbltransaction.customer='" + txtcus.Text + "'"
                    'query & " and tbltransaction.datecreated='" & dfrom & "' tbltransaction.datecreated='" & dto & "'
                End If
            Else
                If hfrom.SelectedItem <> "" And hfrom.SelectedItem <> "" Then
                    Dim dfrom As DateTime = CDate(Format(datefrom1.Value, "MM/dd/yyyy") & " " & hfrom.SelectedItem)
                    Dim dto As DateTime = CDate(Format(dateto1.Value, "MM/dd/yyyy") & " " & hto.SelectedItem)
                    'MsgBox(dfrom & " - " & dto)
                    query = query & " and tbltransaction.cashier='" & cmbcash.SelectedItem & "' and tbltransaction.datecreated>='" & dfrom & "' and tbltransaction.datecreated<='" & dto & "'"
                Else
                    'with cashier with date only without time
                    query = query & " and tbltransaction.cashier='" & cmbcash.SelectedItem & "' and tbltransaction.transdate>='" & Format(datefrom1.Value, "MM/dd/yyyy") & "' and  tbltransaction.transdate<='" & Format(dateto1.Value, "MM/dd/yyyy") & "'"
                End If
            End If
            'If workgroup <> "" Then 
            '    query &= " AND Not area='Production'"
            'End If
            If chkrefund.Checked Then
                query &= " AND tbltransaction.refund='1'"
            Else
                query &= " AND tbltransaction.refund='0'"
            End If

            query = query & " ORDER BY 1 OFFSET " & offset & " ROWS FETCH NEXT 30 ROWS ONLY"
            Dim s As String = query
            s = s.Replace("*", "COUNT(*)")
            connect()
            Dim cc As SqlCommand = New SqlCommand(s, conn)
            rows = Convert.ToInt64(cc.ExecuteScalar()) - 1
            pageTotal = Math.Ceiling(rows / 30) * 1
            disconnect()
            connect()
            Dim cmd1 As SqlCommand = New SqlCommand(query, conn)
            Dim dr1 As SqlDataReader = cmd1.ExecuteReader
            While dr1.Read

                Dim partialamt As Double = 0.0
                If IsDBNull(dr1("partialamt")) Then
                    partialamt = 0
                Else
                    partialamt = dr1("partialamt")
                End If

                grd.Rows.Add(dr1("transid"), dr1("transnum"), dr1("amtdue"), partialamt.ToString("n2"), dr1("servicetype"), "", dr1("tendertype"))
                grd.Columns(5).Visible = False
            End While
            dr1.Dispose()
            cmd1.Dispose()

            Me.Cursor = Cursors.Default

            If grd.Rows.Count <> 0 Then
                selecttrans()
                btnhour.Enabled = False

                'totalsales
                Dim total As Double = 0
                For Each row In grd.Rows
                    total += grd.Rows(row.index).Cells("amtdue").Value
                Next
                totalsales.Text = total.ToString("n2")

            Else
                MsgBox("No Record Found.", MsgBoxStyle.Critical, "")
                txtcus.Text = ""
                'btnok.PerformClick()
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

    Private Sub dateto1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dateto1.ValueChanged
        'searchEngine()
    End Sub

    Private Sub datefrom1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles datefrom1.ValueChanged
        'searchEngine()
    End Sub

    Private Sub cmbcash_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcash.SelectedValueChanged
        loadcashier()
        If Trim(txtcus.Text) <> "" Then
            If login.wrkgrp = "Production" Then
                searchcustomer(offset, "Sales")
            ElseIf login.wrkgrp = "Cashier" Or login.wrkgrp = "Administrator" Or login.wrkgrp = "Manager" Then
                searchcustomer(offset, "Sales")
            Else
                searchcustomer(offset, login.wrkgrp)
            End If
            Exit Sub
        End If
        btnok.PerformClick()
    End Sub

    Private Sub grd_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd.CellClick
        selecttrans()
    End Sub

    Public Sub selecttrans()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim i As Integer = 0
            'grd.Rows.Clear()
            grdorders.Rows.Clear()
            If grd.Rows.Count <> 0 And (grd.SelectedCells.Count = 1 Or grd.SelectedRows.Count = 1) Then
                btnrefund.Enabled = True
                btnremarks.Enabled = True
                sql = "Select * from tbltransaction where transnum='" & grd.Rows(grd.CurrentRow.Index).Cells("trnum").Value & "' AND tendertype='" & grd.Rows(grd.CurrentRow.Index).Cells("tendertype").Value & "';"
                connect()
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    Me.Cursor = Cursors.WaitCursor
                    lbltransnum.Text = dr("transnum")
                    lblcashier.Text = dr("cashier")
                    lbldate.Text = Format(dr("datecreated"), "HH:mm   MM/dd/yyyy")
                    lblsub.Text = Val(dr("subtotal")).ToString("n2")
                    lbldel.Text = Val(dr("delcharge")).ToString("n2")
                    lbldisc.Text = dr("disctype")
                    lblgcamt.Text = Val(dr("gctotal")).ToString("n2")
                    lblless.Text = Val(dr("less")).ToString("n2")
                    lblvatsales.Text = Val(dr("vatsales")).ToString("n2")
                    lblvatamt.Text = Val(dr("vat")).ToString("n2")


                    If grd.CurrentRow.Cells("amtdue").Value = 0 Then
                        lbltotal.Text = CDbl(dr("partialamt")).ToString("n2")
                        Label12.Text = "Partial Amount:"
                    ElseIf grd.CurrentRow.Cells("partialamt").Value = 0 Then
                        lbltotal.Text = CDbl(dr("amtdue")).ToString("n2")
                        Label12.Text = "Total Amt. Due:"
                    End If
                    lblrems.Text = dr("remarks") & dr("comment")
                    lblrems.Tag = dr("remarks")
                End If
                dr.Dispose()
                cmd.Dispose()

                If lbldisc.Text.ToString.Contains("Senior") Or lbldisc.Text.ToString.Contains("Pwd") Then
                    culture = CultureInfo.CreateSpecificCulture("en-US")
                    Dim subttal As Double = Double.Parse(lblsub.Text, culture)

                    If lblrems.Tag.Contains("W/ GRPM") Then
                        'get the vinclude first equals subtotal minus based
                        'get the not disc amt in based equals based/1.12 * .8
                        'then amount due equals add the vinclude and the 80% of the based
                        Dim vatamt As Double = Double.Parse(lblvatamt.Text, culture)
                        Dim vatsales As Double = Double.Parse(lblvatsales.Text, culture)
                        Dim total As Double = Double.Parse(lblsub.Text, culture)
                        Dim vinclude As Double = total - (vatamt + vatsales)
                        lblexempt.Text = Val((vatamt + vatsales) / 1.12).ToString("n2")
                        lblvatsales.Text = Val(vinclude / 1.12).ToString("n2")
                        lblvatamt.Text = Val(vinclude - (vinclude / 1.12)).ToString("n2")
                    Else
                        lblexempt.Text = Val(subttal / 1.12).ToString("n2")
                        lblvatamt.Text = "0.00"
                        lblvatsales.Text = "0.00"
                    End If
                Else
                    lblexempt.Text = "0.00"
                End If

                If grd.Rows(grd.CurrentRow.Index).Cells("servicetype").Value = "Transfer" Then
                    sql = "Select * from tbltransfer where transnum='" & grd.Rows(grd.CurrentRow.Index).Cells("trnum").Value & "'"
                    connect()
                    cmd = New SqlCommand(sql, conn)
                    dr = cmd.ExecuteReader
                    If dr.Read Then
                        lbltransfer.Text = "Transfer to: " & dr("branch")
                    End If
                    dr.Dispose()
                    cmd.Dispose()
                Else
                    lbltransfer.Text = ""
                End If

                Me.Cursor = Cursors.Default

                If grd.CurrentRow.Cells("tendertype").Value = "Advance Payment" Then
                    grdorders.Rows.Clear()
                Else
                    sql = "SELECT * FROM tblorder JOIN tbltransaction ON tblorder.transnum=tbltransaction.transnum WHERE tblorder.transnum='" & grd.CurrentRow.Cells("trnum").Value & "' AND tbltransaction.tendertype='" & grd.CurrentRow.Cells("tendertype").Value & "'"
                    TextBox1.Text = sql
                    connect()
                    cmd = New SqlCommand(sql, conn)
                    dr = cmd.ExecuteReader
                    While dr.Read
                        Dim z As Boolean = False
                        If dr("free") <> 0 Then
                            z = True
                        Else
                            z = False
                        End If
                        grdorders.Rows.Add(dr("itemname"), dr("qty"), dr("price"), dr("dscnt"), dr("totalprice"), dr("request"), z)
                    End While
                    dr.Dispose()
                    cmd.Dispose()

                    Dim t As String = ""
                    cmd = New SqlCommand("select tbltransaction2.ordernum FROM tbltransaction2 JOIN tbltransaction ON tbltransaction2.transnum = tbltransaction.transnum WHERE tbltransaction.transnum='" & lbltransnum.Text & "';", conn)
                    dr = cmd.ExecuteReader
                    If dr.Read Then
                        t = dr("ordernum")
                    End If
                    lblordernum.Text = t
                End If


                connect()
                cmd = New SqlCommand("SELECT  tbladvancepayment.apnum FROM tblreturns JOIN tbladvancepayment ON tblreturns.ap_id = tbladvancepayment.ap_id JOIN tbltransaction ON tblreturns.transnum = tbltransaction.transnum JOIN tblorder ON tblorder.transnum = tblreturns.transnum JOIN tblitems ON tblorder.itemname = tblitems.itemname WHERE tblitems.deposit='1' AND tbltransaction.transnum='" & grd.CurrentRow.Cells("trnum").Value & "' OR tblreturns.status='" & "Active" & "'   AND tblreturns.status='" & "Used" & "'  ORDER BY tblreturns.returnum;", conn)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    lbldepositnumm.Text = dr("apnum")
                Else
                    lbldepositnumm.Text = "N/A"
                End If




                Me.Cursor = Cursors.Default
                btnremarks.Enabled = True
                btnrefund.Enabled = True
                btnhour.Enabled = True
                btnitem.Enabled = True
                btnsenior.Enabled = True
                btngc.Enabled = True
                btncharge.Enabled = True
                If Trim(txttrans.Text) <> "" Then
                    btnhour.Enabled = False
                    btnitem.Enabled = False
                End If
            Else
                btnremarks.Enabled = False
                btnrefund.Enabled = False
                btnhour.Enabled = False
                btnitem.Enabled = False
                btnsenior.Enabled = False
                btngc.Enabled = False
                btncharge.Enabled = False
            End If

            If grd.Rows.Count <> 0 Then
                btnreport.Enabled = True
                btnrefund.Enabled = True
                If grd.SelectedCells.Count = 1 Or grd.SelectedRows.Count = 1 Then
                    Dim checkCell As DataGridViewCheckBoxCell = CType(grd.Rows(grd.CurrentRow.Index).Cells("refund"), DataGridViewCheckBoxCell)
                    If checkCell.Value.ToString = "" Then
                        Exit Sub
                    End If
                    If CBool(checkCell.Value) = True Then
                        btnrefund.Enabled = False
                        btnhour.Enabled = False
                        btnitem.Enabled = False
                        btnsenior.Enabled = False
                        btngc.Enabled = False
                        btncharge.Enabled = False
                    Else
                        btnrefund.Enabled = True
                        btnhour.Enabled = True
                        btnitem.Enabled = True
                        btnsenior.Enabled = True
                        btncharge.Enabled = True
                        btngc.Enabled = True
                        If Trim(txttrans.Text) <> "" Then
                            btnhour.Enabled = False
                            btnitem.Enabled = False
                        End If
                    End If

                Else
                    lbltransnum.Text = ""
                    lblcashier.Text = ""
                    lbldate.Text = ""
                    lblsub.Text = "0.00"
                    lbldisc.Text = "None"
                    lblless.Text = "0.00"
                    lbldel.Text = "0.00"
                    lblvatamt.Text = "0.00"
                    lblvatsales.Text = "0.00"
                    lbltotal.Text = "0.00"
                    lbltransfer.Text = ""
                    lblrems.Text = ""
                    btnhour.Enabled = False
                    btnitem.Enabled = False
                    btnsenior.Enabled = False
                    btngc.Enabled = False
                    btncharge.Enabled = False
                End If
            Else
                btnremarks.Enabled = False
                btnreport.Enabled = False
                btnrefund.Enabled = False
                btnhour.Enabled = False
                btnitem.Enabled = False
                btnsenior.Enabled = False
                btngc.Enabled = False
                btncharge.Enabled = False
                lbltransnum.Text = ""
                lblcashier.Text = ""
                lbldate.Text = ""
                lblsub.Text = "0.00"
                lbldisc.Text = "None"
                lblless.Text = "0.00"
                lbldel.Text = "0.00"
                lblvatamt.Text = "0.00"
                lblvatsales.Text = "0.00"
                lbltotal.Text = "0.00"
                lbltransfer.Text = ""
                lblrems.Text = ""
            End If

            If chkrefund.Checked = True And grd.Rows.Count <> 0 Then
                btnhour.Enabled = False
                btnitem.Enabled = False
                btnsenior.Enabled = False
                btngc.Enabled = False
                btncharge.Enabled = False
            ElseIf chkrefund.Checked <> True And grd.Rows.Count <> 0 Then
                btnhour.Enabled = True
                btnitem.Enabled = True
                btnsenior.Enabled = True
                btngc.Enabled = True
                btncharge.Enabled = True
                If Trim(txttrans.Text) <> "" Then
                    btnhour.Enabled = False
                    btnitem.Enabled = False
                End If
            End If

            For index As Integer = 0 To grdorders.RowCount - 1
                Dim result As Double = CDbl(grdorders.Rows(index).Cells("quantity").Value) * CDbl(grdorders.Rows(index).Cells("price").Value)

                If result <> CDbl(grdorders.Rows(index).Cells("amount").Value) Then
                    grdorders.Columns("amount").HeaderText = "Discounted Amount"
                End If
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

    Private Sub grd_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd.SelectionChanged
        If grd.Rows(grd.CurrentRow.Index).Cells("trnum").Value IsNot Nothing Then
            selecttrans()
        End If
    End Sub

    Private Sub btnremarks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnremarks.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            If btnremarks.Text = "  Add Remarks" Then
                sql = "Select * from tbltransaction where transnum='" & lbltransnum.Text & "'"
                connect()
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    txtrems.Text = dr("comment")
                    lblrems.Tag = dr("remarks").ToString
                End If
                dr.Read()
                cmd.Dispose()

                txtrems.Visible = True
                btncancel.Visible = True
                txtrems.Focus()
                btnremarks.Text = "  Add Remarks"
            Else
                confirm.ShowDialog()
                If trans = True Then
                    sql = "Update tbltransaction set comment='" & " -" & Trim(txtrems.Text) & "', datemodified='" & Date.Now & "' where transnum='" & lbltransnum.Text & "'"
                    connect()
                    cmd = New SqlCommand(sql, conn)
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()

                    lblrems.Text = lblrems.Tag & " -" & Trim(txtrems.Text)
                End If
                txtrems.Text = ""
                txtrems.Visible = False
                btncancel.Visible = False
                btnremarks.Text = "   Add Remarks"
                trans = False
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

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        txtrems.Text = ""
        txtrems.Visible = False
        btncancel.Visible = False
        btnremarks.Text = "  Add Remarkss"
    End Sub

    Private Sub txtrems_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrems.KeyPress
        If Trim(txtrems.Text) <> "" Then
            If Asc(e.KeyChar) = Windows.Forms.Keys.Enter Then
                btnremarks.PerformClick()
            End If
        End If
    End Sub

    Private Sub txtrems_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtrems.TextChanged
        Dim charactersDisallowed As String = "'"
        Dim theText As String = txtrems.Text
        Dim Letter As String
        Dim SelectionIndex As Integer = txtrems.SelectionStart
        Dim Change As Integer

        For x As Integer = 0 To txtrems.Text.Length - 1
            Letter = txtrems.Text.Substring(x, 1)
            If charactersDisallowed.Contains(Letter) Then
                theText = theText.Replace(Letter, String.Empty)
                Change = 1
            End If
        Next

        txtrems.Text = theText
        txtrems.Select(SelectionIndex - Change, 0)
    End Sub

    Private Sub btnreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnreport.Click
        Me.Cursor = Cursors.WaitCursor

        dailysalesprev.Close()
        dsalesreport.Close()
        dailysalesprev.ctr = True
        dsalesreport.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnrefund_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefund.Click
        Try
            If (grd.SelectedCells.Count = 1 Or grd.SelectedRows.Count = 1) Then
                Dim a As String = MsgBox("Are you sure you want to refund transaction?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "")
                If a = vbYes Then
                    'check if transaction is today and if cashier is login.cashier/////////////
                    sql = "Select * from tbltransaction where transdate='" & Format(Date.Now, "MM/dd/yyyy") & "' and transnum='" & lbltransnum.Text & "'"
                    connect()
                    cmd = New SqlCommand(sql, conn)
                    dr = cmd.ExecuteReader
                    If dr.Read Then
                        If dr("cashier") <> login.cashier Then
                            MsgBox("Authorization failed! Cannot refund transaction.", MsgBoxStyle.Critical, "")
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                    Else
                        MsgBox("Cannot refund transaction.", MsgBoxStyle.Critical, "")
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If

                    grd.Enabled = False
                    confirm.ShowDialog()
                    If trans = True Then

                        sql = "Update tbltransaction set refund='1' where transnum='" & lbltransnum.Text & "'"
                        connect()
                        cmd = New SqlCommand(sql, conn)
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()

                        sql = "Select * from tblorder where transnum='" & lbltransnum.Text & "'"
                        connect()
                        cmd = New SqlCommand(sql, conn)
                        dr = cmd.ExecuteReader
                        While dr.Read
                            ' MsgBox(dr("itemname") & " " & dr("qty"))
                            'lahat ng qty - i subtract nmn sa counter out
                            'update inventory stocks
                            Dim lastinvid As String = ""
                            Dim lastin As Integer, lasttotal As Integer, lastout As Integer, lastactual As Integer, lasttotalout As Integer, lastpull As Integer, lastend As Integer
                            sql = "Select TOP 1 * from tblinvitems where itemname='" & dr("itemname") & "' order by invid DESC"
                            connect()
                            Dim cmd1 As SqlCommand = New SqlCommand(sql, conn)
                            Dim dr1 As SqlDataReader = cmd1.ExecuteReader
                            If dr1.Read Then
                                lastin = dr1("itemin")
                                lasttotal = dr1("begbal") + dr1("itemin")
                                lastout = dr1("ctrout")
                                lasttotalout = dr1("ctrout") + dr1("pullout")
                                lastactual = dr1("actualendbal")
                                lastpull = dr1("pullout")
                                lastend = dr1("endbal")
                                lastinvid = dr1("invnum")
                                MsgBox(lastinvid)
                            End If
                            dr1.Dispose()
                            cmd1.Dispose()

                            'Dim uin As Double = dr("qty") + lastin
                            'Dim utotal As Double = dr("qty") + lasttotal
                            Dim uctr As Double = lastout - dr("qty")
                            'Dim uend As Double = lasttotal - ((lastout - dr("qty")) + lastpull)
                            Dim uend As Double = lastend + dr("qty")
                            Dim uvar As Double = lastactual - uend
                            Dim urems As String = ""
                            If uvar < 0 Then
                                urems = "Short"
                            ElseIf uvar > 0 Then
                                urems = "Over"
                            End If


                            sql = "Update tblinvitems set ctrout='" & uctr & "', endbal='" & uend & "', variance='" & uvar & "', shortover='" & urems & "' where itemname='" & dr("itemname") & "' and invnum='" & lastinvid & "'"
                            connect()
                            cmd1 = New SqlCommand(sql, conn)
                            cmd1.ExecuteNonQuery()
                            cmd1.Dispose()
                        End While
                        dr.Dispose()
                        cmd.Dispose()

                        MsgBox("Refund Transaction Successfully.", MsgBoxStyle.Information, "")
                        loadcashier()
                        btnok.PerformClick()
                    End If
                    trans = False
                End If
                grd.Enabled = True
            Else
                MsgBox("Select only one.", MsgBoxStyle.Exclamation, "")
            End If

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

    Private Sub btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If chkrefund.Checked = True Then
                grd.Columns(4).Visible = True
            Else
                grd.Columns(4).Visible = False
            End If
            If login.wrkgrp = "Production" Then
                loadtransnum("")
            ElseIf login.wrkgrp = "Cashier" Or login.wrkgrp = "Administrator" Or login.wrkgrp = "Manager" Then
                loadtransnum("Sales")
            Else
                loadtransnum(login.wrkgrp)
            End If
            selecttrans()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Private Sub btnhour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhour.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            If grd.Rows.Count = 0 Then
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            If chkrefund.Checked = True Then
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            Dim temph1 As Integer = 0, temph2 As Integer = 0, temph3 As Integer = 0, temph4 As Integer = 0, temph5 As Integer = 0, temph6 As Integer = 0
            Dim temph7 As Integer = 0, temph8 As Integer = 0, temph9 As Integer = 0, temph10 As Integer = 0, temph11 As Integer = 0, temph12 As Integer = 0, temph13 As Integer = 0

            Dim salesh1 As Double = 0, salesh2 As Double = 0, salesh3 As Double = 0, salesh4 As Double = 0, salesh5 As Double = 0, salesh6 As Double = 0
            Dim salesh7 As Double = 0, salesh8 As Double = 0, salesh9 As Double = 0, salesh10 As Double = 0, salesh11 As Double = 0, salesh12 As Double = 0, salesh13 As Double = 0

            connect()
            For Each row As DataGridViewRow In grd.Rows
                sql = "Select datecreated,amtdue from tbltransaction where transnum='" & grd.Rows(row.Index).Cells("trnum").Value & "'"
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    Dim time As DateTime = Format(dr("datecreated"), "HH:mm")

                    Dim h1 As DateTime = "08:00 AM"
                    Dim h11 As DateTime = "08:59 AM"
                    If h1 <= time And h11 >= time Then
                        temph1 += 1
                        salesh1 += dr("amtdue")
                        'MsgBox(salesh1)
                    End If

                    Dim h2 As DateTime = "09:00 AM"
                    Dim h22 As DateTime = "09:59 AM"
                    If h2 <= time And h22 >= time Then
                        temph2 += 1
                        salesh2 += dr("amtdue")
                        'MsgBox(salesh2)
                    End If

                    Dim h3 As DateTime = "10:00 AM"
                    Dim h33 As DateTime = "10:59 AM"
                    If h3 <= time And h33 >= time Then
                        temph3 += 1
                        salesh3 += dr("amtdue")
                        'MsgBox(salesh3)
                    End If

                    Dim h4 As DateTime = "11:00 AM"
                    Dim h44 As DateTime = "11:59 AM"
                    If h4 <= time And h44 >= time Then
                        temph4 += 1
                        salesh4 += dr("amtdue")
                        'MsgBox(salesh4)
                    End If

                    Dim h5 As DateTime = "12:00 PM"
                    Dim h55 As DateTime = "12:59 PM"
                    If h5 <= time And h55 >= time Then
                        temph5 += 1
                        salesh5 += dr("amtdue")
                        'MsgBox(salesh5)
                    End If

                    Dim h6 As DateTime = "01:00 PM"
                    Dim h66 As DateTime = "01:59 PM"
                    If h6 <= time And h66 >= time Then
                        temph6 += 1
                        salesh6 += dr("amtdue")
                        'MsgBox(salesh6)
                    End If

                    Dim h7 As DateTime = "02:00 PM"
                    Dim h77 As DateTime = "02:59 PM"
                    If h7 <= time And h77 >= time Then
                        temph7 += 1
                        salesh7 += dr("amtdue")
                        'MsgBox(salesh7)
                    End If

                    Dim h8 As DateTime = "03:00 PM"
                    Dim h88 As DateTime = "03:59 PM"
                    If h8 <= time And h88 >= time Then
                        temph8 += 1
                        salesh8 += dr("amtdue")
                        'MsgBox(salesh8)
                    End If

                    Dim h9 As DateTime = "04:00 PM"
                    Dim h99 As DateTime = "04:59 PM"
                    If h9 <= time And h99 >= time Then
                        temph9 += 1
                        salesh9 += dr("amtdue")
                        'MsgBox(salesh9)
                    End If

                    Dim h10 As DateTime = "05:00 PM"
                    Dim h110 As DateTime = "05:59 PM"
                    If h10 <= time And h110 >= time Then
                        temph10 += 1
                        salesh10 += dr("amtdue")
                        'MsgBox(salesh10)
                    End If

                    Dim h11a As DateTime = "06:00 PM"
                    Dim h111 As DateTime = "06:59 PM"
                    If h11a <= time And h111 >= time Then
                        temph11 += 1
                        salesh11 += dr("amtdue")
                        'MsgBox(salesh11)
                    End If

                    Dim h12a As DateTime = "07:00 PM"
                    Dim h112 As DateTime = "07:59 PM"
                    If h12a <= time And h112 >= time Then
                        temph12 += 1
                        salesh12 += dr("amtdue")
                        'MsgBox(salesh12)
                    End If

                    Dim h13a As DateTime = "08:00 PM"
                    Dim h113 As DateTime = "08:59 PM"
                    If h13a <= time And h113 >= time Then
                        temph13 += 1
                        salesh13 += dr("amtdue")
                        'MsgBox(salesh13)
                    End If
                End If
                cmd.Dispose()
                dr.Dispose()
            Next

            hourly.temph1 = temph1
            hourly.salesh1 = salesh1
            hourly.temph2 = temph2
            hourly.salesh2 = salesh2
            hourly.temph3 = temph3
            hourly.salesh3 = salesh3
            hourly.temph4 = temph4
            hourly.salesh4 = salesh4
            hourly.temph5 = temph5
            hourly.salesh5 = salesh5
            hourly.temph6 = temph6
            hourly.salesh6 = salesh6
            hourly.temph7 = temph7
            hourly.salesh7 = salesh7
            hourly.temph8 = temph8
            hourly.salesh8 = salesh8
            hourly.temph9 = temph9
            hourly.salesh9 = salesh9
            hourly.temph10 = temph10
            hourly.salesh10 = salesh10
            hourly.temph11 = temph11
            hourly.salesh11 = salesh11
            hourly.temph12 = temph12
            hourly.salesh12 = salesh12
            hourly.temph13 = temph13
            hourly.salesh13 = salesh13

            If cmbcash.SelectedItem <> "All" Then
                hourly.lblcash.Text = cmbcash.SelectedItem
            End If
            If hfrom.SelectedItem <> "" And hto.SelectedItem <> "" Then
                hourly.lbldate.Text = Format(datefrom1.Value, "MM/dd/yyyy") & "  " & hfrom.SelectedItem & " - " & Format(dateto1.Value, "MM/dd/yyyy" & "  " & hto.SelectedItem)
            Else
                hourly.lbldate.Text = Format(datefrom1.Value, "MM/dd/yyyy") & " - " & Format(dateto1.Value, "MM/dd/yyyy")
            End If

            hourly.totalsales.Text = totalsales.Text

            hourly.ShowDialog()

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

    Private Sub chkrefund_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkrefund.CheckedChanged
        If chkrefund.Checked = False Then
            btnhour.Enabled = True
            btnitem.Enabled = True
            btnsenior.Enabled = True
            btngc.Enabled = True
            btncharge.Enabled = True
        Else
            btnhour.Enabled = False
            btnitem.Enabled = False
            btnsenior.Enabled = False
            btngc.Enabled = False
            btncharge.Enabled = False
        End If
        loadcashier()
        btnok.PerformClick()
    End Sub

    Private Sub btnitem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnitem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            'aahhh dapat ung mga transaction lng na nasa grd
            If hfrom.SelectedItem <> "" And hto.SelectedItem <> "" Then
                Copyitemsales.lbldate.Text = Format(datefrom1.Value, "MM/dd/yyyy") & "  " & hfrom.SelectedItem & " - " & Format(dateto1.Value, "MM/dd/yyyy" & "  " & hto.SelectedItem)

                Dim frmpull As String = Format(datefrom1.Value, "MM/dd/yyyy") & "  " & hfrom.SelectedItem
                Dim topull As String = Format(dateto1.Value, "MM/dd/yyyy") & "  " & hto.SelectedItem

                Copyitemsales.pullcondition = "where invdate>='" & frmpull & "' and invdate<='" & topull & "'"

                If cmbcash.SelectedItem <> "All" Then
                    Copyitemsales.lblcash.Text = cmbcash.SelectedItem
                End If
                Copyitemsales.ShowDialog()

            Else
                Copyitemsales.lbldate.Text = Format(datefrom1.Value, "MM/dd/yyyy") & " - " & Format(dateto1.Value, "MM/dd/yyyy")

                Dim frmpull As String = Format(datefrom1.Value, "MM/dd/yyyy")
                Dim topull As String = Format(dateto1.Value, "MM/dd/yyyy")

                Copyitemsales.pullcondition = "where invdate>='" & frmpull & "' and invdate<='" & topull & "'"
                If cmbcash.SelectedItem <> "All" Then
                    Copyitemsales.lblcash.Text = cmbcash.SelectedItem
                End If

                Copyitemsales.ShowDialog()
            End If

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Private Sub btnsenior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsenior.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            seniorinfo.grddis.Rows.Clear()
            If hfrom.SelectedItem <> "" And hto.SelectedItem <> "" Then
                seniorinfo.lbldate.Text = Format(datefrom1.Value, "MM/dd/yyyy") & "  " & hfrom.SelectedItem & " - " & Format(dateto1.Value, "MM/dd/yyyy" & "  " & hto.SelectedItem)
            Else
                seniorinfo.lbldate.Text = Format(datefrom1.Value, "MM/dd/yyyy") & " - " & Format(dateto1.Value, "MM/dd/yyyy")
            End If

            connect()
            For Each row As DataGridViewRow In grd.Rows
                sql = "Select * from tblsenior where transnum='" & grd.Rows(row.Index).Cells("trnum").Value & "'"
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    seniorinfo.grddis.Rows.Add(dr("systemid"), dr("transnum"), dr("idno"), dr("name"), dr("disctype"), Format(dr("datedisc"), "MM/dd/yyyy"))
                End If
                dr.Dispose()
                cmd.Dispose()
            Next

            If cmbcash.SelectedItem <> "All" Then
                seniorinfo.lblcash.Text = cmbcash.SelectedItem
            End If

            If seniorinfo.grddis.Rows.Count = 0 Then
                MsgBox("No Record Found.", MsgBoxStyle.Critical, "")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            seniorinfo.ShowDialog()

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

    Private Sub hfrom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hfrom.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        If hfrom.SelectedIndex <> 0 Then
            hto.Enabled = True
            If hfrom.SelectedItem <> "" And hto.SelectedItem <> "" Then
                If hto.SelectedIndex < hfrom.SelectedIndex And hto.SelectedIndex <> 0 Then
                    'check if ung date is nde magkaparehas pra pde
                    If Format(datefrom1.Value, "MM/dd/yyyy") <> Format(dateto1.Value, "MM/dd/yyyy") Then
                        If Trim(txtcus.Text) <> "" Then
                            'searchcustomer()
                            Exit Sub
                        End If
                        'btnok.PerformClick()
                    Else
                        MsgBox("Invalid Time.", MsgBoxStyle.Exclamation, "")
                        hto.SelectedIndex = 0
                    End If
                ElseIf hto.SelectedIndex = 0 Then
                    hfrom.SelectedIndex = 0
                Else
                    If Trim(txtcus.Text) <> "" Then
                        'searchcustomer()
                        Exit Sub
                    End If
                    'btnok.PerformClick()
                End If
            End If
        Else
            hto.SelectedIndex = 0
            hto.Enabled = False
            If Trim(txtcus.Text) <> "" Then
                'searchcustomer()
                Exit Sub
            End If
            'btnok.PerformClick()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub hto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hto.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        If hto.SelectedIndex < hfrom.SelectedIndex And hto.SelectedIndex <> 0 Then
            'check if ung date is nde magkaparehas pra pde
            If Format(datefrom1.Value, "MM/dd/yyyy") <> Format(dateto1.Value, "MM/dd/yyyy") Then
                If Trim(txtcus.Text) <> "" Then
                    'searchcustomer()
                    Exit Sub
                End If
                'btnok.PerformClick()
            Else
                MsgBox("Invalid Time.", MsgBoxStyle.Exclamation, "")
                hto.SelectedIndex = 0
            End If
        ElseIf hto.SelectedIndex = 0 Then
            hfrom.SelectedIndex = 0
        Else
            If Trim(txtcus.Text) <> "" Then
                'searchcustomer()
                Exit Sub
            End If
            'btnok.PerformClick()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txttrans_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttrans.KeyPress

        'If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) And Not e.KeyChar = "-" Then
        '    e.Handled = True
        'End If



    End Sub

    Private Sub txttrans_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttrans.TextChanged

        If Not txttrans.Text.Equals("") Then
            txtcus.Text = ""
        End If


    End Sub

    Public Sub searchtrans()
        Try
            Me.Cursor = Cursors.WaitCursor
            grd.Rows.Clear()

            sql = "Select * from tbltransaction where transnum='" & Trim(txttrans.Text) & "'"
            connect()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            If dr.Read Then
                connect()
                grd.Rows.Add()
                grd.Item(0, 0).Value = dr("transid")
                grd.Item(1, 0).Value = dr("transnum")
                grd.Item(2, 0).Value = dr("amtdue")
                Dim partialamt As Double = 0.0
                If IsDBNull(dr("partialamt")) Then
                    partialamt = 0
                Else
                    partialamt = dr("partialamt")
                End If
                grd.Item(3, 0).Value = partialamt.ToString("n2")
                grd.Item(4, 0).Value = dr("servicetype")
                grd.Item(6, 0).Value = dr("tendertype")
                grd.Columns(4).Visible = False
                If dr("refund") = 0 Then
                    totalsales.Text = Val(dr("amtdue")).ToString("n2")
                Else
                    totalsales.Text = "Refund"
                End If
            End If
            dr.Dispose()
            cmd.Dispose()

            If grd.Rows.Count <> 0 Then
                selecttrans()
                btnhour.Enabled = False
                btnitem.Enabled = False
                'btnsenior.Enabled = False
            Else
                MsgBox("Invalid Transaction Number.", MsgBoxStyle.Exclamation, "")
                txttrans.Text = ""
                btnok.PerformClick()
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

    Public Sub loadtransnumsearch()
        Try
            Me.Cursor = Cursors.WaitCursor
            If cmbcash.Items.Count = 0 Then
                'MsgBox("No Found Record.", MsgBoxStyle.Critical, "")
                grd.Rows.Clear()
                Me.Cursor = Cursors.Default
                'Exit Sub
            End If

            Dim i As Integer = 0
            Dim tempsales As Double = 0.0
            grd.Rows.Clear()
            grdorders.Rows.Clear()

            If cmbcash.SelectedItem = "All" Then
                'lol
                If hfrom.SelectedItem <> "" And hfrom.SelectedItem <> "" Then
                    Dim dfrom As DateTime = CDate(Format(datefrom1.Value, "MM/dd/yyyy") & " " & hfrom.SelectedItem)
                    Dim dto As DateTime = CDate(Format(dateto1.Value, "MM/dd/yyyy") & " " & hto.SelectedItem)
                    'MsgBox(dfrom & " - " & dto)
                    sql = "Select * from tbltransaction where datecreated>='" & dfrom & "' and datecreated<='" & dto & "'"
                Else
                    'cashier with date only without time
                    sql = "Select * from tbltransaction where transdate>='" & Format(datefrom1.Value, "MM/dd/yyyy") & "' and  transdate<='" & Format(dateto1.Value, "MM/dd/yyyy") & "'"
                End If
            Else
                If hfrom.SelectedItem <> "" And hfrom.SelectedItem <> "" Then
                    Dim dfrom As DateTime = CDate(Format(datefrom1.Value, "MM/dd/yyyy") & " " & hfrom.SelectedItem)
                    Dim dto As DateTime = CDate(Format(dateto1.Value, "MM/dd/yyyy") & " " & hto.SelectedItem)
                    'MsgBox(dfrom & " - " & dto)
                    sql = "Select * from tbltransaction where cashier='" & cmbcash.SelectedItem & "' and datecreated>='" & dfrom & "' and datecreated<='" & dto & "'"
                Else
                    'with cashier with date only without time
                    sql = "Select * from tbltransaction where cashier='" & cmbcash.SelectedItem & "' and transdate>='" & Format(datefrom1.Value, "MM/dd/yyyy") & "' and  transdate<='" & Format(dateto1.Value, "MM/dd/yyyy") & "'"
                End If
            End If
            sql &= " AND area='Sales' OR area='Administrator' OR tendertype='A.R Cash' OR tendertype='A.R Payment' OR tendertype='Cash'"
            If chkrefund.Checked = False Then
                sql = sql & " and refund='0'"
            Else
                sql = sql & " and refund='1'"
            End If
            Me.Cursor = Cursors.WaitCursor
            connect()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            While dr.Read
                grd.Rows.Add()
                grd.Item(0, i).Value = dr("transid")
                grd.Item(1, i).Value = dr("transnum")
                grd.Item(2, i).Value = dr("amtdue")

                Dim partialamt As Double = 0.0
                If IsDBNull(dr("partialamt")) Then
                    partialamt = 0
                Else
                    partialamt = dr("partialamt")
                End If

                grd.Item(3, i).Value = partialamt.ToString("n2")
                grd.Item(4, i).Value = dr("servicetype")
                grd.Item(6, i).Value = dr("tendertype")
                Dim checkCell As DataGridViewCheckBoxCell = CType(grd.Rows(i).Cells("refund"), DataGridViewCheckBoxCell)
                If dr("refund") = 0 Then
                    checkCell.Value = False
                    tempsales += dr("amtdue")
                Else
                    checkCell.Value = True
                End If
                i += 1
            End While
            Me.Cursor = Cursors.Default
            cmd.Dispose()
            dr.Dispose()

            culture = CultureInfo.CreateSpecificCulture("en-US")
            Dim total As String = tempsales
            Dim sum As Double
            sum = Double.Parse(total, culture)

            totalsales.Text = sum.ToString("n2") 'format into 2 decimal places with comma

            If grd.Rows.Count <> 0 Then
                btnhour.Enabled = True
                btnitem.Enabled = True
                btnsenior.Enabled = True
                btngc.Enabled = True
                btncharge.Enabled = True
            Else
                btnhour.Enabled = False
                btnitem.Enabled = False
                btnsenior.Enabled = False
                btngc.Enabled = False
                btncharge.Enabled = False
            End If
            Me.Cursor = Cursors.Default
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information) '////
        Finally
            disconnect()
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        itemsales.ShowDialog()
    End Sub

    Private Sub btngc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngc.Click
        Dim frmpull As String = Format(datefrom1.Value, "MM/dd/yyyy") & "  " & hfrom.SelectedItem
        Dim topull As String = Format(dateto1.Value, "MM/dd/yyyy") & "  " & hto.SelectedItem

        If Trim(txttrans.Text) <> "" Then

        Else
            giftcert.lbldate.Text = frmpull & " - " & topull
            giftcert.condition = " and transdate>='" & frmpull & "' and transdate<='" & topull & "'"
        End If

        giftcert.ShowDialog()

    End Sub

    Private Sub txtcus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcus.KeyPress
        If Not Char.IsControl(e.KeyChar) And Not Char.IsLetter(e.KeyChar) And Not e.KeyChar = "-" And Not Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
        If Trim(txtcus.Text) <> "" Then
            If Asc(e.KeyChar) = Windows.Forms.Keys.Enter Then
                'click btn
                If login.wrkgrp = "Production" Then
                    searchcustomer(offset, "Sales")
                ElseIf login.wrkgrp = "Cashier" Or login.wrkgrp = "Administrator" Or login.wrkgrp = "Manager" Then
                    searchcustomer(offset, "Sales")
                Else
                    searchcustomer(offset, login.wrkgrp)
                End If
            End If
        End If

        If Asc(e.KeyChar) = 39 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtcus_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcus.TextChanged

        If Not txtcus.Text.Equals("") Then
            txttrans.Text = ""
        End If

        ''check if empty or not
        'If Trim(txtcus.Text) <> "" Then
        '    'disable mga object n nsa taas
        '    chkrefund.Enabled = False
        '    btnhour.Enabled = False
        '    txttrans.Enabled = False
        '    datefrom1.Enabled = True
        '    dateto1.Enabled = True
        '    'click btn using keypress enter
        'Else
        '    'enable mga object sa taas
        '    chkrefund.Enabled = True
        '    btnhour.Enabled = True
        '    txttrans.Enabled = True

        '    loadtransnumsearch()
        'End If
    End Sub

    Public Sub totalRows()
        Dim change As String = ""
        Dim sample As String = query
        change = sample.Replace("*", "COUNT(*)")
        'MessageBox.Show(change)
    End Sub

    Public Sub searchcustomer(ByVal val As Integer, ByVal workgroup As String)
        Try
            Me.Cursor = Cursors.WaitCursor
            grd.Rows.Clear()
            query = "Select * from tbltransaction LEFT OUTER JOIN tblsenior ON tbltransaction.transnum=tblsenior.transnum where (tbltransaction.customer like '%" & Trim(txtcus.Text) & "%' or tblsenior.name like '%" & Trim(txtcus.Text) & "%') and tbltransaction.refund='0'"
            If cmbcash.SelectedItem = "All" Then
                If hfrom.SelectedItem <> "" And hfrom.SelectedItem <> "" And txttrans.Text <> "" And txtcus.Text <> "" Then
                    Dim dfrom As DateTime = CDate(Format(datefrom1.Value, "MM/dd/yyyy") & " " & hfrom.SelectedItem)
                    Dim dto As DateTime = CDate(Format(dateto1.Value, "MM/dd/yyyy") & " " & hto.SelectedItem)
                    query = query & " and tbltransaction.datecreated>='" & dfrom & "' and tbltransaction.datecreated<='" & dto & "'"
                ElseIf hfrom.Text = "" And hfrom.Text = "" Then
                    Dim dfrom As DateTime = CDate(Format(datefrom1.Value, "MM/dd/yyyy"))
                    Dim dto As DateTime = CDate(Format(dateto1.Value, "MM/dd/yyyy"))
                    query = query & " and tbltransaction.transdate>='" & dfrom & "' and tbltransaction.transdate<='" & dto & "'"
                ElseIf Not txttrans.Text.Equals("") Then
                    Dim dfrom As DateTime = CDate(Format(datefrom1.Value, "MM/dd/yyyy") & " " & hfrom.SelectedItem)
                    Dim dto As DateTime = CDate(Format(dateto1.Value, "MM/dd/yyyy") & " " & hto.SelectedItem)
                    query = query & " and tbltransaction.datecreated>='" & dfrom & "' and tbltransaction.datecreated<='" & dto & "' and tbltransaction.transnum='" + txttrans.Text + "'"
                ElseIf txtcus.Text.Equals("CASH") Or txtcus.Text.Equals("cash") Then
                    Dim dfrom As DateTime = CDate(Format(datefrom1.Value, "MM/dd/yyyy") & " " & hfrom.SelectedItem)
                    Dim dto As DateTime = CDate(Format(dateto1.Value, "MM/dd/yyyy") & " " & hto.SelectedItem)
                    query = query & " and tbltransaction.datecreated>='" & dfrom & "' and tbltransaction.datecreated<='" & dto & "' and tbltransaction.customer='" + txtcus.Text + "'"
                ElseIf Not txtcus.Text.Equals("") Then
                    Dim dfrom As DateTime = CDate(Format(datefrom1.Value, "MM/dd/yyyy") & " " & hfrom.SelectedItem)
                    Dim dto As DateTime = CDate(Format(dateto1.Value, "MM/dd/yyyy") & " " & hto.SelectedItem)
                    query = query & " and tbltransaction.datecreated>='" & dfrom & "' and tbltransaction.datecreated<='" & dto & "' and tblsenior.name='" + txtcus.Text + "'"
                Else
                    'cashier with date only without time
                    Dim dfrom As DateTime = CDate(Format(datefrom1.Value, "MM/dd/yyyy") & " " & hfrom.Text)
                    Dim dto As DateTime = CDate(Format(dateto1.Value, "MM/dd/yyyy") & " " & hto.Text)
                    query = query & " and tbltransaction.datecreated BETWEEN '" & dfrom & "' AND '" & dto & "'"
                    'query & " and tbltransaction.datecreated='" & dfrom & "' tbltransaction.datecreated='" & dto & "'
                End If
            Else
                If hfrom.SelectedItem <> "" And hfrom.SelectedItem <> "" Then
                    Dim dfrom As DateTime = CDate(Format(datefrom1.Value, "MM/dd/yyyy") & " " & hfrom.SelectedItem)
                    Dim dto As DateTime = CDate(Format(dateto1.Value, "MM/dd/yyyy") & " " & hto.SelectedItem)
                    'MsgBox(dfrom & " - " & dto)
                    query = query & " and tbltransaction.cashier='" & cmbcash.SelectedItem & "' and tbltransaction.datecreated>='" & dfrom & "' and tbltransaction.datecreated<='" & dto & "'"
                Else
                    'with cashier with date only without time
                    query = query & " and tbltransaction.cashier='" & cmbcash.SelectedItem & "' and tbltransaction.transdate>='" & Format(datefrom1.Value, "MM/dd/yyyy") & "' and  tbltransaction.transdate<='" & Format(dateto1.Value, "MM/dd/yyyy") & "'"
                End If
            End If
            If workgroup <> "" Then
                query &= " AND Not area='Production'"
            End If
            query = query & " ORDER BY 1 OFFSET " & offset & " ROWS FETCH NEXT 30 ROWS ONLY;"
            Dim s As String = query
            s = s.Replace("*", "COUNT(*)")
            connect()
            Dim cc As SqlCommand = New SqlCommand(s, conn)
            rows = Convert.ToInt64(cc.ExecuteScalar()) - 1
            pageTotal = Math.Ceiling(rows / 30) * 1
            disconnect()
            connect()
            Dim cmd1 As SqlCommand = New SqlCommand(query, conn)
            Dim dr1 As SqlDataReader = cmd1.ExecuteReader
            While dr1.Read
                Dim partialamt As Double = 0.0
                If IsDBNull(dr1("partialamt")) Then
                    partialamt = 0
                Else
                    partialamt = dr1("partialamt")
                End If

                grd.Rows.Add(dr1("transid"), dr1("transnum"), dr1("amtdue"), partialamt.ToString("n2"), dr1("servicetype"), "", dr1("tendertype"))
                grd.Columns(4).Visible = False
            End While
            dr1.Dispose()
            cmd1.Dispose()

            Me.Cursor = Cursors.Default
            If grd.Rows.Count <> 0 Then
                selecttrans()
                btnhour.Enabled = False

                newGenerations("Cash", lblcash)
                newGenerations("Cash", lblcashsales)
                newGenerations("A.R Sales", lblarpayment)
                newGenerations("A.R Cash", lblarcash)
                newGenerations("A.R Charge", lblarcharge)
                newGenerations("Deposit", lbldeposit)
                newGenerations("Cash Out", lblcashout)
                newGenerations("Advance Payment Cash", lbladvancepaymentcash)
                newGenerations("Advance Payment", lbladvancepayment)
                'delXGC("delcharge", lblcashout)
                'totalsales
            Else
                MsgBox("No Record Found.", MsgBoxStyle.Critical, "")
                txtcus.Text = ""
                'btnok.PerformClick()
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

    Private Sub cmbcash_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcash.SelectedIndexChanged
        If cmbcash.Text <> "All" Then
            getID()
            connect()

            Dim amtcashout As Double = 0.0
            cmd = New SqlCommand("SELECT ISNULL(SUM(tblcredits.amount),0) FROM tblcredits JOIN tblusers ON tblcredits.systemid=tblusers.systemid WHERE tblusers.username=@username AND tblcredits.invnum=@invnum;", conn)
            cmd.Parameters.AddWithValue("username", cmbcash.Text)
            cmd.Parameters.AddWithValue("@invnum", inv_id)
            amtcashout = cmd.ExecuteScalar()

            lblluckymoney.Text = amtcashout.ToString("n2")

            Dim drawerout As Double = 0.0
            cmd = New SqlCommand("SELECT ISNULL(SUM(tblcredits.cashout),0) FROM tblcredits JOIN tblusers ON tblcredits.systemid=tblusers.systemid WHERE tblusers.username=@username2 AND tblcredits.invnum=@invnum2;", conn)
            cmd.Parameters.AddWithValue("username2", cmbcash.Text)
            cmd.Parameters.AddWithValue("@invnum2", inv_id)
            drawerout = cmd.ExecuteScalar()

            lbldrawerout.Text = drawerout.ToString("n2")
        Else
            getID()
            connect()
            Dim amtcashout As Double = 0.0
            cmd = New SqlCommand("SELECT ISNULL(SUM(tblcredits.amount),0) FROM tblcredits JOIN tblusers ON tblcredits.systemid=tblusers.systemid WHERE tblcredits.invnum=@invnum;", conn)
            cmd.Parameters.AddWithValue("@invnum", inv_id)
            amtcashout = cmd.ExecuteScalar()

            lblluckymoney.Text = amtcashout.ToString("n2")

            Dim drawerout As Double = 0.0
            cmd = New SqlCommand("SELECT ISNULL(SUM(tblcredits.cashout),0) FROM tblcredits JOIN tblusers ON tblcredits.systemid=tblusers.systemid WHERE tblcredits.invnum=@invnum2;", conn)
            cmd.Parameters.AddWithValue("@invnum2", inv_id)
            drawerout = cmd.ExecuteScalar()
            lbldrawerout.Text = drawerout.ToString("n2")
        End If
        newGenerations("Cash", lblcash)
        newGenerations("Cash", lblcashsales)
        newGenerations("A.R Sales", lblarpayment)
        newGenerations("A.R Cash", lblarcash)
        newGenerations("A.R Charge", lblarcharge)
        newGenerations("Deposit", lbldeposit)
        newGenerations("Cash Out", lblcashout)
        newGenerations("Advance Payment Cash", lbladvancepaymentcash)
        newGenerations("Advance Payment", lbladvancepayment)
    End Sub

    Public Sub searchEngine()
        Me.Cursor = Cursors.WaitCursor

        cmbcash.Items.Clear()
        grd.Rows.Clear()
        dateto1.MinDate = datefrom1.Value
        loadcashier()
        'btnok.PerformClick()
        If hto.SelectedIndex < hfrom.SelectedIndex Then
            MsgBox("Invalid Time.", MsgBoxStyle.Exclamation, "")
            hto.SelectedIndex = 0
            Return
        End If
        If cmbcash.Items.Count <> 0 Then
            cmbcash.SelectedItem = "All"
            If login.wrkgrp = "Production" Then
                searchcustomer(offset, "Sales")
            ElseIf login.wrkgrp = "Cashier" Or login.wrkgrp = "Administrator" Or login.wrkgrp = "Manager" Then
                searchcustomer(offset, "Sales")
            Else
                searchcustomer(offset, login.wrkgrp)
            End If

        Else
            Me.Cursor = Cursors.Default
            MsgBox("No Record Found.", MsgBoxStyle.Critical, "")
            Exit Sub
        End If


        If hto.SelectedIndex < hfrom.SelectedIndex And hto.SelectedIndex <> 0 Then
            'check if ung date is nde magkaparehas pra pde
            If Format(datefrom1.Value, "MM/dd/yyyy") <> Format(dateto1.Value, "MM/dd/yyyy") Then
                If Trim(txtcus.Text) <> "" Then
                    If login.wrkgrp = "Production" Then
                        searchcustomer(offset, "Sales")
                    ElseIf login.wrkgrp = "Cashier" Or login.wrkgrp = "Administrator" Or login.wrkgrp = "Manager" Then
                        searchcustomer(offset, "Sales")
                    Else
                        searchcustomer(offset, login.wrkgrp)
                    End If
                    Exit Sub
                End If
            End If
        ElseIf hto.SelectedIndex = 0 Then
            hfrom.SelectedIndex = 0
        Else
            If Trim(txtcus.Text) <> "" Then
                If login.wrkgrp = "Production" Then
                    searchcustomer(offset, "Sales")
                ElseIf login.wrkgrp = "Cashier" Or login.wrkgrp = "Administrator" Or login.wrkgrp = "Manager" Then
                    searchcustomer(offset, "Sales")
                Else
                    searchcustomer(offset, login.wrkgrp)
                End If
                Exit Sub
            End If
            'btnok.PerformClick()
        End If

        Me.Cursor = Cursors.Default
        'btnok.PerformClick()
    End Sub

    Private Sub ButtonSSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSSearch.Click
        offset = 0
        pageNumber = 1
        rows = 0
        pageTotal = 1
        searchEngine()
        TextBoxPageNumber.Text = pageNumber
        LabelTotalPage.Text = "Total Page: " & pageTotal - 1
        pageTotal2 = LabelTotalPage.Text.Replace("Total Page: ", "")
        If pageTotal2 = "0" Or pageTotal2 = "-1" Then
            TextBoxPageNumber.Text = 1
            pageNumber = 1
            LabelTotalPage.Text = "Total Page: " & 1
        End If

    End Sub

    Private Sub TextBoxPageNumber_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub

    Private Sub ButtonGOTOLastPage_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGOTOLastPage.Click
        Dim pTotal As String = LabelTotalPage.Text.Replace("Total Page: ", "")
        If pTotal.Equals("0") Or pTotal.Equals("1") Then
            Return
        Else
            offset = pTotal * 30
            If login.wrkgrp = "Production" Then
                searchcustomer(offset, "Sales")
            ElseIf login.wrkgrp = "Cashier" Or login.wrkgrp = "Administrator" Or login.wrkgrp = "Manager" Then
                searchcustomer(offset, "Sales")
            Else
                searchcustomer(offset, login.wrkgrp)
            End If
            pageNumber = Convert.ToInt32(pTotal)
            TextBoxPageNumber.Text = pageNumber
        End If
    End Sub

    Private Sub ButtonGOTOFirstPage_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGOTOFirstPage.Click
        Dim pTotal As String = LabelTotalPage.Text.Replace("Total Page: ", "")
        If pageNumber = 1 Or pTotal.Equals("0") Or pTotal.Equals("1") Then
            Return
        Else
            offset = 0
            If login.wrkgrp = "Production" Then
                searchcustomer(offset, "Sales")
            ElseIf login.wrkgrp = "Cashier" Or login.wrkgrp = "Administrator" Or login.wrkgrp = "Manager" Then
                searchcustomer(offset, "Sales")
            Else
                searchcustomer(offset, login.wrkgrp)
            End If
            pageNumber = 1
            TextBoxPageNumber.Text = pageNumber
        End If
    End Sub

    Private Sub ButtonNext_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNext.Click
        Dim pTotal As String = LabelTotalPage.Text.Replace("Total Page: ", "")
        If pageNumber.ToString() = pTotal Or pTotal.Equals("0") Or pTotal.Equals("-1") Or pTotal.Equals("1") Then
            Return
        Else
            offset = offset + 30
            If login.wrkgrp = "Production" Then
                searchcustomer(offset, "Sales")
            ElseIf login.wrkgrp = "Cashier" Or login.wrkgrp = "Administrator" Or login.wrkgrp = "Manager" Then
                searchcustomer(offset, "Sales")
            Else
                searchcustomer(offset, login.wrkgrp)
            End If
            pageNumber = pageNumber + 1
            TextBoxPageNumber.Text = pageNumber
        End If
    End Sub

    Private Sub ButtonPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPrevious.Click
        Dim pTotal As String = LabelTotalPage.Text.Replace("Total Page: ", "")
        If offset > 0 And Not pTotal.Equals("1") Then
            offset = offset - 30
            If login.wrkgrp = "Production" Then
                searchcustomer(offset, "Sales")
            ElseIf login.wrkgrp = "Cashier" Or login.wrkgrp = "Administrator" Or login.wrkgrp = "Manager" Then
                searchcustomer(offset, "Sales")
            Else
                searchcustomer(offset, login.wrkgrp)
            End If
            pageNumber = pageNumber - 1
            TextBoxPageNumber.Text = pageNumber
        Else
            pageNumber = 1
            TextBoxPageNumber.Text = pageNumber
            Return
        End If
    End Sub

    Private Sub ButtonPageSave_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPageSave.Click
        Try
            Dim CpageTotal2 As Integer = Convert.ToInt32(pageTotal2)

            If TextBoxPageNumber.Text.Equals("") Then
                MessageBox.Show("Please input page number", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf ButtonPageSave.Text.Equals("edit") Then
                TextBoxPageNumber.BackColor = Color.White
                ButtonPageSave.Text = "ok"
                TextBoxPageNumber.ReadOnly = False
            ElseIf CpageTotal2.Equals(0) Then

                If TextBoxPageNumber.Text = "1" Then
                    TextBoxPageNumber.BackColor = Color.FromArgb(214, 214, 194)
                    ButtonPageSave.Text = "edit"
                    TextBoxPageNumber.ReadOnly = True
                Else
                    MessageBox.Show("The total page(s) only 1", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            ElseIf Convert.ToInt32(TextBoxPageNumber.Text) > CpageTotal2 Then
                MessageBox.Show("The total page(s) only " & CpageTotal2, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf TextBoxPageNumber.Text = "0" Then
                MessageBox.Show("Invalid Input", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf TextBoxPageNumber.Text <> "0" Then
                TextBoxPageNumber.BackColor = Color.FromArgb(214, 214, 194)
                ButtonPageSave.Text = "update"
                TextBoxPageNumber.ReadOnly = True

                Dim pNumber As Integer = Convert.ToInt32(TextBoxPageNumber.Text)
                offset = 30 * pNumber
                If login.wrkgrp = "Production" Then
                    searchcustomer(offset, "Sales")
                ElseIf login.wrkgrp = "Cashier" Or login.wrkgrp = "Administrator" Or login.wrkgrp = "Manager" Then
                    searchcustomer(offset, "Sales")
                Else
                    searchcustomer(offset, login.wrkgrp)
                End If
                pageNumber = pNumber
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub btnexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexport.Click
        Try
            SaveFileDialog1.Title = "Save as Excel File"
            SaveFileDialog1.Filter = "Excel Document (*.xlsx) | *.xlsx"
            If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                btnexport.Text = "Please Wait..."
                btnexport.Enabled = False
                Me.Cursor = Cursors.WaitCursor
                Dim objExcel As New Excel.Application
                Dim bkWorkBook As Excel.Workbook
                Dim shWorkSheet As Excel.Worksheet
                Dim shWorkSheet1 As Excel.Worksheet
                Dim misValue As Object = System.Reflection.Missing.Value

                objExcel = New Excel.Application
                bkWorkBook = objExcel.Workbooks.Add
                shWorkSheet = CType(bkWorkBook.ActiveSheet, Excel.Worksheet)

                Dim dt As New DataTable()
                dt.Columns.Add("DocNum")
                dt.Columns.Add("DocType")
                dt.Columns.Add("DocDate")
                dt.Columns.Add("DocDueDate")
                dt.Columns.Add("CardCode")
                dt.Columns.Add("CardName")
                dt.Columns.Add("Comments")

                connect()
                For index As Integer = 0 To grd.Rows.Count - 1
                    cmd = New SqlCommand("SELECT datecreated,tendertype,customer,transnum FROM tbltransaction WHERE transnum=@tr", conn)
                    cmd.Parameters.AddWithValue("@tr", grd.Rows(index).Cells("trnum").Value)
                    dr = cmd.ExecuteReader
                    While dr.Read
                        dt.Rows.Add(grd.Rows(index).Cells("id").Value, "dbDocument_Items", CDate(dr("datecreated")).ToString("yyyyMMdd"), CDate(dr("datecreated")).ToString("yyyyMMdd"), dr("tendertype"), dr("customer"), dr("transnum"))
                    End While
                Next

                For i As Integer = 0 To dt.Columns.Count - 1
                    shWorkSheet.Cells(1, i + 1) = dt.Columns(i).ToString
                Next
                For i As Integer = 0 To dt.Rows.Count - 1
                    For j = 0 To dt.Columns.Count - 1
                        shWorkSheet.Cells(i + 2, j + 1) = dt.Rows(i)(j).ToString
                    Next
                Next

                With shWorkSheet
                    .Range("A1", misValue).EntireRow.Font.Bold = True
                    .Range("A1:G1").EntireRow.WrapText = True

                    .Range("A1:G1").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DodgerBlue)
                    .Range("A1:G1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)

                    .Range("A1:G" & dt.Rows.Count + 1).HorizontalAlignment = -4108
                    .Range("A1:G" & dt.Rows.Count + 1).VerticalAlignment = -4108
                    .Range("A1:G1").Font.Size = 12


                    .Range("A2:A" & dt.Rows.Count + 1).RowHeight = 40
                    .Range("A2:B" & dt.Rows.Count + 1).RowHeight = 40
                    .Range("A2:C" & dt.Rows.Count + 1).RowHeight = 40
                    .Range("A2:D" & dt.Rows.Count + 1).RowHeight = 40
                    .Range("A2:E" & dt.Rows.Count + 1).RowHeight = 40
                    .Range("A2:F" & dt.Rows.Count + 1).RowHeight = 40
                    .Range("A2:G" & dt.Rows.Count + 1).RowHeight = 40

                    .Range("A2:A" & dt.Rows.Count + 1).ColumnWidth = 10
                    .Range("A2:B" & dt.Rows.Count + 1).ColumnWidth = 20
                    .Range("A2:C" & dt.Rows.Count + 1).ColumnWidth = 20
                    .Range("A2:D" & dt.Rows.Count + 1).ColumnWidth = 20
                    .Range("A2:E" & dt.Rows.Count + 1).ColumnWidth = 15
                    .Range("A2:F" & dt.Rows.Count + 1).ColumnWidth = 20
                    .Range("A2:G" & dt.Rows.Count + 1).ColumnWidth = 22

                End With

                shWorkSheet = bkWorkBook.Sheets(1)
                shWorkSheet.Name = "OINV"


                Dim dt1 As New DataTable()
                dt1.Columns.Add("DocNum")
                dt1.Columns.Add("ItemCode")
                dt1.Columns.Add("ItemDescription")
                dt1.Columns.Add("Quantity")
                dt1.Columns.Add("Price")
                dt1.Columns.Add("WarehouseCode")
                dt1.Columns.Add("AccountCode")


                For index As Integer = 0 To grd.Rows.Count - 1
                    cmd = New SqlCommand("SELECT itemname,qty,price FROM tblorder WHERE transnum=@tr2", conn)
                    cmd.Parameters.AddWithValue("@tr2", grd.Rows(index).Cells("trnum").Value)
                    adptr.SelectCommand = cmd
                    Dim da As New DataTable()
                    adptr.Fill(da)
                    For Each r0w As DataRow In da.Rows
                        cmd = New SqlCommand("SELECT itemcode FROM tblitems WHERE itemname=@itemname;", conn)
                        cmd.Parameters.AddWithValue("@itemname", r0w("itemname"))
                        dr = cmd.ExecuteReader
                        If dr.Read Then
                            dt1.Rows.Add(grd.Rows(index).Cells("id").Value, dr("itemcode"), r0w("itemname"), r0w("qty"), r0w("price"), "", "")
                        End If
                    Next
                Next


                shWorkSheet1 = bkWorkBook.Worksheets.Add(, shWorkSheet, , )
                For i As Integer = 0 To dt1.Columns.Count - 1
                    shWorkSheet1.Cells(1, i + 1) = dt1.Columns(i).ToString
                Next
                For i As Integer = 0 To dt1.Rows.Count - 1
                    For j = 0 To dt1.Columns.Count - 1
                        shWorkSheet1.Cells(i + 2, j + 1) = dt1.Rows(i)(j).ToString
                    Next
                Next

                With shWorkSheet1
                    .Range("A1", misValue).EntireRow.Font.Bold = True
                    .Range("A1:G1").EntireRow.WrapText = True

                    .Range("A1:G1").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Orange)
                    .Range("A1:G1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)

                    .Range("A1:G" & dt1.Rows.Count + 1).HorizontalAlignment = -4108
                    .Range("A1:G" & dt1.Rows.Count + 1).VerticalAlignment = -4108
                    .Range("A1:G1").Font.Size = 12


                    .Range("A2:A" & dt1.Rows.Count + 1).RowHeight = 40
                    .Range("A2:B" & dt1.Rows.Count + 1).RowHeight = 40
                    .Range("A2:C" & dt1.Rows.Count + 1).RowHeight = 40
                    .Range("A2:D" & dt1.Rows.Count + 1).RowHeight = 40
                    .Range("A2:E" & dt1.Rows.Count + 1).RowHeight = 40
                    .Range("A2:F" & dt1.Rows.Count + 1).RowHeight = 40
                    .Range("A2:G" & dt1.Rows.Count + 1).RowHeight = 40

                    .Range("A2:A" & dt1.Rows.Count + 1).ColumnWidth = 10
                    .Range("A2:B" & dt1.Rows.Count + 1).ColumnWidth = 20
                    .Range("A2:C" & dt1.Rows.Count + 1).ColumnWidth = 30
                    .Range("A2:D" & dt1.Rows.Count + 1).ColumnWidth = 20
                    .Range("A2:E" & dt1.Rows.Count + 1).ColumnWidth = 15
                    .Range("A2:F" & dt1.Rows.Count + 1).ColumnWidth = 15
                    .Range("A2:G" & dt1.Rows.Count + 1).ColumnWidth = 20

                End With

                shWorkSheet1 = bkWorkBook.Sheets(2)
                shWorkSheet1.Name = "INV1"

                objExcel.Visible = False
                objExcel.Application.DisplayAlerts = False

                objExcel.ActiveWorkbook.SaveAs(SaveFileDialog1.FileName.ToString())
                objExcel.Quit()

                objExcel = Nothing
                btnexport.Text = "Export"
                btnexport.Enabled = True
                Me.Cursor = Cursors.Default
                MessageBox.Show("Saved", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            btnexport.Text = "Export"
            btnexport.Enabled = True
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString)
        End Try

        Dim proc As System.Diagnostics.Process
        For Each proc In System.Diagnostics.Process.GetProcessesByName("EXCEL")
            proc.Kill()
        Next
    End Sub
End Class