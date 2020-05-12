Imports AK_POS.connection_class
Public Class pos2_class
    Dim cc As New connection_class()
    Private catoffset As Integer = 0, catrowFetch As Integer = 0,
        itemoffset As Integer = 0, itemrowFetch As Integer = 0,
        itemname As String = ""
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

    Public Function loadItems() As DataTable
        Dim result As New DataTable(), adptr As New SqlClient.SqlDataAdapter
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT itemid,itemname FROM vLoadItems WHERE discontinued=0 AND itemname LIKE '%' + '" & itemname & "' + '%' ORDER BY itemname OFFSET " & itemoffset & " ROW FETCH NEXT " & itemrowFetch & " ROWS ONLY", cc.con)
        adptr.SelectCommand = cc.cmd
        adptr.Fill(result)
        cc.con.Close()
        Return result
    End Function


    Public Function getItemsCount() As Long
        Dim result As Long
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT ISNULL(COUNT(itemid),0) AS itemid FROM vLoadItems WHERE discontinued=0", cc.con)
        result = cc.cmd.ExecuteScalar
        cc.con.Close()
        Return result
    End Function
End Class
