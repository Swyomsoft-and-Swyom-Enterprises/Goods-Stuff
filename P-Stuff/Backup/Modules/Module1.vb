
'Program Name: -    Module1.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    Sky Stuff Plus (Container Stuffing)
'Date: -            23 Dec 2K8 2.50 PM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - Module1 is the module in this project which is containing the database connection
'               and various routines and functions in the box geometry in the project.

#Region " Importing Object "

Imports SDO = System.Data.OleDb
Imports JRO

#End Region

Module Module1

#Region " Module Declarations "

    'Public conn As SDO.OleDbConnection = New SDO.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False")
    'Public connBlank As SDO.OleDbConnection = New SDO.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\Blankcontainer.mdb;Persist Security Info=False")
    'Public connWin As SDO.OleDbConnection = New SDO.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\WinSecure.mdb;Jet OLEDB:Database Password=laptop;Persist Security Info=True")
    'Public connT As SDO.OleDbConnection = New SDO.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\DbCSPTools.mdb;Persist Security Info=False")

    Friend conn As SDO.OleDbConnection = New SDO.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False")
    Friend connBlank As SDO.OleDbConnection = New SDO.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\Blankcontainer.mdb;Persist Security Info=False")
    Friend connWin As SDO.OleDbConnection = New SDO.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\WinSecure.mdb;Jet OLEDB:Database Password=laptop;Persist Security Info=True")
    Friend connT As SDO.OleDbConnection = New SDO.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\DbCSPTools.mdb;Persist Security Info=False")

    Friend oconn As SDO.OleDbConnection = New SDO.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False")

    'Public Cons As SDO.OleDbConnection = New SDO.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False")

    Friend Cons As SDO.OleDbConnection = New SDO.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False")

    Public StartedOnce As Boolean

    Public FCustomerMaster As CustomerMaster
    Public FContainerMaster As ContainerMaster

    Public FMasterCartonEntry As MasterCartonEntry

    Public FFreightMaster As FreightMaster
    Public FInwardEntry As InwardEntry
    Public ContainerReport As ContainerReport
    Public totallengthic As Single
    Public totalwidthic As Single
    Public totalheightic As Single
    Public totalsizeic As Single
    Public totalsizemc As Single
    Public totallengthii As Single
    Public totalwidthii As Single
    Public totalheightii As Single
    Public totalsizeii As Single
    Public totalsizemi As Single
    Friend rwidx As Integer
    Friend MxQTpUp As Boolean

    Public Frmopen As String
    Public FindStr As String
    Public title As String
    Public DT As String
    Public SrNWrlFn As Integer

#End Region

#Region " Function Definitions "

    Public Sub ConnectionStringSet(ByVal conStr As String)

        Try
            'Dim cmd1 As New OleDb.OleDbCommand
            'Dim rdr1 As OleDb.OleDbDataReader
            'Dim cmd2 As New OleDb.OleDbCommand
            'Dim rdr2 As OleDb.OleDbDataReader

            'If conn.State = ConnectionState.Closed Then conn.Open()
            'If Cons.State = ConnectionState.Closed Then Cons.Open()

            'cmd1.Connection = conn
            'cmd2.Connection = Cons

            'If Not conStr = Nothing Or Not conStr = "" Then
            '    Dim str1 As String = Nothing
            '    Dim str2 As String = Nothing

            '    Try
            '        cmd1.CommandText = "select Dbtlink from mainUtility"
            '        rdr1 = cmd1.ExecuteReader()
            '        Do While rdr1.Read()
            '            str1 = rdr1("Dbtlink")
            '        Loop
            '    Catch ex As Exception
            '    End Try
            '    Try
            '        cmd2.CommandText = "select Dbtlink from mainUtility"
            '        rdr2 = cmd2.ExecuteReader()
            '        Do While rdr2.Read()
            '            str2 = rdr2("Dbtlink")
            '        Loop
            '    Catch ex As Exception
            '    End Try

            '    conn = New SDO.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & str1 & ";Persist Security Info=False")
            '    Cons = New SDO.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & str2 & ";Persist Security Info=False")

            'Else
            If setLinkFlg Then
                conn = New SDO.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & conStr & ";Persist Security Info=False")
                Cons = New SDO.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & conStr & ";Persist Security Info=False")
            Else
                conn = New SDO.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False")
                Cons = New SDO.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False")
            End If


            'End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Setting connetion string", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function GenId(ByVal StrQry As String) As Integer 'maxId +1

        Try
            Dim Cmd As New SDO.OleDbCommand

            With Cmd
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If
                Cmd.Connection = conn
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = StrQry
                GenId = Val(Cmd.ExecuteScalar().ToString)
                GenId = GenId + 1
            End With

        Catch Er As Exception
            MsgBox(Er.Message)
            MessageBox.Show("Error in GenId", "Error......", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
            off.Close()
        End Try

    End Function

    Public Function FCount(ByVal StrQry As String) As Integer

        Dim Cmd As New SDO.OleDbCommand

        Try
            With Cmd
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If
                Cmd.Connection = conn
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = StrQry
                FCount = Val(Cmd.ExecuteScalar().ToString)
            End With
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in FCount", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
            off.Close()
        End Try

    End Function

    Function rec_search(ByVal Findstr As String, ByVal DT As String)

        Dim ds1 As New DataSet
        Dim dv As New DataView
        Dim da As New SDO.OleDbDataAdapter(Findstr, conn)

        ds1.Clear()

        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey
            End If
            da.Fill(ds1, DT)
            dv.Table = ds1.Tables(DT)

            Return ds1
        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("Error in rec_search", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try

        Return (0)

    End Function
    Function nz(ByVal e As Object, ByVal r As Object) As Object
        nz = e
        If IsDBNull(e) Then nz = r
        If e Is Nothing Then nz = r
        '  If e = "" Then nz = r
        Return nz
    End Function
    Sub compactdb()
        'conn.Close()
        'Cons.Close()
        'Dim jr As New JetEngine

        'Dim src As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"
        'Dim dst As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\containercompact.mdb;Persist Security Info=False;Jet OLEDB:Engine Type=5"
        'conn = Nothing
        'Cons = Nothing
        'connBlank = Nothing
        'connDrums = Nothing
        'connT = Nothing
        'connWin = Nothing
        '' jr.CompactDatabase(src, dst)

    End Sub

    Public Sub OLEDBCompactDb()

        Try

            conn.Close()
            Cons.Close()
            connBlank.Close()
            connWin.Close()
            connT.Close()

            Dim fileExists As Boolean = False

            fileExists = My.Computer.FileSystem.FileExists(CurDir() & "\containerCompact.mdb")

            Dim cd As JRO.JetEngine

            cd = New JRO.JetEngine()

            If fileExists Then

                Kill(CurDir() & "\containerCompact.mdb")

            End If

            cd.CompactDatabase("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb", _
        "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & CurDir() & "\containerCompact.mdb;Jet OLEDB:Engine Type=5")

            fileExists = My.Computer.FileSystem.FileExists(CurDir() & "\container.mdb")

            Dim Dc As JRO.JetEngine

            Dc = New JRO.JetEngine()

            If fileExists Then

                Kill(CurDir() & "\container.mdb")

            End If

            Dc.CompactDatabase("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\containerCompact.mdb", _
       "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & CurDir() & "\container.mdb;Jet OLEDB:Engine Type=5")

            cd = Nothing
            Dc = Nothing
            GC.Collect()
        Catch ex As Exception
            Exit Sub
            'MsgBox(ex.Message)
            'MsgBox(ex.ToString)
            'MessageBox.Show("Error in Database Compact", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

End Module
