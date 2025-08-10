Imports System.IO
Imports ExcelDataReader
Imports System.Data.SqlClient
Public Class Form_sem1_Browse

    Dim table As New DataTable
    Dim adpt As New SqlDataAdapter
    Dim mycmd As New SqlCommand
    Dim tables As DataTableCollection
    Dim enrollment As String = ""
    Dim con As New SqlConnection("Data Source=JIDNYASANAIK;Initial Catalog=register;Integrated Security=True")

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
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

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click

        Try
            Dim cmd As SqlCommand
            con.Open()

            For i As Integer = 0 To DataGridView2.Rows.Count - 2 Step +1

                cmd = New SqlCommand("insert into sem1 values (@Enrollment,@Name,@ENG,@BSC,@BMS,@ICT,@EGE,@WPC,@Total,@Percentage)", con)

                cmd.Parameters.Add("@Enrollment", SqlDbType.NVarChar).Value = DataGridView2.Rows(i).Cells(0).Value.ToString()
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = DataGridView2.Rows(i).Cells(1).Value.ToString()
                cmd.Parameters.Add("@ENG", SqlDbType.NVarChar).Value = DataGridView2.Rows(i).Cells(2).Value.ToString()
                cmd.Parameters.Add("@BSC", SqlDbType.NVarChar).Value = DataGridView2.Rows(i).Cells(3).Value.ToString()
                cmd.Parameters.Add("@BMS", SqlDbType.NVarChar).Value = DataGridView2.Rows(i).Cells(4).Value.ToString()
                cmd.Parameters.Add("@ICT", SqlDbType.NVarChar).Value = DataGridView2.Rows(i).Cells(5).Value.ToString()
                cmd.Parameters.Add("@EGE", SqlDbType.NVarChar).Value = DataGridView2.Rows(i).Cells(6).Value.ToString()
                cmd.Parameters.Add("@WPC", SqlDbType.NVarChar).Value = DataGridView2.Rows(i).Cells(7).Value.ToString()
                cmd.Parameters.Add("@Total", SqlDbType.NVarChar).Value = DataGridView2.Rows(i).Cells(8).Value.ToString()
                cmd.Parameters.Add("@Percentage", SqlDbType.NVarChar).Value = DataGridView2.Rows(i).Cells(9).Value.ToString()

                cmd.ExecuteNonQuery()
            Next
            MessageBox.Show("All data inserted successfully")
            con.Close()

            viewDataGridView()

        Catch ex As Exception
            Console.WriteLine(ex)
        End Try

    End Sub
    Sub viewDataGridView()
        mycmd.Connection = con
        con.Open()
        mycmd.CommandText = "select * from sem1"
        adpt = New SqlDataAdapter(mycmd)
        table.Rows.Clear()
        adpt.Fill(table)
        DataGridView2.DataSource = table
        con.Close()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim dt As DataTable = tables(ComboBox2.SelectedItem.ToString())
        DataGridView2.DataSource = dt
        If dt IsNot Nothing Then
            Dim list As List(Of sem1) = New List(Of sem1)()
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim sem1 As sem1 = New sem1()
                sem1.Name = dt.Rows(i)("name").ToString()
                sem1.Enrollment = dt.Rows(i)("enrollment").ToString()
                sem1.ENG = dt.Rows(i)("ENG").ToString()
                sem1.BSC = dt.Rows(i)("BSC").ToString()
                sem1.BMS = dt.Rows(i)("BMS").ToString()
                sem1.ICT = dt.Rows(i)("ICT").ToString()
                sem1.EGE = dt.Rows(i)("EGE").ToString()
                sem1.WPC = dt.Rows(i)("WPC").ToString()
                sem1.Total = dt.Rows(i)("Total").ToString()
                sem1.Percentage = dt.Rows(i)("Percentage").ToString()
                list.Add(sem1)
            Next
            DataGridView2.DataSource = list
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Close()
        Form1.Close()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Form_sem1.Show()
        Me.Close()
    End Sub

    Private Sub LOGOUTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LOGOUTToolStripMenuItem.Click
        Me.Close()
        Form2.Show()
    End Sub
End Class
