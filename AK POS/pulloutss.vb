Imports System.Data.SqlClient
Imports System.IO
Public Class pulloutss

    Dim strconn As String = login.ss
    Dim con As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader


    Dim tayp As String = "", ar_number As String = "", conv_number As String = "", selectQuantity As String = "", transnum As String = ""

    Public lcacc As String = ""
    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function

    Private Sub pulloutss_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rbarreject.Checked = True
        'loadItems()
        loadEmployees()
    End Sub
    Public Sub loadEmployees()
        Try
            Dim auto As New AutoCompleteStringCollection()
            con.Open()
            cmd = New SqlCommand("SELECT name FROM tblcustomers WHERE status=1 AND type='Employee';", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                auto.Add(CStr(rdr("name")))
            End While
            con.Close()
            txtname.AutoCompleteCustomSource = auto
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btnQuantity_Click(sender As Object, e As EventArgs) Handles btnQuantity.Click

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
        'If date_.ToString("MM/dd/yyyy") = DateTime.Now.ToString("MM/dd/yyyy") Then
        '    lblID.Text = id
        'Else
        '    lblID.Text = "N/A"
        'End If
    End Sub
    'Public Sub loadItems()
    '    Try
    '        getID()
    '        dgvListItem.Rows.Clear()
    '        con.Open()
    '        cmd = New SqlCommand("SELECT tblinvitems.itemcode,tblinvitems.itemname,tblitems.category,tblinvitems.reject FROM tblinvitems JOIN tblitems ON tblitems.itemname = tblinvitems.itemname AND tblitems.itemcode = tblinvitems.itemcode WHERE invnum='" & lblID.Text & "' AND reject !=0;", con)
    '        rdr = cmd.ExecuteReader
    '        While rdr.Read
    '            dgvListItem.Rows.Add(rdr("itemcode"), rdr("itemname"), rdr("category"), rdr("reject"))
    '        End While
    '        con.Close()
    '    Catch ex As Exception
    '        MessageBox.Show(ex.ToString)
    '    End Try
    'End Sub

    Private Sub dgvListItem_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListItem.CellClick
        Try
            If e.ColumnIndex = 4 Then
                lblQuantityItemCode.Text = "Item Code: " & dgvListItem.CurrentRow.Cells("itemcode").Value.ToString
                lblQuantityItemName.Text = "Item Name: " & dgvListItem.CurrentRow.Cells("itemname").Value.ToString
                lblQuantityCategory.Text = "Category: " & dgvListItem.CurrentRow.Cells("category").Value.ToString
                txtboxQuantity.Text = ""
                selectQuantity = "Add"
                panelQuantity.Visible = True
                panelQuantity.BringToFront()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Function checkRowsExist() As Boolean
        Dim get_itemname As String = lblQuantityItemName.Text.Replace("Item Name: ", "")
        Dim get_itemcode As String = lblQuantityItemCode.Text.Replace("Item Code: ", "")
        For i As Integer = 0 To dgvSelectedItem.Rows.Count - 1
            If get_itemcode = dgvSelectedItem.Rows(i).Cells(0).Value And get_itemname = dgvSelectedItem.Rows(i).Cells(1).Value Then
                Dim quantity_add As Integer = Val(dgvSelectedItem.Rows(i).Cells("quantityy").Value) + Val(txtboxQuantity.Text)

                If selectQuantity = "Add" Then
                    dgvSelectedItem.Rows(i).Cells("quantityy").Value = quantity_add
                Else
                    dgvSelectedItem.Rows(i).Cells("quantityy").Value = txtboxQuantity.Text
                End If

                Me.Cursor = Cursors.WaitCursor
                panelQuantity.Visible = False
                Me.Cursor = Cursors.Default
                txtboxQuantity.Text = ""
                dgvSelectedItem.ClearSelection()
                dgvSelectedItem.Rows(dgvSelectedItem.Rows.Count - 1).Selected = True
                Return True
            End If
        Next
    End Function
End Class