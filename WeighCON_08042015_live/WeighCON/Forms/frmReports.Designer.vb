<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReports
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReports))
        Dim ITEMLOGGridEX_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.WeighconDataSet = New PrintPro.weighconDataSet()
        Me.ITEMLOGBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ITEMLOGTableAdapter = New PrintPro.weighconDataSetTableAdapters.ITEMLOGTableAdapter()
        Me.TableAdapterManager = New PrintPro.weighconDataSetTableAdapters.TableAdapterManager()
        Me.ITEMLOGBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ITEMLOGBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.ITEMLOGGridEX = New Janus.Windows.GridEX.GridEX()
        CType(Me.WeighconDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ITEMLOGBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ITEMLOGBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ITEMLOGBindingNavigator.SuspendLayout()
        CType(Me.ITEMLOGGridEX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'WeighconDataSet
        '
        Me.WeighconDataSet.DataSetName = "weighconDataSet"
        Me.WeighconDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ITEMLOGBindingSource
        '
        Me.ITEMLOGBindingSource.DataMember = "ITEMLOG"
        Me.ITEMLOGBindingSource.DataSource = Me.WeighconDataSet
        '
        'ITEMLOGTableAdapter
        '
        Me.ITEMLOGTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.GroupsTableAdapter = Nothing
        Me.TableAdapterManager.ITEMLOGTableAdapter = Me.ITEMLOGTableAdapter
        Me.TableAdapterManager.ITEMMASTERTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = PrintPro.weighconDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.USERSTableAdapter = Nothing
        '
        'ITEMLOGBindingNavigator
        '
        Me.ITEMLOGBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.ITEMLOGBindingNavigator.BindingSource = Me.ITEMLOGBindingSource
        Me.ITEMLOGBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.ITEMLOGBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.ITEMLOGBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.ITEMLOGBindingNavigatorSaveItem})
        Me.ITEMLOGBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.ITEMLOGBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.ITEMLOGBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.ITEMLOGBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.ITEMLOGBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.ITEMLOGBindingNavigator.Name = "ITEMLOGBindingNavigator"
        Me.ITEMLOGBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.ITEMLOGBindingNavigator.Size = New System.Drawing.Size(701, 25)
        Me.ITEMLOGBindingNavigator.TabIndex = 0
        Me.ITEMLOGBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        Me.BindingNavigatorAddNewItem.Visible = False
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Delete"
        Me.BindingNavigatorDeleteItem.Visible = False
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = Global.PrintPro.My.Resources.Resources.nav_right_blue
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ITEMLOGBindingNavigatorSaveItem
        '
        Me.ITEMLOGBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ITEMLOGBindingNavigatorSaveItem.Image = Global.PrintPro.My.Resources.Resources.disks
        Me.ITEMLOGBindingNavigatorSaveItem.Name = "ITEMLOGBindingNavigatorSaveItem"
        Me.ITEMLOGBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.ITEMLOGBindingNavigatorSaveItem.Text = "Save Data"
        Me.ITEMLOGBindingNavigatorSaveItem.Visible = False
        '
        'ITEMLOGGridEX
        '
        Me.ITEMLOGGridEX.DataSource = Me.ITEMLOGBindingSource
        ITEMLOGGridEX_DesignTimeLayout.LayoutString = resources.GetString("ITEMLOGGridEX_DesignTimeLayout.LayoutString")
        Me.ITEMLOGGridEX.DesignTimeLayout = ITEMLOGGridEX_DesignTimeLayout
        Me.ITEMLOGGridEX.Location = New System.Drawing.Point(12, 57)
        Me.ITEMLOGGridEX.Name = "ITEMLOGGridEX"
        Me.ITEMLOGGridEX.Size = New System.Drawing.Size(599, 339)
        Me.ITEMLOGGridEX.TabIndex = 1
        '
        'frmReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(701, 453)
        Me.Controls.Add(Me.ITEMLOGGridEX)
        Me.Controls.Add(Me.ITEMLOGBindingNavigator)
        Me.Name = "frmReports"
        Me.Text = "Reports"
        CType(Me.WeighconDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ITEMLOGBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ITEMLOGBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ITEMLOGBindingNavigator.ResumeLayout(False)
        Me.ITEMLOGBindingNavigator.PerformLayout()
        CType(Me.ITEMLOGGridEX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents WeighconDataSet As PrintPro.weighconDataSet
    Friend WithEvents ITEMLOGBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ITEMLOGTableAdapter As PrintPro.weighconDataSetTableAdapters.ITEMLOGTableAdapter
    Friend WithEvents TableAdapterManager As PrintPro.weighconDataSetTableAdapters.TableAdapterManager
    Friend WithEvents ITEMLOGBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ITEMLOGBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ITEMLOGGridEX As Janus.Windows.GridEX.GridEX
End Class
