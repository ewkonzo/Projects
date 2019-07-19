Imports Janus.Windows.GridEX
Imports System.IO
Public Class Classfunctions
    Public Gridex As GridEX

    Public Sub export()
        Dim myStream As Stream = Nothing

        Dim savefile As New SaveFileDialog
        savefile.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        savefile.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*"
        savefile.FilterIndex = 1
        savefile.RestoreDirectory = True
        If savefile.ShowDialog = DialogResult.OK Then
            Dim exporter As New Janus.Windows.GridEX.Export.GridEXExporter()
            exporter.GridEX = Gridex
            exporter.IncludeChildTables = True
            exporter.SheetName = Gridex.Name.Remove(Gridex.Name.Length - 6)
            Dim stream As New System.IO.FileStream(savefile.FileName, System.IO.FileMode.Create)
            exporter.Export(stream)
            stream.Close()
        End If

    End Sub
    Public Sub exporting(ByVal sender As System.Object, ByVal e As System.EventArgs)
        export()
    End Sub
End Class
