Imports AK_POS.pos2_class
Public Class mainmenu2
    Dim posc As New pos2_class
    Private catoffset As Integer = 0, catrowFetch As Integer = 4, cattotalCount As Integer = 0, cattotalPage As Integer = 0, catcurrentPage As Integer = 1,
        itemoffset As Integer = 0, itemrowFetch As Integer = 30, itemtotalCount As Integer = 0, itemtotalPage As Integer = 0, itemcurrentPage As Integer = 1
    Private Sub mainmenu2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cattotalCount = catcountLoadItems()
        cattotalPage = Math.Ceiling(cattotalCount / catrowFetch) * 1
        catloadCategories()

        itemtotalCount = itemcountLoadItems()
        cattotalPage = Math.Ceiling(itemtotalCount / itemrowFetch) * 1
        loadItems()
    End Sub

    Private Sub btncatprev_Click(sender As Object, e As EventArgs) Handles btncatprev.Click
        If catoffset > 0 Then
            catoffset -= catrowFetch
            catcurrentPage -= 1
            catloadCategories()
            cattotalCount = catcountLoadItems()
            cattotalPage = Math.Ceiling(cattotalCount / catrowFetch) * 1
        Else
            catoffset = 0
            catcurrentPage = 1
        End If
    End Sub

    Private Sub btnitemprev_Click(sender As Object, e As EventArgs) Handles btnitemprev.Click
        If itemoffset > 0 Then
            itemoffset -= catrowFetch
            itemcurrentPage -= 1
            loadItems()
            itemtotalCount = itemcountLoadItems()
            itemtotalPage = Math.Ceiling(itemtotalCount / itemrowFetch) * 1
        Else
            itemoffset = 0
            itemcurrentPage = 1
        End If
    End Sub

    Private Sub btnitemnxt_Click(sender As Object, e As EventArgs) Handles btnitemnxt.Click
        catoffset += catrowFetch
        catcurrentPage += 1
        If catoffset <= cattotalCount Then
            catloadCategories()
            cattotalCount = catcountLoadItems()
            cattotalPage = Math.Ceiling(cattotalCount / catrowFetch) * 1
        Else
            catoffset -= catrowFetch
            catcurrentPage -= 1
        End If
    End Sub

    Private Sub btncatnxt_Click(sender As Object, e As EventArgs) Handles btncatnxt.Click
        catoffset += catrowFetch
        catcurrentPage += 1
        If catoffset <= cattotalCount Then
            catloadCategories()
            cattotalCount = catcountLoadItems()
            cattotalPage = Math.Ceiling(cattotalCount / catrowFetch) * 1
        Else
            catoffset -= catrowFetch
            catcurrentPage -= 1
        End If
    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Public Sub clearBtnCategories()
        btncat1.Text = ""
        btncat2.Text = ""
        btncat3.Text = ""
        btncat4.Text = ""
    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        loadItems()
    End Sub

    Public Sub catloadCategories()
        Dim result As New DataTable(), catCounter As Integer = 1
        posc.catsetOffset(catoffset)
        posc.catsetrowFetch(catrowFetch)
        result = posc.loadCategories()
        clearBtnCategories()

        For Each r0w As DataRow In result.Rows
            Dim btn As Button = Me.Controls.Find("btncat" & catCounter, True).FirstOrDefault
            btn.Text = r0w(0)
            catCounter += 1
        Next
    End Sub
    Public Function catcountLoadItems() As Integer
        Dim result As Integer = posc.getCategoriesCount
        Return result
    End Function
    Public Sub catrefreshh()
        catcurrentPage = 1
        catoffset = 0
        cattotalCount = catcountLoadItems()
        cattotalPage = Math.Ceiling(cattotalCount / catrowFetch) * 1
        catloadCategories()
    End Sub

    Public Sub loadItems()
        panelitems.Controls.Clear()
        Dim btnWidth As Integer = 104, btnHeight As Integer = 93, result As DataTable
        posc.setItemOffset(itemoffset)
        posc.setItemrowFetch(itemrowFetch)
        posc.setItem(txtsearch.Text)
        result = posc.loadItems()

        For Each r0w As DataRow In result.Rows
            Dim btn As New Button
            btn.Width = btnWidth
            btn.Height = btnHeight
            btn.FlatStyle = FlatStyle.Flat
            btn.FlatAppearance.BorderSize = 0
            btn.Font = New Font("Arial", 9.75, FontStyle.Bold)
            btn.BackColor = Color.Gainsboro
            btn.Cursor = Cursors.Hand
            btn.Name = "btnitem" & r0w("itemid")

            btn.Text = r0w("itemname")
            panelitems.Controls.Add(btn)
        Next

    End Sub
    Public Function itemcountLoadItems() As Integer
        Dim result As Integer = posc.getItemsCount
        Return result
    End Function
End Class