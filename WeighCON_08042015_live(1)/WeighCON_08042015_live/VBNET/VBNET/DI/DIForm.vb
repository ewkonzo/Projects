Public Class frmDI
    Inherits System.Windows.Forms.Form
    Dim isInitializing As Boolean
    Dim chkBitArray(7) As CheckBox
    Dim radHBitArray(7) As RadioButton
    Dim radLBitArray(7) As RadioButton

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        isInitializing = True
        InitializeComponent()

        radHBitArray(0) = radHBit_0
        radHBitArray(1) = radHBit_1
        radHBitArray(2) = radHBit_2
        radHBitArray(3) = radHBit_3
        radHBitArray(4) = radHBit_4
        radHBitArray(5) = radHBit_5
        radHBitArray(6) = radHBit_6
        radHBitArray(7) = radHBit_7

        radLBitArray(0) = radLBit_0
        radLBitArray(1) = radLBit_1
        radLBitArray(2) = radLBit_2
        radLBitArray(3) = radLBit_3
        radLBitArray(4) = radLBit_4
        radLBitArray(5) = radLBit_5
        radLBitArray(6) = radLBit_6
        radLBitArray(7) = radLBit_7

        chkBitArray(0) = chkBit_0
        chkBitArray(1) = chkBit_1
        chkBitArray(2) = chkBit_2
        chkBitArray(3) = chkBit_3
        chkBitArray(4) = chkBit_4
        chkBitArray(5) = chkBit_5
        chkBitArray(6) = chkBit_6
        chkBitArray(7) = chkBit_7

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
    Public WithEvents Frame6 As System.Windows.Forms.GroupBox
    Public WithEvents txtFilter As System.Windows.Forms.TextBox
    Public WithEvents txtData As System.Windows.Forms.TextBox
    Public WithEvents chkMatchEnabled As System.Windows.Forms.CheckBox
    Public WithEvents _Label7_9 As System.Windows.Forms.Label
    Public WithEvents _Label7_8 As System.Windows.Forms.Label
    Public WithEvents _Label7_7 As System.Windows.Forms.Label
    Public WithEvents _Label7_6 As System.Windows.Forms.Label
    Public WithEvents _Label7_5 As System.Windows.Forms.Label
    Public WithEvents _Label7_4 As System.Windows.Forms.Label
    Public WithEvents _Label7_3 As System.Windows.Forms.Label
    Public WithEvents _Label7_2 As System.Windows.Forms.Label
    Public WithEvents _Label7_1 As System.Windows.Forms.Label
    Public WithEvents _Label7_0 As System.Windows.Forms.Label
    Public WithEvents Frame5 As System.Windows.Forms.GroupBox
    Public WithEvents cmdEventScan As System.Windows.Forms.Button
    Public WithEvents cmdEventStop As System.Windows.Forms.Button
    Public WithEvents txtScanTime As System.Windows.Forms.TextBox
    Public WithEvents cmdBitStop As System.Windows.Forms.Button
    Public WithEvents cmdBitScan As System.Windows.Forms.Button
    Public WithEvents cmdByteStop As System.Windows.Forms.Button
    Public WithEvents cmdByteScan As System.Windows.Forms.Button
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents txtDeviceNum As System.Windows.Forms.TextBox
    Public WithEvents txtDeviceName As System.Windows.Forms.TextBox
    Public WithEvents cmdSelectDevice As System.Windows.Forms.Button
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents cmdExit As System.Windows.Forms.Button
    Public WithEvents Frame2 As System.Windows.Forms.GroupBox
    Public WithEvents cmbBit As System.Windows.Forms.ComboBox
    Public WithEvents cmbPort As System.Windows.Forms.ComboBox
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Frame3 As System.Windows.Forms.GroupBox
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents Frame4 As System.Windows.Forms.GroupBox
    Public WithEvents cmdBitRead As System.Windows.Forms.Button
    Public WithEvents cmdByteRead As System.Windows.Forms.Button
    Public WithEvents txtDIData As System.Windows.Forms.TextBox
    Friend WithEvents txtEventNum As System.Windows.Forms.TextBox
    Friend WithEvents txtMatchNum As System.Windows.Forms.TextBox
    Public WithEvents chkBit_7 As System.Windows.Forms.CheckBox
    Public WithEvents chkBit_6 As System.Windows.Forms.CheckBox
    Public WithEvents chkBit_5 As System.Windows.Forms.CheckBox
    Public WithEvents chkBit_4 As System.Windows.Forms.CheckBox
    Public WithEvents chkBit_3 As System.Windows.Forms.CheckBox
    Public WithEvents chkBit_2 As System.Windows.Forms.CheckBox
    Public WithEvents chkBit_1 As System.Windows.Forms.CheckBox
    Public WithEvents chkBit_0 As System.Windows.Forms.CheckBox
    Public WithEvents radHBit_6 As System.Windows.Forms.RadioButton
    Public WithEvents radHBit_5 As System.Windows.Forms.RadioButton
    Public WithEvents radLBit_5 As System.Windows.Forms.RadioButton
    Public WithEvents radHBit_4 As System.Windows.Forms.RadioButton
    Public WithEvents radLBit_4 As System.Windows.Forms.RadioButton
    Public WithEvents radHBit_3 As System.Windows.Forms.RadioButton
    Public WithEvents radLBit_3 As System.Windows.Forms.RadioButton
    Public WithEvents radHBit_2 As System.Windows.Forms.RadioButton
    Public WithEvents radLBit_2 As System.Windows.Forms.RadioButton
    Public WithEvents radHBit_1 As System.Windows.Forms.RadioButton
    Public WithEvents radLBit_1 As System.Windows.Forms.RadioButton
    Public WithEvents radLBit_0 As System.Windows.Forms.RadioButton
    Public WithEvents radHBit_0 As System.Windows.Forms.RadioButton
    Public WithEvents radHBit_7 As System.Windows.Forms.RadioButton
    Public WithEvents radLBit_7 As System.Windows.Forms.RadioButton
    Public WithEvents radLBit_6 As System.Windows.Forms.RadioButton
    Public WithEvents Frame7_7 As System.Windows.Forms.GroupBox
    Public WithEvents Frame7_6 As System.Windows.Forms.GroupBox
    Public WithEvents Frame7_5 As System.Windows.Forms.GroupBox
    Public WithEvents Frame7_4 As System.Windows.Forms.GroupBox
    Public WithEvents Frame7_3 As System.Windows.Forms.GroupBox
    Public WithEvents Frame7_2 As System.Windows.Forms.GroupBox
    Public WithEvents Frame7_1 As System.Windows.Forms.GroupBox
    Public WithEvents Frame7_0 As System.Windows.Forms.GroupBox
    Friend WithEvents DAQDI1 As AxDAQDILib.AxDAQDI
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDI))
        Me.txtDeviceNum = New System.Windows.Forms.TextBox()
        Me.txtDeviceName = New System.Windows.Forms.TextBox()
        Me.cmdSelectDevice = New System.Windows.Forms.Button()
        Me.Frame6 = New System.Windows.Forms.GroupBox()
        Me.Frame7_7 = New System.Windows.Forms.GroupBox()
        Me.radHBit_7 = New System.Windows.Forms.RadioButton()
        Me.radLBit_7 = New System.Windows.Forms.RadioButton()
        Me.Frame7_6 = New System.Windows.Forms.GroupBox()
        Me.radHBit_6 = New System.Windows.Forms.RadioButton()
        Me.radLBit_6 = New System.Windows.Forms.RadioButton()
        Me.Frame7_5 = New System.Windows.Forms.GroupBox()
        Me.radHBit_5 = New System.Windows.Forms.RadioButton()
        Me.radLBit_5 = New System.Windows.Forms.RadioButton()
        Me.Frame7_4 = New System.Windows.Forms.GroupBox()
        Me.radHBit_4 = New System.Windows.Forms.RadioButton()
        Me.radLBit_4 = New System.Windows.Forms.RadioButton()
        Me.Frame7_3 = New System.Windows.Forms.GroupBox()
        Me.radHBit_3 = New System.Windows.Forms.RadioButton()
        Me.radLBit_3 = New System.Windows.Forms.RadioButton()
        Me.Frame7_2 = New System.Windows.Forms.GroupBox()
        Me.radHBit_2 = New System.Windows.Forms.RadioButton()
        Me.radLBit_2 = New System.Windows.Forms.RadioButton()
        Me.Frame7_1 = New System.Windows.Forms.GroupBox()
        Me.radHBit_1 = New System.Windows.Forms.RadioButton()
        Me.radLBit_1 = New System.Windows.Forms.RadioButton()
        Me.Frame7_0 = New System.Windows.Forms.GroupBox()
        Me.radLBit_0 = New System.Windows.Forms.RadioButton()
        Me.radHBit_0 = New System.Windows.Forms.RadioButton()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.txtData = New System.Windows.Forms.TextBox()
        Me.chkMatchEnabled = New System.Windows.Forms.CheckBox()
        Me.chkBit_7 = New System.Windows.Forms.CheckBox()
        Me.chkBit_6 = New System.Windows.Forms.CheckBox()
        Me.chkBit_5 = New System.Windows.Forms.CheckBox()
        Me.chkBit_4 = New System.Windows.Forms.CheckBox()
        Me.chkBit_3 = New System.Windows.Forms.CheckBox()
        Me.chkBit_2 = New System.Windows.Forms.CheckBox()
        Me.chkBit_1 = New System.Windows.Forms.CheckBox()
        Me.chkBit_0 = New System.Windows.Forms.CheckBox()
        Me._Label7_9 = New System.Windows.Forms.Label()
        Me._Label7_8 = New System.Windows.Forms.Label()
        Me._Label7_7 = New System.Windows.Forms.Label()
        Me._Label7_6 = New System.Windows.Forms.Label()
        Me._Label7_5 = New System.Windows.Forms.Label()
        Me._Label7_4 = New System.Windows.Forms.Label()
        Me._Label7_3 = New System.Windows.Forms.Label()
        Me._Label7_2 = New System.Windows.Forms.Label()
        Me._Label7_1 = New System.Windows.Forms.Label()
        Me._Label7_0 = New System.Windows.Forms.Label()
        Me.Frame5 = New System.Windows.Forms.GroupBox()
        Me.cmdEventScan = New System.Windows.Forms.Button()
        Me.cmdEventStop = New System.Windows.Forms.Button()
        Me.txtScanTime = New System.Windows.Forms.TextBox()
        Me.cmdBitStop = New System.Windows.Forms.Button()
        Me.cmdBitScan = New System.Windows.Forms.Button()
        Me.cmdByteStop = New System.Windows.Forms.Button()
        Me.cmdByteScan = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.Frame2 = New System.Windows.Forms.GroupBox()
        Me.cmbBit = New System.Windows.Forms.ComboBox()
        Me.cmbPort = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Frame3 = New System.Windows.Forms.GroupBox()
        Me.txtMatchNum = New System.Windows.Forms.TextBox()
        Me.txtEventNum = New System.Windows.Forms.TextBox()
        Me.txtDIData = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Frame4 = New System.Windows.Forms.GroupBox()
        Me.cmdBitRead = New System.Windows.Forms.Button()
        Me.cmdByteRead = New System.Windows.Forms.Button()
        Me.DAQDI1 = New AxDAQDILib.AxDAQDI()
        Me.Frame6.SuspendLayout()
        Me.Frame7_7.SuspendLayout()
        Me.Frame7_6.SuspendLayout()
        Me.Frame7_5.SuspendLayout()
        Me.Frame7_4.SuspendLayout()
        Me.Frame7_3.SuspendLayout()
        Me.Frame7_2.SuspendLayout()
        Me.Frame7_1.SuspendLayout()
        Me.Frame7_0.SuspendLayout()
        Me.Frame5.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.Frame2.SuspendLayout()
        Me.Frame3.SuspendLayout()
        Me.Frame4.SuspendLayout()
        CType(Me.DAQDI1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtDeviceNum
        '
        Me.txtDeviceNum.AcceptsReturn = True
        Me.txtDeviceNum.BackColor = System.Drawing.SystemColors.Window
        Me.txtDeviceNum.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDeviceNum.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeviceNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDeviceNum.Location = New System.Drawing.Point(48, 28)
        Me.txtDeviceNum.MaxLength = 0
        Me.txtDeviceNum.Name = "txtDeviceNum"
        Me.txtDeviceNum.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDeviceNum.Size = New System.Drawing.Size(57, 20)
        Me.txtDeviceNum.TabIndex = 3
        Me.txtDeviceNum.Text = "-100"
        '
        'txtDeviceName
        '
        Me.txtDeviceName.AcceptsReturn = True
        Me.txtDeviceName.BackColor = System.Drawing.SystemColors.Window
        Me.txtDeviceName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDeviceName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeviceName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDeviceName.Location = New System.Drawing.Point(48, 55)
        Me.txtDeviceName.MaxLength = 0
        Me.txtDeviceName.Name = "txtDeviceName"
        Me.txtDeviceName.ReadOnly = True
        Me.txtDeviceName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDeviceName.Size = New System.Drawing.Size(264, 20)
        Me.txtDeviceName.TabIndex = 2
        Me.txtDeviceName.Text = "AdvanTech"
        '
        'cmdSelectDevice
        '
        Me.cmdSelectDevice.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSelectDevice.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSelectDevice.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSelectDevice.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSelectDevice.Location = New System.Drawing.Point(176, 18)
        Me.cmdSelectDevice.Name = "cmdSelectDevice"
        Me.cmdSelectDevice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSelectDevice.Size = New System.Drawing.Size(97, 29)
        Me.cmdSelectDevice.TabIndex = 1
        Me.cmdSelectDevice.Text = "&Select Device"
        Me.cmdSelectDevice.UseVisualStyleBackColor = False
        '
        'Frame6
        '
        Me.Frame6.BackColor = System.Drawing.SystemColors.Control
        Me.Frame6.Controls.Add(Me.Frame7_7)
        Me.Frame6.Controls.Add(Me.Frame7_6)
        Me.Frame6.Controls.Add(Me.Frame7_5)
        Me.Frame6.Controls.Add(Me.Frame7_4)
        Me.Frame6.Controls.Add(Me.Frame7_3)
        Me.Frame6.Controls.Add(Me.Frame7_2)
        Me.Frame6.Controls.Add(Me.Frame7_1)
        Me.Frame6.Controls.Add(Me.Frame7_0)
        Me.Frame6.Controls.Add(Me.txtFilter)
        Me.Frame6.Controls.Add(Me.txtData)
        Me.Frame6.Controls.Add(Me.chkMatchEnabled)
        Me.Frame6.Controls.Add(Me.chkBit_7)
        Me.Frame6.Controls.Add(Me.chkBit_6)
        Me.Frame6.Controls.Add(Me.chkBit_5)
        Me.Frame6.Controls.Add(Me.chkBit_4)
        Me.Frame6.Controls.Add(Me.chkBit_3)
        Me.Frame6.Controls.Add(Me.chkBit_2)
        Me.Frame6.Controls.Add(Me.chkBit_1)
        Me.Frame6.Controls.Add(Me.chkBit_0)
        Me.Frame6.Controls.Add(Me._Label7_9)
        Me.Frame6.Controls.Add(Me._Label7_8)
        Me.Frame6.Controls.Add(Me._Label7_7)
        Me.Frame6.Controls.Add(Me._Label7_6)
        Me.Frame6.Controls.Add(Me._Label7_5)
        Me.Frame6.Controls.Add(Me._Label7_4)
        Me.Frame6.Controls.Add(Me._Label7_3)
        Me.Frame6.Controls.Add(Me._Label7_2)
        Me.Frame6.Controls.Add(Me._Label7_1)
        Me.Frame6.Controls.Add(Me._Label7_0)
        Me.Frame6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame6.Location = New System.Drawing.Point(8, 305)
        Me.Frame6.Name = "Frame6"
        Me.Frame6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame6.Size = New System.Drawing.Size(432, 166)
        Me.Frame6.TabIndex = 32
        Me.Frame6.TabStop = False
        Me.Frame6.Text = "Pattern Match Setting"
        '
        'Frame7_7
        '
        Me.Frame7_7.BackColor = System.Drawing.SystemColors.Control
        Me.Frame7_7.Controls.Add(Me.radHBit_7)
        Me.Frame7_7.Controls.Add(Me.radLBit_7)
        Me.Frame7_7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame7_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame7_7.Location = New System.Drawing.Point(320, 92)
        Me.Frame7_7.Name = "Frame7_7"
        Me.Frame7_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame7_7.Size = New System.Drawing.Size(25, 57)
        Me.Frame7_7.TabIndex = 74
        Me.Frame7_7.TabStop = False
        '
        'radHBit_7
        '
        Me.radHBit_7.BackColor = System.Drawing.SystemColors.Control
        Me.radHBit_7.Cursor = System.Windows.Forms.Cursors.Default
        Me.radHBit_7.Enabled = False
        Me.radHBit_7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radHBit_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.radHBit_7.Location = New System.Drawing.Point(6, 16)
        Me.radHBit_7.Name = "radHBit_7"
        Me.radHBit_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.radHBit_7.Size = New System.Drawing.Size(16, 15)
        Me.radHBit_7.TabIndex = 76
        Me.radHBit_7.TabStop = True
        Me.radHBit_7.UseVisualStyleBackColor = False
        '
        'radLBit_7
        '
        Me.radLBit_7.BackColor = System.Drawing.SystemColors.Control
        Me.radLBit_7.Cursor = System.Windows.Forms.Cursors.Default
        Me.radLBit_7.Enabled = False
        Me.radLBit_7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radLBit_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.radLBit_7.Location = New System.Drawing.Point(6, 35)
        Me.radLBit_7.Name = "radLBit_7"
        Me.radLBit_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.radLBit_7.Size = New System.Drawing.Size(16, 15)
        Me.radLBit_7.TabIndex = 75
        Me.radLBit_7.TabStop = True
        Me.radLBit_7.UseVisualStyleBackColor = False
        '
        'Frame7_6
        '
        Me.Frame7_6.BackColor = System.Drawing.SystemColors.Control
        Me.Frame7_6.Controls.Add(Me.radHBit_6)
        Me.Frame7_6.Controls.Add(Me.radLBit_6)
        Me.Frame7_6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame7_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame7_6.Location = New System.Drawing.Point(280, 92)
        Me.Frame7_6.Name = "Frame7_6"
        Me.Frame7_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame7_6.Size = New System.Drawing.Size(25, 57)
        Me.Frame7_6.TabIndex = 71
        Me.Frame7_6.TabStop = False
        '
        'radHBit_6
        '
        Me.radHBit_6.BackColor = System.Drawing.SystemColors.Control
        Me.radHBit_6.Cursor = System.Windows.Forms.Cursors.Default
        Me.radHBit_6.Enabled = False
        Me.radHBit_6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radHBit_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.radHBit_6.Location = New System.Drawing.Point(6, 16)
        Me.radHBit_6.Name = "radHBit_6"
        Me.radHBit_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.radHBit_6.Size = New System.Drawing.Size(16, 15)
        Me.radHBit_6.TabIndex = 73
        Me.radHBit_6.TabStop = True
        Me.radHBit_6.UseVisualStyleBackColor = False
        '
        'radLBit_6
        '
        Me.radLBit_6.BackColor = System.Drawing.SystemColors.Control
        Me.radLBit_6.Cursor = System.Windows.Forms.Cursors.Default
        Me.radLBit_6.Enabled = False
        Me.radLBit_6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radLBit_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.radLBit_6.Location = New System.Drawing.Point(6, 35)
        Me.radLBit_6.Name = "radLBit_6"
        Me.radLBit_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.radLBit_6.Size = New System.Drawing.Size(16, 15)
        Me.radLBit_6.TabIndex = 72
        Me.radLBit_6.TabStop = True
        Me.radLBit_6.UseVisualStyleBackColor = False
        '
        'Frame7_5
        '
        Me.Frame7_5.BackColor = System.Drawing.SystemColors.Control
        Me.Frame7_5.Controls.Add(Me.radHBit_5)
        Me.Frame7_5.Controls.Add(Me.radLBit_5)
        Me.Frame7_5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame7_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame7_5.Location = New System.Drawing.Point(240, 92)
        Me.Frame7_5.Name = "Frame7_5"
        Me.Frame7_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame7_5.Size = New System.Drawing.Size(25, 57)
        Me.Frame7_5.TabIndex = 68
        Me.Frame7_5.TabStop = False
        '
        'radHBit_5
        '
        Me.radHBit_5.BackColor = System.Drawing.SystemColors.Control
        Me.radHBit_5.Cursor = System.Windows.Forms.Cursors.Default
        Me.radHBit_5.Enabled = False
        Me.radHBit_5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radHBit_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.radHBit_5.Location = New System.Drawing.Point(6, 16)
        Me.radHBit_5.Name = "radHBit_5"
        Me.radHBit_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.radHBit_5.Size = New System.Drawing.Size(16, 15)
        Me.radHBit_5.TabIndex = 70
        Me.radHBit_5.TabStop = True
        Me.radHBit_5.UseVisualStyleBackColor = False
        '
        'radLBit_5
        '
        Me.radLBit_5.BackColor = System.Drawing.SystemColors.Control
        Me.radLBit_5.Cursor = System.Windows.Forms.Cursors.Default
        Me.radLBit_5.Enabled = False
        Me.radLBit_5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radLBit_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.radLBit_5.Location = New System.Drawing.Point(6, 35)
        Me.radLBit_5.Name = "radLBit_5"
        Me.radLBit_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.radLBit_5.Size = New System.Drawing.Size(16, 15)
        Me.radLBit_5.TabIndex = 69
        Me.radLBit_5.TabStop = True
        Me.radLBit_5.UseVisualStyleBackColor = False
        '
        'Frame7_4
        '
        Me.Frame7_4.BackColor = System.Drawing.SystemColors.Control
        Me.Frame7_4.Controls.Add(Me.radHBit_4)
        Me.Frame7_4.Controls.Add(Me.radLBit_4)
        Me.Frame7_4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame7_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame7_4.Location = New System.Drawing.Point(200, 92)
        Me.Frame7_4.Name = "Frame7_4"
        Me.Frame7_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame7_4.Size = New System.Drawing.Size(25, 57)
        Me.Frame7_4.TabIndex = 65
        Me.Frame7_4.TabStop = False
        '
        'radHBit_4
        '
        Me.radHBit_4.BackColor = System.Drawing.SystemColors.Control
        Me.radHBit_4.Cursor = System.Windows.Forms.Cursors.Default
        Me.radHBit_4.Enabled = False
        Me.radHBit_4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radHBit_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.radHBit_4.Location = New System.Drawing.Point(6, 16)
        Me.radHBit_4.Name = "radHBit_4"
        Me.radHBit_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.radHBit_4.Size = New System.Drawing.Size(16, 15)
        Me.radHBit_4.TabIndex = 67
        Me.radHBit_4.TabStop = True
        Me.radHBit_4.UseVisualStyleBackColor = False
        '
        'radLBit_4
        '
        Me.radLBit_4.BackColor = System.Drawing.SystemColors.Control
        Me.radLBit_4.Cursor = System.Windows.Forms.Cursors.Default
        Me.radLBit_4.Enabled = False
        Me.radLBit_4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radLBit_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.radLBit_4.Location = New System.Drawing.Point(6, 35)
        Me.radLBit_4.Name = "radLBit_4"
        Me.radLBit_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.radLBit_4.Size = New System.Drawing.Size(16, 15)
        Me.radLBit_4.TabIndex = 66
        Me.radLBit_4.TabStop = True
        Me.radLBit_4.UseVisualStyleBackColor = False
        '
        'Frame7_3
        '
        Me.Frame7_3.BackColor = System.Drawing.SystemColors.Control
        Me.Frame7_3.Controls.Add(Me.radHBit_3)
        Me.Frame7_3.Controls.Add(Me.radLBit_3)
        Me.Frame7_3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame7_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame7_3.Location = New System.Drawing.Point(160, 92)
        Me.Frame7_3.Name = "Frame7_3"
        Me.Frame7_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame7_3.Size = New System.Drawing.Size(25, 57)
        Me.Frame7_3.TabIndex = 62
        Me.Frame7_3.TabStop = False
        '
        'radHBit_3
        '
        Me.radHBit_3.BackColor = System.Drawing.SystemColors.Control
        Me.radHBit_3.Cursor = System.Windows.Forms.Cursors.Default
        Me.radHBit_3.Enabled = False
        Me.radHBit_3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radHBit_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.radHBit_3.Location = New System.Drawing.Point(6, 16)
        Me.radHBit_3.Name = "radHBit_3"
        Me.radHBit_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.radHBit_3.Size = New System.Drawing.Size(16, 15)
        Me.radHBit_3.TabIndex = 64
        Me.radHBit_3.TabStop = True
        Me.radHBit_3.UseVisualStyleBackColor = False
        '
        'radLBit_3
        '
        Me.radLBit_3.BackColor = System.Drawing.SystemColors.Control
        Me.radLBit_3.Cursor = System.Windows.Forms.Cursors.Default
        Me.radLBit_3.Enabled = False
        Me.radLBit_3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radLBit_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.radLBit_3.Location = New System.Drawing.Point(6, 35)
        Me.radLBit_3.Name = "radLBit_3"
        Me.radLBit_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.radLBit_3.Size = New System.Drawing.Size(16, 15)
        Me.radLBit_3.TabIndex = 63
        Me.radLBit_3.TabStop = True
        Me.radLBit_3.UseVisualStyleBackColor = False
        '
        'Frame7_2
        '
        Me.Frame7_2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame7_2.Controls.Add(Me.radHBit_2)
        Me.Frame7_2.Controls.Add(Me.radLBit_2)
        Me.Frame7_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame7_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame7_2.Location = New System.Drawing.Point(120, 92)
        Me.Frame7_2.Name = "Frame7_2"
        Me.Frame7_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame7_2.Size = New System.Drawing.Size(25, 57)
        Me.Frame7_2.TabIndex = 59
        Me.Frame7_2.TabStop = False
        '
        'radHBit_2
        '
        Me.radHBit_2.BackColor = System.Drawing.SystemColors.Control
        Me.radHBit_2.Cursor = System.Windows.Forms.Cursors.Default
        Me.radHBit_2.Enabled = False
        Me.radHBit_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radHBit_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.radHBit_2.Location = New System.Drawing.Point(6, 16)
        Me.radHBit_2.Name = "radHBit_2"
        Me.radHBit_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.radHBit_2.Size = New System.Drawing.Size(16, 15)
        Me.radHBit_2.TabIndex = 61
        Me.radHBit_2.TabStop = True
        Me.radHBit_2.UseVisualStyleBackColor = False
        '
        'radLBit_2
        '
        Me.radLBit_2.BackColor = System.Drawing.SystemColors.Control
        Me.radLBit_2.Cursor = System.Windows.Forms.Cursors.Default
        Me.radLBit_2.Enabled = False
        Me.radLBit_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radLBit_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.radLBit_2.Location = New System.Drawing.Point(6, 35)
        Me.radLBit_2.Name = "radLBit_2"
        Me.radLBit_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.radLBit_2.Size = New System.Drawing.Size(16, 15)
        Me.radLBit_2.TabIndex = 60
        Me.radLBit_2.TabStop = True
        Me.radLBit_2.UseVisualStyleBackColor = False
        '
        'Frame7_1
        '
        Me.Frame7_1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame7_1.Controls.Add(Me.radHBit_1)
        Me.Frame7_1.Controls.Add(Me.radLBit_1)
        Me.Frame7_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame7_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame7_1.Location = New System.Drawing.Point(80, 92)
        Me.Frame7_1.Name = "Frame7_1"
        Me.Frame7_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame7_1.Size = New System.Drawing.Size(25, 57)
        Me.Frame7_1.TabIndex = 56
        Me.Frame7_1.TabStop = False
        '
        'radHBit_1
        '
        Me.radHBit_1.BackColor = System.Drawing.SystemColors.Control
        Me.radHBit_1.Cursor = System.Windows.Forms.Cursors.Default
        Me.radHBit_1.Enabled = False
        Me.radHBit_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radHBit_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.radHBit_1.Location = New System.Drawing.Point(6, 16)
        Me.radHBit_1.Name = "radHBit_1"
        Me.radHBit_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.radHBit_1.Size = New System.Drawing.Size(16, 15)
        Me.radHBit_1.TabIndex = 58
        Me.radHBit_1.TabStop = True
        Me.radHBit_1.UseVisualStyleBackColor = False
        '
        'radLBit_1
        '
        Me.radLBit_1.BackColor = System.Drawing.SystemColors.Control
        Me.radLBit_1.Cursor = System.Windows.Forms.Cursors.Default
        Me.radLBit_1.Enabled = False
        Me.radLBit_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radLBit_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.radLBit_1.Location = New System.Drawing.Point(6, 35)
        Me.radLBit_1.Name = "radLBit_1"
        Me.radLBit_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.radLBit_1.Size = New System.Drawing.Size(16, 15)
        Me.radLBit_1.TabIndex = 57
        Me.radLBit_1.TabStop = True
        Me.radLBit_1.UseVisualStyleBackColor = False
        '
        'Frame7_0
        '
        Me.Frame7_0.BackColor = System.Drawing.SystemColors.Control
        Me.Frame7_0.Controls.Add(Me.radLBit_0)
        Me.Frame7_0.Controls.Add(Me.radHBit_0)
        Me.Frame7_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame7_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame7_0.Location = New System.Drawing.Point(40, 92)
        Me.Frame7_0.Name = "Frame7_0"
        Me.Frame7_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame7_0.Size = New System.Drawing.Size(24, 56)
        Me.Frame7_0.TabIndex = 53
        Me.Frame7_0.TabStop = False
        '
        'radLBit_0
        '
        Me.radLBit_0.BackColor = System.Drawing.SystemColors.Control
        Me.radLBit_0.Cursor = System.Windows.Forms.Cursors.Default
        Me.radLBit_0.Enabled = False
        Me.radLBit_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radLBit_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.radLBit_0.Location = New System.Drawing.Point(6, 35)
        Me.radLBit_0.Name = "radLBit_0"
        Me.radLBit_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.radLBit_0.Size = New System.Drawing.Size(16, 18)
        Me.radLBit_0.TabIndex = 55
        Me.radLBit_0.TabStop = True
        Me.radLBit_0.UseVisualStyleBackColor = False
        '
        'radHBit_0
        '
        Me.radHBit_0.BackColor = System.Drawing.SystemColors.Control
        Me.radHBit_0.Cursor = System.Windows.Forms.Cursors.Default
        Me.radHBit_0.Enabled = False
        Me.radHBit_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radHBit_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.radHBit_0.Location = New System.Drawing.Point(6, 16)
        Me.radHBit_0.Name = "radHBit_0"
        Me.radHBit_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.radHBit_0.Size = New System.Drawing.Size(16, 15)
        Me.radHBit_0.TabIndex = 54
        Me.radHBit_0.TabStop = True
        Me.radHBit_0.UseVisualStyleBackColor = False
        '
        'txtFilter
        '
        Me.txtFilter.AcceptsReturn = True
        Me.txtFilter.BackColor = System.Drawing.SystemColors.Window
        Me.txtFilter.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFilter.Enabled = False
        Me.txtFilter.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFilter.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFilter.Location = New System.Drawing.Point(352, 74)
        Me.txtFilter.MaxLength = 0
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFilter.Size = New System.Drawing.Size(57, 20)
        Me.txtFilter.TabIndex = 52
        Me.txtFilter.Text = "Text2"
        '
        'txtData
        '
        Me.txtData.AcceptsReturn = True
        Me.txtData.BackColor = System.Drawing.SystemColors.Window
        Me.txtData.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtData.Enabled = False
        Me.txtData.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtData.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtData.Location = New System.Drawing.Point(352, 102)
        Me.txtData.MaxLength = 0
        Me.txtData.Name = "txtData"
        Me.txtData.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtData.Size = New System.Drawing.Size(57, 20)
        Me.txtData.TabIndex = 51
        Me.txtData.Text = "Text2"
        '
        'chkMatchEnabled
        '
        Me.chkMatchEnabled.BackColor = System.Drawing.SystemColors.Control
        Me.chkMatchEnabled.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkMatchEnabled.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMatchEnabled.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkMatchEnabled.Location = New System.Drawing.Point(48, 28)
        Me.chkMatchEnabled.Name = "chkMatchEnabled"
        Me.chkMatchEnabled.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkMatchEnabled.Size = New System.Drawing.Size(201, 19)
        Me.chkMatchEnabled.TabIndex = 46
        Me.chkMatchEnabled.Text = "Enable Pattern Match Event Mode"
        Me.chkMatchEnabled.UseVisualStyleBackColor = False
        '
        'chkBit_7
        '
        Me.chkBit_7.BackColor = System.Drawing.SystemColors.Control
        Me.chkBit_7.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkBit_7.Enabled = False
        Me.chkBit_7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBit_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkBit_7.Location = New System.Drawing.Point(328, 74)
        Me.chkBit_7.Name = "chkBit_7"
        Me.chkBit_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkBit_7.Size = New System.Drawing.Size(9, 19)
        Me.chkBit_7.TabIndex = 44
        Me.chkBit_7.UseVisualStyleBackColor = False
        '
        'chkBit_6
        '
        Me.chkBit_6.BackColor = System.Drawing.SystemColors.Control
        Me.chkBit_6.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkBit_6.Enabled = False
        Me.chkBit_6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBit_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkBit_6.Location = New System.Drawing.Point(288, 74)
        Me.chkBit_6.Name = "chkBit_6"
        Me.chkBit_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkBit_6.Size = New System.Drawing.Size(9, 19)
        Me.chkBit_6.TabIndex = 43
        Me.chkBit_6.UseVisualStyleBackColor = False
        '
        'chkBit_5
        '
        Me.chkBit_5.BackColor = System.Drawing.SystemColors.Control
        Me.chkBit_5.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkBit_5.Enabled = False
        Me.chkBit_5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBit_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkBit_5.Location = New System.Drawing.Point(248, 74)
        Me.chkBit_5.Name = "chkBit_5"
        Me.chkBit_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkBit_5.Size = New System.Drawing.Size(9, 19)
        Me.chkBit_5.TabIndex = 42
        Me.chkBit_5.UseVisualStyleBackColor = False
        '
        'chkBit_4
        '
        Me.chkBit_4.BackColor = System.Drawing.SystemColors.Control
        Me.chkBit_4.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkBit_4.Enabled = False
        Me.chkBit_4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBit_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkBit_4.Location = New System.Drawing.Point(208, 74)
        Me.chkBit_4.Name = "chkBit_4"
        Me.chkBit_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkBit_4.Size = New System.Drawing.Size(9, 19)
        Me.chkBit_4.TabIndex = 41
        Me.chkBit_4.UseVisualStyleBackColor = False
        '
        'chkBit_3
        '
        Me.chkBit_3.BackColor = System.Drawing.SystemColors.Control
        Me.chkBit_3.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkBit_3.Enabled = False
        Me.chkBit_3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBit_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkBit_3.Location = New System.Drawing.Point(168, 74)
        Me.chkBit_3.Name = "chkBit_3"
        Me.chkBit_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkBit_3.Size = New System.Drawing.Size(9, 19)
        Me.chkBit_3.TabIndex = 40
        Me.chkBit_3.UseVisualStyleBackColor = False
        '
        'chkBit_2
        '
        Me.chkBit_2.BackColor = System.Drawing.SystemColors.Control
        Me.chkBit_2.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkBit_2.Enabled = False
        Me.chkBit_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBit_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkBit_2.Location = New System.Drawing.Point(128, 74)
        Me.chkBit_2.Name = "chkBit_2"
        Me.chkBit_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkBit_2.Size = New System.Drawing.Size(9, 19)
        Me.chkBit_2.TabIndex = 39
        Me.chkBit_2.UseVisualStyleBackColor = False
        '
        'chkBit_1
        '
        Me.chkBit_1.BackColor = System.Drawing.SystemColors.Control
        Me.chkBit_1.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkBit_1.Enabled = False
        Me.chkBit_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBit_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkBit_1.Location = New System.Drawing.Point(88, 74)
        Me.chkBit_1.Name = "chkBit_1"
        Me.chkBit_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkBit_1.Size = New System.Drawing.Size(9, 19)
        Me.chkBit_1.TabIndex = 38
        Me.chkBit_1.UseVisualStyleBackColor = False
        '
        'chkBit_0
        '
        Me.chkBit_0.BackColor = System.Drawing.SystemColors.Control
        Me.chkBit_0.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkBit_0.Enabled = False
        Me.chkBit_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBit_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkBit_0.Location = New System.Drawing.Point(48, 74)
        Me.chkBit_0.Name = "chkBit_0"
        Me.chkBit_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkBit_0.Size = New System.Drawing.Size(9, 19)
        Me.chkBit_0.TabIndex = 37
        Me.chkBit_0.UseVisualStyleBackColor = False
        '
        '_Label7_9
        '
        Me._Label7_9.BackColor = System.Drawing.SystemColors.Control
        Me._Label7_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label7_9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label7_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label7_9.Location = New System.Drawing.Point(8, 102)
        Me._Label7_9.Name = "_Label7_9"
        Me._Label7_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label7_9.Size = New System.Drawing.Size(32, 19)
        Me._Label7_9.TabIndex = 35
        Me._Label7_9.Text = "High"
        '
        '_Label7_8
        '
        Me._Label7_8.BackColor = System.Drawing.SystemColors.Control
        Me._Label7_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label7_8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label7_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label7_8.Location = New System.Drawing.Point(8, 120)
        Me._Label7_8.Name = "_Label7_8"
        Me._Label7_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label7_8.Size = New System.Drawing.Size(25, 20)
        Me._Label7_8.TabIndex = 34
        Me._Label7_8.Text = "Low"
        '
        '_Label7_7
        '
        Me._Label7_7.BackColor = System.Drawing.SystemColors.Control
        Me._Label7_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label7_7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label7_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label7_7.Location = New System.Drawing.Point(128, 55)
        Me._Label7_7.Name = "_Label7_7"
        Me._Label7_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label7_7.Size = New System.Drawing.Size(24, 20)
        Me._Label7_7.TabIndex = 33
        Me._Label7_7.Text = "Bit2"
        '
        '_Label7_6
        '
        Me._Label7_6.BackColor = System.Drawing.SystemColors.Control
        Me._Label7_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label7_6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label7_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label7_6.Location = New System.Drawing.Point(168, 55)
        Me._Label7_6.Name = "_Label7_6"
        Me._Label7_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label7_6.Size = New System.Drawing.Size(24, 20)
        Me._Label7_6.TabIndex = 32
        Me._Label7_6.Text = "Bit3"
        '
        '_Label7_5
        '
        Me._Label7_5.BackColor = System.Drawing.SystemColors.Control
        Me._Label7_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label7_5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label7_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label7_5.Location = New System.Drawing.Point(208, 55)
        Me._Label7_5.Name = "_Label7_5"
        Me._Label7_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label7_5.Size = New System.Drawing.Size(24, 20)
        Me._Label7_5.TabIndex = 31
        Me._Label7_5.Text = "Bit4"
        '
        '_Label7_4
        '
        Me._Label7_4.BackColor = System.Drawing.SystemColors.Control
        Me._Label7_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label7_4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label7_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label7_4.Location = New System.Drawing.Point(248, 55)
        Me._Label7_4.Name = "_Label7_4"
        Me._Label7_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label7_4.Size = New System.Drawing.Size(24, 20)
        Me._Label7_4.TabIndex = 30
        Me._Label7_4.Text = "Bit5"
        '
        '_Label7_3
        '
        Me._Label7_3.BackColor = System.Drawing.SystemColors.Control
        Me._Label7_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label7_3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label7_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label7_3.Location = New System.Drawing.Point(288, 55)
        Me._Label7_3.Name = "_Label7_3"
        Me._Label7_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label7_3.Size = New System.Drawing.Size(24, 20)
        Me._Label7_3.TabIndex = 29
        Me._Label7_3.Text = "Bit6"
        '
        '_Label7_2
        '
        Me._Label7_2.BackColor = System.Drawing.SystemColors.Control
        Me._Label7_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label7_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label7_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label7_2.Location = New System.Drawing.Point(328, 55)
        Me._Label7_2.Name = "_Label7_2"
        Me._Label7_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label7_2.Size = New System.Drawing.Size(24, 20)
        Me._Label7_2.TabIndex = 28
        Me._Label7_2.Text = "Bit7"
        '
        '_Label7_1
        '
        Me._Label7_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label7_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label7_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label7_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label7_1.Location = New System.Drawing.Point(88, 55)
        Me._Label7_1.Name = "_Label7_1"
        Me._Label7_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label7_1.Size = New System.Drawing.Size(24, 20)
        Me._Label7_1.TabIndex = 27
        Me._Label7_1.Text = "Bit1"
        '
        '_Label7_0
        '
        Me._Label7_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label7_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label7_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label7_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label7_0.Location = New System.Drawing.Point(48, 55)
        Me._Label7_0.Name = "_Label7_0"
        Me._Label7_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label7_0.Size = New System.Drawing.Size(24, 20)
        Me._Label7_0.TabIndex = 26
        Me._Label7_0.Text = "Bit0"
        '
        'Frame5
        '
        Me.Frame5.BackColor = System.Drawing.SystemColors.Control
        Me.Frame5.Controls.Add(Me.cmdEventScan)
        Me.Frame5.Controls.Add(Me.cmdEventStop)
        Me.Frame5.Controls.Add(Me.txtScanTime)
        Me.Frame5.Controls.Add(Me.cmdBitStop)
        Me.Frame5.Controls.Add(Me.cmdBitScan)
        Me.Frame5.Controls.Add(Me.cmdByteStop)
        Me.Frame5.Controls.Add(Me.cmdByteScan)
        Me.Frame5.Controls.Add(Me.Label6)
        Me.Frame5.Controls.Add(Me.Label5)
        Me.Frame5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame5.Location = New System.Drawing.Point(256, 111)
        Me.Frame5.Name = "Frame5"
        Me.Frame5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame5.Size = New System.Drawing.Size(184, 186)
        Me.Frame5.TabIndex = 31
        Me.Frame5.TabStop = False
        Me.Frame5.Text = "ByteScan or BitScan"
        '
        'cmdEventScan
        '
        Me.cmdEventScan.BackColor = System.Drawing.SystemColors.Control
        Me.cmdEventScan.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdEventScan.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEventScan.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdEventScan.Location = New System.Drawing.Point(16, 138)
        Me.cmdEventScan.Name = "cmdEventScan"
        Me.cmdEventScan.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdEventScan.Size = New System.Drawing.Size(72, 29)
        Me.cmdEventScan.TabIndex = 78
        Me.cmdEventScan.Text = "Event Scan"
        Me.cmdEventScan.UseVisualStyleBackColor = False
        '
        'cmdEventStop
        '
        Me.cmdEventStop.BackColor = System.Drawing.SystemColors.Control
        Me.cmdEventStop.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdEventStop.Enabled = False
        Me.cmdEventStop.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEventStop.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdEventStop.Location = New System.Drawing.Point(96, 138)
        Me.cmdEventStop.Name = "cmdEventStop"
        Me.cmdEventStop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdEventStop.Size = New System.Drawing.Size(72, 29)
        Me.cmdEventStop.TabIndex = 77
        Me.cmdEventStop.Text = "Event Stop"
        Me.cmdEventStop.UseVisualStyleBackColor = False
        '
        'txtScanTime
        '
        Me.txtScanTime.AcceptsReturn = True
        Me.txtScanTime.BackColor = System.Drawing.SystemColors.Window
        Me.txtScanTime.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtScanTime.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtScanTime.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtScanTime.Location = New System.Drawing.Point(80, 28)
        Me.txtScanTime.MaxLength = 0
        Me.txtScanTime.Name = "txtScanTime"
        Me.txtScanTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtScanTime.Size = New System.Drawing.Size(49, 20)
        Me.txtScanTime.TabIndex = 23
        '
        'cmdBitStop
        '
        Me.cmdBitStop.BackColor = System.Drawing.SystemColors.Control
        Me.cmdBitStop.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdBitStop.Enabled = False
        Me.cmdBitStop.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBitStop.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdBitStop.Location = New System.Drawing.Point(96, 102)
        Me.cmdBitStop.Name = "cmdBitStop"
        Me.cmdBitStop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdBitStop.Size = New System.Drawing.Size(72, 28)
        Me.cmdBitStop.TabIndex = 21
        Me.cmdBitStop.Text = "Bit Stop"
        Me.cmdBitStop.UseVisualStyleBackColor = False
        '
        'cmdBitScan
        '
        Me.cmdBitScan.BackColor = System.Drawing.SystemColors.Control
        Me.cmdBitScan.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdBitScan.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBitScan.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdBitScan.Location = New System.Drawing.Point(16, 102)
        Me.cmdBitScan.Name = "cmdBitScan"
        Me.cmdBitScan.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdBitScan.Size = New System.Drawing.Size(72, 28)
        Me.cmdBitScan.TabIndex = 20
        Me.cmdBitScan.Text = "Bit Scan"
        Me.cmdBitScan.UseVisualStyleBackColor = False
        '
        'cmdByteStop
        '
        Me.cmdByteStop.BackColor = System.Drawing.SystemColors.Control
        Me.cmdByteStop.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdByteStop.Enabled = False
        Me.cmdByteStop.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdByteStop.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdByteStop.Location = New System.Drawing.Point(96, 65)
        Me.cmdByteStop.Name = "cmdByteStop"
        Me.cmdByteStop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdByteStop.Size = New System.Drawing.Size(72, 28)
        Me.cmdByteStop.TabIndex = 19
        Me.cmdByteStop.Text = "Byte Stop"
        Me.cmdByteStop.UseVisualStyleBackColor = False
        '
        'cmdByteScan
        '
        Me.cmdByteScan.BackColor = System.Drawing.SystemColors.Control
        Me.cmdByteScan.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdByteScan.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdByteScan.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdByteScan.Location = New System.Drawing.Point(16, 65)
        Me.cmdByteScan.Name = "cmdByteScan"
        Me.cmdByteScan.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdByteScan.Size = New System.Drawing.Size(72, 28)
        Me.cmdByteScan.TabIndex = 18
        Me.cmdByteScan.Text = "Byte Scan"
        Me.cmdByteScan.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(136, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(24, 19)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "ms"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(16, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(64, 19)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Scan Time :"
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
        Me.Frame1.Size = New System.Drawing.Size(328, 93)
        Me.Frame1.TabIndex = 26
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
        Me.Label1.Location = New System.Drawing.Point(8, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(29, 14)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "No. :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(8, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(40, 14)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Name :"
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExit.Location = New System.Drawing.Point(344, 65)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExit.Size = New System.Drawing.Size(81, 28)
        Me.cmdExit.TabIndex = 28
        Me.cmdExit.Text = "Close"
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me.cmbBit)
        Me.Frame2.Controls.Add(Me.cmbPort)
        Me.Frame2.Controls.Add(Me.Label4)
        Me.Frame2.Controls.Add(Me.Label3)
        Me.Frame2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(8, 111)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(137, 102)
        Me.Frame2.TabIndex = 27
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Port , Bit Settings"
        '
        'cmbBit
        '
        Me.cmbBit.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBit.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbBit.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7"})
        Me.cmbBit.Location = New System.Drawing.Point(56, 65)
        Me.cmbBit.Name = "cmbBit"
        Me.cmbBit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbBit.Size = New System.Drawing.Size(73, 22)
        Me.cmbBit.TabIndex = 16
        '
        'cmbPort
        '
        Me.cmbPort.BackColor = System.Drawing.SystemColors.Window
        Me.cmbPort.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPort.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPort.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbPort.Items.AddRange(New Object() {"0", "1", "2", "3"})
        Me.cmbPort.Location = New System.Drawing.Point(56, 28)
        Me.cmbPort.Name = "cmbPort"
        Me.cmbPort.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbPort.Size = New System.Drawing.Size(73, 22)
        Me.cmbPort.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(16, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(33, 19)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Bit :"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(16, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(33, 19)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Port :"
        '
        'Frame3
        '
        Me.Frame3.BackColor = System.Drawing.SystemColors.Control
        Me.Frame3.Controls.Add(Me.txtMatchNum)
        Me.Frame3.Controls.Add(Me.txtEventNum)
        Me.Frame3.Controls.Add(Me.txtDIData)
        Me.Frame3.Controls.Add(Me.Label8)
        Me.Frame3.Controls.Add(Me.Label9)
        Me.Frame3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame3.Location = New System.Drawing.Point(8, 222)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3.Size = New System.Drawing.Size(241, 75)
        Me.Frame3.TabIndex = 29
        Me.Frame3.TabStop = False
        Me.Frame3.Text = "Return Data"
        '
        'txtMatchNum
        '
        Me.txtMatchNum.ForeColor = System.Drawing.Color.Blue
        Me.txtMatchNum.Location = New System.Drawing.Point(168, 46)
        Me.txtMatchNum.Name = "txtMatchNum"
        Me.txtMatchNum.Size = New System.Drawing.Size(65, 20)
        Me.txtMatchNum.TabIndex = 52
        '
        'txtEventNum
        '
        Me.txtEventNum.ForeColor = System.Drawing.Color.Blue
        Me.txtEventNum.Location = New System.Drawing.Point(168, 18)
        Me.txtEventNum.Name = "txtEventNum"
        Me.txtEventNum.Size = New System.Drawing.Size(65, 20)
        Me.txtEventNum.TabIndex = 51
        '
        'txtDIData
        '
        Me.txtDIData.AcceptsReturn = True
        Me.txtDIData.BackColor = System.Drawing.SystemColors.Window
        Me.txtDIData.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDIData.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDIData.ForeColor = System.Drawing.Color.Blue
        Me.txtDIData.Location = New System.Drawing.Point(8, 28)
        Me.txtDIData.MaxLength = 0
        Me.txtDIData.Name = "txtDIData"
        Me.txtDIData.ReadOnly = True
        Me.txtDIData.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDIData.Size = New System.Drawing.Size(65, 20)
        Me.txtDIData.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(88, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(72, 20)
        Me.Label8.TabIndex = 50
        Me.Label8.Text = "Event Count :"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(88, 46)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(73, 20)
        Me.Label9.TabIndex = 49
        Me.Label9.Text = "Match Count :"
        '
        'Frame4
        '
        Me.Frame4.BackColor = System.Drawing.SystemColors.Control
        Me.Frame4.Controls.Add(Me.cmdBitRead)
        Me.Frame4.Controls.Add(Me.cmdByteRead)
        Me.Frame4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame4.Location = New System.Drawing.Point(152, 111)
        Me.Frame4.Name = "Frame4"
        Me.Frame4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame4.Size = New System.Drawing.Size(97, 102)
        Me.Frame4.TabIndex = 30
        Me.Frame4.TabStop = False
        Me.Frame4.Text = "Single Read"
        '
        'cmdBitRead
        '
        Me.cmdBitRead.BackColor = System.Drawing.SystemColors.Control
        Me.cmdBitRead.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdBitRead.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBitRead.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdBitRead.Location = New System.Drawing.Point(16, 65)
        Me.cmdBitRead.Name = "cmdBitRead"
        Me.cmdBitRead.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdBitRead.Size = New System.Drawing.Size(65, 28)
        Me.cmdBitRead.TabIndex = 15
        Me.cmdBitRead.Text = "Bit Read"
        Me.cmdBitRead.UseVisualStyleBackColor = False
        '
        'cmdByteRead
        '
        Me.cmdByteRead.BackColor = System.Drawing.SystemColors.Control
        Me.cmdByteRead.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdByteRead.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdByteRead.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdByteRead.Location = New System.Drawing.Point(16, 28)
        Me.cmdByteRead.Name = "cmdByteRead"
        Me.cmdByteRead.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdByteRead.Size = New System.Drawing.Size(65, 29)
        Me.cmdByteRead.TabIndex = 14
        Me.cmdByteRead.Text = "Byte Read"
        Me.cmdByteRead.UseVisualStyleBackColor = False
        '
        'DAQDI1
        '
        Me.DAQDI1.Enabled = True
        Me.DAQDI1.Location = New System.Drawing.Point(368, 9)
        Me.DAQDI1.Name = "DAQDI1"
        Me.DAQDI1.OcxState = CType(resources.GetObject("DAQDI1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.DAQDI1.Size = New System.Drawing.Size(33, 33)
        Me.DAQDI1.TabIndex = 33
        '
        'frmDI
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 15)
        Me.ClientSize = New System.Drawing.Size(457, 472)
        Me.Controls.Add(Me.DAQDI1)
        Me.Controls.Add(Me.Frame5)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.Frame3)
        Me.Controls.Add(Me.Frame4)
        Me.Controls.Add(Me.Frame6)
        Me.MaximizeBox = False
        Me.Name = "frmDI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Digital Input"
        Me.Frame6.ResumeLayout(False)
        Me.Frame6.PerformLayout()
        Me.Frame7_7.ResumeLayout(False)
        Me.Frame7_6.ResumeLayout(False)
        Me.Frame7_5.ResumeLayout(False)
        Me.Frame7_4.ResumeLayout(False)
        Me.Frame7_3.ResumeLayout(False)
        Me.Frame7_2.ResumeLayout(False)
        Me.Frame7_1.ResumeLayout(False)
        Me.Frame7_0.ResumeLayout(False)
        Me.Frame5.ResumeLayout(False)
        Me.Frame5.PerformLayout()
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.Frame2.ResumeLayout(False)
        Me.Frame3.ResumeLayout(False)
        Me.Frame3.PerformLayout()
        Me.Frame4.ResumeLayout(False)
        CType(Me.DAQDI1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim bRet As Boolean
    Dim nTemp(10) As Short
    Dim lEventCount As Integer
    Dim lMatchCount As Integer

 

    Private Sub chkMatchEnabled_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMatchEnabled.CheckedChanged
        If (isInitializing) Then
            Exit Sub
        End If
        DisplayPattern()
    End Sub

    Private Sub cmbBit_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbBit.SelectedIndexChanged
        'may fire when form is initialized
        If (isInitializing) Then
            Exit Sub
        End If
        DAQDI1.Bit = cmbBit.SelectedIndex
    End Sub

    Private Sub cmbPort_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbPort.SelectedIndexChanged
        'may fire when form is initialized
        If (isInitializing) Then
            Exit Sub
        End If
        DAQDI1.Port = cmbPort.SelectedIndex
    End Sub

    Private Sub cmdBitRead_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBitRead.Click
        bRet = DAQDI1.OpenDevice
        If bRet Then
            MsgBox(DAQDI1.ErrorMessage, MsgBoxStyle.OKOnly)
            Exit Sub
        End If
        DAQDI1.Port = cmbPort.SelectedIndex
        DAQDI1.Bit = cmbBit.SelectedIndex
        txtDIData.Text = CStr(DAQDI1.BitInput)
        bRet = DAQDI1.CloseDevice
        If bRet Then
            MsgBox(DAQDI1.ErrorMessage, MsgBoxStyle.OKOnly)
            Exit Sub
        End If
    End Sub

    Private Sub cmdBitScan_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBitScan.Click
        bRet = DAQDI1.OpenDevice
        If bRet Then
            MsgBox(DAQDI1.ErrorMessage, MsgBoxStyle.OKOnly)
            Exit Sub
        End If

        cmdBitScan.Enabled = False
        cmdByteScan.Enabled = False
        cmdEventScan.Enabled = False
        DAQDI1.Port = cmbPort.SelectedIndex
        DAQDI1.Bit = cmbBit.SelectedIndex

        bRet = DAQDI1.EnableBitScan(True)
        If bRet Then
            cmdBitScan.Enabled = True
            cmdByteScan.Enabled = True
            MsgBox(DAQDI1.ErrorMessage, MsgBoxStyle.OKOnly)
            Exit Sub
        End If

        cmdBitStop.Enabled = True
        cmdByteStop.Enabled = False
        cmdEventStop.Enabled = False
        cmdExit.Enabled = False
        cmdSelectDevice.Enabled = False


    End Sub

    Private Sub cmdBitStop_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBitStop.Click

        cmdBitStop.Enabled = False
        bRet = DAQDI1.EnableBitScan(False)
        If bRet Then
            MsgBox(DAQDI1.ErrorMessage, MsgBoxStyle.OKOnly)
            Exit Sub
        End If

        cmdBitScan.Enabled = True
        cmdByteScan.Enabled = True
        cmdEventScan.Enabled = True
        cmdExit.Enabled = True
        cmdSelectDevice.Enabled = True

        bRet = DAQDI1.CloseDevice
        If bRet Then
            MsgBox(DAQDI1.ErrorMessage, MsgBoxStyle.OKOnly)
            Exit Sub
        End If
    End Sub

    Private Sub cmdByteRead_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdByteRead.Click
        bRet = DAQDI1.OpenDevice
        If bRet Then
            MsgBox(DAQDI1.ErrorMessage, MsgBoxStyle.OKOnly)
            Exit Sub
        End If

        DAQDI1.Port = cmbPort.SelectedIndex
        txtDIData.Text = Hex(DAQDI1.ByteInput)

        bRet = DAQDI1.CloseDevice
        If bRet Then
            MsgBox(DAQDI1.ErrorMessage, MsgBoxStyle.OKOnly)
            Exit Sub
        End If
    End Sub

    Private Sub cmdByteScan_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdByteScan.Click
        bRet = DAQDI1.OpenDevice
        If bRet Then
            MsgBox(DAQDI1.ErrorMessage, MsgBoxStyle.OKOnly)
            Exit Sub
        End If

        cmdByteScan.Enabled = False
        cmdBitScan.Enabled = False
        cmdEventScan.Enabled = False

        DAQDI1.Port = cmbPort.SelectedIndex
        txtDIData.Text = Hex(DAQDI1.ByteInput)
        bRet = DAQDI1.EnableByteScan(True)
        If bRet Then
            cmdByteScan.Enabled = True
            cmdBitScan.Enabled = True
            MsgBox(DAQDI1.ErrorMessage, MsgBoxStyle.OKOnly)
            Exit Sub
        End If

        cmdByteStop.Enabled = True
        cmdBitStop.Enabled = False
        cmdEventScan.Enabled = False
        cmdExit.Enabled = False
        cmdSelectDevice.Enabled = False




    End Sub

    Private Sub cmdByteStop_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdByteStop.Click


        cmdByteStop.Enabled = False
        bRet = DAQDI1.EnableByteScan(False)
        If bRet Then
            MsgBox(DAQDI1.ErrorMessage, MsgBoxStyle.OKOnly)
            Exit Sub
        End If

        cmdByteScan.Enabled = True
        cmdBitScan.Enabled = True
        cmdEventScan.Enabled = True
        cmdExit.Enabled = True
        cmdSelectDevice.Enabled = True
        bRet = DAQDI1.CloseDevice
        If bRet Then
            MsgBox(DAQDI1.ErrorMessage, MsgBoxStyle.OKOnly)
            Exit Sub
        End If
    End Sub

    Private Sub cmdEventScan_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEventScan.Click
        bRet = DAQDI1.OpenDevice
        If bRet Then
            MsgBox(DAQDI1.ErrorMessage, MsgBoxStyle.OKOnly)
            Exit Sub
        End If

        DAQDI1.Port = cmbPort.SelectedIndex
        DAQDI1.Bit = cmbBit.SelectedIndex

        bRet = DAQDI1.EnableEvent(True)
        If bRet Then
            cmdBitScan.Enabled = True
            cmdByteScan.Enabled = True
            MsgBox(DAQDI1.ErrorMessage, MsgBoxStyle.OKOnly)
            Exit Sub
        End If

        cmdBitScan.Enabled = False
        cmdByteScan.Enabled = False
        cmdEventScan.Enabled = False

        cmdEventStop.Enabled = True
        cmdBitStop.Enabled = False
        cmdByteStop.Enabled = False
        cmdExit.Enabled = False
        cmdSelectDevice.Enabled = False


    End Sub

    Private Sub cmdEventStop_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEventStop.Click

        cmdEventStop.Enabled = False
        bRet = DAQDI1.EnableEvent(False)
        If bRet Then
            MsgBox(DAQDI1.ErrorMessage, MsgBoxStyle.OKOnly)
            Exit Sub
        End If

        cmdByteScan.Enabled = True
        cmdBitScan.Enabled = True
        cmdEventScan.Enabled = True
        cmdExit.Enabled = True
        cmdSelectDevice.Enabled = True
        lMatchCount = 0
        lEventCount = 0
        txtEventNum.Text = CStr(lEventCount)
        bRet = DAQDI1.CloseDevice
        If bRet Then
            MsgBox(DAQDI1.ErrorMessage, MsgBoxStyle.OKOnly)
            Exit Sub
        End If

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


        ' Open Device
        If DAQDI1.OpenDevice Then
            MsgBox(DAQDI1.ErrorMessage, MsgBoxStyle.OKOnly)
            Exit Sub
        End If

        If DAQDI1.MaxPortNumber = 0 Then
            MsgBox("Function Not Supported", MsgBoxStyle.OKOnly)
            Me.Close()
            End
        End If
        ' Add Port number to list box
        cmbPort.Items.Clear()
        For i = 0 To DAQDI1.MaxPortNumber - 1
            cmbPort.Items.Add((Str(i)))
        Next i
        If DAQDI1.MaxPortNumber Then
            cmbPort.SelectedIndex = DAQDI1.Port
        End If

    End Sub




    Private Sub txtDeviceNum_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtDeviceNum.TextChanged
        'may fire when form is initialized
        If (isInitializing) Then
            Exit Sub
        End If

        DAQDI1.DeviceNumber = Val(txtDeviceNum.Text)
        txtDeviceName.Text = DAQDI1.DeviceName
    End Sub

    Private Sub txtScanTime_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtScanTime.TextChanged
        'may fire when form is initialized
        If (isInitializing) Then
            Exit Sub
        End If
        DAQDI1.ScanTime = Val(txtScanTime.Text)
    End Sub

    Private Sub DisplayPattern()
        Dim i As Short
        Dim nFilter As Short
        Dim nData As Short

        nFilter = DAQDI1.PatternMatchFilter
        nData = DAQDI1.PatternMatchData

        nFilter = nFilter And 255
        nData = nData And 255

        If chkMatchEnabled.CheckState = System.Windows.Forms.CheckState.Checked Then
            DAQDI1.PatternMatchEnabled = True
        Else
            DAQDI1.PatternMatchEnabled = False
        End If

        If DAQDI1.PatternMatchEnabled = True Then
            For i = 0 To 7
                chkBitArray(i).Enabled = True
                If (nFilter And nTemp(i)) = nTemp(i) Then
                    chkBitArray(i).Checked = True
                    radHBitArray(i).Enabled = True
                    radLBitArray(i).Enabled = True
                Else
                    chkBitArray(i).Checked = False
                    radHBitArray(i).Enabled = False
                    radLBitArray(i).Enabled = False
                End If
            Next
        Else
            For i = 0 To 7
                chkBitArray(i).Enabled = False
                radHBitArray(i).Enabled = False
                radLBitArray(i).Enabled = False
                If (nFilter And nTemp(i)) = nTemp(i) Then
                    chkBitArray(i).CheckState = System.Windows.Forms.CheckState.Checked
                Else
                    chkBitArray(i).CheckState = System.Windows.Forms.CheckState.Unchecked
                End If
            Next
        End If
        For i = 0 To 7
            If (nData And nTemp(i)) = nTemp(i) Then
                radHBitArray(i).Checked = True
                radLBitArray(i).Checked = False
            Else
                radHBitArray(i).Checked = False
                radLBitArray(i).Checked = True
            End If
        Next
    End Sub

    Private Sub CheckFilter(ByRef nIndex As Short)
        Dim nFilter As Short

        nFilter = DAQDI1.PatternMatchFilter
        nFilter = nFilter And 255

        If chkBitArray(nIndex).Checked = True Then
            nFilter = nFilter Or nTemp(nIndex)
            radHBitArray(nIndex).Enabled = True
            radLBitArray(nIndex).Enabled = True
        Else
            nFilter = nFilter And (Not (nTemp(nIndex)))
            radHBitArray(nIndex).Enabled = False
            radLBitArray(nIndex).Enabled = False
        End If

        nFilter = nFilter And 255

        DAQDI1.PatternMatchFilter = nFilter
        txtFilter.Text = Hex(nFilter)

    End Sub

    Private Sub checkData(ByRef nIndex As Short, ByRef bHighBit As Boolean)
        Dim nData As Short

        nData = DAQDI1.PatternMatchData
        nData = nData And 255

        If bHighBit = True Then
            If radHBitArray(nIndex).Checked = True Then
                radLBitArray(nIndex).Checked = False
                nData = nData Or nTemp(nIndex)
            Else
                radLBitArray(nIndex).Checked = True
                nData = nData And (Not nTemp(nIndex))
            End If
        Else
            If radLBitArray(nIndex).Checked = True Then
                radHBitArray(nIndex).Checked = False
                nData = nData And (Not nTemp(nIndex))
            Else
                radHBitArray(nIndex).Checked = True
                nData = nData Or nTemp(nIndex)
            End If

        End If

        nData = nData And 255

        DAQDI1.PatternMatchData = nData
        txtData.Text = Hex(nData)

    End Sub



    Private Sub frmDI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call cmdSelectDevice_Click(cmdSelectDevice, New System.EventArgs)

        lEventCount = 0
        lMatchCount = 0

        txtScanTime.Text = CStr(DAQDI1.ScanTime)
        txtDeviceNum.Text = CStr(DAQDI1.DeviceNumber)
        txtDeviceName.Text = DAQDI1.DeviceName
        cmdByteStop.Enabled = False
        cmdBitStop.Enabled = False
        cmbPort.SelectedIndex = DAQDI1.Port
        cmbBit.SelectedIndex = DAQDI1.Bit
        nTemp(0) = 1
        nTemp(1) = 2
        nTemp(2) = 4
        nTemp(3) = 8
        nTemp(4) = 16
        nTemp(5) = 32
        nTemp(6) = 64
        nTemp(7) = 128

        txtFilter.Text = CStr(DAQDI1.PatternMatchFilter)
        txtData.Text = CStr(DAQDI1.PatternMatchData)
        If DAQDI1.PatternMatchEnabled = True Then
            chkMatchEnabled.Checked = True
        Else
            chkMatchEnabled.Checked = False
        End If

        txtEventNum.Text = CStr(lEventCount)
        txtMatchNum.Text = CStr(lMatchCount)

        DisplayPattern()
    End Sub

    Private Sub chkBit_0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBit_0.CheckedChanged
        CheckFilter(0)
    End Sub

    Private Sub chkBit_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBit_1.CheckedChanged
        CheckFilter(1)

    End Sub

    Private Sub chkBit_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBit_2.CheckedChanged
        CheckFilter(2)

    End Sub

    Private Sub chkBit_3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBit_3.CheckedChanged
        CheckFilter(3)

    End Sub

    Private Sub chkBit_4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBit_4.CheckedChanged
        CheckFilter(4)

    End Sub

    Private Sub chkBit_5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBit_5.CheckedChanged
        CheckFilter(5)

    End Sub

    Private Sub chkBit_6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBit_6.CheckedChanged
        CheckFilter(6)

    End Sub

    Private Sub chkBit_7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBit_7.CheckedChanged
        CheckFilter(7)

    End Sub

    Private Sub radHBit_0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radHBit_0.CheckedChanged
        checkData(0, True)
    End Sub

    Private Sub radHBit_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radHBit_1.CheckedChanged
        checkData(1, True)

    End Sub

    Private Sub radHBit_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radHBit_2.CheckedChanged
        checkData(2, True)

    End Sub

    Private Sub radHBit_3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radHBit_3.CheckedChanged
        checkData(3, True)

    End Sub

    Private Sub radHBit_4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radHBit_4.CheckedChanged
        checkData(4, True)

    End Sub

    Private Sub radHBit_5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radHBit_5.CheckedChanged
        checkData(5, True)

    End Sub

    Private Sub radHBit_6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radHBit_6.CheckedChanged
        checkData(6, True)

    End Sub

    Private Sub radHBit_7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radHBit_7.CheckedChanged
        checkData(7, True)

    End Sub

    Private Sub radLBit_0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radLBit_0.CheckedChanged
        checkData(0, False)
    End Sub

    Private Sub radLBit_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radLBit_1.CheckedChanged
        checkData(1, False)

    End Sub

    Private Sub radLBit_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radLBit_2.CheckedChanged
        checkData(2, False)

    End Sub

    Private Sub radLBit_3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radLBit_3.CheckedChanged
        checkData(3, False)

    End Sub

    Private Sub radLBit_4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radLBit_4.CheckedChanged
        checkData(4, False)

    End Sub

    Private Sub radLBit_5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radLBit_5.CheckedChanged
        checkData(5, False)

    End Sub

    Private Sub radLBit_6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radLBit_6.CheckedChanged
        checkData(6, False)

    End Sub

    Private Sub radLBit_7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radLBit_7.CheckedChanged
        checkData(7, False)

    End Sub


 
    Private Sub DAQDI1_OnEvent_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DAQDI1.OnEvent
        lEventCount = lEventCount + 1
        txtEventNum.Text = CStr(lEventCount)

    End Sub

    Private Sub DAQDI1_OnBitScan1(ByVal sender As Object, ByVal e As AxDAQDILib._DAddinEvents_OnBitScanEvent) Handles DAQDI1.OnBitScan
        txtDIData.Text = CStr(e.data)

    End Sub

    Private Sub DAQDI1_OnByteScan1(ByVal sender As Object, ByVal e As AxDAQDILib._DAddinEvents_OnByteScanEvent) Handles DAQDI1.OnByteScan
        txtDIData.Text = Hex(DAQDI1.ByteScanValue)

    End Sub

    Private Sub DAQDI1_OnEventPatternMatch1(ByVal sender As Object, ByVal e As System.EventArgs) Handles DAQDI1.OnEventPatternMatch
        lMatchCount = lMatchCount + 1
        If (lMatchCount Mod 9) = 0 Then
            txtMatchNum.Text = CStr(lMatchCount)
        End If

    End Sub
End Class
