
'Program Name: -    DisplayActivity.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    P-Stuff Plus (Container Stuffing)
'Date: -            23 Dec 2K8 10.15 AM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - DisplayActivity is just an open door type activity to separate each task 
'               activity and in between the garbage collection is done so improving little 
'               bit performance, and its the two operation module separation door so every 
'               operation is separated by these so user is properly visualize understand the 
'               separation of the each activity. 

#Region " Importing object "

Imports ToneGen

#End Region


Public NotInheritable Class DisplayActivity
    Inherits System.Windows.Forms.Form

#Region " Class Declaration "

    Dim TdA As Short
    Private Shared displayTimer As New System.Windows.Forms.Timer()
    Private Shared quitFlag As Boolean = False

#End Region

#Region " Routine Definition "

    Private Shared Sub TimerEventProcessor(ByVal myObject As Object, ByVal myEventArgs As EventArgs)

        Try

            displayTimer.Stop()
            quitFlag = True

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in TimerEventProcessor", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub TmrDisplayActivity_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TmrDisplayActivity.Tick

        Try

            AddHandler displayTimer.Tick, AddressOf TimerEventProcessor

            ' Sets the timer interval to 1 seconds.
            displayTimer.Interval = 1000
            displayTimer.Start()

            While quitFlag = False
                ' Processes all the events in the queue.
                Application.DoEvents()
            End While

            Dim Sdp() As System.Diagnostics.Process

            Sdp = Process.GetProcesses

            For i As Integer = LBound(Sdp) To UBound(Sdp)

                TdA += 1

                If TdA = 1 Then

                    Me.Show()

                ElseIf TdA = 5 Then

                    Call OpenDoor()                     'Open door type activity is done through this routine
                    lblDisplayActivity.Refresh()
                End If

                If TdA = 35 Then

                    Me.Dispose(True)
                    Me.Close()
                    quitFlag = False
                    lblDisplayActivity.Text = ""
                    lblDisplayActivity.Visible = False

                    Exit Sub

                End If

            Next

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in TmrDisplayActivity_Tick", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub TonMusic()

        Try

            ToneGenerator.PlayString("O3 L2 EDCDEE L4 E L2 DD L4 D L2 EG L4 G L2 EDCDEEEEDDED L4 C ")

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in TonMusic", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub DisplayActivity_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Stop
        Try
            'TonMusic()                          'Generating musical ton while open Door
            'Process.Start(CurDir() & "\SP.exe")
            btn1DL.Text = ""
            btn2DL.Text = ""
            btn3DL.Text = ""
            btn4DL.Text = ""
            btn5DL.Text = ""
            btn6DL.Text = ""
            btn7DL.Text = ""
            btn8DL.Text = ""
            btn1DR.Text = ""
            btn2DR.Text = ""
            btn3DR.Text = ""
            btn4DR.Text = ""
            btn5DR.Text = ""
            btn6DR.Text = ""
            btn7DR.Text = ""
            btn8DR.Text = ""
            lblDisplayActivity.ForeColor = Color.SandyBrown

            Me.Show()

            Call TmrDisplayActivity_Tick(sender, e)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in DisplayActivity_Load", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Friend Sub OpenDoor()

        Try

            Dim dr As Int16 = 0
            lblDisplayActivity.Refresh()
            btn8DR.Visible = False
            btn8DL.Visible = False
            Do While dr < 255
                dr += 1
                lblDisplayActivity.Refresh()
            Loop
            dr = 0
            btn7DR.Visible = False
            btn7DL.Visible = False
            Do While dr < 200
                dr += 1
                lblDisplayActivity.Refresh()
            Loop
            dr = 0
            btn6DR.Visible = False
            btn6DL.Visible = False
            Do While dr < 175
                dr += 1
                lblDisplayActivity.Refresh()
            Loop
            dr = 0
            btn5DR.Visible = False
            btn5DL.Visible = False
            Do While dr < 165
                dr += 1
                lblDisplayActivity.Refresh()
            Loop
            dr = 0
            lblDisplayActivity.Refresh()
            btn4DR.Visible = False
            btn4DL.Visible = False
            Do While dr < 155
                dr += 1
                lblDisplayActivity.Refresh()
            Loop
            dr = 0
            btn3DR.Visible = False
            btn3DL.Visible = False
            Do While dr < 125
                dr += 1
                lblDisplayActivity.Refresh()
            Loop
            dr = 0
            btn2DR.Visible = False
            btn2DL.Visible = False
            Do While dr < 100
                dr += 1
                lblDisplayActivity.Refresh()
            Loop
            dr = 0
            btn1DR.Visible = False
            btn1DL.Visible = False
            Do While dr < 10
                dr += 1
                lblDisplayActivity.Refresh()
            Loop
            dr = 0
            lblDisplayActivity.Refresh()
            GC.Collect()
            System.Threading.Thread.Sleep(555)
            lblDisplayActivity.Refresh()

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in OpenDoor", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class