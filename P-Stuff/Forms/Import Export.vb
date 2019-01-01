
'Program Name: -    Import Export.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    Sky Stuff Plus (Container Stuffing)
'Date: -            23 Dec 2K8 1.10 PM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - Import Export is the form to display the isometric view through Alteros viewers and 
'               also exports and importing the VRML programming final output file into the project.

Public NotInheritable Class Import_Export
    Inherits System.Windows.Forms.Form

#Region " Class Declaration "

    Dim Ifile As String
    Dim Ofile As String

#End Region

#Region " Routine Definition "

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Dispose(True)
        Me.Close()

    End Sub

    Private Sub btn3DViewers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn3DViewers.Click

        Try

            Process.Start("c:\Program Files\Alteros 3D\alteros.exe", Ifile)
            Me.TopMost = False

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in btn3DViewers_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

    End Sub

    Sub View()

        Try
            Dim Odlg As New OpenFileDialog
            Odlg.AddExtension = True
            Odlg.CheckFileExists = True
            Odlg.CheckPathExists = True
            Odlg.Multiselect = False
            Odlg.Title = "Select file to view 3D"

            If Odlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                Ifile = Odlg.FileName
                txtViewFile.Text = Ifile
            End If
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in View", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnViewFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewFile.Click

        Call View()

    End Sub

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class