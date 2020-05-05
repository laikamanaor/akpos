Imports System.Data.SqlClient
Imports AK_POS.connection_class
Public Class inv2
    Dim cc As New connection_class
    Dim con As New SqlConnection(cc.conString)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader

    Public Shared cnfrm As Boolean = False

    ''' <summary>
    ''' return the server date
    ''' </summary>
    ''' <returns></returns>
    Public Function getSystemDate() As DateTime
        Try
            Dim dt As New DateTime()
            con.Open()
            cmd = New SqlCommand("SELECT dbo.getsystemDate()", con)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                dt = CDate(rdr(0).ToString)
            End If
            con.Close()
            Return dt
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Function
    ''' <summary>
    ''' load categories
    ''' </summary>
    Public Sub loadCategories()
        Try
            cmbcategory.Items.Clear()
            cmbcategory.Items.Add("All")
            con.Open()
            cmd = New SqlCommand("SELECT * FROM vgetCategories;", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                cmbcategory.Items.Add(rdr("category"))
            End While
            con.Close()
            cmbcategory_selected()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    ''' <summary>
    ''' check if inventory is verified
    ''' </summary>
    ''' <returns></returns>
    Public Function checkVerify() As Boolean
        Try
            Dim prod_count As Integer = 0, invitems_count As Integer = 0
            con.Open()
            cmd = New SqlCommand("SELECT ISNULL(COUNT(transaction_id),0) FROM tblproduction WHERE inv_id=@invnum AND type='Actual Ending Balance';", con)
            cmd.Parameters.AddWithValue("@invnum", lblinvnum.Text)
            prod_count = cmd.ExecuteScalar()
            con.Close()

            con.Open()
            cmd = New SqlCommand("SELECT ISNULL(COUNT(invid),0) FROM tblinvitems WHERE invnum=@invnum AND totalav !=0;", con)
            cmd.Parameters.AddWithValue("@invnum", lblinvnum.Text)
            invitems_count = cmd.ExecuteScalar()
            con.Close()

            If prod_count = invitems_count Then
                Dim result As Boolean = False
                con.Open()
                cmd = New SqlCommand("SELECT verify FROM tblinvsum WHERE invnum=@invnum;", con)
                cmd.Parameters.AddWithValue("@invnum", lblinvnum.Text)
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    result = IIf(rdr("verify") = 1, False, True)
                End If
                con.Close()

                If result = False Then
                    btnverify.Text = "Verified"
                    Return False
                Else
                    Return True
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Function
    ''' <summary>
    ''' load inventory items
    ''' </summary>
    Public Sub loadInvItems()
        Try
            dgv.Rows.Clear()
            con.Open()
            cmd = New SqlCommand(IIf(rb1.Checked, "SELECT * FROM funcgetInventory(@invnum)", "SELECT * FROM funcgetInventory2(@invnum)"), con)
            cmd.CommandType = CommandType.Text
            cmd.Parameters.AddWithValue("@invnum", lblinvnum.Text)
            rdr = cmd.ExecuteReader
            While rdr.Read
                Dim over_amt As Double = 0.00
                If Not IsDBNull(rdr("over_amt")) Then
                    over_amt = CDbl(rdr("over_amt"))
                End If

                dgv.Rows.Add(rdr("invid"), rdr("itemcode"), rdr("itemname"), rdr("category"), CInt(rdr("begbal")).ToString("N0"), CInt(rdr("produce")).ToString("N0"), rdr("good"), rdr("charge"), CInt(rdr("productionin")).ToString("N0"), CInt(rdr("itemin")).ToString("N0"), CInt(rdr("supin")).ToString("N0"), CInt(rdr("adjustmentin")).ToString("N0"), CInt(rdr("convin")).ToString("N0"), CInt(rdr("totalav")).ToString("N0"), CInt(rdr("transfer")).ToString("N0"), CInt(rdr("ctrout")).ToString("N0"), CInt(rdr("archarge")).ToString("N0"), CInt(rdr("arsales")).ToString("N0"), CInt(rdr("convout")).ToString("N0"), CInt(rdr("pullout")).ToString("N0"), CInt(rdr("endbal")).ToString("N0"), CInt(rdr("actualendbal")).ToString("N0"), CInt(rdr("variance")).ToString("N0"), rdr("shortover"), over_amt, CDbl(rdr("ctrout_amt")).ToString("n2"), CDbl(rdr("archarge_amt")).ToString("n2"), CDbl(rdr("arsales_amt")).ToString("n2"))
                colors()
            End While
            con.Close()

            lblcount.Text = "ITEMS (" & dgv.RowCount & ")"
            lblnodata.Visible = IIf(dgv.RowCount <> 0, False, True)

            btnverify.Enabled = checkVerify()

            amounts()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
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
                archarge_amt += CDbl(dgv.Rows(index).Cells("arsales_amt").Value)
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
            result = cmd.ExecuteScalar()
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
                    cmd = New SqlCommand("UPDATE tblinvsum SET verify=1 WHERE invnum='" & lblinvnum.Text & "';", con)
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
            Dim good As Integer = 4, out As Integer = 14, endbal As Integer = 20
            While good <= 13
                dgv.Item(good, dgv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 255, 128)
                good += 1
            End While
            While out <= 19
                dgv.Item(out, dgv.Rows.Count - 1).Style.BackColor = Color.FromArgb(192, 255, 192)
                out += 1
            End While

            While endbal <= 21
                dgv.Item(endbal, dgv.Rows.Count - 1).Style.BackColor = Color.FromArgb(247, 247, 87)
                endbal += 1
            End While

            If dgv.Rows(dgv.Rows.Count - 1).Cells("variance").Value > 0 Then
                dgv.Item(22, dgv.Rows.Count - 1).Style.ForeColor = Color.Blue
            ElseIf dgv.Rows(dgv.Rows.Count - 1).Cells("variance").Value = 0 Then
                dgv.Item(22, dgv.Rows.Count - 1).Style.ForeColor = Color.Black
            Else
                dgv.Item(22, dgv.Rows.Count - 1).Style.ForeColor = Color.Firebrick
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub inv2_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Try
            dgv.Columns("itemcode").HeaderCell.Style.BackColor = Color.ForestGreen
            dgv.Columns("itemname").HeaderCell.Style.BackColor = Color.ForestGreen


            loadCategories()
            cmbcategory.SelectedIndex = 0

            Dim datee As New Date(), dateResult As Boolean = False
            con.Open()
            cmd = New SqlCommand("SELECT TOP 1 datecreated FROM tblinvsum WHERE verify=0 ORDER BY invnum DESC", con)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                datee = CDate(rdr("datecreated"))
                dateResult = True
            Else
                dateResult = False
            End If
            con.Close()

            If dateResult = False Then
                datee = getSystemDate()
            End If

            dtinvsearch.Text = datee
            dtinvsearch.MaxDate = datee
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim result As Boolean = False, verify As Integer = 0, invdate As New Date(), invnum As String = ""
            con.Open()
            cmd = New SqlCommand("Select TOP 1 verify,invdate,invnum from tblinvsum WHERE area='" & "Sales" & "' order by invsumid DESC", con)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                result = True
                verify = rdr("verify")
                invdate = CDate(rdr("invdate"))
                invnum = CStr(rdr("invnum"))
            End If
            con.Close()

            If verify = 1 Then
                If invdate = getSystemDate.ToString("MM/dd/yyyy") Then
                    MsgBox("Inventory end for this day.", MsgBoxStyle.Critical, "")
                    Me.Cursor = Cursors.Default
                Else
                    MessageBox.Show("Created New Inventory First", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show(invnum)
            End If
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

    Private Sub inv2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class