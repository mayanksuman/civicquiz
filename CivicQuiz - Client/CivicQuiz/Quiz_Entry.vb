Public Class Quiz_Entry

    Private Sub Quiz_Entry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        This_Team.Name = ""
        Server_Info.Show()

        'Get the team name
        Team_Disp.Text = " Dashboard for " + This_Team.Name
        Copyright.Text = "Copyright © 2010 - 2012 Civil Team, Nimbus, NIT Hamirpur"

        Copyright.Top = Me.ClientRectangle.Height - 4 - Copyright.Height
        Copyright.Left = 10
        wait.Top = (Me.ClientRectangle.Height - wait.Height) / 2
        wait.Left = (Me.ClientRectangle.Width - wait.Width) / 2
        Elastic_Resize_To_Full_Screen3(Me)
        wait.Visible = False
        Timer1.Enabled = True
        Timer1.Interval = 1000
        PictureBox1.Top = 0
        PictureBox1.Left = 0
        PictureBox1.Height = Me.ClientRectangle.Height
        PictureBox1.Width = Me.ClientRectangle.Width
        'Cosmetics Part Ends

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If (This_Team.Name = "") Then
        Else
            Team_Disp.Text = " Dashboard for " + This_Team.Name
            Timer1.Enabled = False
        End If

    End Sub
End Class
