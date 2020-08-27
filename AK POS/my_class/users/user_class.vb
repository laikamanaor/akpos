Imports AK_POS.connection_class
Imports System.Data.SqlClient
Public Class user_class
    Dim cc As New connection_class(), transaction As SqlTransaction
    Private name As String = "", username As String = "", workgroup As String = "", status As Integer = 0, password As String = "", brout As String = "", postype As String = "", systemid As Integer = 0
    Public ReadOnly Property getName() As String
    Get
            Return name
        End Get
    End Property
    Public Sub setName(ByVal value As String)
        name = value
    End Sub
    Public ReadOnly Property getUsername() As String
        Get
            Return username
        End Get
    End Property
    Public Sub setUsername(ByVal value As String)
        username = value
    End Sub
    Public ReadOnly Property getPassword() As String
        Get
            Return password
        End Get
    End Property
    Public Sub setPassword(ByVal value As String)
        password = value
    End Sub
    Public ReadOnly Property getWorkgroup() As String
        Get
            Return workgroup
        End Get
    End Property
    Public Sub setWorkgroup(ByVal value As String)
        workgroup = value
    End Sub
    Public ReadOnly Property getStatus() As Integer
        Get
            Return status
        End Get
    End Property
    Public Sub setStatus(ByVal value As Integer)
        status = value
    End Sub
    Public ReadOnly Property getBrout() As String
        Get
            Return brout
        End Get
    End Property
    Public Sub setBrout(ByVal value As String)
        brout = value
    End Sub
    Public ReadOnly Property getPOSType() As String
        Get
            Return postype
        End Get
    End Property
    Public Sub setPOSType(ByVal value As String)
        postype = value
    End Sub
    Public ReadOnly Property getID() As Integer
        Get
            Return systemid
        End Get
    End Property
    Public Sub setID(ByVal value As Integer)
        systemid = value
    End Sub
    Public Function loadData(ByVal offset As Integer, ByVal rowFetch As Integer) As DataTable
        Dim dt As New DataTable(), adptr As New SqlClient.SqlDataAdapter
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT * FROM funcLoadUsers(@username,@workgroup,@status,@offset,@rowfetch);", cc.con)
        cc.cmd.Parameters.AddWithValue("@username", username)
        cc.cmd.Parameters.AddWithValue("@workgroup", workgroup)
        cc.cmd.Parameters.AddWithValue("@status", status)
        cc.cmd.Parameters.AddWithValue("@offset", offset)
        cc.cmd.Parameters.AddWithValue("@rowfetch", rowFetch)
        adptr.SelectCommand = cc.cmd
        adptr.Fill(dt)
        cc.con.Close()
        Return dt
    End Function
    Public Function loadDataWhereID()
        Dim dt As New DataTable(), adptr As New SqlClient.SqlDataAdapter
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT a.fullname,a.username,a.password,a.workgroup,a.status,b.branchcode,a.postype FROM tblusers a INNER JOIN tblbranch b ON a.brid = b.brid WHERE a.systemid=" & systemid & ";", cc.con)
        adptr.SelectCommand = cc.cmd
        adptr.Fill(dt)
        cc.con.Close()
        Return dt
    End Function
    Public Function loadBranches() As DataTable
        Dim result As New DataTable(), adptr As New SqlDataAdapter()
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT branchcode FROM vLoadBranches WHERE status=1 ORDER BY branchcode", cc.con)
        adptr.SelectCommand = cc.cmd
        adptr.Fill(result)
        cc.con.Close()
        Return result
    End Function

    Public Function countData() As Integer
        Dim result As Integer = 0
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT  dbo.funcCountLoadUsers(@username,@workgroup,@status)", cc.con)
        cc.cmd.Parameters.AddWithValue("@username", username)
        cc.cmd.Parameters.AddWithValue("@workgroup", workgroup)
        cc.cmd.Parameters.AddWithValue("@status", status)
        result = cc.cmd.ExecuteScalar
        cc.con.Close()
        Return result
    End Function

    Public Function checkUsername() As Boolean
        Dim result_int As Integer = 0, result As Boolean = False
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT  dbo.checkUsername(@username)", cc.con)
        cc.cmd.Parameters.AddWithValue("@username", username)
        result_int = cc.cmd.ExecuteScalar
        cc.con.Close()
        result = IIf(result_int = 0, False, True)
        Return result
    End Function

    Public Function returnPOSType() As String
        Dim result As String = ""
        cc.con.Open()
        cc.cmd = New SqlCommand("SELECT dbo.getPOSType(@username)", cc.con)
        cc.cmd.Parameters.AddWithValue("@username", login2.username)
        result = IIf(IsDBNull(cc.cmd.ExecuteScalar), "N/A", cc.cmd.ExecuteScalar)
        cc.con.Close()
        Return result
    End Function

    Public Sub insertUser()
        Try
            Using connection As New SqlConnection(cc.conString)
                Dim cmdd As New SqlCommand()
                cmdd.Connection = connection
                connection.Open()
                transaction = connection.BeginTransaction()
                cmdd.Transaction = transaction
                cmdd.Parameters.Clear()
                cmdd.CommandText = "insertUser"
                cmdd.CommandType = CommandType.StoredProcedure
                cmdd.Parameters.AddWithValue("@fullname", name)
                cmdd.Parameters.AddWithValue("@username", username)
                cmdd.Parameters.AddWithValue("@password", cc.Encrypt(password))
                cmdd.Parameters.AddWithValue("@workgroup", workgroup)
                cmdd.Parameters.AddWithValue("@createdby", login2.username)
                cmdd.Parameters.AddWithValue("@status", status)
                cmdd.Parameters.AddWithValue("@brout", brout)
                cmdd.Parameters.AddWithValue("@postype", postype)
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
    Public Sub updateUser()
        Try
            Using connection As New SqlConnection(cc.conString)
                Dim cmdd As New SqlCommand()
                cmdd.Connection = connection
                connection.Open()
                transaction = connection.BeginTransaction()
                cmdd.Transaction = transaction
                cmdd.Parameters.Clear()
                cmdd.CommandText = "updateUser"
                cmdd.CommandType = CommandType.StoredProcedure
                cmdd.Parameters.AddWithValue("@fullname", name)
                cmdd.Parameters.AddWithValue("@username", username)
                cmdd.Parameters.AddWithValue("@password", cc.Encrypt(password))
                cmdd.Parameters.AddWithValue("@workgroup", workgroup)
                cmdd.Parameters.AddWithValue("@modifiedby", login2.username)
                cmdd.Parameters.AddWithValue("@status", status)
                cmdd.Parameters.AddWithValue("@brout", brout)
                cmdd.Parameters.AddWithValue("@postype", postype)
                cmdd.Parameters.AddWithValue("@systemid", systemid)
                cmdd.ExecuteNonQuery()
                transaction.Commit()
                MessageBox.Show("Transaction Completed", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Try
                transaction.Rollback()
            Catch ex2 As Exception
                MessageBox.Show(ex2.ToString)
            End Try
        End Try
    End Sub

    Public Function loadNameUser() As String
        Dim result As String = ""
        cc.con.Open()
        cc.cmd = New SqlCommand("SELECT fullname FROM tblusers WHERE username=@username;", cc.con)
        cc.cmd.Parameters.AddWithValue("@username", login2.username)
        cc.rdr = cc.cmd.ExecuteReader
        If cc.rdr.Read Then
            result = CStr(cc.rdr("fullname"))
        End If
        cc.con.Close()
        Return result
    End Function
End Class
