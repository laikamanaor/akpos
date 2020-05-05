Imports System.IO
Imports System.Data.SqlClient
Imports System.Drawing

Public Class Copyitemsales
    Dim strconn As String = decryptConString()
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

    Private Sub itemsales_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub itemsales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loaddisname()
        loadall()
        cat()
        grdfree.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdfree.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Public Sub loaddisname()
        cmb100.Items.Clear()

        sql = "Select * from tbldiscount where amount='100'"
        connect()
        cmd = New SqlCommand(sql, conn)
        dr = cmd.ExecuteReader
        While dr.Read
            cmb100.Items.Add(dr("disname"))
        End While
        dr.Dispose()
        cmd.Dispose()

        disconnect()
    End Sub

    Public Sub cat()
        Try
            'Me.Cursor = Cursors.WaitCursor
            cmbcat.Items.Clear()

            sql = "Select * from tblcat where status='1' order by category"
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

            Me.Cursor = Cursors.Default
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

    Private Sub cmbdis_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbdis.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        If cmbdis.SelectedItem = "All" Then
            grdfree.Rows.Clear()
            cmbfree.Items.Clear()
            If cmbcat.SelectedItem <> "All" Then
                For Each row As DataGridViewRow In grdlist.Rows
                    Dim neym As String = grdlist.Rows(row.Index).Cells(3).Value
                    Dim amt As Double = Math.Round(grdlist.Rows(row.Index).Cells(9).Value, 2, MidpointRounding.AwayFromZero)
                    If (grdlist.Rows(row.Index).Cells(0).Value = cmbcat.SelectedItem) Then
                        If (grdlist.Rows(row.Index).Cells(5).Value <> 0) Then
                            If Not cmbfree.Items.Contains(neym) Then
                                cmbfree.Items.Add(grdlist.Rows(row.Index).Cells(3).Value)
                                grdfree.Rows.Add(grdlist.Rows(row.Index).Cells(0).Value, grdlist.Rows(row.Index).Cells(3).Value, grdlist.Rows(row.Index).Cells(4).Value, grdlist.Rows(row.Index).Cells(6).Value, amt)
                            Else
                                For Each roww As DataGridViewRow In grdfree.Rows
                                    If grdfree.Rows(roww.Index).Cells(1).Value = neym Then
                                        grdfree.Rows(roww.Index).Cells(2).Value = Val(grdfree.Rows(roww.Index).Cells(2).Value) + Val(grdlist.Rows(row.Index).Cells(4).Value)
                                        grdfree.Rows(roww.Index).Cells(4).Value = Val(grdfree.Rows(roww.Index).Cells(4).Value) + amt
                                    End If
                                Next
                            End If
                        End If
                    End If
                Next
            Else
                For Each row As DataGridViewRow In grdlist.Rows
                    Dim neym As String = grdlist.Rows(row.Index).Cells(3).Value
                    Dim amt As Double = Math.Round(grdlist.Rows(row.Index).Cells(9).Value, 2, MidpointRounding.AwayFromZero)
                    If (grdlist.Rows(row.Index).Cells(5).Value <> 0) Then
                        If Not cmbfree.Items.Contains(neym) Then
                            cmbfree.Items.Add(grdlist.Rows(row.Index).Cells(3).Value)
                            grdfree.Rows.Add(grdlist.Rows(row.Index).Cells(0).Value, grdlist.Rows(row.Index).Cells(3).Value, grdlist.Rows(row.Index).Cells(4).Value, grdlist.Rows(row.Index).Cells(6).Value, amt)
                        Else
                            For Each roww As DataGridViewRow In grdfree.Rows
                                If grdfree.Rows(roww.Index).Cells(1).Value = neym Then
                                    grdfree.Rows(roww.Index).Cells(2).Value = Val(grdfree.Rows(roww.Index).Cells(2).Value) + Val(grdlist.Rows(row.Index).Cells(4).Value)
                                    grdfree.Rows(roww.Index).Cells(4).Value = Val(grdfree.Rows(roww.Index).Cells(4).Value) + amt
                                End If
                            Next
                        End If
                    End If
                Next
            End If

        Else
            grdfree.Rows.Clear()
            cmbfree.Items.Clear()

            If cmbcat.SelectedItem <> "All" Then
                For Each row As DataGridViewRow In grdlist.Rows
                    Dim neym As String = grdlist.Rows(row.Index).Cells(3).Value
                    Dim amt As Double = Math.Round(grdlist.Rows(row.Index).Cells(9).Value, 2, MidpointRounding.AwayFromZero)
                    If (grdlist.Rows(row.Index).Cells(0).Value = cmbcat.SelectedItem) Then
                        If (grdlist.Rows(row.Index).Cells(5).Value = cmbdis.SelectedItem.ToString.Substring(0, cmbdis.SelectedItem.ToString.Length - 5)) Then
                            If Not cmbfree.Items.Contains(neym) Then
                                cmbfree.Items.Add(grdlist.Rows(row.Index).Cells(3).Value)
                                grdfree.Rows.Add(grdlist.Rows(row.Index).Cells(0).Value, grdlist.Rows(row.Index).Cells(3).Value, grdlist.Rows(row.Index).Cells(4).Value, grdlist.Rows(row.Index).Cells(6).Value, amt)
                            Else
                                For Each roww As DataGridViewRow In grdfree.Rows
                                    If grdfree.Rows(roww.Index).Cells(1).Value = neym Then
                                        grdfree.Rows(roww.Index).Cells(2).Value = Val(grdfree.Rows(roww.Index).Cells(2).Value) + Val(grdlist.Rows(row.Index).Cells(4).Value)
                                        grdfree.Rows(roww.Index).Cells(4).Value = Val(grdfree.Rows(roww.Index).Cells(4).Value) + amt
                                    End If
                                Next
                            End If
                        End If
                    End If
                Next
            Else
                For Each row As DataGridViewRow In grdlist.Rows
                    Dim neym As String = grdlist.Rows(row.Index).Cells(3).Value
                    Dim amt As Double = Math.Round(grdlist.Rows(row.Index).Cells(9).Value, 2, MidpointRounding.AwayFromZero)
                    If (grdlist.Rows(row.Index).Cells(5).Value = cmbdis.SelectedItem.ToString.Substring(0, cmbdis.SelectedItem.ToString.Length - 5)) Then
                        If Not cmbfree.Items.Contains(neym) Then
                            cmbfree.Items.Add(grdlist.Rows(row.Index).Cells(3).Value)
                            grdfree.Rows.Add(grdlist.Rows(row.Index).Cells(0).Value, grdlist.Rows(row.Index).Cells(3).Value, grdlist.Rows(row.Index).Cells(4).Value, grdlist.Rows(row.Index).Cells(6).Value, amt)
                        Else
                            For Each roww As DataGridViewRow In grdfree.Rows
                                If grdfree.Rows(roww.Index).Cells(1).Value = neym Then
                                    grdfree.Rows(roww.Index).Cells(2).Value = Val(grdfree.Rows(roww.Index).Cells(2).Value) + Val(grdlist.Rows(row.Index).Cells(4).Value)
                                    grdfree.Rows(roww.Index).Cells(4).Value = Val(grdfree.Rows(roww.Index).Cells(4).Value) + amt
                                End If
                            Next
                        End If
                    End If
                Next
            End If
        End If
        tcount()
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub tcount()
        Try
            'Me.Cursor = Cursors.WaitCursor

            Dim temptotalcnt As Integer = 0
            For Each row As DataGridViewRow In grdfree.Rows
                temptotalcnt += Val(grdfree.Rows(row.Index).Cells(2).Value)
            Next
            totalcount.Text = temptotalcnt.ToString("n2")

            Dim temptotalamt As Double = 0
            For Each row As DataGridViewRow In grdfree.Rows
                'MsgBox(Val(grdfree.Rows(row.Index).Cells(4).Value).ToString)
                'Dim amt As Double = grdfree.Rows(row.Index).Cells(4).Value
                temptotalamt += grdfree.Rows(row.Index).Cells(4).Value
            Next
            totalamt.Text = temptotalamt.ToString("n2")


            If grdfree.Rows.Count = 0 Then
                MsgBox("No Record Found.", MsgBoxStyle.Critical, "")
            End If

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub rbfree_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbfree.CheckedChanged
        If rbfree.Checked = True Then
            Me.Cursor = Cursors.WaitCursor
            grdfree.Rows.Clear()
            cmbfree.Items.Clear()

            If cmbcat.SelectedItem <> "All" Then
                For Each row As DataGridViewRow In grdlist.Rows
                    Dim neym As String = grdlist.Rows(row.Index).Cells(3).Value
                    Dim amt As Double = Math.Round(grdlist.Rows(row.Index).Cells(9).Value, 2, MidpointRounding.AwayFromZero)
                    If (grdlist.Rows(row.Index).Cells(0).Value = cmbcat.SelectedItem) Then
                        If (grdlist.Rows(row.Index).Cells(6).Value <> 0) Then
                            If Not cmbfree.Items.Contains(neym) Then
                                cmbfree.Items.Add(grdlist.Rows(row.Index).Cells(3).Value)
                                grdfree.Rows.Add(grdlist.Rows(row.Index).Cells(0).Value, grdlist.Rows(row.Index).Cells(3).Value, grdlist.Rows(row.Index).Cells(4).Value, grdlist.Rows(row.Index).Cells(6).Value, amt)
                            Else
                                For Each roww As DataGridViewRow In grdfree.Rows
                                    If grdfree.Rows(roww.Index).Cells(1).Value = neym Then
                                        grdfree.Rows(roww.Index).Cells(2).Value = Val(grdfree.Rows(roww.Index).Cells(2).Value) + Val(grdlist.Rows(row.Index).Cells(4).Value)
                                        grdfree.Rows(roww.Index).Cells(4).Value = Val(grdfree.Rows(roww.Index).Cells(4).Value) + amt
                                    End If
                                Next
                            End If
                        End If

                        For i = 0 To cmb100.Items.Count - 1
                            cmb100.SelectedIndex = i
                            If grdlist.Rows(row.Index).Cells(7).Value = cmb100.SelectedItem Then
                                If Not cmbfree.Items.Contains(neym) Then
                                    cmbfree.Items.Add(grdlist.Rows(row.Index).Cells(3).Value)
                                    grdfree.Rows.Add(grdlist.Rows(row.Index).Cells(0).Value, grdlist.Rows(row.Index).Cells(3).Value, grdlist.Rows(row.Index).Cells(4).Value, grdlist.Rows(row.Index).Cells(6).Value, amt)
                                Else
                                    For Each roww As DataGridViewRow In grdfree.Rows
                                        If grdfree.Rows(roww.Index).Cells(1).Value = neym Then
                                            grdfree.Rows(roww.Index).Cells(2).Value = Val(grdfree.Rows(roww.Index).Cells(2).Value) + Val(grdlist.Rows(row.Index).Cells(4).Value)
                                            grdfree.Rows(roww.Index).Cells(4).Value = Val(grdfree.Rows(roww.Index).Cells(4).Value) + amt
                                        End If
                                    Next
                                End If
                            End If
                        Next
                    End If
                Next
            Else
                For Each row As DataGridViewRow In grdlist.Rows
                    Dim neym As String = grdlist.Rows(row.Index).Cells(3).Value
                    Dim amt As Double = Math.Round(grdlist.Rows(row.Index).Cells(9).Value, 2, MidpointRounding.AwayFromZero)
                    If (grdlist.Rows(row.Index).Cells(6).Value <> 0) Then
                        If Not cmbfree.Items.Contains(neym) Then
                            cmbfree.Items.Add(grdlist.Rows(row.Index).Cells(3).Value)
                            grdfree.Rows.Add(grdlist.Rows(row.Index).Cells(0).Value, grdlist.Rows(row.Index).Cells(3).Value, grdlist.Rows(row.Index).Cells(4).Value, grdlist.Rows(row.Index).Cells(6).Value, amt)
                        Else
                            For Each roww As DataGridViewRow In grdfree.Rows
                                If grdfree.Rows(roww.Index).Cells(1).Value = neym Then
                                    grdfree.Rows(roww.Index).Cells(2).Value = Val(grdfree.Rows(roww.Index).Cells(2).Value) + Val(grdlist.Rows(row.Index).Cells(4).Value)
                                    grdfree.Rows(roww.Index).Cells(4).Value = Val(grdfree.Rows(roww.Index).Cells(4).Value) + amt
                                End If
                            Next
                        End If
                    End If

                    For i = 0 To cmb100.Items.Count - 1
                        cmb100.SelectedIndex = i
                        If grdlist.Rows(row.Index).Cells(7).Value = cmb100.SelectedItem Then
                            If Not cmbfree.Items.Contains(neym) Then
                                cmbfree.Items.Add(grdlist.Rows(row.Index).Cells(3).Value)
                                grdfree.Rows.Add(grdlist.Rows(row.Index).Cells(0).Value, grdlist.Rows(row.Index).Cells(3).Value, grdlist.Rows(row.Index).Cells(4).Value, grdlist.Rows(row.Index).Cells(6).Value, amt)
                            Else
                                For Each roww As DataGridViewRow In grdfree.Rows
                                    If grdfree.Rows(roww.Index).Cells(1).Value = neym Then
                                        grdfree.Rows(roww.Index).Cells(2).Value = Val(grdfree.Rows(roww.Index).Cells(2).Value) + Val(grdlist.Rows(row.Index).Cells(4).Value)
                                        grdfree.Rows(roww.Index).Cells(4).Value = Val(grdfree.Rows(roww.Index).Cells(4).Value) + amt
                                    End If
                                Next
                            End If
                        End If
                    Next
                Next
            End If

            tcount()
            Me.Cursor = Cursors.Default

            lbllabel.Text = "All free items in counter out."
        End If
    End Sub

    Private Sub rbitem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbitem.CheckedChanged
        If rbitem.Checked = True Then
            Me.Cursor = Cursors.WaitCursor
            grdfree.Rows.Clear()
            cmbdis.Items.Clear()

            If cmbcat.SelectedItem <> "All" Then
                For Each row As DataGridViewRow In grdlist.Rows
                    If (grdlist.Rows(row.Index).Cells(0).Value = cmbcat.SelectedItem) Then
                        Dim neym As String = grdlist.Rows(row.Index).Cells(5).Value & "% Off"
                        If (grdlist.Rows(row.Index).Cells(5).Value <> 0) Then
                            If Not cmbdis.Items.Contains(neym) Then
                                cmbdis.Items.Add(neym)
                            End If
                        End If
                    End If
                Next
            Else
                For Each row As DataGridViewRow In grdlist.Rows
                    Dim neym As String = grdlist.Rows(row.Index).Cells(5).Value & "% Off"
                    If (grdlist.Rows(row.Index).Cells(5).Value <> 0) Then
                        If Not cmbdis.Items.Contains(neym) Then
                            cmbdis.Items.Add(neym)
                        End If
                    End If
                Next
            End If

            cmbdis.Enabled = True
            If cmbdis.Items.Count <> 0 Then
                cmbdis.Items.Add("All")
                cmbdis.SelectedItem = "All"
            Else
                tcount()
            End If
            Me.Cursor = Cursors.Default

            lbllabel.Text = "All items with discount per item."
        Else
            cmbdis.Enabled = False
        End If
    End Sub

    Private Sub rbtrans_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtrans.CheckedChanged
        If rbtrans.Checked = True Then
            Me.Cursor = Cursors.WaitCursor
            grdfree.Rows.Clear()
            cmbtrans.Items.Clear()

            If cmbcat.SelectedItem <> "All" Then
                For Each row As DataGridViewRow In grdlist.Rows
                    If (grdlist.Rows(row.Index).Cells(0).Value = cmbcat.SelectedItem) Then
                        Dim neym As String = grdlist.Rows(row.Index).Cells(7).Value.ToString
                        If Not cmbtrans.Items.Contains(neym) And neym <> "" Then
                            cmbtrans.Items.Add(neym)
                        End If
                    End If
                Next
            Else
                For Each row As DataGridViewRow In grdlist.Rows
                    Dim neym As String = grdlist.Rows(row.Index).Cells(7).Value.ToString
                    If Not cmbtrans.Items.Contains(neym) And neym <> "" Then
                        cmbtrans.Items.Add(neym)
                    End If
                Next
            End If

            cmbtrans.Enabled = True
            If cmbtrans.Items.Count <> 0 Then
                cmbtrans.Items.Add("All")
                cmbtrans.SelectedItem = "All"
            Else
                tcount()
            End If
            Me.Cursor = Cursors.Default

            lbllabel.Text = "All items with discount in transaction."
        Else
            cmbtrans.Enabled = False
        End If
    End Sub

    Private Sub cmbtrans_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtrans.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        If cmbtrans.SelectedItem = "All" Then
            grdfree.Rows.Clear()
            cmbfree.Items.Clear()

            If cmbcat.SelectedItem <> "All" Then
                For Each row As DataGridViewRow In grdlist.Rows
                    Dim neym As String = grdlist.Rows(row.Index).Cells(3).Value
                    Dim amt As Double = Math.Round(grdlist.Rows(row.Index).Cells(9).Value, 2, MidpointRounding.AwayFromZero)
                    If (grdlist.Rows(row.Index).Cells(0).Value = cmbcat.SelectedItem) Then
                        If (grdlist.Rows(row.Index).Cells(2).Value.ToString = "1") And Val(grdlist.Rows(row.Index).Cells(6).Value.ToString) = 0 Then
                            If Not cmbfree.Items.Contains(neym) Then
                                cmbfree.Items.Add(grdlist.Rows(row.Index).Cells(3).Value)
                                grdfree.Rows.Add(grdlist.Rows(row.Index).Cells(0).Value, grdlist.Rows(row.Index).Cells(3).Value, grdlist.Rows(row.Index).Cells(4).Value, grdlist.Rows(row.Index).Cells(6).Value, amt)
                            Else
                                For Each roww As DataGridViewRow In grdfree.Rows
                                    If grdfree.Rows(roww.Index).Cells(1).Value = neym Then
                                        grdfree.Rows(roww.Index).Cells(2).Value = Val(grdfree.Rows(roww.Index).Cells(2).Value) + Val(grdlist.Rows(row.Index).Cells(4).Value)
                                        grdfree.Rows(roww.Index).Cells(4).Value = Val(grdfree.Rows(roww.Index).Cells(4).Value) + amt
                                    End If
                                Next
                            End If
                        End If
                    End If
                Next
            Else
                For Each row As DataGridViewRow In grdlist.Rows
                    Dim neym As String = grdlist.Rows(row.Index).Cells(3).Value
                    Dim amt As Double = Math.Round(grdlist.Rows(row.Index).Cells(9).Value, 2, MidpointRounding.AwayFromZero)
                    If (grdlist.Rows(row.Index).Cells(2).Value.ToString = "1") And Val(grdlist.Rows(row.Index).Cells(6).Value.ToString) = 0 Then
                        If Not cmbfree.Items.Contains(neym) Then
                            cmbfree.Items.Add(grdlist.Rows(row.Index).Cells(3).Value)
                            grdfree.Rows.Add(grdlist.Rows(row.Index).Cells(0).Value, grdlist.Rows(row.Index).Cells(3).Value, grdlist.Rows(row.Index).Cells(4).Value, grdlist.Rows(row.Index).Cells(6).Value, amt)
                        Else
                            For Each roww As DataGridViewRow In grdfree.Rows
                                If grdfree.Rows(roww.Index).Cells(1).Value = neym Then
                                    grdfree.Rows(roww.Index).Cells(2).Value = Val(grdfree.Rows(roww.Index).Cells(2).Value) + Val(grdlist.Rows(row.Index).Cells(4).Value)
                                    grdfree.Rows(roww.Index).Cells(4).Value = Val(grdfree.Rows(roww.Index).Cells(4).Value) + amt
                                End If
                            Next
                        End If
                    End If
                Next
            End If
        Else
            grdfree.Rows.Clear()
            cmbfree.Items.Clear()

            If cmbcat.SelectedItem <> "All" Then
                For Each row As DataGridViewRow In grdlist.Rows
                    Dim neym As String = grdlist.Rows(row.Index).Cells(3).Value
                    Dim amt As Double = Math.Round(grdlist.Rows(row.Index).Cells(9).Value, 2, MidpointRounding.AwayFromZero)
                    If (grdlist.Rows(row.Index).Cells(0).Value = cmbcat.SelectedItem) Then
                        If (grdlist.Rows(row.Index).Cells(7).Value.ToString = cmbtrans.SelectedItem) And Val(grdlist.Rows(row.Index).Cells(6).Value.ToString) = 0 Then
                            If Not cmbfree.Items.Contains(neym) Then
                                cmbfree.Items.Add(grdlist.Rows(row.Index).Cells(3).Value)
                                grdfree.Rows.Add(grdlist.Rows(row.Index).Cells(0).Value, grdlist.Rows(row.Index).Cells(3).Value, grdlist.Rows(row.Index).Cells(4).Value, grdlist.Rows(row.Index).Cells(6).Value, amt)
                            Else
                                For Each roww As DataGridViewRow In grdfree.Rows
                                    If grdfree.Rows(roww.Index).Cells(1).Value = neym Then
                                        grdfree.Rows(roww.Index).Cells(2).Value = Val(grdfree.Rows(roww.Index).Cells(2).Value) + Val(grdlist.Rows(row.Index).Cells(4).Value)
                                        grdfree.Rows(roww.Index).Cells(4).Value = Val(grdfree.Rows(roww.Index).Cells(4).Value) + amt
                                    End If
                                Next
                            End If
                        End If
                    End If
                Next
            Else
                For Each row As DataGridViewRow In grdlist.Rows
                    Dim neym As String = grdlist.Rows(row.Index).Cells(3).Value
                    Dim amt As Double = Math.Round(grdlist.Rows(row.Index).Cells(9).Value, 2, MidpointRounding.AwayFromZero)
                    If (grdlist.Rows(row.Index).Cells(7).Value.ToString = cmbtrans.SelectedItem) And Val(grdlist.Rows(row.Index).Cells(6).Value.ToString) = 0 Then
                        If Not cmbfree.Items.Contains(neym) Then
                            cmbfree.Items.Add(grdlist.Rows(row.Index).Cells(3).Value)
                            grdfree.Rows.Add(grdlist.Rows(row.Index).Cells(0).Value, grdlist.Rows(row.Index).Cells(3).Value, grdlist.Rows(row.Index).Cells(4).Value, grdlist.Rows(row.Index).Cells(6).Value, amt)
                        Else
                            For Each roww As DataGridViewRow In grdfree.Rows
                                If grdfree.Rows(roww.Index).Cells(1).Value = neym Then
                                    grdfree.Rows(roww.Index).Cells(2).Value = Val(grdfree.Rows(roww.Index).Cells(2).Value) + Val(grdlist.Rows(row.Index).Cells(4).Value)
                                    grdfree.Rows(roww.Index).Cells(4).Value = Val(grdfree.Rows(roww.Index).Cells(4).Value) + amt
                                End If
                            Next
                        End If
                    End If
                Next
            End If
        End If
        tcount()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub rbwout_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbwout.CheckedChanged
        If rbwout.Checked = True Then
            Me.Cursor = Cursors.WaitCursor
            grdfree.Rows.Clear()
            cmbfree.Items.Clear()

            If cmbcat.SelectedItem <> "All" Then
                For Each row As DataGridViewRow In grdlist.Rows
                    Dim neym As String = grdlist.Rows(row.Index).Cells(3).Value
                    Dim amt As Double = Math.Round(grdlist.Rows(row.Index).Cells(9).Value, 2, MidpointRounding.AwayFromZero)
                    If (grdlist.Rows(row.Index).Cells(0).Value = cmbcat.SelectedItem) Then
                        If (Val(grdlist.Rows(row.Index).Cells(2).Value.ToString) = 0) And (grdlist.Rows(row.Index).Cells(5).Value.ToString = "0") And (grdlist.Rows(row.Index).Cells(6).Value.ToString = "0") Then
                            If Not cmbfree.Items.Contains(neym) Then
                                cmbfree.Items.Add(grdlist.Rows(row.Index).Cells(3).Value)
                                grdfree.Rows.Add(grdlist.Rows(row.Index).Cells(0).Value, grdlist.Rows(row.Index).Cells(3).Value, grdlist.Rows(row.Index).Cells(4).Value, grdlist.Rows(row.Index).Cells(6).Value, amt)
                            Else
                                For Each roww As DataGridViewRow In grdfree.Rows
                                    If grdfree.Rows(roww.Index).Cells(1).Value = neym Then
                                        grdfree.Rows(roww.Index).Cells(2).Value = Val(grdfree.Rows(roww.Index).Cells(2).Value) + Val(grdlist.Rows(row.Index).Cells(4).Value)
                                        grdfree.Rows(roww.Index).Cells(4).Value = Val(grdfree.Rows(roww.Index).Cells(4).Value) + amt
                                    End If
                                Next
                            End If
                        End If
                    End If
                Next
            Else
                For Each row As DataGridViewRow In grdlist.Rows
                    Dim neym As String = grdlist.Rows(row.Index).Cells(3).Value
                    Dim amt As Double = Math.Round(grdlist.Rows(row.Index).Cells(9).Value, 2, MidpointRounding.AwayFromZero)
                    If (Val(grdlist.Rows(row.Index).Cells(2).Value.ToString) = 0) And (grdlist.Rows(row.Index).Cells(5).Value.ToString = "0") And (grdlist.Rows(row.Index).Cells(6).Value.ToString = "0") Then
                        If Not cmbfree.Items.Contains(neym) Then
                            cmbfree.Items.Add(grdlist.Rows(row.Index).Cells(3).Value)
                            grdfree.Rows.Add(grdlist.Rows(row.Index).Cells(0).Value, grdlist.Rows(row.Index).Cells(3).Value, grdlist.Rows(row.Index).Cells(4).Value, grdlist.Rows(row.Index).Cells(6).Value, amt)
                        Else
                            For Each roww As DataGridViewRow In grdfree.Rows
                                If grdfree.Rows(roww.Index).Cells(1).Value = neym Then
                                    grdfree.Rows(roww.Index).Cells(2).Value = Val(grdfree.Rows(roww.Index).Cells(2).Value) + Val(grdlist.Rows(row.Index).Cells(4).Value)
                                    grdfree.Rows(roww.Index).Cells(4).Value = Val(grdfree.Rows(roww.Index).Cells(4).Value) + amt
                                End If
                            Next
                        End If
                    End If
                Next
            End If

            tcount()
            Me.Cursor = Cursors.Default

            lbllabel.Text = "All items without discount."
        End If
    End Sub

    Private Sub rball_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rball.CheckedChanged
        If rball.Checked = True Then
            Me.Cursor = Cursors.WaitCursor
            listofitems()
            tcount()
            Me.Cursor = Cursors.Default

            lbllabel.Text = "All items in counter out; these includes free items, and with and without discount items."
        End If
    End Sub

    Public Sub loadall()
        Try
            'Me.Cursor = Cursors.WaitCursor

            Dim temptr As Integer = 0
            grdlist.Rows.Clear()

            connect()
            For Each row As DataGridViewRow In transactions.grd.Rows
                If transactions.grd.Rows(row.Index).Cells("tendertype").Value = "Advance Payment" Then
                    Continue For
                Else
                    'If cmbcat.SelectedItem = "All" Then
                    sql = "Select * from tblorder where transnum='" & transactions.grd.Rows(row.Index).Cells(1).Value & "' order by itemname"
                    'Else
                    'sql = "Select * from tblorder where transnum='" & transactions.grd.Rows(row.Index).Cells(1).Value & "' and category='" & cmbcat.SelectedItem & "' order by itemname"
                    'End If
                    cmd = New SqlCommand(sql, conn)
                    dr = cmd.ExecuteReader
                    While dr.Read
                        grdlist.Rows.Add(dr("category").ToString, dr("transnum").ToString, dr("disctrans"), dr("itemname").ToString, dr("qty"), dr("dscnt"), dr("free"), "", dr("price"), dr("totalprice"), "")
                    End While
                    dr.Dispose()
                    cmd.Dispose()
                End If
            Next

            For Each row As DataGridViewRow In grdlist.Rows
                sql = "Select servicetype from tbltransaction where transnum='" & grdlist.Rows(row.Index).Cells(1).Value & "'"
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    grdlist.Rows(row.Index).Cells(11).Value = dr("servicetype")
                End If
                dr.Dispose()
                cmd.Dispose()
            Next


            For Each row As DataGridViewRow In grdlist.Rows
                Dim withgrpm As Boolean = False
                sql = "Select servicetype,disctype,less,vatsales,vat,remarks from tbltransaction where transnum='" & grdlist.Rows(row.Index).Cells(1).Value & "' and disctype<>'" & String.Empty & "'"
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    grdlist.Rows(row.Index).Cells(7).Value = dr("disctype")

                    If grdlist.Rows(row.Index).Cells(8).Value = 0 Then
                        grdlist.Rows(row.Index).Cells(9).Value = 0
                    Else
                        Dim less As Double = dr("less")
                        Dim discounted As Double = 0
                        If dr("remarks").ToString.Contains("W/ GRPM") And (dr("disctype").ToString.Contains("Senior") Or dr("disctype").ToString.Contains("Pwd")) Then
                            'w/ grpm and based '''''///// discount based on item
                            withgrpm = True
                            grdlist.Rows(row.Index).Cells(10).Value = Val(dr("vatsales")) + Val(dr("vat"))
                        ElseIf Not dr("remarks").ToString.Contains("W/ GRPM") And (dr("disctype").ToString.Contains("Senior") Or dr("disctype").ToString.Contains("Pwd")) Then
                            'w/o grpm  '''''///// senior and pwd discount deretso
                            discounted = ((Val(grdlist.Rows(row.Index).Cells(4).Value) * Val(grdlist.Rows(row.Index).Cells(8).Value)) / 1.12) * 0.8
                        Else
                            'w/o grpm  ''''///// discount not senior nor pwd and regular price pde din
                            discounted = (Val(grdlist.Rows(row.Index).Cells(4).Value) * Val(grdlist.Rows(row.Index).Cells(8).Value)) * ((100 - less) * 0.01)
                        End If
                        grdlist.Rows(row.Index).Cells(9).Value = discounted
                    End If

                Else
                    grdlist.Rows(row.Index).Cells(7).Value = ""
                End If
                dr.Dispose()
                cmd.Dispose()


                If withgrpm = True Then
                    sql = "Select * from tblgroupdisc where itemname='" & grdlist.Rows(row.Index).Cells(3).Value & "' and status='1'"
                    cmd = New SqlCommand(sql, conn)
                    dr = cmd.ExecuteReader
                    If dr.Read Then
                        'item is in grpm
                        Dim basedprice As Double = grdlist.Rows(row.Index).Cells(10).Value
                        Dim origprice As Double = grdlist.Rows(row.Index).Cells(8).Value
                        grdlist.Rows(row.Index).Cells(9).Value = ((basedprice / 1.12) * 0.8) + (origprice - basedprice)
                    Else
                        'item is with grpm but not in grpm
                        grdlist.Rows(row.Index).Cells(10).Value = 0
                        grdlist.Rows(row.Index).Cells(9).Value = (Val(grdlist.Rows(row.Index).Cells(4).Value) * Val(grdlist.Rows(row.Index).Cells(8).Value))
                    End If
                    dr.Dispose()
                    cmd.Dispose()
                End If
            Next

            grdlist.Sort(grdlist.Columns(3), System.ComponentModel.ListSortDirection.Ascending)

            Me.Cursor = Cursors.Default
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

    Public Sub listofitems()
        Try
            'Me.Cursor = Cursors.WaitCursor

            grdfree.Rows.Clear()
            cmbfree.Items.Clear()

            If cmbcat.SelectedItem <> "All" Then
                For Each row As DataGridViewRow In grdlist.Rows
                    Dim neym As String = grdlist.Rows(row.Index).Cells(3).Value
                    If (grdlist.Rows(row.Index).Cells(0).Value = cmbcat.SelectedItem) Then
                        Dim amt As Double = Math.Round(grdlist.Rows(row.Index).Cells(9).Value, 2, MidpointRounding.AwayFromZero)
                        If Not cmbfree.Items.Contains(neym) Then
                            cmbfree.Items.Add(grdlist.Rows(row.Index).Cells(3).Value)
                            grdfree.Rows.Add(grdlist.Rows(row.Index).Cells(0).Value, grdlist.Rows(row.Index).Cells(3).Value, grdlist.Rows(row.Index).Cells(4).Value, grdlist.Rows(row.Index).Cells(6).Value, amt)
                        Else
                            For Each roww As DataGridViewRow In grdfree.Rows
                                If grdfree.Rows(roww.Index).Cells(1).Value = neym Then
                                    grdfree.Rows(roww.Index).Cells(2).Value = Val(grdfree.Rows(roww.Index).Cells(2).Value) + Val(grdlist.Rows(row.Index).Cells(4).Value)
                                    grdfree.Rows(roww.Index).Cells(4).Value = Val(grdfree.Rows(roww.Index).Cells(4).Value) + amt
                                End If
                            Next
                        End If
                    End If
                Next
            Else
                For Each row As DataGridViewRow In grdlist.Rows
                    Dim neym As String = grdlist.Rows(row.Index).Cells(3).Value
                    Dim amt As Double = Math.Round(grdlist.Rows(row.Index).Cells(9).Value, 2, MidpointRounding.AwayFromZero)
                    If Not cmbfree.Items.Contains(neym) Then
                        cmbfree.Items.Add(grdlist.Rows(row.Index).Cells(3).Value)
                        grdfree.Rows.Add(grdlist.Rows(row.Index).Cells(0).Value, grdlist.Rows(row.Index).Cells(3).Value, grdlist.Rows(row.Index).Cells(4).Value, grdlist.Rows(row.Index).Cells(6).Value, amt)
                    Else
                        For Each roww As DataGridViewRow In grdfree.Rows
                            If grdfree.Rows(roww.Index).Cells(1).Value = neym Then
                                grdfree.Rows(roww.Index).Cells(2).Value = Val(grdfree.Rows(roww.Index).Cells(2).Value) + Val(grdlist.Rows(row.Index).Cells(4).Value)
                                grdfree.Rows(roww.Index).Cells(4).Value = Val(grdfree.Rows(roww.Index).Cells(4).Value) + amt
                            End If
                        Next
                    End If
                Next
            End If

            Me.Cursor = Cursors.Default
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

    Private Sub cmbcat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcat.SelectedIndexChanged
        rball.Checked = False
        rball.Checked = True
        cmbdis.Items.Clear()
        cmbtrans.Items.Clear()
    End Sub

    Private Sub rbpull_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbpull.CheckedChanged
        If rbpull.Checked = True Then
            Me.Cursor = Cursors.WaitCursor
            pullout()
            tcount()
            Me.Cursor = Cursors.Default

            lbllabel.Text = "All items pull out."
        End If
    End Sub

    Public Sub pullout()
        Try
            ' Me.Cursor = Cursors.WaitCursor

            grdfree.Rows.Clear()
            sql = "Select * from tblinvsum " & pullcondition
            connect()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            While dr.Read
                'MsgBox(dr("invnum"))
                sql = "Select * from tblinvitems where invnum='" & dr("invnum") & "' order by itemname"
                connect()
                Dim cmd1 As SqlCommand = New SqlCommand(sql, conn)
                Dim dr1 As SqlDataReader = cmd1.ExecuteReader()
                While dr1.Read
                    If dr1("pullout") <> 0 Then
                        If cmbcat.SelectedItem <> "All" Then
                            sql = "Select * from tblitems where itemname='" & dr1("itemname") & "' and category='" & cmbcat.SelectedItem & "'"
                            connect()
                            Dim cmd2 As SqlCommand = New SqlCommand(sql, conn)
                            Dim dr2 As SqlDataReader = cmd2.ExecuteReader
                            If dr2.Read Then
                                'MsgBox(dr1("itemname") & " " & dr1("pullout"))

                                If grdfree.Rows.Count = 0 Then
                                    grdfree.Rows.Add("", dr1("itemname"), dr1("pullout"))
                                Else
                                    Dim walapa As Boolean = True
                                    For Each row As DataGridViewRow In grdfree.Rows
                                        If grdfree.Rows(row.Index).Cells(1).Value = dr1("itemname") Then
                                            walapa = False
                                            grdfree.Rows(row.Index).Cells(2).Value = Val(grdfree.Rows(row.Index).Cells(2).Value) + Val(dr1("pullout"))
                                            Exit For
                                        End If
                                    Next

                                    If walapa = True Then
                                        For Each row As DataGridViewRow In grdfree.Rows
                                            If Not grdfree.Rows(row.Index).Cells(1).Value = dr1("itemname") Then
                                                grdfree.Rows.Add("", dr1("itemname"), dr1("pullout"))
                                                Exit For
                                            End If
                                        Next
                                    End If
                                End If
                            End If
                            dr2.Dispose()
                            cmd2.Dispose()
                        Else
                            'MsgBox(dr1("itemname") & " " & dr1("pullout"))

                            If grdfree.Rows.Count = 0 Then
                                grdfree.Rows.Add("", dr1("itemname"), dr1("pullout"))
                            Else
                                Dim walapa As Boolean = True
                                For Each row As DataGridViewRow In grdfree.Rows
                                    If grdfree.Rows(row.Index).Cells(1).Value = dr1("itemname") Then
                                        walapa = False
                                        grdfree.Rows(row.Index).Cells(2).Value = Val(grdfree.Rows(row.Index).Cells(2).Value) + Val(dr1("pullout"))
                                        Exit For
                                    End If
                                Next

                                If walapa = True Then
                                    For Each row As DataGridViewRow In grdfree.Rows
                                        If Not grdfree.Rows(row.Index).Cells(1).Value = dr1("itemname") Then
                                            grdfree.Rows.Add("", dr1("itemname"), dr1("pullout"))
                                            Exit For
                                        End If
                                    Next
                                End If
                            End If
                        End If
                    End If
                End While
                dr1.Dispose()
                cmd1.Dispose()
            End While
            dr.Dispose()
            cmd.Dispose()

            grdfree.Sort(grdfree.Columns(1), System.ComponentModel.ListSortDirection.Ascending)

            Me.Cursor = Cursors.Default
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

    Private Sub rbsold_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbsold.CheckedChanged
        If rbsold.Checked = True Then
            Me.Cursor = Cursors.WaitCursor
            grdfree.Rows.Clear()
            cmbfree.Items.Clear()

            If cmbcat.SelectedItem <> "All" Then
                For Each row As DataGridViewRow In grdlist.Rows
                    Dim neym As String = grdlist.Rows(row.Index).Cells(3).Value
                    Dim exist As Boolean = False
                    Dim amt As Double = Math.Round(grdlist.Rows(row.Index).Cells(9).Value, 2, MidpointRounding.AwayFromZero)
                    If (grdlist.Rows(row.Index).Cells(0).Value = cmbcat.SelectedItem) Then
                        If (grdlist.Rows(row.Index).Cells(6).Value = 0) And (grdlist.Rows(row.Index).Cells(7).Value <> "Rnd") Then
                            For i = 0 To cmb100.Items.Count - 1
                                cmb100.SelectedIndex = i
                                If grdlist.Rows(row.Index).Cells(7).Value = cmb100.SelectedItem Then
                                    exist = True
                                    Exit For
                                End If
                            Next


                            If exist = False Then
                                If Not cmbfree.Items.Contains(neym) Then
                                    cmbfree.Items.Add(grdlist.Rows(row.Index).Cells(3).Value)
                                    grdfree.Rows.Add(grdlist.Rows(row.Index).Cells(0).Value, grdlist.Rows(row.Index).Cells(3).Value, grdlist.Rows(row.Index).Cells(4).Value, grdlist.Rows(row.Index).Cells(6).Value, amt)
                                Else
                                    For Each roww As DataGridViewRow In grdfree.Rows
                                        If grdfree.Rows(roww.Index).Cells(1).Value = neym Then
                                            grdfree.Rows(roww.Index).Cells(2).Value = Val(grdfree.Rows(roww.Index).Cells(2).Value) + Val(grdlist.Rows(row.Index).Cells(4).Value)
                                            grdfree.Rows(roww.Index).Cells(4).Value = Val(grdfree.Rows(roww.Index).Cells(4).Value) + amt
                                        End If
                                    Next
                                End If
                            End If
                        End If
                    End If
                Next
            Else
                For Each row As DataGridViewRow In grdlist.Rows
                    Dim neym As String = grdlist.Rows(row.Index).Cells(3).Value
                    Dim exist As Boolean = False
                    Dim amt As Double = Math.Round(grdlist.Rows(row.Index).Cells(9).Value, 2, MidpointRounding.AwayFromZero)
                    If (grdlist.Rows(row.Index).Cells(6).Value = 0) And (grdlist.Rows(row.Index).Cells(7).Value <> "Rnd") Then
                        For i = 0 To cmb100.Items.Count - 1
                            cmb100.SelectedIndex = i
                            If grdlist.Rows(row.Index).Cells(7).Value = cmb100.SelectedItem Then
                                exist = True
                                Exit For
                            End If
                        Next


                        If exist = False Then
                            If Not cmbfree.Items.Contains(neym) Then
                                cmbfree.Items.Add(grdlist.Rows(row.Index).Cells(3).Value)
                                grdfree.Rows.Add(grdlist.Rows(row.Index).Cells(0).Value, grdlist.Rows(row.Index).Cells(3).Value, grdlist.Rows(row.Index).Cells(4).Value, grdlist.Rows(row.Index).Cells(6).Value, amt)
                            Else
                                For Each roww As DataGridViewRow In grdfree.Rows
                                    If grdfree.Rows(roww.Index).Cells(1).Value = neym Then
                                        grdfree.Rows(roww.Index).Cells(2).Value = Val(grdfree.Rows(roww.Index).Cells(2).Value) + Val(grdlist.Rows(row.Index).Cells(4).Value)
                                        grdfree.Rows(roww.Index).Cells(4).Value = Val(grdfree.Rows(roww.Index).Cells(4).Value) + amt
                                    End If
                                Next
                            End If
                        End If
                    End If
                Next
            End If

            tcount()
            Me.Cursor = Cursors.Default

            lbllabel.Text = "All sold items in counter out; these includes with and without discount items"
        End If
    End Sub

    Private Sub rbtransfer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtransfer.CheckedChanged
        Try
            'Me.Cursor = Cursors.WaitCursor

            grdfree.Rows.Clear()
            cmbfree.Items.Clear()

            If cmbcat.SelectedItem <> "All" Then
                For Each row As DataGridViewRow In grdlist.Rows
                    Dim neym As String = grdlist.Rows(row.Index).Cells(3).Value
                    If (grdlist.Rows(row.Index).Cells(0).Value = cmbcat.SelectedItem) Then
                        If (grdlist.Rows(row.Index).Cells(11).Value = "Transfer") Then
                            Dim amt As Double = Math.Round(grdlist.Rows(row.Index).Cells(9).Value, 2, MidpointRounding.AwayFromZero)
                            If Not cmbfree.Items.Contains(neym) Then
                                cmbfree.Items.Add(grdlist.Rows(row.Index).Cells(3).Value)
                                grdfree.Rows.Add(grdlist.Rows(row.Index).Cells(0).Value, grdlist.Rows(row.Index).Cells(3).Value, grdlist.Rows(row.Index).Cells(4).Value, grdlist.Rows(row.Index).Cells(6).Value, amt)
                            Else
                                For Each roww As DataGridViewRow In grdfree.Rows
                                    If grdfree.Rows(roww.Index).Cells(1).Value = neym Then
                                        grdfree.Rows(roww.Index).Cells(2).Value = Val(grdfree.Rows(roww.Index).Cells(2).Value) + Val(grdlist.Rows(row.Index).Cells(4).Value)
                                        grdfree.Rows(roww.Index).Cells(4).Value = Val(grdfree.Rows(roww.Index).Cells(4).Value) + amt
                                    End If
                                Next
                            End If
                        End If
                    End If
                Next
            Else
                For Each row As DataGridViewRow In grdlist.Rows
                    Dim neym As String = grdlist.Rows(row.Index).Cells(3).Value
                    Dim amt As Double = Math.Round(grdlist.Rows(row.Index).Cells(9).Value, 2, MidpointRounding.AwayFromZero)
                    If (grdlist.Rows(row.Index).Cells(11).Value = "Transfer") Then
                        If Not cmbfree.Items.Contains(neym) Then
                            cmbfree.Items.Add(grdlist.Rows(row.Index).Cells(3).Value)
                            grdfree.Rows.Add(grdlist.Rows(row.Index).Cells(0).Value, grdlist.Rows(row.Index).Cells(3).Value, grdlist.Rows(row.Index).Cells(4).Value, grdlist.Rows(row.Index).Cells(6).Value, amt)
                        Else
                            For Each roww As DataGridViewRow In grdfree.Rows
                                If grdfree.Rows(roww.Index).Cells(1).Value = neym Then
                                    grdfree.Rows(roww.Index).Cells(2).Value = Val(grdfree.Rows(roww.Index).Cells(2).Value) + Val(grdlist.Rows(row.Index).Cells(4).Value)
                                    grdfree.Rows(roww.Index).Cells(4).Value = Val(grdfree.Rows(roww.Index).Cells(4).Value) + amt
                                End If
                            Next
                        End If
                    End If
                Next
            End If

            tcount()
            Me.Cursor = Cursors.Default

            lbllabel.Text = "All items that are transferred to other branch."

            Me.Cursor = Cursors.Default
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
End Class