<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStep
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStep))
        Me.btnExit = New System.Windows.Forms.Button
        Me.DgvDisplaySteps = New System.Windows.Forms.DataGridView
        Me.StepShow = New System.Windows.Forms.Button
        CType(Me.DgvDisplaySteps, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(119, 226)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 0
        Me.btnExit.Text = "&Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'DgvDisplaySteps
        '
        Me.DgvDisplaySteps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvDisplaySteps.Location = New System.Drawing.Point(12, 12)
        Me.DgvDisplaySteps.Name = "DgvDisplaySteps"
        Me.DgvDisplaySteps.Size = New System.Drawing.Size(172, 208)
        Me.DgvDisplaySteps.TabIndex = 1
        '
        'StepShow
        '
        Me.StepShow.Location = New System.Drawing.Point(109, 186)
        Me.StepShow.Name = "StepShow"
        Me.StepShow.Size = New System.Drawing.Size(75, 23)
        Me.StepShow.TabIndex = 2
        Me.StepShow.Text = "Show"
        Me.StepShow.UseVisualStyleBackColor = True
        Me.StepShow.Visible = False
        '
        'frmStep
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(196, 250)
        Me.Controls.Add(Me.StepShow)
        Me.Controls.Add(Me.DgvDisplaySteps)
        Me.Controls.Add(Me.btnExit)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(204, 284)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(204, 284)
        Me.Name = "frmStep"
        Me.Text = "Display Step's "
        CType(Me.DgvDisplaySteps, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents DgvDisplaySteps As System.Windows.Forms.DataGridView
    Friend WithEvents StepShow As System.Windows.Forms.Button
End Class
