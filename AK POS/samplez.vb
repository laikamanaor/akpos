Imports AK_POS.connection_class
Public Class samplez
    Dim cc As New connection_class
    Private Sub samplez_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt As New DataTable(), adptr As New SqlClient.SqlDataAdapter
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT * FROM tblsample", cc.con)
        adptr.SelectCommand = cc.cmd
        adptr.Fill(dt)
        cc.con.Close()

        For Each r0w As DataRow In dt.Rows
            ListView1.Items.Add(r0w("id"))
        Next
    End Sub
End Class