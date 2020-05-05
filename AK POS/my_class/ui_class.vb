Public Class ui_class
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Public Sub mouse_down(ByVal frm As Form)
        drag = True 'Sets the variable drag to true.
        mousex = Windows.Forms.Cursor.Position.X - frm.Left 'Sets variable mousex
        mousey = Windows.Forms.Cursor.Position.Y - frm.Top 'Sets variable mousey
    End Sub
    Public Sub mouse_move(ByVal frm As Form)
        'If drag is set to true then move the form accordingly.
        If drag Then
            frm.Top = Windows.Forms.Cursor.Position.Y - mousey
            frm.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub
    Public Sub mouse_up()
        drag = False 'Sets drag to false, so the form does not move according to the code in MouseMove
    End Sub
End Class