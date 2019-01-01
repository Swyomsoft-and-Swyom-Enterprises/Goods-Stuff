<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DisplayPicture
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DisplayPicture))
        Me.TmrPhotoDisplay = New System.Windows.Forms.Timer(Me.components)
        Me.lblCSPPicDisplay = New System.Windows.Forms.Label
        Me.btn_BoxesDiffDim = New System.Windows.Forms.Button
        Me.btn_DrumDHE = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'TmrPhotoDisplay
        '
        '
        'lblCSPPicDisplay
        '
        Me.lblCSPPicDisplay.BackColor = System.Drawing.Color.White
        Me.lblCSPPicDisplay.Font = New System.Drawing.Font("Comic Sans MS", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCSPPicDisplay.ForeColor = System.Drawing.Color.Chocolate
        Me.lblCSPPicDisplay.Location = New System.Drawing.Point(135, 338)
        Me.lblCSPPicDisplay.Name = "lblCSPPicDisplay"
        Me.lblCSPPicDisplay.Size = New System.Drawing.Size(346, 39)
        Me.lblCSPPicDisplay.TabIndex = 4
        Me.lblCSPPicDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_BoxesDiffDim
        '
        Me.btn_BoxesDiffDim.BackColor = System.Drawing.SystemColors.Window
        Me.btn_BoxesDiffDim.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_BoxesDiffDim.Image = Global.Container_Stuff.My.Resources.Resources.StuffBoxes
        Me.btn_BoxesDiffDim.Location = New System.Drawing.Point(12, 12)
        Me.btn_BoxesDiffDim.Name = "btn_BoxesDiffDim"
        Me.btn_BoxesDiffDim.Size = New System.Drawing.Size(73, 71)
        Me.btn_BoxesDiffDim.TabIndex = 3
        Me.btn_BoxesDiffDim.UseVisualStyleBackColor = False
        Me.btn_BoxesDiffDim.Visible = False
        '
        'btn_DrumDHE
        '
        Me.btn_DrumDHE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_DrumDHE.Image = Global.Container_Stuff.My.Resources.Resources.DHSDrums2
        Me.btn_DrumDHE.Location = New System.Drawing.Point(-1, 2)
        Me.btn_DrumDHE.Name = "btn_DrumDHE"
        Me.btn_DrumDHE.Size = New System.Drawing.Size(586, 384)
        Me.btn_DrumDHE.TabIndex = 2
        Me.btn_DrumDHE.UseVisualStyleBackColor = True
        Me.btn_DrumDHE.Visible = False
        '
        'DisplayPicture
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(506, 386)
        Me.Controls.Add(Me.lblCSPPicDisplay)
        Me.Controls.Add(Me.btn_BoxesDiffDim)
        Me.Controls.Add(Me.btn_DrumDHE)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DisplayPicture"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CSP Picture Display"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TmrPhotoDisplay As System.Windows.Forms.Timer
    Friend WithEvents btn_DrumDHE As System.Windows.Forms.Button
    Friend WithEvents btn_BoxesDiffDim As System.Windows.Forms.Button
    Friend WithEvents lblCSPPicDisplay As System.Windows.Forms.Label
End Class
