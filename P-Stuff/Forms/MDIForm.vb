
'Program Name: -    MDIForm.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    Sky Stuff Plus (Container Stuffing)
'Date: -            23 Dec 2K8 2.40 PM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - MDIForm is the main form of this project which navigates the various
'               modules in this project. 

#Region " Importing Object "

Imports sdo = System.Data.OleDb
'Imports SkySwReg

#End Region

Public NotInheritable Class MDIForm
    Inherits System.Windows.Forms.Form

#Region " Class Declarations "

    Dim mDemo As String = Nothing
    Const imgMaster = 0
    Const imgMasterMO = 1
    Const imgStuffing = 2
    Const imgStuffingMO = 3
    Const imgReports = 4
    Const imgReportsMO = 5
    Const imgUtility = 6
    Const imgUtilityMO = 7
    Const imgUpdate_Database = 8
    Const imgUpdate_DatabaseMO = 9
    Const imgContainer = 10
    Const imgContainerMO = 11
    Const imgCarton = 12
    Const imgCartonMO = 13
    Const imgCustomer = 14
    Const imgCustomerMO = 15
    Const imgFreight = 16
    Const imgFreightMO = 17

    Const imgNavigation = 0
    Const imgNavigationMO = 1
    Const imgHelp = 2
    Const imgHelpMO = 3
    Const imgExit = 4
    Const imgExitMO = 5
    Const imgRegister = 6
    Const imgRegisterMO = 7

    Dim HlpClick As Short = 1

    'Public SkyReg As New SkyRegister       'SkySwReg.dll use these object 

#End Region

#Region " Routine Definitions "

    Protected Sub Navigation()
        'ToolTipMDI.SetToolTip(btnNavigate, "Navigate the sub menu module")
    End Sub

    Protected Sub Help()
        'ToolTipMDI.SetToolTip(btnHelp, "Show the application help")
    End Sub

    Protected Sub Aexit()
        'ToolTipMDI.SetToolTip(btnExit, "Quit the application")
    End Sub

    Protected Sub masters()
        'ToolTipMDI.SetToolTip(btnMasters, "Navigate the sub menu of masters")
    End Sub

    Protected Sub stuffing()
        'ToolTipMDI.SetToolTip(btnStuffing, "Active the stuffing activity")
    End Sub

    Protected Sub reports()
        'ToolTipMDI.SetToolTip(btnReports, "Show the reports ")
    End Sub

    Protected Sub utility()
        'ToolTipMDI.SetToolTip(btnUtility, "Show the utility")
    End Sub

    Protected Sub containermasters()
        'ToolTipMDI.SetToolTip(btncontmst, "Active container master")
    End Sub

    Protected Sub cartonmaster()
        'ToolTipMDI.SetToolTip(btnmstcart, "Active carton master")
    End Sub

    Protected Sub register()
        'ToolTipMDI.SetToolTip(btnRegister, "Register the application")
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        System.Diagnostics.Process.Start(e.Link.LinkData.ToString())

    End Sub

    'Private Sub mdiform_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed

    '    'Me.Dispose(True)
    '    'Me.Close()
    '    'Application.Exit()

    'End Sub

    'Const MB_ICONQUESTION = &H20L
    'Const MB_YESNO = &H4
    'Const IDYES = 6
    'Const IDNO = 7

    'Declare Auto Function MBx Lib "user32.dll" Alias "MessageBox" (ByVal hWnd As Integer, ByVal txt As String, ByVal caption As String, ByVal Typ As Integer) As Integer

    'Private Sub mdiform_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick

    '    'Try
    '    '    Process.Start("www.pristinenterprises.com")
    '    'Catch Er As Exception
    '    '    MsgBox(Er.Message)
    '    '    MsgBox(Er.ToString)
    '    '    MessageBox.Show("Error in P-Stuff Link", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    'End Try
    'End Sub

    'Private Sub mdiform_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

    '    'Try

    '    '    Dim Result As Integer

    '    '    Result = MessageBox.Show("Close the 'P-Stuff Application'", "Closing P-Stuff", MessageBoxButtons.OK)             'MBx(0, "Do you want to really close the application", "Closing P-Stuff", MB_ICONQUESTION Or MB_YES)

    '    '    If Result = MsgBoxResult.Ok Then
    '    '        btnExit_Click(sender, e)
    '    '    Else
    '    '        Exit Sub
    '    '        'btnRestart_Click(sender, e)
    '    '    End If


    '    '    'Dim Result As String

    '    '    'Result = MessageBox.Show("Do you want to really close the application", "Closing Sky stuff plus info.....", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

    '    '    'If Result = MsgBoxResult.Yes Then

    '    '    '    btnExit_Click(sender, e)

    '    '    'ElseIf Result = MsgBoxResult.No Then

    '    '    '    btnRestart_Click(sender, e)

    '    '    'End If

    '    'Catch Er As Exception
    '    '    MsgBox(Er.Message)
    '    '    MsgBox(Er.ToString)
    '    '    MessageBox.Show("Fatal error in closing application", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    'Finally
    '    '    GC.Collect()
    '    '    conn.Close()
    '    '    'Me.Dispose(True)
    '    '    'Me.Close()

    '    'End Try

    'End Sub

    Public Sub ScreenRe()

        Try
            btnRegister.Visible = False

            Dim myBitmap1024 As New Bitmap(CurDir() & "\Stuff Screens\Exim-Screen_1024-650.jpg")
            'Dim myBitmap1024 As New Bitmap(CurDir() & "\Exim-Screen_1024-650.jpg")

            Dim myBitmap800 As New Bitmap(CurDir() & "\Stuff Screens\Exim-Screen_800-490.jpg")
            'Dim myBitmap800 As New Bitmap(CurDir() & "\Exim-Screen_800-490.jpg")

            Dim ScRe_Height As Integer = 0
            Dim scRe_Width As Integer = 0

            ScRe_Height = Screen.PrimaryScreen.WorkingArea.Height
            scRe_Width = Screen.PrimaryScreen.WorkingArea.Width

            Me.Height = Screen.PrimaryScreen.WorkingArea.Height
            Me.Width = Screen.PrimaryScreen.WorkingArea.Width
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.WindowState = FormWindowState.Maximized

            'PStuffPicBx.Height = Me.Bottom - 53
            'PStuffPicBx.Width = Me.Width

            ''Me.Top = My.Forms.Main.Top + My.Forms.Main.MenuStrip1.Height + 36

            'PictureBox1.Height = Me.Height

            Dim NavT As Integer = Me.btnNavigate.Top
            Dim NavB As Integer = Me.btnNavigate.Left
            Dim MasT As Integer = Me.btnMasters.Top
            Dim MasB As Integer = Me.btnMasters.Left
            Dim StuT As Integer = Me.btnStuffing.Top
            Dim StuB As Integer = Me.btnStuffing.Left
            Dim RepT As Integer = Me.btnReports.Top
            Dim RepB As Integer = Me.btnReports.Left
            Dim UtiT As Integer = Me.btnUtility.Top
            Dim UtiB As Integer = Me.btnUtility.Left
            Dim HlpT As Integer = Me.btnHelp.Top
            Dim HlpB As Integer = Me.btnHelp.Left
            Dim ExT As Integer = Me.btnExit.Top
            Dim ExB As Integer = Me.btnExit.Left
            Dim ConT As Integer = Me.btncontmst.Top
            Dim ConB As Integer = Me.btncontmst.Left
            Dim CarT As Integer = Me.btnmstcart.Top
            Dim Carb As Integer = Me.btnmstcart.Left

            Dim RegT As Integer = Me.btnRegister.Top
            Dim RegL As Integer = Me.btnRegister.Left


            If ScRe_Height > 700 AndAlso scRe_Width > 802 Then
                Me.AutoScroll = False

                Me.PStuffPicBx.Image = myBitmap1024

                Me.BackgroundImage = myBitmap1024

                PStuffPicBx.Width = 1024
                PStuffPicBx.Height = 688


                Me.btnRegister.Top = RegT - 2
                Me.btnRegister.Left = RegL

                Me.btnNavigate.Top = NavT - 2
                Me.btnNavigate.Left = NavB
                Me.btnMasters.Top = MasT - 2
                Me.btnMasters.Left = MasB
                Me.btnStuffing.Top = StuT - 2
                Me.btnStuffing.Left = StuB
                Me.btnReports.Top = RepT - 2
                Me.btnReports.Left = RepB
                Me.btnUtility.Top = UtiT - 2
                Me.btnUtility.Left = UtiB
                Me.btnHelp.Top = HlpT - 2
                Me.btnHelp.Left = HlpB
                Me.btnExit.Top = ExT - 2
                Me.btnExit.Left = ExB
                Me.btncontmst.Top = ConT - 2
                Me.btncontmst.Left = ConB
                Me.btnmstcart.Top = CarT - 2
                Me.btnmstcart.Left = Carb

                'Stop

            Else
                'PStuffPicBx.Visible = False
                'PStuffPicBx1.Visible = True
                'PStuffPicBx1.Width = 800
                'PStuffPicBx1.Height = 520
                Me.AutoScroll = False
                Me.WindowState = FormWindowState.Normal
                Me.PStuffPicBx1.Image = myBitmap800
                Me.BackgroundImage = myBitmap800
                'Me.PStuffPicBx1.Image = myBitmap1024
                'PStuffPicBx.Width = 1024
                'PStuffPicBx.Height = 688
                PStuffPicBx.Width = 800
                PStuffPicBx.Height = 520

                Me.btnRegister.Top = RegT - 115 '70
                Me.btnRegister.Left = RegL - 125 '113


                Me.btnNavigate.Top = NavT - 70
                Me.btnNavigate.Left = NavB - 113
                Me.btnMasters.Top = MasT - 70
                Me.btnMasters.Left = MasB - 113
                Me.btnStuffing.Top = StuT - 70
                Me.btnStuffing.Left = StuB - 113
                Me.btnReports.Top = RepT - 70
                Me.btnReports.Left = RepB - 113
                Me.btnUtility.Top = UtiT - 70
                Me.btnUtility.Left = UtiB - 113
                Me.btnHelp.Top = HlpT - 70
                Me.btnHelp.Left = HlpB - 113
                Me.btnExit.Top = ExT - 70
                Me.btnExit.Left = ExB - 113
                Me.btncontmst.Top = ConT - 70
                Me.btncontmst.Left = ConB - 113
                Me.btnmstcart.Top = CarT - 70
                Me.btnmstcart.Left = Carb - 113

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in ScreenRe", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'Top = Me.Top

        'Left = Me.Left

        'Me.Location = New System.Drawing.Point(Top, Left)

        'Me.Height = My.Forms.Main.Height - My.Forms.Main.MenuStrip1.Height

        '  Me.Width = My.Forms.Main.Width – 100

    End Sub

    Public Sub ScreenResize()

        Try

            Dim myBitmap1024 As New Bitmap(CurDir() & "\Stuff Screens\Exim-Screen_1024-650.jpg")
            Dim myBitmap800 As New Bitmap(CurDir() & "\Stuff Screens\Exim-Screen_800-490.jpg")

            Dim ScRe_Height As Integer = 0
            Dim scRe_Width As Integer = 0

            ScRe_Height = Screen.PrimaryScreen.WorkingArea.Height
            scRe_Width = Screen.PrimaryScreen.WorkingArea.Width

            Me.Height = Screen.PrimaryScreen.WorkingArea.Height
            Me.Width = Screen.PrimaryScreen.WorkingArea.Width

            Dim NavT As Integer = 0
            Dim NavB As Integer = 0
            Dim MasT As Integer = 0
            Dim MasB As Integer = 0
            Dim StuT As Integer = 0
            Dim StuB As Integer = 0
            Dim RepT As Integer = 0
            Dim RepB As Integer = 0
            Dim UtiT As Integer = 0
            Dim UtiB As Integer = 0
            Dim HlpT As Integer = 0
            Dim HlpB As Integer = 0
            Dim ExT As Integer = 0
            Dim ExB As Integer = 0
            Dim ConT As Integer = 0
            Dim ConB As Integer = 0
            Dim CarT As Integer = 0
            Dim Carb As Integer = 0

            Dim RegT As Integer = Me.btnRegister.Top
            Dim RegL As Integer = Me.btnRegister.Left

            If ScRe_Height > 700 AndAlso scRe_Width > 802 Then

                'NavT = Me.btnNavigate.Top
                'NavB = Me.btnNavigate.Left
                'MasT = Me.btnMasters.Top
                'MasB = Me.btnMasters.Left
                'StuT = Me.btnStuffing.Top
                'StuB = Me.btnStuffing.Left
                'RepT = Me.btnReports.Top
                'RepB = Me.btnReports.Left
                'UtiT = Me.btnUtility.Top
                'UtiB = Me.btnUtility.Left
                'HlpT = Me.btnHelp.Top
                'HlpB = Me.btnHelp.Left
                'ExT = Me.btnExit.Top
                'ExB = Me.btnExit.Left
                'ConT = Me.btncontmst.Top
                'ConB = Me.btncontmst.Left
                'CarT = Me.btnmstcart.Top
                'Carb = Me.btnmstcart.Left

                'RegT = Me.btnRegister.Top
                'RegL = Me.btnRegister.Left

                'Me.AutoScroll = False
                'Me.PStuffPicBx.Image = myBitmap1024
                'Me.BackgroundImage = myBitmap1024

                'PStuffPicBx.Width = 1024
                'PStuffPicBx.Height = 688

                'Me.btnRegister.Top = RegT - 2
                'Me.btnRegister.Left = RegL

                'Me.btnNavigate.Top = NavT - 2
                'Me.btnNavigate.Left = NavB
                'Me.btnMasters.Top = MasT - 2
                'Me.btnMasters.Left = MasB
                'Me.btnStuffing.Top = StuT - 2
                'Me.btnStuffing.Left = StuB
                'Me.btnReports.Top = RepT - 2
                'Me.btnReports.Left = RepB
                'Me.btnUtility.Top = UtiT - 2
                'Me.btnUtility.Left = UtiB
                'Me.btnHelp.Top = HlpT - 2
                'Me.btnHelp.Left = HlpB
                'Me.btnExit.Top = ExT - 2
                'Me.btnExit.Left = ExB
                'Me.btncontmst.Top = ConT - 2
                'Me.btncontmst.Left = ConB
                'Me.btnmstcart.Top = CarT - 2
                'Me.btnmstcart.Left = Carb

            Else

                'NavT = Me.btnNavigate.Top
                'NavB = Me.btnNavigate.Left
                'MasT = Me.btnMasters.Top
                'MasB = Me.btnMasters.Left
                'StuT = Me.btnStuffing.Top
                'StuB = Me.btnStuffing.Left
                'RepT = Me.btnReports.Top
                'RepB = Me.btnReports.Left
                'UtiT = Me.btnUtility.Top
                'UtiB = Me.btnUtility.Left
                'HlpT = Me.btnHelp.Top
                'HlpB = Me.btnHelp.Left
                'ExT = Me.btnExit.Top
                'ExB = Me.btnExit.Left
                'ConT = Me.btncontmst.Top
                'ConB = Me.btncontmst.Left
                'CarT = Me.btnmstcart.Top
                'Carb = Me.btnmstcart.Left

                'RegT = Me.btnRegister.Top
                'RegL = Me.btnRegister.Left

                Me.AutoScroll = False
                Me.PStuffPicBx1.Image = myBitmap800
                Me.BackgroundImage = myBitmap800

                PStuffPicBx.Width = 800
                PStuffPicBx.Height = 520

                'Me.btnRegister.Top = RegT - 115
                'Me.btnRegister.Left = RegL - 125

                'Me.btnNavigate.Top = NavT - 70
                'Me.btnNavigate.Left = NavB - 113
                'Me.btnMasters.Top = MasT - 70
                'Me.btnMasters.Left = MasB - 113
                'Me.btnStuffing.Top = StuT - 70
                'Me.btnStuffing.Left = StuB - 113
                'Me.btnReports.Top = RepT - 70
                'Me.btnReports.Left = RepB - 113
                'Me.btnUtility.Top = UtiT - 70
                'Me.btnUtility.Left = UtiB - 113
                'Me.btnHelp.Top = HlpT - 70
                'Me.btnHelp.Left = HlpB - 113
                'Me.btnExit.Top = ExT - 70
                'Me.btnExit.Left = ExB - 113
                'Me.btncontmst.Top = ConT - 70
                'Me.btncontmst.Left = ConB - 113
                'Me.btnmstcart.Top = CarT - 70
                'Me.btnmstcart.Left = Carb - 113

            End If

        Catch err As Exception
            MsgBox(err.Message)
            MsgBox(err.ToString)
            MessageBox.Show("Error in ScreenResize", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub MDIForm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        GC.Collect()
        Call ClosingAllOpenModuleForm()
        Call OLEDBCompactDb()
        Application.Exit()
        GC.Collect()
    End Sub

    Private Sub MDIForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GC.Collect()
        Call ClosingAllOpenModuleForm()
        Call My.Application.CompactOLEDB()
        GC.Collect()
    End Sub

    Private Sub MDIForm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    'Private Sub MDIForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    '    Try

    '        'Dim Result As Integer

    '        'Result = MessageBox.Show("Close the 'P-Stuff Application'", "Closing P-Stuff", MessageBoxButtons.OK)             'MBx(0, "Do you want to really close the application", "Closing P-Stuff", MB_ICONQUESTION Or MB_YES)

    '        'If Result = MsgBoxResult.Ok Then
    '        '    btnExit_Click(sender, e)
    '        'Else
    '        '    Exit Sub
    '        '    'btnRestart_Click(sender, e)
    '        'End If


    '        'Dim Result As String

    '        'Result = MessageBox.Show("Do you want to really close the application", "Closing Sky stuff plus info.....", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

    '        'If Result = MsgBoxResult.Yes Then

    '        '    btnExit_Click(sender, e)

    '        'ElseIf Result = MsgBoxResult.No Then

    '        '    btnRestart_Click(sender, e)

    '        'End If

    '    Catch Er As Exception
    '        MsgBox(Er.Message)
    '        MsgBox(Er.ToString)
    '        MessageBox.Show("Fatal error in closing application", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        GC.Collect()
    '        conn.Close()
    '        'Me.Dispose(True)
    '        'Me.Close()

    '    End Try

    'End Sub

    'Private Sub MDIForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    '    If e.KeyCode = Keys.Escape Then Close()
    'End Sub

    'Private Sub MDIForm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
    '    'Dim f As System.Windows.Forms.KeyEventArgs = New KeyEventArgs(Keys.Escape)
    '    'Call MDIForm_KeyDown(sender, f)
    '    If Asc(e.KeyChar) = Keys.Escape Then Close()
    '    'If f.KeyCode = Keys.Escape Then Close()
    'End Sub


    Private Sub MDIForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            GC.Collect()
            ScreenRe()
            Me.Cursor = Cursors.WaitCursor
            'PStuffPicBx.Visible = False
            'PStuffPicBx1.Visible = False
            'Me.PictureBox1.Width = Me.Width - 30
            'Me.PictureBox1.Height = Me.Height - 30
            'Me.AutoScroll = True

            Call verGet()           'Application File version dispaly

            Me.TopMost = True

            ToolStripStatusLabel1.Text = ""
            PStuffPicBx.Enabled = True

            Dim flNm As String = "C:\Program Files\Alteros 3D\settings.ini"
            Dim fileLive As Boolean

            fileLive = My.Computer.FileSystem.FileExists(flNm)

            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Lighttek\Alteros\Browser", "autostart", CurDir() & "\first.wrl")

            If fileLive Then
                My.Computer.FileSystem.DeleteFile("C:\Program Files\Alteros 3D\settings.ini")
            End If

            '    StartedOnce = False

            '    Dim cmd As New OleDb.OleDbCommand
            '    Dim rdrWin As OleDb.OleDbDataReader
            '    Dim Sql As String
            '    Dim mDate As String

            '    If connWin.State = ConnectionState.Closed Then connWin.Open()
            '    cmd.Connection = connWin

            '    cmd.CommandText = "Select * from WinSecure"
            '    rdrWin = cmd.ExecuteReader

            '    Me.AutoSizeMode = Windows.Forms.AutoSizeMode.GrowOnly

            '    If rdrWin.HasRows = True Then
            '        rdrWin.Read()

            '        'mDemo = SkyReg.DecryptPassword(rdrWin("CD"))

            '        If (rdrWin("D1") & "") = "" Then
            '            mDate = SkyReg.EncryptPassword(Format(Now, "dd/MMM/yyyy"))
            '            Sql = ""
            '            Sql = "Update WinSecure Set D1 = '" & mDate & "'"
            '            If connWin.State = ConnectionState.Open Then connWin.Close()
            '            If connWin.State = ConnectionState.Closed Then connWin.Open()
            '            cmd.Connection = connWin
            '            cmd.CommandText = Sql
            '            cmd.ExecuteNonQuery()
            '        End If

            '        If mDemo = "DEMO" Then
            '            If connWin.State = ConnectionState.Open Then connWin.Close()
            '            If connWin.State = ConnectionState.Closed Then connWin.Open()
            '            cmd.Connection = connWin
            '            Sql = "Delete from UsrSec "
            '            cmd.CommandText = Sql
            '            cmd.ExecuteNonQuery()
            '        End If

            '        'If SkyReg.ChkSavedId(CurDir()) = True Then
            '        btnRegister.Visible = False
            '        If connWin.State = ConnectionState.Open Then connWin.Close()
            '        If connWin.State = ConnectionState.Closed Then connWin.Open()
            '        cmd.Connection = connWin
            '        Sql = "Update UsrSec Set XB = '' where isnull (XB)"
            '        cmd.CommandText = Sql
            '        cmd.ExecuteNonQuery()

            '        If connWin.State = ConnectionState.Open Then connWin.Close()
            '        If connWin.State = ConnectionState.Closed Then connWin.Open()
            '        cmd.Connection = connWin
            '        cmd.CommandText = "Select * from UsrSec where trim(XB) = '' or isnull (XB)"
            '        rdrWin = cmd.ExecuteReader

            '        If rdrWin.HasRows = True Then
            '            btnRegister.Visible = True
            '        End If
            '    Else
            '        btnRegister.Visible = True
            '    End If
            '    'Else
            '    'btnNavigate.Visible = False
            '    'btnHelp.Visible = False
            '    btnRegister.Visible = False
            '    'SkyReg.ShowSec(CurDir(), "Stuff")
            '    'End If

            Me.TopMost = False

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in MDIForm_Load", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Call Form10.utilityColorLayoutGet()                ' Util opt
            Call Form10.utilityProgressBarGet()
            Call Form10.GetSetLink()
            connWin.Close()
            GC.Collect()
            Call MemoryManagement.FlushMemory()
            Me.Cursor = Cursors.Arrow
            'Me.WindowState = FormWindowState.Maximized
        End Try

        Try
            Call LoadLibraryCSP()               'Loading the assembly in current call in memory
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in LoadLibraryCSP", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            GC.Collect()
        End Try

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PStuffPicBx.Click

        btnMasters.Visible = False
        btnStuffing.Visible = False
        btnReports.Visible = False
        btnUtility.Visible = False
        btnUpdate.Visible = False

        btnContainerStuffPlusHelp.Visible = False
        btnWT.Visible = False
        btnAboutStuffPlus.Visible = False
        btnStuffUC.Visible = False
        btnStuffUG.Visible = False
        btnCSysInfo.Visible = False

        btnRestart.Visible = False

        btnStuffViewer.Visible = False
        btnImportExport.Visible = False
        btnPlugPlay.Visible = False
        btnImageView.Visible = False
        btnOptions.Visible = False
        btnStuffPlusTools.Visible = False

        btnBoxStuffing.Visible = False
        btnDrumtype.Visible = False
        btnBoxDrumType.Visible = False
        btnOthertype.Visible = False

        btnBoxContainer.Visible = False
        btnDrumContainer.Visible = False
        btnBoxDrumContainer.Visible = False
        btnOtherContainer.Visible = False

        btnBoxCarton.Visible = False
        btnDrumCarton.Visible = False
        btnBoxDrumCarton.Visible = False
        btnOtherCarton.Visible = False

    End Sub

    Private Sub PictureBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PStuffPicBx.DoubleClick
        Try
            Process.Start("www.pristinenterprises.com")
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in P-Stuff Link", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PictureBox1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PStuffPicBx.MouseClick

        btnContainerStuffPlusHelp.Visible = False
        btnWT.Visible = False
        btnAboutStuffPlus.Visible = False
        btnStuffUC.Visible = False
        btnStuffUG.Visible = False
        btnCSysInfo.Visible = False

    End Sub

    Private Sub PictureBox1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PStuffPicBx.MouseHover

        btncontmst.Visible = False
        btnmstcart.Visible = False
        btnfreightmst.Visible = False
        bbtncustmst.Visible = False

        btnContainerStuffPlusHelp.Visible = False
        btnWT.Visible = False
        btnAboutStuffPlus.Visible = False
        btnStuffUC.Visible = False
        btnStuffUG.Visible = False
        btnCSysInfo.Visible = False

        btnRestart.Visible = False

        btnStuffViewer.Visible = False
        btnImportExport.Visible = False
        btnPlugPlay.Visible = False
        btnImageView.Visible = False
        btnOptions.Visible = False
        btnStuffPlusTools.Visible = False

        btnBoxStuffing.Visible = False
        btnDrumtype.Visible = False
        btnBoxDrumType.Visible = False
        btnOthertype.Visible = False

        btnBoxContainer.Visible = False
        btnDrumContainer.Visible = False
        btnBoxDrumContainer.Visible = False
        btnOtherContainer.Visible = False

        btnBoxCarton.Visible = False
        btnDrumCarton.Visible = False
        btnBoxDrumCarton.Visible = False
        btnOtherCarton.Visible = False

    End Sub

    Public Sub ButtonHide()

        btnMasters.Visible = False
        btnStuffing.Visible = False
        btnReports.Visible = False
        btnUtility.Visible = False
        btncontmst.Visible = False
        btnmstcart.Visible = False
        bbtncustmst.Visible = False
        btnfreightmst.Visible = False
        btnUpdate.Visible = False

    End Sub

    Public Sub CheckUsrSec()

        Try

            Dim Sql As String
            'Dim comm As sdo.OleDbCommand
            Sql = "Create Table UsrSec (XA Text (50),XB Text (50),XC Text (50),XD Text (50)) "
            Dim comm As sdo.OleDbCommand = New sdo.OleDbCommand(Sql, connWin)
            If connWin.State = ConnectionState.Closed Then connWin.Open()
            comm.CommandType = CommandType.Text
            comm.ExecuteNonQuery()
        Catch ex As Exception
            If ex.Message = "Table 'UsrSec' already exists." Then
                Exit Sub
            Else
                MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
                Exit Sub
            End If
        End Try

    End Sub

    Private Sub btnStuffing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStuffing.Click

        Try

            Call ButtonHide()
            'ChooseActivity.Show()
            'btnBoxStuffing.Visible = True
            'btnDrumtype.Visible = True
            'btnBoxDrumType.Visible = True
            'btnOthertype.Visible = True

            Call btnBoxType_Click(sender, e)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in btnStuffing_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnNavigate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNavigate.Click
        'Stop

        Try

            'If mDemo <> "DEMO" And btnRegister.Visible = True Then
            '    MsgBox("Unregistered Version. First Register and then Proceed", vbExclamation)
            '    Exit Sub
            'End If

            If StartedOnce = False Then
                'If SkyReg.SwConfirmStatus(CurDir()) = False Then Exit Sub
            End If

            StartedOnce = True

            btnMasters.Parent = PStuffPicBx
            btnStuffing.Parent = PStuffPicBx
            btnReports.Parent = PStuffPicBx
            btnUtility.Parent = PStuffPicBx
            btnUpdate.Parent = PStuffPicBx

            btncontmst.Parent = PStuffPicBx
            btnmstcart.Parent = PStuffPicBx
            btnfreightmst.Parent = PStuffPicBx
            bbtncustmst.Parent = PStuffPicBx

            PStuffPicBx.Enabled = True
            btnMasters.Visible = True
            btnStuffing.Visible = True
            btnReports.Visible = True
            btnUtility.Visible = True
            btnUpdate.Visible = False
            'btncontmst.Visible = Not btncontmst.Visible
            'btnmstcart.Visible = Not btnmstcart.Visible
            'bbtncustmst.Visible = Not bbtncustmst.Visible
            'btnfreightmst.Visible = Not btnfreightmst.Visible
            If btnMasters.Visible = False Then
                btncontmst.Visible = False
                btnmstcart.Visible = False
                bbtncustmst.Visible = False
                btnfreightmst.Visible = False
            End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in btnNavigate_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnNavigate_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNavigate.MouseEnter

        Call Navigation()

        'ToolStripStatusLabel1.Text = "Click to view stuff menu Navigation."
        btnNavigate.ImageIndex = imgNavigationMO

        Call visibilityRemove()

    End Sub

    Private Sub visibilityRemove()

        Me.btnMasters.Visible = False
        Me.btnStuffing.Visible = False
        Me.btnReports.Visible = False
        Me.btnUtility.Visible = False
        Me.btncontmst.Visible = False
        Me.btnmstcart.Visible = False

    End Sub

    'Private Sub btnNavigate_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNavigate.MouseHover

    '    ToolStripStatusLabel1.Text = "Click to view stuff menu Navigation."
    '    btnNavigate.ImageIndex = imgNavigationMO

    'End Sub

    Private Sub btnNavigate_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNavigate.MouseLeave

        btnNavigate.ImageIndex = imgNavigation
        ToolStripStatusLabel1.Text = ""

    End Sub

    Private Sub btnMasters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMasters.Click
        Call btnMasters_MouseEnter(sender, e)
    End Sub

    Private Sub btnMasters_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMasters.MouseEnter

        Try
            masters()
            btnMasters.ImageIndex = imgMasterMO
            btncontmst.Visible = True
            btnmstcart.Visible = True

            btnfreightmst.Visible = False
            bbtncustmst.Visible = False

            btnBoxStuffing.Visible = False
            btnDrumtype.Visible = False
            btnBoxDrumType.Visible = False
            btnOthertype.Visible = False

            btnBoxContainer.Visible = False
            btnDrumContainer.Visible = False
            btnBoxDrumContainer.Visible = False
            btnOtherContainer.Visible = False

            btnBoxCarton.Visible = False
            btnDrumCarton.Visible = False
            btnBoxDrumCarton.Visible = False
            btnOtherCarton.Visible = False

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in btnMasters_MouseEnter", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'Private Sub btnMasters_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMasters.MouseHover

    '    Try

    '        btnMasters.ImageIndex = imgMasterMO
    '        btncontmst.Visible = True
    '        btnmstcart.Visible = True

    '        btnfreightmst.Visible = False
    '        bbtncustmst.Visible = False

    '        btnBoxStuffing.Visible = False
    '        btnDrumtype.Visible = False
    '        btnBoxDrumType.Visible = False
    '        btnOthertype.Visible = False

    '        btnBoxContainer.Visible = False
    '        btnDrumContainer.Visible = False
    '        btnBoxDrumContainer.Visible = False
    '        btnOtherContainer.Visible = False

    '        btnBoxCarton.Visible = False
    '        btnDrumCarton.Visible = False
    '        btnBoxDrumCarton.Visible = False
    '        btnOtherCarton.Visible = False

    '    Catch Err As Exception
    '        MsgBox(Err.Message)
    '        MsgBox(Err.ToString)
    '        MessageBox.Show("Error in btnMasters_MouseHover", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    'End Sub

    Private Sub btnMasters_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMasters.MouseLeave

        btnMasters.ImageIndex = imgMaster
        ToolStripStatusLabel1.Text = ""

    End Sub

    Private Sub btnStuffing_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnStuffing.MouseEnter

        stuffing()

        btnStuffing.ImageIndex = imgStuffingMO
        ToolStripStatusLabel1.Text = "Click to view Inward Entry && Items Stuffing Activity."

        Call LostVisibleMasters()

    End Sub

    Private Sub LostVisibleMasters()

        Me.btncontmst.Visible = False
        Me.btnmstcart.Visible = False

    End Sub

    'Private Sub btnStuffing_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnStuffing.MouseHover

    '    btnStuffing.ImageIndex = imgStuffingMO
    '    ToolStripStatusLabel1.Text = "Click to view Inward Entry && Items Stuffing Activity."
    '    'btncontmst.Visible = False
    '    'btnmstcart.Visible = False
    '    'btnfreightmst.Visible = False
    '    'bbtncustmst.Visible = False

    '    ''btnBoxStuffing.Visible = True
    '    ''btnDrumtype.Visible = True
    '    ''btnBoxDrumType.Visible = True
    '    ''btnOthertype.Visible = True

    '    'btnBoxContainer.Visible = False
    '    'btnDrumContainer.Visible = False
    '    'btnBoxDrumContainer.Visible = False
    '    'btnOtherContainer.Visible = False

    '    'btnBoxCarton.Visible = False
    '    'btnDrumCarton.Visible = False
    '    'btnBoxDrumCarton.Visible = False
    '    'btnOtherCarton.Visible = False

    'End Sub

    Private Sub btnStuffing_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnStuffing.MouseLeave

        btnStuffing.ImageIndex = imgStuffing
        ToolStripStatusLabel1.Text = ""

    End Sub

    Private Sub btnReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReports.Click

        Try
            Call SendBack()
            ContainerReport.MdiParent = Me
            ContainerReport.Show()
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in btnReports_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnReports_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReports.MouseEnter
        reports()
        btnReports.ImageIndex = imgReportsMO
        ToolStripStatusLabel1.Text = "Click to view Summarized Container Report."
        btncontmst.Visible = False
        btnmstcart.Visible = False
        btnfreightmst.Visible = False
        bbtncustmst.Visible = False

        btnBoxStuffing.Visible = False
        btnDrumtype.Visible = False
        btnBoxDrumType.Visible = False
        btnOthertype.Visible = False

        btnBoxContainer.Visible = False
        btnDrumContainer.Visible = False
        btnBoxDrumContainer.Visible = False
        btnOtherContainer.Visible = False

    End Sub

    'Private Sub btnReports_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReports.MouseHover

    '    btnReports.ImageIndex = imgReportsMO
    '    ToolStripStatusLabel1.Text = "Click to view Summarized Container Report."
    '    btncontmst.Visible = False
    '    btnmstcart.Visible = False
    '    btnfreightmst.Visible = False
    '    bbtncustmst.Visible = False

    '    btnBoxStuffing.Visible = False
    '    btnDrumtype.Visible = False
    '    btnBoxDrumType.Visible = False
    '    btnOthertype.Visible = False

    '    btnBoxContainer.Visible = False
    '    btnDrumContainer.Visible = False
    '    btnBoxDrumContainer.Visible = False
    '    btnOtherContainer.Visible = False

    'End Sub

    Private Sub btnReports_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReports.MouseLeave

        btnReports.ImageIndex = imgReports
        ToolStripStatusLabel1.Text = ""

    End Sub

    Private Sub btnUtility_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUtility.Click

        Call SendBack()
        Form10.MdiParent = Me
        Form10.Show()
        'btnStuffPlusTools.Visible = True

    End Sub

    Private Sub btnUtility_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUtility.MouseEnter

        utility()
        btnUtility.ImageIndex = imgUtilityMO
        ToolStripStatusLabel1.Text = "Click to view Utility."
        btncontmst.Visible = False
        btnmstcart.Visible = False
        btnfreightmst.Visible = False
        bbtncustmst.Visible = False

        btnBoxStuffing.Visible = False
        btnDrumtype.Visible = False
        btnBoxDrumType.Visible = False
        btnOthertype.Visible = False

        btnBoxContainer.Visible = False
        btnDrumContainer.Visible = False
        btnBoxDrumContainer.Visible = False
        btnOtherContainer.Visible = False

        btnBoxCarton.Visible = False
        btnDrumCarton.Visible = False
        btnBoxDrumCarton.Visible = False
        btnOtherCarton.Visible = False

    End Sub

    'Private Sub btnUtility_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUtility.MouseHover

    '    btnUtility.ImageIndex = imgUtilityMO
    '    ToolStripStatusLabel1.Text = "Click to view Utility."
    '    btncontmst.Visible = False
    '    btnmstcart.Visible = False
    '    btnfreightmst.Visible = False
    '    bbtncustmst.Visible = False

    '    btnBoxStuffing.Visible = False
    '    btnDrumtype.Visible = False
    '    btnBoxDrumType.Visible = False
    '    btnOthertype.Visible = False

    '    btnBoxContainer.Visible = False
    '    btnDrumContainer.Visible = False
    '    btnBoxDrumContainer.Visible = False
    '    btnOtherContainer.Visible = False

    '    btnBoxCarton.Visible = False
    '    btnDrumCarton.Visible = False
    '    btnBoxDrumCarton.Visible = False
    '    btnOtherCarton.Visible = False

    'End Sub

    Private Sub btnUtility_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUtility.MouseLeave

        btnUtility.ImageIndex = imgUtility
        ToolStripStatusLabel1.Text = ""

    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        Try

            frmUpdtData.ShowDialog()

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in btnUpdate_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnUpdate_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.MouseHover

        btnUpdate.ImageIndex = imgUpdate_DatabaseMO
        ToolStripStatusLabel1.Text = "Click to Update Database Structure."
        btncontmst.Visible = False
        btnmstcart.Visible = False
        btnfreightmst.Visible = False
        bbtncustmst.Visible = False

        btnBoxStuffing.Visible = False
        btnDrumtype.Visible = False
        btnBoxDrumType.Visible = False
        btnOthertype.Visible = False

        btnBoxContainer.Visible = False
        btnDrumContainer.Visible = False
        btnBoxDrumContainer.Visible = False
        btnOtherContainer.Visible = False

        btnBoxCarton.Visible = False
        btnDrumCarton.Visible = False
        btnBoxDrumCarton.Visible = False
        btnOtherCarton.Visible = False

    End Sub

    Private Sub btnUpdate_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.MouseLeave

        btnUpdate.ImageIndex = imgUpdate_Database
        ToolStripStatusLabel1.Text = ""

    End Sub

    Private Sub btncontmst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncontmst.Click

        Call ButtonHide()
        'btnBoxContainer.Visible = True
        'btnDrumContainer.Visible = True
        'btnBoxDrumContainer.Visible = True
        'btnOtherContainer.Visible = True
        'ChooseContainer.Show()

        Call btnBoxContainer_Click(sender, e)

    End Sub

    Private Sub btncontmst_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncontmst.MouseEnter

        containermasters()
        btncontmst.ImageIndex = imgContainerMO

        'btnBoxContainer.Visible = True
        'btnDrumContainer.Visible = True
        'btnBoxDrumContainer.Visible = True
        'btnOtherContainer.Visible = True

        btnBoxCarton.Visible = False
        btnDrumCarton.Visible = False
        btnBoxDrumCarton.Visible = False
        btnOtherCarton.Visible = False

    End Sub

    'Private Sub btncontmst_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncontmst.MouseHover

    '    btncontmst.ImageIndex = imgContainerMO

    '    'btnBoxContainer.Visible = True
    '    'btnDrumContainer.Visible = True
    '    'btnBoxDrumContainer.Visible = True
    '    'btnOtherContainer.Visible = True

    '    btnBoxCarton.Visible = False
    '    btnDrumCarton.Visible = False
    '    btnBoxDrumCarton.Visible = False
    '    btnOtherCarton.Visible = False

    'End Sub

    Private Sub btncontmst_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncontmst.MouseLeave

        btncontmst.ImageIndex = imgContainer
        ToolStripStatusLabel1.Text = ""

    End Sub

    Private Sub btnmstcart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmstcart.Click

        Call ButtonHide()
        'ChooseItem.Show()
        'btnBoxCarton.Visible = True
        'btnDrumCarton.Visible = True
        'btnBoxDrumCarton.Visible = True
        'btnOtherCarton.Visible = True

        Call btnBoxCarton_Click(sender, e)

    End Sub

    Private Sub btnmstcart_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnmstcart.MouseEnter

        cartonmaster()
        btnmstcart.ImageIndex = imgCartonMO

        'btnBoxCarton.Visible = True
        'btnDrumCarton.Visible = True
        'btnBoxDrumCarton.Visible = True
        'btnOtherCarton.Visible = True

        btnBoxContainer.Visible = False
        btnDrumContainer.Visible = False
        btnBoxDrumContainer.Visible = False
        btnOtherContainer.Visible = False

    End Sub

    'Private Sub btnmstcart_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnmstcart.MouseHover

    '    btnmstcart.ImageIndex = imgCartonMO

    '    'btnBoxCarton.Visible = True
    '    'btnDrumCarton.Visible = True
    '    'btnBoxDrumCarton.Visible = True
    '    'btnOtherCarton.Visible = True

    '    btnBoxContainer.Visible = False
    '    btnDrumContainer.Visible = False
    '    btnBoxDrumContainer.Visible = False
    '    btnOtherContainer.Visible = False

    'End Sub

    Private Sub btnmstcart_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnmstcart.MouseLeave

        btnmstcart.ImageIndex = imgCarton
        ToolStripStatusLabel1.Text = ""

    End Sub

    Private Sub bbtncustmst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bbtncustmst.Click

        Call ButtonHide()
        CustomerMaster.ShowDialog()

    End Sub

    Private Sub bbtncustmst_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles bbtncustmst.MouseHover

        bbtncustmst.ImageIndex = imgCustomerMO

        btnBoxContainer.Visible = False
        btnDrumContainer.Visible = False
        btnBoxDrumContainer.Visible = False
        btnOtherContainer.Visible = False

        btnBoxCarton.Visible = False
        btnDrumCarton.Visible = False
        btnBoxDrumCarton.Visible = False
        btnOtherCarton.Visible = False

    End Sub

    Private Sub bbtncustmst_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles bbtncustmst.MouseLeave

        bbtncustmst.ImageIndex = imgCustomer
        ToolStripStatusLabel1.Text = ""

    End Sub

    Private Sub btnfreightmst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnfreightmst.Click

        Call ButtonHide()
        FreightMaster.ShowDialog()

    End Sub

    Private Sub btnfreightmst_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnfreightmst.MouseHover

        btnfreightmst.ImageIndex = imgFreightMO

        btnBoxContainer.Visible = False
        btnDrumContainer.Visible = False
        btnBoxDrumContainer.Visible = False
        btnOtherContainer.Visible = False

        btnBoxCarton.Visible = False
        btnDrumCarton.Visible = False
        btnBoxDrumCarton.Visible = False
        btnOtherCarton.Visible = False

    End Sub

    Private Sub btnfreightmst_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnfreightmst.MouseLeave

        btnfreightmst.ImageIndex = imgFreight
        ToolStripStatusLabel1.Text = ""

    End Sub

    Private Sub btnHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHelp.Click

        Try

            Process.Start(CurDir() & "\HelpContainerStuff\Index.chm")

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in Help Button Click", "Error.....", MessageBoxButtons.OK)
        End Try

        'btnContainerStuffPlusHelp.Visible = True
        ''btnWT.Visible = True
        'btnAboutStuffPlus.Visible = True
        ''btnStuffUC.Visible = True
        ''btnStuffUG.Visible = True
        'btnCSysInfo.Visible = True

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click

        Call OLEDBCompactDb()
        'Dim MsgRslt As String = Nothing

        'MsgRslt = MessageBox.Show("Do you realy want to quit", "Container stuff plus info.....", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        'If MsgRslt = MsgBoxResult.Yes Then

        GC.Collect()
        Historys() 'History Recorded

        '23 May 2k8 Impliment Here
        'Me.Focus()
        Me.Close()
        Application.Exit()

        Try
            'DisplayActivity.lblDisplayActivity.Visible = True
            'DisplayActivity.lblDisplayActivity.Text = "Please wait..." & Chr(13) & "The Container stuffing application is close"
            'DisplayActivity.Show()
            'Me.Dispose(True)
        Catch ex As Exception
            Exit Try
        Finally
            'Call frmUpdtData.CompactDatabase()
            'Me.Dispose(True)
            'Me.Close()
            'Application.Exit()
            'GC.Collect()
        End Try

        'End If


    End Sub

    Private Sub btnRegister_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegister.Click

        Try

            Call CheckUsrSec()

            'If SkyReg.RegisterNode(CurDir()) = False Then
            '    frmRegister.ShowDialog()
            'End If

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in btnRegister_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnHelp_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHelp.MouseEnter

        Help()
        btnHelp.ImageIndex = imgHelpMO
        'ToolStripStatusLabel1.Text = "Help and Other Info Use"

    End Sub

    'Private Sub btnHelp_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHelp.MouseHover

    '    btnHelp.ImageIndex = imgHelpMO
    '    ToolStripStatusLabel1.Text = "Help and Other Info Use"

    'End Sub

    Private Sub btnHelp_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHelp.MouseLeave

        btnHelp.ImageIndex = imgHelp
        ToolStripStatusLabel1.Text = ""

    End Sub

    Private Sub btnExit_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.MouseEnter
        Aexit()
        btnExit.ImageIndex = imgExitMO
    End Sub

    'Private Sub btnExit_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.MouseHover

    '    btnExit.ImageIndex = imgExitMO
    '    'btnRestart.Visible = True

    'End Sub

    Private Sub btnExit_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.MouseLeave

        btnExit.ImageIndex = imgExit
        ToolStripStatusLabel1.Text = ""

    End Sub

    Private Sub btnRegister_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnRegister.KeyPress
        If (Control.ModifierKeys And Keys.Shift) = Keys.Shift Then
            MessageBox.Show("Pressed " & Keys.Shift)
        End If
    End Sub

    Private Sub btnRegister_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegister.MouseEnter
        register()
        btnRegister.ImageIndex = imgRegisterMO

    End Sub

    'Private Sub btnRegister_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegister.MouseHover

    '    btnRegister.ImageIndex = imgRegisterMO

    'End Sub

    Private Sub btnRegister_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegister.MouseLeave

        btnRegister.ImageIndex = imgRegister

    End Sub


    Public Sub uu(ByVal i As Integer)

        MsgBox(i)

    End Sub

    Public Sub vv()

        Dim nn As xx.cc = New xx.cc(AddressOf uu)
        nn.Invoke(2)

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Form7.Show()

    End Sub

    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim ar1 As New Area
        Dim ar2 As New Area
        ar1.StrtPt.x = 0
        ar1.StrtPt.y = 0
        ar1.StrtPt.z = 0
        ar1.length = 100
        ar1.width = 100
        ar1.height = 100

        ar2.StrtPt.x = 0
        ar2.StrtPt.y = 0
        ar2.StrtPt.z = 0
        ar2.length = 20.1
        ar2.width = 20.1
        ar2.height = 10
        Dim pt As New Point
        pt.x = ar1.length
        pt.y = ar1.width
        pt.z = ar1.height

        Strt("c:\addd.wrl", True, pt)

        Closef("c:\addd.wrl")

    End Sub

    Private Sub Button1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Button1.KeyPress

        Try
            If (Control.ModifierKeys And Keys.Shift) = Keys.Shift Then
                btnExit_Click(sender, e)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in Keypress", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub Button1_Click_3(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim ptm As New Container_Stuff.Point
        ptm.x = 10
        ptm.y = 10
        ptm.z = 10
        strt1("c:\gg.wrl", True)
        Dim arx As New Area
        arx.length = 10
        arx.width = 10
        arx.height = 10
        arx.StrtPt.x = 0
        arx.StrtPt.y = 0
        arx.StrtPt.z = 0
        placecyl(arx, 1.5, 1.5, 12)
        Closef("c:\gg.wrl")

    End Sub

    Private Sub btnContainerStuffPlusHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContainerStuffPlusHelp.Click

        Process.Start(CurDir() & "\HelpContainerStuff\Index.chm")

    End Sub

    Private Sub btnCSysInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCSysInfo.Click

        Process.Start(CurDir() & "\SystemInformation\HIL_Satwadhir_CSP_SystemInfoPROJECT.exe")

    End Sub

    Private Sub btnRestart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRestart.Click

        Historys() 'History Recorded

        Dim msgBxRslt As String = Nothing

        msgBxRslt = MessageBox.Show("Do you want to restarting application", "Closing P-Stuff .....", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If msgBxRslt = MsgBoxResult.Yes Then

            '23 May 2k8 Impliment Here
            Me.Focus()
            GC.Collect()
            Try
                'DisplayActivity.lblDisplayActivity.Visible = True
                'DisplayActivity.lblDisplayActivity.Text = "Please wait..." & Chr(13) & "The container stuffing application is restarting"
                'DisplayActivity.Show()
                'Me.Dispose(True)
            Catch ex As Exception
                Exit Try
            Finally
                Me.Dispose(True)
                Me.Close()
                Application.Exit()
                GC.Collect()
                Process.Start(CurDir() & "\Container Stuff.exe")
            End Try

        End If

    End Sub

    Private Sub btnOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptions.Click

        Form10.Show()

    End Sub

    Private Sub btnStuffPlusTools_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStuffPlusTools.Click

        btnStuffViewer.Visible = True
        btnImportExport.Visible = True
        btnPlugPlay.Visible = True
        btnImageView.Visible = True
        btnOptions.Visible = True

    End Sub

    Private Sub btnStuffPlusTools_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnStuffPlusTools.MouseHover

        btnStuffViewer.Visible = True
        btnImportExport.Visible = True
        btnPlugPlay.Visible = True
        btnImageView.Visible = True
        btnOptions.Visible = True

    End Sub

    Private Sub btnStuffViewer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStuffViewer.Click

        Try
            Stuff_Viewers.Show()
            Stuff_Viewers.Focus()
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in btnStuffViewer_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

    Private Sub btnImportExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportExport.Click

        Try
            Import_Export.Show()
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in btnImportExport_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

    Private Sub btnAboutStuffPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAboutStuffPlus.Click

        Try
            AboutStuffPlus.Show()
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in btnAboutStuffPlus_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

    Private Sub btnBoxType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoxStuffing.Click

        btnBoxStuffing.Visible = False
        btnDrumtype.Visible = False
        btnBoxDrumType.Visible = False
        btnOthertype.Visible = False
        Me.Focus()
        GC.Collect()
        Try
            ConDrm.Close()
            'DisplayActivity.lblDisplayActivity.Visible = True
            'DisplayActivity.lblDisplayActivity.Text = "Please wait..." & vbCrLf & "Box type stuffing activity show"
            'DisplayActivity.Show()
            'Me.Dispose(True)
        Catch ex As Exception
            Exit Try
        Finally

            Call SendBack()
            TransactionMenu.MdiParent = Me
            TransactionMenu.Show()
            TransactionMenu.BringToFront()

        End Try

    End Sub

    Public Sub SendBack()

        PStuffPicBx.SendToBack()
        btnNavigate.SendToBack()
        btnHelp.SendToBack()
        btnExit.SendToBack()
        btnRegister.SendToBack()
        Me.Refresh()

    End Sub

    Public Sub BringFront()

        PStuffPicBx.BringToFront()
        btnNavigate.BringToFront()
        btnHelp.BringToFront()
        btnExit.BringToFront()
        btnRegister.BringToFront()
        Me.Refresh()

    End Sub


    Private Sub btnDrumtype_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDrumtype.Click

        btnBoxStuffing.Visible = False
        btnDrumtype.Visible = False
        btnBoxDrumType.Visible = False
        btnOthertype.Visible = False
        Me.Focus()
        GC.Collect()

        Try
            conn.Close()
            DisplayActivity.lblDisplayActivity.Visible = True
            DisplayActivity.lblDisplayActivity.Text = "Please wait..." & vbCrLf & "Drum type stuffing activity show"

            DisplayActivity.Show()      'Showing the display activity form in 2 second for changing the activity
            Me.Dispose(True)
        Catch Ex As Exception

        Finally
            TransactionsMenu.Show()
        End Try

    End Sub

    Private Sub btnBoxDrumType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoxDrumType.Click

        MessageBox.Show(" Work in progress ", "Info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub btnOthertype_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOthertype.Click

        MessageBox.Show(" Work in progress ", "Info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)

        MsgBox("Database Manipulation")
        DbsManipulate()

    End Sub

    Private Sub btnBoxContainer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoxContainer.Click

        btnBoxContainer.Visible = False
        btnDrumContainer.Visible = False
        btnBoxDrumContainer.Visible = False
        btnOtherContainer.Visible = False
        Me.Focus()
        GC.Collect()
        Try
            'DisplayActivity.lblDisplayActivity.Visible = True
            'DisplayActivity.lblDisplayActivity.Text = "Please wait..." & vbCrLf & "Box Container master activity show"

            'DisplayActivity.Show()
            'Me.Dispose(True)
        Catch ex As Exception
            Exit Try
        Finally
            Try
                Call SendBack()
                ContainerMaster.MdiParent = Me
                ContainerMaster.Show()
            Catch Ex As Exception
                MsgBox(Ex.Message)
                MsgBox(Ex.ToString)
                Application.Exit()
            End Try
        End Try

    End Sub

    Private Sub btnDrumContainer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDrumContainer.Click

        btnBoxContainer.Visible = False
        btnDrumContainer.Visible = False
        btnBoxDrumContainer.Visible = False
        btnOtherContainer.Visible = False
        Me.Focus()
        GC.Collect()
        Try
            DisplayActivity.lblDisplayActivity.Visible = True
            DisplayActivity.lblDisplayActivity.Text = "Please wait..." & vbCrLf & "Drum Container master activity show"
            DisplayActivity.Show()
            Me.Dispose(True)
        Catch ex As Exception
            Exit Try
        Finally
            Try
                ContainerMasterDrum.Show()
            Catch Ex As Exception
                MsgBox(Ex.Message)
                MsgBox(Ex.ToString)
                Application.Exit()
            End Try
        End Try

    End Sub

    Private Sub btnBoxDrumContainer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoxDrumContainer.Click

        MessageBox.Show(" Work in progress ", "Info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub btnOtherContainer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtherContainer.Click

        MessageBox.Show(" Work in progress ", "Info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub btnBoxCarton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoxCarton.Click

        btnBoxCarton.Visible = False
        btnDrumCarton.Visible = False
        btnBoxDrumCarton.Visible = False
        btnOtherCarton.Visible = False
        Me.Focus()
        GC.Collect()
        Try
            'DisplayActivity.lblDisplayActivity.Visible = True
            'DisplayActivity.lblDisplayActivity.Text = "Please wait..." & vbCrLf & "Box type item entry activity show"

            'DisplayActivity.Show()
            'Me.Dispose(True)
        Catch ex As Exception
            Exit Try
        Finally
            Try
                Call SendBack()
                MasterCartonEntry.MdiParent = Me
                MasterCartonEntry.Show()
            Catch Ex As Exception
                MsgBox(Ex.Message)
                MsgBox(Ex.ToString)
                Application.Exit()
            End Try
        End Try
        'Me.Focus()
        'GC.Collect()
        'Try
        '    DisplayActivity.lblDisplayActivity.Visible = True
        '    DisplayActivity.lblDisplayActivity.Text = "Please wait..." & vbCrLf & "Box type item entry activity show"

        '    DisplayActivity.Show()
        '    Me.Dispose(True)
        'Catch ex As Exception
        '    Exit Try
        'Finally
        '    Try
        '        MasterCartonEntry.Show()
        '    Catch Ex As Exception
        '        MsgBox(Ex.Message)
        '        Application.Exit()

        '    End Try
        'End Try

    End Sub

    Private Sub btnDrumCarton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDrumCarton.Click

        btnBoxCarton.Visible = False
        btnDrumCarton.Visible = False
        btnBoxDrumCarton.Visible = False
        btnOtherCarton.Visible = False
        Me.Focus()
        GC.Collect()
        Try
            DisplayActivity.lblDisplayActivity.Visible = True
            DisplayActivity.lblDisplayActivity.Text = "Please wait..." & vbCrLf & "Drum type item entry activity show"

            DisplayActivity.Show()
            Me.Dispose(True)
        Catch ex As Exception
            Exit Try
        Finally
            Try
                MasterCartonDrmEntry.Show()
            Catch Ex As Exception
                MsgBox(Ex.Message)
                MsgBox(Ex.ToString)
                Application.Exit()
            End Try

        End Try

        'Me.Focus()
        'GC.Collect()
        'Try
        '    DisplayActivity.lblDisplayActivity.Visible = True
        '    DisplayActivity.lblDisplayActivity.Text = "Please wait..." & vbCrLf & "Drum type item entry activity show"

        '    DisplayActivity.Show()
        '    Me.Dispose(True)
        'Catch ex As Exception
        '    Exit Try
        'Finally
        '    Try
        '        MasterCartonDrmEntry.Show()
        '    Catch Ex As Exception
        '        MsgBox(Ex.Message)
        '        Application.Exit()
        '    End Try

        'End Try


    End Sub

    Private Sub btnBoxDrumCarton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoxDrumCarton.Click

        MessageBox.Show(" Work in progress ", "Info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub btnOtherCarton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOtherCarton.Click

        MessageBox.Show(" Work in progress ", "Info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub NotifyIcon_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon.Click
        Me.TopMost = True
        Me.TopMost = False
        Me.Focus()
    End Sub

    Private Sub btnLink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLink.Click

        Try
            Process.Start("www.pristinenterprises.com")
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in P Stuff Link", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'Private Sub MDIForm_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint

    '    Try

    '    Catch Err As Exception
    '        MsgBox(Err.Message)
    '        MsgBox(Err.ToString)
    '        MessageBox.Show("Error in Paint", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    'End Sub

    Private Sub mdiform_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

        Try
            'Call ScreenResize()
            Me.StartPosition = FormStartPosition.CenterScreen
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Paint", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub ClosingAllOpenModuleForm()

        Try
            Call OLEDBCompactDb()
            'Dim i As Int16 = 0
            'Dim j As Int16 = Application.OpenForms.Count - 1
            'Do While j >= 0
            '    If Application.OpenForms(j).Name.ToLower.Contains("MDIForm") Then
            '        'If Application.OpenForms(j).Name.ToLower.Contains("main") Then
            '        j -= 1
            '    Else
            '        Application.OpenForms(j).Close()
            '        j = Application.OpenForms.Count - 1
            '    End If
            'Loop

            Application.Exit()
            Environment.Exit(0)

        Catch er As Exception
            MsgBox(er.Message)
            MsgBox(er.ToString)
            MessageBox.Show("Error in Closing application", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub verGet()
        '    Try
        '        Dim sFile As New Scripting.FileSystemObject
        '        Dim aPath, pVer As String
        '        aPath = Application.ExecutablePath
        '        aPath = sFile.GetFileVersion(aPath)
        '        Tlstrpstlbl.Text = "Publish Version:" & aPath

        '        Dim dtApp As DateTime = DateTime.Now
        '        Dim appFile As String = Nothing
        '        dtApp = IO.Directory.GetCreationTime(Application.ExecutablePath)

        '        With My.Application.Info.Version

        '            pVer = .Major & "." & .Minor & "." & .Build & "." & .Revision
        '            dtApp = IO.Directory.GetCreationTime(Application.ExecutablePath)
        '            pVer = aPath & "::" & dtApp.Day & ":" & dtApp.Month & ":" & dtApp.Year & "::" & dtApp.Hour & "." & dtApp.Minute & "." & dtApp.Second

        '        End With

        '        Tlstrpstlbl.Text = "Publish Version::" & pVer

        '    Catch Er As Exception
        '        MsgBox(Er.Message)
        '        MsgBox(Er.ToString)
        '        MessageBox.Show("Error in publish version getting", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Try
    End Sub

#End Region

#Region " Function Definitions "

    Private Function ValidateSw() As Boolean

        Try

            'Dim Sql As String
            'Dim mDemo As String = Nothing
            'Dim mSingle As String
            'Dim mContainer As String
            'Dim mLock As String = Nothing
            'Call CheckUsrSec()

            'Dim Ds1 As New DataSet
            'Dim Da As sdo.OleDbDataAdapter
            'Sql = "Select * from WinSecure"
            'If connWin.State = ConnectionState.Closed Then connWin.Open()
            'Da = New sdo.OleDbDataAdapter(Sql, connWin)
            'If Ds1.Tables.CanRemove(Ds1.Tables("WinSecure")) = True Then
            '    Ds1.Tables("WinSecure").Rows.Clear()
            '    Ds1.Tables("WinSecure").Columns.Clear()
            'End If
            'Da.Fill(Ds1, "WinSecure")

            'If Ds1.Tables("Winsecure").Rows.Count > 0 Then
            '    mDemo = SkyReg.DecryptPassword(IIf(IsDBNull(Ds1.Tables("Winsecure").Rows(0).Item("CD")), "", Ds1.Tables!Winsecure.Rows(0).Item("CD")))
            '    If mDemo = "DEMO" Then
            '        If SkyReg.SwConfirmStatus(CurDir()) = False Then
            '            ValidateSw = True
            '            Application.Exit()
            '        End If
            '    Else
            '        mLock = SkyReg.DecryptPassword(IIf(IsDBNull(Ds1.Tables("Winsecure").Rows(0).Item("L1")), "", Ds1.Tables!Winsecure.Rows(0).Item("L1")))
            '        If UCase(mLock) = "LOCK" Then

            '        End If
            '    End If
            '    mSingle = SkyReg.DecryptPassword(IIf(IsDBNull(Ds1.Tables("Winsecure").Rows(0).Item("S1")), "", Ds1.Tables!Winsecure.Rows(0).Item("S1")))
            '    mContainer = SkyReg.DecryptPassword(IIf(IsDBNull(Ds1.Tables("Winsecure").Rows(0).Item("X34")), "", Ds1.Tables!Winsecure.Rows(0).Item("X34")))
            '    If mContainer = "NSTUFF" Then
            '        ValidateSw = True
            '        MsgBox("Unauthorised Software Registration. Application will Terminate`", MsgBoxStyle.Critical)
            '        Application.Exit()
            '    End If
            'End If

            'Dim comm As sdo.OleDbCommand
            'If mDemo = "DEMO" Then
            '    btnRegister.Visible = True
            'Else
            '    btnRegister.Visible = False

            '    If UCase(mLock) <> "LOCK" Then
            '        If SkyReg.ChkSavedId(CurDir()) = True Then
            '            Sql = "Update UsrSec Set XB = '' where isnull (XB)"
            '            comm = New sdo.OleDbCommand(Sql, conn)
            '            If conn.State = ConnectionState.Closed Then conn.Open()
            '            comm.ExecuteNonQuery()

            '            Sql = "Select * from UsrSec where trim(XB) = '' or isnull (XB)"
            '            If connWin.State = ConnectionState.Closed Then connWin.Open()
            '            Da = New sdo.OleDbDataAdapter(Sql, connWin)
            '            If Ds1.Tables.CanRemove(Ds1.Tables("WinSecure")) = True Then
            '                Ds1.Tables("WinSecure").Rows.Clear()
            '                Ds1.Tables("WinSecure").Columns.Clear()
            '            End If
            '            Da.Fill(Ds1, "WinSecure")
            '            If Ds1.Tables("Winsecure").Rows.Count > 0 Then
            '                btnRegister.Visible = True
            '                ValidateSw = True
            '            End If
            '        Else
            '            btnRegister.Visible = True
            '            ValidateSw = True
            '        End If
            '    End If
            'End If


            'Ramson Lock
            'If mLock = "UNLOCK" Then
            'Else
            '    'Call CheckLock()
            'End If


            ValidateSw = False
            Exit Function
        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Function

#End Region



End Class

