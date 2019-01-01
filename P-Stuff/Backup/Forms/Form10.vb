
'Program Name: -    Form10.vb (Select Option)
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    P-Stuff Plus (Container Stuffing)
'Date: -            23 Dec 2K8 10.50 AM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - Select option is the option selection form to select color or plan layout.
Imports ISystem
Public NotInheritable Class Form10
    Inherits System.Windows.Forms.Form

    Dim CNstrFnm As String = Nothing

#Region "Routine Definition "

    Public Sub utilityProgressBarGet()

        Try

            Dim pbsB As Integer = Nothing
            Dim pbsC As Integer = Nothing
            Dim pbsM As Integer = Nothing
            Dim imgindx As Integer = Nothing

            Dim cmd As New OleDb.OleDbCommand
            Dim rdr As OleDb.OleDbDataReader

            If conn.State = ConnectionState.Closed Then conn.Open()
            cmd.Connection = conn

            cmd.CommandText = "select pbBlocks, pbContinuous, pbMarquee, ImgIndx from mainUtility"
            rdr = cmd.ExecuteReader()

            Do While rdr.Read()
                pbsB = CInt(rdr("pbBlocks"))
                pbsC = CInt(rdr("pbContinuous"))
                pbsM = CInt(rdr("pbMarquee"))
                imgindx = CInt(rdr("ImgIndx"))
            Loop

            If pbsB = 1 Then
                rdbBlocks.Checked = True
                rdbContinuous.Checked = False
                rdbMarquee.Checked = False
                TransactionMenu.pbCSP1.Style = ProgressBarStyle.Blocks
            ElseIf pbsC = 1 Then
                rdbContinuous.Checked = True
                rdbBlocks.Checked = False
                rdbMarquee.Checked = False
                TransactionMenu.pbCSP1.Style = ProgressBarStyle.Continuous
            ElseIf pbsM = 1 Then
                rdbMarquee.Checked = True
                rdbBlocks.Checked = False
                rdbContinuous.Checked = False
                TransactionMenu.pbCSP1.Style = ProgressBarStyle.Marquee
            Else
                'MessageBox.Show("Error in progress bar style", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            If imgindx = 0 Then
                lblpbDirct.ImageIndex = 0
                TransactionMenu.pbCSP1.RightToLeftLayout = False
                TransactionMenu.pbCSP1.RightToLeft = Windows.Forms.RightToLeft.No
            ElseIf imgindx = 1 Then
                lblpbDirct.ImageIndex = 1
                TransactionMenu.pbCSP1.RightToLeftLayout = True
                TransactionMenu.pbCSP1.RightToLeft = Windows.Forms.RightToLeft.Yes
            Else
                lblpbDirct.ImageIndex = 1
                TransactionMenu.pbCSP1.RightToLeftLayout = True
                TransactionMenu.pbCSP1.RightToLeft = Windows.Forms.RightToLeft.Yes
            End If

            Me.Refresh()
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in utilityProgressBarGet", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub utilityColorLayoutGet()

        Try
            Dim tf As Integer = Nothing
            Dim cmdr As New OleDb.OleDbCommand
            Dim rdrr As OleDb.OleDbDataReader

            If conn.State = ConnectionState.Closed Then conn.Open()
            cmdr.Connection = conn

            cmdr.CommandText = "select colorLayOptFlg from mainUtility"
            rdrr = cmdr.ExecuteReader()

            Do While rdrr.Read()
                tf = CInt(rdrr("colorLayOptFlg"))
            Loop

            If tf = 1 Then
                colopt = True
                RadioButton1.Checked = True
                RadioButton2.Checked = False
            ElseIf tf = 0 Then
                colopt = False
                RadioButton2.Checked = True
                RadioButton1.Checked = False
            Else
                colopt = False
                RadioButton1.Checked = True
                RadioButton2.Checked = False
            End If
            Me.Refresh()
        Catch Exr As Exception
            MsgBox(Exr.Message)
            MsgBox(Exr.ToString)
            MessageBox.Show("Error in utilityColorLayoutGet", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Refresh()
        End Try

    End Sub

    Public Sub utilityColorLayoutPBrDel()

        Try

            Dim cmd As New OleDb.OleDbCommand
            If conn.State = ConnectionState.Closed Then conn.Open()
            cmd.Connection = conn

            cmd.CommandText = "delete from mainUtility"
            cmd.ExecuteNonQuery()

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in utilityColorLayoutDel", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub utilityProgressBarStyleIns()

        Try

            Dim cmd As New OleDb.OleDbCommand
            If conn.State = ConnectionState.Closed Then conn.Open()
            cmd.Connection = conn

            Dim pbsB As Integer = Nothing
            Dim pbsC As Integer = Nothing
            Dim pbsM As Integer = Nothing
            Dim imgindx As Integer = Nothing

            If rdbBlocks.Checked Then
                pbsB = 1
                pbsC = 0
                pbsM = 0
                TransactionMenu.pbCSP1.Style = ProgressBarStyle.Blocks
            ElseIf rdbContinuous.Checked Then
                pbsC = 1
                pbsB = 0
                pbsM = 0
                TransactionMenu.pbCSP1.Style = ProgressBarStyle.Continuous
            ElseIf rdbMarquee.Checked Then
                pbsM = 1
                pbsB = 0
                pbsC = 0
                TransactionMenu.pbCSP1.Style = ProgressBarStyle.Marquee
            Else
                'MessageBox.Show("Error in Progress bar style", "Error....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            If lblpbDirct.ImageIndex = 0 Then
                imgindx = 0
                TransactionMenu.pbCSP1.RightToLeftLayout = False
                TransactionMenu.pbCSP1.RightToLeft = Windows.Forms.RightToLeft.No
            ElseIf lblpbDirct.ImageIndex = 1 Then
                imgindx = 1
                TransactionMenu.pbCSP1.RightToLeftLayout = True
                TransactionMenu.pbCSP1.RightToLeft = Windows.Forms.RightToLeft.Yes
            Else
                imgindx = 1
                TransactionMenu.pbCSP1.RightToLeftLayout = True
                TransactionMenu.pbCSP1.RightToLeft = Windows.Forms.RightToLeft.Yes
            End If

            cmd.CommandText = "update mainUtility set pbBlocks = " & pbsB & ", pbContinuous = " & pbsC & ", pbMarquee = " & pbsM & ", ImgIndx = " & imgindx
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in utilityProgressBarStyleIns", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub utilityColorLayoutIns()

        Try
            Dim cmdc As New OleDb.OleDbCommand
            If conn.State = ConnectionState.Closed Then conn.Open()
            cmdc.Connection = conn

            Dim tf As Int16 = 0

            If RadioButton1.Checked Then
                colopt = True
                tf = 1
            Else
                colopt = False
                tf = 0
            End If

            If colopt = True And tf = 1 Then
                cmdc.CommandText = "update mainUtility set colorLayOptFlg = " & 1
                cmdc.ExecuteNonQuery()
            ElseIf colopt = False And tf = 0 Then
                cmdc.CommandText = "update mainUtility set colorLayOptFlg = " & 0
                cmdc.ExecuteNonQuery()
            End If

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in utilityColorLayoutIns", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try

    End Sub

    Private Sub btnPBrChng_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPBrChng.Click
        Call utilityProgressBarStyleIns()
        MessageBox.Show("Progress bar setting change successfully", "Info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Try
            Call utilityColorLayoutIns()
            MessageBox.Show("Color layout setting change successfully", "Info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Button1_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Form10_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call MDIForm.BringFront()
    End Sub

    Private Sub Form10_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        Call utilityColorLayoutGet()
        Call utilityProgressBarGet()
        Call GetSetLink()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click

        Try
            Me.Close()
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in cmdExit_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub lblpbDirct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblpbDirct.Click

        If lblpbDirct.ImageIndex = 0 Then
            lblpbDirct.ImageIndex = 1
        ElseIf lblpbDirct.ImageIndex = 1 Then
            lblpbDirct.ImageIndex = 0
        Else
            lblpbDirct.ImageIndex = 1
        End If

    End Sub

    Private Sub btnselectlink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnselectlink.Click

        Try

            Dim opdlg As New OpenFileDialog

            opdlg.Filter = "Database file(*.mdb)|*.mdb|All files (*.*)|*.*"
            opdlg.Title = "Select a database file"

            opdlg.ShowDialog()

            CNstrFnm = opdlg.FileName
            txtDatatieLink.Text = CNstrFnm

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in Database Link Selection", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnSetlink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetlink.Click

        Try
            setLinkFlg = True
            Call ConnectionStringSet(CNstrFnm)
            Call StoringSetLinkInfo(CNstrFnm)

            MessageBox.Show("Connection link set successfully", "Data tie setlink info", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Setlink", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub GetSetLink()

        Try
            Dim cmd As New OleDb.OleDbCommand
            Dim rdr As OleDb.OleDbDataReader
            If conn.State = ConnectionState.Closed Then conn.Open()
            cmd.Connection = conn

            cmd.CommandText = "select Dbtlink from mainUtility"
            rdr = cmd.ExecuteReader

            Do While rdr.Read

                CNstrFNm = rdr("Dbtlink")

            Loop

            txtDatatieLink.Text = CNstrFnm

            Call ConnectionStringSet(CNstrFnm)

            txtDatatieLink.Focus()

            Me.Refresh()

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in GetSetLink", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub StoringSetLinkInfo(ByVal CNstrFNm As String)

        Try

            Dim cmd As New OleDb.OleDbCommand

            If conn.State = ConnectionState.Closed Then conn.Open()
            cmd.Connection = conn

            cmd.CommandText = "update mainUtility set Dbtlink = '" & CNstrFNm & "'"

            cmd.ExecuteNonQuery()

            Dim ocmd As New OleDb.OleDbCommand
            If oconn.State = ConnectionState.Closed Then oconn.Open()
            ocmd.Connection = oconn

            ocmd.CommandText = "update mainUtility set Dbtlink = '" & CNstrFNm & "'"
            
            ocmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in Storing set link info", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub DeleteSetLinkInfo()

        Try

            Dim cmd As New OleDb.OleDbCommand
            If conn.State = ConnectionState.Closed Then conn.Open()
            cmd.Connection = conn
            cmd.CommandText = "delete from mainUtility"
            cmd.ExecuteNonQuery()

            Dim ocmd As New OleDb.OleDbCommand
            If oconn.State = ConnectionState.Closed Then oconn.Open()
            ocmd.Connection = oconn
            ocmd.CommandText = "delete from mainUtility"
            ocmd.ExecuteNonQuery()

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in delete set link info", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

    Private Sub cmdSysInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSysInfo.Click
        'Call AboutStuffPlus.SystemInformation()
        Try
            Dim si As New SystemI
            Call si.SystemInformation()
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in System Information Of Machine", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class