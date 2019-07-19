Public Class Form1
    Inherits System.Windows.Forms.Form
    Dim gEventCount As Short
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
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents cmdSelectDevice As System.Windows.Forms.Button
    Public WithEvents txtDeviceName As System.Windows.Forms.TextBox
    Public WithEvents txtDeviceNum As System.Windows.Forms.TextBox
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Frame2 As System.Windows.Forms.GroupBox
    Public WithEvents hscrlCount As System.Windows.Forms.HScrollBar
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Frame3 As System.Windows.Forms.GroupBox
    Public WithEvents txtEventFreq As System.Windows.Forms.TextBox
    Public WithEvents cmdDisableEvent As System.Windows.Forms.Button
    Public WithEvents cmdEnableEvent As System.Windows.Forms.Button
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents cmdExit As System.Windows.Forms.Button
    Public WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents WatchTimer As System.Windows.Forms.Timer
    Friend WithEvents DAQDI1 As AxDAQDILib.AxDAQDI
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.cmdSelectDevice = New System.Windows.Forms.Button
        Me.txtDeviceName = New System.Windows.Forms.TextBox
        Me.txtDeviceNum = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Frame2 = New System.Windows.Forms.GroupBox
        Me.hscrlCount = New System.Windows.Forms.HScrollBar
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Frame3 = New System.Windows.Forms.GroupBox
        Me.txtEventFreq = New System.Windows.Forms.TextBox
        Me.cmdDisableEvent = New System.Windows.Forms.Button
        Me.cmdEnableEvent = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdExit = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.WatchTimer = New System.Windows.Forms.Timer(Me.components)
        Me.DAQDI1 = New AxDAQDILib.AxDAQDI
        Me.Frame1.SuspendLayout()
        Me.Frame2.SuspendLayout()
        Me.Frame3.SuspendLayout()
        CType(Me.DAQDI1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(8, 8)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(329, 79)
        Me.Frame1.TabIndex = 13
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Select Device :"
        '
        'cmdSelectDevice
        '
        Me.cmdSelectDevice.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSelectDevice.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSelectDevice.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSelectDevice.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSelectDevice.Location = New System.Drawing.Point(216, 16)
        Me.cmdSelectDevice.Name = "cmdSelectDevice"
        Me.cmdSelectDevice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSelectDevice.Size = New System.Drawing.Size(97, 25)
        Me.cmdSelectDevice.TabIndex = 3
        Me.cmdSelectDevice.Text = "&Select Device"
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
        Me.txtDeviceName.Size = New System.Drawing.Size(225, 19)
        Me.txtDeviceName.TabIndex = 2
        Me.txtDeviceName.Text = "AdvanTech"
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
        Me.txtDeviceNum.TabIndex = 1
        Me.txtDeviceNum.Text = "-100"
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
        Me.Label1.Location = New System.Drawing.Point(8, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Device No. :"
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me.hscrlCount)
        Me.Frame2.Controls.Add(Me.Label4)
        Me.Frame2.Controls.Add(Me.Label8)
        Me.Frame2.Controls.Add(Me.Label3)
        Me.Frame2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(8, 96)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(185, 105)
        Me.Frame2.TabIndex = 15
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Device Property:"
        '
        'hscrlCount
        '
        Me.hscrlCount.Cursor = System.Windows.Forms.Cursors.Default
        Me.hscrlCount.LargeChange = 1
        Me.hscrlCount.Location = New System.Drawing.Point(8, 69)
        Me.hscrlCount.Maximum = 10
        Me.hscrlCount.Minimum = 1
        Me.hscrlCount.Name = "hscrlCount"
        Me.hscrlCount.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.hscrlCount.Size = New System.Drawing.Size(169, 16)
        Me.hscrlCount.TabIndex = 9
        Me.hscrlCount.TabStop = True
        Me.hscrlCount.Value = 1
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(152, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(25, 25)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "10"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(24, 51)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(17, 17)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "1"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "EventTrigCount:"
        '
        'Frame3
        '
        Me.Frame3.BackColor = System.Drawing.SystemColors.Control
        Me.Frame3.Controls.Add(Me.txtEventFreq)
        Me.Frame3.Controls.Add(Me.cmdDisableEvent)
        Me.Frame3.Controls.Add(Me.cmdEnableEvent)
        Me.Frame3.Controls.Add(Me.Label5)
        Me.Frame3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame3.Location = New System.Drawing.Point(200, 96)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3.Size = New System.Drawing.Size(225, 105)
        Me.Frame3.TabIndex = 16
        Me.Frame3.TabStop = False
        Me.Frame3.Text = "Interrupt Event:"
        '
        'txtEventFreq
        '
        Me.txtEventFreq.AcceptsReturn = True
        Me.txtEventFreq.AutoSize = False
        Me.txtEventFreq.BackColor = System.Drawing.SystemColors.Window
        Me.txtEventFreq.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEventFreq.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEventFreq.ForeColor = System.Drawing.Color.Blue
        Me.txtEventFreq.Location = New System.Drawing.Point(56, 64)
        Me.txtEventFreq.MaxLength = 0
        Me.txtEventFreq.Name = "txtEventFreq"
        Me.txtEventFreq.ReadOnly = True
        Me.txtEventFreq.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtEventFreq.Size = New System.Drawing.Size(81, 25)
        Me.txtEventFreq.TabIndex = 15
        Me.txtEventFreq.Text = ""
        '
        'cmdDisableEvent
        '
        Me.cmdDisableEvent.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDisableEvent.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdDisableEvent.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDisableEvent.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDisableEvent.Location = New System.Drawing.Point(128, 24)
        Me.cmdDisableEvent.Name = "cmdDisableEvent"
        Me.cmdDisableEvent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdDisableEvent.Size = New System.Drawing.Size(73, 25)
        Me.cmdDisableEvent.TabIndex = 14
        Me.cmdDisableEvent.Text = "Disable"
        '
        'cmdEnableEvent
        '
        Me.cmdEnableEvent.BackColor = System.Drawing.SystemColors.Control
        Me.cmdEnableEvent.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdEnableEvent.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEnableEvent.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdEnableEvent.Location = New System.Drawing.Point(16, 24)
        Me.cmdEnableEvent.Name = "cmdEnableEvent"
        Me.cmdEnableEvent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdEnableEvent.Size = New System.Drawing.Size(81, 25)
        Me.cmdEnableEvent.TabIndex = 13
        Me.cmdEnableEvent.Text = "Enable"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(152, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(25, 16)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "1/S"
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExit.Location = New System.Drawing.Point(344, 61)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExit.Size = New System.Drawing.Size(81, 24)
        Me.cmdExit.TabIndex = 14
        Me.cmdExit.Text = "Close"
        '
        'WatchTimer
        '
        Me.WatchTimer.Interval = 1
        '
        'DAQDI1
        '
        Me.DAQDI1.Enabled = True
        Me.DAQDI1.Location = New System.Drawing.Point(368, 16)
        Me.DAQDI1.Name = "DAQDI1"
        Me.DAQDI1.OcxState = CType(resources.GetObject("DAQDI1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.DAQDI1.Size = New System.Drawing.Size(33, 33)
        Me.DAQDI1.TabIndex = 17
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(440, 213)
        Me.Controls.Add(Me.DAQDI1)
        Me.Controls.Add(Me.Frame3)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.Frame2)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Digital Input with Interrupt"
        Me.Frame1.ResumeLayout(False)
        Me.Frame2.ResumeLayout(False)
        Me.Frame3.ResumeLayout(False)
        CType(Me.DAQDI1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub cmdDisableEvent_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDisableEvent.Click
        'Disable Event
        DAQDI1.EnableEvent(False)

        ' Close device
        DAQDI1.CloseDevice()

        'Disable watch timer
        WatchTimer.Enabled = False

        cmdEnableEvent.Enabled = True
        cmdDisableEvent.Enabled = False
        cmdExit.Enabled = True
        cmdSelectDevice.Enabled = True

    End Sub

    Private Sub cmdEnableEvent_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEnableEvent.Click
        'Open Device
        If DAQDI1.OpenDevice Then
            MsgBox(DAQDI1.ErrorMessage, MsgBoxStyle.OKOnly)
            Exit Sub
        End If

        'Enable Event
        If (DAQDI1.EnableEvent(True)) Then
            MsgBox(DAQDI1.ErrorMessage, MsgBoxStyle.OKOnly)
            Exit Sub
        End If

        cmdEnableEvent.Enabled = False
        cmdDisableEvent.Enabled = True
        cmdExit.Enabled = False
        'Enable watch timer
        WatchTimer.Enabled = True
        cmdSelectDevice.Enabled = False



    End Sub

    Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
        Me.Close()
        End
    End Sub

    Private Sub cmdSelectDevice_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSelectDevice.Click
        Dim i As Short
        Dim Ret As Integer

        ' Select Device from installed list
        Ret = DAQDI1.SelectDevice
        txtDeviceNum.Text = CStr(DAQDI1.DeviceNumber)
        txtDeviceName.Text = DAQDI1.DeviceName
    End Sub

    Private Sub DAQDI1_OnEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DAQDI1.OnEvent
        gEventCount = gEventCount + 1
    End Sub

    Private Sub hscrlCount_Change(ByVal newScrollValue As Integer)
        DAQDI1.EventTrigCount = newScrollValue
    End Sub

    Private Sub txtDeviceNum_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtDeviceNum.TextChanged
        If (IsInitializing = False) Then
            DAQDI1.DeviceNumber = Val(txtDeviceNum.Text)
            txtDeviceName.Text = DAQDI1.DeviceName
        End If

    End Sub
    Private Sub Form1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ' Select default device
        Call cmdSelectDevice_Click(cmdSelectDevice, New System.EventArgs)
        ' Setting initial value

        'Initialize global value
        gEventCount = 0
        WatchTimer.Enabled = False
        WatchTimer.Interval = 1000
        cmdEnableEvent.Enabled = True
        cmdDisableEvent.Enabled = False

    End Sub

    Private Sub WatchTimer_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WatchTimer.Tick
        txtEventFreq.Text = Str(gEventCount)
        gEventCount = 0
    End Sub
    Private Sub hscrlCount_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles hscrlCount.Scroll
        Select Case eventArgs.Type
            Case System.Windows.Forms.ScrollEventType.EndScroll
                hscrlCount_Change(eventArgs.NewValue)
        End Select
    End Sub



    Private Sub txtEventFreq_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEventFreq.TextChanged

    End Sub
End Class
