Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Public Class ViewUI
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim myConnectionString As String


    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        myConnectionString = "server=127.0.0.1;" _
       & "uid=root;" _
       & "pwd=root;" _
                & "SslMode=none;" _
       & "database=db"

        conn.ConnectionString = myConnectionString
        conn.Open()

        Using con As New MySqlConnection(myConnectionString)
            Using cmd As New MySql.Data.MySqlClient.MySqlCommand("SELECT items.id,items.name,items.stocks,category.description,items.description,items.isDeployable,items.isDamaged,items.isOnrepair,items.isRented FROM items left join category on items.categoryID = category.id where items.id =" & EquipmentUI.A, conn)
                cmd.CommandType = CommandType.Text
                Using sda As New MySqlDataAdapter(cmd)

                    Dim myreader As MySqlDataReader = cmd.ExecuteReader()
                    If myreader.Read() Then
                        Label2.Text = myreader.GetValue(1)
                        Label4.Text = myreader.GetValue(3)
                        Label8.Text = myreader.GetValue(2)
                        If myreader.IsDBNull(4) Then
                            Label6.Text = "Not specified"
                        Else
                            Label6.Text = myreader.GetValue(4)
                        End If
                        Label13.Text = myreader.GetValue(5)
                        Label14.Text = myreader.GetValue(6)
                        Label15.Text = myreader.GetValue(7)
                        Label16.Text = myreader.GetValue(8)
                        Me.Text = myreader.GetValue(1)
                    End If
                    myreader.Close()
                End Using
            End Using
        End Using

        conn.Close()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub
  

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim b = New EditUI()
        b.Show()

    End Sub
End Class