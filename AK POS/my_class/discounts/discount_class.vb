Imports AK_POS.connection_class
Public Class discount_class
    Dim cc As New connection_class()
    Private vdisname As String = ""

    Public Property discountName As String
        Set(value As String)
            vdisname = value
        End Set
        Get
            Return vdisname
        End Get
    End Property
    ''' <summary>
    ''' return discount names
    ''' </summary>
    ''' <returns></returns>
    Public Function loadDIscounts() As DataTable
        Dim result As New DataTable(), adptr As New SqlClient.SqlDataAdapter
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT disname FROM tbldiscount WHERE status=1", cc.con)
        adptr.SelectCommand = cc.cmd
        adptr.Fill(result)
        cc.con.Close()
        Return result
    End Function
    ''' <summary>
    ''' return discounts of discount name
    ''' </summary>
    ''' <returns></returns>
    Public Function returnAmount() As Double
        Dim result As Double = 0.00
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT amount FROM tbldiscount WHERE disname=@disname", cc.con)
        cc.cmd.Parameters.AddWithValue("@disname", vdisname)
        result = IIf(IsDBNull(cc.cmd.ExecuteScalar), 0, cc.cmd.ExecuteScalar)
        cc.con.Close()
        Return result
    End Function

End Class
