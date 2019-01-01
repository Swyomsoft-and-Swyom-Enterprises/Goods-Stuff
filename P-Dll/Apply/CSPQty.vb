
Imports System

Namespace QtyManipulation{
		
		Public Class FindQty{
		Public ItmArr() As String
		Public StrtPos As Integer

	Public Function DrumFindQtyDHD(ByVal ItmArr() As String, ByVal StrtPos As Integer) As Integer

        Dim Nm As String = ItmArr(StrtPos)
        Dim L As Integer
        Try
            For L = StrtPos To UBound(ItmArr)
                If ItmArr(L) <> Nm Then
                    Exit For
                End If
            Next
            Return L - StrtPos
        Catch Er As Exception
            MsgBox(Er.Message)
            MessageBox.Show("Error in DrumFindQtyDHD", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function

	End Class

		}
	}
}