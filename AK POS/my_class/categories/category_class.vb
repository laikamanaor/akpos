Imports AK_POS.connection_class
Imports System.Data.SqlClient
Public Class category_class
    Dim cc As New connection_class(), transaction As SqlTransaction
    Private category As String = "", status As Integer = 0, catid As Integer = 0
    Public ReadOnly Property getCategory() As String
        Get
            Return category
        End Get
    End Property
    Public Sub setCategory(ByVal value As String)
        category = value
    End Sub
    Public ReadOnly Property getStatus() As Integer
        Get
            Return status
        End Get
    End Property
    Public Sub setStatus(ByVal value As Integer)
        status = value
    End Sub
    Public ReadOnly Property getID() As Integer
        Get
            Return catid
        End Get
    End Property
    Public Sub setID(ByVal value As Integer)
        catid = value
    End Sub
    Public Function loadData(ByVal offset As Integer, ByVal rowFetch As Integer) As DataTable
        Dim dt As New DataTable(), adptr As New SqlClient.SqlDataAdapter
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT catid,category,status FROM vLoadCategories WHERE category LIKE '%" & category & "%' AND status=" & status & " ORDER BY 1 OFFSET " & offset & " ROW FETCH NEXT " & rowFetch & " ROWS ONLY;", cc.con)
        adptr.SelectCommand = cc.cmd
        adptr.Fill(dt)
        cc.con.Close()
        Return dt
    End Function
    Public Function loadDataWhereID()
        Dim dt As New DataTable(), adptr As New SqlClient.SqlDataAdapter
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT category,status FROM vLoadCategories WHERE catid=" & catid & ";", cc.con)
        adptr.SelectCommand = cc.cmd
        adptr.Fill(dt)
        cc.con.Close()
        Return dt
    End Function
    Public Function countData() As Integer
        Dim result As Integer = 0
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT COUNT(catid) FROM vLoadCategories WHERE category LIKE '%" & category & "%' AND status=" & status & ";", cc.con)
        result = cc.cmd.ExecuteScalar
        cc.con.Close()
        Return result
    End Function

    Public Function checkCategory() As Boolean
        Dim result_int As Integer = 0, result As Boolean = False
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT dbo.checkCategory(@code)", cc.con)
        cc.cmd.Parameters.AddWithValue("@code", category)
        result_int = cc.cmd.ExecuteScalar
        cc.con.Close()
        result = IIf(result_int = 1, True, False)
        Return result
    End Function

    Public Sub insertCategory()
        Try
            Using connection As New SqlConnection(login.ss)
                Dim cmdd As New SqlCommand()
                cmdd.Connection = connection
                connection.Open()
                transaction = connection.BeginTransaction()
                cmdd.Transaction = transaction
                cmdd.Parameters.Clear()
                cmdd.CommandText = "insertCategory"
                cmdd.CommandType = CommandType.StoredProcedure
                cmdd.Parameters.AddWithValue("@category", category)
                cmdd.Parameters.AddWithValue("@createdby", login.username)
                cmdd.Parameters.AddWithValue("@status", status)
                cmdd.ExecuteNonQuery()
                transaction.Commit()
                MessageBox.Show("Transaction Completed", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            Try
                transaction.Rollback()
            Catch ex2 As Exception
                MessageBox.Show(ex2.ToString)
            End Try
        End Try
    End Sub
    Public Sub updateBranch()
        Try
            Using connection As New SqlConnection(login.ss)
                Dim cmdd As New SqlCommand()
                cmdd.Connection = connection
                connection.Open()
                transaction = connection.BeginTransaction()
                cmdd.Transaction = transaction
                cmdd.Parameters.Clear()
                cmdd.CommandText = "updateCategory"
                cmdd.CommandType = CommandType.StoredProcedure
                cmdd.Parameters.AddWithValue("@category", category)
                cmdd.Parameters.AddWithValue("@modifiedby", login.username)
                cmdd.Parameters.AddWithValue("@status", status)
                cmdd.Parameters.AddWithValue("@catid", catid)
                cmdd.ExecuteNonQuery()
                transaction.Commit()
                MessageBox.Show("Transaction Completed", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            Try
                transaction.Rollback()
            Catch ex2 As Exception
                MessageBox.Show(ex2.ToString)
            End Try
        End Try
    End Sub
End Class
