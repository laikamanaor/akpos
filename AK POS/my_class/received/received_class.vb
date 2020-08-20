Imports System.Data.SqlClient
Imports AK_POS.connection_class
Public Class received_class
    Dim cc As New connection_class(), transaction As SqlTransaction
    Private sap_number As String = "", datecreated As String, itemname As String = "", category As String = "", vheaderText As String, vinventorynum As String = "", vtableName As String = "", vtransactionNumber As String, vsapNumber As Integer = 0, vsapDoc As String = "", vremarks As String = "", vfromBranch As String = "", vconvnum As String = "", vtype, vtype2
    Public Sub setSAPNumber(ByVal value As String)
        sap_number = value
    End Sub
    Public ReadOnly Property getSAPNumber() As String
        Get
            Return sap_number
        End Get
    End Property
    Public Sub setDateCreated(ByVal value As String)
        datecreated = value
    End Sub
    Public ReadOnly Property getDateCreated() As String
        Get
            Return datecreated
        End Get
    End Property
    Public Sub setItemName(ByVal value As String)
        itemname = value
    End Sub
    Public ReadOnly Property getItemName() As String
        Get
            Return itemname
        End Get
    End Property
    Public Sub setCategory(ByVal value As String)
        category = value
    End Sub
    Public ReadOnly Property getCategory() As String
        Get
            Return category
        End Get
    End Property
    Public Property headerText As String
        Set(value As String)
            vheaderText = value
        End Set
        Get
            Return vheaderText
        End Get
    End Property
    Public Property inventoryNumber As String
        Set(value As String)
            vinventorynum = value
        End Set
        Get
            Return vinventorynum
        End Get
    End Property
    Public Property tableName As String
        Set(value As String)
            vtableName = value
        End Set
        Get
            Return vtableName
        End Get
    End Property
    Public Property transactionNumber As String
        Set(value As String)
            vtransactionNumber = value
        End Set
        Get
            Return vtransactionNumber
        End Get
    End Property
    Public Property sapNumber As Integer
        Set(value As Integer)
            vsapNumber = value
        End Set
        Get
            Return vsapNumber
        End Get
    End Property
    Public Property sapDocument As String
        Set(value As String)
            vsapDoc = value
        End Set
        Get
            Return vsapDoc
        End Get
    End Property
    Public Property remarks As String
        Set(value As String)
            vremarks = value
        End Set
        Get
            Return vremarks
        End Get
    End Property
    Public Property fromBranchSupplier As String
        Set(value As String)
            vfromBranch = value
        End Set
        Get
            Return vfromBranch
        End Get
    End Property
    Public Property convNumber As String
        Set(value As String)
            vconvnum = value
        End Set
        Get
            Return vconvnum
        End Get
    End Property

    Public Property type As String
        Set(value As String)
            vtype = value
        End Set
        Get
            Return vtype
        End Get
    End Property

    Public Property type2 As String
        Set(value As String)
            vtype2 = value
        End Set
        Get
            Return vtype2
        End Get
    End Property

    ''' <summary>
    ''' Check SAP Number if exist
    ''' </summary>
    ''' <returns></returns>
    Public Function checkSAPNumber() As Boolean
        Dim result_num As Integer = 0, result As Boolean = False
        cc.con.Open()
        cc.cmd = New SqlCommand("SELECT dbo.checkSAPNumber(@sap_number)", cc.con)
        cc.cmd.Parameters.AddWithValue("@sap_number", sap_number)
        result_num = cc.cmd.ExecuteScalar()
        cc.con.Close()
        result = IIf(result_num = 1, True, False)
        Return result
    End Function

    ''' <summary>
    ''' return the result of branch code and supplier
    ''' </summary>
    ''' <param name="cmdText"></param>
    ''' <returns></returns>
    Public Function loadBranchesCustomers(ByVal cmdText As String) As DataTable
        Dim result As New DataTable(), adptr As New SqlDataAdapter()
        cc.con.Open()
        cc.cmd = New SqlCommand(cmdText, cc.con)
        adptr.SelectCommand = cc.cmd
        adptr.Fill(result)
        cc.con.Close()
        Return result
    End Function

    Public Function loadCategories() As DataTable
        Dim result As New DataTable(), adptr As New SqlDataAdapter()
        cc.con.Open()
        cc.cmd = New SqlCommand("SELECT category AS result FROM tblcat WHERE status=1 ORDER BY category", cc.con)
        adptr.SelectCommand = cc.cmd
        adptr.Fill(result)
        cc.con.Close()
        Return result
    End Function

    Public Function loadAvailableItems(ByVal rectrans As String) As DataTable
        Dim result As New DataTable(), adptr As New SqlDataAdapter(),
            rec As String = "SELECT * FROM funcLoadInventoryItems(@datecreated,@itemname,@category)",
            trans As String = "SELECT * FROM funcLoadStockItems(@datecreated,@itemname,@category)"
        cc.con.Open()
        cc.cmd = New SqlCommand(IIf(rectrans = "rec", rec, trans), cc.con)
        cc.cmd.Parameters.AddWithValue("@datecreated", datecreated)
        cc.cmd.Parameters.AddWithValue("@itemname", itemname)
        cc.cmd.Parameters.AddWithValue("@category", category)
        adptr.SelectCommand = cc.cmd
        adptr.Fill(result)
        cc.con.Close()
        Return result
    End Function

    Public Function returnTransactionNumber(ByVal isRecTrans As Boolean) As String
        Dim result As Integer = 0, totalZero As String = "", result_format As String = "", taypz As String = "", type2 As String = "", branchcode As String = "", template As String = ""
        If headerText = "Received from Adjustment" Then
            taypz = "Adjustment Item"
        ElseIf headerText = "Transfer Out" Then
            taypz = "Transfer Item"
        ElseIf headerText = "Conversion Out" Then
            taypz = "Parent"
        ElseIf headerText = "Conversion In" Then
            taypz = "Child"
        ElseIf headerText = "Pull Out" Then
            taypz = "Pull Out"
        Else
            taypz = "Received Item"
        End If
        type2 = IIf(headerText = "Transfer Out", "Transfer", headerText)

        Dim rectrans_query As String = "Select ISNULL(MAX(transaction_id),0) +1 from tblproduction WHERE area='Sales' AND type='" & taypz & "' AND type2='" & type2 & "';",
            conv_query As String = "SELECT ISNULL(MAX(conv_id),0) +1 FROM tblconversion WHERE area='Sales' AND type='" & taypz & "';",
            result_query As String = ""
        result_query = IIf(isRecTrans, rectrans_query, conv_query)

        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand(result_query, cc.con)
        result = cc.cmd.ExecuteScalar
        cc.con.Close()

        cc.con.Open()
        cc.cmd.CommandText = "SELECT branchcode FROM tblbranch WHERE main='1';"
        branchcode = cc.cmd.ExecuteScalar & " - "
        cc.con.Close()

        Select Case headerText
            Case "Received from Production"
                template = "RECPROD - "
            Case "Received from Other Branch"
                template = "RECBRA - "
            Case "Received from Direct Supplier"
                template = "RECSUPP - "
            Case "Received from Adjustment"
                template = "ADJIN - "
            Case "Transfer Out"
                template = "TRA - "
            Case "Conversion Out"
                template = "CONVOUT - "
            Case "Conversion In"
                template = "CONVIN - "
            Case "Pull Out"
                template = "PO - "
        End Select

        If result < 1000000 Then
            Dim cselectcount_result As String = CStr(result)
            For temp As Integer = 0 To 6 - cselectcount_result.Length
                totalZero += "0"
            Next
            result_format = template & branchcode & totalZero & result
        Else
            result_format = template & branchcode & totalZero & result
        End If
        Return result_format
    End Function

    Public Function returnBranchCode() As String
        Dim result As String = ""
        cc.con.Open()
        cc.cmd.CommandText = "SELECT branchcode FROM tblbranch WHERE main='1';"
        result = cc.cmd.ExecuteScalar
        cc.con.Close()
        Return result
    End Function

    Public Function loadBranchesSupplier() As DataTable
        Dim result As New DataTable(), adptr As New SqlDataAdapter
        If vheaderText = "Received from Direct Supplier" Then
            cc.con.Open()
            cc.cmd = New SqlCommand("SELECT branchcode FROM tblbranch WHERE main='0' AND status=1", cc.con)
            adptr.SelectCommand = cc.cmd
            adptr.Fill(result)
            cc.con.Close()
        ElseIf vheaderText = "Received from Other Branch" Then
            cc.con.Open()
            cc.cmd = New SqlCommand("SELECT name FROM tblcustomers WHERE type='Supplier' AND status='1';", cc.con)
            adptr.SelectCommand = cc.cmd
            adptr.Fill(result)
            cc.con.Close()
        End If
        Return result
    End Function

    Public Sub updateInventory(ByVal dt As DataTable)
        Try
            Dim toBranch As String = returnBranchCode() & IIf(vheaderText = "Transfer Out", " (SLS)", " (PRD)"), fromBranch As String = "", taypz As String = ""
            If vheaderText = "Received from Production" Or vheaderText = "Received from Adjustment" Then
                fromBranch = returnBranchCode() & " (SLS)"
            Else
                fromBranch = vfromBranch
            End If
            If headerText = "Received from Adjustment" Then
                taypz = "Adjustment Item"
            ElseIf headerText = "Transfer Out" Then
                taypz = "Transfer Item"
            Else
                taypz = "Received Item"
            End If


            Using connection As New SqlConnection(cc.conString)
                Dim cmdd As New SqlCommand()
                cmdd.Connection = connection
                connection.Open()
                transaction = connection.BeginTransaction()
                cmdd.Transaction = transaction

                If vheaderText <> "Conversion Out" Then
                    Dim assignOperator As String = IIf(vheaderText = "Transfer Out", "-", "+")

                    For Each r0w As DataRow In dt.Rows
                        cmdd.Parameters.Clear()
                        cmdd.CommandText = "UPDATE tblinvitems Set " & vtableName & "+=@quantity" & IIf(vheaderText = "Transfer Out", "", ",totalav+=@quantity") & ", endbal" & assignOperator & "=@quantity, variance" & IIf(vheaderText = "Transfer Out", "+", "-") & "=@quantity WHERE itemname=@itemname And invnum=@invnum And area='Sales';"
                        cmdd.Parameters.AddWithValue("@quantity", CDbl(r0w("quantity")))
                        cmdd.Parameters.AddWithValue("@itemname", r0w("item"))
                        cmdd.Parameters.AddWithValue("@invnum", vinventorynum)
                        cmdd.ExecuteNonQuery()

                        cmdd.Parameters.Clear()
                        cmdd.CommandText = "INSERT INTO tblproduction (transaction_number,inv_id,item_code,item_name,category,quantity,reject,charge,sap_number,remarks,date,processed_by,type,area,status,transfer_from,transfer_to,typenum,type2) VALUES (@trans_id,@id,(SELECT itemcode FROM tblitems WHERE itemname=@name),@name,(SELECT category FROM tblitems WHERE itemname=@name),@quantity,0,0,@sap,@remarks,(SELECT GETDATE()),@processed_by,@type,'Sales','Completed',@from,@to,@typenum,@type2);"
                        cmdd.Parameters.AddWithValue("@trans_id", vtransactionNumber)
                        cmdd.Parameters.AddWithValue("@id", vinventorynum)
                        cmdd.Parameters.AddWithValue("@name", r0w("item"))
                        cmdd.Parameters.AddWithValue("@quantity", CDbl(r0w("quantity")))
                        cmdd.Parameters.AddWithValue("@sap", IIf(vsapNumber = 0, "To Follow", vsapNumber))
                        cmdd.Parameters.AddWithValue("@remarks", vremarks)
                        cmdd.Parameters.AddWithValue("@processed_by", login2.username)
                        cmdd.Parameters.AddWithValue("@type", taypz)
                        cmdd.Parameters.AddWithValue("@typenum", vsapDoc)
                        cmdd.Parameters.AddWithValue("@type2", IIf(vheaderText.Equals("Transfer Out"), "Transfer", vheaderText))
                        cmdd.Parameters.AddWithValue("@from", fromBranch)
                        cmdd.Parameters.AddWithValue("@to", toBranch)
                        cmdd.ExecuteNonQuery()
                    Next
                ElseIf vheaderText = "Conversion Out" Then
                    For Each r0w As DataRow In dt.Rows
                        cmdd.Parameters.Clear()
                        cmdd.CommandText = "insertConvOut"
                        cmdd.CommandType = CommandType.StoredProcedure
                        cmdd.Parameters.AddWithValue("@conv_number", vtransactionNumber)
                        cmdd.Parameters.AddWithValue("@itemname", r0w("item"))
                        cmdd.Parameters.AddWithValue("@quantity", CDbl(r0w("quantity")))
                        cmdd.Parameters.AddWithValue("@type", "Parent")
                        cmdd.Parameters.AddWithValue("@status", "Open")
                        cmdd.Parameters.AddWithValue("@createdby", login2.username)
                        cmdd.Parameters.AddWithValue("@area", "Sales")
                        cmdd.Parameters.AddWithValue("@typenum", vsapDoc)
                        cmdd.Parameters.AddWithValue("@sapnum", IIf(vsapNumber = 0, "To Follow", vsapNumber))
                        cmdd.Parameters.AddWithValue("@remarks", vremarks)
                        cmdd.Parameters.AddWithValue("@reference", vtransactionNumber)
                        cmdd.Parameters.AddWithValue("@marks", "")
                        cmdd.ExecuteNonQuery()
                    Next
                End If
                transaction.Commit()
                Dim frm As New show_trans()
                frm.lbltr.Text = vtransactionNumber
                frm.ShowDialog()
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

    Public Sub updatePullOut(ByVal dt As DataTable)
        Try
            Dim getMainBranch As String = returnBranchCode()
            Using connection As New SqlConnection(cc.conString)
                Dim cmdd As New SqlCommand()
                cmdd.Connection = connection
                connection.Open()
                transaction = connection.BeginTransaction()
                cmdd.Transaction = transaction

                For Each r0w As DataRow In dt.Rows
                    cmdd.Parameters.Clear()
                    cmdd.CommandText = "UPDATE tblinvitems Set " & vtableName & "+=@quantity, endbal-=@quantity, variance+=@quantity WHERE itemname=@itemname And invnum=@invnum And area='Sales';"
                    cmdd.Parameters.AddWithValue("@quantity", CDbl(r0w("quantity")))
                    cmdd.Parameters.AddWithValue("@itemname", r0w("item"))
                    cmdd.Parameters.AddWithValue("@invnum", vinventorynum)
                    cmdd.ExecuteNonQuery()

                    MessageBox.Show(vtype)

                    cmdd.Parameters.Clear()
                    cmdd.CommandText = "INSERT INTO tblproduction (transaction_number,inv_id,item_code,item_name,category,quantity,reject,charge,sap_number,remarks,date,processed_by,type,area,status,transfer_from,transfer_to,typenum,type2) VALUES (@trans_id,@id,(SELECT itemcode FROM tblitems WHERE itemname=@name),@name,(SELECT category FROM tblitems WHERE itemname=@name),@quantity,0,0,@sap,@remarks,(SELECT GETDATE()),@processed_by,@type,'Sales','Completed',@from,@to,@typenum,@type2);"
                    cmdd.Parameters.AddWithValue("@trans_id", vtransactionNumber)
                    cmdd.Parameters.AddWithValue("@id", vinventorynum)
                    cmdd.Parameters.AddWithValue("@name", r0w("item"))
                    cmdd.Parameters.AddWithValue("@quantity", CDbl(r0w("quantity")))
                    cmdd.Parameters.AddWithValue("@sap", IIf(vsapNumber = 0, "To Follow", vsapNumber))
                    cmdd.Parameters.AddWithValue("@remarks", vremarks)
                    cmdd.Parameters.AddWithValue("@processed_by", login2.username)
                    cmdd.Parameters.AddWithValue("@type", vtype)
                    cmdd.Parameters.AddWithValue("@typenum", vsapDoc)
                    cmdd.Parameters.AddWithValue("@type2", vtype2)
                    cmdd.Parameters.AddWithValue("@from", getMainBranch)
                    cmdd.Parameters.AddWithValue("@to", vfromBranch)
                    cmdd.ExecuteNonQuery()
                Next
                transaction.Commit()
                Dim frm As New show_trans()
                frm.lbltr.Text = vtransactionNumber
                frm.ShowDialog()
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

    Public Sub conversionFunction(ByVal dtConvOut As DataTable, dtConvIn As DataTable)
        Try
            Using connection As New SqlConnection(cc.conString)
                Dim cmdd As New SqlCommand()
                cmdd.Connection = connection
                connection.Open()
                transaction = connection.BeginTransaction()
                cmdd.Transaction = transaction
                For Each r0w As DataRow In dtConvOut.Rows
                    cmdd.Parameters.Clear()
                    cmdd.CommandText = "Update tblinvitems set  convout+=@quantity, endbal-=@quantity, variance+=@quantity,status=1 where itemname=@itemname and invnum=(Select TOP 1 invnum from tblinvsum WHERE area='Sales' order by invsumid DESC);"
                    cmdd.Parameters.AddWithValue("@quantity", CDbl(r0w("quantity")))
                    cmdd.Parameters.AddWithValue("@itemname", r0w("itemname"))
                    cmdd.ExecuteNonQuery()

                    cmdd.Parameters.Clear()
                    cmdd.CommandText = "UPDATE tblconversion SET status=@status1 WHERE conv_number=@conv_number AND item_name=@itemname"
                    cmdd.Parameters.AddWithValue("@conv_number", r0w("conv_number"))
                    cmdd.Parameters.AddWithValue("@itemname", r0w("itemname"))
                    cmdd.Parameters.AddWithValue("@status1", "Closed")
                    cmdd.ExecuteNonQuery()
                Next
                For Each r0w As DataRow In dtConvIn.Rows
                    cmdd.Parameters.Clear()
                    cmdd.CommandText = "Update tblinvitems set convin+=@quantity, totalav+=@quantity, endbal+=@quantity, variance-=@quantity where itemname=@itemname and invnum=(Select TOP 1 invnum from tblinvsum WHERE area='Sales' order by invsumid DESC)"
                    cmdd.Parameters.AddWithValue("@quantity", r0w("quantity"))
                    cmdd.Parameters.AddWithValue("@itemname", r0w("itemname"))
                    cmdd.ExecuteNonQuery()

                    cmdd.Parameters.Clear()
                    cmdd.CommandText = "INSERT INTO tblconversion (inv_number,conv_number,item_code,item_name,category,quantity,type,status,sap_id,remarks,date_created,created_by,area,typenum,reference_number,marks) VALUES ((Select TOP 1 invnum from tblinvsum WHERE area='Sales' order by invsumid DESC),@convnumber,(SELECT itemcode FROm tblitems WHERE itemname=@itemname),@itemname,(SELECT category FROM tblitems WHERE itemname=@itemname),@quantity,@type,@status,@sap_id,@remarks,(SELECT GETDATE()),@createdby,@area,@typenum,@reference,@marks)"
                    cmdd.Parameters.AddWithValue("@convnumber", vconvnum)
                    cmdd.Parameters.AddWithValue("@itemname", r0w("itemname"))
                    cmdd.Parameters.AddWithValue("@quantity", CDbl(r0w("quantity")))
                    cmdd.Parameters.AddWithValue("@type", "Child")
                    cmdd.Parameters.AddWithValue("@status", "Closed")
                    cmdd.Parameters.AddWithValue("@typenum", vsapDoc)
                    cmdd.Parameters.AddWithValue("@sap_id", IIf(vsapNumber = 0, "To Follow", vsapNumber))
                    cmdd.Parameters.AddWithValue("@remarks", vremarks)
                    cmdd.Parameters.AddWithValue("@createdby", login2.username)
                    cmdd.Parameters.AddWithValue("@area", "Sales")
                    cmdd.Parameters.AddWithValue("@reference", r0w("reference_number"))
                    cmdd.Parameters.AddWithValue("@marks", "")
                    cmdd.ExecuteNonQuery()
                Next
                transaction.Commit()
                Dim frm As New show_trans()
                frm.lbltr.Text = vconvnum
                frm.ShowDialog()
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

    ''' <summary>
    ''' load pending conversion out
    ''' </summary>
    ''' <returns></returns>
    Public Function loadPendingConvOut() As DataTable
        Dim result As New DataTable(), adptr As New SqlDataAdapter
        cc.con.Open()
        cc.cmd = New SqlCommand("SELECT * FROM vPendingConvOut", cc.con)
        adptr.SelectCommand = cc.cmd
        adptr.Fill(result)
        cc.con.Close()
        Return result
    End Function
    Public Function loadConvOutItems() As DataTable
        Dim result As New DataTable(), adptr As New SqlDataAdapter
        cc.con.Open()
        cc.cmd = New SqlCommand("SELECT * FROM funcLoadConvOutItems(@convnum)", cc.con)
        cc.cmd.Parameters.AddWithValue("@convnum", vconvnum)
        adptr.SelectCommand = cc.cmd
        adptr.Fill(result)
        cc.con.Close()
        Return result
    End Function
End Class
