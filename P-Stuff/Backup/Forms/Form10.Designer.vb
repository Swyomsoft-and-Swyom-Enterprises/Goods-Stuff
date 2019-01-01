<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form10
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form10))
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.Button1 = New System.Windows.Forms.Button
        Me.grpBx = New System.Windows.Forms.GroupBox
        Me.cmdExit = New System.Windows.Forms.Button
        Me.gbxPbr = New System.Windows.Forms.GroupBox
        Me.lblpbDirct = New System.Windows.Forms.Label
        Me.ImgArows = New System.Windows.Forms.ImageList(Me.components)
        Me.btnPBrChng = New System.Windows.Forms.Button
        Me.rdbMarquee = New System.Windows.Forms.RadioButton
        Me.rdbContinuous = New System.Windows.Forms.RadioButton
        Me.rdbBlocks = New System.Windows.Forms.RadioButton
        Me.tbcSelectOption = New System.Windows.Forms.TabControl
        Me.tbpg2DLayout = New System.Windows.Forms.TabPage
        Me.tbpgProgressbar = New System.Windows.Forms.TabPage
        Me.tbpgDatatie = New System.Windows.Forms.TabPage
        Me.btnSetlink = New System.Windows.Forms.Button
        Me.btnselectlink = New System.Windows.Forms.Button
        Me.lblLink = New System.Windows.Forms.Label
        Me.txtDatatieLink = New System.Windows.Forms.TextBox
        Me.cmdSysInfo = New System.Windows.Forms.Button
        Me.grpBx.SuspendLayout()
        Me.gbxPbr.SuspendLayout()
        Me.tbcSelectOption.SuspendLayout()
        Me.tbpg2DLayout.SuspendLayout()
        Me.tbpgProgressbar.SuspendLayout()
        Me.tbpgDatatie.SuspendLayout()
        Me.SuspendLayout()
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(30, 19)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(84, 17)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Color Layout"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(30, 40)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(83, 17)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "Plain Layout"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(30, 63)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Change Layout"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'grpBx
        '
        Me.grpBx.Controls.Add(Me.Button1)
        Me.grpBx.Controls.Add(Me.RadioButton2)
        Me.grpBx.Controls.Add(Me.RadioButton1)
        Me.grpBx.Location = New System.Drawing.Point(6, 6)
        Me.grpBx.Name = "grpBx"
        Me.grpBx.Size = New System.Drawing.Size(144, 94)
        Me.grpBx.TabIndex = 3
        Me.grpBx.TabStop = False
        Me.grpBx.Text = "2D Layout"
        '
        'cmdExit
        '
        Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdExit.Location = New System.Drawing.Point(130, 151)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(75, 23)
        Me.cmdExit.TabIndex = 4
        Me.cmdExit.Text = "&Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'gbxPbr
        '
        Me.gbxPbr.Controls.Add(Me.lblpbDirct)
        Me.gbxPbr.Controls.Add(Me.btnPBrChng)
        Me.gbxPbr.Controls.Add(Me.rdbMarquee)
        Me.gbxPbr.Controls.Add(Me.rdbContinuous)
        Me.gbxPbr.Controls.Add(Me.rdbBlocks)
        Me.gbxPbr.Location = New System.Drawing.Point(6, 6)
        Me.gbxPbr.Name = "gbxPbr"
        Me.gbxPbr.Size = New System.Drawing.Size(168, 94)
        Me.gbxPbr.TabIndex = 5
        Me.gbxPbr.TabStop = False
        Me.gbxPbr.Text = "Progress bar"
        '
        'lblpbDirct
        '
        Me.lblpbDirct.BackColor = System.Drawing.Color.Pink
        Me.lblpbDirct.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblpbDirct.ImageIndex = 1
        Me.lblpbDirct.ImageList = Me.ImgArows
        Me.lblpbDirct.Location = New System.Drawing.Point(119, 16)
        Me.lblpbDirct.Name = "lblpbDirct"
        Me.lblpbDirct.Size = New System.Drawing.Size(33, 30)
        Me.lblpbDirct.TabIndex = 6
        '
        'ImgArows
        '
        Me.ImgArows.ImageStream = CType(resources.GetObject("ImgArows.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImgArows.TransparentColor = System.Drawing.Color.Transparent
        Me.ImgArows.Images.SetKeyName(0, "arowR.PNG")
        Me.ImgArows.Images.SetKeyName(1, "arowL.PNG")
        '
        'btnPBrChng
        '
        Me.btnPBrChng.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPBrChng.Location = New System.Drawing.Point(87, 63)
        Me.btnPBrChng.Name = "btnPBrChng"
        Me.btnPBrChng.Size = New System.Drawing.Size(75, 23)
        Me.btnPBrChng.TabIndex = 6
        Me.btnPBrChng.Text = "Change Bar"
        Me.btnPBrChng.UseVisualStyleBackColor = True
        '
        'rdbMarquee
        '
        Me.rdbMarquee.AutoSize = True
        Me.rdbMarquee.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rdbMarquee.Location = New System.Drawing.Point(17, 63)
        Me.rdbMarquee.Name = "rdbMarquee"
        Me.rdbMarquee.Size = New System.Drawing.Size(67, 17)
        Me.rdbMarquee.TabIndex = 8
        Me.rdbMarquee.Text = "Marquee"
        Me.rdbMarquee.UseVisualStyleBackColor = True
        '
        'rdbContinuous
        '
        Me.rdbContinuous.AutoSize = True
        Me.rdbContinuous.Checked = True
        Me.rdbContinuous.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rdbContinuous.Location = New System.Drawing.Point(17, 40)
        Me.rdbContinuous.Name = "rdbContinuous"
        Me.rdbContinuous.Size = New System.Drawing.Size(78, 17)
        Me.rdbContinuous.TabIndex = 7
        Me.rdbContinuous.TabStop = True
        Me.rdbContinuous.Text = "Continuous"
        Me.rdbContinuous.UseVisualStyleBackColor = True
        '
        'rdbBlocks
        '
        Me.rdbBlocks.AutoSize = True
        Me.rdbBlocks.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rdbBlocks.Location = New System.Drawing.Point(17, 17)
        Me.rdbBlocks.Name = "rdbBlocks"
        Me.rdbBlocks.Size = New System.Drawing.Size(57, 17)
        Me.rdbBlocks.TabIndex = 6
        Me.rdbBlocks.Text = "Blocks"
        Me.rdbBlocks.UseVisualStyleBackColor = True
        '
        'tbcSelectOption
        '
        Me.tbcSelectOption.Controls.Add(Me.tbpg2DLayout)
        Me.tbcSelectOption.Controls.Add(Me.tbpgProgressbar)
        Me.tbcSelectOption.Controls.Add(Me.tbpgDatatie)
        Me.tbcSelectOption.Location = New System.Drawing.Point(12, 12)
        Me.tbcSelectOption.Name = "tbcSelectOption"
        Me.tbcSelectOption.SelectedIndex = 0
        Me.tbcSelectOption.Size = New System.Drawing.Size(205, 133)
        Me.tbcSelectOption.TabIndex = 6
        '
        'tbpg2DLayout
        '
        Me.tbpg2DLayout.Controls.Add(Me.grpBx)
        Me.tbpg2DLayout.Location = New System.Drawing.Point(4, 22)
        Me.tbpg2DLayout.Name = "tbpg2DLayout"
        Me.tbpg2DLayout.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpg2DLayout.Size = New System.Drawing.Size(197, 107)
        Me.tbpg2DLayout.TabIndex = 0
        Me.tbpg2DLayout.Text = "2D Layout"
        Me.tbpg2DLayout.UseVisualStyleBackColor = True
        '
        'tbpgProgressbar
        '
        Me.tbpgProgressbar.Controls.Add(Me.gbxPbr)
        Me.tbpgProgressbar.Location = New System.Drawing.Point(4, 22)
        Me.tbpgProgressbar.Name = "tbpgProgressbar"
        Me.tbpgProgressbar.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpgProgressbar.Size = New System.Drawing.Size(197, 107)
        Me.tbpgProgressbar.TabIndex = 1
        Me.tbpgProgressbar.Text = "Progress bar"
        Me.tbpgProgressbar.UseVisualStyleBackColor = True
        '
        'tbpgDatatie
        '
        Me.tbpgDatatie.Controls.Add(Me.btnSetlink)
        Me.tbpgDatatie.Controls.Add(Me.btnselectlink)
        Me.tbpgDatatie.Controls.Add(Me.lblLink)
        Me.tbpgDatatie.Controls.Add(Me.txtDatatieLink)
        Me.tbpgDatatie.Location = New System.Drawing.Point(4, 22)
        Me.tbpgDatatie.Name = "tbpgDatatie"
        Me.tbpgDatatie.Size = New System.Drawing.Size(197, 107)
        Me.tbpgDatatie.TabIndex = 2
        Me.tbpgDatatie.Text = "Data tie"
        Me.tbpgDatatie.UseVisualStyleBackColor = True
        '
        'btnSetlink
        '
        Me.btnSetlink.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSetlink.Location = New System.Drawing.Point(108, 69)
        Me.btnSetlink.Name = "btnSetlink"
        Me.btnSetlink.Size = New System.Drawing.Size(75, 23)
        Me.btnSetlink.TabIndex = 3
        Me.btnSetlink.Text = "Set Link"
        Me.btnSetlink.UseVisualStyleBackColor = True
        '
        'btnselectlink
        '
        Me.btnselectlink.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnselectlink.Location = New System.Drawing.Point(17, 69)
        Me.btnselectlink.Name = "btnselectlink"
        Me.btnselectlink.Size = New System.Drawing.Size(75, 23)
        Me.btnselectlink.TabIndex = 2
        Me.btnselectlink.Text = "Select Link"
        Me.btnselectlink.UseVisualStyleBackColor = True
        '
        'lblLink
        '
        Me.lblLink.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLink.Location = New System.Drawing.Point(3, 29)
        Me.lblLink.Name = "lblLink"
        Me.lblLink.Size = New System.Drawing.Size(31, 17)
        Me.lblLink.TabIndex = 1
        Me.lblLink.Text = "Link"
        '
        'txtDatatieLink
        '
        Me.txtDatatieLink.Location = New System.Drawing.Point(40, 27)
        Me.txtDatatieLink.Name = "txtDatatieLink"
        Me.txtDatatieLink.Size = New System.Drawing.Size(149, 20)
        Me.txtDatatieLink.TabIndex = 0
        '
        'cmdSysInfo
        '
        Me.cmdSysInfo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdSysInfo.Location = New System.Drawing.Point(16, 151)
        Me.cmdSysInfo.Name = "cmdSysInfo"
        Me.cmdSysInfo.Size = New System.Drawing.Size(71, 23)
        Me.cmdSysInfo.TabIndex = 7
        Me.cmdSysInfo.Text = "System Info"
        Me.cmdSysInfo.UseVisualStyleBackColor = True
        '
        'Form10
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(229, 179)
        Me.Controls.Add(Me.cmdSysInfo)
        Me.Controls.Add(Me.tbcSelectOption)
        Me.Controls.Add(Me.cmdExit)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(237, 213)
        Me.MinimumSize = New System.Drawing.Size(237, 213)
        Me.Name = "Form10"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Option"
        Me.grpBx.ResumeLayout(False)
        Me.grpBx.PerformLayout()
        Me.gbxPbr.ResumeLayout(False)
        Me.gbxPbr.PerformLayout()
        Me.tbcSelectOption.ResumeLayout(False)
        Me.tbpg2DLayout.ResumeLayout(False)
        Me.tbpgProgressbar.ResumeLayout(False)
        Me.tbpgDatatie.ResumeLayout(False)
        Me.tbpgDatatie.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents grpBx As System.Windows.Forms.GroupBox
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents gbxPbr As System.Windows.Forms.GroupBox
    Friend WithEvents rdbMarquee As System.Windows.Forms.RadioButton
    Friend WithEvents rdbContinuous As System.Windows.Forms.RadioButton
    Friend WithEvents rdbBlocks As System.Windows.Forms.RadioButton
    Friend WithEvents btnPBrChng As System.Windows.Forms.Button
    Friend WithEvents tbcSelectOption As System.Windows.Forms.TabControl
    Friend WithEvents tbpg2DLayout As System.Windows.Forms.TabPage
    Friend WithEvents tbpgProgressbar As System.Windows.Forms.TabPage
    Friend WithEvents lblpbDirct As System.Windows.Forms.Label
    Friend WithEvents ImgArows As System.Windows.Forms.ImageList
    Friend WithEvents tbpgDatatie As System.Windows.Forms.TabPage
    Friend WithEvents txtDatatieLink As System.Windows.Forms.TextBox
    Friend WithEvents btnSetlink As System.Windows.Forms.Button
    Friend WithEvents btnselectlink As System.Windows.Forms.Button
    Friend WithEvents lblLink As System.Windows.Forms.Label
    Friend WithEvents cmdSysInfo As System.Windows.Forms.Button
End Class
