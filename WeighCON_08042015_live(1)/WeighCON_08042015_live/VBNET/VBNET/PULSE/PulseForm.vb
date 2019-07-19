Public Class frmPulse
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
    Friend WithEvents cmbGateMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents DAQPulse1 As AxDAQPulseLib.AxDAQPulse
    Friend WithEvents txtUpCycle As System.Windows.Forms.TextBox
    Friend WithEvents txtChannel As System.Windows.Forms.TextBox
    Friend WithEvents txtPeriod As System.Windows.Forms.TextBox
    Friend WithEvents cmdStop As System.Windows.Forms.Button
    Friend WithEvents cmdStart As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents txtErrorCode As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPulse))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.cmdExit = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtError = New System.Windows.Forms.TextBox
        Me.txtErrorCode = New System.Windows.Forms.TextBox
        Me.cmdStop = New System.Windows.Forms.Button
        Me.cmdStart = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdSelectDevice = New System.Windows.Forms.Button
        Me.txtDeviceNum = New System.Windows.Forms.TextBox
        Me.txtDeviceName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtChannel = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtUpCycle = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtPeriod = New System.Windows.Forms.TextBox
        Me.cmbGateMode = New System.Windows.Forms.ComboBox
        Me.DAQPulse1 = New AxDAQPulseLib.AxDAQPulse
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DAQPulse1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(400, 64)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(80, 24)
        Me.cmdExit.TabIndex = 8
        Me.cmdExit.Text = "Close"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.txtError)
        Me.GroupBox3.Controls.Add(Me.txtErrorCode)
        Me.GroupBox3.Controls.Add(Me.cmdStop)
        Me.GroupBox3.Controls.Add(Me.cmdStart)
        Me.GroupBox3.Location = New System.Drawing.Point(288, 96)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(192, 128)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Pulse Out"
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
        Me.Label7.Text = "Error Code:"
        '
        'txtError
        '
        Me.txtError.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtError.Location = New System.Drawing.Point(88, 96)
        Me.txtError.Name = "txtError"
        Me.txtError.ReadOnly = True
        Me.txtError.Size = New System.Drawing.Size(96, 20)
        Me.txtError.TabIndex = 3
        Me.txtError.Text = ""
        '
        'txtErrorCode
        '
        Me.txtErrorCode.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtErrorCode.Location = New System.Drawing.Point(88, 64)
        Me.txtErrorCode.Name = "txtErrorCode"
        Me.txtErrorCode.ReadOnly = True
        Me.txtErrorCode.Size = New System.Drawing.Size(96, 20)
        Me.txtErrorCode.TabIndex = 2
        Me.txtErrorCode.Text = ""
        '
        'cmdStop
        '
        Me.cmdStop.Location = New System.Drawing.Point(104, 24)
        Me.cmdStop.Name = "cmdStop"
        Me.cmdStop.Size = New System.Drawing.Size(80, 24)
        Me.cmdStop.TabIndex = 1
        Me.cmdStop.Text = "Stop"
        '
        'cmdStart
        '
        Me.cmdStart.Location = New System.Drawing.Point(16, 24)
        Me.cmdStart.Name = "cmdStart"
        Me.cmdStart.Size = New System.Drawing.Size(80, 24)
        Me.cmdStart.TabIndex = 0
        Me.cmdStart.Text = "Start"
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
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select Device :"
        '
        'cmdSelectDevice
        '
        Me.cmdSelectDevice.Location = New System.Drawing.Point(264, 16)
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
        Me.txtDeviceName.Size = New System.Drawing.Size(264, 20)
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
        Me.GroupBox2.Controls.Add(Me.txtChannel)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtUpCycle)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtPeriod)
        Me.GroupBox2.Controls.Add(Me.cmbGateMode)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 96)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(264, 128)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Property Settings:"
        '
        'txtChannel
        '
        Me.txtChannel.Location = New System.Drawing.Point(80, 24)
        Me.txtChannel.Name = "txtChannel"
        Me.txtChannel.Size = New System.Drawing.Size(80, 20)
        Me.txtChannel.TabIndex = 11
        Me.txtChannel.Text = "0"
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
        Me.Label10.Location = New System.Drawing.Point(136, 72)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(120, 16)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "s(only for PCL830,836)"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(8, 74)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 16)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "UpCycle:"
        '
        'txtUpCycle
        '
        Me.txtUpCycle.Location = New System.Drawing.Point(80, 72)
        Me.txtUpCycle.Name = "txtUpCycle"
        Me.txtUpCycle.Size = New System.Drawing.Size(56, 20)
        Me.txtUpCycle.TabIndex = 7
        Me.txtUpCycle.Text = "0"
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
        Me.Label5.Location = New System.Drawing.Point(8, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 16)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Period: "
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Gate Mode:"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Channel:"
        '
        'txtPeriod
        '
        Me.txtPeriod.Location = New System.Drawing.Point(80, 96)
        Me.txtPeriod.Name = "txtPeriod"
        Me.txtPeriod.Size = New System.Drawing.Size(56, 20)
        Me.txtPeriod.TabIndex = 2
        Me.txtPeriod.Text = "10"
        '
        'cmbGateMode
        '
        Me.cmbGateMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGateMode.Items.AddRange(New Object() {"no gating", "high level", "low level", "rising edge", "falling edge"})
        Me.cmbGateMode.Location = New System.Drawing.Point(80, 48)
        Me.cmbGateMode.Name = "cmbGateMode"
        Me.cmbGateMode.Size = New System.Drawing.Size(80, 21)
        Me.cmbGateMode.TabIndex = 1
        '
        'DAQPulse1
        '
        Me.DAQPulse1.Enabled = True
        Me.DAQPulse1.Location = New System.Drawing.Point(425, 19)
        Me.DAQPulse1.Name = "DAQPulse1"
        Me.DAQPulse1.OcxState = CType(resources.GetObject("DAQPulse1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.DAQPulse1.Size = New System.Drawing.Size(33, 33)
        Me.DAQPulse1.TabIndex = 9
        '
        'frmPulse
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(496, 237)
        Me.Controls.Add(Me.DAQPulse1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdExit)
        Me.MaximizeBox = False
        Me.Name = "frmPulse"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pulse Tester"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DAQPulse1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub cmdSelectDevice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectDevice.Click
        DAQPulse1.SelectDevice()

        txtDeviceNum.Text = DAQPulse1.DeviceNumber
        txtDeviceName.Text = DAQPulse1.DeviceName

    End Sub

    Private Sub frmCounterTester_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Select Default device
        cmdSelectDevice_Click(sender, e)
        Timer1.Enabled = False
        cmbGateMode.SelectedIndex = 0
        cmdStop.Enabled = False

    End Sub

    Private Sub cmdScanStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStart.Click

        If DAQPulse1.OpenDevice Then
            MsgBox(DAQPulse1.ErrorMessage, vbOKOnly)
            Exit Sub
        End If

        DAQPulse1.Channel = txtChannel.Text
        DAQPulse1.PulsePeriod = txtPeriod.Text / 1000
        DAQPulse1.PulseUpCycle = txtUpCycle.Text
        DAQPulse1.GateMode = cmbGateMode.SelectedIndex

        DAQPulse1.EnablePulseOut(True)

        cmdExit.Enabled = False
        cmdStart.Enabled = False
        cmdStop.Enabled = True
        Timer1.Enabled = True
        cmdSelectDevice.Enabled = False
    End Sub

    Private Sub ScanTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        txtErrorCode.Text = DAQPulse1.ErrorCode
        txtError.Text = DAQPulse1.ErrorMessage
    End Sub

    Private Sub txtCounter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtErrorCode.TextChanged

    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Application.Exit()
    End Sub

    Private Sub cmdScanStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStop.Click
        Timer1.Enabled = False
        DAQPulse1.EnablePulseOut(False)
        cmdStop.Enabled = False
        cmdStart.Enabled = True
        cmdSelectDevice.Enabled = True

        If DAQPulse1.CloseDevice Then
            MsgBox(DAQPulse1.ErrorMessage, vbOKOnly)
            Exit Sub
        End If
        cmdExit.Enabled = True



    End Sub


    Private Sub txtScanTime_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPeriod.TextChanged
        If isInitializing Then
            Exit Sub
        End If
        DAQPulse1.PulsePeriod = txtPeriod.Text / 1000
        DAQPulse1.EnablePulseOut(False)
        DAQPulse1.EnablePulseOut(True)

    End Sub

    Private Sub txtDeviceNum_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDeviceNum.TextChanged

        If isInitializing Then
            Exit Sub
        End If
        DAQPulse1.DeviceNumber = Val(txtDeviceNum.Text)
        txtDeviceName.Text = DAQPulse1.DeviceName
    End Sub

    Private Sub cmbChannel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If isInitializing Then
            Exit Sub
        End If

        DAQPulse1.Channel = txtChannel.Text

    End Sub

    Private Sub cmbGateMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGateMode.SelectedIndexChanged
        If isInitializing Then
            Exit Sub
        End If
        DAQPulse1.GateMode = cmbGateMode.SelectedIndex
    End Sub

    Private Sub txtUpCycle_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUpCycle.TextChanged

    End Sub
End Class
