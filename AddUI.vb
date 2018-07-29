Imports MySql.Data.MySqlClient
Public Class AddUI
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim myConnectionString As String



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        myConnectionString = "server=127.0.0.1;" _
               & "uid=root;" _
              & "pwd=;" _
                & "SslMode=none;" _
               & "database=db"

        conn.ConnectionString = myConnectionString
        conn.Open()

        Using cmd1 As New MySqlCommand("Select COUNT(*) FROM items where name ='" + TextBox1.Text + "'", conn)
            cmd1.CommandType = CommandType.Text

            If cmd1.ExecuteScalar > 0 Then
                MsgBox("Item is already registered.", MsgBoxStyle.Exclamation, "Error")

            Else

                If TextBox1.Text = "" Then
                    MsgBox("Inputs cannot be blank.", MsgBoxStyle.Exclamation, "Process Complete")
                Else
                    Using con As New MySqlConnection(myConnectionString)
                        Using cmd As New MySqlCommand(" INSERT INTO `db`.`items` (`name`,`categoryID`,`tagID`,`stocks`,`isDeployable`,`isDamaged`,`isOnrepair`,`isRented`,`description`) VALUES ('" + TextBox1.Text + "'," & ComboBox1.SelectedIndex + 1 & ",1,0,0,0,0,0,'" & TextBox2.Text & "');", conn)
                            cmd.CommandType = CommandType.Text

                            If cmd.ExecuteNonQuery > 0 Then
                                MsgBox("Successfully added to database", MsgBoxStyle.Exclamation, "Process Complete")
                                Using cmd2 As New MySql.Data.MySqlClient.MySqlCommand("SELECT items.id,items.name,items.stocks FROM items ", conn)
                                    cmd2.CommandType = CommandType.Text
                                    Using sda As New MySqlDataAdapter(cmd2)
                                        Using dt As New DataTable()
                                            sda.Fill(dt)
                                            EquipmentUI.DataGridView1.DataSource = dt
                                            EquipmentUI.DataGridView1.ReadOnly = False
                                            EquipmentUI.DataGridView1.ClearSelection()
                                            'DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
                                            EquipmentUI.DataGridView1.Columns(1).Visible = False
                                            EquipmentUI.DataGridView1.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                                            EquipmentUI.DataGridView1.Columns(2).HeaderCell.Value = "Name"
                                            EquipmentUI.DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                                            EquipmentUI.DataGridView1.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                                            EquipmentUI.DataGridView1.Columns(3).HeaderCell.Value = "Stock"
                                            EquipmentUI.DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                                            EquipmentUI.DataGridView1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                                            EquipmentUI.DataGridView1.Columns(0).HeaderCell.Value = ""
                                            EquipmentUI.DataGridView1.Columns(0).Width = 50
                                            EquipmentUI.DataGridView1.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                                            EquipmentUI.DataGridView1.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                                        End Using
                                    End Using
                                End Using

                                TextBox1.Text = ""
                                TextBox2.Text = ""
                                Me.Hide()
                            End If
                        End Using
                    End Using
                End If
            End If
        End Using
        conn.Close()

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub
End Class