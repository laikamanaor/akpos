Imports AK_POS.connection_class
Imports System.Data.SqlClient
Public Class adjustment_class
    Dim cc As New connection_class(), transaction As SqlTransaction
    Private vdatecreated As String = "", vstatus As String = "", vtransnum As String = "", vtype As String = "", vitemname As String = "", vinvnum As String = ""

    Public Property datecreated As String
        Set(value As String)
            vdatecreated = value
        End Set
        Get
            Return vdatecreated
        End Get
    End Property

    Public Property status As String
        Set(value As String)
            vstatus = value
        End Set
        Get
            Return vstatus
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

    Public Property invnum As String
        Set(value As String)
            vinvnum = value
        End Set
        Get
            Return vinvnum
        End Get
    End Property

    Public Function loadTransaction(ByVal offset As Integer, rowFetch As Integer) As DataTable
        Dim result As New DataTable(), adptr As New SqlClient.SqlDataAdapter
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT DISTINCT inv_id,transaction_number,type2,processed_by FROM tblproduction WHERE type=@type AND CAST(date AS date)=@date AND status=@status AND transaction_number LIKE '%" & vtransnum & "%' ORDER BY transaction_number OFFSET @offset ROW FETCH NEXT @rowfetch ROWS ONLY", cc.con)
        cc.cmd.Parameters.AddWithValue("@type", vtype)
        cc.cmd.Parameters.AddWithValue("@status", vstatus)
        cc.cmd.Parameters.AddWithValue("@date", vdatecreated)
        cc.cmd.Parameters.AddWithValue("@offset", offset)
        cc.cmd.Parameters.AddWithValue("@rowfetch", rowFetch)
        adptr.SelectCommand = cc.cmd
        adptr.Fill(result)
        cc.con.Close()
        Return result
    End Function

    Public Function countData() As Integer
        Dim result As Integer = 0, rdr As SqlClient.SqlDataReader
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT DISTINCT transaction_number FROM tblproduction WHERE type=@type AND CAST(date AS date)=@date AND status=@status AND transaction_number LIKE '%" & vtransnum & "%' ORDER BY transaction_number ASC", cc.con)
        cc.cmd.Parameters.AddWithValue("@type", vtype)
        cc.cmd.Parameters.AddWithValue("@status", vstatus)
        cc.cmd.Parameters.AddWithValue("@date", vdatecreated)
        rdr = cc.cmd.ExecuteReader
        While rdr.Read
            result += 1
        End While
        cc.con.Close()
        Return result
    End Function

    ''' <summary>
    ''' load items where transaction number
    ''' </summary>
    ''' <returns></returns>
    Public Function loadItems() As DataTable
        Dim result As New DataTable(), adptr As New SqlClient.SqlDataAdapter
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT item_name,category,quantity,charge FROM tblproduction WHERE transaction_number=@transnum;", cc.con)
        cc.cmd.Parameters.AddWithValue("@transnum", vtransnum)
        adptr.SelectCommand = cc.cmd
        adptr.Fill(result)
        cc.con.Close()
        Return result
    End Function

    Public Function checkTransactionStatus() As Boolean
        Dim result As Boolean = False, result_int As Integer = 0
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT dbo.checkTransactionStatus(@transnum)", cc.con)
        cc.cmd.Parameters.AddWithValue("@transnum", vtransnum)
        result_int = cc.cmd.ExecuteScalar
        cc.con.Close()
        result = IIf(result_int = 0, False, True)
        Return result
    End Function

    Public Function checkQuantity() As DataTable
        Dim result As New DataTable(), adptr As New SqlClient.SqlDataAdapter
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT a.item_name,a.quantity,b.endbal FROM tblproduction a JOIN tblinvitems b ON a.item_name = b.itemname  WHERE a.transaction_number=@transnum AND b.invnum=@invnum GROUP BY a.item_name,a.quantity,b.endbal HAVING SUM(a.quantity) > SUM(b.endbal)", cc.con)
        cc.cmd.Parameters.AddWithValue("@transnum", vtransnum)
        cc.cmd.Parameters.AddWithValue("@itemname", vitemname)
        cc.cmd.Parameters.AddWithValue("@invnum", vinvnum)
        adptr.SelectCommand = cc.cmd
        adptr.Fill(result)
        cc.con.Close()
        Return result
    End Function

    Public Sub cancelTransaction(ByVal dtItems As DataTable, ByVal columName As String)
        Try
            Using connection As New SqlConnection(cc.conString)
                Dim command As New SqlCommand()
                command.Connection = connection
                connection.Open()
                transaction = connection.BeginTransaction()
                command.Transaction = transaction

                command.Parameters.Clear()
                command.CommandText = "cancelRecTrans"
                command.Parameters.AddWithValue("@transnum", vtransnum)
                command.CommandType = CommandType.StoredProcedure
                command.ExecuteNonQuery()
                If dtItems.Rows.Count > 0 Then
                    For Each r0w As DataRow In dtItems.Rows
                        command.Parameters.Clear()
                        command.CommandType = CommandType.Text
                        command.CommandText = "UPDATE tblinvitems SET " & columName & "-=@quantity,charge-=@charge,archarge-=@charge" & IIf(columName = "transfer", "", ",totalav-=@quantity") & ",endbal" & IIf(columName = "transfer", "+", "-") & "=@quantity,variance" & IIf(columName = "transfer", "-", "+") & "=@quantity WHERE invnum=@invnum AND itemname=@itemname;"
                        command.Parameters.AddWithValue("@charge", CDbl(r0w("charge")))
                        command.Parameters.AddWithValue("@quantity", CDbl(r0w("quantity")))
                        command.Parameters.AddWithValue("@invnum", invnum)
                        command.Parameters.AddWithValue("@itemname", CStr(r0w("item_name")))
                        command.ExecuteNonQuery()
                    Next
                End If
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

End Class
