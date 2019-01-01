'	Program Name: - CompactADb.vb
'	Programmer Name:- Satwadhir B. Pawar Mob No. :- 9323974665
'	Description:-  The Access i.e. .mdb database compact activity is done throught this library
'	Company Name:-Hazel Infotech LTD.
'	Project Name: - Container Stuffing Plus
'	Date:- 22 August 2K8 3.50 PM (Modified Time)
'
'$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

Imports System
Imports System.Reflection
Imports System.ComponentModel
Imports JRO
Imports eCSP.HIL

Namespace CompactADb

	Public Class DbACompact
		Public OrigDb As String
		Public CpyDb As String

	Public Sub OLEDBCompactDb()

	        Try

	            Dim fileExists As Boolean = False

	            fileExists = My.Computer.FileSystem.FileExists(CpyDb)

	            Dim cd As JRO.JetEngine

	            cd = New JRO.JetEngine()

	            If fileExists Then

	                Kill(CpyDb)

	            End If

	
        	    cd.CompactDatabase("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & OrigDb , _
       		 "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & CpyDb & ";Jet OLEDB:Engine Type=5")

	            fileExists = My.Computer.FileSystem.FileExists(OrigDb)

	            Dim Dc As JRO.JetEngine

	            Dc = New JRO.JetEngine()

	            If fileExists Then

	                Kill(OrigDb)

	            End If

	            Dc.CompactDatabase("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & CpyDb , _
       		"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & OrigDb & ";Jet OLEDB:Engine Type=5")

	            cd = Nothing
        	    Dc = Nothing
        	    GC.Collect()
        Catch ex As Exception
            	MsgBox(ex.Message)
        End Try

    End Sub


     End Class

End Namespace
