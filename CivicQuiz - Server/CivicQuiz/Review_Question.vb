Public Class Review_Question

    Private Sub Review_Question_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Question_Text_Label.Text = Question_Shown.Question_Text
        If (Question_Shown.Is_MCQ = True) Then
            Me.OptionA.Text = "A. " + Question_Shown.OptionA
            Me.OptionB.Text = "B. " + Question_Shown.OptionB
            Me.OptionC.Text = "C. " + Question_Shown.OptionC
            Me.OptionD.Text = "D. " + Question_Shown.OptionD
        Else
            Me.OptionA.Text = ""
            Me.OptionB.Text = ""
            Me.OptionC.Text = ""
            Me.OptionD.Text = ""
        End If
        
        If (Question_Shown.Question_Image = "") Then
        Else
            Me.Question_Image_Box.BackgroundImage = Image.FromFile(Question_Shown.Question_Image)
            Me.Question_Image_Box.BackgroundImageLayout = ImageLayout.Stretch
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class