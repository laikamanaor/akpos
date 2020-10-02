Public Class module_class
    Dim cc As New connection_class()
    Public Function loadModules() As DataTable
        Dim result As New DataTable()
        Try
            cc.con.Open()
            cc.cmd = New SqlClient.SqlCommand("SELECT name [result] FROM tblmodules WHERE status = 1 ORDER BY name ASC", cc.con)
            cc.adptr.SelectCommand = cc.cmd
            cc.adptr.Fill(result)
            cc.con.Close()
        Catch ex As Exception
            MessageBox.Show("loadModules() " & ex.Message)
        End Try
        Return result
    End Function
End Class
