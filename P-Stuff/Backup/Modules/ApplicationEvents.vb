Imports CompactADb

Namespace My

    ' The following events are availble for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        Private Sub MyApplication_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown
            'compactdb()
            Try

                Call OLEDBCompactDb()
                Call CompactOLEDB()

                Call MDIForm.ClosingAllOpenModuleForm()

            Catch Er As Exception
                MsgBox(Er.Message)
                MsgBox(Er.ToString)
                MessageBox.Show("Error in My Application Shutdown", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            
        End Sub

        Public Sub CompactOLEDB()

            'Try
            '    conn.Close()
            '    Cons.Close()
            '    connBlank.Close()
            '    connWin.Close()
            '    connT.Close()

            '    Dim CompDb As New DbACompact

            '    CompDb.OrigDb = CurDir() & "\container.mdb"
            '    CompDb.CpyDb = CurDir() & "\containerCompact.mdb"
            '    CompDb.OLEDBCompactDb()
            'Catch ex As Exception
            '    MsgBox(ex.Message)
            '    MsgBox(ex.ToString)
            '    MessageBox.Show("Error in Application Exit", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End Try

        End Sub

        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup

            Dim SplashScreen As New frmDisplayScreen

            SplashScreen.TDisplay.Enabled = True
            SplashScreen.TDisplay.Interval = 5000
            SplashScreen.ShowDialog()
            SplashScreen.Visible = False
            SplashScreen.Dispose()
            SplashScreen = Nothing

            GC.Collect()

        End Sub

    End Class

End Namespace

