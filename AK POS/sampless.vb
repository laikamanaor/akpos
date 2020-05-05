Imports System.Data.SqlClient
Public Class sampless
    Dim strconn As String = login.ss
    Dim con As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim adptr As New SqlDataAdapter

    Private Sub sampless_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dgv.Rows.Clear()
            dgv.Rows.Add("q")

            grd.Rows.Add("q")
            'con.Open()
            'cmd = New SqlCommand("SELECT username, fullname FROM tblusers", con)
            'rdr = cmd.ExecuteReader
            'While rdr.Read
            '    dgv.Rows.Add(rdr("username"))
            '    CType(Me.dgv.Columns("username"), DataGridViewComboBoxColumn).Items.Add(rdr("username"))
            'End While
            'con.Close()

            con.Open()
            cmd = New SqlCommand("SELECT username FROM tblusers", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                CType(Me.dgv.Columns("username"), DataGridViewComboBoxColumn).Items.Add(rdr("username"))
            End While
            con.Close()

            Dim cmb As DataGridViewComboBoxColumn = CType(Me.dgv.Columns("username"), DataGridViewComboBoxColumn)
            cmb.DropDownWidth = 300
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub dgv_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgv.DataError
        If (e.Context = DataGridViewDataErrorContexts.LeaveControl) Then
            MessageBox.Show("leave control error")
        End If
    End Sub

    Private Sub dgv_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgv.EditingControlShowing
        Dim comboBoxColumn As DataGridViewComboBoxColumn = dgv.Columns(0)
        If (dgv.CurrentCellAddress.X = comboBoxColumn.DisplayIndex) Then
            Dim cb As ComboBox = e.Control
            If (cb IsNot Nothing) Then
                cb.DropDownStyle = ComboBoxStyle.DropDown
                cb.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            End If
        End If
    End Sub
End Class