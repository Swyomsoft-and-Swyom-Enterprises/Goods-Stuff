
'Program Name: -    frmDisplayScreen.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    Sky Stuff Plus (Container Stuffing)
'Date: -            24 Dec 2K8 12.16 PM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - frmDisplayScreen is the starting screen which is set visible with 
'               set 5 second counts to display the product logo and company info.

#Region " Importing Object "

Imports Microsoft.VisualBasic
Imports System

#End Region

Public NotInheritable Class frmDisplayScreen
    Inherits System.Windows.Forms.Form

#Region " Class Definition "

    Dim i As Integer

#End Region

#Region " Routine Definition "

    Private Sub TDisplay_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TDisplay.Tick

        'Try
        '    Dim mm() As System.Diagnostics.Process

        '    mm = Process.GetProcesses
        '    For i As Integer = LBound(mm) To UBound(mm)
        '    Next

        '    Historys() 'History Recorded

        '    ''=========================
        '    'i += 1
        '    'If i = 1 Then
        '    '    'Me.Visible = False
        '    '    mdiform.Show()

        '    'End If

        '    'If i = 2 Then

        '    '    Me.Visible = False

        '    'End If
        '    ''=========================

        '    '=========================*
        '    i += 1
        '    If i = 7 Then               'If i = 2 Then           

        '        MDIForm.Show()

        '        TDisplay.Enabled = False
        '        TDisplay.Dispose()
        '        TDisplay.Stop()
        '        Me.Dispose(True)
        '        Me.Close()
        '    End If

        '    'If i = 2 Then

        '    '    Me.Visible = False

        '    'End If
        '    '=========================*

        'Catch Ex As Exception
        '    MsgBox(Ex.Message)
        '    MsgBox(Ex.ToString)
        '    MessageBox.Show("Error in TDisplay_Tick", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Finally
        '    GC.Collect()
        'End Try

        TDisplay.Enabled = False

        Me.Close()

    End Sub

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class