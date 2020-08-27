Imports AK_POS.connection_class
Imports System.Data.SqlClient
Public Class branch_class
    Dim cc As New connection_class()
    Dim transaction As SqlTransaction
    Private brid As Integer = 0, branchcode As String = "", branchname As String = "", gr As String = "", sales As String = "", address As String = "", remarks As String = "", status As Integer = 0
    Public ReadOnly Property getBranchCode() As String
        Get
            Return branchcode
        End Get
    End Property
    Public Sub setBranchCode(ByVal value As String)
        branchcode = value
    End Sub
    Public ReadOnly Property getBranchName() As String
        Get
            Return branchname
        End Get
    End Property
    Public Sub setBranchName(ByVal value As String)
        branchname = value
    End Sub
    Public ReadOnly Property getGR() As String
        Get
            Return gr
        End Get
    End Property
    Public Sub setGR(ByVal value As String)
        gr = value
    End Sub
    Public ReadOnly Property getSales() As String
        Get
            Return sales
        End Get
    End Property
    Public Sub setSales(ByVal value As String)
        sales = value
    End Sub
    Public ReadOnly Property getAddress() As String
        Get
            Return address
        End Get
    End Property
    Public Sub setAddress(ByVal value As String)
        address = value
    End Sub
    Public ReadOnly Property getRemarks() As String
        Get
            Return remarks
        End Get
    End Property
    Public Sub setRemarks(ByVal value As String)
        remarks = value
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
            Return brid
        End Get
    End Property
    Public Sub setID(ByVal value As Integer)
        brid = value
    End Sub
    Public Function loadData(ByVal offset As Integer, ByVal rowFetch As Integer) As DataTable
        Dim dt As New DataTable(), adptr As New SqlClient.SqlDataAdapter
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT * FROM vLoadBranches WHERE branchcode LIKE '%" & branchcode & "%' AND status=" & status & " ORDER BY 1 OFFSET " & offset & " ROW FETCH NEXT " & rowFetch & " ROWS ONLY;", cc.con)
        adptr.SelectCommand = cc.cmd
        adptr.Fill(dt)
        cc.con.Close()
        Return dt
    End Function
    Public Function loadDataWhereID()
        Dim dt As New DataTable(), adptr As New SqlClient.SqlDataAdapter
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT branchcode,branch,gr,sales,status,address,remarks FROM tblbranch WHERE brid=" & brid & ";", cc.con)
        adptr.SelectCommand = cc.cmd
        adptr.Fill(dt)
        cc.con.Close()
        Return dt
    End Function
    Public Function countData() As Integer
        Dim result As Integer = 0
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT COUNT(brid) FROM vLoadBranches WHERE branchcode LIKE '%" & branchcode & "%' AND status=" & status & ";", cc.con)
        result = cc.cmd.ExecuteScalar
        cc.con.Close()
        Return result
    End Function

    Public Function checkCode() As Boolean
        Dim result_int As Integer = 0, result As Boolean = False
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT dbo.checkBranchCode(@code)", cc.con)
        cc.cmd.Parameters.AddWithValue("@code", branchcode)
        result_int = cc.cmd.ExecuteScalar
        cc.con.Close()
        result = IIf(result_int = 1, True, False)
        Return result
    End Function
    Public Sub insertBranch()
        Try
            Using connection As New SqlConnection(cc.conString)
                Dim cmdd As New SqlCommand()
                cmdd.Connection = connection
                connection.Open()
                transaction = connection.BeginTransaction()
                cmdd.Transaction = transaction
                cmdd.Parameters.Clear()
                cmdd.CommandText = "insertBranch"
                cmdd.CommandType = CommandType.StoredProcedure
                cmdd.Parameters.AddWithValue("@code", branchcode)
                cmdd.Parameters.AddWithValue("@name", branchname)
                cmdd.Parameters.AddWithValue("@gr", gr)
                cmdd.Parameters.AddWithValue("@sales", sales)
                cmdd.Parameters.AddWithValue("@address", address)
                cmdd.Parameters.AddWithValue("@remarks", remarks)
                cmdd.Parameters.AddWithValue("@createdby", login2.username)
                cmdd.Parameters.AddWithValue("@status", status)
                cmdd.Parameters.AddWithValue("@main", 0)
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
            Using connection As New SqlConnection(cc.conString)
                Dim cmdd As New SqlCommand()
                cmdd.Connection = connection
                connection.Open()
                transaction = connection.BeginTransaction()
                cmdd.Transaction = transaction
                cmdd.Parameters.Clear()
                cmdd.CommandText = "updateBranch"
                cmdd.CommandType = CommandType.StoredProcedure
                cmdd.Parameters.AddWithValue("@branchcode", branchcode)
                cmdd.Parameters.AddWithValue("@branchname", branchname)
                cmdd.Parameters.AddWithValue("@gr", gr)
                cmdd.Parameters.AddWithValue("@sales", sales)
                cmdd.Parameters.AddWithValue("@address", address)
                cmdd.Parameters.AddWithValue("@remarks", remarks)
                cmdd.Parameters.AddWithValue("@modifiedby", login2.username)
                cmdd.Parameters.AddWithValue("@status", status)
                cmdd.Parameters.AddWithValue("@brid", brid)
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
