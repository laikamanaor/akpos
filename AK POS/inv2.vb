Imports System.Data.SqlClient
Imports AK_POS.connection_class
Imports AK_POS.received_class
Imports AK_POS.inventory_class
Public Class inv2
    Dim cc As New connection_class, recc As New received_class(), invc As New inventory_class
    Dim con As New SqlConnection(cc.conString)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader

    Public Shared cnfrm As Boolean = False
    ''' <summary>
    ''' load inventory items
    ''' </summary>
    Public Sub loadInvItems()
        Try
            If cmbinventory.SelectedIndex = 0 Then

                dgv.Columns("salesin").HeaderText = "Transfer from Sales"
                dgv.Columns("salesout").HeaderText = "Transfer to Sales"

                dgv.Columns("itemcode").Visible = True
                dgv.Columns("begbal").Visible = True
                dgv.Columns("produce").Visible = True
                dgv.Columns("good").Visible = True
                dgv.Columns("charge").Visible = True
                dgv.Columns("productionin").Visible = True
                dgv.Columns("branchin").Visible = True
                dgv.Columns("adjustmentin").Visible = True
                dgv.Columns("supin").Visible = True
                dgv.Columns("convin").Visible = True
                dgv.Columns("transfer").Visible = True
                dgv.Columns("pullout2").Visible = True

                dgv.Columns("convout").Visible = True
                dgv.Columns("adjustmentout").Visible = True
                dgv.Columns("actualendbal").Visible = True
                dgv.Columns("variance").Visible = True
                dgv.Columns("shortover").Visible = True
                dgv.Columns("overamt").Visible = True
                Dim result As New DataTable
                invc.invnum = lblinvnum.Text
                result = invc.loadInventory(rb1.Checked)
                dgv.Rows.Clear()
                For Each r0w As DataRow In result.Rows
                    Dim over_amt As Double = 0.00, ctr_amt As Double = 0.00
                    If Not IsDBNull(r0w("over_amt")) Then
                        over_amt = CDbl(r0w("over_amt"))

                    End If
                    If Not IsDBNull(r0w("ctrout_amt")) Then
                        ctr_amt = CDbl(r0w("ctrout_amt"))
                    End If
                    dgv.Rows.Add(r0w("invid"), r0w("itemcode"), r0w("itemname"), r0w("category"), CInt(r0w("begbal")).ToString("N0"), CInt(r0w("produce")).ToString("N0"), r0w("good"), r0w("charge"), CInt(r0w("productionin")).ToString("N0"), CInt(r0w("itemin")).ToString("N0"), CInt(r0w("supin")).ToString("N0"), CInt(r0w("adjustmentin")).ToString("N0"), CInt(r0w("convin")).ToString("N0"), CInt(r0w("salesin")).ToString("N0"), CInt(r0w("totalav")).ToString("N0"), CInt(r0w("transfer")).ToString("N0"), CInt(r0w("pullout2")).ToString("N0"), CInt(r0w("ctrout")).ToString("N0"), CInt(r0w("archarge")).ToString("N0"), CInt(r0w("arsales")).ToString("N0"), CInt(r0w("convout")).ToString("N0"), CInt(r0w("pullout")).ToString("N0"), CInt(r0w("salesout")).ToString("N0"), CInt(r0w("endbal")).ToString("N0"), CInt(r0w("actualendbal")).ToString("N0"), CInt(r0w("variance")).ToString("N0"), r0w("shortover"), over_amt, ctr_amt, CDbl(r0w("archarge_amt")).ToString("n2"), CDbl(r0w("arsales_amt")).ToString("n2"))
                    colors()
                Next
            Else
                dgv.Columns("salesin").HeaderText = "Transfer to Sales"
                dgv.Columns("salesout").HeaderText = "Transfer to Main"

                dgv.Columns("itemcode").Visible = False
                dgv.Columns("begbal").Visible = False
                dgv.Columns("produce").Visible = False
                dgv.Columns("good").Visible = False
                dgv.Columns("charge").Visible = False
                dgv.Columns("productionin").Visible = False
                dgv.Columns("branchin").Visible = False
                dgv.Columns("supin").Visible = False
                dgv.Columns("adjustmentin").Visible = False
                dgv.Columns("convin").Visible = False
                dgv.Columns("transfer").Visible = False
                dgv.Columns("pullout2").Visible = False

                dgv.Columns("convout").Visible = False
                dgv.Columns("adjustmentout").Visible = False
                dgv.Columns("actualendbal").Visible = False
                dgv.Columns("variance").Visible = False
                dgv.Columns("shortover").Visible = False
                dgv.Columns("overamt").Visible = False
                Dim dt As New DataTable()
                dt = invc.getSalesInventory(cmbinventory.Text)
                dgv.Rows.Clear()
                For Each r0w As DataRow In dt.Rows
                    dgv.Rows.Add("N/A", "N/A", r0w("item"), "N/a", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", CInt(r0w("transferToSales")).ToString("N0"), CInt(r0w("transferToSales")).ToString("N0"), "N/A", "N/A", CInt(r0w("counter")).ToString("N0"), CInt(r0w("archarge")).ToString("N0"), CInt(r0w("arsales")).ToString("N0"), "N/A", "N/A", CInt(r0w("transferFromSales")).ToString("N0"), CInt(r0w("endbal")).ToString("N0"), "N/A", "0", "N/A", "0", CDbl(r0w("counter_amt")).ToString("N0"), CDbl(r0w("archarge_amt")).ToString("n2"), CDbl(r0w("arsales_amt")).ToString("n2"))
                    colors()
                Next
            End If
            amounts()
            lblcount.Text = "ITEMS (" & dgv.RowCount & ")"
            lblnodata.Visible = IIf(dgv.RowCount <> 0, False, True)
            invc.invnum = lblinvnum.Text
            btnverify.Enabled = invc.checkVerify(btnverify)
        Catch ex As Exception

        Finally
            con.Close()
        End Try
    End Sub
    ''' <summary>
    ''' it shows the amount of variance,counter out,ar sales, and ar charge
    ''' </summary>
    Public Sub amounts()
        Try
            Dim ctramt_total As Double = 0.00, archarge_amt As Double = 0.00, arsales_amt As Double = 0.00, over_amt As Double = 0.0
            For index As Integer = 0 To dgv.RowCount - 1

                ctramt_total += CDbl(dgv.Rows(index).Cells("ctrout_amt").Value)
                archarge_amt += CDbl(dgv.Rows(index).Cells("archarge_amt").Value)
                arsales_amt += CDbl(dgv.Rows(index).Cells("arsales_amt").Value)
                over_amt += IIf(IsDBNull(CDbl(dgv.Rows(index).Cells("overamt").Value)), 0, CDbl(dgv.Rows(index).Cells("overamt").Value))
                dgv.Rows(index).Cells("ctrout_amt").Style.ForeColor = IIf(CDbl(dgv.Rows(index).Cells("ctrout_amt").Value) > 0, Color.Green, Color.Black)
                dgv.Rows(index).Cells("archarge_amt").Style.ForeColor = IIf(CDbl(dgv.Rows(index).Cells("archarge_amt").Value) > 0, Color.Green, Color.Black)
                dgv.Rows(index).Cells("arsales_amt").Style.ForeColor = IIf(CDbl(dgv.Rows(index).Cells("arsales_amt").Value) > 0, Color.Green, Color.Black)
            Next

            lblcounteramount.Text = ctramt_total.ToString("n2")
            lblarchargeamount.Text = archarge_amt.ToString("n2")
            lblarsalesamount.Text = arsales_amt.ToString("n2")
            lbloveramount.Text = over_amt.ToString("n2")
            lbltotal.Text = CDbl(CDbl(lblcounteramount.Text) + CDbl(lblarchargeamount.Text) + CDbl(lblarsalesamount.Text) + CDbl(lbloveramount.Text)).ToString("n2")
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    ''' <summary>
    ''' returns the value of type like counter out, ar sales, etc...
    ''' </summary>
    ''' <param name="types"></param>
    ''' <param name="itemname"></param>
    ''' <returns></returns>
    Public Function ctramount(ByVal types As Double, ByVal itemname As String) As Double
        Try
            Dim result As Double = 0.00
            con.Open()
            cmd = New SqlCommand("SELECT ISNULL(SUM(a.price *" & types & "),0) FROM tblitems a WHERE itemname='" & itemname & "';", con)
            Result = cmd.ExecuteScalar()
                con.Close()
            Return result
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Function
    ''' <summary>
    ''' return the inventory number depends on date parameter
    ''' </summary>
    ''' <returns></returns>
    Public Function loadInvSum() As String
        Dim result As String = ""
        con.Open()
        cmd = New SqlCommand("SELECT invnum,datecreated FROM tblinvsum WHERE CAST(datecreated AS date)='" & dtinvsearch.Text & "';", con)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            result = rdr("invnum")
            lbldatetime.Text = CDate(rdr("datecreated")).ToString("MM/dd/yyyy hh:mm tt")
        Else
            result = "N/A"
            lbldatetime.Text = "DT_NOTFOUND"
        End If
        con.Close()

        Return result
    End Function

    Private Sub dtinvsearch_ValueChanged(sender As Object, e As EventArgs) Handles dtinvsearch.ValueChanged
        lblinvnum.Text = loadInvSum()
        loadInvItems()
    End Sub

    Private Sub rb1_CheckedChanged(sender As Object, e As EventArgs) Handles rb1.CheckedChanged
        loadInvItems()
    End Sub
    Private Sub rb2_CheckedChanged(sender As Object, e As EventArgs) Handles rb2.CheckedChanged
        loadInvItems()
        btnverify.Enabled = False
    End Sub
    Public Sub cmbcategory_selected()
        Try
            Dim auto As New AutoCompleteStringCollection()
            If cmbcategory.SelectedIndex <> 0 Then
                For index As Integer = 0 To dgv.Rows.Count - 1
                    If cmbcategory.SelectedItem = dgv.Rows(index).Cells("category").Value Then
                        auto.Add(dgv.Rows(index).Cells("itemname").Value)
                    End If
                Next
            Else
                For index As Integer = 0 To dgv.RowCount - 1
                    auto.Add(dgv.Rows(index).Cells("itemname").Value)
                    dgv.Rows(index).Selected = False
                Next
            End If
            txtsearch.AutoCompleteCustomSource = auto
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub cmbcategory_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbcategory.SelectedValueChanged
        cmbcategory_selected()
    End Sub

    Private Sub btnrefresh_Click(sender As Object, e As EventArgs) Handles btnrefresh.Click
        loadInvItems()
    End Sub

    Private Sub btnverify_Click(sender As Object, e As EventArgs) Handles btnverify.Click
        Try
            If Not IsDate(lbldatetime.Text) Then
                MessageBox.Show("No inventory found", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim a As String = MsgBox("WARNING! You are about to end the inventory for " & CDate(lbldatetime.Text).ToString("MM/dd/yyyy") & ". Are you sure you want to verify?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "")
            If a = vbYes Then
                confirm.ShowDialog()
                If cnfrm Then
                    con.Open()
                    cmd = New SqlCommand("UPDATE tblinvsum SET verify=1,datemodified=(SELECT GETDATE()),modifiedby=@username WHERE invnum='" & lblinvnum.Text & "';", con)
                    cmd.Parameters.AddWithValue("@username", login2.username)
                    cmd.ExecuteNonQuery()
                    con.Close()

                    MessageBox.Show("Verified", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    btnverify.Text = "Verified"
                    btnverify.Enabled = False
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Public Sub colors()
        Try
            Dim good As Integer = 4, out As Integer = 15, endbal As Integer = 23
            While good <= 14
                dgv.Item(good, dgv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 255, 128)
                good += 1
            End While
            While out <= 22
                dgv.Item(out, dgv.Rows.Count - 1).Style.BackColor = Color.FromArgb(192, 255, 192)
                out += 1
            End While

            While endbal <= 24
                dgv.Item(endbal, dgv.Rows.Count - 1).Style.BackColor = Color.FromArgb(247, 247, 87)
                endbal += 1
            End While

            If dgv.Rows(dgv.Rows.Count - 1).Cells("variance").Value > 0 Then
                dgv.Item(25, dgv.Rows.Count - 1).Style.ForeColor = Color.Blue
            ElseIf dgv.Rows(dgv.Rows.Count - 1).Cells("variance").Value = 0 Then
                dgv.Item(25, dgv.Rows.Count - 1).Style.ForeColor = Color.Black
            Else
                dgv.Item(25, dgv.Rows.Count - 1).Style.ForeColor = Color.Firebrick
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' load categories to combobox
    ''' </summary>
    Public Sub loadCategories()
        Dim result As New DataTable()
        result = recc.loadCategories()
        cmbcategory.Items.Clear()
        cmbcategory.Items.Add("All")
        For Each r0w As DataRow In result.Rows
            cmbcategory.Items.Add(r0w("result"))
        Next
        cmbcategory.SelectedIndex = 0
    End Sub

    Public Sub loadInventorySales()
        Dim result As New DataTable()
        result = recc.loadHaveOwnStockSalesAgent()
        cmbinventory.Items.Clear()
        cmbinventory.Items.Add("A1 S-FG")
        For Each r0w As DataRow In result.Rows
            cmbinventory.Items.Add(r0w("result"))
        Next
        cmbinventory.SelectedIndex = 0
    End Sub

    Private Sub inv2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cmbinventory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbinventory.SelectedIndexChanged
        loadInvItems()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim user As String = "admin"
        Dim pass As String = "admin"
        Dim servername As String = "DELL,1433"
        Dim dbName As String = "AKPOS"
        Dim fileName As String = "salesInventory"

        Dim rptDoc As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        'rptDoc = New AB_Coffee_Shop
        'Dim strReportPath As String = "\\192.168.30.6\Atlantic Inv\Reports\" & fileName & ".rpt"
        Dim strReportPath As String = My.Application.Info.DirectoryPath & "\" & fileName & ".rpt"
        rptDoc.Load(strReportPath)
        rptDoc.SetDatabaseLogon(user, pass, servername, dbName)
        rptDoc.SetParameterValue("transfer_from", cmbinventory.Text)
        rptDoc.SetParameterValue("inv_date", dtinvsearch.Value)
        'cform_coffeeshop.CrystalReportViewer1.ReportSource = Nothing
        'cform_coffeeshop.CrystalReportViewer1.Refresh()
        cform_coffeeshop.CrystalReportViewer1.ReportSource = rptDoc
        cform_coffeeshop.CrystalReportViewer1.RefreshReport()
        cform_coffeeshop.ShowDialog()
    End Sub

    Private Sub inv2_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Try
            dgv.Columns("itemcode").HeaderCell.Style.BackColor = Color.ForestGreen
            dgv.Columns("itemname").HeaderCell.Style.BackColor = Color.ForestGreen

            loadInventorySales()
            loadCategories()
            cmbcategory.SelectedIndex = 0

            Dim datee As New Date(), dateResult As Boolean = False, systemdate As New Date()
            con.Open()
            cmd = New SqlCommand("SELECT TOP 1 datecreated,(SELECT GETDATE()) systemdate FROM tblinvsum WHERE verify=0 ORDER BY invnum DESC", con)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                datee = CDate(rdr("datecreated"))
                dateResult = True
            Else
                dateResult = False
            End If
            con.Close()

            If dateResult = False Then
                datee = systemdate
            End If

            dtinvsearch.Text = datee
            'dtinvsearch.MaxDate = datee
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        Try
            For index As Integer = 0 To dgv.RowCount - 1
                If txtsearch.Text = dgv.Rows(index).Cells("itemname").Value Then
                    dgv.Rows(index).Selected = True
                    dgv.CurrentCell = dgv.Rows(index).Cells(1)
                Else
                    dgv.Rows(index).Selected = False
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class