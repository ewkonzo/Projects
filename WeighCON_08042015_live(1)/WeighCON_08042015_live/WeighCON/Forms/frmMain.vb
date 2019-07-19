Imports System.IO.Ports
Imports AxDAQDOLib
Imports System.IO
Imports PrintPro.My

Public Class frmMain
    Dim strScannerState As String
    Dim strScaleState As String
    Dim strScannerInput As String
    Dim myCONN As New DbConn

    Dim itemscanned As Boolean
    Dim itemcode As String
    Dim itemmass As String
    Dim itemserial As String
    Dim labelname As String
    Dim bOpen As Boolean
    Dim isInitializing As Boolean
    Dim MaskBits As New BitArray(8)
    Dim StatusBits As New BitArray(8)
    Dim cmdChannelArray(8) As Button
    Dim chkMaskArray(8) As CheckBox
    Dim DAQDO1 As New AxDAQDOLib.AxDAQDO

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        initializeport()
        'Weighport.DiscardInBuffer()
        'Scannerport.DiscardInBuffer()
        AddHandler Scannerport.DataReceived, New SerialDataReceivedEventHandler(AddressOf scannerport_DataReceived)

        AddHandler Weighport.DataReceived, New SerialDataReceivedEventHandler(AddressOf Weigherport_DataReceived)
        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Sub selectdevice()
        Dim i As Object
        Dim Ret As Integer

        If bOpen Then
            DAQDO1.CloseDevice()
            bOpen = False

        End If

        ' Select Device from installed list
        Ret = DAQDO1.SelectDevice
        'txtDeviceNum.Text = CStr(DAQDO1.DeviceNumber)
        'txtDeviceName.Text = DAQDO1.DeviceName

        ' Open Device
        If DAQDO1.OpenDevice Then
            MsgBox(DAQDO1.ErrorMessage, MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If DAQDO1.MaxPortNumber = 0 Then
            MsgBox("Function Not Supported", MsgBoxStyle.OkOnly)
            DAQDO1.CloseDevice()
            Exit Sub
        End If
        'cmbPort.Enabled = True
        bOpen = True
        ' Add Port number to list box
        'cmbPort.Items.Clear()
        'For i = 0 To DAQDO1.MaxPortNumber - 1
        '    cmbPort.Items.Add((Str(i)))
        'Next i
        'If DAQDO1.MaxPortNumber Then
        '    cmbPort.SelectedIndex = DAQDO1.Port
        'End If
        UpdateStatus()
        UpdateMask()
    End Sub
    Private Sub UpdateStatus()
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

        'txtReadBack.Text = Hex(Status)

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
        'txtMask.Text = Hex(DAQDO1.Mask)
    End Sub
    Sub Reject()
        DAQDO1.Bit = 2
        StatusBits.Set(2, Not StatusBits.Get(2))
        DAQDO1.BitOutput(StatusBits.Get(2))
        UpdateStatus()
    End Sub
    Dim starting As Boolean = True
    Private Sub scannerport_DataReceived(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs)
        ' If the com port has been closed, do nothing
        Try
            If Not Scannerport.IsOpen Then
                Return
            End If
            ' This method will be called when there is data waiting in the port's buffer
            ' Determain which mode (string or binary) the user is in
            Threading.Thread.Sleep(500)
            Dim data As String = Scannerport.ReadExisting()
            log(data)

            If (Not (data.Contains("?"))) Or (data.Contains("NOREAD")) Then
                If (data = "") Or data.Contains("NOREAD") Then
                    txtBarcodeInput.Text = "NOREAD"
                Else

                    'data = data.Substring(2, data.Length - 3).Trim
                    'txtBarcodeInput.Text = data
                    Dim mydata() As String = data.Split(Environment.NewLine)
                    Dim mycode() As String = mydata(0).Split(New Char() {"O"})
                    If mycode.Count > 1 Then
                        txtBarcodeInput.Text = mycode(1)
                    Else
                        txtBarcodeInput.Text = mycode(0)
                    End If

                End If

                itemscanned = True
                readInputs()
            End If
            ' Display the text to the user in the terminal
        Catch ex As Exception

        End Try
    End Sub
    Private Sub log(d As String)
        File.AppendAllText(String.Format("c:\Printpro\{0}{1}{2}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), d & vbCrLf & "--------" & vbCrLf)
    End Sub
    Private Sub Weigherport_DataReceived(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs)
        ' If the com port has been closed, do nothing
        Try

            If Not Weighport.IsOpen Then
                Return
            End If

            ' This method will be called when there is data waiting in the port's buffer
            Threading.Thread.Sleep(500)
            Dim data As String = Weighport.ReadExisting()
            'data = data.Substring(1).Trim
            If starting Then
                starting = False
                Exit Sub
            End If
            txtGrossMass.Text = data
            txtGrossMass.Text = txtGrossMass.Text.Substring(1, txtGrossMass.Text.Length - 2).Trim
            ' Determain which mode (string or binary) the user is in
            myCONN.AccDownload("Select Max(id) from itemlog")
            If myCONN.Accrec.HasRows Then
                myCONN.Accrec.Read()
                'MsgBox("data OK")
                itemserial = (CInt(myCONN.Accrec.Item(0)) + 1).ToString.PadLeft("8", "0")
                'MsgBox(itemserial)
            Else
                itemserial = "00000000"
            End If

            If Not txtItemCode.Text = "" Then
                itemcode = Me.txtItemCode.Text
            Else
                itemcode = Settings.UnknownItemcode
            End If

            itemmass = Me.txtGrossMass.Text.Replace("kg", "")

            Dim weightstatus As String
            If txtPermittedUpperMass.Text <> "" And txtPermittedLowerMass.Text <> "" Then
                If CDbl(itemmass) > CDbl(txtPermittedUpperMass.Text) Then
                    txtMassStatus.Text = "OVERWEIGHT"
                    weightstatus = "O"
                ElseIf CDbl(itemmass) < CDbl(txtPermittedLowerMass.Text) Then
                    txtMassStatus.Text = "UNDERWEIGHT"
                    weightstatus = "U"
                Else
                    txtMassStatus.Text = "OK"
                    weightstatus = "OK"
                End If

            End If
            'MsgBox(itemcode + itemmass + labelname)

            Dim printer As String
            printer = Settings.Printer

            'TODO check selected printer and generate the string.
            Dim year = Format(Convert.ToDateTime(Now.Date), "yyyy").ToString
            year = year.Substring(year.Length - 1)
            Select Case printer
                Case "52/54"
                    labelname = Settings.Labelname52.ToString
                    datatosend = "^UV0|1|8|0|" & CInt(Now.Date.DayOfWeek) & "|1|" & currentshift & "|2|" & year & "|3|" & DatePart(DateInterval.WeekOfYear, Now.Date) & "|4|" & itemcode & "|5|" & Format(Convert.ToDateTime(Now), "HH:mm") & "|6|" & itemmass & "|7|" & itemserial & "|"

                Case "56/58"
                    labelname = Settings.LabelName.ToString
                    datatosend = "~JS0|" & labelname & "|1|Field000|" & CInt(Now.Date.DayOfWeek) & "|Field001|" & currentshift & "|Field002|" & year & "|Field003|" & DatePart(DateInterval.WeekOfYear, Now.Date) & "|Field004|" & itemcode & "|Field005|" & Format(Convert.ToDateTime(Now), "HH:mm") & "|Field006|" & itemmass & "|Field007|" & itemserial & "|"


            End Select
            'MsgBox(datatosend)
            SendData(datatosend)
            'MsgBox(datatosend)
            'If Settings.Enablerejection Then
            For i As Integer = 0 To 1
                Select Case weightstatus
                    Case "O"
                        fom.DAQDO1.Bit = 2
                        fom.StatusBits.Set(2, Not fom.StatusBits.Get(2))
                        fom.DAQDO1.BitOutput(fom.StatusBits.Get(2))
                        fom.UpdateStatus()
                    Case "U"
                        fom.DAQDO1.Bit = 2
                        fom.StatusBits.Set(2, Not fom.StatusBits.Get(2))
                        fom.DAQDO1.BitOutput(fom.StatusBits.Get(2))
                        fom.UpdateStatus()

                End Select
            Next

            'End If

            ToolStripStatusLabel1.Text = "Last serial: " & itemserial
            myCONN.AccUpload("insert into itemlog ( Dayofweek, Shift, Year, Weekofyear,barcode, itemcode, Time, Mass,status )values('" & CInt(Now.Date.DayOfWeek) & "','" & currentshift & "','" & year & "','" & DatePart(DateInterval.WeekOfYear, Now.Date) & "','" & txtBarcodeInput.Text & "','" & itemcode & "','" & Format(Convert.ToDateTime(Now), "HH:mm") & "','" & itemmass & "','" & txtMassStatus.Text & "')")
            itemscanned = False

            'If Settings.Enablerejection Then
            For i As Integer = 0 To 1
                Select Case weightstatus
                    Case "O"
                        System.Threading.Thread.Sleep(Settings.Delay * 1000)
                        fom.DAQDO1.Bit = 2
                        fom.StatusBits.Set(2, Not fom.StatusBits.Get(2))
                        fom.DAQDO1.BitOutput(fom.StatusBits.Get(2))
                        fom.UpdateStatus()
                    Case "U"
                        System.Threading.Thread.Sleep(Settings.Delay * 1000)
                        fom.DAQDO1.Bit = 2
                        fom.StatusBits.Set(2, Not fom.StatusBits.Get(2))
                        fom.DAQDO1.BitOutput(fom.StatusBits.Get(2))
                        fom.UpdateStatus()

                End Select
            Next

            'End If

            ' Display the text to the user in the terminal
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SendData(ByVal data As String)
        Printerport.Write(data)
    End Sub
    Private Sub SetupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetup.Click
        frmSetup.ShowDialog()
    End Sub

    Private Sub UserManagementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuUsers.Click
        Dim fom As New frmUsers
        fom.ShowDialog()
    End Sub

    Private Sub ItemMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuItemaster.Click
        Frmitemmasterlist.ShowDialog()
    End Sub
    Dim fom As New frmDO

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        fom.Close()
    End Sub
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        currentshift = Settings.Shift
        Select Case usertype
            Case "Operator"
                Me.mnuUsers.Enabled = False
                Me.mnuSetup.Enabled = False
                Me.mnuLogoff.Enabled = False

        End Select
        fom.Show()
        fom.Hide()

    End Sub

    Private Sub LogonToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim myForm As New frmLogin
        myForm.ShowDialog()
    End Sub

    Sub readInputs()
        Try
            myCONN.AccDownload("SELECT * FROM ITEMMASTER WHERE BarCode='" & Me.txtBarcodeInput.Text & "'")
            Dim myreader As SqlClient.SqlDataReader
            myreader = myCONN.Accrec
            If myreader.HasRows Then
                myreader.Read()

                Me.txtItemCode.Text = myreader("Item_Code")
                Me.txtDescription.Text = myreader("Description")
                Me.txtTheoriticalmass.Text = myreader("Theoretical_Mass")
                Me.txtPermittedLowerTol.Text = myreader("Permitted_Tol_Lower_%")
                Me.txtPermittedUpperTol.Text = myreader("Permitted_Tol_Upper_%")
                Me.txtPermittedUpperMass.Text = myreader("Theoretical_Mass") + (myreader("Theoretical_Mass") * (myreader("Permitted_Tol_Upper_%") / 100))
                Me.txtPermittedLowerMass.Text = myreader("Theoretical_Mass") - (myreader("Theoretical_Mass") * (myreader("Permitted_Tol_Lower_%") / 100))
            Else
                Me.txtItemCode.Text = Settings.UnknownItemcode

                Me.txtDescription.Text = ""
                Me.txtTheoriticalmass.Text = ""
                Me.txtPermittedLowerTol.Text = ""
                Me.txtPermittedUpperTol.Text = ""
                Me.txtPermittedUpperMass.Text = ""
                Me.txtPermittedLowerMass.Text = ""
                Me.txtMassStatus.Text = ""
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub mnuLogoff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLogoff.Click
        If MsgBox("Exit PrintPro?", MsgBoxStyle.Information + MsgBoxStyle.YesNoCancel, "PrintPro") = MsgBoxResult.Yes Then Exit Sub
    End Sub

    Private Sub StatusStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles StatusStrip1.ItemClicked

    End Sub


    Private Sub GroupBox4_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox4.Enter

    End Sub

    Private Sub mnuLastLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLastLabel.Click
        MsgBox(datatosend, MsgBoxStyle.OkOnly, "PrintPro")
    End Sub

    Private Sub mnuArchive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuArchive.Click
        Dim sql As String = "insert into archive ([ID] ,[Dayofweek],[Shift],[Year],[Weekofyear],[itemcode],[Time],[Mass],username)(select [ID] ,[Dayofweek],[Shift],[Year],[Weekofyear],[itemcode],[Time],[Mass] ,'" & username & "' from itemlog )"

        myCONN.AccUpload(sql)
        myCONN.AccDownload("Select Max(id) from itemlog")
        If myCONN.Accrec.HasRows Then
            myCONN.Accrec.Read()
            myCONN.AccUpload("delete from itemlog where id <> " & myCONN.Accrec.Item(0) & " ")
        End If
        MsgBox("Data has been archived successfully")

    End Sub

    Private Sub RegistrationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistrationToolStripMenuItem.Click
        Dim form As New Aboutus
        form.ShowDialog()
    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Dim ss As Integer = DateDiff(DateInterval.Hour, Now.Date.TimeOfDay, start)
        If ss > Settings.Shiftlengthhrs Then
            Settings.Shift = Settings.Shift + 1
            Dim fom As New frmLogin
            fom.Show()
            Me.Close()
        End If
        Timer1.Enabled = True
    End Sub

    Private Sub CompleteLogToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompleteLogToolStripMenuItem.Click
        Dim fom As New frmReports
        fom.Show()
    End Sub

End Class
