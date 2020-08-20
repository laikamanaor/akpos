Imports AK_POS.connection_class
Imports System.Data.SqlClient
Public Class pos_class
    Dim cc As New connection_class()
    Public Function checkOrderNumber(ByVal ordernumber As String) As Boolean
        Dim result_num As Integer = 0, result As Boolean = False
        cc.con.Open()
        cc.cmd = New SqlCommand("SELECT dbo.checkOrderNumber(@ordernum)", cc.con)
        cc.cmd.Parameters.AddWithValue("@ordernum", ordernumber)
        result_num = cc.cmd.ExecuteScalar()
        cc.con.Close()
        result = IIf(result_num = 1, True, False)
        Return result
    End Function

    Public Function checkCustomer(ByVal customername As String, ByVal typee As String) As Boolean
        Dim result_num As Integer = 0, result As Boolean = False
        cc.con.Open()
        cc.cmd = New SqlCommand("SELECT dbo.checkCustomer(@name,@type)", cc.con)
        cc.cmd.Parameters.AddWithValue("@name", customername)
        cc.cmd.Parameters.AddWithValue("@type", typee)
        result_num = cc.cmd.ExecuteScalar()
        cc.con.Close()
        result = IIf(result_num <> 0, True, False)
        Return result
    End Function

    Public Function checkStocks(ByVal dgv As DataGridView, ByVal invnum As String) As String
        Dim resut As String = ""
        For index As Integer = 0 To dgv.RowCount - 1
            Dim currentStock As Double = 0.00
            cc.con.Open()
            cc.cmd = New SqlCommand("Select a.endbal FROM tblinvitems a JOIN tblitems b On a.itemname = b.itemname WHERE a.invnum=@invnum And a.itemcode=@itemcode And a.itemname=@itemname And b.category !='Coffee Shop';", cc.con)
            cc.cmd.Parameters.AddWithValue("@invnum", invnum)
            cc.cmd.Parameters.AddWithValue("@itemcode", dgv.Rows(index).Cells("code").Value)
            cc.cmd.Parameters.AddWithValue("@itemname", dgv.Rows(index).Cells("description").Value)
            cc.rdr = cc.cmd.ExecuteReader
            If cc.rdr.Read Then
                currentStock = CDbl(cc.rdr("endbal"))
            End If
            cc.con.Close()

            If CDbl(dgv.Rows(index).Cells("quantity").Value) > currentStock And dgv.Rows(index).Cells("cat").Value <> "Coffee Shop" Then
                resut &= dgv.Rows(index).Cells("description").Value & " - Ending Balance (" & currentStock & ")" & Environment.NewLine
            End If
        Next
        Return resut
    End Function

    Public Function checkQuantity(ByVal dgv As DataGridView) As String
        Dim result As String = ""
        For index As Integer = 0 To dgv.Rows.Count - 1
            If dgv.Rows(index).Cells("quantity").Value = 0 Then
                result &= dgv.Rows(index).Cells("description").Value & Environment.NewLine
            End If
        Next
        Return result
    End Function

    Public Function checkQuantityLevel2(ByVal dgv As DataGridView) As String
        Dim resut As String = ""
        For index As Integer = 0 To dgv.RowCount - 1
            If CBool(dgv.Rows(index).Cells("free").Value) = False And CDbl(dgv.Rows(index).Cells("amtdue").Value) = 0 And CDbl(dgv.Rows(index).Cells("price").Value) <> 0 Then
                resut &= dgv.Rows(index).Cells("description").Value & Environment.NewLine
            End If
        Next
        Return resut
    End Function

    Public Function checkCSFree(ByVal dgv As DataGridView) As String
        Dim result As String = "", result_temp As String = "", errrrr As Integer = 0
        If pos_dialog.ans = "Coffee Shop" Then
            Dim free_count As Integer = 0
            For index As Integer = 0 To dgv.RowCount - 1
                Dim cs_result As Boolean = False, freee As Double = 0.00
                cc.con.Open()
                cc.cmd = New SqlCommand("SELECT free FROM tblcsitems WHERE itemid=(SELECT itemid FROM tblitems WHERE itemname=@itemname);", cc.con)
                cc.cmd.Parameters.AddWithValue("@itemname", dgv.Rows(index).Cells("description").Value)
                cc.rdr = cc.cmd.ExecuteReader
                If cc.rdr.Read Then
                    cs_result = True
                    freee = cc.rdr("free")
                End If
                cc.con.Close()
                If cs_result Then
                    free_count += freee * dgv.Rows(index).Cells("quantity").Value
                    result_temp = dgv.Rows(index).Cells("description").Value & " - Free(" & freee & ")"
                End If
                If CBool(dgv.Rows(index).Cells("free").Value) <> False And dgv.Rows(index).Cells("quantity").Value = free_count Then
                    errrrr += 1
                End If
            Next
            If errrrr = 0 Then
                result = result_temp
            End If
        End If
        Return result
    End Function

    Public Function checkItemAmount(ByVal dgv As DataGridView) As String
        Dim result As String = ""
        For index As Integer = 0 To dgv.RowCount - 1
            If pos_dialog.ans = "Wholesale" Then
                If CDbl(dgv.Rows(index).Cells("amtdue").Value) = 0 Then
                    result &= dgv.Rows(index).Cells("description").Value & Environment.NewLine
                End If
            End If
        Next
        Return result
    End Function


    Public Function advancePaymentTotal(ByVal value As String) As Double
        Dim wordz() As String = value.Split(New Char() {","c})
        Dim wordd As String = "", apamt As Double = 0.00
        Try
            For Each wordd In wordz
                If Not String.IsNullOrEmpty(wordd) Then
                    cc.con.Open()
                    cc.cmd = New SqlCommand("SELECT amount FROM tbladvancepayment WHERE apnum=@apnum AND type='Advance Payment' AND status='Active';", cc.con)
                    cc.cmd.Parameters.AddWithValue("@apnum", wordd)
                    cc.rdr = cc.cmd.ExecuteReader
                    While cc.rdr.Read
                        apamt += CDbl(cc.rdr("amount"))
                    End While
                    cc.con.Close()
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        Return apamt
    End Function

    Public Function itemsDepositPrice(ByVal dataItems As DataTable) As Double
        Dim result As Double = 0.00
        Try
            For Each r0w As DataRow In dataItems.Rows
                cc.con.Open()
                cc.cmd = New SqlCommand("SELECT ISNULL(SUM(" & CDbl(r0w("quantity")) & " * price),0) [depositPrice] FROM tbldepositprice WHERE itemid=(SELECT itemid FROM tblitems WHERE itemname=@itemname) AND status=1;", cc.con)
                cc.cmd.Parameters.AddWithValue("@itemname", r0w("itemname"))
                result += cc.cmd.ExecuteScalar
                cc.con.Close()
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        Return result
    End Function

    Public Function returnAPDEP(ByVal columnName As String, ByVal paramater As String) As String
        Dim result As String = ""
        Try
            cc.con.Open()
            cc.cmd = New SqlCommand("SELECT " & columnName & " FROM tbladvancepayment WHERE apnum=@type;", cc.con)
            cc.cmd.Parameters.AddWithValue("@type", paramater)
            result = cc.cmd.ExecuteScalar
            cc.con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        Return result
    End Function

End Class
