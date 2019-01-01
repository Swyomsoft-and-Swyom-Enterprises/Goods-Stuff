<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContainerMaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ContainerMaster))
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.cmdDel = New System.Windows.Forms.Button
        Me.cmdUpdate = New System.Windows.Forms.Button
        Me.cmdRef = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdFirst = New System.Windows.Forms.Button
        Me.cmdNext = New System.Windows.Forms.Button
        Me.cmdPrev = New System.Windows.Forms.Button
        Me.cmdLast = New System.Windows.Forms.Button
        Me.cmdFind = New System.Windows.Forms.Button
        Me.cmdEdit = New System.Windows.Forms.Button
        Me.ContainerDetails = New System.Windows.Forms.GroupBox
        Me.txttotalsizef = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txttotalsize = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtheightm = New System.Windows.Forms.NumericUpDown
        Me.txtheightc = New System.Windows.Forms.NumericUpDown
        Me.txtheighti = New System.Windows.Forms.NumericUpDown
        Me.txtheightf = New System.Windows.Forms.NumericUpDown
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtwidthm = New System.Windows.Forms.NumericUpDown
        Me.txtwidthc = New System.Windows.Forms.NumericUpDown
        Me.txtwidthi = New System.Windows.Forms.NumericUpDown
        Me.txtwidthf = New System.Windows.Forms.NumericUpDown
        Me.txtlengthm = New System.Windows.Forms.NumericUpDown
        Me.txtlengthc = New System.Windows.Forms.NumericUpDown
        Me.txtlengthi = New System.Windows.Forms.NumericUpDown
        Me.txtlengthf = New System.Windows.Forms.NumericUpDown
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtloadlbs = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtloadkg = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtcontname = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtcontno = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdHelp = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ContainerDetails.SuspendLayout()
        CType(Me.txtheightm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtheightc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtheighti, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtheightf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtwidthm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtwidthc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtwidthi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtwidthf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtlengthm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtlengthc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtlengthi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtlengthf, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdAdd
        '
        Me.cmdAdd.AccessibleName = ""
        Me.cmdAdd.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdAdd.Enabled = False
        Me.cmdAdd.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.cmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdAdd.ForeColor = System.Drawing.Color.Black
        Me.cmdAdd.Image = CType(resources.GetObject("cmdAdd.Image"), System.Drawing.Image)
        Me.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdAdd.Location = New System.Drawing.Point(5, 5)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(54, 45)
        Me.cmdAdd.TabIndex = 0
        Me.cmdAdd.Text = "&Add"
        Me.cmdAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolTip1.SetToolTip(Me.cmdAdd, "Click to Add.")
        Me.cmdAdd.UseCompatibleTextRendering = True
        Me.cmdAdd.UseVisualStyleBackColor = False
        '
        'cmdDel
        '
        Me.cmdDel.AccessibleName = ""
        Me.cmdDel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdDel.Enabled = False
        Me.cmdDel.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.cmdDel.FlatAppearance.BorderSize = 0
        Me.cmdDel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdDel.ForeColor = System.Drawing.Color.Black
        Me.cmdDel.Image = CType(resources.GetObject("cmdDel.Image"), System.Drawing.Image)
        Me.cmdDel.Location = New System.Drawing.Point(111, 5)
        Me.cmdDel.Name = "cmdDel"
        Me.cmdDel.Size = New System.Drawing.Size(54, 45)
        Me.cmdDel.TabIndex = 18
        Me.cmdDel.TabStop = False
        Me.cmdDel.Text = "&Delete"
        Me.cmdDel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolTip1.SetToolTip(Me.cmdDel, "Click to Delete.")
        Me.cmdDel.UseCompatibleTextRendering = True
        Me.cmdDel.UseVisualStyleBackColor = False
        '
        'cmdUpdate
        '
        Me.cmdUpdate.AccessibleName = ""
        Me.cmdUpdate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdUpdate.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.cmdUpdate.FlatAppearance.BorderSize = 0
        Me.cmdUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdUpdate.ForeColor = System.Drawing.Color.Black
        Me.cmdUpdate.Image = CType(resources.GetObject("cmdUpdate.Image"), System.Drawing.Image)
        Me.cmdUpdate.Location = New System.Drawing.Point(310, 302)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(87, 45)
        Me.cmdUpdate.TabIndex = 15
        Me.cmdUpdate.Text = "&Update"
        Me.cmdUpdate.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolTip1.SetToolTip(Me.cmdUpdate, "Click to Update.")
        Me.cmdUpdate.UseCompatibleTextRendering = True
        Me.cmdUpdate.UseVisualStyleBackColor = False
        '
        'cmdRef
        '
        Me.cmdRef.AccessibleName = ""
        Me.cmdRef.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdRef.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdRef.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.cmdRef.FlatAppearance.BorderSize = 0
        Me.cmdRef.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdRef.ForeColor = System.Drawing.Color.Black
        Me.cmdRef.Image = CType(resources.GetObject("cmdRef.Image"), System.Drawing.Image)
        Me.cmdRef.Location = New System.Drawing.Point(403, 302)
        Me.cmdRef.Name = "cmdRef"
        Me.cmdRef.Size = New System.Drawing.Size(87, 45)
        Me.cmdRef.TabIndex = 16
        Me.cmdRef.TabStop = False
        Me.cmdRef.Text = "&Refresh"
        Me.cmdRef.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdRef.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolTip1.SetToolTip(Me.cmdRef, "Click to Refresh.")
        Me.cmdRef.UseCompatibleTextRendering = True
        Me.cmdRef.UseVisualStyleBackColor = False
        '
        'cmdExit
        '
        Me.cmdExit.AccessibleName = ""
        Me.cmdExit.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdExit.Enabled = False
        Me.cmdExit.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.cmdExit.FlatAppearance.BorderSize = 0
        Me.cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdExit.ForeColor = System.Drawing.Color.Black
        Me.cmdExit.Image = CType(resources.GetObject("cmdExit.Image"), System.Drawing.Image)
        Me.cmdExit.Location = New System.Drawing.Point(482, 5)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(54, 45)
        Me.cmdExit.TabIndex = 25
        Me.cmdExit.TabStop = False
        Me.cmdExit.Text = "E&xit"
        Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolTip1.SetToolTip(Me.cmdExit, "Click to Exit.")
        Me.cmdExit.UseCompatibleTextRendering = True
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'cmdFirst
        '
        Me.cmdFirst.AccessibleName = ""
        Me.cmdFirst.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdFirst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdFirst.Enabled = False
        Me.cmdFirst.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.cmdFirst.FlatAppearance.BorderSize = 0
        Me.cmdFirst.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdFirst.ForeColor = System.Drawing.Color.Black
        Me.cmdFirst.Image = CType(resources.GetObject("cmdFirst.Image"), System.Drawing.Image)
        Me.cmdFirst.Location = New System.Drawing.Point(164, 5)
        Me.cmdFirst.Name = "cmdFirst"
        Me.cmdFirst.Size = New System.Drawing.Size(54, 45)
        Me.cmdFirst.TabIndex = 19
        Me.cmdFirst.TabStop = False
        Me.cmdFirst.Text = "&First"
        Me.cmdFirst.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdFirst.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolTip1.SetToolTip(Me.cmdFirst, "Click to view First record.")
        Me.cmdFirst.UseCompatibleTextRendering = True
        Me.cmdFirst.UseVisualStyleBackColor = False
        '
        'cmdNext
        '
        Me.cmdNext.AccessibleName = ""
        Me.cmdNext.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdNext.Enabled = False
        Me.cmdNext.FlatAppearance.BorderSize = 0
        Me.cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdNext.ForeColor = System.Drawing.Color.Black
        Me.cmdNext.Image = CType(resources.GetObject("cmdNext.Image"), System.Drawing.Image)
        Me.cmdNext.Location = New System.Drawing.Point(270, 5)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(54, 45)
        Me.cmdNext.TabIndex = 21
        Me.cmdNext.TabStop = False
        Me.cmdNext.Text = "&Next"
        Me.cmdNext.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolTip1.SetToolTip(Me.cmdNext, "Click to view Next record.")
        Me.cmdNext.UseCompatibleTextRendering = True
        Me.cmdNext.UseVisualStyleBackColor = False
        '
        'cmdPrev
        '
        Me.cmdPrev.AccessibleName = ""
        Me.cmdPrev.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdPrev.Enabled = False
        Me.cmdPrev.FlatAppearance.BorderSize = 0
        Me.cmdPrev.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdPrev.ForeColor = System.Drawing.Color.Black
        Me.cmdPrev.Image = CType(resources.GetObject("cmdPrev.Image"), System.Drawing.Image)
        Me.cmdPrev.Location = New System.Drawing.Point(217, 5)
        Me.cmdPrev.Name = "cmdPrev"
        Me.cmdPrev.Size = New System.Drawing.Size(54, 45)
        Me.cmdPrev.TabIndex = 20
        Me.cmdPrev.TabStop = False
        Me.cmdPrev.Text = "&Prev"
        Me.cmdPrev.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdPrev.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolTip1.SetToolTip(Me.cmdPrev, "Click to view Previous record.")
        Me.cmdPrev.UseCompatibleTextRendering = True
        Me.cmdPrev.UseVisualStyleBackColor = False
        '
        'cmdLast
        '
        Me.cmdLast.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdLast.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdLast.Enabled = False
        Me.cmdLast.FlatAppearance.BorderSize = 0
        Me.cmdLast.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdLast.ForeColor = System.Drawing.Color.Black
        Me.cmdLast.Image = CType(resources.GetObject("cmdLast.Image"), System.Drawing.Image)
        Me.cmdLast.Location = New System.Drawing.Point(323, 5)
        Me.cmdLast.Name = "cmdLast"
        Me.cmdLast.Size = New System.Drawing.Size(54, 45)
        Me.cmdLast.TabIndex = 22
        Me.cmdLast.TabStop = False
        Me.cmdLast.Text = "&Last"
        Me.cmdLast.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdLast.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolTip1.SetToolTip(Me.cmdLast, "Click to view Last record.")
        Me.cmdLast.UseCompatibleTextRendering = True
        Me.cmdLast.UseVisualStyleBackColor = False
        '
        'cmdFind
        '
        Me.cmdFind.AccessibleName = ""
        Me.cmdFind.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdFind.Enabled = False
        Me.cmdFind.FlatAppearance.BorderSize = 0
        Me.cmdFind.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdFind.ForeColor = System.Drawing.Color.Black
        Me.cmdFind.Image = CType(resources.GetObject("cmdFind.Image"), System.Drawing.Image)
        Me.cmdFind.Location = New System.Drawing.Point(376, 5)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(54, 45)
        Me.cmdFind.TabIndex = 23
        Me.cmdFind.TabStop = False
        Me.cmdFind.Text = "F&ind"
        Me.cmdFind.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolTip1.SetToolTip(Me.cmdFind, "Click to search for a particular record.")
        Me.cmdFind.UseCompatibleTextRendering = True
        Me.cmdFind.UseVisualStyleBackColor = False
        '
        'cmdEdit
        '
        Me.cmdEdit.AccessibleName = ""
        Me.cmdEdit.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdEdit.Enabled = False
        Me.cmdEdit.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.cmdEdit.FlatAppearance.BorderSize = 0
        Me.cmdEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdEdit.ForeColor = System.Drawing.Color.Black
        Me.cmdEdit.Image = CType(resources.GetObject("cmdEdit.Image"), System.Drawing.Image)
        Me.cmdEdit.Location = New System.Drawing.Point(58, 5)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(54, 45)
        Me.cmdEdit.TabIndex = 17
        Me.cmdEdit.TabStop = False
        Me.cmdEdit.Text = "&Edit"
        Me.cmdEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolTip1.SetToolTip(Me.cmdEdit, "Click to Edit.")
        Me.cmdEdit.UseCompatibleTextRendering = True
        Me.cmdEdit.UseVisualStyleBackColor = False
        '
        'ContainerDetails
        '
        Me.ContainerDetails.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ContainerDetails.Controls.Add(Me.txttotalsizef)
        Me.ContainerDetails.Controls.Add(Me.Label14)
        Me.ContainerDetails.Controls.Add(Me.txttotalsize)
        Me.ContainerDetails.Controls.Add(Me.Label13)
        Me.ContainerDetails.Controls.Add(Me.txtheightm)
        Me.ContainerDetails.Controls.Add(Me.txtheightc)
        Me.ContainerDetails.Controls.Add(Me.txtheighti)
        Me.ContainerDetails.Controls.Add(Me.txtheightf)
        Me.ContainerDetails.Controls.Add(Me.Label12)
        Me.ContainerDetails.Controls.Add(Me.txtwidthm)
        Me.ContainerDetails.Controls.Add(Me.txtwidthc)
        Me.ContainerDetails.Controls.Add(Me.txtwidthi)
        Me.ContainerDetails.Controls.Add(Me.txtwidthf)
        Me.ContainerDetails.Controls.Add(Me.txtlengthm)
        Me.ContainerDetails.Controls.Add(Me.txtlengthc)
        Me.ContainerDetails.Controls.Add(Me.txtlengthi)
        Me.ContainerDetails.Controls.Add(Me.txtlengthf)
        Me.ContainerDetails.Controls.Add(Me.Label11)
        Me.ContainerDetails.Controls.Add(Me.Label10)
        Me.ContainerDetails.Controls.Add(Me.Label9)
        Me.ContainerDetails.Controls.Add(Me.Label8)
        Me.ContainerDetails.Controls.Add(Me.Label7)
        Me.ContainerDetails.Controls.Add(Me.Label6)
        Me.ContainerDetails.Controls.Add(Me.txtloadlbs)
        Me.ContainerDetails.Controls.Add(Me.Label5)
        Me.ContainerDetails.Controls.Add(Me.txtloadkg)
        Me.ContainerDetails.Controls.Add(Me.Label4)
        Me.ContainerDetails.Controls.Add(Me.Label3)
        Me.ContainerDetails.Controls.Add(Me.txtcontname)
        Me.ContainerDetails.Controls.Add(Me.Label2)
        Me.ContainerDetails.Controls.Add(Me.txtcontno)
        Me.ContainerDetails.Controls.Add(Me.Label1)
        Me.ContainerDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContainerDetails.ForeColor = System.Drawing.Color.MediumBlue
        Me.ContainerDetails.Location = New System.Drawing.Point(19, 56)
        Me.ContainerDetails.Name = "ContainerDetails"
        Me.ContainerDetails.Size = New System.Drawing.Size(502, 237)
        Me.ContainerDetails.TabIndex = 50
        Me.ContainerDetails.TabStop = False
        Me.ContainerDetails.Text = "Container Details"
        '
        'txttotalsizef
        '
        Me.txttotalsizef.AccessibleName = ""
        Me.txttotalsizef.BackColor = System.Drawing.SystemColors.Info
        Me.txttotalsizef.Enabled = False
        Me.txttotalsizef.Location = New System.Drawing.Point(363, 207)
        Me.txttotalsizef.MaxLength = 3000
        Me.txttotalsizef.Name = "txttotalsizef"
        Me.txttotalsizef.ReadOnly = True
        Me.txttotalsizef.Size = New System.Drawing.Size(113, 20)
        Me.txttotalsizef.TabIndex = 54
        Me.txttotalsizef.TabStop = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(266, 210)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(91, 13)
        Me.Label14.TabIndex = 105
        Me.Label14.Text = "Total Size Cu. Ft.:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txttotalsize
        '
        Me.txttotalsize.AccessibleName = ""
        Me.txttotalsize.BackColor = System.Drawing.SystemColors.Info
        Me.txttotalsize.Enabled = False
        Me.txttotalsize.Location = New System.Drawing.Point(122, 207)
        Me.txttotalsize.MaxLength = 3000
        Me.txttotalsize.Name = "txttotalsize"
        Me.txttotalsize.ReadOnly = True
        Me.txttotalsize.Size = New System.Drawing.Size(113, 20)
        Me.txttotalsize.TabIndex = 53
        Me.txttotalsize.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(14, 210)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(94, 13)
        Me.Label13.TabIndex = 103
        Me.Label13.Text = "Total Size Cu. Mt.:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtheightm
        '
        Me.txtheightm.AccessibleName = ""
        Me.txtheightm.DecimalPlaces = 4
        Me.txtheightm.Location = New System.Drawing.Point(408, 170)
        Me.txtheightm.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtheightm.Name = "txtheightm"
        Me.txtheightm.Size = New System.Drawing.Size(68, 20)
        Me.txtheightm.TabIndex = 14
        '
        'txtheightc
        '
        Me.txtheightc.AccessibleName = ""
        Me.txtheightc.DecimalPlaces = 4
        Me.txtheightc.Location = New System.Drawing.Point(310, 170)
        Me.txtheightc.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtheightc.Name = "txtheightc"
        Me.txtheightc.Size = New System.Drawing.Size(64, 20)
        Me.txtheightc.TabIndex = 13
        '
        'txtheighti
        '
        Me.txtheighti.AccessibleName = ""
        Me.txtheighti.DecimalPlaces = 4
        Me.txtheighti.Location = New System.Drawing.Point(218, 170)
        Me.txtheighti.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtheighti.Name = "txtheighti"
        Me.txtheighti.Size = New System.Drawing.Size(64, 20)
        Me.txtheighti.TabIndex = 12
        '
        'txtheightf
        '
        Me.txtheightf.AccessibleName = ""
        Me.txtheightf.DecimalPlaces = 4
        Me.txtheightf.Location = New System.Drawing.Point(124, 170)
        Me.txtheightf.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtheightf.Name = "txtheightf"
        Me.txtheightf.Size = New System.Drawing.Size(65, 20)
        Me.txtheightf.TabIndex = 11
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(14, 172)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 13)
        Me.Label12.TabIndex = 99
        Me.Label12.Text = "Height:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtwidthm
        '
        Me.txtwidthm.AccessibleName = ""
        Me.txtwidthm.DecimalPlaces = 4
        Me.txtwidthm.Location = New System.Drawing.Point(408, 132)
        Me.txtwidthm.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtwidthm.Name = "txtwidthm"
        Me.txtwidthm.Size = New System.Drawing.Size(68, 20)
        Me.txtwidthm.TabIndex = 10
        '
        'txtwidthc
        '
        Me.txtwidthc.AccessibleName = ""
        Me.txtwidthc.DecimalPlaces = 4
        Me.txtwidthc.Location = New System.Drawing.Point(310, 132)
        Me.txtwidthc.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtwidthc.Name = "txtwidthc"
        Me.txtwidthc.Size = New System.Drawing.Size(64, 20)
        Me.txtwidthc.TabIndex = 9
        '
        'txtwidthi
        '
        Me.txtwidthi.AccessibleName = ""
        Me.txtwidthi.DecimalPlaces = 4
        Me.txtwidthi.Location = New System.Drawing.Point(218, 132)
        Me.txtwidthi.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtwidthi.Name = "txtwidthi"
        Me.txtwidthi.Size = New System.Drawing.Size(64, 20)
        Me.txtwidthi.TabIndex = 8
        '
        'txtwidthf
        '
        Me.txtwidthf.AccessibleName = ""
        Me.txtwidthf.DecimalPlaces = 4
        Me.txtwidthf.Location = New System.Drawing.Point(124, 132)
        Me.txtwidthf.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtwidthf.Name = "txtwidthf"
        Me.txtwidthf.Size = New System.Drawing.Size(65, 20)
        Me.txtwidthf.TabIndex = 7
        '
        'txtlengthm
        '
        Me.txtlengthm.AccessibleName = ""
        Me.txtlengthm.DecimalPlaces = 4
        Me.txtlengthm.Location = New System.Drawing.Point(408, 94)
        Me.txtlengthm.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtlengthm.Name = "txtlengthm"
        Me.txtlengthm.Size = New System.Drawing.Size(68, 20)
        Me.txtlengthm.TabIndex = 6
        '
        'txtlengthc
        '
        Me.txtlengthc.AccessibleName = ""
        Me.txtlengthc.DecimalPlaces = 4
        Me.txtlengthc.Location = New System.Drawing.Point(310, 94)
        Me.txtlengthc.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtlengthc.Name = "txtlengthc"
        Me.txtlengthc.Size = New System.Drawing.Size(64, 20)
        Me.txtlengthc.TabIndex = 5
        '
        'txtlengthi
        '
        Me.txtlengthi.AccessibleName = ""
        Me.txtlengthi.DecimalPlaces = 4
        Me.txtlengthi.Location = New System.Drawing.Point(218, 94)
        Me.txtlengthi.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtlengthi.Name = "txtlengthi"
        Me.txtlengthi.Size = New System.Drawing.Size(64, 20)
        Me.txtlengthi.TabIndex = 4
        '
        'txtlengthf
        '
        Me.txtlengthf.AccessibleName = ""
        Me.txtlengthf.DecimalPlaces = 4
        Me.txtlengthf.Location = New System.Drawing.Point(124, 94)
        Me.txtlengthf.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtlengthf.Name = "txtlengthf"
        Me.txtlengthf.Size = New System.Drawing.Size(65, 20)
        Me.txtlengthf.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(14, 134)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(38, 13)
        Me.Label11.TabIndex = 89
        Me.Label11.Text = "Width:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(14, 96)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 13)
        Me.Label10.TabIndex = 88
        Me.Label10.Text = "Length:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(408, 76)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 13)
        Me.Label9.TabIndex = 87
        Me.Label9.Text = "Mms"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(307, 76)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 13)
        Me.Label8.TabIndex = 86
        Me.Label8.Text = "Cms"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(215, 76)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 13)
        Me.Label7.TabIndex = 85
        Me.Label7.Text = "Inches"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(121, 76)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 13)
        Me.Label6.TabIndex = 84
        Me.Label6.Text = "Feet"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtloadlbs
        '
        Me.txtloadlbs.AccessibleName = ""
        Me.txtloadlbs.BackColor = System.Drawing.SystemColors.Info
        Me.txtloadlbs.Enabled = False
        Me.txtloadlbs.Location = New System.Drawing.Point(363, 45)
        Me.txtloadlbs.MaxLength = 3000
        Me.txtloadlbs.Name = "txtloadlbs"
        Me.txtloadlbs.ReadOnly = True
        Me.txtloadlbs.Size = New System.Drawing.Size(113, 20)
        Me.txtloadlbs.TabIndex = 52
        Me.txtloadlbs.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(14, 76)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 82
        Me.Label5.Text = "Size"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtloadkg
        '
        Me.txtloadkg.AccessibleName = ""
        Me.txtloadkg.Location = New System.Drawing.Point(363, 16)
        Me.txtloadkg.MaxLength = 3000
        Me.txtloadkg.Name = "txtloadkg"
        Me.txtloadkg.Size = New System.Drawing.Size(113, 20)
        Me.txtloadkg.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(266, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 80
        Me.Label4.Text = "Pay Load(lbs):"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(266, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 79
        Me.Label3.Text = "Pay Load(Kg):"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtcontname
        '
        Me.txtcontname.AccessibleName = ""
        Me.txtcontname.Location = New System.Drawing.Point(122, 16)
        Me.txtcontname.MaxLength = 60
        Me.txtcontname.Name = "txtcontname"
        Me.txtcontname.Size = New System.Drawing.Size(113, 20)
        Me.txtcontname.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(14, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 77
        Me.Label2.Text = "Container Name:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtcontno
        '
        Me.txtcontno.AccessibleName = ""
        Me.txtcontno.BackColor = System.Drawing.SystemColors.Info
        Me.txtcontno.Enabled = False
        Me.txtcontno.Location = New System.Drawing.Point(122, 45)
        Me.txtcontno.MaxLength = 3000
        Me.txtcontno.Name = "txtcontno"
        Me.txtcontno.Size = New System.Drawing.Size(113, 20)
        Me.txtcontno.TabIndex = 51
        Me.txtcontno.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(14, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 75
        Me.Label1.Text = "Container No.:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdHelp
        '
        Me.cmdHelp.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdHelp.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdHelp.ForeColor = System.Drawing.Color.Black
        Me.cmdHelp.Image = CType(resources.GetObject("cmdHelp.Image"), System.Drawing.Image)
        Me.cmdHelp.Location = New System.Drawing.Point(429, 5)
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.Size = New System.Drawing.Size(54, 45)
        Me.cmdHelp.TabIndex = 24
        Me.cmdHelp.TabStop = False
        Me.cmdHelp.Text = "&Help"
        Me.cmdHelp.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolTip1.SetToolTip(Me.cmdHelp, "Click to view Help.")
        Me.cmdHelp.UseCompatibleTextRendering = True
        Me.cmdHelp.UseVisualStyleBackColor = False
        '
        'ToolTip1
        '
        Me.ToolTip1.ShowAlways = True
        '
        'ContainerMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(541, 360)
        Me.Controls.Add(Me.cmdHelp)
        Me.Controls.Add(Me.ContainerDetails)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.cmdDel)
        Me.Controls.Add(Me.cmdUpdate)
        Me.Controls.Add(Me.cmdRef)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdFirst)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.cmdPrev)
        Me.Controls.Add(Me.cmdLast)
        Me.Controls.Add(Me.cmdFind)
        Me.Controls.Add(Me.cmdEdit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ContainerMaster"
        Me.Text = "Container Master"
        Me.ContainerDetails.ResumeLayout(False)
        Me.ContainerDetails.PerformLayout()
        CType(Me.txtheightm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtheightc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtheighti, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtheightf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtwidthm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtwidthc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtwidthi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtwidthf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtlengthm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtlengthc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtlengthi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtlengthf, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdDel As System.Windows.Forms.Button
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents cmdRef As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdFirst As System.Windows.Forms.Button
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents cmdPrev As System.Windows.Forms.Button
    Friend WithEvents cmdLast As System.Windows.Forms.Button
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents ContainerDetails As System.Windows.Forms.GroupBox
    Friend WithEvents txttotalsizef As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txttotalsize As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtheightm As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtheightc As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtheighti As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtheightf As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtwidthm As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtwidthc As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtwidthi As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtwidthf As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtlengthm As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtlengthc As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtlengthi As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtlengthf As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtloadlbs As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtloadkg As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtcontname As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtcontno As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdHelp As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
