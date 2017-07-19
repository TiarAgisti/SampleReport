Imports Microsoft.Reporting.WinForms
Imports System.Data
Imports System.Data.SqlClient
Public Class FrmSampleReportUsingTable
    Sub ReportKaryawan()
        Dim rptDataSource As ReportDataSource
        Dim f As New FrmPrintPreview
        With f.rptView.LocalReport
            .ReportPath = "D:\Tiar\SampleReport\RptKaryawan.rdlc"
            .DataSources.Clear()
        End With
        'populasi data dari datagridview 
        Dim ds As DataSet = New DatasetKaryawan
        Dim connectionString As String = "Server=WS020104\SQLEXPRESS;Database=Ocean;User Id=sa;Password=12345;"
        Using myConnection As SqlConnection = New SqlConnection(connectionString)
            If myConnection.State = ConnectionState.Open Then myConnection.Close()
            myConnection.Open()
            Using myCommand = New SqlCommand("select * from karyawan", myConnection)
                'myCommand.Parameters.Add(New SqlParameter("@nik", txtNik.Text))
                Using myAdapter As New SqlDataAdapter
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(ds, "dtKaryawan")
                End Using
            End Using
        End Using
        rptDataSource = New ReportDataSource("DSKaryawan", ds.Tables(0))
        f.rptView.LocalReport.DataSources.Add(rptDataSource)
        f.Show()
        f.rptView.RefreshReport()
    End Sub

    Sub ReportKaryawanByNik()
        Dim rptDataSource As ReportDataSource
        Dim f As New FrmPrintPreview
        With f.rptView.LocalReport
            .ReportPath = "D:\Tiar\SampleReport\RptKaryawan.rdlc"
            .DataSources.Clear()
        End With

        Dim ds As DataSet = New DatasetKaryawan
        Dim connectionString As String = "Server=WS020104\SQLEXPRESS;Database=Ocean;User Id=sa;Password=12345;"
        Using myConnection As SqlConnection = New SqlConnection(connectionString)
            If myConnection.State = ConnectionState.Open Then myConnection.Close()
            myConnection.Open()
            Using myCommand = New SqlCommand("select * from karyawan where nik = @nik", myConnection)
                myCommand.Parameters.Add(New SqlParameter("@nik", txtNik.Text))
                Using myAdapter As New SqlDataAdapter
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(ds, "dtKaryawan")
                End Using
            End Using
        End Using
        rptDataSource = New ReportDataSource("DSKaryawan", ds.Tables(0))
        f.rptView.LocalReport.DataSources.Add(rptDataSource)
        f.Show()
        f.rptView.RefreshReport()
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        If rdbAll.Checked = True Then
            ReportKaryawan()
        End If

        If rdbNik.Checked = True Then
            ReportKaryawanByNik()
        End If
    End Sub
End Class