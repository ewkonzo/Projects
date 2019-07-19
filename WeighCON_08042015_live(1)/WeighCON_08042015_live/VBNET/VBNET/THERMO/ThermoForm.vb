Public Class frmThermo
    Inherits System.Windows.Forms.Form
    Dim GainCode As Short
    '   Dim GainCodeList(16) As Short
    Dim NumOfInputRange As Short
    Dim InputRangeList(30) As String
    ' Dim InputRangeList As New String("", 30)
    Dim Reading As Boolean
    Dim SampleNumber As Integer
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
    Public WithEvents cmdExit As System.Windows.Forms.Button
    Public WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents cmbDasChannel As System.Windows.Forms.ComboBox
    Public WithEvents txtDaughterName As System.Windows.Forms.TextBox
    Public WithEvents cmbSelectDaughter As System.Windows.Forms.Button
    Public WithEvents cmbDaughterChannel As System.Windows.Forms.ComboBox
    Public WithEvents cmbThermoScale As System.Windows.Forms.ComboBox
    Public WithEvents cmbThermoType As System.Windows.Forms.ComboBox
    Public WithEvents cmbInputRange As System.Windows.Forms.ComboBox
    Public WithEvents Line1 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents txtDeviceNum As System.Windows.Forms.TextBox
    Public WithEvents txtDeviceName As System.Windows.Forms.TextBox
    Public WithEvents cmdSelectDevice As System.Windows.Forms.Button
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Frame4 As System.Windows.Forms.GroupBox
    Public WithEvents txtSampleNumber As System.Windows.Forms.TextBox
    Public WithEvents txtThermoReading As System.Windows.Forms.TextBox
    Public WithEvents hscrlFreq As System.Windows.Forms.HScrollBar
    Public WithEvents cmdThermoStop As System.Windows.Forms.Button
    Public WithEvents cmdThermoStart As System.Windows.Forms.Button
    Public WithEvents Label13 As System.Windows.Forms.Label
    Public WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents ScanTimer As System.Windows.Forms.Timer
    Friend WithEvents txtErrCode As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents DAQAI1 As AxDAQAILib.AxDAQAI
    Public WithEvents FrameProperty As System.Windows.Forms.GroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmThermo))
        Me.cmdExit = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmbInputRange = New System.Windows.Forms.ComboBox
        Me.txtDeviceNum = New System.Windows.Forms.TextBox
        Me.txtDeviceName = New System.Windows.Forms.TextBox
        Me.cmdSelectDevice = New System.Windows.Forms.Button
        Me.cmdThermoStop = New System.Windows.Forms.Button
        Me.cmdThermoStart = New System.Windows.Forms.Button
        Me.FrameProperty = New System.Windows.Forms.GroupBox
        Me.cmbDasChannel = New System.Windows.Forms.ComboBox
        Me.txtDaughterName = New System.Windows.Forms.TextBox
        Me.cmbSelectDaughter = New System.Windows.Forms.Button
        Me.cmbDaughterChannel = New System.Windows.Forms.ComboBox
        Me.cmbThermoScale = New System.Windows.Forms.ComboBox
        Me.cmbThermoType = New System.Windows.Forms.ComboBox
        Me.Line1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Frame4 = New System.Windows.Forms.GroupBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtErrCode = New System.Windows.Forms.TextBox
        Me.txtSampleNumber = New System.Windows.Forms.TextBox
        Me.txtThermoReading = New System.Windows.Forms.TextBox
        Me.hscrlFreq = New System.Windows.Forms.HScrollBar
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.ScanTimer = New System.Windows.Forms.Timer(Me.components)
        Me.DAQAI1 = New AxDAQAILib.AxDAQAI
        Me.FrameProperty.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.Frame4.SuspendLayout()
        CType(Me.DAQAI1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExit.Location = New System.Drawing.Point(384, 56)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExit.Size = New System.Drawing.Size(89, 25)
        Me.cmdExit.TabIndex = 43
        Me.cmdExit.Text = "&Close"
        Me.ToolTip1.SetToolTip(Me.cmdExit, "Close application")
        '
        'cmbInputRange
        '
        Me.cmbInputRange.BackColor = System.Drawing.SystemColors.Window
        Me.cmbInputRange.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbInputRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbInputRange.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbInputRange.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbInputRange.Location = New System.Drawing.Point(112, 24)
        Me.cmbInputRange.Name = "cmbInputRange"
        Me.cmbInputRange.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbInputRange.Size = New System.Drawing.Size(105, 22)
        Me.cmbInputRange.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.cmbInputRange, "Input voltage range")
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
        Me.txtDeviceNum.TabIndex = 3
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
        Me.txtDeviceName.Size = New System.Drawing.Size(272, 19)
        Me.txtDeviceName.TabIndex = 2
        Me.txtDeviceName.Text = "AdvanTech"
        Me.ToolTip1.SetToolTip(Me.txtDeviceName, "Device Name")
        '
        'cmdSelectDevice
        '
        Me.cmdSelectDevice.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSelectDevice.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSelectDevice.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSelectDevice.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSelectDevice.Location = New System.Drawing.Point(264, 16)
        Me.cmdSelectDevice.Name = "cmdSelectDevice"
        Me.cmdSelectDevice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSelectDevice.Size = New System.Drawing.Size(97, 25)
        Me.cmdSelectDevice.TabIndex = 1
        Me.cmdSelectDevice.Text = "&Select Device"
        Me.ToolTip1.SetToolTip(Me.cmdSelectDevice, "Selecting device to operation")
        '
        'cmdThermoStop
        '
        Me.cmdThermoStop.BackColor = System.Drawing.SystemColors.Control
        Me.cmdThermoStop.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdThermoStop.Enabled = False
        Me.cmdThermoStop.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdThermoStop.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdThermoStop.Location = New System.Drawing.Point(104, 24)
        Me.cmdThermoStop.Name = "cmdThermoStop"
        Me.cmdThermoStop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdThermoStop.Size = New System.Drawing.Size(73, 25)
        Me.cmdThermoStop.TabIndex = 12
        Me.cmdThermoStop.Text = "St&op"
        Me.ToolTip1.SetToolTip(Me.cmdThermoStop, "Stop Auto Scan")
        '
        'cmdThermoStart
        '
        Me.cmdThermoStart.BackColor = System.Drawing.SystemColors.Control
        Me.cmdThermoStart.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdThermoStart.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdThermoStart.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdThermoStart.Location = New System.Drawing.Point(16, 24)
        Me.cmdThermoStart.Name = "cmdThermoStart"
        Me.cmdThermoStart.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdThermoStart.Size = New System.Drawing.Size(73, 25)
        Me.cmdThermoStart.TabIndex = 11
        Me.cmdThermoStart.Text = "St&art"
        Me.ToolTip1.SetToolTip(Me.cmdThermoStart, "Star Auto Scan")
        '
        'FrameProperty
        '
        Me.FrameProperty.BackColor = System.Drawing.SystemColors.Control
        Me.FrameProperty.Controls.Add(Me.cmbDasChannel)
        Me.FrameProperty.Controls.Add(Me.txtDaughterName)
        Me.FrameProperty.Controls.Add(Me.cmbSelectDaughter)
        Me.FrameProperty.Controls.Add(Me.cmbDaughterChannel)
        Me.FrameProperty.Controls.Add(Me.cmbThermoScale)
        Me.FrameProperty.Controls.Add(Me.cmbThermoType)
        Me.FrameProperty.Controls.Add(Me.cmbInputRange)
        Me.FrameProperty.Controls.Add(Me.Line1)
        Me.FrameProperty.Controls.Add(Me.Label4)
        Me.FrameProperty.Controls.Add(Me.Label12)
        Me.FrameProperty.Controls.Add(Me.Label11)
        Me.FrameProperty.Controls.Add(Me.Label9)
        Me.FrameProperty.Controls.Add(Me.Label7)
        Me.FrameProperty.Controls.Add(Me.Label3)
        Me.FrameProperty.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FrameProperty.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FrameProperty.Location = New System.Drawing.Point(8, 96)
        Me.FrameProperty.Name = "FrameProperty"
        Me.FrameProperty.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FrameProperty.Size = New System.Drawing.Size(248, 241)
        Me.FrameProperty.TabIndex = 44
        Me.FrameProperty.TabStop = False
        Me.FrameProperty.Text = "Property Settings:"
        '
        'cmbDasChannel
        '
        Me.cmbDasChannel.BackColor = System.Drawing.SystemColors.Window
        Me.cmbDasChannel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbDasChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDasChannel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDasChannel.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbDasChannel.Location = New System.Drawing.Point(112, 96)
        Me.cmbDasChannel.Name = "cmbDasChannel"
        Me.cmbDasChannel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbDasChannel.Size = New System.Drawing.Size(105, 22)
        Me.cmbDasChannel.TabIndex = 28
        '
        'txtDaughterName
        '
        Me.txtDaughterName.AcceptsReturn = True
        Me.txtDaughterName.AutoSize = False
        Me.txtDaughterName.BackColor = System.Drawing.SystemColors.Window
        Me.txtDaughterName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDaughterName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDaughterName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDaughterName.Location = New System.Drawing.Point(112, 168)
        Me.txtDaughterName.MaxLength = 0
        Me.txtDaughterName.Name = "txtDaughterName"
        Me.txtDaughterName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDaughterName.Size = New System.Drawing.Size(105, 25)
        Me.txtDaughterName.TabIndex = 22
        Me.txtDaughterName.Text = ""
        '
        'cmbSelectDaughter
        '
        Me.cmbSelectDaughter.BackColor = System.Drawing.SystemColors.Control
        Me.cmbSelectDaughter.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbSelectDaughter.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSelectDaughter.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbSelectDaughter.Location = New System.Drawing.Point(112, 136)
        Me.cmbSelectDaughter.Name = "cmbSelectDaughter"
        Me.cmbSelectDaughter.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbSelectDaughter.Size = New System.Drawing.Size(105, 25)
        Me.cmbSelectDaughter.TabIndex = 20
        Me.cmbSelectDaughter.Text = "Select Daughter"
        '
        'cmbDaughterChannel
        '
        Me.cmbDaughterChannel.BackColor = System.Drawing.SystemColors.Window
        Me.cmbDaughterChannel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbDaughterChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDaughterChannel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDaughterChannel.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbDaughterChannel.Location = New System.Drawing.Point(112, 208)
        Me.cmbDaughterChannel.Name = "cmbDaughterChannel"
        Me.cmbDaughterChannel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbDaughterChannel.Size = New System.Drawing.Size(105, 22)
        Me.cmbDaughterChannel.TabIndex = 18
        '
        'cmbThermoScale
        '
        Me.cmbThermoScale.BackColor = System.Drawing.SystemColors.Window
        Me.cmbThermoScale.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbThermoScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbThermoScale.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbThermoScale.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbThermoScale.Location = New System.Drawing.Point(112, 72)
        Me.cmbThermoScale.Name = "cmbThermoScale"
        Me.cmbThermoScale.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbThermoScale.Size = New System.Drawing.Size(105, 22)
        Me.cmbThermoScale.TabIndex = 16
        '
        'cmbThermoType
        '
        Me.cmbThermoType.BackColor = System.Drawing.SystemColors.Window
        Me.cmbThermoType.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbThermoType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbThermoType.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbThermoType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbThermoType.Location = New System.Drawing.Point(112, 48)
        Me.cmbThermoType.Name = "cmbThermoType"
        Me.cmbThermoType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbThermoType.Size = New System.Drawing.Size(105, 22)
        Me.cmbThermoType.TabIndex = 14
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.SystemColors.WindowText
        Me.Line1.Location = New System.Drawing.Point(0, 128)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(248, 1)
        Me.Line1.TabIndex = 29
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(16, 176)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(89, 17)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Daughter Name:"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(16, 208)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(97, 17)
        Me.Label12.TabIndex = 19
        Me.Label12.Text = "Daughter Channel:"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(12, 104)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(89, 17)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "Das Channel:"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(11, 80)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(80, 17)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Thermo Scale:"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(11, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(81, 17)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Thermo Type:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(12, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(97, 16)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Input Range(Gain):"
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
        Me.Frame1.Location = New System.Drawing.Point(8, 8)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(368, 79)
        Me.Frame1.TabIndex = 42
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
        Me.Label1.TabIndex = 5
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
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Device Name :"
        '
        'Frame4
        '
        Me.Frame4.BackColor = System.Drawing.SystemColors.Control
        Me.Frame4.Controls.Add(Me.Label14)
        Me.Frame4.Controls.Add(Me.txtErrCode)
        Me.Frame4.Controls.Add(Me.txtSampleNumber)
        Me.Frame4.Controls.Add(Me.txtThermoReading)
        Me.Frame4.Controls.Add(Me.hscrlFreq)
        Me.Frame4.Controls.Add(Me.cmdThermoStop)
        Me.Frame4.Controls.Add(Me.cmdThermoStart)
        Me.Frame4.Controls.Add(Me.Label13)
        Me.Frame4.Controls.Add(Me.Label10)
        Me.Frame4.Controls.Add(Me.Label8)
        Me.Frame4.Controls.Add(Me.Label6)
        Me.Frame4.Controls.Add(Me.Label5)
        Me.Frame4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame4.Location = New System.Drawing.Point(272, 96)
        Me.Frame4.Name = "Frame4"
        Me.Frame4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame4.Size = New System.Drawing.Size(208, 241)
        Me.Frame4.TabIndex = 45
        Me.Frame4.TabStop = False
        Me.Frame4.Text = "Thermo Read:"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(8, 192)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 16)
        Me.Label14.TabIndex = 33
        Me.Label14.Text = "Error Message"
        '
        'txtErrCode
        '
        Me.txtErrCode.Location = New System.Drawing.Point(8, 208)
        Me.txtErrCode.Name = "txtErrCode"
        Me.txtErrCode.ReadOnly = True
        Me.txtErrCode.Size = New System.Drawing.Size(192, 20)
        Me.txtErrCode.TabIndex = 32
        Me.txtErrCode.Text = ""
        '
        'txtSampleNumber
        '
        Me.txtSampleNumber.AcceptsReturn = True
        Me.txtSampleNumber.AutoSize = False
        Me.txtSampleNumber.BackColor = System.Drawing.SystemColors.Window
        Me.txtSampleNumber.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSampleNumber.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSampleNumber.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSampleNumber.Location = New System.Drawing.Point(104, 120)
        Me.txtSampleNumber.MaxLength = 0
        Me.txtSampleNumber.Name = "txtSampleNumber"
        Me.txtSampleNumber.ReadOnly = True
        Me.txtSampleNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSampleNumber.Size = New System.Drawing.Size(72, 25)
        Me.txtSampleNumber.TabIndex = 30
        Me.txtSampleNumber.Text = "0"
        Me.txtSampleNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtThermoReading
        '
        Me.txtThermoReading.AcceptsReturn = True
        Me.txtThermoReading.AutoSize = False
        Me.txtThermoReading.BackColor = System.Drawing.SystemColors.Window
        Me.txtThermoReading.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtThermoReading.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtThermoReading.ForeColor = System.Drawing.Color.Blue
        Me.txtThermoReading.Location = New System.Drawing.Point(104, 160)
        Me.txtThermoReading.MaxLength = 0
        Me.txtThermoReading.Name = "txtThermoReading"
        Me.txtThermoReading.ReadOnly = True
        Me.txtThermoReading.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtThermoReading.Size = New System.Drawing.Size(72, 25)
        Me.txtThermoReading.TabIndex = 26
        Me.txtThermoReading.Text = ""
        Me.txtThermoReading.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'hscrlFreq
        '
        Me.hscrlFreq.Cursor = System.Windows.Forms.Cursors.Default
        Me.hscrlFreq.LargeChange = 1
        Me.hscrlFreq.Location = New System.Drawing.Point(16, 72)
        Me.hscrlFreq.Minimum = 1
        Me.hscrlFreq.Name = "hscrlFreq"
        Me.hscrlFreq.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.hscrlFreq.Size = New System.Drawing.Size(160, 17)
        Me.hscrlFreq.TabIndex = 23
        Me.hscrlFreq.TabStop = True
        Me.hscrlFreq.Value = 10
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.Control
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(128, 96)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(56, 16)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "100 time/s"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(8, 128)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(88, 16)
        Me.Label10.TabIndex = 29
        Me.Label10.Text = "Sample Number:"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(16, 96)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(16, 16)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "1"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(8, 160)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(97, 16)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Thermo Reading:"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(16, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(80, 17)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Polling Rate:"
        '
        'ScanTimer
        '
        Me.ScanTimer.Interval = 1
        '
        'DAQAI1
        '
        Me.DAQAI1.Enabled = True
        Me.DAQAI1.Location = New System.Drawing.Point(416, 8)
        Me.DAQAI1.Name = "DAQAI1"
        Me.DAQAI1.OcxState = CType(resources.GetObject("DAQAI1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.DAQAI1.Size = New System.Drawing.Size(33, 33)
        Me.DAQAI1.TabIndex = 46
        '
        'frmThermo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(488, 349)
        Me.Controls.Add(Me.DAQAI1)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.Frame4)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.FrameProperty)
        Me.MaximizeBox = False
        Me.Name = "frmThermo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "thermo"
        Me.FrameProperty.ResumeLayout(False)
        Me.Frame1.ResumeLayout(False)
        Me.Frame4.ResumeLayout(False)
        CType(Me.DAQAI1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cmbInputRange_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbInputRange.SelectedIndexChanged
        If (IsInitializing) Then
            Exit Sub
        End If

        DAQAI1.ThermoDasGain = cmbInputRange.SelectedIndex
    End Sub

    Private Sub cmbDasChannel_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbDasChannel.SelectedIndexChanged
        If (IsInitializing) Then
            Exit Sub
        End If
        DAQAI1.ThermoDasChannel = cmbDasChannel.SelectedIndex
    End Sub



    Private Sub cmbDaughterChannel_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbDaughterChannel.SelectedIndexChanged
        If (IsInitializing) Then
            Exit Sub
        End If
        DAQAI1.DaughterChannel = cmbDaughterChannel.SelectedIndex
    End Sub

    Private Sub cmbSelectDaughter_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbSelectDaughter.Click
        Dim j As Object

        Dim ThermoDasChannel = DAQAI1.SelectDaughter()

        txtDaughterName.Enabled = True
        cmbDaughterChannel.Enabled = True

        cmbDaughterChannel.Items.Clear()
        For j = 0 To 31
            cmbDaughterChannel.Items.Add((Str(j)))
        Next j

        txtDaughterName.Text = DAQAI1.DaughterName
        cmbDaughterChannel.SelectedIndex = 0
        cmbDasChannel.SelectedIndex = DAQAI1.ThermoDasChannel
        txtErrCode.Text = DAQAI1.ErrorMessage


    End Sub

    Private Sub cmbThermoScale_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbThermoScale.SelectedIndexChanged
        If (IsInitializing) Then
            Exit Sub
        End If
        DAQAI1.ThermoScale = cmbThermoScale.SelectedIndex
    End Sub

    Private Sub cmbThermoType_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbThermoType.SelectedIndexChanged
        If (IsInitializing) Then
            Exit Sub
        End If
        DAQAI1.ThermoType = cmbThermoType.SelectedIndex
    End Sub



    Private Sub frmThermo_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        ' Add selectable items of Thermocouple type
        cmbThermoType.Items.Add("J type") ' 0
        cmbThermoType.Items.Add("K type") ' 1
        cmbThermoType.Items.Add("S type") ' 2
        cmbThermoType.Items.Add("T type") ' 3
        cmbThermoType.Items.Add("B type") ' 4
        cmbThermoType.Items.Add("R type") ' 5
        cmbThermoType.Items.Add("E type") ' 6

        ' Set the default selection of thermocouple type
        cmbThermoType.SelectedIndex = 0
        DAQAI1.ThermoType = 0

        ' Add selectable items of Thermocouple scale
        cmbThermoScale.Items.Add("C") ' 0
        cmbThermoScale.Items.Add("F") ' 1
        cmbThermoScale.Items.Add("R") ' 2
        cmbThermoScale.Items.Add("K") ' 3

        ' Set the default selection of thermocouple type
        cmbThermoScale.SelectedIndex = 0
        DAQAI1.ThermoScale = 0
        ' Disable Daughter Board
        txtDaughterName.Enabled = False
        cmbDaughterChannel.Enabled = False

        ' Select default device
        Call cmdSelectDevice_Click(cmdSelectDevice, New System.EventArgs)


    End Sub

    Private Sub cmdSelectDevice_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSelectDevice.Click
        Dim i As Short
        Dim j As Short
        Dim bRet As Boolean
        Dim strRange As New String("", 30)

        DAQAI1.SelectDevice()
        txtDeviceNum.Text = CStr(DAQAI1.DeviceNumber)
        txtDeviceName.Text = DAQAI1.DeviceName
        cmbInputRange.Items.Clear()
        cmbDasChannel.Items.Clear()

        ' Open device
        If DAQAI1.OpenDevice Then
            MsgBox(DAQAI1.ErrorMessage, MsgBoxStyle.OKOnly)
            Exit Sub
        End If
        ' Get input range list
        DAQAI1.GetFirstInputRange(strRange)
        cmbInputRange.Items.Add(strRange)
        While (DAQAI1.GetNextInputRange(strRange) = False)
            cmbInputRange.Items.Add(strRange)
        End While
        cmbInputRange.SelectedIndex = 0

        For j = 0 To NumOfInputRange - 1

        Next j
        If NumOfInputRange <> 0 Then
            cmbInputRange.SelectedIndex = 0
            DAQAI1.ThermoDasGain = 0
        End If
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

        For j = 0 To i - 1
            cmbDasChannel.Items.Add((Str(j)))
        Next j
        If i <> 0 Then
            cmbDasChannel.SelectedIndex = 0
        End If
        txtDaughterName.Text = DAQAI1.DaughterName

        DAQAI1.CloseDevice()
    End Sub



    Private Sub cmdThermoStart_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdThermoStart.Click
        If DAQAI1.OpenDevice Then
            MsgBox(DAQAI1.ErrorMessage, MsgBoxStyle.OKOnly)
            Exit Sub
        End If
        cmdThermoStart.Enabled = False
        cmdThermoStop.Enabled = True
        cmdExit.Enabled = False
        cmdSelectDevice.Enabled = False

        ' Start getting data
        ScanTimer.Enabled = True
        FrameProperty.Enabled = False
        ScanTimer.Interval = 1000 / hscrlFreq.Value
    End Sub

    Private Sub cmdThermoStop_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdThermoStop.Click
        ' Stop get data
        ScanTimer.Enabled = False
        cmdSelectDevice.Enabled = True

        ' Close device
        DAQAI1.CloseDevice()

        FrameProperty.Enabled = True
        cmdThermoStart.Enabled = True
        cmdThermoStop.Enabled = False
        cmdExit.Enabled = True
    End Sub

    Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
        Me.Close()
        End
    End Sub

    Private Sub hscrlFreq_Change(ByVal newScrollValue As Integer)

        If newScrollValue = 0 Then
            ScanTimer.Interval = 1000
        Else
            ScanTimer.Interval = 1000 / newScrollValue
        End If
    End Sub



    Private Sub ScanTimer_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ScanTimer.Tick
        txtThermoReading.Text = Format(DAQAI1.ThermoRead, "0.000")
        SampleNumber = SampleNumber + 1
        txtSampleNumber.Text = Str(SampleNumber)
        txtErrCode.Text = DAQAI1.ErrorMessage
    End Sub

    Private Sub txtDeviceNum_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtDeviceNum.TextChanged
        If (IsInitializing) Then
            Exit Sub
        End If
        DAQAI1.DeviceNumber = Val(txtDeviceNum.Text)
        txtDeviceName.Text = DAQAI1.DeviceName
    End Sub
    Private Sub hscrlFreq_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles hscrlFreq.Scroll

        Select Case eventArgs.Type
            Case System.Windows.Forms.ScrollEventType.EndScroll
                hscrlFreq_Change(eventArgs.NewValue)
        End Select
    End Sub
End Class

