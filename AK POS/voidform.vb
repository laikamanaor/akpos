Public Class voidform

    Private Sub btnvoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnvoid.Click
        For Each row As DataGridViewRow In mainmenu.grd.Rows
            If mainmenu.grd.Rows(row.Index).Cells(0).Value = cmbitems.SelectedItem Then
                mainmenu.grd.Rows.Remove(row)
                mainmenu.computetotal()
                If mainmenu.grd.Rows.Count = 0 Then
                    mainmenu.txttendered.Text = "0"
                    mainmenu.txtchange.Text = ""
                    mainmenu.txttotal.Text = "0.00"
                End If
                Me.Cursor = Cursors.Default
                Me.Close()
            End If
        Next
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Me.Dispose()
    End Sub

    Private Sub voidform_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cmbitems.Items.Clear()
    End Sub

    Private Sub voidform_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class