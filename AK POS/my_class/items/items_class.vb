Imports AK_POS.connection_class
Public Class items_class
    'init classes
    Dim cc As New connection_class
    'init local variables
    Private vitemname As String = "", discontinued As Integer = 0, icategory As Integer = 0, category As String = "", vitemid As Integer = 0
    'get and set
    Public Property itemName As String
        Set(value As String)
            vitemname = value
        End Set
        Get
            Return vitemname
        End Get
    End Property
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
    Public Property itemid As Integer
        Set(value As Integer)
            vitemid = value
        End Set
        Get
            Return vitemid
        End Get
    End Property
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
        cc.cmd = New SqlClient.SqlCommand("SELECT category FROM vLoadCategories WHERE status=1 ORDER BY category;", cc.con)
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
        cc.cmd.Parameters.AddWithValue("@itemname", vitemname)
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
        cc.cmd.Parameters.AddWithValue("@itemname", vitemname)
        'get result
        result = cc.cmd.ExecuteScalar
        'close connection
        cc.con.Close()
        'return result
        Return result
    End Function

    ''' <summary>
    ''' load items where itemid
    ''' </summary>
    Public Function loadIemsWhereID() As DataTable
        Dim result As New DataTable(), adptr As New SqlClient.SqlDataAdapter
        'open connection
        cc.con.Open()
        'syntax
        cc.cmd.CommandText = "SELECT a.itemcode, a.itemname, a.category, a.description, a.price, a.deposit, ISNULL((SELECT price FROM tbldepositprice WHERE itemid=a.itemid), 0) [deposit_price] FROM tblitems a WHERE a.itemid= " & vitemid & ";"
        'get command
        adptr.SelectCommand = cc.cmd
        'fil data to datatable
        adptr.Fill(result)
        'close connection
        cc.con.Close()
        'return result
        Return result
    End Function

    ''' <summary>
    ''' check item if exist
    ''' </summary>
    ''' <returns></returns>
    Public Function checkItem(ByVal itemname As String) As Boolean
        'init result
        Dim result As Boolean = False, result_int As Integer = 0
        'open connection
        cc.con.Open()
        'syntax
        cc.cmd.CommandText = "SELECT dbo.checkItemname(@itemname)"
        'assign parameter
        cc.cmd.Parameters.AddWithValue("@itemname", itemname)
        result_int = cc.cmd.ExecuteScalar
        'close connection
        cc.con.Close()
        'assign result depends on expression
        result = IIf(result_int = 0, False, True)
        'return result
        Return result
    End Function

    ''' <summary>
    '''  get latest inventory number
    ''' </summary>
    Public Function getInvID() As String
        'init variable
        Dim id As String = ""
        'open connection
        cc.con.Open()
        'syntax
        cc.cmd = New SqlClient.SqlCommand("Select TOP 1 invnum from tblinvsum WHERE area='Sales' order by invsumid DESC", cc.con)
        id = cc.cmd.ExecuteScalar
        'close connection
        cc.con.Close()
        'return expression
        id = IIf(String.IsNullOrEmpty(Trim(id)), "N/A", id)
        Return id
    End Function
End Class
