Imports System.Data.SqlClient
Public Class heyy

    Dim strconn As String = login.ss
    Dim con As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim adptr As New SqlDataAdapter
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            Dim transnum As Integer = 3797, temp As String = "0"

            con.Open()
            cmd = New SqlCommand("SELECT transid FROM tbltransaction WHERE transnum='TR - A1 - 0003797' ORDER BY transid ASC;", con)
            Dim dt As New DataTable()
            adptr.SelectCommand = cmd
            adptr.Fill(dt)
            con.Close()
            For Each r0w As DataRow In dt.Rows
                transnum += 1
                'If transnum < 1000000 Then
                '    Dim cselectcount_result As String = CStr(transnum)
                '    For vv As Integer = 1 To 6 - cselectcount_result.Length
                '        temp += "0"
                '    Next
                '    transnum = temp & transnum
                'End If
                Dim tbltransaction2_orderid As Integer = 0
                con.Open()
                cmd = New SqlCommand("SELECT TOP 1 orderid FROM tbltransaction2 WHERE transnum='TR - A1 - 0003797' ORDER BY orderid ASC;", con)
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    tbltransaction2_orderid = CInt(rdr("orderid"))
                End If
                con.Close()

                con.Open()
                cmd = New SqlCommand("UPDATE tbltransaction2 SET transnum=@transnum2 WHERE orderid=@od", con)
                cmd.Parameters.AddWithValue("@transnum2", "TR - A1 - 00" & transnum)
                cmd.Parameters.AddWithValue("@od", tbltransaction2_orderid)
                cmd.ExecuteNonQuery()
                con.Close()

                con.Open()
                cmd = New SqlCommand("UPDATE tbltransaction SET transnum=@transnum WHERE transid=@trid", con)
                cmd.Parameters.AddWithValue("@transnum", "TR - A1 - 00" & transnum)
                cmd.Parameters.AddWithValue("@trid", r0w("transid"))
                cmd.ExecuteNonQuery()
                con.Close()

                Dim tblorder_orderid As Integer = 0
                con.Open()
                cmd = New SqlCommand("SELECT TOP 1 orderid FROM tblorder WHERE transnum='TR - A1 - 0003797' ORDER BY orderid ASC;", con)
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    tblorder_orderid = CInt(rdr("orderid"))
                End If
                con.Close()

                con.Open()
                cmd = New SqlCommand("UPDATE tblorder SET transnum=@transnum3 WHERE orderid=@orderid", con)
                cmd.Parameters.AddWithValue("@transnum3", "TR - A1 - 00" & transnum)
                cmd.Parameters.AddWithValue("@orderid", tblorder_orderid)
                cmd.ExecuteNonQuery()
                con.Close()

            Next
            con.Open()
            cmd = New SqlCommand("SELECT transid FROM tbltransaction WHERE transnum='TR - A1 - 0003798' ORDER BY transid ASC;", con)
            Dim dt2 As New DataTable()
            adptr.SelectCommand = cmd
            adptr.Fill(dt2)
            con.Close()
            For Each r0w As DataRow In dt2.Rows
                transnum += 1
                'If transnum < 1000000 Then
                '    Dim cselectcount_result As String = CStr(transnum)
                '    For vv As Integer = 1 To 6 - cselectcount_result.Length
                '        temp += "0"
                '    Next
                '    transnum = temp & transnum
                'End If
                Dim tbltransaction2_orderid As Integer = 0
                con.Open()
                cmd = New SqlCommand("SELECT TOP 1 orderid FROM tbltransaction2 WHERE transnum='TR - A1 - 0003798' ORDER BY orderid ASC;", con)
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    tbltransaction2_orderid = CInt(rdr("orderid"))
                End If
                con.Close()

                con.Open()
                cmd = New SqlCommand("UPDATE tbltransaction2 SET transnum=@transnum2 WHERE orderid=@od", con)
                cmd.Parameters.AddWithValue("@transnum2", "TR - A1 - 00" & transnum)
                cmd.Parameters.AddWithValue("@od", tbltransaction2_orderid)
                cmd.ExecuteNonQuery()
                con.Close()

                con.Open()
                cmd = New SqlCommand("UPDATE tbltransaction SET transnum=@transnum WHERE transid=@trid", con)
                cmd.Parameters.AddWithValue("@transnum", "TR - A1 - 00" & transnum)
                cmd.Parameters.AddWithValue("@trid", r0w("transid"))
                cmd.ExecuteNonQuery()
                con.Close()

                Dim tblorder_orderid As Integer = 0
                con.Open()
                cmd = New SqlCommand("SELECT TOP 1 orderid FROM tblorder WHERE transnum='TR - A1 - 0003798' ORDER BY orderid ASC;", con)
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    tblorder_orderid = CInt(rdr("orderid"))
                End If
                con.Close()

                con.Open()
                cmd = New SqlCommand("UPDATE tblorder SET transnum=@transnum3 WHERE orderid=@orderid", con)
                cmd.Parameters.AddWithValue("@transnum3", "TR - A1 - 00" & transnum)
                cmd.Parameters.AddWithValue("@orderid", tblorder_orderid)
                cmd.ExecuteNonQuery()
                con.Close()

            Next
            MessageBox.Show("Completed", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class