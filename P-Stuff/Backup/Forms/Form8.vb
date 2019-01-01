
'Program Name: -    Form8.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    Sky Stuff Plus (Container Stuffing)
'Date: -            24 Dec 2K8 11.52 AM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - Form8 is the progress form of stuffing which is older to shown the progress
'               activity of stuffing.

Public NotInheritable Class Form8
    Inherits System.Windows.Forms.Form

#Region " Class Declaration "

    Public i As Integer

#End Region

#Region " Routine Definition "

    Public Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Try
            stk.Clear()
            exflg = True
            Try
                Me.Dispose(True)
                Me.Close()
            Catch
            Finally
                Try
                    Me.Dispose(True)
                    Me.Close()
                Catch
                End Try
            End Try

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in Button1_Click", "Error .....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Form8_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick

        Try
            Dim ColDlg As New ColorDialog

            If ColDlg.ShowDialog Then
                Me.BackColor = ColDlg.Color
            End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Color selection", "Progress.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'Private Sub Form8_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    '    ' Call Button1_Click(sender, e)
    '    Try
    '        stk.Clear()
    '        exflg = True
    '        Try
    '            Me.Dispose(True)
    '            Me.Close()
    '        Catch
    '        Finally
    '            Try
    '                Me.Dispose(True)
    '                Me.Close()
    '            Catch
    '            End Try
    '        End Try

    '    Catch Ex As Exception
    '        MsgBox(Ex.Message)
    '        MessageBox.Show("Error in Form8_FormClosed", "Error .....", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    'Private Sub Form8_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    '    If e.KeyCode = Keys.Escape Then
    '        Try
    '            stk.Clear()
    '            exflg = True
    '            Try
    '                Me.Dispose(True)
    '                Me.Close()
    '            Catch
    '            Finally
    '                Try
    '                    Me.Dispose(True)
    '                    Me.Close()
    '                Catch
    '                End Try
    '            End Try

    '        Catch Ex As Exception
    '            MsgBox(Ex.Message)
    '            MessageBox.Show("Error in Form8_KeyDown", "Error .....", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End Try
    '    End If
    'End Sub

    Private Sub Form8_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            Me.ShowInTaskbar = False
            Me.TopMost = True

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Load", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            Call TransactionMenu.AnimateWindow(Me.Handle, 1500, TransactionMenu.AnimateStyles.HOR_Positive Or TransactionMenu.AnimateStyles.Slide)
        End Try

    End Sub

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    
End Class