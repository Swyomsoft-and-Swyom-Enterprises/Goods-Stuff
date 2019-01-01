<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Calculation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Calculation))
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOk = New System.Windows.Forms.Button
        Me.gbCalC = New System.Windows.Forms.GroupBox
        Me.btnAns = New System.Windows.Forms.Button
        Me.txtValue = New System.Windows.Forms.TextBox
        Me.lblValue = New System.Windows.Forms.Label
        Me.gbTabs = New System.Windows.Forms.GroupBox
        Me.btnOk1 = New System.Windows.Forms.Button
        Me.gbCalC.SuspendLayout()
        Me.gbTabs.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.LightPink
        Me.btnCancel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(72, 13)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.Color.MediumSpringGreen
        Me.btnOk.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Location = New System.Drawing.Point(6, 13)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(62, 23)
        Me.btnOk.TabIndex = 1
        Me.btnOk.Text = "&Ok"
        Me.btnOk.UseVisualStyleBackColor = False
        '
        'gbCalC
        '
        Me.gbCalC.Controls.Add(Me.btnAns)
        Me.gbCalC.Controls.Add(Me.txtValue)
        Me.gbCalC.Controls.Add(Me.lblValue)
        Me.gbCalC.Location = New System.Drawing.Point(7, 0)
        Me.gbCalC.Name = "gbCalC"
        Me.gbCalC.Size = New System.Drawing.Size(200, 73)
        Me.gbCalC.TabIndex = 4
        Me.gbCalC.TabStop = False
        Me.gbCalC.Text = "Calculation"
        '
        'btnAns
        '
        Me.btnAns.BackColor = System.Drawing.Color.Lavender
        Me.btnAns.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAns.Location = New System.Drawing.Point(123, 45)
        Me.btnAns.Name = "btnAns"
        Me.btnAns.Size = New System.Drawing.Size(62, 23)
        Me.btnAns.TabIndex = 4
        Me.btnAns.Text = "&Ans"
        Me.btnAns.UseVisualStyleBackColor = False
        '
        'txtValue
        '
        Me.txtValue.Location = New System.Drawing.Point(82, 20)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(103, 20)
        Me.txtValue.TabIndex = 0
        '
        'lblValue
        '
        Me.lblValue.Font = New System.Drawing.Font("RomanD", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValue.Location = New System.Drawing.Point(6, 16)
        Me.lblValue.Name = "lblValue"
        Me.lblValue.Size = New System.Drawing.Size(73, 26)
        Me.lblValue.TabIndex = 3
        Me.lblValue.Text = "value"
        Me.lblValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbTabs
        '
        Me.gbTabs.Controls.Add(Me.btnOk1)
        Me.gbTabs.Controls.Add(Me.btnOk)
        Me.gbTabs.Controls.Add(Me.btnCancel)
        Me.gbTabs.Location = New System.Drawing.Point(75, 74)
        Me.gbTabs.Name = "gbTabs"
        Me.gbTabs.Size = New System.Drawing.Size(142, 40)
        Me.gbTabs.TabIndex = 5
        Me.gbTabs.TabStop = False
        '
        'btnOk1
        '
        Me.btnOk1.BackColor = System.Drawing.Color.MediumSpringGreen
        Me.btnOk1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk1.Location = New System.Drawing.Point(6, 13)
        Me.btnOk1.Name = "btnOk1"
        Me.btnOk1.Size = New System.Drawing.Size(62, 23)
        Me.btnOk1.TabIndex = 3
        Me.btnOk1.Text = "&Ok"
        Me.btnOk1.UseVisualStyleBackColor = False
        '
        'Calculation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LavenderBlush
        Me.ClientSize = New System.Drawing.Size(219, 115)
        Me.ControlBox = False
        Me.Controls.Add(Me.gbTabs)
        Me.Controls.Add(Me.gbCalC)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Calculation"
        Me.Opacity = 0.9
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Calculation"
        Me.TopMost = True
        Me.gbCalC.ResumeLayout(False)
        Me.gbCalC.PerformLayout()
        Me.gbTabs.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents gbCalC As System.Windows.Forms.GroupBox
    Friend WithEvents txtValue As System.Windows.Forms.TextBox
    Friend WithEvents lblValue As System.Windows.Forms.Label
    Friend WithEvents gbTabs As System.Windows.Forms.GroupBox
    Friend WithEvents btnAns As System.Windows.Forms.Button
    Friend WithEvents btnOk1 As System.Windows.Forms.Button
End Class
