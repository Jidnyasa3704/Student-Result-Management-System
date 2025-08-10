Imports System.Data.SqlClient

Public Class Form5

    Dim con As New SqlConnection
    Dim cmd As New SqlCommand

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con = New SqlConnection("Data Source=JIDNYASANAIK;Initial Catalog=register;Integrated Security=True")
        con.Open()
        con.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        con = New SqlConnection("Data Source=JIDNYASANAIK;Initial Catalog=register;Integrated Security=True")
        con.Open()
        Dim cmd As New SqlCommand("insert into teacher(Name, sem,sub)values( '" + TextBox2.Text + "','" + ComboBox1.Text + "', '" + ComboBox2.Text + "')", con)
        cmd.ExecuteNonQuery()
        con.Close()
        MessageBox.Show("Assigned Successfullly")
        TextBox2.Clear()
        ComboBox1.ResetText()
        ComboBox2.ResetText()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        con.Open()
        Dim cmd As New SqlCommand("delete from teacher where name='" + TextBox2.Text + "'", con)
        cmd.ExecuteNonQuery()
        Dim cmd1 As New SqlCommand("delete from reg where name='" + TextBox2.Text + "'", con)
        cmd1.ExecuteNonQuery()
        con.Close()
        MessageBox.Show("Removed Successfullly")
        TextBox2.Clear()
        ComboBox1.ResetText()
        ComboBox2.ResetText()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        Me.Close()
        Form4.Show()
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
        Form4.Show()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem = "sem1" Then
            ComboBox2.Items.Clear()
            ComboBox2.Items.Add("ENG")
            ComboBox2.Items.Add("BSC")
            ComboBox2.Items.Add("BMS")
            ComboBox2.Items.Add("ICT")
            ComboBox2.Items.Add("EGE")
            ComboBox2.Items.Add("WPC")
        ElseIf ComboBox1.SelectedItem = "sem2" Then
            ComboBox2.Items.Clear()
            ComboBox2.Items.Add("EEC")
            ComboBox2.Items.Add("AMI")
            ComboBox2.Items.Add("BEC")
            ComboBox2.Items.Add("PCI")
            ComboBox2.Items.Add("BCC")
            ComboBox2.Items.Add("CPH")
            ComboBox2.Items.Add("WPD")
        ElseIf ComboBox1.SelectedItem = "sem3" Then
            ComboBox2.Items.Clear()
            ComboBox2.Items.Add("OOP")
            ComboBox2.Items.Add("DSU")
            ComboBox2.Items.Add("CGR")
            ComboBox2.Items.Add("DMS")
            ComboBox2.Items.Add("DTE")
        ElseIf ComboBox1.SelectedItem = "sem4" Then
            ComboBox2.Items.Clear()
            ComboBox2.Items.Add("JPR")
            ComboBox2.Items.Add("SEN")
            ComboBox2.Items.Add("DCC")
            ComboBox2.Items.Add("MIC")
            ComboBox2.Items.Add("GAD")
        ElseIf ComboBox1.SelectedItem = "sem5" Then
            ComboBox2.Items.Clear()
            ComboBox2.Items.Add("EST")
            ComboBox2.Items.Add("OSY")
            ComboBox2.Items.Add("AJP")
            ComboBox2.Items.Add("STE")
            ComboBox2.Items.Add("CSS")
            ComboBox2.Items.Add("ACN")
            ComboBox2.Items.Add("ITR")
            ComboBox2.Items.Add("CPP")
        Else
            ComboBox2.Items.Clear()
            ComboBox2.Items.Add("MGT")
            ComboBox2.Items.Add("PWP")
            ComboBox2.Items.Add("MAD")
            ComboBox2.Items.Add("ETI")
            ComboBox2.Items.Add("WBP")
            ComboBox2.Items.Add("NIS")
            ComboBox2.Items.Add("EDE")
            ComboBox2.Items.Add("CPE")
        End If
    End Sub

    Private Sub LOGOUTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LOGOUTToolStripMenuItem.Click
        Form2.Show()
        Me.Close()
    End Sub

End Class