Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Public Class Listener_Form
    Public Event Data_Received(ByVal IP As String, ByVal T As String)
    Public Delegate Sub myDelegate(ByVal s As String, ByVal d As String)
    Public Listener_Thread As Threading.Thread


    Private Sub Listener_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Listener_Thread = New Threading.Thread(AddressOf Listener_Thread_Sub)
        Listener_Thread.Start()

    End Sub
    Public Sub Listener_Thread_Sub()
        'Dim listenPort As Integer = Teams(0).Port

        Dim done As Boolean = False
        'Dim listener As New UdpClient(listenPort)
        'Dim groupEP As New IPEndPoint(IPAddress.Parse(Quiz_Server.IPAdress), listenPort)
        Dim groupEP As New IPEndPoint(IPAddress.Any, 7777)
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
        Dim Is_Answer As Boolean = False   'False -INfo    True-Question
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
            Dim pos As Integer = InStr(ipaddress, ":")
            Dim ip As String = Mid(ipaddress, 1, pos - 1)
            Select Case count
                Case 0
                    If temp = "~" Then
                        Is_Answer = True
                    Else
                        Is_Answer = False
                    End If
                Case 1
                    If Is_Answer Then
                        If Current_Round_Index = 3 Then
                            Dim team_index As Integer = 0
                            Dim check As Boolean = True
                            While check
                                If (Teams(team_index).IPAdress = ip) Then
                                    check = False
                                Else
                                    team_index = team_index + 1
                                    If team_index > 3 Then
                                        team_index = 4
                                        check = False
                                    End If
                                End If
                            End While
                            If team_index <= 3 Then
                                Current_Team_Index = team_index
                            End If
                            MCQ.Show_Answer_Form(temp)
                        Else
                            If (ip = Teams(Current_Team_Index).IPAdress) Then
                                MCQ.Show_Answer_Form(temp)
                            End If

                        End If

                    Else
                        If temp = "TEAM_INFO_NEEDED" Then
                            Dim team_index As Integer = 0
                            Dim check As Boolean = True
                            

                            While check
                                If (team_index > 3) Then
                                    check = False
                                Else
                                    If (Teams(team_index).IPAdress = ip) Then
                                        check = False
                                    Else
                                        team_index = team_index + 1
                                    End If
                                End If
                            End While
                            If team_index <= 3 Then
                                Send_To_Client("TEAM:" + Teams(team_index).Name, "I", Teams(team_index))
                            End If
                        End If


                        If (temp = "SUPERXCEL_DEMANDED") Then
                            If ip = Teams(Current_Team_Index).IPAdress Then
                                MCQ.Activate_SuperXcel()
                            End If
                        End If

                        If temp = "HINT_DEMANDED" Then
                            If ip = Teams(Current_Team_Index).IPAdress Then
                                Dim hint As String = MCQ.Generate_Hint
                                Send_To_Client("Hint:" + hint, "I", Teams(Current_Team_Index))
                                If Not (hint = "") Then
                                    MsgBox(hint, vbOKOnly, "Hint")
                                End If
                            End If
                        End If
                        End If

            End Select
            count = count + 1
        Loop

        RichTextBox1.Text = ipaddress + "--\\--" + message
    End Sub

    Private Sub RichTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RichTextBox1.TextChanged

    End Sub
End Class