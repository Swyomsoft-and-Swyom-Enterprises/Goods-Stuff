
'Program Name: -    ChooseActivity.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    P-Stuff Plus (Container Stuffing)
'Date: -            22 Dec 2K8 5.00 PM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - ChooseActivity is the form to select the box drum stuffing activity by 
'               separate controls

Public NotInheritable Class ChooseActivity
    Inherits System.Windows.Forms.Form

#Region " Routine Definitions"

    Private Sub btnRestart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRestart.Click

        Try

            MDIForm.Focus()
            GC.Collect()
            Try
                DisplayActivity.lblDisplayActivity.Visible = True
                DisplayActivity.lblDisplayActivity.Text = "Please wait..." & Chr(13) & "The container stuffing application is restarting"
                DisplayActivity.Show()
                Me.Dispose(True)
            Catch Ex As Exception
                Exit Try
            Finally
                Me.Dispose(True)
                Me.Close()
                Application.Exit()
                GC.Collect()
                Process.Start(CurDir() & "\Container Stuff.exe")
            End Try

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in btnRestart_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnBoxType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoxType.Click

        Try
            MDIForm.Focus()
            Me.Close()
            GC.Collect()
            Try
                DisplayActivity.lblDisplayActivity.Visible = True
                DisplayActivity.lblDisplayActivity.Text = "Please wait..." & vbCrLf & "Box type stuffing activity show"
                DisplayActivity.Show()
                Me.Dispose(True)
            Catch ex As Exception
                Exit Try
            Finally
                TransactionMenu.Show()
            End Try

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in btnBoxType_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnDrumtype_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDrumtype.Click

        Try

            MDIForm.Focus()
            Me.Close()
            GC.Collect()
            Try
                DisplayActivity.lblDisplayActivity.Visible = True
                DisplayActivity.lblDisplayActivity.Text = "Please wait..." & vbCrLf & "Drum type stuffing activity show"

                DisplayActivity.Show()      'Showing the display activity form in 2 second for changing the activity
                Me.Dispose(True)
            Catch Ex As Exception
            Finally
                TransactionsMenu.Show()
            End Try

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in btnDrumtype_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSettings.Click
        ActivitySettings.Show()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose(True)
        Me.Close()
    End Sub

    Private Sub btnStuffViewer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStuffViewer.Click
        Stuff_Viewers.Show()
        Stuff_Viewers.Focus()
        Me.Dispose(True)
        Me.Close()
    End Sub

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class