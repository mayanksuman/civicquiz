Public Class Public_Question_Answer

    Private Sub Public_Question_Answer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = "Public Questions"
        Label1.Text = "Questions :-"
        RichTextBox1.LoadFile("Question.rtf")
        Button1.Text = "Answers"

    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If (Button1.Text = "Answers") Then
            Label1.Text = "Answers :-"
            RichTextBox1.LoadFile("Answers.rtf")
            Button1.Text = "Proceed To Next Round"

        End If
    End Sub

    Private Sub Button1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.TextChanged
        Button1.Left = (Me.Size.Width - Button1.Width) / 2
    End Sub
End Class