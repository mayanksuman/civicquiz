Public Class Round_Welcome

    Private Sub Round_Welcome_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PictureBox1.Top = 0
        PictureBox1.Left = 0
        PictureBox1.Height = Me.ClientRectangle.Height
        PictureBox1.Width = Me.ClientRectangle.Width
        If Not (Quiz_Parts(Current_Quiz_Part_Index).Rounds(Current_Round_Index).Round_Image_File = "") Then
            Dim filestr As String = Quiz_Parts(Current_Quiz_Part_Index).Rounds(Current_Round_Index).Round_Image_File
            PictureBox1.BackgroundImage = Image.FromFile(filestr)
            PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        End If
        Label1.Text = Quiz_Parts(Current_Quiz_Part_Index).Rounds(Current_Round_Index).Round_Name
        Label1.Top = (Me.ClientRectangle.Height - Label1.Height) / 2
        Label1.Left = (Me.ClientRectangle.Width - Label1.Width) / 2
        If Current_Quiz_Part_Index = 0 Then
            Button1.Text = "Show &Questions"
        Else
            Button1.Text = "Show &Rules"
        End If
        Button1.Top = Me.ClientRectangle.Height - 10 - Button1.Height
        Button1.Left = Me.ClientRectangle.Width - 10 - Button1.Width
        Label1.AutoSize = False
        Elastic_Resize_To_Full_Screen3(Me)


    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Current_Quiz_Part_Index = 0 Then
            Show_Overloaded_Information("Questions For Qualifying Round", "Questions :-", "Test.rtf", "Show &Answer")
        Else
            Show_Default_Information()
        End If
        Me.Close()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
End Class