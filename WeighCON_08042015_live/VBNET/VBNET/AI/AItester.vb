Public Class Form1
    Inherits System.Windows.Forms.Form
    Dim bRet As Boolean
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
    Public WithEvents ErrorTimer As System.Windows.Forms.Timer
    Public WithEvents Frame4 As System.Windows.Forms.GroupBox
    Public WithEvents ErrorFrame As System.Windows.Forms.GroupBox
    Public WithEvents txtErrorMessage As System.Windows.Forms.TextBox
    Public WithEvents txtErrorCode As System.Windows.Forms.TextBox
    Public WithEvents Label14 As System.Windows.Forms.Label
    Public WithEvents Label13 As System.Windows.Forms.Label
    Public WithEvents cmdStopAutoGet As System.Windows.Forms.Button
    Public WithEvents cmdAutoGet As System.Windows.Forms.Button
    Public WithEvents txtStatus As System.Windows.Forms.TextBox
    Public WithEvents cmdStatus As System.Windows.Forms.Button
    Public WithEvents lstReading As System.Windows.Forms.ListBox
    Public WithEvents cmdAcquireStart As System.Windows.Forms.Button
    Public WithEvents cmdAcquireStop As System.Windows.Forms.Button
    Public WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents cmdExit As System.Windows.Forms.Button
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents cmdSelectDevice As System.Windows.Forms.Button
    Public WithEvents txtDeviceName As System.Windows.Forms.TextBox
    Public WithEvents txtDeviceNum As System.Windows.Forms.TextBox
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents chou2121 As System.Windows.Forms.GroupBox
    Public WithEvents cmbNumofChannels As System.Windows.Forms.ComboBox
    Public WithEvents txtFifoSize As System.Windows.Forms.TextBox
    Public WithEvents CyclicMode As System.Windows.Forms.CheckBox
    Public WithEvents cmbClockSource As System.Windows.Forms.ComboBox
    Public WithEvents cmbTriggerSource As System.Windows.Forms.ComboBox
    Public WithEvents chkEventEnabled As System.Windows.Forms.CheckBox
    Public WithEvents chkOverAllGain As System.Windows.Forms.CheckBox
    Public WithEvents cmdGainList As System.Windows.Forms.Button
    Public WithEvents txtNumOfSample As System.Windows.Forms.TextBox
    Public WithEvents chkFIFOEnabled As System.Windows.Forms.CheckBox
    Public WithEvents cmbStartChannel As System.Windows.Forms.ComboBox
    Public WithEvents cmbTransferMode As System.Windows.Forms.ComboBox
    Public WithEvents txtSampleRate As System.Windows.Forms.TextBox
    Public WithEvents cmbDataType As System.Windows.Forms.ComboBox
    Public WithEvents cmbInputRange As System.Windows.Forms.ComboBox
    Public WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents Label24 As System.Windows.Forms.Label
    Public WithEvents Label19 As System.Windows.Forms.Label
    Public WithEvents Label16 As System.Windows.Forms.Label
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents ScanTimer As System.Windows.Forms.Timer
    Public WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents DAQAI1 As AxDAQAILib.AxDAQAI


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.ErrorTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Frame4 = New System.Windows.Forms.GroupBox
        Me.ErrorFrame = New System.Windows.Forms.GroupBox
        Me.txtErrorMessage = New System.Windows.Forms.TextBox
        Me.txtErrorCode = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.cmdStopAutoGet = New System.Windows.Forms.Button
        Me.cmdAutoGet = New System.Windows.Forms.Button
        Me.txtStatus = New System.Windows.Forms.TextBox
        Me.cmdStatus = New System.Windows.Forms.Button
        Me.lstReading = New System.Windows.Forms.ListBox
        Me.cmdAcquireStart = New System.Windows.Forms.Button
        Me.cmdAcquireStop = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmdExit = New System.Windows.Forms.Button
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.cmdSelectDevice = New System.Windows.Forms.Button
        Me.txtDeviceName = New System.Windows.Forms.TextBox
        Me.txtDeviceNum = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.chou2121 = New System.Windows.Forms.GroupBox
        Me.cmbNumofChannels = New System.Windows.Forms.ComboBox
        Me.txtFifoSize = New System.Windows.Forms.TextBox
        Me.CyclicMode = New System.Windows.Forms.CheckBox
        Me.cmbClockSource = New System.Windows.Forms.ComboBox
        Me.cmbTriggerSource = New System.Windows.Forms.ComboBox
        Me.chkEventEnabled = New System.Windows.Forms.CheckBox
        Me.chkOverAllGain = New System.Windows.Forms.CheckBox
        Me.cmdGainList = New System.Windows.Forms.Button
        Me.txtNumOfSample = New System.Windows.Forms.TextBox
        Me.chkFIFOEnabled = New System.Windows.Forms.CheckBox
        Me.cmbStartChannel = New System.Windows.Forms.ComboBox
        Me.cmbTransferMode = New System.Windows.Forms.ComboBox
        Me.txtSampleRate = New System.Windows.Forms.TextBox
        Me.cmbDataType = New System.Windows.Forms.ComboBox
        Me.cmbInputRange = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.ScanTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.DAQAI1 = New AxDAQAILib.AxDAQAI
        Me.Frame4.SuspendLayout()
        Me.ErrorFrame.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.chou2121.SuspendLayout()
        CType(Me.DAQAI1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ErrorTimer
        '
        Me.ErrorTimer.Enabled = True
        Me.ErrorTimer.Interval = 1000
        '
        'Frame4
        '
        Me.Frame4.BackColor = System.Drawing.SystemColors.Control
        Me.Frame4.Controls.Add(Me.ErrorFrame)
        Me.Frame4.Controls.Add(Me.cmdStopAutoGet)
        Me.Frame4.Controls.Add(Me.cmdAutoGet)
        Me.Frame4.Controls.Add(Me.txtStatus)
        Me.Frame4.Controls.Add(Me.cmdStatus)
        Me.Frame4.Controls.Add(Me.lstReading)
        Me.Frame4.Controls.Add(Me.cmdAcquireStart)
        Me.Frame4.Controls.Add(Me.cmdAcquireStop)
        Me.Frame4.Controls.Add(Me.Label10)
        Me.Frame4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame4.Location = New System.Drawing.Point(222, 84)
        Me.Frame4.Name = "Frame4"
        Me.Frame4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame4.Size = New System.Drawing.Size(194, 335)
        Me.Frame4.TabIndex = 21
        Me.Frame4.TabStop = False
        Me.Frame4.Text = "Acquire Read:"
        '
        'ErrorFrame
        '
        Me.ErrorFrame.BackColor = System.Drawing.SystemColors.Control
        Me.ErrorFrame.Controls.Add(Me.txtErrorMessage)
        Me.ErrorFrame.Controls.Add(Me.txtErrorCode)
        Me.ErrorFrame.Controls.Add(Me.Label14)
        Me.ErrorFrame.Controls.Add(Me.Label13)
        Me.ErrorFrame.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ErrorFrame.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ErrorFrame.Location = New System.Drawing.Point(13, 260)
        Me.ErrorFrame.Name = "ErrorFrame"
        Me.ErrorFrame.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ErrorFrame.Size = New System.Drawing.Size(171, 68)
        Me.ErrorFrame.TabIndex = 33
        Me.ErrorFrame.TabStop = False
        Me.ErrorFrame.Text = "Eroor Message"
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
        Me.txtErrorMessage.Location = New System.Drawing.Point(62, 37)
        Me.txtErrorMessage.MaxLength = 0
        Me.txtErrorMessage.Name = "txtErrorMessage"
        Me.txtErrorMessage.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtErrorMessage.Size = New System.Drawing.Size(99, 18)
        Me.txtErrorMessage.TabIndex = 37
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
        Me.txtErrorCode.Location = New System.Drawing.Point(92, 15)
        Me.txtErrorCode.MaxLength = 0
        Me.txtErrorCode.Name = "txtErrorCode"
        Me.txtErrorCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtErrorCode.Size = New System.Drawing.Size(70, 17)
        Me.txtErrorCode.TabIndex = 36
        Me.txtErrorCode.Text = ""
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.SystemColors.Control
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(7, 37)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(49, 16)
        Me.Label14.TabIndex = 35
        Me.Label14.Text = "Message :"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.Control
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(7, 15)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(73, 16)
        Me.Label13.TabIndex = 34
        Me.Label13.Text = "Error Code:"
        '
        'cmdStopAutoGet
        '
        Me.cmdStopAutoGet.BackColor = System.Drawing.SystemColors.Control
        Me.cmdStopAutoGet.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdStopAutoGet.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdStopAutoGet.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdStopAutoGet.Location = New System.Drawing.Point(107, 45)
        Me.cmdStopAutoGet.Name = "cmdStopAutoGet"
        Me.cmdStopAutoGet.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdStopAutoGet.Size = New System.Drawing.Size(77, 23)
        Me.cmdStopAutoGet.TabIndex = 32
        Me.cmdStopAutoGet.Text = "Stop Getting"
        '
        'cmdAutoGet
        '
        Me.cmdAutoGet.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAutoGet.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAutoGet.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAutoGet.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAutoGet.Location = New System.Drawing.Point(107, 15)
        Me.cmdAutoGet.Name = "cmdAutoGet"
        Me.cmdAutoGet.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAutoGet.Size = New System.Drawing.Size(77, 23)
        Me.cmdAutoGet.TabIndex = 31
        Me.cmdAutoGet.Text = "Get Buffer"
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
        Me.txtStatus.Location = New System.Drawing.Point(107, 74)
        Me.txtStatus.MaxLength = 0
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStatus.Size = New System.Drawing.Size(77, 23)
        Me.txtStatus.TabIndex = 30
        Me.txtStatus.Text = ""
        '
        'cmdStatus
        '
        Me.cmdStatus.BackColor = System.Drawing.SystemColors.Control
        Me.cmdStatus.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdStatus.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdStatus.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdStatus.Location = New System.Drawing.Point(13, 74)
        Me.cmdStatus.Name = "cmdStatus"
        Me.cmdStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdStatus.Size = New System.Drawing.Size(74, 23)
        Me.cmdStatus.TabIndex = 29
        Me.cmdStatus.Text = "Status"
        '
        'lstReading
        '
        Me.lstReading.BackColor = System.Drawing.SystemColors.Window
        Me.lstReading.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstReading.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstReading.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstReading.ItemHeight = 14
        Me.lstReading.Location = New System.Drawing.Point(13, 115)
        Me.lstReading.Name = "lstReading"
        Me.lstReading.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstReading.Size = New System.Drawing.Size(171, 144)
        Me.lstReading.TabIndex = 21
        '
        'cmdAcquireStart
        '
        Me.cmdAcquireStart.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAcquireStart.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAcquireStart.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAcquireStart.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAcquireStart.Location = New System.Drawing.Point(13, 15)
        Me.cmdAcquireStart.Name = "cmdAcquireStart"
        Me.cmdAcquireStart.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAcquireStart.Size = New System.Drawing.Size(74, 23)
        Me.cmdAcquireStart.TabIndex = 19
        Me.cmdAcquireStart.Text = "St&art"
        Me.ToolTip1.SetToolTip(Me.cmdAcquireStart, "Start Auto Scan")
        '
        'cmdAcquireStop
        '
        Me.cmdAcquireStop.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAcquireStop.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAcquireStop.Enabled = False
        Me.cmdAcquireStop.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAcquireStop.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAcquireStop.Location = New System.Drawing.Point(13, 45)
        Me.cmdAcquireStop.Name = "cmdAcquireStop"
        Me.cmdAcquireStop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAcquireStop.Size = New System.Drawing.Size(74, 23)
        Me.cmdAcquireStop.TabIndex = 18
        Me.cmdAcquireStop.Text = "St&op"
        Me.ToolTip1.SetToolTip(Me.cmdAcquireStop, "Stop Auto Scan")
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(13, 100)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(67, 16)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Reading :"
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExit.Location = New System.Drawing.Point(338, 53)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExit.Size = New System.Drawing.Size(67, 23)
        Me.cmdExit.TabIndex = 19
        Me.cmdExit.Text = "&Close"
        Me.ToolTip1.SetToolTip(Me.cmdExit, "Close application")
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.cmdSelectDevice)
        Me.Frame1.Controls.Add(Me.txtDeviceName)
        Me.Frame1.Controls.Add(Me.txtDeviceNum)
        Me.Frame1.Controls.Add(Me.Label2)
        Me.Frame1.Controls.Add(Me.Label1)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(9, 8)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(314, 74)
        Me.Frame1.TabIndex = 18
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Select Device :"
        '
        'cmdSelectDevice
        '
        Me.cmdSelectDevice.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSelectDevice.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSelectDevice.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSelectDevice.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSelectDevice.Location = New System.Drawing.Point(201, 15)
        Me.cmdSelectDevice.Name = "cmdSelectDevice"
        Me.cmdSelectDevice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSelectDevice.Size = New System.Drawing.Size(100, 25)
        Me.cmdSelectDevice.TabIndex = 5
        Me.cmdSelectDevice.Text = "&Select Device"
        Me.ToolTip1.SetToolTip(Me.cmdSelectDevice, "Selecting device to operation")
        '
        'txtDeviceName
        '
        Me.txtDeviceName.AcceptsReturn = True
        Me.txtDeviceName.AutoSize = False
        Me.txtDeviceName.BackColor = System.Drawing.SystemColors.Window
        Me.txtDeviceName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDeviceName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeviceName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDeviceName.Location = New System.Drawing.Point(87, 45)
        Me.txtDeviceName.MaxLength = 0
        Me.txtDeviceName.Name = "txtDeviceName"
        Me.txtDeviceName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDeviceName.Size = New System.Drawing.Size(214, 17)
        Me.txtDeviceName.TabIndex = 4
        Me.txtDeviceName.Text = "AdvanTech"
        Me.ToolTip1.SetToolTip(Me.txtDeviceName, "Device Name")
        '
        'txtDeviceNum
        '
        Me.txtDeviceNum.AcceptsReturn = True
        Me.txtDeviceNum.AutoSize = False
        Me.txtDeviceNum.BackColor = System.Drawing.SystemColors.Window
        Me.txtDeviceNum.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDeviceNum.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeviceNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDeviceNum.Location = New System.Drawing.Point(87, 15)
        Me.txtDeviceNum.MaxLength = 0
        Me.txtDeviceNum.Name = "txtDeviceNum"
        Me.txtDeviceNum.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDeviceNum.Size = New System.Drawing.Size(47, 17)
        Me.txtDeviceNum.TabIndex = 1
        Me.txtDeviceNum.Text = "-100"
        Me.ToolTip1.SetToolTip(Me.txtDeviceNum, "Device Number")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(13, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(76, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Device Name :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(13, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Device No. :"
        '
        'chou2121
        '
        Me.chou2121.BackColor = System.Drawing.SystemColors.Control
        Me.chou2121.Controls.Add(Me.cmbNumofChannels)
        Me.chou2121.Controls.Add(Me.txtFifoSize)
        Me.chou2121.Controls.Add(Me.CyclicMode)
        Me.chou2121.Controls.Add(Me.cmbClockSource)
        Me.chou2121.Controls.Add(Me.cmbTriggerSource)
        Me.chou2121.Controls.Add(Me.chkEventEnabled)
        Me.chou2121.Controls.Add(Me.chkOverAllGain)
        Me.chou2121.Controls.Add(Me.cmdGainList)
        Me.chou2121.Controls.Add(Me.txtNumOfSample)
        Me.chou2121.Controls.Add(Me.chkFIFOEnabled)
        Me.chou2121.Controls.Add(Me.cmbStartChannel)
        Me.chou2121.Controls.Add(Me.cmbTransferMode)
        Me.chou2121.Controls.Add(Me.txtSampleRate)
        Me.chou2121.Controls.Add(Me.cmbDataType)
        Me.chou2121.Controls.Add(Me.cmbInputRange)
        Me.chou2121.Controls.Add(Me.Label12)
        Me.chou2121.Controls.Add(Me.Label11)
        Me.chou2121.Controls.Add(Me.Label9)
        Me.chou2121.Controls.Add(Me.Label24)
        Me.chou2121.Controls.Add(Me.Label19)
        Me.chou2121.Controls.Add(Me.Label16)
        Me.chou2121.Controls.Add(Me.Label8)
        Me.chou2121.Controls.Add(Me.Label7)
        Me.chou2121.Controls.Add(Me.Label6)
        Me.chou2121.Controls.Add(Me.Label5)
        Me.chou2121.Controls.Add(Me.Label4)
        Me.chou2121.Controls.Add(Me.Label3)
        Me.chou2121.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chou2121.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chou2121.Location = New System.Drawing.Point(9, 84)
        Me.chou2121.Name = "chou2121"
        Me.chou2121.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chou2121.Size = New System.Drawing.Size(199, 335)
        Me.chou2121.TabIndex = 20
        Me.chou2121.TabStop = False
        Me.chou2121.Text = "Property Settings:"
        '
        'cmbNumofChannels
        '
        Me.cmbNumofChannels.BackColor = System.Drawing.SystemColors.Window
        Me.cmbNumofChannels.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbNumofChannels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNumofChannels.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbNumofChannels.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbNumofChannels.Location = New System.Drawing.Point(88, 45)
        Me.cmbNumofChannels.Name = "cmbNumofChannels"
        Me.cmbNumofChannels.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbNumofChannels.Size = New System.Drawing.Size(95, 22)
        Me.cmbNumofChannels.TabIndex = 48
        '
        'txtFifoSize
        '
        Me.txtFifoSize.AcceptsReturn = True
        Me.txtFifoSize.AutoSize = False
        Me.txtFifoSize.BackColor = System.Drawing.SystemColors.Window
        Me.txtFifoSize.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFifoSize.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFifoSize.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFifoSize.Location = New System.Drawing.Point(87, 275)
        Me.txtFifoSize.MaxLength = 0
        Me.txtFifoSize.Name = "txtFifoSize"
        Me.txtFifoSize.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFifoSize.Size = New System.Drawing.Size(95, 17)
        Me.txtFifoSize.TabIndex = 46
        Me.txtFifoSize.Text = ""
        '
        'CyclicMode
        '
        Me.CyclicMode.BackColor = System.Drawing.SystemColors.Control
        Me.CyclicMode.Cursor = System.Windows.Forms.Cursors.Default
        Me.CyclicMode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CyclicMode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CyclicMode.Location = New System.Drawing.Point(104, 300)
        Me.CyclicMode.Name = "CyclicMode"
        Me.CyclicMode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CyclicMode.Size = New System.Drawing.Size(88, 15)
        Me.CyclicMode.TabIndex = 44
        Me.CyclicMode.Text = "CyclicMode"
        '
        'cmbClockSource
        '
        Me.cmbClockSource.BackColor = System.Drawing.SystemColors.Window
        Me.cmbClockSource.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbClockSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbClockSource.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbClockSource.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbClockSource.Items.AddRange(New Object() {"Internal", "External"})
        Me.cmbClockSource.Location = New System.Drawing.Point(88, 182)
        Me.cmbClockSource.Name = "cmbClockSource"
        Me.cmbClockSource.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbClockSource.Size = New System.Drawing.Size(95, 22)
        Me.cmbClockSource.TabIndex = 42
        Me.ToolTip1.SetToolTip(Me.cmbClockSource, "Data transfer mode")
        '
        'cmbTriggerSource
        '
        Me.cmbTriggerSource.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTriggerSource.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbTriggerSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTriggerSource.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTriggerSource.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbTriggerSource.Items.AddRange(New Object() {"Internal", "External"})
        Me.cmbTriggerSource.Location = New System.Drawing.Point(88, 159)
        Me.cmbTriggerSource.Name = "cmbTriggerSource"
        Me.cmbTriggerSource.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbTriggerSource.Size = New System.Drawing.Size(95, 22)
        Me.cmbTriggerSource.TabIndex = 40
        Me.ToolTip1.SetToolTip(Me.cmbTriggerSource, "Data transfer mode")
        '
        'chkEventEnabled
        '
        Me.chkEventEnabled.BackColor = System.Drawing.SystemColors.Control
        Me.chkEventEnabled.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkEventEnabled.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEventEnabled.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkEventEnabled.Location = New System.Drawing.Point(13, 300)
        Me.chkEventEnabled.Name = "chkEventEnabled"
        Me.chkEventEnabled.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkEventEnabled.Size = New System.Drawing.Size(91, 15)
        Me.chkEventEnabled.TabIndex = 38
        Me.chkEventEnabled.Text = "Event Enabled"
        '
        'chkOverAllGain
        '
        Me.chkOverAllGain.BackColor = System.Drawing.SystemColors.Control
        Me.chkOverAllGain.Checked = True
        Me.chkOverAllGain.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOverAllGain.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkOverAllGain.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkOverAllGain.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkOverAllGain.Location = New System.Drawing.Point(88, 90)
        Me.chkOverAllGain.Name = "chkOverAllGain"
        Me.chkOverAllGain.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkOverAllGain.Size = New System.Drawing.Size(84, 17)
        Me.chkOverAllGain.TabIndex = 27
        Me.chkOverAllGain.Text = "Overall Gain"
        '
        'cmdGainList
        '
        Me.cmdGainList.BackColor = System.Drawing.SystemColors.Control
        Me.cmdGainList.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdGainList.Enabled = False
        Me.cmdGainList.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGainList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdGainList.Location = New System.Drawing.Point(161, 70)
        Me.cmdGainList.Name = "cmdGainList"
        Me.cmdGainList.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdGainList.Size = New System.Drawing.Size(21, 19)
        Me.cmdGainList.TabIndex = 26
        Me.cmdGainList.Text = "..."
        '
        'txtNumOfSample
        '
        Me.txtNumOfSample.AcceptsReturn = True
        Me.txtNumOfSample.AutoSize = False
        Me.txtNumOfSample.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumOfSample.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNumOfSample.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumOfSample.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtNumOfSample.Location = New System.Drawing.Point(87, 226)
        Me.txtNumOfSample.MaxLength = 0
        Me.txtNumOfSample.Name = "txtNumOfSample"
        Me.txtNumOfSample.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtNumOfSample.Size = New System.Drawing.Size(95, 19)
        Me.txtNumOfSample.TabIndex = 24
        Me.txtNumOfSample.Text = "4096"
        Me.txtNumOfSample.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkFIFOEnabled
        '
        Me.chkFIFOEnabled.BackColor = System.Drawing.SystemColors.Control
        Me.chkFIFOEnabled.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkFIFOEnabled.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFIFOEnabled.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkFIFOEnabled.Location = New System.Drawing.Point(87, 253)
        Me.chkFIFOEnabled.Name = "chkFIFOEnabled"
        Me.chkFIFOEnabled.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkFIFOEnabled.Size = New System.Drawing.Size(95, 20)
        Me.chkFIFOEnabled.TabIndex = 22
        Me.chkFIFOEnabled.Text = "FIFO Enabled"
        '
        'cmbStartChannel
        '
        Me.cmbStartChannel.BackColor = System.Drawing.SystemColors.Window
        Me.cmbStartChannel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbStartChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStartChannel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbStartChannel.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbStartChannel.Location = New System.Drawing.Point(88, 22)
        Me.cmbStartChannel.Name = "cmbStartChannel"
        Me.cmbStartChannel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbStartChannel.Size = New System.Drawing.Size(95, 22)
        Me.cmbStartChannel.TabIndex = 20
        '
        'cmbTransferMode
        '
        Me.cmbTransferMode.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTransferMode.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbTransferMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTransferMode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTransferMode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbTransferMode.Items.AddRange(New Object() {"Software Trigger", "Interrupt Transfer", "DMA Transfer"})
        Me.cmbTransferMode.Location = New System.Drawing.Point(88, 136)
        Me.cmbTransferMode.Name = "cmbTransferMode"
        Me.cmbTransferMode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbTransferMode.Size = New System.Drawing.Size(95, 22)
        Me.cmbTransferMode.TabIndex = 15
        Me.ToolTip1.SetToolTip(Me.cmbTransferMode, "Data transfer mode")
        '
        'txtSampleRate
        '
        Me.txtSampleRate.AcceptsReturn = True
        Me.txtSampleRate.AutoSize = False
        Me.txtSampleRate.BackColor = System.Drawing.SystemColors.Window
        Me.txtSampleRate.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSampleRate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSampleRate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSampleRate.Location = New System.Drawing.Point(88, 205)
        Me.txtSampleRate.MaxLength = 0
        Me.txtSampleRate.Name = "txtSampleRate"
        Me.txtSampleRate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSampleRate.Size = New System.Drawing.Size(79, 20)
        Me.txtSampleRate.TabIndex = 12
        Me.txtSampleRate.Text = "10000"
        Me.txtSampleRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtSampleRate, "Sample rate")
        '
        'cmbDataType
        '
        Me.cmbDataType.BackColor = System.Drawing.SystemColors.Window
        Me.cmbDataType.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDataType.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDataType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbDataType.Items.AddRange(New Object() {"Raw Data", "Real Data"})
        Me.cmbDataType.Location = New System.Drawing.Point(88, 112)
        Me.cmbDataType.Name = "cmbDataType"
        Me.cmbDataType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbDataType.Size = New System.Drawing.Size(95, 22)
        Me.cmbDataType.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.cmbDataType, "Device Data ype")
        '
        'cmbInputRange
        '
        Me.cmbInputRange.BackColor = System.Drawing.SystemColors.Window
        Me.cmbInputRange.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbInputRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbInputRange.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbInputRange.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbInputRange.Location = New System.Drawing.Point(88, 69)
        Me.cmbInputRange.Name = "cmbInputRange"
        Me.cmbInputRange.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbInputRange.Size = New System.Drawing.Size(74, 22)
        Me.cmbInputRange.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.cmbInputRange, "Input voltage range")
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(167, 208)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(24, 16)
        Me.Label12.TabIndex = 49
        Me.Label12.Text = "Hz"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(147, 230)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(14, 16)
        Me.Label11.TabIndex = 47
        Me.Label11.Text = "Hz"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(13, 275)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(67, 15)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "FIFO Size :"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.SystemColors.Control
        Me.Label24.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label24.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(7, 47)
        Me.Label24.Name = "Label24"
        Me.Label24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label24.Size = New System.Drawing.Size(88, 16)
        Me.Label24.TabIndex = 43
        Me.Label24.Text = "Num of Chan(s) :"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.SystemColors.Control
        Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label19.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(7, 186)
        Me.Label19.Name = "Label19"
        Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label19.Size = New System.Drawing.Size(81, 15)
        Me.Label19.TabIndex = 41
        Me.Label19.Text = "Clock Source:"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.Control
        Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(7, 163)
        Me.Label16.Name = "Label16"
        Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label16.Size = New System.Drawing.Size(73, 16)
        Me.Label16.TabIndex = 39
        Me.Label16.Text = "Trig. Source:"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(7, 229)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(73, 12)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Conv# Num :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(5, 141)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(82, 16)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Transfer mode :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(7, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(77, 16)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Start Channel :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(7, 208)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(74, 16)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Sample Rate :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(8, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(61, 16)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Data Type :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(9, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(70, 16)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Input Range :"
        '
        'ScanTimer
        '
        Me.ScanTimer.Interval = 500
        '
        'DAQAI1
        '
        Me.DAQAI1.Enabled = True
        Me.DAQAI1.Location = New System.Drawing.Point(357, 10)
        Me.DAQAI1.Name = "DAQAI1"
        Me.DAQAI1.OcxState = CType(resources.GetObject("DAQAI1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.DAQAI1.Size = New System.Drawing.Size(33, 33)
        Me.DAQAI1.TabIndex = 22
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(424, 425)
        Me.Controls.Add(Me.DAQAI1)
        Me.Controls.Add(Me.chou2121)
        Me.Controls.Add(Me.Frame4)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.Frame1)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AI Tester"
        Me.Frame4.ResumeLayout(False)
        Me.ErrorFrame.ResumeLayout(False)
        Me.Frame1.ResumeLayout(False)
        Me.chou2121.ResumeLayout(False)
        CType(Me.DAQAI1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cmdAcquireStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAcquireStop.Click
        If IsInitializing Then
            Exit Sub
        End If
        ' Stop get data
        cmdAcquireStop.Enabled = False
        bRet = DAQAI1.AcquireStop
        If bRet Then
            MsgBox(DAQAI1.ErrorMessage, MsgBoxStyle.OKOnly)
            Exit Sub
        End If
        ErrorTimer.Enabled = False
        ' Close device
        bRet = DAQAI1.CloseDevice
        If bRet Then
            MsgBox(DAQAI1.ErrorMessage, MsgBoxStyle.OKOnly)
            Exit Sub
        End If
        UIControl(True)
        cmdAutoGet.Enabled = False
        cmdSelectDevice.Enabled = True


    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Select default device
        Call cmdSelectDevice_Click(cmdSelectDevice, New System.EventArgs)
        ' Setting initial value
        cmbDataType.SelectedIndex = DAQAI1.DataType

        'End Add

        ScanTimer.Enabled = False
        cmdAutoGet.Enabled = False
        cmdStopAutoGet.Enabled = False
        lstReading.ResetText()
    End Sub

    Private Sub cmdSelectDevice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectDevice.Click
        Dim i As Short
        Dim j As Short
        Dim bRet As Boolean
        Dim strRange As New String("", 30)

        If IsInitializing Then
            Exit Sub
        End If

        ScanTimer.Enabled = False
        ErrorTimer.Enabled = False

        DAQAI1.SelectDevice()

        txtDeviceNum.Text = CStr(DAQAI1.DeviceNumber)
        txtDeviceName.Text = DAQAI1.DeviceName
        DAQAI1.DeviceNumber = DAQAI1.DeviceNumber
        DAQAI1.DeviceName = DAQAI1.DeviceName
        cmbInputRange.Items.Clear()
        ' Open device
        If DAQAI1.OpenDevice Then
            MsgBox(DAQAI1.ErrorMessage, MsgBoxStyle.OKOnly)
            Exit Sub
        End If

        If InStr(DAQAI1.DeviceName, "DEMO") <> 0 Then
            cmbDataType.Enabled = False
            cmbDataType.SelectedIndex = 1
            DAQAI1.DataType = DAQAILib.DATA_TYPE.adReal
            chkFIFOEnabled.Enabled = False
            txtFifoSize.Text = CStr(1)
            txtFifoSize.Enabled = False
            chkOverAllGain.Enabled = False
        Else
            cmbDataType.Enabled = True
            chkFIFOEnabled.Enabled = True
            chkOverAllGain.Enabled = True
            txtFifoSize.Enabled = True

        End If

        ' Get input range list
        DAQAI1.GetFirstInputRange(strRange)
        cmbInputRange.Items.Add(strRange)
        gInputRangeList(0) = strRange
        i = 1
        While (DAQAI1.GetNextInputRange(strRange) = False)
            cmbInputRange.Items.Add(strRange)
            gInputRangeList(i) = strRange
            i += 1
        End While
        cmbInputRange.SelectedIndex = 0

        ' Get Max. channel number
        If DAQAI1.MaxDifferentialChannel > DAQAI1.MaxSingleEndedChannel Then
            i = DAQAI1.MaxDifferentialChannel
        Else
            i = DAQAI1.MaxSingleEndedChannel
        End If

        If i = 0 Then
            MsgBox("Function Not Supported", MsgBoxStyle.OKOnly)
            DAQAI1.CloseDevice()

            Exit Sub
        End If
        'redim the size of gGainCodeList
        ReDim gGainCodeList(i - 1)
        cmbStartChannel.Items.Clear()
        cmbNumofChannels.Items.Clear()

        For j = 0 To i - 1
            cmbStartChannel.Items.Add((Str(j)))
            cmbNumofChannels.Items.Add((Str(j + 1)))
        Next j
        If i <> 0 Then
            cmbStartChannel.SelectedIndex = 0
            cmbNumofChannels.SelectedIndex = 0
        End If

        If DAQAI1.FIFOEnabled Then
            txtFifoSize.Enabled = True
            txtFifoSize.Text = CStr(DAQAI1.FIFOSize)
        Else
            txtFifoSize.Enabled = False
        End If

        cmbStartChannel.SelectedIndex = DAQAI1.StartChannel

        cmbTransferMode.SelectedIndex = DAQAI1.TransferMode


        cmbClockSource.SelectedIndex = DAQAI1.ClockSource

        If DAQAI1.FIFOEnabled Then
            chkFIFOEnabled.CheckState = System.Windows.Forms.CheckState.Checked
            txtFifoSize.Text = CStr(DAQAI1.FIFOSize)
        Else
            chkFIFOEnabled.CheckState = System.Windows.Forms.CheckState.Unchecked
            txtFifoSize.Enabled = False
        End If

        If DAQAI1.EventEnabled Then
            chkEventEnabled.CheckState = System.Windows.Forms.CheckState.Checked
        Else
            chkEventEnabled.CheckState = System.Windows.Forms.CheckState.Unchecked
        End If

        If DAQAI1.CyclicMode Then
            CyclicMode.CheckState = System.Windows.Forms.CheckState.Checked
        Else
            CyclicMode.CheckState = System.Windows.Forms.CheckState.Unchecked
        End If


        If DAQAI1.ExtTrigger = True Then
            cmbTriggerSource.SelectedIndex = 1
        Else
            cmbTriggerSource.SelectedIndex = 0
        End If

        cmbNumofChannels.SelectedIndex = DAQAI1.NumberOfChannels - 1
        txtSampleRate.Text = CStr(DAQAI1.SampleRate)
        txtNumOfSample.Text = CStr(DAQAI1.NumberOfSamples)


        DAQAI1.CloseDevice()
    End Sub

    Private Sub chkEventEnabled_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEventEnabled.CheckedChanged
        If IsInitializing Then
            Exit Sub
        End If

        If chkEventEnabled.CheckState = System.Windows.Forms.CheckState.Checked Then
            DAQAI1.EventEnabled = True
        Else
            DAQAI1.EventEnabled = False
        End If
    End Sub

    Private Sub CyclicMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CyclicMode.CheckedChanged
        If IsInitializing Then
            Exit Sub
        End If

        If CyclicMode.Checked Then
            DAQAI1.CyclicMode = True
        Else
            DAQAI1.CyclicMode = False
        End If
    End Sub

    Private Sub chkOverAllGain_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOverAllGain.CheckedChanged
        If IsInitializing Then
            Exit Sub
        End If

        If chkOverAllGain.Checked Then
            cmbInputRange.Enabled = True
            cmdGainList.Enabled = False
            DAQAI1.InputRangeMode = 0
        Else
            cmbInputRange.Enabled = False
            cmdGainList.Enabled = True
            DAQAI1.InputRangeMode = 1
        End If
    End Sub

    Private Sub cmbDataType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDataType.SelectedIndexChanged
        If IsInitializing Then
            Exit Sub
        End If
        DAQAI1.DataType = cmbDataType.SelectedIndex
    End Sub

    Private Sub cmbInputRange_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbInputRange.SelectedIndexChanged
        If IsInitializing Then
            Exit Sub
        End If
        gGainCode = cmbInputRange.SelectedIndex
        DAQAI1.OverallInputRange = gGainCode
    End Sub

    Private Sub cmbNumofChannels_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNumofChannels.SelectedIndexChanged
        If IsInitializing Then
            Exit Sub
        End If
        DAQAI1.NumberOfChannels = cmbNumofChannels.SelectedIndex + 1
    End Sub

    Private Sub cmbStartChannel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStartChannel.SelectedIndexChanged
        Dim index As Short
        Dim i As Short

        If IsInitializing Then
            Exit Sub
        End If
        DAQAI1.StartChannel = cmbStartChannel.SelectedIndex
        cmbNumofChannels.Items.Clear()
        index = cmbStartChannel.Items.Count - cmbStartChannel.SelectedIndex
        For i = 1 To index
            cmbNumofChannels.Items.Add(Str(i))
        Next i
        cmbNumofChannels.SelectedIndex = 0
        DAQAI1.NumberOfChannels = 1
    End Sub

    Private Sub cmbTransferMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTransferMode.SelectedIndexChanged
        If IsInitializing Then
            Exit Sub
        End If
        DAQAI1.TransferMode = cmbTransferMode.SelectedIndex
    End Sub

    Private Sub cmdAcquireStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAcquireStart.Click
        If IsInitializing Then
            Exit Sub
        End If
        lstReading.Items.Clear()

        If DAQAI1.OpenDevice Then
            MsgBox(DAQAI1.ErrorMessage, vbOKOnly)
            Exit Sub
        End If

        If DAQAI1.InputRangeMode = 1 Then    ' 1 = adDifferentRange
            DAQAI1.InputRangeList = gGainCodeList
        Else
            DAQAI1.OverallInputRange = cmbInputRange.SelectedIndex
            If DAQAI1.OverallInputRange < 0 Then
                DAQAI1.OverallInputRange = 0
            End If
        End If
        DAQAI1.StartChannel = cmbStartChannel.SelectedIndex

        DAQAI1.SampleRate = txtSampleRate.Text
        DAQAI1.NumberOfSamples = txtNumOfSample.Text
        DAQAI1.ClockSource = cmbClockSource.SelectedIndex
        DAQAI1.ExtTrigger = False


        DAQAI1.DataType = cmbDataType.SelectedIndex

        If chkFIFOEnabled.Checked Then
            DAQAI1.FIFOEnabled = True
        Else
            DAQAI1.FIFOEnabled = False
        End If

        If cmbTriggerSource.SelectedIndex = 1 Then
            DAQAI1.ExtTrigger = True
        End If

        DAQAI1.CyclicMode = CyclicMode.Checked

        ' Start getting data
        bRet = DAQAI1.AcquireStart
        If bRet Then
            MsgBox(DAQAI1.ErrorMessage, vbOKOnly)
            Exit Sub
        End If
        ErrorTimer.Enabled = True
        cmdAutoGet.Enabled = True

        UIControl(False)
        cmdAutoGet.Enabled = True
        cmdSelectDevice.Enabled = False

    End Sub

    Private Sub cmdAutoGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAutoGet.Click
        If IsInitializing Then
            Exit Sub
        End If
        ScanTimer.Enabled = True
        cmdAcquireStop.Enabled = False
        cmdAutoGet.Enabled = False
        cmdStopAutoGet.Enabled = True
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
        End
    End Sub

    Private Sub cmdGainList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGainList.Click
        Dim fGainList As New Form2     'GainList

        fGainList.Show()

        'fGainList.Show(vbModal, Me)
    End Sub

    Private Sub cmdStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStatus.Click
        If IsInitializing Then
            Exit Sub
        End If
        txtStatus.Text = DAQAI1.AcquireStatus
    End Sub

    Private Sub cmdStopAutoGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStopAutoGet.Click
        If IsInitializing Then
            Exit Sub
        End If
        ScanTimer.Enabled = False
        cmdAutoGet.Enabled = True
        cmdAcquireStop.Enabled = True
        cmdStopAutoGet.Enabled = False
    End Sub

    Private Sub chkFIFOEnabled_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFIFOEnabled.CheckedChanged
        If IsInitializing Then
            Exit Sub
        End If

        If chkFIFOEnabled.Checked Then
            DAQAI1.FIFOEnabled = True
            txtFifoSize.Enabled = True
            txtFifoSize.Text = DAQAI1.FIFOSize
        Else
            DAQAI1.FIFOEnabled = False
            txtFifoSize.Enabled = False
        End If
    End Sub
    Private Sub ErrorTimer_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ErrorTimer.Tick
        If IsInitializing Then
            Exit Sub
        End If
        txtErrorCode.Text = CStr(DAQAI1.ErrorCode)
        txtErrorMessage.Text = DAQAI1.ErrorMessage
    End Sub

    Private Sub ScanTimer_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ScanTimer.Tick
        Dim binReadings(9) As Short
        Dim volReadings(9) As Single
        Dim i As Short
        Dim vaReturn As Object

        lstReading.Items.Clear()
        vaReturn = DAQAI1.GetBufferDataEx(0, 10)
        If DAQAI1.DataType = DAQAILib.DATA_TYPE.adRaw Then
            binReadings = vaReturn
            For i = 0 To 9
                lstReading.Items.Add(Str(binReadings(i)))
            Next i
        Else
            volReadings = vaReturn
            For i = 0 To 9
                lstReading.Items.Add(Str(volReadings(i)))
            Next i
        End If
    End Sub
    Private Sub form1_Closed(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Closed
        cmdAcquireStop.Enabled = False
        DAQAI1.AcquireStop()
        ErrorTimer.Enabled = False
        bRet = DAQAI1.CloseDevice
    End Sub

    Private Sub DAQAI1_OnEventRaw1(ByVal sender As Object, ByVal e As AxDAQAILib._DDAQAIEvents_OnEventRawEvent) Handles DAQAI1.OnEventRaw
        Dim i As Long
        Dim j As Long

        lstReading.Items.Clear()

        If e.dataCount > 10 Then
            j = 10
        Else
            j = e.dataCount
        End If

        For i = 0 To j - 1
            lstReading.Items.Add(Hex(e.data(i)))
        Next i
    End Sub

    Private Sub DAQAI1_OnTerminated1(ByVal sender As Object, ByVal e As System.EventArgs) Handles DAQAI1.OnTerminated
        Dim binData(10) As Short
        Dim volData(10) As Single
        Dim i As Integer
        Dim vaReturn As Object

        lstReading.Items.Clear()
        vaReturn = DAQAI1.GetBufferDataEx(0, 10)

        If DAQAI1.DataType = DAQAILib.DATA_TYPE.adRaw Then

            binData = vaReturn

            For i = 0 To 9
                lstReading.Items.Add(Hex(binData(i)))
            Next i

            
        Else

            volData = vaReturn
            For i = 0 To 9
                lstReading.Items.Add(Str(volData(i)))
            Next i

        End If

        DAQAI1.AcquireStop()

        UIControl(True)
        cmdSelectDevice.Enabled = True
        cmdAutoGet.Enabled = False
    End Sub

    Private Sub DAQAI1_OnEventReal1(ByVal sender As Object, ByVal e As AxDAQAILib._DDAQAIEvents_OnEventRealEvent) Handles DAQAI1.OnEventReal
        Dim i As Long
        Dim j As Long

        lstReading.Items.Clear()

        If e.dataCount > 10 Then
            j = 10
        Else
            j = e.dataCount
        End If

        For i = 0 To j - 1
            lstReading.Items.Add(Str(e.data(i)))
        Next i
    End Sub

    Private Sub UIControl(ByVal b_value As Boolean)
        cmdAcquireStart.Enabled = b_value
        cmdAcquireStop.Enabled = Not b_value
        cmdExit.Enabled = b_value

        cmbStartChannel.Enabled = b_value
        cmbNumofChannels.Enabled = b_value
        cmbInputRange.Enabled = b_value
        cmbDataType.Enabled = b_value
        chkOverAllGain.Enabled = b_value
        cmbTransferMode.Enabled = b_value
        cmbClockSource.Enabled = b_value
        cmbTriggerSource.Enabled = b_value
        txtSampleRate.Enabled = b_value
        txtNumOfSample.Enabled = b_value
        txtFifoSize.Enabled = b_value
        chkFIFOEnabled.Enabled = b_value
        chkEventEnabled.Enabled = b_value
        CyclicMode.Enabled = b_value

    End Sub
End Class
