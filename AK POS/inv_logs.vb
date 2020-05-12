Imports System.Data.SqlClient
Imports System.IO
Imports AK_POS.connection_class
Public Class inv_logs
    Dim cc As New connection_class
    Dim strconn As String = cc.conString
    Dim con As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim adptr As New SqlDataAdapter

    Public manager As String = ""
    Dim getCurrentModule As String = ""
    Dim z As String = ""

    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function

    Private Sub btnReceivedItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReceivedItem.Click
        home()
        'loadtofrom()
    End Sub
    Public Sub home()
        lbltype.Text = "#:"
        If manager = "Production" Then
            load_data("Produce Item", "")
            dgvData.Columns("transferto").Visible = False
            dgvData.Columns("transferfrom").Visible = False
            dgvData.Columns("transferto").HeaderText = "To"
            dgvData.Columns("transferfrom").HeaderText = "From"
            dgvData.Columns("printreceipt").Visible = False
        Else
            load_data("Received Item", "")
            dgvData.Columns("transferto").Visible = True
            dgvData.Columns("transferfrom").Visible = True
            dgvData.Columns("transferto").HeaderText = "To"
            dgvData.Columns("transferfrom").HeaderText = "From"
            dgvData.Columns("printreceipt").Visible = False
        End If
        btnReceivedItem.ForeColor = Color.Black
        btnPullOut.ForeColor = Color.White
        btnTransfer.ForeColor = Color.White
        btnActualEndingBalance.ForeColor = Color.White
        btnobb.ForeColor = Color.White
        dgvData.Columns("reject").Visible = True
        dgvData.Columns("charge").Visible = True
        dgvData.Columns("quantity").HeaderText = "Good"
        dgvData.Columns("transferfrom").Visible = False
        dgvData.Columns("transferto").Visible = False
        clear_all()
    End Sub
    Public Sub load_data(ByVal q As String, ByVal cat As String)
        Try
            dgvData.Rows.Clear()
            Dim auto As New AutoCompleteStringCollection()
            con.Open()
            Dim query As String = ""
            If cat = "" Then
                'Dim workgroup As String = ""
                'If q = "Adjustment Item" Then
                '    workgroup = "Sales"
                'Else
                '    workgroup = manager
                'End If
                query = "SELECT transaction_number, inv_id,item_code,item_name,category,quantity,date,type,area,type,area,transfer_to,transfer_from,reject,charge,processed_by FROM tblproduction WHERE type='" & q & "' AND area='" & manager & "'"
            ElseIf cat = "" And q = "Transfer Item" Then
                query = "SELECT transaction_number, inv_id,item_code,item_name,category,quantity,date,type,area,type,area,transfer_to,transfer_from,reject,charge,processed_by FROM tblproduction WHERE type='" & q & "' AND area='" & manager & "'"
            ElseIf cat <> "" And q = "Tran" Then
            ElseIf q = "Adjustment Item" Then
                query = "SELECT transaction_number, inv_id,item_code,item_name,category,quantity,date,type,area,transfer_to,transfer_from,reject,charge,processed_by FROM tblproduction WHERE type='" & q & "' AND area='" & manager & "'" & cat
            Else
                query = "SELECT transaction_number, inv_id,item_code,item_name,category,quantity,date,type,area,transfer_to,transfer_from,reject,charge,processed_by FROM tblproduction WHERE type='" & q & "' AND area='" & manager & "'" & cat
            End If

            If txtboxSearch.Text <> "" Then
                query &= " AND item_name=@itemname"
            End If

            'query &= " ORDER BY transaction_id ASC"
            query &= " AND CAST(date AS date)>='" & dtFrom.Text & "' AND CAST(date AS date)<='" & dtFrom.Text & "' AND status !='Cancelled';"
            TextBox1.Text = query
            cmd = New SqlCommand(query, con)

            If txtboxSearch.Text <> "" Then
                cmd.Parameters.AddWithValue("@itemname", txtboxSearch.Text)
            End If

            rdr = cmd.ExecuteReader()
            While rdr.Read()
                Dim s As String = "", d As String = ""
                If rdr("area").ToString = "" Then
                    s = "N/A"
                Else
                    s = rdr("area")
                End If
                dgvData.Rows.Add(rdr("transaction_number"), rdr("inv_id"), rdr("item_code"), rdr("item_name"), rdr("category"), rdr("quantity"), rdr("reject"), rdr("charge"), rdr("transfer_from"), rdr("transfer_to"), rdr("processed_by"), CDate(rdr("date")).ToString("hh:mm tt"), rdr("type"), s)
                auto.Add(rdr("transaction_number"))
                auto.Add(rdr("inv_id"))
                auto.Add(rdr("item_code"))
                auto.Add(rdr("item_name"))
            End While
            con.Close()
            txtboxSearch.AutoCompleteCustomSource = auto
            If dgvData.Rows.Count = 0 Then
                lblError.Visible = True
            Else
                lblError.Visible = False
            End If
            lbltotal.Text = "TOTAL: " & dgvData.Rows.Count.ToString
            getCurrentModule = q
            z = query
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub clear_all()
        lblSAPNo.Text = "N/A"
        lblRemarks.Text = "N/A"
        lbltransnum.Text = "N/A"
        categories()
        cmbCategory.SelectedIndex = cmbCategory.Items.IndexOf("All")
        txtboxSearch.Text = ""
        PictureBox1.Image = My.Resources.not_available
    End Sub
    Public Sub categories()
        cmbCategory.Items.Clear()

        con.Open()
        cmd = New SqlCommand("Select category from tblcat where status='1' order by category", con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            cmbCategory.Items.Add(rdr("category"))
        End While
        con.Close()
        If cmbCategory.Items.Count <> 0 Then
            cmbCategory.Items.Add("All")
        End If
    End Sub
    'Public Sub loadtofrom()
    '    cmbreceived.Items.Clear()
    '    Dim x As String = "", dem As String = ""
    '    If getCurrentModule = "Received Item" Or getCurrentModule = "Produce Item" Then
    '        x = "transfer_from"
    '    Else
    '        x = "transfer_to"
    '    End If
    '    dem = z
    '    ''Dim c As String = dem.Substring(204).Replace(dem.Substring(204), "")
    '    Dim f As String = dem.Replace(dem.Substring(7, 130), "DISTINCT " & x & " ")
    '    'Dim c As String = f.Substring(0, 96).Replace(f.Substring(94), "")
    '    'MessageBox.Show(c)
    '    con.Open()
    '    cmd = New SqlCommand(f, con)
    '    rdr = cmd.ExecuteReader
    '    While rdr.Read
    '        cmbreceived.Items.Add(rdr(x))
    '    End While
    '    con.Close()
    'End Sub
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
    Private Sub inv_logs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If manager = "Production" Then
            btnReceivedItem.Text = "Produce Item"
            dgvData.Columns("reject").Visible = True
        Else
            btnReceivedItem.Text = "Received Item"
            dgvData.Columns("reject").Visible = False
        End If
        dtFrom.Value = getSystemDate()
        dtTo.Value = getSystemDate()
        btnReceivedItem.PerformClick()
    End Sub
    Private Sub btnPullOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPullOut.Click
        load_data("Adjustment Out Item", "")
        btnPullOut.ForeColor = Color.Black
        btnReceivedItem.ForeColor = Color.White
        btnTransfer.ForeColor = Color.White
        btnActualEndingBalance.ForeColor = Color.White
        btnobb.ForeColor = Color.White

        dgvData.Columns("transferto").Visible = False
        dgvData.Columns("transferfrom").Visible = False
        dgvData.Columns("printreceipt").Visible = False
        dgvData.Columns("quantity").HeaderText = "Quantity"
        dgvData.Columns("charge").Visible = False
        dgvData.Columns("reject").Visible = False

        clear_all()
    End Sub

    Private Sub btnTransfer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransfer.Click
        load_data("Transfer Item", "")
        lbltype.Text = "#:"
        btnTransfer.ForeColor = Color.Black
        btnReceivedItem.ForeColor = Color.White
        btnPullOut.ForeColor = Color.White
        btnActualEndingBalance.ForeColor = Color.White
        btnobb.ForeColor = Color.White
        clear_all()
        dgvData.Columns("transferto").Visible = True
        dgvData.Columns("transferfrom").Visible = True
        dgvData.Columns("quantity").HeaderText = "Quantity"
        dgvData.Columns("reject").Visible = False
        dgvData.Columns("charge").Visible = False
        dgvData.Columns("transferto").HeaderText = "To"
        dgvData.Columns("transferfrom").HeaderText = "From"
        dgvData.Columns("transferfrom").Visible = True
        dgvData.Columns("transferto").Visible = True
        dgvData.Columns("printreceipt").Visible = False
        'loadtofrom()
    End Sub

    Private Sub btnActualEndingBalance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualEndingBalance.Click
        load_data("Actual Ending Balance", "")
        btnActualEndingBalance.ForeColor = Color.Black
        btnReceivedItem.ForeColor = Color.White
        btnPullOut.ForeColor = Color.White
        btnTransfer.ForeColor = Color.White
        btnobb.ForeColor = Color.White
        clear_all()
        dgvData.Columns("transferto").Visible = False
        dgvData.Columns("transferfrom").Visible = False
        dgvData.Columns("reject").Visible = False
        dgvData.Columns("printreceipt").Visible = False
        dgvData.Columns("quantity").HeaderText = "Quantity"
        dgvData.Columns("charge").Visible = True
        'loadtofrom()
    End Sub

    Private Sub dgvData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvData.CellContentClick, dgvData.CellClick
        If e.ColumnIndex = 14 Then
            'Dim dt As New DataTable
            'With dt
            '    .Columns.Add("itemcode")
            '    .Columns.Add("itemname")
            '    .Columns.Add("category")
            '    .Columns.Add("quantity")
            'End With

            'con.Open()
            'cmd = New SqlCommand("SELECT item_code,item_name,category,quantity FROM tblproduction WHERE transaction_number=@transnum", con)
            'cmd.Parameters.AddWithValue("@transnum", dgvData.CurrentRow.Cells("transnum").Value)
            'rdr = cmd.ExecuteReader
            'While rdr.Read
            '    dt.Rows.Add(rdr("item_code"), rdr("item_name"), rdr("category"), rdr("quantity"))
            'End While
            'con.Close()
            ''For Each row As DataGridViewRow In dgvSelectedItem.Rows
            ''    dt.Rows.Add(row.Cells("itemcodee").Value, row.Cells("itemnamee").Value, row.Cells("categoryy").Value, row.Cells("quantityy").Value)
            ''Next
            'Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
            'rptDoc = New cr_transfer
            'rptDoc.SetDataSource(dt)

            'rptDoc.SetParameterValue("copy", "REPRINT")
            'rptDoc.SetParameterValue("transnum", dgvData.CurrentRow.Cells("transnum").Value)
            'rptDoc.SetParameterValue("date_printed", "Date Printed: " & getSystemDate.ToString("MM/dd/yyyy hh:mm:ss tt"))
            'rptDoc.SetParameterValue("date_processed", dgvData.CurrentRow.Cells("datee").Value)
            'rptDoc.SetParameterValue("sending_to", dgvData.CurrentRow.Cells("transferto").Value)
            'rptDoc.SetParameterValue("sending_from", dgvData.CurrentRow.Cells("transferfrom").Value)
            'con.Open()
            'cmd = New SqlCommand("SELECT fullname FROM tblusers WHERE username=@username;", con)
            'cmd.Parameters.AddWithValue("@username", login.username)
            'rdr = cmd.ExecuteReader()
            'If rdr.Read Then
            '    rptDoc.SetParameterValue("processed_by", rdr("fullname"))
            'End If
            'con.Close()
            'cform_transfer.CrystalReportViewer1.ReportSource = rptDoc
            'cform_transfer.ShowDialog()
            'cform_transfer.Dispose()
        Else
            con.Open()
            cmd = New SqlCommand("SELECT sap_number, remarks,from_transnum,attachment,typenum FROM tblproduction WHERE transaction_number=@num AND area='" & If(btnobb.ForeColor = Color.Black, "Sales", manager) & "'", con)
            cmd.Parameters.AddWithValue("@num", dgvData.CurrentRow.Cells("transnum").Value)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                If Not IsDBNull(rdr("sap_number")) Then
                    lblSAPNo.Text = rdr("sap_number")
                Else
                    lblSAPNo.Text = ""
                End If
                If Not IsDBNull(rdr("remarks")) Then
                    lblRemarks.Text = rdr("remarks")
                Else
                    lblRemarks.Text = ""
                End If
                If Not IsDBNull(rdr("typenum")) Then
                    lbltype.Text = rdr("typenum") & " #:"
                Else
                    lbltype.Text = "N/A"
                End If
                If Not IsDBNull(rdr("from_transnum")) Then
                    lbltransnum.Text = rdr("from_transnum")
                Else
                    lbltransnum.Text = ""
                End If
                If Not IsDBNull(rdr("attachment")) Then
                    Dim img() As Byte
                    img = rdr("attachment")
                    Dim ms As New MemoryStream(img)
                    PictureBox1.Image = Image.FromStream(ms)
                Else
                    PictureBox1.Image = My.Resources.not_available
                End If
            Else
                con.Close()
                clear_all()
            End If
            con.Close()
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        load_data(getCurrentModule, "")
        'con.Open()
        'cmd = New SqlCommand("SELECT transaction_number,inv_id,item_code,item_name,category,quantity,reject,charge,transfer_from,transfer_to,processed_by,date,type,area FROM tblproduction WHERE item_name=@search AND area='" & manager & "' ", con)
        'cmd.Parameters.AddWithValue("@search", txtboxSearch.Text)
        'rdr = cmd.ExecuteReader()

        'dgvData.Rows.Clear()

        'While rdr.Read
        '    MessageBox.Show("whaat")
        '    dgvData.Rows.Add(rdr("transaction_number"), rdr("inv_id"), rdr("item_code"), rdr("item_name"), rdr("category"), rdr("quantity"), rdr("reject"), rdr("charge"), rdr("transfer_from"), rdr("transfer_to"), rdr("processed_by"), rdr("date"), rdr("type"), rdr("area"))
        'End While

        con.Close()
    End Sub
    'Public Function getSystemDate() As DateTime
    '    Try
    '        Dim dt As New DateTime()
    '        con.Open()
    '        cmd = New SqlCommand("SELECT GETDATE()", con)
    '        rdr = cmd.ExecuteReader()
    '        While rdr.Read
    '            dt = CDate(rdr(0).ToString)
    '        End While
    '        con.Close()
    '        Return dt
    '    Catch ex As Exception
    '        MessageBox.Show(ex.ToString)
    '    Finally
    '        con.Close()
    '    End Try
    'End Function
    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        dtFrom.Text = getSystemDate().ToString("MM/dd/yyyy")
        dtTo.Text = getSystemDate().ToString("MM/dd/yyyy")
        load_data(getCurrentModule, "")
        clear_all()
    End Sub

    Private Sub cmbCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCategory.SelectedIndexChanged
        If cmbCategory.Text = "All" Then
            load_data(getCurrentModule, "")
        Else
            load_data(getCurrentModule, " AND category='" & cmbCategory.Text & "' AND area='" & If(btnobb.ForeColor = Color.Black, "Sales", manager) & "'")
        End If
        dtFrom.Value = getSystemDate()
        dtTo.Value = getSystemDate()
        lblRemarks.Text = "N/A"
        lblSAPNo.Text = "N/A"
    End Sub

    Private Sub btnSearchDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchDate.Click
        cmbCategory.Text = "All"
        load_data(getCurrentModule, " AND area='" & If(btnobb.ForeColor = Color.Black, "Sales", manager) & "'")
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If dgvData.Rows.Count = 0 Then
            MessageBox.Show("No data to print", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            Dim cform As New cform_invlogs()
            cform.typez = dgvData.Rows(0).Cells("type").Value
            If dtFrom.Text = dtTo.Text Then
                cform.datez = dtFrom.Text
            Else
                cform.datez = dtFrom.Text & " - " & dtTo.Text
            End If
            cform.query = z
            cform.ShowDialog()
        End If
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        pictures.PictureBox1.Image = PictureBox1.Image
        pictures.ShowDialog()
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub cmbreceived_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbreceived.SelectedValueChanged
        Dim x As String = "", w As String = ""
        If getCurrentModule = "Received Item" Or getCurrentModule = "Produce Item" Then
            x = "transfer_from"
        Else
            x = "transfer_to"
        End If
        load_data(getCurrentModule, " AND " & x & "='" & cmbreceived.Text & "' AND area='" & manager & "'")

        'dtFrom.Value = DateTime.Now.AddDays(-1)
        'dtTo.Value = DateTime.Now
        lblRemarks.Text = "N/A"
        lblSAPNo.Text = "N/A"
    End Sub

    Private Sub cmbreceived_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbreceived.SelectedIndexChanged

    End Sub

    Private Sub inv_logs_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        dtFrom.Value = getSystemDate()
        dtTo.Value = getSystemDate()
        btnReceivedItem.PerformClick()
        'loadtofrom()

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub

    Private Sub btnobb_Click(sender As Object, e As EventArgs) Handles btnobb.Click
        load_data("Adjustment Item", "")
        btnobb.ForeColor = Color.Black
        btnActualEndingBalance.ForeColor = Color.White
        btnReceivedItem.ForeColor = Color.White
        btnPullOut.ForeColor = Color.White
        btnTransfer.ForeColor = Color.White
        btnPullOut.ForeColor = Color.White
        dgvData.Columns("transferto").Visible = False
        dgvData.Columns("transferfrom").Visible = False
        dgvData.Columns("printreceipt").Visible = False
        dgvData.Columns("quantity").HeaderText = "Quantity"
        dgvData.Columns("charge").Visible = False
        dgvData.Columns("reject").Visible = False
        clear_all()
    End Sub

    Private Sub dtFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtFrom.ValueChanged
        cmbCategory.Text = "All"
        load_data(getCurrentModule, " AND area='" & If(btnobb.ForeColor = Color.Black, "Sales", manager) & "'")
    End Sub
End Class