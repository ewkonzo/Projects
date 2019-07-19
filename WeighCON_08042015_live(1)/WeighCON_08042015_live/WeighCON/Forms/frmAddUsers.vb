Public Class frmAddUsers

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click, Button1.Click
        If String.Compare(Me.TextBox3.Text, UserPasswordTextBox.Text, False) = 1 Then
            MsgBox("Password confirmation erro", MsgBoxStyle.Critical)
        Else
            Me.Validate()
            Me.USERSBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(WEIGHCONDataSet)
            MsgBox("User successfully Saved")
            Me.Button1.Enabled = True
        End If
    End Sub

    Private Sub frmAddUsers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        
    End Sub
End Class