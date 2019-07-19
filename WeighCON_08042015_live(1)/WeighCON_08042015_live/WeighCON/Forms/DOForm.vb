Public Class frmDO
    Inherits System.Windows.Forms.Form
    Dim bOpen As Boolean
    Dim isInitializing As Boolean
    Dim MaskBits As New BitArray(8)
    Public StatusBits As New BitArray(8)
    Dim cmdChannelArray(8) As Button
    Dim chkMaskArray(8) As CheckBox




#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        isInitializing = True
        InitializeComponent()
        isInitializing = False
        cmdChannelArray(0) = cmdChannel0
        cmdChannelArray(1) = cmdChannel1
        cmdChannelArray(2) = cmdChannel2
        cmdChannelArray(3) = cmdChannel3
        cmdChannelArray(4) = cmdChannel4
        cmdChannelArray(5) = cmdChannel5
        cmdChannelArray(6) = cmdChannel6
        cmdChannelArray(7) = cmdChannel7

        chkMaskArray(0) = ChkMask0
        chkMaskArray(1) = ChkMask1
        chkMaskArray(2) = ChkMask2
        chkMaskArray(3) = ChkMask3
        chkMaskArray(4) = ChkMask4
        chkMaskArray(5) = ChkMask5
        chkMaskArray(6) = ChkMask6
        chkMaskArray(7) = ChkMask7


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
    Public WithEvents txtDeviceNum As System.Windows.Forms.TextBox
    Public WithEvents txtDeviceName As System.Windows.Forms.TextBox
    Public WithEvents cmdSelectDevice As System.Windows.Forms.Button
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents cmdExit As System.Windows.Forms.Button
    Public WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents DAQDO1 As AxDAQDOLib.AxDAQDO
    Public WithEvents cmdByteOut As System.Windows.Forms.Button
    Public WithEvents cmdReadBack As System.Windows.Forms.Button
    Public WithEvents framChannel As System.Windows.Forms.GroupBox
    Friend WithEvents ChkMask1 As System.Windows.Forms.CheckBox
    Friend WithEvents ChkMask7 As System.Windows.Forms.CheckBox
    Friend WithEvents ChkMask6 As System.Windows.Forms.CheckBox
    Friend WithEvents ChkMask5 As System.Windows.Forms.CheckBox
    Friend WithEvents ChkMask4 As System.Windows.Forms.CheckBox
    Friend WithEvents ChkMask3 As System.Windows.Forms.CheckBox
    Friend WithEvents ChkMask2 As System.Windows.Forms.CheckBox
    Friend WithEvents ChkMask0 As System.Windows.Forms.CheckBox
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents _labBit_7 As System.Windows.Forms.Label
    Public WithEvents _labBit_6 As System.Windows.Forms.Label
    Public WithEvents _labBit_5 As System.Windows.Forms.Label
    Public WithEvents _labBit_4 As System.Windows.Forms.Label
    Public WithEvents _labBit_3 As System.Windows.Forms.Label
    Public WithEvents _labBit_2 As System.Windows.Forms.Label
    Public WithEvents _labBit_1 As System.Windows.Forms.Label
    Public WithEvents _labBit_0 As System.Windows.Forms.Label
    Public WithEvents cmbPort As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents txtMask As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents cmdChannel0 As System.Windows.Forms.Button
    Public WithEvents cmdChannel7 As System.Windows.Forms.Button
    Public WithEvents cmdChannel6 As System.Windows.Forms.Button
    Public WithEvents cmdChannel5 As System.Windows.Forms.Button
    Public WithEvents cmdChannel4 As System.Windows.Forms.Button
    Public WithEvents cmdChannel3 As System.Windows.Forms.Button
    Public WithEvents cmdChannel2 As System.Windows.Forms.Button
    Public WithEvents cmdChannel1 As System.Windows.Forms.Button
    Public WithEvents txtOutByte As System.Windows.Forms.TextBox
    Public WithEvents txtReadBack As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDO))
        Me.DAQDO1 = New AxDAQDOLib.AxDAQDO()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.txtDeviceNum = New System.Windows.Forms.TextBox()
        Me.txtDeviceName = New System.Windows.Forms.TextBox()
        Me.cmdSelectDevice = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdByteOut = New System.Windows.Forms.Button()
        Me.cmdReadBack = New System.Windows.Forms.Button()
        Me.framChannel = New System.Windows.Forms.GroupBox()
        Me.ChkMask1 = New System.Windows.Forms.CheckBox()
        Me.ChkMask7 = New System.Windows.Forms.CheckBox()
        Me.ChkMask6 = New System.Windows.Forms.CheckBox()
        Me.ChkMask5 = New System.Windows.Forms.CheckBox()
        Me.ChkMask4 = New System.Windows.Forms.CheckBox()
        Me.ChkMask3 = New System.Windows.Forms.CheckBox()
        Me.ChkMask2 = New System.Windows.Forms.CheckBox()
        Me.ChkMask0 = New System.Windows.Forms.CheckBox()
        Me.cmdChannel0 = New System.Windows.Forms.Button()
        Me.cmdChannel7 = New System.Windows.Forms.Button()
        Me.cmdChannel6 = New System.Windows.Forms.Button()
        Me.cmdChannel5 = New System.Windows.Forms.Button()
        Me.cmdChannel4 = New System.Windows.Forms.Button()
        Me.cmdChannel3 = New System.Windows.Forms.Button()
        Me.cmdChannel2 = New System.Windows.Forms.Button()
        Me.cmdChannel1 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me._labBit_7 = New System.Windows.Forms.Label()
        Me._labBit_6 = New System.Windows.Forms.Label()
        Me._labBit_5 = New System.Windows.Forms.Label()
        Me._labBit_4 = New System.Windows.Forms.Label()
        Me._labBit_3 = New System.Windows.Forms.Label()
        Me._labBit_2 = New System.Windows.Forms.Label()
        Me._labBit_1 = New System.Windows.Forms.Label()
        Me._labBit_0 = New System.Windows.Forms.Label()
        Me.cmbPort = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtMask = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtOutByte = New System.Windows.Forms.TextBox()
        Me.txtReadBack = New System.Windows.Forms.TextBox()
        CType(Me.DAQDO1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Frame1.SuspendLayout()
        Me.framChannel.SuspendLayout()
        Me.SuspendLayout()
        '
        'DAQDO1
        '
        Me.DAQDO1.Enabled = True
        Me.DAQDO1.Location = New System.Drawing.Point(440, 18)
        Me.DAQDO1.Name = "DAQDO1"
        Me.DAQDO1.OcxState = CType(resources.GetObject("DAQDO1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.DAQDO1.Size = New System.Drawing.Size(33, 33)
        Me.DAQDO1.TabIndex = 0
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
        Me.Frame1.Location = New System.Drawing.Point(8, 9)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(385, 103)
        Me.Frame1.TabIndex = 41
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Select Device :"
        '
        'txtDeviceNum
        '
        Me.txtDeviceNum.AcceptsReturn = True
        Me.txtDeviceNum.BackColor = System.Drawing.SystemColors.Window
        Me.txtDeviceNum.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDeviceNum.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeviceNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDeviceNum.Location = New System.Drawing.Point(80, 28)
        Me.txtDeviceNum.MaxLength = 0
        Me.txtDeviceNum.Name = "txtDeviceNum"
        Me.txtDeviceNum.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDeviceNum.Size = New System.Drawing.Size(65, 20)
        Me.txtDeviceNum.TabIndex = 3
        Me.txtDeviceNum.Text = "-1"
        Me.ToolTip1.SetToolTip(Me.txtDeviceNum, "Device Number")
        '
        'txtDeviceName
        '
        Me.txtDeviceName.AcceptsReturn = True
        Me.txtDeviceName.BackColor = System.Drawing.SystemColors.Window
        Me.txtDeviceName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDeviceName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeviceName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDeviceName.Location = New System.Drawing.Point(80, 65)
        Me.txtDeviceName.MaxLength = 0
        Me.txtDeviceName.Name = "txtDeviceName"
        Me.txtDeviceName.ReadOnly = True
        Me.txtDeviceName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDeviceName.Size = New System.Drawing.Size(289, 20)
        Me.txtDeviceName.TabIndex = 2
        Me.txtDeviceName.Text = "Advantech"
        Me.ToolTip1.SetToolTip(Me.txtDeviceName, "Device Name")
        '
        'cmdSelectDevice
        '
        Me.cmdSelectDevice.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSelectDevice.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSelectDevice.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSelectDevice.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSelectDevice.Location = New System.Drawing.Point(280, 28)
        Me.cmdSelectDevice.Name = "cmdSelectDevice"
        Me.cmdSelectDevice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSelectDevice.Size = New System.Drawing.Size(89, 29)
        Me.cmdSelectDevice.TabIndex = 1
        Me.cmdSelectDevice.Text = "&Select Device"
        Me.ToolTip1.SetToolTip(Me.cmdSelectDevice, "Selecting device to operation")
        Me.cmdSelectDevice.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(65, 14)
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
        Me.Label2.Location = New System.Drawing.Point(8, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(76, 14)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Device Name :"
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExit.Location = New System.Drawing.Point(416, 74)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExit.Size = New System.Drawing.Size(81, 29)
        Me.cmdExit.TabIndex = 44
        Me.cmdExit.Text = "&Close"
        Me.ToolTip1.SetToolTip(Me.cmdExit, "Close application")
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'cmdByteOut
        '
        Me.cmdByteOut.BackColor = System.Drawing.SystemColors.Control
        Me.cmdByteOut.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdByteOut.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdByteOut.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdByteOut.Location = New System.Drawing.Point(432, 194)
        Me.cmdByteOut.Name = "cmdByteOut"
        Me.cmdByteOut.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdByteOut.Size = New System.Drawing.Size(80, 29)
        Me.cmdByteOut.TabIndex = 47
        Me.cmdByteOut.Text = "&Byte Out"
        Me.cmdByteOut.UseVisualStyleBackColor = False
        '
        'cmdReadBack
        '
        Me.cmdReadBack.BackColor = System.Drawing.SystemColors.Control
        Me.cmdReadBack.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdReadBack.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReadBack.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdReadBack.Location = New System.Drawing.Point(432, 231)
        Me.cmdReadBack.Name = "cmdReadBack"
        Me.cmdReadBack.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdReadBack.Size = New System.Drawing.Size(80, 29)
        Me.cmdReadBack.TabIndex = 46
        Me.cmdReadBack.Text = "&Read Back"
        Me.cmdReadBack.UseVisualStyleBackColor = False
        '
        'framChannel
        '
        Me.framChannel.BackColor = System.Drawing.SystemColors.Control
        Me.framChannel.Controls.Add(Me.ChkMask1)
        Me.framChannel.Controls.Add(Me.ChkMask7)
        Me.framChannel.Controls.Add(Me.ChkMask6)
        Me.framChannel.Controls.Add(Me.ChkMask5)
        Me.framChannel.Controls.Add(Me.ChkMask4)
        Me.framChannel.Controls.Add(Me.ChkMask3)
        Me.framChannel.Controls.Add(Me.ChkMask2)
        Me.framChannel.Controls.Add(Me.ChkMask0)
        Me.framChannel.Controls.Add(Me.cmdChannel0)
        Me.framChannel.Controls.Add(Me.cmdChannel7)
        Me.framChannel.Controls.Add(Me.cmdChannel6)
        Me.framChannel.Controls.Add(Me.cmdChannel5)
        Me.framChannel.Controls.Add(Me.cmdChannel4)
        Me.framChannel.Controls.Add(Me.cmdChannel3)
        Me.framChannel.Controls.Add(Me.cmdChannel2)
        Me.framChannel.Controls.Add(Me.cmdChannel1)
        Me.framChannel.Controls.Add(Me.Label5)
        Me.framChannel.Controls.Add(Me.Label4)
        Me.framChannel.Controls.Add(Me.Label3)
        Me.framChannel.Controls.Add(Me._labBit_7)
        Me.framChannel.Controls.Add(Me._labBit_6)
        Me.framChannel.Controls.Add(Me._labBit_5)
        Me.framChannel.Controls.Add(Me._labBit_4)
        Me.framChannel.Controls.Add(Me._labBit_3)
        Me.framChannel.Controls.Add(Me._labBit_2)
        Me.framChannel.Controls.Add(Me._labBit_1)
        Me.framChannel.Controls.Add(Me._labBit_0)
        Me.framChannel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.framChannel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.framChannel.Location = New System.Drawing.Point(8, 120)
        Me.framChannel.Name = "framChannel"
        Me.framChannel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.framChannel.Size = New System.Drawing.Size(335, 148)
        Me.framChannel.TabIndex = 45
        Me.framChannel.TabStop = False
        Me.framChannel.Text = "Bit Setting"
        '
        'ChkMask1
        '
        Me.ChkMask1.Location = New System.Drawing.Point(256, 37)
        Me.ChkMask1.Name = "ChkMask1"
        Me.ChkMask1.Size = New System.Drawing.Size(16, 18)
        Me.ChkMask1.TabIndex = 49
        '
        'ChkMask7
        '
        Me.ChkMask7.Location = New System.Drawing.Point(71, 37)
        Me.ChkMask7.Name = "ChkMask7"
        Me.ChkMask7.Size = New System.Drawing.Size(16, 18)
        Me.ChkMask7.TabIndex = 48
        '
        'ChkMask6
        '
        Me.ChkMask6.Location = New System.Drawing.Point(101, 37)
        Me.ChkMask6.Name = "ChkMask6"
        Me.ChkMask6.Size = New System.Drawing.Size(16, 18)
        Me.ChkMask6.TabIndex = 47
        '
        'ChkMask5
        '
        Me.ChkMask5.Location = New System.Drawing.Point(132, 37)
        Me.ChkMask5.Name = "ChkMask5"
        Me.ChkMask5.Size = New System.Drawing.Size(16, 18)
        Me.ChkMask5.TabIndex = 46
        '
        'ChkMask4
        '
        Me.ChkMask4.Location = New System.Drawing.Point(162, 37)
        Me.ChkMask4.Name = "ChkMask4"
        Me.ChkMask4.Size = New System.Drawing.Size(16, 18)
        Me.ChkMask4.TabIndex = 45
        '
        'ChkMask3
        '
        Me.ChkMask3.Location = New System.Drawing.Point(193, 37)
        Me.ChkMask3.Name = "ChkMask3"
        Me.ChkMask3.Size = New System.Drawing.Size(16, 18)
        Me.ChkMask3.TabIndex = 44
        '
        'ChkMask2
        '
        Me.ChkMask2.Location = New System.Drawing.Point(225, 37)
        Me.ChkMask2.Name = "ChkMask2"
        Me.ChkMask2.Size = New System.Drawing.Size(16, 18)
        Me.ChkMask2.TabIndex = 43
        '
        'ChkMask0
        '
        Me.ChkMask0.Location = New System.Drawing.Point(288, 37)
        Me.ChkMask0.Name = "ChkMask0"
        Me.ChkMask0.Size = New System.Drawing.Size(16, 18)
        Me.ChkMask0.TabIndex = 42
        '
        'cmdChannel0
        '
        Me.cmdChannel0.BackColor = System.Drawing.Color.Red
        Me.cmdChannel0.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdChannel0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdChannel0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdChannel0.Location = New System.Drawing.Point(281, 65)
        Me.cmdChannel0.Name = "cmdChannel0"
        Me.cmdChannel0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdChannel0.Size = New System.Drawing.Size(25, 28)
        Me.cmdChannel0.TabIndex = 23
        Me.cmdChannel0.TabStop = False
        Me.cmdChannel0.UseVisualStyleBackColor = False
        '
        'cmdChannel7
        '
        Me.cmdChannel7.BackColor = System.Drawing.Color.Red
        Me.cmdChannel7.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdChannel7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdChannel7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdChannel7.Location = New System.Drawing.Point(64, 65)
        Me.cmdChannel7.Name = "cmdChannel7"
        Me.cmdChannel7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdChannel7.Size = New System.Drawing.Size(25, 28)
        Me.cmdChannel7.TabIndex = 21
        Me.cmdChannel7.TabStop = False
        Me.cmdChannel7.UseVisualStyleBackColor = False
        '
        'cmdChannel6
        '
        Me.cmdChannel6.BackColor = System.Drawing.Color.Red
        Me.cmdChannel6.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdChannel6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdChannel6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdChannel6.Location = New System.Drawing.Point(95, 65)
        Me.cmdChannel6.Name = "cmdChannel6"
        Me.cmdChannel6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdChannel6.Size = New System.Drawing.Size(25, 28)
        Me.cmdChannel6.TabIndex = 20
        Me.cmdChannel6.TabStop = False
        Me.cmdChannel6.UseVisualStyleBackColor = False
        '
        'cmdChannel5
        '
        Me.cmdChannel5.BackColor = System.Drawing.Color.Red
        Me.cmdChannel5.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdChannel5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdChannel5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdChannel5.Location = New System.Drawing.Point(126, 65)
        Me.cmdChannel5.Name = "cmdChannel5"
        Me.cmdChannel5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdChannel5.Size = New System.Drawing.Size(25, 28)
        Me.cmdChannel5.TabIndex = 19
        Me.cmdChannel5.TabStop = False
        Me.cmdChannel5.UseVisualStyleBackColor = False
        '
        'cmdChannel4
        '
        Me.cmdChannel4.BackColor = System.Drawing.Color.Red
        Me.cmdChannel4.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdChannel4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdChannel4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdChannel4.Location = New System.Drawing.Point(157, 65)
        Me.cmdChannel4.Name = "cmdChannel4"
        Me.cmdChannel4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdChannel4.Size = New System.Drawing.Size(25, 28)
        Me.cmdChannel4.TabIndex = 18
        Me.cmdChannel4.TabStop = False
        Me.cmdChannel4.UseVisualStyleBackColor = False
        '
        'cmdChannel3
        '
        Me.cmdChannel3.BackColor = System.Drawing.Color.Red
        Me.cmdChannel3.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdChannel3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdChannel3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdChannel3.Location = New System.Drawing.Point(188, 65)
        Me.cmdChannel3.Name = "cmdChannel3"
        Me.cmdChannel3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdChannel3.Size = New System.Drawing.Size(25, 28)
        Me.cmdChannel3.TabIndex = 17
        Me.cmdChannel3.TabStop = False
        Me.cmdChannel3.UseVisualStyleBackColor = False
        '
        'cmdChannel2
        '
        Me.cmdChannel2.BackColor = System.Drawing.Color.Red
        Me.cmdChannel2.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdChannel2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdChannel2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdChannel2.Location = New System.Drawing.Point(219, 65)
        Me.cmdChannel2.Name = "cmdChannel2"
        Me.cmdChannel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdChannel2.Size = New System.Drawing.Size(25, 28)
        Me.cmdChannel2.TabIndex = 16
        Me.cmdChannel2.TabStop = False
        Me.cmdChannel2.UseVisualStyleBackColor = False
        '
        'cmdChannel1
        '
        Me.cmdChannel1.BackColor = System.Drawing.Color.Red
        Me.cmdChannel1.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdChannel1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdChannel1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdChannel1.Location = New System.Drawing.Point(250, 65)
        Me.cmdChannel1.Name = "cmdChannel1"
        Me.cmdChannel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdChannel1.Size = New System.Drawing.Size(25, 28)
        Me.cmdChannel1.TabIndex = 15
        Me.cmdChannel1.TabStop = False
        Me.cmdChannel1.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(24, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(297, 20)
        Me.Label5.TabIndex = 41
        Me.Label5.Text = "Note : Mask value would not affect BitOutput method."
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(8, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(37, 16)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Status :"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(9, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(32, 16)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Mask :"
        '
        '_labBit_7
        '
        Me._labBit_7.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me._labBit_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._labBit_7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._labBit_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me._labBit_7.Location = New System.Drawing.Point(65, 92)
        Me._labBit_7.Name = "_labBit_7"
        Me._labBit_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._labBit_7.Size = New System.Drawing.Size(15, 20)
        Me._labBit_7.TabIndex = 31
        Me._labBit_7.Text = "7"
        Me._labBit_7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_labBit_6
        '
        Me._labBit_6.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me._labBit_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._labBit_6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._labBit_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me._labBit_6.Location = New System.Drawing.Point(97, 92)
        Me._labBit_6.Name = "_labBit_6"
        Me._labBit_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._labBit_6.Size = New System.Drawing.Size(15, 20)
        Me._labBit_6.TabIndex = 30
        Me._labBit_6.Text = "6"
        Me._labBit_6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_labBit_5
        '
        Me._labBit_5.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me._labBit_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._labBit_5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._labBit_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me._labBit_5.Location = New System.Drawing.Point(129, 92)
        Me._labBit_5.Name = "_labBit_5"
        Me._labBit_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._labBit_5.Size = New System.Drawing.Size(15, 20)
        Me._labBit_5.TabIndex = 29
        Me._labBit_5.Text = "5"
        Me._labBit_5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_labBit_4
        '
        Me._labBit_4.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me._labBit_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._labBit_4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._labBit_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me._labBit_4.Location = New System.Drawing.Point(161, 92)
        Me._labBit_4.Name = "_labBit_4"
        Me._labBit_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._labBit_4.Size = New System.Drawing.Size(15, 20)
        Me._labBit_4.TabIndex = 28
        Me._labBit_4.Text = "4"
        Me._labBit_4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_labBit_3
        '
        Me._labBit_3.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me._labBit_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._labBit_3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._labBit_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me._labBit_3.Location = New System.Drawing.Point(193, 92)
        Me._labBit_3.Name = "_labBit_3"
        Me._labBit_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._labBit_3.Size = New System.Drawing.Size(15, 20)
        Me._labBit_3.TabIndex = 27
        Me._labBit_3.Text = "3"
        Me._labBit_3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_labBit_2
        '
        Me._labBit_2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me._labBit_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._labBit_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._labBit_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me._labBit_2.Location = New System.Drawing.Point(225, 92)
        Me._labBit_2.Name = "_labBit_2"
        Me._labBit_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._labBit_2.Size = New System.Drawing.Size(15, 20)
        Me._labBit_2.TabIndex = 26
        Me._labBit_2.Text = "2"
        Me._labBit_2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_labBit_1
        '
        Me._labBit_1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me._labBit_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._labBit_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._labBit_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me._labBit_1.Location = New System.Drawing.Point(257, 92)
        Me._labBit_1.Name = "_labBit_1"
        Me._labBit_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._labBit_1.Size = New System.Drawing.Size(15, 20)
        Me._labBit_1.TabIndex = 25
        Me._labBit_1.Text = "1"
        Me._labBit_1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_labBit_0
        '
        Me._labBit_0.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me._labBit_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._labBit_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._labBit_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._labBit_0.Location = New System.Drawing.Point(289, 92)
        Me._labBit_0.Name = "_labBit_0"
        Me._labBit_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._labBit_0.Size = New System.Drawing.Size(15, 20)
        Me._labBit_0.TabIndex = 24
        Me._labBit_0.Text = "0"
        Me._labBit_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmbPort
        '
        Me.cmbPort.BackColor = System.Drawing.SystemColors.Window
        Me.cmbPort.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPort.Enabled = False
        Me.cmbPort.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPort.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbPort.ItemHeight = 14
        Me.cmbPort.Items.AddRange(New Object() {"0", "1", "2", "3"})
        Me.cmbPort.Location = New System.Drawing.Point(408, 129)
        Me.cmbPort.Name = "cmbPort"
        Me.cmbPort.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbPort.Size = New System.Drawing.Size(104, 22)
        Me.cmbPort.TabIndex = 50
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(368, 129)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 19)
        Me.Label6.TabIndex = 51
        Me.Label6.Text = "Port"
        '
        'txtMask
        '
        Me.txtMask.AcceptsReturn = True
        Me.txtMask.BackColor = System.Drawing.SystemColors.Window
        Me.txtMask.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMask.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMask.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMask.Location = New System.Drawing.Point(408, 160)
        Me.txtMask.MaxLength = 0
        Me.txtMask.Name = "txtMask"
        Me.txtMask.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMask.Size = New System.Drawing.Size(104, 20)
        Me.txtMask.TabIndex = 52
        Me.txtMask.Text = "00"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(368, 162)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 18)
        Me.Label7.TabIndex = 53
        Me.Label7.Text = "Mask"
        '
        'txtOutByte
        '
        Me.txtOutByte.AcceptsReturn = True
        Me.txtOutByte.BackColor = System.Drawing.SystemColors.Window
        Me.txtOutByte.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtOutByte.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOutByte.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOutByte.Location = New System.Drawing.Point(360, 194)
        Me.txtOutByte.MaxLength = 0
        Me.txtOutByte.Name = "txtOutByte"
        Me.txtOutByte.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtOutByte.Size = New System.Drawing.Size(64, 20)
        Me.txtOutByte.TabIndex = 54
        Me.txtOutByte.Text = "00"
        '
        'txtReadBack
        '
        Me.txtReadBack.AcceptsReturn = True
        Me.txtReadBack.BackColor = System.Drawing.SystemColors.Window
        Me.txtReadBack.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtReadBack.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReadBack.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtReadBack.Location = New System.Drawing.Point(360, 231)
        Me.txtReadBack.MaxLength = 0
        Me.txtReadBack.Name = "txtReadBack"
        Me.txtReadBack.ReadOnly = True
        Me.txtReadBack.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtReadBack.Size = New System.Drawing.Size(64, 20)
        Me.txtReadBack.TabIndex = 55
        Me.txtReadBack.Text = "00"
        '
        'frmDO
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 15)
        Me.ClientSize = New System.Drawing.Size(529, 277)
        Me.Controls.Add(Me.txtReadBack)
        Me.Controls.Add(Me.txtOutByte)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtMask)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmdByteOut)
        Me.Controls.Add(Me.cmdReadBack)
        Me.Controls.Add(Me.framChannel)
        Me.Controls.Add(Me.cmbPort)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.DAQDO1)
        Me.MaximizeBox = False
        Me.Name = "frmDO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Digital Output"
        CType(Me.DAQDO1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.framChannel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '  Button1.BackColor = Color.Red
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmdSelectDevice_Click(sender, e)
    End Sub



    Private Sub cmdSelectDevice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectDevice.Click
        Dim i As Object
        Dim Ret As Integer

        If bOpen Then
            DAQDO1.CloseDevice()
            bOpen = False
            cmbPort.Enabled = False
        End If

        ' Select Device from installed list
        Ret = DAQDO1.SelectDevice
        txtDeviceNum.Text = CStr(DAQDO1.DeviceNumber)
        txtDeviceName.Text = DAQDO1.DeviceName

        ' Open Device
        If DAQDO1.OpenDevice Then
            MsgBox(DAQDO1.ErrorMessage, MsgBoxStyle.OKOnly)
            Exit Sub
        End If

        If DAQDO1.MaxPortNumber = 0 Then
            MsgBox("Function Not Supported", MsgBoxStyle.OKOnly)
            DAQDO1.CloseDevice()
            Exit Sub
        End If
        cmbPort.Enabled = True
        bOpen = True
        ' Add Port number to list box
        cmbPort.Items.Clear()
        For i = 0 To DAQDO1.MaxPortNumber - 1
            cmbPort.Items.Add((Str(i)))
        Next i
        If DAQDO1.MaxPortNumber Then
            cmbPort.SelectedIndex = DAQDO1.Port
        End If
        UpdateStatus()
        UpdateMask()
    End Sub

    Private Sub txtDeviceNum_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDeviceNum.TextChanged
        'may fire when form is initialized
        If (isInitializing) Then
            Exit Sub
        End If

        Dim i As Integer
        DAQDO1.DeviceNumber = Val(txtDeviceNum.Text)
        txtDeviceName.Text = DAQDO1.DeviceName
        ' Open Device
        If DAQDO1.OpenDevice Then
            MsgBox(DAQDO1.ErrorMessage, MsgBoxStyle.OKOnly)
            Exit Sub
        End If

        If DAQDO1.MaxPortNumber = 0 Then
            MsgBox("Function Not Supported", MsgBoxStyle.OKOnly)
            DAQDO1.CloseDevice()
            Exit Sub
        End If
        cmbPort.Enabled = True
        bOpen = True
        ' Add Port number to list box
        cmbPort.Items.Clear()
        For i = 0 To DAQDO1.MaxPortNumber - 1
            cmbPort.Items.Add((Str(i)))
        Next i
        If DAQDO1.MaxPortNumber Then
            cmbPort.SelectedIndex = DAQDO1.Port
        End If
    End Sub
    Private Sub UpdateMask()
        Dim i As Integer
        Dim mask As Short
        For i = 0 To 7
            If (chkMaskArray(i).Checked) Then
                mask = mask Or (1 << i)
            Else
                mask = mask Or (0 << i)
            End If
        Next i
        DAQDO1.Mask = mask
        txtMask.Text = Hex(DAQDO1.Mask)
    End Sub
    Private Sub ChkMask0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMask0.CheckedChanged
        UpdateMask()
    End Sub

    Private Sub ChkMask1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMask1.CheckedChanged
        UpdateMask()
    End Sub

    Private Sub ChkMask2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMask2.CheckedChanged
        UpdateMask()

    End Sub

    Private Sub ChkMask3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMask3.CheckedChanged
        UpdateMask()
    End Sub

    Private Sub ChkMask4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMask4.CheckedChanged
        UpdateMask()
    End Sub

    Private Sub ChkMask5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMask5.CheckedChanged
        UpdateMask()
    End Sub

    Private Sub ChkMask6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMask6.CheckedChanged
        UpdateMask()
    End Sub
    Private Sub ChkMask7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMask7.CheckedChanged
        UpdateMask()
    End Sub

    Private Sub txtMask_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMask.TextChanged
        Dim lStart As Long, lLength As Long
        Dim sHex As String
        If (isInitializing) Then
            Exit Sub
        End If

        '
        ' Bound the  value in 0 ~ FFh
        '
        If (Len(txtMask.Text) > 2) Then
            'Out of value bound
            lStart = txtMask.SelectionStart
            lLength = txtMask.SelectionLength
            If lStart <> 0 Then lStart = lStart - 1

            txtMask.Text = Hex(txtMask.Tag)

            txtMask.SelectionStart = lStart
            txtMask.SelectionLength = lLength
        End If

        If (Len(txtMask.Text) = 0) Then
            ' 0 Value
            txtMask.Text = "0"
            txtMask.SelectionStart = 0
        End If
        '
        ' Valid Patterm Match value,write this new property value to device.
        '
        sHex = "&H" + txtMask.Text
        lStart = Val(sHex)
        txtMask.Tag = lStart

        Dim i As Integer
        Dim mask As Short
        mask = lStart
        For i = 0 To 7
            If (mask And (1 << i)) Then
                chkMaskArray(i).Checked = True
            Else
                chkMaskArray(i).Checked = False
            End If
        Next i
        DAQDO1.Mask = mask


    End Sub

    Private Sub txtMask_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMask.KeyPress


    End Sub

    Public Sub UpdateStatus()
        Dim i As Integer
        Dim Status As Integer

        Status = DAQDO1.ByteReadBack()

        For i = 0 To 7
            If (Status And (1 << i)) Then
                cmdChannelArray(i).BackColor = Color.Red
                StatusBits.Set(i, True)
            Else
                cmdChannelArray(i).BackColor = Color.Blue
                StatusBits.Set(i, False)
            End If
        Next

        txtReadBack.Text = Hex(Status)

    End Sub


    Private Sub cmdChannel7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChannel7.Click
        DAQDO1.Bit = 7
        StatusBits.Set(7, Not StatusBits.Get(7))
        DAQDO1.BitOutput(StatusBits.Get(7))
        UpdateStatus()

    End Sub

    Private Sub cmdChannel6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChannel6.Click
        DAQDO1.Bit = 6
        StatusBits.Set(6, Not StatusBits.Get(6))
        DAQDO1.BitOutput(StatusBits.Get(6))
        UpdateStatus()

    End Sub

    Private Sub cmdChannel5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChannel5.Click
        DAQDO1.Bit = 5
        StatusBits.Set(5, Not StatusBits.Get(5))
        DAQDO1.BitOutput(StatusBits.Get(5))
        UpdateStatus()


    End Sub

    Private Sub cmdChannel4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChannel4.Click
        DAQDO1.Bit = 4
        StatusBits.Set(4, Not StatusBits.Get(4))
        DAQDO1.BitOutput(StatusBits.Get(4))
        UpdateStatus()


    End Sub

    Private Sub cmdChannel3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChannel3.Click
        DAQDO1.Bit = 3
        StatusBits.Set(3, Not StatusBits.Get(3))
        DAQDO1.BitOutput(StatusBits.Get(3))
        UpdateStatus()


    End Sub

    Private Sub cmdChannel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChannel2.Click
        DAQDO1.Bit = 2
        StatusBits.Set(2, Not StatusBits.Get(2))
        DAQDO1.BitOutput(StatusBits.Get(2))
        UpdateStatus()


    End Sub

    Private Sub cmdChannel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChannel1.Click
        DAQDO1.Bit = 1
        StatusBits.Set(1, Not StatusBits.Get(1))
        DAQDO1.BitOutput(StatusBits.Get(1))
        UpdateStatus()


    End Sub

    Private Sub cmdChannel0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChannel0.Click
        DAQDO1.Bit = 0
        StatusBits.Set(0, Not StatusBits.Get(0))
        DAQDO1.BitOutput(StatusBits.Get(0))
        UpdateStatus()
    End Sub

    Private Sub txtReadBack_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
  


    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub cmdReadBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReadBack.Click
        UpdateStatus()
    End Sub

    Private Sub cmdByteOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdByteOut.Click
        DAQDO1.Mask = CShort("&H" & txtMask.Text)
        DAQDO1.ByteOutput(CShort("&H" & txtOutByte.Text))
        MsgBox(txtMask.Text)
        MsgBox(txtOutByte.Text)
    End Sub

    Private Sub cmbPort_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPort.SelectedIndexChanged
        If (isInitializing) Then
            Exit Sub
        End If
        DAQDO1.Port = cmbPort.SelectedIndex
        cmdReadBack_Click(cmdReadBack, New System.EventArgs)

    End Sub


    Private Sub txtOutByte_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOutByte.TextChanged
        Dim lStart As Long, lLength As Long
        Dim sHex As String
        If (isInitializing) Then
            Exit Sub
        End If

        '
        ' Bound the  value in 0 ~ FFh
        '
        If (Len(txtOutByte.Text) > 2) Then
            'Out of value bound
            lStart = txtOutByte.SelectionStart
            lLength = txtOutByte.SelectionLength
            If lStart <> 0 Then lStart = lStart - 1

            txtOutByte.Text = Hex(txtOutByte.Tag)

            txtOutByte.SelectionStart = lStart
            txtOutByte.SelectionLength = lLength
        End If

        If (Len(txtOutByte.Text) = 0) Then
            ' 0 Value
            txtOutByte.Text = "0"
            txtOutByte.SelectionStart = 0
        End If
        '
        ' Valid Patterm Match value,write this new property value to device.
        '
        sHex = "&H" + txtOutByte.Text
        lStart = Val(sHex)
        txtOutByte.Tag = lStart

    End Sub

    Private Sub Frame1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Frame1.Enter

    End Sub
End Class
