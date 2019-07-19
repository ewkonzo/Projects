Public Class Form2
    Inherits System.Windows.Forms.Form
    Dim IsInitializing As Boolean

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        IsInitializing = True
        InitializeComponent()
        IsInitializing = False

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Public WithEvents cmbInputRangeDiff As System.Windows.Forms.ComboBox
    Public WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents cmdOK As System.Windows.Forms.Button
    Public WithEvents _Label2_1 As System.Windows.Forms.Label
    Public WithEvents _Label2_0 As System.Windows.Forms.Label
    Friend WithEvents ListGainList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents columnheader2 As System.Windows.Forms.ColumnHeader
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Me.cmbInputRangeDiff = New System.Windows.Forms.ComboBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdOK = New System.Windows.Forms.Button
        Me._Label2_1 = New System.Windows.Forms.Label
        Me._Label2_0 = New System.Windows.Forms.Label
        Me.ListGainList = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.columnheader2 = New System.Windows.Forms.ColumnHeader
        Me.SuspendLayout()
        '
        'cmbInputRangeDiff
        '
        Me.cmbInputRangeDiff.BackColor = System.Drawing.SystemColors.Window
        Me.cmbInputRangeDiff.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbInputRangeDiff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbInputRangeDiff.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbInputRangeDiff.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbInputRangeDiff.Location = New System.Drawing.Point(192, 32)
        Me.cmbInputRangeDiff.Name = "cmbInputRangeDiff"
        Me.cmbInputRangeDiff.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbInputRangeDiff.Size = New System.Drawing.Size(101, 22)
        Me.cmbInputRangeDiff.TabIndex = 6
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Location = New System.Drawing.Point(118, 137)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.Size = New System.Drawing.Size(76, 25)
        Me.cmdOK.TabIndex = 5
        Me.cmdOK.Text = "&OK"
        '
        '_Label2_1
        '
        Me._Label2_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label2_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_1.Location = New System.Drawing.Point(16, 13)
        Me._Label2_1.Name = "_Label2_1"
        Me._Label2_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_1.Size = New System.Drawing.Size(80, 16)
        Me._Label2_1.TabIndex = 8
        Me._Label2_1.Text = "Gain List"
        '
        '_Label2_0
        '
        Me._Label2_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label2_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label2_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label2_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label2_0.Location = New System.Drawing.Point(192, 12)
        Me._Label2_0.Name = "_Label2_0"
        Me._Label2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label2_0.Size = New System.Drawing.Size(88, 16)
        Me._Label2_0.TabIndex = 7
        Me._Label2_0.Text = "Range Selection"
        '
        'ListGainList
        '
        Me.ListGainList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.columnheader2})
        Me.ListGainList.FullRowSelect = CType(configurationAppSettings.GetValue("ListGainList.FullRowSelect", GetType(System.Boolean)), Boolean)
        Me.ListGainList.GridLines = CType(configurationAppSettings.GetValue("ListGainList.GridLines", GetType(System.Boolean)), Boolean)
        Me.ListGainList.Location = New System.Drawing.Point(16, 32)
        Me.ListGainList.Name = "ListGainList"
        Me.ListGainList.Size = New System.Drawing.Size(160, 88)
        Me.ListGainList.TabIndex = 9
        Me.ListGainList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Chan"
        '
        'columnheader2
        '
        Me.columnheader2.Text = "Input Range"
        Me.columnheader2.Width = 96
        '
        'Form2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(304, 173)
        Me.Controls.Add(Me.ListGainList)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me._Label2_1)
        Me.Controls.Add(Me._Label2_0)
        Me.Controls.Add(Me.cmbInputRangeDiff)
        Me.MaximizeBox = False
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gain List"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cmbInputRangeDiff_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbInputRangeDiff.SelectedIndexChanged
        Dim i As Integer
        Dim GainItem As ListViewItem

        If IsInitializing Then
            Exit Sub
        End If

        i = 0
        If (ListGainList.SelectedIndices.Count > 0) Then
            While (i < ListGainList.SelectedIndices.Count)
                GainItem = ListGainList.SelectedItems(i)
                GainItem.SubItems(1).Text = cmbInputRangeDiff.Text
                gGainCodeList(ListGainList.SelectedIndices.Item(i)) = cmbInputRangeDiff.SelectedIndex
                i = i + 1
            End While
        End If

    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Dim i As Integer
        If IsInitializing Then
            Exit Sub
        End If
        AItester.DAQAI1.InputRangeList = gGainCodeList
        AItester.DAQAI1.CloseDevice()

        Me.Close()
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i, j, startch, bRet As Integer
        Dim SubItems As ListViewItem
        Dim strRange As New String("", 30)

        AItester.DAQAI1.OpenDevice()

        AItester.DAQAI1.GetFirstInputRange(strRange)
        cmbInputRangeDiff.Items.Add(strRange)

        While (AItester.DAQAI1.GetNextInputRange(strRange) = False)
            cmbInputRangeDiff.Items.Add(strRange)
        End While
        cmbInputRangeDiff.SelectedIndex = 0

        gNumofChannels = AItester.DAQAI1.NumberOfChannels
        startch = AItester.DAQAI1.StartChannel

        For i = startch To (startch + gNumofChannels - 1)
            SubItems = ListGainList.Items.Add(Str(i))
            SubItems.SubItems.Add(gInputRangeList(gGainCodeList(i)))
        Next i

    End Sub

End Class
