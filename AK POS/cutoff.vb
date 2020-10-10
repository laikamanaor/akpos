Imports System.Data.SqlClient
Imports System.IO
Imports AK_POS.connection_class
Public Class cutoff
    Dim cc As New connection_class
    Dim con As New SqlConnection(cc.conString)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader

    Dim invc As New inventory_class()

    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub
    Public Sub loadData()
        Try
            dgvusers.Rows.Clear()
            con.Open()
            cmd = New SqlCommand("SELECT DISTINCT b.workgroup,CAST(a.date AS date)[date]  FROM tblcutoff a INNER JOIN tblusers b ON a.userid = b.systemid WHERE CAST(a.date AS date)=(SELECT TOP 1 CAST(datecreated AS date) FROM tblinvsum WHERE verify=0 AND b.workgroup='Sales' AND a.status='Active' ORDER BY invsumid ASC);", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                dgvusers.Rows.Add(rdr("workgroup"), rdr("date"))
            End While
            con.Close()

            If cmbstat.SelectedItem = "Active" Then
                dgvusers.Columns("btncutoff").Visible = True
                dgvusers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            ElseIf cmbstat.SelectedItem = "In Active" Then
                dgvusers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                dgvusers.Columns("btncutoff").Visible = False
            End If

            If dgvusers.RowCount = 0 Then
                lblerror.Visible = True
            Else
                lblerror.Visible = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub cutoff_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        loadData()
    End Sub
    Public Function getSystemDate() As DateTime
        Try
            Dim dt As New DateTime()
            con.Open()
            cmd = New SqlCommand("SELECT dbo.getSystemDate()", con)
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

    Public Function checkPendingOrders() As Integer
        Try
            Dim serverDate As String = getSystemDate.ToString("MM/dd/yyyy")
            Dim result As Double = 0.00
            con.Open()
            cmd = New SqlCommand("SELECT COUNT(*) FROM tbltransaction2 WHERE CAST(datecreated AS date)='" & serverDate & "' AND status2='Unpaid';", con)
            result = cmd.ExecuteScalar()
            con.Close()
            Return result
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function

    Private Sub dgvusers_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvusers.CellContentClick
        Try
            If e.ColumnIndex = 2 And dgvusers.RowCount <> 0 Then
                Dim dtSalesInventory As New DataTable()
                dtSalesInventory = invc.getSalesInventory("", invc.getLatestInventoryDate())
                Dim endBal As Double = 0.00
                If dtSalesInventory.Rows.Count > 0 Then
                    For Each r0w As DataRow In dtSalesInventory.Rows
                        endBal = endBal + r0w("endbal")
                    Next
                End If
                If checkPendingOrders() <> 0 Then
                    MessageBox.Show("Confirm all pending orders before Cut Off", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ElseIf endBal > 0 Then
                    MessageBox.Show("Transfer all Sales Inventory to Main before Cut Off", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    Dim a As String = MsgBox("Are you sure you want to cutoff?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "")
                    If a = vbYes Then
                        For i As Integer = 0 To dgvusers.Rows.Count - 1
                            con.Open()
                            cmd = New SqlCommand("UPDATE tblcutoff SET date_cutoff=(SELECT GETDATE()), status='In Active' WHERE CAST(date AS date)=@date", con)
                            cmd.Parameters.AddWithValue("@date", dgvusers.Rows(i).Cells("datee").Value)
                        cmd.ExecuteNonQuery()
                            con.Close()
                        Next
                        MessageBox.Show("Your request has been granted", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        loadData()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub cutoff_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If login2.wrkgrp = "LC Accounting" Or login2.wrkgrp = "Administrator" Then
            btnremove.Visible = True
        Else
            btnremove.Visible = False
        End If
        cmbstat.SelectedIndex = 0
    End Sub

    Private Sub cmbstat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbstat.SelectedIndexChanged
        loadData()
    End Sub

    Private Sub btnremove_Click(sender As Object, e As EventArgs) Handles btnremove.Click
        Try
            Dim serverDate As String = getSystemDate.ToString("MM/dd/yyyy")
            con.Open()
            cmd = New SqlCommand("UPDATE tblcutoff SET status='Active' WHERE CAST(date AS date)=@date;", con)
            cmd.Parameters.AddWithValue("@date", serverDate)
            cmd.ExecuteNonQuery()
            con.Close()

            MessageBox.Show("Cut Off removed", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
            loadData()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class