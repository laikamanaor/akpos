Imports System.Data.SqlClient
Imports System.IO
Imports AK_POS.connection_class
Public Class dashboard_hourly
    Dim cc As New connection_class
    Dim strconn As String = cc.conString
    Dim con As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Public Sub loadSales()
        Try
            cmbsales.Items.Clear()
            cmbsales.Items.Add("All")
            con.Open()
            cmd = New SqlCommand("SELECT username FROM tblusers WHERE workgroup IN ('Sales','Manager') AND status=1 ORDER BY username;", con)
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
    Public Sub items()
        Try
            chartitems.Series.Clear()
            chartitems.Series.Add("Salary")
            chartitems.Titles.Clear()
            chartitems.Titles.Add("TOP 10 ITEMS")
            chartitems.Series("Salary").Font = New Font("Arial", 10, FontStyle.Bold)
            chartitems.Series("Salary").LegendText = "Items"

            Dim totalPrice As Double = 0.00
            con.Open()
            cmd = New SqlCommand("SELECT ISNULL(SUM(a.qty),0) [qty] FROM tblorder a INNER JOIN tbltransaction b ON a.transnum = b.transnum WHERE CAST(b.datecreated AS date)='" & dtdate.Text & "' " & IIf(cmbsales.SelectedIndex <> 0, "AND b.salesname='" & cmbsales.Text & "'", "") & " AND b.status = 1 GROUP BY a.itemname ORDER BY qty DESC OFFSET 0 ROWS FETCH Next 10 ROWS ONLY", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                totalPrice += CDbl(rdr("qty"))
            End While
            con.Close()

            con.Open()
            cmd = New SqlCommand("Select a.itemname, ISNULL(SUM(a.qty), 0) [qty] FROM tblorder a INNER JOIN tbltransaction b On a.transnum = b.transnum WHERE CAST(b.datecreated AS date)='" & dtdate.Text & "' " & IIf(cmbsales.SelectedIndex <> 0, "AND b.salesname='" & cmbsales.Text & "'", "") & " AND b.status = 1 GROUP BY a.itemname ORDER BY qty DESC OFFSET 0 ROWS FETCH Next 10 ROWS ONLY", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                Dim result As Double = CDbl(rdr("qty")) / totalPrice * 100
                chartitems.Series("Salary").Points.AddXY(rdr("itemname") & " " & result.ToString("n2") & "%", rdr("qty"))
            End While
            con.Close()

            chartitems.ChartAreas(0).AxisX.Interval = 1
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Public Sub sales()
        Try
            Dim total As Double = 0.0

            chartsales.Series.Clear()
            chartsales.Titles.Clear()
            chartsales.Series.Add("sales")
            chartsales.Series("sales").ChartType = DataVisualization.Charting.SeriesChartType.Bar
            chartsales.Series("sales").LegendText = "SALES"
            con.Open()
            cmd = New SqlCommand("SELECT SUM(a1.amtdue) [amtdue], DATEPART(HOUR,a1.datecreated)[hour],x.total FROM tbltransaction a1 OUTER APPLY(SELECT SUM(amtdue) [total] FROM tbltransaction a2 WHERE CAST(a2.datecreated AS date)='" & dtdate.Text & "' And a2.tendertype='CASH' AND a2.status=1 " & IIf(cmbsales.SelectedIndex <> 0, "AND a2.salesname='" & cmbsales.Text & "'", "") & ")x WHERE CAST(a1.datecreated as date)='" & dtdate.Text & "' And a1.tendertype='CASH' AND a1.status=1  " & IIf(cmbsales.SelectedIndex <> 0, "AND a1.salesname='" & cmbsales.Text & "'", "") & " GROUP BY DATEPART(HOUR,a1.datecreated),x.total", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                Dim result As Double = rdr("amtdue") / rdr("total") * 100
                chartsales.Series("sales").Points.AddXY(rdr("hour") & ":00 (" & Math.Round(result) & "%)", Math.Round(result))
                total = CDbl(rdr("total"))
            End While
            con.Close()
            chartsales.Titles.Add("POS Cash Onhand: " & total.ToString("n2"))
            chartsales.ChartAreas(0).AxisX.Interval = 1
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub ars()
        Try
            chartar.Series.Clear()
            chartar.Series.Add("ar1")
            chartar.Titles.Clear()
            chartar.Titles.Add("A.R")
            chartar.Series("ar1").ChartType = DataVisualization.Charting.SeriesChartType.Doughnut
            chartar.Series("ar1").IsValueShownAsLabel = True


            con.Open()
            cmd = New SqlCommand("SELECT ISNULL(SUM(a.amtdue),0)  [ar_cash],x.ar_charge,xx.ar_sales,xxx.total FROM tbltransaction a OUTER APPLY (SELECT ISNULL(SUM(b.amtdue),0) [ar_charge] FROM tbltransaction b WHERE CAST(b.datecreated AS date)='" & dtdate.Text & "' AND b.status=1 AND b.tendertype='A.R Charge')x OUTER APPLY (SELECT ISNULL(SUM(c.amtdue),0) [ar_sales] FROM tbltransaction c WHERE CAST(c.datecreated AS date)='" & dtdate.Text & "' AND c.status=1 AND c.tendertype='A.R Sales')xx OUTER APPLY (SELECT ISNULL(SUM(c.amtdue),0) [total] FROM tbltransaction c WHERE CAST(c.datecreated AS date)='" & dtdate.Text & "' AND c.status=1 AND c.tendertype IN('A.R Sales','A.R Charge','CASH'))xxx WHERE CAST(a.datecreated AS date)='" & dtdate.Text & "' AND a.status=1 AND a.tendertype='CASH' GROUP BY x.ar_charge,xx.ar_sales,xxx.total", con)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                Dim result_arcash As Double = rdr("ar_cash") / rdr("total") * 100
                Dim result_archarge As Double = rdr("ar_charge") / rdr("total") * 100
                Dim result_arsales As Double = rdr("ar_sales") / rdr("total") * 100
                chartar.Series("ar1").Points.AddXY("A.R Cash (" & CDbl(rdr("ar_cash")).ToString("n2") & ")", Math.Round(result_arcash))
                chartar.Series("ar1").Points.AddXY("A.R Charge (" & CDbl(rdr("ar_charge")).ToString("n2") & ")", Math.Round(result_archarge))
                chartar.Series("ar1").Points.AddXY("A.R Sales (" & CDbl(rdr("ar_sales")).ToString("n2") & ")", Math.Round(result_arsales))
            End If
            con.Close()
            chartar.Series("ar1").Label = "#PERCENT"
            'chartar.Series("ar1").LegendText = "#VALX (#VAL)"
            chartar.ChartAreas(0).AxisX.Interval = 1
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub postype()
        Try
            chartpostype.Series.Clear()
            chartpostype.Series.Add("postype")
            chartpostype.Titles.Clear()
            chartpostype.Titles.Add("POS Type")
            chartpostype.Series("postype").ChartType = DataVisualization.Charting.SeriesChartType.SplineArea
            chartpostype.Series("postype").IsValueShownAsLabel = True

            Dim total_amtdue As Double = 0.00
            con.Open()
            cmd = New SqlCommand("SELECT ISNULL(COUNT(a.typez),0)  [retail],ISNULL(SUM(a.amtdue),0) [r_amtdue],x.wholesale,x.w_amtdue, xx.coffeeshop,xx.cs_amtdue,xxx.total,xxx.total_amtdue FROM tbltransaction a OUTER APPLY (SELECT ISNULL(COUNT(b.typez),0) [wholesale],ISNULL(SUM(b.amtdue),0) [w_amtdue] FROM tbltransaction b WHERE CAST(b.datecreated AS date)='" & dtdate.Text & "' AND b.status=1 AND b.typez='Wholesale')x OUTER APPLY (SELECT ISNULL(COUNT(c.typez),0) [coffeeshop],ISNULL(SUM(c.amtdue),0)[cs_amtdue] FROM tbltransaction c WHERE CAST(c.datecreated AS date)='" & dtdate.Text & "' AND c.status=1 AND c.typez='Coffee Shop')xx  OUTER APPLY (SELECT ISNULL(COUNT(c.typez),0)[total],ISNULL(SUM(c.amtdue),0)[total_amtdue] FROM tbltransaction c WHERE CAST(c.datecreated AS date)='05/11/2020' AND c.status=1 AND c.typez IN('Retail','Wholesale','Coffee Shop'))xxx WHERE CAST(a.datecreated AS date)='" & dtdate.Text & "' AND a.status=1 AND a.typez='Retail' GROUP BY x.wholesale,xx.coffeeshop,xxx.total,x.w_amtdue,xx.cs_amtdue,xxx.total_amtdue", con)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                Dim result_retail As Double = rdr("retail") / rdr("total") * 100
                Dim result_wholesale As Double = rdr("wholesale") / rdr("total") * 100
                Dim result_coffeeshop As Double = rdr("coffeeshop") / rdr("total") * 100
                chartpostype.Series("postype").Points.AddXY("Retail (" & rdr("r_amtdue") & ")", Math.Round(result_retail))
                chartpostype.Series("postype").Points.AddXY("Wholesale (" & rdr("w_amtdue") & ")", Math.Round(result_wholesale))
                chartpostype.Series("postype").Points.AddXY("Coffee Shop (" & rdr("cs_amtdue") & ")", Math.Round(result_coffeeshop))
                total_amtdue = CDbl(rdr("total_amtdue"))
            End If
            con.Close()
            chartpostype.Series("postype").Label = "#PERCENT"
            chartpostype.Series("postype").LegendText = "POS Type (" & total_amtdue.ToString("n2") & ")"
            chartpostype.ChartAreas(0).AxisX.Interval = 1
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub cmbsales_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbsales.SelectedIndexChanged
        items()
        sales()
        ars()
        postype()
    End Sub

    Private Sub dtdate_ValueChanged(sender As Object, e As EventArgs) Handles dtdate.ValueChanged
        items()
        sales()
        ars()
        postype()
    End Sub

    Private Sub dashboard_hourly_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        dtdate.Text = DateTime.Now
        dtdate.MaxDate = DateTime.Now
        loadSales()
        'items()
        'sales()
        'ars()
    End Sub

    Private Sub dashboard_hourly_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class