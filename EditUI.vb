﻿Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Public Class EditUI
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim myConnectionString As String

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        myConnectionString = "server=127.0.0.1;" _
 & "uid=root;" _
 & "pwd=;" _
                & "SslMode=none;" _
 & "database=db"

        conn.ConnectionString = myConnectionString
        conn.Open()

        Using con As New MySqlConnection(myConnectionString)
            Using cmd As New MySql.Data.MySqlClient.MySqlCommand("SELECT items.id,items.name,items.stocks,category.description,items.description,items.isDeployable,items.isDamaged,items.isOnrepair,items.isRented,items.isDeployed,items.isDamagedBeyondRepair FROM items left join category on items.categoryID = category.id where items.id =" & EquipmentUI.A, conn)
                cmd.CommandType = CommandType.Text
                Using sda As New MySqlDataAdapter(cmd)

                    Dim myreader As MySqlDataReader = cmd.ExecuteReader()
                    If myreader.Read() Then
                        TextBox1.Text = myreader.GetValue(1)
                        ComboBox1.SelectedIndex = ComboBox1.FindStringExact(myreader.GetValue(3))
                        TextBox3.Text = myreader.GetValue(2)
                        If myreader.IsDBNull(4) Then
                            TextBox2.Text = "Not specified"
                        Else
                            TextBox2.Text = myreader.GetValue(4)
                        End If
                        TextBox4.Text = myreader.GetValue(5)
                        TextBox5.Text = myreader.GetValue(6)
                        TextBox6.Text = myreader.GetValue(7)
                        TextBox7.Text = myreader.GetValue(8)
                        dep.Text = myreader.GetValue(9)
                        dbr.Text = myreader.GetValue(10)
                        Me.Text = myreader.GetValue(1)
                    End If
                    myreader.Close()
                End Using
            End Using
        End Using

        conn.Close()
       
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        conn.Open()
        Using con As New MySqlConnection(myConnectionString)
            Using cmd As New MySqlCommand(" UPDATE `db`.`items` SET `name`='" + TextBox1.Text + "',`stocks`=" & TextBox3.Text & ",`categoryID`=" & ComboBox1.SelectedIndex + 1 & ",`description`=" & TextBox2.Text & ",`isDeployable`=" & TextBox4.Text & ",`isDamaged`=" & TextBox5.Text & ",`isOnrepair`=" & TextBox6.Text & ",`isRented`=" & TextBox7.Text & ",`isDeployed`=" & dep.Text & ",`isDamagedBeyondRepair`=" & dbr.Text & " WHERE (`id` = '" & EquipmentUI.A & "');", conn)
                cmd.CommandType = CommandType.Text

                If cmd.ExecuteNonQuery > 0 Then
                    MsgBox("Successfully updated in the database", MsgBoxStyle.Exclamation, "Process Complete")
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

                    Me.Hide()
                    Dim b = New ViewUI()
                    b.Hide()


                End If
            End Using
        End Using
        conn.Close()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub
End Class