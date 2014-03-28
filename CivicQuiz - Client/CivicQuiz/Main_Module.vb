Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Public Module Main_Module
    Public Structure Ratio
        Public Wratio As Single
        Public Hratio As Single
        Public Lratio As Single
        Public Tratio As Single
    End Structure

    Public Structure Question
        Public Is_MCQ As Boolean
        Public Is_Arrangement_Question As Boolean
        Public Is_Rapid_Question As Boolean
        Public Question_Text As String
        Public OptionA As String
        Public OptionB As String
        Public OptionC As String
        Public OptionD As String
        Public Is_Having_Hints As Boolean
        Public Num_of_Hint As Integer
        Public Hints() As String
        Public Is_Having_SuperXcel As Boolean
        Public Answer As String
        Public Show_Answer As String
        Public Time_Seconds As Integer    '0 means unlimited
        Public Question_Image As String
    End Structure
    Public Structure Team
        Public Name As String
        Public IPAdress As String
        Public Port As Integer
        Public Score(,) As Integer
    End Structure

    Public Num_Of_Team As Integer = 4
    Public Teams(Num_Of_Team) As Team
    Public Quiz_Server As Team
    Public This_Team As Team

    
    Public Question_Shown As Question
   


    Public Question_Start_Time As Date

    Public Current_Hint_Index As Integer
    Public Option_Label_Respond As Boolean
    Public SenderUdp As New UdpClient(17777)
   
        
    Public Sub Load_Question_In_Form(ByVal Queston_To_Be_Shown As Question)
        Question_Shown = Queston_To_Be_Shown

        If (Question_Shown.Is_MCQ) Then
            If (Question_Shown.Is_Arrangement_Question) Or (Question_Shown.Is_Rapid_Question) Then
                'MCQ.Arrangement_Question_Box.BringToFront()
                MCQ.MCQ_Box.Visible = False
                MCQ.Arrangement_Question_Box.Visible = True
                MCQ.Clock.Visible = True
                MCQ.Clock.BringToFront()
                MCQ.Question_Text_Arrangement.Text = Question_Shown.Question_Text
                If (Question_Shown.Is_Rapid_Question) Then
                    MCQ.ArrangedList.Visible = False
                    MCQ.Label11.Visible = False
                    MCQ.List_Up_Button.Visible = False
                    MCQ.List_Down_Button.Visible = False
                    MCQ.Submit_Arrange_Button.Visible = False
                    MCQ.Submit_Arrange_Button.Enabled = False
                Else
                    MCQ.ArrangedList.Visible = True
                    MCQ.Label11.Visible = True
                    MCQ.List_Up_Button.Visible = True
                    MCQ.List_Down_Button.Visible = True
                    MCQ.Submit_Arrange_Button.Visible = True
                    MCQ.Submit_Arrange_Button.Enabled = False
                End If
                MCQ.OptionA_Arrangement.Text = "A. " + Question_Shown.OptionA
                MCQ.OptionB_Arrangement.Text = "B. " + Question_Shown.OptionB
                MCQ.OptionC_Arrangement.Text = "C. " + Question_Shown.OptionC
                MCQ.OptionD_Arrangement.Text = "D. " + Question_Shown.OptionD
            Else
                MCQ.MCQ_Box.BringToFront()
                MCQ.Arrangement_Question_Box.Visible = False
                MCQ.Clock.Visible = True
                MCQ.Clock.BringToFront()
                MCQ.Question_Text_Label.Text = Question_Shown.Question_Text
                MCQ.OptionA.Text = "A. " + Question_Shown.OptionA
                MCQ.OptionB.Text = "B. " + Question_Shown.OptionB
                MCQ.OptionC.Text = "C. " + Question_Shown.OptionC
                MCQ.OptionD.Text = "D. " + Question_Shown.OptionD
            End If
            Option_Label_Respond = True
        Else
            MCQ.MCQ_Box.BringToFront()
            MCQ.Arrangement_Question_Box.Visible = False
            MCQ.Clock.Visible = True
            MCQ.Clock.BringToFront()
            MCQ.Arrangement_Question_Box.Visible = False
            MCQ.Question_Text_Label.Text = Question_Shown.Question_Text
            MCQ.OptionA.Text = " "
            MCQ.OptionB.Text = " "
            MCQ.OptionC.Text = " "
            MCQ.OptionD.Text = " "
            Option_Label_Respond = False
            MCQ.Leave_Button.Text = "Start Answering"
        End If
        MCQ.Hint_Button.Visible = Question_Shown.Is_Having_Hints

        MCQ.SuperXcel_Picture_Box.Visible = False
        MCQ.Superxcel_Button.Visible = Question_Shown.Is_Having_SuperXcel
        If (Question_Shown.Is_Having_Hints) Then
            Current_Hint_Index = 0
        End If
        If (Question_Shown.Time_Seconds > 0) Then
            If (Question_Shown.Time_Seconds > 60) Then
                MCQ.Label5.Text = (Question_Shown.Time_Seconds / 60).ToString + " Min. " + (Question_Shown.Time_Seconds - (Question_Shown.Time_Seconds / 60) * 60).ToString + " Sec."
            Else
                MCQ.Label5.Text = Question_Shown.Time_Seconds.ToString + " Sec."
            End If
            Question_Start_Time = Now()
            MCQ.Timer1.Enabled = True
            MCQ.Timer1.Interval = 1000
            MCQ.Label4.Text = MCQ.Label5.Text
            MCQ.ProgressBar1.Maximum = Question_Shown.Time_Seconds
            MCQ.ProgressBar1.Value = Question_Shown.Time_Seconds
        Else
            MCQ.Clock.Visible = False
        End If
        If (Question_Shown.Question_Image = "") Then
        Else
            MCQ.Question_Image_Box.BackgroundImage = Image.FromFile(Question_Shown.Question_Image)
            MCQ.Question_Image_Box.BackgroundImageLayout = ImageLayout.Stretch
        End If
        MCQ.Team_Indicator.Text = "Question For " + This_Team.Name

        MCQ.Show()

    End Sub

    Public Function Question_String_For_Send(ByVal Quest As Question) As String
        Question_String_For_Send = Quest.Question_Text + "--\\--"
        If (Quest.Is_MCQ) Then
            If (Quest.Is_Arrangement_Question) Then
                Question_String_For_Send = Question_String_For_Send + "1" + "--\\--" + "1" + "--\\--" + Quest.OptionA + "--\\--" + Quest.OptionB + "--\\--" + Quest.OptionC + "--\\--" + Quest.OptionD + "--\\--"
            Else
                Question_String_For_Send = Question_String_For_Send + "1" + "--\\--" + "0" + "--\\--" + Quest.OptionA + "--\\--" + Quest.OptionB + "--\\--" + Quest.OptionC + "--\\--" + Quest.OptionD + "--\\--"
            End If
        Else
            Question_String_For_Send = Question_String_For_Send + "0" + "--\\--" + "0" + "--\\--" + " " + "--\\--" + " " + "--\\--" + " " + "--\\--" + " " + "--\\--"
        End If
        If (Quest.Is_Having_Hints) Then
            Question_String_For_Send = Question_String_For_Send + "1" + "--\\--"

        Else
            Question_String_For_Send = Question_String_For_Send + "0" + "--\\--"
        End If
        If Quest.Is_Having_SuperXcel Then
            Question_String_For_Send = Question_String_For_Send + "1" + "--\\--"
        Else
            Question_String_For_Send = Question_String_For_Send + "0" + "--\\--"
        End If
        Question_String_For_Send = Question_String_For_Send + Str(Quest.Time_Seconds) + "--\\--"
        Question_String_For_Send = Question_String_For_Send + Quest.Question_Image.ToString
    End Function
    Public Sub Send_To_Client(ByVal Send_Str As String, ByVal Data_Type As String)
        Select Case Data_Type
            Case "Q"
                Send_Str = "?" + "--\\--" + Send_Str
            Case "Question"
                Send_Str = "?" + "--\\--" + Send_Str
            Case "I"
                Send_Str = "!" + "--\\--" + Send_Str
            Case "Information"
                Send_Str = "!" + "--\\--" + Send_Str
        End Select
        'Send to Client by UDp 
    End Sub
    'Client Side Send
    Public Sub Send_To_Server(ByVal send_str As String, ByVal Data_Type As String)
        Select Case Data_Type
            Case "A"
                send_str = "~" + "--\\--" + send_str
            Case "Answer"
                send_str = "~" + "--\\--" + send_str
            Case "I"
                send_str = "!" + "--\\--" + send_str
            Case "Information"
                send_str = "!" + "--\\--" + send_str
        End Select
        'Send to Server

        Dim broadcast As IPAddress = IPAddress.Parse(Quiz_Server.IPAdress)
        Dim sendbuf As Byte() = Encoding.ASCII.GetBytes(send_str)
        Dim ep As New IPEndPoint(broadcast, 7777) '7777
        Try
            SenderUdp.Send(sendbuf, sendbuf.Length, ep)
        Finally
        End Try
        '.SendTo(sendbuf, ep)
    End Sub


    Public Sub Elastic_Resize_To_Full_Screen3(ByVal g As Form)
        Dim FinalRatio As Ratio
        FinalRatio.Wratio = g.ClientRectangle.Width
        FinalRatio.Hratio = g.ClientRectangle.Height
        'MsgBox(g.ClientRectangle.ToString)
        Dim screenarea As Rectangle
        screenarea = Screen.PrimaryScreen.Bounds
        'MsgBox(screenarea.ToString)
        g.Height = screenarea.Height
        g.Width = screenarea.Width
        g.Top = 0
        g.Left = 0
        'MsgBox(g.ClientRectangle.ToString)
        FinalRatio.Wratio = g.ClientRectangle.Width / FinalRatio.Wratio
        FinalRatio.Hratio = g.ClientRectangle.Height / FinalRatio.Hratio
        Dim control1 As Object
        For Each control1 In g.Controls
            control1.left = control1.Left * FinalRatio.Wratio
            control1.Top = control1.Top * FinalRatio.Hratio
            control1.Width = control1.Width * FinalRatio.Wratio
            control1.Height = control1.Height * FinalRatio.Hratio
            If (control1.Controls.Count > 0) Then
                Dim control2 As Object
                For Each control2 In control1.Controls
                    control2.Left = control2.Left * FinalRatio.Wratio
                    control2.Top = control2.Top * FinalRatio.Hratio
                    control2.Width = control2.Width * FinalRatio.Wratio
                    control2.Height = control2.Height * FinalRatio.Hratio
                    If (control2.Controls.Count > 0) Then
                        Dim control3 As Object
                        For Each control3 In control2.Controls
                            control3.Left = control3.Left * FinalRatio.Wratio
                            control3.Top = control3.Top * FinalRatio.Hratio
                            control3.Width = control3.Width * FinalRatio.Wratio
                            control3.Height = control3.Height * FinalRatio.Hratio
                            If (control3.Controls.Count > 0) Then
                                Dim control4 As Object
                                For Each control4 In control3.Controls
                                    control4.Left = control4.Left * FinalRatio.Wratio
                                    control4.Top = control4.Top * FinalRatio.Hratio
                                    control4.Width = control4.Width * FinalRatio.Wratio
                                    control4.Height = control4.Height * FinalRatio.Hratio
                                    If (control4.Controls.Count > 0) Then
                                        Dim control5 As Object
                                        For Each control5 In control4.Controls
                                            control5.Left = control5.Left * FinalRatio.Wratio
                                            control5.Top = control5.Top * FinalRatio.Hratio
                                            control5.Width = control5.Width * FinalRatio.Wratio
                                            control5.Height = control5.Height * FinalRatio.Hratio
                                            If (control5.Controls.Count > 0) Then
                                                Dim control6 As Object
                                                For Each control6 In control5.Controls
                                                    control6.Left = control6.Left * FinalRatio.Wratio
                                                    control6.Top = control6.Top * FinalRatio.Hratio
                                                    control6.Width = control6.Width * FinalRatio.Wratio
                                                    control6.Height = control6.Height * FinalRatio.Hratio
                                                Next
                                            End If
                                        Next
                                    End If
                                Next
                            End If
                        Next
                    End If
                Next
            End If
        Next
    End Sub

End Module