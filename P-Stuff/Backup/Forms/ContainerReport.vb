
'Program Name: -    ContainerReport.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    P-Stuff Plus (Container Stuffing)
'Date: -            22 Dec 2K8 5.35 PM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - These form shown the reports in sky stuff plus project i.e. container stuff reports. 

Public NotInheritable Class Reports
    Inherits System.Windows.Forms.Form

#Region " Routine Definitions "

    Private Sub Button1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseHover

        ToolStripStatusLabel1.Text = "Click to open Summarized Container Report."

    End Sub

    Private Sub Reports_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Call MDIForm.BringFront()
    End Sub

    Private Sub Reports_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call MDIForm.BringFront()
    End Sub

    Private Sub ContainerReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Top = 235 : Me.Left = 265
        ToolStripStatusLabel1.Text = ""

    End Sub

    Private Sub Button1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseLeave

        ToolStripStatusLabel1.Text = ""

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        ContainerReport.Show()

    End Sub

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class

