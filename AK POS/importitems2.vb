Imports System.IO
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Public Class importitems2
    Dim cc As New connection_class()
    Dim strconn As String = cc.conString
    Dim conn As New SqlConnection(strconn)
    Dim cmdd As SqlCommand
    Dim rdrr As SqlDataReader

    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Private Sub btnbrowse_Click(sender As Object, e As EventArgs) Handles btnbrowse.Click
        Try
            Dim con As System.Data.OleDb.OleDbConnection
            Dim ds As New DataSet
            Dim cmd As OleDbCommand
            Dim rdr As OleDbDataReader
            Dim opf As New OpenFileDialog()

            If opf.ShowDialog = Windows.Forms.DialogResult.OK Then
                txtpath.Text = opf.FileName
                dgv.Rows.Clear()
                con = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" & txtpath.Text & "; Extended Properties=Excel 12.0;")
                ''     Dim stss As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path + ";Extended Properties=Excel 12.0;"

                con.Open()
                cmd = New OleDbCommand("SELECT * FROM [Sheet1$]", con)
                rdr = cmd.ExecuteReader
                While rdr.Read
                    dgv.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6))
                End While
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    ''' <summary>
    ''' get the server date
    ''' </summary>
    ''' <returns></returns>
    Public Function getSystemDate() As DateTime
        Try
            Dim dt As New DateTime()
            conn.Open()
            cmdd = New SqlCommand("SELECT GETDATE()", conn)
            rdrr = cmdd.ExecuteReader()
            While rdrr.Read
                dt = CDate(rdrr(0).ToString)
            End While
            conn.Close()
            Return dt
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function
    ''' <summary>
    '''  get latest inventory number
    ''' </summary>
    Public Function getInvID() As String
        Dim id As String = ""
        Dim date_ As New DateTime()
        conn.Open()
        cmdd = New SqlCommand("Select TOP 1 invnum,datecreated from tblinvsum WHERE area='" & "Sales" & "' order by invsumid DESC", conn)
        rdrr = cmdd.ExecuteReader()
        If rdrr.Read() Then
            id = rdrr("invnum")
            date_ = CDate(rdrr("datecreated"))
        End If
        conn.Close()
        If date_.ToString("MM/dd/yyyy") = getSystemDate.ToString("MM/dd/yyyy") Then
            Return id
        Else
            Return "N/A"
        End If
    End Function
    Public Function getLastItemID(ByVal itemname As String) As Integer
        Dim itemid As Integer = 0
        conn.Open()
        cmdd = New SqlCommand("Select Top 1 itemid from tblitems WHERE itemname=@itemname", conn)
        cmdd.Parameters.AddWithValue("@itemname", itemname)
        rdrr = cmdd.ExecuteReader
        If rdrr.Read Then
            itemid = rdrr("itemid")
        End If
        conn.Close()
        Return itemid
    End Function
    Private Sub btnsubmit_Click(sender As Object, e As EventArgs) Handles btnsubmit.Click
        Try
            For index As Integer = 0 To dgv.RowCount - 1
                Dim result As Boolean = False
                conn.Open()
                cmdd = New SqlCommand("SELECT itemname FROM tblitems WHERE itemname=@itemname;", conn)
                cmdd.Parameters.AddWithValue("@itemname", dgv.Rows(index).Cells("itemname").Value)
                rdrr = cmdd.ExecuteReader
                If rdrr.Read Then
                    result = True
                End If
                conn.Close()

                If result = False Then
                    conn.Open()
                    cmdd = New SqlCommand("INSERT INTO tblitems (category,itemcode,itemname,description,price,datecreated,createdby,datemodified,status,discontinued,deposit) VALUES (@category,@itemcode,@itemname,@description,@price,(SELECT GETDATE()), @createdby,(SELECT GETDATE()),0,0,@deposit)", conn)
                    cmdd.Parameters.AddWithValue("@category", dgv.Rows(index).Cells("category").Value)
                    cmdd.Parameters.AddWithValue("@itemcode", dgv.Rows(index).Cells("itemcode").Value)
                    cmdd.Parameters.AddWithValue("@itemname", dgv.Rows(index).Cells("itemname").Value)
                    cmdd.Parameters.AddWithValue("@description", dgv.Rows(index).Cells("description").Value)
                    cmdd.Parameters.AddWithValue("@price", dgv.Rows(index).Cells("price").Value)
                    cmdd.Parameters.AddWithValue("@createdby", login2.username)
                    cmdd.Parameters.AddWithValue("@deposit", dgv.Rows(index).Cells("havedeposit").Value)
                    cmdd.ExecuteNonQuery()
                    conn.Close()


                    Dim invnum As String = getInvID()

                    conn.Open()
                    cmdd = New SqlCommand("INSERT INTO tblinvitems (invnum,itemcode,itemname,begbal,produce,good,reject,charge,productionin,itemin,totalav,ctrout,pullout,endbal,actualendbal,variance,shortover,status,convin,archarge,arsales,convout,transfer,area,arreject,supin,adjustmentin,reject_convin,reject_convout,reject_archarge,reject_transfer,reject_totalav,cancelin) VALUES (@invnum,@itemcode,@itemname,0,0,0,0,0,0,0,0,0,0,0,0,0,'',1,0,0,0,0,0,'Sales',0,0,0,0,0,0,0,0,0)", conn)
                    cmdd.Parameters.AddWithValue("@invnum", invnum)
                    cmdd.Parameters.AddWithValue("@itemname", dgv.Rows(index).Cells("itemname").Value)
                    cmdd.Parameters.AddWithValue("@itemcode", dgv.Rows(index).Cells("itemcode").Value)
                    cmdd.ExecuteNonQuery()
                    conn.Close()



                    Dim last_itemid As Integer = getLastItemID(dgv.Rows(index).Cells("itemname").Value)
                    If dgv.Rows(index).Cells("havedeposit").Value = 1 Then
                        conn.Open()
                        cmdd = New SqlCommand("INSERT INTO tbldepositprice (itemid,price) VALUES (@itemid,@price);", conn)
                        cmdd.Parameters.AddWithValue("@itemid", last_itemid)
                        cmdd.Parameters.AddWithValue("@price", dgv.Rows(index).Cells("price").Value)
                        cmdd.ExecuteNonQuery()
                        conn.Close()

                        conn.Open()
                        cmdd = New SqlCommand("INSERT  INTO tbldiscitems (itemid) VALUES (@itemid);", conn)
                        cmdd.Parameters.AddWithValue("@itemid", last_itemid)
                        cmdd.ExecuteNonQuery()
                        conn.Close()
                    End If
                End If
            Next
            MessageBox.Show("Item(s) Added", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub lblclose_Click(sender As Object, e As EventArgs) Handles lblclose.Click
        Me.Close()
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown, MyBase.MouseDown, Label1.MouseDown
        drag = True 'Sets the variable drag to true.
        mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'Sets variable mousey
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp, MyBase.MouseUp, Label1.MouseUp
        drag = False 'Sets drag to false, so the form does not move according to the code in MouseMove
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove, MyBase.MouseMove, Label1.MouseMove
        'If drag is set to true then move the form accordingly.
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub importitems2_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class