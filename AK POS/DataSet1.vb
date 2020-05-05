

Partial Public Class DataSet1
    Partial Class DataTable10DataTable

        Private Sub DataTable10DataTable_DataTable10RowChanging(ByVal sender As System.Object, ByVal e As DataTable10RowChangeEvent) Handles Me.DataTable10RowChanging

        End Sub

    End Class

    Partial Class DataTable8DataTable


    End Class

    Partial Class DataTable7DataTable

        Private Sub DataTable7DataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me._Sales_Amount__Take_Out_Column.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class
