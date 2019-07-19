Public Class frmNewReportViewer

    Private Sub frmNewReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.crvReports.RefreshReport()
    End Sub
End Class