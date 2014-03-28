Public Class Subjects

    

    Private Sub Subjects_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Elastic_Resize_To_Full_Screen3(Me)
    End Sub
    Public Sub Show_Question(ByVal Sub_index As Integer)
        Load_Question_In_Form(Sel_Sub_Questions(Sub_index, Current_Round_Part_Index))
        Me.Visible = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Show_Question(0)
        Button1.Enabled = False
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Show_Question(1)
        Button2.Enabled = False
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Show_Question(2)
        Button3.Enabled = False
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Show_Question(3)
        Button4.Enabled = False
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Show_Question(4)
        Button5.Enabled = False
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Show_Question(5)
        Button6.Enabled = False
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Show_Question(6)
        Button7.Enabled = False
    End Sub
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Show_Question(7)
        Button8.Enabled = False
    End Sub

    Private Sub Subjects_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

    End Sub

    Private Sub Subjects_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If (Current_Round_Part_Index = 1) And (Current_Team_Index = 3) Then
            Button1.Enabled = True
            Button2.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True
            Button5.Enabled = True
            Button6.Enabled = True
            Button7.Enabled = True
            Button8.Enabled = True
        End If
        Label1.Text = "Subjects Available for " + Teams(Current_Team_Index).Name
    End Sub
End Class