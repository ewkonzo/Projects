Imports System.Data
Imports System.IO.Ports
Imports PrintPro.My
Imports System.Text
Imports System.Security
Imports System.Security.Cryptography
Imports System.IO
Imports System.Collections
Imports System.Management
Imports Janus.Windows.GridEX
'Imports Microsoft.Office
Module functions
    Public isAdmin As Boolean
    Public isLogged As Boolean = False
    Public usertype, username As String
    Public currentshift As String
    Public Scannerport As New SerialPort
    Public shift As Integer
    Public Weighport As New SerialPort
    Public Printerport As New SerialPort
    Public datatosend As String
    Dim [error] As Boolean
    Public activatedd As Boolean = False
    Public start As TimeSpan
    Public userid As Integer
    Public Bn As BindingNavigator = Nothing
    Public gxxx() As GridEX = Nothing
    Public addnw, totalrow As InheritableBoolean
    Public groupbox, filter, autosizecol, export, wrap, tcc As Boolean

    Public ma As Padding
    Public sizes As Size
    Public openfile As New OpenFileDialog
    Public fe As Janus.Windows.FilterEditor.FilterEditor = Nothing
    Public Column As Janus.Windows.GridEX.GridEXColumn
    Public ValueList As Janus.Windows.GridEX.GridEXValueListItemCollection
    Public Exporter As ToolStripButton
    Public First, Nxt, Previous, Last, Addnew, Edit, Save, delete As ToolStripItem
    Public WithEvents tc As System.Windows.Forms.ToolStripContainer

    'conveyor
   














    Public Sub init(ByVal fom As Form)
        For Each gxx As GridEX In gxxx

            If filter Then
                fe = New Janus.Windows.FilterEditor.FilterEditor
                fe.AllowFilterByFieldValue = True
                fe.AutoApply = True
                fe.AutomaticHeightResize = True
                fe.BackgroundImage = My.Resources.ll
                fe.BackgroundImageLayout = ImageLayout.Stretch
                fe.SourceControl = gxx
                fe.Dock = DockStyle.Top
                fe.SortFieldList = False
            End If
            If Not gxx Is Nothing Then
                If tcc Then
                    tc = New System.Windows.Forms.ToolStripContainer
                    tc.BottomToolStripPanel.SuspendLayout()
                    tc.SuspendLayout()
                    tc.ContentPanel.Size = New System.Drawing.Size(150, 150)
                    tc.Location = New System.Drawing.Point(8, 8)
                    tc.Name = "ToolStripContainer1"
                    tc.Size = New System.Drawing.Size(150, 175)
                    tc.Text = "ToolStripContainer1"
                    tc.TopToolStripPanelVisible = False
                    tc.BottomToolStripPanel.Controls.Add(Bn)
                    tc.Dock = DockStyle.Fill
                    fom.Controls.Add(tc)
                End If


                'exporter
                If export Then
                    Exporter = New ToolStripButton
                    Bn.Items.Add(Exporter)
                    Exporter.Name = "Exporttoexcel"
                    Exporter.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
                    Exporter.Image = My.Resources.ExcelExport
                    Exporter.Text = "Export to Excel"
                    Dim dd As New Classfunctions
                    dd.Gridex = gxx
                    AddHandler Exporter.Click, AddressOf dd.exporting
                End If

                'gridex
                gxx.BackgroundImage = My.Resources.ll
                gxx.BackgroundImageDrawMode = Janus.Windows.GridEX.BackgroundImageDrawMode.Stretch
                gxx.GroupByBoxVisible = groupbox
                gxx.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
                gxx.AllowAddNew = addnw
                gxx.TotalRow = totalrow
                gxx.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
                gxx.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed
                gxx.Dock = DockStyle.Fill
                gxx.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
                gxx.BringToFront()
                gxx.AllowDelete = InheritableBoolean.True
                gxx.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True
                gxx.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex
                gxx.ColumnAutoResize = autosizecol
                For Each Column As GridEXColumn In gxx.RootTable.Columns
                    Dim sz As New Size(New Point(30, 20))
                    If Column.ColumnType = ColumnType.BoundImage Or Column.ColumnType = ColumnType.Image Then
                        Column.Width = 30
                        Column.BoundImageSize = sz
                        Column.ButtonStyle = ButtonStyle.Ellipsis
                        'Dim dd As New Classfunctions
                        'dd.Gridex = gxx
                        'AddHandler gxx.ColumnButtonClick, AddressOf dd.uploadimages
                    End If
                    Select Case Column.DataTypeCode
                        'Case TypeCode.DateTime
                        '    Column.FormatString = "dd MMM yyyy (ddd)"
                        Case TypeCode.Int16 Or TypeCode.Int32 Or TypeCode.Int64
                            Column.TextAlignment = TextAlignment.Far
                        Case TypeCode.Double
                            Column.FormatString = "0.00"
                            Column.TextAlignment = TextAlignment.Far
                        Case TypeCode.String
                            If Not Column.PasswordChar = "" Then
                                Column.CharacterCasing = CharacterCasing.Upper
                            End If
                            If wrap Then
                                Column.WordWrap = True
                                Column.MaxLines = 10
                            End If

                    End Select

                Next
                'toolstripcontainer
                If tcc Then
                    tc.ContentPanel.Controls.Add(gxx)
                    If filter Then
                        tc.ContentPanel.Controls.Add(fe)
                    End If

                    tc.Dock = DockStyle.Fill
                    tc.BottomToolStripPanel.BackgroundImage = My.Resources.ll
                    tc.BottomToolStripPanel.BackgroundImageLayout = ImageLayout.Stretch
                    tc.BottomToolStripPanel.ResumeLayout(False)
                    tc.BottomToolStripPanel.PerformLayout()
                    tc.ResumeLayout(False)
                    tc.PerformLayout()
                End If

            End If

            'Bindingnavigator
            If Not Addnew Is Nothing Then
                Addnew.Image = My.Resources.add2
                Addnew.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
            End If
            If Not First Is Nothing Then
                First.Image = My.Resources.media_beginning
            End If
            If Not Last Is Nothing Then
                Last.Image = My.Resources.media_end
            End If
            If Not Edit Is Nothing Then
                Edit.Image = My.Resources.edit1
                Edit.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
            End If
            If Not Previous Is Nothing Then
                Previous.Image = My.Resources.nav_left_blue
            End If
            If Not Nxt Is Nothing Then
                Nxt.Image = My.Resources.nav_right_blue
            End If
            If Not delete Is Nothing Then
                delete.Image = My.Resources.delete2
                delete.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
                delete.Margin = ma
            End If
            If Not Save Is Nothing Then
                Save.Image = My.Resources.disks
                Save.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
            End If
            If Not Bn Is Nothing Then
                Bn.ImageScalingSize = sizes
                Bn.Items.Insert(0, Addnew)
                Bn.Items.Insert(Bn.Items.Count - 1, delete)
                Bn.BackgroundImage = My.Resources.ll
                Bn.BackgroundImageLayout = ImageLayout.Stretch
            End If
            If Not gxx Is Nothing Then
                If tcc Then
                    tc.BringToFront()
                End If

            End If
        Next

    End Sub

    Sub gx(ByVal grid() As GridEX, Optional ByVal addnew As InheritableBoolean = InheritableBoolean.True, Optional ByVal fe As Boolean = True, Optional ByVal totalrow As InheritableBoolean = InheritableBoolean.True, Optional ByVal groupb As Boolean = True, Optional ByVal auto As Boolean = False, Optional ByVal expor As Boolean = True, Optional ByVal rap As Boolean = True, Optional ByVal toolstripcontainer As Boolean = True)
        gxxx = grid
        addnw = addnew
        filter = fe
        Functions.totalrow = totalrow
        groupbox = groupb
        autosizecol = auto
        export = expor
        wrap = rap
        tcc = toolstripcontainer
    End Sub
    Sub initializeport()
        Printerport.BaudRate = Integer.Parse(Settings.BaudRate)
        Printerport.DataBits = Integer.Parse(Settings.DataBits)
        Printerport.StopBits = CType([Enum].Parse(GetType(StopBits), Settings.StopBits), StopBits)
        Printerport.Parity = CType([Enum].Parse(GetType(Parity), Settings.Parity), Parity)
        Printerport.PortName = Settings.PortName

        Try
            ' Open the port
            Printerport.Open()
        Catch generatedExceptionName As UnauthorizedAccessException
            [error] = True
        Catch generatedExceptionName As IO.IOException
            [error] = True
        Catch generatedExceptionName As ArgumentException
            [error] = True
        End Try

        If [error] Then
            MessageBox.Show("Could not open the Printer COM port.  Most likely it is already in use, has been removed, or is unavailable.", "COM Port Unavalible", MessageBoxButtons.OK, MessageBoxIcon.[Stop])
        Else
            ' Show the initial pin states
            'UpdatePinState()
            'chkDTR.Checked = comport.DtrEnable
            'chkRTS.Checked = comport.RtsEnable
        End If

        Scannerport.BaudRate = Integer.Parse(Settings.Baudrates)
        Scannerport.DataBits = Integer.Parse(Settings.Databitss)
        Scannerport.StopBits = CType([Enum].Parse(GetType(StopBits), Settings.stopbitss), StopBits)
        Scannerport.Parity = CType([Enum].Parse(GetType(Parity), Settings.paritys), Parity)
        Scannerport.PortName = Settings.portnames

        Try
            ' Open the port
            Scannerport.Open()
        Catch generatedExceptionName As UnauthorizedAccessException
            [error] = True
        Catch generatedExceptionName As IO.IOException
            [error] = True
        Catch generatedExceptionName As ArgumentException
            [error] = True
        End Try

        If [error] Then
            MessageBox.Show("Could not open the Scanner COM port.  Most likely it is already in use, has been removed, or is unavailable.", "COM Port Unavalible", MessageBoxButtons.OK, MessageBoxIcon.[Stop])
        Else
            ' Show the initial pin states
            'UpdatePinState()
            'chkDTR.Checked = comport.DtrEnable
            'chkRTS.Checked = comport.RtsEnable
        End If
        Weighport.BaudRate = Integer.Parse(Settings.baudratew)
        Weighport.DataBits = Integer.Parse(Settings.Databitsw)
        Weighport.StopBits = CType([Enum].Parse(GetType(StopBits), Settings.stopbitw), StopBits)
        Weighport.Parity = CType([Enum].Parse(GetType(Parity), Settings.parityw), Parity)
        Weighport.PortName = Settings.Portnamew
        Weighport.DtrEnable = True


        Try
            ' Open the port
            Weighport.Open()
        Catch generatedExceptionName As UnauthorizedAccessException
            [error] = True
        Catch generatedExceptionName As IO.IOException
            [error] = True
        Catch generatedExceptionName As ArgumentException
            [error] = True
        End Try

        If [error] Then
            MessageBox.Show("Could not open the Scalar COM port.  Most likely it is already in use, has been removed, or is unavailable.", "COM Port Unavalible", MessageBoxButtons.OK, MessageBoxIcon.[Stop])
        Else
            ' Show the initial pin states
            'UpdatePinState()
            'chkDTR.Checked = comport.DtrEnable
            'chkRTS.Checked = comport.RtsEnable
        End If
    End Sub

    Dim passPhrase As String = "PP"
    Dim saltValue As String = "PrintPro"
    Dim hashAlgorithm As String = "SHA1"
    Dim initVector As String = "@1B2c3D4e5F6g7H8" 'must be 16 xters long
    Dim passwordIterations As Integer = 2
    Dim keySize As Integer = 128
   
   
    Public Function sEncrypt(ByVal plainText As String) As String
        On Error GoTo vError

        Dim initVectorBytes() As Byte = Encoding.ASCII.GetBytes(initVector)
        Dim saltValueBytes() As Byte = Encoding.ASCII.GetBytes(saltValue)
        Dim plainTextBytes() As Byte = Encoding.UTF8.GetBytes(plainText)
        Dim password As PasswordDeriveBytes = New PasswordDeriveBytes(passPhrase, _
                                                       saltValueBytes, _
                                                        hashAlgorithm, _
                                                        passwordIterations)
        Dim keyBytes() As Byte = password.GetBytes(keySize / 8)
        Dim symmetricKey As RijndaelManaged = New RijndaelManaged()
        symmetricKey.Mode = CipherMode.CBC
        Dim encryptor As ICryptoTransform = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes)
        Dim memoryStream As MemoryStream = New MemoryStream()
        Dim cryptoStream As CryptoStream = New CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write)
        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length)
        cryptoStream.FlushFinalBlock()
        Dim cipherTextBytes() As Byte = memoryStream.ToArray()
        memoryStream.Close()
        cryptoStream.Close()
        Dim cipherText As String = Convert.ToBase64String(cipherTextBytes)
        Return cipherText

        Exit Function
vError:
        Err.Clear()
    End Function

    Public Function sDecrypt(ByVal cipherText As String) As String
        On Error GoTo vError

        Dim r As String
        Dim initVectorBytes() As Byte = Encoding.ASCII.GetBytes(initVector)
        Dim saltValueBytes() As Byte = Encoding.ASCII.GetBytes(saltValue)
        Dim cipherTextBytes() As Byte = Convert.FromBase64String(cipherText)
        Dim password As PasswordDeriveBytes = New PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations)
        Dim keyBytes() As Byte = password.GetBytes(keySize / 8)
        Dim symmetricKey As RijndaelManaged = New RijndaelManaged()
        symmetricKey.Mode = CipherMode.CBC
        Dim decryptor As ICryptoTransform = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes)
        Dim memoryStream As MemoryStream = New MemoryStream(cipherTextBytes)
        Dim cryptoStream As CryptoStream = New CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read)
        Dim plainTextBytes(cipherTextBytes.Length) As Byte
        Dim decryptedByteCount As Integer = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length)
        memoryStream.Close()
        cryptoStream.Close()
        Dim plainText As String = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount)

        Return plainText

        Exit Function
vError:
        Err.Clear()
    End Function
    Public Function getdriveserial() As String
        Dim hdCollection As New ArrayList()

        Dim searcher As New ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive")

        For Each wmi_HD As ManagementObject In searcher.[Get]()
            If wmi_HD("InterfaceType").ToString() = "IDE" Then
                Dim hd As New HardDrive()

                hd.Model = wmi_HD("Model").ToString()
                hd.Type = wmi_HD("InterfaceType").ToString()
                hdCollection.Add(hd)
            End If
        Next

        searcher = New ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia")

        Dim i As Integer = 0
        For Each wmi_HD As ManagementObject In searcher.[Get]()
            ' get the hard drive from collection
            ' using index
            If hdCollection.Count > i Then


                Dim hd As HardDrive = DirectCast(hdCollection(i), HardDrive)

                ' get the hardware serial no.
                If wmi_HD("SerialNumber") Is Nothing Then
                    hd.SerialNo = "None"
                Else
                    hd.SerialNo = wmi_HD("SerialNumber").ToString()
                End If

                i += 1
            End If
        Next

        Return CType(hdCollection(0), HardDrive).SerialNo.ToString
    End Function
    Public Function Checkserial(ByVal serial As String) As Boolean
        Dim hdCollection As New ArrayList()

        Dim searcher As New ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive")

        For Each wmi_HD As ManagementObject In searcher.[Get]()
            If wmi_HD("InterfaceType").ToString() = "IDE" Then
                Dim hd As New HardDrive()

                hd.Model = wmi_HD("Model").ToString()
                hd.Type = wmi_HD("InterfaceType").ToString()
                hdCollection.Add(hd)
            End If
        Next

        searcher = New ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia")

        Dim i As Integer = 0
        For Each wmi_HD As ManagementObject In searcher.[Get]()
            ' get the hard drive from collection
            ' using index
            If hdCollection.Count > i Then

                Dim hd As HardDrive = DirectCast(hdCollection(i), HardDrive)

                ' get the hardware serial no.
                If wmi_HD("SerialNumber") Is Nothing Then
                    hd.SerialNo = "None"
                Else
                    hd.SerialNo = wmi_HD("SerialNumber").ToString()
                End If
                i += 1
            End If
        Next
        Dim r As Boolean = False
        For Each hd As HardDrive In hdCollection
            If hd.SerialNo = serial Then
                r = True
                Exit For
            End If
        Next
        Return r
    End Function
    Class HardDrive
        Private m_model As String = Nothing
        Private m_type As String = Nothing
        Private m_serialNo As String = Nothing

        Public Property Model() As String
            Get
                Return m_model
            End Get
            Set(ByVal value As String)
                m_model = value
            End Set
        End Property

        Public Property Type() As String
            Get
                Return m_type
            End Get
            Set(ByVal value As String)
                m_type = value
            End Set
        End Property

        Public Property SerialNo() As String
            Get
                Return m_serialNo
            End Get
            Set(ByVal value As String)
                m_serialNo = value
            End Set
        End Property
    End Class
    Public Class clsReportsProcessing
        'namespace ReportEngine
#Region "Variables"
        Dim strReportName As String = "<<Report Name>>"
        Dim strReportTitle As String = "<<Report Title>>"
        Dim strCurrency As String = "<<Currency>>"
        Dim currReportType As ReportTypes = ReportTypes.reportTypeCrystal
        Dim tblReportData As New DataTable
        Dim blnDataSourceSet As Boolean = False
        Dim strReportsLocation As String
        Dim strErrReport As String = ""
        Dim StrLoginId As String = ""
        Dim reportDataSourceType As DataSourceTypes = DataSourceTypes.dtSourceTypeLive
        Dim myCONN As New DbConn

        Public Enum ReportTypes
            reportTypeCrystal = 0
            reportTypeExcel = 1
            reportTypeNotepad = 2
            reportTypeXml = 3
        End Enum

        Public Enum DataSourceTypes
            dtSourceTypeLive = 0
            dtSourceTypeArchive = 1
        End Enum

        Public Structure ReportFiltersStruct
            Public Ref_No As String
            Dim Min_Amount As Decimal
            Dim Max_Amount As Decimal
            Dim Date_From As Date
            Dim Date_To As Date
            Dim Account As String
            Dim BankCode As String
            Dim BranchCode As String
            Dim CurrencyCode As String
            Dim BatchNumber As String
            Dim ProcessingBranch As String
        End Structure
        Public ReportFilters As ReportFiltersStruct
        Dim isArchiveData As Boolean = False
#End Region

#Region "Properties"
        '----- Report Name
        Property ReportName() As String
            Get
                Return strReportName
            End Get
            Set(ByVal value As String)
                strReportName = value
            End Set
        End Property

        '----- Report Title 
        Property ReportTitle()
            Get
                Return strReportTitle
            End Get
            Set(ByVal value)
                strReportTitle = value
            End Set
        End Property
        '------ Report Type
        Property ReportType() As ReportTypes
            Get
                Return currReportType
            End Get
            Set(ByVal value As ReportTypes)
                currReportType = value
            End Set
        End Property
        '----- User Name
        ReadOnly Property ReportUsername()
            Get
                Return StrLoginId
            End Get
        End Property
        '---- Data source
        ReadOnly Property ReportDataSource() As DataTable
            Get
                Return tblReportData
            End Get
        End Property

        Public ReadOnly Property ReportError() As String
            Get
                Return strErrReport
            End Get
        End Property
        '------- Database 
        Public Property DataBaseSource() As DataSourceTypes
            Get
                Return reportDataSourceType
            End Get
            Set(ByVal value As DataSourceTypes)
                reportDataSourceType = value
            End Set
        End Property
#End Region

#Region "Events"
        Public Event ReportProcessError(ByVal ErrorMessage As String)
#End Region

#Region "Methods"
        '------ Process and Show Report
        'Sub ShowReport(Optional ByVal otherFields() As String = Nothing)
        '    Dim strBaseTable As String = ""
        '    Dim ReportDetails As New DataTable
        '    Dim strSql As String = ""
        '    Try
        '        '---- Get The Base Table
        '        myCONN.AccDownload("SELECT TITLE,BASETABLE,SHOWALLDATA,BASETABLETYPE FROM REPORTS WHERE FILENAME='" & Me.ReportName.ToUpper & "'")
        '        If ReportDetails.Rows.Count = 0 Then
        '            RaiseEvent ReportProcessError("Error In Function ShowReport!" & vbNewLine & "Report [" & Me.ReportName.ToUpper & "] is not maintaned in system database.")
        '            Exit Sub
        '        Else
        '            Me.ReportTitle = ReportDetails.Rows(0).Item("TITLE")
        '        End If
        '        '------ If datasource is not loaded load the data ---
        '        If blnDataSourceSet = False Then
        '            '----- Check whether to show all data
        '            ReportDetails.Rows(0).Item("SHOWALLDATA") = IIf(IsDBNull(ReportDetails.Rows(0).Item("SHOWALLDATA")), 0, ReportDetails.Rows(0).Item("SHOWALLDATA"))
        '            If ReportDetails.Rows(0).Item("BASETABLETYPE") = 2 Then '----- Stored Proc
        '                ReportFilters.CurrencyCode = IIf(ReportFilters.CurrencyCode = "ALL", "0", ReportFilters.CurrencyCode)
        '                strSql = ReportDetails.Rows(0).Item("BASETABLE") & " '" & ReportFilters.CurrencyCode & "'"
        '                myCONN.AccDownload(strSql)
        '            Else '-------- Table or Voew
        '                If ReportDetails.Rows(0).Item("SHOWALLDATA") = True Or ReportDetails.Rows(0).Item("SHOWALLDATA") = 1 Then
        '                    strSql = "SELECT * FROM " & ReportDetails.Rows(0).Item("BASETABLE")
        '                    If DataBaseSource = DataSourceTypes.dtSourceTypeArchive Then
        '                        'myConType = dbConnectionTypes.dbConnTypeArchive
        '                        strSql = strSql & " WHERE BACKUPDATE >='" & Format(Me.ReportFilters.Date_From, "dd MMM yyyy") & "' AND BACKUPDATE <='" & Format(Me.ReportFilters.Date_To, "dd MMM yyyy") & "'"
        '                    End If
        '                    myCONN.AccDownload(strSql)
        '                Else
        '                    '------ Create Report data query
        '                    strSql = "SELECT * FROM " & ReportDetails.Rows(0).Item("BASETABLE") & " WHERE (AMOUNT>=" & ReportFilters.Min_Amount & " AND AMOUNT<=" & ReportFilters.Max_Amount & ")"
        '                    '------- Set Account
        '                    If ReportFilters.Account.ToUpper <> "ALL" Then strSql = strSql & " AND (ACCNO='" & ReportFilters.Account & "')"
        '                    '------- Set Ref No
        '                    If ReportFilters.Ref_No.ToUpper <> "ALL" Then strSql = strSql & " AND (REF_NO='" & ReportFilters.Ref_No & "')"
        '                    '------- Set Bank Code
        '                    If ReportFilters.BankCode.ToUpper <> "ALL" Then strSql = strSql & " AND (BKCODE='" & ReportFilters.BankCode & "')"
        '                    '------- Set Branch Code
        '                    If ReportFilters.BranchCode.ToUpper <> "ALL" Then strSql = strSql & " AND (BRCODE='" & ReportFilters.BranchCode & "')"
        '                    '------- Currency Code
        '                    If ReportFilters.CurrencyCode.ToUpper <> "ALL" Then strSql = strSql & " AND (CURRENCYCODE='" & ReportFilters.CurrencyCode & "')"
        '                    '------- Batch Number
        '                    If ReportFilters.BatchNumber.ToUpper <> "ALL" Then strSql = strSql & " AND (BATCHNO='" & ReportFilters.BatchNumber & "')"
        '                    '-------- Processing Branch 
        '                    If ReportFilters.ProcessingBranch.ToUpper <> "ALL" Then strSql = strSql & " AND (PROCBRANCH ='" & ReportFilters.ProcessingBranch & "')"

        '                    If DataBaseSource = DataSourceTypes.dtSourceTypeArchive Then
        '                        strSql = strSql & " AND (BACKUPDATE >='" & Format(Me.ReportFilters.Date_From, "dd MMM yyyy") & "' AND BACKUPDATE <='" & Format(Me.ReportFilters.Date_To, "dd MMM yyyy") & "')"
        '                        'myConType = dbConnectionTypes.dbConnTypeArchive
        '                    End If

        '                    myCONN.AccDownload(strSql)
        '                End If
        '            End If
        '        End If

        '        If tblReportData.Rows.Count = 0 Then
        '            MsgBox("No Records Found!", MsgBoxStyle.Exclamation)
        '            Exit Sub
        '        End If
        '        Select Case ReportType
        '            Case ReportTypes.reportTypeCrystal
        '                Dim myReport As New ReportDocument
        '                '------- Check Whether Report File Exist ---
        '                If IO.File.Exists(strReportsLocation & "Reports\" & Me.ReportName.ToUpper) = False Then
        '                    MsgBox("The Report File[" & Me.ReportName.ToUpper & "] Does Not Exist!", MsgBoxStyle.Exclamation)
        '                    Exit Sub
        '                End If
        '                myReport.Load(strReportsLocation & "Reports\" & Me.ReportName.ToUpper, OpenReportMethod.OpenReportByTempCopy)
        '                myReport.SetDataSource(tblReportData)
        '                '------ set Report Parameters
        '                Try
        '                    'bonni 05042011 after Aggrey's Ultimutum of 1 day.
        '                    'have each of this formula fields passed 
        '                    ' in single try catch so as to avoid any missing
        '                    'to interfere with others
        '                    If myReport.DataDefinition.FormulaFields.Count > 0 Then

        '                        Try
        '                            myReport.DataDefinition.FormulaFields(0).Text = "'" & ReportDetails.Rows(0).Item("TITLE") & "'"
        '                        Catch ex As Exception
        '                        End Try
        '                        Try
        '                            myReport.DataDefinition.FormulaFields("BReportName").Text = "'" & ReportDetails.Rows(0).Item("TITLE") & "'"
        '                        Catch ex As Exception
        '                        End Try
        '                        Try
        '                            myReport.DataDefinition.FormulaFields("FUserName").Text = "'" & StrLoginId & "'"
        '                        Catch ex As Exception
        '                        End Try
        '                        Try
        '                            myReport.DataDefinition.FormulaFields("TODATE").Text = "'" & ReportFilters.Date_To & "'"
        '                        Catch ex As Exception
        '                        End Try
        '                        Try
        '                            myReport.DataDefinition.FormulaFields("FROMDATE").Text = "'" & ReportFilters.Date_From & "'"
        '                        Catch ex As Exception
        '                        End Try
        '                        Try
        '                            myReport.DataDefinition.FormulaFields("GPrint_Date").Text = Date.Now
        '                        Catch ex As Exception
        '                        End Try

        '                    End If
        '                    'here am adding fields to accommodate 
        '                    'uploads report
        '                    'waf for bonni because he will give me his bonus for this year 05/04/2011
        '                    'this caters for the uploads report file. note the inclusion of
        '                    'an optional parameter as ana array which can accommodate several
        '                    'values of the same type
        '                    If otherFields.Equals(Nothing) Then
        '                    Else
        '                        myReport.DataDefinition.FormulaFields("filetype").Text = "'" & otherFields(0) & "'"
        '                        myReport.DataDefinition.FormulaFields("path").Text = "'" & otherFields(1) & "'"
        '                    End If
        '                Catch ex As Exception

        '                End Try
        '                Dim frm As New frmNewReportViewer
        '                frm.WindowState = FormWindowState.Maximized
        '                'frm.crvReports.reportpath = myReport
        '                frm.Text = frm.Text & " - " & ReportName

        '                frm.ShowDialog()
        '            Case ReportTypes.reportTypeExcel
        '                'Dim appExcel As New Microsoft.Office.Interop.Excel.Application
        '                'Dim wBook As Microsoft.Office.Interop.Excel.Workbook
        '                'Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
        '                'Dim colIndex As Integer = 0
        '                'Dim rowIndex As Integer = 0
        '                'Dim getFileName As New SaveFileDialog
        '                'Dim flName As String = ""
        '                'getFileName.Filter = "Excel Files(*.xls)|*.xls"
        '                'If getFileName.ShowDialog = DialogResult.OK Then
        '                '    flName = getFileName.FileName
        '                'Else
        '                '    Exit Sub
        '                'End If
        '                'If flName.Trim = "" Then Exit Sub
        '                'wBook = appExcel.Workbooks.Add
        '                'wSheet = wBook.ActiveSheet
        '                ''------ Write Coloumn Headers
        '                'For Each dCol As DataColumn In tblReportData.Columns
        '                '    colIndex += 1
        '                '    appExcel.Cells(1, colIndex) = dCol.ColumnName
        '                'Next
        '                ''------- write the data
        '                'For k As Integer = 0 To tblReportData.Rows.Count - 1
        '                '    For c As Integer = 0 To tblReportData.Columns.Count - 1
        '                '        appExcel.Cells(k + 2, c + 1) = tblReportData.Rows(k).Item(c)
        '                '    Next
        '                '    Application.DoEvents()
        '                'Next
        '                'wSheet.Columns.AutoFit()
        '                'wBook.SaveAs(flName)
        '                'MsgBox("Export Complete.", MsgBoxStyle.Information, MsgBoxTitle)
        '                'appExcel.Workbooks.Open(flName)
        '                'appExcel.Visible = True
        '            Case ReportTypes.reportTypeNotepad
        '                Dim getFileName As New SaveFileDialog
        '                Dim flName As String = ""
        '                Dim FileLine As String = ""
        '                Dim colIndex As Integer = 0
        '                getFileName.Filter = "Text Files(*.txt)|*.txt"
        '                If getFileName.ShowDialog = DialogResult.OK Then
        '                    flName = getFileName.FileName
        '                Else
        '                    Exit Sub
        '                End If
        '                If flName.Trim = "" Then Exit Sub
        '                If flName.Split(".").Length = 1 Then flName = flName & ".TXT"
        '                Dim myEJSStreamWriter As System.IO.StreamWriter = New System.IO.StreamWriter(flName)
        '                '------ Write Header -----
        '                For Each dCol As DataColumn In tblReportData.Columns
        '                    colIndex += 1
        '                    FileLine = FileLine & "," & dCol.ColumnName
        '                Next
        '                FileLine = FileLine.Substring(1)
        '                myEJSStreamWriter.WriteLine(FileLine)
        '                FileLine = ""
        '                '------- write the data
        '                For k As Integer = 0 To tblReportData.Rows.Count - 1
        '                    For c As Integer = 0 To tblReportData.Columns.Count - 1
        '                        If IsDBNull(tblReportData.Rows(k).Item(c)) Then
        '                            FileLine = FileLine & "," & tblReportData.Rows(k).Item(c) '.ToString.Replace(",", " ")
        '                        Else
        '                            FileLine = FileLine & "," & tblReportData.Rows(k).Item(c).ToString.Replace(",", " ")
        '                        End If
        '                    Next
        '                    FileLine = FileLine.Substring(1)
        '                    myEJSStreamWriter.WriteLine(FileLine)
        '                    FileLine = ""
        '                    Application.DoEvents()
        '                Next
        '                myEJSStreamWriter.Close()
        '                myEJSStreamWriter.Dispose()
        '                MsgBox("Export Complete.", MsgBoxStyle.Information)
        '            Case ReportTypes.reportTypeXml

        '        End Select
        '    Catch ex As Exception
        '        RaiseEvent ReportProcessError("Error In Function ShowReport!" & vbNewLine & ex.Message)
        '    End Try
        'End Sub
        ''---- Set Report Dataset
        'Sub SetReportDataSource(ByVal ReportData As DataTable)
        '    Try
        '        blnDataSourceSet = True
        '        tblReportData = New DataTable
        '        tblReportData = ReportData
        '    Catch ex As Exception
        '        RaiseEvent ReportProcessError("Error In Function SetReportDataSource!" & vbNewLine & ex.Message)
        '    End Try

        'End Sub
#End Region

#Region "Other Function"
        Sub New(ByVal ReportLocation As String, ByVal myDataType As DataSourceTypes)
            '----Initialise Filters
            With ReportFilters
                .Max_Amount = 9999999.99
                .Min_Amount = -9999999.99
                .Ref_No = "ALL"
                .Date_To = Date.Now
                .Date_From = Date.Now
                .BranchCode = "ALL"
                .BankCode = "ALL"
                .Account = "ALL"
                .CurrencyCode = "ALL"
                .BatchNumber = "ALL"
            End With
            strErrReport = ""
            strReportsLocation = ReportLocation & IIf(ReportLocation.Trim.EndsWith("\"), "", "\")
            Me.DataBaseSource = myDataType
        End Sub
#End Region

        Private Sub clsReportsProcessing_ReportProcessError(ByVal ErrorMessage As String) Handles Me.ReportProcessError
            Me.strErrReport = ErrorMessage
        End Sub
    End Class

End Module

