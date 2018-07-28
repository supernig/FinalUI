Imports MySql.Data.MySqlClient
Public Class UserControl1
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim myConnectionString As String

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        myConnectionString = "server=127.0.0.1;" _
               & "uid=root;" _
               & "pwd=root;" _
               & "database=db"

        conn.ConnectionString = myConnectionString
        conn.Open()
        Using con As New MySqlConnection(myConnectionString)
            Using cmd As New MySql.Data.MySqlClient.MySqlCommand("SELECT items.id,items.name,items.stocks FROM items where categoryID=" & ComboBox1.SelectedIndex + 1, conn)
                cmd.CommandType = CommandType.Text
                Using sda As New MySqlDataAdapter(cmd)
                    Using dt As New DataTable()
                        sda.Fill(dt)
                        Form1.DataGridView1.DataSource = dt
                        Form1.DataGridView1.Columns(0).Visible = False
                        Form1.DataGridView1.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Form1.DataGridView1.Columns(2).HeaderCell.Value = "Stocks"
                        Form1.DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Form1.DataGridView1.Refresh()
                        '  MsgBox(Form1.DataGridView1.Rows(0).Cells(1).Value.ToString())
                        conn.Close()
                        '  BunifuCustomDataGrid1.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                        'BunifuCustomDataGrid1.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                        ' BunifuCustomDataGrid1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        '  BunifuCustomDataGrid1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter



                    End Using
                End Using
            End Using
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub UserControl1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox1.SelectedIndex > -1 Then
            MsgBox("taka ra")
            myConnectionString = "server=127.0.0.1;" _
             & "uid=root;" _
             & "pwd=root;" _
             & "database=db"

            conn.ConnectionString = myConnectionString
            conn.Open()
            Using con As New MySqlConnection(myConnectionString)
                Using cmd As New MySql.Data.MySqlClient.MySqlCommand("SELECT items.id,items.name,items.is" & ComboBox2.SelectedItem & " FROM items where categoryID =" & ComboBox1.SelectedIndex + 1, conn)
                    cmd.CommandType = CommandType.Text
                    Using sda As New MySqlDataAdapter(cmd)
                        Using dt As New DataTable()
                            sda.Fill(dt)
                            Form1.DataGridView1.DataSource = dt
                            Form1.DataGridView1.Columns(0).Visible = False
                            Form1.DataGridView1.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                            Form1.DataGridView1.Columns(2).HeaderCell.Value = "Stocks"
                            Form1.DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            Form1.DataGridView1.Refresh()
                            '  MsgBox(Form1.DataGridView1.Rows(0).Cells(1).Value.ToString())
                            conn.Close()
                            '  BunifuCustomDataGrid1.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                            'BunifuCustomDataGrid1.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                            ' BunifuCustomDataGrid1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            '  BunifuCustomDataGrid1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter



                        End Using
                    End Using
                End Using
            End Using


        End If
        If ComboBox1.SelectedIndex = -1 Then

            MsgBox("SELECT items.id,items.name,items.is" & ComboBox2.SelectedItem & " FROM items ")
            myConnectionString = "server=127.0.0.1;" _
             & "uid=root;" _
             & "pwd=root;" _
             & "database=db"

            conn.ConnectionString = myConnectionString
            conn.Open()
            Using con As New MySqlConnection(myConnectionString)
                Using cmd As New MySql.Data.MySqlClient.MySqlCommand("SELECT items.id,items.name,items.is" & ComboBox2.SelectedItem & " FROM items ", conn)
                    cmd.CommandType = CommandType.Text
                    Using sda As New MySqlDataAdapter(cmd)
                        Using dt As New DataTable()
                            sda.Fill(dt)
                            Form1.DataGridView1.DataSource = dt
                            Form1.DataGridView1.Columns(0).Visible = False
                            Form1.DataGridView1.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                            Form1.DataGridView1.Columns(2).HeaderCell.Value = "Stocks"
                            Form1.DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            Form1.DataGridView1.Refresh()
                            '  MsgBox(Form1.DataGridView1.Rows(0).Cells(1).Value.ToString())
                            conn.Close()
                            '  BunifuCustomDataGrid1.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                            'BunifuCustomDataGrid1.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                            ' BunifuCustomDataGrid1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            '  BunifuCustomDataGrid1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter



                        End Using
                    End Using
                End Using
            End Using
        End If

    End Sub
End Class
