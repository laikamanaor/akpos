Imports System.IO
Imports System.Data.SqlClient

Public Class bundletxt
    Dim strconn As String = login.ss
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim sql As String

    Public btn As String = ""

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

    Private Sub bundletxt_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cmbcat.Items.Clear()
        cmbname.Items.Clear()
        cmbcat.Focus()
    End Sub

    Private Sub bundletxt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbcat.Focus()
        loadcat()
    End Sub

    Public Sub loadcat()
        Try
            cmbcat.Items.Clear()
            sql = "Select category from tblcat where status='1' order by category"
            connect()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            While dr.Read
                cmbcat.Items.Add(dr("category"))
            End While
            dr.Dispose()
            cmd.Dispose()
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
        Try
            If cmbcat.Items.Count <> 0 Then
                cmbname.Items.Clear()
                sql = "Select itemname,itemcode,price from tblitems where category='" & cmbcat.SelectedItem & "' and discontinued='0' order by itemname"
                connect()
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                While dr.Read
                    cmbname.Items.Add(dr("itemname"))
                End While
                dr.Dispose()
                cmd.Dispose()
            End If

            cmbname.Focus()

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

    Private Sub cmbname_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbname.SelectedIndexChanged
        Try
            If cmbname.SelectedItem <> "" Then
                sql = "Select itemname,itemcode,price from tblitems where itemname='" & cmbname.SelectedItem & "' and discontinued='0'"
                connect()
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    If btn = "btnname" Then
                        bundle.lblcode.Text = dr("itemcode")
                    Else
                        bundle.lblprice.Text = dr("price")
                    End If
                End If
            End If

            btnok.Focus()

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

    Private Sub btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
        If cmbcat.Text = "" Then
            MsgBox("Complete the fields.", MsgBoxStyle.Exclamation, "")
            cmbcat.Focus()
        ElseIf cmbname.Text = "" Then
            MsgBox("Complete the fields.", MsgBoxStyle.Exclamation, "")
            cmbname.Focus()
        Else
            If btn = "btnname" Then
                bundle.txtname.Text = cmbname.SelectedItem
            Else
                bundle.txtbased.Text = cmbname.SelectedItem
            End If
            Me.Close()
        End If
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        cmbcat.Items.Clear()
        cmbname.Items.Clear()
        If btn = "btnname" And bundle.btnupdate.Text = "&Update" Then
            bundle.lblcode.Text = ""
        ElseIf btn = "btnbased" And bundle.btnupdate.Text = "&Update" Then
            bundle.lblprice.Text = ""
        End If
        Me.Close()
    End Sub
End Class