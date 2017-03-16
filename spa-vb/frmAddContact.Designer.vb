<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddContact
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
        Me.btAdd = New System.Windows.Forms.Button()
        Me.label2 = New System.Windows.Forms.Label()
        Me.tbPhone = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.tbName = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btAdd
        '
        Me.btAdd.Location = New System.Drawing.Point(40, 105)
        Me.btAdd.Name = "btAdd"
        Me.btAdd.Size = New System.Drawing.Size(160, 44)
        Me.btAdd.TabIndex = 15
        Me.btAdd.Text = "Add"
        Me.btAdd.UseVisualStyleBackColor = True
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(12, 48)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(38, 13)
        Me.label2.TabIndex = 14
        Me.label2.Text = "Phone"
        '
        'tbPhone
        '
        Me.tbPhone.Location = New System.Drawing.Point(15, 64)
        Me.tbPhone.MaxLength = 15
        Me.tbPhone.Name = "tbPhone"
        Me.tbPhone.Size = New System.Drawing.Size(117, 20)
        Me.tbPhone.TabIndex = 13
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(12, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(35, 13)
        Me.label1.TabIndex = 12
        Me.label1.Text = "Name"
        '
        'tbName
        '
        Me.tbName.Location = New System.Drawing.Point(15, 25)
        Me.tbName.MaxLength = 20
        Me.tbName.Name = "tbName"
        Me.tbName.Size = New System.Drawing.Size(185, 20)
        Me.tbName.TabIndex = 11
        '
        'frmAddContact
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(238, 160)
        Me.Controls.Add(Me.btAdd)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.tbPhone)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.tbName)
        Me.Name = "frmAddContact"
        Me.Text = "Add Contact"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btAdd As System.Windows.Forms.Button
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents tbPhone As System.Windows.Forms.TextBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents tbName As System.Windows.Forms.TextBox
End Class
