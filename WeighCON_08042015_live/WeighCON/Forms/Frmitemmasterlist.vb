Public Class Frmitemmasterlist

    Private Sub ITEMMASTERBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ITEMMASTERBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.ITEMMASTERBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.WEIGHCONDataSet)
        MsgBox("Items Saved successfully", MsgBoxStyle.Information)
    End Sub

    Private Sub Frmitemmasterlist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'WEIGHCONDataSet.ITEMMASTER' table. You can move, or remove it, as needed.
        Me.ITEMMASTERTableAdapter.Fill(Me.WEIGHCONDataSet.ITEMMASTER)

    End Sub
End Class