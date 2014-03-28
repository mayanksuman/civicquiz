Public Class Audience_Question_Form
    Private Sub Leave_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Leave_Button.Click
        
        If Leave_Button.Text = "Next Question" Then
            Current_Audience_Question_Index = Current_Audience_Question_Index + 1
            Load_Audience_Question()
            Leave_Button.Text = "Show Answer"
            Label2.Text = ""
        Else
            If (Leave_Button.Text = "Show Answer") Then
                Label2.Text = Audience_Question(Current_Audience_Question_Index).Show_Answer
                If (Current_Audience_Question_Index Mod 2 = 1) Then
                    Leave_Button.Text = "Next Round"
                    If Current_Round_Index = 3 Then
                        Leave_Button.Text = "Show Final Scores"
                    End If
                Else
                    Leave_Button.Text = "Next Question"
                End If
            End If
            If Leave_Button.Text = "Next Round" Then
                If (Current_Audience_Question_Index Mod 2 = 1) Then
                    Current_Audience_Question_Index = Current_Audience_Question_Index + 1
                    Current_Round_Index = Current_Round_Index + 1
                    Run_Quiz()
                    Me.Close()
                End If
            End If
            If Leave_Button.Text = "Show Final Scores" Then
                ScoreBoard.Show()
                Me.Close()

            End If
            End If

    End Sub

    Private Sub Audience_Question_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Elastic_Resize_To_Full_Screen3(Me)
        Leave_Button.Text = "Show Answer"
    End Sub
End Class