Imports AK_POS.connection_class
Public Class cashier_class
    Dim cc As New connection_class(), transaction As SqlClient.SqlTransaction

    Private vordernum As Integer = 0, vtendertype As String = "", vsales As String = "", vtype As String = "", vdate As Date, vorderid As Integer = 0, vreason As String = ""

    Public Property ordernum As Integer
        Set(value As Integer)
            vordernum = value
        End Set
        Get
            Return vordernum
        End Get
    End Property

    Public Property tendertype As String
        Set(value As String)
            vtendertype = value
        End Set
        Get
            Return vtendertype
        End Get
    End Property

    Public Property sales As String
        Set(value As String)
            vsales = value
        End Set
        Get
            Return vsales
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

    Public Property datee As Date
        Set(value As Date)
            vdate = value
        End Set
        Get
            Return vdate
        End Get
    End Property

    Public Property orderid As Integer
        Set(value As Integer)
            vorderid = value
        End Set
        Get
            Return vorderid
        End Get
    End Property

    Public Property reason As String
        Set(value As String)
            vreason = value
        End Set
        Get
            Return vreason
        End Get
    End Property

    Public Function loadPendingOrders(ByVal offset As Integer, rowFetch As Integer) As DataTable
        Dim result As New DataTable(), adptr As New SqlClient.SqlDataAdapter
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT * FROM dbo.funcLoadPendingOrders(@ordernum,@tendertype,@sales,@type,@offset,@rowfetch)", cc.con)
        cc.cmd.Parameters.AddWithValue("@ordernum", IIf(vordernum = 0, "", vordernum.ToString))
        cc.cmd.Parameters.AddWithValue("@tendertype", vtendertype)
        cc.cmd.Parameters.AddWithValue("@sales", vsales)
        cc.cmd.Parameters.AddWithValue("@type", vtype)
        cc.cmd.Parameters.AddWithValue("@offset", offset)
        cc.cmd.Parameters.AddWithValue("@rowfetch", rowFetch)
        adptr.SelectCommand = cc.cmd
        adptr.Fill(result)
        cc.con.Close()
        Return result
    End Function

    Public Function loadItems() As DataTable
        Dim result As New DataTable(), adptr As New SqlClient.SqlDataAdapter
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT a.orderid,a.itemname,a.qty,a.price,a.dscnt,a.totalprice,a.free,a.discamt,a.pricebefore FROM tblorder2 a INNER JOIN tbltransaction2 b ON a.ordernum = b.ordernum WHERE CAST(a.datecreated AS date)=@date AND b.orderid=@orderid AND a.status=1", cc.con)
        cc.cmd.Parameters.AddWithValue("@date", vdate.ToString("MM/dd/yyyy"))
        cc.cmd.Parameters.AddWithValue("orderid", vorderid)
        adptr.SelectCommand = cc.cmd
        adptr.Fill(result)
        cc.con.Close()
        Return result
    End Function

    Public Function countData() As Integer
        Dim result As Integer = 0
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT  dbo.funcCountPendingOrders(@ordernum,@tendertype,@sales,@type)", cc.con)
        cc.cmd.Parameters.AddWithValue("@ordernum", IIf(vordernum = 0, "", vordernum.ToString))
        cc.cmd.Parameters.AddWithValue("@tendertype", vtendertype)
        cc.cmd.Parameters.AddWithValue("@sales", vsales)
        cc.cmd.Parameters.AddWithValue("@type", vtype)
        result = cc.cmd.ExecuteScalar
        cc.con.Close()
        Return result
    End Function


    Public Function loadBills() As DataTable
        Dim result As New DataTable(), adptr As New SqlClient.SqlDataAdapter
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT a.subtotal,a.disctype,a.less,a.amtdue,a.tenderamt,a.change,discamt FROM tbltransaction2 a WHERE a.orderid=@orderid", cc.con)
        cc.cmd.Parameters.AddWithValue("orderid", vorderid)
        adptr.SelectCommand = cc.cmd
        adptr.Fill(result)
        cc.con.Close()
        Return result
    End Function

    Public Function returnSalesAgent() As DataTable
        Dim result As New DataTable(), adptr As New SqlClient.SqlDataAdapter
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT username from tblusers WHERE status=1 AND workgroup IN ('Sales','Manager','LC Accounting','Administrator') ORDER BY username;", cc.con)
        adptr.SelectCommand = cc.cmd
        adptr.Fill(result)
        cc.con.Close()
        Return result
    End Function

    Public Function returnOrderStatus() As String
        Dim result As String = ""
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT status2 FROM tbltransaction2 WHERE orderid=@orderid;", cc.con)
        cc.cmd.Parameters.AddWithValue("@orderid", vorderid)
        result = cc.cmd.ExecuteScalar
        cc.con.Close()
        Return result
    End Function

    Public Sub voidOrder()
        Try
            Using connection As New SqlClient.SqlConnection(cc.conString)
                Dim command As New SqlClient.SqlCommand()
                command.Connection = connection

                connection.Open()
                transaction = connection.BeginTransaction()

                command.Transaction = transaction

                command.CommandText = "UPDATE tbltransaction2 SET status2='Void', reason=@reason WHERE orderid=@orderid"
                command.Parameters.AddWithValue("@reason", vreason)
                command.Parameters.AddWithValue("@orderid", vorderid)
                command.ExecuteNonQuery()

                transaction.Commit()
                MessageBox.Show("Transaction Complete", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

    Public Function haveDepositItem() As DataTable
        Dim result As New DataTable, dtItems As New DataTable(), adptr As New SqlClient.SqlDataAdapter
        dtItems.Columns.Add("item")
        dtItems.Columns.Add("quantity")
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT b.itemname,b.qty FROM tbltransaction2 a INNER JOIN tblorder2 b ON a.ordernum = b.ordernum WHERE a.orderid=@orderid;", cc.con)
        cc.cmd.Parameters.AddWithValue("@orderid", vorderid)
        cc.rdr = cc.cmd.ExecuteReader
        While cc.rdr.Read
            dtItems.Rows.Add(cc.rdr("itemname"), cc.rdr("qty"))
        End While
        cc.con.Close()

        For Each r0w As DataRow In dtItems.Rows
            cc.con.Open()
            cc.cmd = New SqlClient.SqlCommand("SELECT a.itemname,b.price,@quantity [quantity] FROM tblitems a INNER JOIN tbldepositprice b ON a.itemid = b.itemid WHERE itemname=@itemname;", cc.con)
            cc.cmd.Parameters.AddWithValue("@itemname", r0w("item"))
            cc.cmd.Parameters.AddWithValue("@quantity", r0w("quantity"))
            adptr.SelectCommand = cc.cmd
            adptr.Fill(result)
            cc.con.Close()
        Next
        Return result
    End Function

    Public Function checkDepositTransnum(ByVal transnums As String, totalDeposit As Double) As Boolean
        Dim words() As String = transnums.Split(New Char() {","c}), result As Boolean = False
        Dim word As String = "", totalDepositByTransnums As Double = 0.00
        For Each word In words
            cc.con.Open()
            cc.cmd = New SqlClient.SqlCommand("SELECT amount FROM tbladvancepayment WHERE apnum=@apnum;", cc.con)
            cc.cmd.Parameters.AddWithValue("@apnum", word)
            totalDepositByTransnums += cc.cmd.ExecuteScalar
            cc.con.Close()
        Next
        If totalDepositByTransnums >= totalDeposit Then
            result = True
        Else
            result = False
        End If
        Return result
    End Function

    Public Function returnDepositTransnumAmounts(ByVal transnums As String) As Double
        Dim words() As String = transnums.Split(New Char() {","c})
        Dim word As String = "", result As Double = 0.00
        For Each word In words
            cc.con.Open()
            cc.cmd = New SqlClient.SqlCommand("SELECT amount FROM tbladvancepayment WHERE apnum=@apnum;", cc.con)
            cc.cmd.Parameters.AddWithValue("@apnum", word)
            result += cc.cmd.ExecuteScalar
            cc.con.Close()
        Next
        Return result
    End Function

End Class
