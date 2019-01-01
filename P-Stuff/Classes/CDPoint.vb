
'Program Name: -    CDPoint.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    P-Stuff Plus (Container Stuffing)
'Date: -            23 Dec 2K8 6.00 PM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - CDPoint is the class of drum starting point which containing the x y z 
'               members type Double and the operator overloading shared methods of 
'               comparing the points of drum (cylinder) geometry.

Public Class CDPoint

#Region " Class Declaration "

    'Class Drum Points x, y, z as the starting points of drums

    Public x As Double
    Public y As Double
    Public z As Double

#End Region

#Region "Operator over function"

    Public Shared Operator =(ByVal P1 As CDPoint, ByVal P2 As CDPoint) As Boolean

        If P1.x = P2.x AndAlso P1.y = P2.y AndAlso P1.z = P2.z Then
            Return True
        End If

    End Operator

    Public Shared Operator <>(ByVal P1 As CDPoint, ByVal P2 As CDPoint) As Boolean

        If P1.x <> P2.x OrElse P1.y <> P2.y OrElse P1.z <> P2.z Then
            Return True
        End If

    End Operator

    Public Shared Operator >=(ByVal S1 As CDPoint, ByVal S2 As CDPoint) As Boolean

        If S1.x > S2.x OrElse S1.y > S2.y OrElse S1.z > S2.z Then
            Return True
        End If

    End Operator

    Public Shared Operator <=(ByVal S1 As CDPoint, ByVal S2 As CDPoint) As Boolean

        If S1.x < S2.x OrElse S1.y < S2.y OrElse S1.z < S2.z Then
            Return True
        End If

    End Operator

#End Region

End Class
