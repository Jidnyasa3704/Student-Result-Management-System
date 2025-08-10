Imports System.Data.SqlClient

Public Class Form6
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con = New SqlConnection("Data Source=JIDNYASANAIK;Initial Catalog=register;Integrated Security=True")
        con.Open()
        con.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Form_sem1.Show()
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        con.Open()
        Dim str As String
        str = "select sem, sub from teacher where Name='" + TextBox2.Text + "'"
        Dim cmd As New SqlCommand(str, con)
        Dim myreader As SqlDataReader
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable()
        adapter.Fill(table)

        myreader = cmd.ExecuteReader()
        myreader.Read()
        ComboBox1.DataSource = table
        ComboBox1.DisplayMember = "sem"

        ComboBox2.DataSource = table
        ComboBox2.DisplayMember = "sub"

        con.Close()
    End Sub

    Private Sub LOGOUTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LOGOUTToolStripMenuItem.Click
        Me.Close()
        Form2.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Form_sem1.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
        Form_sem2.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
        Form_sem3.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
        Form_sem4.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Close()
        Form_sem5.Show()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        Form1.Close()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs)
        Form_sem1_Browse.Show()
        Me.Close()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Result_Analysis.Show()
        Me.Close()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Form5.Show()
        Me.Close()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Result.Show()
        Me.Close()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Form_sem6.Show()
        Me.Close()
    End Sub
End Class