<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.btContacts = New System.Windows.Forms.Button()
        Me.btLog = New System.Windows.Forms.Button()
        Me.panLine4 = New spa_vb.displayRow()
        Me.panLine3 = New spa_vb.displayRow()
        Me.panLine2 = New spa_vb.displayRow()
        Me.panLine1 = New spa_vb.displayRow()
        Me.SuspendLayout()
        '
        'btContacts
        '
        Me.btContacts.Location = New System.Drawing.Point(525, 220)
        Me.btContacts.Name = "btContacts"
        Me.btContacts.Size = New System.Drawing.Size(78, 27)
        Me.btContacts.TabIndex = 7
        Me.btContacts.Text = "Contacts"
        Me.btContacts.UseVisualStyleBackColor = True
        '
        'btLog
        '
        Me.btLog.Location = New System.Drawing.Point(441, 220)
        Me.btLog.Name = "btLog"
        Me.btLog.Size = New System.Drawing.Size(78, 27)
        Me.btLog.TabIndex = 6
        Me.btLog.Text = "Open Log"
        Me.btLog.UseVisualStyleBackColor = True
        '
        'panLine4
        '
        Me.panLine4.BackColor = System.Drawing.Color.Silver
        Me.panLine4.Line = 0
        Me.panLine4.Location = New System.Drawing.Point(12, 168)
        Me.panLine4.Name = "panLine4"
        Me.panLine4.Size = New System.Drawing.Size(591, 46)
        Me.panLine4.TabIndex = 12
        '
        'panLine3
        '
        Me.panLine3.BackColor = System.Drawing.Color.Silver
        Me.panLine3.Line = 0
        Me.panLine3.Location = New System.Drawing.Point(12, 116)
        Me.panLine3.Name = "panLine3"
        Me.panLine3.Size = New System.Drawing.Size(591, 46)
        Me.panLine3.TabIndex = 12
        '
        'panLine2
        '
        Me.panLine2.BackColor = System.Drawing.Color.Silver
        Me.panLine2.Line = 0
        Me.panLine2.Location = New System.Drawing.Point(12, 64)
        Me.panLine2.Name = "panLine2"
        Me.panLine2.Size = New System.Drawing.Size(591, 46)
        Me.panLine2.TabIndex = 12
        '
        'panLine1
        '
        Me.panLine1.BackColor = System.Drawing.Color.Silver
        Me.panLine1.Line = 0
        Me.panLine1.Location = New System.Drawing.Point(12, 12)
        Me.panLine1.Name = "panLine1"
        Me.panLine1.Size = New System.Drawing.Size(591, 46)
        Me.panLine1.TabIndex = 12
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(615, 260)
        Me.Controls.Add(Me.panLine4)
        Me.Controls.Add(Me.panLine3)
        Me.Controls.Add(Me.panLine2)
        Me.Controls.Add(Me.panLine1)
        Me.Controls.Add(Me.btContacts)
        Me.Controls.Add(Me.btLog)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmMain"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Example Application VB"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents btContacts As System.Windows.Forms.Button
    Private WithEvents btLog As System.Windows.Forms.Button
    Private WithEvents panLine1 As spa_vb.displayRow
    Private WithEvents panLine2 As spa_vb.displayRow
    Private WithEvents panLine3 As spa_vb.displayRow
    Private WithEvents panLine4 As spa_vb.displayRow
End Class
