Public NotInheritable Class Aboutus

    Private Sub Aboutus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If activatedd Then
            Me.PictureBox1.Visible = True
        Else
            Me.PictureBox1.Visible = False
        End If
        Me.TextBox2.Text = sEncrypt(getdriveserial())
        Me.TextBox1.Text = My.Settings.Productid
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try

            Dim key As String
            key = sDecrypt(Me.TextBox1.Text)
            Dim serial() As String
            serial = key.Split("|")
            If Checkserial(serial(1)) Then
                My.Settings.Productid = Me.TextBox1.Text
                activatedd = True
                MsgBox("Thank you for activating the Application")
                Me.Close()
            Else
                MsgBox("Invalid Key")
            End If
        Catch ex As Exception
            MsgBox("Invalid key")
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If Me.TextBox1.Text = "" Then
            Button2.Enabled = False
        Else
            Me.Button2.Enabled = True
        End If
    End Sub
End Class
