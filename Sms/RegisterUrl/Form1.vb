Imports System.Xml
Imports System.Text
Imports System.IO
Imports System.Net
Imports System.Security.Cryptography.X509Certificates

Public Class Form1
    Public Sub Deposits(ByVal code As String)

        Try

            'Dim corporate As String = withd.Corporate_No
            'Dim sacco = (From saccos In db.SaccoSource_Info Where saccos.Corporate_No = corporate Select saccos).FirstOrDefault()

            Dim req As HttpWebRequest = Nothing
            Dim rsp As HttpWebResponse = Nothing

            'Dim cert As X509Certificate = X509Certificate.CreateFromCertFile("D:\APISigned3.cer")'Old Cert
            '   Dim cert As X509Certificate = X509Certificate.CreateFromCertFile("D:\Cert\2016-2018\ProdBroker.cer") ' New Cert 2016-2018
            Dim cert As X509Certificate = X509Certificate.CreateFromCertFile(TextBox2.Text) ' New Cert 2016-2018
            ' Create a  X509Certificat object from yor certificate.
            ' other way is to go through all the cerificates  which are installed
            ' in your Pc and get the right one from the store list

            'Dim uri As String = "https://192.168.9.49:18423/mminterface/request"  ' Production 

            'Dim uri As String = "https://192.168.9.48:8310/mminterface/request"  'Test Bed

            'Dim uri As String = "http://192.168.9.48:8310/mminterface/registerURL"   'Register URL Test

            'Dim uri As String = "https://192.168.9.49:18423/mminterface/registerURL"     'Register URL Production
            'Dim uri As String = "https://portal.safaricom.com/registerURL"
            ' A url which is looking for the right public key with 
            ' the incomming https request
            Dim uri As String = "https://196.201.214.137:18423/mminterface/registerURL"
            'String myfile = File.ReadAllText("C:\\somfile.xml");

            req = DirectCast(System.Net.WebRequest.Create(uri), HttpWebRequest)

            'String DataToPost = this.GetTextFromXMLFile(myfile);
            Dim postData As String = ""
            Dim s As New StringBuilder()

            Dim spid As String
            Dim spPassword As String
            Dim timeStamp As String
            Dim serviceId As String
            Dim ShortCode As String
            Dim C2BURL As String


            'spid = "100014"
            'spPassword = "QThEMzFEOUM0NDNCNEVDMjkzQjE4NDFFNjlFRTc2QzBERTc2RjUxNDIwRTdEMjA5MjRBNDJENDhENEQ5OUM0MQ==" '
            'timeStamp = "20140107213003"
            'serviceId = "100014000"
            'ShortCode = "544700"

            C2BURL = "https://10.178.0.18:7892/C2BResults.asmx" 'Register https only on port 8016

            spid = "100903"
            'spPassword = "QTVBNTEyQzE2NDI1QzJCMzMxRjUyRDkwNEQ3OTUxNzg0MkU4RDE1OEQ4REY5QUQ1QzAxMTg2MjcwNUM5QTk5Mw==" '@QAZ2wsx34
            spPassword = "YjE3NDQ1YjUxYTZlYjIyZTJlOWZlYjgyOTIxOTQ3OTczMjYwMjcwYTQ1NDg0NDlhYWM3NjBmODc3ZDdhMDVhNg==" '@QAZ2wsx34
            timeStamp = "20170623154054" '20140107213003
            serviceId = "100903000"
            ShortCode = code ' "540700" 'paybill  ,,,,,,,,,,, ,,,,,


            '======================== G2 ======================================

            s.AppendLine("<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/""")
            s.AppendLine("xmlns:req=""http://api-v1.gen.mm.vodafone.com/mminterface/request"">")
            s.AppendLine("<soapenv:Header>")
            s.AppendLine("<tns:RequestSOAPHeader xmlns:tns=""http://www.huawei.com/schema/osg/common/v2_1"">")
            s.AppendLine("<tns:spId>" + spid + "</tns:spId>")
            s.AppendLine("<tns:spPassword>" + spPassword + "</tns:spPassword>")
            s.AppendLine("<tns:timeStamp>" + timeStamp + "</tns:timeStamp>")
            s.AppendLine("<tns:serviceId>" + serviceId + "</tns:serviceId>")
            s.AppendLine("</tns:RequestSOAPHeader>")
            s.AppendLine("</soapenv:Header>")
            s.AppendLine("<soapenv:Body>")
            s.AppendLine("<req:RequestMsg><![CDATA[<?xml version='1.0' encoding='UTF-8'?><request xmlns=""http://api-v1.gen.mm.vodafone.com/mminterface/request"">")
            s.AppendLine("<Transaction>")
            s.AppendLine("<CommandID>RegisterURL</CommandID>")
            s.AppendLine("<OriginatorConversationID>Handinhand_00001</OriginatorConversationID>")
            s.AppendLine("<Parameters><Parameter>")
            s.AppendLine("<Key>ResponseType</Key>")
            s.AppendLine("<Value>Completed</Value>")
            s.AppendLine("</Parameter>")
            s.AppendLine("</Parameters>")
            s.AppendLine("<ReferenceData>")
            s.AppendLine("<ReferenceItem>")
            s.AppendLine("<Key>ValidationURL</Key>")
            s.AppendLine("<Value>" + C2BURL + "</Value>")
            s.AppendLine("</ReferenceItem>")
            s.AppendLine("<ReferenceItem>")
            s.AppendLine("<Key>ConfirmationURL</Key>")
            s.AppendLine("<Value>" + C2BURL + "</Value>")
            s.AppendLine("</ReferenceItem>")
            s.AppendLine("</ReferenceData>")
            s.AppendLine("</Transaction>")
            s.AppendLine("<Identity>")
            s.AppendLine("<Caller>")
            s.AppendLine("<CallerType>0</CallerType>")
            s.AppendLine("<ThirdPartyID/>")
            s.AppendLine("<Password/>")
            s.AppendLine("<CheckSum/>")
            s.AppendLine("<ResultURL/>")
            s.AppendLine("</Caller>")
            s.AppendLine("<Initiator>")
            s.AppendLine("<IdentifierType>1</IdentifierType>")
            s.AppendLine("<Identifier/>")
            s.AppendLine("<SecurityCredential/>")
            s.AppendLine("<ShortCode/>")
            s.AppendLine("</Initiator>")
            s.AppendLine("<PrimaryParty>")
            s.AppendLine("<IdentifierType>1</IdentifierType>")
            s.AppendLine("<Identifier/>")
            s.AppendLine("<ShortCode>" + ShortCode + "</ShortCode>")
            s.AppendLine("</PrimaryParty>")
            s.AppendLine("</Identity>")
            s.AppendLine("<KeyOwner>1</KeyOwner>")
            s.AppendLine("</request>]]></req:RequestMsg>")
            s.AppendLine("</soapenv:Body>")
            s.AppendLine("</soapenv:Envelope>")

            '==============================End of G2======================================


            postData = s.ToString()
            TextBox3.Text = postData
            Dim DataToPost As [String] = postData

            'String strSenderID = "123";

            req.Method = "POST"
            ' Post method
            req.ContentType = "text/xml;charset=UTF-8"
            ' content type
            'You can also use ContentType = "text/xml";
            'req.Headers.Add("sender-id", strSenderID);
            ' Some Header information which you would like to send 
            ' with the request
            req.ContentLength = postData.Length
            req.KeepAlive = False
            req.UserAgent = Nothing
            req.Timeout = 99999
            req.ReadWriteTimeout = 99999
            req.ServicePoint.MaxIdleTime = 99999

            req.ClientCertificates.Add(cert)
            ' Attaching the Certificate To the request

            System.Net.ServicePointManager.CertificatePolicy = New TrustAllCertificatePolicys()

            ' when you browse manually you get a dialogue box asking 
            ' that whether you want to browse over a secure connection.
            ' this line will suppress that message
            '(pragramatically saying ok to that message). 

            'StreamWriter writer = new StreamWriter(req.GetRequestStream());

            ''/writer.WriteLine(this.GetTextFromXMLFile(myfile));

            'writer.WriteLine(postData);

            'writer.Close();


            Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
            Dim dataStream As Stream = req.GetRequestStream()
            dataStream.Write(byteArray, 0, byteArray.Length)
            dataStream.Close()
            rsp = DirectCast(req.GetResponse(), HttpWebResponse)
            Dim reader As New System.IO.StreamReader(rsp.GetResponseStream())
            Dim retData As String = reader.ReadToEnd()
            txtresults.Text = retData
            'Apilog.LogEntryOnFile(withd.Corporate_No & ":" & retData)

            Dim xxd As XmlDocument = New XmlDocument()
            xxd.LoadXml(retData)
            Dim Results As XmlNodeList = xxd.GetElementsByTagName("req:ResponseMsg")
            Dim result As XmlNode = Results.Item(0)

            Dim Status As String
            Dim Broker_Resp_Desc As String

            For Each x As XmlNode In Results
                Dim ress As XmlDocument = New XmlDocument()
                ress.LoadXml(x.InnerText.Substring(x.InnerText.IndexOf("<")))
                For Each cn As XmlNode In ress.ChildNodes
                    Select Case cn.Name
                        Case "response"
                            For Each cnn As XmlNode In cn.ChildNodes
                                Select Case cnn.Name
                                    Case "ResponseCode"
                                        Select Case cnn.InnerText
                                            Case "00000000"
                                                Status = "Success"
                                            Case Else
                                                Status = "Failed"
                                        End Select

                                    Case "ResponseDesc"
                                        Broker_Resp_Desc = cnn.InnerText

                                End Select
                            Next
                    End Select
                Next
            Next

            If req IsNot Nothing Then
                req.GetRequestStream().Close()
            End If
            If rsp IsNot Nothing Then
                rsp.GetResponseStream().Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            'withd.Comments = String.Format("API:{0}", ex.Message)
        End Try




    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click, Label3.Click

    End Sub

    Private Sub btncert_Click(sender As Object, e As EventArgs) Handles btncert.Click
        Dim myStream As Stream = Nothing
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.InitialDirectory = "c:\"
        openFileDialog1.Multiselect = False
        openFileDialog1.Filter = "cer files (*.cer)|*.cer|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                TextBox2.Text = openFileDialog1.FileName

            Catch Ex As Exception
                MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)
            Finally
                ' Check this again, since we need to make sure we didn't throw an exception on open.
                If (myStream IsNot Nothing) Then
                    myStream.Close()
                End If
            End Try
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Deposits(TextBox1.Text)
    End Sub
End Class
Public Class TrustAllCertificatePolicys
    Implements System.Net.ICertificatePolicy
    Public Sub New()
    End Sub
    Public Function CheckValidationResult(ByVal sp As ServicePoint, ByVal cert As System.Security.Cryptography.X509Certificates.X509Certificate, ByVal req As WebRequest, ByVal problem As Integer) As Boolean Implements ICertificatePolicy.CheckValidationResult

        Return True
    End Function
End Class