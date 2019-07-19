Public Class frmAoSync
    Inherits System.Windows.Forms.Form
    Dim IsInitializing As Boolean
    Dim OutputValue(3) As Single
    Dim Index As Integer


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
    Public WithEvents Frame3 As System.Windows.Forms.GroupBox
    Public WithEvents txtOutputValue As System.Windows.Forms.TextBox
    Public WithEvents cmdOutputStart As System.Windows.Forms.Button
    Public WithEvents cmdOutputStop As System.Windows.Forms.Button
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents ScanTimer As System.Windows.Forms.Timer
    Public WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents cmdExit As System.Windows.Forms.Button
    Public WithEvents Frame4 As System.Windows.Forms.GroupBox
    Public WithEvents txtScanTime As System.Windows.Forms.TextBox
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents cmdSelectDevice As System.Windows.Forms.Button
    Public WithEvents txtDeviceName As System.Windows.Forms.TextBox
    Public WithEvents txtDeviceNum As System.Windows.Forms.TextBox
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Frame2 As System.Windows.Forms.GroupBox
    Public WithEvents frmOutputKind As System.Windows.Forms.GroupBox
    Public WithEvents optVoltageOut As System.Windows.Forms.RadioButton
    Public WithEvents optCurrentOut0 As System.Windows.Forms.RadioButton
    Public WithEvents optCurrentOut4 As System.Windows.Forms.RadioButton
    Public WithEvents chkSyncAOEnable As System.Windows.Forms.CheckBox
    Friend WithEvents DAQAO1 As AxDAQAOLib.AxDAQAO
    Friend WithEvents chkListBox As System.Windows.Forms.CheckedListBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAoSync))
        Me.Frame3 = New System.Windows.Forms.GroupBox
        Me.txtOutputValue = New System.Windows.Forms.TextBox
        Me.cmdOutputStart = New System.Windows.Forms.Button
        Me.cmdOutputStop = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.ScanTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdSelectDevice = New System.Windows.Forms.Button
        Me.txtDeviceName = New System.Windows.Forms.TextBox
        Me.txtDeviceNum = New System.Windows.Forms.TextBox
        Me.Frame4 = New System.Windows.Forms.GroupBox
        Me.txtScanTime = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Frame2 = New System.Windows.Forms.GroupBox
        Me.chkListBox = New System.Windows.Forms.CheckedListBox
        Me.frmOutputKind = New System.Windows.Forms.GroupBox
        Me.optVoltageOut = New System.Windows.Forms.RadioButton
        Me.optCurrentOut0 = New System.Windows.Forms.RadioButton
        Me.optCurrentOut4 = New System.Windows.Forms.RadioButton
        Me.chkSyncAOEnable = New System.Windows.Forms.CheckBox
        Me.DAQAO1 = New AxDAQAOLib.AxDAQAO
        Me.Frame3.SuspendLayout()
        Me.Frame4.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.Frame2.SuspendLayout()
        Me.frmOutputKind.SuspendLayout()
        CType(Me.DAQAO1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Frame3
        '
        Me.Frame3.BackColor = System.Drawing.SystemColors.Control
        Me.Frame3.Controls.Add(Me.txtOutputValue)
        Me.Frame3.Controls.Add(Me.cmdOutputStart)
        Me.Frame3.Controls.Add(Me.cmdOutputStop)
        Me.Frame3.Controls.Add(Me.Label3)
        Me.Frame3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame3.Location = New System.Drawing.Point(408, 84)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3.Size = New System.Drawing.Size(121, 172)
        Me.Frame3.TabIndex = 24
        Me.Frame3.TabStop = False
        Me.Frame3.Text = "Sync. Output:"
        '
        'txtOutputValue
        '
        Me.txtOutputValue.AcceptsReturn = True
        Me.txtOutputValue.AutoSize = False
        Me.txtOutputValue.BackColor = System.Drawing.SystemColors.Window
        Me.txtOutputValue.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtOutputValue.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOutputValue.ForeColor = System.Drawing.Color.Blue
        Me.txtOutputValue.Location = New System.Drawing.Point(19, 136)
        Me.txtOutputValue.MaxLength = 0
        Me.txtOutputValue.Name = "txtOutputValue"
        Me.txtOutputValue.ReadOnly = True
        Me.txtOutputValue.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtOutputValue.Size = New System.Drawing.Size(69, 24)
        Me.txtOutputValue.TabIndex = 16
        Me.txtOutputValue.Text = ""
        Me.txtOutputValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmdOutputStart
        '
        Me.cmdOutputStart.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOutputStart.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOutputStart.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOutputStart.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOutputStart.Location = New System.Drawing.Point(16, 32)
        Me.cmdOutputStart.Name = "cmdOutputStart"
        Me.cmdOutputStart.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOutputStart.Size = New System.Drawing.Size(73, 25)
        Me.cmdOutputStart.TabIndex = 15
        Me.cmdOutputStart.Text = "St&art"
        Me.ToolTip1.SetToolTip(Me.cmdOutputStart, "Star Auto Scan")
        '
        'cmdOutputStop
        '
        Me.cmdOutputStop.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOutputStop.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOutputStop.Enabled = False
        Me.cmdOutputStop.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOutputStop.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOutputStop.Location = New System.Drawing.Point(16, 64)
        Me.cmdOutputStop.Name = "cmdOutputStop"
        Me.cmdOutputStop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOutputStop.Size = New System.Drawing.Size(73, 25)
        Me.cmdOutputStop.TabIndex = 14
        Me.cmdOutputStop.Text = "St&op"
        Me.ToolTip1.SetToolTip(Me.cmdOutputStop, "Stop Auto Scan")
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(16, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(73, 17)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Output Value:"
        '
        'ScanTimer
        '
        Me.ScanTimer.Interval = 1000
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExit.Location = New System.Drawing.Point(424, 48)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExit.Size = New System.Drawing.Size(89, 25)
        Me.cmdExit.TabIndex = 22
        Me.cmdExit.Text = "&Close"
        Me.ToolTip1.SetToolTip(Me.cmdExit, "Close application")
        '
        'cmdSelectDevice
        '
        Me.cmdSelectDevice.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSelectDevice.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSelectDevice.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSelectDevice.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSelectDevice.Location = New System.Drawing.Point(295, 16)
        Me.cmdSelectDevice.Name = "cmdSelectDevice"
        Me.cmdSelectDevice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSelectDevice.Size = New System.Drawing.Size(96, 25)
        Me.cmdSelectDevice.TabIndex = 3
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
        Me.txtDeviceName.Location = New System.Drawing.Point(88, 48)
        Me.txtDeviceName.MaxLength = 0
        Me.txtDeviceName.Name = "txtDeviceName"
        Me.txtDeviceName.ReadOnly = True
        Me.txtDeviceName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDeviceName.Size = New System.Drawing.Size(303, 19)
        Me.txtDeviceName.TabIndex = 2
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
        Me.txtDeviceNum.Location = New System.Drawing.Point(88, 20)
        Me.txtDeviceNum.MaxLength = 0
        Me.txtDeviceNum.Name = "txtDeviceNum"
        Me.txtDeviceNum.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDeviceNum.Size = New System.Drawing.Size(57, 19)
        Me.txtDeviceNum.TabIndex = 1
        Me.txtDeviceNum.Text = "-100"
        Me.ToolTip1.SetToolTip(Me.txtDeviceNum, "Device Number")
        '
        'Frame4
        '
        Me.Frame4.BackColor = System.Drawing.SystemColors.Control
        Me.Frame4.Controls.Add(Me.txtScanTime)
        Me.Frame4.Controls.Add(Me.Label5)
        Me.Frame4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame4.Location = New System.Drawing.Point(408, 264)
        Me.Frame4.Name = "Frame4"
        Me.Frame4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame4.Size = New System.Drawing.Size(121, 72)
        Me.Frame4.TabIndex = 26
        Me.Frame4.TabStop = False
        Me.Frame4.Text = "Scan &Time Setting"
        '
        'txtScanTime
        '
        Me.txtScanTime.AcceptsReturn = True
        Me.txtScanTime.AutoSize = False
        Me.txtScanTime.BackColor = System.Drawing.SystemColors.Window
        Me.txtScanTime.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtScanTime.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtScanTime.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtScanTime.Location = New System.Drawing.Point(21, 32)
        Me.txtScanTime.MaxLength = 0
        Me.txtScanTime.Name = "txtScanTime"
        Me.txtScanTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtScanTime.Size = New System.Drawing.Size(68, 20)
        Me.txtScanTime.TabIndex = 21
        Me.txtScanTime.Text = "1000"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(96, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(24, 17)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "ms"
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
        Me.Frame1.Location = New System.Drawing.Point(8, 2)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(401, 79)
        Me.Frame1.TabIndex = 21
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Select Device :"
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Device No. :"
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me.chkListBox)
        Me.Frame2.Controls.Add(Me.frmOutputKind)
        Me.Frame2.Controls.Add(Me.chkSyncAOEnable)
        Me.Frame2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(8, 84)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(395, 252)
        Me.Frame2.TabIndex = 23
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Property Settings:"
        '
        'chkListBox
        '
        Me.chkListBox.CheckOnClick = True
        Me.chkListBox.Location = New System.Drawing.Point(8, 104)
        Me.chkListBox.MultiColumn = True
        Me.chkListBox.Name = "chkListBox"
        Me.chkListBox.Size = New System.Drawing.Size(376, 139)
        Me.chkListBox.TabIndex = 10
        '
        'frmOutputKind
        '
        Me.frmOutputKind.BackColor = System.Drawing.SystemColors.Control
        Me.frmOutputKind.Controls.Add(Me.optVoltageOut)
        Me.frmOutputKind.Controls.Add(Me.optCurrentOut0)
        Me.frmOutputKind.Controls.Add(Me.optCurrentOut4)
        Me.frmOutputKind.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frmOutputKind.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frmOutputKind.Location = New System.Drawing.Point(8, 40)
        Me.frmOutputKind.Name = "frmOutputKind"
        Me.frmOutputKind.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frmOutputKind.Size = New System.Drawing.Size(375, 48)
        Me.frmOutputKind.TabIndex = 9
        Me.frmOutputKind.TabStop = False
        Me.frmOutputKind.Text = "Output Type:"
        '
        'optVoltageOut
        '
        Me.optVoltageOut.BackColor = System.Drawing.SystemColors.Control
        Me.optVoltageOut.Checked = True
        Me.optVoltageOut.Cursor = System.Windows.Forms.Cursors.Default
        Me.optVoltageOut.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optVoltageOut.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optVoltageOut.Location = New System.Drawing.Point(17, 24)
        Me.optVoltageOut.Name = "optVoltageOut"
        Me.optVoltageOut.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optVoltageOut.Size = New System.Drawing.Size(76, 13)
        Me.optVoltageOut.TabIndex = 12
        Me.optVoltageOut.TabStop = True
        Me.optVoltageOut.Text = "&Voltage Out"
        '
        'optCurrentOut0
        '
        Me.optCurrentOut0.BackColor = System.Drawing.SystemColors.Control
        Me.optCurrentOut0.Cursor = System.Windows.Forms.Cursors.Default
        Me.optCurrentOut0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optCurrentOut0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optCurrentOut0.Location = New System.Drawing.Point(104, 24)
        Me.optCurrentOut0.Name = "optCurrentOut0"
        Me.optCurrentOut0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optCurrentOut0.Size = New System.Drawing.Size(122, 13)
        Me.optCurrentOut0.TabIndex = 11
        Me.optCurrentOut0.TabStop = True
        Me.optCurrentOut0.Text = "&0 - 20 mA Current Out"
        '
        'optCurrentOut4
        '
        Me.optCurrentOut4.BackColor = System.Drawing.SystemColors.Control
        Me.optCurrentOut4.Cursor = System.Windows.Forms.Cursors.Default
        Me.optCurrentOut4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optCurrentOut4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optCurrentOut4.Location = New System.Drawing.Point(240, 24)
        Me.optCurrentOut4.Name = "optCurrentOut4"
        Me.optCurrentOut4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optCurrentOut4.Size = New System.Drawing.Size(122, 13)
        Me.optCurrentOut4.TabIndex = 10
        Me.optCurrentOut4.TabStop = True
        Me.optCurrentOut4.Text = "&4 - 20 mA Current Out"
        '
        'chkSyncAOEnable
        '
        Me.chkSyncAOEnable.BackColor = System.Drawing.SystemColors.Control
        Me.chkSyncAOEnable.Checked = True
        Me.chkSyncAOEnable.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSyncAOEnable.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkSyncAOEnable.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSyncAOEnable.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkSyncAOEnable.Location = New System.Drawing.Point(8, 24)
        Me.chkSyncAOEnable.Name = "chkSyncAOEnable"
        Me.chkSyncAOEnable.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkSyncAOEnable.Size = New System.Drawing.Size(165, 15)
        Me.chkSyncAOEnable.TabIndex = 8
        Me.chkSyncAOEnable.Text = "S&ynchronously AO Enable"
        '
        'DAQAO1
        '
        Me.DAQAO1.Enabled = True
        Me.DAQAO1.Location = New System.Drawing.Point(448, 8)
        Me.DAQAO1.Name = "DAQAO1"
        Me.DAQAO1.OcxState = CType(resources.GetObject("DAQAO1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.DAQAO1.Size = New System.Drawing.Size(33, 33)
        Me.DAQAO1.TabIndex = 27
        '
        'frmAoSync
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(544, 349)
        Me.Controls.Add(Me.DAQAO1)
        Me.Controls.Add(Me.Frame4)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.Frame3)
        Me.Controls.Add(Me.cmdExit)
        Me.MaximizeBox = False
        Me.Name = "frmAoSync"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sync Anolog output"
        Me.Frame3.ResumeLayout(False)
        Me.Frame4.ResumeLayout(False)
        Me.Frame1.ResumeLayout(False)
        Me.Frame2.ResumeLayout(False)
        Me.frmOutputKind.ResumeLayout(False)
        CType(Me.DAQAO1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub chkSyncAOEnable_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkSyncAOEnable.CheckStateChanged
        If IsInitializing Then
            Exit Sub
        End If
        If chkSyncAOEnable.CheckState = System.Windows.Forms.CheckState.Checked Then
            DAQAO1.SetSynchronous(True)
        Else
            DAQAO1.SetSynchronous(False)
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
        Me.Close()
        End
    End Sub

    Private Sub cmdOutputStart_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOutputStart.Click
        'Open Device
        If DAQAO1.OpenDevice Then
            MsgBox(DAQAO1.ErrorMessage, MsgBoxStyle.OKOnly)
            Exit Sub
        End If

        'Set Outputtype & initialize output value
        If optVoltageOut.Checked = True Then
            OutputValue(0) = 0.0#
            OutputValue(1) = 1.25
            OutputValue(2) = 2.5
            OutputValue(3) = 5.0#

            DAQAO1.OutputType = DAQAOLib.OUTPUT_TYPE.adVoltage
        End If
        If optCurrentOut0.Checked = True Then
            OutputValue(0) = 0.0#
            OutputValue(1) = 5.0#
            OutputValue(2) = 10.0#
            OutputValue(3) = 20.0#

            DAQAO1.OutputType = DAQAOLib.OUTPUT_TYPE.adCurrent
        End If
        If optCurrentOut4.Checked = True Then
            OutputValue(0) = 4.0#
            OutputValue(1) = 10.0#
            OutputValue(2) = 15.0#
            OutputValue(3) = 20.0#

            DAQAO1.OutputType = DAQAOLib.OUTPUT_TYPE.adCurrent
        End If

        'Reset button state
        cmdOutputStart.Enabled = False
        cmdOutputStop.Enabled = True
        cmdExit.Enabled = False
        cmdSelectDevice.Enabled = False

        'Enable ScanTimer
        ScanTimer.Enabled = True



    End Sub

    Private Sub cmdOutputStop_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOutputStop.Click
        'Disable ScanTimer
        ScanTimer.Enabled = False

        'Close Device
        If DAQAO1.CloseDevice Then
            MsgBox(DAQAO1.ErrorMessage, MsgBoxStyle.OKOnly)
            Exit Sub
        End If

        cmdOutputStart.Enabled = True
        cmdOutputStop.Enabled = False
        cmdExit.Enabled = True
        cmdSelectDevice.Enabled = True
    End Sub

    Private Sub cmdSelectDevice_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSelectDevice.Click
        Dim chkSyncEnable As Object
        Dim i As Short
        Dim j As Short
        Dim bRet As Boolean

        DAQAO1.SelectDevice()
        txtDeviceNum.Text = CStr(DAQAO1.DeviceNumber)
        txtDeviceName.Text = DAQAO1.DeviceName

        ' Open device
        If DAQAO1.OpenDevice Then
            MsgBox(DAQAO1.ErrorMessage, MsgBoxStyle.OKOnly)
            Exit Sub
        End If

        If DAQAO1.MaxChannel = 0 Then
            MsgBox("Function Not Supported")
            DAQAO1.CloseDevice()
            Exit Sub
            
        End If
        chkListBox.Items.Clear()

        For i = 0 To DAQAO1.MaxChannel - 1
            chkListBox.Items.Add("Chan " & i & " ")
        Next i
        Dim width As Integer = CInt(chkListBox.CreateGraphics().MeasureString(chkListBox.Items(0).ToString(), _
    chkListBox.Font).Width + 30)
        '  Set the column width based on the width of each item in the list.
        chkListBox.ColumnWidth = width

        'Set SyncAo enable
        DAQAO1.SetSynchronous(True)

        'Close Device
        If DAQAO1.CloseDevice Then
            MsgBox(DAQAO1.ErrorMessage, MsgBoxStyle.OKOnly)
            Exit Sub
        End If
    End Sub

    Private Sub frmSyncAo_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ' Select default device
        Call cmdSelectDevice_Click(cmdSelectDevice, New System.EventArgs)
        ' Setting initial value
        txtDeviceNum.Text = CStr(DAQAO1.DeviceNumber)
        txtDeviceName.Text = DAQAO1.DeviceName

    End Sub



    Private Sub ScanTimer_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ScanTimer.Tick
        Dim chkSyncEnable As Object
        Dim i As Object

        'Output value
        For i = 0 To DAQAO1.MaxChannel - 1
            If chkListBox.GetItemChecked(i) Then
                DAQAO1.Channel = i
                If DAQAO1.RealOutput(OutputValue(Index)) Then
                    ScanTimer.Enabled = False

                    MsgBox(DAQAO1.ErrorMessage, MsgBoxStyle.OKOnly)
                    Exit Sub
                End If
            End If
        Next i

        ' Start SyncAO
        If DAQAO1.SynchronousOutput Then
            ScanTimer.Enabled = False
            MsgBox(DAQAO1.ErrorMessage, MsgBoxStyle.OKOnly)
            Exit Sub
        End If

        'Update text output value
        txtOutputValue.Text = Str(OutputValue(Index))

        Index = Index + 1
        If Index > 3 Then
            Index = 0
        End If

    End Sub

    Private Sub txtDeviceNum_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtDeviceNum.TextChanged

        Dim i As Integer
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
            '       MsgBox("Function Not Supported")
            DAQAO1.CloseDevice()
            Exit Sub
        End If
        chkListBox.Items.Clear()

        For i = 0 To DAQAO1.MaxChannel - 1
            chkListBox.Items.Add("Chan " & i & " ")
        Next i
        Dim width As Integer = CInt(chkListBox.CreateGraphics().MeasureString(chkListBox.Items(0).ToString(), _
    chkListBox.Font).Width + 30)
        '  Set the column width based on the width of each item in the list.
        chkListBox.ColumnWidth = width

        'Set SyncAo enable
        DAQAO1.SetSynchronous(True)

        'Close Device
        If DAQAO1.CloseDevice Then
            MsgBox(DAQAO1.ErrorMessage, MsgBoxStyle.OKOnly)
            Exit Sub
        End If
    End Sub

    Private Sub txtScanTime_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtScanTime.TextChanged
        If IsInitializing Then
            Exit Sub
        End If
        If (Val(txtScanTime.Text) > 0) Then
            ScanTimer.Interval = Val(txtScanTime.Text)
        End If
    End Sub

    Private Sub optCurrentOut0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCurrentOut0.CheckedChanged

    End Sub
End Class
