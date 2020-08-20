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
Imports AK_POS.connection_class
Public Class fake_transaction
    Dim cc As New connection_class
    Dim strconn As String = cc.conString
    Dim con As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim adptr As New SqlDataAdapter

    Dim offset As Integer = 0, pageNumber As Integer = 0

    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function
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
    Private Sub fake_transaction_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        datefrom1.Value = getSystemDate()
        dateto1.Value = getSystemDate()
        'cmbcash.Items.Clear()
        'cmbcash.Items.Add(login.username)
        'cmbcash.SelectedIndex = 0
        loadTrans()
        Me.WindowState = FormWindowState.Maximized
        ButtonSSearch.PerformClick()
    End Sub

    Public Sub loadCashiers()
        Try
            cmbcash.Items.Clear()
            If login.wrkgrp <> "Cashier" Then
                cmbcash.Items.Add("All")
                'cmbcash.Items.Add(login.username)
                con.Open()
                cmd = New SqlCommand("SELECT username FROM tblusers WHERE workgroup='Cashier' AND status=1;", con)
                rdr = cmd.ExecuteReader
                While rdr.Read
                    cmbcash.Items.Add(rdr("username"))
                End While
                con.Close()
            ElseIf login.wrkgrp = "Cashier" Then
                cmbcash.Items.Add(login.username)
            End If
            cmbcash.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Sub checkCancelled(ByVal tendertype As String)
        Dim aa As Double = 0.00
        For index As Integer = 0 To grd.Rows.Count - 1
            If grd.Rows(index).Cells("tendertype").Value = tendertype Then
                Dim a As String = ""
                con.Open()
                cmd = New SqlCommand("select tbltransaction.transnum from tbladvancepayment JOIN tbltransaction ON tbladvancepayment.date= tbltransaction.datecreated WHERE tbltransaction.tendertype='" & tendertype & "' AND tbladvancepayment.status='Cancelled';", con)
                rdr = cmd.ExecuteReader
                While rdr.Read
                    a = rdr("transnum")
                    If a = grd.Rows(index).Cells("trnum").Value Then
                        grd.Rows(index).DefaultCellStyle.BackColor = Color.Firebrick
                        grd.Rows(index).DefaultCellStyle.ForeColor = Color.White
                        aa += CDbl(grd.Rows(index).Cells("amtdue").Value)
                    End If
                End While
                con.Close()
            End If
        Next
    End Sub
    Public Sub loadTrans()
        Try
            grd.Rows.Clear()
            Dim query As String = "SELECT tbltransaction.transid,tbltransaction.transnum,tbltransaction.amtdue,tbltransaction.partialamt,tbltransaction.servicetype,tbltransaction.refund,tbltransaction.tendertype,ISNULL(tbltransaction.typez,'') AS typez FROM tbltransaction WHERE CAST(tbltransaction.datecreated as date)>='" & datefrom1.Text & "' AND CAST(tbltransaction.datecreated as date)<='" & datefrom1.Text & "' AND tbltransaction.area !='Production'"
            If txtcus.Text <> "" Then
                query &= " AND tbltransaction.customer='" & txtcus.Text & "'"
            ElseIf cmbcash.SelectedItem = "All" Then
                query = query
            ElseIf cmbcash.SelectedItem <> "All" And hfrom.Text = "" And hto.Text = "" And txttrans.Text = "" And txtcus.Text = "" Then
                query &= " AND tbltransaction.cashier='" & cmbcash.Text & "'"
            ElseIf cmbcash.SelectedItem <> "All" And hfrom.Text <> "" And hto.Text <> "" And txttrans.Text = "" And txtcus.Text = "" Then
                query &= " AND CAST(tbltransaction.datecreated as time)>='" & hfrom.Text & "' AND CAST (tbltransaction.datecreated as time)<='" & hto.Text & "' AND tbltransaction.cashier='" & cmbcash.Text & "'"
            ElseIf cmbcash.SelectedItem <> "All" And hfrom.Text = "" And hto.Text = "" And txttrans.Text <> "" Then
                query &= " AND tbltransaction.transnum='" & txttrans.Text & "' AND tbltransaction.cashier='" & cmbcash.Text & "'"
            ElseIf cmbcash.SelectedItem <> "All" And hfrom.Text <> "" And hto.Text <> "" And txttrans.Text <> "" Then
                query &= " AND CAST(tbltransaction.datecreated as time)>='" & hfrom.Text & "' AND CAST (tbltransaction.datecreated as time)<='" & hto.Text & "' AND tbltransaction.transnum='" & txttrans.Text & "' AND tbltransaction.cashier='" & cmbcash.Text & "'"
            ElseIf cmbcash.SelectedItem <> "All" And hfrom.Text <> "" And hto.Text <> "" And txtcus.Text <> "" Then
                query &= " AND CAST(tbltransaction.datecreated as time)>='" & hfrom.Text & "' AND CAST (tbltransaction.datecreated as time)<='" & hto.Text & "' AND tbltransaction.customer='" & txtcus.Text & "' AND tbltransaction.cashier='" & cmbcash.Text & "'"
            ElseIf cmbcash.SelectedItem <> "All" And hfrom.Text <> "" And hto.Text <> "" Then
                'txtcus.Text = ""
                'txttrans.Text = ""
                query &= " AND CAST(tbltransaction.datecreated as time)>='" & hfrom.Text & "' AND CAST (tbltransaction.datecreated as time)<='" & hto.Text & "' AND AND tbltransaction.cashier='" & cmbcash.Text & "'"
            ElseIf cmbcash.SelectedItem <> "All" And hfrom.Text = "" And hto.Text = "" Then
                'txtcus.Text = ""
                'txttrans.Text = ""
                query &= " AND tbltransaction.cashier='" & cmbcash.Text & "'"

            End If

            If chkrefund.Checked Then
                query &= " AND tbltransaction.status =0"
            Else
                query &= " AND tbltransaction.status=1"
            End If

            If cmbtype.SelectedIndex <> 0 And cmbsales.SelectedIndex = 0 Then
                query &= " AND tbltransaction.typez='" & cmbtype.Text & "'"
            ElseIf cmbtype.SelectedIndex = 0 And cmbsales.SelectedIndex <> 0 Then
                query &= " AND tbltransaction.salesname='" & cmbsales.Text & "'"
            ElseIf cmbtype.SelectedIndex <> 0 And cmbsales.SelectedIndex <> 0 Then
                query &= " AND tbltransaction.salesname='" & cmbsales.Text & "' AND tbltransaction.typez='" & cmbtype.Text & "'"
            End If

            query &= " AND tbltransaction.customer !='Short' ORDER BY 1 OFFSET " & offset & " ROWS FETCH Next 30 ROWS ONLY"
            TextBox2.Text = query
            Dim s As String = query
            con.Open()
            cmd = New SqlCommand(query, con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                Dim re As Boolean = False, par As Double = 0.0
                If rdr("refund") = 0 Then
                    re = False
                Else
                    re = True
                End If
                If IsDBNull(rdr("partialamt")) Then
                    par = 0
                Else
                    par = CDbl(rdr("partialamt"))
                End If
                grd.Rows.Add(rdr("transid"), rdr("transnum"), rdr("amtdue"), par, rdr("tendertype"), rdr("servicetype"), re, rdr("typez"))
            End While
            con.Close()

            s = s.Replace("transid, transnum, amtdue, partialamt, servicetype, refund, tendertype, ISNULL(typez,'')", "COUNT(*)")
            con.Open()
            cmd = New SqlCommand(s, con)
            pageNumber = cmd.ExecuteScalar()
            con.Close()
            pageNumber = Math.Ceiling(pageNumber / 30) * 1
            lblcount.Text = "TRANSACTIONS: (" & pageNumber & ")"
            TextBoxPageNumber.Text = pageNumber

            If grd.RowCount = 0 Then
                lblerr.Visible = True
            Else
                lblerr.Visible = False
            End If

            cash("A.R Sales", lblarpayment)
            cash("A.R Cash", lblarcash)
            cash("A.R Charge", lblarcharge)
            apcash("Deposit", lbldeposit)
            cash("Cash Out", lblcashout)
            apcash("Advance Payment Cash", lbladvancepaymentcash)
            cash("Advance Payment", lbladvancepayment)
            gross_sales()
            discounts()
            netcashsales()
            netsales()
            gc_total()
            net_cash_from_sales()
            net_cash_sales()
            cash_from_sales()
            Dim hihi As String = getSystemDate.ToString("MM/dd/yyyy")
            Dim amt As Double = 0.00
            con.Open()
            cmd = New SqlCommand("SELECT ISNULL(SUM(amount),0) FROM tbladvancepayment WHERE status='Cancelled' AND CAST(date_cancelled AS date)='" & hihi & "' AND type='Advance Payment';", con)
            amt = cmd.ExecuteScalar()
            con.Close()

            lbladvancepaymentcash.Text = (CDbl(lbladvancepaymentcash.Text) - amt).ToString("n2")
            lblcashonhand.Text = (CDbl(lblcash.Text) + CDbl(lbldeposit.Text) + CDbl(lbladvancepaymentcash.Text) + CDbl(lblarcash.Text)).ToString("n2")
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Sub gross_sales()
        Try

            Dim subtotal As Double = 0.00
            Dim query As String = "SELECT ISNULL(SUM(subtotal),0) FROM tbltransaction WHERE CAST(datecreated AS date)=@date AND tendertype='CASH' AND status=1"

            If cmbsales.SelectedIndex <> 0 And cmbtype.SelectedIndex = 0 Then
                query &= " AND salesname='" & cmbsales.SelectedItem & "';"
            ElseIf cmbsales.SelectedIndex = 0 And cmbtype.SelectedIndex <> 0 Then
                query &= " AND typez='" & cmbtype.SelectedItem & "';"
            ElseIf cmbsales.SelectedIndex <> 0 And cmbtype.SelectedIndex <> 0 Then
                query &= " AND typez='" & cmbtype.SelectedItem & "' AND salesname='" & cmbsales.SelectedItem & "';"
            End If

            con.Open()
            cmd = New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@date", datefrom1.Text)
            subtotal = cmd.ExecuteScalar()
            con.Close()

            Dim dscnt As Double = 0.00
            Dim query2 As String = "SELECT ISNULL(SUM((qty*price)*(dscnt/100)),0) FROM tblorder a1 LEFT JOIN tbltransaction a2 ON a1.transnum=a2.transnum WHERE a2.status=1 AND CAST(a2.datecreated AS date)=@date AND a1.dscnt !=0"

            If cmbsales.SelectedIndex <> 0 And cmbtype.SelectedIndex = 0 Then
                query2 &= " AND a2.salesname='" & cmbsales.SelectedItem & "';"
            ElseIf cmbsales.SelectedIndex = 0 And cmbtype.SelectedIndex <> 0 Then
                query2 &= " AND a2.typez='" & cmbtype.SelectedItem & "';"
            ElseIf cmbsales.SelectedIndex <> 0 And cmbtype.SelectedIndex <> 0 Then
                query2 &= " AND a2.typez='" & cmbtype.SelectedItem & "' AND a2.salesname='" & cmbsales.SelectedItem & "';"
            End If

            con.Open()
            cmd = New SqlCommand(query2, con)
            cmd.Parameters.AddWithValue("@date", datefrom1.Text)
            dscnt = cmd.ExecuteScalar()
            con.Close()
            lblgrossales.Text = Math.Round(dscnt + subtotal).ToString("n2")
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub discounts()
        Try
            Dim d1 As Double = 0.00, query As String = "SELECT ISNULL(SUM(discamt),0) from tbltransaction WHERE CAST(datecreated as date)=@date AND status=1"

            If cmbsales.SelectedIndex <> 0 And cmbtype.SelectedIndex = 0 Then
                query &= " AND salesname='" & cmbsales.SelectedItem & "';"
            ElseIf cmbsales.SelectedIndex = 0 And cmbtype.SelectedIndex <> 0 Then
                query &= " AND typez='" & cmbtype.SelectedItem & "';"
            ElseIf cmbsales.SelectedIndex <> 0 And cmbtype.SelectedIndex <> 0 Then
                query &= " AND typez='" & cmbtype.SelectedItem & "' AND salesname='" & cmbsales.SelectedItem & "';"
            End If

            con.Open()
            cmd = New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@date", datefrom1.Text)
            d1 = cmd.ExecuteScalar()
            con.Close()

            Dim d2 As Double = 0.00, query2 As String = "Select ISNULL(sum((qty*price)*(dscnt/100)),0)[discount_amount] FROM tblorder a1 LEFT JOIN tbltransaction a2 ON a1.transnum=a2.transnum WHERE a2.status=1 AND  CAST(a2.datecreated AS date)=@date AND a1.dscnt !=0"


            If cmbsales.SelectedIndex <> 0 And cmbtype.SelectedIndex = 0 Then
                query2 &= " AND a2.salesname='" & cmbsales.SelectedItem & "';"
            ElseIf cmbsales.SelectedIndex = 0 And cmbtype.SelectedIndex <> 0 Then
                query2 &= " AND a2.typez='" & cmbtype.SelectedItem & "';"
            ElseIf cmbsales.SelectedIndex <> 0 And cmbtype.SelectedIndex <> 0 Then
                query2 &= " AND a2.typez='" & cmbtype.SelectedItem & "' AND a2.salesname='" & cmbsales.SelectedItem & "';"
            End If

            con.Open()
            cmd = New SqlCommand(query2, con)
            cmd.Parameters.AddWithValue("@date", datefrom1.Text)
            d2 = cmd.ExecuteScalar()
            con.Close()

            lbldiscounts.Text = (d1 + d2).ToString("n2")
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Sub netcashsales()
        Try
            Dim ap_used As Double = 0.00, query As String = "SELECT ISNULL(SUM(amtdue),0) FROM tbltransaction WHERE CAST(datecreated AS date)=@date AND tendertype='Advance Payment' AND status=1"

            If cmbsales.SelectedIndex <> 0 And cmbtype.SelectedIndex = 0 Then
                query &= " AND salesname='" & cmbsales.SelectedItem & "';"
            ElseIf cmbsales.SelectedIndex = 0 And cmbtype.SelectedIndex <> 0 Then
                query &= " AND typez='" & cmbtype.SelectedItem & "';"
            ElseIf cmbsales.SelectedIndex <> 0 And cmbtype.SelectedIndex <> 0 Then
                query &= " AND typez='" & cmbtype.SelectedItem & "' AND salesname='" & cmbsales.SelectedItem & "';"
            End If

            con.Open()
            cmd = New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@date", datefrom1.Text)
            ap_used = cmd.ExecuteScalar
            con.Close()

            Dim gc_total As Double = 0.00, query2 As String = "SELECT ISNULL(SUM(gctotal),0) FROM tbltransaction WHERE CAST(datecreated AS date)=@date AND status=1"

            If cmbsales.SelectedIndex <> 0 And cmbtype.SelectedIndex = 0 Then
                query2 &= " AND salesname='" & cmbsales.SelectedItem & "';"
            ElseIf cmbsales.SelectedIndex = 0 And cmbtype.SelectedIndex <> 0 Then
                query2 &= " AND typez='" & cmbtype.SelectedItem & "';"
            ElseIf cmbsales.SelectedIndex <> 0 And cmbtype.SelectedIndex <> 0 Then
                query2 &= " AND typez='" & cmbtype.SelectedItem & "' AND salesname='" & cmbsales.SelectedItem & "';"
            End If

            con.Open()
            cmd = New SqlCommand(query2, con)
            cmd.Parameters.AddWithValue("@date", datefrom1.Text)
            gc_total = cmd.ExecuteScalar
            con.Close()

            Dim sub_total As Double = 0.00, query3 As String = "SELECT ISNULL(SUM(amtdue),0) FROM tbltransaction WHERE CAST(datecreated AS date)=@date AND tendertype='CASH' AND status=1"

            If cmbsales.SelectedIndex <> 0 And cmbtype.SelectedIndex = 0 Then
                query3 &= " AND salesname='" & cmbsales.SelectedItem & "';"
            ElseIf cmbsales.SelectedIndex = 0 And cmbtype.SelectedIndex <> 0 Then
                query3 &= " AND typez='" & cmbtype.SelectedItem & "';"
            ElseIf cmbsales.SelectedIndex <> 0 And cmbtype.SelectedIndex <> 0 Then
                query3 &= " AND typez='" & cmbtype.SelectedItem & "' AND salesname='" & cmbsales.SelectedItem & "';"
            End If

            con.Open()
            cmd = New SqlCommand(query3, con)
            cmd.Parameters.AddWithValue("@date", datefrom1.Text)
            sub_total = cmd.ExecuteScalar()
            con.Close()

            lblnetcashsales.Text = (sub_total + ap_used + gc_total).ToString("n2")
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub netsales()
        Try
            lblnetsales.Text = (CDbl(lblnetcashsales.Text) + CDbl(lblarpayment.Text) + CDbl(lblarcharge.Text)).ToString("n2")
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Sub cash_from_sales()
        Try
            'Dim sub_total As Double = 0.00
            'con.Open()
            'cmd = New SqlCommand("SELECT ISNULL(SUM(amtdue),0) FROM tbltransaction WHERE CAST(datecreated AS date)=@date AND tendertype='CASH' AND status=1;", con)
            'cmd.Parameters.AddWithValue("@date", datefrom1.Text)
            'sub_total = cmd.ExecuteScalar()
            'con.Close()

            Dim gc_total As Double = 0.00
            con.Open()
            cmd = New SqlCommand("SELECT ISNULL(SUM(gctotal),0) FROM tbltransaction WHERE CAST(datecreated AS date)=@date AND status=1;", con)
            cmd.Parameters.AddWithValue("@date", datefrom1.Text)
            gc_total = cmd.ExecuteScalar()
            con.Close()

            Dim used_ap As Double = 0.00
            con.Open()
            cmd = New SqlCommand("SELECT ISNULL(SUM(amtdue),0) FROM tbltransaction WHERE CAST(datecreated AS date)=@date AND status=1 AND tendertype='Advance Payment';", con)
            cmd.Parameters.AddWithValue("@date", datefrom1.Text)
            used_ap = cmd.ExecuteScalar()
            con.Close()

            Dim cash_out As Double = 0.00
            con.Open()
            cmd = New SqlCommand("SELECT ISNULL(SUM(amtdue),0) FROM tbltransaction WHERE CAST(datecreated AS date)=@date AND status=1 AND tendertype='Cash Out';", con)
            cmd.Parameters.AddWithValue("@date", datefrom1.Text)
            cash_out = cmd.ExecuteScalar()
            con.Close()
            lblcash.Text = (CDbl(lblnetcashsales.Text) - used_ap - cash_out - gc_total).ToString("n2")
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub gc_total()
        Try
            Dim gc_total As Double = 0.00, query As String = "SELECT ISNULL(SUM(gctotal),0) FROM tbltransaction WHERE CAST(datecreated AS date)=@date AND status=1"

            If cmbsales.SelectedIndex <> 0 And cmbtype.SelectedIndex = 0 Then
                query &= " AND salesname='" & cmbsales.SelectedItem & "';"
            ElseIf cmbsales.SelectedIndex = 0 And cmbtype.SelectedIndex <> 0 Then
                query &= " AND typez='" & cmbtype.SelectedItem & "';"
            ElseIf cmbsales.SelectedIndex <> 0 And cmbtype.SelectedIndex <> 0 Then
                query &= " AND typez='" & cmbtype.SelectedItem & "' AND salesname='" & cmbsales.SelectedItem & "';"
            End If

            con.Open()
            cmd = New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@date", datefrom1.Text)
            gc_total = cmd.ExecuteScalar()
            con.Close()

            lblgctotal.Text = gc_total.ToString("n2")
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub cash_out()
        Try
            Dim gc_total As Double = 0.00
            con.Open()
            cmd = New SqlCommand("SELECT ISNULL(SUM(amtdue),0) FROM tbltransaction WHERE CAST(datecreated AS date)=@date AND status=1 AND tendertype='Cash Out';", con)
            cmd.Parameters.AddWithValue("@date", datefrom1.Text)
            gc_total = cmd.ExecuteScalar()
            con.Close()

            lblgctotal.Text = gc_total.ToString("n2")
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub net_cash_from_sales()
        Try
            lblcashfromsales.Text = (CDbl(lblnetcashsales.Text) - CDbl(lblgctotal.Text) - CDbl(lbladvancepayment.Text) - CDbl(lblcashout.Text)).ToString("n2")
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Sub net_cash_sales()
        Try
            lblpaymenttotal.Text = (CDbl(lblgctotal.Text) + CDbl(lblcashout.Text) + CDbl(lblcashfromsales.Text) + CDbl(lbladvancepayment.Text)).ToString("n2")
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Sub apcash(ByVal typee As String, ByVal lbl As Label)
        Try

            Dim totalprice As Double = 0.0
            Dim query As String = "select ISNULL(SUM(tbltransaction.amtdue),0) from tbltransaction WHERE tbltransaction.tendertype='" & typee & "' AND tbltransaction.status='" & IIf(chkrefund.Checked, 0, 1) & "' AND CAST(tbltransaction.datecreated AS date)='" & datefrom1.Text & "'"

            If cmbtype.SelectedIndex <> 0 And cmbcash.SelectedIndex = 0 Then
                query &= " AND tbltransaction.typez='" & cmbtype.Text & "'"
            ElseIf cmbtype.SelectedIndex = 0 And cmbcash.SelectedIndex <> 0 Then
                query &= " AND tbltransaction.salesname='" & cmbsales.Text & "'"
            ElseIf cmbtype.SelectedIndex <> 0 And cmbsales.SelectedIndex <> 0 Then
                query &= " AND tbltransaction.salesname='" & cmbcash.Text & "' AND tbltransaction.typez='" & cmbtype.Text & "'"
            End If
            con.Open()
            cmd = New SqlCommand(query, con)
            totalprice = cmd.ExecuteScalar
            con.Close()
            totalprice = Math.Abs(totalprice)
            lbl.Text = totalprice.ToString("n2")
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Public Sub cash(ByVal typee As String, ByVal lbl As Label)
        Try

            Dim totalprice As Double = 0.0
            Dim query As String = "select ISNULL(SUM(tbltransaction.amtdue + tbltransaction.partialamt),0) from tbltransaction WHERE tbltransaction.tendertype='" & typee & "' AND tbltransaction.status='" & IIf(chkrefund.Checked, 0, 1) & "' AND CAST(tbltransaction.datecreated AS date)='" & datefrom1.Text & "'"

            If cmbtype.SelectedIndex <> 0 And cmbsales.SelectedIndex = 0 Then
                query &= " AND tbltransaction.typez='" & cmbtype.Text & "'"
            ElseIf cmbtype.SelectedIndex = 0 And cmbsales.SelectedIndex <> 0 Then
                query &= " AND tbltransaction.salesname='" & cmbsales.Text & "'"
            ElseIf cmbtype.SelectedIndex <> 0 And cmbsales.SelectedIndex <> 0 Then
                query &= " AND tbltransaction.salesname='" & cmbsales.Text & "' AND tbltransaction.typez='" & cmbtype.Text & "'"
            End If

            If cmbcash.SelectedIndex <> 0 Then
                query &= " AND tbltransaction.cashier='" & cmbcash.Text & "';"
            End If
            con.Open()
            cmd = New SqlCommand(query, con)
            totalprice = cmd.ExecuteScalar
            con.Close()
            totalprice = Math.Abs(totalprice)
            lbl.Text = totalprice.ToString("n2")
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub ButtonSSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSSearch.Click
        loadTrans()
    End Sub
    Private Sub fake_transaction_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadCashiers()
        offset = 0
        loadSales()
        cmbtype.SelectedIndex = 0
    End Sub
    Public Sub loadSales()
        Try
            cmbsales.Items.Clear()
            cmbsales.Items.Add("All")
            con.Open()
            cmd = New SqlCommand("SELECT username FROM tblusers WHERE workgroup='Sales' OR workgroup='Manager' ORDER BY username ASC;", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                cmbsales.Items.Add(rdr("username"))
            End While
            con.Close()
            cmbsales.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub grd_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd.CellClick
        Try

            If grd.Rows.Count <> 0 And (grd.SelectedCells.Count = 1 Or grd.SelectedRows.Count = 1) Then
                grdorders.Rows.Clear()
                btnrefund.Enabled = True
                btnremarks.Enabled = True
                con.Open()
                cmd = New SqlCommand("Select * from tbltransaction where transnum='" & grd.Rows(grd.CurrentRow.Index).Cells("trnum").Value & "' AND tendertype='" & grd.Rows(grd.CurrentRow.Index).Cells("tendertype").Value & "';", con)
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    Me.Cursor = Cursors.WaitCursor
                    lbltransnum.Text = rdr("transnum")
                    lblcashier.Text = rdr("salesname")
                    lbldate.Text = Format(rdr("datecreated"), "HH:mm   MM/dd/yyyy")
                    lblsub.Text = Val(rdr("subtotal")).ToString("n2")
                    lbldel.Text = Val(rdr("delcharge")).ToString("n2")
                    lbldisc.Text = rdr("disctype")
                    lblgcamt.Text = Val(rdr("gctotal")).ToString("n2")
                    lblless.Text = Val(rdr("less")).ToString("n2")
                    lblvatsales.Text = Val(rdr("vatsales")).ToString("n2")
                    lblvatamt.Text = Val(rdr("vat")).ToString("n2")


                    If grd.CurrentRow.Cells("amtdue").Value = 0 Then
                        If IsDBNull(rdr("partialamt")) Then
                            lbltotal.Text = 0
                        Else
                            lbltotal.Text = CDbl(rdr("partialamt")).ToString("n2")
                        End If
                        Label12.Text = "Partial Amount:"
                    ElseIf grd.CurrentRow.Cells("partialamt").Value = 0 Then
                        lbltotal.Text = CDbl(rdr("amtdue")).ToString("n2")
                        Label12.Text = "Total Amt. Due:"
                    End If
                    lblrems.Text = rdr("remarks") & rdr("comment")
                    lblrems.Tag = rdr("remarks")
                End If
                con.Close()
                lbltransnum.Text = grd.CurrentRow.Cells("trnum").Value
                If grd.CurrentRow.Cells("tendertype").Value = "Advance Payment" Or grd.CurrentRow.Cells("tendertype").Value = "Cash Out" Then
                    grdorders.Rows.Clear()
                Else
                    con.Open()
                    cmd = New SqlCommand("SELECT * FROM tblorder JOIN tbltransaction ON tblorder.transnum=tbltransaction.transnum WHERE tblorder.transnum='" & grd.CurrentRow.Cells("trnum").Value & "' AND tbltransaction.tendertype='" & grd.CurrentRow.Cells("tendertype").Value & "'", con)
                    Dim datatable As New DataTable()
                    Dim adptr As New SqlDataAdapter()
                    adptr.SelectCommand = cmd
                    adptr.Fill(datatable)
                    con.Close()
                    For Each r0w As DataRow In datatable.Rows
                        Dim z As Boolean = False, orig_price As Double = 0.00
                        If r0w("free") <> 0 Then
                            z = True
                        Else
                            z = False
                        End If

                        con.Open()
                        cmd = New SqlCommand("SELECT price FROM tblitems WHERE itemname=@itemname", con)
                        cmd.Parameters.AddWithValue("@itemname", r0w("itemname"))
                        rdr = cmd.ExecuteReader
                        If rdr.Read Then
                            orig_price = CDbl(rdr("price"))
                        End If
                        con.Close()

                        'If orig_price <> CDbl(r0w("price")) Then
                        '    grdorders.Columns("price").HeaderText = "Discounted Price"
                        'Else
                        '    grdorders.Columns("price").HeaderText = "Price"
                        'End If

                        Dim dscnt_amt As Double = CDbl(r0w("qty")) * CDbl(r0w("price")) - r0w("totalprice")

                        grdorders.Rows.Add(r0w("itemname"), r0w("qty"), r0w("price"), r0w("dscnt"), dscnt_amt.ToString("n2"), r0w("totalprice"), r0w("request"), z)
                    Next

                    Dim t As String = ""
                    con.Open()
                    cmd = New SqlCommand("select ISNULL(tbltransaction2.ordernum,0) AS s FROM tbltransaction2 JOIN tbltransaction ON tbltransaction2.transnum = tbltransaction.transnum WHERE tbltransaction.transnum='" & lbltransnum.Text & "';", con)
                    rdr = cmd.ExecuteReader
                    If rdr.Read Then
                        t = rdr("s")
                    End If
                    lblordernum.Text = t
                    con.Close()
                End If


                con.Open()
                cmd = New SqlCommand("SELECT  tbladvancepayment.apnum FROM tblreturns JOIN tbladvancepayment ON tblreturns.ap_id = tbladvancepayment.ap_id JOIN tbltransaction ON tblreturns.transnum = tbltransaction.transnum JOIN tblorder ON tblorder.transnum = tblreturns.transnum JOIN tblitems ON tblorder.itemname = tblitems.itemname WHERE tblitems.deposit='1' AND tbltransaction.transnum='" & grd.CurrentRow.Cells("trnum").Value & "' OR tblreturns.status='" & "Active" & "'   AND tblreturns.status='" & "Used" & "'  ORDER BY tblreturns.returnum;", con)
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    lbldepositnumm.Text = rdr("apnum")
                Else
                    lbldepositnumm.Text = "N/A"
                End If
                con.Close()

                con.Open()
                cmd = New SqlCommand("SELECT apnum FROM tbladvancepayment WHERE from_trans=@trans and type='Advance Payment';", con)
                cmd.Parameters.AddWithValue("@trans", grd.CurrentRow.Cells("trnum").Value)
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    lblapnumm.Text = rdr("apnum")
                Else
                    lblapnumm.Text = "N/A"
                End If
                con.Close()

                con.Open()
                cmd = New SqlCommand("SELECT sap_no FROM tblars1 WHERE transnum=@trans;", con)
                cmd.Parameters.AddWithValue("@trans", grd.CurrentRow.Cells("trnum").Value)
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    lblarnum.Text = rdr("sap_no")
                Else
                    lblarnum.Text = "N/A"
                End If
                con.Close()

                Dim zz As Double = 0.00
                For index As Integer = 0 To grdorders.RowCount - 1
                    Dim result As Double = CDbl(grdorders.Rows(index).Cells("quantity").Value) * CDbl(grdorders.Rows(index).Cells("price").Value)

                    If result <> CDbl(grdorders.Rows(index).Cells("amount").Value) Then
                        grdorders.Columns("amount").HeaderText = "Discounted Amount"
                        zz += 1
                    End If
                Next

                If zz = 0 Then
                    grdorders.Columns("amount").HeaderText = "Amount"
                End If

                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub txttrans_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttrans.Enter
        txtcus.Enabled = False
    End Sub

    Private Sub txttrans_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttrans.Leave
        txttrans.Enabled = False
        txtcus.Enabled = True
    End Sub

    Private Sub txtcus_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcus.Enter
        txttrans.Enabled = False
    End Sub

    Private Sub txtcus_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcus.Leave
        txttrans.Enabled = True
        txtcus.Enabled = False
    End Sub

    Private Sub chkrefund_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkrefund.CheckedChanged
        loadTrans()
    End Sub

    Private Sub ButtonNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNext.Click
        offset += 30
        loadTrans()
    End Sub

    Private Sub ButtonPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPrevious.Click
        offset -= 30
        If offset = -30 Then
            offset = 0
        End If
        loadTrans()
    End Sub

    Private Sub datefrom1_ValueChanged(sender As Object, e As EventArgs) Handles datefrom1.ValueChanged
        loadTrans()
    End Sub

    Private Sub dateto1_ValueChanged(sender As Object, e As EventArgs) Handles dateto1.ValueChanged
        loadTrans()
    End Sub

    Private Sub cmbcash_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbcash.SelectedIndexChanged
        loadTrans()
    End Sub

    Private Sub hfrom_SelectedIndexChanged(sender As Object, e As EventArgs) Handles hfrom.SelectedIndexChanged
        loadTrans()
    End Sub

    Private Sub hto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles hto.SelectedIndexChanged
        loadTrans()
    End Sub

    Private Sub cmbtype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbtype.SelectedIndexChanged
        loadTrans()
    End Sub

    Private Sub cmbsales_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbsales.SelectedIndexChanged
        loadTrans()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub ButtonPageSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPageSave.Click
        If ButtonPageSave.Text = "edit" Then
            TextBoxPageNumber.BackColor = Color.White
            TextBoxPageNumber.Enabled = True
            ButtonPageSave.Text = "ok"
        ElseIf ButtonPageSave.Text = "ok" Then
            TextBoxPageNumber.BackColor = Color.FromArgb(214, 214, 194)
            TextBoxPageNumber.Enabled = False
            ButtonPageSave.Text = "edit"
            offset = CInt(TextBoxPageNumber.Text) * 30
            TextBoxPageNumber.Text = (CInt(TextBoxPageNumber.Text) - 1)
            loadTrans()
        End If
    End Sub
End Class