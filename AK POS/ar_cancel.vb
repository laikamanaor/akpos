Imports System.Data.SqlClient
Imports System.IO
Public Class ar_cancel
    Dim strconn As String = login.ss
    Dim con As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim adptr As New SqlDataAdapter

    Public lcacc As String = ""
    Dim trnum As String = "", invnum As String = ""

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

    Public Sub loadData(ByVal aaa As String)
        Try

            Dim zz As String = getSystemDate.AddDays(-1).ToString("yyyy-MM-dd")

            Dim invv As String = ""
            con.Open()
            cmd = New SqlCommand("Select TOP 1 invnum from tblinvsum WHERE area='" & lcacc & "' AND invdate='" & zz & "' AND verify=1 order by invsumid DESC", con)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                invv = rdr("invnum")
            End If
            con.Close()

            Dim query As String = "SELECT DISTINCT tblars1.transnum, tblars1.name, tblars1.amountdue, tblars1.date_created,tblars1.created_by,tblars1.date_cancelled,tblars1.cancelled_by,tblars1.sap_no FROM tblars1 JOIN tblproduction ON tblars1.date_created = tblproduction.date WHERE tblproduction.type='Actual Ending Balance' AND tblproduction.area='" & lcacc & "'"
            dgvData.Rows.Clear()
            con.Open()
            Dim one As String = ""
            If aaa = "1" Then
                one = query & " AND tblars1.invnum='" & invv & "'"
            Else
                one = query
            End If
            cmd = New SqlCommand(one, con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                If aaa = "1" Then
                    If IsDBNull(rdr("date_cancelled")) And rdr("sap_no") <> "N/A" Then
                        dgvData.Rows.Add(rdr("transnum"), rdr("name"), CDbl(rdr("amountdue")).ToString("n2"), rdr("date_created"), rdr("created_by"))
                    End If
                    dgvData.Columns("btncancel").Visible = True
                ElseIf aaa = "2" Then
                    If Not IsDBNull(rdr("date_cancelled")) And rdr("sap_no") = "N/A" Then
                        dgvData.Rows.Add(rdr("transnum"), rdr("name"), CDbl(rdr("amountdue")).ToString("n2"), rdr("date_created"), rdr("created_by"))
                    End If
                    dgvData.Columns("btncancel").Visible = False
                End If
            End While
            con.Close()
            If dgvData.RowCount = 0 Then
                lblerror.Visible = True
            Else
                lblerror.Visible = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        loadData("1")
        dgvitems.Rows.Clear()
        btn2.BackColor = Color.Firebrick
        btn1.BackColor = Color.Maroon
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        loadData("2")
        dgvitems.Rows.Clear()
        btn1.BackColor = Color.Firebrick
        btn2.BackColor = Color.Maroon
        panelRemarks.Visible = False
        txtremarks.Text = ""
    End Sub

    Private Sub dgvData_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvData.CellContentClick
        Try
            If e.ColumnIndex = 5 Then
                panelRemarks.Visible = True
            End If
            If dgvData.RowCount <> 0 Then
                dgvitems.Rows.Clear()
                con.Open()
                cmd = New SqlCommand("SELECT description,quantity,price,amount FROM tblars2 WHERE transnum=@trnum;", con)
                cmd.Parameters.AddWithValue("@trnum", dgvData.CurrentRow.Cells("transnum").Value)
                rdr = cmd.ExecuteReader
                While rdr.Read
                    dgvitems.Rows.Add(rdr("description"), rdr("quantity"), CDbl(rdr("price")).ToString("n2"), CDbl(rdr("amount")).ToString("n2"))
                End While
                con.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ar_cancel_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        loadData("1")
    End Sub

    Private Sub ar_cancel_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ar_cancel_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim a As String = MsgBox("Are you sure you want to close AR Cancel Form?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "")
        If a = vbYes Then
            If mainmenu.counters = True Then
                mainmenu.counters = False
                mainmenu.Show()
                Me.Dispose()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            'mdiform.Show()
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub btnproceed_Click(sender As Object, e As EventArgs) Handles btnproceed.Click
        Dim a As String = MsgBox("Are you sure you want to Cancel?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "")
        If a = vbYes Then
            con.Open()
            cmd = New SqlCommand("UPDATE tblars1 SET sap_no='N/A',status='Paid',remarks=@remarks,date_cancelled=(SELECT GETDATE()),cancelled_by='" & login.username & "' WHERE transnum=@transnum;", con)
            cmd.Parameters.AddWithValue("@transnum", dgvData.CurrentRow.Cells("transnum").Value)
            cmd.Parameters.AddWithValue("@remarks", txtremarks.Text)
            cmd.ExecuteNonQuery()
            con.Close()

            GetTransID()
            getID()
            For index As Integer = 0 To dgvitems.Rows.Count - 1

                Dim zz As String = getSystemDate.ToString("MM/dd/yyyy hh:mm:ss tt")

                con.Open()
                cmd = New SqlCommand("INSERT INTO tblproduction (transaction_number,inv_id,item_code,item_name,category,quantity,date,processed_by,type,area,status) VALUES ('" & trnum & "','" & invnum & "',(SELECT itemcode FROM tblitems WHERE itemcode='" & dgvitems.Rows(index).Cells("itemname").Value & "'),'" & dgvitems.Rows(index).Cells("itemname").Value & "',(SELECT category FROM tblitems WHERE itemname='" & dgvitems.Rows(index).Cells("itemname").Value & "'),'" & dgvitems.Rows(index).Cells("quantity").Value & "','" & zz & "','" & login.neym & "','Adjustment Item', '" & lcacc & "', 'Completed');", con)
                cmd.ExecuteNonQuery()
                con.Close()
            Next

            MessageBox.Show("Transaction Completed", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            loadData("1")
            panelRemarks.Visible = False
            txtremarks.Text = ""
        End If
    End Sub
    Public Sub getID()
        Dim id As String = ""
        Dim date_ As New DateTime()
        con.Open()
        cmd = New SqlCommand("Select TOP 1 invnum,datecreated from tblinvsum WHERE area='" & lcacc & "' order by invsumid DESC", con)
        rdr = cmd.ExecuteReader()
        If rdr.Read() Then
            id = rdr("invnum")
            date_ = CDate(rdr("datecreated"))
        End If
        con.Close()
        If date_.ToString("MM/dd/yyyy") = getSystemDate.ToString("MM/dd/yyyy") Then
            invnum = id
        Else
            invnum = "N/A"
        End If
    End Sub
    Public Sub GetTransID()
        Try
            Dim selectcount_result As Integer = 0
            Dim get_area As String = "", temp As String = "1"
            Dim area_format As String = ""
            con.Open()

            cmd = New SqlCommand("Select DISTINCT transaction_number  from tblproduction WHERE area='" & lcacc & "' AND type='" & "Adjustment Item" & "' AND type2='" & "Adjustment" & "';", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                selectcount_result += 1
            End While
            con.Close()
            selectcount_result += 1

            Dim branchcode As String = ""
            con.Open()
            cmd = New SqlCommand("SELECT branchcode FROM tblbranch WHERE main='1';", con)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                branchcode = rdr("branchcode")
            End If
            con.Close()

            If lcacc = "Administrator" Then
                area_format = "RECADJIN - " & branchcode & " - "
            ElseIf lcacc = "Production" Then
                area_format = "PRODADJIN - " & branchcode & " - "
            End If

            If selectcount_result < 1000000 Then
                Dim cselectcount_result As String = CStr(selectcount_result)
                For vv As Integer = 1 To 6 - cselectcount_result.Length
                    temp += "0"
                Next
                trnum = area_format & temp & selectcount_result
            End If
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information, "")
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub lblhide_Click(sender As Object, e As EventArgs) Handles lblhide.Click
        panelRemarks.Visible = False
        txtremarks.Text = ""
    End Sub
End Class