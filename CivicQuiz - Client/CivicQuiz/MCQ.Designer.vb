<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MCQ
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MCQ))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Arrangement_Question_Box = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.List_Down_Button = New System.Windows.Forms.PictureBox()
        Me.List_Up_Button = New System.Windows.Forms.PictureBox()
        Me.ArrangedList = New System.Windows.Forms.ListBox()
        Me.Submit_Arrange_Button = New System.Windows.Forms.Button()
        Me.OptionD_Arrangement = New System.Windows.Forms.Label()
        Me.OptionC_Arrangement = New System.Windows.Forms.Label()
        Me.OptionB_Arrangement = New System.Windows.Forms.Label()
        Me.OptionA_Arrangement = New System.Windows.Forms.Label()
        Me.Question_Text_Arrangement = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Leave_Button = New System.Windows.Forms.Button()
        Me.Hint_Button = New System.Windows.Forms.Button()
        Me.Superxcel_Button = New System.Windows.Forms.Button()
        Me.Question_Text_Label = New System.Windows.Forms.Label()
        Me.OptionA = New System.Windows.Forms.Label()
        Me.OptionB = New System.Windows.Forms.Label()
        Me.OptionC = New System.Windows.Forms.Label()
        Me.OptionD = New System.Windows.Forms.Label()
        Me.Question_Image_Box = New System.Windows.Forms.PictureBox()
        Me.Clock = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.SuperXcel_Picture_Box = New System.Windows.Forms.PictureBox()
        Me.Team_Indicator = New System.Windows.Forms.Label()
        Me.MCQ_Box = New System.Windows.Forms.GroupBox()
        Me.Arrangement_Question_Box.SuspendLayout()
        CType(Me.List_Down_Button, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.List_Up_Button, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Question_Image_Box, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Clock.SuspendLayout()
        CType(Me.SuperXcel_Picture_Box, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MCQ_Box.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'Arrangement_Question_Box
        '
        Me.Arrangement_Question_Box.Controls.Add(Me.Label11)
        Me.Arrangement_Question_Box.Controls.Add(Me.List_Down_Button)
        Me.Arrangement_Question_Box.Controls.Add(Me.List_Up_Button)
        Me.Arrangement_Question_Box.Controls.Add(Me.ArrangedList)
        Me.Arrangement_Question_Box.Controls.Add(Me.Submit_Arrange_Button)
        Me.Arrangement_Question_Box.Controls.Add(Me.OptionD_Arrangement)
        Me.Arrangement_Question_Box.Controls.Add(Me.OptionC_Arrangement)
        Me.Arrangement_Question_Box.Controls.Add(Me.OptionB_Arrangement)
        Me.Arrangement_Question_Box.Controls.Add(Me.OptionA_Arrangement)
        Me.Arrangement_Question_Box.Controls.Add(Me.Question_Text_Arrangement)
        Me.Arrangement_Question_Box.Controls.Add(Me.Label15)
        Me.Arrangement_Question_Box.Location = New System.Drawing.Point(4, -2)
        Me.Arrangement_Question_Box.Name = "Arrangement_Question_Box"
        Me.Arrangement_Question_Box.Size = New System.Drawing.Size(709, 537)
        Me.Arrangement_Question_Box.TabIndex = 14
        Me.Arrangement_Question_Box.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(465, 138)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(76, 13)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "Your Answer :-"
        '
        'List_Down_Button
        '
        Me.List_Down_Button.BackgroundImage = CType(resources.GetObject("List_Down_Button.BackgroundImage"), System.Drawing.Image)
        Me.List_Down_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.List_Down_Button.Location = New System.Drawing.Point(663, 305)
        Me.List_Down_Button.Name = "List_Down_Button"
        Me.List_Down_Button.Size = New System.Drawing.Size(38, 31)
        Me.List_Down_Button.TabIndex = 14
        Me.List_Down_Button.TabStop = False
        '
        'List_Up_Button
        '
        Me.List_Up_Button.BackgroundImage = CType(resources.GetObject("List_Up_Button.BackgroundImage"), System.Drawing.Image)
        Me.List_Up_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.List_Up_Button.Location = New System.Drawing.Point(663, 160)
        Me.List_Up_Button.Name = "List_Up_Button"
        Me.List_Up_Button.Size = New System.Drawing.Size(38, 31)
        Me.List_Up_Button.TabIndex = 13
        Me.List_Up_Button.TabStop = False
        '
        'ArrangedList
        '
        Me.ArrangedList.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ArrangedList.FormattingEnabled = True
        Me.ArrangedList.ItemHeight = 16
        Me.ArrangedList.Location = New System.Drawing.Point(468, 157)
        Me.ArrangedList.Name = "ArrangedList"
        Me.ArrangedList.Size = New System.Drawing.Size(186, 180)
        Me.ArrangedList.TabIndex = 12
        '
        'Submit_Arrange_Button
        '
        Me.Submit_Arrange_Button.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Submit_Arrange_Button.Location = New System.Drawing.Point(267, 494)
        Me.Submit_Arrange_Button.Name = "Submit_Arrange_Button"
        Me.Submit_Arrange_Button.Size = New System.Drawing.Size(154, 36)
        Me.Submit_Arrange_Button.TabIndex = 9
        Me.Submit_Arrange_Button.Text = "&Submit Answer"
        Me.Submit_Arrange_Button.UseVisualStyleBackColor = True
        '
        'OptionD_Arrangement
        '
        Me.OptionD_Arrangement.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptionD_Arrangement.Location = New System.Drawing.Point(43, 282)
        Me.OptionD_Arrangement.Name = "OptionD_Arrangement"
        Me.OptionD_Arrangement.Size = New System.Drawing.Size(422, 30)
        Me.OptionD_Arrangement.TabIndex = 5
        Me.OptionD_Arrangement.Text = "D ."
        '
        'OptionC_Arrangement
        '
        Me.OptionC_Arrangement.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptionC_Arrangement.Location = New System.Drawing.Point(43, 249)
        Me.OptionC_Arrangement.Name = "OptionC_Arrangement"
        Me.OptionC_Arrangement.Size = New System.Drawing.Size(422, 30)
        Me.OptionC_Arrangement.TabIndex = 4
        Me.OptionC_Arrangement.Text = "C ."
        '
        'OptionB_Arrangement
        '
        Me.OptionB_Arrangement.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptionB_Arrangement.Location = New System.Drawing.Point(43, 215)
        Me.OptionB_Arrangement.Name = "OptionB_Arrangement"
        Me.OptionB_Arrangement.Size = New System.Drawing.Size(422, 30)
        Me.OptionB_Arrangement.TabIndex = 3
        Me.OptionB_Arrangement.Text = "B ."
        '
        'OptionA_Arrangement
        '
        Me.OptionA_Arrangement.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptionA_Arrangement.Location = New System.Drawing.Point(43, 177)
        Me.OptionA_Arrangement.Name = "OptionA_Arrangement"
        Me.OptionA_Arrangement.Size = New System.Drawing.Size(422, 30)
        Me.OptionA_Arrangement.TabIndex = 2
        Me.OptionA_Arrangement.Text = "A ."
        '
        'Question_Text_Arrangement
        '
        Me.Question_Text_Arrangement.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Question_Text_Arrangement.Location = New System.Drawing.Point(76, 31)
        Me.Question_Text_Arrangement.Name = "Question_Text_Arrangement"
        Me.Question_Text_Arrangement.Size = New System.Drawing.Size(626, 101)
        Me.Question_Text_Arrangement.TabIndex = 1
        Me.Question_Text_Arrangement.Text = "Question Goes Here"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(12, 19)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(53, 31)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Q ."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Q ."
        '
        'Leave_Button
        '
        Me.Leave_Button.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Leave_Button.Location = New System.Drawing.Point(19, 492)
        Me.Leave_Button.Name = "Leave_Button"
        Me.Leave_Button.Size = New System.Drawing.Size(154, 36)
        Me.Leave_Button.TabIndex = 7
        Me.Leave_Button.Text = "Leave &Question"
        Me.Leave_Button.UseVisualStyleBackColor = True
        '
        'Hint_Button
        '
        Me.Hint_Button.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Hint_Button.Location = New System.Drawing.Point(277, 492)
        Me.Hint_Button.Name = "Hint_Button"
        Me.Hint_Button.Size = New System.Drawing.Size(154, 36)
        Me.Hint_Button.TabIndex = 8
        Me.Hint_Button.Text = "Show &Hint"
        Me.Hint_Button.UseVisualStyleBackColor = True
        '
        'Superxcel_Button
        '
        Me.Superxcel_Button.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Superxcel_Button.Location = New System.Drawing.Point(538, 495)
        Me.Superxcel_Button.Name = "Superxcel_Button"
        Me.Superxcel_Button.Size = New System.Drawing.Size(154, 36)
        Me.Superxcel_Button.TabIndex = 9
        Me.Superxcel_Button.Text = "&SuperXcel"
        Me.Superxcel_Button.UseVisualStyleBackColor = True
        '
        'Question_Text_Label
        '
        Me.Question_Text_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Question_Text_Label.Location = New System.Drawing.Point(74, 44)
        Me.Question_Text_Label.Name = "Question_Text_Label"
        Me.Question_Text_Label.Size = New System.Drawing.Size(626, 91)
        Me.Question_Text_Label.TabIndex = 1
        Me.Question_Text_Label.Text = "Question Goes Here"
        '
        'OptionA
        '
        Me.OptionA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptionA.Location = New System.Drawing.Point(41, 146)
        Me.OptionA.Name = "OptionA"
        Me.OptionA.Size = New System.Drawing.Size(497, 30)
        Me.OptionA.TabIndex = 2
        Me.OptionA.Text = "A ."
        '
        'OptionB
        '
        Me.OptionB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptionB.Location = New System.Drawing.Point(41, 184)
        Me.OptionB.Name = "OptionB"
        Me.OptionB.Size = New System.Drawing.Size(497, 30)
        Me.OptionB.TabIndex = 3
        Me.OptionB.Text = "B ."
        '
        'OptionC
        '
        Me.OptionC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptionC.Location = New System.Drawing.Point(41, 218)
        Me.OptionC.Name = "OptionC"
        Me.OptionC.Size = New System.Drawing.Size(497, 30)
        Me.OptionC.TabIndex = 4
        Me.OptionC.Text = "C ."
        '
        'OptionD
        '
        Me.OptionD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptionD.Location = New System.Drawing.Point(41, 251)
        Me.OptionD.Name = "OptionD"
        Me.OptionD.Size = New System.Drawing.Size(497, 30)
        Me.OptionD.TabIndex = 5
        Me.OptionD.Text = "D ."
        '
        'Question_Image_Box
        '
        Me.Question_Image_Box.Location = New System.Drawing.Point(552, 140)
        Me.Question_Image_Box.Name = "Question_Image_Box"
        Me.Question_Image_Box.Size = New System.Drawing.Size(151, 155)
        Me.Question_Image_Box.TabIndex = 6
        Me.Question_Image_Box.TabStop = False
        '
        'Clock
        '
        Me.Clock.Controls.Add(Me.Label5)
        Me.Clock.Controls.Add(Me.Label4)
        Me.Clock.Controls.Add(Me.Label3)
        Me.Clock.Controls.Add(Me.Label2)
        Me.Clock.Controls.Add(Me.ProgressBar1)
        Me.Clock.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Clock.Location = New System.Drawing.Point(472, 354)
        Me.Clock.Name = "Clock"
        Me.Clock.Size = New System.Drawing.Size(230, 108)
        Me.Clock.TabIndex = 11
        Me.Clock.TabStop = False
        Me.Clock.Text = "Clock"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(133, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 15)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Label5"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(133, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 15)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Label4"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Time Left"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Time Given"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(11, 22)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(207, 26)
        Me.ProgressBar1.TabIndex = 0
        '
        'SuperXcel_Picture_Box
        '
        Me.SuperXcel_Picture_Box.BackgroundImage = CType(resources.GetObject("SuperXcel_Picture_Box.BackgroundImage"), System.Drawing.Image)
        Me.SuperXcel_Picture_Box.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SuperXcel_Picture_Box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SuperXcel_Picture_Box.Location = New System.Drawing.Point(44, 354)
        Me.SuperXcel_Picture_Box.Name = "SuperXcel_Picture_Box"
        Me.SuperXcel_Picture_Box.Size = New System.Drawing.Size(197, 108)
        Me.SuperXcel_Picture_Box.TabIndex = 12
        Me.SuperXcel_Picture_Box.TabStop = False
        '
        'Team_Indicator
        '
        Me.Team_Indicator.AutoSize = True
        Me.Team_Indicator.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Team_Indicator.Location = New System.Drawing.Point(13, 16)
        Me.Team_Indicator.Name = "Team_Indicator"
        Me.Team_Indicator.Size = New System.Drawing.Size(113, 15)
        Me.Team_Indicator.TabIndex = 13
        Me.Team_Indicator.Text = "Question For Team"
        '
        'MCQ_Box
        '
        Me.MCQ_Box.Controls.Add(Me.Team_Indicator)
        Me.MCQ_Box.Controls.Add(Me.SuperXcel_Picture_Box)
        Me.MCQ_Box.Controls.Add(Me.Question_Image_Box)
        Me.MCQ_Box.Controls.Add(Me.OptionD)
        Me.MCQ_Box.Controls.Add(Me.OptionC)
        Me.MCQ_Box.Controls.Add(Me.OptionB)
        Me.MCQ_Box.Controls.Add(Me.OptionA)
        Me.MCQ_Box.Controls.Add(Me.Question_Text_Label)
        Me.MCQ_Box.Controls.Add(Me.Superxcel_Button)
        Me.MCQ_Box.Controls.Add(Me.Hint_Button)
        Me.MCQ_Box.Controls.Add(Me.Leave_Button)
        Me.MCQ_Box.Controls.Add(Me.Label1)
        Me.MCQ_Box.Location = New System.Drawing.Point(6, 0)
        Me.MCQ_Box.Name = "MCQ_Box"
        Me.MCQ_Box.Size = New System.Drawing.Size(709, 537)
        Me.MCQ_Box.TabIndex = 0
        Me.MCQ_Box.TabStop = False
        '
        'MCQ
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(719, 544)
        Me.ControlBox = False
        Me.Controls.Add(Me.Arrangement_Question_Box)
        Me.Controls.Add(Me.MCQ_Box)
        Me.Controls.Add(Me.Clock)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "MCQ"
        Me.Text = "Question"
        Me.Arrangement_Question_Box.ResumeLayout(False)
        Me.Arrangement_Question_Box.PerformLayout()
        CType(Me.List_Down_Button, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.List_Up_Button, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Question_Image_Box, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Clock.ResumeLayout(False)
        Me.Clock.PerformLayout()
        CType(Me.SuperXcel_Picture_Box, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MCQ_Box.ResumeLayout(False)
        Me.MCQ_Box.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Arrangement_Question_Box As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents List_Down_Button As System.Windows.Forms.PictureBox
    Friend WithEvents List_Up_Button As System.Windows.Forms.PictureBox
    Friend WithEvents ArrangedList As System.Windows.Forms.ListBox
    Friend WithEvents Submit_Arrange_Button As System.Windows.Forms.Button
    Friend WithEvents OptionD_Arrangement As System.Windows.Forms.Label
    Friend WithEvents OptionC_Arrangement As System.Windows.Forms.Label
    Friend WithEvents OptionB_Arrangement As System.Windows.Forms.Label
    Friend WithEvents OptionA_Arrangement As System.Windows.Forms.Label
    Friend WithEvents Question_Text_Arrangement As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Leave_Button As System.Windows.Forms.Button
    Friend WithEvents Hint_Button As System.Windows.Forms.Button
    Friend WithEvents Superxcel_Button As System.Windows.Forms.Button
    Friend WithEvents Question_Text_Label As System.Windows.Forms.Label
    Friend WithEvents OptionA As System.Windows.Forms.Label
    Friend WithEvents OptionB As System.Windows.Forms.Label
    Friend WithEvents OptionC As System.Windows.Forms.Label
    Friend WithEvents OptionD As System.Windows.Forms.Label
    Friend WithEvents Question_Image_Box As System.Windows.Forms.PictureBox
    Friend WithEvents Clock As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents SuperXcel_Picture_Box As System.Windows.Forms.PictureBox
    Friend WithEvents Team_Indicator As System.Windows.Forms.Label
    Friend WithEvents MCQ_Box As System.Windows.Forms.GroupBox
End Class
