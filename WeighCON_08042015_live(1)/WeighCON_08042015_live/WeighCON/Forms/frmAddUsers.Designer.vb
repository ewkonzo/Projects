<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddUsers
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
        Dim UsernameLabel As System.Windows.Forms.Label
        Dim UserfullnameLabel As System.Windows.Forms.Label
        Dim UserPasswordLabel As System.Windows.Forms.Label
        Dim UserGroupLabel As System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.USERSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.WEIGHCONDataSet = New PrintPro.weighconDataSet()
        Me.GroupsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.UserPasswordTextBox = New System.Windows.Forms.TextBox()
        Me.UsernameTextBox = New System.Windows.Forms.TextBox()
        Me.UserfullnameTextBox = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.USERSTableAdapter = New PrintPro.weighconDataSetTableAdapters.USERSTableAdapter()
        Me.TableAdapterManager = New PrintPro.weighconDataSetTableAdapters.TableAdapterManager()
        Me.GroupsTableAdapter = New PrintPro.weighconDataSetTableAdapters.GroupsTableAdapter()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.UserGroupComboBox = New System.Windows.Forms.ComboBox()
        UsernameLabel = New System.Windows.Forms.Label()
        UserfullnameLabel = New System.Windows.Forms.Label()
        UserPasswordLabel = New System.Windows.Forms.Label()
        UserGroupLabel = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.USERSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WEIGHCONDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UsernameLabel
        '
        UsernameLabel.AutoSize = True
        UsernameLabel.Location = New System.Drawing.Point(23, 16)
        UsernameLabel.Name = "UsernameLabel"
        UsernameLabel.Size = New System.Drawing.Size(59, 13)
        UsernameLabel.TabIndex = 5
        UsernameLabel.Text = "User name:"
        '
        'UserfullnameLabel
        '
        UserfullnameLabel.AutoSize = True
        UserfullnameLabel.Location = New System.Drawing.Point(29, 42)
        UserfullnameLabel.Name = "UserfullnameLabel"
        UserfullnameLabel.Size = New System.Drawing.Size(53, 13)
        UserfullnameLabel.TabIndex = 7
        UserfullnameLabel.Text = "Full name:"
        '
        'UserPasswordLabel
        '
        UserPasswordLabel.AutoSize = True
        UserPasswordLabel.Location = New System.Drawing.Point(3, 101)
        UserPasswordLabel.Name = "UserPasswordLabel"
        UserPasswordLabel.Size = New System.Drawing.Size(75, 13)
        UserPasswordLabel.TabIndex = 9
        UserPasswordLabel.Text = "User Password:"
        '
        'UserGroupLabel
        '
        UserGroupLabel.AutoSize = True
        UserGroupLabel.Location = New System.Drawing.Point(20, 68)
        UserGroupLabel.Name = "UserGroupLabel"
        UserGroupLabel.Size = New System.Drawing.Size(62, 13)
        UserGroupLabel.TabIndex = 11
        UserGroupLabel.Text = "User Group:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.UserGroupComboBox)
        Me.GroupBox1.Controls.Add(UserGroupLabel)
        Me.GroupBox1.Controls.Add(Me.TextBox3)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(UserPasswordLabel)
        Me.GroupBox1.Controls.Add(UsernameLabel)
        Me.GroupBox1.Controls.Add(Me.UserPasswordTextBox)
        Me.GroupBox1.Controls.Add(Me.UsernameTextBox)
        Me.GroupBox1.Controls.Add(UserfullnameLabel)
        Me.GroupBox1.Controls.Add(Me.UserfullnameTextBox)
        Me.GroupBox1.Location = New System.Drawing.Point(27, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(344, 170)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "User Details"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(85, 128)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox3.Size = New System.Drawing.Size(239, 22)
        Me.TextBox3.TabIndex = 4
        '
        'USERSBindingSource
        '
        Me.USERSBindingSource.DataMember = "USERS"
        Me.USERSBindingSource.DataSource = Me.WEIGHCONDataSet
        '
        'WEIGHCONDataSet
        '
        Me.WEIGHCONDataSet.DataSetName = "WEIGHCONDataSet"
        Me.WEIGHCONDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GroupsBindingSource
        '
        Me.GroupsBindingSource.DataMember = "Groups"
        Me.GroupsBindingSource.DataSource = Me.WEIGHCONDataSet
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 131)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Confirm Pass"
        '
        'UserPasswordTextBox
        '
        Me.UserPasswordTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.USERSBindingSource, "UserPassword", True))
        Me.UserPasswordTextBox.Location = New System.Drawing.Point(85, 98)
        Me.UserPasswordTextBox.Name = "UserPasswordTextBox"
        Me.UserPasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.UserPasswordTextBox.Size = New System.Drawing.Size(237, 22)
        Me.UserPasswordTextBox.TabIndex = 3
        '
        'UsernameTextBox
        '
        Me.UsernameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.USERSBindingSource, "Username", True))
        Me.UsernameTextBox.Location = New System.Drawing.Point(85, 13)
        Me.UsernameTextBox.Name = "UsernameTextBox"
        Me.UsernameTextBox.Size = New System.Drawing.Size(237, 22)
        Me.UsernameTextBox.TabIndex = 0
        '
        'UserfullnameTextBox
        '
        Me.UserfullnameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.USERSBindingSource, "Userfullname", True))
        Me.UserfullnameTextBox.Location = New System.Drawing.Point(85, 39)
        Me.UserfullnameTextBox.Name = "UserfullnameTextBox"
        Me.UserfullnameTextBox.Size = New System.Drawing.Size(237, 22)
        Me.UserfullnameTextBox.TabIndex = 1
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(274, 186)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(194, 186)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "Save"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'USERSTableAdapter
        '
        Me.USERSTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.GroupsTableAdapter = Me.GroupsTableAdapter
        Me.TableAdapterManager.ITEMLOGTableAdapter = Nothing
        Me.TableAdapterManager.ITEMMASTERTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = PrintPro.weighconDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.USERSTableAdapter = Me.USERSTableAdapter
        '
        'GroupsTableAdapter
        '
        Me.GroupsTableAdapter.ClearBeforeFill = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(91, 186)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Add new"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'UserGroupComboBox
        '
        Me.UserGroupComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.USERSBindingSource, "UserGroup", True))
        Me.UserGroupComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.USERSBindingSource, "UserGroup", True))
        Me.UserGroupComboBox.DataSource = Me.GroupsBindingSource
        Me.UserGroupComboBox.DisplayMember = "GroupName"
        Me.UserGroupComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.UserGroupComboBox.FormattingEnabled = True
        Me.UserGroupComboBox.Location = New System.Drawing.Point(85, 68)
        Me.UserGroupComboBox.Name = "UserGroupComboBox"
        Me.UserGroupComboBox.Size = New System.Drawing.Size(237, 21)
        Me.UserGroupComboBox.TabIndex = 12
        Me.UserGroupComboBox.ValueMember = "GroupName"
        '
        'frmAddUsers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(404, 227)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmAddUsers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Users"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.USERSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WEIGHCONDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents WEIGHCONDataSet As PrintPro.weighconDataSet
    Friend WithEvents USERSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents USERSTableAdapter As PrintPro.WEIGHCONDataSetTableAdapters.USERSTableAdapter
    Friend WithEvents TableAdapterManager As PrintPro.WEIGHCONDataSetTableAdapters.TableAdapterManager
    Friend WithEvents GroupsTableAdapter As PrintPro.WEIGHCONDataSetTableAdapters.GroupsTableAdapter
    Friend WithEvents GroupsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents UserPasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents UsernameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents UserfullnameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents UserGroupComboBox As System.Windows.Forms.ComboBox
End Class
