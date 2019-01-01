Imports Microsoft.Win32

Module NetfileAssociate

    Public Sub Associate_File(ByRef Extension As String, ByRef Application As String, ByRef Identifier As String, ByRef Description As String, ByRef Icon As String) 'As Object

        Try

            Dim regkey As RegistryKey
            Dim regsubkey As RegistryKey

            regkey = Registry.ClassesRoot.OpenSubKey("." & Extension)

            If Not regkey Is Nothing Then
                regkey.Close()
                Registry.ClassesRoot.DeleteSubKey("." & Extension)
            End If

            regkey = Registry.ClassesRoot.OpenSubKey(Identifier)

            If Not regkey Is Nothing Then
                regkey.Close()
                Registry.ClassesRoot.DeleteSubKeyTree(Identifier)
            End If

            regkey = Registry.ClassesRoot.CreateSubKey("." & Extension, RegistryKeyPermissionCheck.Default)

            regkey.SetValue("", Identifier)
            regkey.Close()

            regkey = Registry.ClassesRoot.CreateSubKey(Identifier, RegistryKeyPermissionCheck.Default)
            regkey.SetValue("", Description)

            regsubkey = regkey.CreateSubKey("DefaultIcon")

            If Icon.Trim.Length > 0 Then regsubkey.SetValue("", (Chr(34) & Icon & Chr(34) & ",0 "))

            regsubkey = regkey.CreateSubKey("shell")

            regsubkey = regsubkey.CreateSubKey("open")

            regsubkey = regsubkey.CreateSubKey("command")
            regsubkey.SetValue("", (Chr(34) & Application & Chr(34) & " " & Chr(34) & "%1" & Chr(34)))

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in Associate file", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


End Module
