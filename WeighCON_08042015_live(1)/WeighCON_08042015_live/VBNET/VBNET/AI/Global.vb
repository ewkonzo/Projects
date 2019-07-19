Option Strict Off
Option Explicit On
Module Global
	Public gGainCode As Short
    Public gGainCodeList() As Short
	Public gNumOfInputRange As Short
	Public gInputRangeList(30) As String
	Public gNumofChannels As Short
	Public gChanIndex As Short
    Public AItester As New Form1
    Public frmGainlist As New Form2
    Sub Main()
        Application.Run(AItester)
    End Sub
End Module