Imports System.Data.SqlClient
Imports System.IO
Public Class cashoutlogs
    Dim strconn As String = login.ss
    Dim con As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function

    Public Sub loadCashiers()
        cmbcashier.Items.Clear()
        If login.wrkgrp = "Cashier" Then
            cmbcashier.Items.Add(login.username)
        Else
            cmbcashier.Items.Add("All")
            con.Open()
            cmd = New SqlCommand("SELECT username FROM tblusers WHERE workgroup='Cashier' AND status=1 ORDER BY username ASC;", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                cmbcashier.Items.Add(rdr("username"))
            End While
            con.Close()
        End If
        cmbcashier.SelectedIndex = 0
    End Sub
    Public Sub loadd()
        If cmbcashier.SelectedIndex = 0 Or cmbcashier.SelectedItem = "All" Then
            loadLogs("SELECT tblcreditslogs.creditnum,tblcreditslogs.systemid,tblusers.fullname,tblcreditslogs.amt,tblcreditslogs.datecreated,tblcreditslogs.processedby,tblcreditslogs.type FROM tblcreditslogs JOIN tblusers ON tblusers.systemid = tblcreditslogs.systemid AND CAST(tblcreditslogs.datecreated AS date)='" & dt.Text & "';")
        Else
            loadLogs("SELECT tblcreditslogs.creditnum,tblcreditslogs.systemid,tblusers.fullname,tblcreditslogs.amt,tblcreditslogs.datecreated,tblcreditslogs.processedby,tblcreditslogs.type FROM tblcreditslogs JOIN tblusers ON tblusers.systemid = tblcreditslogs.systemid AND CAST(tblcreditslogs.datecreated AS date)='" & dt.Text & "' AND tblusers.username='" & cmbcashier.SelectedItem & "';")
        End If
    End Sub
    Public Sub loadLogs(ByVal query As String)
        Try
            dgvlists.Rows.Clear()
            con.Open()
            cmd = New SqlCommand(query, con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                dgvlists.Rows.Add(rdr("creditnum"), rdr("systemid"), rdr("fullname"), CDbl(rdr("amt")).ToString("n2"), CDate(rdr("datecreated")).ToString("MM/dd/yyyy hh:mm tt"), rdr("processedby"), rdr("type"))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub dt_ValueChanged(sender As Object, e As EventArgs) Handles dt.ValueChanged
        loadLogs("SELECT tblcreditslogs.creditnum,tblcreditslogs.systemid,tblusers.fullname,tblcreditslogs.amt,tblcreditslogs.datecreated,tblcreditslogs.processedby,tblcreditslogs.type FROM tblcreditslogs JOIN tblusers ON tblusers.systemid = tblcreditslogs.systemid AND CAST(tblcreditslogs.datecreated AS date)='" & dt.Text & "';")
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbcashier.SelectedIndexChanged
        loadd()
    End Sub

    Private Sub cashoutlogs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadCashiers()
    End Sub

    Private Sub dgvlists_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvlists.CellDoubleClick
        If dgvlists.CurrentRow.Cells("typee").Value = "Cash Out" Then
            Dim c As New cashoutsap()
            c.creditnum = CStr(dgvlists.CurrentRow.Cells("id").Value)
            c.ShowDialog()
        End If
    End Sub
End Class