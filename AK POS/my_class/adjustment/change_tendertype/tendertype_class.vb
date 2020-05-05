Imports AK_POS.connection_class
Imports System.Data.SqlClient
Public Class tendertype_class
    Private ordernum As String = "", postype As String = "", salesname As String = "", datee As New DateTime()
    Dim cc As New connection_class()
    Public ReadOnly Property getOrdernum() As String
        Get
            Return ordernum
        End Get
    End Property
    Public Sub setOrdernum(ByVal value As String)
        ordernum = value
    End Sub
    Public ReadOnly Property getPOSType() As String
        Get
            Return postype
        End Get
    End Property
    Public Sub setPOSType(ByVal value As String)
        postype = value
    End Sub
    Public ReadOnly Property getSalesName() As String
        Get
            Return salesname
        End Get
    End Property
    Public Sub setSalesName(ByVal value As String)
        salesname = value
    End Sub
    Public ReadOnly Property getDatee() As DateTime
        Get
            Return datee
        End Get
    End Property
    Public Sub setDatee(ByVal value As DateTime)
        datee = value
    End Sub
    Public Function showTransactions() As DataTable
        cc.con.Open()
        cc.cmd = New SqlCommand("SELECT tbltransaction.transid,tbltransaction2.orderid,tbltransaction.transnum,tbltransaction2.ordernum,tbltransaction.amtdue,tbltransaction.partialamt,tbltransaction.tendertype,tbltransaction.servicetype,tbltransaction.typez FROM tbltransaction JOIN tbltransaction2 ON tbltransaction.transnum = tbltransaction2.transnum  WHERE CAST(tbltransaction.datecreated  AS date)='" & datee.ToString("MM/dd/yyyy") & "' AND sap_number !='' AND tbltransaction.status=1 AND tbltransaction.tendertype !='Deposit' AND tbltransaction.tendertype != 'Cash Out'" & IIf(ordernum = "", "", " AND ordernum LIKE '%" & ordernum & "%'") & IIf(salesname = "All", "", " AND tbltransaction.salesname='" & salesname & "'") & IIf(postype = "All", "", " AND tbltransaction.typez='" & postype & "'"), cc.con)
        Dim adptr As New SqlClient.SqlDataAdapter()
        Dim dt As New DataTable()
        adptr.SelectCommand = cc.cmd
        adptr.Fill(dt)
        cc.con.Close()
        Return dt
    End Function
    Public Sub loadSales(ByVal cmb As ComboBox)
        Try
            cmb.Items.Clear()
            cmb.Items.Add("All")
            cc.con.Open()
            cc.cmd = New SqlCommand("SELECT username FROM tblusers WHERE workgroup IN ('Sales','Manager') ORDER BY username;", cc.con)
            cc.rdr = cc.cmd.ExecuteReader
            While cc.rdr.Read
                cmb.Items.Add(cc.rdr("username"))
            End While
            cc.con.Close()
            cmb.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class
