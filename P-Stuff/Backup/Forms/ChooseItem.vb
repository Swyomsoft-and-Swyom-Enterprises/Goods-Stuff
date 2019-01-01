
'Program Name: -    ChooseItem.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    P-Stuff Plus (Container Stuffing)
'Date: -            22 Dec 2K8 5.00 PM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - ChooseItem is the form to select the box drum goods i.e. items activity by 
'               separate controls

Public NotInheritable Class ChooseItem
    Inherits System.Windows.Forms.Form

#Region " Routine Definitions "

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose(True)
        Me.Close()
    End Sub

    Private Sub btnRestart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRestart.Click

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

    End Sub

    Private Sub btnBoxtypeitem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoxtypeitem.Click

        MDIForm.Focus()
        Me.Close()
        GC.Collect()
        Try
            DisplayActivity.lblDisplayActivity.Visible = True
            DisplayActivity.lblDisplayActivity.Text = "Please wait..." & vbCrLf & "Box type item entry activity show"

            DisplayActivity.Show()
            Me.Dispose(True)
        Catch ex As Exception
            Exit Try
        Finally
            Try
                MasterCartonEntry.ShowDialog()
            Catch Ex As Exception
                MsgBox(Ex.Message)
                Application.Exit()

            End Try
        End Try
    End Sub

    Private Sub btnDrumtypeitem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDrumtypeitem.Click

        MDIForm.Focus()
        Me.Close()
        GC.Collect()
        Try
            DisplayActivity.lblDisplayActivity.Visible = True
            DisplayActivity.lblDisplayActivity.Text = "Please wait..." & vbCrLf & "Drum type item entry activity show"

            DisplayActivity.Show()
            Me.Dispose(True)
        Catch ex As Exception
            Exit Try
        Finally
            Try
                MasterCartonDrmEntry.ShowDialog()
            Catch Ex As Exception
                MsgBox(Ex.Message)
                Application.Exit()
            End Try

        End Try

    End Sub

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class