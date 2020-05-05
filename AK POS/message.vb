Public Class message

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub Panel5_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel5.MouseEnter
        Panel5.BackColor = Color.FromArgb(23, 23, 23)
    End Sub

    Private Sub Panel5_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel5.MouseLeave
        Panel5.BackColor = Color.Black
    End Sub

    Private Sub btnsend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsend.Click
        'MessageBox.Show(txtmessage.Text)
        Dim pa As New Panel, pa2 As New Panel, pa3 As New Panel, pa4 As New Panel
        Dim lbl1 As New Label, lbltime As New Label, lbl2 As New Label, lbltime2 As New Label
        pa.Height = 63
        pa.Width = 696
        pa.Dock = DockStyle.Top
        pa.Name = "panpan"

        pa2.Height = 50
        pa2.Width = 175
        pa2.Location = New Point(518, 7)
        pa2.Name = "panpan2"
        pa2.BackColor = Color.Gray
        pa.Controls.Add(pa2)

        lbl1.Font = New Font("Arial Rounded MT", 11, FontStyle.Bold)
        lbl1.Name = "lbl1"
        lbl1.Location = New Point(3, 11)
        lbl1.Text = txtmessage.Text
        lbl1.ForeColor = Color.White
        lbl1.BackColor = Color.Gray
        pa2.Controls.Add(lbl1)

        lbltime.Font = New Font("Arial Rounded MT", 8, FontStyle.Regular)
        lbltime.Name = "lblTime"
        lbltime.Location = New Point(100, 15)
        lbltime.Text = DateTime.Now.ToString("hh:mm tt")
        lbltime.ForeColor = Color.Gainsboro
        lbltime.BackColor = Color.Gray
        pa2.Controls.Add(lbltime)

        pa3.Height = 63
        pa3.Width = 696
        pa3.Dock = DockStyle.Top
        pa3.Name = "panpan3"

        pa4.Height = 50
        pa4.Width = 175
        pa4.Location = New Point(7, 7)
        pa4.Name = "panpan4"
        pa4.BackColor = Color.Gray
        pa3.Controls.Add(pa4)

        lbl2.Font = New Font("Arial Rounded MT", 11, FontStyle.Bold)
        lbl2.Name = "lbl2"
        lbl2.Location = New Point(3, 11)
        lbl2.Text = "Hi Gords!"
        lbl2.ForeColor = Color.White
        lbl2.BackColor = Color.Gray
        pa4.Controls.Add(lbl2)

        lbltime2.Font = New Font("Arial Rounded MT", 8, FontStyle.Regular)
        lbltime2.Name = "lblTime2"
        lbltime2.Location = New Point(100, 15)
        lbltime2.Text = DateTime.Now.ToString("hh:mm tt")
        lbltime2.ForeColor = Color.Gainsboro
        lbltime2.BackColor = Color.Gray
        pa4.Controls.Add(lbltime2)

        FlowLayoutPanel2.Controls.Add(pa)
        FlowLayoutPanel2.Controls.Add(pa3)
    End Sub

    Private Sub message_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class