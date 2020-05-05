Imports System.IO
Imports System.Data.SqlClient
Imports System.Drawing

Public Class itemsales
    Dim strconn As String = login.ss
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim sql As String

    Public condition As String, conditiontrans As String, alls As String, pullcondition As String
    Dim tempqty As Integer = 0, temptotal As Double

    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function

    Public Sub connect()
        conn = New SqlConnection
        conn.ConnectionString = strconn
        If conn.State <> ConnectionState.Open Then
            conn.Open()
        End If
    End Sub

    Public Sub disconnect()
        conn = New SqlConnection
        conn.ConnectionString = strconn
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
    End Sub

    Private Sub itemsales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        grdsales.Rows.Clear()
        cat()
        checkdisc()
    End Sub

    Public Sub cat()
        Try
            cmbcat.Items.Clear()

            sql = "Select * from tblcat where status='1'"
            connect()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            While dr.Read
                cmbcat.Items.Add(dr("category"))
            End While
            dr.Dispose()
            cmd.Dispose()

            If cmbcat.Items.Count <> 0 Then
                cmbcat.Items.Add("All")
                cmbcat.SelectedItem = "All"
            End If

        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Public Sub checkdisc()
        Try
            grdsales.Rows.Clear()
            cmbdis.Items.Clear()

            connect()
            For Each row As DataGridViewRow In transactions.grd.Rows
                sql = "Select * from tbltransaction where transnum='" & transactions.grd.Rows(row.Index).Cells(1).Value & "' order by disctype"
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                While dr.Read
                    If Not cmbdis.Items.Contains(dr("disctype")) And dr("disctype") <> "" Then
                        cmbdis.Items.Add(dr("disctype"))
                    End If
                End While
                dr.Dispose()
                cmd.Dispose()
            Next

            addcol()
            'Dim n As Integer = grdsales.Columns.Count

            For i = 0 To cmbdis.Items.Count - 1
                cmbdis.SelectedIndex = i
                grdsales.Columns.Add(i, cmbdis.SelectedItem)
                grdsales.Columns(grdsales.Columns.Count - 1).Width = 100
                grdsales.Columns(grdsales.Columns.Count - 1).MinimumWidth = 100
            Next
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Public Sub addcol()
        grdsales.Columns.Clear()

        grdsales.Columns.Add("a", "Item Name")
        grdsales.Columns(0).Width = 200
        grdsales.Columns(0).MinimumWidth = 200
        grdsales.Columns.Add("c", "Regular")
        grdsales.Columns(1).Width = 100
        grdsales.Columns(1).MinimumWidth = 100
    End Sub

    Private Sub cmbcat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcat.SelectedIndexChanged
        connect()
        For Each row As DataGridViewRow In transactions.grd.Rows
            If cmbcat.SelectedItem = "All" Then
                sql = "Select * from tblorder where transnum='" & transactions.grd.Rows(row.Index).Cells(1).Value & "' order by itemname"
            Else
                sql = "Select * from tblorder where transnum='" & transactions.grd.Rows(row.Index).Cells(1).Value & "' and category='" & cmbcat.SelectedItem & "' order by itemname"
            End If
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            While dr.Read
                'check wat header of the column before lagyan ng qty

                'grdsales.Rows.Add(dr("category").ToString, dr("transnum").ToString, dr("disctrans"), dr("itemname").ToString, dr("qty"), dr("dscnt"), dr("free"), "")
            End While
            dr.Dispose()
            cmd.Dispose()
        Next
    End Sub
End Class