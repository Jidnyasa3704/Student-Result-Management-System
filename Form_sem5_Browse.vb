
Imports System.IO
Imports ExcelDataReader
Imports System.Data.SqlClient

Public Class Form_sem5_Browse
    Dim table As New DataTable
    Dim adpt As New SqlDataAdapter
    Dim mycmd As New SqlCommand
    Dim tables As DataTableCollection
    Dim enrollment As String = ""
    Dim con As New SqlConnection("Data Source=JIDNYASANAIK;Initial Catalog=register;Integrated Security=True")

    Sub viewDataGridView()
        mycmd.Connection = con
        con.Open()
        mycmd.CommandText = "select Enrollment,Name,EST,OSY,AJP,STE,CSS,ACN,ITR,CPP,Total,Percentage from sem5"
        adpt = New SqlDataAdapter(mycmd)
        table.Rows.Clear()
        adpt.Fill(table)
        DataGridView2.DataSource = table
        con.Close()
    End Sub

    Private Sub LOGOUTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LOGOUTToolStripMenuItem.Click
        Me.Close()
        Form2.Show()
    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        Using ofd As OpenFileDialog = New OpenFileDialog() With {.Filter = "Excel 97-2003 workbook|*.xls|Excel workbook|*.xlsx"}
            If ofd.ShowDialog() = Windows.Forms.DialogResult.OK Then
                TextBox2.Text = ofd.FileName
                Using stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read)
                    Using reader As IExcelDataReader = ExcelReaderFactory.CreateReader(stream)
                        Dim result As DataSet = reader.AsDataSet(New ExcelDataSetConfiguration() With {
                                                                 .ConfigureDataTable = Function(__) New ExcelDataTableConfiguration() With {
                        .UseHeaderRow = True}})
                        tables = result.Tables
                        ComboBox2.Items.Clear()
                        For Each table As DataTable In tables
                            ComboBox2.Items.Add(table.TableName)
                        Next
                    End Using
                End Using
            End If
        End Using
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim dt As DataTable = tables(ComboBox2.SelectedItem.ToString())
        DataGridView2.DataSource = dt
        If dt IsNot Nothing Then
            Dim list As List(Of sem5) = New List(Of sem5)()
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim sem5 As sem5 = New sem5()
                sem5.Name = dt.Rows(i)("name").ToString()
                sem5.Enrollment = dt.Rows(i)("enrollment").ToString()
                sem5.EST = dt.Rows(i)("EST").ToString()
                sem5.OSY = dt.Rows(i)("OSY").ToString()
                sem5.AJP = dt.Rows(i)("AJP").ToString()
                sem5.STE = dt.Rows(i)("STE").ToString()
                sem5.CSS = dt.Rows(i)("CSS").ToString()
                sem5.ACN = dt.Rows(i)("ACN").ToString()
                sem5.ITR = dt.Rows(i)("ITR").ToString()
                sem5.CPP = dt.Rows(i)("CPP").ToString()
                sem5.Total = dt.Rows(i)("Total").ToString()
                sem5.Percentage = dt.Rows(i)("Percentage").ToString()
                list.Add(sem5)
            Next
            DataGridView2.DataSource = list
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        Try
            Dim cmd As SqlCommand
            con.Open()

            For i As Integer = 0 To DataGridView2.Rows.Count - 2 Step +1

                cmd = New SqlCommand("insert into sem5 values (@Enrollment,@Name,@EST,@OSY,@AJP,@STE,@CSS,@ACN,@ITR,@CPP,@Total,@Percentage)", con)

                cmd.Parameters.Add("@Enrollment", SqlDbType.NVarChar).Value = DataGridView2.Rows(i).Cells(0).Value.ToString()
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = DataGridView2.Rows(i).Cells(1).Value.ToString()
                cmd.Parameters.Add("@EST", SqlDbType.NVarChar).Value = DataGridView2.Rows(i).Cells(2).Value.ToString()
                cmd.Parameters.Add("@OSY", SqlDbType.NVarChar).Value = DataGridView2.Rows(i).Cells(3).Value.ToString()
                cmd.Parameters.Add("@AJP", SqlDbType.NVarChar).Value = DataGridView2.Rows(i).Cells(4).Value.ToString()
                cmd.Parameters.Add("@STE", SqlDbType.NVarChar).Value = DataGridView2.Rows(i).Cells(5).Value.ToString()
                cmd.Parameters.Add("@CSS", SqlDbType.NVarChar).Value = DataGridView2.Rows(i).Cells(6).Value.ToString()
                cmd.Parameters.Add("@ACN", SqlDbType.NVarChar).Value = DataGridView2.Rows(i).Cells(7).Value.ToString()
                cmd.Parameters.Add("@ITR", SqlDbType.NVarChar).Value = DataGridView2.Rows(i).Cells(8).Value.ToString()
                cmd.Parameters.Add("@CPP", SqlDbType.NVarChar).Value = DataGridView2.Rows(i).Cells(9).Value.ToString()
                cmd.Parameters.Add("@Total", SqlDbType.NVarChar).Value = DataGridView2.Rows(i).Cells(10).Value.ToString()
                cmd.Parameters.Add("@Percentage", SqlDbType.NVarChar).Value = DataGridView2.Rows(i).Cells(11).Value.ToString()

                cmd.ExecuteNonQuery()
            Next
            MessageBox.Show("All data inserted successfully")
            con.Close()

            viewDataGridView()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Close()
        Form_sem5.Show()
    End Sub

    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Close()
        Form1.Close()
    End Sub

    Private Sub Form_sem5_Browse_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con = New SqlConnection("Data Source=JIDNYASANAIK;Initial Catalog=register;Integrated Security=True")
        con.Open()
        con.Close()
    End Sub
End Class



