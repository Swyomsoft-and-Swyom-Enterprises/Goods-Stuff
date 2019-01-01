<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Stuff_Viewers
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Stuff_Viewers))
        Me.btn3DViewersBox = New System.Windows.Forms.Button
        Me.btn3DViewersDrum = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btn3DViewersBox
        '
        Me.btn3DViewersBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn3DViewersBox.Location = New System.Drawing.Point(23, 32)
        Me.btn3DViewersBox.Name = "btn3DViewersBox"
        Me.btn3DViewersBox.Size = New System.Drawing.Size(109, 44)
        Me.btn3DViewersBox.TabIndex = 6
        Me.btn3DViewersBox.Text = "&Box 3D Viewers"
        Me.btn3DViewersBox.UseVisualStyleBackColor = True
        '
        'btn3DViewersDrum
        '
        Me.btn3DViewersDrum.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn3DViewersDrum.Location = New System.Drawing.Point(171, 32)
        Me.btn3DViewersDrum.Name = "btn3DViewersDrum"
        Me.btn3DViewersDrum.Size = New System.Drawing.Size(109, 44)
        Me.btn3DViewersDrum.TabIndex = 7
        Me.btn3DViewersDrum.Text = "&Drum 3D Viewers"
        Me.btn3DViewersDrum.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdExit.ForeColor = System.Drawing.Color.Black
        Me.cmdExit.Image = CType(resources.GetObject("cmdExit.Image"), System.Drawing.Image)
        Me.cmdExit.Location = New System.Drawing.Point(226, 212)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(54, 45)
        Me.cmdExit.TabIndex = 9
        Me.cmdExit.Text = "E&xit"
        Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdExit.UseCompatibleTextRendering = True
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'Stuff_Viewers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 269)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.btn3DViewersDrum)
        Me.Controls.Add(Me.btn3DViewersBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Stuff_Viewers"
        Me.Text = "Stuff Viewers"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn3DViewersBox As System.Windows.Forms.Button
    Friend WithEvents btn3DViewersDrum As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
End Class
