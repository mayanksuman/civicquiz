Public Class Information_Form

    Private Sub Information_Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Elastic_Resize_To_Full_Screen3(Me)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Select Case Current_Quiz_Part_Index
            Case 0
                
                    If (Is_Answer_Needed = False) Then
                    Show_Overloaded_Information("Questions", "Qualifying Questions", "Question1.rtf", "&Show Answers")
                        Is_Answer_Needed = True
                    Else
                    Show_Overloaded_Information("Answers", "", "Pre_Answer.rtf", "&Proceed To Next Part")
                    Current_Quiz_Part_Index = 1
                    Initialize_Quiz_Part()
                End If

            Case 1
                Select Case Current_Round_Index
                    Case 0
                        If (Is_Second_Part_In_Progress = False) Then

                            Client_Info.Show()
                            Is_Second_Part_In_Progress = True
                        Else
                            Subjects.Show()
                        End If
                    Case 1
                        Load_Question_In_Form(Our_Question(0))
                        Me.Hide()
                    Case 2
                        Load_Question_In_Form(Expert_Question(0))
                        Me.Hide()
                    Case 3
                        Load_Question_In_Form(Arrange_Question(0))
                        Me.Hide()

                End Select

        End Select


    End Sub
End Class