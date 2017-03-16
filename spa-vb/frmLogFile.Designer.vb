<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogFile
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
        Me.dgvLogFile = New System.Windows.Forms.DataGridView()
        CType(Me.dgvLogFile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvLogFile
        '
        Me.dgvLogFile.AllowUserToAddRows = False
        Me.dgvLogFile.AllowUserToDeleteRows = False
        Me.dgvLogFile.AllowUserToOrderColumns = True
        Me.dgvLogFile.AllowUserToResizeRows = False
        Me.dgvLogFile.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvLogFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLogFile.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLogFile.Location = New System.Drawing.Point(0, 0)
        Me.dgvLogFile.Name = "dgvLogFile"
        Me.dgvLogFile.ReadOnly = True
        Me.dgvLogFile.RowHeadersVisible = False
        Me.dgvLogFile.Size = New System.Drawing.Size(1046, 505)
        Me.dgvLogFile.TabIndex = 3
        '
        'frmLogFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1046, 505)
        Me.Controls.Add(Me.dgvLogFile)
        Me.Name = "frmLogFile"
        Me.Text = "Log File Database"
        CType(Me.dgvLogFile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents dgvLogFile As System.Windows.Forms.DataGridView
End Class
