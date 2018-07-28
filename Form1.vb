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
                        DataGridView1.ReadOnly = False
                        DataGridView1.ClearSelection()

                        'DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
                        DataGridView1.Columns(1).Visible = False
                        DataGridView1.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                        DataGridView1.Columns(2).HeaderCell.Value = "Name"
                        DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        DataGridView1.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                        DataGridView1.Columns(3).HeaderCell.Value = "Stock"
                        DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        DataGridView1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        DataGridView1.Columns(0).HeaderCell.Value = ""
                        DataGridView1.Columns(0).Width = 50
                        DataGridView1.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                        DataGridView1.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill



                    End Using
                End Using
            End Using
        End Using


    End Sub



    Private Sub UserControl21_Load_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub UserControl11_Load(sender As Object, e As EventArgs) Handles UserControl11.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles view.Click

    End Sub

    Private CheckColIndex As Integer = 0



    Private Sub DataGridView1_RowMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs)
        If e.Button = MouseButtons.Left Then

            MsgBox("bogo")
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = DataGridView1.Columns("Column1").Index Then
            DataGridViewCheckBoxColumn_Uncheck()
            Dim cell As DataGridViewCheckBoxCell = DataGridView1.Rows(e.RowIndex).Cells("Column1")
            cell.Value = cell.TrueValue
            Dim Checked As Boolean = CType(DataGridView1.CurrentCell.Value, Boolean)
            If Checked Then
                edit.Visible = True
                view.Visible = True

            Else
                MessageBox.Show("You have un-checked")
            End If



        End If

    End Sub

    Private Sub DataGridViewCheckBoxColumn_Uncheck()
        For Each row As DataGridViewRow In DataGridView1.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("Column1")
            cell.Value = cell.FalseValue
        Next
    End Sub

    Private Sub edit_Click(sender As Object, e As EventArgs) Handles edit.Click

    End Sub
End Class
