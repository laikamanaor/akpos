Imports System.Data.SqlClient
Imports System.IO
Imports AK_POS.connection_class
Public Class pendingrequests
    Dim cc As New connection_class
    Dim con As New SqlConnection(cc.conString)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim adptr As New SqlDataAdapter

    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function

    Private Sub pendingrequests_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        loadd()
    End Sub

    Public Function getSystemDate() As DateTime
        Try
            Dim dt As New DateTime()
            con.Open()
            cmd = New SqlCommand("SELECT GETDATE()", con)
            rdr = cmd.ExecuteReader()
            While rdr.Read
                dt = CDate(rdr(0).ToString)
            End While
            con.Close()
            Return dt
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Function

    Public Sub loadd()
        Try
            FlowLayoutPanel1.Controls.Clear()
            Dim query As String = ""

            Dim serverDate As String = datee.Text

            If login2.wrkgrp = "LC Accounting" Then
                query = "SELECT requestid,(SELECT fullname FROM tblusers WHERE systemid=tblrequests.fromid) AS fullname ,description,datecreated,dateapdis FROM tblrequests WHERE status=@status AND CAST(tblrequests.datecreated AS date)=@date"
            Else
                query = "SELECT requestid,(SELECT fullname FROM tblusers WHERE systemid=tblrequests.fromid) AS fullname ,description,datecreated,dateapdis FROM tblrequests WHERE status=@status AND fromid=(SELECT systemid FROM tblusers WHERE username='" & login2.username & "') AND CAST(tblrequests.datecreated AS date)=@date"
            End If
            con.Open()
            cmd = New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@date", serverDate)
            cmd.Parameters.AddWithValue("@status", cmbstatus.Text)
            rdr = cmd.ExecuteReader
            While rdr.Read
                Dim pan As New Panel(), lbl As New Label(), lbldate As New Label(), lbltime As New Label, txt As New TextBox(), btndis As New Button(), btnapp As New Button(), lbldateapdis As New Label(), lbltimeapdis As New Label()
                pan.Name = "pan" & rdr("requestid")
                pan.Width = 948
                pan.Height = 158


                If cmbstatus.Text = "Pending" Then
                    pan.BackColor = Color.DarkOrange

                    btndis.Name = "btndis" & rdr("requestid")
                    btndis.Location = New Point(713, 124)
                    btndis.Cursor = Cursors.Hand
                    btndis.Width = 106
                    btndis.Height = 24
                    btndis.Text = "DISAPPROVE"
                    btndis.BackColor = Color.Firebrick
                    btndis.FlatAppearance.BorderSize = 0
                    btndis.ForeColor = Color.White
                    btndis.Font = New Font("Arial", 10, FontStyle.Bold)
                    btndis.FlatStyle = FlatStyle.Flat


                    btnapp.Name = "btnapp" & rdr("requestid")
                    btnapp.Location = New Point(824, 124)
                    btnapp.Cursor = Cursors.Hand
                    btnapp.Width = 106
                    btnapp.Height = 24
                    btnapp.Text = "APPROVE"
                    btnapp.BackColor = Color.ForestGreen
                    btnapp.FlatAppearance.BorderSize = 0
                    btnapp.ForeColor = Color.White
                    btnapp.Font = New Font("Arial", 10, FontStyle.Bold)
                    btnapp.FlatStyle = FlatStyle.Flat

                ElseIf cmbstatus.Text = "Approve" Then
                    pan.BackColor = Color.ForestGreen
                ElseIf cmbstatus.Text = "Disapprove" Then
                    pan.BackColor = Color.Firebrick
                End If

                If cmbstatus.Text = "Approve" Or cmbstatus.Text = "Disapprove" Then
                    lbldateapdis.Name = "lbldateapdis" & rdr("requestid")
                    lbldateapdis.Width = 200
                    lbldateapdis.Height = 14
                    lbldateapdis.Font = New Font("Arial", 9, FontStyle.Bold)
                    lbldateapdis.Location = New Point(33, 121)
                    lbldateapdis.ForeColor = Color.LightGray
                    lbldateapdis.Text = "Date " & cmbstatus.Text & " : " & CDate(rdr("dateapdis")).ToString("MM/dd/yyyy")

                    lbltimeapdis.Name = "lbltimeapdis" & rdr("requestid")
                    lbltimeapdis.Width = 200
                    lbltimeapdis.Height = 14
                    lbltimeapdis.Font = New Font("Arial", 9, FontStyle.Bold)
                    lbltimeapdis.Location = New Point(33, 132)
                    lbltimeapdis.ForeColor = Color.LightGray
                    lbltimeapdis.Text = "Time " & cmbstatus.Text & " : " & CDate(rdr("dateapdis")).ToString("hh:mm tt")
                End If

                lbl.Name = "lbl" & rdr("requestid")
                lbl.Width = 300
                lbl.Height = 22
                lbl.Font = New Font("Arial", 14, FontStyle.Bold)
                lbl.Location = New Point(35, 6)
                lbl.ForeColor = Color.White
                Dim upp As String = rdr("fullname")
                lbl.Text = upp.ToUpper

                lbldate.Name = "lbldate" & rdr("requestid")
                lbldate.Width = 170
                lbldate.Height = 14
                lbldate.Font = New Font("Arial", 9, FontStyle.Bold)
                lbldate.Location = New Point(782, 0)
                lbldate.ForeColor = Color.LightGray
                lbldate.Text = "Date Request: " & CDate(rdr("datecreated")).ToString("MM/dd/yyyy")

                lbltime.Name = "lbltime" & rdr("requestid")
                lbltime.Width = 170
                lbltime.Height = 14
                lbltime.Font = New Font("Arial", 9, FontStyle.Bold)
                lbltime.Location = New Point(782, 14)
                lbltime.ForeColor = Color.LightGray
                lbltime.Text = "Time Request: " & CDate(rdr("datecreated")).ToString("hh:mm tt")


                txt.Name = "txt" & rdr("requestid")
                txt.Width = 896
                txt.Height = 87
                txt.Font = New Font("Arial", 12, FontStyle.Bold)
                txt.Location = New Point(35, 31)
                txt.BackColor = Color.White
                txt.Text = rdr("description")
                txt.ScrollBars = ScrollBars.Vertical
                txt.ReadOnly = True
                txt.Cursor = Cursors.Default
                txt.Multiline = True
                txt.TextAlign = HorizontalAlignment.Center
                txt.BorderStyle = BorderStyle.None

                AddHandler btndis.Click, AddressOf Me.btndis_click
                AddHandler btnapp.Click, AddressOf Me.btnapp_click

                pan.Controls.Add(lbl)
                pan.Controls.Add(lbldate)
                pan.Controls.Add(lbltime)
                pan.Controls.Add(txt)

                If cmbstatus.Text = "Approve" Or cmbstatus.Text = "Disapprove" Then
                    pan.Controls.Add(lbldateapdis)
                    pan.Controls.Add(lbltimeapdis)
                End If

                If login2.wrkgrp = "LC Accounting" Then
                    If cmbstatus.Text = "Pending" Then
                        pan.Controls.Add(btndis)
                        pan.Controls.Add(btnapp)
                    End If
                End If
                FlowLayoutPanel1.Controls.Add(pan)
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btnapp_click(sender As Object, e As EventArgs)
        Dim btnapp As Button = DirectCast(sender, Button)
        Dim id As Integer = CInt(btnapp.Name.Replace("btnapp", ""))

        Try
            con.Open()
            cmd = New SqlCommand("UPDATE tblrequests SET status='Approve', dateapdis=(SELECT GETDATE())  WHERE requestid=@id", con)
            cmd.Parameters.AddWithValue("@id", id)
            cmd.ExecuteNonQuery()
            con.Close()

            MessageBox.Show("Transaction Completed", "", MessageBoxButtons.OK, MessageBoxIcon.Information)

            loadd()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btndis_click(sender As Object, e As EventArgs)
        Dim btndis As Button = DirectCast(sender, Button)
        Dim id As Integer = CInt(btndis.Name.Replace("btndis", ""))

        Try

            con.Open()
            cmd = New SqlCommand("UPDATE tblrequests SET status='Disapprove', dateapdis=(SELECT GETDATE()) WHERE requestid=@id", con)
            cmd.Parameters.AddWithValue("@id", id)
            cmd.ExecuteNonQuery()
            con.Close()

            MessageBox.Show("Transaction Completed", "", MessageBoxButtons.OK, MessageBoxIcon.Information)

            loadd()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub pendingrequests_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        datee.Text = getSystemDate.ToString("MM/dd/yyyy")
        cmbstatus.SelectedIndex = 0
        loadd()
    End Sub

    Private Sub cmbstatus_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmbstatus.SelectedIndexChanged
        loadd()
    End Sub

    Private Sub btnapprove_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub datee_ValueChanged(sender As Object, e As EventArgs) Handles datee.ValueChanged
        loadd()
    End Sub
End Class