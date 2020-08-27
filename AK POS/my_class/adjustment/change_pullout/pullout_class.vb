Imports AK_POS.connection_class
Imports System.Data.SqlClient
Public Class pullout_class
    Dim cc As New connection_class(), transaction As SqlTransaction
    Private itemname As String = "", category As String = "", datee As String = "", invid As Integer = 0, qty As Double = 0.00, trannum As String = "", toBranch As String = ""
    Public ReadOnly Property getCategory() As String
        Get
            Return category
        End Get
    End Property
    Public Sub setCategory(ByVal value As String)
        category = value
    End Sub
    Public ReadOnly Property getItemName() As String
        Get
            Return itemname
        End Get
    End Property
    Public Sub setItemName(ByVal value As String)
        itemname = value
    End Sub
    Public ReadOnly Property getDatee() As String
        Get
            Return datee
        End Get
    End Property
    Public Sub setInvID(ByVal value As Integer)
        invid = value
    End Sub
    Public ReadOnly Property getInvID() As Integer
        Get
            Return invid
        End Get
    End Property
    Public Sub setDatee(ByVal value As String)
        datee = value
    End Sub
    Public ReadOnly Property getQty() As Double
        Get
            Return qty
        End Get
    End Property
    Public Sub setQty(ByVal value As Double)
        qty = value
    End Sub
    Public ReadOnly Property getToBranch() As String
        Get
            Return toBranch
        End Get
    End Property
    Public Sub setToBanch(ByVal value As String)
        toBranch = value
    End Sub
    Public Function showInventory() As DataTable
        Dim query As String = ""

        query = IIf(invid = 0, "SELECT a.invid,b.category,a.itemname,SUM(a.actualendbal-a.endbal) AS qty FROM tblinvitems a INNER JOIN tblitems b ON a.itemname = b.itemname WHERE a.invnum=(SELECT invnum FROM tblinvsum WHERE CAST(datecreated AS date)='" & datee & "') AND a.itemname LIKE '%" & itemname & "%'" & IIf(category = "All", "", " AND b.category='" & category & "'") & " AND a.endbal !=0 GROUP BY a.invid,b.category,a.itemname,a.actualendbal,a.endbal HAVING SUM(a.actualendbal-a.endbal) !=0;", "SELECT b.category,a.itemname, SUM(a.actualendbal-a.endbal) AS qty FROM tblinvitems a INNER JOIN tblitems b ON a.itemname = b.itemname WHERE invid=" & invid & " GROUP BY a.invid,b.category,a.itemname,a.actualendbal,a.endbal HAVING SUM(a.actualendbal-a.endbal) !=0;")
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand(query, cc.con)
        Dim adptr As New SqlClient.SqlDataAdapter()
        Dim dt As New DataTable()
        adptr.SelectCommand = cc.cmd
        adptr.Fill(dt)
        cc.con.Close()
        Return dt
    End Function
    Public Function showCategories() As DataTable
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT category FROM tblcat WHERE status=1;", cc.con)
        Dim adptr As New SqlClient.SqlDataAdapter()
        Dim dt As New DataTable()
        adptr.SelectCommand = cc.cmd
        adptr.Fill(dt)
        cc.con.Close()
        Return dt
    End Function
    Public Sub GetTransID()
        Try
            Dim selectcount_result As Integer = 0
            Dim get_area As String = "", temp As String = "0"
            Dim area_format As String = ""
            cc.con.Close()
            cc.con.Open()
            cc.cmd = New SqlCommand("Select ISNULL(MAX(transaction_id),0) transaction_number  from tblproduction WHERE area='" & "Sales" & "' AND type='Transfer Item' AND type2='Transfer';", cc.con)
            selectcount_result = cc.cmd.ExecuteScalar + 1
            cc.con.Close()
            Dim branchcode As String = ""
            cc.con.Open()
            cc.cmd = New SqlCommand("SELECT branchcode FROM tblbranch WHERE main='1';", cc.con)
            cc.rdr = cc.cmd.ExecuteReader
            While cc.rdr.Read
                branchcode = cc.rdr("branchcode")
            End While
            cc.con.Close()
            area_format = "TRA - " & branchcode & " - "

            If selectcount_result < 1000000 Then
                Dim cselectcount_result As String = CStr(selectcount_result)
                For vv As Integer = 1 To 6 - cselectcount_result.Length
                    temp += "0"
                Next
                trannum = area_format & temp & selectcount_result
            Else
                trannum = area_format & temp & selectcount_result
            End If
        Catch ex As System.InvalidOperationException
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "")
        Finally
            cc.con.Close()
        End Try
    End Sub
    Public Sub POTransaction()
        Try
            Dim mainBranch As String = "", dtBranch As New DataTable()
            dtBranch = getMainBranch(1)
            GetTransID()
            For Each r0w As DataRow In dtBranch.Rows
                mainBranch = r0w("branchcode")
            Next
            Using connection As New SqlConnection(cc.conString)
                Dim cmdd As New SqlCommand()
                cmdd.Connection = connection
                connection.Open()
                transaction = connection.BeginTransaction()
                cmdd.Transaction = transaction

                cmdd.Parameters.Clear()
                cmdd.CommandText = "INSERT INTO tblproduction (transaction_number,inv_id,item_code,item_name,category,quantity,sap_number,remarks,date,processed_by,type,transfer_to,transfer_from,status,area,from_transnum,reject,charge,typenum,type2) VALUES (@trans_id,(SELECT invnum FROM tblinvsum WHERE CAST(datecreated AS date)='" & datee & "'), (SELECT itemcode FROM tblitems WHERE itemname=@name),@name,@cat,@qty,@sap,@remarks,(SELECT GETDATE()),@processed_by,@type,@transfer_to,@transfer_from,@status,@area,@from_transnum,@reject,@charge,@typenum,@type2)"
                cmdd.Parameters.AddWithValue("@trans_id", trannum)
                cmdd.Parameters.AddWithValue("@name", itemname)
                cmdd.Parameters.AddWithValue("@cat", category)
                cmdd.Parameters.AddWithValue("@qty", CDbl(qty))
                cmdd.Parameters.AddWithValue("@sap", "To Follow")
                cmdd.Parameters.AddWithValue("@remarks", "pull out")
                cmdd.Parameters.AddWithValue("@processed_by", login2.username)
                cmdd.Parameters.AddWithValue("@type", "Transfer Item")
                cmdd.Parameters.AddWithValue("@transfer_to", toBranch)
                cmdd.Parameters.AddWithValue("@transfer_from", mainBranch)
                cmdd.Parameters.AddWithValue("@status", "Completed")
                cmdd.Parameters.AddWithValue("@area", "Sales")
                cmdd.Parameters.AddWithValue("@from_transnum", "")
                cmdd.Parameters.AddWithValue("@reject", "0")
                cmdd.Parameters.AddWithValue("@charge", "0")
                cmdd.Parameters.AddWithValue("@typenum", "IT")
                cmdd.Parameters.AddWithValue("@type2", "Transfer")
                cmdd.ExecuteNonQuery()

                cmdd.CommandText = "UPDATE tblinvitems SET actualendbal-=" & qty & ",transfer+=" & qty & ",variance-=" & qty & " WHERE invid=" & invid & ";"
                cmdd.ExecuteNonQuery()

                cmdd.CommandText = "UPDATE tblproduction SET quantity-=" & qty & " WHERE inv_id=(SELECT invnum FROM tblinvsum WHERE CAST(datecreated AS date)='" & datee & "') AND type='Actual Ending Balance';"
                cmdd.ExecuteNonQuery()

                transaction.Commit()
                MessageBox.Show("Transaction Completed", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            Try
                MessageBox.Show(ex.ToString)
                transaction.Rollback()
            Catch ex2 As Exception
                MessageBox.Show(ex2.ToString)
            End Try
        End Try
    End Sub

    Public Function getMainBranch(ByVal status As Integer) As DataTable
        Dim dt As New DataTable(), adptr As New SqlDataAdapter()
        cc.con.Open()
        cc.cmd = New SqlCommand("SELECT branchcode FROM tblbranch WHERE main=" & status & ";", cc.con)
        adptr.SelectCommand = cc.cmd
        adptr.Fill(dt)
        Return dt
    End Function

    Public Function checkBranch(ByVal value As String) As Boolean
        Dim result As Boolean = False
        cc.con.Close()
        cc.con.Open()
        cc.cmd = New SqlCommand("SELECT brid FROM tblbranch WHERE branchcode='" & value & "';", cc.con)
        cc.rdr = cc.cmd.ExecuteReader
        If cc.rdr.Read Then
            result = True
        End If
        cc.con.Close()
        Return result
    End Function

End Class
