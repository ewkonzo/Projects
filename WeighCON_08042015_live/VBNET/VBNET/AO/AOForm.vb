Public Class frmAO
    Inherits System.Windows.Forms.Form

    Dim OutputRange As Single
    Dim DataArray() As Single
    Dim BinDataArray() As Short
    Dim IsInitializing As Boolean
    Dim bRet As Boolean
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
    Public WithEvents txtNumberOfOutputs As System.Windows.Forms.TextBox
    Public WithEvents chkCyclicMode As System.Windows.Forms.CheckBox
    Public WithEvents cmbOutputRange As System.Windows.Forms.ComboBox
    Public WithEvents cmbChannel As System.Windows.Forms.ComboBox
    Public WithEvents txtOutputRate As System.Windows.Forms.TextBox
    Public WithEvents cmbDataType As System.Windows.Forms.ComboBox
    Public WithEvents cmbTransferMode As System.Windows.Forms.ComboBox
    Public WithEvents Line1 As System.Windows.Forms.Label
    Public WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents Frame4 As System.Windows.Forms.GroupBox
    Public WithEvents Frame3 As System.Windows.Forms.GroupBox
    Public WithEvents txtErrorMessage As System.Windows.Forms.TextBox
    Public WithEvents txtErrorCode As System.Windows.Forms.TextBox
    Public WithEvents Label13 As System.Windows.Forms.Label
    Public WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents txtStatus As System.Windows.Forms.TextBox
    Public WithEvents cmdStatus As System.Windows.Forms.Button
    Public WithEvents cmdOutputStop As System.Windows.Forms.Button
    Public WithEvents cmdOutputStart As System.Windows.Forms.Button
    Public WithEvents lstWritting As System.Windows.Forms.ListBox
    Public WithEvents chkEventEnabled As System.Windows.Forms.CheckBox
    Public WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents cmdExit As System.Windows.Forms.Button
    Public WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents txtDeviceNum As System.Windows.Forms.TextBox
    Public WithEvents txtDeviceName As System.Windows.Forms.TextBox
    Public WithEvents cmdSelectDevice As System.Windows.Forms.Button
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents ErrorTimer As System.Windows.Forms.Timer
    Friend WithEvents DAQAO1 As AxDAQAOLib.AxDAQAO
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmbWaveForm As System.Windows.Forms.ComboBox
    Public WithEvents PropertyFrame As System.Windows.Forms.GroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAO))
        Me.PropertyFrame = New System.Windows.Forms.GroupBox
        Me.cmbWaveForm = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtNumberOfOutputs = New System.Windows.Forms.TextBox
        Me.chkCyclicMode = New System.Windows.Forms.CheckBox
        Me.cmbOutputRange = New System.Windows.Forms.ComboBox
        Me.cmbChannel = New System.Windows.Forms.ComboBox
        Me.txtOutputRate = New System.Windows.Forms.TextBox
        Me.cmbDataType = New System.Windows.Forms.ComboBox
        Me.cmbTransferMode = New System.Windows.Forms.ComboBox
        Me.Line1 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Frame4 = New System.Windows.Forms.GroupBox
        Me.Frame3 = New System.Windows.Forms.GroupBox
        Me.txtErrorMessage = New System.Windows.Forms.TextBox
        Me.txtErrorCode = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtStatus = New System.Windows.Forms.TextBox
        Me.cmdStatus = New System.Windows.Forms.Button
        Me.cmdOutputStop = New System.Windows.Forms.Button
        Me.cmdOutputStart = New System.Windows.Forms.Button
        Me.lstWritting = New System.Windows.Forms.ListBox
        Me.chkEventEnabled = New System.Windows.Forms.CheckBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmdExit = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtDeviceNum = New System.Windows.Forms.TextBox
        Me.txtDeviceName = New System.Windows.Forms.TextBox
        Me.cmdSelectDevice = New System.Windows.Forms.Button
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ErrorTimer = New System.Windows.Forms.Timer(Me.components)
        Me.DAQAO1 = New AxDAQAOLib.AxDAQAO
        Me.PropertyFrame.SuspendLayout()
        Me.Frame4.SuspendLayout()
        Me.Frame3.SuspendLayout()
        Me.Frame1.SuspendLayout()
        CType(Me.DAQAO1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PropertyFrame
        '
        Me.PropertyFrame.BackColor = System.Drawing.SystemColors.Control
        Me.PropertyFrame.Controls.Add(Me.cmbWaveForm)
        Me.PropertyFrame.Controls.Add(Me.Label14)
        Me.PropertyFrame.Controls.Add(Me.txtNumberOfOutputs)
        Me.PropertyFrame.Controls.Add(Me.chkCyclicMode)
        Me.PropertyFrame.Controls.Add(Me.cmbOutputRange)
        Me.PropertyFrame.Controls.Add(Me.cmbChannel)
        Me.PropertyFrame.Controls.Add(Me.txtOutputRate)
        Me.PropertyFrame.Controls.Add(Me.cmbDataType)
        Me.PropertyFrame.Controls.Add(Me.cmbTransferMode)
        Me.PropertyFrame.Controls.Add(Me.Line1)
        Me.PropertyFrame.Controls.Add(Me.Label11)
        Me.PropertyFrame.Controls.Add(Me.Label8)
        Me.PropertyFrame.Controls.Add(Me.Label6)
        Me.PropertyFrame.Controls.Add(Me.Label5)
        Me.PropertyFrame.Controls.Add(Me.Label3)
        Me.PropertyFrame.Controls.Add(Me.Label4)
        Me.PropertyFrame.Controls.Add(Me.Label7)
        Me.PropertyFrame.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PropertyFrame.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PropertyFrame.Location = New System.Drawing.Point(12, 97)
        Me.PropertyFrame.Name = "PropertyFrame"
        Me.PropertyFrame.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PropertyFrame.Size = New System.Drawing.Size(249, 281)
        Me.PropertyFrame.TabIndex = 22
        Me.PropertyFrame.TabStop = False
        Me.PropertyFrame.Text = "Property Settings:"
        '
        'cmbWaveForm
        '
        Me.cmbWaveForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbWaveForm.Items.AddRange(New Object() {"Sine Wave", "Square Wave", "Triangle Wave"})
        Me.cmbWaveForm.Location = New System.Drawing.Point(106, 248)
        Me.cmbWaveForm.Name = "cmbWaveForm"
        Me.cmbWaveForm.Size = New System.Drawing.Size(126, 22)
        Me.cmbWaveForm.TabIndex = 31
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(8, 248)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(96, 16)
        Me.Label14.TabIndex = 30
        Me.Label14.Text = "Output Waveform"
        '
        'txtNumberOfOutputs
        '
        Me.txtNumberOfOutputs.AcceptsReturn = True
        Me.txtNumberOfOutputs.AutoSize = False
        Me.txtNumberOfOutputs.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumberOfOutputs.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNumberOfOutputs.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumberOfOutputs.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtNumberOfOutputs.Location = New System.Drawing.Point(96, 152)
        Me.txtNumberOfOutputs.MaxLength = 0
        Me.txtNumberOfOutputs.Name = "txtNumberOfOutputs"
        Me.txtNumberOfOutputs.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtNumberOfOutputs.Size = New System.Drawing.Size(65, 19)
        Me.txtNumberOfOutputs.TabIndex = 28
        Me.txtNumberOfOutputs.Text = ""
        '
        'chkCyclicMode
        '
        Me.chkCyclicMode.BackColor = System.Drawing.SystemColors.Control
        Me.chkCyclicMode.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkCyclicMode.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkCyclicMode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCyclicMode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkCyclicMode.Location = New System.Drawing.Point(8, 176)
        Me.chkCyclicMode.Name = "chkCyclicMode"
        Me.chkCyclicMode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkCyclicMode.Size = New System.Drawing.Size(100, 23)
        Me.chkCyclicMode.TabIndex = 25
        Me.chkCyclicMode.Text = "Cyclic Mode"
        '
        'cmbOutputRange
        '
        Me.cmbOutputRange.BackColor = System.Drawing.SystemColors.Window
        Me.cmbOutputRange.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbOutputRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOutputRange.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOutputRange.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbOutputRange.Items.AddRange(New Object() {"0 ~ 5 V", "0 ~ 10 V"})
        Me.cmbOutputRange.Location = New System.Drawing.Point(106, 216)
        Me.cmbOutputRange.Name = "cmbOutputRange"
        Me.cmbOutputRange.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbOutputRange.Size = New System.Drawing.Size(126, 22)
        Me.cmbOutputRange.TabIndex = 18
        '
        'cmbChannel
        '
        Me.cmbChannel.BackColor = System.Drawing.SystemColors.Window
        Me.cmbChannel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbChannel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbChannel.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbChannel.Location = New System.Drawing.Point(96, 24)
        Me.cmbChannel.Name = "cmbChannel"
        Me.cmbChannel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbChannel.Size = New System.Drawing.Size(129, 22)
        Me.cmbChannel.TabIndex = 16
        '
        'txtOutputRate
        '
        Me.txtOutputRate.AcceptsReturn = True
        Me.txtOutputRate.AutoSize = False
        Me.txtOutputRate.BackColor = System.Drawing.SystemColors.Window
        Me.txtOutputRate.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtOutputRate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOutputRate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOutputRate.Location = New System.Drawing.Point(96, 120)
        Me.txtOutputRate.MaxLength = 0
        Me.txtOutputRate.Name = "txtOutputRate"
        Me.txtOutputRate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtOutputRate.Size = New System.Drawing.Size(65, 21)
        Me.txtOutputRate.TabIndex = 13
        Me.txtOutputRate.Text = "100"
        Me.txtOutputRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtOutputRate, "Sample rate")
        '
        'cmbDataType
        '
        Me.cmbDataType.BackColor = System.Drawing.SystemColors.Window
        Me.cmbDataType.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDataType.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDataType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbDataType.Items.AddRange(New Object() {"Raw Data", "Real Data"})
        Me.cmbDataType.Location = New System.Drawing.Point(96, 56)
        Me.cmbDataType.Name = "cmbDataType"
        Me.cmbDataType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbDataType.Size = New System.Drawing.Size(131, 22)
        Me.cmbDataType.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.cmbDataType, "Device Data ype")
        '
        'cmbTransferMode
        '
        Me.cmbTransferMode.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTransferMode.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbTransferMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTransferMode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTransferMode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbTransferMode.Items.AddRange(New Object() {"Software Trigger", "Interrupt Transfer", "DMA Transfer"})
        Me.cmbTransferMode.Location = New System.Drawing.Point(96, 88)
        Me.cmbTransferMode.Name = "cmbTransferMode"
        Me.cmbTransferMode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbTransferMode.Size = New System.Drawing.Size(131, 22)
        Me.cmbTransferMode.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.cmbTransferMode, "Data transfer mode")
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.SystemColors.WindowText
        Me.Line1.Location = New System.Drawing.Point(8, 208)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(232, 1)
        Me.Line1.TabIndex = 29
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(168, 120)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(25, 17)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "Hz"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(8, 216)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(81, 17)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Output Range:"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(8, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(49, 17)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Channel:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(8, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(69, 16)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Output Rate :"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 152)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(88, 17)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Output Numbers:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(8, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(61, 16)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Data Type :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(8, 88)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(82, 16)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Transfer mode :"
        '
        'Frame4
        '
        Me.Frame4.BackColor = System.Drawing.SystemColors.Control
        Me.Frame4.Controls.Add(Me.Frame3)
        Me.Frame4.Controls.Add(Me.txtStatus)
        Me.Frame4.Controls.Add(Me.cmdStatus)
        Me.Frame4.Controls.Add(Me.cmdOutputStop)
        Me.Frame4.Controls.Add(Me.cmdOutputStart)
        Me.Frame4.Controls.Add(Me.lstWritting)
        Me.Frame4.Controls.Add(Me.chkEventEnabled)
        Me.Frame4.Controls.Add(Me.Label10)
        Me.Frame4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame4.Location = New System.Drawing.Point(268, 97)
        Me.Frame4.Name = "Frame4"
        Me.Frame4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame4.Size = New System.Drawing.Size(257, 283)
        Me.Frame4.TabIndex = 23
        Me.Frame4.TabStop = False
        Me.Frame4.Text = "Output:"
        '
        'Frame3
        '
        Me.Frame3.BackColor = System.Drawing.SystemColors.Control
        Me.Frame3.Controls.Add(Me.txtErrorMessage)
        Me.Frame3.Controls.Add(Me.txtErrorCode)
        Me.Frame3.Controls.Add(Me.Label13)
        Me.Frame3.Controls.Add(Me.Label12)
        Me.Frame3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame3.Location = New System.Drawing.Point(8, 200)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3.Size = New System.Drawing.Size(241, 73)
        Me.Frame3.TabIndex = 31
        Me.Frame3.TabStop = False
        Me.Frame3.Text = "Error Message"
        '
        'txtErrorMessage
        '
        Me.txtErrorMessage.AcceptsReturn = True
        Me.txtErrorMessage.AutoSize = False
        Me.txtErrorMessage.BackColor = System.Drawing.SystemColors.Window
        Me.txtErrorMessage.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtErrorMessage.Enabled = False
        Me.txtErrorMessage.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtErrorMessage.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtErrorMessage.Location = New System.Drawing.Point(80, 48)
        Me.txtErrorMessage.MaxLength = 0
        Me.txtErrorMessage.Name = "txtErrorMessage"
        Me.txtErrorMessage.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtErrorMessage.Size = New System.Drawing.Size(144, 19)
        Me.txtErrorMessage.TabIndex = 35
        Me.txtErrorMessage.Text = ""
        '
        'txtErrorCode
        '
        Me.txtErrorCode.AcceptsReturn = True
        Me.txtErrorCode.AutoSize = False
        Me.txtErrorCode.BackColor = System.Drawing.SystemColors.Window
        Me.txtErrorCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtErrorCode.Enabled = False
        Me.txtErrorCode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtErrorCode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtErrorCode.Location = New System.Drawing.Point(80, 24)
        Me.txtErrorCode.MaxLength = 0
        Me.txtErrorCode.Name = "txtErrorCode"
        Me.txtErrorCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtErrorCode.Size = New System.Drawing.Size(144, 19)
        Me.txtErrorCode.TabIndex = 34
        Me.txtErrorCode.Text = ""
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.Control
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(16, 48)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(57, 17)
        Me.Label13.TabIndex = 33
        Me.Label13.Text = "Message:"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(16, 24)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(64, 17)
        Me.Label12.TabIndex = 32
        Me.Label12.Text = "Error Code:"
        '
        'txtStatus
        '
        Me.txtStatus.AcceptsReturn = True
        Me.txtStatus.AutoSize = False
        Me.txtStatus.BackColor = System.Drawing.SystemColors.Window
        Me.txtStatus.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStatus.Enabled = False
        Me.txtStatus.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStatus.Location = New System.Drawing.Point(16, 168)
        Me.txtStatus.MaxLength = 0
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStatus.Size = New System.Drawing.Size(65, 19)
        Me.txtStatus.TabIndex = 30
        Me.txtStatus.Text = ""
        '
        'cmdStatus
        '
        Me.cmdStatus.BackColor = System.Drawing.SystemColors.Control
        Me.cmdStatus.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdStatus.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdStatus.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdStatus.Location = New System.Drawing.Point(16, 128)
        Me.cmdStatus.Name = "cmdStatus"
        Me.cmdStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdStatus.Size = New System.Drawing.Size(65, 25)
        Me.cmdStatus.TabIndex = 29
        Me.cmdStatus.Text = "Status"
        '
        'cmdOutputStop
        '
        Me.cmdOutputStop.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOutputStop.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOutputStop.Enabled = False
        Me.cmdOutputStop.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOutputStop.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOutputStop.Location = New System.Drawing.Point(8, 64)
        Me.cmdOutputStop.Name = "cmdOutputStop"
        Me.cmdOutputStop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOutputStop.Size = New System.Drawing.Size(73, 25)
        Me.cmdOutputStop.TabIndex = 23
        Me.cmdOutputStop.Text = "St&op"
        Me.ToolTip1.SetToolTip(Me.cmdOutputStop, "Stop Auto Scan")
        '
        'cmdOutputStart
        '
        Me.cmdOutputStart.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOutputStart.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOutputStart.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOutputStart.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOutputStart.Location = New System.Drawing.Point(8, 25)
        Me.cmdOutputStart.Name = "cmdOutputStart"
        Me.cmdOutputStart.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOutputStart.Size = New System.Drawing.Size(73, 25)
        Me.cmdOutputStart.TabIndex = 22
        Me.cmdOutputStart.Text = "St&art"
        Me.ToolTip1.SetToolTip(Me.cmdOutputStart, "Star Auto Scan")
        '
        'lstWritting
        '
        Me.lstWritting.BackColor = System.Drawing.SystemColors.Window
        Me.lstWritting.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstWritting.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstWritting.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstWritting.ItemHeight = 14
        Me.lstWritting.Location = New System.Drawing.Point(101, 42)
        Me.lstWritting.Name = "lstWritting"
        Me.lstWritting.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstWritting.Size = New System.Drawing.Size(140, 144)
        Me.lstWritting.TabIndex = 21
        '
        'chkEventEnabled
        '
        Me.chkEventEnabled.BackColor = System.Drawing.SystemColors.Control
        Me.chkEventEnabled.Checked = True
        Me.chkEventEnabled.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEventEnabled.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkEventEnabled.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEventEnabled.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkEventEnabled.Location = New System.Drawing.Point(7, 96)
        Me.chkEventEnabled.Name = "chkEventEnabled"
        Me.chkEventEnabled.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkEventEnabled.Size = New System.Drawing.Size(97, 21)
        Me.chkEventEnabled.TabIndex = 20
        Me.chkEventEnabled.Text = "Event Enabled"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(101, 21)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(80, 18)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "Writting :"
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExit.Location = New System.Drawing.Point(436, 65)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExit.Size = New System.Drawing.Size(89, 25)
        Me.cmdExit.TabIndex = 20
        Me.cmdExit.Text = "&Close"
        Me.ToolTip1.SetToolTip(Me.cmdExit, "Close application")
        '
        'txtDeviceNum
        '
        Me.txtDeviceNum.AcceptsReturn = True
        Me.txtDeviceNum.AutoSize = False
        Me.txtDeviceNum.BackColor = System.Drawing.SystemColors.Window
        Me.txtDeviceNum.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDeviceNum.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeviceNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDeviceNum.Location = New System.Drawing.Point(88, 24)
        Me.txtDeviceNum.MaxLength = 0
        Me.txtDeviceNum.Name = "txtDeviceNum"
        Me.txtDeviceNum.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDeviceNum.Size = New System.Drawing.Size(57, 19)
        Me.txtDeviceNum.TabIndex = 4
        Me.txtDeviceNum.Text = "-100"
        Me.ToolTip1.SetToolTip(Me.txtDeviceNum, "Device Number")
        '
        'txtDeviceName
        '
        Me.txtDeviceName.AcceptsReturn = True
        Me.txtDeviceName.AutoSize = False
        Me.txtDeviceName.BackColor = System.Drawing.SystemColors.Window
        Me.txtDeviceName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDeviceName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeviceName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDeviceName.Location = New System.Drawing.Point(88, 48)
        Me.txtDeviceName.MaxLength = 0
        Me.txtDeviceName.Name = "txtDeviceName"
        Me.txtDeviceName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDeviceName.Size = New System.Drawing.Size(305, 19)
        Me.txtDeviceName.TabIndex = 3
        Me.txtDeviceName.Text = "AdvanTech"
        Me.ToolTip1.SetToolTip(Me.txtDeviceName, "Device Name")
        '
        'cmdSelectDevice
        '
        Me.cmdSelectDevice.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSelectDevice.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSelectDevice.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSelectDevice.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSelectDevice.Location = New System.Drawing.Point(296, 16)
        Me.cmdSelectDevice.Name = "cmdSelectDevice"
        Me.cmdSelectDevice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSelectDevice.Size = New System.Drawing.Size(97, 25)
        Me.cmdSelectDevice.TabIndex = 2
        Me.cmdSelectDevice.Text = "&Select Device"
        Me.ToolTip1.SetToolTip(Me.cmdSelectDevice, "Selecting device to operation")
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.txtDeviceNum)
        Me.Frame1.Controls.Add(Me.txtDeviceName)
        Me.Frame1.Controls.Add(Me.cmdSelectDevice)
        Me.Frame1.Controls.Add(Me.Label1)
        Me.Frame1.Controls.Add(Me.Label2)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(12, 9)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(417, 79)
        Me.Frame1.TabIndex = 21
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Select Device :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Device No. :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(8, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(76, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Device Name :"
        '
        'ErrorTimer
        '
        Me.ErrorTimer.Enabled = True
        '
        'DAQAO1
        '
        Me.DAQAO1.Enabled = True
        Me.DAQAO1.Location = New System.Drawing.Point(464, 24)
        Me.DAQAO1.Name = "DAQAO1"
        Me.DAQAO1.OcxState = CType(resources.GetObject("DAQAO1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.DAQAO1.Size = New System.Drawing.Size(33, 33)
        Me.DAQAO1.TabIndex = 24
        '
        'frmAO
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(536, 389)
        Me.Controls.Add(Me.DAQAO1)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.PropertyFrame)
        Me.Controls.Add(Me.Frame4)
        Me.MaximizeBox = False
        Me.Name = "frmAO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Anolog output "
        Me.PropertyFrame.ResumeLayout(False)
        Me.Frame4.ResumeLayout(False)
        Me.Frame3.ResumeLayout(False)
        Me.Frame1.ResumeLayout(False)
        CType(Me.DAQAO1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub chkCyclicMode_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkCyclicMode.CheckStateChanged
        If IsInitializing Then
            Exit Sub
        End If
        If chkCyclicMode.CheckState = System.Windows.Forms.CheckState.Checked Then
            DAQAO1.CyclicMode = True
        Else
            DAQAO1.CyclicMode = False
        End If

    End Sub


    Private Sub chkEventEnabled_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkEventEnabled.CheckStateChanged
        If IsInitializing Then
            Exit Sub
        End If
        If chkEventEnabled.CheckState = System.Windows.Forms.CheckState.Checked Then
            DAQAO1.EventEnabled = True
        Else
            DAQAO1.EventEnabled = False
        End If
    End Sub

    Private Sub cmbChannel_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbChannel.SelectedIndexChanged
        If IsInitializing Then
            Exit Sub
        End If
        DAQAO1.Channel = cmbChannel.SelectedIndex
    End Sub


    Private Sub cmbDataType_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbDataType.SelectedIndexChanged
        If IsInitializing Then
            Exit Sub
        End If
        DAQAO1.DataType = cmbDataType.SelectedIndex
    End Sub

    Private Sub cmdStatus_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdStatus.Click
        txtStatus.Text = CStr(DAQAO1.OutputStatus)
    End Sub

    Private Sub ErrorTimer_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ErrorTimer.Tick
        txtErrorCode.Text = CStr(DAQAO1.ErrorCode)
        txtErrorMessage.Text = DAQAO1.ErrorMessage

    End Sub

    Private Sub txtNumberOfOutputs_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtNumberOfOutputs.Click
        DAQAO1.NumberOfOutputs = Val(txtNumberOfOutputs.Text)
    End Sub

    Private Sub cmbOutputRange_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbOutputRange.SelectedIndexChanged
        If IsInitializing Then
            Exit Sub
        End If
        OutputRange = (cmbOutputRange.SelectedIndex + 1) * 5 ' 5 ,10 V
    End Sub

    'UPGRADE_WARNING: Event cmbTransferMode.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
    Private Sub cmbTransferMode_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbTransferMode.SelectedIndexChanged
        DAQAO1.TransferMode = cmbTransferMode.SelectedIndex
    End Sub

    Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
        Me.Close()
        End
    End Sub
    Private Sub SetOutWaveForm()
        Dim i As Integer
        Dim j As Integer
        Dim Remain As Integer
        Dim Period As Integer
        If (DAQAO1.NumberOfOutputs > 200) Then
            Period = 200
        Else
            Period = DAQAO1.NumberOfOutputs / 4
        End If
        If DAQAO1.DataType = DAQAOLib.DATA_TYPE.adReal Then
            ReDim DataArray(DAQAO1.NumberOfOutputs - 1)
            For i = 0 To DAQAO1.NumberOfOutputs - 1

                Select Case (cmbWaveForm.SelectedIndex)
                    Case 0
                        DataArray(i) = ((OutputRange / 2) * (System.Math.Sin((2 * 3.14 / Period) * i) + 1))
                    Case 1
                        Remain = Decimal.Remainder(i, Period)
                        If Remain < Period / 2 Then
                            DataArray(i) = OutputRange
                        Else
                            DataArray(i) = 0
                        End If
                    Case 2
                        Remain = Decimal.Remainder(i, Period)
                        If Remain < Period / 2 Then
                            DataArray(i) = Remain * OutputRange * 2.0 / Period
                        Else
                            DataArray(i) = 2 * OutputRange - Remain * OutputRange * 2.0 / Period
                        End If

                End Select
            Next i
            DAQAO1.SetRealBuffer(DataArray)
        Else
            ReDim BinDataArray(DAQAO1.NumberOfOutputs - 1)
            For i = 0 To DAQAO1.NumberOfOutputs - 1
                Select Case (cmbWaveForm.SelectedIndex)
                    Case 0
                        BinDataArray(i) = ((4095 / 2) * (System.Math.Sin((3.14 / Period) * i) + 1))
                    Case 1
                        Remain = Decimal.Remainder(i, Period)
                        If Remain < Period / 2 Then
                            BinDataArray(i) = 4095
                        Else
                            BinDataArray(i) = 0
                        End If
                    Case 2
                        Remain = Decimal.Remainder(i, Period)
                        If Remain < Period / 2 Then
                            BinDataArray(i) = Remain * 4095 * 2 / Period
                        Else
                            BinDataArray(i) = 2 * 4095 - Remain * 4095 * 2 / Period
                        End If
                End Select
            Next
            DAQAO1.SetRawBuffer(BinDataArray)
        End If
    End Sub
    Private Sub cmdOutputStart_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOutputStart.Click
        Dim i As Integer
        Dim j As Integer
        If DAQAO1.OpenDevice Then
            MsgBox(DAQAO1.ErrorMessage, MsgBoxStyle.OKOnly)
            Exit Sub
        End If

        DAQAO1.Channel = cmbChannel.SelectedIndex
        DAQAO1.EventEnabled = chkEventEnabled.CheckState
        DAQAO1.CyclicMode = chkCyclicMode.CheckState
        DAQAO1.NumberOfOutputs = Val(txtNumberOfOutputs.Text)
        DAQAO1.TransferMode = cmbTransferMode.SelectedIndex
        DAQAO1.OutputRate = Val(txtOutputRate.Text)
        DAQAO1.DataType = cmbDataType.SelectedIndex

        'Set Data Array
        SetOutWaveForm()
        lstWritting.Items.Clear()

        ' Start getting data
        bRet = DAQAO1.OutputStart
        If bRet Then
            MsgBox(DAQAO1.ErrorMessage, MsgBoxStyle.OKOnly)
            DAQAO1.CloseDevice()
            Exit Sub
        End If
        cmdOutputStart.Enabled = False
        cmdOutputStop.Enabled = True
        cmdExit.Enabled = False
        ErrorTimer.Enabled = True
        PropertyFrame.Enabled = False
        cmdSelectDevice.Enabled = False
    End Sub

    Private Sub cmdOutputStop_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOutputStop.Click
        ' Stop get data
        ErrorTimer.Enabled = False
        PropertyFrame.Enabled = True
        cmdOutputStart.Enabled = True
        cmdOutputStop.Enabled = False
        cmdExit.Enabled = True
        cmdSelectDevice.Enabled = True

        bRet = DAQAO1.OutputStop
        If bRet Then
            MsgBox(DAQAO1.ErrorMessage, MsgBoxStyle.OKOnly)
        End If
        ' Close device
        DAQAO1.CloseDevice()

    End Sub

    Private Sub cmdSelectDevice_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSelectDevice.Click
        Dim i As Short
        Dim j As Short
        Dim bRet As Boolean

        'DAQDevice1.SelectDevice
        DAQAO1.SelectDevice()
        txtDeviceNum.Text = CStr(DAQAO1.DeviceNumber)
        txtDeviceName.Text = DAQAO1.DeviceName

        ' Open device
        If DAQAO1.OpenDevice Then
            MsgBox(DAQAO1.ErrorMessage, MsgBoxStyle.OKOnly)
            Exit Sub
        End If

        If DAQAO1.MaxChannel = 0 Then
            DAQAO1.CloseDevice()
            MsgBox("Function Not Supported", MsgBoxStyle.OKOnly)
            Exit Sub
        End If
        ' Get Max. channel number
        cmbChannel.Items.Clear()

        For j = 0 To DAQAO1.MaxChannel - 1
            cmbChannel.Items.Add((Str(j)))
        Next j

        cmbChannel.SelectedIndex = DAQAO1.Channel
        ' Setting initial value
        txtDeviceNum.Text = CStr(DAQAO1.DeviceNumber)
        txtDeviceName.Text = DAQAO1.DeviceName

        cmbDataType.SelectedIndex = DAQAO1.DataType
        cmbChannel.SelectedIndex = DAQAO1.Channel
        cmbTransferMode.SelectedIndex = DAQAO1.TransferMode

        txtOutputRate.Text = CStr(DAQAO1.OutputRate)
        txtNumberOfOutputs.Text = CStr(32768)
        OutputRange = 5

        DAQAO1.CloseDevice()
    End Sub

    Private Sub DAQAO1_OnCompleted(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DAQAO1.OnCompleted
        Dim i As Integer
        Dim j As Integer

        lstWritting.Items.Clear()
        If DAQAO1.NumberOfOutputs < 10 Then
            j = 0
        Else
            j = DAQAO1.NumberOfOutputs - 10
        End If

        If DAQAO1.DataType = DAQAOLib.DATA_TYPE.adReal Then
            For i = j To DAQAO1.NumberOfOutputs - 1
                lstWritting.Items.Add(("Buff[" & Str(i) & "]: " & Format(DataArray(i), "0.000000")))
            Next i
        Else
            For i = j To DAQAO1.NumberOfOutputs - 1
                lstWritting.Items.Add(("Buff[" & Str(i) & "]: " & Hex(BinDataArray(i))))
            Next i
        End If
    End Sub

    Private Sub DAQAO1_OnTerminated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DAQAO1.OnTerminated
        Dim i As Integer
        Dim j As Integer

        ' Stop wtite data
        DAQAO1.OutputStop()

        lstWritting.Items.Clear()
        If DAQAO1.NumberOfOutputs < 10 Then
            j = 0
        Else
            j = DAQAO1.NumberOfOutputs - 10
        End If

        If DAQAO1.DataType = DAQAOLib.DATA_TYPE.adReal Then
            For i = j To DAQAO1.NumberOfOutputs - 1
                lstWritting.Items.Add(("Buff[" & Str(i) & "]: " & Format(DataArray(i), "0.000000")))
            Next i
        Else
            For i = j To DAQAO1.NumberOfOutputs - 1
                lstWritting.Items.Add(("Buff[" & Str(i) & "]: " & Hex(BinDataArray(i))))
            Next i
        End If

        ' Close device
        DAQAO1.CloseDevice()
        PropertyFrame.Enabled = True
        cmdOutputStart.Enabled = True
        cmdOutputStop.Enabled = False
        cmdExit.Enabled = True
        ErrorTimer.Enabled = False
    End Sub

    Private Sub frmAoTester_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ' Select default device
        ErrorTimer.Enabled = False
        cmbOutputRange.SelectedIndex = 0
        cmbWaveForm.SelectedIndex = 0
        Call cmdSelectDevice_Click(cmdSelectDevice, New System.EventArgs)

    End Sub



    Private Sub txtDeviceNum_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtDeviceNum.TextChanged

        Dim j As Integer
        If IsInitializing Then
            Exit Sub
        End If
        DAQAO1.DeviceNumber = Val(txtDeviceNum.Text)
        txtDeviceName.Text = DAQAO1.DeviceName
        ' Open device
        If DAQAO1.OpenDevice Then
            MsgBox(DAQAO1.ErrorMessage, MsgBoxStyle.OKOnly)
            Exit Sub
        End If

        If DAQAO1.MaxChannel = 0 Then
            '   MsgBox("Function Not Supported", MsgBoxStyle.OKOnly)
            DAQAO1.CloseDevice()
            Exit Sub
            
        End If
        ' Get Max. channel number
        cmbChannel.Items.Clear()

        For j = 0 To DAQAO1.MaxChannel - 1
            cmbChannel.Items.Add((Str(j)))
        Next j

        cmbChannel.SelectedIndex = DAQAO1.Channel

        DAQAO1.CloseDevice()
    End Sub


    Private Sub txtOutputRate_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtOutputRate.TextChanged
        If IsInitializing Then
            Exit Sub
        End If
        DAQAO1.OutputRate = Val(txtOutputRate.Text)
    End Sub
End Class
