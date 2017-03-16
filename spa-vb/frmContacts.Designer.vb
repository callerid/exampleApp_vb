<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContacts
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
        Me.dgvContacts = New System.Windows.Forms.DataGridView()
        CType(Me.dgvContacts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvContacts
        '
        Me.dgvContacts.AllowUserToAddRows = False
        Me.dgvContacts.AllowUserToDeleteRows = False
        Me.dgvContacts.AllowUserToResizeRows = False
        Me.dgvContacts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvContacts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvContacts.Location = New System.Drawing.Point(0, 0)
        Me.dgvContacts.Name = "dgvContacts"
        Me.dgvContacts.ReadOnly = True
        Me.dgvContacts.RowHeadersVisible = False
        Me.dgvContacts.Size = New System.Drawing.Size(490, 530)
        Me.dgvContacts.TabIndex = 1
        '
        'frmContacts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(490, 530)
        Me.Controls.Add(Me.dgvContacts)
        Me.Name = "frmContacts"
        Me.Text = "Contacts"
        CType(Me.dgvContacts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents dgvContacts As System.Windows.Forms.DataGridView
End Class
