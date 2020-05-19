Imports AK_POS.connection_class
Public Class items_class
    'init classes
    Dim cc As New connection_class
    'init local variables
    Private itemname As String = "", discontinued As Integer = 0, icategory As Integer = 0, category As String = ""
    'get and set
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
    ''' <summary>
    ''' get categories from tblcat
    ''' </summary>
    ''' <returns></returns>
    Public Function loadCategories() As DataTable
        'init result and sql data adapter
        Dim result As New DataTable, adptr As New SqlClient.SqlDataAdapter
        'open connection
        cc.con.Open()
        'syntax
        cc.cmd = New SqlClient.SqlCommand("SELECT category FROM vLoadCategories WHERE status=1;", cc.con)
        'get command
        adptr.SelectCommand = cc.cmd
        'fill result from adapter
        adptr.Fill(result)
        'close connection
        cc.con.Close()
        'return result
        Return result
    End Function
    ''' <summary>
    ''' load items from table-valued functions
    ''' </summary>
    ''' <param name="offset"></param>
    ''' <param name="rowsFetch"></param>
    ''' <returns></returns>
    Public Function loadItems(ByVal offset As Integer, rowsFetch As Integer) As DataTable
        'init result and adapter
        Dim result As New DataTable(), adptr As New SqlClient.SqlDataAdapter
        'open connection
        cc.con.Open()
        'syntax
        cc.cmd = New SqlClient.SqlCommand("SELECT * FROM funcLoadItems(@icategory,@category,@itemname,@discontinued," & offset & "," & rowsFetch & ")", cc.con)
        'assign parameters
        cc.cmd.Parameters.AddWithValue("@icategory", icategory)
        cc.cmd.Parameters.AddWithValue("@category", category)
        cc.cmd.Parameters.AddWithValue("@discontinued", discontinued)
        cc.cmd.Parameters.AddWithValue("@itemname", itemname)
        'get command
        adptr.SelectCommand = cc.cmd
        'fill result from adapter
        adptr.Fill(result)
        'close connection
        cc.con.Close()
        'return result
        Return result
    End Function
    ''' <summary>
    ''' get count of items
    ''' </summary>
    ''' <returns></returns>
    Public Function countItems() As Integer
        'init result
        Dim result As Integer
        'open connection
        cc.con.Open()
        'syntax from scalar-valued function
        cc.cmd = New SqlClient.SqlCommand("Select  dbo.funcCountLoadItems(@icategory,@category,@itemname,@discontinued)", cc.con)
        'assign values
        cc.cmd.Parameters.AddWithValue("@icategory", icategory)
        cc.cmd.Parameters.AddWithValue("@category", category)
        cc.cmd.Parameters.AddWithValue("@discontinued", discontinued)
        cc.cmd.Parameters.AddWithValue("@itemname", itemname)
        'get result
        result = cc.cmd.ExecuteScalar
        'close connection
        cc.con.Close()
        'return result
        Return result
    End Function
End Class
