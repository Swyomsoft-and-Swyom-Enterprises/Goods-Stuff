<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUpdtData
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUpdtData))
        Me.GbUpdbs = New System.Windows.Forms.GroupBox
        Me.btnChngPwd = New System.Windows.Forms.Button
        Me.lblPwd = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnUpdate = New System.Windows.Forms.Button
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.PrgBrs = New System.Windows.Forms.ProgressBar
        Me.GbUpdbs.SuspendLayout()
        Me.SuspendLayout()
        '
        'GbUpdbs
        '
        Me.GbUpdbs.BackColor = System.Drawing.Color.OldLace
        Me.GbUpdbs.Controls.Add(Me.btnChngPwd)
        Me.GbUpdbs.Controls.Add(Me.lblPwd)
        Me.GbUpdbs.Controls.Add(Me.btnCancel)
        Me.GbUpdbs.Controls.Add(Me.btnUpdate)
        Me.GbUpdbs.Controls.Add(Me.txtPassword)
        Me.GbUpdbs.Location = New System.Drawing.Point(12, 12)
        Me.GbUpdbs.Name = "GbUpdbs"
        Me.GbUpdbs.Size = New System.Drawing.Size(259, 105)
        Me.GbUpdbs.TabIndex = 0
        Me.GbUpdbs.TabStop = False
        Me.GbUpdbs.Tag = "Update Task"
        Me.GbUpdbs.Text = "Update Task"
        '
        'btnChngPwd
        '
        Me.btnChngPwd.BackColor = System.Drawing.Color.Khaki
        Me.btnChngPwd.Location = New System.Drawing.Point(9, 76)
        Me.btnChngPwd.Name = "btnChngPwd"
        Me.btnChngPwd.Size = New System.Drawing.Size(108, 23)
        Me.btnChngPwd.TabIndex = 4
        Me.btnChngPwd.Text = "Change password"
        Me.btnChngPwd.UseVisualStyleBackColor = False
        Me.btnChngPwd.Visible = False
        '
        'lblPwd
        '
        Me.lblPwd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPwd.Location = New System.Drawing.Point(6, 37)
        Me.lblPwd.Name = "lblPwd"
        Me.lblPwd.Size = New System.Drawing.Size(64, 23)
        Me.lblPwd.TabIndex = 3
        Me.lblPwd.Text = "Password"
        Me.lblPwd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnCancel.Location = New System.Drawing.Point(145, 76)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(108, 23)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnUpdate.Location = New System.Drawing.Point(172, 37)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(81, 23)
        Me.btnUpdate.TabIndex = 1
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(76, 38)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(85, 21)
        Me.txtPassword.TabIndex = 0
        '
        'PrgBrs
        '
        Me.PrgBrs.ForeColor = System.Drawing.Color.Firebrick
        Me.PrgBrs.Location = New System.Drawing.Point(12, 131)
        Me.PrgBrs.Name = "PrgBrs"
        Me.PrgBrs.Size = New System.Drawing.Size(259, 10)
        Me.PrgBrs.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.PrgBrs.TabIndex = 1
        Me.PrgBrs.Visible = False
        '
        'frmUpdtData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightCyan
        Me.ClientSize = New System.Drawing.Size(282, 146)
        Me.Controls.Add(Me.PrgBrs)
        Me.Controls.Add(Me.GbUpdbs)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUpdtData"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Update Database"
        Me.GbUpdbs.ResumeLayout(False)
        Me.GbUpdbs.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GbUpdbs As System.Windows.Forms.GroupBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents lblPwd As System.Windows.Forms.Label
    Friend WithEvents PrgBrs As System.Windows.Forms.ProgressBar
    Friend WithEvents btnChngPwd As System.Windows.Forms.Button
End Class
