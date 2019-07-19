Public Class frmLogin
    Dim Mystring As String
    Dim myConn As New DbConn
    Dim scanPortState As Boolean
    Dim scalePortState As Boolean
    

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If Me.txtPassword.Text = "" Or Me.txtUsername.Text = "" Then MsgBox("Missing Username\Password!!", MsgBoxStyle.Critical, "PrintPro") : Exit Sub
        Try
            '"SELECT     USERS.Username, USERS.Userfullname, USERS.UserPassword, USERS.UserGroup, Groups.GroupRight FROM         USERS INNER JOIN   Groups ON USERS.UserGroup = Groups.GroupName Where Username='" & Me.txtUsername.Text & "' and UserPassword='" & Me.txtPassword.Text & "'"
            myConn.AccDownload("SELECT     USERS.Username, USERS.Userfullname, USERS.UserPassword, USERS.UserGroup, Groups.GroupRight FROM         USERS INNER JOIN   Groups ON USERS.UserGroup = Groups.GroupName Where Username='" & Me.txtUsername.Text & "' and UserPassword='" & Me.txtPassword.Text & "'")
            Dim myreader As SqlClient.SqlDataReader
            myreader = myConn.Accrec
            If myreader.HasRows Then
                isLogged = True
                myreader.Read()
                usertype = myreader.Item("groupright")
                username = myreader.Item("username")
                'While activatedd = False

                '    If My.Settings.Productid <> "" Then
                '        Dim key As String
                '        key = sDecrypt(My.Settings.Productid)
                '        Dim serial() As String

                '        serial = key.Split("|")
                '        If String.Compare(serial(1).ToString, getdriveserial) Then
                '            Dim fom As New Aboutus
                '            fom.ShowDialog()
                '        Else
                '            activatedd = True
                '        End If
                '    Else
                '        Dim fom As New Aboutus
                '        fom.ShowDialog()
                '    End If


                'End While
                start = Now.TimeOfDay
                Dim myForm As New frmMain
                myForm.tlsUser.Text = "USER:" & Me.txtUsername.Text
                myForm.tlsUser.ForeColor = System.Drawing.Color.Green
                myForm.Refresh()

                myForm.Show()

                Me.Close()

            Else
                MsgBox("Invalid Username and\or Password !!", MsgBoxStyle.Exclamation, "PrintPro")

            End If
        Catch ex As Exception
            Throw

        End Try
    End Sub
   
    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
     

        Try
            Me.USERSTableAdapter.Fill(Me.WeighconDataSet.USERS)

        Catch ex As Exception
            Dim fom As New FrmDataenviroment
            fom.Show()
            Me.Close()
        End Try
    End Sub

    Private Sub USERSBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Validate()
        Me.USERSBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.WeighconDataSet)

    End Sub
End Class