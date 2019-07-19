Imports System.IO
Imports System.Linq
Imports System.IO.Ports
Imports PrintPro.My
Imports System.Text
#Region "Public Enumerations"
Public Enum DataMode
    Text
    Hex
End Enum
Public Enum LogMsgType
    Incoming
    Outgoing
    Normal
    Warning
    [Error]
End Enum
#End Region

Public Class frmSetup

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

    End Sub
    Private Sub SaveSettings()
        settings.BaudRate = Integer.Parse(cmbBaudRate.Text)
        settings.DataBits = Integer.Parse(cmbDataBits.Text)
        Settings.Parity = CType([Enum].Parse(GetType(Parity), Cmbparity.Text), Parity)
        settings.StopBits = CType([Enum].Parse(GetType(StopBits), cmbStopBits.Text), StopBits)
        Settings.PortName = cmbPortName.Text


        Settings.Baudrates = Integer.Parse(cmbbaudrates.Text)
        Settings.Databitss = Integer.Parse(Cmbdatabitss.Text)
        Settings.paritys = CType([Enum].Parse(GetType(Parity), cmbparitys.Text), Parity)
        Settings.stopbitss = CType([Enum].Parse(GetType(StopBits), cmbstopbitss.Text), StopBits)
        Settings.portnames = Cmbcomports.Text


        Settings.baudratew = Integer.Parse(cmbbaudratew.Text)
        Settings.Databitsw = Integer.Parse(cmbdatabitsw.Text)
        Settings.parityw = CType([Enum].Parse(GetType(Parity), cmbparityw.Text), Parity)
        Settings.stopbitw = CType([Enum].Parse(GetType(StopBits), cmbstopbitsw.Text), StopBits)
        Settings.Portnamew = cmbcomportw.Text
        'Global Settings
        Settings.UnknownItemcode = Me.txtUnknownItem.Text
        Settings.Shiftlengthhrs = Me.txtShiftlength.Text
        Settings.LabelName = Me.txtLabelName.Text
        Settings.Labelname52 = Me.labelname52.Text
        Settings.Delay = Delay.Text
        Settings.Enablerejection = chkrejection.Checked
        If rbn5254.Checked = True Then
            Settings.Printer = "52/54"
        ElseIf rbn5658.Checked = True Then
            Settings.Printer = "56/58"
        End If

        'Settings.Weightvariance = txtweightvariation.Text
        'Settings.Averagecounter = txtaverage.Text
        Settings.Save()
    End Sub
    Private Sub InitializeControlValues()
        'printer
        Cmbparity.Items.Clear()
        cmbParity.Items.AddRange([Enum].GetNames(GetType(Parity)))
        cmbStopBits.Items.Clear()
        cmbStopBits.Items.AddRange([Enum].GetNames(GetType(StopBits)))

        cmbParity.Text = settings.Parity.ToString()
        cmbStopBits.Text = settings.StopBits.ToString()
        cmbDataBits.Text = settings.DataBits.ToString()

        cmbBaudRate.Text = Settings.BaudRate.ToString()
        'scanner
        cmbparitys.Items.Clear()
        cmbparitys.Items.AddRange([Enum].GetNames(GetType(Parity)))
        cmbstopbitss.Items.Clear()
        cmbstopbitss.Items.AddRange([Enum].GetNames(GetType(StopBits)))
        cmbparitys.Text = Settings.paritys.ToString()
        cmbstopbitss.Text = Settings.stopbitss.ToString()
        Cmbdatabitss.Text = Settings.Databitss.ToString()
        cmbbaudrates.Text = Settings.Baudrates.ToString()
        'weigher
        cmbparityw.Items.Clear()
        cmbparityw.Items.AddRange([Enum].GetNames(GetType(Parity)))
        cmbstopbitsw.Items.Clear()
        cmbstopbitsw.Items.AddRange([Enum].GetNames(GetType(StopBits)))
        cmbparityw.Text = Settings.parityw.ToString()
        cmbstopbitsw.Text = Settings.stopbitw.ToString()
        cmbdatabitsw.Text = Settings.Databitsw.ToString()
        cmbbaudratew.Text = Settings.baudratew.ToString()
        'Global Settings
        Dim strPrinter As String = Settings.Printer.ToString
        If strPrinter = "52/54" Then

        End If
        Me.rbn5254.Checked = True
        If strPrinter = "56/58" Then
            Me.rbn5658.Checked = True
            Me.txtLabelName.Text = Settings.LabelName.ToString
        
        End If
        'Me.txtweightvariation.Text = Settings.Weightvariance.ToString()
        'Me.txtaverage.Text = Settings.Averagecounter.ToString()
        Me.txtShiftlength.Text = Settings.Shiftlengthhrs.ToString
        Me.txtUnknownItem.Text = Settings.UnknownItemcode.ToString
        Delay.Text = Settings.Delay
        chkrejection.Checked = Settings.Enablerejection
        Me.labelname52.Text = Settings.Labelname52


        ' If it is still avalible, select the last com port used
        'printer
        If cmbPortName.Items.Contains(Settings.PortName) Then
            cmbPortName.Text = Settings.PortName
        ElseIf cmbPortName.Items.Count > 0 Then
            cmbPortName.SelectedIndex = cmbPortName.Items.Count - 1
        Else
            MessageBox.Show(Me, "There are no COM Ports detected on this computer." & vbLf & "Please install a COM Port and restart this app.", "No COM Ports Installed", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Me.Close()
        End If
        'scanner
        If Cmbcomports.Items.Contains(Settings.portnames) Then
            Cmbcomports.Text = Settings.portnames
        ElseIf Cmbcomports.Items.Count > 0 Then
            Cmbcomports.SelectedIndex = Cmbcomports.Items.Count - 1
        Else

            Me.Close()
        End If
        'weigher
        If cmbcomportw.Items.Contains(Settings.Portnamew) Then
            cmbcomportw.Text = Settings.Portnamew
        ElseIf cmbPortName.Items.Count > 0 Then
            cmbcomportw.SelectedIndex = cmbcomportw.Items.Count - 1
        Else

            Me.Close()
        End If

    End Sub
    ''' <summary> Convert a string of hex digits (ex: E4 CA B2) to a byte array. </summary>
    ''' <param name="s"> The string containing the hex digits (with or without spaces). </param>
    ''' <returns> Returns an array of bytes. </returns>
    Private Function HexStringToByteArray(ByVal s As String) As Byte()
        s = s.Replace(" ", "")
        Dim buffer As Byte() = New Byte(s.Length \ 2 - 1) {}
        For i As Integer = 0 To s.Length - 1 Step 2
            buffer(i \ 2) = CByte(Convert.ToByte(s.Substring(i, 2), 16))
        Next
        Return buffer
    End Function

    ''' <summary> Converts an array of bytes into a formatted string of hex digits (ex: E4 CA B2)</summary>
    ''' <param name="data"> The array of bytes to be translated into a string of hex digits. </param>
    ''' <returns> Returns a well formatted string of hex digits with spacing. </returns>
    Private Function ByteArrayToHexString(ByVal data As Byte()) As String
        Dim sb As New StringBuilder(data.Length * 3)
        For Each b As Byte In data
            sb.Append(Convert.ToString(b, 16).PadLeft(2, "0"c).PadRight(3, " "c))
        Next
        Return sb.ToString().ToUpper()
    End Function




    Private Sub lnkAbout_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs)
        ' Show the user the about dialog

        '(New frmAbout()).ShowDialog(Me)
    End Sub


    'Private Sub port_DataReceived(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs)
    '    ' If the com port has been closed, do nothing
    '    If Not comport.IsOpen Then
    '        Return
    '    End If

    '    ' This method will be called when there is data waiting in the port's buffer

    '    ' Determain which mode (string or binary) the user is in
    '    If CurrentDataMode = DataMode.Text Then
    '        ' Read all the data waiting in the buffer
    '        Dim data As String = comport.ReadExisting()

    '        ' Display the text to the user in the terminal
    '        Log(LogMsgType.Incoming, data)
    '    Else
    '        ' Obtain the number of bytes waiting in the port's buffer
    '        Dim bytes As Integer = comport.BytesToRead

    '        ' Create a byte array buffer to hold the incoming data
    '        Dim buffer As Byte() = New Byte(bytes - 1) {}

    '        ' Read the data from the port and store it in our buffer
    '        comport.Read(buffer, 0, bytes)

    '        ' Show the user the incoming data in hex format
    '        Log(LogMsgType.Incoming, ByteArrayToHexString(buffer))
    '    End If
    'End Sub


    'Private Sub tmrCheckComPorts_Tick(ByVal sender As Object, ByVal e As EventArgs)
    '    ' checks to see if COM ports have been added or removed
    '    ' since it is quite common now with USB-to-Serial adapters
    '    RefreshComPortList()
    'End Sub

    'Private Sub RefreshComPortList()
    '    ' Determain if the list of com port names has changed since last checked
    '    Dim selected As String = RefreshComPortList(cmbPortName.Items.Cast(Of String)(), TryCast(cmbPortName.SelectedItem, String), comport.IsOpen)

    '    ' If there was an update, then update the control showing the user the list of port names
    '    If Not [String].IsNullOrEmpty(selected) Then
    '        cmbPortName.Items.Clear()
    '        cmbPortName.Items.AddRange(OrderedPortNames())
    '        cmbPortName.SelectedItem = selected
    '    End If
    'End Sub

    Private Function OrderedPortNames() As String()
        ' Just a placeholder for a successful parsing of a string to an integer
        Dim num As Integer

        ' Order the serial port names in numberic order (if possible)
        Return SerialPort.GetPortNames().OrderBy(Function(a) If(a.Length > 3 AndAlso Integer.TryParse(a.Substring(3), num), num, 0)).ToArray()
    End Function

    Private Function RefreshComPortList(ByVal PreviousPortNames As IEnumerable(Of String), ByVal CurrentSelection As String, ByVal PortOpen As Boolean) As String
        ' Create a new return report to populate
        Dim selected As String = Nothing

        ' Retrieve the list of ports currently mounted by the operating system (sorted by name)
        Dim ports As String() = SerialPort.GetPortNames()

        ' First determain if there was a change (any additions or removals)
        Dim updated As Boolean = PreviousPortNames.Except(ports).Count() > 0 OrElse ports.Except(PreviousPortNames).Count() > 0

        ' If there was a change, then select an appropriate default port
        If updated Then
            ' Use the correctly ordered set of port names
            ports = OrderedPortNames()

            ' Find newest port if one or more were added
            Dim newest As String = SerialPort.GetPortNames().Except(PreviousPortNames).OrderBy(Function(a) a).LastOrDefault()

            ' If the port was already open... (see logic notes and reasoning in Notes.txt)
            If PortOpen Then
                If ports.Contains(CurrentSelection) Then
                    selected = CurrentSelection
                ElseIf Not [String].IsNullOrEmpty(newest) Then
                    selected = newest
                Else
                    selected = ports.LastOrDefault()
                End If
            Else
                If Not [String].IsNullOrEmpty(newest) Then
                    selected = newest
                ElseIf ports.Contains(CurrentSelection) Then
                    selected = CurrentSelection
                Else
                    selected = ports.LastOrDefault()
                End If
            End If
        End If

        ' If there was a change to the port list, return the recommended default selection
        Return selected
    End Function
    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
        target = value
        Return value
    End Function

    Private Sub frmSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.rbnwin32scanner.Checked = True
        Me.rbnwin32printer.Checked = True
        Me.rbnwinscale.Checked = True
        Me.rbnScanweigh.Checked = True
        'Me.txtShiftlength.Text = "1"
        Me.txtStartvalue.Text = "1"
        Me.txtNodigits.Text = "8"
        Me.txtMaxvalue.Text = "99999999"
        Me.txtlastserial.Text = "00000000"
        InitializeControlValues()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SaveSettings()
        Scannerport.Close()
        Weighport.Close()
        Printerport.Close()
        initializeport()
        Me.Close()
    End Sub

    Private Sub rbn5658_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbn5658.CheckedChanged

    End Sub

    Private Sub GroupBox13_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox13.Enter

    End Sub
End Class