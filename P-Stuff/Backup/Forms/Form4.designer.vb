<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
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
        Me.CmbContainer = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Customer = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.ItemName = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.Length = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Breadth = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Depth = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Quantity = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Weight = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TopUp = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Seq = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Transperent = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.MaxQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Plcqty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label4 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Button6 = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.CheckBox3 = New System.Windows.Forms.CheckBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.ListBox1 = New System.Windows.Forms.ListBox
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CmbContainer
        '
        Me.CmbContainer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbContainer.FormattingEnabled = True
        Me.CmbContainer.Location = New System.Drawing.Point(28, 36)
        Me.CmbContainer.Name = "CmbContainer"
        Me.CmbContainer.Size = New System.Drawing.Size(111, 21)
        Me.CmbContainer.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(163, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(271, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(360, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 13)
        Me.Label3.TabIndex = 3
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Customer, Me.ItemName, Me.Length, Me.Breadth, Me.Depth, Me.Quantity, Me.Weight, Me.TopUp, Me.Seq, Me.Transperent, Me.MaxQty, Me.Plcqty})
        Me.DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DataGridView1.Location = New System.Drawing.Point(-2, 63)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(815, 284)
        Me.DataGridView1.TabIndex = 4
        '
        'Customer
        '
        Me.Customer.Frozen = True
        Me.Customer.HeaderText = "Customer"
        Me.Customer.Name = "Customer"
        Me.Customer.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Customer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Customer.ToolTipText = "Select Customer Name"
        Me.Customer.Width = 60
        '
        'ItemName
        '
        Me.ItemName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.ItemName.Frozen = True
        Me.ItemName.HeaderText = "Item Name"
        Me.ItemName.Name = "ItemName"
        Me.ItemName.ToolTipText = "Select Item Name"
        Me.ItemName.Width = 60
        '
        'Length
        '
        Me.Length.Frozen = True
        Me.Length.HeaderText = "Length"
        Me.Length.Name = "Length"
        Me.Length.ReadOnly = True
        Me.Length.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Length.ToolTipText = "Length in Inches"
        Me.Length.Width = 60
        '
        'Width
        '
        Me.Breadth.Frozen = True
        Me.Breadth.HeaderText = "Width"
        Me.Breadth.Name = "Width"
        Me.Breadth.ReadOnly = True
        Me.Breadth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Breadth.ToolTipText = "Width in Inches"
        Me.Breadth.Width = 60
        '
        'Height
        '
        Me.Depth.Frozen = True
        Me.Depth.HeaderText = "Height"
        Me.Depth.Name = "Height"
        Me.Depth.ReadOnly = True
        Me.Depth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Depth.ToolTipText = "Height in Inches"
        Me.Depth.Width = 60
        '
        'Quantity
        '
        Me.Quantity.Frozen = True
        Me.Quantity.HeaderText = "Quantity"
        Me.Quantity.Name = "Quantity"
        Me.Quantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Quantity.ToolTipText = "Enter Quantity"
        Me.Quantity.Width = 60
        '
        'Weight
        '
        Me.Weight.Frozen = True
        Me.Weight.HeaderText = "Weight"
        Me.Weight.Name = "Weight"
        Me.Weight.ReadOnly = True
        Me.Weight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Weight.ToolTipText = "Item Weight"
        Me.Weight.Width = 60
        '
        'TopUp
        '
        Me.TopUp.Frozen = True
        Me.TopUp.HeaderText = "Top Up"
        Me.TopUp.Name = "TopUp"
        Me.TopUp.ToolTipText = "Select this for maintaining Top"
        Me.TopUp.Width = 40
        '
        'Seq
        '
        Me.Seq.Frozen = True
        Me.Seq.HeaderText = "Seq"
        Me.Seq.Name = "Seq"
        Me.Seq.ToolTipText = "Packing Sequence Number"
        Me.Seq.Width = 40
        '
        'Transperent
        '
        Me.Transperent.Frozen = True
        Me.Transperent.HeaderText = "Transperent"
        Me.Transperent.Name = "Transperent"
        Me.Transperent.ToolTipText = "Select this for Showing Items Transperent"
        Me.Transperent.Width = 25
        '
        'MaxQty
        '
        Me.MaxQty.Frozen = True
        Me.MaxQty.HeaderText = "MaxQty"
        Me.MaxQty.Name = "MaxQty"
        Me.MaxQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.MaxQty.ToolTipText = "Maximum Item Quantity that can be stuffed"
        Me.MaxQty.Width = 50
        '
        'Plcqty
        '
        Me.Plcqty.HeaderText = "Plc.Items"
        Me.Plcqty.Name = "Plcqty"
        Me.Plcqty.ReadOnly = True
        Me.Plcqty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Plcqty.ToolTipText = "Placed Items"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Select Container"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(-2, 440)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(36, 22)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Sequence"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.Location = New System.Drawing.Point(81, 375)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(89, 26)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Draw"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(655, 32)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(99, 17)
        Me.CheckBox1.TabIndex = 8
        Me.CheckBox1.Text = "Draw Container"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(-2, 445)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(81, 17)
        Me.CheckBox2.TabIndex = 9
        Me.CheckBox2.Text = "Draw Steps"
        Me.CheckBox2.UseVisualStyleBackColor = True
        Me.CheckBox2.Visible = False
        '
        'Button3
        '
        Me.Button3.Enabled = False
        Me.Button3.Location = New System.Drawing.Point(318, 376)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(89, 25)
        Me.Button3.TabIndex = 10
        Me.Button3.Text = "Area usage"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(440, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 13)
        Me.Label5.TabIndex = 11
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(-2, 440)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(80, 25)
        Me.Button4.TabIndex = 12
        Me.Button4.Text = "Delete Row"
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'Button5
        '
        Me.Button5.Enabled = False
        Me.Button5.Location = New System.Drawing.Point(-2, 436)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(52, 20)
        Me.Button5.TabIndex = 13
        Me.Button5.Text = "Maxqty"
        Me.Button5.UseVisualStyleBackColor = True
        Me.Button5.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(541, 375)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(63, 20)
        Me.TextBox1.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(163, 440)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(0, 13)
        Me.Label6.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(170, 415)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(0, 13)
        Me.Label7.TabIndex = 16
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(201, 375)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(87, 26)
        Me.Button6.TabIndex = 17
        Me.Button6.Text = "Reset"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(538, 398)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Step Quantity"
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(433, 378)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(90, 17)
        Me.CheckBox3.TabIndex = 19
        Me.CheckBox3.Text = "Stuff All Items"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(565, 35)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(0, 13)
        Me.Label9.TabIndex = 20
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(-2, -8)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(120, 17)
        Me.ListBox1.TabIndex = 21
        Me.ListBox1.Visible = False
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(766, 485)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.CheckBox3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CmbContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "Form4"
        Me.Text = "Sky Container Stuffing plus"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmbContainer As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Customer As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ItemName As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Length As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Breadth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Depth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Weight As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TopUp As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Seq As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Transperent As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents MaxQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Plcqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
End Class
