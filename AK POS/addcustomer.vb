Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports System.Security
Imports System.Security.Cryptography
Imports AK_POS.connection_class
Public Class addcustomer
    Dim cc As New connection_class
    Dim con As New SqlConnection(cc.conString)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim adptr As New SqlDataAdapter


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

    Private Sub addcustomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clear_all()
        load_customers(" status='1';")
        cmbtype.SelectedIndex = 0
        cmbsearchtype.SelectedIndex = 0
    End Sub
    Public Sub load_customers(ByVal stat As String)
        dgvData.Rows.Clear()
        con.Open()
        Dim auto As New AutoCompleteStringCollection()
        Dim query As String = ""
        If stat = "" Then
            query = "SELECT customer_id,name,contact_number,address,status,type,code FROM tblcustomers"
        Else
            query = "SELECT customer_id,name,contact_number,address,status,type,code FROM tblcustomers WHERE " & stat
        End If
        cmd = New SqlCommand(query, con)
        rdr = cmd.ExecuteReader()
        While rdr.Read()
            Dim q As String = ""
            If rdr("status") = "1" Then
                q = "Active"
            ElseIf rdr("status") = "0" Then
                q = "In Active"
            End If
            auto.Add(rdr("name"))
            auto.Add(rdr("contact_number"))
            auto.Add(rdr("address"))
            dgvData.Rows.Add(rdr("customer_id"), rdr("name"), rdr("code"), rdr("contact_number"), rdr("address"), q, rdr("type"))
        End While
        con.Close()
        txtboxSearch.AutoCompleteCustomSource = auto
        If dgvData.Rows.Count = 0 Then
            lblError.Visible = True
        Else
            lblError.Visible = False
        End If
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            If txtname.Text = "" And txtboxContactNo.Text = "" And txtboxAddress.Text = "" Then
                MessageBox.Show("Fields is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            ElseIf txtname.Text = "" Then
                MessageBox.Show("Name is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            ElseIf txtboxContactNo.Text = "" Then
                MessageBox.Show("Contact No. is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            ElseIf txtboxAddress.Text = "" Then
                MessageBox.Show("Address is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            ElseIf txtcode.Enabled = True And String.IsNullOrEmpty(txtcode.Text) Then
                MessageBox.Show("Code is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim code As String = ""

            con.Open()
            cmd = New SqlCommand("SELECT name FROM tblcustomers WHERE name=@name AND type=@type", con)
            cmd.Parameters.AddWithValue("@name", txtname.Text)
            cmd.Parameters.AddWithValue("@type", cmbtype.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                MessageBox.Show("Name is already registered", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                con.Close()
                Exit Sub
            End If
            con.Close()

            If txtcode.Enabled = True Then
                con.Open()
                cmd = New SqlCommand("SELECT code FROM tblcustomers WHERE type=@type", con)
                cmd.Parameters.AddWithValue("@type", cmbtype.Text)
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    code = rdr("code")
                End If
                con.Close()

                If code = txtcode.Text Then
                    MessageBox.Show("Code is already exist", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

            End If

            Dim zz As String = getSystemDate.ToString("MM/dd/yyyy hh:mm tt")

            con.Open()
            cmd = New SqlCommand("INSERT INTO tblcustomers (name,contact_number,address,date,created_by,status,type,code) VALUES (@name,@contact,@address,@date,@created_by,@status,@tayp,@code)", con)
            cmd.Parameters.AddWithValue("@name", txtname.Text)
            cmd.Parameters.AddWithValue("@contact", txtboxContactNo.Text)
            cmd.Parameters.AddWithValue("@address", txtboxAddress.Text)
            cmd.Parameters.AddWithValue("@created_by", login.neym)
            cmd.Parameters.AddWithValue("@date", zz)
            cmd.Parameters.AddWithValue("@status", "1")
            cmd.Parameters.AddWithValue("@tayp", cmbtype.Text)
            cmd.Parameters.AddWithValue("@code", IIf(String.IsNullOrEmpty(txtcode.Text), "", txtcode.Text))
            cmd.ExecuteNonQuery()
            con.Close()
            MessageBox.Show("Added", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            clear_all()
            load_customers("")
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub clear_all()
        txtboxAddress.Text = ""
        txtname.Text = ""
        txtboxContactNo.Text = ""
        txtcode.Text = ""
        cmbStatus.SelectedIndex = 0
    End Sub

    Private Sub txtboxContactNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtboxContactNo.KeyPress
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub dgvData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvData.CellContentClick, dgvData.CellClick
        If e.ColumnIndex = 7 Then
            Dim edit As New editcustomer()
            edit.id = dgvData.CurrentRow.Cells(0).Value
            edit.txtname.Text = dgvData.CurrentRow.Cells("namee").Value
            edit.txtcode.Text = dgvData.CurrentRow.Cells("code").Value
            edit.txtboxContactNo.Text = dgvData.CurrentRow.Cells("contactnumber").Value
            edit.txtboxAddress.Text = dgvData.CurrentRow.Cells("address").Value
            edit.cmbStatus.Text = dgvData.CurrentRow.Cells("status").Value
            edit.ShowDialog()
            load_customers("")
        ElseIf e.ColumnIndex = 8 Then
            Dim a As String = MsgBox("Are you sure you want to delete?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MessageBoxDefaultButton.Button2, "")
            If a = vbYes Then
                con.Open()
                cmd = New SqlCommand("DELETE FROM tblcustomers WHERE customer_id=@id ", con)
                cmd.Parameters.AddWithValue("@id", dgvData.CurrentRow.Cells(0).Value)
                cmd.ExecuteNonQuery()
                con.Close()
                load_customers("")
            End If
        End If

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        con.Open()
        cmd = New SqlCommand("SELECT customer_id,name,contact_number,address,status FROM tblcustomers WHERE name=@search OR contact_number=@search OR address=@search ", con)
        cmd.Parameters.AddWithValue("@search", txtboxSearch.Text)
        rdr = cmd.ExecuteReader()

        If rdr.Read() Then
            For i As Integer = 0 To dgvData.Rows.Count - 1
                If dgvData.Rows(i).Cells(1).Value = rdr("name") Then
                    dgvData.Rows(i).Selected = True
                    dgvData.CurrentCell = dgvData.Rows(i).Cells(1)
                Else
                    dgvData.Rows(i).Selected = False
                End If
            Next
        End If
        con.Close()
    End Sub

    Private Sub cmbStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStatus.SelectedIndexChanged
        If cmbStatus.Text = "Active" Then
            load_customers(" status='1' AND type='" & cmbsearchtype.Text & "';")
        ElseIf cmbStatus.Text = "In Active" Then
            load_customers(" status='0' AND type='" & cmbsearchtype.Text & "';")
        ElseIf cmbStatus.Text = "All" Then
            load_customers(" status='0' OR status='1' AND type='" & cmbsearchtype.Text & "';")
        End If
    End Sub

    Private Sub cmbsearchtype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbsearchtype.SelectedIndexChanged
        If cmbStatus.Text = "Active" Then
            load_customers(" status='1' AND type='" & cmbsearchtype.Text & "';")
        ElseIf cmbStatus.Text = "In Active" Then
            load_customers(" status='0' AND type='" & cmbsearchtype.Text & "';")
        ElseIf cmbStatus.Text = "All" Then
            load_customers(" status='0' OR status='1' AND type='" & cmbsearchtype.Text & "';")
        End If
    End Sub

    Private Sub cmbtype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbtype.SelectedIndexChanged
        If cmbtype.SelectedIndex = 0 Or cmbtype.SelectedIndex = 1 Then
            txtcode.Enabled = True
        Else
            txtcode.Enabled = False
        End If
    End Sub

    Private Sub btnimport_Click(sender As Object, e As EventArgs) Handles btnimport.Click
        Dim frm As New importcustomers()
        frm.ShowDialog()
        load_customers("")
    End Sub
End Class