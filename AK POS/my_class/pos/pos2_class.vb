Imports AK_POS.connection_class
Public Class pos2_class
    Dim cc As New connection_class()
    Private catoffset As Integer = 0, catrowFetch As Integer = 0,
        itemoffset As Integer = 0, itemrowFetch As Integer = 0,
        itemname As String = "", vdatecreated As New DateTime,
        vitemid As Integer = 0
    Public ReadOnly Property catgetOffset() As Integer
        Get
            Return catoffset
        End Get
    End Property
    Public Sub catsetOffset(ByVal value As Integer)
        catoffset = value
    End Sub
    Public ReadOnly Property catgetrowFetch() As Integer
        Get
            Return catrowFetch
        End Get
    End Property
    Public Sub catsetrowFetch(ByVal value As Integer)
        catrowFetch = value
    End Sub
    Public ReadOnly Property getItemOffset() As Integer
        Get
            Return itemoffset
        End Get
    End Property
    Public Sub setItemOffset(ByVal value As Integer)
        itemoffset = value
    End Sub
    Public ReadOnly Property getItemrowFetch() As Integer
        Get
            Return itemrowFetch
        End Get
    End Property
    Public Sub setItemrowFetch(ByVal value As Integer)
        itemrowFetch = value
    End Sub

    Public ReadOnly Property getItem() As String
        Get
            Return itemname
        End Get
    End Property
    Public Sub setItem(ByVal value As String)
        itemname = value
    End Sub

    Public Property datecreated As DateTime
        Set(value As DateTime)
            vdatecreated = value
        End Set
        Get
            Return vdatecreated
        End Get
    End Property

    Public Property itemid As Integer
        Set(value As Integer)
            vitemid = value
        End Set
        Get
            Return vitemid
        End Get
    End Property

    Public Function loadCategories() As DataTable
        Dim result As New DataTable(), adptr As New SqlClient.SqlDataAdapter
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT * FROM dbo.funcLoadCategories(" & catoffset & "," & catrowFetch & ")", cc.con)
        adptr.SelectCommand = cc.cmd
        adptr.Fill(result)
        cc.con.Close()
        Return result
    End Function

    Public Function getCategoriesCount() As Long
        Dim result As Long
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT ISNULL(COUNT(catid),0) AS catid FROM vLoadCategories WHERE status=1", cc.con)
        result = cc.cmd.ExecuteScalar
        cc.con.Close()
        Return result
    End Function

    Public Function getDateParameterResult() As DateTime
        Dim dateParameter As New DateTime()
        If login2.wrkgrp = "Sales" Or login2.wrkgrp = "Manager" Or login2.wrkgrp = "Casher" Then
            cc.con.Open()
            cc.cmd = New SqlClient.SqlCommand("SELECT dbo.funcGetLatestInventoryDate()", cc.con)
            dateParameter = cc.cmd.ExecuteScalar()
            cc.con.Close()
        Else
            dateParameter = vdatecreated
        End If
        Return dateParameter
    End Function

    Public Function loadItems() As DataTable
        Dim dateParameter As New DateTime()
        dateParameter = getDateParameterResult()
        Dim result As New DataTable(), adptr As New SqlClient.SqlDataAdapter
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT * FROM funcLoadItemswithEndbal(@date,@itemname,@offset,@rowfetch)", cc.con)
        cc.cmd.Parameters.AddWithValue("@date", dateParameter.ToString("MM/dd/yyyy"))
        cc.cmd.Parameters.AddWithValue("@itemname", itemname)
        cc.cmd.Parameters.AddWithValue("@offset", itemoffset)
        cc.cmd.Parameters.AddWithValue("@rowfetch", itemrowFetch)
        adptr.SelectCommand = cc.cmd
        adptr.Fill(result)
        cc.con.Close()
        Return result
    End Function


    Public Function getItemsCount() As Long
        Dim dateParameter As New DateTime()
        dateParameter = getDateParameterResult()
        Dim result As Long
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT  dbo.funcCountLoadItemswithEndbal(@date,@itemname)", cc.con)
        cc.cmd.Parameters.AddWithValue("@date", dateParameter.ToString("MM/dd/yyyy"))
        cc.cmd.Parameters.AddWithValue("@itemname", itemname)
        result = cc.cmd.ExecuteScalar
        cc.con.Close()
        Return result
    End Function

    Public Function searchItemFill() As DataTable
        Dim result As New DataTable(), adptr As New SqlClient.SqlDataAdapter
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT a.itemname FROM vLoadItems a WHERE a.discontinued=0 ORDER BY a.itemname", cc.con)
        adptr.SelectCommand = cc.cmd
        adptr.Fill(result)
        cc.con.Close()
        Return result
    End Function

    Public Function checkInventoryStock() As Boolean
        Dim result As Boolean, result_int As Integer = 0
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT dbo.checkInventoryStock(@itemid)", cc.con)
        cc.cmd.Parameters.AddWithValue("@itemid", vitemid)
        result_int = cc.cmd.ExecuteScalar
        cc.con.Close()
        result = IIf(result_int = 0, False, True)
        Return result
    End Function

    Public Function returnLatestOrderNumber() As Integer
        Dim result As Integer = 0, dateParameter As New DateTime()
        dateParameter = getDateParameterResult()

        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT dbo.getOrdernumber(@date)", cc.con)
        cc.cmd.Parameters.AddWithValue("@date", dateParameter)
        result = cc.cmd.ExecuteScalar
        cc.con.Close()
        Return result
    End Function

    Public Function getItemPrice() As Double
        Dim result As Double = 0.00
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT dbo.getItemPrice(@itemid)", cc.con)
        cc.cmd.Parameters.AddWithValue("@itemid", vitemid)
        result = IIf(IsDBNull(cc.cmd.ExecuteScalar), 0, cc.cmd.ExecuteScalar)
        cc.con.Close()
        Return result
    End Function

    Public Function getTransactionNumber() As String
        Dim selectcount_result As Integer = 0, branchcode As String = "", temp As String = "0", result As String = ""
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT ISNULL(MAX(a.transid),0)+1 FROM tbltransaction a WHERE a.area='Sales' AND tendertype !='Advance Payment' AND a.tendertype !='Cash Out' AND tendertype!='Deposit' AND a.tendertype !='Advance Payment Cash'", cc.con)
        selectcount_result = cc.cmd.ExecuteScalar
        cc.con.Close()

        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("Select branchcode FROM tblbranch WHERE main='1';", cc.con)
        branchcode = cc.cmd.ExecuteScalar
        cc.con.Close()

        If selectcount_result < 1000000 Then
            Dim cselectcount_result As String = CStr(selectcount_result)
            For vv As Integer = 1 To 6 - cselectcount_result.Length
                temp += "0"
            Next
            result = "TR - " & branchcode & " - " & temp & selectcount_result
        Else
            result = "TR - " & branchcode & " - " & temp & selectcount_result
        End If
        Return result
    End Function

End Class
