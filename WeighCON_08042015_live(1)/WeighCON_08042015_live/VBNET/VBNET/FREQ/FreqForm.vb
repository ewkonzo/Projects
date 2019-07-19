Public Class frmFreq
    Inherits System.Windows.Forms.Form
    Dim isInitializing As Boolean

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        isInitializing = True
        InitializeComponent()
        isInitializing = False

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
    Friend WithEvents ScanTimer As System.Windows.Forms.Timer
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtError As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSelectDevice As System.Windows.Forms.Button
    Friend WithEvents txtDeviceNum As System.Windows.Forms.TextBox
    Friend WithEvents txtDeviceName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtScanTime As System.Windows.Forms.TextBox
    Friend WithEvents cmbGateMode As System.Windows.Forms.ComboBox
    Friend WithEvents cmbChannel As System.Windows.Forms.ComboBox
    Friend WithEvents cmdScanStop As System.Windows.Forms.Button
    Friend WithEvents cmdScanStart As System.Windows.Forms.Button
    Friend WithEvents txtGatePeriod As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtFreq As System.Windows.Forms.TextBox
   Friend WithEvents DAQCounter1 As AxDAQCounterLib.AxDAQCounter
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmFreq))
      Me.ScanTimer = New System.Windows.Forms.Timer(Me.components)
      Me.cmdExit = New System.Windows.Forms.Button
      Me.GroupBox3 = New System.Windows.Forms.GroupBox
      Me.Label8 = New System.Windows.Forms.Label
      Me.Label7 = New System.Windows.Forms.Label
      Me.txtError = New System.Windows.Forms.TextBox
      Me.txtFreq = New System.Windows.Forms.TextBox
      Me.cmdScanStop = New System.Windows.Forms.Button
      Me.cmdScanStart = New System.Windows.Forms.Button
      Me.GroupBox1 = New System.Windows.Forms.GroupBox
      Me.cmdSelectDevice = New System.Windows.Forms.Button
      Me.txtDeviceNum = New System.Windows.Forms.TextBox
      Me.txtDeviceName = New System.Windows.Forms.TextBox
      Me.Label2 = New System.Windows.Forms.Label
      Me.Label1 = New System.Windows.Forms.Label
      Me.GroupBox2 = New System.Windows.Forms.GroupBox
      Me.Label11 = New System.Windows.Forms.Label
      Me.Label10 = New System.Windows.Forms.Label
      Me.Label9 = New System.Windows.Forms.Label
      Me.txtGatePeriod = New System.Windows.Forms.TextBox
      Me.Label6 = New System.Windows.Forms.Label
      Me.Label5 = New System.Windows.Forms.Label
      Me.Label4 = New System.Windows.Forms.Label
      Me.Label3 = New System.Windows.Forms.Label
      Me.txtScanTime = New System.Windows.Forms.TextBox
      Me.cmbGateMode = New System.Windows.Forms.ComboBox
      Me.cmbChannel = New System.Windows.Forms.ComboBox
      Me.DAQCounter1 = New AxDAQCounterLib.AxDAQCounter
      Me.GroupBox3.SuspendLayout()
      Me.GroupBox1.SuspendLayout()
      Me.GroupBox2.SuspendLayout()
      CType(Me.DAQCounter1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'ScanTimer
      '
      '
      'cmdExit
      '
      Me.cmdExit.Location = New System.Drawing.Point(384, 56)
      Me.cmdExit.Name = "cmdExit"
      Me.cmdExit.Size = New System.Drawing.Size(88, 24)
      Me.cmdExit.TabIndex = 8
      Me.cmdExit.Text = "Close"
      '
      'GroupBox3
      '
      Me.GroupBox3.Controls.Add(Me.Label8)
      Me.GroupBox3.Controls.Add(Me.Label7)
      Me.GroupBox3.Controls.Add(Me.txtError)
      Me.GroupBox3.Controls.Add(Me.txtFreq)
      Me.GroupBox3.Controls.Add(Me.cmdScanStop)
      Me.GroupBox3.Controls.Add(Me.cmdScanStart)
      Me.GroupBox3.Location = New System.Drawing.Point(288, 96)
      Me.GroupBox3.Name = "GroupBox3"
      Me.GroupBox3.Size = New System.Drawing.Size(192, 128)
      Me.GroupBox3.TabIndex = 7
      Me.GroupBox3.TabStop = False
      Me.GroupBox3.Text = "Freq Read:"
      '
      'Label8
      '
      Me.Label8.Location = New System.Drawing.Point(11, 96)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(88, 16)
      Me.Label8.TabIndex = 5
      Me.Label8.Text = "Error Message:"
      '
      'Label7
      '
      Me.Label7.Location = New System.Drawing.Point(11, 64)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(80, 16)
      Me.Label7.TabIndex = 4
      Me.Label7.Text = "Freq value:"
      '
      'txtError
      '
      Me.txtError.ForeColor = System.Drawing.SystemColors.HotTrack
      Me.txtError.Location = New System.Drawing.Point(107, 96)
      Me.txtError.Name = "txtError"
      Me.txtError.ReadOnly = True
      Me.txtError.Size = New System.Drawing.Size(77, 20)
      Me.txtError.TabIndex = 3
      Me.txtError.Text = ""
      '
      'txtFreq
      '
      Me.txtFreq.ForeColor = System.Drawing.SystemColors.HotTrack
      Me.txtFreq.Location = New System.Drawing.Point(107, 64)
      Me.txtFreq.Name = "txtFreq"
      Me.txtFreq.ReadOnly = True
      Me.txtFreq.Size = New System.Drawing.Size(77, 20)
      Me.txtFreq.TabIndex = 2
      Me.txtFreq.Text = ""
      '
      'cmdScanStop
      '
      Me.cmdScanStop.Location = New System.Drawing.Point(104, 24)
      Me.cmdScanStop.Name = "cmdScanStop"
      Me.cmdScanStop.Size = New System.Drawing.Size(80, 24)
      Me.cmdScanStop.TabIndex = 1
      Me.cmdScanStop.Text = "Scan Stop"
      '
      'cmdScanStart
      '
      Me.cmdScanStart.Location = New System.Drawing.Point(13, 24)
      Me.cmdScanStart.Name = "cmdScanStart"
      Me.cmdScanStart.Size = New System.Drawing.Size(80, 24)
      Me.cmdScanStart.TabIndex = 0
      Me.cmdScanStart.Text = "Scan Start"
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.cmdSelectDevice)
      Me.GroupBox1.Controls.Add(Me.txtDeviceNum)
      Me.GroupBox1.Controls.Add(Me.txtDeviceName)
      Me.GroupBox1.Controls.Add(Me.Label2)
      Me.GroupBox1.Controls.Add(Me.Label1)
      Me.GroupBox1.Location = New System.Drawing.Point(16, 8)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(352, 80)
      Me.GroupBox1.TabIndex = 5
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Select Device :"
      '
      'cmdSelectDevice
      '
      Me.cmdSelectDevice.Location = New System.Drawing.Point(240, 16)
      Me.cmdSelectDevice.Name = "cmdSelectDevice"
      Me.cmdSelectDevice.Size = New System.Drawing.Size(88, 24)
      Me.cmdSelectDevice.TabIndex = 4
      Me.cmdSelectDevice.Text = "Select Device"
      '
      'txtDeviceNum
      '
      Me.txtDeviceNum.Location = New System.Drawing.Point(96, 24)
      Me.txtDeviceNum.Name = "txtDeviceNum"
      Me.txtDeviceNum.Size = New System.Drawing.Size(56, 20)
      Me.txtDeviceNum.TabIndex = 3
      Me.txtDeviceNum.Text = "0"
      '
      'txtDeviceName
      '
      Me.txtDeviceName.Location = New System.Drawing.Point(96, 48)
      Me.txtDeviceName.Name = "txtDeviceName"
      Me.txtDeviceName.ReadOnly = True
      Me.txtDeviceName.Size = New System.Drawing.Size(248, 20)
      Me.txtDeviceName.TabIndex = 2
      Me.txtDeviceName.Text = "No Device!"
      '
      'Label2
      '
      Me.Label2.Location = New System.Drawing.Point(9, 48)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(80, 16)
      Me.Label2.TabIndex = 1
      Me.Label2.Text = "Device Name :"
      '
      'Label1
      '
      Me.Label1.Location = New System.Drawing.Point(9, 24)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(64, 16)
      Me.Label1.TabIndex = 0
      Me.Label1.Text = "Device No. :"
      '
      'GroupBox2
      '
      Me.GroupBox2.Controls.Add(Me.Label11)
      Me.GroupBox2.Controls.Add(Me.Label10)
      Me.GroupBox2.Controls.Add(Me.Label9)
      Me.GroupBox2.Controls.Add(Me.txtGatePeriod)
      Me.GroupBox2.Controls.Add(Me.Label6)
      Me.GroupBox2.Controls.Add(Me.Label5)
      Me.GroupBox2.Controls.Add(Me.Label4)
      Me.GroupBox2.Controls.Add(Me.Label3)
      Me.GroupBox2.Controls.Add(Me.txtScanTime)
      Me.GroupBox2.Controls.Add(Me.cmbGateMode)
      Me.GroupBox2.Controls.Add(Me.cmbChannel)
      Me.GroupBox2.Location = New System.Drawing.Point(16, 96)
      Me.GroupBox2.Name = "GroupBox2"
      Me.GroupBox2.Size = New System.Drawing.Size(264, 128)
      Me.GroupBox2.TabIndex = 6
      Me.GroupBox2.TabStop = False
      Me.GroupBox2.Text = "Property Settings:"
      '
      'Label11
      '
      Me.Label11.Location = New System.Drawing.Point(160, 48)
      Me.Label11.Name = "Label11"
      Me.Label11.Size = New System.Drawing.Size(96, 16)
      Me.Label11.TabIndex = 10
      Me.Label11.Text = "(only for PCL830)"
      '
      'Label10
      '
      Me.Label10.Location = New System.Drawing.Point(144, 72)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(112, 16)
      Me.Label10.TabIndex = 9
      Me.Label10.Text = "ms (only for PCL830)"
      '
      'Label9
      '
      Me.Label9.Location = New System.Drawing.Point(8, 70)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(72, 16)
      Me.Label9.TabIndex = 8
      Me.Label9.Text = "Gate Period:"
      '
      'txtGatePeriod
      '
      Me.txtGatePeriod.Location = New System.Drawing.Point(82, 72)
      Me.txtGatePeriod.Name = "txtGatePeriod"
      Me.txtGatePeriod.Size = New System.Drawing.Size(56, 20)
      Me.txtGatePeriod.TabIndex = 7
      Me.txtGatePeriod.Text = "0"
      '
      'Label6
      '
      Me.Label6.Location = New System.Drawing.Point(136, 96)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(24, 16)
      Me.Label6.TabIndex = 6
      Me.Label6.Text = "ms"
      '
      'Label5
      '
      Me.Label5.Location = New System.Drawing.Point(8, 93)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(64, 16)
      Me.Label5.TabIndex = 5
      Me.Label5.Text = "Scan Time: "
      '
      'Label4
      '
      Me.Label4.Location = New System.Drawing.Point(8, 47)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(64, 16)
      Me.Label4.TabIndex = 4
      Me.Label4.Text = "Gate Mode:"
      '
      'Label3
      '
      Me.Label3.Location = New System.Drawing.Point(8, 24)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(64, 16)
      Me.Label3.TabIndex = 3
      Me.Label3.Text = "Channel:"
      '
      'txtScanTime
      '
      Me.txtScanTime.Location = New System.Drawing.Point(82, 96)
      Me.txtScanTime.Name = "txtScanTime"
      Me.txtScanTime.Size = New System.Drawing.Size(56, 20)
      Me.txtScanTime.TabIndex = 2
      Me.txtScanTime.Text = "1000"
      '
      'cmbGateMode
      '
      Me.cmbGateMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbGateMode.Items.AddRange(New Object() {"no gating", "high level", "low level", "rising edge", "falling edge"})
      Me.cmbGateMode.Location = New System.Drawing.Point(82, 48)
      Me.cmbGateMode.Name = "cmbGateMode"
      Me.cmbGateMode.Size = New System.Drawing.Size(80, 21)
      Me.cmbGateMode.TabIndex = 1
      '
      'cmbChannel
      '
      Me.cmbChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbChannel.Location = New System.Drawing.Point(82, 24)
      Me.cmbChannel.Name = "cmbChannel"
      Me.cmbChannel.Size = New System.Drawing.Size(80, 21)
      Me.cmbChannel.TabIndex = 0
      '
      'DAQCounter1
      '
      Me.DAQCounter1.Enabled = True
      Me.DAQCounter1.Location = New System.Drawing.Point(408, 8)
      Me.DAQCounter1.Name = "DAQCounter1"
      Me.DAQCounter1.OcxState = CType(resources.GetObject("DAQCounter1.OcxState"), System.Windows.Forms.AxHost.State)
      Me.DAQCounter1.Size = New System.Drawing.Size(33, 33)
      Me.DAQCounter1.TabIndex = 9
      '
      'frmFreq
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(496, 237)
      Me.Controls.Add(Me.DAQCounter1)
      Me.Controls.Add(Me.GroupBox3)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.GroupBox2)
      Me.Controls.Add(Me.cmdExit)
      Me.MaximizeBox = False
      Me.Name = "frmFreq"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Frequency Tester"
      Me.GroupBox3.ResumeLayout(False)
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox2.ResumeLayout(False)
      CType(Me.DAQCounter1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region
    Private Sub cmdSelectDevice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectDevice.Click
        Dim Ret As Long
        Dim i As Long

        Ret = DAQCounter1.SelectDevice

        txtDeviceNum.Text = DAQCounter1.DeviceNumber
        txtDeviceName.Text = DAQCounter1.DeviceName

        If DAQCounter1.OpenDevice Then
            MsgBox(DAQCounter1.ErrorMessage, vbOKOnly)
            Exit Sub
        End If


        cmbChannel.Items.Clear()

        If DAQCounter1.MaxCounterNumber = 0 Then
            MsgBox("Function Not Supported", vbOKOnly)
            Exit Sub
        End If

        For i = 0 To DAQCounter1.MaxCounterNumber - 1
            cmbChannel.Items.Add(i.ToString)
        Next

        If DAQCounter1.MaxCounterNumber Then
            cmbChannel.SelectedIndex = DAQCounter1.Channel
        End If
        txtGatePeriod.Text = DAQCounter1.GatePeriod
        cmbGateMode.SelectedIndex = DAQCounter1.GateMode




    End Sub

    Private Sub frmCounterTester_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Select Default device
        cmdSelectDevice_Click(sender, e)
        ScanTimer.Enabled = False

    End Sub

    Private Sub cmdScanStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScanStart.Click
        If DAQCounter1.OpenDevice Then
            MsgBox(DAQCounter1.ErrorMessage, vbOKOnly)
            Exit Sub
        End If

        DAQCounter1.Channel = cmbChannel.SelectedIndex
        DAQCounter1.GateMode = cmbGateMode.SelectedIndex
        DAQCounter1.GatePeriod = txtGatePeriod.Text
        cmdScanStart.Enabled = False
        cmdScanStop.Enabled = True
        cmdExit.Enabled = False
        cmdSelectDevice.Enabled = False

        DAQCounter1.EnableFrequency(True)
        ScanTimer.Interval = txtScanTime.Text
        ScanTimer.Enabled = True

    End Sub

    Private Sub ScanTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScanTimer.Tick
        txtFreq.Text = DAQCounter1.FrequencyValue
        txtError.Text = DAQCounter1.ErrorMessage
        If DAQCounter1.ErrorCode Then
            ScanTimer.Enabled = False
            MsgBox("Error Message is " & DAQCounter1.ErrorMessage, vbCritical)
            Exit Sub
        End If
    End Sub

    Private Sub txtCounter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFreq.TextChanged

    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Application.Exit()
    End Sub

    Private Sub cmdScanStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScanStop.Click
        Dim j As Integer
        DAQCounter1.EnableFrequency(False)
        cmdSelectDevice.Enabled = True
        ScanTimer.Enabled = False
        cmdScanStart.Enabled = True
        cmdScanStop.Enabled = False
        cmdExit.Enabled = True

        If DAQCounter1.CloseDevice Then
            MsgBox(DAQCounter1.ErrorMessage, vbOKOnly)
            Exit Sub
        End If


    End Sub


    Private Sub txtScanTime_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScanTime.TextChanged
        ScanTimer.Interval = txtScanTime.Text
    End Sub

    Private Sub txtDeviceNum_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDeviceNum.TextChanged
        Dim i As Integer
        'may fire when form is initialized
        If (isInitializing) Then
            Exit Sub
        End If
        DAQCounter1.DeviceNumber = Val(txtDeviceNum.Text)
        txtDeviceName.Text = DAQCounter1.DeviceName

    End Sub

    Private Sub cmbChannel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbChannel.SelectedIndexChanged

        DAQCounter1.Channel = cmbChannel.SelectedIndex

    End Sub

    Private Sub cmbGateMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGateMode.SelectedIndexChanged
        DAQCounter1.GateMode = cmbGateMode.SelectedIndex
    End Sub
End Class
