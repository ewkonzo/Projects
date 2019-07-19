Public Class frmCounter
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdSelectDevice As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDeviceName As System.Windows.Forms.TextBox
    Friend WithEvents txtDeviceNum As System.Windows.Forms.TextBox
    Friend WithEvents cmbChannel As System.Windows.Forms.ComboBox
    Friend WithEvents cmbGateMode As System.Windows.Forms.ComboBox
    Friend WithEvents txtScanTime As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCounterStart As System.Windows.Forms.Button
    Friend WithEvents cmdCounterStop As System.Windows.Forms.Button
    Friend WithEvents txtCounter As System.Windows.Forms.TextBox
    Friend WithEvents ScanTimer As System.Windows.Forms.Timer
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents txtError As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents DAQCounter1 As AxDAQCounterLib.AxDAQCounter
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCounter))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdSelectDevice = New System.Windows.Forms.Button
        Me.txtDeviceNum = New System.Windows.Forms.TextBox
        Me.txtDeviceName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtScanTime = New System.Windows.Forms.TextBox
        Me.cmbGateMode = New System.Windows.Forms.ComboBox
        Me.cmbChannel = New System.Windows.Forms.ComboBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtError = New System.Windows.Forms.TextBox
        Me.txtCounter = New System.Windows.Forms.TextBox
        Me.cmdCounterStop = New System.Windows.Forms.Button
        Me.cmdCounterStart = New System.Windows.Forms.Button
        Me.ScanTimer = New System.Windows.Forms.Timer(Me.components)
        Me.cmdExit = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.DAQCounter1 = New AxDAQCounterLib.AxDAQCounter
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DAQCounter1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.GroupBox1.Size = New System.Drawing.Size(368, 80)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select Device :"
        '
        'cmdSelectDevice
        '
        Me.cmdSelectDevice.Location = New System.Drawing.Point(248, 16)
        Me.cmdSelectDevice.Name = "cmdSelectDevice"
        Me.cmdSelectDevice.Size = New System.Drawing.Size(88, 23)
        Me.cmdSelectDevice.TabIndex = 4
        Me.cmdSelectDevice.Text = "SelectDevice"
        Me.ToolTip1.SetToolTip(Me.cmdSelectDevice, "Select the device")
        '
        'txtDeviceNum
        '
        Me.txtDeviceNum.Location = New System.Drawing.Point(96, 24)
        Me.txtDeviceNum.Name = "txtDeviceNum"
        Me.txtDeviceNum.Size = New System.Drawing.Size(56, 20)
        Me.txtDeviceNum.TabIndex = 3
        Me.txtDeviceNum.Text = "-1"
        Me.ToolTip1.SetToolTip(Me.txtDeviceNum, "Device Number")
        '
        'txtDeviceName
        '
        Me.txtDeviceName.Location = New System.Drawing.Point(96, 48)
        Me.txtDeviceName.Name = "txtDeviceName"
        Me.txtDeviceName.ReadOnly = True
        Me.txtDeviceName.Size = New System.Drawing.Size(256, 20)
        Me.txtDeviceName.TabIndex = 2
        Me.txtDeviceName.Text = "No Device!"
        Me.ToolTip1.SetToolTip(Me.txtDeviceName, "Device name")
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Device Name :"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Device No. :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtScanTime)
        Me.GroupBox2.Controls.Add(Me.cmbGateMode)
        Me.GroupBox2.Controls.Add(Me.cmbChannel)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 96)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(256, 128)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Property Settings:"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(152, 67)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(96, 16)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "(only for PCL830)"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(163, 99)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 16)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "ms"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 16)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Scan Time: "
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Gate Mode:"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Channel:"
        '
        'txtScanTime
        '
        Me.txtScanTime.Location = New System.Drawing.Point(73, 96)
        Me.txtScanTime.Name = "txtScanTime"
        Me.txtScanTime.Size = New System.Drawing.Size(80, 20)
        Me.txtScanTime.TabIndex = 2
        Me.txtScanTime.Text = "200"
        '
        'cmbGateMode
        '
        Me.cmbGateMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGateMode.Items.AddRange(New Object() {"no gating", "high level", "low level", "rising edge", "falling edge"})
        Me.cmbGateMode.Location = New System.Drawing.Point(73, 64)
        Me.cmbGateMode.Name = "cmbGateMode"
        Me.cmbGateMode.Size = New System.Drawing.Size(80, 21)
        Me.cmbGateMode.TabIndex = 1
        '
        'cmbChannel
        '
        Me.cmbChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbChannel.Location = New System.Drawing.Point(73, 32)
        Me.cmbChannel.Name = "cmbChannel"
        Me.cmbChannel.Size = New System.Drawing.Size(80, 21)
        Me.cmbChannel.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.txtError)
        Me.GroupBox3.Controls.Add(Me.txtCounter)
        Me.GroupBox3.Controls.Add(Me.cmdCounterStop)
        Me.GroupBox3.Controls.Add(Me.cmdCounterStart)
        Me.GroupBox3.Location = New System.Drawing.Point(280, 96)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(192, 128)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Counter Read:"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(8, 96)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 16)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Error Message"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 16)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Counter value:"
        '
        'txtError
        '
        Me.txtError.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtError.Location = New System.Drawing.Point(88, 96)
        Me.txtError.Name = "txtError"
        Me.txtError.ReadOnly = True
        Me.txtError.Size = New System.Drawing.Size(88, 20)
        Me.txtError.TabIndex = 3
        Me.txtError.Text = ""
        '
        'txtCounter
        '
        Me.txtCounter.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtCounter.Location = New System.Drawing.Point(88, 64)
        Me.txtCounter.Name = "txtCounter"
        Me.txtCounter.ReadOnly = True
        Me.txtCounter.Size = New System.Drawing.Size(88, 20)
        Me.txtCounter.TabIndex = 2
        Me.txtCounter.Text = ""
        '
        'cmdCounterStop
        '
        Me.cmdCounterStop.Location = New System.Drawing.Point(104, 24)
        Me.cmdCounterStop.Name = "cmdCounterStop"
        Me.cmdCounterStop.Size = New System.Drawing.Size(80, 24)
        Me.cmdCounterStop.TabIndex = 1
        Me.cmdCounterStop.Text = "Counter Stop"
        '
        'cmdCounterStart
        '
        Me.cmdCounterStart.Location = New System.Drawing.Point(16, 24)
        Me.cmdCounterStart.Name = "cmdCounterStart"
        Me.cmdCounterStart.Size = New System.Drawing.Size(80, 24)
        Me.cmdCounterStart.TabIndex = 0
        Me.cmdCounterStart.Text = "Counter Start"
        '
        'ScanTimer
        '
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(393, 56)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(72, 24)
        Me.cmdExit.TabIndex = 4
        Me.cmdExit.Text = "Close"
        '
        'DAQCounter1
        '
        Me.DAQCounter1.Enabled = True
        Me.DAQCounter1.Location = New System.Drawing.Point(408, 8)
        Me.DAQCounter1.Name = "DAQCounter1"
        Me.DAQCounter1.OcxState = CType(resources.GetObject("DAQCounter1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.DAQCounter1.Size = New System.Drawing.Size(33, 33)
        Me.DAQCounter1.TabIndex = 5
        '
        'frmCounter
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(480, 229)
        Me.Controls.Add(Me.DAQCounter1)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.Name = "frmCounter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Counter"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
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
            DAQCounter1.CloseDevice()
            Exit Sub
        End If

        For i = 0 To DAQCounter1.MaxCounterNumber - 1
            cmbChannel.Items.Add(i.ToString)
        Next


        If DAQCounter1.MaxCounterNumber Then
            cmbChannel.SelectedIndex = DAQCounter1.Channel
        End If
        DAQCounter1.CloseDevice()
    End Sub

    Private Sub frmCounterTester_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Select Default device
        cmdSelectDevice_Click(sender, e)

        cmdCounterStop.Enabled = False
        ScanTimer.Enabled = False
        cmbChannel.SelectedIndex = DAQCounter1.Channel
        cmbGateMode.SelectedIndex = DAQCounter1.GateMode
    End Sub

    Private Sub cmdCounterStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCounterStart.Click
        If DAQCounter1.OpenDevice Then
            MsgBox(DAQCounter1.ErrorMessage, vbOKOnly)
            Exit Sub
        End If

        DAQCounter1.Channel = cmbChannel.SelectedIndex
        DAQCounter1.GateMode = cmbGateMode.SelectedIndex
        cmdCounterStart.Enabled = False
        cmdCounterStop.Enabled = True
        cmdExit.Enabled = False
        cmdSelectDevice.Enabled = False

        DAQCounter1.EnableCounter(True)
        ScanTimer.Interval = txtScanTime.Text
        ScanTimer.Enabled = True
        txtDeviceNum.Enabled = False
    End Sub

    Private Sub ScanTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScanTimer.Tick
        Dim temp As Long
        temp = DAQCounter1.CounterValue
        txtError.Text = DAQCounter1.ErrorMessage
        If DAQCounter1.ErrorCode Then
            ScanTimer.Enabled = False
            MsgBox("Error Message is " & DAQCounter1.ErrorMessage, vbCritical)
            Exit Sub
        End If
        txtCounter.Text = DAQCounter1.CounterValue
    End Sub

    Private Sub txtCounter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCounter.TextChanged

    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Application.Exit()
    End Sub

    Private Sub cmdCounterStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCounterStop.Click
        Dim j As Integer
        DAQCounter1.EnableCounter(False)
        cmdSelectDevice.Enabled = True
        ScanTimer.Enabled = False
        cmdCounterStart.Enabled = True
        cmdCounterStop.Enabled = False
        cmdExit.Enabled = True
        txtDeviceNum.Enabled = True

        If DAQCounter1.CloseDevice Then
            MsgBox(DAQCounter1.ErrorMessage, vbOKOnly)
            Exit Sub
        End If


    End Sub

    Private Sub txtDeviceNum_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDeviceNum.TextChanged
        Dim i As Integer

        If IsInitializing Then
            Exit Sub
        End If
        DAQCounter1.DeviceNumber = Val(txtDeviceNum.Text)
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
        DAQCounter1.CloseDevice()

    End Sub

    Private Sub cmbChannel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbChannel.SelectedIndexChanged
        If IsInitializing Then
            Exit Sub
        End If
        DAQCounter1.Channel = cmbChannel.SelectedIndex
    End Sub

    Private Sub cmbGateMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGateMode.SelectedIndexChanged
        If IsInitializing Then
            Exit Sub
        End If
        DAQCounter1.GateMode = cmbGateMode.SelectedIndex
    End Sub

    Private Sub txtScanTime_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScanTime.TextChanged
        If IsInitializing Then
            Exit Sub
        End If
        If (txtScanTime.Text.Length <= 0 Or txtScanTime.Text = "0") Then
            txtScanTime.Text = "200"
        End If

        ScanTimer.Interval = txtScanTime.Text
    End Sub

    Private Sub DAQCounter1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DAQCounter1.Enter

    End Sub
End Class
