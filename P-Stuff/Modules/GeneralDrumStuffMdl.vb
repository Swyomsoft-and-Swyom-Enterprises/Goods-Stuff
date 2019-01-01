
'Program Name: -    GeneralDrumStuffMdl.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    Sky Stuff Plus (Container Stuffing)
'Date: -            24 Dec 2K8 11.17 AM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - GeneralDrumStuffMdl is the drum (cylinder) stuffing module which includes
'               the database connection and various routine and function which can
'               generate the final VRML geometry program.

#Region " Importing Object "

Imports SDOleDb = System.Data.OleDb

#End Region

Module GeneralDrumStuffMdl

#Region " Moudule Declaration "

    Public connDrums As SDOleDb.OleDbConnection = New SDOleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;data source=" & CurDir() & "\Drums.mdb;Persist Security Info =false")

    Friend dsItemNo As Integer
    Friend dsItemQty As Integer
    Friend LstAhistArr As New List(Of StructR1)     'Public LstAhistArr As New List(Of StructR1)
    Friend dsQtyArr As New List(Of StructE1)

    Friend ContnrColor As String = Nothing          'Drum Container Color

#End Region

End Module
