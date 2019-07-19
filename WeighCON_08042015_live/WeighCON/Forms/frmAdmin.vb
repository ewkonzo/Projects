Public Class frmUsers

    Private Sub frmUsers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.GroupsTableAdapter.Fill(Me.WEIGHCONDataSet.Groups)

        Me.USERSTableAdapter.Fill(Me.WEIGHCONDataSet.USERS)

    End Sub

    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        frmAddUsers.ShowDialog()

    End Sub

    Private Sub AddToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim fom As New frmAddGroup
        fom.ShowDialog()
    End Sub

    Private Sub USERSBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USERSBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.USERSBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.WEIGHCONDataSet)

    End Sub

    Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorAddNewItem.Click
        Dim fom As New frmAddUsers
        fom.Button1.Enabled = False
        fom.GroupsTableAdapter.Fill(fom.WEIGHCONDataSet.Groups)
        fom.USERSBindingSource.AddNew()
        fom.ShowDialog()
        USERSTableAdapter.Fill(WEIGHCONDataSet.USERS)
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Me.Validate()
        Me.GroupsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.WEIGHCONDataSet)
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Select Case TabControl1.SelectedIndex
            Case 0
                Me.GroupsTableAdapter.Fill(Me.WEIGHCONDataSet.Groups)
        End Select
    End Sub

    Private Sub USERSDataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles USERSDataGridView.CellContentClick

    End Sub

    Private Sub USERSDataGridView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles USERSDataGridView.DoubleClick
        Dim fom As New frmAddUsers

        fom.USERSTableAdapter.Fill(fom.WEIGHCONDataSet.USERS)
        fom.GroupsTableAdapter.Fill(fom.WEIGHCONDataSet.Groups)
        fom.USERSBindingSource.Position = Me.USERSBindingSource.Position
        fom.ShowDialog()
        USERSTableAdapter.Fill(WEIGHCONDataSet.USERS)
    End Sub

    Private Sub GroupsDataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GroupsDataGridView.CellContentClick

    End Sub
End Class