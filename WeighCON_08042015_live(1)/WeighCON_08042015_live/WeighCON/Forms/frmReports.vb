Public Class frmReports

    Sub New()
        InitializeComponent()
        Bn = ITEMLOGBindingNavigator
        Addnew = BindingNavigatorAddNewItem
        First = BindingNavigatorMoveFirstItem
        Nxt = BindingNavigatorMoveNextItem
        Previous = BindingNavigatorMovePreviousItem
        Last = BindingNavigatorMoveLastItem
        Edit = Nothing
        delete = BindingNavigatorDeleteItem

        gx({ITEMLOGGridEX}, , , , , True, , False)
        Save = ITEMLOGBindingNavigatorSaveItem
        ma = New Padding(50, 0, 0, 0)
        sizes = New Size(24, 24)
        init(Me)
    End Sub

    Private Sub frmReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'WeighconDataSet.ITEMLOG' table. You can move, or remove it, as needed.
        Me.ITEMLOGTableAdapter.Fill(Me.WeighconDataSet.ITEMLOG)
        'TODO: This line of code loads data into the 'WeighconDataSet.ITEMLOG' table. You can move, or remove it, as needed.



    End Sub

   

    Private Sub ITEMLOGBindingNavigatorSaveItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ITEMLOGBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.ITEMLOGBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.WeighconDataSet)

    End Sub
End Class