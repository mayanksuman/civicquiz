Public Class Quiz_Entry

    Private Sub Quiz_Entry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Initiate_Quiz()
        'Cosmetic Part Begin
        PictureBox1.Top = 0
        PictureBox1.Left = 0
        PictureBox1.Height = Me.ClientRectangle.Height
        PictureBox1.Width = Me.ClientRectangle.Width
        PictureBox1.BackgroundImage = Image.FromFile("Quizotica.jpg")
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch

        Developed_For.Text = "Developed For " + vbCrLf + "Civil Team, NIMBUS"
        Developed_by.Text = vbCrLf + "Developed By " + vbCrLf + "Mayank Suman, Civil Engg. Deptt."
        Copyright.Text = "Copyright © 2010 - 2012 Civil Team, Nimbus, NIT Hamirpur"
        Developed_by.Height = Me.Height / 8
        Developed_by.Width = Me.Width / 4
        Developed_For.Height = Me.Height / 8
        Developed_For.Width = Me.Width / 4
        Developed_For.Top = Me.ClientRectangle.Height / 2 - Developed_For.Height
        Developed_by.Top = Me.ClientRectangle.Height / 2
        Developed_by.Left = (Me.ClientRectangle.Width - Developed_by.Width) / 2
        Developed_For.Left = (Me.ClientRectangle.Width - Developed_For.Width) / 2
        Copyright.Top = Me.ClientRectangle.Height - 4 - Copyright.Height
        Copyright.Left = 10
        Button1.Top = Me.ClientRectangle.Height - 10 - Button1.Height
        Button1.Left = Me.ClientRectangle.Width - 10 - Button1.Width
        Elastic_Resize_To_Full_Screen3(Me)
        Button1.Visible = False
        'Cosmetics Part Ends
        If (Current_Quiz_Part_Index = 0) And (Current_Round_Index = 0) Then
        Else
            Me.Hide()

        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Show_Overloaded_Information("Quizotica: Introduction", "Quiz Procedure and General Rules", "Quzotica_main_rules.rtf", "Proceed To &Quiz")
        Me.Hide()
    End Sub

    
    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Button1.Visible = True
        Timer2.Enabled = False
    End Sub
End Class
