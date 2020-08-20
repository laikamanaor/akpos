Public Class frmThread
    Dim cc As New connection_class()
    Public Function countItems() As Integer
        Dim countItemID As Integer = 0
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT COUNT(itemid) [count] FROM tblitems", cc.con)
        countItemID = cc.cmd.ExecuteScalar
        cc.con.Close()
        Return countItemID
    End Function

    Private Sub frmThread_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        Dim th1 As New Threading.Thread(AddressOf loadData)
        th1.Start()
    End Sub

    Public Sub loadData()
        dgv.ScrollBars = ScrollBars.None
        Dim total As Integer = countItems()
        Dim count As Integer = 0
        dgv.Rows.Clear()
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT itemname,price FROM tblitems ORDER BY itemname", cc.con)
        cc.rdr = cc.cmd.ExecuteReader
        While cc.rdr.Read
            count += 1
            dgv.Rows.Add(cc.rdr("itemname"), cc.rdr("price"))
            ProgressBar1.Value = (count / total) * 100
            Me.Refresh()
        End While
        cc.con.Close()
        dgv.ScrollBars = ScrollBars.Both
    End Sub
End Class