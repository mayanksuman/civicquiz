Public Class Client_Info

    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim port_num As Integer = Val(TextBox5.Text)
        Teams(0).Name = "Team A"
        Teams(0).IPAdress = TextBox1.Text

        Teams(1).Name = "Team B"
        Teams(1).IPAdress = TextBox2.Text

        Teams(2).Name = "Team C"
        Teams(2).IPAdress = TextBox3.Text

        Teams(3).Name = "Team D"
        Teams(3).IPAdress = TextBox4.Text

        Quiz_Server.Port = Val(TextBox9.Text)
        Teams(0).Port = port_num

        Listener_Form.Show()
        Listener_Form.Visible = False
        Dim i As Integer
        For i = 0 To 3
            Teams(i).Port = port_num
            Send_To_Client("CONNECTED", "I", Teams(i))
            ReDim Teams(i).Score(4, 4)
            For j = 0 To 3
                For k = 0 To 3
                    Teams(i).Score(j, k) = 0
                Next
            Next
        Next
        Run_Quiz()
        Information_Form.Close()
        'Subjects.Show() 'Show_Default_Information()
        Me.Close()

    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Client_Info_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
    End Sub
End Class