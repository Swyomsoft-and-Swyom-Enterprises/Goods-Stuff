
'Program Name: -    frmUpdtData.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    Sky Stuff Plus (Container Stuffing)
'Date: -            24 Dec 2K8 12.49 PM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - frmUpdtData is the updating the sky stuff plus (container stuff) of container
'               database update. The database is updated and the coping the database as it is.   

#Region " Importing Object "

Imports sdo = System.Data.OleDb
Imports System.Data.OleDb
Imports fT = System.IO.FileStream

#End Region

Public NotInheritable Class frmUpdtData
    Inherits System.Windows.Forms.Form

#Region " Routine Definition "

    Public Sub UpdtCopyDbt(ByVal Ifile As String, ByVal Ofile As String)

        Try

            Dim Ifl As fT = New fT(Ifile, IO.FileMode.Open)
            Dim Ofl As fT = New fT(Ofile, IO.FileMode.Create)

            Dim Buf(Ifl.Length) As Byte

            Dim p As Integer = Ifl.Read(Buf, 0, Buf.Length)

            Dim i As Integer

            Buf(i) = Buf(i)

            Ofl.Write(Buf, 0, p)

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in CopyDbt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        'Stop
        Try
            If txtPassword.Text = "updatenow" Then
                Call UpdateData()
            ElseIf txtPassword.Text = "" Then
                MessageBox.Show("Empty incorrect password", "Update Database Info.....", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPassword.Focus()
            Else
                MessageBox.Show("Incorrect password", "Update Database Info.....", MessageBoxButtons.OK, MessageBoxIcon.Warning)        'MsgBox("Incorrect Password")
                txtPassword.Text = ""
                txtPassword.Focus()
            End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in btnUpdate_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub UpdateData()
        'Stop
        ''Dim PbCnt As Int16 = 0
        ''Try
        ''    PrgBrs.Visible = True
        ''    PrgBrs.Value = 0

        ''    conn.Close()

        ''    PbCnt = Progbar(PbCnt, 10)

        ''    UpdtCopyDbt(CurDir() & "\container.mdb", CurDir() & "\UpdateDb_container.mdb")      'Copy container access file to another file

        ''    Dim sFso As New Scripting.FileSystemObject
        ''    'Dim cmdData As sdo.OleDbCommand

        ''    'Dim cmdTable As New OleDb.OleDbCommand
        ''    'Dim rdrTable As OleDb.OleDbDataReader
        ''    'Dim Sql As String

        ''    If sFso.FileExists(CurDir() & "\container.ldb") = True Then
        ''        Try
        ''            sFso.DeleteFile(CurDir() & "\container.ldb")
        ''        Catch ex As Exception
        ''            PrgBrs.Visible = False
        ''            PrgBrs.Value = 0
        ''            MessageBox.Show("Cannot update... First close application and then Retry")
        ''            Exit Sub
        ''        End Try
        ''    End If

        ''    PbCnt = Progbar(PbCnt, 30)

        ''    Try
        ''        sFso.CopyFile(CurDir() & "\BlankContainer.mdb", CurDir() & "\TempContainer.mdb")
        ''    Catch ex As Exception
        ''        MessageBox.Show("Cannot update... First close application and then Retry")
        ''        Exit Sub
        ''    End Try

        ''    PbCnt = Progbar(PbCnt, 55)

        ''    'If connBlank.State = ConnectionState.Closed Then connBlank.Open()
        ''    'cmdTable.Connection = connBlank
        ''    'cmdTable.CommandText = "Select * from AllTableList order by TableType,Preference"
        ''    'rdrTable = cmdTable.ExecuteReader

        ''    PbCnt = Progbar(PbCnt, 75)

        ''    If conn.State = ConnectionState.Closed Then conn.Open()

        ''    'If rdrTable.HasRows = True Then
        ''    '    cmdTable.Connection = conn

        ''    '    Do While rdrTable.Read
        ''    '        Try
        ''    '            Sql = "INSERT INTO " & rdrTable("TableName") & " IN '" & CurDir() & "\Tempcontainer.mdb'" & " SELECT * from " & rdrTable("TableName")
        ''    '            cmdData = New sdo.OleDbCommand(Sql, conn)
        ''    '            cmdData.ExecuteNonQuery()

        ''    '        Catch ex As OleDbException
        ''    '            If ex.ErrorCode = -2147217865 Then
        ''    '                ''do nothing
        ''    '            ElseIf ex.ErrorCode = -2147217900 Then
        ''    '                Alter_Table(rdrTable("TableName"))

        ''    '                Sql = "INSERT INTO " & rdrTable("TableName") & " IN '" & CurDir() & "\Tempcontainer.mdb'" & " SELECT * from " & rdrTable("TableName")
        ''    '                cmdData = New sdo.OleDbCommand(Sql, conn)
        ''    '                cmdData.ExecuteNonQuery()

        ''    '                End If
        ''    'End Try
        ''    '        Loop
        ''    'End If

        ''    PbCnt = Progbar(PbCnt, 90)

        ''    If connBlank.State = ConnectionState.Open Then connBlank.Close()
        ''    If conn.State = ConnectionState.Open Then conn.Close()

        ''    sFso.DeleteFile(CurDir() & "\container.mdb")
        ''    sFso.CopyFile(CurDir() & "\Tempcontainer.mdb", (CurDir() & "\container.mdb"), True)
        ''    'sFso.DeleteFile(CurDir() & "\Tempcontainer.mdb")

        ''    PbCnt = Progbar(PbCnt, 100)

        ''    UpdtCopyDbt(CurDir() & "\UpdateDb_container.mdb", CurDir() & "\container.mdb")      'Copy container access file to another file

        ''    MessageBox.Show("Update Completed...", "Update Database Info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ''    PrgBrs.Value = 0
        ''    PrgBrs.Visible = False

        ''    UpdtUnload()

        ''    Me.Dispose(True)
        ''    Me.Close()

        ''Catch Err As Exception
        ''    PrgBrs.Visible = False
        ''    PrgBrs.Value = 0
        ''    MsgBox(Err.Message)
        ''    MsgBox(Err.ToString)
        ''    MessageBox.Show("Error in UpdateData", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ''Finally
        ''    PrgBrs.Value = 0
        ''    PrgBrs.Visible = False
        ''End Try

    End Sub

    'Public Sub CompactDatabase()

    '    Exit Sub

    '    Dim PbCnt As Int16 = 0

    '    Try
    '        Cons.Close()
    '        conn.Close()

    '        If conn.State = ConnectionState.Open Then conn.Close()
    '        If Cons.State = ConnectionState.Open Then Cons.Close()

    '        Dim sFso As New Scripting.FileSystemObject

    '        If sFso.FileExists(CurDir() & "\container.ldb") = True Then

    '            Try
    '                conn.Dispose()
    '                Cons.Dispose()
    '                conn.Close()
    '                Cons.Close()

    '                Kill(CurDir() & "\container.ldb")
    '                'sFso.DeleteFile(CurDir() & "\container.ldb")
    '            Catch ex As Exception
    '                MessageBox.Show("Cannot compactdatabase...", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                Exit Sub
    '            End Try
    '        End If

    '        UpdtCopyDbt(CurDir() & "\container.mdb", CurDir() & "\UpdateDb_container.mdb")      'Copy container access file to another file


    '        'sFso.DeleteFile(CurDir() & "\container.mdb")

    '        UpdtCopyDbt(CurDir() & "\UpdateDb_container.mdb", CurDir() & "\container.mdb")      'Copy container access file to another file

    '        Me.Dispose(True)
    '        Me.Close()

    '    Catch Err As Exception
    '        MsgBox(Err.Message)
    '        MsgBox(Err.ToString)
    '        MessageBox.Show("Cannot compactdatabase...", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    'End Sub

    Private Function Progbar(ByVal pBrs As Int16, ByVal prgInvl As Int16)

        Dim pbCnt As Int16 = pBrs

        Try
            PrgBrs.Visible = True

            Do While pbCnt < prgInvl
                PrgBrs.Value = pbCnt
                pbCnt += 1
                Me.Refresh()
                System.Threading.Thread.Sleep(10)
            Loop

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in Progbar", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return pbCnt

        'PrgBrs.Visible = True

        'Do While PbCnt < 100
        '    PrgBrs.Value = PbCnt
        '    PbCnt += 1
        '    Me.Refresh()
        '    System.Threading.Thread.Sleep(10)
        'Loop

    End Function

    Private Sub Alter_Table(ByVal TableName As String)

        Dim SqlDeleteFields As String
        Dim cmdData As New sdo.OleDbCommand
        Dim rdrData As OleDb.OleDbDataReader

        Dim cmdBlank As New OleDb.OleDbCommand
        Dim rdrBlank As OleDb.OleDbDataReader

        Dim cmdDrop As New sdo.OleDbCommand
        Dim rdrDrop As OleDb.OleDbDataAdapter

        Dim Sql As String
        Dim i As Integer
        Dim j As Integer

        Dim FieldName As String
        Dim FoundColumn As Boolean

        Try
            cmdBlank.Connection = connBlank
            cmdBlank.CommandText = "Select * from " & TableName & " where 1=2"
            rdrBlank = cmdBlank.ExecuteReader

            cmdData.Connection = conn
            cmdData.CommandText = "Select * from " & TableName & " where 1=2"
            rdrData = cmdData.ExecuteReader
            SqlDeleteFields = ""
            For i = 0 To rdrData.FieldCount - 1
                FieldName = rdrData.GetName(i)
                FoundColumn = False
                For j = 0 To rdrBlank.FieldCount - 1
                    If rdrBlank.GetName(j) = FieldName Then
                        FoundColumn = True
                        Exit For
                    End If
                Next j

                If (FoundColumn = False) Then
                    'alter table to remove specific column ....
                    SqlDeleteFields = SqlDeleteFields & "[" & FieldName & "],"
                End If
            Next i

            If Trim(SqlDeleteFields) <> "" Then
                rdrData.Close()

                SqlDeleteFields = Mid(SqlDeleteFields, 1, Len(SqlDeleteFields) - 1)
                Sql = "Alter table " & TableName & " DROP COLUMN " & SqlDeleteFields
                cmdDrop.Connection = conn
                cmdDrop.CommandText = Sql
                rdrDrop = cmdDrop.ExecuteScalar
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in Alter_Table", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Try
            UpdtUnload()

            Me.Dispose("True")
            Me.Close()

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in btnCancel_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub UpdtUnload()

        Try
            txtPassword.Text = ""
            txtPassword.Focus()

            Dim Yaxd As Int16 = 410
            Dim Xaxd As Int16 = 2

            Do While Xaxd > -290
                Me.Location = New System.Drawing.Point(Xaxd, Yaxd)
                Xaxd -= 5
                GbUpdbs.Refresh()
                Me.Show()
            Loop

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in UpdtUnload", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub frmUpdtData_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            txtPassword.Text = ""
            txtPassword.Focus()

            Dim Yaxd As Int16 = 355     '410
            Dim Xaxd As Int16 = -290

            Do While Xaxd < 2
                Me.Location = New System.Drawing.Point(Xaxd, Yaxd)
                Xaxd += 1
                GbUpdbs.Refresh()
                Me.Show()
            Loop

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in frmUpdtData_Load", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

    'txtPassword.Text = ""
    'txtPassword.Focus()

    'Dim Yaxd As Int16 = 410
    'Dim Xaxd As Int16 = 2

    'Do While Xaxd > -290
    '    Me.Location = New System.Drawing.Point(Xaxd, Yaxd)
    '    Xaxd -= 1
    '    GbUpdbs.Refresh()
    '    Me.Show()
    'Loop

    'Private Sub UpdateData()

    '    Stop

    '    Dim Ms As New Scripting.FileSystemObject
    '    Dim Fs As Scripting.FileSystemObject

    '    Dim CmdData As New sdo.OleDbCommand                 'Dim cmdData As sdo.OleDbCommand

    '    Dim cmdTable As New OleDb.OleDbCommand
    '    Dim rdrTable As New OleDb.OleDbDataReader               'Dim rdrTable As OleDb.OleDbDataReader
    '    Dim Sql As String

    '    Try
    '        If Ms.FileExists(CurDir() & "\container.ldb") = True Then

    '            Try
    '                Dim Vf = My.Computer.FileSystem.FileExists(CurDir() & "\container.ldb")

    '                Kill(CurDir() & "\container.ldb")

    '            Catch Err As Exception
    '                MsgBox(Err.Message)
    '                MessageBox.Show("Cannot update... First close application and then Retry")
    '                Exit Sub

    '            End Try

    '        End If

    '        Try

    '            Ms.CopyFile(CurDir() & "\BlankContainer.mdb", CurDir() & "\TempContainer.mdb")

    '        Catch Err As Exception
    '            MsgBox(Err.Message)
    '            MessageBox.Show("Cannot update... First close application and then Retry")
    '            Exit Sub
    '        End Try

    '        If connBlank.State = ConnectionState.Closed Then connBlank.Open()
    '        cmdTable.Connection = connBlank

    '        cmdTable.CommandText = "Select * from AllTableList order by TableType,Preference"

    '        Dim rdrBlank As OleDb.OleDbDataReader

    '        rdrTable = cmdTable.ExecuteReader

    '        If conn.State = ConnectionState.Closed Then conn.Open()

    '        If rdrTable.HasRows = True Then
    '            cmdTable.Connection = conn

    '            Do While rdrTable.Read

    '                Try
    '                    Sql = "INSERT INTO " & rdrTable("TableName") & " IN '" & CurDir() & "\Tempcontainer.mdb'" & " SELECT * from " & rdrTable("TableName")
    '                    CmdData = New sdo.OleDbCommand(Sql, conn)
    '                    CmdData.ExecuteNonQuery()

    '                Catch ex As OleDbException
    '                    If ex.ErrorCode = -2147217865 Then
    '                        ''do nothing
    '                    ElseIf ex.ErrorCode = -2147217900 Then
    '                        Alter_Table(rdrTable("TableName"))

    '                        Sql = "INSERT INTO " & rdrTable("TableName") & " IN '" & CurDir() & "\Tempcontainer.mdb'" & " SELECT * from " & rdrTable("TableName")
    '                        CmdData = New sdo.OleDbCommand(Sql, conn)
    '                        CmdData.ExecuteNonQuery()

    '                    End If
    '                End Try

    '            Loop
    '        End If

    '        If connBlank.State = ConnectionState.Open Then connBlank.Close()
    '        If conn.State = ConnectionState.Open Then conn.Close()

    '        Fs.DeleteFile(CurDir() & "\container.mdb")
    '        Fs.CopyFile(CurDir() & "\Tempcontainer.mdb", (CurDir() & "\container.mdb"), True)
    '        Fs.DeleteFile(CurDir() & "\Tempcontainer.mdb")

    '        MessageBox.Show("Update Completed...")

    '        Me.Close()
    '    Catch Ex As Exception
    '        MsgBox(Ex.Message)
    '        MessageBox.Show("Error in UpdateData", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    'End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class
