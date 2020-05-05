Imports System.Data.SqlClient
Public Class itemprice

    Dim strconn As String = login.ss
    Dim con As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader

    Private Sub itemprice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadCategories()
        loadItemNames()
    End Sub
    Public Sub loadCategories()
        Try
            cmbcategory.Items.Clear()
            cmbcategory.Items.Add("All")
            con.Open()
            cmd = New SqlCommand("SELECT category FROM tblcat WHERE status=1 ORDER BY category ASC;", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                cmbcategory.Items.Add(rdr("category"))
            End While
            con.Close()
            cmbcategory.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub loadItemNames()
        Try
            Dim auto As New AutoCompleteStringCollection()
            con.Open()
            cmd = New SqlCommand("SELECT itemname FROM tblitems WHERE status=1;", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                auto.Add(rdr("itemname"))
            End While
            con.Close()
            txtsearch.AutoCompleteCustomSource = auto
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub loadItems()
        Try
            Dim q As String = ""

            If cmbcategory.SelectedIndex <> 0 And String.IsNullOrEmpty(txtsearch.Text) Then
                q = "SELECT itemname,category,price FROM tblitems WHERE status=1 AND category=@category ORDER BY itemname ASC;"
            ElseIf cmbcategory.SelectedIndex <> 0 And Not String.IsNullOrEmpty(txtsearch.Text) Then
                q = "SELECT itemname,category,price FROM tblitems WHERE status=1 AND category=@category AND itemname=@itemname ORDER BY itemname ASC;"
            ElseIf cmbcategory.SelectedIndex = 0 And String.IsNullOrEmpty(txtsearch.Text) Then
                q = "SELECT itemname,category,price FROM tblitems WHERE status=1 ORDER BY itemname ASC;"
            ElseIf cmbcategory.SelectedIndex = 0 And Not String.IsNullOrEmpty(txtsearch.Text) Then
                q = "SELECT itemname,category,price FROM tblitems WHERE status=1 AND itemname=@itemname ORDER BY itemname ASC;"
            End If

            dgvlists.Rows.Clear()
            con.Open()
            cmd = New SqlCommand(q, con)

            If cmbcategory.SelectedIndex <> 0 Then
                cmd.Parameters.AddWithValue("@category", cmbcategory.Text)
            End If
            If Not String.IsNullOrEmpty(txtsearch.Text) Then
                cmd.Parameters.AddWithValue("@itemname", txtsearch.Text)
            End If

            rdr = cmd.ExecuteReader
            While rdr.Read
                dgvlists.Rows.Add(rdr("itemname"), rdr("category"), CDbl(rdr("price")).ToString("n2"))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub cmbcategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbcategory.SelectedIndexChanged
        loadItems()
    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        loadItems()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub txtsearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            loadItemNames()
        End If
    End Sub
End Class