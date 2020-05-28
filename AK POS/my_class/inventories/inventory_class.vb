Imports AK_POS.connection_class
Public Class inventory_class
    Dim cc As New connection_class()
    Private vinvnum As String, vtransnum As String, vdatecreated As DateTime, vtype As String, vitemname As String = "", vcategory As String = ""
    Public Property invnum As String
        Set(value As String)
            vinvnum = value
        End Set
        Get
            Return vinvnum
        End Get
    End Property
    Public Property transnum As String
        Set(value As String)
            vtransnum = value
        End Set
        Get
            Return vtransnum
        End Get
    End Property
    Public Property datecreated As DateTime
        Set(value As DateTime)
            vdatecreated = value
        End Set
        Get
            Return vdatecreated
        End Get
    End Property
    Public Property typee As String
        Set(value As String)
            vtype = value
        End Set
        Get
            Return vtype
        End Get
    End Property
    Public Property itemname As String
        Set(value As String)
            vitemname = value
        End Set
        Get
            Return vitemname
        End Get
    End Property
    Public Property category As String
        Set(value As String)
            vcategory = value
        End Set
        Get
            Return vcategory
        End Get
    End Property
    ''' <summary>
    ''' check if inventory is verified
    ''' </summary>
    ''' <returns></returns>
    Public Function checkVerify(ByVal btn As Button) As Boolean
        Dim prod_count As Integer = 0, invitems_count As Integer = 0, result As Boolean = False
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT ISNULL(COUNT(transaction_id),0) FROM tblproduction WHERE inv_id=@invnum AND type='Actual Ending Balance';", cc.con)
        cc.cmd.Parameters.AddWithValue("@invnum", vinvnum)
        prod_count = cc.cmd.ExecuteScalar()
        cc.con.Close()

        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT ISNULL(COUNT(invid),0) FROM tblinvitems WHERE invnum=@invnum AND totalav !=0;", cc.con)
        cc.cmd.Parameters.AddWithValue("@invnum", vinvnum)
        invitems_count = cc.cmd.ExecuteScalar()
        cc.con.Close()

        If prod_count = 0 And invitems_count = 0 Then
            result = False
        ElseIf prod_count = invitems_count Then
            cc.con.Open()
            cc.cmd = New SqlClient.SqlCommand("SELECT verify FROM tblinvsum WHERE invnum=@invnum;", cc.con)
            cc.cmd.Parameters.AddWithValue("@invnum", vinvnum)
            cc.rdr = cc.cmd.ExecuteReader
            If cc.rdr.Read Then
                result = IIf(cc.rdr("verify") = 1, False, True)
            End If
            cc.con.Close()
            If result = False Then
                btn.Text = "Verified"
            End If
        End If
        Return result
    End Function

    Public Function loadInventory(ByVal hasStock As Boolean) As DataTable
        Dim result As New DataTable, adptr As New SqlClient.SqlDataAdapter
        Dim inStock_query As String = "SELECT * FROM funcgetInventory(@invnum)",
                outStock_query As String = "SELECT * FROM funcgetInventory2(@invnum)",
                result_query As String = ""
        result_query = IIf(hasStock, inStock_query, outStock_query)
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand(result_query, cc.con)
        cc.cmd.CommandType = CommandType.Text
        cc.cmd.Parameters.AddWithValue("@invnum", vinvnum)
        adptr.SelectCommand = cc.cmd
        cc.con.Close()
        adptr.Fill(result)
        Return result
    End Function

    Public Function loadTransaction(ByVal offset As Integer, rowFetch As Integer) As DataTable
        Dim result As New DataTable(), adptr As New SqlClient.SqlDataAdapter
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT * FROM funcLoadInventoryLogs(@transnum,@date,@type,@offset,@rowfetch)", cc.con)
        cc.cmd.Parameters.AddWithValue("@transnum", vtransnum)
        cc.cmd.Parameters.AddWithValue("@date", vdatecreated)
        cc.cmd.Parameters.AddWithValue("@type", vtype)
        cc.cmd.Parameters.AddWithValue("@offset", offset)
        cc.cmd.Parameters.AddWithValue("@rowfetch", rowFetch)
        adptr.SelectCommand = cc.cmd
        adptr.Fill(result)
        cc.con.Close()
        Return result
    End Function

    Public Function countTransaction() As Integer
        Dim result As Integer = 0, rdr As SqlClient.SqlDataReader
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT DISTINCT transaction_number FROM vInventoryLogs WHERE transaction_number LIKE '% " & vtransnum & "%' AND CAST(date AS date)=@date AND type=@type AND status='Completed'", cc.con)
        'cc.cmd.Parameters.AddWithValue("@transnum", vtransnum)
        cc.cmd.Parameters.AddWithValue("@date", vdatecreated)
        cc.cmd.Parameters.AddWithValue("@type", vtype)
        rdr = cc.cmd.ExecuteReader
        While rdr.Read
            result += 1
        End While
        cc.con.Close()
        Return result
    End Function

    Public Function loadItems() As DataTable
        Dim result As New DataTable(), adptr As New SqlClient.SqlDataAdapter
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT * FROM funcLoadInventoryItemsLogs(@transnum,@category,@itemname)", cc.con)
        cc.cmd.Parameters.AddWithValue("@transnum", vtransnum)
        cc.cmd.Parameters.AddWithValue("@itemname", vitemname)
        cc.cmd.Parameters.AddWithValue("@category", vcategory)
        cc.con.Close()
        adptr.SelectCommand = cc.cmd
        adptr.Fill(result)
        Return result
    End Function

    Public Function loadSAPRemarks() As DataTable
        Dim result As New DataTable(), adptr As New SqlClient.SqlDataAdapter
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT sap_number,remarks FROM tblproduction WHERE transaction_number=@transnum;", cc.con)
        cc.cmd.Parameters.AddWithValue("@transnum", vtransnum)
        adptr.SelectCommand = cc.cmd
        adptr.Fill(result)
        cc.con.Close()
        Return result
    End Function

End Class
