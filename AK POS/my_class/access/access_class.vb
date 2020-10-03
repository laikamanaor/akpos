Imports System.Data.SqlClient
Public Class access_class
    Dim transaction As SqlTransaction
    Dim cc As New connection_class
    Public Function insertModule(ByVal username As String, ByVal modulee As String, ByVal status As Integer, ByVal createdBy As String) As Boolean
        Dim result As Boolean = False
        Try
            Using connection As New SqlConnection(cc.conString)
                Dim cmdd As New SqlCommand()
                cmdd.Connection = connection

                connection.Open()
                transaction = connection.BeginTransaction()
                cmdd.Transaction = transaction

                cmdd.Parameters.Clear()
                cmdd.CommandText = "INSERT INTO tblaccess (userid,moduleid,status,createdbyid,datecreated) VALUES ((SELECT systemid FROM tblusers WHERE username=@username),(SELECT id FROM tblmodules WHERE name=@module),@status,(SELECT systemid FROM tblusers WHERE username=@createdby),(SELECT GETDATE()))"
                cmdd.Parameters.Add(New SqlParameter("@username", username))
                cmdd.Parameters.Add(New SqlParameter("@module", modulee))
                cmdd.Parameters.Add(New SqlParameter("@status", status))
                cmdd.Parameters.Add(New SqlParameter("@createdby", createdBy))
                cmdd.ExecuteNonQuery()
                transaction.Commit()
                result = True
            End Using
        Catch ex As Exception
            MessageBox.Show("insertModules() " & ex.ToString)
            Try
                transaction.Rollback()
            Catch ex2 As Exception
                MessageBox.Show("insertModules() " & ex2.ToString)
            End Try
        End Try
        Return result
    End Function

    Public Function checkAccess(ByVal username As String, ByVal modulee As String) As Boolean
        Dim result As Boolean = False, result_int As Integer = 0
        Try
            cc.con.Open()
            cc.cmd = New SqlClient.SqlCommand("SELECT id FROM tblaccess WHERE userid=(SELECT systemid FROM tblusers WHERE username=@username) AND moduleid=(SELECT id FROM tblmodules WHERE name=@module)", cc.con)
            cc.cmd.Parameters.AddWithValue("@username", username)
            cc.cmd.Parameters.AddWithValue("@module", modulee)
            result_int = cc.cmd.ExecuteScalar
            cc.con.Close()
        Catch ex As Exception
            MessageBox.Show("loadModules() " & ex.Message)
        End Try
        result = IIf(result_int <= 0, False, True)
        Return result
    End Function

    Public Function loadAccess(ByVal status as Integer) As DataTable
        Dim result As New DataTable
        Try
            cc.con.Open()
            cc.cmd = New SqlCommand("SELECT a.id,(SELECT name FROM tblmodules WHERE id=a.moduleid) [module],(SELECT username FROM tblusers WHERE systemid=a.userid) [username],a.status FROM tblaccess a WHERE a.status=" & status & ";", cc.con)
            cc.adptr.SelectCommand = cc.cmd
            cc.adptr.Fill(result)
            cc.con.Close()
        Catch ex As Exception
            MessageBox.Show("loadAccess() " & ex.Message)
        End Try
        Return result
    End Function
End Class
