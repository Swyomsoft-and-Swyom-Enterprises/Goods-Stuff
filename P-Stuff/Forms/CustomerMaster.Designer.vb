<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomerMaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CustomerMaster))
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
        Me.Group1 = New System.Windows.Forms.GroupBox
        Me.txtState = New System.Windows.Forms.TextBox
        Me.lblState = New System.Windows.Forms.Label
        Me.txtmobileno = New System.Windows.Forms.TextBox
        Me.txttelno = New System.Windows.Forms.TextBox
        Me.CmbCountry = New System.Windows.Forms.ComboBox
        Me.txtpincode = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.lblcountry = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtcity = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtadd = New System.Windows.Forms.TextBox
        Me.txtcustname = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtcustcode = New System.Windows.Forms.TextBox
        Me.customercode = New System.Windows.Forms.Label
        Me.cmdHelp = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ColDlgCM = New System.Windows.Forms.ColorDialog
        Me.Group1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdAdd
        '
        Me.cmdAdd.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAdd.Image = CType(resources.GetObject("cmdAdd.Image"), System.Drawing.Image)
        Me.cmdAdd.Location = New System.Drawing.Point(6, 1)
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
        'cmdEdit
        '
        Me.cmdEdit.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdEdit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdEdit.ForeColor = System.Drawing.Color.Black
        Me.cmdEdit.Image = CType(resources.GetObject("cmdEdit.Image"), System.Drawing.Image)
        Me.cmdEdit.Location = New System.Drawing.Point(59, 1)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(54, 45)
        Me.cmdEdit.TabIndex = 12
        Me.cmdEdit.TabStop = False
        Me.cmdEdit.Text = "&Edit"
        Me.cmdEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolTip1.SetToolTip(Me.cmdEdit, "Click to Edit.")
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
        Me.cmdDel.Location = New System.Drawing.Point(112, 1)
        Me.cmdDel.Name = "cmdDel"
        Me.cmdDel.Size = New System.Drawing.Size(54, 45)
        Me.cmdDel.TabIndex = 13
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
        Me.cmdUpdate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdUpdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdUpdate.Image = CType(resources.GetObject("cmdUpdate.Image"), System.Drawing.Image)
        Me.cmdUpdate.Location = New System.Drawing.Point(355, 342)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(87, 45)
        Me.cmdUpdate.TabIndex = 9
        Me.cmdUpdate.Text = "&Update"
        Me.cmdUpdate.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolTip1.SetToolTip(Me.cmdUpdate, "Click to Update a record.")
        Me.cmdUpdate.UseCompatibleTextRendering = True
        Me.cmdUpdate.UseVisualStyleBackColor = False
        '
        'cmdRef
        '
        Me.cmdRef.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdRef.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdRef.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdRef.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdRef.Image = CType(resources.GetObject("cmdRef.Image"), System.Drawing.Image)
        Me.cmdRef.Location = New System.Drawing.Point(448, 342)
        Me.cmdRef.Name = "cmdRef"
        Me.cmdRef.Size = New System.Drawing.Size(87, 45)
        Me.cmdRef.TabIndex = 10
        Me.cmdRef.TabStop = False
        Me.cmdRef.Text = "&Refresh"
        Me.cmdRef.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdRef.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolTip1.SetToolTip(Me.cmdRef, "Click to Cancel.")
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
        Me.cmdExit.Location = New System.Drawing.Point(483, 1)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(54, 45)
        Me.cmdExit.TabIndex = 20
        Me.cmdExit.TabStop = False
        Me.cmdExit.Text = "E&xit"
        Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolTip1.SetToolTip(Me.cmdExit, "Click to Exit.")
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
        Me.cmdFirst.Location = New System.Drawing.Point(165, 1)
        Me.cmdFirst.Name = "cmdFirst"
        Me.cmdFirst.Size = New System.Drawing.Size(54, 45)
        Me.cmdFirst.TabIndex = 14
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
        Me.cmdNext.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdNext.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdNext.ForeColor = System.Drawing.Color.Black
        Me.cmdNext.Image = CType(resources.GetObject("cmdNext.Image"), System.Drawing.Image)
        Me.cmdNext.Location = New System.Drawing.Point(271, 1)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(54, 45)
        Me.cmdNext.TabIndex = 16
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
        Me.cmdPrev.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdPrev.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdPrev.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdPrev.ForeColor = System.Drawing.Color.Black
        Me.cmdPrev.Image = CType(resources.GetObject("cmdPrev.Image"), System.Drawing.Image)
        Me.cmdPrev.Location = New System.Drawing.Point(218, 1)
        Me.cmdPrev.Name = "cmdPrev"
        Me.cmdPrev.Size = New System.Drawing.Size(54, 45)
        Me.cmdPrev.TabIndex = 15
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
        Me.cmdLast.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdLast.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdLast.ForeColor = System.Drawing.Color.Black
        Me.cmdLast.Image = CType(resources.GetObject("cmdLast.Image"), System.Drawing.Image)
        Me.cmdLast.Location = New System.Drawing.Point(324, 1)
        Me.cmdLast.Name = "cmdLast"
        Me.cmdLast.Size = New System.Drawing.Size(54, 45)
        Me.cmdLast.TabIndex = 17
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
        Me.cmdFind.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdFind.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdFind.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdFind.ForeColor = System.Drawing.Color.Black
        Me.cmdFind.Image = CType(resources.GetObject("cmdFind.Image"), System.Drawing.Image)
        Me.cmdFind.Location = New System.Drawing.Point(377, 1)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(54, 45)
        Me.cmdFind.TabIndex = 18
        Me.cmdFind.TabStop = False
        Me.cmdFind.Text = "F&ind"
        Me.cmdFind.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolTip1.SetToolTip(Me.cmdFind, "Click to search for a particular record.")
        Me.cmdFind.UseCompatibleTextRendering = True
        Me.cmdFind.UseVisualStyleBackColor = False
        '
        'Group1
        '
        Me.Group1.Controls.Add(Me.txtState)
        Me.Group1.Controls.Add(Me.lblState)
        Me.Group1.Controls.Add(Me.txtmobileno)
        Me.Group1.Controls.Add(Me.txttelno)
        Me.Group1.Controls.Add(Me.CmbCountry)
        Me.Group1.Controls.Add(Me.txtpincode)
        Me.Group1.Controls.Add(Me.Label8)
        Me.Group1.Controls.Add(Me.lblcountry)
        Me.Group1.Controls.Add(Me.Label6)
        Me.Group1.Controls.Add(Me.Label5)
        Me.Group1.Controls.Add(Me.txtcity)
        Me.Group1.Controls.Add(Me.Label4)
        Me.Group1.Controls.Add(Me.txtadd)
        Me.Group1.Controls.Add(Me.txtcustname)
        Me.Group1.Controls.Add(Me.Label3)
        Me.Group1.Controls.Add(Me.Label2)
        Me.Group1.Controls.Add(Me.txtcustcode)
        Me.Group1.Controls.Add(Me.customercode)
        Me.Group1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Group1.ForeColor = System.Drawing.Color.MediumBlue
        Me.Group1.Location = New System.Drawing.Point(8, 52)
        Me.Group1.Name = "Group1"
        Me.Group1.Size = New System.Drawing.Size(527, 274)
        Me.Group1.TabIndex = 20
        Me.Group1.TabStop = False
        Me.Group1.Text = "Customer Details"
        '
        'txtState
        '
        Me.txtState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtState.Location = New System.Drawing.Point(112, 163)
        Me.txtState.MaxLength = 10
        Me.txtState.Name = "txtState"
        Me.txtState.Size = New System.Drawing.Size(126, 20)
        Me.txtState.TabIndex = 5
        '
        'lblState
        '
        Me.lblState.AutoSize = True
        Me.lblState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblState.ForeColor = System.Drawing.Color.Black
        Me.lblState.Location = New System.Drawing.Point(15, 166)
        Me.lblState.Name = "lblState"
        Me.lblState.Size = New System.Drawing.Size(35, 13)
        Me.lblState.TabIndex = 101
        Me.lblState.Text = "State:"
        Me.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtmobileno
        '
        Me.txtmobileno.Location = New System.Drawing.Point(112, 241)
        Me.txtmobileno.MaxLength = 30
        Me.txtmobileno.Name = "txtmobileno"
        Me.txtmobileno.Size = New System.Drawing.Size(126, 20)
        Me.txtmobileno.TabIndex = 8
        '
        'txttelno
        '
        Me.txttelno.Location = New System.Drawing.Point(112, 215)
        Me.txttelno.MaxLength = 30
        Me.txttelno.Name = "txttelno"
        Me.txttelno.Size = New System.Drawing.Size(126, 20)
        Me.txttelno.TabIndex = 7
        '
        'CmbCountry
        '
        Me.CmbCountry.FormattingEnabled = True
        Me.CmbCountry.Location = New System.Drawing.Point(112, 110)
        Me.CmbCountry.Name = "CmbCountry"
        Me.CmbCountry.Size = New System.Drawing.Size(126, 21)
        Me.CmbCountry.TabIndex = 3
        '
        'txtpincode
        '
        Me.txtpincode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpincode.Location = New System.Drawing.Point(112, 189)
        Me.txtpincode.MaxLength = 10
        Me.txtpincode.Name = "txtpincode"
        Me.txtpincode.Size = New System.Drawing.Size(126, 20)
        Me.txtpincode.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(15, 192)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 13)
        Me.Label8.TabIndex = 46
        Me.Label8.Text = "PinCode:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblcountry
        '
        Me.lblcountry.AutoSize = True
        Me.lblcountry.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcountry.ForeColor = System.Drawing.Color.Black
        Me.lblcountry.Location = New System.Drawing.Point(15, 113)
        Me.lblcountry.Name = "lblcountry"
        Me.lblcountry.Size = New System.Drawing.Size(46, 13)
        Me.lblcountry.TabIndex = 45
        Me.lblcountry.Text = "Country:"
        Me.lblcountry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(15, 244)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 13)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "Mobile No.:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(15, 218)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "Tel No.:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtcity
        '
        Me.txtcity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcity.Location = New System.Drawing.Point(112, 137)
        Me.txtcity.MaxLength = 20
        Me.txtcity.Name = "txtcity"
        Me.txtcity.Size = New System.Drawing.Size(126, 20)
        Me.txtcity.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(15, 141)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 13)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "City:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtadd
        '
        Me.txtadd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtadd.Location = New System.Drawing.Point(112, 48)
        Me.txtadd.MaxLength = 250
        Me.txtadd.Multiline = True
        Me.txtadd.Name = "txtadd"
        Me.txtadd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtadd.Size = New System.Drawing.Size(376, 55)
        Me.txtadd.TabIndex = 2
        '
        'txtcustname
        '
        Me.txtcustname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcustname.Location = New System.Drawing.Point(112, 20)
        Me.txtcustname.MaxLength = 60
        Me.txtcustname.Name = "txtcustname"
        Me.txtcustname.Size = New System.Drawing.Size(376, 20)
        Me.txtcustname.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(15, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Address:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(15, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Customer Name:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtcustcode
        '
        Me.txtcustcode.BackColor = System.Drawing.SystemColors.Control
        Me.txtcustcode.Enabled = False
        Me.txtcustcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcustcode.Location = New System.Drawing.Point(386, 109)
        Me.txtcustcode.MaxLength = 3000
        Me.txtcustcode.Name = "txtcustcode"
        Me.txtcustcode.Size = New System.Drawing.Size(97, 20)
        Me.txtcustcode.TabIndex = 11
        '
        'customercode
        '
        Me.customercode.AutoSize = True
        Me.customercode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.customercode.ForeColor = System.Drawing.Color.Black
        Me.customercode.Location = New System.Drawing.Point(281, 113)
        Me.customercode.Name = "customercode"
        Me.customercode.Size = New System.Drawing.Size(82, 13)
        Me.customercode.TabIndex = 99
        Me.customercode.Text = "Customer Code:"
        Me.customercode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.customercode.Visible = False
        '
        'cmdHelp
        '
        Me.cmdHelp.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdHelp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdHelp.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdHelp.ForeColor = System.Drawing.Color.Black
        Me.cmdHelp.Image = CType(resources.GetObject("cmdHelp.Image"), System.Drawing.Image)
        Me.cmdHelp.Location = New System.Drawing.Point(430, 1)
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.Size = New System.Drawing.Size(54, 45)
        Me.cmdHelp.TabIndex = 19
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
        'CustomerMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(541, 396)
        Me.Controls.Add(Me.cmdHelp)
        Me.Controls.Add(Me.Group1)
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
        Me.Name = "CustomerMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Customer Master"
        Me.Group1.ResumeLayout(False)
        Me.Group1.PerformLayout()
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
    Friend WithEvents Group1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtpincode As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblcountry As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtcity As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtadd As System.Windows.Forms.TextBox
    Friend WithEvents txtcustname As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtcustcode As System.Windows.Forms.TextBox
    Friend WithEvents customercode As System.Windows.Forms.Label
    Friend WithEvents CmbCountry As System.Windows.Forms.ComboBox
    Friend WithEvents txtmobileno As System.Windows.Forms.TextBox
    Friend WithEvents txttelno As System.Windows.Forms.TextBox
    Friend WithEvents cmdHelp As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtState As System.Windows.Forms.TextBox
    Friend WithEvents lblState As System.Windows.Forms.Label
    Friend WithEvents ColDlgCM As System.Windows.Forms.ColorDialog
End Class
