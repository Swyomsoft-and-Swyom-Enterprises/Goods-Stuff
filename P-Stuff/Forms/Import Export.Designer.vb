<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Import_Export
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
        Me.lblExportFile = New System.Windows.Forms.Label
        Me.lblSaveExportfile = New System.Windows.Forms.Label
        Me.btn3DViewers = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.cboExportfile = New System.Windows.Forms.ComboBox
        Me.cboSaveexportfile = New System.Windows.Forms.ComboBox
        Me.txtViewFile = New System.Windows.Forms.TextBox
        Me.btnViewFile = New System.Windows.Forms.Button
        Me.gbViewfile = New System.Windows.Forms.GroupBox
        Me.gbViewfile.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblExportFile
        '
        Me.lblExportFile.Font = New System.Drawing.Font("Comic Sans MS", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExportFile.Location = New System.Drawing.Point(8, 163)
        Me.lblExportFile.Name = "lblExportFile"
        Me.lblExportFile.Size = New System.Drawing.Size(100, 20)
        Me.lblExportFile.TabIndex = 0
        Me.lblExportFile.Text = "Export file :"
        '
        'lblSaveExportfile
        '
        Me.lblSaveExportfile.Font = New System.Drawing.Font("Comic Sans MS", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaveExportfile.Location = New System.Drawing.Point(8, 197)
        Me.lblSaveExportfile.Name = "lblSaveExportfile"
        Me.lblSaveExportfile.Size = New System.Drawing.Size(133, 20)
        Me.lblSaveExportfile.TabIndex = 1
        Me.lblSaveExportfile.Text = "Save export file :"
        '
        'btn3DViewers
        '
        Me.btn3DViewers.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btn3DViewers.Location = New System.Drawing.Point(393, 17)
        Me.btn3DViewers.Name = "btn3DViewers"
        Me.btn3DViewers.Size = New System.Drawing.Size(84, 26)
        Me.btn3DViewers.TabIndex = 9
        Me.btn3DViewers.Text = "3D Viewers"
        Me.btn3DViewers.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCancel.Location = New System.Drawing.Point(205, 238)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSave.Location = New System.Drawing.Point(124, 238)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'cboExportfile
        '
        Me.cboExportfile.FormattingEnabled = True
        Me.cboExportfile.Location = New System.Drawing.Point(136, 165)
        Me.cboExportfile.Name = "cboExportfile"
        Me.cboExportfile.Size = New System.Drawing.Size(144, 21)
        Me.cboExportfile.TabIndex = 10
        '
        'cboSaveexportfile
        '
        Me.cboSaveexportfile.FormattingEnabled = True
        Me.cboSaveexportfile.Location = New System.Drawing.Point(136, 199)
        Me.cboSaveexportfile.Name = "cboSaveexportfile"
        Me.cboSaveexportfile.Size = New System.Drawing.Size(144, 21)
        Me.cboSaveexportfile.TabIndex = 11
        '
        'txtViewFile
        '
        Me.txtViewFile.Location = New System.Drawing.Point(90, 20)
        Me.txtViewFile.Name = "txtViewFile"
        Me.txtViewFile.Size = New System.Drawing.Size(297, 20)
        Me.txtViewFile.TabIndex = 13
        '
        'btnViewFile
        '
        Me.btnViewFile.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnViewFile.Location = New System.Drawing.Point(7, 19)
        Me.btnViewFile.Name = "btnViewFile"
        Me.btnViewFile.Size = New System.Drawing.Size(75, 23)
        Me.btnViewFile.TabIndex = 14
        Me.btnViewFile.Text = "&View file"
        Me.btnViewFile.UseVisualStyleBackColor = True
        '
        'gbViewfile
        '
        Me.gbViewfile.BackColor = System.Drawing.SystemColors.Control
        Me.gbViewfile.Controls.Add(Me.btnViewFile)
        Me.gbViewfile.Controls.Add(Me.btn3DViewers)
        Me.gbViewfile.Controls.Add(Me.txtViewFile)
        Me.gbViewfile.Location = New System.Drawing.Point(5, 12)
        Me.gbViewfile.Name = "gbViewfile"
        Me.gbViewfile.Size = New System.Drawing.Size(485, 51)
        Me.gbViewfile.TabIndex = 15
        Me.gbViewfile.TabStop = False
        Me.gbViewfile.Text = "View 3D file"
        '
        'Import_Export
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(498, 266)
        Me.Controls.Add(Me.gbViewfile)
        Me.Controls.Add(Me.cboSaveexportfile)
        Me.Controls.Add(Me.cboExportfile)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lblSaveExportfile)
        Me.Controls.Add(Me.lblExportFile)
        Me.Name = "Import_Export"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import Export Utility"
        Me.TopMost = True
        Me.gbViewfile.ResumeLayout(False)
        Me.gbViewfile.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblExportFile As System.Windows.Forms.Label
    Friend WithEvents lblSaveExportfile As System.Windows.Forms.Label
    Friend WithEvents btn3DViewers As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents cboExportfile As System.Windows.Forms.ComboBox
    Friend WithEvents cboSaveexportfile As System.Windows.Forms.ComboBox
    Friend WithEvents txtViewFile As System.Windows.Forms.TextBox
    Friend WithEvents btnViewFile As System.Windows.Forms.Button
    Friend WithEvents gbViewfile As System.Windows.Forms.GroupBox
End Class
