Public Class Form1
    Inherits System.Windows.Forms.Form
   Dim gInputRangeList(12) As String

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

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
   Public WithEvents Frame1 As System.Windows.Forms.GroupBox
   Public WithEvents cmdSelectDevice As System.Windows.Forms.Button
   Public WithEvents txtDeviceName As System.Windows.Forms.TextBox
   Public WithEvents txtDeviceNum As System.Windows.Forms.TextBox
   Public WithEvents Label2 As System.Windows.Forms.Label
   Public WithEvents Label1 As System.Windows.Forms.Label
   Public WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Public WithEvents cmdExit As System.Windows.Forms.Button
   Public WithEvents Frame2 As System.Windows.Forms.GroupBox
   Public WithEvents cmbChannel As System.Windows.Forms.ComboBox
   Public WithEvents cmbDataType As System.Windows.Forms.ComboBox
   Public WithEvents cmbInputRange As System.Windows.Forms.ComboBox
   Public WithEvents Label5 As System.Windows.Forms.Label
   Public WithEvents Label4 As System.Windows.Forms.Label
   Public WithEvents Label3 As System.Windows.Forms.Label
   Public WithEvents Frame3 As System.Windows.Forms.GroupBox
   Public WithEvents cmdStop As System.Windows.Forms.Button
   Public WithEvents cmdStart As System.Windows.Forms.Button
   Public WithEvents txtScanTime As System.Windows.Forms.TextBox
   Public WithEvents cmdRead As System.Windows.Forms.Button
   Public WithEvents txtReturnData As System.Windows.Forms.TextBox
   Public WithEvents Label9 As System.Windows.Forms.Label
   Public WithEvents Label8 As System.Windows.Forms.Label
   Public WithEvents ScanTimer As System.Windows.Forms.Timer
    Friend WithEvents DAQAI1 As AxDAQAILib.AxDAQAI

   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.cmdSelectDevice = New System.Windows.Forms.Button
        Me.txtDeviceName = New System.Windows.Forms.TextBox
        Me.txtDeviceNum = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmbChannel = New System.Windows.Forms.ComboBox
        Me.cmbDataType = New System.Windows.Forms.ComboBox
        Me.cmbInputRange = New System.Windows.Forms.ComboBox
        Me.cmdStop = New System.Windows.Forms.Button
        Me.cmdStart = New System.Windows.Forms.Button
        Me.txtScanTime = New System.Windows.Forms.TextBox
        Me.cmdRead = New System.Windows.Forms.Button
        Me.txtReturnData = New System.Windows.Forms.TextBox
        Me.Frame2 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Frame3 = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.ScanTimer = New System.Windows.Forms.Timer(Me.components)
        Me.DAQAI1 = New AxDAQAILib.AxDAQAI
        Me.Frame1.SuspendLayout()
        Me.Frame2.SuspendLayout()
        Me.Frame3.SuspendLayout()
        CType(Me.DAQAI1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.cmdSelectDevice)
        Me.Frame1.Controls.Add(Me.txtDeviceName)
        Me.Frame1.Controls.Add(Me.txtDeviceNum)
        Me.Frame1.Controls.Add(Me.Label2)
        Me.Frame1.Controls.Add(Me.Label1)
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(16, 8)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(352, 81)
        Me.Frame1.TabIndex = 13
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Select Device :"
        '
        'cmdSelectDevice
        '
        Me.cmdSelectDevice.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSelectDevice.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSelectDevice.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSelectDevice.Location = New System.Drawing.Point(176, 16)
        Me.cmdSelectDevice.Name = "cmdSelectDevice"
        Me.cmdSelectDevice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSelectDevice.Size = New System.Drawing.Size(97, 25)
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
        Me.txtDeviceName.Enabled = False
        Me.txtDeviceName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDeviceName.Location = New System.Drawing.Point(88, 48)
        Me.txtDeviceName.MaxLength = 0
        Me.txtDeviceName.Name = "txtDeviceName"
        Me.txtDeviceName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDeviceName.Size = New System.Drawing.Size(256, 21)
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
        Me.txtDeviceNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDeviceNum.Location = New System.Drawing.Point(88, 21)
        Me.txtDeviceNum.MaxLength = 0
        Me.txtDeviceNum.Name = "txtDeviceNum"
        Me.txtDeviceNum.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDeviceNum.Size = New System.Drawing.Size(57, 20)
        Me.txtDeviceNum.TabIndex = 1
        Me.txtDeviceNum.Text = "-100"
        Me.ToolTip1.SetToolTip(Me.txtDeviceNum, "Device Number")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(7, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(78, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Device Name :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(5, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(66, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = " Device No :"
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExit.Location = New System.Drawing.Point(376, 56)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExit.Size = New System.Drawing.Size(64, 25)
        Me.cmdExit.TabIndex = 14
        Me.cmdExit.Text = "&Close"
        Me.ToolTip1.SetToolTip(Me.cmdExit, "Close application")
        '
        'cmbChannel
        '
        Me.cmbChannel.BackColor = System.Drawing.SystemColors.Window
        Me.cmbChannel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbChannel.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbChannel.Location = New System.Drawing.Point(80, 81)
        Me.cmbChannel.Name = "cmbChannel"
        Me.cmbChannel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbChannel.Size = New System.Drawing.Size(81, 21)
        Me.cmbChannel.TabIndex = 20
        Me.ToolTip1.SetToolTip(Me.cmbChannel, "Device Data ype")
        '
        'cmbDataType
        '
        Me.cmbDataType.BackColor = System.Drawing.SystemColors.Window
        Me.cmbDataType.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDataType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbDataType.Items.AddRange(New Object() {"Raw Data", "Real Data"})
        Me.cmbDataType.Location = New System.Drawing.Point(80, 53)
        Me.cmbDataType.Name = "cmbDataType"
        Me.cmbDataType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbDataType.Size = New System.Drawing.Size(81, 21)
        Me.cmbDataType.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.cmbDataType, "Device Data ype")
        '
        'cmbInputRange
        '
        Me.cmbInputRange.BackColor = System.Drawing.SystemColors.Window
        Me.cmbInputRange.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbInputRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbInputRange.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbInputRange.Location = New System.Drawing.Point(80, 24)
        Me.cmbInputRange.Name = "cmbInputRange"
        Me.cmbInputRange.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbInputRange.Size = New System.Drawing.Size(81, 21)
        Me.cmbInputRange.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.cmbInputRange, "Input voltage range")
        '
        'cmdStop
        '
        Me.cmdStop.BackColor = System.Drawing.SystemColors.Control
        Me.cmdStop.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdStop.Enabled = False
        Me.cmdStop.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdStop.Location = New System.Drawing.Point(128, 80)
        Me.cmdStop.Name = "cmdStop"
        Me.cmdStop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdStop.Size = New System.Drawing.Size(73, 25)
        Me.cmdStop.TabIndex = 19
        Me.cmdStop.Text = "St&op"
        Me.ToolTip1.SetToolTip(Me.cmdStop, "Stop Auto Scan")
        '
        'cmdStart
        '
        Me.cmdStart.BackColor = System.Drawing.SystemColors.Control
        Me.cmdStart.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdStart.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdStart.Location = New System.Drawing.Point(16, 80)
        Me.cmdStart.Name = "cmdStart"
        Me.cmdStart.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdStart.Size = New System.Drawing.Size(73, 25)
        Me.cmdStart.TabIndex = 18
        Me.cmdStart.Text = "St&art"
        Me.ToolTip1.SetToolTip(Me.cmdStart, "Star Auto Scan")
        '
        'txtScanTime
        '
        Me.txtScanTime.AcceptsReturn = True
        Me.txtScanTime.AutoSize = False
        Me.txtScanTime.BackColor = System.Drawing.SystemColors.Window
        Me.txtScanTime.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtScanTime.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtScanTime.Location = New System.Drawing.Point(80, 56)
        Me.txtScanTime.MaxLength = 0
        Me.txtScanTime.Name = "txtScanTime"
        Me.txtScanTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtScanTime.Size = New System.Drawing.Size(73, 19)
        Me.txtScanTime.TabIndex = 16
        Me.txtScanTime.Text = "1000"
        Me.txtScanTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtScanTime, "Auto Scan time interval")
        '
        'cmdRead
        '
        Me.cmdRead.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRead.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdRead.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRead.Location = New System.Drawing.Point(168, 21)
        Me.cmdRead.Name = "cmdRead"
        Me.cmdRead.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRead.Size = New System.Drawing.Size(57, 25)
        Me.cmdRead.TabIndex = 15
        Me.cmdRead.Text = "&Read"
        Me.ToolTip1.SetToolTip(Me.cmdRead, "Single Read action")
        '
        'txtReturnData
        '
        Me.txtReturnData.AcceptsReturn = True
        Me.txtReturnData.AutoSize = False
        Me.txtReturnData.BackColor = System.Drawing.SystemColors.Window
        Me.txtReturnData.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtReturnData.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtReturnData.Location = New System.Drawing.Point(80, 22)
        Me.txtReturnData.MaxLength = 0
        Me.txtReturnData.Name = "txtReturnData"
        Me.txtReturnData.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtReturnData.Size = New System.Drawing.Size(73, 19)
        Me.txtReturnData.TabIndex = 13
        Me.txtReturnData.Text = "0"
        Me.txtReturnData.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtReturnData, "Data Reading")
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me.cmbChannel)
        Me.Frame2.Controls.Add(Me.cmbDataType)
        Me.Frame2.Controls.Add(Me.cmbInputRange)
        Me.Frame2.Controls.Add(Me.Label5)
        Me.Frame2.Controls.Add(Me.Label4)
        Me.Frame2.Controls.Add(Me.Label3)
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(11, 92)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(176, 112)
        Me.Frame2.TabIndex = 15
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Property Settings:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(9, 83)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(53, 16)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Channel :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(9, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(62, 16)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Data Type :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(10, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Input Range :"
        '
        'Frame3
        '
        Me.Frame3.BackColor = System.Drawing.SystemColors.Control
        Me.Frame3.Controls.Add(Me.cmdStop)
        Me.Frame3.Controls.Add(Me.cmdStart)
        Me.Frame3.Controls.Add(Me.txtScanTime)
        Me.Frame3.Controls.Add(Me.cmdRead)
        Me.Frame3.Controls.Add(Me.txtReturnData)
        Me.Frame3.Controls.Add(Me.Label9)
        Me.Frame3.Controls.Add(Me.Label8)
        Me.Frame3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame3.Location = New System.Drawing.Point(200, 92)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3.Size = New System.Drawing.Size(241, 113)
        Me.Frame3.TabIndex = 16
        Me.Frame3.TabStop = False
        Me.Frame3.Text = "Single Read"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(5, 58)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(139, 16)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = " Scan Time :                  mS"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(8, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(71, 16)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Return Data :"
        '
        'ScanTimer
        '
        Me.ScanTimer.Interval = 1000
        '
        'DAQAI1
        '
        Me.DAQAI1.Enabled = True
        Me.DAQAI1.Location = New System.Drawing.Point(392, 16)
        Me.DAQAI1.Name = "DAQAI1"
        Me.DAQAI1.OcxState = CType(resources.GetObject("DAQAI1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.DAQAI1.Size = New System.Drawing.Size(33, 33)
        Me.DAQAI1.TabIndex = 17
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(453, 213)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.Frame3)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.DAQAI1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AI TIMER test"
        Me.Frame1.ResumeLayout(False)
        Me.Frame2.ResumeLayout(False)
        Me.Frame3.ResumeLayout(False)
        CType(Me.DAQAI1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

   Private Sub cmbDataType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDataType.SelectedIndexChanged
        daqai1.DataType = cmbDataType.SelectedIndex
   End Sub

   Private Sub cmbInputRange_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbInputRange.SelectedIndexChanged
        daqai1.OverallInputRange = cmbInputRange.SelectedIndex
   End Sub

   Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
      Me.Close()
      End
   End Sub

   Private Sub cmdRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRead.Click
      Dim bReading As Integer
      Dim vReading As Single
      Dim uChannel As Integer

      If daqai1.OpenDevice Then
         MsgBox(daqai1.ErrorMessage, vbOKOnly)
         Exit Sub
      End If
        uChannel = cmbChannel.SelectedIndex
        daqai1.OverallInputRange = cmbInputRange.SelectedIndex
        Select Case (cmbDataType.SelectedIndex)
            Case 0
                bReading = daqai1.RawInput(uChannel)
                txtReturnData.Text = bReading
            Case 1
                vReading = daqai1.RealInput(uChannel)
                txtReturnData.Text = vReading
        End Select
        daqai1.CloseDevice()
   End Sub

   Private Sub cmdSelectDevice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectDevice.Click
      Dim i As Integer
      Dim j As Integer
      Dim bRet As Boolean
        Dim strRange As New String("", 30)

      daqai1.SelectDevice()
      txtDeviceNum.Text = daqai1.DeviceNumber
      txtDeviceName.Text = daqai1.DeviceName
      daqai1.DeviceNumber = daqai1.DeviceNumber
      daqai1.DeviceName = daqai1.DeviceName
        cmbInputRange.ResetText()
      ' Open Device
      If daqai1.OpenDevice Then
         MsgBox(daqai1.ErrorMessage, vbOKOnly)
         Exit Sub
      End If
 
        cmbInputRange.Items.Clear()
        DAQAI1.GetFirstInputRange(strRange)
        cmbInputRange.Items.Add(strRange)
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
            MsgBox("Function Not Supported", vbOKOnly)
            DAQAI1.CloseDevice()
            Exit Sub
        End If

        cmbChannel.Items.Clear()
        For j = 0 To i - 1
            cmbChannel.Items.Add(Str(j))
        Next j
        If i <> 0 Then
            cmbChannel.SelectedIndex = 0
        End If
        DAQAI1.CloseDevice()
   End Sub

   Private Sub cmdStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStart.Click
      If daqai1.OpenDevice Then
         MsgBox(daqai1.ErrorMessage, vbOKOnly)
         Exit Sub
      End If

      cmdExit.Enabled = False
      cmdRead.Enabled = False
      cmdStart.Enabled = False
        cmdStop.Enabled = True
        cmdSelectDevice.Enabled = False
        daqai1.OverallInputRange = cmbInputRange.SelectedIndex
      ScanTimer.Enabled = True
   End Sub

   Private Sub cmdStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStop.Click
      daqai1.CloseDevice()

      cmdExit.Enabled = True
      cmdRead.Enabled = True
      cmdStart.Enabled = True
      cmdStop.Enabled = False
        ScanTimer.Enabled = False
        cmdSelectDevice.Enabled = True
   End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer
        For i = 0 To 11
            gInputRangeList(i) = New String("")
        Next
        Call cmdSelectDevice_Click(cmdSelectDevice, New System.EventArgs)
        txtDeviceNum.Text = DAQAI1.DeviceNumber
        txtDeviceName.Text = DAQAI1.DeviceName
        cmbDataType.SelectedIndex = DAQAI1.DataType
    End Sub

    Private Sub ScanTimer_Timer()
        Dim bReading As Integer
        Dim vReading As Single

        Select Case (cmbDataType.SelectedIndex)
            Case 0
                bReading = DAQAI1.RawInput(cmbChannel.SelectedIndex)
                txtReturnData.Text = bReading
            Case 1
                vReading = DAQAI1.RealInput(cmbChannel.SelectedIndex)
                txtReturnData.Text = vReading
        End Select
    End Sub

    Private Sub txtScanTime_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScanTime.TextChanged
        ScanTimer.Interval = Val(txtScanTime.Text)
    End Sub
    Private Sub ScanTimer_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ScanTimer.Tick
        Dim bReading As Short
        Dim vReading As Single

        Select Case (cmbDataType.SelectedIndex)
            Case 0
                bReading = DAQAI1.RawInput(cmbChannel.SelectedIndex)
                txtReturnData.Text = CStr(bReading)
            Case 1
                vReading = DAQAI1.RealInput(cmbChannel.SelectedIndex)
                txtReturnData.Text = CStr(vReading)
        End Select
    End Sub

End Class
