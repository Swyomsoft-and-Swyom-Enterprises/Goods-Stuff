<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContainerReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ContainerReport))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.numupdown2 = New System.Windows.Forms.NumericUpDown
        Me.numupdown1 = New System.Windows.Forms.NumericUpDown
        Me.cmbleftmargin = New System.Windows.Forms.ComboBox
        Me.cmbtopmargin = New System.Windows.Forms.ComboBox
        Me.lblleftmargin = New System.Windows.Forms.Label
        Me.lbltopmargin = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnallrecpt = New System.Windows.Forms.Button
        Me.btnselrecpt = New System.Windows.Forms.Button
        Me.lblrcptno = New System.Windows.Forms.Label
        Me.CmbRNumber = New System.Windows.Forms.ComboBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Cr1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrystalReport11 = New Container_Stuff.CrystalReport1
        Me.GroupBox2.SuspendLayout()
        CType(Me.numupdown2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numupdown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.numupdown2)
        Me.GroupBox2.Controls.Add(Me.numupdown1)
        Me.GroupBox2.Controls.Add(Me.cmbleftmargin)
        Me.GroupBox2.Controls.Add(Me.cmbtopmargin)
        Me.GroupBox2.Controls.Add(Me.lblleftmargin)
        Me.GroupBox2.Controls.Add(Me.lbltopmargin)
        Me.GroupBox2.Location = New System.Drawing.Point(179, 71)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(81, 20)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Visible = False
        '
        'numupdown2
        '
        Me.numupdown2.Location = New System.Drawing.Point(190, 49)
        Me.numupdown2.Name = "numupdown2"
        Me.numupdown2.Size = New System.Drawing.Size(76, 20)
        Me.numupdown2.TabIndex = 5
        '
        'numupdown1
        '
        Me.numupdown1.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numupdown1.Location = New System.Drawing.Point(190, 16)
        Me.numupdown1.Name = "numupdown1"
        Me.numupdown1.Size = New System.Drawing.Size(76, 20)
        Me.numupdown1.TabIndex = 4
        '
        'cmbleftmargin
        '
        Me.cmbleftmargin.FormattingEnabled = True
        Me.cmbleftmargin.Location = New System.Drawing.Point(97, 49)
        Me.cmbleftmargin.Name = "cmbleftmargin"
        Me.cmbleftmargin.Size = New System.Drawing.Size(76, 21)
        Me.cmbleftmargin.TabIndex = 3
        '
        'cmbtopmargin
        '
        Me.cmbtopmargin.FormattingEnabled = True
        Me.cmbtopmargin.Location = New System.Drawing.Point(97, 16)
        Me.cmbtopmargin.Name = "cmbtopmargin"
        Me.cmbtopmargin.Size = New System.Drawing.Size(76, 21)
        Me.cmbtopmargin.TabIndex = 2
        '
        'lblleftmargin
        '
        Me.lblleftmargin.AutoSize = True
        Me.lblleftmargin.Location = New System.Drawing.Point(25, 57)
        Me.lblleftmargin.Name = "lblleftmargin"
        Me.lblleftmargin.Size = New System.Drawing.Size(57, 13)
        Me.lblleftmargin.TabIndex = 1
        Me.lblleftmargin.Text = "LeftMargin"
        '
        'lbltopmargin
        '
        Me.lbltopmargin.AutoSize = True
        Me.lbltopmargin.Location = New System.Drawing.Point(25, 24)
        Me.lbltopmargin.Name = "lbltopmargin"
        Me.lbltopmargin.Size = New System.Drawing.Size(61, 13)
        Me.lbltopmargin.TabIndex = 0
        Me.lbltopmargin.Text = "Top Margin"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnallrecpt)
        Me.GroupBox1.Controls.Add(Me.btnselrecpt)
        Me.GroupBox1.Controls.Add(Me.lblrcptno)
        Me.GroupBox1.Controls.Add(Me.CmbRNumber)
        Me.GroupBox1.Location = New System.Drawing.Point(5, -2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(786, 42)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'btnallrecpt
        '
        Me.btnallrecpt.Location = New System.Drawing.Point(567, 10)
        Me.btnallrecpt.Name = "btnallrecpt"
        Me.btnallrecpt.Size = New System.Drawing.Size(144, 26)
        Me.btnallrecpt.TabIndex = 13
        Me.btnallrecpt.Text = "&All Receipts"
        Me.btnallrecpt.UseVisualStyleBackColor = True
        '
        'btnselrecpt
        '
        Me.btnselrecpt.Enabled = False
        Me.btnselrecpt.Location = New System.Drawing.Point(391, 11)
        Me.btnselrecpt.Name = "btnselrecpt"
        Me.btnselrecpt.Size = New System.Drawing.Size(144, 26)
        Me.btnselrecpt.TabIndex = 12
        Me.btnselrecpt.Text = "&Selected Receipts"
        Me.btnselrecpt.UseVisualStyleBackColor = True
        '
        'lblrcptno
        '
        Me.lblrcptno.AutoSize = True
        Me.lblrcptno.Location = New System.Drawing.Point(31, 16)
        Me.lblrcptno.Name = "lblrcptno"
        Me.lblrcptno.Size = New System.Drawing.Size(103, 13)
        Me.lblrcptno.TabIndex = 11
        Me.lblrcptno.Text = "RECEIPT NUMBER"
        '
        'CmbRNumber
        '
        Me.CmbRNumber.FormattingEnabled = True
        Me.CmbRNumber.Location = New System.Drawing.Point(154, 13)
        Me.CmbRNumber.Name = "CmbRNumber"
        Me.CmbRNumber.Size = New System.Drawing.Size(173, 21)
        Me.CmbRNumber.TabIndex = 10
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Cr1)
        Me.Panel1.Location = New System.Drawing.Point(5, 44)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(786, 495)
        Me.Panel1.TabIndex = 12
        '
        'Cr1
        '
        Me.Cr1.ActiveViewIndex = 0
        Me.Cr1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Cr1.DisplayGroupTree = False
        Me.Cr1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Cr1.Location = New System.Drawing.Point(0, 0)
        Me.Cr1.Name = "Cr1"
        Me.Cr1.ReportSource = "C:\Program Files\Pristine Enterprises\P-Stuff\Report1.rpt"
        Me.Cr1.Size = New System.Drawing.Size(786, 495)
        Me.Cr1.TabIndex = 0
        '
        'ContainerReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(801, 578)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "ContainerReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ContainerReport"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.numupdown2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numupdown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents numupdown2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents numupdown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents cmbleftmargin As System.Windows.Forms.ComboBox
    Friend WithEvents cmbtopmargin As System.Windows.Forms.ComboBox
    Friend WithEvents lblleftmargin As System.Windows.Forms.Label
    Friend WithEvents lbltopmargin As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnallrecpt As System.Windows.Forms.Button
    Friend WithEvents btnselrecpt As System.Windows.Forms.Button
    Friend WithEvents lblrcptno As System.Windows.Forms.Label
    Friend WithEvents CmbRNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Cr1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrystalReport11 As Container_Stuff.CrystalReport1
End Class
