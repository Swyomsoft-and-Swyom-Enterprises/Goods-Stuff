Imports GenLibMth
Imports MSScriptControl

Public NotInheritable Class Calculation
    Inherits System.Windows.Forms.Form

    'Dim cReslt As Double = 0

    Protected Friend cReslt As Double = 0         'Public cReslt As Double = 0            'Calculation is assign the final results
    Protected Friend Rdgv1 As Integer = 0         'Public Rdgv1 As Integer = 0           'row index in datagrid
    Protected Friend Cdgv1 As Integer = 0         'Public Cdgv1 As Integer = 0           'column index in datagrid

    Dim gVal As New GenMthCalc

    Private Sub Calculation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtValue.Focus()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Dispose(True)
        Me.Close()

    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        Try

            'TransactionMenu.dgv1.Item(e.ColumnIndex, e.RowIndex).Value = cReslt
            TransactionMenu.dgvValAsgn()

            Me.Dispose(True)
            Me.Close()

            TransactionMenu.btnDoor.Focus()

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Calculation", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnAns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAns.Click

        Try
            If txtValue.Text.Trim = "" Then Exit Sub
            Dim MthCal As New ScriptControl()

            MthCal.Language = "VBScript"

            Try
                txtValue.Text = CStr(MthCal.Eval(txtValue.Text))
            Catch
                MessageBox.Show("Invalid entry", "Calculation Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            'txtValue.Text = gVal.CalC(txtValue.Text)

            cReslt = txtValue.Text

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in General calculation", "Error Calculation", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtValue_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValue.LostFocus
        btnAns_Click(sender, e)
    End Sub

    Public Function mthCalc(ByVal ValueIn As String) As String

        If ValueIn.Trim = "" Then
            Return ValueIn
            Exit Function
        End If

        Dim MthCal As New ScriptControl()

        MthCal.Language = "VBScript"

        Try
            Return ValueIn = CStr(MthCal.Eval(ValueIn))
        Catch
            Return ValueIn
            MessageBox.Show("Invalid entry", "Calculation Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return ValueIn
    End Function

    Private Sub btnOk1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk1.Click

        Me.Dispose(True)
        Me.Close()

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class