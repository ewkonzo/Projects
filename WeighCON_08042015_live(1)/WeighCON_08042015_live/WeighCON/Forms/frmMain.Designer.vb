<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.mnuMainmenu = New System.Windows.Forms.MenuStrip()
        Me.SystemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSetup = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuLogoff = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTools = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuItemaster = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuUsers = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuReports = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLastLabel = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnulog = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompleteLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuArchive = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistrationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tlsWeigher = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tlsScanner = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tlsUser = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.pteProcessing = New System.Windows.Forms.PictureBox()
        Me.txtBarcodeInput = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtItemCode = New System.Windows.Forms.TextBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.txtPermittedLowerTol = New System.Windows.Forms.TextBox()
        Me.txtTheoriticalmass = New System.Windows.Forms.TextBox()
        Me.txtPermittedUpperTol = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtMassStatus = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtTareMass = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNetMass = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtGrossMass = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtPermittedUpperMass = New System.Windows.Forms.TextBox()
        Me.txtPermittedLowerMass = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.mnuMainmenu.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pteProcessing, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuMainmenu
        '
        Me.mnuMainmenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SystemToolStripMenuItem, Me.mnuTools, Me.mnuReports, Me.HelpToolStripMenuItem})
        Me.mnuMainmenu.Location = New System.Drawing.Point(0, 0)
        Me.mnuMainmenu.Name = "mnuMainmenu"
        Me.mnuMainmenu.Size = New System.Drawing.Size(578, 24)
        Me.mnuMainmenu.TabIndex = 0
        Me.mnuMainmenu.Text = "MenuStrip1"
        '
        'SystemToolStripMenuItem
        '
        Me.SystemToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSetup, Me.ToolStripSeparator3, Me.mnuLogoff})
        Me.SystemToolStripMenuItem.Name = "SystemToolStripMenuItem"
        Me.SystemToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.SystemToolStripMenuItem.Text = "File"
        '
        'mnuSetup
        '
        Me.mnuSetup.Image = CType(resources.GetObject("mnuSetup.Image"), System.Drawing.Image)
        Me.mnuSetup.Name = "mnuSetup"
        Me.mnuSetup.Size = New System.Drawing.Size(117, 22)
        Me.mnuSetup.Text = "Settings"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(114, 6)
        '
        'mnuLogoff
        '
        Me.mnuLogoff.Name = "mnuLogoff"
        Me.mnuLogoff.Size = New System.Drawing.Size(117, 22)
        Me.mnuLogoff.Text = "Logoff..."
        '
        'mnuTools
        '
        Me.mnuTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuItemaster, Me.ToolStripSeparator1, Me.mnuUsers, Me.LogToolStripMenuItem})
        Me.mnuTools.Name = "mnuTools"
        Me.mnuTools.Size = New System.Drawing.Size(44, 20)
        Me.mnuTools.Text = "Tools"
        '
        'mnuItemaster
        '
        Me.mnuItemaster.Image = CType(resources.GetObject("mnuItemaster.Image"), System.Drawing.Image)
        Me.mnuItemaster.Name = "mnuItemaster"
        Me.mnuItemaster.Size = New System.Drawing.Size(133, 22)
        Me.mnuItemaster.Text = "Data Master"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(130, 6)
        '
        'mnuUsers
        '
        Me.mnuUsers.Image = CType(resources.GetObject("mnuUsers.Image"), System.Drawing.Image)
        Me.mnuUsers.Name = "mnuUsers"
        Me.mnuUsers.Size = New System.Drawing.Size(133, 22)
        Me.mnuUsers.Text = "User Setup"
        '
        'LogToolStripMenuItem
        '
        Me.LogToolStripMenuItem.Image = CType(resources.GetObject("LogToolStripMenuItem.Image"), System.Drawing.Image)
        Me.LogToolStripMenuItem.Name = "LogToolStripMenuItem"
        Me.LogToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.LogToolStripMenuItem.Text = "Log"
        '
        'mnuReports
        '
        Me.mnuReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuLastLabel, Me.ToolStripSeparator2, Me.mnulog, Me.mnuArchive})
        Me.mnuReports.Name = "mnuReports"
        Me.mnuReports.Size = New System.Drawing.Size(57, 20)
        Me.mnuReports.Text = "Reports"
        '
        'mnuLastLabel
        '
        Me.mnuLastLabel.Image = CType(resources.GetObject("mnuLastLabel.Image"), System.Drawing.Image)
        Me.mnuLastLabel.Name = "mnuLastLabel"
        Me.mnuLastLabel.Size = New System.Drawing.Size(122, 22)
        Me.mnuLastLabel.Text = "Last Label"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(119, 6)
        '
        'mnulog
        '
        Me.mnulog.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CompleteLogToolStripMenuItem})
        Me.mnulog.Image = CType(resources.GetObject("mnulog.Image"), System.Drawing.Image)
        Me.mnulog.Name = "mnulog"
        Me.mnulog.Size = New System.Drawing.Size(122, 22)
        Me.mnulog.Text = "Log"
        '
        'CompleteLogToolStripMenuItem
        '
        Me.CompleteLogToolStripMenuItem.Name = "CompleteLogToolStripMenuItem"
        Me.CompleteLogToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.CompleteLogToolStripMenuItem.Text = "Complete Log"
        '
        'mnuArchive
        '
        Me.mnuArchive.Image = CType(resources.GetObject("mnuArchive.Image"), System.Drawing.Image)
        Me.mnuArchive.Name = "mnuArchive"
        Me.mnuArchive.Size = New System.Drawing.Size(122, 22)
        Me.mnuArchive.Text = "Archive"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegistrationToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'RegistrationToolStripMenuItem
        '
        Me.RegistrationToolStripMenuItem.Name = "RegistrationToolStripMenuItem"
        Me.RegistrationToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.RegistrationToolStripMenuItem.Text = "Registration"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.AllowMerge = False
        Me.StatusStrip1.AutoSize = False
        Me.StatusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tlsWeigher, Me.tlsScanner, Me.tlsUser, Me.ToolStripStatusLabel1})
        Me.StatusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 435)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(2, 0, 14, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(578, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tlsWeigher
        '
        Me.tlsWeigher.Name = "tlsWeigher"
        Me.tlsWeigher.Size = New System.Drawing.Size(0, 0)
        Me.tlsWeigher.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tlsScanner
        '
        Me.tlsScanner.Name = "tlsScanner"
        Me.tlsScanner.Size = New System.Drawing.Size(0, 0)
        Me.tlsScanner.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tlsUser
        '
        Me.tlsUser.Name = "tlsUser"
        Me.tlsUser.Size = New System.Drawing.Size(0, 0)
        Me.tlsUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 0)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.pteProcessing)
        Me.GroupBox1.Controls.Add(Me.txtBarcodeInput)
        Me.GroupBox1.Font = New System.Drawing.Font("Agency FB", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(554, 76)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Product Barcode"
        '
        'pteProcessing
        '
        Me.pteProcessing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pteProcessing.Image = Global.PrintPro.My.Resources.Resources.loading
        Me.pteProcessing.Location = New System.Drawing.Point(514, 26)
        Me.pteProcessing.Name = "pteProcessing"
        Me.pteProcessing.Size = New System.Drawing.Size(35, 41)
        Me.pteProcessing.TabIndex = 2
        Me.pteProcessing.TabStop = False
        '
        'txtBarcodeInput
        '
        Me.txtBarcodeInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBarcodeInput.Font = New System.Drawing.Font("Agency FB", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcodeInput.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtBarcodeInput.Location = New System.Drawing.Point(21, 22)
        Me.txtBarcodeInput.Name = "txtBarcodeInput"
        Me.txtBarcodeInput.Size = New System.Drawing.Size(486, 40)
        Me.txtBarcodeInput.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtItemCode)
        Me.GroupBox2.Controls.Add(Me.txtDescription)
        Me.GroupBox2.Controls.Add(Me.txtPermittedLowerTol)
        Me.GroupBox2.Controls.Add(Me.txtTheoriticalmass)
        Me.GroupBox2.Controls.Add(Me.txtPermittedUpperTol)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 110)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(554, 143)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Item Details"
        '
        'txtItemCode
        '
        Me.txtItemCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemCode.Location = New System.Drawing.Point(111, 17)
        Me.txtItemCode.Name = "txtItemCode"
        Me.txtItemCode.Size = New System.Drawing.Size(172, 25)
        Me.txtItemCode.TabIndex = 4
        Me.txtItemCode.TabStop = False
        '
        'txtDescription
        '
        Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescription.Location = New System.Drawing.Point(111, 48)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(437, 25)
        Me.txtDescription.TabIndex = 4
        Me.txtDescription.TabStop = False
        '
        'txtPermittedLowerTol
        '
        Me.txtPermittedLowerTol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPermittedLowerTol.Location = New System.Drawing.Point(376, 108)
        Me.txtPermittedLowerTol.Name = "txtPermittedLowerTol"
        Me.txtPermittedLowerTol.Size = New System.Drawing.Size(172, 25)
        Me.txtPermittedLowerTol.TabIndex = 4
        Me.txtPermittedLowerTol.TabStop = False
        '
        'txtTheoriticalmass
        '
        Me.txtTheoriticalmass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTheoriticalmass.Location = New System.Drawing.Point(111, 79)
        Me.txtTheoriticalmass.Name = "txtTheoriticalmass"
        Me.txtTheoriticalmass.Size = New System.Drawing.Size(125, 25)
        Me.txtTheoriticalmass.TabIndex = 4
        Me.txtTheoriticalmass.TabStop = False
        '
        'txtPermittedUpperTol
        '
        Me.txtPermittedUpperTol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPermittedUpperTol.Location = New System.Drawing.Point(376, 77)
        Me.txtPermittedUpperTol.Name = "txtPermittedUpperTol"
        Me.txtPermittedUpperTol.Size = New System.Drawing.Size(172, 25)
        Me.txtPermittedUpperTol.TabIndex = 4
        Me.txtPermittedUpperTol.TabStop = False
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(242, 108)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(128, 32)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Permitted L. Tol % "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 79)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 17)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Theoretical Mass"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Description"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(242, 78)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(131, 48)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Permitted U. Tol % "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 17)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Item Code"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtMassStatus)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.txtTareMass)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.txtNetMass)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.txtGrossMass)
        Me.GroupBox3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(12, 258)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(266, 142)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Scale Status"
        '
        'txtMassStatus
        '
        Me.txtMassStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMassStatus.Location = New System.Drawing.Point(111, 96)
        Me.txtMassStatus.Name = "txtMassStatus"
        Me.txtMassStatus.Size = New System.Drawing.Size(149, 25)
        Me.txtMassStatus.TabIndex = 4
        Me.txtMassStatus.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 68)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 17)
        Me.Label12.TabIndex = 3
        Me.Label12.Text = "Net Mass"
        '
        'txtTareMass
        '
        Me.txtTareMass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTareMass.Location = New System.Drawing.Point(111, 42)
        Me.txtTareMass.Name = "txtTareMass"
        Me.txtTareMass.Size = New System.Drawing.Size(149, 25)
        Me.txtTareMass.TabIndex = 4
        Me.txtTareMass.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(3, 95)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 17)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Mass Status"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 17)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Gross Mass"
        '
        'txtNetMass
        '
        Me.txtNetMass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNetMass.Location = New System.Drawing.Point(111, 69)
        Me.txtNetMass.Name = "txtNetMass"
        Me.txtNetMass.Size = New System.Drawing.Size(149, 25)
        Me.txtNetMass.TabIndex = 4
        Me.txtNetMass.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(3, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 17)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Tare Mass"
        '
        'txtGrossMass
        '
        Me.txtGrossMass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGrossMass.Location = New System.Drawing.Point(111, 15)
        Me.txtGrossMass.Name = "txtGrossMass"
        Me.txtGrossMass.Size = New System.Drawing.Size(149, 25)
        Me.txtGrossMass.TabIndex = 4
        Me.txtGrossMass.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.txtPermittedUpperMass)
        Me.GroupBox4.Controls.Add(Me.txtPermittedLowerMass)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(284, 258)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(281, 145)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Scale Status"
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(18, 15)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(83, 48)
        Me.Label14.TabIndex = 3
        Me.Label14.Text = "Permitted Upper Mass"
        '
        'txtPermittedUpperMass
        '
        Me.txtPermittedUpperMass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPermittedUpperMass.Location = New System.Drawing.Point(107, 18)
        Me.txtPermittedUpperMass.Name = "txtPermittedUpperMass"
        Me.txtPermittedUpperMass.Size = New System.Drawing.Size(169, 25)
        Me.txtPermittedUpperMass.TabIndex = 4
        Me.txtPermittedUpperMass.TabStop = False
        '
        'txtPermittedLowerMass
        '
        Me.txtPermittedLowerMass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPermittedLowerMass.Location = New System.Drawing.Point(106, 69)
        Me.txtPermittedLowerMass.Name = "txtPermittedLowerMass"
        Me.txtPermittedLowerMass.Size = New System.Drawing.Size(170, 25)
        Me.txtPermittedLowerMass.TabIndex = 4
        Me.txtPermittedLowerMass.TabStop = False
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(18, 60)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(83, 46)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "Permitted Lower Mass"
        '
        'Timer1
        '
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 500
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(578, 457)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.mnuMainmenu)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.mnuMainmenu
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PrintPro"
        Me.mnuMainmenu.ResumeLayout(False)
        Me.mnuMainmenu.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pteProcessing, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mnuMainmenu As System.Windows.Forms.MenuStrip
    Friend WithEvents SystemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuReports As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTools As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tlsScanner As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtBarcodeInput As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtItemCode As System.Windows.Forms.TextBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtPermittedLowerTol As System.Windows.Forms.TextBox
    Friend WithEvents txtTheoriticalmass As System.Windows.Forms.TextBox
    Friend WithEvents txtPermittedUpperTol As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtMassStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtTareMass As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtNetMass As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtGrossMass As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtPermittedUpperMass As System.Windows.Forms.TextBox
    Friend WithEvents txtPermittedLowerMass As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents mnuLastLabel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnulog As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CompleteLogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuArchive As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuItemaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuUsers As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSetup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuLogoff As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tlsWeigher As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tlsUser As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents pteProcessing As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents RegistrationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
End Class
