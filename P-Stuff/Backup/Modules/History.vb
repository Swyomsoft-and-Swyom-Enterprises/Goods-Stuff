
'Program Name: -   GenRoutines.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    Sky Stuff Plus (Container Stuffing)
'Date: -            23 Dec 2K8 12.52 PM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - History is the module in project which containing the date time and day where 
'               ever the project starts and stops this is store to the one of the file 
'               ContainerStuffPlus. Also the all dll reference is maintained when one of the 
'               dll is missing the error occurs to notify which dll is not in the deployment
'               of the project.  

#Region " Importing Objects "

Imports System
Imports System.Reflection

#End Region

Module History

#Region "Module Declaration "

    Public SIswHis As IO.StreamWriter

    Public Ctrl As Control = Nothing
    Public xLocUc, yLocUc As Integer

    Public StpShowFlg As Boolean = False

#End Region

#Region " Routine Definition "

    Public Sub Historys()

        Try
            'Stop
            Dim DTm As DateTime = DateTime.Now

            Dim DtTms As String = DTm.ToString("dd/MM/yyyy : hh : mm : ss : tt")
            'Dim dtmFile As String = DT.ToString("ddMMyyhms")

            Dim OutFiles As String = CurDir() & "\ContainerStuffPlus"

            Dim fileExists As Boolean
            Dim KillFile As Boolean

            fileExists = My.Computer.FileSystem.FileExists(OutFiles)

            If fileExists And KillFile Then
                Kill(OutFiles)
            End If

            SIswHis = New IO.StreamWriter(OutFiles)

            SIswHis.WriteLine(" The application history time     Date             Time      ")
            SIswHis.WriteLine("")
            SIswHis.WriteLine("The history time =>  " & DtTms & " Application time")

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in History", "Error .....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SIswHis.Close()
        End Try

    End Sub

    Public Sub LoadLibraryCSP()             'Loading the assembly in current call in memory

        Dim ObjAsy As Object
        Dim Dll As Assembly

        Try

            'Process.Start(CurDir() & "\Dll.bat")

            '1
            Dll = Reflection.Assembly.LoadFrom(CurDir() & "\CSPEncryptWr.dll")
            ObjAsy = Dll.CreateInstance("CSPEncryptWr.dll")
            Dll = Nothing
            ObjAsy = Nothing
            '2
            Dll = Reflection.Assembly.LoadFrom(CurDir() & "\CSPContnr.dll")
            ObjAsy = Dll.CreateInstance("CSPContnr.dll")
            Dll = Nothing
            ObjAsy = Nothing
            '3
            Dll = Reflection.Assembly.LoadFrom(CurDir() & "\DmpCSP.dll")
            ObjAsy = Dll.CreateInstance("DmpCSP.dll")
            Dll = Nothing
            ObjAsy = Nothing
            '4
            Dll = Reflection.Assembly.LoadFrom(CurDir() & "\DcpCSP.dll")
            ObjAsy = Dll.CreateInstance("DcpCSP.dll")
            Dll = Nothing
            ObjAsy = Nothing
            '5
            Dll = Reflection.Assembly.LoadFrom(CurDir() & "\DrmGmPtCSP.dll")
            ObjAsy = Dll.CreateInstance("DrmGmPtCSP.dll")
            Dll = Nothing
            ObjAsy = Nothing
            '6
            Dll = Reflection.Assembly.LoadFrom(CurDir() & "\DgCntPtCSP.dll")
            ObjAsy = Dll.CreateInstance("DgCntPtCSP.dll")
            Dll = Nothing
            ObjAsy = Nothing
            '7
            Dll = Reflection.Assembly.LoadFrom(CurDir() & "\DcFlgCSP.dll")
            ObjAsy = Dll.CreateInstance("DcFlgCSP.dll")
            Dll = Nothing
            ObjAsy = Nothing
            '8
            Dll = Reflection.Assembly.LoadFrom(CurDir() & "\DCalcQty.dll")
            ObjAsy = Dll.CreateInstance("DCalcQty.dll")
            Dll = Nothing
            ObjAsy = Nothing
            '9
            Dll = Reflection.Assembly.LoadFrom(CurDir() & "\DcaNrs.dll")
            ObjAsy = Dll.CreateInstance("DcaNrs.dll")
            Dll = Nothing
            ObjAsy = Nothing
            '10
            Dll = Reflection.Assembly.LoadFrom(CurDir() & "\DgmPtCAlt.dll")
            ObjAsy = Dll.CreateInstance("DgmPtCAlt.dll")
            Dll = Nothing
            ObjAsy = Nothing
            '11
            Dll = Reflection.Assembly.LoadFrom(CurDir() & "\DGmPtCA.dll")
            ObjAsy = Dll.CreateInstance("DGmPtCA.dll")
            Dll = Nothing
            ObjAsy = Nothing
            '12
            Dll = Reflection.Assembly.LoadFrom(CurDir() & "\CSPDbtracK.dll")
            ObjAsy = Dll.CreateInstance("CSPDbtracK.dll")
            Dll = Nothing
            ObjAsy = Nothing
            '13
            Dll = Reflection.Assembly.LoadFrom(CurDir() & "\DBxContnr.dll")
            ObjAsy = Dll.CreateInstance("DBxContnr.dll")
            Dll = Nothing
            ObjAsy = Nothing
            '14
            Dll = Reflection.Assembly.LoadFrom(CurDir() & "\CSP.dll")
            ObjAsy = Dll.CreateInstance("CSP.dll")
            Dll = Nothing
            ObjAsy = Nothing
            '15
            Dll = Reflection.Assembly.LoadFrom(CurDir() & "\SmallBasicLibrary.dll")
            ObjAsy = Dll.CreateInstance("SmallBasicLibrary.dll")
            Dll = Nothing
            ObjAsy = Nothing
            '16
            Dll = Reflection.Assembly.LoadFrom(CurDir() & "\ToneGen.dll")
            ObjAsy = Dll.CreateInstance("ToneGen.dll")
            Dll = Nothing
            ObjAsy = Nothing
            '17
            Dll = Reflection.Assembly.LoadFrom(CurDir() & "\GenMthCalc.dll")
            ObjAsy = Dll.CreateInstance("GenMthCalc.dll")
            Dll = Nothing
            ObjAsy = Nothing
            '18
            Dll = Reflection.Assembly.LoadFrom(CurDir() & "\CompactADb.dll")
            ObjAsy = Dll.CreateInstance("CompactADb.dll")
            Dll = Nothing
            ObjAsy = Nothing
            '19
            Dll = Reflection.Assembly.LoadFrom(CurDir() & "\CSPs.dll")
            ObjAsy = Dll.CreateInstance("CSPs.dll")
            Dll = Nothing
            ObjAsy = Nothing
            '20
            Dll = Reflection.Assembly.LoadFrom(CurDir() & "\OptMthd.dll")
            ObjAsy = Dll.CreateInstance("OptMthd.dll")
            Dll = Nothing
            ObjAsy = Nothing
            '21
            Dll = Reflection.Assembly.LoadFrom(CurDir() & "\CSPImgPrnt.dll")
            ObjAsy = Dll.CreateInstance("CSPImgPrnt.dll")
            Dll = Nothing
            ObjAsy = Nothing
            '22
            Dll = Reflection.Assembly.LoadFrom(CurDir() & "\CSPStrtCont.dll")
            ObjAsy = Dll.CreateInstance("CSPStrtCont.dll")
            Dll = Nothing
            ObjAsy = Nothing
            '23
            Dll = Reflection.Assembly.LoadFrom(CurDir() & "\SysInfo.dll")
            ObjAsy = Dll.CreateInstance("SysInfo.dll")
            Dll = Nothing
            ObjAsy = Nothing

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in LoadLibraryCSP", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MsgBox("Exit application due to incomplete resources", MsgBoxStyle.Critical, MDIForm.Text)
            Application.Exit()
        End Try

    End Sub

    Sub RestartApp(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Stop
        Try

            MDIForm.Focus()
            GC.Collect()

            Try
                DisplayActivity.lblDisplayActivity.Visible = True
                DisplayActivity.lblDisplayActivity.Text = "Please wait..." & Chr(13) & "The container stuffing application is restarting"
                DisplayActivity.Show()
                'Me.Dispose(True)
                Application.Exit()

                Application.Restart()
            Catch Ex As Exception
                Exit Try
            Finally
                'Me.Dispose(True)
                'Me.Close()
                'Application.Exit()
                GC.Collect()
                'Process.Start(CurDir() & "\Container Stuff.exe")
            End Try
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in RestartApp", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

End Module
