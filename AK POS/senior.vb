Imports System.IO
Imports System.Data.SqlClient
Imports System.Drawing
Imports AK_POS.connection_class
Public Class senior
    Dim cc As New connection_class
    Dim strconn As String = cc.conString
    Dim conn As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim sql As String

    Public sn As Boolean = False, add As Boolean = False

    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function
    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        Try
            If Trim(txtidno.Text) <> "" And Trim(txtname.Text) <> "" Then
                '/confirm.ShowDialog()
                '/If sn = True Then
                'temp in mainmenu
                'mainmenu.lblidno.Text = Trim(txtidno.Text)
                'mainmenu.lblname.Text = Trim(txtname.Text) 'Trim(txtname.Text)
                add = True
                sn = False
                Me.Cursor = Cursors.Default
                Me.Hide()
                '/End If
            Else
                MsgBox("Complete the fields.", MsgBoxStyle.Exclamation, "")
                txtidno.Focus()
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
        End Try
    End Sub
    Public Function getSystemDate() As DateTime
        Try
            Dim dt As New DateTime()
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            cmd = New SqlCommand("SELECT GETDATE()", conn)
            dr = cmd.ExecuteReader()
            While dr.Read
                dt = CDate(dr(0).ToString)
            End While
            conn.Close()
            Return dt
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function
    Private Sub senior_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Try
        '    If login.wrkgrp = "Cashier" Then
        '        Dim serverDate As String = getSystemDate.ToString("MM/dd/yyyy")
        '        conn.Open()
        '        cmd = New SqlCommand("SELECT idno,name FROM tblsenior WHERE transnum=@transnum AND CAST(datedisc AS date)=@date;", conn)
        '        cmd.Parameters.AddWithValue("@transnum", mainmenu.ornum)
        '        cmd.Parameters.AddWithValue("@date", serverDate)
        '        dr = cmd.ExecuteReader
        '        If dr.Read Then
        '            txtidno.Text = dr("idno")
        '            txtname.Text = dr("name")
        '        End If
        '        conn.Close()
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.ToString)
        'End Try
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        mainmenu.cmbdis.SelectedIndex = 0
        Me.Close()
    End Sub
End Class