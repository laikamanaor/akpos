Imports AK_POS.connection_class
Imports System.Data.SqlClient
Public Class category_class
    'init classes
    Dim cc As New connection_class(), transaction As SqlTransaction
    'init variables
    Private vcategory As String = "", vstatus As Integer = 0, vcatid As Integer = 0
    'get and set
    Public Property category As String
        Set(value As String)
            vcategory = value
        End Set
        Get
            Return vcategory
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
    Public Property catid As Integer
        Set(value As Integer)
            vcatid = value
        End Set
        Get
            Return vcatid
        End Get
    End Property

    ''' <summary>
    ''' load data from tblcat
    ''' </summary>
    ''' <param name="offset"></param>
    ''' <param name="rowFetch"></param>
    ''' <returns></returns>
    Public Function loadData(ByVal offset As Integer, ByVal rowFetch As Integer) As DataTable
        'init result and sql data adapter
        Dim dt As New DataTable(), adptr As New SqlClient.SqlDataAdapter
        'open connection
        cc.con.Open()
        'syntax'
        cc.cmd = New SqlClient.SqlCommand("SELECT catid,category,status FROM vLoadCategories WHERE category LIKE '%" & vcategory & "%' AND status=" & vstatus & " ORDER BY 1 OFFSET " & offset & " ROW FETCH NEXT " & rowFetch & " ROWS ONLY;", cc.con)
        adptr.SelectCommand = cc.cmd
        'fill datatable from data adapter
        adptr.Fill(dt)
        'close connection
        cc.con.Close()
        'return result
        Return dt
    End Function

    Public Function loadDataExported() As DataTable
        'init result and sql data adapter
        Dim dt As New DataTable(), adptr As New SqlClient.SqlDataAdapter
        'open connection
        cc.con.Open()
        'syntax'
        cc.cmd = New SqlClient.SqlCommand("SELECT category,status FROM vLoadCategories WHERE category LIKE '%" & vcategory & "%' AND status=" & vstatus & ";", cc.con)
        adptr.SelectCommand = cc.cmd
        'fill datatable from data adapter
        adptr.Fill(dt)
        'close connection
        cc.con.Close()
        'return result
        Return dt
    End Function

    ''' <summary>
    ''' load data based on specific id
    ''' </summary>
    ''' <returns></returns>
    Public Function loadDataWhereID()
        'init result and sql data adapter
        Dim dt As New DataTable(), adptr As New SqlClient.SqlDataAdapter
        'open connection
        cc.con.Open()
        'syntax
        cc.cmd = New SqlClient.SqlCommand("SELECT category,status FROM vLoadCategories WHERE catid=" & vcatid & ";", cc.con)
        adptr.SelectCommand = cc.cmd
        'fill datatable from data adapter
        adptr.Fill(dt)
        'close connection
        cc.con.Close()
        'return result
        Return dt
    End Function
    ''' <summary>
    ''' get rows count based on category and status
    ''' </summary>
    ''' <returns></returns>
    Public Function countData() As Integer
        'init result
        Dim result As Integer = 0
        'open connection
        cc.con.Open()
        'syntax
        cc.cmd = New SqlClient.SqlCommand("SELECT COUNT(catid) FROM vLoadCategories WHERE category LIKE '%" & vcategory & "%' AND status=" & status & ";", cc.con)
        'assign result
        result = cc.cmd.ExecuteScalar
        'close connection
        cc.con.Close()
        'return result
        Return result
    End Function

    ''' <summary>
    ''' check category if exist
    ''' </summary>
    ''' <returns></returns>
    Public Function checkCategory() As Boolean
        'init result
        Dim result_int As Integer = 0, result As Boolean = False
        'open connection'
        cc.con.Open()
        'call scalar function from datatable
        cc.cmd = New SqlClient.SqlCommand("SELECT dbo.checkCategory(@code)", cc.con)
        'assign parameter
        cc.cmd.Parameters.AddWithValue("@code", vcategory)
        'assign result
        result_int = cc.cmd.ExecuteScalar
        'close connection
        cc.con.Close()
        'assign result depends on expression
        result = IIf(result_int = 1, True, False)
        'return result
        Return result
    End Function
    ''' <summary>
    ''' insert category
    ''' </summary>
    Public Sub insertCategory()
        Try
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
                'clear command to make sure no errors
                cmdd.Parameters.Clear()

                'command name of procedure
                cmdd.CommandText = "insertCategory"
                'command type
                cmdd.CommandType = CommandType.StoredProcedure
                'assign parameters
                cmdd.Parameters.AddWithValue("@category", vcategory)
                cmdd.Parameters.AddWithValue("@createdby", login2.username)
                cmdd.Parameters.AddWithValue("@status", vstatus)
                'execute query
                cmdd.ExecuteNonQuery()
                'commit query
                transaction.Commit()
                'message when commit is success
                MessageBox.Show("Transaction Completed", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Try
                'not insert data when have error(s)
                transaction.Rollback()
            Catch ex2 As Exception
                'display error message
                MessageBox.Show(ex2.Message)
            End Try
        End Try
    End Sub
    Public Sub updateCategory()
        Try
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
                'clear parameters to make sure no error(s)
                cmdd.Parameters.Clear()
                'procedure name for updating category
                cmdd.CommandText = "updateCategory"
                'command type
                cmdd.CommandType = CommandType.StoredProcedure
                'assign parameters
                cmdd.Parameters.AddWithValue("@category", vcategory)
                cmdd.Parameters.AddWithValue("@modifiedby", login2.username)
                cmdd.Parameters.AddWithValue("@status", vstatus)
                cmdd.Parameters.AddWithValue("@catid", vcatid)
                'execute query
                cmdd.ExecuteNonQuery()
                'commit query
                transaction.Commit()
            End Using
        Catch ex As Exception
            'display error message
            MessageBox.Show(ex.Message)
            Try
                'not insert data when have error(s)
                transaction.Rollback()
            Catch ex2 As Exception
                'display sql error message
                MessageBox.Show(ex2.ToString)
            End Try
        End Try
    End Sub
End Class
