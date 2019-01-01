
'Program Name: -    Form6.vb 
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    P-Stuff Plus (Container Stuffing)
'Date: -            24 Dec 2K8 10.59 AM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - Form6 is the report generation form which shown the stuffing geometry 
'               reports data in this reports.

Imports CrystalDecisions.CrystalReports.Engine

Public NotInheritable Class Form6
    Inherits System.Windows.Forms.Form

    Public WithEvents oRpt As ReportDocument

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
   
End Class