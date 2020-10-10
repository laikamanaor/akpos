Imports System.Data.SqlClient
Public Class inv_logs_items
    Dim cc As New connection_class()
    Dim uic As New ui_class()
    Public transnum As String = ""

    Dim conString As String = "Data Source=192.168.30.6;Network Library=DBMSSOCN;Initial Catalog=AKPOS;User ID=admin;Password=abC@43212020;MultipleActiveResultSets=true;"
    Public con As New SqlConnection(conString)
    Public rdr As SqlDataReader
    Public cmd As SqlCommand
    Private Sub inv_logs_items_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        threadSub()
    End Sub

    Public Sub loadItems()
        spinner.Visible = True
        Dim type As String = ""
        dgv.Rows.Clear()
        Dim dt As New DataTable()
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT item_name,SUM(ISNULL(quantity,0))[quantity],transfer_to,transaction_number,sap_number,type FROM tblproduction WHERE transaction_number=@transnum GROUP BY item_name,transfer_to,transaction_number,sap_number,type ORDER BY item_name", cc.con)
        cc.cmd.Parameters.AddWithValue("@transnum", transnum)
        cc.adptr.SelectCommand = cc.cmd
        cc.adptr.Fill(dt)
        cc.con.Close()
        For Each r0w As DataRow In dt.Rows
            Dim itemName As String = r0w("item_name")
            Dim quantity As Double = CDbl(r0w("quantity"))
            Dim actualQuantity As Double = 0.00
            Dim variance As Double = 0.00
            type = r0w("type")

            lblfromBranch.Text = IIf(IsDBNull(r0w("transfer_to")), "N/A", r0w("transfer_to"))
            lbltransnum.Text = r0w("transaction_number")
            Dim sapNumber As String = IIf(IsDBNull(r0w("sap_number")), "N/A", r0w("sap_number"))
            If Not sapNumber.Equals("To Follow") And type = "Received Item" Then
                Try
                    con.Open()
                    cmd = New SqlCommand("SELECT Quantity [qty] FROM vSAP_IT WHERE Dscription='" & itemName & "' AND DocNum=" & sapNumber & " ORDER BY Dscription", con)
                    'cmd.Parameters.AddWithValue("@itemName", itemName)
                    'cmd.Parameters.AddWithValue("@sapNumber", sapNumber)
                    rdr = cmd.ExecuteReader
                    If rdr.Read Then
                        actualQuantity = CDbl(rdr("qty"))
                    Else
                        actualQuantity = quantity
                    End If
                    con.Close()
                Catch ex As Exception
                    MessageBox.Show("No Internet Connection", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit For
                End Try
            Else
                actualQuantity = quantity
            End If
            variance = quantity - actualQuantity
            dgv.Rows.Add(itemName, quantity.ToString("n2"), actualQuantity.ToString("n2"), variance.ToString("n2"))
        Next
        For index As Integer = 0 To dgv.Rows.Count - 1
            Dim variance As Double = dgv.Rows(index).Cells("variance").Value
            If variance = 0 Then
                dgv.Rows(index).Cells("variance").Style.ForeColor = Color.Black
            ElseIf variance < 0 Then
                dgv.Rows(index).Cells("variance").Style.ForeColor = Color.Red
            ElseIf variance > 0 Then
                dgv.Rows(index).Cells("variance").Style.ForeColor = Color.Blue
            End If
        Next
        If type = "Received Item" Then
            dgv.Columns("act_qty").Visible = True
            dgv.Columns("variance").Visible = True
            dgv.Columns("del_qty").HeaderText = "Delivered Quantity"
        Else
            dgv.Columns("act_qty").Visible = False
            dgv.Columns("variance").Visible = False
            dgv.Columns("del_qty").HeaderText = "Quantity"
        End If
        spinner.Visible = False
    End Sub

    Public Sub threadSub()
        Control.CheckForIllegalCrossThreadCalls = False
        Dim th As New Threading.Thread(AddressOf loadItems)
        th.Start()
    End Sub

    Private Sub inv_logs_items_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub lblclose_Click(sender As Object, e As EventArgs) Handles lblclose.Click
        Me.Close()
    End Sub

    Private Sub Panel5_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel5.MouseDown, spinner.MouseDown, MyBase.MouseDown, lbltransnum.MouseDown, lblfromBranch.MouseDown, Label3.MouseDown, Label2.MouseDown, Label1.MouseDown
        uic.mouse_down(Me)
    End Sub

    Private Sub Panel5_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel5.MouseMove, spinner.MouseMove, MyBase.MouseMove, lbltransnum.MouseMove, lblfromBranch.MouseMove, Label3.MouseMove, Label2.MouseMove, Label1.MouseMove
        uic.mouse_move(Me)
    End Sub

    Private Sub Panel5_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel5.MouseUp, spinner.MouseUp, MyBase.MouseUp, lbltransnum.MouseUp, lblfromBranch.MouseUp, Label3.MouseUp, Label2.MouseUp, Label1.MouseUp
        uic.mouse_up()
    End Sub
End Class