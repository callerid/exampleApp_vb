<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class displayRow
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.lbName = New System.Windows.Forms.Label()
        Me.lbNumber = New System.Windows.Forms.Label()
        Me.lbTime = New System.Windows.Forms.Label()
        Me.lbLine = New System.Windows.Forms.Label()
        Me.picDatabase = New System.Windows.Forms.PictureBox()
        Me.picPhone = New System.Windows.Forms.PictureBox()
        CType(Me.picDatabase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPhone, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbName
        '
        Me.lbName.AutoSize = True
        Me.lbName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbName.Location = New System.Drawing.Point(320, 13)
        Me.lbName.Name = "lbName"
        Me.lbName.Size = New System.Drawing.Size(51, 20)
        Me.lbName.TabIndex = 13
        Me.lbName.Text = "Name"
        '
        'lbNumber
        '
        Me.lbNumber.AutoSize = True
        Me.lbNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNumber.Location = New System.Drawing.Point(181, 13)
        Me.lbNumber.Name = "lbNumber"
        Me.lbNumber.Size = New System.Drawing.Size(65, 20)
        Me.lbNumber.TabIndex = 12
        Me.lbNumber.Text = "Number"
        '
        'lbTime
        '
        Me.lbTime.AutoSize = True
        Me.lbTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTime.Location = New System.Drawing.Point(87, 13)
        Me.lbTime.Name = "lbTime"
        Me.lbTime.Size = New System.Drawing.Size(43, 20)
        Me.lbTime.TabIndex = 11
        Me.lbTime.Text = "Time"
        '
        'lbLine
        '
        Me.lbLine.AutoSize = True
        Me.lbLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbLine.Location = New System.Drawing.Point(48, 13)
        Me.lbLine.Name = "lbLine"
        Me.lbLine.Size = New System.Drawing.Size(27, 20)
        Me.lbLine.TabIndex = 10
        Me.lbLine.Text = "01"
        '
        'picDatabase
        '
        Me.picDatabase.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picDatabase.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picDatabase.Image = Global.spa_vb.My.Resources.Resources.databaseIdle
        Me.picDatabase.Location = New System.Drawing.Point(564, 5)
        Me.picDatabase.Name = "picDatabase"
        Me.picDatabase.Size = New System.Drawing.Size(39, 40)
        Me.picDatabase.TabIndex = 14
        Me.picDatabase.TabStop = False
        Me.picDatabase.Tag = "idle"
        '
        'picPhone
        '
        Me.picPhone.Image = Global.spa_vb.My.Resources.Resources.phoneOnHook
        Me.picPhone.Location = New System.Drawing.Point(3, 3)
        Me.picPhone.Name = "picPhone"
        Me.picPhone.Size = New System.Drawing.Size(39, 40)
        Me.picPhone.TabIndex = 9
        Me.picPhone.TabStop = False
        '
        'displayRow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.Controls.Add(Me.picDatabase)
        Me.Controls.Add(Me.lbName)
        Me.Controls.Add(Me.lbNumber)
        Me.Controls.Add(Me.lbTime)
        Me.Controls.Add(Me.lbLine)
        Me.Controls.Add(Me.picPhone)
        Me.Name = "displayRow"
        Me.Size = New System.Drawing.Size(608, 46)
        CType(Me.picDatabase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPhone, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents picDatabase As System.Windows.Forms.PictureBox
    Friend WithEvents lbName As System.Windows.Forms.Label
    Friend WithEvents lbNumber As System.Windows.Forms.Label
    Friend WithEvents lbTime As System.Windows.Forms.Label
    Friend WithEvents lbLine As System.Windows.Forms.Label
    Friend WithEvents picPhone As System.Windows.Forms.PictureBox

End Class
