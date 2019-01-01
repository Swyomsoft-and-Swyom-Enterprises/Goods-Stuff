<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTrial
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTrial))
        Me.DgvTrial = New System.Windows.Forms.DataGridView
        Me.btnExit = New System.Windows.Forms.Button
        Me.TrialShow = New System.Windows.Forms.Button
        Me.btnStop = New System.Windows.Forms.Button
        Me.chkbxCompactShow = New System.Windows.Forms.CheckBox
        Me.chkbxQuickShow = New System.Windows.Forms.CheckBox
        Me.chkbxStepTrials = New System.Windows.Forms.CheckBox
        Me.gbTrialOpt = New System.Windows.Forms.GroupBox
        CType(Me.DgvTrial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTrialOpt.SuspendLayout()
        Me.SuspendLayout()
        '
        'DgvTrial
        '
        Me.DgvTrial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgvTrial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTrial.Location = New System.Drawing.Point(12, 12)
        Me.DgvTrial.Name = "DgvTrial"
        Me.DgvTrial.Size = New System.Drawing.Size(405, 99)
        Me.DgvTrial.TabIndex = 0
        '
        'btnExit
        '
        Me.btnExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExit.Location = New System.Drawing.Point(274, 148)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(65, 25)
        Me.btnExit.TabIndex = 1
        Me.btnExit.Text = "&Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'TrialShow
        '
        Me.TrialShow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TrialShow.Location = New System.Drawing.Point(205, 88)
        Me.TrialShow.Name = "TrialShow"
        Me.TrialShow.Size = New System.Drawing.Size(56, 23)
        Me.TrialShow.TabIndex = 2
        Me.TrialShow.Text = "Show"
        Me.TrialShow.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.TrialShow.UseVisualStyleBackColor = True
        Me.TrialShow.Visible = False
        '
        'btnStop
        '
        Me.btnStop.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStop.Location = New System.Drawing.Point(274, 124)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(65, 23)
        Me.btnStop.TabIndex = 3
        Me.btnStop.Text = "&Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'chkbxCompactShow
        '
        Me.chkbxCompactShow.AutoSize = True
        Me.chkbxCompactShow.Location = New System.Drawing.Point(96, 14)
        Me.chkbxCompactShow.Name = "chkbxCompactShow"
        Me.chkbxCompactShow.Size = New System.Drawing.Size(98, 17)
        Me.chkbxCompactShow.TabIndex = 4
        Me.chkbxCompactShow.Text = "&Compact Show"
        Me.chkbxCompactShow.UseVisualStyleBackColor = True
        '
        'chkbxQuickShow
        '
        Me.chkbxQuickShow.AutoSize = True
        Me.chkbxQuickShow.Checked = True
        Me.chkbxQuickShow.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkbxQuickShow.Location = New System.Drawing.Point(6, 14)
        Me.chkbxQuickShow.Name = "chkbxQuickShow"
        Me.chkbxQuickShow.Size = New System.Drawing.Size(84, 17)
        Me.chkbxQuickShow.TabIndex = 5
        Me.chkbxQuickShow.Text = "&Quick Show"
        Me.chkbxQuickShow.UseVisualStyleBackColor = True
        '
        'chkbxStepTrials
        '
        Me.chkbxStepTrials.AutoSize = True
        Me.chkbxStepTrials.Enabled = False
        Me.chkbxStepTrials.Location = New System.Drawing.Point(6, 37)
        Me.chkbxStepTrials.Name = "chkbxStepTrials"
        Me.chkbxStepTrials.Size = New System.Drawing.Size(78, 17)
        Me.chkbxStepTrials.TabIndex = 6
        Me.chkbxStepTrials.Text = "Step Trial's"
        Me.chkbxStepTrials.UseVisualStyleBackColor = True
        '
        'gbTrialOpt
        '
        Me.gbTrialOpt.Controls.Add(Me.chkbxQuickShow)
        Me.gbTrialOpt.Controls.Add(Me.chkbxStepTrials)
        Me.gbTrialOpt.Controls.Add(Me.chkbxCompactShow)
        Me.gbTrialOpt.Location = New System.Drawing.Point(12, 114)
        Me.gbTrialOpt.Name = "gbTrialOpt"
        Me.gbTrialOpt.Size = New System.Drawing.Size(206, 59)
        Me.gbTrialOpt.TabIndex = 7
        Me.gbTrialOpt.TabStop = False
        Me.gbTrialOpt.Text = "Trial Option"
        '
        'frmTrial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(342, 176)
        Me.Controls.Add(Me.gbTrialOpt)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.TrialShow)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.DgvTrial)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(350, 210)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(350, 200)
        Me.Name = "frmTrial"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Trial Stuff's"
        Me.TopMost = True
        CType(Me.DgvTrial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbTrialOpt.ResumeLayout(False)
        Me.gbTrialOpt.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DgvTrial As System.Windows.Forms.DataGridView
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents TrialShow As System.Windows.Forms.Button
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents chkbxCompactShow As System.Windows.Forms.CheckBox
    Friend WithEvents chkbxQuickShow As System.Windows.Forms.CheckBox
    Friend WithEvents chkbxStepTrials As System.Windows.Forms.CheckBox
    Friend WithEvents gbTrialOpt As System.Windows.Forms.GroupBox
End Class
