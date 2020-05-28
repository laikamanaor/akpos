Imports AK_POS.connection_class
Imports System.Data.SqlClient
Public Class pendingsap_class
    Dim cc As New connection_class(), transaction As SqlTransaction
    Private vdatecreated As String = "", vtransnum As String = "", vtypee As String = "", vsapnum As Integer = 0, vremarks As String = ""
    Public Property datecreated As String
        Set(value As String)
            vdatecreated = value
        End Set
        Get
            Return vdatecreated
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
            vtypee = value
        End Set
        Get
            Return vtypee
        End Get
    End Property

    Public Property sapnum As Integer
        Set(value As Integer)
            vsapnum = value
        End Set
        Get
            Return vsapnum
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

    Public Function loadTransactions(ByVal offset As Integer, ByVal rowsFetch As Integer) As DataTable
        Dim result As New DataTable(), result_query As String = "", adptr As New SqlClient.SqlDataAdapter,
        prodtable_query As String = "SELECT * FROM dbo.funcLoadPendingRecTrans(@date,@type,@transnum,@offset,@rowsFetch)",
            convtable_query As String = "SELECT * FROM dbo.funcLoadPendingConv(@date,@type,@transnum,@offset,@rowsFetch)",
            type_result As String = ""

        If vtypee = "Received Item" Or vtypee = "Transfer Item" Or vtypee = "Adjustment Item" Then
            result_query = prodtable_query
            type_result = vtypee
        ElseIf vtypee = "Conversion In" Or vtypee = "Conversion Out" Then
            result_query = convtable_query
            type_result = IIf(vtypee = "Conversion Out", "Parent", "Child")
        End If
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand(result_query, cc.con)
        cc.cmd.Parameters.AddWithValue("@date", vdatecreated)
        cc.cmd.Parameters.AddWithValue("@type", type_result)
        cc.cmd.Parameters.AddWithValue("@transnum", vtransnum)
        cc.cmd.Parameters.AddWithValue("@offset", offset)
        cc.cmd.Parameters.AddWithValue("@rowsFetch", rowsFetch)
        adptr.SelectCommand = cc.cmd
        adptr.Fill(result)
        cc.con.Close()
        Return result
    End Function


    Public Function loadItems() As DataTable
        Dim result As New DataTable(), adptr As New SqlClient.SqlDataAdapter,
            result_query As String = "",
            type_result As String = "",
            prodtable_query As String = "SELECT item_name,quantity FROM tblproduction WHERE transaction_number=@transnum;",
            convtable_query As String = "SELECT item_name,quantity FROM tblconversion WHERE conv_number=@transnum;"

        If vtypee = "Received Item" Or vtypee = "Transfer Item" Or vtypee = "Adjustment Item" Then
            result_query = prodtable_query
        ElseIf vtypee = "Conversion In" Or vtypee = "Conversion Out" Then
            result_query = convtable_query
        End If

        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand(result_query, cc.con)
        cc.cmd.Parameters.AddWithValue("@transnum", vtransnum)
        adptr.SelectCommand = cc.cmd
        adptr.Fill(result)
        cc.con.Close()
        Return result
    End Function

    Public Function countData() As Integer
        Dim result As Integer = 0, rdr As SqlClient.SqlDataReader,
            result_query As String = "",
            type_result As String = "",
            prodtable_query As String = "SELECT DISTINCT transaction_number[transnum] FROM tblproduction WHERE sap_number='To Follow' AND CAST(date AS date)=@date AND transaction_number LIKE '%" & vtransnum & "%'  AND type=@type AND status='Completed';",
            convtable_query As String = "SELECT DISTINCT conv_number FROM tblconversion WHERE sap_id='To Follow' AND status='Closed' AND type=@type  AND CAST(date_created AS date)=@date AND conv_number LIKE '%" & vtransnum & "%';"

        If vtypee = "Received Item" Or vtypee = "Transfer Item" Or vtypee = "Adjustment Item" Then
            result_query = prodtable_query
            type_result = vtypee
        ElseIf vtypee = "Conversion In" Or vtypee = "Conversion Out" Then
            result_query = convtable_query
            type_result = IIf(vtypee = "Conversion Out", "Parent", "Child")
        End If
        If vtypee = "Received Item" Or vtypee = "Transfer Item" Or vtypee = "Adjustment Item" Or vtypee = "Conversion In" Or vtypee = "Conversion Out" Then
            cc.con.Open()
            cc.cmd = New SqlClient.SqlCommand(result_query, cc.con)
            cc.cmd.Parameters.AddWithValue("@date", vdatecreated)
            cc.cmd.Parameters.AddWithValue("@type", type_result)
            cc.cmd.Parameters.AddWithValue("@transnum", vtransnum)
            rdr = cc.cmd.ExecuteReader
            While rdr.Read
                result += 1
            End While
            cc.con.Close()
            Return result
        End If
    End Function

    Public Sub updateSAPNumber(ByVal dtTransnum As DataTable)
        Try
            Using connection As New SqlConnection(cc.conString)
                Dim command As New SqlCommand()
                command.Connection = connection
                connection.Open()
                transaction = connection.BeginTransaction()
                command.Transaction = transaction

                Dim result_query As String = "",
                prodtable_query As String = "UPDATE tblproduction SET sap_number=@sapnum,remarks=@remarks WHERE transaction_number=@transnum;",
                 convtable_query As String = "UPDATE tblconversion SET sap_id=@sapnum,remarks=@remarks WHERE conv_number=@transnum;"

                If vtypee = "Received Item" Or vtypee = "Transfer Item" Or vtypee = "Adjustment Item" Then
                    result_query = prodtable_query
                ElseIf vtypee = "Conversion In" Or vtypee = "Conversion Out" Then
                    result_query = convtable_query
                End If

                If dtTransnum.Rows.Count > 0 Then
                    For Each r0w As DataRow In dtTransnum.Rows
                        command.Parameters.Clear()
                        command.CommandText = result_query
                        command.Parameters.AddWithValue("@transnum", r0w("transnum"))
                        command.Parameters.AddWithValue("@sapnum", vsapnum)
                        command.Parameters.AddWithValue("remarks", vremarks)
                        command.ExecuteNonQuery()
                    Next
                    transaction.Commit()
                    MessageBox.Show("SAP # updated", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
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
