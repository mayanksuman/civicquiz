Public Class MCQ_Answer

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Save Score
        'Game_Score(Current_Team_Index, Current_Round_Index, Current_Round_Part_Index) = Val(TextBox1.Text)
        'If Current_Round_Index = 3 Then

        'End If
        'For Last round listener set the 'Current_Team_Index' before showing answer
        Teams(Current_Team_Index).Score(Current_Round_Index, Current_Round_Part_Index) = Val(TextBox1.Text)

        'Team Cycling Code
        Select Case Current_Round_Index
            Case 0
                If Current_Round_Part_Index = 0 Then
                    Current_Team_Index = Current_Team_Index + 1
                    If (Current_Team_Index = 4) Then
                        Current_Team_Index = 3
                        Current_Round_Part_Index = 1
                    End If
                    Subjects.Show()
                Else
                    If Current_Team_Index = 0 Then
                        'Show Score Board
                        ScoreBoard.Show()

                    Else
                        Current_Team_Index = Current_Team_Index - 1
                        Subjects.Show()
                    End If
                End If
            Case 1
                If Current_Round_Part_Index = 0 Then
                    Current_Team_Index = Current_Team_Index + 1
                    If (Current_Team_Index = Num_Of_Team) Then
                        Current_Team_Index = 3
                        Current_Round_Part_Index = 1
                        GoTo loadQue
                    Else
                        Load_Question_In_Form(Our_Question(Current_Team_Index))
                    End If

                    'Subjects.Show()
                Else
                    If Current_Team_Index = 0 Then
                        ScoreBoard.Show()
                        'Show Score Board
                    Else
                        Current_Team_Index = Current_Team_Index - 1
loadQue:
                        Load_Question_In_Form(Our_Question(7 - Current_Team_Index))
                        'Subjects.Show()
                    End If
                End If

            Case 2
                If (Current_Team_Index = 3) Then
                    ScoreBoard.Show()
                    'Show Score Board
                Else
                    Current_Team_Index = Current_Team_Index + 1
                    Load_Question_In_Form(Expert_Question(Current_Team_Index))
                End If
            Case 3
                If (Current_Round_Part_Index = 3) Then
                    ScoreBoard.Show()
                    'Show Score Board
                Else
                    Current_Round_Part_Index = Current_Round_Part_Index + 1
                    Load_Question_In_Form(Arrange_Question(Current_Round_Part_Index))
                End If
        End Select
        Me.Close()
    End Sub

    Private Sub MCQ_Answer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Review_Question.Close()

    End Sub

    Private Sub MCQ_Answer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Elastic_Resize_To_Full_Screen3(Me)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Review_Question.Show()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If Current_Round_Index = 2 Then
            If (Val(TextBox1.Text) < 6) Then
                If (Val(TextBox1.Text) > 0) Then
                    TextBox1.Text = (Val(TextBox1.Text) * 10).ToString
                End If

                If TextBox1.Text = "a" Then
                    TextBox1.Text = "0"
                End If
            End If
        End If
        TextBox1.SelectAll()

    End Sub
End Class