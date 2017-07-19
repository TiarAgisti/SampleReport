Imports Microsoft.Reporting.WinForms
Public Class Form1
    Function CheckNikInList(nik As Integer) As Integer
        Dim value As Integer
        If dgv.Rows.Count > 0 Then
            For i = 0 To dgv.Rows.Count - 1
                If dgv.Rows.Item(i).Cells(0).Value = nik Then
                    value = 1
                End If
            Next
        End If
        Return value
    End Function

    Sub ClearText()
        txtNik.Clear()
        txtNama.Clear()
        cmbJk.Text = ""
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        If Not txtNik.Text = String.Empty And CheckNikInList(txtNik.Text) = 0 Then
            Dim data As String()
            data = New String() {txtNik.Text, txtNama.Text, cmbJk.Text, dtpTglLahir.Value}
            dgv.Rows.Add(data)
            ClearText()
        Else
            MsgBox("Periksa kembali data yg diinputkan", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        If dgv.Rows.Count > 0 And dgv.SelectedRows.Count > 0 Then
            dgv.Rows.Remove(dgv.CurrentRow)
        End If
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        Dim rptDataSource As ReportDataSource
        Dim prev As New FrmPrintPreview
        With prev.rptView.LocalReport
            .ReportPath = "D:\Tiar\SampleReport\RptKaryawan.rdlc"
            .DataSources.Clear()
        End With

        Dim ds As DataSet = New DatasetKaryawan
        Dim dt As DataTable
        dt = ds.Tables("dtKaryawan")
        If dgv.Rows.Count > 0 Then
            dt.Rows.Clear()
            For i = 0 To dgv.Rows.Count - 1
                dt.Rows.Add(dgv.Rows(i).Cells(0).Value, dgv.Rows(i).Cells(1).Value, dgv.Rows(i).Cells(2).Value, dgv.Rows(i).Cells(3).Value)
            Next
        End If

        rptDataSource = New ReportDataSource("DSKaryawan", ds.Tables(0))
        prev.rptView.LocalReport.DataSources.Add(rptDataSource)
        prev.Show()
        prev.rptView.RefreshReport()
    End Sub
End Class
