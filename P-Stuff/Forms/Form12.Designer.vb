<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form12
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form12))
        Me.txtlengthc = New System.Windows.Forms.NumericUpDown
        Me.txtheighti = New System.Windows.Forms.NumericUpDown
        Me.txtlengthi = New System.Windows.Forms.NumericUpDown
        Me.txtheightf = New System.Windows.Forms.NumericUpDown
        Me.txtlengthf = New System.Windows.Forms.NumericUpDown
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdHelp = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdRef = New System.Windows.Forms.Button
        Me.cmdUpdate = New System.Windows.Forms.Button
        Me.cmdDel = New System.Windows.Forms.Button
        Me.cmdEdit = New System.Windows.Forms.Button
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.cmdFirst = New System.Windows.Forms.Button
        Me.cmdFind = New System.Windows.Forms.Button
        Me.cmdLast = New System.Windows.Forms.Button
        Me.cmdPrev = New System.Windows.Forms.Button
        Me.cmdNext = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtfactor = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtgrossweight = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtnetweight = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtmaxqty = New System.Windows.Forms.TextBox
        Me.txtpackcode = New System.Windows.Forms.TextBox
        Me.TxtCId = New System.Windows.Forms.TextBox
        Me.lblpackcode = New System.Windows.Forms.Label
        Me.lblcontname = New System.Windows.Forms.Label
        Me.txtmaxweight = New System.Windows.Forms.TextBox
        Me.txtmaxcont = New System.Windows.Forms.TextBox
        Me.CmbOrient = New System.Windows.Forms.ComboBox
        Me.cmbcontname = New System.Windows.Forms.ComboBox
        Me.lblmaxweight = New System.Windows.Forms.Label
        Me.lblmaxcont = New System.Windows.Forms.Label
        Me.txtpackingmode = New System.Windows.Forms.TextBox
        Me.lblpacktype = New System.Windows.Forms.Label
        Me.txtpackname = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txttotalsizef = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txttotalsize = New System.Windows.Forms.TextBox
        Me.txtheightm = New System.Windows.Forms.NumericUpDown
        Me.txtlengthm = New System.Windows.Forms.NumericUpDown
        Me.txtheightc = New System.Windows.Forms.NumericUpDown
        Me.MasterCartonDetails = New System.Windows.Forms.GroupBox
        CType(Me.txtlengthc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtheighti, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtlengthi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtheightf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtlengthf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtheightm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtlengthm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtheightc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MasterCartonDetails.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtlengthc
        '
        Me.txtlengthc.DecimalPlaces = 4
        Me.txtlengthc.Location = New System.Drawing.Point(308, 129)
        Me.txtlengthc.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtlengthc.Name = "txtlengthc"
        Me.txtlengthc.Size = New System.Drawing.Size(83, 20)
        Me.txtlengthc.TabIndex = 11
        '
        'txtheighti
        '
        Me.txtheighti.DecimalPlaces = 4
        Me.txtheighti.Location = New System.Drawing.Point(207, 169)
        Me.txtheighti.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtheighti.Name = "txtheighti"
        Me.txtheighti.Size = New System.Drawing.Size(80, 20)
        Me.txtheighti.TabIndex = 10
        '
        'txtlengthi
        '
        Me.txtlengthi.DecimalPlaces = 4
        Me.txtlengthi.Location = New System.Drawing.Point(207, 129)
        Me.txtlengthi.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtlengthi.Name = "txtlengthi"
        Me.txtlengthi.Size = New System.Drawing.Size(80, 20)
        Me.txtlengthi.TabIndex = 8
        '
        'txtheightf
        '
        Me.txtheightf.DecimalPlaces = 4
        Me.txtheightf.Location = New System.Drawing.Point(106, 169)
        Me.txtheightf.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtheightf.Name = "txtheightf"
        Me.txtheightf.Size = New System.Drawing.Size(80, 20)
        Me.txtheightf.TabIndex = 7
        '
        'txtlengthf
        '
        Me.txtlengthf.DecimalPlaces = 4
        Me.txtlengthf.Location = New System.Drawing.Point(106, 129)
        Me.txtlengthf.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtlengthf.Name = "txtlengthf"
        Me.txtlengthf.Size = New System.Drawing.Size(80, 20)
        Me.txtlengthf.TabIndex = 5
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(10, 218)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(94, 13)
        Me.Label14.TabIndex = 98
        Me.Label14.Text = "Total Size Cu. Mt.:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(10, 176)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 13)
        Me.Label13.TabIndex = 95
        Me.Label13.Text = "Height:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(10, 136)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(52, 13)
        Me.Label11.TabIndex = 92
        Me.Label11.Text = "Diameter:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(414, 110)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(32, 13)
        Me.Label10.TabIndex = 89
        Me.Label10.Text = "Mms"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolTip1
        '
        Me.ToolTip1.ShowAlways = True
        '
        'cmdHelp
        '
        Me.cmdHelp.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdHelp.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdHelp.Image = CType(resources.GetObject("cmdHelp.Image"), System.Drawing.Image)
        Me.cmdHelp.Location = New System.Drawing.Point(436, 2)
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.Size = New System.Drawing.Size(54, 45)
        Me.cmdHelp.TabIndex = 60
        Me.cmdHelp.Text = "&Help"
        Me.cmdHelp.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolTip1.SetToolTip(Me.cmdHelp, "Click to view Help.")
        Me.cmdHelp.UseCompatibleTextRendering = True
        Me.cmdHelp.UseVisualStyleBackColor = False
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdExit.Enabled = False
        Me.cmdExit.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.cmdExit.FlatAppearance.BorderSize = 0
        Me.cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdExit.Image = CType(resources.GetObject("cmdExit.Image"), System.Drawing.Image)
        Me.cmdExit.Location = New System.Drawing.Point(489, 2)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(54, 45)
        Me.cmdExit.TabIndex = 61
        Me.cmdExit.Text = "E&xit"
        Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolTip1.SetToolTip(Me.cmdExit, "Click to Exit.")
        Me.cmdExit.UseCompatibleTextRendering = True
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'cmdRef
        '
        Me.cmdRef.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdRef.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdRef.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.cmdRef.FlatAppearance.BorderSize = 0
        Me.cmdRef.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdRef.Image = CType(resources.GetObject("cmdRef.Image"), System.Drawing.Image)
        Me.cmdRef.Location = New System.Drawing.Point(449, 374)
        Me.cmdRef.Name = "cmdRef"
        Me.cmdRef.Size = New System.Drawing.Size(85, 45)
        Me.cmdRef.TabIndex = 52
        Me.cmdRef.Text = "&Refresh"
        Me.cmdRef.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdRef.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolTip1.SetToolTip(Me.cmdRef, "Click to Refresh.")
        Me.cmdRef.UseCompatibleTextRendering = True
        Me.cmdRef.UseVisualStyleBackColor = False
        '
        'cmdUpdate
        '
        Me.cmdUpdate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdUpdate.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.cmdUpdate.FlatAppearance.BorderSize = 0
        Me.cmdUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdUpdate.Image = CType(resources.GetObject("cmdUpdate.Image"), System.Drawing.Image)
        Me.cmdUpdate.Location = New System.Drawing.Point(356, 374)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(85, 45)
        Me.cmdUpdate.TabIndex = 51
        Me.cmdUpdate.Text = "&Update"
        Me.cmdUpdate.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolTip1.SetToolTip(Me.cmdUpdate, "Click to Update.")
        Me.cmdUpdate.UseCompatibleTextRendering = True
        Me.cmdUpdate.UseVisualStyleBackColor = False
        '
        'cmdDel
        '
        Me.cmdDel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdDel.Enabled = False
        Me.cmdDel.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.cmdDel.FlatAppearance.BorderSize = 0
        Me.cmdDel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdDel.Image = CType(resources.GetObject("cmdDel.Image"), System.Drawing.Image)
        Me.cmdDel.Location = New System.Drawing.Point(118, 2)
        Me.cmdDel.Name = "cmdDel"
        Me.cmdDel.Size = New System.Drawing.Size(54, 45)
        Me.cmdDel.TabIndex = 54
        Me.cmdDel.Text = "&Delete"
        Me.cmdDel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolTip1.SetToolTip(Me.cmdDel, "Click to Delete.")
        Me.cmdDel.UseCompatibleTextRendering = True
        Me.cmdDel.UseVisualStyleBackColor = False
        '
        'cmdEdit
        '
        Me.cmdEdit.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdEdit.Enabled = False
        Me.cmdEdit.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.cmdEdit.FlatAppearance.BorderSize = 0
        Me.cmdEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdEdit.Image = CType(resources.GetObject("cmdEdit.Image"), System.Drawing.Image)
        Me.cmdEdit.Location = New System.Drawing.Point(65, 2)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(54, 45)
        Me.cmdEdit.TabIndex = 53
        Me.cmdEdit.TabStop = False
        Me.cmdEdit.Text = "&Edit"
        Me.cmdEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolTip1.SetToolTip(Me.cmdEdit, "Click to Edit.")
        Me.cmdEdit.UseCompatibleTextRendering = True
        Me.cmdEdit.UseVisualStyleBackColor = False
        '
        'cmdAdd
        '
        Me.cmdAdd.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdAdd.Enabled = False
        Me.cmdAdd.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.cmdAdd.FlatAppearance.BorderSize = 0
        Me.cmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdAdd.Image = CType(resources.GetObject("cmdAdd.Image"), System.Drawing.Image)
        Me.cmdAdd.Location = New System.Drawing.Point(12, 2)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(54, 45)
        Me.cmdAdd.TabIndex = 50
        Me.cmdAdd.Text = "&Add"
        Me.cmdAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolTip1.SetToolTip(Me.cmdAdd, "Click to Add.")
        Me.cmdAdd.UseCompatibleTextRendering = True
        Me.cmdAdd.UseVisualStyleBackColor = False
        '
        'cmdFirst
        '
        Me.cmdFirst.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdFirst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdFirst.Enabled = False
        Me.cmdFirst.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.cmdFirst.FlatAppearance.BorderSize = 0
        Me.cmdFirst.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdFirst.Image = CType(resources.GetObject("cmdFirst.Image"), System.Drawing.Image)
        Me.cmdFirst.Location = New System.Drawing.Point(171, 2)
        Me.cmdFirst.Name = "cmdFirst"
        Me.cmdFirst.Size = New System.Drawing.Size(54, 45)
        Me.cmdFirst.TabIndex = 55
        Me.cmdFirst.Text = "&First"
        Me.cmdFirst.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdFirst.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolTip1.SetToolTip(Me.cmdFirst, "Click to view First record.")
        Me.cmdFirst.UseCompatibleTextRendering = True
        Me.cmdFirst.UseVisualStyleBackColor = False
        '
        'cmdFind
        '
        Me.cmdFind.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdFind.Enabled = False
        Me.cmdFind.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.cmdFind.FlatAppearance.BorderSize = 0
        Me.cmdFind.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdFind.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdFind.Image = CType(resources.GetObject("cmdFind.Image"), System.Drawing.Image)
        Me.cmdFind.Location = New System.Drawing.Point(383, 2)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(54, 45)
        Me.cmdFind.TabIndex = 59
        Me.cmdFind.Text = "&Find"
        Me.cmdFind.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolTip1.SetToolTip(Me.cmdFind, "Click to search for a particular record. ")
        Me.cmdFind.UseCompatibleTextRendering = True
        Me.cmdFind.UseVisualStyleBackColor = False
        '
        'cmdLast
        '
        Me.cmdLast.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdLast.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdLast.Enabled = False
        Me.cmdLast.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.cmdLast.FlatAppearance.BorderSize = 0
        Me.cmdLast.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdLast.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdLast.Image = CType(resources.GetObject("cmdLast.Image"), System.Drawing.Image)
        Me.cmdLast.Location = New System.Drawing.Point(330, 2)
        Me.cmdLast.Name = "cmdLast"
        Me.cmdLast.Size = New System.Drawing.Size(54, 45)
        Me.cmdLast.TabIndex = 58
        Me.cmdLast.Text = "&Last"
        Me.cmdLast.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdLast.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolTip1.SetToolTip(Me.cmdLast, "Click to view Last record.")
        Me.cmdLast.UseCompatibleTextRendering = True
        Me.cmdLast.UseVisualStyleBackColor = False
        '
        'cmdPrev
        '
        Me.cmdPrev.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdPrev.Enabled = False
        Me.cmdPrev.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.cmdPrev.FlatAppearance.BorderSize = 0
        Me.cmdPrev.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdPrev.Image = CType(resources.GetObject("cmdPrev.Image"), System.Drawing.Image)
        Me.cmdPrev.Location = New System.Drawing.Point(224, 2)
        Me.cmdPrev.Name = "cmdPrev"
        Me.cmdPrev.Size = New System.Drawing.Size(54, 45)
        Me.cmdPrev.TabIndex = 56
        Me.cmdPrev.Text = "&Prev"
        Me.cmdPrev.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdPrev.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolTip1.SetToolTip(Me.cmdPrev, "Click to view Previous record.")
        Me.cmdPrev.UseCompatibleTextRendering = True
        Me.cmdPrev.UseVisualStyleBackColor = False
        '
        'cmdNext
        '
        Me.cmdNext.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdNext.Enabled = False
        Me.cmdNext.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.cmdNext.FlatAppearance.BorderSize = 0
        Me.cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdNext.Image = CType(resources.GetObject("cmdNext.Image"), System.Drawing.Image)
        Me.cmdNext.Location = New System.Drawing.Point(277, 2)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(54, 45)
        Me.cmdNext.TabIndex = 57
        Me.cmdNext.Text = "&Next"
        Me.cmdNext.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolTip1.SetToolTip(Me.cmdNext, "Click to view Next record.")
        Me.cmdNext.UseCompatibleTextRendering = True
        Me.cmdNext.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(308, 110)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(30, 13)
        Me.Label9.TabIndex = 87
        Me.Label9.Text = "Cms"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(207, 110)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 13)
        Me.Label8.TabIndex = 85
        Me.Label8.Text = "Inches"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(106, 110)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 13)
        Me.Label7.TabIndex = 83
        Me.Label7.Text = "Feet"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(10, 110)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.TabIndex = 81
        Me.Label6.Text = "Size"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtfactor
        '
        Me.txtfactor.Location = New System.Drawing.Point(106, 81)
        Me.txtfactor.Name = "txtfactor"
        Me.txtfactor.Size = New System.Drawing.Size(135, 20)
        Me.txtfactor.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(10, 84)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 79
        Me.Label5.Text = "Factor:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtgrossweight
        '
        Me.txtgrossweight.Location = New System.Drawing.Point(366, 53)
        Me.txtgrossweight.Name = "txtgrossweight"
        Me.txtgrossweight.Size = New System.Drawing.Size(135, 20)
        Me.txtgrossweight.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(254, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 13)
        Me.Label4.TabIndex = 75
        Me.Label4.Text = "GrossWeight/p.c.:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtnetweight
        '
        Me.txtnetweight.Location = New System.Drawing.Point(106, 53)
        Me.txtnetweight.Name = "txtnetweight"
        Me.txtnetweight.Size = New System.Drawing.Size(135, 20)
        Me.txtnetweight.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(10, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 72
        Me.Label3.Text = "NetWeight/p.c.:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtmaxqty
        '
        Me.txtmaxqty.Location = New System.Drawing.Point(343, 9)
        Me.txtmaxqty.Name = "txtmaxqty"
        Me.txtmaxqty.Size = New System.Drawing.Size(100, 20)
        Me.txtmaxqty.TabIndex = 51
        Me.txtmaxqty.Visible = False
        '
        'txtpackcode
        '
        Me.txtpackcode.BackColor = System.Drawing.SystemColors.Control
        Me.txtpackcode.Location = New System.Drawing.Point(113, 9)
        Me.txtpackcode.Name = "txtpackcode"
        Me.txtpackcode.ReadOnly = True
        Me.txtpackcode.Size = New System.Drawing.Size(100, 20)
        Me.txtpackcode.TabIndex = 50
        '
        'TxtCId
        '
        Me.TxtCId.Location = New System.Drawing.Point(278, 205)
        Me.TxtCId.Name = "TxtCId"
        Me.TxtCId.Size = New System.Drawing.Size(57, 20)
        Me.TxtCId.TabIndex = 52
        Me.TxtCId.Visible = False
        '
        'lblpackcode
        '
        Me.lblpackcode.AutoSize = True
        Me.lblpackcode.ForeColor = System.Drawing.Color.Black
        Me.lblpackcode.Location = New System.Drawing.Point(10, 16)
        Me.lblpackcode.Name = "lblpackcode"
        Me.lblpackcode.Size = New System.Drawing.Size(63, 13)
        Me.lblpackcode.TabIndex = 114
        Me.lblpackcode.Text = "Pack Code:"
        Me.lblpackcode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblpackcode.Visible = False
        '
        'lblcontname
        '
        Me.lblcontname.AutoSize = True
        Me.lblcontname.ForeColor = System.Drawing.Color.Black
        Me.lblcontname.Location = New System.Drawing.Point(253, 247)
        Me.lblcontname.Name = "lblcontname"
        Me.lblcontname.Size = New System.Drawing.Size(86, 13)
        Me.lblcontname.TabIndex = 110
        Me.lblcontname.Text = "Container Name:"
        Me.lblcontname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtmaxweight
        '
        Me.txtmaxweight.BackColor = System.Drawing.SystemColors.Info
        Me.txtmaxweight.Enabled = False
        Me.txtmaxweight.Location = New System.Drawing.Point(401, 275)
        Me.txtmaxweight.Name = "txtmaxweight"
        Me.txtmaxweight.Size = New System.Drawing.Size(100, 20)
        Me.txtmaxweight.TabIndex = 56
        '
        'txtmaxcont
        '
        Me.txtmaxcont.BackColor = System.Drawing.SystemColors.Info
        Me.txtmaxcont.Enabled = False
        Me.txtmaxcont.Location = New System.Drawing.Point(139, 275)
        Me.txtmaxcont.Name = "txtmaxcont"
        Me.txtmaxcont.Size = New System.Drawing.Size(100, 20)
        Me.txtmaxcont.TabIndex = 55
        '
        'CmbOrient
        '
        Me.CmbOrient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbOrient.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmbOrient.FormattingEnabled = True
        Me.CmbOrient.Items.AddRange(New Object() {"6", "2"})
        Me.CmbOrient.Location = New System.Drawing.Point(466, 244)
        Me.CmbOrient.MaxLength = 50
        Me.CmbOrient.Name = "CmbOrient"
        Me.CmbOrient.Size = New System.Drawing.Size(35, 21)
        Me.CmbOrient.TabIndex = 19
        '
        'cmbcontname
        '
        Me.cmbcontname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbcontname.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbcontname.FormattingEnabled = True
        Me.cmbcontname.Location = New System.Drawing.Point(362, 244)
        Me.cmbcontname.MaxLength = 50
        Me.cmbcontname.Name = "cmbcontname"
        Me.cmbcontname.Size = New System.Drawing.Size(104, 21)
        Me.cmbcontname.TabIndex = 18
        '
        'lblmaxweight
        '
        Me.lblmaxweight.AutoSize = True
        Me.lblmaxweight.ForeColor = System.Drawing.Color.Black
        Me.lblmaxweight.Location = New System.Drawing.Point(253, 278)
        Me.lblmaxweight.Name = "lblmaxweight"
        Me.lblmaxweight.Size = New System.Drawing.Size(116, 13)
        Me.lblmaxweight.TabIndex = 107
        Me.lblmaxweight.Text = "Max Qty. Weight Wise:"
        Me.lblmaxweight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblmaxcont
        '
        Me.lblmaxcont.AutoSize = True
        Me.lblmaxcont.ForeColor = System.Drawing.Color.Black
        Me.lblmaxcont.Location = New System.Drawing.Point(10, 278)
        Me.lblmaxcont.Name = "lblmaxcont"
        Me.lblmaxcont.Size = New System.Drawing.Size(127, 13)
        Me.lblmaxcont.TabIndex = 106
        Me.lblmaxcont.Text = "Max Qty. Container Wise:"
        Me.lblmaxcont.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtpackingmode
        '
        Me.txtpackingmode.Location = New System.Drawing.Point(106, 244)
        Me.txtpackingmode.MaxLength = 50
        Me.txtpackingmode.Name = "txtpackingmode"
        Me.txtpackingmode.Size = New System.Drawing.Size(135, 20)
        Me.txtpackingmode.TabIndex = 17
        '
        'lblpacktype
        '
        Me.lblpacktype.AutoSize = True
        Me.lblpacktype.ForeColor = System.Drawing.Color.Black
        Me.lblpacktype.Location = New System.Drawing.Point(10, 247)
        Me.lblpacktype.Name = "lblpacktype"
        Me.lblpacktype.Size = New System.Drawing.Size(65, 13)
        Me.lblpacktype.TabIndex = 104
        Me.lblpacktype.Text = "Pack Type: "
        Me.lblpacktype.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtpackname
        '
        Me.txtpackname.Location = New System.Drawing.Point(106, 25)
        Me.txtpackname.MaxLength = 50
        Me.txtpackname.Name = "txtpackname"
        Me.txtpackname.Size = New System.Drawing.Size(395, 20)
        Me.txtpackname.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(10, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 102
        Me.Label2.Text = "Pack Name:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txttotalsizef
        '
        Me.txttotalsizef.BackColor = System.Drawing.SystemColors.Info
        Me.txttotalsizef.Enabled = False
        Me.txttotalsizef.Location = New System.Drawing.Point(363, 215)
        Me.txttotalsizef.Name = "txttotalsizef"
        Me.txttotalsizef.Size = New System.Drawing.Size(138, 20)
        Me.txttotalsizef.TabIndex = 54
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(254, 218)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(91, 13)
        Me.Label15.TabIndex = 100
        Me.Label15.Text = "Total Size Cu. Ft.:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txttotalsize
        '
        Me.txttotalsize.BackColor = System.Drawing.SystemColors.Info
        Me.txttotalsize.Enabled = False
        Me.txttotalsize.Location = New System.Drawing.Point(106, 215)
        Me.txttotalsize.Name = "txttotalsize"
        Me.txttotalsize.Size = New System.Drawing.Size(135, 20)
        Me.txttotalsize.TabIndex = 53
        '
        'txtheightm
        '
        Me.txtheightm.DecimalPlaces = 4
        Me.txtheightm.Location = New System.Drawing.Point(414, 169)
        Me.txtheightm.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtheightm.Name = "txtheightm"
        Me.txtheightm.Size = New System.Drawing.Size(87, 20)
        Me.txtheightm.TabIndex = 16
        '
        'txtlengthm
        '
        Me.txtlengthm.DecimalPlaces = 4
        Me.txtlengthm.Location = New System.Drawing.Point(414, 129)
        Me.txtlengthm.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtlengthm.Name = "txtlengthm"
        Me.txtlengthm.Size = New System.Drawing.Size(87, 20)
        Me.txtlengthm.TabIndex = 14
        '
        'txtheightc
        '
        Me.txtheightc.DecimalPlaces = 4
        Me.txtheightc.Location = New System.Drawing.Point(308, 169)
        Me.txtheightc.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtheightc.Name = "txtheightc"
        Me.txtheightc.Size = New System.Drawing.Size(83, 20)
        Me.txtheightc.TabIndex = 13
        '
        'MasterCartonDetails
        '
        Me.MasterCartonDetails.Controls.Add(Me.CmbOrient)
        Me.MasterCartonDetails.Controls.Add(Me.cmbcontname)
        Me.MasterCartonDetails.Controls.Add(Me.txtmaxqty)
        Me.MasterCartonDetails.Controls.Add(Me.txtpackcode)
        Me.MasterCartonDetails.Controls.Add(Me.TxtCId)
        Me.MasterCartonDetails.Controls.Add(Me.lblpackcode)
        Me.MasterCartonDetails.Controls.Add(Me.lblcontname)
        Me.MasterCartonDetails.Controls.Add(Me.txtmaxweight)
        Me.MasterCartonDetails.Controls.Add(Me.txtmaxcont)
        Me.MasterCartonDetails.Controls.Add(Me.lblmaxweight)
        Me.MasterCartonDetails.Controls.Add(Me.lblmaxcont)
        Me.MasterCartonDetails.Controls.Add(Me.txtpackingmode)
        Me.MasterCartonDetails.Controls.Add(Me.lblpacktype)
        Me.MasterCartonDetails.Controls.Add(Me.txtpackname)
        Me.MasterCartonDetails.Controls.Add(Me.Label2)
        Me.MasterCartonDetails.Controls.Add(Me.txttotalsizef)
        Me.MasterCartonDetails.Controls.Add(Me.Label15)
        Me.MasterCartonDetails.Controls.Add(Me.txttotalsize)
        Me.MasterCartonDetails.Controls.Add(Me.txtheightm)
        Me.MasterCartonDetails.Controls.Add(Me.txtlengthm)
        Me.MasterCartonDetails.Controls.Add(Me.txtheightc)
        Me.MasterCartonDetails.Controls.Add(Me.txtlengthc)
        Me.MasterCartonDetails.Controls.Add(Me.txtheighti)
        Me.MasterCartonDetails.Controls.Add(Me.txtlengthi)
        Me.MasterCartonDetails.Controls.Add(Me.txtheightf)
        Me.MasterCartonDetails.Controls.Add(Me.txtlengthf)
        Me.MasterCartonDetails.Controls.Add(Me.Label14)
        Me.MasterCartonDetails.Controls.Add(Me.Label13)
        Me.MasterCartonDetails.Controls.Add(Me.Label11)
        Me.MasterCartonDetails.Controls.Add(Me.Label10)
        Me.MasterCartonDetails.Controls.Add(Me.Label9)
        Me.MasterCartonDetails.Controls.Add(Me.Label8)
        Me.MasterCartonDetails.Controls.Add(Me.Label7)
        Me.MasterCartonDetails.Controls.Add(Me.Label6)
        Me.MasterCartonDetails.Controls.Add(Me.txtfactor)
        Me.MasterCartonDetails.Controls.Add(Me.Label5)
        Me.MasterCartonDetails.Controls.Add(Me.txtgrossweight)
        Me.MasterCartonDetails.Controls.Add(Me.Label4)
        Me.MasterCartonDetails.Controls.Add(Me.txtnetweight)
        Me.MasterCartonDetails.Controls.Add(Me.Label3)
        Me.MasterCartonDetails.ForeColor = System.Drawing.Color.MediumBlue
        Me.MasterCartonDetails.Location = New System.Drawing.Point(10, 53)
        Me.MasterCartonDetails.Name = "MasterCartonDetails"
        Me.MasterCartonDetails.Size = New System.Drawing.Size(531, 310)
        Me.MasterCartonDetails.TabIndex = 62
        Me.MasterCartonDetails.TabStop = False
        Me.MasterCartonDetails.Text = "Carton Master Details"
        '
        'Form12
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(558, 431)
        Me.Controls.Add(Me.cmdHelp)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdRef)
        Me.Controls.Add(Me.cmdUpdate)
        Me.Controls.Add(Me.cmdDel)
        Me.Controls.Add(Me.cmdEdit)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.cmdFirst)
        Me.Controls.Add(Me.MasterCartonDetails)
        Me.Controls.Add(Me.cmdFind)
        Me.Controls.Add(Me.cmdLast)
        Me.Controls.Add(Me.cmdPrev)
        Me.Controls.Add(Me.cmdNext)
        Me.Name = "Form12"
        Me.Text = "Drum Master"
        CType(Me.txtlengthc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtheighti, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtlengthi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtheightf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtlengthf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtheightm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtlengthm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtheightc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MasterCartonDetails.ResumeLayout(False)
        Me.MasterCartonDetails.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtlengthc As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtheighti As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtlengthi As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtheightf As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtlengthf As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmdHelp As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdRef As System.Windows.Forms.Button
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents cmdDel As System.Windows.Forms.Button
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdFirst As System.Windows.Forms.Button
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents cmdLast As System.Windows.Forms.Button
    Friend WithEvents cmdPrev As System.Windows.Forms.Button
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtfactor As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtgrossweight As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtnetweight As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtmaxqty As System.Windows.Forms.TextBox
    Friend WithEvents txtpackcode As System.Windows.Forms.TextBox
    Friend WithEvents TxtCId As System.Windows.Forms.TextBox
    Friend WithEvents lblpackcode As System.Windows.Forms.Label
    Friend WithEvents lblcontname As System.Windows.Forms.Label
    Friend WithEvents txtmaxweight As System.Windows.Forms.TextBox
    Friend WithEvents txtmaxcont As System.Windows.Forms.TextBox
    Friend WithEvents CmbOrient As System.Windows.Forms.ComboBox
    Friend WithEvents cmbcontname As System.Windows.Forms.ComboBox
    Friend WithEvents lblmaxweight As System.Windows.Forms.Label
    Friend WithEvents lblmaxcont As System.Windows.Forms.Label
    Friend WithEvents txtpackingmode As System.Windows.Forms.TextBox
    Friend WithEvents lblpacktype As System.Windows.Forms.Label
    Friend WithEvents txtpackname As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txttotalsizef As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txttotalsize As System.Windows.Forms.TextBox
    Friend WithEvents txtheightm As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtlengthm As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtheightc As System.Windows.Forms.NumericUpDown
    Friend WithEvents MasterCartonDetails As System.Windows.Forms.GroupBox
End Class
