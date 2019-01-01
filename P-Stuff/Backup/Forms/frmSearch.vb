
'Program Name: -    frmSearch.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    Sky Stuff Plus (Container Stuffing)
'Date: -            24 Dec 2K8 12.30 PM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - frmSearch is the record searching form the user enters the container
'               name customer name etc. the respect to that field the record is searching 
'               and displaying into the form.

#Region " Importing Object "

Imports SDO = System.Data.OleDb

#End Region

Public NotInheritable Class frmSearch
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Public components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents g2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Txtsearch As System.Windows.Forms.TextBox
    Friend WithEvents DG As System.Windows.Forms.DataGrid

    <System.Diagnostics.DebuggerStepThrough()> Public Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSearch))
        Me.g2 = New System.Windows.Forms.GroupBox
        Me.DG = New System.Windows.Forms.DataGrid
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Txtsearch = New System.Windows.Forms.TextBox
        Me.g2.SuspendLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'g2
        '
        Me.g2.Controls.Add(Me.DG)
        Me.g2.Location = New System.Drawing.Point(9, 39)
        Me.g2.Name = "g2"
        Me.g2.Size = New System.Drawing.Size(523, 253)
        Me.g2.TabIndex = 6
        Me.g2.TabStop = False
        '
        'DG
        '
        Me.DG.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DG.DataMember = ""
        Me.DG.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DG.Location = New System.Drawing.Point(8, 14)
        Me.DG.Name = "DG"
        Me.DG.Size = New System.Drawing.Size(508, 233)
        Me.DG.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Enter the Name: "
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Navy
        Me.Button1.Location = New System.Drawing.Point(409, 10)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 24)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "&Search"
        '
        'Txtsearch
        '
        Me.Txtsearch.BackColor = System.Drawing.SystemColors.Info
        Me.Txtsearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtsearch.Location = New System.Drawing.Point(111, 12)
        Me.Txtsearch.MaxLength = 50
        Me.Txtsearch.Name = "Txtsearch"
        Me.Txtsearch.Size = New System.Drawing.Size(275, 20)
        Me.Txtsearch.TabIndex = 0
        '
        'frmSearch
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(543, 306)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Txtsearch)
        Me.Controls.Add(Me.g2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(9, 9)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.g2.ResumeLayout(False)
        CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region " Routine definition "

    Dim ds1 As New DataSet

    Private Sub frmSearch_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        Me.KeyPreview = True
        Txtsearch.Focus()

    End Sub

    Public Sub frmSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DG.DataSource = Module1.rec_search(FindStr, DT)
        DG.DataMember = DT
        g2.Enabled = True
        Txtsearch.Enabled = True
        Txtsearch.Text = ""
        Txtsearch.Focus()

        Select Case title
            Case "Container"
                Me.Text = "Search for Container Name"
                ContainerMasterTableStyleProperties(DG)
            Case "PackMast"
                Me.Text = "Search for Pack Name"
                PackMasterTableStyleProperties(DG)
            Case "Customer"
                Me.Text = "Search for Customer Name"
                CustomerMasterTableStyleProperties(DG)
                ' GroupTableStyleProperties(DG)
            Case "Freight"
                Me.Text = "Search for Freight Name"
                FreightMasterTableStyleProperties(DG)
            Case "client"
                'ClientTableStyleProperties(DG)
            Case "sales"

            Case "OrderEntry"
                'OrderEntryTableStyleProperties(DG)
        End Select
        'Me.Top = 120 : Me.Left = 130

    End Sub

    Private Sub setMyDataGridTableStyleProperties(ByRef myDG As DataGrid)

        ' Use a table style object to apply custom formatting
        ' to the DataGrid.
        Dim mydgTableStyle As New DataGridTableStyle
        Dim mygrdColStyle1 As New DataGridTextBoxColumn
        Dim mygrdColStyle2 As New DataGridTextBoxColumn
        Dim mygrdColStyle3 As New DataGridTextBoxColumn

        With mydgTableStyle
            .MappingName = "Sales_Entry"
        End With
        ' Use column style objects to applyformatting specific
        ' to each column of customer table.
        With mygrdColStyle1
            .HeaderText = "ID#"
            .MappingName = "Sales_ID"
            .Width = 0
            .ReadOnly = True
        End With

        With mygrdColStyle2
            .HeaderText = "Name"
            .MappingName = "Comp_name"
            .Width = 140
            .ReadOnly = True
        End With

        With mygrdColStyle3
            .HeaderText = "Product"
            .MappingName = "Product_Name"
            .Width = 180
            .ReadOnly = True
        End With

        mydgTableStyle.GridColumnStyles.AddRange(New DataGridColumnStyle() {mygrdColStyle1, mygrdColStyle2, mygrdColStyle3})
        myDG.TableStyles.Add(mydgTableStyle)

    End Sub

    Private Sub ContainerMasterTableStyleProperties(ByRef myDG As DataGrid) 'Add GridColumn Title 

        Dim mydgTableStyle As New DataGridTableStyle
        Dim mygrdColStyle1 As DataGridTextBoxColumn
        ',,,,,,,
        ',,,,,,,,
        With mydgTableStyle
            .MappingName = "ContainerMaster"
        End With
        mygrdColStyle1 = New DataGridTextBoxColumn
        With mygrdColStyle1
            .HeaderText = "ContainerNo"
            .MappingName = "ContainerNo"
            .Width = 0
            .NullText = ""
            .ReadOnly = True
        End With
        mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)
        '
        mygrdColStyle1 = New DataGridTextBoxColumn
        With mygrdColStyle1
            .HeaderText = "Container Name"
            .MappingName = "ContainerName"
            .Width = 150
            .NullText = ""
            .ReadOnly = True
        End With
        mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

        mygrdColStyle1 = New DataGridTextBoxColumn
        With mygrdColStyle1
            .HeaderText = "LengthF"
            .MappingName = "LengthF"
            .Width = 60
            .NullText = ""
            .ReadOnly = True
        End With
        mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

        mygrdColStyle1 = New DataGridTextBoxColumn
        With mygrdColStyle1
            .HeaderText = "WidthF"
            .MappingName = "WidthF"
            .Width = 60
            .NullText = ""
            .ReadOnly = True
        End With
        mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

        mygrdColStyle1 = New DataGridTextBoxColumn
        With mygrdColStyle1
            .HeaderText = "HeightF"
            .MappingName = "HeightF"
            .Width = 60
            .NullText = ""
            .ReadOnly = True
        End With
        mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

        mygrdColStyle1 = New DataGridTextBoxColumn
        With mygrdColStyle1
            .HeaderText = "LengthI"
            .MappingName = "LengthI"
            .Width = 60
            .NullText = ""
            .ReadOnly = True
        End With
        mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

        mygrdColStyle1 = New DataGridTextBoxColumn
        With mygrdColStyle1
            .HeaderText = "WidthI"
            .MappingName = "WidthI"
            .Width = 60
            .NullText = ""
            .ReadOnly = True
        End With
        mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

        mygrdColStyle1 = New DataGridTextBoxColumn
        With mygrdColStyle1
            .HeaderText = "HeightI"
            .MappingName = "HeightI"
            .Width = 60
            .NullText = ""
            .ReadOnly = True
        End With
        mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

        mygrdColStyle1 = New DataGridTextBoxColumn
        With mygrdColStyle1
            .HeaderText = "LengthC"
            .MappingName = "LengthC"
            .Width = 60
            .NullText = ""
            .ReadOnly = True
        End With
        mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

        mygrdColStyle1 = New DataGridTextBoxColumn
        With mygrdColStyle1
            .HeaderText = "WidthC"
            .MappingName = "WidthC"
            .Width = 60
            .NullText = ""
            .ReadOnly = True
        End With
        mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

        mygrdColStyle1 = New DataGridTextBoxColumn
        With mygrdColStyle1
            .HeaderText = "HeightC"
            .MappingName = "HeightC"
            .Width = 60
            .NullText = ""
            .ReadOnly = True
        End With
        mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

        mygrdColStyle1 = New DataGridTextBoxColumn
        With mygrdColStyle1
            .HeaderText = "LengthMm"
            .MappingName = "LengthM"
            .Width = 60
            .NullText = ""
            .ReadOnly = True
        End With
        mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

        mygrdColStyle1 = New DataGridTextBoxColumn
        With mygrdColStyle1
            .HeaderText = "WidthMm"
            .MappingName = "WidthM"
            .Width = 60
            .NullText = ""
            .ReadOnly = True
        End With
        mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

        mygrdColStyle1 = New DataGridTextBoxColumn
        With mygrdColStyle1
            .HeaderText = "HeightMm"
            .MappingName = "HeightM"
            .Width = 60
            .NullText = ""
            .ReadOnly = True
        End With
        mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

        mygrdColStyle1 = New DataGridTextBoxColumn
        With mygrdColStyle1
            .HeaderText = "PayLoad"
            .MappingName = "PayLoad"
            .Width = 60
            .NullText = ""
            .ReadOnly = True
        End With
        mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

        mygrdColStyle1 = New DataGridTextBoxColumn
        With mygrdColStyle1
            .HeaderText = "TotalSizeCM"
            .MappingName = "TotalSize"
            .Width = 80
            .NullText = ""
            .ReadOnly = True
        End With
        mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

        mygrdColStyle1 = New DataGridTextBoxColumn
        With mygrdColStyle1
            .HeaderText = "TotalSizeCF"
            .MappingName = "TotalSizeF"
            .Width = 80
            .NullText = ""
            .ReadOnly = True
        End With
        mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

        myDG.TableStyles.Clear()
        myDG.TableStyles.Add(mydgTableStyle)
    End Sub

    Private Sub OnGridKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        Dim k As Integer
        k = Asc(e.KeyChar)
        Select Case k
            Case 48 To 57, 8, 13, 32
            Case 45
            Case 46
            Case Else
                k = 0
        End Select
        If k = 0 Then
            e.Handled = True
        Else
            e.Handled = False
        End If

    End Sub

    Private Sub DG_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DG.DoubleClick

        Try
            If DG.CurrentRowIndex >= 0 Then
                Select Case title
                    Case "Customer"
                        Me.Close()
                        CustomerMaster.Show()
                        CustomerMaster.txtcustcode.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 0)), "", DG.Item(DG.CurrentRowIndex, 0))
                        CustomerMaster.txtcustname.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 1)), "", DG.Item(DG.CurrentRowIndex, 1))
                        CustomerMaster.txtadd.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 2)), "", DG.Item(DG.CurrentRowIndex, 2))
                        CustomerMaster.txtcity.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 3)), "", DG.Item(DG.CurrentRowIndex, 3))
                        CustomerMaster.txttelno.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 4)), "", DG.Item(DG.CurrentRowIndex, 4))
                        CustomerMaster.txtmobileno.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 5)), "", DG.Item(DG.CurrentRowIndex, 5))
                        CustomerMaster.CmbCountry.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 6)), "", DG.Item(DG.CurrentRowIndex, 6))
                        CustomerMaster.txtpincode.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 7)), "", DG.Item(DG.CurrentRowIndex, 7))
                    Case "Container"
                        Me.Close()
                        ContainerMaster.Show()
                        ContainerMaster.Txtclear()
                        ContainerMaster.txtcontno.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 0)), "", DG.Item(DG.CurrentRowIndex, 0))
                        ContainerMaster.txtcontname.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 1)), "", DG.Item(DG.CurrentRowIndex, 1))
                        If Val(DG.Item(DG.CurrentRowIndex, 2)) = 0 Then
                            ContainerMaster.txtlengthf.Text = ""
                        Else
                            ContainerMaster.txtlengthf.Text = DG.Item(DG.CurrentRowIndex, 2)
                        End If
                        'ContainerMaster.txtlengthf.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 2)), "", DG.Item(DG.CurrentRowIndex, 2))
                        If Val(DG.Item(DG.CurrentRowIndex, 3)) = 0 Then
                            ContainerMaster.txtwidthf.Text = ""
                        Else
                            ContainerMaster.txtwidthf.Text = DG.Item(DG.CurrentRowIndex, 3)
                        End If
                        'ContainerMaster.txtwidthf.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 3)), "", DG.Item(DG.CurrentRowIndex, 3))
                        If Val(DG.Item(DG.CurrentRowIndex, 4)) = 0 Then
                            ContainerMaster.txtheightf.Text = ""
                        Else
                            ContainerMaster.txtheightf.Text = DG.Item(DG.CurrentRowIndex, 4)
                        End If
                        'ContainerMaster.txtheightf.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 4)), "", DG.Item(DG.CurrentRowIndex, 4))
                        If Val(DG.Item(DG.CurrentRowIndex, 5)) = 0 Then
                            ContainerMaster.txtlengthi.Text = ""
                        Else
                            ContainerMaster.txtlengthi.Text = DG.Item(DG.CurrentRowIndex, 5)
                        End If
                        'ContainerMaster.txtlengthi.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 5)), "", DG.Item(DG.CurrentRowIndex, 5))
                        If Val(DG.Item(DG.CurrentRowIndex, 6)) = 0 Then
                            ContainerMaster.txtwidthi.Text = ""
                        Else
                            ContainerMaster.txtwidthi.Text = DG.Item(DG.CurrentRowIndex, 6)
                        End If
                        'ContainerMaster.txtwidthi.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 6)), "", DG.Item(DG.CurrentRowIndex, 6))
                        If Val(DG.Item(DG.CurrentRowIndex, 7)) = 0 Then
                            ContainerMaster.txtheighti.Text = ""
                        Else
                            ContainerMaster.txtheighti.Text = DG.Item(DG.CurrentRowIndex, 7)
                        End If
                        'ContainerMaster.txtheighti.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 7)), "", DG.Item(DG.CurrentRowIndex, 7))
                        If Val(DG.Item(DG.CurrentRowIndex, 8)) = 0 Then
                            ContainerMaster.txtlengthc.Text = ""
                        Else
                            ContainerMaster.txtlengthc.Text = DG.Item(DG.CurrentRowIndex, 8)
                        End If
                        'ContainerMaster.txtlengthc.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 8)), "", DG.Item(DG.CurrentRowIndex, 8))
                        If Val(DG.Item(DG.CurrentRowIndex, 9)) = 0 Then
                            ContainerMaster.txtwidthc.Text = ""
                        Else
                            ContainerMaster.txtwidthc.Text = DG.Item(DG.CurrentRowIndex, 9)
                        End If
                        'ContainerMaster.txtwidthc.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 9)), "", DG.Item(DG.CurrentRowIndex, 9))
                        If Val(DG.Item(DG.CurrentRowIndex, 10)) = 0 Then
                            ContainerMaster.txtheightc.Text = ""
                        Else
                            ContainerMaster.txtheightc.Text = DG.Item(DG.CurrentRowIndex, 10)
                        End If
                        'ContainerMaster.txtheightc.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 10)), "", DG.Item(DG.CurrentRowIndex, 10))
                        If Val(DG.Item(DG.CurrentRowIndex, 11)) = 0 Then
                            ContainerMaster.txtlengthm.Text = ""
                        Else
                            ContainerMaster.txtlengthm.Text = DG.Item(DG.CurrentRowIndex, 11)
                        End If
                        'ContainerMaster.txtlengthm.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 11)), "", DG.Item(DG.CurrentRowIndex, 11))
                        If Val(DG.Item(DG.CurrentRowIndex, 12)) = 0 Then
                            ContainerMaster.txtwidthm.Text = ""
                        Else
                            ContainerMaster.txtwidthm.Text = DG.Item(DG.CurrentRowIndex, 12)
                        End If
                        'ContainerMaster.txtwidthm.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 12)), "", DG.Item(DG.CurrentRowIndex, 12))
                        If Val(DG.Item(DG.CurrentRowIndex, 13)) = 0 Then
                            ContainerMaster.txtheightm.Text = ""
                        Else
                            ContainerMaster.txtheightm.Text = DG.Item(DG.CurrentRowIndex, 13)
                        End If
                        ' ContainerMaster.txtheightm.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 13)), "", DG.Item(DG.CurrentRowIndex, 13))
                        ContainerMaster.txtloadkg.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 14)), "", DG.Item(DG.CurrentRowIndex, 14))
                        ContainerMaster.txtloadlbs.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 14) * 2.2045), "", DG.Item(DG.CurrentRowIndex, 14) * 2.2045)
                        ContainerMaster.txttotalsize.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 15)), "", DG.Item(DG.CurrentRowIndex, 15))
                        ContainerMaster.txttotalsizef.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 16)), "", DG.Item(DG.CurrentRowIndex, 16))
                        'Me.Top = 0 : Me.Left = 0
                    Case "PackMast"
                        Me.Close()
                        MasterCartonEntry.Show()
                        MasterCartonEntry.txtpackcode.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 0)), "", DG.Item(DG.CurrentRowIndex, 0))
                        MasterCartonEntry.txtpackname.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 1)), "", DG.Item(DG.CurrentRowIndex, 1))
                        If Val(DG.Item(DG.CurrentRowIndex, 2)) = 0 Then
                            ContainerMaster.txtlengthf.Text = ""
                        Else
                            ContainerMaster.txtlengthf.Text = DG.Item(DG.CurrentRowIndex, 2)
                        End If
                        'ContainerMaster.txtlengthf.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 2)), "", DG.Item(DG.CurrentRowIndex, 2))
                        If Val(DG.Item(DG.CurrentRowIndex, 3)) = 0 Then
                            ContainerMaster.txtwidthf.Text = ""
                        Else
                            ContainerMaster.txtwidthf.Text = DG.Item(DG.CurrentRowIndex, 3)
                        End If
                        'ContainerMaster.txtwidthf.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 3)), "", DG.Item(DG.CurrentRowIndex, 3))
                        If Val(DG.Item(DG.CurrentRowIndex, 4)) = 0 Then
                            ContainerMaster.txtheightf.Text = ""
                        Else
                            ContainerMaster.txtheightf.Text = DG.Item(DG.CurrentRowIndex, 4)
                        End If
                        'ContainerMaster.txtheightf.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 4)), "", DG.Item(DG.CurrentRowIndex, 4))
                        If Val(DG.Item(DG.CurrentRowIndex, 5)) = 0 Then
                            ContainerMaster.txtlengthi.Text = ""
                        Else
                            ContainerMaster.txtlengthi.Text = DG.Item(DG.CurrentRowIndex, 5)
                        End If
                        'ContainerMaster.txtlengthi.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 5)), "", DG.Item(DG.CurrentRowIndex, 5))
                        If Val(DG.Item(DG.CurrentRowIndex, 6)) = 0 Then
                            ContainerMaster.txtwidthi.Text = ""
                        Else
                            ContainerMaster.txtwidthi.Text = DG.Item(DG.CurrentRowIndex, 6)
                        End If
                        'ContainerMaster.txtwidthi.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 6)), "", DG.Item(DG.CurrentRowIndex, 6))
                        If Val(DG.Item(DG.CurrentRowIndex, 7)) = 0 Then
                            ContainerMaster.txtheighti.Text = ""
                        Else
                            ContainerMaster.txtheighti.Text = DG.Item(DG.CurrentRowIndex, 7)
                        End If
                        'ContainerMaster.txtheighti.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 7)), "", DG.Item(DG.CurrentRowIndex, 7))
                        If Val(DG.Item(DG.CurrentRowIndex, 8)) = 0 Then
                            ContainerMaster.txtlengthc.Text = ""
                        Else
                            ContainerMaster.txtlengthc.Text = DG.Item(DG.CurrentRowIndex, 8)
                        End If
                        'ContainerMaster.txtlengthc.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 8)), "", DG.Item(DG.CurrentRowIndex, 8))
                        If Val(DG.Item(DG.CurrentRowIndex, 9)) = 0 Then
                            ContainerMaster.txtwidthc.Text = ""
                        Else
                            ContainerMaster.txtwidthc.Text = DG.Item(DG.CurrentRowIndex, 9)
                        End If
                        'ContainerMaster.txtwidthc.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 9)), "", DG.Item(DG.CurrentRowIndex, 9))
                        If Val(DG.Item(DG.CurrentRowIndex, 10)) = 0 Then
                            ContainerMaster.txtheightc.Text = ""
                        Else
                            ContainerMaster.txtheightc.Text = DG.Item(DG.CurrentRowIndex, 10)
                        End If
                        'ContainerMaster.txtheightc.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 10)), "", DG.Item(DG.CurrentRowIndex, 10))
                        If Val(DG.Item(DG.CurrentRowIndex, 11)) = 0 Then
                            ContainerMaster.txtlengthm.Text = ""
                        Else
                            ContainerMaster.txtlengthm.Text = DG.Item(DG.CurrentRowIndex, 11)
                        End If
                        'ContainerMaster.txtlengthm.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 11)), "", DG.Item(DG.CurrentRowIndex, 11))
                        If Val(DG.Item(DG.CurrentRowIndex, 12)) = 0 Then
                            ContainerMaster.txtwidthm.Text = ""
                        Else
                            ContainerMaster.txtwidthm.Text = DG.Item(DG.CurrentRowIndex, 12)
                        End If
                        'ContainerMaster.txtwidthm.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 12)), "", DG.Item(DG.CurrentRowIndex, 12))
                        If Val(DG.Item(DG.CurrentRowIndex, 13)) = 0 Then
                            ContainerMaster.txtheightm.Text = ""
                        Else
                            ContainerMaster.txtheightm.Text = DG.Item(DG.CurrentRowIndex, 13)
                        End If
                        ' ContainerMaster.txtheightm.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 13)), "", DG.Item(DG.CurrentRowIndex, 13))
                        ContainerMaster.txtloadkg.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 14)), "", DG.Item(DG.CurrentRowIndex, 14))
                        ContainerMaster.txtloadlbs.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 14) * 2.2045), "", DG.Item(DG.CurrentRowIndex, 14) * 2.2045)
                        ContainerMaster.txttotalsize.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 15)), "", DG.Item(DG.CurrentRowIndex, 15))
                        ContainerMaster.txttotalsizef.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 16)), "", DG.Item(DG.CurrentRowIndex, 16))
                        'Me.Top = 0 : Me.Left = 0
                    Case "Freight"
                        Me.Close()
                        FreightMaster.Show()
                        FreightMaster.CmbCountry.DropDownStyle = ComboBoxStyle.DropDown
                        FreightMaster.CmbCountry.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 0)), "", DG.Item(DG.CurrentRowIndex, 0))
                        'FreightMaster.CmbCountry.DropDownStyle = ComboBoxStyle.DropDownList
                        FreightMaster.txtfreight.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 1)), "", DG.Item(DG.CurrentRowIndex, 1))
                        FreightMaster.txtfreightid.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 2)), "", DG.Item(DG.CurrentRowIndex, 2))
                End Select
            End If
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in DG_DoubleClick", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Txtsearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtsearch.KeyDown

        If e.KeyCode = Keys.Enter Then Button1.Focus()

    End Sub

    Private Sub Txtsearch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtsearch.TextChanged

        Try
            Me.Txtsearch.Focus()
            Dim StrR As String
            StrR = Replace(Txtsearch.Text, "'", "`")

            Select Case title
                Case "Customer"
                    FindStr = "SELECT CustomerCode,CustomerName,Address1,City,Telno1,Telno2,Country,PinCode FROM CustomerMaster where CustomerName like '" & StrR & "%' Order by CustomerName"
                    DG.DataSource = Module1.rec_search(FindStr, DT)
                    DG.DataMember = DT
                    CustomerMasterTableStyleProperties(DG)
                Case "Container"
                    FindStr = "Select ContainerNo,ContainerName,LengthF,WidthF,HeightF,LengthI,WidthI,HeightI,LengthC,WidthC,HeightC,LengthM,WidthM,HeightM,PayLoad,TotalSize,TotalSizeF FROM ContainerMaster where ContainerName like '" & StrR & "%' order by ContainerName"
                    DG.DataSource = Module1.rec_search(FindStr, DT)
                    DG.DataMember = DT
                    ContainerMasterTableStyleProperties(DG)
                Case "PackMast"
                    FindStr = "SELECT * FROM PackMast where PackName like '" & StrR & "%' Order by PackName"
                    DG.DataSource = Module1.rec_search(FindStr, DT)
                    DG.DataMember = DT
                    PackMasterTableStyleProperties(DG)
                Case "Freight"
                    FindStr = "select Country,Freight,FreightId FROM FreightSea where Country like '" & StrR & "%' order by Country"
                    DG.DataSource = Module1.rec_search(FindStr, DT)
                    DG.DataMember = DT
                    FreightMasterTableStyleProperties(DG)
            End Select
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in Txtsearch_TextChanged", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Try
            If DG.CurrentRowIndex >= 0 And Len(Trim(Txtsearch.Text)) <> 0 Then
                Select Case title
                    Case "Customer"
                        ''Me.Close()
                        CustomerMaster.Show()
                        CustomerMaster.txtcustcode.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 0)), "", DG.Item(DG.CurrentRowIndex, 0))
                        CustomerMaster.txtcustname.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 1)), "", DG.Item(DG.CurrentRowIndex, 1))
                        CustomerMaster.txtadd.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 2)), "", DG.Item(DG.CurrentRowIndex, 2))
                        CustomerMaster.txtcity.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 3)), "", DG.Item(DG.CurrentRowIndex, 3))
                        CustomerMaster.txttelno.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 4)), "", DG.Item(DG.CurrentRowIndex, 4))
                        CustomerMaster.txtmobileno.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 5)), "", DG.Item(DG.CurrentRowIndex, 5))
                        CustomerMaster.CmbCountry.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 6)), "", DG.Item(DG.CurrentRowIndex, 6))
                        CustomerMaster.txtpincode.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 7)), "", DG.Item(DG.CurrentRowIndex, 7))
                    Case "Container"
                        ''Me.Close()
                        ContainerMaster.Show()
                        ContainerMaster.Txtclear()
                        ContainerMaster.txtcontno.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 0)), "", DG.Item(DG.CurrentRowIndex, 0))
                        ContainerMaster.txtcontname.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 1)), "", DG.Item(DG.CurrentRowIndex, 1))
                        If Val(DG.Item(DG.CurrentRowIndex, 2)) = 0 Then
                            ContainerMaster.txtlengthf.Text = ""
                        Else
                            ContainerMaster.txtlengthf.Text = DG.Item(DG.CurrentRowIndex, 2)
                        End If
                        'ContainerMaster.txtlengthf.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 2)), "", DG.Item(DG.CurrentRowIndex, 2))
                        If Val(DG.Item(DG.CurrentRowIndex, 3)) = 0 Then
                            ContainerMaster.txtwidthf.Text = ""
                        Else
                            ContainerMaster.txtwidthf.Text = DG.Item(DG.CurrentRowIndex, 3)
                        End If
                        'ContainerMaster.txtwidthf.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 3)), "", DG.Item(DG.CurrentRowIndex, 3))
                        If Val(DG.Item(DG.CurrentRowIndex, 4)) = 0 Then
                            ContainerMaster.txtheightf.Text = ""
                        Else
                            ContainerMaster.txtheightf.Text = DG.Item(DG.CurrentRowIndex, 4)
                        End If
                        'ContainerMaster.txtheightf.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 4)), "", DG.Item(DG.CurrentRowIndex, 4))
                        If Val(DG.Item(DG.CurrentRowIndex, 5)) = 0 Then
                            ContainerMaster.txtlengthi.Text = ""
                        Else
                            ContainerMaster.txtlengthi.Text = DG.Item(DG.CurrentRowIndex, 5)
                        End If
                        'ContainerMaster.txtlengthi.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 5)), "", DG.Item(DG.CurrentRowIndex, 5))
                        If Val(DG.Item(DG.CurrentRowIndex, 6)) = 0 Then
                            ContainerMaster.txtwidthi.Text = ""
                        Else
                            ContainerMaster.txtwidthi.Text = DG.Item(DG.CurrentRowIndex, 6)
                        End If
                        'ContainerMaster.txtwidthi.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 6)), "", DG.Item(DG.CurrentRowIndex, 6))
                        If Val(DG.Item(DG.CurrentRowIndex, 7)) = 0 Then
                            ContainerMaster.txtheighti.Text = ""
                        Else
                            ContainerMaster.txtheighti.Text = DG.Item(DG.CurrentRowIndex, 7)
                        End If
                        'ContainerMaster.txtheighti.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 7)), "", DG.Item(DG.CurrentRowIndex, 7))
                        If Val(DG.Item(DG.CurrentRowIndex, 8)) = 0 Then
                            ContainerMaster.txtlengthc.Text = ""
                        Else
                            ContainerMaster.txtlengthc.Text = DG.Item(DG.CurrentRowIndex, 8)
                        End If
                        'ContainerMaster.txtlengthc.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 8)), "", DG.Item(DG.CurrentRowIndex, 8))
                        If Val(DG.Item(DG.CurrentRowIndex, 9)) = 0 Then
                            ContainerMaster.txtwidthc.Text = ""
                        Else
                            ContainerMaster.txtwidthc.Text = DG.Item(DG.CurrentRowIndex, 9)
                        End If
                        'ContainerMaster.txtwidthc.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 9)), "", DG.Item(DG.CurrentRowIndex, 9))
                        If Val(DG.Item(DG.CurrentRowIndex, 10)) = 0 Then
                            ContainerMaster.txtheightc.Text = ""
                        Else
                            ContainerMaster.txtheightc.Text = DG.Item(DG.CurrentRowIndex, 10)
                        End If
                        'ContainerMaster.txtheightc.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 10)), "", DG.Item(DG.CurrentRowIndex, 10))
                        If Val(DG.Item(DG.CurrentRowIndex, 11)) = 0 Then
                            ContainerMaster.txtlengthm.Text = ""
                        Else
                            ContainerMaster.txtlengthm.Text = DG.Item(DG.CurrentRowIndex, 11)
                        End If
                        'ContainerMaster.txtlengthm.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 11)), "", DG.Item(DG.CurrentRowIndex, 11))
                        If Val(DG.Item(DG.CurrentRowIndex, 12)) = 0 Then
                            ContainerMaster.txtwidthm.Text = ""
                        Else
                            ContainerMaster.txtwidthm.Text = DG.Item(DG.CurrentRowIndex, 12)
                        End If
                        'ContainerMaster.txtwidthm.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 12)), "", DG.Item(DG.CurrentRowIndex, 12))
                        If Val(DG.Item(DG.CurrentRowIndex, 13)) = 0 Then
                            ContainerMaster.txtheightm.Text = ""
                        Else
                            ContainerMaster.txtheightm.Text = DG.Item(DG.CurrentRowIndex, 13)
                        End If
                        ' ContainerMaster.txtheightm.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 13)), "", DG.Item(DG.CurrentRowIndex, 13))
                        ContainerMaster.txtloadkg.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 14)), "", DG.Item(DG.CurrentRowIndex, 14))
                        ContainerMaster.txtloadlbs.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 14) * 2.2045), "", DG.Item(DG.CurrentRowIndex, 14) * 2.2045)
                        ContainerMaster.txttotalsize.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 15)), "", DG.Item(DG.CurrentRowIndex, 15))
                        ContainerMaster.txttotalsizef.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 16)), "", DG.Item(DG.CurrentRowIndex, 16))
                        'Me.Top = 0 : Me.Left = 0
                    Case "PackMast"
                        ''Me.Close()
                        MasterCartonEntry.Show()
                        MasterCartonEntry.txtpackcode.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 0)), "", DG.Item(DG.CurrentRowIndex, 0))
                        MasterCartonEntry.txtpackname.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 1)), "", DG.Item(DG.CurrentRowIndex, 1))
                        If Val(DG.Item(DG.CurrentRowIndex, 2)) = 0 Then
                            MasterCartonEntry.txtlengthf.Text = ""
                        Else
                            MasterCartonEntry.txtlengthf.Text = DG.Item(DG.CurrentRowIndex, 2)
                        End If
                        'MasterCartonEntry.txtlengthf.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 2)), "", DG.Item(DG.CurrentRowIndex, 2))
                        If Val(DG.Item(DG.CurrentRowIndex, 3)) = 0 Then
                            MasterCartonEntry.txtlengthi.Text = ""
                        Else
                            MasterCartonEntry.txtlengthi.Text = DG.Item(DG.CurrentRowIndex, 3)
                        End If
                        'MasterCartonEntry.txtlengthi.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 3)), "", DG.Item(DG.CurrentRowIndex, 3))
                        If Val(DG.Item(DG.CurrentRowIndex, 4)) = 0 Then
                            MasterCartonEntry.txtlengthc.Text = ""
                        Else
                            MasterCartonEntry.txtlengthc.Text = DG.Item(DG.CurrentRowIndex, 4)
                        End If
                        'MasterCartonEntry.txtlengthc.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 4)), "", DG.Item(DG.CurrentRowIndex, 4))
                        If Val(DG.Item(DG.CurrentRowIndex, 5)) = 0 Then
                            MasterCartonEntry.txtwidthf.Text = ""
                        Else
                            MasterCartonEntry.txtwidthf.Text = DG.Item(DG.CurrentRowIndex, 5)
                        End If
                        'MasterCartonEntry.txtwidthf.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 5)), "", DG.Item(DG.CurrentRowIndex, 5))
                        If Val(DG.Item(DG.CurrentRowIndex, 6)) = 0 Then
                            MasterCartonEntry.txtwidthi.Text = ""
                        Else
                            MasterCartonEntry.txtwidthi.Text = DG.Item(DG.CurrentRowIndex, 6)
                        End If
                        'MasterCartonEntry.txtwidthi.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 6)), "", DG.Item(DG.CurrentRowIndex, 6))
                        If Val(DG.Item(DG.CurrentRowIndex, 7)) = 0 Then
                            MasterCartonEntry.txtwidthc.Text = ""
                        Else
                            MasterCartonEntry.txtwidthc.Text = DG.Item(DG.CurrentRowIndex, 7)
                        End If
                        'MasterCartonEntry.txtwidthc.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 7)), "", DG.Item(DG.CurrentRowIndex, 7))
                        If Val(DG.Item(DG.CurrentRowIndex, 8)) = 0 Then
                            MasterCartonEntry.txtheightf.Text = ""
                        Else
                            MasterCartonEntry.txtheightf.Text = DG.Item(DG.CurrentRowIndex, 8)
                        End If
                        'MasterCartonEntry.txtheightf.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 8)), "", DG.Item(DG.CurrentRowIndex, 8))
                        If Val(DG.Item(DG.CurrentRowIndex, 9)) = 0 Then
                            MasterCartonEntry.txtheighti.Text = ""
                        Else
                            MasterCartonEntry.txtheighti.Text = DG.Item(DG.CurrentRowIndex, 9)
                        End If
                        'MasterCartonEntry.txtheighti.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 9)), "", DG.Item(DG.CurrentRowIndex, 9))
                        If Val(DG.Item(DG.CurrentRowIndex, 10)) = 0 Then
                            MasterCartonEntry.txtheightc.Text = ""
                        Else
                            MasterCartonEntry.txtheightc.Text = DG.Item(DG.CurrentRowIndex, 10)
                        End If
                        'MasterCartonEntry.txtheightc.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 10)), "", DG.Item(DG.CurrentRowIndex, 10))

                        MasterCartonEntry.txtpackingmode.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 11)), "", DG.Item(DG.CurrentRowIndex, 11))
                        MasterCartonEntry.txtnetweight.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 12)), "", DG.Item(DG.CurrentRowIndex, 12))
                        MasterCartonEntry.txtgrossweight.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 13)), "", DG.Item(DG.CurrentRowIndex, 13))
                        MasterCartonEntry.txttotalsize.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 14)), "", DG.Item(DG.CurrentRowIndex, 14))
                        MasterCartonEntry.txtfactor.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 15)), "", DG.Item(DG.CurrentRowIndex, 15))
                        If Val(DG.Item(DG.CurrentRowIndex, 16)) = 0 Then
                            MasterCartonEntry.txtheightm.Text = ""
                        Else
                            MasterCartonEntry.txtheightm.Text = DG.Item(DG.CurrentRowIndex, 16)
                        End If
                        'MasterCartonEntry.txtheightm.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 16)), "", DG.Item(DG.CurrentRowIndex, 16))
                        If Val(DG.Item(DG.CurrentRowIndex, 17)) = 0 Then
                            MasterCartonEntry.txtwidthm.Text = ""
                        Else
                            MasterCartonEntry.txtwidthm.Text = DG.Item(DG.CurrentRowIndex, 17)
                        End If
                        'MasterCartonEntry.txtwidthm.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 17)), "", DG.Item(DG.CurrentRowIndex, 17))
                        If Val(DG.Item(DG.CurrentRowIndex, 18)) = 0 Then
                            MasterCartonEntry.txtlengthm.Text = ""
                        Else
                            MasterCartonEntry.txtlengthm.Text = DG.Item(DG.CurrentRowIndex, 18)
                        End If
                        'MasterCartonEntry.txtlengthm.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 18)), "", DG.Item(DG.CurrentRowIndex, 18))
                        MasterCartonEntry.txttotalsizef.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 19)), "", DG.Item(DG.CurrentRowIndex, 19))
                        MasterCartonEntry.cmbcontname.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 20)), "", DG.Item(DG.CurrentRowIndex, 20))
                        MasterCartonEntry.txtmaxqty.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 21)), "", DG.Item(DG.CurrentRowIndex, 21))
                        MasterCartonEntry.txtmaxweight.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 22)), "", DG.Item(DG.CurrentRowIndex, 22))
                        MasterCartonEntry.TxtCId.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 23)), "", DG.Item(DG.CurrentRowIndex, 23))
                    Case "Freight"
                        ''Me.Close()
                        FreightMaster.Show()
                        FreightMaster.CmbCountry.DropDownStyle = ComboBoxStyle.DropDown
                        FreightMaster.CmbCountry.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 0)), "", DG.Item(DG.CurrentRowIndex, 0))
                        'FreightMaster.CmbCountry.DropDownStyle = ComboBoxStyle.DropDownList
                        FreightMaster.txtfreight.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 1)), "", DG.Item(DG.CurrentRowIndex, 1))
                        FreightMaster.txtfreightid.Text = IIf(IsDBNull(DG.Item(DG.CurrentRowIndex, 2)), "", DG.Item(DG.CurrentRowIndex, 2))
                End Select
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in Button1_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub PackMasterTableStyleProperties(ByRef myDG As DataGrid) 'Add GridColumn Title 

        Dim mydgTableStyle As New DataGridTableStyle
        Dim mygrdColStyle1 As DataGridTextBoxColumn

        Try
            With mydgTableStyle
                .MappingName = "MasterCartonEntry"
            End With
            mygrdColStyle1 = New DataGridTextBoxColumn
            With mygrdColStyle1
                .HeaderText = "PackCode"
                .MappingName = "PackCode"
                .Width = 0
                .NullText = ""
                .ReadOnly = True
            End With
            mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)
            '
            mygrdColStyle1 = New DataGridTextBoxColumn
            With mygrdColStyle1
                .HeaderText = "Pack Name"
                .MappingName = "PackName"
                .Width = 150
                .NullText = ""
                .ReadOnly = True
            End With
            mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

            mygrdColStyle1 = New DataGridTextBoxColumn
            With mygrdColStyle1
                .HeaderText = "LengthF"
                .MappingName = "LengthF"
                .Width = 60
                .NullText = ""
                .ReadOnly = True
            End With
            mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

            mygrdColStyle1 = New DataGridTextBoxColumn
            With mygrdColStyle1
                .HeaderText = "LengthI"
                .MappingName = "LengthI"
                .Width = 60
                .NullText = ""
                .ReadOnly = True
            End With
            mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

            mygrdColStyle1 = New DataGridTextBoxColumn
            With mygrdColStyle1
                .HeaderText = "LengthC"
                .MappingName = "LengthC"
                .Width = 60
                .NullText = ""
                .ReadOnly = True
            End With
            mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

            mygrdColStyle1 = New DataGridTextBoxColumn
            With mygrdColStyle1
                .HeaderText = "WidthF"
                .MappingName = "WidthF"
                .Width = 60
                .NullText = ""
                .ReadOnly = True
            End With
            mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

            mygrdColStyle1 = New DataGridTextBoxColumn
            With mygrdColStyle1
                .HeaderText = "WidthI"
                .MappingName = "WidthI"
                .Width = 60
                .NullText = ""
                .ReadOnly = True
            End With
            mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

            mygrdColStyle1 = New DataGridTextBoxColumn
            With mygrdColStyle1
                .HeaderText = "WidthC"
                .MappingName = "WidthC"
                .Width = 60
                .NullText = ""
                .ReadOnly = True
            End With
            mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

            mygrdColStyle1 = New DataGridTextBoxColumn
            With mygrdColStyle1
                .HeaderText = "HeightF"
                .MappingName = "HeightF"
                .Width = 60
                .NullText = ""
                .ReadOnly = True
            End With
            mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

            mygrdColStyle1 = New DataGridTextBoxColumn
            With mygrdColStyle1
                .HeaderText = "HeightI"
                .MappingName = "HeightI"
                .Width = 60
                .NullText = ""
                .ReadOnly = True
            End With
            mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

            mygrdColStyle1 = New DataGridTextBoxColumn
            With mygrdColStyle1
                .HeaderText = "HeightC"
                .MappingName = "HeightC"
                .Width = 60
                .NullText = ""
                .ReadOnly = True
            End With
            mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

            mygrdColStyle1 = New DataGridTextBoxColumn
            With mygrdColStyle1
                .HeaderText = "PackingMode"
                .MappingName = "PackingMode"
                .Width = 60
                .NullText = ""
                .ReadOnly = True
            End With
            mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

            mygrdColStyle1 = New DataGridTextBoxColumn
            With mygrdColStyle1
                .HeaderText = "Netweight"
                .MappingName = "Netweight"
                .Width = 60
                .NullText = ""
                .ReadOnly = True
            End With
            mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

            mygrdColStyle1 = New DataGridTextBoxColumn
            With mygrdColStyle1
                .HeaderText = "Grossweight"
                .MappingName = "Grossweight"
                .Width = 60
                .NullText = ""
                .ReadOnly = True
            End With
            mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

            mygrdColStyle1 = New DataGridTextBoxColumn
            With mygrdColStyle1
                .HeaderText = "Totalsize"
                .MappingName = "Totalsize"
                .Width = 60
                .NullText = ""
                .ReadOnly = True
            End With
            mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

            mygrdColStyle1 = New DataGridTextBoxColumn
            With mygrdColStyle1
                .HeaderText = "Factor"
                .MappingName = "Factor"
                .Width = 60
                .NullText = ""
                .ReadOnly = True
            End With
            mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

            mygrdColStyle1 = New DataGridTextBoxColumn
            With mygrdColStyle1
                .HeaderText = "HeightMm"
                .MappingName = "HeightM"
                .Width = 60
                .NullText = ""
                .ReadOnly = True
            End With
            mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

            mygrdColStyle1 = New DataGridTextBoxColumn
            With mygrdColStyle1
                .HeaderText = "WidthMm"
                .MappingName = "WidthM"
                .Width = 60
                .NullText = ""
                .ReadOnly = True
            End With
            mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)
            '
            mygrdColStyle1 = New DataGridTextBoxColumn
            With mygrdColStyle1
                .HeaderText = "LengthMm"
                .MappingName = "LengthM"
                .Width = 60
                .NullText = ""
                .ReadOnly = True
            End With
            mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

            mygrdColStyle1 = New DataGridTextBoxColumn
            With mygrdColStyle1
                .HeaderText = "TotalsizeCF"
                .MappingName = "TotalsizeF"
                .Width = 80
                .NullText = ""
                .ReadOnly = True
            End With
            mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

            mygrdColStyle1 = New DataGridTextBoxColumn
            With mygrdColStyle1
                .HeaderText = "Container Name"
                .MappingName = "ContainerName"
                .Width = 60
                .NullText = ""
                .ReadOnly = True
            End With
            mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

            mygrdColStyle1 = New DataGridTextBoxColumn
            With mygrdColStyle1
                .HeaderText = "MaxCont"
                .MappingName = "MaxCont"
                .Width = 60
                .NullText = ""
                .ReadOnly = True
            End With
            mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

            mygrdColStyle1 = New DataGridTextBoxColumn
            With mygrdColStyle1
                .HeaderText = "MaxWeight"
                .MappingName = "MaxWeight"
                .Width = 60
                .NullText = ""
                .ReadOnly = True
            End With
            mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

            mygrdColStyle1 = New DataGridTextBoxColumn
            With mygrdColStyle1
                .HeaderText = "ContainerId"
                .MappingName = "ContainerId"
                .Width = 0
                .NullText = ""
                .ReadOnly = True
            End With
            mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

            myDG.TableStyles.Clear()
            myDG.TableStyles.Add(mydgTableStyle)
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in PackMasterTableStyleProperties", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub CustomerMasterTableStyleProperties(ByRef myDG As DataGrid) 'Add GridColumn Title 

        Dim mydgTableStyle As New DataGridTableStyle
        Dim mygrdColStyle1 As DataGridTextBoxColumn

        Try
            With mydgTableStyle
                .MappingName = "CustomerMaster"
            End With
            mygrdColStyle1 = New DataGridTextBoxColumn
            With mygrdColStyle1
                .HeaderText = "CustomerCode"
                .MappingName = "CustomerCode"
                .Width = 0
                .NullText = ""
                .ReadOnly = True
            End With
            mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)
            '
            mygrdColStyle1 = New DataGridTextBoxColumn
            With mygrdColStyle1
                .HeaderText = "Customer Name"
                .MappingName = "CustomerName"
                .Width = 150
                .NullText = ""
                .ReadOnly = True
            End With
            mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

            mygrdColStyle1 = New DataGridTextBoxColumn
            With mygrdColStyle1
                .HeaderText = "Address"
                .MappingName = "Address1"
                .Width = 60
                .NullText = ""
                .ReadOnly = True
            End With
            mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

            mygrdColStyle1 = New DataGridTextBoxColumn
            With mygrdColStyle1
                .HeaderText = "City"
                .MappingName = "City"
                .Width = 60
                .NullText = ""
                .ReadOnly = True
            End With
            mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

            mygrdColStyle1 = New DataGridTextBoxColumn
            With mygrdColStyle1
                .HeaderText = "Telno."
                .MappingName = "Telno1"
                .Width = 60
                .NullText = ""
                .ReadOnly = True
            End With
            mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

            mygrdColStyle1 = New DataGridTextBoxColumn
            With mygrdColStyle1
                .HeaderText = "Mobile No"
                .MappingName = "Telno2"
                .Width = 60
                .NullText = ""
                .ReadOnly = True
            End With
            mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

            mygrdColStyle1 = New DataGridTextBoxColumn
            With mygrdColStyle1
                .HeaderText = "Country"
                .MappingName = "Country"
                .Width = 60
                .NullText = ""
                .ReadOnly = True
            End With
            mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

            mygrdColStyle1 = New DataGridTextBoxColumn
            With mygrdColStyle1
                .HeaderText = "PinCode"
                .MappingName = "PinCode"
                .Width = 60
                .NullText = ""
                .ReadOnly = True
            End With
            mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

            myDG.TableStyles.Clear()
            myDG.TableStyles.Add(mydgTableStyle)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in CustomerMasterTableStyleProperties", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub FreightMasterTableStyleProperties(ByRef myDG As DataGrid) 'Add GridColumn Title 

        Dim mydgTableStyle As New DataGridTableStyle
        Dim mygrdColStyle1 As DataGridTextBoxColumn

        Try
            With mydgTableStyle
                .MappingName = "FreightSea"
            End With
            mygrdColStyle1 = New DataGridTextBoxColumn
            With mygrdColStyle1
                .HeaderText = "Country"
                .MappingName = "Country"
                .Width = 100
                .NullText = ""
                .ReadOnly = True
            End With
            mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)
            '
            mygrdColStyle1 = New DataGridTextBoxColumn
            With mygrdColStyle1
                .HeaderText = "Freight"
                .MappingName = "Freight"
                .Width = 60
                .NullText = ""
                .ReadOnly = True
            End With
            mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)

            mygrdColStyle1 = New DataGridTextBoxColumn
            With mygrdColStyle1
                .HeaderText = "FreightId"
                .MappingName = "FreightId"
                .Width = 0
                .NullText = ""
                .ReadOnly = True
            End With
            mydgTableStyle.GridColumnStyles.Add(mygrdColStyle1)
            myDG.TableStyles.Clear()
            myDG.TableStyles.Add(mydgTableStyle)
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in FreightMasterTableStyleProperties", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class
