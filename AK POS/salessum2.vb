Imports System.Data.SqlClient
Imports System.Text
Imports System.IO
Public Class salessum2
    Dim strconn As String = login.ss
    Dim con As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader


    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function

    Private Sub salessum2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dateFromDaily.Text = DateTime.Now
        dateFromDaily.MaxDate = DateTime.Now
        dateToDaily.MaxDate = DateTime.Now.AddDays(1)
        'dateToDaily.Value = DateTime.Now.AddDays(1)
        loadCashiers()
        hourly()
        daily()
        yearlyGetYear()
        yearly()
    End Sub
    Public Sub yearlyGetYear()
        cmbyear.Items.Clear()
        con.Open()
        cmd = New SqlCommand("SELECT DISTINCT Year(datecreated) FROM tbltransaction", con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            cmbyear.Items.Add(rdr(0))
        End While
        con.Close()
        cmbyear.SelectedIndex = cmbyear.Items.Count - 1
    End Sub
    Public Sub totalPrices(ByVal txt As String, ByVal lbl As Label, ByVal sumOf As String)
        Dim cash As Double = 0.0, query As String = ""
        If txt = "" Then
            If sumOf = "delcharge" Then
                query = "SELECT ISNULL(SUM(delcharge),0) FROM tbltransaction WHERE Not area='Production' AND MONTH(datecreated)='" & datefrom.Value.Month & "' AND DAY(datecreated)='" & datefrom.Value.Day & "' AND YEAR(datecreated)='" & datefrom.Value.Year & "' AND tendertype='Cash'"
            Else
                query = "SELECT ISNULL(SUM(gctotal),0) FROM tbltransaction WHERE Not area='Production' AND MONTH(datecreated)='" & datefrom.Value.Month & "' AND DAY(datecreated)='" & datefrom.Value.Day & "' AND YEAR(datecreated)='" & datefrom.Value.Year & "'"
            End If
        Else
            If txt = "A.R Cash" Then
                query = "SELECT ISNULL(SUM(amtdue + partialamt),0) FROM tbltransaction WHERE Not area='Production' AND MONTH(datecreated)='" & datefrom.Value.Month & "' AND DAY(datecreated)='" & datefrom.Value.Day & "' AND YEAR(datecreated)='" & datefrom.Value.Year & "'  AND tendertype='" & txt & "'"
            Else
                query = "SELECT ISNULL(SUM(amtdue),0) FROM tbltransaction WHERE Not area='Production' AND MONTH(datecreated)='" & datefrom.Value.Month & "' AND DAY(datecreated)='" & datefrom.Value.Day & "' AND YEAR(datecreated)='" & datefrom.Value.Year & "'  AND tendertype='" & txt & "'"
            End If
        End If
        If cmbCashiers.SelectedIndex <> 0 Then
            query &= " AND cashier='" & cmbCashiers.Text & "';"
        End If
        con.Open()
        cmd = New SqlCommand(query, con)
        cash = cmd.ExecuteScalar()
        con.Close()
        If cash = 0 Then
            lbl.Text = "0.00"
        Else
            lbl.Text = cash.ToString("n2")
        End If
        Dim cashTotal As Double = 0.0, paymentTotal As Double = 0.0
        cashTotal = CDbl(lblARCASH.Text) + CDbl(lblcash.Text) + CDbl(lblapcash.Text) + CDbl(lbldeposit.Text) - CDbl(lblcashout.Text)
        paymentTotal = CDbl(lblap.Text) + CDbl(lblarsales.Text) + CDbl(lblcashsales.Text) + CDbl(lblarcharge.Text)
        lblcashtotal.Text = cashTotal.ToString("n2")
        lblpaymenttotal.Text = paymentTotal.ToString("n2")
        lblgtotal.Text = (cashTotal + paymentTotal).ToString("n2")
    End Sub

    Public Sub loadCashiers()
        cmbCashiers.Items.Clear()
        cmbCashiers2.Items.Clear()
        cmbCashiers3.Items.Clear()
        cmbCashiers.Items.Add("All")
        cmbCashiers2.Items.Add("All")
        cmbCashiers3.Items.Add("All")
        con.Open()
        cmd = New SqlCommand("SELECT username FROM tblusers WHERE workgroup='Cashier';", con)
        rdr = cmd.ExecuteReader()
        While rdr.Read
            cmbCashiers.Items.Add(rdr("username"))
            cmbCashiers2.Items.Add(rdr("username"))
            cmbCashiers3.Items.Add(rdr("username"))
        End While
        con.Close()
        cmbCashiers.SelectedIndex = 0
        cmbCashiers2.SelectedIndex = 0
        cmbCashiers3.SelectedIndex = 0
    End Sub
    Public Sub grandtotal()
        Try
            Dim result As Double = 0
            For index As Integer = 0 To dgvhour.Rows.Count - 1
                result += CDbl(dgvhour.Rows(index).Cells("totalsales").Value)
            Next
            lblgtotal.Text = result.ToString("n2")
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub hourly()
        Try
            datefrom.MaxDate = DateTime.Now
            dgvhour.Rows.Clear()
            Dim timeIn As New DateTime(datefrom.Value.Year, datefrom.Value.Month, datefrom.Value.Day, 7, 0, 0)
            Dim timeClosed As New DateTime(datefrom.Value.Year, datefrom.Value.Month, datefrom.Value.Day, 20, 0, 0)
            While timeIn <> timeClosed
                Dim numofTakeOut As Integer = 0, sumofTakeOut As Double = 0, numofDeliver As Integer = 0, sumofDeliver = 0, numofArCash As Integer = 0, sumofArCash As Double = 0, numofArSales As Integer = 0, sumofArSales As Double = 0, numofAdvancePaymentCash As Integer = 0, sumofAdvancePaymentCash As Double = 0, numofAdvancePayment As Integer = 0, sumofAdvancePayment As Double = 0, numofTransaction As Integer = 0, sumofTransaction As Double = 0, numofArCharge As Double = 0, sumofArCharge As Double = 0

                numofTakeOut = cunt("servicetype", "Take Out", timeIn)
                sumofTakeOut = value("servicetype", "Take Out", timeIn)
                numofDeliver = cunt("servicetype", "Deliver", timeIn)
                sumofDeliver = value("servicetype", "Deliver", timeIn)
                numofArCash = cunt("tendertype", "A.R Cash", timeIn)
                sumofArCash = value("tendertype", "A.R Cash", timeIn)
                numofArSales = cunt("tendertype", "A.R Sales", timeIn)
                sumofArSales = value("tendertype", "A.R Sales", timeIn)

                numofArCharge = cunt("tendertype", "A.R Charge", timeIn)
                sumofArCharge = value("tendertype", "A.R Charge", timeIn)

                numofAdvancePaymentCash = cunt("tendertype", "Advance Payment Cash", timeIn)
                sumofAdvancePaymentCash = value("tendertype", "Advance Payment Cash", timeIn)
                numofAdvancePayment = cunt("tendertype", "Advance Payment", timeIn)
                sumofAdvancePayment = value("tendertype", "Advance Payment", timeIn)

                'Dim q1 As String = "SELECT count(*) FROM tbltransaction WHERE datecreated  BETWEEN '" & timeIn & "' AND '" & timeIn.AddMinutes(59) & "' AND Not area='Production'"

                Dim q1 As String = "SELECT count(*) FROM tbltransaction WHERE datecreated>='" & timeIn & "' AND datecreated<='" & timeIn.AddMinutes(59) & "' AND Not area='Production'"


                If cmbCashiers.SelectedIndex <> 0 Then
                    q1 &= " AND cashier='" & cmbCashiers.Text & "';"
                End If
                con.Open()
                cmd = New SqlCommand(q1, con)
                numofTransaction = cmd.ExecuteScalar()
                con.Close()
                'Dim q2 As String = "SELECT ISNULL(SUM(amtdue  + gctotal),0) FROM tbltransaction WHERE datecreated  BETWEEN '" & timeIn & "' AND '" & timeIn.AddMinutes(59) & "' AND Not area='Production'"

                Dim q2 As String = "SELECT ISNULL(SUM(amtdue  + gctotal),0) FROM tbltransaction WHERE datecreated>='" & timeIn & "' AND datecreated<='" & timeIn.AddMinutes(59) & "' AND Not area='Production'"

                If cmbCashiers.SelectedIndex <> 0 Then
                    q2 &= " AND cashier='" & cmbCashiers.Text & "';"
                End If
                con.Open()
                cmd = New SqlCommand(q2, con)
                sumofTransaction = cmd.ExecuteScalar()
                con.Close()

                timeIn = timeIn.AddHours(1)
                dgvhour.Rows.Add(timeIn.ToString("hh:mm") & "-" & timeIn.AddMinutes(59).ToString("hh:mm") & " " & timeIn.ToString("tt"), numofTakeOut, sumofTakeOut.ToString("n2"), numofDeliver, sumofDeliver.ToString("n2"), numofArCharge.ToString("n2"), sumofArCharge.ToString("n2"), numofArCash, sumofArCash.ToString("n2"), numofArSales, sumofArSales.ToString("n2"), numofAdvancePaymentCash, sumofAdvancePaymentCash.ToString("n2"), numofAdvancePayment, sumofAdvancePayment.ToString("n2"), numofTransaction, sumofTransaction.ToString("n2"))
            End While
            'grandtotal()
            totalPrices("Cash", lblcash, "amtdue")
            totalPrices("Cash", lblcashsales, "amtdue")
            totalPrices("A.R Cash", lblARCASH, "amtdue")
            totalPrices("Advance Payment Cash", lblapcash, "amtdue")
            totalPrices("Advance Payment", lblap, "amtdue")
            totalPrices("A.R Sales", lblarsales, "amtdue")
            totalPrices("A.R Charge", lblarcharge, "amtdue")
            totalPrices("Deposit", lbldeposit, "amtdue")
            totalPrices("Cash Out", lblcashout, "amtdue")
            dgvhour.Columns("time").HeaderCell.Style.BackColor = Color.Coral
            dgvhour.Columns("numtakeout").HeaderCell.Style.BackColor = Color.LightSalmon
            dgvhour.Columns("salestakeout").HeaderCell.Style.BackColor = Color.LightSalmon
            dgvhour.Columns("numdeliver").HeaderCell.Style.BackColor = Color.LightBlue
            dgvhour.Columns("salesdeliver").HeaderCell.Style.BackColor = Color.LightBlue

            dgvhour.Columns("numarcharge").HeaderCell.Style.BackColor = Color.Violet
            dgvhour.Columns("salesarcharge").HeaderCell.Style.BackColor = Color.Violet

            dgvhour.Columns("numarcash").HeaderCell.Style.BackColor = Color.DarkSalmon
            dgvhour.Columns("salesarcash").HeaderCell.Style.BackColor = Color.DarkSalmon
            dgvhour.Columns("numarsales").HeaderCell.Style.BackColor = Color.LightSkyBlue
            dgvhour.Columns("salesarsales").HeaderCell.Style.BackColor = Color.LightSkyBlue
            dgvhour.Columns("numapcash").HeaderCell.Style.BackColor = Color.Khaki
            dgvhour.Columns("salesapcash").HeaderCell.Style.BackColor = Color.Khaki
            dgvhour.Columns("numap").HeaderCell.Style.BackColor = Color.Gold
            dgvhour.Columns("salesap").HeaderCell.Style.BackColor = Color.Gold
            dgvhour.Columns("numtotal").HeaderCell.Style.BackColor = Color.DodgerBlue
            dgvhour.Columns("totalsales").HeaderCell.Style.BackColor = Color.DodgerBlue
            For index As Integer = 0 To dgvhour.Rows.Count - 1
                dgvhour.Rows(index).Cells("time").Style.BackColor = Color.Coral
                dgvhour.Rows(index).Cells("numtakeout").Style.BackColor = Color.LightSalmon
                dgvhour.Rows(index).Cells("salestakeout").Style.BackColor = Color.LightSalmon
                dgvhour.Rows(index).Cells("numdeliver").Style.BackColor = Color.LightBlue
                dgvhour.Rows(index).Cells("salesdeliver").Style.BackColor = Color.LightBlue

                dgvhour.Rows(index).Cells("numarcharge").Style.BackColor = Color.Violet
                dgvhour.Rows(index).Cells("salesarcharge").Style.BackColor = Color.Violet

                dgvhour.Rows(index).Cells("numarcash").Style.BackColor = Color.DarkSalmon
                dgvhour.Rows(index).Cells("salesarcash").Style.BackColor = Color.DarkSalmon
                dgvhour.Rows(index).Cells("numarsales").Style.BackColor = Color.LightSkyBlue
                dgvhour.Rows(index).Cells("salesarsales").Style.BackColor = Color.LightSkyBlue
                dgvhour.Rows(index).Cells("numapcash").Style.BackColor = Color.Khaki
                dgvhour.Rows(index).Cells("salesapcash").Style.BackColor = Color.Khaki
                dgvhour.Rows(index).Cells("numap").Style.BackColor = Color.Gold
                dgvhour.Rows(index).Cells("salesap").Style.BackColor = Color.Gold
                dgvhour.Rows(index).Cells("numtotal").Style.BackColor = Color.DodgerBlue
                dgvhour.Rows(index).Cells("totalsales").Style.BackColor = Color.DodgerBlue
            Next

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Function cunt(ByVal whr As String, ByVal servicetype As String, ByVal tin As DateTime) As Integer
        'Dim q As String = "SELECT count(*) FROM tbltransaction WHERE " & whr & "='" & servicetype & "' AND datecreated  BETWEEN '" & tin & "' AND '" & tin.AddMinutes(59) & "' AND Not area='Production'"
        Dim q As String = "SELECT count(*) FROM tbltransaction WHERE " & whr & "='" & servicetype & "' AND datecreated>='" & tin & "' AND datecreated<='" & tin.AddMinutes(59) & "' AND Not area='Production'"

        If cmbCashiers.SelectedIndex <> 0 Then
            q &= " AND cashier='" & cmbCashiers.Text & "';"
        End If
        Dim count As Integer = 0
        con.Open()
        cmd = New SqlCommand(q, con)
        count = cmd.ExecuteScalar()
        con.Close()
        Return count
    End Function
    Public Function value(ByVal whr As String, ByVal servicetype As String, ByVal tin As DateTime) As Double
        Dim q As String = ""
        If servicetype.Equals("Deliver") Then
            'q = "SELECT ISNULL(SUM(amtdue + delcharge),0) FROM tbltransaction WHERE " & whr & "='" & servicetype & "' AND datecreated  BETWEEN '" & tin & "' AND '" & tin.AddMinutes(59) & "' AND Not area='Production' AND tendertype='Cash'"
            q = "SELECT ISNULL(SUM(amtdue + delcharge),0) FROM tbltransaction WHERE " & whr & "='" & servicetype & "' AND datecreated>='" & tin & "' AND datecreated<='" & tin.AddMinutes(59) & "' AND Not area='Production' AND tendertype='Cash'"
        Else
            If servicetype = "A.R Cash" Then
                q = "SELECT ISNULL(SUM(amtdue + partialamt),0) FROM tbltransaction WHERE " & whr & "='" & servicetype & "' AND datecreated>='" & tin & "' AND datecreated<='" & tin.AddMinutes(59) & "' AND Not area='Production'"
            Else
                q = "SELECT ISNULL(SUM(amtdue),0) FROM tbltransaction WHERE " & whr & "='" & servicetype & "' AND datecreated>='" & tin & "' AND datecreated<='" & tin.AddMinutes(59) & "' AND Not area='Production'"
            End If
            'q = "SELECT ISNULL(SUM(amtdue),0) FROM tbltransaction WHERE " & whr & "='" & servicetype & "' AND datecreated  BETWEEN '" & tin & "' AND '" & tin.AddMinutes(59) & "' AND Not area='Production'"
        End If
        If cmbCashiers.SelectedIndex <> 0 Then
            q &= " AND cashier='" & cmbCashiers.Text & "';"
        End If
        Dim vals As Double = 0
        con.Open()
        cmd = New SqlCommand(q, con)
        vals = cmd.ExecuteScalar()
        con.Close()
        Return vals
    End Function

    Private Sub datefrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles datefrom.ValueChanged
        hourly()
    End Sub

    Private Sub cmbCashiers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCashiers.SelectedIndexChanged
        hourly()
    End Sub
    Public Sub dailytotalPrices(ByVal txt As String, ByVal lbl As Label, ByVal sumOf As String)
        Dim dfrom As New DateTime(dateFromDaily.Value.Year, dateFromDaily.Value.Month, dateFromDaily.Value.Day)
        Dim dto As New DateTime(dateToDaily.Value.Year, dateToDaily.Value.Month, dateToDaily.Value.Day)
        Dim cash As Double = 0.0
        While dfrom <= dto
            Dim query As String = ""
            If txt = "" Then
                If sumOf = "delcharge" Then
                    query = "SELECT ISNULL(SUM(delcharge),0) FROM tbltransaction WHERE Not area='Production' AND MONTH(datecreated)='" & dfrom.Month & "' AND DAY(datecreated)='" & dfrom.Day & "' AND YEAR(datecreated)='" & dfrom.Year & "' AND tendertype='Cash'"
                Else
                    query = "SELECT ISNULL(SUM(gctotal),0) FROM tbltransaction WHERE Not area='Production' AND MONTH(datecreated)='" & dfrom.Month & "' AND DAY(datecreated)='" & dfrom.Day & "' AND YEAR(datecreated)='" & dfrom.Year & "'"
                End If
            Else
                If txt = "A.R Cash" Then
                    query = "SELECT ISNULL(SUM(amtdue + partialamt),0) FROM tbltransaction WHERE Not area='Production' AND MONTH(datecreated)='" & dfrom.Month & "' AND DAY(datecreated)='" & dfrom.Day & "' AND YEAR(datecreated)='" & dfrom.Year & "'  AND tendertype='" & txt & "'"
                Else
                    query = "SELECT ISNULL(SUM(amtdue),0) FROM tbltransaction WHERE Not area='Production' AND MONTH(datecreated)='" & dfrom.Month & "' AND DAY(datecreated)='" & dfrom.Day & "' AND YEAR(datecreated)='" & dfrom.Year & "'  AND tendertype='" & txt & "'"
                End If
            End If
            If cmbCashiers2.SelectedIndex <> 0 Then
                query &= " AND cashier='" & cmbCashiers2.Text & "';"
            End If
            con.Open()
            cmd = New SqlCommand(query, con)
            cash += cmd.ExecuteScalar()
            con.Close()
            dfrom = dfrom.AddDays(1)
        End While
        If cash = 0 Then
            lbl.Text = "0.00"
        Else
            lbl.Text = cash.ToString("n2")
        End If
        Dim cashTotal As Double = 0.0, paymentTotal As Double = 0.0
        cashTotal = CDbl(lbldailyarcash.Text) + CDbl(lbldailycash.Text) + CDbl(lbldailyapcash.Text) + CDbl(lbldailydeposit.Text) - CDbl(lbldailycashout.Text)
        paymentTotal = CDbl(lbldailyap.Text) + CDbl(lbldailyarsales.Text) + CDbl(lbldailycashsales.Text) + CDbl(lbldailyarcharge.Text)
        lbldailycashtotal.Text = cashTotal.ToString("n2")
        lbldailypaymenttotal.Text = paymentTotal.ToString("n2")
        lbldailygtotal.Text = (cashTotal + paymentTotal).ToString("n2")
    End Sub
    Public Sub daily()
        dgvDaily.Rows.Clear()
        Dim dfrom As New DateTime(dateFromDaily.Value.Year, dateFromDaily.Value.Month, dateFromDaily.Value.Day)
        Dim dto As New DateTime(dateToDaily.Value.Year, dateToDaily.Value.Month, dateToDaily.Value.Day)

        While dfrom <= dto
            Dim numofTakeOut As Integer = 0, sumofTakeOut As Double = 0, numofDeliver As Integer = 0, sumofDeliver = 0, numofArCash As Integer = 0, sumofArCash As Double = 0, numofArSales As Integer = 0, sumofArSales As Double = 0, numofAdvancePaymentCash As Integer = 0, sumofAdvancePaymentCash As Double = 0, numofAdvancePayment As Integer = 0, sumofAdvancePayment As Double = 0, numofTransaction As Integer = 0, sumofTransaction As Double = 0, numofArCharge As Double = 0, sumofArCharge As Double = 0

            numofTakeOut = Dailycunt("servicetype", "Take Out", dfrom)
            sumofTakeOut = Dailyvalue("servicetype", "Take Out", dfrom)
            numofDeliver = Dailycunt("servicetype", "Deliver", dfrom)
            sumofDeliver = Dailyvalue("servicetype", "Deliver", dfrom)

            numofArCharge = Dailycunt("tendertype", "A.R Charge", dfrom)
            sumofArCharge = Dailyvalue("tendertype", "A.R Charge", dfrom)

            numofArCash = Dailycunt("tendertype", "A.R Cash", dfrom)
            sumofArCash = Dailyvalue("tendertype", "A.R Cash", dfrom)
            numofArSales = Dailycunt("tendertype", "A.R Sales", dfrom)
            sumofArSales = Dailyvalue("tendertype", "A.R Sales", dfrom)
            numofAdvancePaymentCash = Dailycunt("tendertype", "Advance Payment Cash", dfrom)
            sumofAdvancePaymentCash = Dailyvalue("tendertype", "Advance Payment Cash", dfrom)
            numofAdvancePayment = Dailycunt("tendertype", "Advance Payment", dfrom)
            sumofAdvancePayment = Dailyvalue("tendertype", "Advance Payment", dfrom)

            Dim q1 As String = "SELECT count(*) FROM tbltransaction WHERE MONTH(datecreated)='" & dfrom.Month & "' AND DAY(datecreated)='" & dfrom.Day & "' AND YEAR(datecreated)='" & dfrom.Year & "' AND Not area='Production'"
            If cmbCashiers2.SelectedIndex <> 0 Then
                q1 &= " AND cashier='" & cmbCashiers2.Text & "';"
            End If
            con.Open()
            cmd = New SqlCommand(q1, con)
            numofTransaction = cmd.ExecuteScalar()
            con.Close()
            Dim q2 As String = "SELECT ISNULL(SUM(amtdue  + gctotal),0) FROM tbltransaction WHERE MONTH(datecreated)='" & dfrom.Month & "' AND DAY(datecreated)='" & dfrom.Day & "' AND YEAR(datecreated)='" & dfrom.Year & "' AND Not area='Production'"
            If cmbCashiers2.SelectedIndex <> 0 Then
                q2 &= " AND cashier='" & cmbCashiers2.Text & "';"
            End If
            con.Open()
            cmd = New SqlCommand(q2, con)
            sumofTransaction = cmd.ExecuteScalar()
            con.Close()

            dgvDaily.Rows.Add(dfrom.ToString("MM/dd/yyyy"), numofTakeOut, sumofTakeOut.ToString("n2"), numofDeliver, sumofDeliver.ToString("n2"), numofArCharge, sumofArCharge.ToString("n2"), numofArCash, sumofArCash.ToString("n2"), numofArSales, sumofArSales.ToString("n2"), numofAdvancePaymentCash, sumofAdvancePaymentCash.ToString("n2"), numofAdvancePayment, sumofAdvancePayment.ToString("n2"), numofTransaction, sumofTransaction.ToString("n2"))
            dfrom = dfrom.AddDays(1)
        End While

        dailytotalPrices("Cash", lbldailycash, "amtdue")
        dailytotalPrices("Cash", lbldailycashsales, "amtdue")
        dailytotalPrices("A.R Cash", lbldailyarcash, "amtdue")
        dailytotalPrices("Advance Payment Cash", lbldailyapcash, "amtdue")
        'dailytotalPrices("", lbldailygc, "gctotal")
        'dailytotalPrices("", lbldailydeliver, "delcharge")
        dailytotalPrices("Advance Payment", lbldailyap, "amtdue")
        dailytotalPrices("A.R Sales", lbldailyarsales, "amtdue")
        dailytotalPrices("A.R Charge", lbldailyarcharge, "amtdue")

        dailytotalPrices("Deposit", lbldailydeposit, "amtdue")
        dailytotalPrices("Cash Out", lbldailycashout, "amtdue")

        dgvDaily.Columns("dailydate").HeaderCell.Style.BackColor = Color.Coral
        dgvDaily.Columns("dailynumtakeout").HeaderCell.Style.BackColor = Color.LightSalmon
        dgvDaily.Columns("dailysalestakeout").HeaderCell.Style.BackColor = Color.LightSalmon
        dgvDaily.Columns("dailynumdeliver").HeaderCell.Style.BackColor = Color.LightBlue
        dgvDaily.Columns("dailysalesdeliver").HeaderCell.Style.BackColor = Color.LightBlue

        dgvDaily.Columns("dailynumarcharge").HeaderCell.Style.BackColor = Color.Violet
        dgvDaily.Columns("dailysalesarcharge").HeaderCell.Style.BackColor = Color.Violet

        dgvDaily.Columns("dailynumarcash").HeaderCell.Style.BackColor = Color.DarkSalmon
        dgvDaily.Columns("dailysalesarcash").HeaderCell.Style.BackColor = Color.DarkSalmon
        dgvDaily.Columns("dailynumarsales").HeaderCell.Style.BackColor = Color.LightSkyBlue
        dgvDaily.Columns("dailysalesarsales").HeaderCell.Style.BackColor = Color.LightSkyBlue
        dgvDaily.Columns("dailynumapcash").HeaderCell.Style.BackColor = Color.Khaki
        dgvDaily.Columns("dailysalesapcash").HeaderCell.Style.BackColor = Color.Khaki
        dgvDaily.Columns("dailynumap").HeaderCell.Style.BackColor = Color.Gold
        dgvDaily.Columns("dailysalesap").HeaderCell.Style.BackColor = Color.Gold
        dgvDaily.Columns("dailynumtotal").HeaderCell.Style.BackColor = Color.DodgerBlue
        dgvDaily.Columns("dailytotalsales").HeaderCell.Style.BackColor = Color.DodgerBlue
        For index As Integer = 0 To dgvDaily.Rows.Count - 1
            dgvDaily.Rows(index).Cells("dailydate").Style.BackColor = Color.Coral
            dgvDaily.Rows(index).Cells("dailynumtakeout").Style.BackColor = Color.LightSalmon
            dgvDaily.Rows(index).Cells("dailysalestakeout").Style.BackColor = Color.LightSalmon
            dgvDaily.Rows(index).Cells("dailynumdeliver").Style.BackColor = Color.LightBlue
            dgvDaily.Rows(index).Cells("dailysalesdeliver").Style.BackColor = Color.LightBlue

            dgvDaily.Rows(index).Cells("dailynumarcharge").Style.BackColor = Color.Violet
            dgvDaily.Rows(index).Cells("dailysalesarcharge").Style.BackColor = Color.Violet

            dgvDaily.Rows(index).Cells("dailynumarcash").Style.BackColor = Color.DarkSalmon
            dgvDaily.Rows(index).Cells("dailysalesarcash").Style.BackColor = Color.DarkSalmon
            dgvDaily.Rows(index).Cells("dailynumarsales").Style.BackColor = Color.LightSkyBlue
            dgvDaily.Rows(index).Cells("dailysalesarsales").Style.BackColor = Color.LightSkyBlue
            dgvDaily.Rows(index).Cells("dailynumapcash").Style.BackColor = Color.Khaki
            dgvDaily.Rows(index).Cells("dailysalesapcash").Style.BackColor = Color.Khaki
            dgvDaily.Rows(index).Cells("dailynumap").Style.BackColor = Color.Gold
            dgvDaily.Rows(index).Cells("dailysalesap").Style.BackColor = Color.Gold
            dgvDaily.Rows(index).Cells("dailynumtotal").Style.BackColor = Color.DodgerBlue
            dgvDaily.Rows(index).Cells("dailytotalsales").Style.BackColor = Color.DodgerBlue
        Next
    End Sub
    Public Function Dailycunt(ByVal whr As String, ByVal servicetype As String, ByVal tin As DateTime) As Integer
        Dim q As String = "SELECT count(*) FROM tbltransaction WHERE " & whr & "='" & servicetype & "' AND MONTH(datecreated)='" & tin.Month & "' AND DAY(datecreated)='" & tin.Day & "' AND YEAR(datecreated)='" & tin.Year & "' AND Not area='Production'"
        If cmbCashiers2.SelectedIndex <> 0 Then
            q &= " AND cashier='" & cmbCashiers2.Text & "';"
        End If
        Dim count As Integer = 0
        con.Open()
        cmd = New SqlCommand(q, con)
        count = cmd.ExecuteScalar()
        con.Close()
        Return count
    End Function
    Public Function Dailyvalue(ByVal whr As String, ByVal servicetype As String, ByVal tin As DateTime) As Double
        Dim q As String = ""
        If servicetype.Equals("Deliver") Then
            q = "SELECT ISNULL(SUM(amtdue + delcharge),0) FROM tbltransaction WHERE " & whr & "='" & servicetype & "' AND MONTH(datecreated)='" & tin.Month & "' AND DAY(datecreated)='" & tin.Day & "' AND YEAR(datecreated)='" & tin.Year & "' AND Not area='Production' AND tendertype='Cash'"
        Else
            If servicetype = "A.R Cash" Then
                q = "SELECT ISNULL(SUM(amtdue + partialamt),0) FROM tbltransaction WHERE " & whr & "='" & servicetype & "' AND MONTH(datecreated)='" & tin.Month & "' AND DAY(datecreated)='" & tin.Day & "' AND YEAR(datecreated)='" & tin.Year & "' AND Not area='Production'"
            Else
                q = "SELECT ISNULL(SUM(amtdue),0) FROM tbltransaction WHERE " & whr & "='" & servicetype & "' AND MONTH(datecreated)='" & tin.Month & "' AND DAY(datecreated)='" & tin.Day & "' AND YEAR(datecreated)='" & tin.Year & "' AND Not area='Production'"
            End If
        End If
        If cmbCashiers2.SelectedIndex <> 0 Then
            q &= " AND cashier='" & cmbCashiers2.Text & "';"
        End If
        Dim vals As Double = 0
        con.Open()
        cmd = New SqlCommand(q, con)
        vals = cmd.ExecuteScalar()
        con.Close()
        Return vals
    End Function
    Private Sub dateFromDaily_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dateFromDaily.ValueChanged
        daily()
    End Sub

    Private Sub dateToDaily_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dateToDaily.ValueChanged
        daily()
    End Sub

    Private Sub cmbCashiers2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCashiers2.SelectedIndexChanged
        daily()
    End Sub
    Public Sub yearly()
        dgvyearly.Rows.Clear()
        Dim mo As Integer = 1, month As String = ""
        While mo <= 12
            Select Case mo
                Case 1
                    month = "January"
                Case 2
                    month = "February"
                Case 3
                    month = "March"
                Case 4
                    month = "April"
                Case 5
                    month = "May"
                Case 6
                    month = "June"
                Case 7
                    month = "July"
                Case 8
                    month = "August"
                Case 9
                    month = "September"
                Case 10
                    month = "October"
                Case 11
                    month = "November"
                Case 12
                    month = "December"
            End Select
            Dim numofTakeOut As Integer = 0, sumofTakeOut As Double = 0, numofDeliver As Integer = 0, sumofDeliver = 0, numofArCash As Integer = 0, sumofArCash As Double = 0, numofArSales As Integer = 0, sumofArSales As Double = 0, numofAdvancePaymentCash As Integer = 0, sumofAdvancePaymentCash As Double = 0, numofAdvancePayment As Integer = 0, sumofAdvancePayment As Double = 0, numofTransaction As Integer = 0, sumofTransaction As Double = 0, numofArCharge As Double = 0, sumofArCharge As Double = 0

            numofTakeOut = Yearlycunt("servicetype", "Take Out", mo)
            sumofTakeOut = Yearlyvalue("servicetype", "Take Out", mo)
            numofDeliver = Yearlycunt("servicetype", "Deliver", mo)
            sumofDeliver = Yearlyvalue("servicetype", "Deliver", mo)

            numofArCharge = Yearlycunt("tendertype", "A.R Charge", mo)
            sumofArCharge = Yearlyvalue("tendertype", "A.R Charge", mo)

            numofArCash = Yearlycunt("tendertype", "A.R Cash", mo)
            sumofArCash = Yearlyvalue("tendertype", "A.R Cash", mo)
            numofArSales = Yearlycunt("tendertype", "A.R Sales", mo)
            sumofArSales = Yearlyvalue("tendertype", "A.R Sales", mo)
            numofAdvancePaymentCash = Yearlycunt("tendertype", "Advance Payment Cash", mo)
            sumofAdvancePaymentCash = Yearlyvalue("tendertype", "Advance Payment Cash", mo)
            numofAdvancePayment = Yearlycunt("tendertype", "Advance Payment", mo)
            sumofAdvancePayment = Yearlyvalue("tendertype", "Advance Payment", mo)


            Dim q1 As String = "SELECT count(*) FROM tbltransaction WHERE MONTH(datecreated)='" & mo & "' AND YEAR(datecreated)='" & cmbyear.Text & "' AND Not area='Production'"
            If cmbCashiers3.SelectedIndex <> 0 Then
                q1 &= " AND cashier='" & cmbCashiers3.Text & "';"
            End If
            con.Open()
            cmd = New SqlCommand(q1, con)
            numofTransaction = cmd.ExecuteScalar()
            con.Close()
            Dim q2 As String = "SELECT ISNULL(SUM(amtdue  + gctotal),0) FROM tbltransaction WHERE MONTH(datecreated)='" & mo & "' AND YEAR(datecreated)='" & cmbyear.Text & "' AND Not area='Production'"
            If cmbCashiers3.SelectedIndex <> 0 Then
                q2 &= " AND cashier='" & cmbCashiers3.Text & "';"
            End If
            con.Open()
            cmd = New SqlCommand(q2, con)
            sumofTransaction = cmd.ExecuteScalar()
            con.Close()

            mo = mo + 1
            dgvyearly.Rows.Add(month, numofTakeOut, sumofTakeOut.ToString("n2"), numofDeliver, sumofDeliver.ToString("n2"), numofArCharge, sumofArCharge.ToString("n2"), numofArCash, sumofArCash.ToString("n2"), numofArSales, sumofArSales.ToString("n2"), numofAdvancePaymentCash, sumofAdvancePaymentCash.ToString("n2"), numofAdvancePayment, sumofAdvancePayment.ToString("n2"), numofTransaction, sumofTransaction.ToString("n2"))
        End While

        yearlytotalPrices("Cash", lblyearlycash, "amtdue")
        yearlytotalPrices("Cash", lblyearlycashsales, "amtdue")
        yearlytotalPrices("A.R Cash", lblyearlyarcash, "amtdue")
        yearlytotalPrices("Advance Payment Cash", lblyearlyapcash, "amtdue")
        'yearlytotalPrices("", lblyearlygc, "gctotal")
        'yearlytotalPrices("", lblyearlydeliver, "delcharge")
        yearlytotalPrices("Advance Payment", lblyearlyap, "amtdue")
        yearlytotalPrices("A.R Sales", lblyearlyarsales, "amtdue")
        yearlytotalPrices("A.R Charge", lblyearlyarcharge, "amtdue")

        yearlytotalPrices("Deposit", lblyearlydeposit, "amtdue")
        yearlytotalPrices("Cash Out", lblyearlycashout, "amtdue")

        dgvyearly.Columns("yearlymonth").HeaderCell.Style.BackColor = Color.Coral
        dgvyearly.Columns("yearlynumtakeout").HeaderCell.Style.BackColor = Color.LightSalmon
        dgvyearly.Columns("yearlysalestakeout").HeaderCell.Style.BackColor = Color.LightSalmon
        dgvyearly.Columns("yearlynumdeliver").HeaderCell.Style.BackColor = Color.LightBlue
        dgvyearly.Columns("yearlysalesdeliver").HeaderCell.Style.BackColor = Color.LightBlue

        dgvyearly.Columns("yearlynumarcharge").HeaderCell.Style.BackColor = Color.Violet
        dgvyearly.Columns("yearlysalesarcharge").HeaderCell.Style.BackColor = Color.Violet

        dgvyearly.Columns("yearlynumarcash").HeaderCell.Style.BackColor = Color.DarkSalmon
        dgvyearly.Columns("yearlysalesarcash").HeaderCell.Style.BackColor = Color.DarkSalmon
        dgvyearly.Columns("yearlynumarsales").HeaderCell.Style.BackColor = Color.LightSkyBlue
        dgvyearly.Columns("yearlysalesarsales").HeaderCell.Style.BackColor = Color.LightSkyBlue
        dgvyearly.Columns("yearlynumapcash").HeaderCell.Style.BackColor = Color.Khaki
        dgvyearly.Columns("yearlysalesapcash").HeaderCell.Style.BackColor = Color.Khaki
        dgvyearly.Columns("yearlynumap").HeaderCell.Style.BackColor = Color.Gold
        dgvyearly.Columns("yearlysalesap").HeaderCell.Style.BackColor = Color.Gold
        dgvyearly.Columns("yearlynumtotal").HeaderCell.Style.BackColor = Color.DodgerBlue
        dgvyearly.Columns("yearlytotalsales").HeaderCell.Style.BackColor = Color.DodgerBlue
        For index As Integer = 0 To dgvyearly.Rows.Count - 1
            dgvyearly.Rows(index).Cells("yearlymonth").Style.BackColor = Color.Coral
            dgvyearly.Rows(index).Cells("yearlynumtakeout").Style.BackColor = Color.LightSalmon
            dgvyearly.Rows(index).Cells("yearlysalestakeout").Style.BackColor = Color.LightSalmon
            dgvyearly.Rows(index).Cells("yearlynumdeliver").Style.BackColor = Color.LightBlue
            dgvyearly.Rows(index).Cells("yearlysalesdeliver").Style.BackColor = Color.LightBlue

            dgvyearly.Rows(index).Cells("yearlynumarcharge").Style.BackColor = Color.Violet
            dgvyearly.Rows(index).Cells("yearlysalesarcharge").Style.BackColor = Color.Violet

            dgvyearly.Rows(index).Cells("yearlynumarcash").Style.BackColor = Color.DarkSalmon
            dgvyearly.Rows(index).Cells("yearlysalesarcash").Style.BackColor = Color.DarkSalmon
            dgvyearly.Rows(index).Cells("yearlynumarsales").Style.BackColor = Color.LightSkyBlue
            dgvyearly.Rows(index).Cells("yearlysalesarsales").Style.BackColor = Color.LightSkyBlue
            dgvyearly.Rows(index).Cells("yearlynumapcash").Style.BackColor = Color.Khaki
            dgvyearly.Rows(index).Cells("yearlysalesapcash").Style.BackColor = Color.Khaki
            dgvyearly.Rows(index).Cells("yearlynumap").Style.BackColor = Color.Gold
            dgvyearly.Rows(index).Cells("yearlysalesap").Style.BackColor = Color.Gold
            dgvyearly.Rows(index).Cells("yearlynumtotal").Style.BackColor = Color.DodgerBlue
            dgvyearly.Rows(index).Cells("yearlytotalsales").Style.BackColor = Color.DodgerBlue
        Next

    End Sub
    Public Function Yearlycunt(ByVal whr As String, ByVal servicetype As String, ByVal tin As Integer) As Integer
        Dim q As String = "SELECT count(*) FROM tbltransaction WHERE " & whr & "='" & servicetype & "' AND MONTH(datecreated)='" & tin & "' AND Not area='Production' AND YEAR(datecreated)='" & cmbyear.Text & "'"
        If cmbCashiers3.SelectedIndex <> 0 Then
            q &= " AND cashier='" & cmbCashiers3.Text & "';"
        End If
        Dim count As Integer = 0
        con.Open()
        cmd = New SqlCommand(q, con)
        count = cmd.ExecuteScalar()
        con.Close()
        Return count
    End Function
    Public Function Yearlyvalue(ByVal whr As String, ByVal servicetype As String, ByVal tin As Integer) As Double
        Dim q As String = ""
        If servicetype.Equals("Deliver") Then
            q = "SELECT ISNULL(SUM(amtdue + delcharge),0) FROM tbltransaction WHERE " & whr & "='" & servicetype & "' AND MONTH(datecreated)='" & tin & "' AND Not area='Production' AND YEAR(datecreated)='" & cmbyear.Text & "' AND tendertype='Cash'"
        Else
            If servicetype = "A.R Cash" Then
                q = "SELECT ISNULL(SUM(amtdue + partialamt),0) FROM tbltransaction WHERE " & whr & "='" & servicetype & "' AND MONTH(datecreated)='" & tin & "' AND Not area='Production' AND YEAR(datecreated)='" & cmbyear.Text & "'"
            Else
                q = "SELECT ISNULL(SUM(amtdue),0) FROM tbltransaction WHERE " & whr & "='" & servicetype & "' AND MONTH(datecreated)='" & tin & "' AND Not area='Production' AND YEAR(datecreated)='" & cmbyear.Text & "'"
            End If
        End If
        If cmbCashiers3.SelectedIndex <> 0 Then
            q &= " AND cashier='" & cmbCashiers3.Text & "';"
        End If
        Dim vals As Double = 0
        con.Open()
        cmd = New SqlCommand(q, con)
        vals = cmd.ExecuteScalar()
        con.Close()
        Return vals
    End Function
    Public Sub yearlytotalPrices(ByVal txt As String, ByVal lbl As Label, ByVal sumOf As String)
        Dim cash As Double = 0.0
        Dim mo As Integer = 1, month As String = ""
        While mo <= 12
            Dim query As String = ""
            If txt = "" Then
                If sumOf = "delcharge" Then
                    query = "SELECT ISNULL(SUM(delcharge),0) FROM tbltransaction WHERE Not area='Production' AND YEAR(datecreated)='" & cmbyear.Text & "' AND tendertype='Cash'"
                Else
                    query = "SELECT ISNULL(SUM(gctotal),0) FROM tbltransaction WHERE Not area='Production' AND YEAR(datecreated)='" & cmbyear.Text & "'"
                End If
            Else
                If txt = "A.R Cash" Then
                    query = "SELECT ISNULL(SUM(amtdue + partialamt),0) FROM tbltransaction WHERE Not area='Production' AND YEAR(datecreated)='" & cmbyear.Text & "'  AND tendertype='" & txt & "'"
                Else
                    query = "SELECT ISNULL(SUM(amtdue),0) FROM tbltransaction WHERE Not area='Production' AND YEAR(datecreated)='" & cmbyear.Text & "'  AND tendertype='" & txt & "'"
                End If
            End If
            If cmbCashiers3.SelectedIndex <> 0 Then
                query &= " AND cashier='" & cmbCashiers3.Text & "';"
            End If
            con.Open()
            cmd = New SqlCommand(query, con)
            cash = cmd.ExecuteScalar()
            con.Close()
            mo = mo + 1
        End While
        If cash = 0 Then
            lbl.Text = "0.00"
        Else
            lbl.Text = cash.ToString("n2")
        End If
        Dim cashTotal As Double = 0.0, paymentTotal As Double = 0.0
        cashTotal = CDbl(lblyearlyarcash.Text) + CDbl(lblyearlycash.Text) + CDbl(lblyearlyapcash.Text) + CDbl(lblyearlydeposit.Text) - CDbl(lblyearlycashout.Text)
        paymentTotal = CDbl(lblyearlyap.Text) + CDbl(lblyearlyarsales.Text) + CDbl(lblyearlycashsales.Text) + CDbl(lblyearlyarcharge.Text)
        lblyearlycashtotal.Text = cashTotal.ToString("n2")
        lblyearlypaymenttotal.Text = paymentTotal.ToString("n2")
        lblyearlygtotal.Text = (cashTotal + paymentTotal).ToString("n2")
    End Sub
    Private Sub cmbCashiers3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCashiers3.SelectedIndexChanged
        yearly()
    End Sub

    Private Sub dgvhour_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvhour.CellContentClick

    End Sub
End Class