Public Class ScoreBoard


    Private Sub ScoreBoard_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Beige
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("Times New Roman", 20, FontStyle.Bold)
        DataGridView1.RowsDefaultCellStyle.BackColor = Color.Beige
        DataGridView1.RowsDefaultCellStyle.Font = New Font("Times New Roman", 14, FontStyle.Regular)
        If Is_To_Show_Final_Score Then
            Show_Final_Score()
        Else
            Show_Round_Score()
        End If
        Elastic_Resize_To_Full_Screen3(Me)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Button1.Text = "Quit Quiz" Then
            'Quit Quiz
            Me.Close()
            'Listener_Form.Listener_Thread.Abort()
            Listener_Form.Close()
            Quiz_Entry.Close()

        Else
            Load_Audience_Question()
            If Current_Round_Index = 3 Then
                Is_To_Show_Final_Score = True
            Else
                Is_To_Show_Final_Score = False
            End If
            Me.Close()
        End If

    End Sub
    Public Sub Show_Final_Score()
        DataGridView1.ColumnCount = 6
        DataGridView1.ColumnHeadersVisible = True
        DataGridView1.Columns(0).HeaderText = "Teams"
        DataGridView1.Columns(1).HeaderText = "Round 1"
        DataGridView1.Columns(2).HeaderText = "Round 2"
        DataGridView1.Columns(3).HeaderText = "Round 3"
        DataGridView1.Columns(4).HeaderText = "Round 4"
        DataGridView1.Columns(5).HeaderText = "Final Score"
        For i = 0 To Num_Of_Team - 1
            'Dim i As Integer = 0
            Dim r() As String = {Teams(i).Name, (Teams(i).Score(1, 0) + Teams(i).Score(1, 1)).ToString, (Teams(i).Score(2, 0) + Teams(i).Score(2, 1)).ToString, (Teams(i).Score(3, 0)).ToString, (Teams(i).Score(4, 0)).ToString, (Teams(i).Score(1, 0) + Teams(i).Score(1, 1) + Teams(i).Score(2, 0) + Teams(i).Score(2, 1) + Teams(i).Score(3, 0) + Teams(i).Score(4, 0)).ToString}
            DataGridView1.Rows.Add(r)
        Next
        Button1.Text = "Quit Quiz"
    End Sub

    Public Sub Show_Round_Score()
        

        If (Current_Round_Index <= 1) Then
            DataGridView1.ColumnCount = Current_Round_Part_Index + 3
            DataGridView1.ColumnHeadersVisible = True
            DataGridView1.Columns(0).HeaderText = "Teams"
            DataGridView1.Columns(1).HeaderText = "First Question"
            DataGridView1.Columns(2).HeaderText = "Second Question"
            DataGridView1.Columns(3).HeaderText = "Total Score"
            DataGridView1.Columns(3).DefaultCellStyle.Font = New Font("Times New Roman", 14, FontStyle.Bold)
            For i = 0 To Num_Of_Team - 1
                'Dim i As Integer = 0
                Dim r() As String = {Teams(i).Name, Teams(i).Score(Current_Round_Index, 0).ToString, Teams(i).Score(Current_Round_Index, 1).ToString, (Teams(i).Score(Current_Round_Index, 0) + Teams(i).Score(Current_Round_Index, 1)).ToString}
                DataGridView1.Rows.Add(r)
            Next
        Else
            If (Current_Round_Index = 2) Then
                DataGridView1.ColumnCount = Current_Round_Part_Index + 2
                DataGridView1.Columns(0).HeaderText = "Teams"
                DataGridView1.Columns(1).HeaderText = "Round Score"
                For i = 0 To Num_Of_Team - 1
                    'Dim i As Integer = 0
                    Dim r() As String = {Teams(i).Name, Teams(i).Score(Current_Round_Index, 0).ToString}
                    DataGridView1.Rows.Add(r)
                Next
            End If
            
            If Current_Round_Index = 3 Then
                DataGridView1.ColumnCount = 6
                DataGridView1.Columns(0).HeaderText = "Teams"
                DataGridView1.Columns(1).HeaderText = "First Question"
                DataGridView1.Columns(2).HeaderText = "Second Question"
                DataGridView1.Columns(3).HeaderText = "Third Question"
                DataGridView1.Columns(4).HeaderText = "Forth Question"
                DataGridView1.Columns(5).HeaderText = "Total Score"
                For i = 0 To Num_Of_Team - 1
                    'Dim i As Integer = 0
                    Dim r() As String = {Teams(i).Name, Teams(i).Score(Current_Round_Index, 0).ToString, Teams(i).Score(Current_Round_Index, 1).ToString, Teams(i).Score(Current_Round_Index, 2).ToString, Teams(i).Score(Current_Round_Index, 3).ToString, (Teams(i).Score(Current_Round_Index, 0) + Teams(i).Score(Current_Round_Index, 1) + Teams(i).Score(Current_Round_Index, 2) + Teams(i).Score(Current_Round_Index, 3)).ToString}
                    DataGridView1.Rows.Add(r)
                Next

            End If
        End If
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False

    End Sub
End Class