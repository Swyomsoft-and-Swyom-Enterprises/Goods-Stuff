<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Progress8
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
        Me.btnStatus = New System.Windows.Forms.Button
        Me.GbUpdbsChng = New System.Windows.Forms.GroupBox
        Me.lblPwdOld = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.btnChngPwd = New System.Windows.Forms.Button
        Me.lblPwdNew = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnDone = New System.Windows.Forms.Button
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.GbUpdbsChng.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnStatus
        '
        Me.btnStatus.Location = New System.Drawing.Point(138, 101)
        Me.btnStatus.Name = "btnStatus"
        Me.btnStatus.Size = New System.Drawing.Size(45, 27)
        Me.btnStatus.TabIndex = 100
        Me.btnStatus.Text = "Ok"
        Me.btnStatus.UseVisualStyleBackColor = True
        '
        'GbUpdbsChng
        '
        Me.GbUpdbsChng.BackColor = System.Drawing.Color.OldLace
        Me.GbUpdbsChng.Controls.Add(Me.lblPwdOld)
        Me.GbUpdbsChng.Controls.Add(Me.Button2)
        Me.GbUpdbsChng.Controls.Add(Me.TextBox1)
        Me.GbUpdbsChng.Controls.Add(Me.btnChngPwd)
        Me.GbUpdbsChng.Controls.Add(Me.lblPwdNew)
        Me.GbUpdbsChng.Controls.Add(Me.btnCancel)
        Me.GbUpdbsChng.Controls.Add(Me.btnDone)
        Me.GbUpdbsChng.Controls.Add(Me.txtPassword)
        Me.GbUpdbsChng.Location = New System.Drawing.Point(35, 12)
        Me.GbUpdbsChng.Name = "GbUpdbsChng"
        Me.GbUpdbsChng.Size = New System.Drawing.Size(259, 101)
        Me.GbUpdbsChng.TabIndex = 131
        Me.GbUpdbsChng.TabStop = False
        Me.GbUpdbsChng.Tag = "Change Password"
        Me.GbUpdbsChng.Text = "Change Password"
        '
        'lblPwdOld
        '
        Me.lblPwdOld.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lblPwdOld.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPwdOld.Location = New System.Drawing.Point(6, 21)
        Me.lblPwdOld.Name = "lblPwdOld"
        Me.lblPwdOld.Size = New System.Drawing.Size(90, 23)
        Me.lblPwdOld.TabIndex = 7
        Me.lblPwdOld.Text = "Old Password"
        Me.lblPwdOld.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button2.Location = New System.Drawing.Point(199, 21)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(54, 23)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Ok"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.TextBox1.Location = New System.Drawing.Point(102, 22)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox1.Size = New System.Drawing.Size(85, 21)
        Me.TextBox1.TabIndex = 5
        '
        'btnChngPwd
        '
        Me.btnChngPwd.BackColor = System.Drawing.Color.Khaki
        Me.btnChngPwd.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnChngPwd.Location = New System.Drawing.Point(9, 76)
        Me.btnChngPwd.Name = "btnChngPwd"
        Me.btnChngPwd.Size = New System.Drawing.Size(108, 23)
        Me.btnChngPwd.TabIndex = 4
        Me.btnChngPwd.Text = "Change password"
        Me.btnChngPwd.UseVisualStyleBackColor = False
        '
        'lblPwdNew
        '
        Me.lblPwdNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lblPwdNew.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPwdNew.Location = New System.Drawing.Point(6, 47)
        Me.lblPwdNew.Name = "lblPwdNew"
        Me.lblPwdNew.Size = New System.Drawing.Size(90, 23)
        Me.lblPwdNew.TabIndex = 3
        Me.lblPwdNew.Text = "New Password"
        Me.lblPwdNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancel.Location = New System.Drawing.Point(145, 76)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(108, 23)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnDone
        '
        Me.btnDone.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnDone.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnDone.Location = New System.Drawing.Point(199, 47)
        Me.btnDone.Name = "btnDone"
        Me.btnDone.Size = New System.Drawing.Size(54, 23)
        Me.btnDone.TabIndex = 1
        Me.btnDone.Text = "Ok"
        Me.btnDone.UseVisualStyleBackColor = False
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.txtPassword.Location = New System.Drawing.Point(102, 48)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(85, 21)
        Me.txtPassword.TabIndex = 0
        '
        'Progress8
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(340, 131)
        Me.Controls.Add(Me.GbUpdbsChng)
        Me.Controls.Add(Me.btnStatus)
        Me.Name = "Progress8"
        Me.Text = "Progress8"
        Me.GbUpdbsChng.ResumeLayout(False)
        Me.GbUpdbsChng.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnStatus As System.Windows.Forms.Button
    Friend WithEvents GbUpdbsChng As System.Windows.Forms.GroupBox
    Friend WithEvents lblPwdOld As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents btnChngPwd As System.Windows.Forms.Button
    Friend WithEvents lblPwdNew As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnDone As System.Windows.Forms.Button
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
End Class
