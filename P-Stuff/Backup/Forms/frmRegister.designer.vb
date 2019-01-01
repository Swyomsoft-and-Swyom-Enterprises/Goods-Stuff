<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegister
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRegister))
        Me.Gb = New System.Windows.Forms.GroupBox
        Me.grdRegister = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnRegister = New System.Windows.Forms.Button
        Me.txtUniqueId = New System.Windows.Forms.TextBox
        Me.grpServer = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCDKeyOther = New System.Windows.Forms.TextBox
        Me.txtCDKey2 = New System.Windows.Forms.TextBox
        Me.txtCDKey1 = New System.Windows.Forms.TextBox
        Me.Gb.SuspendLayout()
        CType(Me.grdRegister, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpServer.SuspendLayout()
        Me.SuspendLayout()
        '
        'Gb
        '
        Me.Gb.Controls.Add(Me.grdRegister)
        Me.Gb.Controls.Add(Me.Label4)
        Me.Gb.Controls.Add(Me.btnRegister)
        Me.Gb.Controls.Add(Me.txtUniqueId)
        Me.Gb.Controls.Add(Me.grpServer)
        Me.Gb.Location = New System.Drawing.Point(1, 1)
        Me.Gb.Name = "Gb"
        Me.Gb.Size = New System.Drawing.Size(381, 221)
        Me.Gb.TabIndex = 0
        Me.Gb.TabStop = False
        '
        'grdRegister
        '
        Me.grdRegister.AllowUserToResizeColumns = False
        Me.grdRegister.AllowUserToResizeRows = False
        Me.grdRegister.BackgroundColor = System.Drawing.SystemColors.Control
        Me.grdRegister.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grdRegister.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.grdRegister.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdRegister.ColumnHeadersVisible = False
        Me.grdRegister.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
        Me.grdRegister.Location = New System.Drawing.Point(94, 11)
        Me.grdRegister.Name = "grdRegister"
        Me.grdRegister.RowHeadersVisible = False
        Me.grdRegister.Size = New System.Drawing.Size(247, 55)
        Me.grdRegister.TabIndex = 10
        '
        'Column1
        '
        Me.Column1.HeaderText = ""
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        '
        'Column2
        '
        Me.Column2.HeaderText = ""
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 175
        '
        'Column3
        '
        Me.Column3.HeaderText = ""
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 50
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "User Id :"
        '
        'btnRegister
        '
        Me.btnRegister.Location = New System.Drawing.Point(119, 179)
        Me.btnRegister.Name = "btnRegister"
        Me.btnRegister.Size = New System.Drawing.Size(193, 26)
        Me.btnRegister.TabIndex = 8
        Me.btnRegister.Text = "Register Now"
        Me.btnRegister.UseVisualStyleBackColor = True
        '
        'txtUniqueId
        '
        Me.txtUniqueId.Location = New System.Drawing.Point(6, 185)
        Me.txtUniqueId.Name = "txtUniqueId"
        Me.txtUniqueId.Size = New System.Drawing.Size(94, 20)
        Me.txtUniqueId.TabIndex = 7
        Me.txtUniqueId.Visible = False
        '
        'grpServer
        '
        Me.grpServer.Controls.Add(Me.Label3)
        Me.grpServer.Controls.Add(Me.Label2)
        Me.grpServer.Controls.Add(Me.Label1)
        Me.grpServer.Controls.Add(Me.txtCDKeyOther)
        Me.grpServer.Controls.Add(Me.txtCDKey2)
        Me.grpServer.Controls.Add(Me.txtCDKey1)
        Me.grpServer.Location = New System.Drawing.Point(6, 72)
        Me.grpServer.Name = "grpServer"
        Me.grpServer.Size = New System.Drawing.Size(369, 101)
        Me.grpServer.TabIndex = 1
        Me.grpServer.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Key 3 :"
        Me.Label3.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Key 2 :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Key 1 :"
        '
        'txtCDKeyOther
        '
        Me.txtCDKeyOther.Location = New System.Drawing.Point(88, 71)
        Me.txtCDKeyOther.Name = "txtCDKeyOther"
        Me.txtCDKeyOther.Size = New System.Drawing.Size(237, 20)
        Me.txtCDKeyOther.TabIndex = 2
        Me.txtCDKeyOther.Visible = False
        '
        'txtCDKey2
        '
        Me.txtCDKey2.Location = New System.Drawing.Point(88, 45)
        Me.txtCDKey2.Name = "txtCDKey2"
        Me.txtCDKey2.Size = New System.Drawing.Size(237, 20)
        Me.txtCDKey2.TabIndex = 1
        '
        'txtCDKey1
        '
        Me.txtCDKey1.Location = New System.Drawing.Point(88, 19)
        Me.txtCDKey1.Name = "txtCDKey1"
        Me.txtCDKey1.Size = New System.Drawing.Size(237, 20)
        Me.txtCDKey1.TabIndex = 0
        '
        'frmRegister
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(383, 224)
        Me.Controls.Add(Me.Gb)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRegister"
        Me.Text = "Register"
        Me.Gb.ResumeLayout(False)
        Me.Gb.PerformLayout()
        CType(Me.grdRegister, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpServer.ResumeLayout(False)
        Me.grpServer.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Gb As System.Windows.Forms.GroupBox
    Friend WithEvents grpServer As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCDKeyOther As System.Windows.Forms.TextBox
    Friend WithEvents txtCDKey2 As System.Windows.Forms.TextBox
    Friend WithEvents txtCDKey1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnRegister As System.Windows.Forms.Button
    Friend WithEvents txtUniqueId As System.Windows.Forms.TextBox
    Friend WithEvents grdRegister As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
