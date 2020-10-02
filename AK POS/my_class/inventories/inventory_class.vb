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

    Public Function getInvNum() As String
        Dim result As String = ""
        Try
            cc.con.Open()
            cc.cmd = New SqlClient.SqlCommand("SELECT dbo.returnInvNum()", cc.con)
            result = cc.cmd.ExecuteScalar
            cc.con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        result = IIf(String.IsNullOrEmpty(result), "N/A", result)
        Return result
    End Function

    Public Function getSalesInventory(ByVal transferFrom As String) As DataTable
        Dim result As New DataTable(), adptr As New SqlClient.SqlDataAdapter
        Try
            Dim query As String = "SELECT a.item_name [item], SUM(a.quantity) [transferToSales] ,ISNULL(x.qty,0) [counter],
ISNULL(xx.qty,0) [archarge],ISNULL(xxx.qty,0) [arsales],xxxx.transferFromSales
,SUM(a.quantity) - (ISNULL(x.qty,0) + ISNULL(xx.qty,0) + ISNULL(xxx.qty,0) + ISNULL(xxxx.transferFromSales,0))[endbal]
,ISNULL(x.qty,0) * (SELECT price FROM tblitems WHERE itemname=a.item_name) [counter_amt]
,ISNULL(xx.qty,0) * (SELECT price FROM tblitems WHERE itemname=a.item_name) [archarge_amt]
,ISNULL(xxx.qty,0) * (SELECT price FROM tblitems WHERE itemname=a.item_name) [arsales_amt]
FROM tblproduction a 
OUTER APPLY(
SELECT c.itemname,SUM(c.qty) [qty] 
FROM tbltransaction2 b INNER JOIN tblorder2 c ON c.ordernum = b.ordernum 
AND CAST(b.datecreated As date)=CAST(c.datecreated AS date) 
WHERE CAST(b.datecreated AS date)=(SELECT TOP 1 CAST(datecreated AS date) 
FROM tblinvsum ORDER BY invsumid DESC) AND b.inventory_type='Own Inventory' AND a.item_name = c.itemname AND
b.status2 IN ('Unpaid','Paid') AND b.createdby='" & transferFrom & "' AND b.tendertype='Cash' GROUP BY c.itemname
)x 
OUTER APPLY(
SELECT c.itemname,ISNULL(SUM(c.qty),0) [qty] 
FROM tbltransaction2 b INNER JOIN tblorder2 c ON c.ordernum = b.ordernum 
AND CAST(b.datecreated As date)=CAST(c.datecreated AS date) 
WHERE CAST(b.datecreated AS date)=(SELECT TOP 1 CAST(datecreated AS date)
FROM tblinvsum ORDER BY invsumid DESC) AND b.inventory_type='Own Inventory' AND a.item_name = c.itemname AND
b.status2 IN ('Unpaid','Paid') AND b.createdby='" & transferFrom & "' AND b.tendertype='A.R Charge'  GROUP BY c.itemname
)xx
OUTER APPLY(
SELECT c.itemname,ISNULL(SUM(c.qty),0) [qty] 
FROM tbltransaction2 b INNER JOIN tblorder2 c ON c.ordernum = b.ordernum 
AND CAST(b.datecreated As date)=CAST(c.datecreated AS date) 
WHERE CAST(b.datecreated AS date)=(SELECT TOP 1 CAST(datecreated AS date)
FROM tblinvsum ORDER BY invsumid DESC) AND b.inventory_type='Own Inventory' AND a.item_name = c.itemname AND
b.status2 IN ('Unpaid','Paid') AND b.tendertype='A.R Sales' AND b.createdby='" & transferFrom & "'  GROUP BY c.itemname
)xxx
OUTER APPLY(
SELECT ISNULL(SUM(b.quantity),0) [transferFromSales] FROM tblproduction b WHERE b.type2='Transfer from Sales' AND b.inv_id = a.inv_id
AND b.transfer_from = a.transfer_from AND b.item_name = a.item_name
)xxxx
WHERE a.inv_id=(SELECT TOP 1 invnum FROM tblinvsum ORDER BY invsumid DESC) 
AND a.type2='Transfer to Sales' AND a.transfer_from='" & transferFrom & "' AND a.item_name LIKE '%%' 
GROUP BY a.item_name,x.qty,xx.qty,xxx.qty,xxxx.transferFromSales ORDER BY 2 DESC,1 ASC"
            cc.con.Open()
            cc.cmd = New SqlClient.SqlCommand(query, cc.con)
            adptr.SelectCommand = cc.cmd
            adptr.Fill(result)
            cc.con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        Return result
    End Function

End Class
