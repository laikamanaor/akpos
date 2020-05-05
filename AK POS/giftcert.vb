Imports System.IO
Imports System.Data.SqlClient
Imports System.Globalization

Public Class giftcert
    Dim strconn As String = login.ss
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim sql As String

    Public condition As String
    Dim culture As CultureInfo = Nothing


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

    Private Sub giftcert_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        txtsearch.Text = ""
        grd.Rows.Clear()
        Me.Dispose()
    End Sub

    Private Sub giftcert_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnview.PerformClick()
    End Sub

    Private Sub btnview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.Click
        Try
            txtsearch.Text = ""
            grd.Rows.Clear()

            If Trim(transactions.txttrans.Text) <> "" Then
                sql = "Select * from tblgctrans where transnum='" & Trim(transactions.txttrans.Text) & "' and status='1'"
                lbldate.Text = Trim(transactions.lbldate.Text.Substring(6, 12))
            Else
                sql = "Select * from tblgctrans where status='1'" & condition
            End If

            connect()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            While dr.Read
                grd.Rows.Add(dr("gcid"), dr("serial"), dr("amt"), dr("transnum"), dr("customer"))
            End While
            dr.Dispose()
            cmd.Dispose()

            If grd.Rows.Count = 0 Then
                MsgBox("No Record Found.", MsgBoxStyle.Critical, "")
                Me.Close()
            End If

            compute()

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

    Private Sub txtsearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsearch.KeyPress
        If Asc(e.KeyChar) = Windows.Forms.Keys.Enter Then
            btnsearch.PerformClick()
        End If
    End Sub

    Private Sub txtsearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.TextChanged
        Dim charactersDisallowed As String = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ 0123456789_-"
        Dim theText As String = txtsearch.Text
        Dim Letter As String
        Dim SelectionIndex As Integer = txtsearch.SelectionStart
        Dim Change As Integer

        For x As Integer = 0 To txtsearch.Text.Length - 1
            Letter = txtsearch.Text.Substring(x, 1)
            If Not charactersDisallowed.Contains(Letter) Then
                theText = theText.Replace(Letter, String.Empty)
                Change = 1
            End If
        Next

        txtsearch.Text = theText
        txtsearch.Select(SelectionIndex - Change, 0)
    End Sub

    Private Sub btnsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        Try
            If Trim(txtsearch.Text) <> "" Then
                grd.Rows.Clear()

                If Trim(transactions.txttrans.Text) <> "" Then
                    sql = "Select * from tblgctrans where serial='" & Trim(txtsearch.Text) & "' and transnum='" & Trim(transactions.txttrans.Text) & "' and status='1'"
                Else
                    sql = "Select * from tblgctrans where serial='" & Trim(txtsearch.Text) & "' and status='1'" & condition
                End If

                connect()
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    grd.Rows.Add(dr("gcid"), dr("serial"), dr("amt"), dr("transnum"), dr("customer"))
                Else
                    MsgBox("Cannot find serial number: " & Trim(txtsearch.Text), MsgBoxStyle.Critical, "")
                    txtsearch.Focus()
                    txtsearch.Text = ""
                End If
            Else
                MsgBox("Input serial number first.", MsgBoxStyle.Exclamation, "")
                txtsearch.Focus()
                txtsearch.Text = ""
            End If

            compute()
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

    Public Sub compute()
        Try
            Dim temp As Double = 0
            For Each row As DataGridViewRow In grd.Rows
                Dim str As Double = Double.Parse(grd.Rows(row.Index).Cells(2).Value, culture)
                temp = temp + str
            Next

            lbltotal.Text = temp.ToString("n2")
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