Imports System.Data.SqlClient
Imports System.IO
Public Class dashboard_hourly

    Dim strconn As String = login.ss
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
                chartar.Series("ar1").Points.AddXY("A.R Cash", Math.Round(result_arcash))
                chartar.Series("ar1").Points.AddXY("A.R Charge", Math.Round(result_archarge))
                chartar.Series("ar1").Points.AddXY("A.R Sales", Math.Round(result_arsales))
            End If
            con.Close()
            chartar.Series("ar1").Label = "#PERCENT"
            chartar.Series("ar1").LegendText = "#VALX (#VAL)"
            chartar.ChartAreas(0).AxisX.Interval = 1
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub posType()
        Try
            chartar.Series.Clear()
            chartar.Series.Add("ar1")
            chartar.Titles.Clear()
            chartar.Titles.Add("A.R")
            chartar.Series("ar1").ChartType = DataVisualization.Charting.SeriesChartType.SplineArea
            chartar.Series("ar1").IsValueShownAsLabel = True
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
    End Sub

    Private Sub dtdate_ValueChanged(sender As Object, e As EventArgs) Handles dtdate.ValueChanged
        items()
        sales()
        ars()
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