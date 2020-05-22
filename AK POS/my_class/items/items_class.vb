Imports AK_POS.connection_class
Imports System.Data.SqlClient
Public Class items_class
    'init classes
    Dim cc As New connection_class, transaction As SqlTransaction, rdr As SqlDataReader
    'init local variables
    Private vitemname As String = "", discontinued As Integer = 0, icategory As Integer = 0, category As String = "", vitemid As Integer = 0, vstatus As Integer = 0, vitemcode As String = "", vdescription As String = "", vprice As Double = 0.00, vchck As Boolean = False, vdepositprice As Double = 0.00
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
    Public Property status As Integer
        Set(value As Integer)
            vstatus = value
        End Set
        Get
            Return vstatus
        End Get
    End Property
    Public Property itemcode As String
        Set(value As String)
            vitemcode = value
        End Set
        Get
            Return vitemcode
        End Get
    End Property
    Public Property description As String
        Set(value As String)
            vdescription = value
        End Set
        Get
            Return vdescription
        End Get
    End Property
    Public Property price As Double
        Set(value As Double)
            vprice = value
        End Set
        Get
            Return vprice
        End Get
    End Property
    Public Property chck As Boolean
        Set(value As Boolean)
            vchck = value
        End Set
        Get
            Return vchck
        End Get
    End Property
    Public Property depositPrice As Double
        Set(value As Double)
            vdepositprice = value
        End Set
        Get
            Return vdepositprice
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
        cc.cmd.Parameters.Clear()
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

    ''' <summary>
    ''' add to inventory
    ''' </summary>
    Public Sub addInventory()
        Try
            'init variables
            Dim result As Boolean = False
            'create new connection
            Using connection As New SqlConnection(cc.conString)
                'init command
                Dim cmdd As New SqlCommand()
                'open connection
                cmdd.Connection = connection
                connection.Open()
                'begin sql transaction
                transaction = connection.BeginTransaction()
                cmdd.Transaction = transaction

                'clear parameters first
                cmdd.Parameters.Clear()
                'procedure name for updating discontinued status
                cmdd.CommandText = "updateDiscontinued"
                'command type
                cmdd.CommandType = CommandType.StoredProcedure
                'assign parameters
                cmdd.Parameters.AddWithValue("@itemid", vitemid)
                cmdd.Parameters.AddWithValue("@discontinued", discontinued)
                'execute query
                cmdd.ExecuteNonQuery()

                'clear parameters first
                cmdd.Parameters.Clear()
                'command syntax
                cmdd.CommandText = "SELECT invid FROM tblinvitems WHERE invnum=(Select TOP 1 invnum from tblinvsum WHERE area='Sales' order by invsumid DESC) AND itemname=@itemname;"
                'command type
                cmdd.CommandType = CommandType.Text
                'command parameters
                cmdd.Parameters.AddWithValue("@itemname", vitemname)
                'read command
                rdr = cmdd.ExecuteReader
                'return result depends on expression
                If rdr.Read Then
                    result = True
                Else
                    result = False
                End If
                rdr.Close()
                'close read

                'check if result is true
                If result Then
                    'clear parameters
                    cmdd.Parameters.Clear()
                    'procedure name
                    cmdd.CommandText = "updateInvStatus"
                    'command type
                    cmdd.CommandType = CommandType.StoredProcedure
                    'assign parameters
                    cmdd.Parameters.AddWithValue("@itemname", vitemname)
                    'cmdd.Parameters.AddWithValue("@status", IIf(chck.Checked = True, 1, 0))
                    cmdd.Parameters.AddWithValue("@status", vstatus)
                    'execute query
                    cmdd.ExecuteNonQuery()
                Else
                    'clear parameters first
                    cmdd.Parameters.Clear()
                    'procedure name
                    cmdd.CommandText = "insertContinueInvitems"
                    'command type
                    cmdd.CommandType = CommandType.StoredProcedure
                    'assign parameters
                    cmdd.Parameters.AddWithValue("@itemid", vitemid)
                    'execute query
                    cmdd.ExecuteNonQuery()
                End If
                'commit query
                transaction.Commit()
            End Using
        Catch ex As Exception
            'msg error
            MessageBox.Show(ex.ToString)
            Try
                'not updating items when have error(s)
                transaction.Rollback()
            Catch ex2 As Exception
                'sql msg error
                MessageBox.Show(ex2.ToString)
            End Try
        End Try
    End Sub

    Public Sub addItem()
        Try
            'create new connection
            Using connection As New SqlConnection(cc.conString)
                'init command
                Dim cmdd As New SqlCommand()
                'open connection
                cmdd.Connection = connection
                connection.Open()
                'begin transaction
                transaction = connection.BeginTransaction()
                cmdd.Transaction = transaction

                'clear parameter first
                cmdd.Parameters.Clear()
                'syntax
                cmdd.CommandText = "insertItem"
                cmdd.CommandType = CommandType.StoredProcedure
                'assign parameters
                cmdd.Parameters.AddWithValue("@category", category)
                cmdd.Parameters.AddWithValue("@itemcode", vitemcode)
                cmdd.Parameters.AddWithValue("@itemname", vitemname)
                cmdd.Parameters.AddWithValue("@description", vdescription)
                cmdd.Parameters.AddWithValue("@price", vprice)
                cmdd.Parameters.AddWithValue("@createdby", login2.username)
                cmdd.Parameters.AddWithValue("@deposit", IIf(vchck, 1, 0))
                'execute query
                cmdd.ExecuteNonQuery()
                'check if checkbox is checked
                If vchck Then
                    'clear parameters first
                    cmdd.Parameters.Clear()
                    'command syntax
                    cmdd.CommandText = "insertDepositItem"
                    cmdd.CommandType = CommandType.StoredProcedure
                    'assign parameters
                    cmdd.Parameters.AddWithValue("@price", vdepositprice)
                    'execute query
                    cmdd.ExecuteNonQuery()
                End If
                'commit query
                transaction.Commit()
                'msg 
                MessageBox.Show("Item Added", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'close the form
            End Using
        Catch ex As Exception
            'msg error
            MessageBox.Show(ex.ToString)
            Try
                'rollback query
                transaction.Rollback()
            Catch ex2 As Exception
                'msg sql error
                MessageBox.Show(ex2.ToString)
            End Try
        End Try
    End Sub
    Public Sub updateItem(ByVal current_itemcode As String, ByVal current_itemname As String)
        Try
            'create new connection
            Using connection As New SqlConnection(cc.conString)
                'init command
                Dim cmdd As New SqlCommand()
                'open connection
                cmdd.Connection = connection
                connection.Open()
                'begin connection
                transaction = connection.BeginTransaction()
                cmdd.Transaction = transaction

                'clear parameter first
                cmdd.Parameters.Clear()
                'command syntax
                cmdd.CommandText = "updateItems"
                cmdd.CommandType = CommandType.StoredProcedure
                'assign parameters
                cmdd.Parameters.AddWithValue("@itemid", vitemid)
                cmdd.Parameters.AddWithValue("@category", category)
                cmdd.Parameters.AddWithValue("@itemname", vitemname)
                cmdd.Parameters.AddWithValue("@itemcode", vitemcode)
                cmdd.Parameters.AddWithValue("@description", vdescription)
                cmdd.Parameters.AddWithValue("@price", vprice)
                cmdd.Parameters.AddWithValue("@modby", login2.username)
                cmdd.Parameters.AddWithValue("@deposit", IIf(vchck, 1, 0))
                cmdd.Parameters.AddWithValue("@current_itemcode", current_itemcode)
                cmdd.Parameters.AddWithValue("@current_itemname", current_itemname)
                cmdd.Parameters.AddWithValue("@depositprice", vdepositprice)
                'execute query
                cmdd.ExecuteNonQuery()
                'check if item id has deposit price
                If vchck Then
                    'check haveDeposit is true
                    If checkDepositItem() Then
                        'clear parameter first
                        cmdd.Parameters.Clear()
                        'command syntax
                        cmdd.CommandText = "updateDepositItem"
                        cmdd.CommandType = CommandType.StoredProcedure
                        'assign parameters
                        cmdd.Parameters.AddWithValue("@itemid", vitemid)
                        cmdd.Parameters.AddWithValue("@price", vdepositprice)
                        cmdd.Parameters.AddWithValue("@status", 1)
                        'execute query
                        cmdd.ExecuteNonQuery()
                    Else
                        'clear parameter first
                        cmdd.Parameters.Clear()
                        cmdd.CommandText = "insertDepositItem"
                        cmdd.Parameters.AddWithValue("@price", vdepositprice)
                        cmdd.CommandType = CommandType.StoredProcedure
                        cmdd.ExecuteNonQuery()
                    End If
                Else
                    'check if haveDeposit is true
                    If checkDepositItem() Then
                        'clear parameter first
                        cmdd.Parameters.Clear()
                        cmdd.CommandText = "updateDepositItem"
                        cmdd.CommandType = CommandType.StoredProcedure
                        'assign parameters
                        cmdd.Parameters.AddWithValue("@itemid", vitemid)
                        cmdd.Parameters.AddWithValue("@price", 0)
                        cmdd.Parameters.AddWithValue("@status", 0)
                        'execute query
                        cmdd.ExecuteNonQuery()
                    End If
                End If
                'commit query
                transaction.Commit()
                'msg
                MessageBox.Show("Item Updated", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            'msg error
            MessageBox.Show(ex.ToString)
            Try
                'rollback query
                transaction.Rollback()
            Catch ex2 As Exception
                'sql msg error
                MessageBox.Show(ex2.ToString)
            End Try
        End Try
    End Sub
    Public Function checkDepositItem() As Boolean
        'init variable
        Dim result As Boolean = False, result_int As Integer = 0
        'command syntax
        cc.con.Open()
        cc.cmd.CommandText = "SELECT dbo.checkDepositItem(@itemid)"
        'assign parameter
        cc.cmd.Parameters.AddWithValue("@itemid", vitemid)
        'read command
        result_int = cc.cmd.ExecuteScalar
        cc.con.Close()
        result = IIf(result_int = 0, False, True)
        Return result
    End Function
End Class
