
'Program Name: -    CDArngmtCA.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    P-Stuff Plus (Container Stuffing)
'Date: -            24 Dec 2K8 10.07 AM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - CDArngmtCA is the class including the CDArea objects and three int type datatype
'               members and this class inherited through CDrum.
'               This class utilize in drum (cylinder) geometry cross arrangement stuffing.

Public NotInheritable Class CDArngmtCA
    Inherits CDrum                          'Its like a database stored 

#Region " Class Declaration "

    Friend DCRA As New CDArea   'Drum container reamining area
    Friend REO As Int16         'Row echo org
    Friend CEO As Int16         'Column echo org
    Friend DGM As Int16         'Drum geom midl

#End Region

End Class
