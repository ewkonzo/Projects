<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewReportViewer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.crvReports = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'crvReports
        '
        Me.crvReports.AutoSize = True
        Me.crvReports.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvReports.Location = New System.Drawing.Point(0, 0)
        Me.crvReports.Name = "crvReports"
        Me.crvReports.Size = New System.Drawing.Size(580, 413)
        Me.crvReports.TabIndex = 0
        '
        'frmNewReportViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(580, 413)
        Me.Controls.Add(Me.crvReports)
        Me.Name = "frmNewReportViewer"
        Me.Text = "frmNewReportViewer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents crvReports As Microsoft.Reporting.WinForms.ReportViewer
End Class
