Public Class MCQ
    Dim Arrange_Option_Added_To_List As Integer = 0
    Public Current_Hint_Index As Integer
    Public Hover_option_Color As Color = Color.ForestGreen
    Public Is_SuperXcel_Taken As Boolean
    Public Question_Start_Time As Date = Now

    Private Sub MCQ_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Elastic_Resize_To_Full_Screen3(Me)
    End Sub
    
    Private Sub Option_Mouse_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionD.MouseEnter, OptionC.MouseEnter, OptionB.MouseEnter, OptionA.MouseEnter, OptionA_Arrangement.MouseEnter, OptionB_Arrangement.MouseEnter, OptionC_Arrangement.MouseEnter, OptionD_Arrangement.MouseEnter
        If Question_Shown.Is_MCQ Then
            sender.backcolor = Hover_option_Color
        End If
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If (Question_Shown.Time_Seconds > 0) Then
            Dim Left_Time_Second As Integer
            Dim Time_Taken As System.TimeSpan
            Time_Taken = Now() - Question_Start_Time
            Left_Time_Second = Time_Taken.TotalSeconds
            Left_Time_Second = Question_Shown.Time_Seconds - Left_Time_Second

            
            If (Question_Shown.Time_Seconds > 60) Then
                Label4.Text = (Question_Shown.Time_Seconds \ 60).ToString + " Min. " + (Question_Shown.Time_Seconds - (Question_Shown.Time_Seconds \ 60) * 60).ToString + " Sec."
            Else
                Label4.Text = Question_Shown.Time_Seconds.ToString + " Sec."
            End If

            If (Left_Time_Second < 0) Then
                Show_Answer_Form("TIMELAPSE")
            Else
                If (Left_Time_Second > 60) Then
                    Label5.Text = (Left_Time_Second \ 60).ToString + " Min. " + (Left_Time_Second - (Left_Time_Second \ 60) * 60).ToString + " Sec."
                Else
                    Label5.Text = Left_Time_Second.ToString + " Sec."
                End If
                Me.ProgressBar1.Value = Left_Time_Second
            End If
            
        End If
    End Sub
    Private Sub Option_Mouse_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionD.MouseLeave, OptionC.MouseLeave, OptionB.MouseLeave, OptionA.MouseLeave, OptionA_Arrangement.MouseLeave, OptionB_Arrangement.MouseLeave, OptionC_Arrangement.MouseLeave, OptionD_Arrangement.MouseLeave
        If Question_Shown.Is_MCQ Then
            sender.backcolor = sender.defaultbackcolor
        End If
    End Sub
    Public Sub Show_Answer_Form(ByVal Team_Response As String)
        If Is_Question_Shown Then
            Dim Answer_Status As Integer
            Dim Points_Earned As Integer
            Num_Of_Team_Answered = Num_Of_Team_Answered + 1

            If Question_Shown.Answer = Team_Response Then
                Answer_Status = 1  'Right
            Else
                Answer_Status = 0   'Wrong
                If (Team_Response = "ANSWER_EXPERT_QUESTION") Then
                    Answer_Status = 2
                End If
                If (Team_Response = "LEAVE") Then
                    Answer_Status = 3
                End If
                If (Team_Response = "TIMELAPSE") Then
                    Answer_Status = 4
                End If
                If Team_Response = "SERVER_LEAVE" Then
                    If Current_Round_Index = 3 Then
                        Dim a As Integer
                        For a = 0 To 3
                            Send_To_Client("DEACTIVATE", "I", Teams(a))
                        Next
                        Answer_Status = 6
                    End If

                End If
                If (Answer_Status = 0) Then
                    'ALL_NOT_ANSWERED
                    If Num_Of_Team_Answered = 4 Then
                        Answer_Status = 5
                    End If
                End If

            End If

            If (Answer_Status = 1) Or (Answer_Status = 4) Or (Answer_Status = 5) Then
                If Current_Round_Index = 3 Then
                    Dim a As Integer
                    For a = 0 To 3
                        Send_To_Client("DEACTIVATE", "I", Teams(a))
                    Next

                Else
                    Send_To_Client("DEACTIVATE", "I", Teams(Current_Team_Index))
                End If
            Else
                Send_To_Client("DEACTIVATE", "I", Teams(Current_Team_Index))
            End If
            'If Not (Answer_Status = 1) Then
            'If Current_Round_Index = 3 Then
            'Current_Team_Index = 0
            'End If
            'End If


            Points_Earned = 0
            MCQ_Answer.Label1.Text = "The right answer is "
            MCQ_Answer.Label2.Text = Question_Shown.Show_Answer
            Select Case Answer_Status
                Case 0
                    If (Current_Round_Index = 3) Then
                        Label10.Text = Label10.Text + Teams(Current_Team_Index).Name + " answered wrong. Team Deactivated."
                    Else
                        MCQ_Answer.Label3.Text = "Sorry, " + Teams(Current_Team_Index).Name + " has answered wrong."
                        Points_Earned = Quiz_Parts(Current_Quiz_Part_Index).Rounds(Current_Round_Index).Wrong_Points
                    End If

                    'False
                Case 1
                    'True
                    If (Current_Round_Index = 3) Then
                        Label10.Text = Label10.Text + Teams(Current_Team_Index).Name + " answered right. Team Deactivated."
                    End If
                    MCQ_Answer.Label3.Text = "Congratulations, " + Teams(Current_Team_Index).Name + " has answered the right option."
                    Points_Earned = Quiz_Parts(Current_Quiz_Part_Index).Rounds(Current_Round_Index).Max_Points
                Case 2
                    If (Current_Round_Index = 2) Then
                        MCQ_Answer.Label1.Text = Teams(Current_Team_Index).Name + " has answered the question."
                        MCQ_Answer.Label2.Text = "Waiting for response of Expert."
                        MCQ_Answer.Label3.Text = ""
                    End If
                    'No Answer -Expert Questions
                Case 3
                    'Left Question                        
                    MCQ_Answer.Label3.Text = Teams(Current_Team_Index).Name + " opted for leaving the question."
                    'Cant do in 4th round
                Case 4
                    If (Current_Round_Index = 3) Then
                        Label10.Text = Label10.Text + Teams(Current_Team_Index).Name + "Time up. All teams Deactivated."
                        MCQ_Answer.Label3.Text = "No Team was able to answer this question in time."

                    Else
                        MCQ_Answer.Label3.Text = "The time for " + Teams(Current_Team_Index).Name + " ran out."
                    End If
                    'Time Lapse
                Case 5
                    'No Answer Correct All Team
                    If (Current_Round_Index = 3) Then
                        Label10.Text = Label10.Text + "No Team was able to answer question correctly. All Teams Deactivated"
                        MCQ_Answer.Label3.Text = "No Team was able to answer this question."
                    End If
                Case 6
                    ''Server Leave in 3rd round
                    If Current_Round_Index = 3 Then
                        Label10.Text = Label10.Text + "Server Opted to leave this question. All Teams Deactivated"
                        MCQ_Answer.Label3.Text = "Sever opted to leave this question."
                    End If
            End Select
            If Current_Round_Index = 3 Then
                Label10.Text = Label10.Text + vbCrLf
            End If

            If (Answer_Status = 3) Or (Answer_Status = 4) Then
                Points_Earned = 0
            Else
                If Question_Shown.Is_Having_Hints = True Then
                    If Current_Hint_Index > 0 Then
                        MCQ_Answer.Label3.Text = MCQ_Answer.Label3.Text + vbCrLf + "Use of " + Current_Hint_Index.ToString
                        If (Current_Hint_Index = 1) Then
                            MCQ_Answer.Label3.Text = MCQ_Answer.Label3.Text + " hints has resulted in deduction of " + (Current_Hint_Index * 5).ToString + " points."
                        Else

                            MCQ_Answer.Label3.Text = MCQ_Answer.Label3.Text + " hints has resulted in deduction of " + (Current_Hint_Index * 5).ToString + " points."
                        End If

                        Points_Earned = Points_Earned - Current_Hint_Index * 5
                    End If
                End If
                If Is_SuperXcel_Taken Then
                    MCQ_Answer.Label3.Text = MCQ_Answer.Label3.Text + vbCrLf + "Superxcel was active, which has double the points of " + Teams(Current_Team_Index).Name + "."
                    Points_Earned = 2 * Points_Earned
                End If
            End If

            MCQ_Answer.TextBox1.Text = Points_Earned.ToString
            If Current_Round_Index = 3 Then
                If (Answer_Status = 1) Or (Answer_Status = 4) Or (Answer_Status = 5) Or (Answer_Status = 6) Then
                    MCQ_Answer.Show()
                    Is_Question_Shown = False
                    Me.Close()
                End If
            Else
                MCQ_Answer.Show()
                Is_Question_Shown = False
                Me.Close()
            End If
        End If
    End Sub

    Private Sub Leave_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Leave_Button.Click
        If (Current_Round_Index = 2) Then
            Show_Answer_Form("ANSWER_EXPERT_QUESTION")
        Else
            Show_Answer_Form("LEAVE")
        End If

    End Sub

    Private Sub OptionD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionD.Click
        If Question_Shown.Is_MCQ Then
            Show_Answer_Form(Question_Shown.OptionD)
        End If

    End Sub

    Private Sub OptionA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionA.Click
        If Question_Shown.Is_MCQ Then
            Show_Answer_Form(Question_Shown.OptionA)
        End If
    End Sub

    Private Sub OptionB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionB.Click
        If Question_Shown.Is_MCQ Then
            Show_Answer_Form(Question_Shown.OptionB)
        End If
    End Sub

    Private Sub OptionC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionC.Click
        If Question_Shown.Is_MCQ Then
            Show_Answer_Form(Question_Shown.OptionC)
        End If
    End Sub

    Private Sub Superxcel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Superxcel_Button.Click
        Activate_SuperXcel()
    End Sub
    Public Sub Activate_SuperXcel()
        If Is_Question_Shown Then
            Is_SuperXcel_Taken = True
            SuperXcel_Picture_Box.Visible = True
            Superxcel_Button.Enabled = False
        End If
    End Sub
    Private Sub Hint_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Hint_Button.Click
        Dim msgstr As String = Generate_Hint()
        If Not (msgstr = "") Then
            MsgBox(msgstr, vbOKOnly)
        End If
    End Sub
    Public Function Generate_Hint() As String
        If Is_Question_Shown Then
            Generate_Hint = Question_Shown.Hints(Current_Hint_Index)
            Current_Hint_Index = Current_Hint_Index + 1
            If Current_Hint_Index > 1 Then
                Current_Hint_Index = 2
                Hint_Button.Enabled = False
            End If
        Else
            Generate_Hint = ""
        End If
    End Function
    Private Sub OptionA_Arrangement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionA_Arrangement.Click
        If (Question_Shown.Is_Arrangement_Question) Then
            ArrangedList.Items.Add(Question_Shown.OptionA)
            OptionA_Arrangement.Enabled = False
            Arrange_Option_Added_To_List = Arrange_Option_Added_To_List + 1
            ArrangedList.SelectedIndex = Arrange_Option_Added_To_List - 1
            Change_Arrange_Controls()
        End If
    End Sub

    Private Sub OptionB_Arrangement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionB_Arrangement.Click
        If (Question_Shown.Is_Arrangement_Question) Then
            ArrangedList.Items.Add(Question_Shown.OptionB)
            OptionB_Arrangement.Enabled = False
            Arrange_Option_Added_To_List = Arrange_Option_Added_To_List + 1
            ArrangedList.SelectedIndex = Arrange_Option_Added_To_List - 1
            Change_Arrange_Controls()
        End If
    End Sub

    Private Sub OptionC_Arrangement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionC_Arrangement.Click
        If (Question_Shown.Is_Arrangement_Question) Then
            ArrangedList.Items.Add(Question_Shown.OptionC)
            OptionC_Arrangement.Enabled = False
            Arrange_Option_Added_To_List = Arrange_Option_Added_To_List + 1
            ArrangedList.SelectedIndex = Arrange_Option_Added_To_List - 1
            Change_Arrange_Controls()
        End If
    End Sub

    Private Sub OptionD_Arrangement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionD_Arrangement.Click
        If (Question_Shown.Is_Arrangement_Question) Then
            ArrangedList.Items.Add(Question_Shown.OptionD)
            OptionD_Arrangement.Enabled = False
            Arrange_Option_Added_To_List = Arrange_Option_Added_To_List + 1
            ArrangedList.SelectedIndex = Arrange_Option_Added_To_List - 1
            Change_Arrange_Controls()
        End If
    End Sub


    Private Sub List_Up_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles List_Up_Button.Click

        Dim i As Integer = ArrangedList.SelectedIndex
        If (i > 0) Then
            Dim Temp As String = ArrangedList.Items(i - 1).ToString
            ArrangedList.Items(i - 1) = ArrangedList.Items(i)
            ArrangedList.Items(i) = Temp
        End If
        ArrangedList.SelectedIndex = i - 1
        ' ArrangedList.SelectedIndex
    End Sub

    Private Sub ArrangedList_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles ArrangedList.DrawItem

    End Sub

    Private Sub ArrangedList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ArrangedList.SelectedIndexChanged
        Change_Arrange_Controls()
    End Sub
    Public Sub Change_Arrange_Controls()
        If (Arrange_Option_Added_To_List = 4) Then
            Submit_Arrange_Button.Enabled = True
        End If
        If ArrangedList.SelectedIndex = 0 Then
            List_Up_Button.Enabled = False
        Else
            List_Up_Button.Enabled = True
        End If

        If ArrangedList.SelectedIndex = Arrange_Option_Added_To_List - 1 Then
            List_Down_Button.Enabled = False
        Else
            List_Down_Button.Enabled = True
        End If
    End Sub
    Private Sub List_Down_Button_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles List_Down_Button.Click
        Dim i As Integer = ArrangedList.SelectedIndex
        If (i >= 0) Then
            Dim Temp As String = ArrangedList.Items(i + 1).ToString
            ArrangedList.Items(i + 1) = ArrangedList.Items(i)
            ArrangedList.Items(i) = Temp
        End If
        ArrangedList.SelectedIndex = i + 1

    End Sub

    Private Sub Submit_Arrange_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Submit_Arrange_Button.Click
        Dim AnswerStr As String = ""
        For i = 0 To 3
            If Not (ArrangedList.Items(i).ToString = "") Then
                AnswerStr = AnswerStr + ArrangedList.Items(i).ToString
            End If
        Next
        Show_Answer_Form(AnswerStr)
    End Sub

    Private Sub Leave_Arrange_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Leave_Arrange_Button.Click
        Show_Answer_Form("SERVER_LEAVE")
    End Sub

End Class