
'Program Name: -    Progress8.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    Sky Stuff Plus (Container Stuffing)
'Date: -            23 Dec 2K8 2.55 PM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - Progress8 is the old form shown the progress of stuffing the progress
'               in stuffing in different in the form shown the quantity is to be placed.

Public Class Progress8

#Region " Class Declarations "

    Public iQty As Integer

#End Region

#Region " Routine Definitions "

    Public Sub btnStatus_Click()

        Try
            CDLst.Clear()
            exflg = True
            Me.Close()
            TransactionsMenu.btnStatus.Visible = False
            btnStatus.Visible = False

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in btnStatus_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class
