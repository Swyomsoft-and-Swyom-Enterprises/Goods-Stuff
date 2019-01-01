
'Program Name: -    frmRegister.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    Sky Stuff Plus (Container Stuffing)
'Date: -            24 Dec 2K8 12.16 PM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - frmRegister is the form which is the registering the software to permanent
'               customer utilization. This form contains to user id and three keys to 
'               enter for registration.

#Region " Importing Object "

Imports sdo = System.Data.OleDb
'Imports SkySwReg

#End Region

Public NotInheritable Class frmRegister
    Inherits System.Windows.Forms.Form
    'Public SkyReg As New SkyRegister       'SkySwReg.dll use these object 

#Region " Routine definition "

    Private Sub frmRegister_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Dim UniqIdToMail As String = Nothing
            Dim cmd As New OleDb.OleDbCommand
            Dim rdrWin As OleDb.OleDbDataReader
            Dim rdrNode As OleDb.OleDbDataReader = Nothing
            Dim I As Integer = Nothing

            If connWin.State = ConnectionState.Closed Then connWin.Open()
            cmd.Connection = connWin
            cmd.CommandText = "Select * from UsrSec"
            rdrWin = cmd.ExecuteReader
            grdRegister.RowCount = 1

            'If rdrWin.HasRows = True Then
            '    If rdrWin.IsClosed = False Then rdrWin.Close()
            '    If Trim(SkyReg.DisplaySavedId(CurDir())) <> "" Then
            '        txtCDKey1.Text = Mid(SkyReg.DisplaySavedId(CurDir()), 1, 20)
            '        txtCDKey2.Text = Mid(SkyReg.DisplaySavedId(CurDir()), 21, 20)

            '        cmd.CommandText = "Select * from UsrSec where trim(XB) = ''"
            '        rdrNode = cmd.ExecuteReader

            '        If rdrNode.RecordsAffected > 0 Then
            '            I = 0
            '            Do While rdrNode.Read
            '                grdRegister.Rows.Add()
            '                grdRegister.Item(0, I).Value = "Client"
            '                grdRegister.Item(1, I).Value = rdrNode("XD")
            '                grdRegister.Item(2, I).Value = True
            '                I = I + 1
            '            Loop
            '            grdRegister.Rows.RemoveAt(grdRegister.RowCount)
            '        End If
            '        grpServer.Visible = False
            '    Else
            '        btnRegister.Enabled = False
            '    End If
            'Else
            '    grdRegister.Item(0, 0).Value = "Server"
            '    grdRegister.Item(1, 0).Value = SkyReg.GetMachineId
            '    UniqIdToMail = txtUniqueId.Text
            '    grdRegister.Item(2, 0).Value = True
            '    grpServer.Visible = True
            'End If
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in frmRegister_Load", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnRegister_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegister.Click

        Dim cdKey As String
        Dim RegNode As Boolean
        Dim I As Integer

        Try
            For I = 0 To grdRegister.RowCount - 1
                If grdRegister.Item(2, I).Value = True Then
                    RegNode = True
                End If
            Next I
            If RegNode = False Then
                MsgBox("Nothing Selected", vbExclamation)
                Exit Sub
            End If

            cdKey = txtCDKey1.Text & txtCDKey2.Text

            'For I = 0 To grdRegister.RowCount - 1
            '    If grdRegister.Item(2, I).Value = True Then
            '        SkyReg.RegisterSw(CurDir, grdRegister.Item(1, I).Value, cdKey, Trim(txtCDKeyOther.Text))
            '    End If
            'Next I
            'End

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in btnRegister_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtCDKey1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCDKey1.TextChanged

        txtCDKey1.Text = UCase(txtCDKey1.Text)

    End Sub

    Private Sub txtCDKey2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCDKey2.TextChanged

        txtCDKey2.Text = UCase(txtCDKey2.Text)

    End Sub

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class