
'Program Name: -    Form9.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    Sky Stuff Plus (Container Stuffing)
'Date: -            24 Dec 2K8 11.52 AM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - Form9 is the practice form to generate cylinder geometry VRML program.
'               This is various routine and function which is to produce the VRML program.
'               This contains module temp includes function of maximum quantity finding.

Public NotInheritable Class Form9
    Inherits System.Windows.Forms.Form

#Region " Routine Definition "

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim crad As Single = TextBox1.Text
        Dim cht As Single = TextBox2.Text
        Dim contln As Single = TextBox3.Text
        Dim contwd As Single = TextBox4.Text
        Dim contht As Single = TextBox5.Text
        Dim cdia As Single = crad * 2
        Dim cyl As New cylinder


        If contwd Mod cdia = 0 Then
            Dim mt As String = ""  'Initialize mt ==>>Satw
            Dim cylmax As Integer = findcylmax(cdia, contwd, contln, mt)
        End If

    End Sub

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class

Module tmp

#Region " Function Definition "

    'The logic developed inside the find maximum quantity 

    Public Function findcylmax(ByVal d As Single, ByVal wd As Single, ByVal ln As Single, ByRef mthd As String) As Integer

        Dim wdqty As Integer
        Dim lnqty As Integer
        If wd Mod d = 0 Then
            wdqty = wd \ d
            lnqty = ln \ d
            Dim qty1 As Integer = wdqty * lnqty
            Dim dst As Single = 0.866 * d
            Dim celqty = (wdqty * 2) - 1
            Dim celdst As Single = d + (d * 0.866)
            Dim qty2 As Integer = (ln \ celdst) * celqty
            If ln - ((ln \ celdst) * celdst) >= (d * 0.866) Then
                qty2 = qty2 + wdqty
            End If
        End If

    End Function

#End Region

End Module