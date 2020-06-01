Imports AK_POS.connection_class
Imports System.Data.SqlClient
Public Class pos2_class
    Dim cc As New connection_class()
    Private catoffset As Integer = 0, catrowFetch As Integer = 0,
        itemoffset As Integer = 0, itemrowFetch As Integer = 0,
        itemname As String = "", vdatecreated As New DateTime,
        vitemid As Integer = 0, vcategory As String = ""
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

    Public Property category As String
        Set(value As String)
            vcategory = value
        End Set
        Get
            Return vcategory
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
        cc.cmd = New SqlClient.SqlCommand("SELECT * FROM funcLoadItemswithEndbal(@date,@itemname,@offset,@rowfetch,@category)", cc.con)
        cc.cmd.Parameters.AddWithValue("@date", dateParameter.ToString("MM/dd/yyyy"))
        cc.cmd.Parameters.AddWithValue("@itemname", itemname)
        cc.cmd.Parameters.AddWithValue("@category", vcategory)
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


    Public Function checkQuantity(ByVal dgv As DataGridView) As String
        Dim result As String = ""
        For index As Integer = 0 To dgv.Rows.Count - 1
            If dgv.Rows(index).Cells("quantity").Value = 0 Then
                result &= dgv.Rows(index).Cells("item").Value & Environment.NewLine
            End If
        Next
        Return result
    End Function

    Public Function checkQuantityLevel2(ByVal dgv As DataGridView) As String
        Dim resut As String = ""
        For index As Integer = 0 To dgv.RowCount - 1
            If CBool(dgv.Rows(index).Cells("free").Value) = False And CDbl(dgv.Rows(index).Cells("amount").Value) = 0 And CDbl(dgv.Rows(index).Cells("price").Value) <> 0 Then
                resut &= dgv.Rows(index).Cells("item").Value & Environment.NewLine
            End If
        Next
        Return resut
    End Function

    Public Function checkCSFree(ByVal dgv As DataGridView) As String
        Dim result As String = "", result_temp As String = "", freeitems_qty As Double = 0.00
        If pos_dialog.ans = "Coffee Shop" Then
            Dim free_count As Integer = 0
            For index As Integer = 0 To dgv.RowCount - 1
                Dim cs_result As Boolean = False, freee As Double = 0.00, category As String = ""
                cc.con.Open()
                cc.cmd = New SqlCommand("SELECT a.free,b.category FROM tblcsitems a INNER JOIN tblitems b ON a.itemid = b.itemid WHERE a.itemid=(SELECT itemid FROM tblitems WHERE itemname=@itemname) AND b.category='Coffee Shop';", cc.con)
                cc.cmd.Parameters.AddWithValue("@itemname", dgv.Rows(index).Cells("item").Value)
                cc.rdr = cc.cmd.ExecuteReader
                If cc.rdr.Read Then
                    cs_result = True
                    freee = cc.rdr("free")
                    category = cc.rdr("category")
                End If
                cc.con.Close()
                If cs_result Then
                    free_count += freee * dgv.Rows(index).Cells("quantity").Value
                    result_temp = dgv.Rows(index).Cells("item").Value & " - Free(" & free_count & ")"
                End If
                If dgv.Rows(index).Cells("free").Value = True And category = "" Then
                    freeitems_qty += dgv.Rows(index).Cells("quantity").Value
                End If
            Next
            If freeitems_qty < free_count Then
                result = result_temp
            End If
        End If
        Return result
    End Function

    Public Function checkItemAmount(ByVal dgv As DataGridView) As String
        Dim result As String = ""
        For index As Integer = 0 To dgv.RowCount - 1
            If pos_dialog.ans = "Wholesale" Then
                If CDbl(dgv.Rows(index).Cells("amount").Value) = 0 Then
                    result &= dgv.Rows(index).Cells("item").Value & Environment.NewLine
                End If
            End If
        Next
        Return result
    End Function

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

    Public Function checkCoffeeShopItem(posdialog As String, grd As DataGridView) As String
        Dim errorCategory As String = "Below item is invalid for " & posdialog & Environment.NewLine
        For index As Integer = 0 To grd.RowCount - 1
            Dim chckCategory As String = ""
            If pos_dialog.ans = posdialog Then
                cc.con.Open()
                cc.cmd = New SqlCommand("Select category FROM tblitems WHERE itemname=@iname;", cc.con)
                cc.cmd.Parameters.AddWithValue("@iname", grd.Rows(index).Cells("item").Value)
                chckCategory = cc.cmd.ExecuteScalar
                cc.con.Close()

                If posdialog = "Coffee Shop" Then
                    If chckCategory = "Breads" Or chckCategory = "Beverages" Or chckCategory = "Coffee Shop" Then
                        Continue For
                    Else
                        errorCategory &= grd.Rows(index).Cells("item").Value & Environment.NewLine
                    End If
                Else
                    If pos_dialog.ans <> posdialog Then
                        errorCategory &= grd.Rows(index).Cells("item").Value & Environment.NewLine
                    End If
                End If
            End If
        Next
        'If errorCategory <> "Below item Is invalid for " & posdialog & Environment.NewLine Then
        '    Return errorCategory
        'End If
        Return errorCategory
    End Function

    Public Function checkStocks(ByVal dgv As DataGridView, ByVal datecreated As String) As String
        Dim resut As String = ""
        For index As Integer = 0 To dgv.RowCount - 1
            Dim currentStock As Double = 0.00, category As String = ""
            cc.con.Open()
            cc.cmd = New SqlCommand("Select a.endbal,b.category FROM tblinvitems a JOIN tblitems b On a.itemname = b.itemname WHERE a.invnum=(SELECT invnum FROM tblinvsum WHERE CAST(datecreated AS date)=@date) AND a.itemcode=(SELECT itemcode FROM tblitems WHERE itemname=@itemname) AND a.itemname=@itemname;", cc.con)
            cc.cmd.Parameters.AddWithValue("@date", datecreated)
            cc.cmd.Parameters.AddWithValue("@itemname", dgv.Rows(index).Cells("item").Value)
            cc.rdr = cc.cmd.ExecuteReader
            If cc.rdr.Read Then
                currentStock = CDbl(cc.rdr("endbal"))
                category = cc.rdr("category")
            End If
            cc.con.Close()
            If CDbl(dgv.Rows(index).Cells("quantity").Value) > currentStock And category <> "Coffee Shop" Then
                resut &= dgv.Rows(index).Cells("item").Value & " - Ending Balance (" & currentStock & ")" & Environment.NewLine
            End If
        Next
        Return resut
    End Function

    Public Function returnEndingBalance() As Double
        Dim dateParameter As New DateTime()
        dateParameter = getDateParameterResult()
        Dim result As Double = 0.00
        cc.con.Open()
        cc.cmd = New SqlCommand("Select a.endbal FROM tblinvitems a JOIN tblitems b On a.itemname = b.itemname WHERE a.invnum=(SELECT invnum FROM tblinvsum WHERE CAST(datecreated AS date)=@date) AND a.itemcode=(SELECT itemcode FROM tblitems WHERE itemname=@itemname) AND a.itemname=@itemname AND b.category='Coffee Shop';", cc.con)
        cc.cmd.Parameters.AddWithValue("@date", dateParameter.ToString("MM/dd/yyyy"))
        cc.cmd.Parameters.AddWithValue("@itemname", itemname)
        result = cc.cmd.ExecuteScalar
        cc.con.Close()
        Return result
    End Function

    Public Function returnCategory() As String
        Dim result As String = ""
        cc.con.Open()
        cc.cmd = New SqlCommand("SELECT category FROM tblitems WHERE itemname=@itemname;", cc.con)
        cc.cmd.Parameters.AddWithValue("@itemname", itemname)
        result = IIf(IsDBNull(cc.cmd.ExecuteScalar), "", cc.cmd.ExecuteScalar)
        cc.con.Close()
        Return result
    End Function

End Class
