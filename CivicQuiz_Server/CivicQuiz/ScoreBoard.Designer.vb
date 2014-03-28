<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ScoreBoard
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Team = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Score1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Score_Round2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Score_Round3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Score_Round4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Location = New System.Drawing.Point(4, -3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(716, 382)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(286, 342)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(145, 34)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "&Proceed"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Team, Me.Score1, Me.Score_Round2, Me.Score_Round3, Me.Score_Round4, Me.Total})
        Me.DataGridView1.Location = New System.Drawing.Point(3, 16)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(706, 318)
        Me.DataGridView1.TabIndex = 0
        '
        'Team
        '
        Me.Team.HeaderText = "Team"
        Me.Team.Name = "Team"
        '
        'Score1
        '
        Me.Score1.HeaderText = "Round 1"
        Me.Score1.Name = "Score1"
        '
        'Score_Round2
        '
        Me.Score_Round2.HeaderText = "Round 2"
        Me.Score_Round2.Name = "Score_Round2"
        '
        'Score_Round3
        '
        Me.Score_Round3.HeaderText = "Round 3"
        Me.Score_Round3.Name = "Score_Round3"
        '
        'Score_Round4
        '
        Me.Score_Round4.HeaderText = "Round 4"
        Me.Score_Round4.Name = "Score_Round4"
        '
        'Total
        '
        Me.Total.HeaderText = "Total Score"
        Me.Total.Name = "Total"
        '
        'ScoreBoard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(725, 384)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ScoreBoard"
        Me.Text = "ScoreBoard"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Team As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Score1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Score_Round2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Score_Round3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Score_Round4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
