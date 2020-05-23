Imports AK_POS.connection_class
Public Class conversion_class
    Dim cc As New connection_class()
    Private vtype As String = "", vdateParameter As String = "", vcategory As String = "", vitemname As String = "", vrefnum As String = ""
    Public Property typee As String
        Set(value As String)
            vtype = value
        End Set
        Get
            Return vtype
        End Get
    End Property
    Public Property dateParameter As String
        Set(value As String)
            vdateParameter = value
        End Set
        Get
            Return vdateParameter
        End Get
    End Property
    Public Property category As String
        Set(value As String)
            vcategory = value
        End Set
        Get
            Return vcategory
        End Get
    End Property
    Public Property itemname As String
        Set(value As String)
            vitemname = value
        End Set
        Get
            Return vitemname
        End Get
    End Property
    Public Property refnum As String
        Set(value As String)
            vrefnum = value
        End Set
        Get
            Return vrefnum
        End Get
    End Property
    Public Function loadConvOut() As DataTable
        Dim result As New DataTable(), adptr As New SqlClient.SqlDataAdapter
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT * FROM loadConvOut(@type,@date,@category,@itemname)", cc.con)
        cc.cmd.Parameters.AddWithValue("@type", vtype)
        cc.cmd.Parameters.AddWithValue("@date", vdateParameter)
        cc.cmd.Parameters.AddWithValue("@category", vcategory)
        cc.cmd.Parameters.AddWithValue("@itemname", vitemname)
        adptr.SelectCommand = cc.cmd
        adptr.Fill(result)
        cc.con.Close()
        Return result
    End Function

    Public Function loadConvIn() As DataTable
        Dim result As New DataTable(), adptr As New SqlClient.SqlDataAdapter
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT * FROM loadConvIn(@type,@date,@category,@itemname,@ref)", cc.con)
        cc.cmd.Parameters.AddWithValue("@type", vtype)
        cc.cmd.Parameters.AddWithValue("@date", vdateParameter)
        cc.cmd.Parameters.AddWithValue("@category", vcategory)
        cc.cmd.Parameters.AddWithValue("@itemname", vitemname)
        cc.cmd.Parameters.AddWithValue("@ref", vrefnum)
        adptr.SelectCommand = cc.cmd
        adptr.Fill(result)
        cc.con.Close()
        Return result
    End Function

End Class
