Imports System.Data.SqlClient
Public Class sorttt

    Dim strconn As String = login.ss
    Dim con As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim adptr As New SqlDataAdapter
    Private Sub btnsort_Click(sender As Object, e As EventArgs) Handles btnsort.Click
        Try
            Dim dt1 As New DataTable()
            con.Open()
            cmd = New SqlCommand("SELECT transnum FROM tbltransaction WHERE tendertype='CASH' AND status=1 AND CAST(datecreated AS date)='02/12/2020'", con)
            adptr.SelectCommand = cmd
            adptr.Fill(dt1)
            con.Close()

            Dim dt2 As New DataTable()
            con.Open()
            cmd = New SqlCommand("SELECT transnum FROM tbltransaction2 WHERE tendertype='CASH' AND status=1 AND status2='Paid' AND CAST(datecreated AS date)='02/12/2020'", con)
            adptr.SelectCommand = cmd
            adptr.Fill(dt2)
            con.Close()

            Dim result() As DataRow = Nothing
            For Each r0w As DataRow In dt1.Rows
                result = dt2.Select("transnum='" & r0w("transnum") & "'")
            Next

            DataGridView1.Rows.Clear()
            For Each row As DataRow In result
                DataGridView1.Rows.Add(row(0))
            Next
            MessageBox.Show("donee")
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class