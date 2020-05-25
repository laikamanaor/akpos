Imports AK_POS.connection_class
Public Class pendingsap_class
    Dim cc As New connection_class()
    Private vdatecreated As String = "", vtransnum As String = "", vtypee As String = ""
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

    Public Function loadTransactions() As DataTable
        Dim result As New DataTable(), result_query As String = "", adptr As New SqlClient.SqlDataAdapter,
        prodtable_query As String = "SELECT DISTINCT transaction_number[transnum],transfer_from[name],typenum[sapdoc],sap_number[sapnum],remarks[remarks],type2 [from],(SELECT CONVERT(CHAR(5),date,8)) [time] FROM tblproduction WHERE sap_number='To Follow' AND CAST(date AS date)=@date AND transaction_number LIKE '%" & vtransnum & "%'  AND type=@type AND status='Completed';",
            convtable_query As String = "SELECT conv_number,'N/A' [name],typenum [sapdoc],sap_id [sapnum],remarks [remarks],'From Conversion'[from],(SELECT CONVERT(CHAR(5),date_created,8)) [time] FROM tblconversion WHERE sap_id='To Follow' AND status='Closed' AND type=@type AND CAST(date_created AS date)=@date AND conv_number LIKE '%" & vtransnum & "%';", type_result As String = ""

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
        adptr.SelectCommand = cc.cmd
        adptr.Fill(result)
        cc.con.Close()
        Return result
    End Function
End Class
