
'Program Name: -    WaddleBox.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    Sky Stuff Plus (Container Stuffing)
'Date: -            22 Dec 2K8 10.29 AM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - The manually taking dimensions to move particular quantity of goods in
'               container to specific directions depends upon the entering the dimensions.

Public NotInheritable Class WaddleBox
    Inherits System.Windows.Forms.Form

#Region "Routine definitions"

    'Form is closing to Exit button	
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click

        Try
            Me.Dispose(True)
            Me.Close()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in btnExit_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class