Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class Form2
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con = New SqlConnection("Data Source=JIDNYASANAIK;Initial Catalog=register;Integrated Security=True")
        con.Open()
        con.Close()
    End Sub

    Private Sub Login_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        con.Open()
        If TextBox2.Text = "" Then
            MsgBox("Enter Username", MsgBoxStyle.Critical)
        ElseIf TextBox2.Text = "" Then
            MsgBox("Enter Password", MsgBoxStyle.Critical)
        Else
            Dim query As String
            query = "select * from reg where username='" + TextBox2.Text + "'and password='" + TextBox3.Text + "' and usertype='" + ComboBox1.SelectedItem + "'"
            cmd = New SqlCommand(query, con)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim ds As DataSet = New DataSet()
            da.Fill(ds)
            Dim a As Integer
            a = ds.Tables(0).Rows.Count

            If a = 0 Then
                MsgBox("Login Failed", MsgBoxStyle.Critical)
            ElseIf ComboBox1.SelectedItem = "HOD" Then
                MessageBox.Show("Login Successful as HOD")
                Form4.Show()
                Form4.Label1.Text = TextBox2.Text
                Form5.Label6.Text = TextBox2.Text
                Form6.Label6.Text = TextBox2.Text
                Form_sem1.Label13.Text = TextBox2.Text
                Form_sem1_Browse.Label13.Text = TextBox2.Text
                Form_sem2.Label14.Text = TextBox2.Text
                Form_sem2_Browse.Label13.Text = TextBox2.Text
                Form_sem3.Label13.Text = TextBox2.Text
                Form_sem3_Browse.Label13.Text = TextBox2.Text
                Form_sem4.Label13.Text = TextBox2.Text
                Form_sem4_Browse.Label13.Text = TextBox2.Text
                Form_sem5.Label13.Text = TextBox2.Text
                Form_sem5_Browse.Label13.Text = TextBox2.Text
                Form_sem6.Label13.Text = TextBox2.Text
                Form_sem6_Browse.Label13.Text = TextBox2.Text
                Result.Label7.Text = TextBox2.Text
                Result_Analysis.Label7.Text = TextBox2.Text
                Me.Close()
            ElseIf ComboBox1.SelectedItem = "Teacher" Then
                MessageBox.Show("Login Successful as Teacher")
                Form6.Show()
                Form6.Label6.Text = TextBox2.Text
                Form_sem1.Label13.Text = TextBox2.Text
                Form_sem1_Browse.Label13.Text = TextBox2.Text
                Form_sem2.Label14.Text = TextBox2.Text
                Form_sem2_Browse.Label13.Text = TextBox2.Text
                Form_sem3.Label13.Text = TextBox2.Text
                Form_sem3_Browse.Label13.Text = TextBox2.Text
                Form_sem4.Label13.Text = TextBox2.Text
                Form_sem4_Browse.Label13.Text = TextBox2.Text
                Form_sem5.Label13.Text = TextBox2.Text
                Form_sem5_Browse.Label13.Text = TextBox2.Text
                Form_sem6.Label13.Text = TextBox2.Text
                Form_sem6_Browse.Label13.Text = TextBox2.Text
                Result.Label7.Text = TextBox2.Text
                Result_Analysis.Label7.Text = TextBox2.Text
                Me.Close()
            End If
        End If
        con.Close()
       
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ComboBox1.ResetText()
        TextBox2.Clear()
        TextBox3.Clear()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
        Form1.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
        Form3.Show()
    End Sub

End Class