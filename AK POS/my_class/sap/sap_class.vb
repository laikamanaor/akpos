Imports AK_POS.connection_class
Public Class sap_class
    Dim cc As New connection_class()
    Private dateParameter As DateTime
    Public ReadOnly Property getDateParameter() As DateTime
        Get
            Return dateParameter
        End Get
    End Property
    Public Sub setDateParameter(ByVal value As DateTime)
        dateParameter = value
    End Sub

    Public Function SgetName() As DataTable
        Dim result As New DataTable, adptr As New SqlClient.SqlDataAdapter
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT name,code FROM sGetName(@dateParameter)", cc.con)
        cc.cmd.Parameters.AddWithValue("@dateParameter", dateParameter.ToString("MM/dd/yyyy"))
        adptr.SelectCommand = cc.cmd
        adptr.Fill(result)
        cc.con.Close()
        Return result
    End Function

    Public Function getBranchInfo() As DataTable
        Dim result As New DataTable, adptr As New SqlClient.SqlDataAdapter
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("Select gr,branchcode FROM tblbranch WHERE main=1;", cc.con)
        adptr.SelectCommand = cc.cmd
        adptr.Fill(result)
        cc.con.Close()
        Return result
    End Function


    Public Function getendingBalanceShort() As DataTable
        Dim result As New DataTable(), adptr As New SqlClient.SqlDataAdapter
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("select * from sGetEBShort(@dateParameter)", cc.con)
        cc.cmd.Parameters.AddWithValue("@dateParameter", dateParameter)
        adptr.SelectCommand = cc.cmd
        adptr.Fill(result)
        Return result
    End Function

End Class
