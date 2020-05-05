Imports System.Data.SqlClient
Imports System.IO
Public Class importsap
    Dim path As String = ""

    Dim strconn As String = login.ss
    Dim connect As New SqlConnection(strconn)
    Dim command As SqlCommand
    Dim reader As SqlDataReader
    Dim adapter As New SqlDataAdapter

    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub btnbrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbrowse.Click
        Try
            Dim con As System.Data.OleDb.OleDbConnection
            Dim ds As New DataSet
            Dim cmd As System.Data.OleDb.OleDbDataAdapter
            Dim opf As New OpenFileDialog()
            If opf.ShowDialog = Windows.Forms.DialogResult.OK Then
                path = opf.FileName

                con = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" & path & "; Extended Properties=Excel 12.0;")
                con.Open()
                cmd = New System.Data.OleDb.OleDbDataAdapter("SELECT * FROM [OINV$]", con)
                cmd.Fill(ds)
                dgvlists.DataSource = ds.Tables(0)
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub dgvlists_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvlists.CellClick
        Try
            Dim con As System.Data.OleDb.OleDbConnection
            Dim ds As New DataSet
            Dim cmd As System.Data.OleDb.OleDbDataAdapter
            con = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" & path & "; Extended Properties=Excel 12.0;")
            con.Open()
            cmd = New System.Data.OleDb.OleDbDataAdapter("SELECT * FROM [INV1$] WHERE DocNum=" & dgvlists.CurrentRow.Cells(0).Value & ";", con)
            cmd.Fill(ds)
            dgvitems.DataSource = ds.Tables(0)
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btnsubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsubmit.Click
        Try
            Dim con As System.Data.OleDb.OleDbConnection
            Dim adptr As New System.Data.OleDb.OleDbDataAdapter
            Dim cmd As New System.Data.OleDb.OleDbCommand
            Dim dt As New DataTable
            con = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" & path & "; Extended Properties=Excel 12.0;")

            For index As Integer = 0 To dgvlists.Rows.Count - 1
                con.Open()
                cmd = New System.Data.OleDb.OleDbCommand("SELECT *  FROM [OINV$];", con)
                adptr.SelectCommand = cmd
                adptr.Fill(dt)
                con.Close()
                For Each r0w As DataRow In dt.Rows
                    If Not IsDBNull(r0w("#")) Then
                        If r0w("CardCode") = "Received Item" Or r0w("CardCode") = "Transfer Item" Or r0w("CardCode") = "Produce Item" Then
                            connect.Open()
                            command = New SqlCommand("UPDATE tblproduction SET sap_number=@sapno,remarks=@remarks WHERE transaction_number=@trnum ", connect)
                            command.Parameters.AddWithValue("@sapno", r0w("#"))
                            command.Parameters.AddWithValue("@remarks", r0w("Remarks"))
                            command.Parameters.AddWithValue("@trnum", r0w("Comments"))
                            command.ExecuteNonQuery()
                            connect.Close()
                        ElseIf r0w("CardCode") = "AR Charge" Or r0w("CardCode") = "AR Reject" Or r0w("CardCode") = "AR Sales" Or r0w("CardCode") = "Cash Sales" Then
                            connect.Open()
                            command = New SqlCommand("UPDATE tblars1 SET sap_no=@sapno,remarks=@remarks,status='Paid' WHERE transnum=@trnum", connect)
                            command.Parameters.AddWithValue("@sapno", r0w("#"))
                            command.Parameters.AddWithValue("@remarks", r0w("Remarks"))
                            command.Parameters.AddWithValue("@trnum", r0w("Comments"))
                            command.ExecuteNonQuery()
                            connect.Close()
                        ElseIf r0w("CardCode") = "Conversion IN" Or r0w("CardCode") = "Conversion OUT" Then
                            connect.Open()
                            command = New SqlCommand("UPDATE tblconversion SET sap_id=@sapno,remarks=@remarks WHERE conv_number=@trnum ", connect)
                            command.Parameters.AddWithValue("@sapno", r0w("#"))
                            command.Parameters.AddWithValue("@remarks", r0w("Remarks"))
                            command.Parameters.AddWithValue("@trnum", r0w("Comments"))
                            command.ExecuteNonQuery()
                            connect.Close()
                        End If
                    End If
                Next
            Next
            MessageBox.Show("Transaction Completed", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub importsap_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class