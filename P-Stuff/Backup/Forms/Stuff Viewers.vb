
'Program Name: -    Stuff Viewers.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    Sky Stuff Plus (Container Stuffing)
'Date: -            23 Dec 2K8 3.40 PM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - Stuff Viewers is the form to shown the isometric views in Alteros 3D viewers
'               of box and drum type stuffing.

Public NotInheritable Class Stuff_Viewers
    Inherits System.Windows.Forms.Form

#Region " Class Declarations "

    Private SIswDestry As IO.StreamWriter

#End Region

#Region " Routine definitions "

    Private Sub Stuff_Viewers_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            'Dim DT As DateTime = DateTime.Now
            'Dim dtmFile As String = DT.ToString("ddMMyyhms")

            'Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

            '    Try
            '        Dim DT As DateTime = DateTime.Now

            '        Dim dtmFile As String = DT.ToString("ddMMyyhms")

            '        Dim Wifile As String = CurDir() & "\Box.wrl"
            '        Dim wofile As String

            '        Dim Extn As String

            '        If lstbTyp.TopIndex = 0 Then
            '            Extn = ".wrl"
            '        ElseIf lstbTyp.TopIndex = 1 Then
            '            Extn = ".txt"
            '        Else
            '            Extn = ""
            '        End If

            '        wofile = CurDir() & "\Stuff Viewers files\" & txtSavefileas.Text & Extn

            '        Dim F As Int16 = 1

            '        EDWr.De = F
            '        EDWr.Ifile = Wifile
            '        EDWr.Ofile = wofile
            '        EDWr.DEKey = "C$P"

            '        F = EDWr.DEncript()

            '        EDWr.De = 5
            '        EDWr.Ifile = Wifile
            '        EDWr.Ofile = wofile

            '        F = EDWr.WrProgCSP()

            '        IFOPWr(dtmFile)

            '    Catch ex As Exception
            '        MsgBox(ex.Message, MsgBoxStyle.Critical)
            '    Finally
            '        MessageBox.Show("File save successfully", "File Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    End Try

            'End Sub

            'Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

            '    Me.Close()

            'End Sub

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Stuff_Viewers_Load", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btn3DViewersBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn3DViewersBox.Click

        Try

            Dim FName As String = "C:\CSP.Box.wrl"
            Process.Start("c:\Program Files\Alteros 3D\alteros.exe", FName)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in btn3DViewersBox_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btn3DViewersDrum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn3DViewersDrum.Click

        Dim FName As String = "C:\CSP.Drum.wrl"

        Try
            Process.Start("C:\Program Files\Alteros 3D\alteros.exe", FName)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in btn3DViewersDrum_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        
        End Try

    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click

        Me.Dispose(True)
        Me.Close()

    End Sub

    Friend Sub DestroyOldFile(ByVal FNames As String)

        Dim killfl As Boolean = False
        Dim flExts As Boolean = False
        killfl = True

        Try
            If killfl Then

                Try
                    flExts = My.Computer.FileSystem.FileExists(FNames)

                    If flExts And killfl Then

                        Kill(FNames)

                    End If

                Catch Ex As Exception
                    MsgBox(Ex.Message)
                    MsgBox(Ex.ToString)
                    MessageBox.Show("Error in DestroyOldFile", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    killfl = False
                End Try
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in DestroyOldFile", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class

