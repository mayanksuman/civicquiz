Public Class MCQ
    Dim Arrange_Option_Added_To_List As Integer = 0

    Public Hover_option_Color As Color = Color.ForestGreen
    Public Is_SuperXcel_Taken As Boolean

    Private Sub MCQ_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Elastic_Resize_To_Full_Screen3(Me)
    End Sub
    
    Private Sub Option_Mouse_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionA.MouseEnter, OptionB.MouseEnter, OptionC.MouseEnter, OptionD.MouseEnter, OptionD_Arrangement.MouseEnter, OptionC_Arrangement.MouseEnter, OptionB_Arrangement.MouseEnter, OptionA_Arrangement.MouseEnter
        If Question_Shown.Is_MCQ Then
            sender.backcolor = Hover_option_Color
        End If
    End Sub
    Public Sub Generate_Hint(ByVal hint_Str As String)
        Current_Hint_Index = Current_Hint_Index + 1
        If Current_Hint_Index > 1 Then
            Hint_Button.Enabled = False
        End If
        MsgBox(hint_Str)
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
    Private Sub Option_Mouse_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionA.MouseLeave, OptionB.MouseLeave, OptionC.MouseLeave, OptionD.MouseLeave, OptionD_Arrangement.MouseLeave, OptionC_Arrangement.MouseLeave, OptionB_Arrangement.MouseLeave, OptionA_Arrangement.MouseLeave
        If Question_Shown.Is_MCQ Then
            sender.backcolor = sender.defaultbackcolor
        End If
    End Sub
    Public Sub Show_Answer_Form(ByVal Team_Response As String)
        Send_To_Server(Team_Response, "A")
        Quiz_Entry.Show()
        Me.Close()
    End Sub

    Private Sub Leave_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Leave_Button.Click
        Show_Answer_Form("LEAVE")
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
        Send_To_Server("SUPERXCEL_DEMANDED", "I")
    
            Is_SuperXcel_Taken = True
            SuperXcel_Picture_Box.Visible = True
            Superxcel_Button.Enabled = False

    End Sub
    

    Private Sub Hint_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Hint_Button.Click
        Send_To_Server("HINT_DEMANDED", "I")
        'MsgBox(Question_Shown.Hints(Current_Hint_Index))
        'Current_Hint_Index = Current_Hint_Index + 1
    End Sub

    Private Sub OptionA_Arrangement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionA_Arrangement.Click
        If (Question_Shown.Is_Arrangement_Question) Then
            ArrangedList.Items.Add(Question_Shown.OptionA)
            OptionA_Arrangement.Enabled = False
            Arrange_Option_Added_To_List = Arrange_Option_Added_To_List + 1
            Change_Arrange_Controls()
        End If
    End Sub

    Private Sub OptionB_Arrangement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionB_Arrangement.Click
        If (Question_Shown.Is_Arrangement_Question) Then
            ArrangedList.Items.Add(Question_Shown.OptionB)
            OptionB_Arrangement.Enabled = False
            Arrange_Option_Added_To_List = Arrange_Option_Added_To_List + 1
            Change_Arrange_Controls()
        End If
    End Sub

    Private Sub OptionC_Arrangement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionC_Arrangement.Click
        If (Question_Shown.Is_Arrangement_Question) Then
            ArrangedList.Items.Add(Question_Shown.OptionC)
            OptionC_Arrangement.Enabled = False
            Arrange_Option_Added_To_List = Arrange_Option_Added_To_List + 1
            Change_Arrange_Controls()

        End If
    End Sub

    Private Sub OptionD_Arrangement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionD_Arrangement.Click
        If (Question_Shown.Is_Arrangement_Question) Then
            ArrangedList.Items.Add(Question_Shown.OptionD)
            OptionD_Arrangement.Enabled = False
            Arrange_Option_Added_To_List = Arrange_Option_Added_To_List + 1
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
    End Sub

    Private Sub ArrangedList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ArrangedList.SelectedIndexChanged
        Change_Arrange_Controls()
    End Sub

    Private Sub List_Down_Button_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles List_Down_Button.Click
        Dim i As Integer = ArrangedList.SelectedIndex
        If (i >= 0) Then
            Dim Temp As String = ArrangedList.Items(i + 1).ToString
            ArrangedList.Items(i + 1) = ArrangedList.Items(i)
            ArrangedList.Items(i) = Temp
        End If

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

    Private Sub Leave_Arrange_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

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

    Private Sub Arrangement_Question_Box_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Arrangement_Question_Box.Enter

    End Sub
End Class