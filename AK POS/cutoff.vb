Imports System.Data.SqlClient
Imports System.IO
Imports AK_POS.connection_class
Public Class cutoff
    Dim cc As New connection_class
    Dim con As New SqlConnection(cc.conString)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader

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
            cmd = New SqlCommand("SELECT TOP 1 tblusers.workgroup  FROM tblcutoff JOIN tblusers ON tblcutoff.userid = tblusers.systemid WHERE tblcutoff.status='" & cmbstat.SelectedItem & "' AND tblcutoff.cid=(SELECT TOP 1 cid FROM tblcutoff WHERE CAST(date AS date)=(select cast(getdate() as date)) ORDER BY cid ASC);", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                dgvusers.Rows.Add(rdr("workgroup"))
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
            If e.ColumnIndex = 1 And dgvusers.RowCount <> 0 Then

                If checkPendingOrders() <> 0 Then
                    MessageBox.Show("Confirm all pending orders before cutt off", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                Dim a As String = MsgBox("Are you sure you want to cutoff?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "")
                If a = vbYes Then
                    If dgvusers.CurrentRow.Cells("workgroup").Value = "Sales" Then
                        con.Open()
                        cmd = New SqlCommand("SELECT tblcutoff.userid,tblusers.username FROM tblusers JOIN tblcutoff ON tblcutoff.userid = tblusers.systemid WHERE workgroup='" & "Sales" & "' or workgroup='Cashier';", con)
                        Dim adptr As New SqlDataAdapter()
                        adptr.SelectCommand = cmd
                        Dim dt As New DataTable()
                        adptr.Fill(dt)
                        con.Close()

                        For Each r0w As DataRow In dt.Rows
                            Dim cid As Integer = 0
                            con.Open()
                            cmd = New SqlCommand("SELECT cid,userid FROM tblcutoff WHERE userid='" & r0w("userid") & "' AND status='Active' ORDER BY userid DESC;", con)
                            rdr = cmd.ExecuteReader
                            If rdr.Read Then
                                cid = rdr("cid")
                            End If
                            con.Close()

                            con.Open()
                            cmd = New SqlCommand("UPDATE tblcutoff SET date_cutoff=(SELECT GETDATE()), status='In Active' WHERE cid=@id", con)
                            cmd.Parameters.AddWithValue("@id", cid)
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Next
                    Else
                        con.Open()
                        cmd = New SqlCommand("SELECT tblcutoff.userid,tblusers.username FROM tblusers JOIN tblcutoff ON tblcutoff.userid = tblusers.systemid WHERE workgroup='" & dgvusers.CurrentRow.Cells("workgroup").Value & "';", con)
                        Dim adptr2 As New SqlDataAdapter()
                        adptr2.SelectCommand = cmd
                        Dim dt2 As New DataTable()
                        adptr2.Fill(dt2)
                        con.Close()

                        For Each r0w As DataRow In dt2.Rows
                            Dim cid As Integer = 0
                            con.Open()
                            cmd = New SqlCommand("SELECT cid,userid FROM tblcutoff WHERE userid='" & r0w("userid") & "' AND status='Active' ORDER BY userid DESC;", con)
                            rdr = cmd.ExecuteReader
                            If rdr.Read Then
                                cid = rdr("cid")
                            End If
                            con.Close()

                            con.Open()
                            cmd = New SqlCommand("UPDATE tblcutoff SET date_cutoff=(SELECT GETDATE()), status='In Active' WHERE cid=@id", con)
                            cmd.Parameters.AddWithValue("@id", cid)
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Next
                    End If
                    MessageBox.Show("Transaction Completed", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    loadData()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub cutoff_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If login.wrkgrp = "LC Accounting" Or login.wrkgrp = "Administrator" Then
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