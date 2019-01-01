
'Program Name: -    CylinderC.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    P-Stuff Plus (Container Stuffing)
'Date: -            22 Dec 2K8 6.10 PM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - CylinderC is containing the class cylinder its members are radius, 
'               height and instance cntr of point class its containing the routine and 
'               functions to generate the cylinder stuff activity. 

Public Class cylinder

#Region " Class Declaration "

    Public radius As Single
    Public height As Single
    Public cntr As New Point

#End Region

#Region " Routine Definitions "

    Public Sub AutoDraw(ByVal fn As String, ByVal col As String, ByVal tex As String, ByVal transpx As Single)

        Try

            Dim dq As Char = Chr(34)
            off.WriteLine("Transform {")
            trans(fn, New String() {CStr(cntr.x), CStr(cntr.y), CStr((cntr.z + height))})
            off.WriteLine("children [")
            'off.WriteLine("Transform {")
            'off.WriteLine("rotation 1 0 0 -1.57")
            'off.WriteLine("children [")
            off.WriteLine("Cylinder {")
            off.WriteLine("radius " & CStr(radius))
            off.WriteLine("Height " & CStr(height))
            off.WriteLine("}")
            off.WriteLine("appearance Appearance {")
            If tex <> "" Then
                off.WriteLine("texture ImageTexture {")
                off.WriteLine("url " & dq & tex & dq)
                off.WriteLine("}")
            End If

            off.WriteLine("material Material {")

            FileClose(1)
            transp(fn, transpx, col)


            off.WriteLine("}]}")

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in AutoDraw", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

End Class
