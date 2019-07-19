Public Class FrmDataenviroment

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'server

        'windows authentication

        If RadioButton1.Checked = True Then
            If RadioButton6.Checked = True Then
                If checkdb() = Nothing Then
                    'create database
                    createdb()
                End If
            End If
            Try
                For Each ctl As Control In Me.Controls
                    If TypeOf ctl Is TextBox Then
                        If ctl.Text = "".Trim Then
                            MessageBox.Show("Please Fill in required details")
                            ctl.Focus()
                            Exit Sub
                        End If
                    End If

                Next

                My.Settings.SetUserOverride("WEIGHCONConnectionString", "Data Source=" & Me.TextBox1.Text & ";Initial Catalog=" & Me.TextBox2.Text & ";Integrated Security=True")

                'My.Settings.Save()
                Me.Close()
            Catch ex As Exception
                MessageBox.Show("Could not save the settings", "Saving Failed")
            End Try

            'sql server authentication
        ElseIf RadioButton2.Checked = True Then
            If RadioButton6.Checked = True Then

                If checkdb(TextBox3.Text, TextBox4.Text) = Nothing Then
                    'create database
                    createdb(TextBox3.Text, TextBox4.Text)
                End If

            End If
            Try
                For Each ctl As Control In Me.Controls
                    If TypeOf ctl Is TextBox Then
                        If ctl.Text = "".Trim Then
                            MessageBox.Show("Please Fill in required details")
                            ctl.Focus()
                            Exit Sub
                        End If
                    End If

                Next
                'Data Source=.\sqlexpress;Initial Catalog=FleetManager2;Persist Security Info=True;User ID=sa;password=sa
                My.Settings.SetUserOverride("WEIGHCONConnectionString", "Data Source=" & Me.TextBox1.Text & ";Initial Catalog=" & Me.TextBox2.Text & ";Persist Security Info=True;User ID=" & TextBox3.Text & ";password=" & TextBox4.Text & "")
                My.Settings.Save()
                Me.Close()
            Catch ex As Exception
                MessageBox.Show("Could not save the settings", "Saving Failed")
            End Try

        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        GroupBox2.Visible = False
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        GroupBox2.Visible = True
    End Sub

    Private Sub Frmenvironment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.TextBox1.Text = My.Computer.Name.ToString & "\SQLEXPRESS"

    End Sub


    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
    Function checkdb(Optional ByVal uname As String = "", Optional ByVal pword As String = "") As String

        Dim str As String
        'Dim str As String = "Data Source=localhost;Integrated Security=false;user=sa;password=sa"
        If uname <> "" And pword <> "" Then
            str = "Data Source=" & Me.TextBox1.Text & ";Integrated Security=false;user=" & uname & ";password=" & pword & ""
        Else
            str = "Data Source=" & Me.TextBox1.Text & ";Integrated Security=true;"
        End If
        Dim sqlconn As New SqlClient.SqlConnection(str)
        Dim cmd As New SqlClient.SqlCommand
        Dim reader As SqlClient.SqlDataReader
        cmd.CommandText = "SELECT name FROM master.sys.databases WHERE name = 'Reelinsurance' "
        cmd = New SqlClient.SqlCommand(cmd.CommandText, sqlconn)
        Try
            sqlconn.Open()
            reader = cmd.ExecuteReader
            If reader.HasRows = True Then
                reader.Read()
                Return reader(0)
            Else
                Return Nothing
            End If
            reader.Close()
            sqlconn.Close()
            sqlconn = Nothing

        Catch ex As Exception
            MsgBox("Unable to access the database server: " & ex.Message)
            Return Nothing
            Exit Function
        End Try

    End Function

    Sub createdb(Optional ByVal uname As String = "", Optional ByVal pword As String = "")
        Dim scriptpath As String
        scriptpath = My.Application.Info.DirectoryPath & "\WEIGHCON.sql"
        Dim connectionstring As String
        'Dim str As String = "Data Source=localhost;Integrated Security=false;user=sa;password=sa"
        If uname <> "" And pword <> "" Then
            connectionstring = "Data Source=" & Me.TextBox1.Text & ";Integrated Security=false;user=" & uname & ";password=" & pword & ""
        Else
            connectionstring = "Data Source=" & Me.TextBox1.Text & ";Integrated Security=true;"
        End If
        Dim conn As New SqlClient.SqlConnection(connectionstring)

        Try
            conn.Open()

            ExecuteSQLScript(scriptpath, conn)
            'ExecuteSQLScript("C:\dbs\table.sql", conn)
            'ExecuteSQLScript("C:\dbs\view.sql", conn)
            'ExecuteSQLScript("C:\dbs\sp.sql", conn)

            conn.Close()
            conn = Nothing
            MsgBox("Database Succesfully Configured.")
        Catch ex As Exception
            MsgBox("Error configuring database: " + ex.Message)
        End Try

    End Sub
    Private Sub ExecuteSQLScript(ByVal Filename As String, ByVal conn As SqlClient.SqlConnection)
        Dim cmd As New SqlClient.SqlCommand
        Dim Reader As System.IO.StreamReader

        Try
            cmd.CommandType = CommandType.Text
            cmd.Connection = conn

            Reader = New System.IO.StreamReader(Filename)
            Dim s As String = Reader.ReadToEnd
            s = Replace(s, "GO", "~") 'Replace GO with a "~". Split only works with char
            's = Replace(s, "date", "datetime")
            Dim delimiter() As Char = "~".ToCharArray
            Dim SQL() As String = s.Split(delimiter) 'Now split the different SQL statements into an array
            For I As Integer = 0 To UBound(SQL) 'Loop through array, executing each statement separately
                cmd.CommandText = SQL(I)

                cmd.ExecuteNonQuery()
            Next

            Reader.Close()
            Reader = Nothing
            cmd = Nothing

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GroupBox5_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox5.Enter

    End Sub
End Class
