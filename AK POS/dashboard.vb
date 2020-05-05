Imports System.Data.SqlClient
Imports System.IO
Public Class dashboard
    Dim strconn As String = login.ss
    Dim con As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader

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
    Private Sub dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
    Public Sub loadYears()
        Try
            cmbmonthlyyear.Items.Clear()
            con.Open()
            cmd = New SqlCommand("SELECT DISTINCT YEAR(datecreated) AS y from tbltransaction JOIN tblars1 ON YEAR(tbltransaction.datecreated) = YEAR(tblars1.date_created) ORDER BY y DESC", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                cmbmonthlyyear.Items.Add(rdr("y").ToString)
            End While
            con.Close()
            If cmbmonthlyyear.Items.Count = 0 Then
                cmbmonthlyyear.Items.Add(DateTime.Now.Year())
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Public Sub loadCashiers(ByVal cmb As ComboBox)
        Try
            cmb.Items.Clear()
            cmb.Items.Add("All")
            If login.wrkgrp = "Sales" Then
                cmb.Items.Add(login.username)
            End If
            con.Open()
            cmd = New SqlCommand("SELECT username FROM tblusers WHERE workgroup='Cashier' AND status=1;", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                cmb.Items.Add(rdr("username"))
            End While
            con.Close()
            cmb.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub dashboard_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        'loadCategory(charthourlycategory, cmbhourly, "Hourly")
        'loadCategory(chartdailycategory, cmbdaily, "Daily")
        'loadSales()
        'loadARS(charthourlycategory, cmbhourly, "Hourly")
        'loadARS(chartdailycategory, cmbdaily, "Daily")
    End Sub
    Public Sub loadItems(ByVal chart As DataVisualization.Charting.Chart, ByVal cmb As ComboBox, tabpage As String)
        Try
            chart.Series.Clear()
            chart.Series.Add("Salary")
            chart.Titles.Clear()
            chart.Titles.Add("TOP 10 ITEMS")
            chart.Series("Salary").Font = New Font("Arial", 10, FontStyle.Bold)
            chart.Series("Salary").LegendText = "Items"
            Dim totalPrice As Double = 0.00, query As String = ""

            If cmb.SelectedIndex = 0 Then
                If tabpage = "Hourly" Then
                    query = "SELECT ISNULL(SUM(tblorder.qty),0) AS qty FROM tbltransaction JOIN tblorder ON tbltransaction.transnum = tblorder.transnum WHERE CAST(datecreated AS date)='" & datehourly.Text & "' AND tbltransaction.area='Sales'"
                ElseIf tabpage = "Daily" Then
                    query = "SELECT ISNULL(SUM(tblorder.qty),0) AS qty FROM tbltransaction JOIN tblorder ON tbltransaction.transnum = tblorder.transnum WHERE CAST(datecreated AS date)>='" & datedaily.Text & "' AND CAST(datecreated AS date)<='" & datedaily2.Text & "' And tbltransaction.area ='Sales'"
                ElseIf tabpage = "Monthly" Then
                    query = "SELECT ISNULL(SUM(tblorder.qty),0) AS qty FROM tbltransaction JOIN tblorder ON tbltransaction.transnum = tblorder.transnum WHERE YEAR(datecreated)='" & cmbmonthlyyear.Text & "' And tbltransaction.area ='Sales'"
                End If
            Else
                If tabpage = "Hourly" Then
                    query = "SELECT ISNULL(SUM(tblorder.qty),0) AS qty FROM tbltransaction JOIN tblorder ON tbltransaction.transnum = tblorder.transnum WHERE CAST(datecreated AS date)='" & datehourly.Text & "' AND cashier='" & cmb.Text & "' AND tbltransaction.area='Sales'"
                ElseIf tabpage = "Daily" Then
                    query = "SELECT ISNULL(SUM(tblorder.qty),0) AS qty FROM tbltransaction JOIN tblorder ON tbltransaction.transnum = tblorder.transnum WHERE CAST(datecreated AS date)>='" & datedaily.Text & "' AND CAST(datecreated AS date)<='" & datedaily2.Text & "' AND tbltransaction.area='Sales'"
                ElseIf tabpage = "Monthly" Then
                    query = "SELECT ISNULL(SUM(tblorder.qty),0) AS qty FROM tbltransaction JOIN tblorder ON tbltransaction.transnum = tblorder.transnum WHERE YEAR(datecreated)='" & cmbmonthlyyear.Text & "' AND tbltransaction.area='Sales'"
                End If
            End If
            query &= " GROUP BY tblorder.itemname ORDER BY qty  DESC OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY"
            con.Open()
            cmd = New SqlCommand(query, con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                totalPrice += rdr("qty")
            End While
            con.Close()
            Dim query2 As String = ""
            If cmb.SelectedIndex = 0 Then
                If tabpage = "Hourly" Then
                    query2 = "SELECT tblorder.itemname, ISNULL(SUM(tblorder.qty),0) AS quantity FROM tbltransaction JOIN tblorder ON tbltransaction.transnum = tblorder.transnum WHERE  CAST(datecreated AS date)='" & datehourly.Text & "' AND tbltransaction.area='Sales'"
                ElseIf tabpage = "Daily" Then
                    query2 = "SELECT tblorder.itemname, ISNULL(SUM(tblorder.qty),0) AS quantity FROM tbltransaction JOIN tblorder ON tbltransaction.transnum = tblorder.transnum WHERE CAST(datecreated AS date)>='" & datedaily.Text & "' AND CAST(datecreated AS date)<='" & datedaily2.Text & "' AND tbltransaction.area='Sales'"
                ElseIf tabpage = "Monthly" Then
                    query2 = "SELECT tblorder.itemname, ISNULL(SUM(tblorder.qty),0) AS quantity FROM tbltransaction JOIN tblorder ON tbltransaction.transnum = tblorder.transnum WHERE YEAR(datecreated)='" & cmbmonthlyyear.Text & "' AND tbltransaction.area='Sales'"
                End If

            Else
                If tabpage = "Hourly" Then
                    query2 = "SELECT tblorder.itemname, ISNULL(SUM(tblorder.qty),0) AS quantity FROM tbltransaction JOIN tblorder ON tbltransaction.transnum = tblorder.transnum WHERE CAST(datecreated AS date)='" & datehourly.Text & "' AND cashier='" & cmb.Text & "' AND tbltransaction.area='Sales'"
                ElseIf tabpage = "Daily" Then
                    query2 = "SELECT tblorder.itemname, ISNULL(SUM(tblorder.qty),0) AS quantity FROM tbltransaction JOIN tblorder ON tbltransaction.transnum = tblorder.transnum WHERE CAST(datecreated AS date)>='" & datedaily.Text & "' AND CAST(datecreated AS date)<='" & datedaily2.Text & "' AND cashier='" & cmb.Text & "' AND tbltransaction.area='Sales'"
                ElseIf tabpage = "Monthly" Then
                    query2 = "SELECT tblorder.itemname, ISNULL(SUM(tblorder.qty),0) AS quantity FROM tbltransaction JOIN tblorder ON tbltransaction.transnum = tblorder.transnum WHERE  YEAR(datecreated)='" & cmbmonthlyyear.Text & "' AND cashier='" & cmb.Text & "' AND tbltransaction.area='Sales'"
                End If
            End If
            query2 &= " GROUP BY tblorder.itemname ORDER BY quantity DESC  OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY"
            con.Open()
            cmd = New SqlCommand(query2, con)
            Dim dt As New DataTable()
            rdr = cmd.ExecuteReader
            While rdr.Read
                Dim result As Double = 0.00
                result = CDbl(rdr("quantity")) / totalPrice * 100
                chart.Series("Salary").Points.AddXY(rdr("itemname") & " " & result.ToString("n2") & "%", result)
            End While
            con.Close()
            chart.ChartAreas(0).AxisX.Interval = 1
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Public Sub loadCategory(ByVal chart As DataVisualization.Charting.Chart, ByVal cmb As ComboBox, tabpage As String)
        Try
            chart.Series.Clear()
            chart.Titles.Clear()
            chart.Series.Add("typez")

            chart.Titles.Add("POS TYPE")
            chart.Series("typez").ChartType = DataVisualization.Charting.SeriesChartType.Pie
            chart.Series("typez").IsValueShownAsLabel = True
            Dim totalPrice As Double = 0.00, query As String = "", query2 As String = ""
            If cmb.SelectedIndex = 0 Then
                If tabpage = "Hourly" Then
                    query = "SELECT ISNULL(COUNT(tbltransaction.transid),0) AS qty FROM tbltransaction JOIN tblorder ON tbltransaction.transnum = tblorder.transnum WHERE CAST(datecreated AS date)='" & datehourly.Text & "' AND tbltransaction.area='Sales'"
                ElseIf tabpage = "Daily" Then
                    query = "SELECT ISNULL(COUNT(tbltransaction.transid),0) AS qty FROM tbltransaction JOIN tblorder ON tbltransaction.transnum = tblorder.transnum WHERE CAST(datecreated AS date)>='" & datedaily.Text & "' AND CAST(datecreated AS date)<='" & datedaily2.Text & "' And tbltransaction.area ='Sales'"
                ElseIf tabpage = "Monthly" Then
                    query = "SELECT ISNULL(COUNT(tbltransaction.transid),0) AS qty FROM tbltransaction JOIN tblorder ON tbltransaction.transnum = tblorder.transnum WHERE YEAR(datecreated)='" & cmbmonthlyyear.Text & "' And tbltransaction.area ='Sales'"
                End If
            Else
                If tabpage = "Hourly" Then
                    query = "SELECT ISNULL(COUNT(tbltransaction.transid),0) AS qty FROM tbltransaction JOIN tblorder ON tbltransaction.transnum = tblorder.transnum WHERE CAST(datecreated AS date)='" & datehourly.Text & "' AND cashier='" & cmb.Text & "' AND tbltransaction.area='Sales'"
                ElseIf tabpage = "Daily" Then
                    query = "SELECT ISNULL(COUNT(tbltransaction.transid),0) AS qty FROM tbltransaction JOIN tblorder ON tbltransaction.transnum = tblorder.transnum WHERE CAST(datecreated AS date)>='" & datedaily.Text & "' AND CAST(datecreated AS date)<='" & datedaily2.Text & "' AND tbltransaction.area='Sales'"
                ElseIf tabpage = "Monthly" Then
                    query = "SELECT ISNULL(COUNT(tbltransaction.transid),0) AS qty FROM tbltransaction JOIN tblorder ON tbltransaction.transnum = tblorder.transnum WHERE YEAR(datecreated)='" & cmbmonthlyyear.Text & "' AND tbltransaction.area='Sales'"
                End If
            End If
            query &= " GROUP BY tbltransaction.typez ORDER BY qty DESC OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY"
            con.Open()
            cmd = New SqlCommand(query, con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                totalPrice += rdr("qty")
            End While
            con.Close()
            If cmb.SelectedIndex = 0 Then
                If tabpage = "Hourly" Then
                    query2 = "SELECT tbltransaction.typez, ISNULL(COUNT(tbltransaction.transid),0) AS quantity FROM tbltransaction JOIN tblorder ON tbltransaction.transnum = tblorder.transnum WHERE CAST(datecreated AS date)='" & datehourly.Text & "' AND tbltransaction.area='Sales'"
                ElseIf tabpage = "Daily" Then
                    query2 = "SELECT tbltransaction.typez, ISNULL(COUNT(tbltransaction.transid),0) AS quantity FROM tbltransaction JOIN tblorder ON tbltransaction.transnum = tblorder.transnum WHERE CAST(datecreated AS date)>='" & datedaily.Text & "' AND CAST(datecreated AS date)<='" & datedaily2.Text & "' AND tbltransaction.area='Sales'"
                ElseIf tabpage = "Monthly" Then
                    query2 = "SELECT tbltransaction.typez, ISNULL(COUNT(tbltransaction.transid),0) AS quantity FROM tbltransaction JOIN tblorder ON tbltransaction.transnum = tblorder.transnum WHERE YEAR(datecreated)='" & cmbmonthlyyear.Text & "' AND tbltransaction.area='Sales'"
                End If

            Else
                If tabpage = "Hourly" Then
                    query2 = "SELECT tbltransaction.typez, ISNULL(COUNT(tbltransaction.transid),0) AS quantity FROM tbltransaction JOIN tblorder ON tbltransaction.transnum = tblorder.transnum WHERE CAST(datecreated AS date)='" & datehourly.Text & "' AND cashier='" & cmb.Text & "' AND tbltransaction.area='Sales'"
                ElseIf tabpage = "Daily" Then
                    query2 = "SELECT tbltransaction.typez, ISNULL(COUNT(tbltransaction.transid),0) AS quantity FROM tbltransaction JOIN tblorder ON tbltransaction.transnum = tblorder.transnum WHERE CAST(datecreated AS date)>='" & datedaily.Text & "' AND CAST(datecreated AS date)<='" & datedaily2.Text & "' AND cashier='" & cmb.Text & "' AND tbltransaction.area='Sales'"
                ElseIf tabpage = "Monthly" Then
                    query2 = "SELECT tbltransaction.typez, ISNULL(COUNT(tbltransaction.transid),0) AS quantity FROM tbltransaction JOIN tblorder ON tbltransaction.transnum = tblorder.transnum WHERE  YEAR(datecreated)='" & cmbmonthlyyear.Text & "' AND cashier='" & cmb.Text & "' AND tbltransaction.area='Sales'"
                End If
            End If
            query2 &= " GROUP BY tbltransaction.typez ORDER BY quantity DESC OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY"
            con.Open()
            cmd = New SqlCommand(query2, con)
            Dim dt As New DataTable()
            rdr = cmd.ExecuteReader
            While rdr.Read
                Dim result As Double = 0.00
                result = CDbl(rdr("quantity"))
                chart.Series("typez").Points.AddXY(rdr("typez"), result)
            End While
            con.Close()
            chart.Series("typez").Label = "#PERCENT"
            chart.Series("typez").LegendText = "#VALX (#VAL)"
            'chart.ChartAreas(0).Area3DStyle.Enable3D = True
            chart.ChartAreas(0).AxisX.Interval = 1
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Public Sub loadSales(ByVal chart As DataVisualization.Charting.Chart, ByVal cmb As ComboBox, tabpage As String, ByVal tin As DateTime, ByVal tout As DateTime)
        Try
            chart.Series.Clear()
            chart.Titles.Clear()
            chart.Titles.Add("SALES")
            chart.Series.Add("sales")
            chart.Series("sales").ChartType = DataVisualization.Charting.SeriesChartType.Bar
            chart.Series("sales").LegendText = "SALES"

            Dim totalPrice As Double = 0.00, query As String = "", query2 As String = ""
            If cmb.SelectedIndex = 0 Then
                If tabpage = "Hourly" Then
                    query = "SELECT ISNULL(SUM(tbltransaction.amtdue),0) FROM tbltransaction WHERE CAST(datecreated AS date)='" & datehourly.Value.ToString("MM/dd/yyyy") & "'  AND area='Sales';"
                ElseIf tabpage = "Daily" Then
                    query = "SELECT ISNULL(SUM(tbltransaction.amtdue),0) FROM tbltransaction WHERE CAST(datecreated AS date)>='" & datedaily.Value.ToString("MM/dd/yyyy") & "' AND CAST(datecreated AS date)<='" & datedaily2.Value.ToString("MM/dd/yyyy") & "' AND area='Sales';"
                ElseIf tabpage = "Monthly" Then
                    query = "SELECT ISNULL(SUM(tbltransaction.amtdue),0) FROM tbltransaction WHERE YEAR(datecreated)='" & cmbmonthlyyear.Text & "' AND area='Sales';"
                End If
            Else
                If tabpage = "Hourly" Then
                    query = "SELECT ISNULL(SUM(tbltransaction.amtdue),0) FROM tbltransaction WHERE CAST(datecreated AS date)='" & datehourly.Value.ToString("MM/dd/yyyy") & "' AND cashier='" & cmb.Text & "'  AND area='Sales';"
                ElseIf tabpage = "Daily" Then
                    query = "SELECT ISNULL(SUM(tbltransaction.amtdue),0) FROM tbltransaction WHERE CAST(datecreated AS date)>='" & datedaily.Value.ToString("MM/dd/yyyy") & "' AND CAST(datecreated AS date)<='" & datedaily2.Value.ToString("MM/dd/yyyy") & "' AND cashier='" & cmb.Text & "'  AND area='Sales';"
                ElseIf tabpage = "Monthly" Then
                    query = "SELECT ISNULL(SUM(tbltransaction.amtdue),0) FROM tbltransaction WHERE YEAR(datecreated)='" & cmbmonthlyyear.Text & "' AND cashier='" & cmb.Text & "'  AND area='Sales';"
                End If
            End If
            con.Open()
            cmd = New SqlCommand(query, con)
            totalPrice = cmd.ExecuteScalar()
            con.Close()
            Dim result As Double = 0.00
            While tin <= tout

                If cmb.SelectedIndex = 0 Then
                    If tabpage = "Hourly" Then
                        query2 = "SELECT ISNULL(SUM(amtdue),0)  FROM tbltransaction WHERE datecreated BETWEEN '" & tin & "' AND  '" & tin.AddMinutes(59) & "'  AND area='Sales';"
                    ElseIf tabpage = "Daily" Then
                        query2 = "SELECT ISNULL(SUM(amtdue),0)  FROM tbltransaction WHERE datecreated BETWEEN '" & tin.ToString("MM/dd/yyyy") & "' AND  '" & tin.AddDays(1).ToString("MM/dd/yyyy") & "'  AND area='Sales';"
                    ElseIf tabpage = "Monthly" Then
                        query2 = "SELECT ISNULL(SUM(amtdue),0)  FROM tbltransaction WHERE datecreated BETWEEN '" & tin.ToString("MM/dd/yyyy") & "' AND  '" & tin.AddMonths(1).ToString("MM/dd/yyyy") & "'  AND area='Sales';"
                    End If
                Else
                    If tabpage = "Hourly" Then
                        query2 = "SELECT ISNULL(SUM(amtdue),0)  FROM tbltransaction WHERE datecreated BETWEEN '" & tin & "' AND  '" & tin.AddMinutes(59) & "' AND cashier='" & cmb.Text & "'  AND area='Sales';"
                    ElseIf tabpage = "Daily" Then
                        query2 = "SELECT ISNULL(SUM(amtdue),0)  FROM tbltransaction WHERE datecreated BETWEEN '" & tin.ToString("MM/dd/yyyy") & "' AND  '" & tin.AddDays(1).ToString("MM/dd/yyyy") & "' AND cashier='" & cmb.Text & "'  AND area='Sales';"
                    ElseIf tabpage = "Monthly" Then
                        query2 = "SELECT ISNULL(SUM(amtdue),0)  FROM tbltransaction WHERE datecreated BETWEEN '" & tin.ToString("MM/dd/yyyy") & "' AND  '" & tin.AddMonths(1).ToString("MM/dd/yyyy") & "' AND cashier='" & cmb.Text & "'  AND area='Sales';"
                    End If
                End If

                con.Open()
                cmd = New SqlCommand(query2, con)
                result = cmd.ExecuteScalar()
                con.Close()

                result = result / totalPrice * 100
                result = result

                If tabpage = "Hourly" Then
                    chart.Series("sales").Points.AddXY(tin.ToString("hh:mm tt") & " - " & tin.AddMinutes(59).ToString("hh:mm tt") & " " & result.ToString("n2") & "%", result.ToString("n2"))
                    tin = tin.AddMinutes(60)
                ElseIf tabpage = "Daily" Then
                    chart.Series("sales").Points.AddXY(tin.ToString("MM/dd/yyyy") & " " & result.ToString("n2") & "%", result.ToString("n2"))
                    tin = tin.AddDays(1)
                ElseIf tabpage = "Monthly" Then
                    chart.Series("sales").Points.AddXY(MonthName(tin.Month()) & " " & result.ToString("n2") & "%", result.ToString("n2"))
                    tin = tin.AddMonths(1)
                End If
            End While

            chart.ChartAreas(0).AxisX.Interval = 1
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Public Sub loadARS(ByVal chart As DataVisualization.Charting.Chart, ByVal cmb As ComboBox, tabpage As String)
        Try

            chart.Series.Clear()
            chart.Series.Add("ar1")
            chart.Titles.Clear()
            chart.Titles.Add("A.R")
            chart.Series("ar1").ChartType = DataVisualization.Charting.SeriesChartType.Pie
            chart.Series("ar1").IsValueShownAsLabel = True


            chart.Series("ar1").Points.AddXY("AR Cash", res("AR Cash", tabpage, cmb, "s").ToString("n2"))
            chart.Series("ar1").Points.AddXY("AR Charge", res("AR Charge", tabpage, cmb, "s")).ToString("n2")
            chart.Series("ar1").Points.AddXY("AR Sales", res("AR Sales", tabpage, cmb, "s")).ToString("n2")
            chart.Series("ar1").Label = "#PERCENT"
            chart.Series("ar1").LegendText = "#VALX (#VAL)"
            chart.ChartAreas(0).AxisX.Interval = 1
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Public Function res(ty As String, ByVal tabpage As String, cmb As ComboBox, ByVal s As String) As Double
        Try

            Dim totalPrice As Double = 0.00, query As String = "", query2 As String = "", r As Double = 0.00
            If cmb.SelectedIndex = 0 Then
                If tabpage = "Hourly" Then
                    query = "SELECT ISNULL(SUM(amountdue),0) FROM tblars1  WHERE CAST(date_created AS date)= '" & datehourly.Value.ToString("MM/dd/yyyy") & "'  AND area='Sales';"
                ElseIf tabpage = "Daily" Then
                    query = "SELECT ISNULL(SUM(amountdue),0) FROM tblars1  WHERE CAST(date_created AS date)>= '" & datedaily.Value.ToString("MM/dd/yyyy") & "' AND CAST(date_created AS date)<= '" & datedaily2.Value.ToString("MM/dd/yyyy") & "'  AND area='Sales';"
                ElseIf tabpage = "Monthly" Then
                    query = "SELECT ISNULL(SUM(amountdue),0) FROM tblars1  WHERE YEAR(date_created)='" & cmbmonthlyyear.Text & "'  AND area='Sales';"
                End If
            Else
                If tabpage = "Hourly" Then
                    query = "SELECT ISNULL(SUM(amountdue),0) FROM tblars1  WHERE CAST(date_created AS date)= '" & datehourly.Value.ToString("MM/dd/yyyy") & "' AND created_by='" & cmb.Text & "'  AND area='Sales';"
                ElseIf tabpage = "Daily" Then
                    query = "SELECT ISNULL(SUM(amountdue),0) FROM tblars1  WHERE CAST(date_created AS date)>= '" & datedaily.Value.ToString("MM/dd/yyyy") & "' AND CAST(date_created AS date)<= '" & datedaily2.Value.ToString("MM/dd/yyyy") & "' AND created_by='" & cmb.Text & "'  AND area='Sales';"
                ElseIf tabpage = "Monthly" Then
                    query = "SELECT ISNULL(SUM(amountdue),0) FROM tblars1  WHERE YEAR(date_created)='" & cmbmonthlyyear.Text & "'  AND created_by='" & cmb.Text & "'  AND area='Sales';"
                End If

            End If
            con.Open()
            cmd = New SqlCommand(query, con)
            totalPrice = cmd.ExecuteScalar()
            con.Close()

            If cmb.SelectedIndex = 0 Then
                If tabpage = "Hourly" Then
                    query2 = "SELECT ISNULL(SUM(amountdue),0) FROM tblars1 WHERE CAST(date_created AS date)= '" & datehourly.Value.ToString("MM/dd/yyyy") & "' AND type='" & ty & "'  AND area='Sales';"
                ElseIf tabpage = "Daily" Then
                    query2 = "SELECT ISNULL(SUM(amountdue),0) FROM tblars1 WHERE CAST(date_created AS date)>= '" & datedaily.Value.ToString("MM/dd/yyyy") & "' AND CAST(date_created AS date)<= '" & datedaily2.Value.ToString("MM/dd/yyyy") & "' AND type='" & ty & "'  AND area='Sales';"
                ElseIf tabpage = "Monthly" Then
                    query2 = "SELECT ISNULL(SUM(amountdue),0) FROM tblars1 WHERE YEAR(date_created)='" & cmbmonthlyyear.Text & "' AND type='" & ty & "'  AND area='Sales';"
                End If

            Else
                If tabpage = "Hourly" Then
                    query2 = "SELECT ISNULL(SUM(amountdue),0) FROM tblars1 WHERE CAST(date_created AS date)<= '" & datehourly.Value.ToString("MM/dd/yyyy") & "' AND type='" & ty & "' AND created_by='" & cmb.Text & "'  AND area='Sales';"
                ElseIf tabpage = "Daily" Then
                    query2 = "SELECT ISNULL(SUM(amountdue),0) FROM tblars1 WHERE CAST(date_created AS date)>= '" & datedaily.Value.ToString("MM/dd/yyyy") & "' AND CAST(date_created AS date)<= '" & datedaily2.Value.ToString("MM/dd/yyyy") & "' AND type='" & ty & "' AND created_by='" & cmb.Text & "'  AND area='Sales';"
                ElseIf tabpage = "Monthly" Then
                    query2 = "SELECT ISNULL(SUM(amountdue),0) FROM tblars1 WHERE YEAR(date_created)='" & cmbmonthlyyear.Text & "'  AND type='" & ty & "' AND created_by='" & cmb.Text & "'  AND area='Sales';"
                End If
            End If

            con.Open()
            cmd = New SqlCommand(query2, con)
            r = cmd.ExecuteScalar()
            con.Close()
            If s = "" Then
                Return r / totalPrice * 100
            Else
                Return r
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Function
    Private Sub datehourly_ValueChanged(sender As Object, e As EventArgs) Handles datehourly.ValueChanged
        Try
            loadItems(charthourlyitems, cmbhourly, "Hourly")
            Dim timeIn As New DateTime(datehourly.Value.Year, datehourly.Value.Month, datehourly.Value.Day, 0, 0, 0)
            Dim timeOut As New DateTime(datehourly.Value.Year, datehourly.Value.Month, datehourly.Value.Day, 23, 0, 0)
            loadSales(charthourlysales, cmbhourly, "Hourly", timeIn, timeOut)
            loadCategory(charthourlycategory, cmbhourly, "Hourly")
            loadARS(charthourlyar, cmbhourly, "Hourly")
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub cmbhourly_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbhourly.SelectedIndexChanged
        loadItems(charthourlyitems, cmbhourly, "Hourly")
        loadCategory(charthourlycategory, cmbhourly, "Hourly")
        Dim timeIn As New DateTime(datehourly.Value.Year, datehourly.Value.Month, datehourly.Value.Day, 0, 0, 0)
        Dim timeOut As New DateTime(datehourly.Value.Year, datehourly.Value.Month, datehourly.Value.Day, 23, 0, 0)
        loadSales(charthourlysales, cmbhourly, "Hourly", timeIn, timeOut)
        loadARS(charthourlyar, cmbhourly, "Hourly")
    End Sub

    Private Sub charthourlyitems_Click(sender As Object, e As EventArgs) Handles charthourlyitems.Click

    End Sub

    Private Sub datedaily_ValueChanged(sender As Object, e As EventArgs) Handles datedaily.ValueChanged
        'loadItems(chartdailyitems, cmbdaily, "Daily")
        'loadCategory(chartdailycategory, cmbdaily, "Daily")
        'loadARS(chartdailyar, cmbdaily, "Daily")

        'Dim timeIn As New DateTime(datedaily.Value.Year, datedaily.Value.Month, datedaily.Value.Day)
        'Dim timeOut As New DateTime(datedaily2.Value.Year, datedaily2.Value.Month, datedaily2.Value.Day)
        'loadSales(chartdailysales, cmbdaily, "Daily", timeIn, timeOut)
    End Sub

    Private Sub datedaily2_ValueChanged(sender As Object, e As EventArgs) Handles datedaily2.ValueChanged
        'loadItems(chartdailyitems, cmbdaily, "Daily")
        'loadCategory(chartdailycategory, cmbdaily, "Daily")
        'loadARS(chartdailyar, cmbdaily, "Daily")

        'Dim timeIn As New DateTime(datedaily.Value.Year, datedaily.Value.Month, datedaily.Value.Day)
        'Dim timeOut As New DateTime(datedaily2.Value.Year, datedaily2.Value.Month, datedaily2.Value.Day)
        'loadSales(chartdailysales, cmbdaily, "Daily", timeIn, timeOut)
    End Sub

    Private Sub cmbdaily_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbdaily.SelectedIndexChanged
        'loadItems(chartdailyitems, cmbdaily, "Daily")
        'loadCategory(chartdailycategory, cmbdaily, "Daily")
        'loadARS(chartdailyar, cmbdaily, "Daily")

        'Dim timeIn As New DateTime(datedaily.Value.Year, datedaily.Value.Month, datedaily.Value.Day)
        'Dim timeOut As New DateTime(datedaily2.Value.Year, datedaily2.Value.Month, datedaily2.Value.Day)
        'loadSales(chartdailysales, cmbdaily, "Daily", timeIn, timeOut)
    End Sub

    Private Sub cmbmonthlyyear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbmonthlyyear.SelectedIndexChanged
        'loadItems(chartmonthlyitems, cmbmonthly, "Monthly")
        'loadCategory(chartmonthlycategory, cmbmonthly, "Monthly")
        'loadARS(chartmonthlyar, cmbmonthly, "Monthly")

        'Dim timeIn As New DateTime(CInt(cmbmonthlyyear.Text), 1, 1)
        'Dim timeOut As New DateTime(CInt(cmbmonthlyyear.Text), 12, 1)
        'loadSales(chartmonthlysales, cmbmonthly, "Monthly", timeIn, timeOut)
    End Sub

    Private Sub cmbmonthly_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbmonthly.SelectedIndexChanged
        'loadItems(chartmonthlyitems, cmbmonthly, "Monthly")
        'loadCategory(chartmonthlycategory, cmbmonthly, "Monthly")
        'loadARS(chartmonthlyar, cmbmonthly, "Monthly")
        'Dim timeIn As New DateTime(CInt(cmbmonthlyyear.Text), 1, 1)
        'Dim timeOut As New DateTime(CInt(cmbmonthlyyear.Text), 12, 1)
        'loadSales(chartmonthlysales, cmbmonthly, "Monthly", timeIn, timeOut)
    End Sub

    Private Sub dashboard_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        loadYears()
        cmbmonthlyyear.SelectedIndex = 0

        datehourly.MaxDate = getSystemDate()
        datehourly.Text = getSystemDate().ToString("MM/dd/yyyy")
        datedaily.MaxDate = getSystemDate()
        datedaily.Text = getSystemDate.ToString("MM/dd/yyyy")
        datedaily2.MaxDate = getSystemDate()
        datedaily2.Text = getSystemDate().ToString("MM/dd/yyyy")

        loadCashiers(cmbhourly)
        loadCashiers(cmbdaily)
        loadCashiers(cmbmonthly)
    End Sub
End Class