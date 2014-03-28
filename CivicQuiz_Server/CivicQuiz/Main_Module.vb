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
        'To add Answer image support
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

    Public Structure Round
        Public Round_Name As String
        Public Round_Rule_File As String
        Public Round_Image_File As String
        Public Roud_Type As String '"Multi_Select" or "Multi" or "Mono" or "Public"
        Public Max_Points As Integer
        Public Wrong_Points As Integer
    End Structure

    Public Structure Quiz_Part
        Public Part_Name As String
        Public Num_Of_Round As Integer
        Public Rounds() As Round
    End Structure
    Public Is_Question_Shown As Boolean = False
    Public Quiz_Parts(2) As Quiz_Part
    Public Current_Quiz_Part_Index As Integer = 0
    Public Current_Round_Part_Index As Integer = 0
    Public Current_Round_Index As Integer
    Public Current_Team_Index As Integer
    Public Current_Audience_Question_Index As Integer = 0
    Public Num_Of_Team As Integer = 4
    Public Teams(Num_Of_Team) As Team
    Public Game_Score(Num_Of_Team, 4, 4) As Integer
    Public Selection_Round_Shown As Boolean
    Public Is_Answer_Needed As Boolean
    Public Is_Second_Part_In_Progress As Boolean
    Public Is_To_Show_Final_Score As Boolean
    Public Quiz_Server As Team
    Public SenderUdp As New UdpClient(7777)


    Public Question_Shown As Question
    'Questions
    Public Sel_Sub_Questions(8, 2) As Question
    Public Our_Question(8) As Question
    Public Expert_Question(4) As Question
    Public Arrange_Question(4) As Question
    Public Audience_Question(8) As Question




    Public Num_Of_Team_Answered As Integer
    Public Option_Label_Respond As Boolean

    Public Sub Initiate_Quiz()
        Selection_Round_Shown = False
        Is_Answer_Needed = False
        Is_Second_Part_In_Progress = False

        Set_Quiz_Parts()
    End Sub
    Public Sub Initialize_Quiz_Part()
        Current_Round_Index = 0

    End Sub
    Public Sub Initialize_Round()
        Current_Round_Part_Index = 0
        Current_Team_Index = 0
    End Sub
    Public Sub Set_Quiz_Parts()
        Insert_Question()
        Quiz_Parts(0).Part_Name = "Qualifying Round"
        Quiz_Parts(0).Num_Of_Round = 1
        ReDim Quiz_Parts(0).Rounds(1)
        Quiz_Parts(0).Rounds(0).Roud_Type = "Public"
        Quiz_Parts(0).Rounds(0).Round_Image_File = ""
        Quiz_Parts(0).Rounds(0).Round_Name = "Qualifying Round"
        Quiz_Parts(0).Rounds(0).Round_Rule_File = "Test.rtf"

        Quiz_Parts(1).Part_Name = "Main Quiz"
        Quiz_Parts(1).Num_Of_Round = 4
        ReDim Quiz_Parts(1).Rounds(4)
        Quiz_Parts(1).Rounds(0).Roud_Type = "Multi-Select"
        Quiz_Parts(1).Rounds(0).Round_Image_File = "U_R_Boss.jpg"
        Quiz_Parts(1).Rounds(0).Round_Name = "Choose A Pick"
        Quiz_Parts(1).Rounds(0).Round_Rule_File = "Round 1.rtf"
        Quiz_Parts(1).Rounds(0).Max_Points = 20
        Quiz_Parts(1).Rounds(0).Wrong_Points = -5

        Quiz_Parts(1).Rounds(1).Roud_Type = "Multi"
        Quiz_Parts(1).Rounds(1).Round_Image_File = "Let_Me_Know.jpg"
        Quiz_Parts(1).Rounds(1).Round_Name = "Let Me Know"
        Quiz_Parts(1).Rounds(1).Round_Rule_File = "Round 2.rtf"
        Quiz_Parts(1).Rounds(1).Max_Points = 20
        Quiz_Parts(1).Rounds(1).Wrong_Points = -5

        Quiz_Parts(1).Rounds(2).Roud_Type = "Mono"
        Quiz_Parts(1).Rounds(2).Round_Image_File = "Expert_Question.jpg"
        Quiz_Parts(1).Rounds(2).Round_Name = "Expert Question"
        Quiz_Parts(1).Rounds(2).Round_Rule_File = "Round 3.rtf"

        Quiz_Parts(1).Rounds(3).Roud_Type = "Multi-Select"
        Quiz_Parts(1).Rounds(3).Round_Image_File = "Arrange_Question.jpg"
        Quiz_Parts(1).Rounds(3).Round_Name = "Sorting Mesh"
        Quiz_Parts(1).Rounds(3).Round_Rule_File = "Round 4.rtf"
        Quiz_Parts(1).Rounds(3).Max_Points = 20
        Quiz_Parts(1).Rounds(3).Wrong_Points = 0

        Initialize_Quiz_Part()
        'Redirection
        'Current_Round_Index = 3
        'Current_Quiz_Part_Index = 1
        'Is_Second_Part_In_Progress = True
        'Selection_Round_Shown = True

        Is_To_Show_Final_Score = False
        Run_Quiz()
    End Sub

    Public Sub Run_Quiz()
        Initialize_Round()
        If (Current_Quiz_Part_Index = 1) Then
            Round_Welcome.Show()
            If (Current_Round_Index > 0) Then
                If Is_Second_Part_In_Progress = False Then
                    Client_Info.Show()
                    Is_Second_Part_In_Progress = True
                End If
            End If
        Else
            'Quiz_Entry.Show()
        End If
    End Sub

    Public Sub Load_Question_In_Form(ByVal Queston_To_Be_Shown As Question)

        Question_Shown = Queston_To_Be_Shown
        Num_Of_Team_Answered = 0

        If Current_Round_Index = 3 Then
            Dim i As Integer
            For i = 0 To 3
                Send_To_Client("DEACTIVATE", "I", Teams(i))
                'Send_To_Client(Question_String_For_Send(Question_Shown), "Q", Teams(i))
            Next
            For i = 0 To 3
                'Send_To_Client("DEACTIVATE", "I", Teams(i))
                Send_To_Client(Question_String_For_Send(Question_Shown), "Q", Teams(i))
            Next
        Else
            Send_To_Client("DEACTIVATE", "I", Teams(Current_Team_Index))
            Send_To_Client(Question_String_For_Send(Question_Shown), "Q", Teams(Current_Team_Index))
        End If


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
        MCQ.Current_Hint_Index = 0
        If (Question_Shown.Time_Seconds > 0) Then
            If (Question_Shown.Time_Seconds > 60) Then
                MCQ.Label5.Text = (Question_Shown.Time_Seconds / 60).ToString + " Min. " + (Question_Shown.Time_Seconds - (Question_Shown.Time_Seconds / 60) * 60).ToString + " Sec."
            Else
                MCQ.Label5.Text = Question_Shown.Time_Seconds.ToString + " Sec."
            End If
            MCQ.Question_Start_Time = Now()
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
        MCQ.Team_Indicator.Text = "Question For " + Teams(Current_Team_Index).Name
        Is_Question_Shown = True
        MCQ.Show()
    End Sub
    Public Sub Load_Audience_Question()
        Audience_Question_Form.Question_Text_Label.Text = Audience_Question(Current_Audience_Question_Index).Question_Text
        'Audience_Question_Form.OptionA.Text = "A. " + Audience_Question(Current_Audience_Question_Index).OptionA
        'Audience_Question_Form.OptionB.Text = "B. " + Audience_Question(Current_Audience_Question_Index).OptionB
        'Audience_Question_Form.OptionC.Text = "C. " + Audience_Question(Current_Audience_Question_Index).OptionC
        'Audience_Question_Form.OptionD.Text = "D. " + Audience_Question(Current_Audience_Question_Index).OptionD
        If Not (Audience_Question(Current_Audience_Question_Index).Question_Image = "") Then
            Audience_Question_Form.Question_Image_Box.BackgroundImage = Image.FromFile(Audience_Question(Current_Audience_Question_Index).Question_Image)
            Audience_Question_Form.Question_Image_Box.BackgroundImageLayout = ImageLayout.Stretch
        End If
        
        Audience_Question_Form.Show()

    End Sub

    Public Sub Show_Overloaded_Information(ByVal title As String, ByVal Label_Text As String, ByVal RTF_File As String, ByVal Button_Text As String)
        Information_Form.Text = title
        Information_Form.Label1.Text = Label_Text
        Information_Form.RichTextBox1.LoadFile(RTF_File)
        Information_Form.Button1.Text = Button_Text
        Information_Form.Show()
    End Sub
    Public Sub Show_Default_Information()
        Information_Form.Text = Quiz_Parts(Current_Quiz_Part_Index).Rounds(Current_Round_Index).Round_Name + " : Introduction"
        Information_Form.Label1.Text = "Rules for " + Quiz_Parts(Current_Quiz_Part_Index).Rounds(Current_Round_Index).Round_Name + " round :-"
        Information_Form.RichTextBox1.LoadFile(Quiz_Parts(Current_Quiz_Part_Index).Rounds(Current_Round_Index).Round_Rule_File)
        Information_Form.Button1.Text = "Play &Round"
        Information_Form.Show()
    End Sub
    Public Function Question_String_For_Send(ByVal Quest As Question) As String
        Dim Temp_Question_String_For_Send As String = Quest.Question_Text + "--\\--"
        If (Quest.Is_MCQ) Then
            If (Quest.Is_Arrangement_Question) Then
                Temp_Question_String_For_Send = Temp_Question_String_For_Send + "1" + "--\\--" + "1" + "--\\--" + Quest.OptionA + "--\\--" + Quest.OptionB + "--\\--" + Quest.OptionC + "--\\--" + Quest.OptionD + "--\\--"
            Else
                Temp_Question_String_For_Send = Temp_Question_String_For_Send + "1" + "--\\--" + "0" + "--\\--" + Quest.OptionA + "--\\--" + Quest.OptionB + "--\\--" + Quest.OptionC + "--\\--" + Quest.OptionD + "--\\--"
            End If
        Else
            Temp_Question_String_For_Send = Temp_Question_String_For_Send + "0" + "--\\--" + "0" + "--\\--" + " " + "--\\--" + " " + "--\\--" + " " + "--\\--" + " " + "--\\--"
        End If
        If (Quest.Is_Having_Hints) Then
            Temp_Question_String_For_Send = Temp_Question_String_For_Send + "1" + "--\\--"

        Else
            Temp_Question_String_For_Send = Temp_Question_String_For_Send + "0" + "--\\--"
        End If
        If Quest.Is_Having_SuperXcel Then
            Temp_Question_String_For_Send = Temp_Question_String_For_Send + "1" + "--\\--"
        Else
            Temp_Question_String_For_Send = Temp_Question_String_For_Send + "0" + "--\\--"
        End If
        Temp_Question_String_For_Send = Temp_Question_String_For_Send + Str(Quest.Time_Seconds) + "--\\--"
        Temp_Question_String_For_Send = Temp_Question_String_For_Send + Quest.Question_Image.ToString
        Question_String_For_Send = Temp_Question_String_For_Send
    End Function
    Public Sub Send_To_Client(ByVal Send_Str As String, ByVal Data_Type As String, ByVal Receiving_Team As Team)
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
        Dim broadcast As IPAddress = IPAddress.Parse(Receiving_Team.IPAdress)
        Dim sendbuf As Byte() = Encoding.ASCII.GetBytes(Send_Str)
        Dim ep As New IPEndPoint(broadcast, 17777)
        Try
            SenderUdp.Send(sendbuf, sendbuf.Length, ep)  '17777
        Finally
        End Try
        'Send to Client by UDp 
    End Sub
    'Client Side Send
    Public Sub Send_To_Server(ByVal send_str As String, ByVal Data_Type As String)
        Select Case Data_Type
            Case "A" Or "Answer"
                send_str = "~" + "--\\--" + send_str
            Case "I" Or "Information"
                send_str = "!" + "--\\--" + send_str
        End Select


        
        'Send to Server

    End Sub
    Public Sub Elastic_Resize_To_Full_Screen(ByVal g As Form)
        Dim i As Integer
        Dim Moverarry() As Ratio
        ReDim Moverarry(g.Controls.Count - 1)
        Dim Form_Client_Area As Rectangle
        Form_Client_Area = g.ClientRectangle
        MsgBox(Form_Client_Area.ToString)
        For i = 0 To g.Controls.Count - 1 Step 1
            'If TypeOf g.Controls(i) Is Timer Then
            'Else
            Moverarry(i).Wratio = g.Controls(i).Width / Form_Client_Area.Width
            Moverarry(i).Hratio = g.Controls(i).Height / Form_Client_Area.Height
            Moverarry(i).Lratio = g.Controls(i).Left / Form_Client_Area.Width
            Moverarry(i).Tratio = g.Controls(i).Top / Form_Client_Area.Height
            'End If
        Next i
        Dim screenarea As Rectangle
        screenarea = Screen.PrimaryScreen.Bounds
        MsgBox(screenarea.ToString)
        g.Height = screenarea.Height
        g.Width = screenarea.Width
        g.Top = 0
        g.Left = 0
        Form_Client_Area = g.ClientRectangle
        MsgBox(Form_Client_Area.ToString)
        For i = 0 To g.Controls.Count - 1 Step 1
            'If TypeOf g.Controls(i) Is Timer Then
            'Else
            On Error Resume Next
            g.Controls(i).Left = Moverarry(i).Lratio * Form_Client_Area.Width
            g.Controls(i).Top = Moverarry(i).Tratio * Form_Client_Area.Height
            g.Controls(i).Width = Moverarry(i).Wratio * Form_Client_Area.Width
            g.Controls(i).Height = Moverarry(i).Hratio * Form_Client_Area.Height
            'g.Controls(i).Move(Moverarry(i).Lratio * Form_Client_Area.Width, Moverarry(i).Tratio * Form_Client_Area.Height, Moverarry(i).Wratio * Form_Client_Area.Width, Moverarry(i).Hratio * Form_Client_Area.Height)
            'End If
        Next i
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


    Public Sub Insert_Question()
        For i = 0 To 7
            For j = 0 To 1
                Sel_Sub_Questions(i, j).Is_MCQ = True
                Sel_Sub_Questions(i, j).Is_Rapid_Question = False
                Sel_Sub_Questions(i, j).Is_Arrangement_Question = False
                Sel_Sub_Questions(i, j).Is_Having_Hints = False
                Sel_Sub_Questions(i, j).Num_of_Hint = 0
                Sel_Sub_Questions(i, j).Is_Having_SuperXcel = True
                Sel_Sub_Questions(i, j).Question_Image = ""
                Sel_Sub_Questions(i, j).Time_Seconds = 30

            Next
        Next

        For i = 0 To 7
            Our_Question(i).Is_MCQ = True
            Our_Question(i).Is_Arrangement_Question = False
            Our_Question(i).Is_Rapid_Question = False
            Our_Question(i).Is_Having_Hints = True
            Our_Question(i).Num_of_Hint = 2
            ReDim Our_Question(i).Hints(Our_Question(i).Num_of_Hint)
            Our_Question(i).Is_Having_SuperXcel = True
            Our_Question(i).Question_Image = ""
            Our_Question(i).Time_Seconds = 45
        Next

        For i = 0 To 3
            Expert_Question(i).Is_MCQ = False
            Expert_Question(i).Is_Rapid_Question = False
            Expert_Question(i).Is_Arrangement_Question = False
            Expert_Question(i).OptionA = ""
            Expert_Question(i).OptionB = ""
            Expert_Question(i).OptionC = ""
            Expert_Question(i).OptionD = ""
            Expert_Question(i).Is_Having_Hints = False
            Expert_Question(1).Num_of_Hint = 0
            Expert_Question(i).Is_Having_SuperXcel = False
            Expert_Question(i).Question_Image = ""
            Expert_Question(i).Time_Seconds = 120

            Arrange_Question(i).Is_MCQ = True
            Arrange_Question(i).Is_Arrangement_Question = True
            Arrange_Question(i).Is_Rapid_Question = False
            Arrange_Question(i).Is_Having_Hints = False
            Arrange_Question(i).Num_of_Hint = 0
            Arrange_Question(i).Is_Having_SuperXcel = False
            Arrange_Question(i).Question_Image = ""
            Arrange_Question(i).Time_Seconds = 60
        Next
        Sel_Sub_Questions(0, 0).Question_Text = "You have just entered a building. Before you arived, a stranger told you about an incredible sculpture in the fastigiun. Where should you look in order to see this sculpture?"
        Sel_Sub_Questions(0, 0).OptionA = "I will look left."
        Sel_Sub_Questions(0, 0).OptionB = "I will look up."
        Sel_Sub_Questions(0, 0).OptionC = "I will look right."
        Sel_Sub_Questions(0, 0).OptionD = "I will look into the corner."
        Sel_Sub_Questions(0, 0).Answer = "I will look up."
        Sel_Sub_Questions(0, 0).Show_Answer = "B. I will look up."

        Sel_Sub_Questions(0, 1).Question_Text = "What is Ashlar ?"
        Sel_Sub_Questions(0, 1).OptionA = "Vaulted semicircular or polygonal end of a chancel or chapel."
        Sel_Sub_Questions(0, 1).OptionB = "Small top storey within a roof."
        Sel_Sub_Questions(0, 1).OptionC = "A small parapet or attic wall bearing the weight of the roof"
        Sel_Sub_Questions(0, 1).OptionD = "Masonry of large blocks cut with even faces and square edges."
        Sel_Sub_Questions(0, 1).Answer = "Masonry of large blocks cut with even faces and square edges."
        Sel_Sub_Questions(0, 1).Show_Answer = "D. Masonry of large blocks cut with even faces and square edges."

        Sel_Sub_Questions(1, 0).Question_Text = "Toughness of a material is equal to area under ____________ part of the stress-strain curve."
        Sel_Sub_Questions(1, 0).OptionA = "Elastic"
        Sel_Sub_Questions(1, 0).OptionB = "Plastic"
        Sel_Sub_Questions(1, 0).OptionC = "Both"
        Sel_Sub_Questions(1, 0).OptionD = "None It is not related to stress-strain curve"
        Sel_Sub_Questions(1, 0).Answer = "Both"
        Sel_Sub_Questions(1, 0).Show_Answer = "C. Both, Elastic and Plastic region of stress-strain curve contribute to toughness"

        Sel_Sub_Questions(1, 1).Question_Text = "The vertical Distance of a point above mean sea level is known as its:"
        Sel_Sub_Questions(1, 1).OptionA = "Level"
        Sel_Sub_Questions(1, 1).OptionB = "Altitude"
        Sel_Sub_Questions(1, 1).OptionC = "Datum"
        Sel_Sub_Questions(1, 1).OptionD = "Elevation"
        Sel_Sub_Questions(1, 1).Answer = "Elevation"
        Sel_Sub_Questions(1, 1).Show_Answer = "D. Elevation"


        Sel_Sub_Questions(2, 0).Question_Text = "What was originally called the 'imitation game' by its creator?"
        Sel_Sub_Questions(2, 0).OptionA = "LISP"
        Sel_Sub_Questions(2, 0).OptionB = "The Turing Test"
        Sel_Sub_Questions(2, 0).OptionC = "The Logic Theorist"
        Sel_Sub_Questions(2, 0).OptionD = "Cybernetics"
        Sel_Sub_Questions(2, 0).Answer = "The Turing Test"
        Sel_Sub_Questions(2, 0).Show_Answer = "B. The Turing Test"



        Sel_Sub_Questions(2, 1).Question_Text = "Which of the following is not a built-in libary of JavaScript (Web Scripting Language)?"
        Sel_Sub_Questions(2, 1).OptionA = "script.aculo.us"
        Sel_Sub_Questions(2, 1).OptionB = "Prototype"
        Sel_Sub_Questions(2, 1).OptionC = "Construct"
        Sel_Sub_Questions(2, 1).OptionD = "MooTools"
        Sel_Sub_Questions(2, 1).Answer = "Construct"
        Sel_Sub_Questions(2, 1).Show_Answer = "C. Construct, It is a built-in library of python."


        Sel_Sub_Questions(3, 0).Question_Text = "Which of the following ratings appear(s) in the specification sheet for an FET?"
        Sel_Sub_Questions(3, 0).OptionA = "Voltages between specific terminals"
        Sel_Sub_Questions(3, 0).OptionB = "Current Level"
        Sel_Sub_Questions(3, 0).OptionC = "Power Dissipation"
        Sel_Sub_Questions(3, 0).OptionD = "All of the Above"
        Sel_Sub_Questions(3, 0).Answer = "All of the Above"
        Sel_Sub_Questions(3, 0).Show_Answer = "D. All of the Above"


        Sel_Sub_Questions(3, 1).Question_Text = "A demultiplexer has ________."
        Sel_Sub_Questions(3, 1).OptionA = "one data input and a number of selection inputs, and they have several outputs"
        Sel_Sub_Questions(3, 1).OptionB = "one input and one output"
        Sel_Sub_Questions(3, 1).OptionC = "several inputs and several outputs"
        Sel_Sub_Questions(3, 1).OptionD = "several inputs and one output"
        Sel_Sub_Questions(3, 1).Answer = "one data input and a number of selection inputs, and they have several outputs"
        Sel_Sub_Questions(3, 1).Show_Answer = "A. one data input and a number of selection inputs, and they have several outputs"


        Sel_Sub_Questions(4, 0).Question_Text = "In a Y-Y source/load configuration, the"
        Sel_Sub_Questions(4, 0).OptionA = "phase current, the line current, and the load current are all equal in each phase"
        Sel_Sub_Questions(4, 0).OptionB = "phase current, the line current, and the load current are 120° out of phase"
        Sel_Sub_Questions(4, 0).OptionC = "phase current and the line current are in phase, and both are 120° out of phase with the load current"
        Sel_Sub_Questions(4, 0).OptionD = "line current and the load current are in phase, and both are out of phase with the phase current"
        Sel_Sub_Questions(4, 0).Answer = "phase current, the line current, and the load current are all equal in each phase"
        Sel_Sub_Questions(4, 0).Show_Answer = "A. phase current, the line current, and the load current are all equal in each phase"


        Sel_Sub_Questions(4, 1).Question_Text = "If the capacitor in an integrator becomes leaky, then"
        Sel_Sub_Questions(4, 1).OptionA = "The time constant will be effectively reduced"
        Sel_Sub_Questions(4, 1).OptionB = "The waveshape of the output voltage across C is altered"
        Sel_Sub_Questions(4, 1).OptionC = "The amplitude of the output is reduced"
        Sel_Sub_Questions(4, 1).OptionD = "All of the above"
        Sel_Sub_Questions(4, 1).Answer = "All of the above"
        Sel_Sub_Questions(4, 1).Show_Answer = "D. All of the above"


        Sel_Sub_Questions(5, 0).Question_Text = "Spheroidal Grephite Iron has"
        Sel_Sub_Questions(5, 0).OptionA = "High Machinability"
        Sel_Sub_Questions(5, 0).OptionB = "Low Melting Point"
        Sel_Sub_Questions(5, 0).OptionC = "Low Tensile Strength"
        Sel_Sub_Questions(5, 0).OptionD = "Both A and B"
        Sel_Sub_Questions(5, 0).Answer = "Both A and B"
        Sel_Sub_Questions(5, 0).Show_Answer = "D. Both A and B"


        Sel_Sub_Questions(5, 1).Question_Text = "Tooth interference in an external involute spur gear pair can be reduced by"
        Sel_Sub_Questions(5, 1).OptionA = "Decreasing center distance between gear pair"
        Sel_Sub_Questions(5, 1).OptionB = "Decreasing Module"
        Sel_Sub_Questions(5, 1).OptionC = "Increasing Number Of Gear Teeth"
        Sel_Sub_Questions(5, 1).OptionD = "Decreasing Pressure Angle"
        Sel_Sub_Questions(5, 1).Answer = "Increasing Number Of Gear Teeth"
        Sel_Sub_Questions(5, 1).Show_Answer = "C. Increasing Number Of Gear Teeth"


        Sel_Sub_Questions(6, 0).Question_Text = "The failure of material due to repeated stresses acting on it is called:"
        Sel_Sub_Questions(6, 0).OptionA = "Creep"
        Sel_Sub_Questions(6, 0).OptionB = "Fatigue"
        Sel_Sub_Questions(6, 0).OptionC = "Fracture"
        Sel_Sub_Questions(6, 0).OptionD = "Brittle Failure"
        Sel_Sub_Questions(6, 0).Answer = "Fatigue"
        Sel_Sub_Questions(6, 0).Show_Answer = "B. Fatigue"


        Sel_Sub_Questions(6, 1).Question_Text = "The resistor identified in brown is called?"
        Sel_Sub_Questions(6, 1).OptionA = "Load Resistor"
        Sel_Sub_Questions(6, 1).OptionB = "Base Bias Resistor"
        Sel_Sub_Questions(6, 1).OptionC = "Emitter Feedback Resistor"
        Sel_Sub_Questions(6, 1).OptionD = "Bypass Resistor"
        Sel_Sub_Questions(6, 1).Answer = "Load Resistor"
        Sel_Sub_Questions(6, 1).Show_Answer = "A. Load Resistor"
        Sel_Sub_Questions(6, 1).Question_Image = "resist.jpg"


        Sel_Sub_Questions(7, 0).Question_Text = "Which of the following movie won oscar award for 'Best Animted Feature Film' in 2011."
        Sel_Sub_Questions(7, 0).OptionA = "Cars"
        Sel_Sub_Questions(7, 0).OptionB = "Up"
        Sel_Sub_Questions(7, 0).OptionC = "Beauty and the Beast"
        Sel_Sub_Questions(7, 0).OptionD = "Toy Story 3"
        Sel_Sub_Questions(7, 0).Answer = "Toy Story 3"
        Sel_Sub_Questions(7, 0).Show_Answer = "D. Toy Story 3"



        Sel_Sub_Questions(7, 1).Question_Text = "How many Padma Vibhushan Awards Awards were presented for the year 2011?"
        Sel_Sub_Questions(7, 1).OptionA = "8"
        Sel_Sub_Questions(7, 1).OptionB = "13"
        Sel_Sub_Questions(7, 1).OptionC = "18"
        Sel_Sub_Questions(7, 1).OptionD = "31"
        Sel_Sub_Questions(7, 1).Answer = "18"
        Sel_Sub_Questions(7, 1).Show_Answer = "B. 18"




        'Our Question




        Our_Question(0).Question_Text = "Corbett National Park is situated in?"
        Our_Question(0).OptionA = "Bastar (Chattisgarh)"
        Our_Question(0).OptionB = "Daltonganj (Jharkhand)"
        Our_Question(0).OptionC = "Nainital (Uttarakhand)"
        Our_Question(0).OptionD = "Jorhat (Assam)"
        Our_Question(0).Answer = "Nainital (Uttarakhand)"
        Our_Question(0).Show_Answer = "C. Nainital (Uttarakhand)"
        Our_Question(0).Hints(0) = "Corbett National Park is famous for it's successfull implementation of 'Tiger Project'."
        Our_Question(0).Hints(1) = "The Park is situated in a newly made State."

        Our_Question(1).Question_Text = "Whose Sign is there on One Rupee Note ?"
        Our_Question(1).OptionA = "Finance Minister of India"
        Our_Question(1).OptionB = "Governor Of RBI"
        Our_Question(1).OptionC = "Attorney General of India"
        Our_Question(1).OptionD = "Secretory, Ministry of Finance, India"
        Our_Question(1).Answer = "Secretory, Ministry of Finance, India"
        Our_Question(1).Show_Answer = "D. Secretory, Ministry of Finance, India"
        Our_Question(1).Hints(0) = "One Rupee Note Doesn't have Mahatma Gandhi Impression."
        Our_Question(1).Hints(1) = "This person don't sign on any of the currency note."


        Our_Question(2).Question_Text = "'Yellowcake', an item of smuggling is actually ?"
        Our_Question(2).OptionA = "A crude form of Heroin"
        Our_Question(2).OptionB = "A crude form of Cocaine"
        Our_Question(2).OptionC = "Uranium Oxide"
        Our_Question(2).OptionD = "Unrefined Gold"
        Our_Question(2).Answer = "Uranium Oxide"
        Our_Question(2).Show_Answer = "C. Uranium Oxide"
        Our_Question(2).Hints(0) = "It is a course yellow powder with pungent odor."
        Our_Question(2).Hints(1) = "It is insoluble in water and melt at 2878 C."


        Our_Question(3).Question_Text = "What are the official languages of the U.N.O ?"
        Our_Question(3).OptionA = "English, French and Russian"
        Our_Question(3).OptionB = "English, French, German and Russian"
        Our_Question(3).OptionC = "English, French, Russian, Chinese and Hindi"
        Our_Question(3).OptionD = "English, French, Russian, Chinese, Arabic and Spanish"
        Our_Question(3).Answer = "English, French, Russian, Chinese, Arabic and Spanish"
        Our_Question(3).Show_Answer = "D. English, French, Russian, Chinese, Arabic and Spanish"
        Our_Question(3).Hints(0) = "In one of these languages 'I Love You' is known as 'Te amo'."
        Our_Question(3).Hints(1) = "Largest countries are always given preference over other !"


        Our_Question(4).Question_Text = "According Indian railway reccomdation, What is the gauge distance for 'Broad gauge' "
        Our_Question(4).OptionA = "1767 mm"
        Our_Question(4).OptionB = "1676 mm"
        Our_Question(4).OptionC = "1647 mm"
        Our_Question(4).OptionD = "1000 mm"
        Our_Question(4).Answer = "1676 mm"
        Our_Question(4).Show_Answer = "B. 1676 mm"
        Our_Question(4).Hints(0) = "Gauge distance is the clear distance between the two parallel rails."
        Our_Question(4).Hints(1) = "It is the widely used Gaudge Distance in India."


        Our_Question(5).Question_Text = "Who among the following is not a recipient of the Bharat Ratna Award ?"
        Our_Question(5).OptionA = "Ustad Bismillah Khan"
        Our_Question(5).OptionB = "Satyajit Ray"
        Our_Question(5).OptionC = "Lata Mangeshkar"
        Our_Question(5).OptionD = "Raj Kapoor"
        Our_Question(5).Answer = "Raj Kapoor"
        Our_Question(5).Show_Answer = "D. Raj Kapoor"
        Our_Question(5).Hints(0) = "The person was not a instrumentalist"
        Our_Question(5).Hints(1) = "Showman of Indian Cinema"

        Our_Question(6).Question_Text = "What was official name of U.S. army operation in which Osama Bin Laden was killed ?"
        Our_Question(6).OptionA = "Operation Blue Heart"
        Our_Question(6).OptionB = "Operation Moolah"
        Our_Question(6).OptionC = "Operation Phoenix"
        Our_Question(6).OptionD = "Operation Neptune Spear"
        Our_Question(6).Answer = "Operation Neptune Spear"
        Our_Question(6).Show_Answer = "D. Operation Neptune Spear"
        Our_Question(6).Hints(0) = "Osama Bin Laben was killed in Abbottabad, Pakistan in a operation in which Pakistan was in dark."
        Our_Question(6).Hints(1) = "The name of operation is the trident, which appears on U.S. Navy Special Warfare insignia"


        Our_Question(7).Question_Text = "Recently Uttar Pradesh and Madhya Pradesh government signed a Memorandum of Understanding for the linking of two rivers as a link project.Which are these two rivers ?"
        Our_Question(7).OptionA = "Betwa and Chambal"
        Our_Question(7).OptionB = "Betwa and Ken"
        Our_Question(7).OptionC = "Chambal and son"
        Our_Question(7).OptionD = "Ken and Narmada"
        Our_Question(7).Answer = "Betwa and Ken"
        Our_Question(7).Show_Answer = "B. Betwa and Ken"
        Our_Question(7).Hints(0) = "These rivers do not flow towards west."
        Our_Question(7).Hints(1) = "Chambal is not included in this link."



        'ExpertQuestion
        Expert_Question(0).Question_Text = "In concrete pavement, keyway joint are sometimes adopted in longitudinal joint. Why?"
        Expert_Question(0).Question_Image = "q1.jpg"
        Expert_Question(1).Question_Text = "Does the use of concrete road enhance fuel saving when compared with bituminous road?"
        Expert_Question(2).Question_Text = "Why are steeply inclined soil nails not commonly used in stabilizing slopes?"
        Expert_Question(2).Question_Image = "q3.jpg"
        Expert_Question(3).Question_Text = "Why are dimples present in golf balls?"
        Expert_Question(3).Question_Image = "golf.jpg"

        'Arrange Question



        Arrange_Question(0).Question_Text = "Arrange the following players in accordance to their runs in ODI : (Highest First)"
        Arrange_Question(0).OptionA = "S.C. Ganguly"
        Arrange_Question(0).OptionB = "J.H. Kallis"
        Arrange_Question(0).OptionC = "S.T. Jayasuriya"
        Arrange_Question(0).OptionD = "R.T. Pointing"
        Arrange_Question(0).Answer = "R.T. PointingS.T. JayasuriyaJ.H. KallisS.C. Ganguly"
        Arrange_Question(0).Show_Answer = "R.T. Pointing ( Runs : 13704; Highest : 164; Match : 375 ; Avg.: 40.29)" + vbCrLf + "S.T. Jayasuriya ( Runs : 13430; Highest : 189; Match : 445 ; Avg.: 431.45)" + vbCrLf + "J.H. Kallis ( Runs : 11498; Highest : 139; Match : 321 ; Avg.: 42.9)" + vbCrLf + "S.C. Ganguly ( Runs : 11363; Highest : 183; Match : 311 ; Avg.: 39.45)"



        Arrange_Question(1).Question_Text = "Arrange the following events in timeline : (Ancient First)"
        Arrange_Question(1).OptionA = "Noble Prize Won by  Rabindra Nath Tagore in Literature"
        Arrange_Question(1).OptionB = "First Train (Locomotive) in India"
        Arrange_Question(1).OptionC = "Birth of Mahatma Gandhi"
        Arrange_Question(1).OptionD = "Rowlatt Act"
        Arrange_Question(1).Answer = "First Train (Locomotive) in IndiaBirth of Mahatma GandhiNoble Prize Won by  Rabindra Nath Tagore in LiteratureRowlatt Act"
        Arrange_Question(1).Show_Answer = "First Train (Locomotive ) in India (1853 , on 16th April at 3:35 pm from Bori Bunder to Thane ; Journey was of 1 hr and 15 mins )" + vbCrLf + "Birth of Mahatma Gandhi (1869)" + vbCrLf + "Noble Prize Won by  Rabindra Nath Tagore in Literature (1913)" + vbCrLf + "Rowlatt Act (1919)"


        Arrange_Question(2).Question_Text = "Arrange the following days in accordance they come in a year :"
        Arrange_Question(2).OptionA = "World AIDS Day"
        Arrange_Question(2).OptionB = "International Womens Day"
        Arrange_Question(2).OptionC = "Engineers Day"
        Arrange_Question(2).OptionD = "World Population Day"
        Arrange_Question(2).Answer = "International Womens DayWorld Population DayEngineers DayWorld AIDS Day"
        Arrange_Question(2).Show_Answer = "International Women’s Day (8th March)" + vbCrLf + "World Population Day (11th July)" + vbCrLf + "Engineers’ Day (15th Sept)" + vbCrLf + "World AIDS Day (1st Dec)"


        Arrange_Question(3).Question_Text = "Arrange the following cities from West to East in a political Map of India:"
        Arrange_Question(3).OptionA = "Indore"
        Arrange_Question(3).OptionB = "Delhi"
        Arrange_Question(3).OptionC = "Chandigarh"
        Arrange_Question(3).OptionD = "Agra"
        Arrange_Question(3).Answer = "IndoreChandigarhDelhiAgra"
        Arrange_Question(3).Show_Answer = "Indore" + vbCrLf + "Chandigarh" + vbCrLf + "Delhi" + vbCrLf + "Agra"



        'Audience Question
        Audience_Question(0).Question_Text = "'John Dawes' who recently became new bowling coach of Indian cricket Team belongs to which of the country ?"
        Audience_Question(0).Show_Answer = "Australia"

        Audience_Question(1).Question_Text = "The first ever world cup championship tournament for women's Kabaddi took place at which place ?"
        Audience_Question(1).Show_Answer = "Patna (Bihar)"

        Audience_Question(2).Question_Text = "Who won the Oscar 2011 for the 'Best Actor Award in Leading Role'?"
        Audience_Question(2).Show_Answer = "Jean Dujrandin,The Artist"

        Audience_Question(3).Question_Text = "In which country the first 'Arab Spring movement' had started ?"
        Audience_Question(3).Show_Answer = "Tunisia"

        Audience_Question(4).Question_Text = "Recently one of the Indian Railway's express train has achieved the distinction of being the first train to enter the 100th year if its run in Jan 2012.Name the train ?  (Hint : Train runs between Ferozpur and Mumbai)"
        Audience_Question(4).Show_Answer = "Punjab Mail"

        Audience_Question(5).Question_Text = "Which place is known as 'God's own country'?  (Hint : Its not a country !)"
        Audience_Question(5).Show_Answer = "Kerla"

        Audience_Question(6).Question_Text = "Legendry classical Music Maestro Bhimsen Joshi was the the leading exponent of which form of singing?   (hint : He passed away on Jan 24 2011)"
        Audience_Question(6).Show_Answer = "Khayal"

        Audience_Question(7).Question_Text = "Aishwarya Rai became Miss world in which year?"
        Audience_Question(7).Show_Answer = "1994"
    End Sub



End Module