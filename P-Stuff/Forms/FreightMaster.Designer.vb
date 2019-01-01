<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FreightMaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FreightMaster))
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.cmdEdit = New System.Windows.Forms.Button
        Me.cmdDel = New System.Windows.Forms.Button
        Me.cmdUpdate = New System.Windows.Forms.Button
        Me.cmdRef = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdFirst = New System.Windows.Forms.Button
        Me.cmdNext = New System.Windows.Forms.Button
        Me.cmdPrev = New System.Windows.Forms.Button
        Me.cmdLast = New System.Windows.Forms.Button
        Me.cmdFind = New System.Windows.Forms.Button
        Me.FreightDetails = New System.Windows.Forms.GroupBox
        Me.txtfreight = New System.Windows.Forms.TextBox
        Me.txtfreightid = New System.Windows.Forms.TextBox
        Me.lblfreightid = New System.Windows.Forms.Label
        Me.lblfreight = New System.Windows.Forms.Label
        Me.CmbCountry = New System.Windows.Forms.ComboBox
        Me.lblcountry = New System.Windows.Forms.Label
        Me.cmdHelp = New System.Windows.Forms.Button
        Me.ColDlgFM = New System.Windows.Forms.ColorDialog
        Me.FreightDetails.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdAdd
        '
        Me.cmdAdd.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdAdd.ForeColor = System.Drawing.Color.Black
        Me.cmdAdd.Image = CType(resources.GetObject("cmdAdd.Image"), System.Drawing.Image)
        Me.cmdAdd.Location = New System.Drawing.Point(6, 4)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(54, 45)
        Me.cmdAdd.TabIndex = 0
        Me.cmdAdd.Text = "&Add"
        Me.cmdAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdAdd.UseCompatibleTextRendering = True
        Me.cmdAdd.UseVisualStyleBackColor = False
        '
        'cmdEdit
        '
        Me.cmdEdit.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdEdit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdEdit.ForeColor = System.Drawing.Color.Black
        Me.cmdEdit.Image = CType(resources.GetObject("cmdEdit.Image"), System.Drawing.Image)
        Me.cmdEdit.Location = New System.Drawing.Point(59, 4)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(54, 45)
        Me.cmdEdit.TabIndex = 5
        Me.cmdEdit.Text = "&Edit"
        Me.cmdEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdEdit.UseCompatibleTextRendering = True
        Me.cmdEdit.UseVisualStyleBackColor = False
        '
        'cmdDel
        '
        Me.cmdDel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdDel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdDel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdDel.ForeColor = System.Drawing.Color.Black
        Me.cmdDel.Image = CType(resources.GetObject("cmdDel.Image"), System.Drawing.Image)
        Me.cmdDel.Location = New System.Drawing.Point(112, 4)
        Me.cmdDel.Name = "cmdDel"
        Me.cmdDel.Size = New System.Drawing.Size(54, 45)
        Me.cmdDel.TabIndex = 6
        Me.cmdDel.Text = "&Delete"
        Me.cmdDel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdDel.UseCompatibleTextRendering = True
        Me.cmdDel.UseVisualStyleBackColor = False
        '
        'cmdUpdate
        '
        Me.cmdUpdate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdUpdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdUpdate.Image = CType(resources.GetObject("cmdUpdate.Image"), System.Drawing.Image)
        Me.cmdUpdate.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdUpdate.Location = New System.Drawing.Point(357, 230)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(87, 45)
        Me.cmdUpdate.TabIndex = 3
        Me.cmdUpdate.Text = "&Update "
        Me.cmdUpdate.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdUpdate.UseCompatibleTextRendering = True
        Me.cmdUpdate.UseVisualStyleBackColor = False
        '
        'cmdRef
        '
        Me.cmdRef.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdRef.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdRef.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdRef.Image = CType(resources.GetObject("cmdRef.Image"), System.Drawing.Image)
        Me.cmdRef.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdRef.Location = New System.Drawing.Point(450, 230)
        Me.cmdRef.Name = "cmdRef"
        Me.cmdRef.Size = New System.Drawing.Size(87, 45)
        Me.cmdRef.TabIndex = 4
        Me.cmdRef.Text = "&Refresh"
        Me.cmdRef.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdRef.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdRef.UseCompatibleTextRendering = True
        Me.cmdRef.UseVisualStyleBackColor = False
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdExit.ForeColor = System.Drawing.Color.Black
        Me.cmdExit.Image = CType(resources.GetObject("cmdExit.Image"), System.Drawing.Image)
        Me.cmdExit.Location = New System.Drawing.Point(483, 4)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(54, 45)
        Me.cmdExit.TabIndex = 13
        Me.cmdExit.Text = "E&xit"
        Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdExit.UseCompatibleTextRendering = True
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'cmdFirst
        '
        Me.cmdFirst.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdFirst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdFirst.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdFirst.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdFirst.ForeColor = System.Drawing.Color.Black
        Me.cmdFirst.Image = CType(resources.GetObject("cmdFirst.Image"), System.Drawing.Image)
        Me.cmdFirst.Location = New System.Drawing.Point(165, 4)
        Me.cmdFirst.Name = "cmdFirst"
        Me.cmdFirst.Size = New System.Drawing.Size(54, 45)
        Me.cmdFirst.TabIndex = 7
        Me.cmdFirst.Text = "&First"
        Me.cmdFirst.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdFirst.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdFirst.UseCompatibleTextRendering = True
        Me.cmdFirst.UseVisualStyleBackColor = False
        '
        'cmdNext
        '
        Me.cmdNext.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdNext.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdNext.ForeColor = System.Drawing.Color.Black
        Me.cmdNext.Image = CType(resources.GetObject("cmdNext.Image"), System.Drawing.Image)
        Me.cmdNext.Location = New System.Drawing.Point(271, 4)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(54, 45)
        Me.cmdNext.TabIndex = 9
        Me.cmdNext.Text = "&Next"
        Me.cmdNext.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdNext.UseCompatibleTextRendering = True
        Me.cmdNext.UseVisualStyleBackColor = False
        '
        'cmdPrev
        '
        Me.cmdPrev.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdPrev.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdPrev.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdPrev.ForeColor = System.Drawing.Color.Black
        Me.cmdPrev.Image = CType(resources.GetObject("cmdPrev.Image"), System.Drawing.Image)
        Me.cmdPrev.Location = New System.Drawing.Point(218, 4)
        Me.cmdPrev.Name = "cmdPrev"
        Me.cmdPrev.Size = New System.Drawing.Size(54, 45)
        Me.cmdPrev.TabIndex = 8
        Me.cmdPrev.Text = "&Prev"
        Me.cmdPrev.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdPrev.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdPrev.UseCompatibleTextRendering = True
        Me.cmdPrev.UseVisualStyleBackColor = False
        '
        'cmdLast
        '
        Me.cmdLast.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdLast.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdLast.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdLast.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdLast.ForeColor = System.Drawing.Color.Black
        Me.cmdLast.Image = CType(resources.GetObject("cmdLast.Image"), System.Drawing.Image)
        Me.cmdLast.Location = New System.Drawing.Point(324, 4)
        Me.cmdLast.Name = "cmdLast"
        Me.cmdLast.Size = New System.Drawing.Size(54, 45)
        Me.cmdLast.TabIndex = 10
        Me.cmdLast.Text = "&Last"
        Me.cmdLast.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdLast.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdLast.UseCompatibleTextRendering = True
        Me.cmdLast.UseVisualStyleBackColor = False
        '
        'cmdFind
        '
        Me.cmdFind.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdFind.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdFind.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdFind.ForeColor = System.Drawing.Color.Black
        Me.cmdFind.Image = CType(resources.GetObject("cmdFind.Image"), System.Drawing.Image)
        Me.cmdFind.Location = New System.Drawing.Point(377, 4)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(54, 45)
        Me.cmdFind.TabIndex = 11
        Me.cmdFind.Text = "F&ind"
        Me.cmdFind.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdFind.UseCompatibleTextRendering = True
        Me.cmdFind.UseVisualStyleBackColor = False
        '
        'FreightDetails
        '
        Me.FreightDetails.Controls.Add(Me.txtfreight)
        Me.FreightDetails.Controls.Add(Me.txtfreightid)
        Me.FreightDetails.Controls.Add(Me.lblfreightid)
        Me.FreightDetails.Controls.Add(Me.lblfreight)
        Me.FreightDetails.Controls.Add(Me.CmbCountry)
        Me.FreightDetails.Controls.Add(Me.lblcountry)
        Me.FreightDetails.ForeColor = System.Drawing.Color.MediumBlue
        Me.FreightDetails.Location = New System.Drawing.Point(6, 68)
        Me.FreightDetails.Name = "FreightDetails"
        Me.FreightDetails.Size = New System.Drawing.Size(531, 143)
        Me.FreightDetails.TabIndex = 18
        Me.FreightDetails.TabStop = False
        Me.FreightDetails.Text = "Freight Details "
        '
        'txtfreight
        '
        Me.txtfreight.Location = New System.Drawing.Point(190, 82)
        Me.txtfreight.MaxLength = 15
        Me.txtfreight.Name = "txtfreight"
        Me.txtfreight.Size = New System.Drawing.Size(188, 20)
        Me.txtfreight.TabIndex = 2
        '
        'txtfreightid
        '
        Me.txtfreightid.Location = New System.Drawing.Point(190, 25)
        Me.txtfreightid.Name = "txtfreightid"
        Me.txtfreightid.Size = New System.Drawing.Size(188, 20)
        Me.txtfreightid.TabIndex = 15
        '
        'lblfreightid
        '
        Me.lblfreightid.AutoSize = True
        Me.lblfreightid.ForeColor = System.Drawing.Color.Black
        Me.lblfreightid.Location = New System.Drawing.Point(113, 28)
        Me.lblfreightid.Name = "lblfreightid"
        Me.lblfreightid.Size = New System.Drawing.Size(51, 13)
        Me.lblfreightid.TabIndex = 23
        Me.lblfreightid.Text = "FreightId:"
        Me.lblfreightid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblfreight
        '
        Me.lblfreight.AutoSize = True
        Me.lblfreight.ForeColor = System.Drawing.Color.Black
        Me.lblfreight.Location = New System.Drawing.Point(113, 85)
        Me.lblfreight.Name = "lblfreight"
        Me.lblfreight.Size = New System.Drawing.Size(42, 13)
        Me.lblfreight.TabIndex = 21
        Me.lblfreight.Text = "Freight:"
        Me.lblfreight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbCountry
        '
        Me.CmbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCountry.FormattingEnabled = True
        Me.CmbCountry.Location = New System.Drawing.Point(190, 51)
        Me.CmbCountry.MaxLength = 40
        Me.CmbCountry.Name = "CmbCountry"
        Me.CmbCountry.Size = New System.Drawing.Size(188, 21)
        Me.CmbCountry.TabIndex = 1
        '
        'lblcountry
        '
        Me.lblcountry.AutoSize = True
        Me.lblcountry.ForeColor = System.Drawing.Color.Black
        Me.lblcountry.Location = New System.Drawing.Point(113, 54)
        Me.lblcountry.Name = "lblcountry"
        Me.lblcountry.Size = New System.Drawing.Size(46, 13)
        Me.lblcountry.TabIndex = 19
        Me.lblcountry.Text = "Country:"
        Me.lblcountry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdHelp
        '
        Me.cmdHelp.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdHelp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdHelp.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdHelp.ForeColor = System.Drawing.Color.Black
        Me.cmdHelp.Image = CType(resources.GetObject("cmdHelp.Image"), System.Drawing.Image)
        Me.cmdHelp.Location = New System.Drawing.Point(430, 4)
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.Size = New System.Drawing.Size(54, 45)
        Me.cmdHelp.TabIndex = 12
        Me.cmdHelp.Text = "&Help"
        Me.cmdHelp.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdHelp.UseCompatibleTextRendering = True
        Me.cmdHelp.UseVisualStyleBackColor = False
        '
        'FreightMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(541, 313)
        Me.Controls.Add(Me.cmdHelp)
        Me.Controls.Add(Me.FreightDetails)
        Me.Controls.Add(Me.cmdFind)
        Me.Controls.Add(Me.cmdLast)
        Me.Controls.Add(Me.cmdPrev)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.cmdFirst)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdRef)
        Me.Controls.Add(Me.cmdUpdate)
        Me.Controls.Add(Me.cmdDel)
        Me.Controls.Add(Me.cmdEdit)
        Me.Controls.Add(Me.cmdAdd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FreightMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Freight Master"
        Me.FreightDetails.ResumeLayout(False)
        Me.FreightDetails.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents cmdDel As System.Windows.Forms.Button
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents cmdRef As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdFirst As System.Windows.Forms.Button
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents cmdPrev As System.Windows.Forms.Button
    Friend WithEvents cmdLast As System.Windows.Forms.Button
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents FreightDetails As System.Windows.Forms.GroupBox
    Friend WithEvents lblcountry As System.Windows.Forms.Label
    Friend WithEvents lblfreightid As System.Windows.Forms.Label
    Friend WithEvents lblfreight As System.Windows.Forms.Label
    Friend WithEvents CmbCountry As System.Windows.Forms.ComboBox
    Friend WithEvents txtfreight As System.Windows.Forms.TextBox
    Friend WithEvents txtfreightid As System.Windows.Forms.TextBox
    Friend WithEvents cmdHelp As System.Windows.Forms.Button
    Friend WithEvents ColDlgFM As System.Windows.Forms.ColorDialog
End Class
