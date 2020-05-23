Imports AK_POS.inventory_class
Imports AK_POS.ui_class
Public Class showSAPNumber
    Dim invc As New inventory_class(), uic As New ui_class()
    Public transnum As String = ""
    Private Sub showSAPNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub showSAPNumber_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadData()
    End Sub
    Public Sub loadData()
        invc.transnum = transnum
        Dim result As New DataTable()
        result = invc.loadSAPRemarks()
        If result.Rows.Count <> 0 Then
            For Each r0w As DataRow In result.Rows
                lblsap.Text = IIf(IsDBNull(r0w("sap_number")), "", r0w("sap_number"))
                txtremarks.Text = r0w("remarks")
            Next
        Else
            lblsap.Text = "N/A"
            lblsap.Text = "N/A"
        End If
    End Sub

    Private Sub Panel5_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel5.MouseMove, txtremarks.MouseMove, MyBase.MouseMove, lblsap.MouseMove, Label2.MouseMove, Label1.MouseMove
        uic.mouse_move(Me)
    End Sub

    Private Sub Panel5_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel5.MouseUp, txtremarks.MouseUp, MyBase.MouseUp, lblsap.MouseUp, Label2.MouseUp, Label1.MouseUp
        uic.mouse_up()
    End Sub

    Private Sub Panel5_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel5.MouseDown, txtremarks.MouseDown, MyBase.MouseDown, lblsap.MouseDown, Label2.MouseDown, Label1.MouseDown
        uic.mouse_down(Me)
    End Sub
End Class