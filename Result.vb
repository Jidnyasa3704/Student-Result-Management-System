Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel

Public Class Result

    Dim con As New SqlConnection
    Dim cmd As New SqlCommand

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim sem As String = ComboBox1.SelectedItem
        Dim enroll As String = TextBox2.Text
        con.Open()

        Dim cmd As String = "SELECT * FROM " + sem + " WHERE Enrollment = '" & TextBox2.Text & "'"
        Dim abcd As New SqlDataAdapter(cmd, con)
        Dim ds As New DataSet()
        abcd.Fill(ds, "register")
        DataGridView1.DataSource = ds.Tables(0)
        con.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        Form1.Close()
    End Sub

    Private Sub Result_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con = New SqlConnection("Data Source=JIDNYASANAIK;Initial Catalog=register;Integrated Security=True")
        con.Open()
        con.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
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