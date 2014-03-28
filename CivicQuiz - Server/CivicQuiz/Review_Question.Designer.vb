<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Review_Question
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
        Me.Question_Image_Box = New System.Windows.Forms.PictureBox()
        Me.OptionD = New System.Windows.Forms.Label()
        Me.OptionC = New System.Windows.Forms.Label()
        Me.OptionB = New System.Windows.Forms.Label()
        Me.OptionA = New System.Windows.Forms.Label()
        Me.Question_Text_Label = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.Question_Image_Box, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Question_Image_Box
        '
        Me.Question_Image_Box.Location = New System.Drawing.Point(891, 108)
        Me.Question_Image_Box.Name = "Question_Image_Box"
        Me.Question_Image_Box.Size = New System.Drawing.Size(159, 155)
        Me.Question_Image_Box.TabIndex = 13
        Me.Question_Image_Box.TabStop = False
        '
        'OptionD
        '
        Me.OptionD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptionD.Location = New System.Drawing.Point(29, 219)
        Me.OptionD.Name = "OptionD"
        Me.OptionD.Size = New System.Drawing.Size(856, 30)
        Me.OptionD.TabIndex = 12
        Me.OptionD.Text = "D ."
        '
        'OptionC
        '
        Me.OptionC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptionC.Location = New System.Drawing.Point(29, 186)
        Me.OptionC.Name = "OptionC"
        Me.OptionC.Size = New System.Drawing.Size(856, 30)
        Me.OptionC.TabIndex = 11
        Me.OptionC.Text = "C ."
        '
        'OptionB
        '
        Me.OptionB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptionB.Location = New System.Drawing.Point(29, 152)
        Me.OptionB.Name = "OptionB"
        Me.OptionB.Size = New System.Drawing.Size(856, 30)
        Me.OptionB.TabIndex = 10
        Me.OptionB.Text = "B ."
        '
        'OptionA
        '
        Me.OptionA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptionA.Location = New System.Drawing.Point(29, 114)
        Me.OptionA.Name = "OptionA"
        Me.OptionA.Size = New System.Drawing.Size(856, 30)
        Me.OptionA.TabIndex = 9
        Me.OptionA.Text = "A ."
        '
        'Question_Text_Label
        '
        Me.Question_Text_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Question_Text_Label.Location = New System.Drawing.Point(62, 12)
        Me.Question_Text_Label.Name = "Question_Text_Label"
        Me.Question_Text_Label.Size = New System.Drawing.Size(985, 91)
        Me.Question_Text_Label.TabIndex = 8
        Me.Question_Text_Label.Text = "Question Goes Here"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(-2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 31)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Q ."
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(407, 295)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(238, 38)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "Close"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Review_Question
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1053, 346)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Question_Image_Box)
        Me.Controls.Add(Me.OptionD)
        Me.Controls.Add(Me.OptionC)
        Me.Controls.Add(Me.OptionB)
        Me.Controls.Add(Me.OptionA)
        Me.Controls.Add(Me.Question_Text_Label)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Review_Question"
        Me.Text = "Review Question"
        CType(Me.Question_Image_Box, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Question_Image_Box As System.Windows.Forms.PictureBox
    Friend WithEvents OptionD As System.Windows.Forms.Label
    Friend WithEvents OptionC As System.Windows.Forms.Label
    Friend WithEvents OptionB As System.Windows.Forms.Label
    Friend WithEvents OptionA As System.Windows.Forms.Label
    Friend WithEvents Question_Text_Label As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
