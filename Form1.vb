Imports MySql.Data.MySqlClient
Public Class Form1
    Private Sub UserControl21_Load(sender As Object, e As EventArgs)

    End Sub
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim myConnectionString As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        myConnectionString = "server=127.0.0.1;" _
               & "uid=root;" _
               & "pwd=root;" _
               & "database=db"

        conn.ConnectionString = myConnectionString
        conn.Open()

        Using con As New MySqlConnection(myConnectionString)
            Using cmd As New MySql.Data.MySqlClient.MySqlCommand("SELECT items.id,items.name,items.stocks FROM items ", conn)
                cmd.CommandType = CommandType.Text
                Using sda As New MySqlDataAdapter(cmd)
                    Using dt As New DataTable()
                        sda.Fill(dt)
                        DataGridView1.DataSource = dt
                        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
                        DataGridView1.Columns(0).Visible = False
                        DataGridView1.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                        DataGridView1.Columns(1).HeaderCell.Value = "Name"
                        DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        DataGridView1.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                        DataGridView1.Columns(2).HeaderCell.Value = "Stock"
                        DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                        '  BunifuCustomDataGrid1.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                        'BunifuCustomDataGrid1.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                        ' BunifuCustomDataGrid1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        '  BunifuCustomDataGrid1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter



                    End Using
                End Using
            End Using
        End Using
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub UserControl21_Load_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub UserControl11_Load(sender As Object, e As EventArgs) Handles UserControl11.Load

    End Sub
End Class
