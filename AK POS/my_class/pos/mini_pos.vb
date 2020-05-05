Imports AK_POS.connection_class
Imports System.Data.SqlClient
Public Class mini_pos
    Private itemname As String = "", category As String = "", datee As String = ""
    Public ReadOnly Property getItem() As String
        Get
            Return itemname
        End Get
    End Property
    Public Sub setItem(ByVal value As String)
        itemname = value
    End Sub
    Public ReadOnly Property getCategory() As String
        Get
            Return category
        End Get
    End Property
    Public Sub setCategory(ByVal value As String)
        category = value
    End Sub
    Public ReadOnly Property getDatee() As String
        Get
            Return datee
        End Get
    End Property
    Public Sub setDatee(ByVal value As String)
        datee = value
    End Sub
    Dim cc As New connection_class()

    Public Function showItems(ByVal wtItems As String) As DataTable
        Dim dt As New DataTable()
        cc.con.Open()

        cc.cmd = New SqlClient.SqlCommand("SELECT b.itemid,a.itemname,a.endbal FROM tblinvitems a JOIN tblitems b ON a.itemname = b.itemname WHERE invnum=(SELECT invnum FROM tblinvsum WHERE CAST(datecreated AS date)='" & datee & "') " & IIf(wtItems = "", "", "AND b.category='" & category & "'") & " AND b.discontinued=0 AND a.itemname LIKE @name ORDER BY a.endbal DESC,a.itemname ASC", cc.con)
        cc.cmd.Parameters.AddWithValue("@name", "%" & itemname & "%")
        Dim adptr As New SqlDataAdapter()
        adptr.SelectCommand = cc.cmd
        adptr.Fill(dt)
        cc.con.Close()
        Return dt
    End Function

    Public Function showCategories() As DataTable
        Dim dt As New DataTable()
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT category FROM tblcat WHERE status=1;", cc.con)
        Dim adptr As New SqlDataAdapter()
        adptr.SelectCommand = cc.cmd
        adptr.Fill(dt)
        cc.con.Close()
        Return dt
    End Function

    Public Function showCustomers(ByVal typee As String) As DataTable
        Dim dt As New DataTable()
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT name FROM tblcustomers WHERE status=1 AND type='" & typee & "';", cc.con)
        Dim adptr As New SqlDataAdapter()
        adptr.SelectCommand = cc.cmd
        adptr.Fill(dt)
        cc.con.Close()
        Return dt
    End Function

    Public Function checkStocks() As Boolean
        Dim result As Boolean = False
        cc.con.Open()
        cc.cmd = New SqlCommand("SELECT a.invid FROM tblinvitems a INNER JOIN tblitems b ON a.itemname = b.itemname WHERE a.itemname=@itemname AND invnum=(SELECT invnum FROM tblinvsum WHERE CAST(datecreated AS date)='" & datee & "') AND b.category !='Coffee Shop' AND a.endbal !=0;", cc.con)
        cc.cmd.Parameters.AddWithValue("@itemname", itemname)
        cc.rdr = cc.cmd.ExecuteReader
        If cc.rdr.Read Then
            result = True
        End If
        cc.con.Close()
        Return result
    End Function

    Public Function addCart(ByVal id As Integer) As DataTable
        Dim dt As New DataTable()
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT itemname,category,price FROM tblitems WHERE itemid=" & id & ";", cc.con)
        Dim adptr As New SqlDataAdapter()
        adptr.SelectCommand = cc.cmd
        adptr.Fill(dt)
        cc.con.Close()
        Return dt
    End Function

    Public Function returnPrice(ByVal value As String) As Double
        Dim result As Double = 0.00
        cc.con.Open()
        cc.cmd = New SqlCommand("Select price from tblitems where itemname='" & value & "'", cc.con)
        cc.rdr = cc.cmd.ExecuteReader
        If cc.rdr.Read Then
            result = CDbl(cc.rdr("price"))
        End If
        cc.con.Close()
        Return result
    End Function
    Public Function returnStock(ByVal value As String, ByVal datee As String)
        Dim endbal As Double = 0.00
        cc.con.Open()
        cc.cmd = New SqlCommand("SELECT endbal FROM tblinvitems WHERE invnum=(SELECT invnum FROM tblinvsum WHERE CAST(datecreated AS date)='" & datee & "') AND itemname=@itemname;", cc.con)
        cc.cmd.Parameters.AddWithValue("@itemname", Trim(value))
        cc.rdr = cc.cmd.ExecuteReader
        If cc.rdr.Read Then
            endbal = CDbl(cc.rdr("endbal"))
        End If
        cc.con.Close()
        Return endbal
    End Function
End Class
