Imports AK_POS.connection_class
Public Class items_class
    Dim cc As New connection_class
    Private itemname As String = "", discontinued As Integer = 0, icategory As Integer = 0, category As String = ""
    Public ReadOnly Property getItem() As String
        Get
            Return itemname
        End Get
    End Property
    Public Sub setItem(ByVal value As String)
        itemname = value
    End Sub
    Public ReadOnly Property getDiscontinued() As Integer
        Get
            Return discontinued
        End Get
    End Property
    Public Sub setDiscontinued(ByVal value As Integer)
        discontinued = value
    End Sub
    Public ReadOnly Property getiCategory() As Integer
        Get
            Return icategory
        End Get
    End Property
    Public Sub setICategory(ByVal value As Integer)
        icategory = value
    End Sub
    Public ReadOnly Property getCategory() As String
        Get
            Return category
        End Get
    End Property
    Public Sub setCategory(ByVal value As String)
        category = value
    End Sub
    Public Function loadCategories() As DataTable
        Dim result As New DataTable, adptr As New SqlClient.SqlDataAdapter
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT category FROM vLoadCategories WHERE status=1;", cc.con)
        adptr.SelectCommand = cc.cmd
        adptr.Fill(result)
        cc.con.Close()
        Return result
    End Function
    Public Function loadItems(ByVal offset As Integer, rowsFetch As Integer) As DataTable
        Dim result As New DataTable(), adptr As New SqlClient.SqlDataAdapter
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT * FROM funcLoadItems(@icategory,@category,@itemname,@discontinued," & offset & "," & rowsFetch & ")", cc.con)
        cc.cmd.Parameters.AddWithValue("@icategory", icategory)
        cc.cmd.Parameters.AddWithValue("@category", category)
        cc.cmd.Parameters.AddWithValue("@discontinued", discontinued)
        cc.cmd.Parameters.AddWithValue("@itemname", itemname)
        adptr.SelectCommand = cc.cmd
        adptr.Fill(result)
        cc.con.Close()
        Return result
    End Function
    Public Function countItems() As Integer
        Dim result As Integer
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("Select  dbo.funcCountLoadItems(@icategory,@category,@itemname,@discontinued)", cc.con)
        cc.cmd.Parameters.AddWithValue("@icategory", icategory)
        cc.cmd.Parameters.AddWithValue("@category", category)
        cc.cmd.Parameters.AddWithValue("@discontinued", discontinued)
        cc.cmd.Parameters.AddWithValue("@itemname", itemname)
        result = cc.cmd.ExecuteScalar
        cc.con.Close()
        Return result
    End Function
End Class
