Imports System.Data.SqlClient
Imports System.IO
Imports AK_POS.connection_class
Public Class drawerr
    Dim cc As New connection_class
    Dim strconn As String = cc.conString
    Dim con As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader

    Public manager As String = ""

    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function

    Private Sub drawerr_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Me.WindowState = FormWindowState.Maximized
        loadd()
        If manager = "Manager" Then
            btnaddnew.Visible = True
            btncashout.Visible = False
        ElseIf manager = "Cashier" Then
            btnaddnew.Visible = False
            btncashout.Visible = True
        End If
    End Sub
    Public Sub loadd()
        If cmbcashier.SelectedIndex = 0 Or cmbcashier.SelectedItem = "All" Then
            loadLogs("SELECT tblcreditslogs.creditnum,tblcreditslogs.systemid,tblusers.fullname,tblcreditslogs.available,tblcreditslogs.amt,tblcreditslogs.datecreated,tblcreditslogs.processedby,tblcreditslogs.type,ISNULL(description,'') AS description FROM tblcreditslogs JOIN tblusers ON tblusers.systemid = tblcreditslogs.systemid AND CAST(tblcreditslogs.datecreated AS date)='" & dt.Text & "';")
        Else
            loadLogs("SELECT tblcreditslogs.creditnum,tblcreditslogs.systemid,tblusers.fullname,tblcreditslogs.available,tblcreditslogs.amt,tblcreditslogs.datecreated,tblcreditslogs.processedby,tblcreditslogs.type,ISNULL(description,'N/A') AS description FROM tblcreditslogs JOIN tblusers ON tblusers.systemid = tblcreditslogs.systemid AND CAST(tblcreditslogs.datecreated AS date)='" & dt.Text & "' AND tblusers.username='" & cmbcashier.SelectedItem & "';")
        End If
    End Sub
    Public Sub loadLogs(ByVal query As String)
        Try
            dgvlists.Rows.Clear()
            con.Open()
            cmd = New SqlCommand(query, con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                dgvlists.Rows.Add(rdr("creditnum"), rdr("systemid"), rdr("fullname"), CDbl(rdr("available")).ToString("n2"), CDbl(rdr("amt")).ToString("n2"), rdr("description"), CDate(rdr("datecreated")).ToString("MM/dd/yyyy hh:mm tt"), rdr("processedby"), rdr("type"))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub loadCashiers()
        cmbcashier.Items.Clear()
        cmbcashier.Items.Add("All")
        con.Open()
        cmd = New SqlCommand("SELECT username FROM tblusers WHERE workgroup='Cashier' AND status=1 ORDER BY username ASC;", con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            cmbcashier.Items.Add(rdr("username"))
        End While
        con.Close()
        cmbcashier.SelectedIndex = 0
    End Sub
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
    Public Function checkCutOff() As Boolean
        Try
            Dim status As String = "", date_from As New DateTime()
            con.Open()
            cmd = New SqlCommand("SELECT status,date,tblcutoff.userid FROM tblcutoff WHERE userid=(SELECT systemid FROM tblusers WHERE username=@username) ORDER BY cid DESC;", con)
            cmd.Parameters.AddWithValue("@username", login.username)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                status = rdr("status")
                date_from = CDate(rdr("date"))
            End If
            con.Close()
            If status = "In Active" And date_from.ToString("MM/dd/yyyy") = getSystemDate.ToString("MM/dd/yyyy") Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function

    Private Sub btnaddnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaddnew.Click

        Dim frm As New adddrawer()

        frm.lblheader.Text = "ADD"
        frm.Label4.Visible = False
        frm.lblavailable.Visible = False
        frm.ShowDialog()
        loadd()
    End Sub

    Private Sub btnlogs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlogs.Click
        Dim cash As New cashoutlogs()
        cash.ShowDialog()
        loadd()
    End Sub

    Private Sub drawerr_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dim a As String = MsgBox("Are you sure you want to close Lucky Money Form?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "")
        If a = vbYes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub drawerr_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadCashiers()
    End Sub

    Private Sub btncashout_Click(sender As Object, e As EventArgs) Handles btncashout.Click
        Dim frm As New adddrawer()

        frm.lblheader.Text = "CASH OUT"
        frm.Label4.Visible = True
        frm.lblavailable.Visible = True
        frm.ShowDialog()
        loadd()
    End Sub

    Private Sub cmbcashier_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbcashier.SelectedIndexChanged
        loadd()
    End Sub

    Private Sub dgvlists_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvlists.CellDoubleClick
        If dgvlists.CurrentRow.Cells("typee").Value = "Cash Out" Then
            Dim c As New cashoutsap()
            c.creditnum = CStr(dgvlists.CurrentRow.Cells("id").Value)
            c.ShowDialog()
        End If
    End Sub

    Private Sub btncashcount_Click(sender As Object, e As EventArgs) Handles btncashcount.Click

        Dim frm As New adddrawer()

        frm.lblheader.Text = "CASH COUNT"
        frm.Label4.Visible = True
        frm.lblavailable.Visible = True

        frm.ShowDialog()
        loadd()
    End Sub

    Private Sub dt_ValueChanged(sender As Object, e As EventArgs) Handles dt.ValueChanged
        loadd()
    End Sub
End Class