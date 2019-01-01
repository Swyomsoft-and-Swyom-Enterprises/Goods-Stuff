<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class usProgress
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.PbUC = New System.Windows.Forms.ProgressBar
        Me.lblClose1 = New System.Windows.Forms.Label
        Me.btnExit = New System.Windows.Forms.Button
        Me.lblProgress = New System.Windows.Forms.Label
        Me.lblClose2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'PbUC
        '
        Me.PbUC.Location = New System.Drawing.Point(12, 88)
        Me.PbUC.Name = "PbUC"
        Me.PbUC.Size = New System.Drawing.Size(398, 13)
        Me.PbUC.TabIndex = 0
        '
        'lblClose1
        '
        Me.lblClose1.AutoSize = True
        Me.lblClose1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClose1.ForeColor = System.Drawing.Color.Red
        Me.lblClose1.Location = New System.Drawing.Point(394, 0)
        Me.lblClose1.Name = "lblClose1"
        Me.lblClose1.Size = New System.Drawing.Size(27, 25)
        Me.lblClose1.TabIndex = 1
        Me.lblClose1.Text = "&X"
        Me.lblClose1.Visible = False
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(344, 108)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "&Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'lblProgress
        '
        Me.lblProgress.AutoSize = True
        Me.lblProgress.Location = New System.Drawing.Point(19, 33)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(0, 13)
        Me.lblProgress.TabIndex = 3
        '
        'lblClose2
        '
        Me.lblClose2.AutoSize = True
        Me.lblClose2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClose2.Location = New System.Drawing.Point(400, 9)
        Me.lblClose2.Name = "lblClose2"
        Me.lblClose2.Size = New System.Drawing.Size(15, 13)
        Me.lblClose2.TabIndex = 4
        Me.lblClose2.Text = "&X"
        Me.lblClose2.Visible = False
        '
        'usProgress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Info
        Me.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Controls.Add(Me.lblClose2)
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.lblClose1)
        Me.Controls.Add(Me.PbUC)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Name = "usProgress"
        Me.Size = New System.Drawing.Size(418, 130)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PbUC As System.Windows.Forms.ProgressBar
    Friend WithEvents lblClose1 As System.Windows.Forms.Label
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents lblProgress As System.Windows.Forms.Label
    Friend WithEvents lblClose2 As System.Windows.Forms.Label

End Class
