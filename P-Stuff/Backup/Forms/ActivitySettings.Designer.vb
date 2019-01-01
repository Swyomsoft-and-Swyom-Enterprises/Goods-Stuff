<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ActivitySettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ActivitySettings))
        Me.lblASR = New System.Windows.Forms.Label
        Me.rdbYes = New System.Windows.Forms.RadioButton
        Me.rdbNo = New System.Windows.Forms.RadioButton
        Me.lbldt = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblASR
        '
        Me.lblASR.Font = New System.Drawing.Font("Comic Sans MS", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblASR.Location = New System.Drawing.Point(3, 21)
        Me.lblASR.Name = "lblASR"
        Me.lblASR.Size = New System.Drawing.Size(156, 27)
        Me.lblASR.TabIndex = 0
        Me.lblASR.Text = "Auto Save Result ::"
        '
        'rdbYes
        '
        Me.rdbYes.Checked = True
        Me.rdbYes.Location = New System.Drawing.Point(165, 22)
        Me.rdbYes.Name = "rdbYes"
        Me.rdbYes.Size = New System.Drawing.Size(50, 24)
        Me.rdbYes.TabIndex = 1
        Me.rdbYes.TabStop = True
        Me.rdbYes.Text = "True"
        Me.rdbYes.UseVisualStyleBackColor = True
        '
        'rdbNo
        '
        Me.rdbNo.Location = New System.Drawing.Point(230, 22)
        Me.rdbNo.Name = "rdbNo"
        Me.rdbNo.Size = New System.Drawing.Size(50, 24)
        Me.rdbNo.TabIndex = 2
        Me.rdbNo.Text = "False"
        Me.rdbNo.UseVisualStyleBackColor = True
        '
        'lbldt
        '
        Me.lbldt.BackColor = System.Drawing.Color.LightYellow
        Me.lbldt.Font = New System.Drawing.Font("Comic Sans MS", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldt.Location = New System.Drawing.Point(68, 65)
        Me.lbldt.Name = "lbldt"
        Me.lbldt.Size = New System.Drawing.Size(156, 27)
        Me.lbldt.TabIndex = 3
        '
        'ActivitySettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(296, 156)
        Me.Controls.Add(Me.lbldt)
        Me.Controls.Add(Me.rdbNo)
        Me.Controls.Add(Me.rdbYes)
        Me.Controls.Add(Me.lblASR)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ActivitySettings"
        Me.Text = "CSP Activity Settings"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblASR As System.Windows.Forms.Label
    Friend WithEvents rdbYes As System.Windows.Forms.RadioButton
    Friend WithEvents rdbNo As System.Windows.Forms.RadioButton
    Friend WithEvents lbldt As System.Windows.Forms.Label
End Class
