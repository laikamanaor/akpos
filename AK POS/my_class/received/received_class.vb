Imports System.Data.SqlClient
Imports AK_POS.connection_class
Public Class received_class
    Dim cc As New connection_class()
    Private sap_number As String = "", datecreated As String, itemname As String = "", category As String = ""
    Public Sub setSAPNumber(ByVal value As String)
        sap_number = value
    End Sub
    Public ReadOnly Property getSAPNumber() As String
        Get
            Return sap_number
        End Get
    End Property
    Public Sub setDateCreated(ByVal value As String)
        datecreated = value
    End Sub
    Public ReadOnly Property getDateCreated() As String
        Get
            Return datecreated
        End Get
    End Property
    Public Sub setItemName(ByVal value As String)
        itemname = value
    End Sub
    Public ReadOnly Property getItemName() As String
        Get
            Return itemname
        End Get
    End Property
    Public Sub setCategory(ByVal value As String)
        category = value
    End Sub
    Public ReadOnly Property getCategory() As String
        Get
            Return category
        End Get
    End Property
    ''' <summary>
    ''' Check SAP Number if exist
    ''' </summary>
    ''' <returns></returns>
    Public Function checkSAPNumber() As Boolean
        Dim result_num As Integer = 0, result As Boolean = False
        cc.con.Open()
        cc.cmd = New SqlCommand("SELECT dbo.checkSAPNumber(@sap_number)", cc.con)
        cc.cmd.Parameters.AddWithValue("@sap_number", sap_number)
        result_num = cc.cmd.ExecuteScalar()
        cc.con.Close()
        result = IIf(result_num = 1, True, False)
        Return result
    End Function

    ''' <summary>
    ''' return the result of branch code and supplier
    ''' </summary>
    ''' <param name="cmdText"></param>
    ''' <returns></returns>
    Public Function loadBranchesCustomers(ByVal cmdText As String) As DataTable
        Dim result As New DataTable(), adptr As New SqlDataAdapter()
        cc.con.Open()
        cc.cmd = New SqlCommand(cmdText, cc.con)
        adptr.SelectCommand = cc.cmd
        adptr.Fill(result)
        cc.con.Close()
        Return result
    End Function

    Public Function loadCategories() As DataTable
        Dim result As New DataTable(), adptr As New SqlDataAdapter()
        cc.con.Open()
        cc.cmd = New SqlCommand("SELECT category AS result FROM tblcat WHERE status=1 ORDER BY category", cc.con)
        adptr.SelectCommand = cc.cmd
        adptr.Fill(result)
        cc.con.Close()
        Return result
    End Function

    Public Function loadAvailableItems()
        Dim result As New DataTable(), adptr As New SqlDataAdapter()
        cc.con.Open()
        cc.cmd = New SqlCommand("SELECT * FROM funcLoadInventoryItems(@datecreated,@itemname,@category)", cc.con)
        cc.cmd.Parameters.AddWithValue("@datecreated", datecreated)
        cc.cmd.Parameters.AddWithValue("@itemname", itemname)
        cc.cmd.Parameters.AddWithValue("@category", category)
        adptr.SelectCommand = cc.cmd
        adptr.Fill(result)
        cc.con.Close()
        Return result
    End Function
End Class
