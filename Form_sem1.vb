Imports System.Data.SqlClient

Public Class Form_sem1
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand

    Private Sub Form_sem1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con = New SqlConnection("Data Source=JIDNYASANAIK;Initial Catalog=register;Integrated Security=True")
        con.Open()
        con.Close()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Close()
        Form6.Show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Close()
        Form1.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cmd As String = "select * from sem1"
        Dim abcd As New SqlDataAdapter(cmd, con)
        Dim ds As New DataSet()
        abcd.Fill(ds, "register")
        DataGridView1.DataSource = ds.Tables(0)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        con.Open()
        Dim total = Val(TextBox3.Text) + Val(TextBox4.Text) + Val(TextBox5.Text) + Val(TextBox6.Text) + Val(TextBox7.Text) + Val(TextBox8.Text)
        Dim per = (total / 700) * 100
        TextBox9.Text = total
        TextBox10.Text = per
        Dim cmd As New SqlCommand("insert into sem1(Enrollment,Name,ENG,BSC,BMS,ICT,EGE,WPC,Total,Percentage)values( '" + TextBox1.Text + "','" + TextBox2.Text + "', '" + TextBox3.Text + "', '" + TextBox4.Text + "','" + TextBox5.Text + "', '" + TextBox6.Text + "','" + TextBox7.Text + "', '" + TextBox8.Text + "','" + TextBox9.Text + "','" + TextBox10.Text + "')", con)
        cmd.ExecuteNonQuery()
        con.Close()
        MessageBox.Show("Inserted Successfully")
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        con.Open()
        Dim cmd As New SqlCommand("delete from sem1 where enrollment='" + TextBox1.Text + "'", con)
        cmd.ExecuteNonQuery()
        con.Close()
        MessageBox.Show("Deleted successfully")
        TextBox1.Clear()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        con.Open()
        Dim total = Val(TextBox3.Text) + Val(TextBox4.Text) + Val(TextBox5.Text) + Val(TextBox6.Text) + Val(TextBox7.Text) + Val(TextBox8.Text)
        Dim per = (total / 700) * 100
        TextBox9.Text = total
        TextBox10.Text = per
        Dim cmd As New SqlCommand("update sem1 set Name='" + TextBox2.Text + "',ENG='" + TextBox3.Text + "',BSC='" + TextBox4.Text + "',BMS='" + TextBox5.Text + "',ICT='" + TextBox6.Text + "',EGE='" + TextBox7.Text + "',WPC='" + TextBox8.Text + "',Total='" + TextBox9.Text + "',Percentage='" + TextBox10.Text + "'where Enrollment='" + TextBox1.Text + "' ", con)
        cmd.ExecuteNonQuery()
        con.Close()
        MessageBox.Show("Updated Successfullly")
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form_sem1_Browse.Show()
        Me.Close()
    End Sub

    Private Sub LOGOUTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LOGOUTToolStripMenuItem.Click
        Me.Close()
        Form2.Show()
    End Sub
End Class