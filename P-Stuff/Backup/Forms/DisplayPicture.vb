
'Program Name: -    DisplayPicture.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    P-Stuff Plus (Container Stuffing)
'Date: -            23 Dec 2K8 10.45 AM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - The display picture is the activity to shown the displaying the picture 
'               of boxes or drums like goods in certain seconds so that the user is understanding
'               which type of activity is done and the picture is displaying to clear the user understanding.

Public NotInheritable Class DisplayPicture
    Inherits System.Windows.Forms.Form

#Region " Class Declaration "

    Private Shared photoTimer As New System.Windows.Forms.Timer()
    Dim Tdp As Short

#End Region

#Region " Routine Definitions "

    Private Shared Sub TimerEventProcessors(ByVal myObject As Object, ByVal myEventArgs As EventArgs)

        photoTimer.Stop()
        PieFlag = True

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        PieFlag = False
        Me.Dispose(True)
        Me.Close()

    End Sub

    Private Sub TmrPhotoDisplay_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TmrPhotoDisplay.Tick

        AddHandler photoTimer.Tick, AddressOf TimerEventProcessors

        Try

            ' Sets the timer interval to 5 seconds.
            photoTimer.Interval = 5000
            photoTimer.Start()

            While PieFlag = False
                ' Processes all the events in the queue.
                Application.DoEvents()
            End While


            Dim Sdph() As System.Diagnostics.Process

            Sdph = Process.GetProcesses
            For i As Integer = LBound(Sdph) To UBound(Sdph)

                Tdp += 1

                If Tdp = 20 Then
                    Me.Dispose(True)
                    Me.Close()
                    PieFlag = False

                    Exit Sub
                End If
            Next

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in TmrPhotoDisplay", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub DisplayPicture_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            Me.Show()
            Call TmrPhotoDisplay_Tick(sender, e)

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in DisplayPicture_Load", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class
