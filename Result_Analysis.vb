Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel

Public Class Result_Analysis
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand

    Private Sub Result_Analysis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con = New SqlConnection("Data Source=JIDNYASANAIK;Initial Catalog=register;Integrated Security=True")
        con.Open()
        con.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem = "sem1" Then
            ComboBox2.Items.Clear()
            ComboBox2.Items.Add("ENG")
            ComboBox2.Items.Add("BSC")
            ComboBox2.Items.Add("BMS")

        ElseIf ComboBox1.SelectedItem = "sem2" Then
            ComboBox2.Items.Clear()
            ComboBox2.Items.Add("EEC")
            ComboBox2.Items.Add("AMI")
            ComboBox2.Items.Add("BEC")
            ComboBox2.Items.Add("PCI")

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

        ElseIf ComboBox1.SelectedItem = "sem5" Then
            ComboBox2.Items.Clear()
            ComboBox2.Items.Add("EST")
            ComboBox2.Items.Add("OSY")
            ComboBox2.Items.Add("AJP")
            ComboBox2.Items.Add("STE")
            ComboBox2.Items.Add("CSS")
            ComboBox2.Items.Add("ACN")

        Else
            ComboBox2.Items.Clear()
            ComboBox2.Items.Add("MGT")
            ComboBox2.Items.Add("PWP")
            ComboBox2.Items.Add("MAD")
            ComboBox2.Items.Add("ETI")
            ComboBox2.Items.Add("WBP")
            ComboBox2.Items.Add("NIS")
        End If
        Dim subject As String = ComboBox2.SelectedItem
        Dim sem As String = ComboBox1.SelectedItem
        Label6.Text = subject
        con.Open()
        Dim cmd As String = "select * from " + sem
        Dim abcd As New SqlDataAdapter(cmd, con)
        Dim ds As New DataSet()
        abcd.Fill(ds, "register")
        DataGridView1.DataSource = ds.Tables(0)
        con.Close()
    End Sub


    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

        Dim subject As String = ComboBox2.SelectedItem
        Dim sem As String = ComboBox1.SelectedItem

        con.Open()
        Dim cmd As String = "select Enrollment,Name," + subject + " from " + sem
        Dim abcd As New SqlDataAdapter(cmd, con)
        Dim ds As New DataSet()
        abcd.Fill(ds, "register")
        DataGridView1.DataSource = ds.Tables(0)

        Dim cmd1 As String = "select Top 1 " + subject + ", Enrollment,Name  from " + sem + " order by " + subject + " desc "
        Dim res As New SqlDataAdapter(cmd1, con)
        Dim dsa As New DataSet()
        res.Fill(dsa, "register")
        DataGridView2.DataSource = dsa.Tables(0)

        Dim cmd2 As String = "select  Top 1 " + subject + ", Enrollment, Name  from " + sem + " order by " + subject + " asc "
        Dim result As New SqlDataAdapter(cmd2, con)
        Dim dsla As New DataSet()
        result.Fill(dsla, "register")
        DataGridView3.DataSource = dsla.Tables(0)
        con.Close()

    End Sub

    Private Sub SUBMIT_Click(sender As Object, e As EventArgs) Handles SUBMIT.Click
        Dim min_marks = TextBox2.Text
        Dim max_marks = TextBox3.Text

        Dim subject As String = ComboBox2.SelectedItem
        Dim sem As String = ComboBox1.SelectedItem
        con.Open()

        Dim cmd As String = "select * from " + sem + " where Percentage between " + min_marks + " and " + max_marks

        Dim abcd As New SqlDataAdapter(cmd, con)
        Dim ds As New DataSet()
        abcd.Fill(ds, "register")
        DataGridView1.DataSource = ds.Tables(0)

        con.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim excel As Excel.Application
        Dim workbook As Excel.Workbook
        Dim worksheet As Excel.Worksheet
        excel = CreateObject("Excel.application")
        excel.Visible = True
        workbook = excel.Workbooks.Add
        worksheet = workbook.ActiveSheet
        For i = 0 To DataGridView1.RowCount - 2
            For j = 0 To DataGridView1.ColumnCount - 1
                worksheet.Cells(i + 1, j + 1) = DataGridView1(j, i).Value.ToString()
            Next
        Next
        excel.Quit()
    End Sub

    Private Sub LOGOUTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LOGOUTToolStripMenuItem.Click
        Me.Close()
        Form2.Show()
    End Sub
End Class