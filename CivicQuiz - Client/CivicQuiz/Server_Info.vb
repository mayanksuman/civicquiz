Public Class Server_Info

   

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Quiz_Entry.wait.Visible = True
        Teams(0).Name = "Team A"
        Teams(1).Name = "Team B"
        Teams(2).Name = "Team C"
        Teams(3).Name = "Team D"
        Quiz_Server.Name = "Server"
        Quiz_Server.IPAdress = TextBox1.Text
        Quiz_Server.Port = Val(TextBox5.Text)
        This_Team.Port = Val(TextBox2.Text)
        Send_To_Server("TEAM_INFO_NEEDED", "I")
        Listener.Show()
        Me.Close()


    End Sub

    
End Class