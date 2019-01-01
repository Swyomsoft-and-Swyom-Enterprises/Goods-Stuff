
'Program Name: -    Summarised Report.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    Sky Stuff Plus (Container Stuffing)
'Date: -            22 Dec 2K8 5.40 PM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - These form shown the reports in sky stuff plus project i.e. container stuff reports. 


#Region " Importing Object "

Imports SDO = System.Data.OleDb

#End Region

Public NotInheritable Class ContainerReport
    Inherits System.Windows.Forms.Form

#Region " Class Declaration "

    Dim opt As Byte
    Dim str As String
    Dim Da1 As SDO.OleDbDataAdapter
    Dim Ds1 As New DataSet

#End Region

#Region " Routine Definition "

    Private Sub ContainerReport_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call MDIForm.BringFront()
    End Sub

    Private Sub ContainerReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Close()
    End Sub

    Private Sub Summarised_Report_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            'Me.Top = 60 : Me.Left = 250

            Me.StartPosition = FormStartPosition.CenterScreen

            Dim strSQL As String
            'strSQL = "Select * from InwardHead"
            'strSQL = "Select * from NInwardHead"
            strSQL = "Select distinct ReceiptNo from NInwardDetail"

            '--------------
            Dim da1 As New SDO.OleDbDataAdapter(strSQL, conn)
            If Ds1.Tables.CanRemove(Ds1.Tables("TabRno")) = True Then
                Ds1.Tables("TabRno").Rows.Clear()
                Ds1.Tables("TabRno").Columns.Clear()
            End If
            da1.Fill(Ds1, "TabRno")

            CmbRNumber.DataSource = Nothing
            CmbRNumber.DataSource = Ds1.Tables("TabRno").DefaultView
            CmbRNumber.DisplayMember = "Receiptno"

            '---------------

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Summarised Report Load", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmbleftmargin_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        If cmbleftmargin.Text = "Inches" Then
            numupdown2.Minimum = 0
            numupdown2.Maximum = 8.5
        End If
        If cmbleftmargin.Text = "Cms" Then
            numupdown2.Minimum = 0
            numupdown2.Maximum = 21.25
        End If
        If cmbleftmargin.Text = "Inches" Then
            numupdown2.Minimum = 0
            numupdown2.Maximum = 12240
        End If

    End Sub

    Private Sub cmbtopmargin_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If cmbtopmargin.Text = "Inches" Then
            numupdown1.Minimum = 0
            numupdown1.Maximum = 12
        End If
        If cmbtopmargin.Text = "Cms" Then
            numupdown1.Minimum = 0
            numupdown1.Maximum = 30
        End If
        If cmbtopmargin.Text = "Pixels" Then
            numupdown1.Minimum = 0
            numupdown1.Maximum = 17280
        End If
    End Sub

    Private Sub numupdown1_click()

        If cmbtopmargin.Text = "Inches" Then
            numupdown1.Value = (CLng(numupdown1.Text) * 1440)
        ElseIf cmbtopmargin.Text = "Cms" Then
            numupdown2.Value = (CLng(numupdown1.Text) * 567)
        ElseIf cmbtopmargin.Text = "pixels" Then
            numupdown1.Value = (CLng(numupdown1.Text))
        End If

    End Sub

    Private Sub numupdown2_click()

        If cmbleftmargin.Text = "Inches" Then
            numupdown2.Value = (CLng(numupdown2.Text) * 1440)
        ElseIf cmbleftmargin.Text = "Cms" Then
            numupdown2.Value = (CLng(numupdown2.Text) * 567)
        ElseIf cmbleftmargin.Text = "Pixels" Then
            numupdown2.Value = (CLng(numupdown2.Text))
        End If

    End Sub

    Private Sub btnallrecpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnallrecpt.Click

        Try
            Cursor = Cursors.WaitCursor
            'Cr1.SelectionFormula = "{InwardDetail.itemcode} > 0 And {Inwardhead.receiptno} >=1 "
            Cr1.ReportSource = CurDir() & "\Report1.rpt"
            Cr1.Refresh()
            Cursor = Cursors.Default

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in All Recpt Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnselrecpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnselrecpt.Click

        Try
            Cursor = Cursors.WaitCursor
            Cr1.SelectionFormula = "{NInwardDetail.ReceiptNo} = " & Val(CmbRNumber.Text)
            Cr1.ReportSource = CurDir() & "\Report1.rpt"
            Cr1.Refresh()
            Cursor = Cursors.Default
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in Select Recpt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub CmbRNumber_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbRNumber.KeyDown

        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            If CmbRNumber.Text <> "" Then
                btnselrecpt.Enabled = True
                btnselrecpt.Focus()
            Else
                btnselrecpt.Enabled = False
                btnallrecpt.Focus()
            End If
        End If

    End Sub

    Private Sub CmbRNumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbRNumber.TextChanged

        If CmbRNumber.Text = "" Then
            btnselrecpt.Enabled = False
        Else
            btnselrecpt.Enabled = True
        End If
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

#End Region

End Class