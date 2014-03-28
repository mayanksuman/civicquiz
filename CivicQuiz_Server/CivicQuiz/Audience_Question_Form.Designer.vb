<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Audience_Question_Form
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
        Me.MCQ_Box = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Team_Indicator = New System.Windows.Forms.Label()
        Me.Question_Image_Box = New System.Windows.Forms.PictureBox()
        Me.OptionD = New System.Windows.Forms.Label()
        Me.OptionC = New System.Windows.Forms.Label()
        Me.OptionB = New System.Windows.Forms.Label()
        Me.Question_Text_Label = New System.Windows.Forms.Label()
        Me.Leave_Button = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MCQ_Box.SuspendLayout()
        CType(Me.Question_Image_Box, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MCQ_Box
        '
        Me.MCQ_Box.Controls.Add(Me.Label2)
        Me.MCQ_Box.Controls.Add(Me.Team_Indicator)
        Me.MCQ_Box.Controls.Add(Me.Question_Image_Box)
        Me.MCQ_Box.Controls.Add(Me.OptionD)
        Me.MCQ_Box.Controls.Add(Me.OptionC)
        Me.MCQ_Box.Controls.Add(Me.OptionB)
        Me.MCQ_Box.Controls.Add(Me.Question_Text_Label)
        Me.MCQ_Box.Controls.Add(Me.Leave_Button)
        Me.MCQ_Box.Controls.Add(Me.Label1)
        Me.MCQ_Box.Location = New System.Drawing.Point(3, -2)
        Me.MCQ_Box.Name = "MCQ_Box"
        Me.MCQ_Box.Size = New System.Drawing.Size(709, 537)
        Me.MCQ_Box.TabIndex = 1
        Me.MCQ_Box.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(225, 341)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 33)
        Me.Label2.TabIndex = 14
        '
        'Team_Indicator
        '
        Me.Team_Indicator.AutoSize = True
        Me.Team_Indicator.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Team_Indicator.Location = New System.Drawing.Point(13, 16)
        Me.Team_Indicator.Name = "Team_Indicator"
        Me.Team_Indicator.Size = New System.Drawing.Size(114, 15)
        Me.Team_Indicator.TabIndex = 13
        Me.Team_Indicator.Text = "Audience Question"
        '
        'Question_Image_Box
        '
        Me.Question_Image_Box.Location = New System.Drawing.Point(552, 140)
        Me.Question_Image_Box.Name = "Question_Image_Box"
        Me.Question_Image_Box.Size = New System.Drawing.Size(151, 155)
        Me.Question_Image_Box.TabIndex = 6
        Me.Question_Image_Box.TabStop = False
        '
        'OptionD
        '
        Me.OptionD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptionD.Location = New System.Drawing.Point(41, 251)
        Me.OptionD.Name = "OptionD"
        Me.OptionD.Size = New System.Drawing.Size(497, 30)
        Me.OptionD.TabIndex = 5
        '
        'OptionC
        '
        Me.OptionC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptionC.Location = New System.Drawing.Point(41, 218)
        Me.OptionC.Name = "OptionC"
        Me.OptionC.Size = New System.Drawing.Size(497, 30)
        Me.OptionC.TabIndex = 4
        '
        'OptionB
        '
        Me.OptionB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptionB.Location = New System.Drawing.Point(41, 184)
        Me.OptionB.Name = "OptionB"
        Me.OptionB.Size = New System.Drawing.Size(497, 30)
        Me.OptionB.TabIndex = 3
        '
        'Question_Text_Label
        '
        Me.Question_Text_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Question_Text_Label.Location = New System.Drawing.Point(74, 100)
        Me.Question_Text_Label.Name = "Question_Text_Label"
        Me.Question_Text_Label.Size = New System.Drawing.Size(464, 210)
        Me.Question_Text_Label.TabIndex = 1
        Me.Question_Text_Label.Text = "Question Goes Here"
        '
        'Leave_Button
        '
        Me.Leave_Button.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Leave_Button.Location = New System.Drawing.Point(303, 492)
        Me.Leave_Button.Name = "Leave_Button"
        Me.Leave_Button.Size = New System.Drawing.Size(154, 36)
        Me.Leave_Button.TabIndex = 7
        Me.Leave_Button.Text = "Show &Answer"
        Me.Leave_Button.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Q ."
        '
        'Audience_Question_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(718, 538)
        Me.ControlBox = False
        Me.Controls.Add(Me.MCQ_Box)
        Me.Name = "Audience_Question_Form"
        Me.Text = "Audience Question"
        Me.MCQ_Box.ResumeLayout(False)
        Me.MCQ_Box.PerformLayout()
        CType(Me.Question_Image_Box, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MCQ_Box As System.Windows.Forms.GroupBox
    Friend WithEvents Team_Indicator As System.Windows.Forms.Label
    Friend WithEvents Question_Image_Box As System.Windows.Forms.PictureBox
    Friend WithEvents OptionD As System.Windows.Forms.Label
    Friend WithEvents OptionC As System.Windows.Forms.Label
    Friend WithEvents OptionB As System.Windows.Forms.Label
    Friend WithEvents Question_Text_Label As System.Windows.Forms.Label
    Friend WithEvents Leave_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
