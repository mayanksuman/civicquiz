Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Public Class Listener
    Public Event Data_Received(ByVal IP As String, ByVal T As String)
    Public Delegate Sub myDelegate(ByVal s As String, ByVal d As String)

    Private Sub RichTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RichTextBox1.TextChanged
        
    End Sub

    Private Sub Listener_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Listener_Thread As Threading.Thread
        Listener_Thread = New Threading.Thread(AddressOf Listener_Thread_Sub)
        Listener_Thread.Start()
        Me.Hide()

    End Sub
    Public Sub Listener_Thread_Sub()
        Dim listenPort As Integer = This_Team.Port

        Dim done As Boolean = False
        'Dim listener As New UdpClient(listenPort)
        Dim groupEP As New IPEndPoint(IPAddress.Parse(Quiz_Server.IPAdress), 17777)
        'Dim groupEP As New IPEndPoint(IPAddress.Any, listenPort)
        Try
            While Not done
                Dim bytes As Byte() = SenderUdp.Receive(groupEP)
                RaiseEvent Data_Received(groupEP.ToString(), Encoding.ASCII.GetString(bytes, 0, bytes.Length))
            End While
        Catch

        Finally

        End Try
    End Sub
    Sub Data_Received_Sub(ByVal ip As String, ByVal g As String) Handles Me.Data_Received
        Me.Invoke(New myDelegate(AddressOf ChangeRTB), New Object() {ip, g})
    End Sub
    Public Sub ChangeRTB(ByVal ipaddress As String, ByVal message As String)
        Dim str As String = message
        Dim Is_Question As Boolean = False   'False -INfo    True-Question
        Dim i As Integer = 1
        Dim count As Integer = 0
        Dim temp As String
        Dim increment As Integer = Strings.Len("--\\--")
        Dim j As Integer = InStr(i, str, "--\\--")
        Do While i > 0
            If (j = 0) Then
                temp = Mid(str, i)
                i = 0
            Else
                temp = Mid(str, i, j - i)
                i = j + increment
                j = InStr(i, str, "--\\--", )
            End If
            Select Case count
                Case 0
                    If (temp = "?") Then
                        'Questions
                        Is_Question = True
                    Else
                        Is_Question = False
                    End If
                Case 1
                    If (Is_Question) Then
                        Question_Shown.Question_Text = temp
                    Else
                        If temp = "CONNECTED" Then
                            Send_To_Server("TEAM_INFO_NEEDED", "I")
                        Else
                            If temp = "DEACTIVATE" Then
                                MCQ.Close()
                            Else
                                Dim a As Integer = InStr(temp, ":", )
                                If (a > 0) Then
                                    Dim temp_data As String = Mid(temp, a + 1)
                                    If (temp(0) = "H") Then
                                        If (temp_data = "") Then
                                            MsgBox("No More Hints", vbOKOnly, "No Hints")
                                        Else
                                            MCQ.Generate_Hint(temp_data)
                                        End If

                                    Else
                                        If (temp(0) = "T") Then
                                            This_Team.Name = temp_data
                                        End If
                                    End If
                                End If

                            End If
                        End If
                    End If
                Case 2
                    If (temp = "1") Then
                        Question_Shown.Is_MCQ = True
                    Else
                        Question_Shown.Is_MCQ = False
                    End If
                Case 3
                    If (temp = "1") Then
                        Question_Shown.Is_Arrangement_Question = True
                    Else
                        Question_Shown.Is_Arrangement_Question = False
                    End If
                Case 4
                    Question_Shown.OptionA = temp
                Case 5
                    Question_Shown.OptionB = temp
                Case 6
                    Question_Shown.OptionC = temp
                Case 7
                    Question_Shown.OptionD = temp
                Case 8
                    If (temp = "1") Then
                        Question_Shown.Is_Having_Hints = True
                        Question_Shown.Num_of_Hint = 2
                    Else
                        Question_Shown.Is_Having_Hints = False
                    End If
                Case 9
                    If (temp = "1") Then
                        Question_Shown.Is_Having_SuperXcel = True
                    Else
                        Question_Shown.Is_Having_SuperXcel = False

                    End If
                Case 10
                    Question_Shown.Time_Seconds = Val(temp)
                Case 11
                    Question_Shown.Question_Image = temp

            End Select
            count = count + 1
        Loop
        If (Is_Question) Then
            Load_Question_In_Form(Question_Shown)
        End If
        RichTextBox1.Text = message
    End Sub
End Class