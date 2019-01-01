Imports System
Imports System.Windows.Forms

<Assembly: CLSCompliant(True)> 

Namespace OptMthd

    Public Class FndOptMthd

        Public Class sPoint
            Public x As Double
            Public y As Double
            Public z As Double
        End Class

        Public Class Areas

            Public length As Double
            Public width As Double
            Public height As Double
            Public StrtPt As New sPoint

        End Class

        Dim Occ As Integer
        Dim OccLst As New List(Of Integer)

        Public Function FindOptMethod(ByVal ar1 As Areas, ByVal ar2 As Areas, ByRef maxqty1 As Integer, ByVal tpup As Boolean) As Integer

            Dim ln1 As Double = ar1.length
            Dim wd1 As Double = ar1.width
            Dim ht1 As Double = ar1.height

            Dim ln2 As Double = ar2.length
            Dim wd2 As Double = ar2.width
            Dim ht2 As Double = ar2.height

            Dim qty1 As Integer = 0
            Dim qty2 As Integer = 0
            Dim qty3 As Integer = 0
            Dim qty4 As Integer = 0
            Dim qty5 As Integer = 0
            Dim qty6 As Integer = 0

            Dim qtypos As String

            Try

                If ln2 >= ln1 AndAlso wd2 >= wd1 AndAlso ht2 >= ht1 Then
                    qty1 = Fix(ln2 / ln1) * Fix(wd2 / wd1) * Fix(ht2 / ht1)
                Else
                    qty1 = 0
                End If
                If Not tpup Then

                    If ln2 >= ln1 AndAlso wd2 >= ht1 AndAlso ht2 >= wd1 Then
                        qty2 = Fix(ln2 / ln1) * Fix(wd2 / ht1) * Fix(ht2 / wd1)
                    Else
                        qty2 = 0
                    End If

                    If ln2 >= wd1 AndAlso wd2 >= ht1 AndAlso ht2 >= ln1 Then
                        qty3 = Fix(ln2 / wd1) * Fix(wd2 / ht1) * Fix(ht2 / ln1)
                    Else
                        qty3 = 0
                    End If

                End If

                If ln2 >= wd1 AndAlso wd2 >= ln1 AndAlso ht2 >= ht1 Then
                    qty4 = Fix(ln2 / wd1) * Fix(wd2 / ln1) * Fix(ht2 / ht1)
                Else
                    qty4 = 0
                End If

                If Not tpup Then

                    If ln2 >= ht1 AndAlso wd2 >= wd1 AndAlso ht2 >= ln1 Then
                        qty5 = Fix(ln2 / ht1) * Fix(wd2 / wd1) * Fix(ht2 / ln1)
                    Else
                        qty5 = 0
                    End If

                    If ln2 >= ht1 AndAlso wd2 >= ln1 AndAlso ht2 >= wd1 Then
                        qty6 = Fix(ln2 / ht1) * Fix(wd2 / ln1) * Fix(ht2 / wd1)
                    Else
                        qty6 = 0
                    End If

                End If

                maxqty1 = qty1
                qtypos = "1"

                If Not tpup Then
                    If qty2 > maxqty1 Then
                        maxqty1 = qty2
                        qtypos = "2"
                    End If

                    If qty3 > maxqty1 Then
                        maxqty1 = qty3
                        qtypos = "3"
                    End If
                End If

                If qty4 > maxqty1 Then
                    maxqty1 = qty4
                    qtypos = "4"
                End If

                If Not tpup Then
                    If qty5 > maxqty1 Then
                        maxqty1 = qty5
                        qtypos = "5"
                    End If

                    If qty6 > maxqty1 Then
                        maxqty1 = qty6
                        qtypos = "6"
                    End If
                End If

                Occ = 0
                OccLst.Clear()

                If maxqty1 = qty1 Then
                    Occ += 1
                    OccLst.Add(1)
                End If

                If maxqty1 = qty2 Then
                    Occ += 1
                    OccLst.Add(2)
                End If

                If maxqty1 = qty3 Then
                    Occ += 1
                    OccLst.Add(3)
                End If

                If maxqty1 = qty4 Then
                    Occ += 1
                    OccLst.Add(4)
                End If

                If maxqty1 = qty5 Then
                    Occ += 1
                    OccLst.Add(5)
                End If

                If maxqty1 = qty6 Then
                    Occ += 1
                    OccLst.Add(6)
                End If

                If maxqty1 = qty1 Then
                    qtypos = "1"
                End If

                If qtypos = "1" Then
                    Return 1
                End If

                If qtypos = "2" Then
                    Return 2
                End If

                If qtypos = "3" Then
                    Return 3
                End If

                If qtypos = "4" Then
                    Return 4
                End If

                If qtypos = "5" Then
                    Return 5
                End If

                If qtypos = "6" Then
                    Return 6
                End If

            Catch Err As Exception
                MsgBox(Err.Message)
                MsgBox(Err.ToString)
                MessageBox.Show("Error in FindOptMethod ", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            Return 1

        End Function

    End Class

End Namespace
