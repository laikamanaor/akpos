Imports AK_POS.connection_class
Public Class customer_class
    Dim cc As New connection_class()
    Private vtype As String = ""
    Public Property typee As String
        Set(value As String)
            vtype = value
        End Set
        Get
            Return vtype
        End Get
    End Property

    Public Function returnName() As DataTable
        Dim result As New DataTable(), adptr As New SqlClient.SqlDataAdapter
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT * FROM funcLoadCustomerEmployee(@type)", cc.con)
        cc.cmd.Parameters.AddWithValue("@type", vtype)
        adptr.SelectCommand = cc.cmd
        adptr.Fill(result)
        cc.con.Close()
        Return result
    End Function
End Class
