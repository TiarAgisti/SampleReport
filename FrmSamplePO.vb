Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms

Public Class FrmSamplePO
    Protected myID As Long
    Protected supplierID As Integer
    Protected barangID As Integer
    Protected intBaris As Integer
    Protected intPost As Integer

    Sub AutoCompleteNamaSupplier()
        Try
            Dim conBFC As Koneksi = New Koneksi
            Dim myConn As SqlConnection = conBFC.sqlConnection
            Dim myCommand As SqlCommand = New SqlCommand("SELECT NamaSupplier FROM Supplier", myConn)
            'myConn.Open()
            Dim myReader As SqlDataReader = myCommand.ExecuteReader
            While myReader.Read
                With txtSupplier
                    .AutoCompleteCustomSource.Add(myReader(0).ToString)
                    .AutoCompleteMode = AutoCompleteMode.Suggest
                    .AutoCompleteSource = AutoCompleteSource.CustomSource
                End With
            End While
            'myReader = Nothing
            'myReader.Close()
            myConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub AutoCompleteBarang()
        Try
            Dim conBFC As Koneksi = New Koneksi
            Dim myConn As SqlConnection = conBFC.sqlConnection
            Dim myCommand As SqlCommand = New SqlCommand("Select NamaBarang From Barang", myConn)
            'myConn.Open()
            Dim myReader As SqlDataReader = myCommand.ExecuteReader
            While myReader.Read
                With txtBrg
                    .AutoCompleteCustomSource.Add(myReader(0).ToString)
                    .AutoCompleteMode = AutoCompleteMode.Suggest
                    .AutoCompleteSource = AutoCompleteSource.CustomSource
                End With
            End While
            'myReader.Close()
            myConn.Close()
            'myReader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub GridDetail()
        With dgv
            .Columns.Add(0, "Barang ID")
            .Columns.Add(1, "Barang")
            .Columns.Add(2, "Satuan")
            .Columns.Add(3, "Qty")
            .Columns.Add(4, "Harga")
            .Columns.Add(5, "Total")

            .Columns(0).Visible = False
        End With
    End Sub

    Sub AddGridDetail()
        With dgv
            .Rows.Add()
            .Item(0, intBaris).Value = barangID
            .Item(1, intBaris).Value = txtBrg.Text
            .Item(2, intBaris).Value = txtSatuan.Text
            .Item(3, intBaris).Value = txtQty.Text
            .Item(4, intBaris).Value = txtHarga.Text
            .Item(5, intBaris).Value = Val(txtHarga.Text) * Val(txtQty.Text)
        End With
        intBaris = intBaris + 1
        ClearDetail()
    End Sub

    Sub DeleteGridDetail()
        Me.dgv.Rows.RemoveAt(Me.dgv.CurrentCell.RowIndex)
        intBaris = intBaris - 1
    End Sub

    Sub ClearDetail()
        txtBrg.Clear()
        txtSatuan.Clear()
        txtQty.Clear()
        txtHarga.Clear()
    End Sub

    Public Function GeneratedAutoNumber() As Integer
        Dim id As Long = 0
        Dim urutan As Integer = 0
        Dim query As String = "Select MAX(POHeaderID) as POHeaderID From POHeader"
        Dim conBFC As Koneksi = New Koneksi
        Using myConnection As SqlConnection = conBFC.sqlConnection
            Using myCommand As SqlCommand = New SqlCommand(query, myConnection)
                Try
                    Dim myReader As SqlDataReader = myCommand.ExecuteReader
                    myReader.Read()
                    If myReader.HasRows Then
                        If IsDBNull(myReader.Item(0)) Then
                            urutan = 1
                        Else
                            urutan = myReader.Item(0) + 1
                        End If
                    End If
                    myReader.Close()
                    myCommand.Dispose()
                    myConnection.Close()
                Catch ex As Exception
                    myCommand.Dispose()
                    myConnection.Close()
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
        id = urutan
        Return id
    End Function

    Function InsertData() As Boolean
        Dim conBFC As Koneksi = New Koneksi
        myID = GeneratedAutoNumber()
        Using myConnection As SqlConnection = conBFC.sqlConnection
            Using myCommand As SqlCommand = myConnection.CreateCommand
                Using myTransaction As SqlTransaction = myConnection.BeginTransaction("Master Detail")
                    myCommand.Connection = myConnection
                    myCommand.Transaction = myTransaction
                    Dim queryList As List(Of String) = New List(Of String)
                    Dim sqlHeader = "Insert into POHeader(POHeaderID,PODate,PONo,SupplierID)Values('" & myID & "','" & Format(dtpDate.Value, "yyyy-MM-dd") & "'" &
                                    ",'" & txtPO.Text & "','" & supplierID & "')"

                    queryList.Add(sqlHeader)

                    For detail = 0 To dgv.Rows.Count - 2
                        Dim sqlDetail As String = "Insert into PODetail(POHeaderID,BarangID,Qty,Harga)Values('" & myID & "','" & dgv.Rows(detail).Cells(0).Value & "'" &
                                                    ",'" & dgv.Rows(detail).Cells(3).Value & "','" & dgv.Rows(detail).Cells(4).Value & "')"
                        queryList.Add(sqlDetail)
                    Next


                    Try
                        For Each sqlDetail In queryList
                            myCommand.CommandText = sqlDetail
                            myCommand.ExecuteNonQuery()
                        Next

                        myTransaction.Commit()
                        myConnection.Close()
                        myCommand.Dispose()
                        Return True
                    Catch ex As Exception
                        myConnection.Close()
                        myCommand.Dispose()
                        MsgBox(ex.Message)
                        Return False
                        Try
                            myTransaction.Rollback()
                        Catch ex2 As Exception
                            MsgBox(ex2.Message)
                        End Try
                    End Try
                End Using
            End Using
        End Using
    End Function

    Private Sub GetPurchaseOrderData(ByVal purchaseOrderNumber As String, ByRef dsPurchaseOrder As DataSet)
        Dim conn As Koneksi = New Koneksi
        Dim sqlPurchaseOrder As String = "select poh.*,supp.NamaSupplier,supp.Alamat from POHeader as poh" &
                                             " Inner Join Supplier as supp ON supp.SupplierID = poh.SupplierID where poh.PONo = @PONo"

        Using myConnection As SqlConnection = conn.sqlConnection
            Dim myCommand As SqlCommand = New SqlCommand(sqlPurchaseOrder, myConnection)
            Dim parameter As New SqlParameter("PONo", purchaseOrderNumber)
            myCommand.Parameters.Add(parameter)
            Dim purchaseOrderAdapter As New SqlDataAdapter(myCommand)
            purchaseOrderAdapter.Fill(dsPurchaseOrder, "POHeader")
        End Using
    End Sub

    Private Sub GetPurchaseOrderDetailData(ByVal purchaseOrderNumber As String, ByRef dsPurchaseOrderDetail As DataSet)
        Dim conn As Koneksi = New Koneksi
        Dim sqlPurchaseOrder As String = "select pod.*,poh.PONo,brg.NamaBarang,brg.Satuan from PODetail as pod" &
                                             " Inner Join POHeader as poh ON poh.POHeaderID = pod.POHeaderID" &
                                             " Inner Join Barang as brg ON brg.BarangID = pod.BarangID where poh.PONo = @PONo"
        Using myConnection As SqlConnection = conn.sqlConnection
            Dim myCommand As SqlCommand = New SqlCommand(sqlPurchaseOrder, myConnection)
            Dim parameter As New SqlParameter("PONo", purchaseOrderNumber)
            myCommand.Parameters.Add(parameter)
            Dim purchaseOrderDetailAdapter As New SqlDataAdapter(myCommand)
            purchaseOrderDetailAdapter.Fill(dsPurchaseOrderDetail, "PODetail")
        End Using
    End Sub

    Private Sub PrintPurchaseOrder()
        Dim frm As New FrmPrintPreview
        'frm.rptView.ProcessingMode = ProcessingMode.Local
        Dim localReport As LocalReport
        localReport = frm.rptView.LocalReport
        localReport.ReportPath = "D:\Tiar\SampleReport\rptPO.rdlc"

        'localReport.ReportEmbeddedResource = "ReportViewerIntro.rptPO.rdlc"
        Dim dataset As New DataSet("DsPOHeader")
        Dim purchaseOrderNumber As String = txtPO.Text

        GetPurchaseOrderData(purchaseOrderNumber, dataset)

        Dim dsPurchaseOrder As New ReportDataSource
        dsPurchaseOrder.Name = "DsPOHeader"
        dsPurchaseOrder.Value = dataset.Tables("POHeader")

        localReport.DataSources.Add(dsPurchaseOrder)

        GetPurchaseOrderDetailData(purchaseOrderNumber, dataset)
        Dim dsPurchaseOrderDetail As New ReportDataSource
        dsPurchaseOrderDetail.Name = "DsPODetail"
        dsPurchaseOrderDetail.Value = dataset.Tables("PODetail")

        localReport.DataSources.Add(dsPurchaseOrderDetail)

        frm.Show()
        frm.rptView.RefreshReport()
    End Sub
    Sub PrintOutPO()
        'Dim rptDataSource As ReportDataSource
        Dim frm As New FrmPrintPreview

        With frm.rptView.LocalReport
            .ReportPath = "D:\Tiar\SampleReport\rptPO.rdlc"
            .DataSources.Clear()
        End With


        Dim conBFC As Koneksi = New Koneksi
        Dim ds As DataSet = New SampleReport
        Using myConnection As SqlConnection = conBFC.sqlConnection
            Using myCommand = New SqlCommand("select poh.*,supp.NamaSupplier,supp.Alamat from POHeader as poh" &
                                             " Inner Join Supplier as supp ON supp.SupplierID = poh.SupplierID where poh.PONo = @PONo", myConnection)
                myCommand.Parameters.Add(New SqlParameter("@PONo", txtPO.Text))
                Using myAdapter As New SqlDataAdapter
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(ds, "POHeaderDT")
                End Using
                myCommand.Dispose()
            End Using
            myConnection.Close()
        End Using

        Dim ds2 As DataSet = New SampleReport
        Using myConnection2 As SqlConnection = conBFC.sqlConnection
            Using myCommand2 = New SqlCommand("select pod.*,poh.PONo,brg.NamaBarang,brg.Satuan from PODetail as pod" &
                                             " Inner Join POHeader as poh ON poh.POHeaderID = pod.POHeaderID" &
                                             " Inner Join Barang as brg ON brg.BarangID = pod.BarangID where poh.PONo = @PONo2", myConnection2)
                myCommand2.Parameters.Add(New SqlParameter("@PONo2", txtPO.Text))
                Using myAdapter2 As New SqlDataAdapter
                    myAdapter2.SelectCommand = myCommand2
                    myAdapter2.Fill(ds2, "PODetailDT")
                End Using
                myCommand2.Dispose()
            End Using
            myConnection2.Close()
        End Using

        Dim poDetailDT As ReportDataSource = New ReportDataSource("DsPODetail", ds2.Tables(0))
        Dim poHeaderDT As ReportDataSource = New ReportDataSource("DsPOHeader", ds.Tables(0))
        frm.rptView.LocalReport.DataSources.Add(poHeaderDT)
        frm.rptView.LocalReport.DataSources.Add(poDetailDT)
        frm.Show()
        frm.rptView.Refresh()
    End Sub

    Private Sub FrmSamplePO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AutoCompleteNamaSupplier()
        AutoCompleteBarang()
        GridDetail()
    End Sub

    Private Sub txtSupplier_Validated(sender As Object, e As EventArgs) Handles txtSupplier.Validated
        If txtSupplier.Text = String.Empty Then
            txtSupplier.Text = ""
        Else
            Try
                Dim conBFC As Koneksi = New Koneksi
                Dim myConn As SqlConnection = conBFC.sqlConnection
                Dim myCommand As SqlCommand = New SqlCommand("SELECT SupplierID, Alamat FROM Supplier Where NamaSupplier = '" & txtSupplier.Text & "'", myConn)
                Dim myReader As SqlDataReader = myCommand.ExecuteReader
                While myReader.Read
                    supplierID = myReader(0).ToString
                    txtAlamat.Text = myReader(1).ToString
                End While
                'myReader.Close()
                myConn.Close()
                'AutoCompleteBarang()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub txtBrg_Validated(sender As Object, e As EventArgs) Handles txtBrg.Validated
        If txtBrg.Text = String.Empty Then
            txtBrg.Text = ""
        Else
            Try
                Dim conBFC As Koneksi = New Koneksi
                Dim myConn As SqlConnection = conBFC.sqlConnection
                Dim myCommand As SqlCommand = New SqlCommand("Select BarangID,NamaBarang,Satuan,Keterangan From Barang Where NamaBarang = '" & txtBrg.Text & "'", myConn)
                Dim myReader As SqlDataReader = myCommand.ExecuteReader
                While myReader.Read
                    barangID = myReader(0).ToString
                    txtSatuan.Text = myReader(2).ToString
                End While
                'myReader.Close()
                myConn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        AddGridDetail()
    End Sub

    Private Sub dgv_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgv.RowStateChanged
        intPost = e.Row.Index
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        DeleteGridDetail()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If InsertData() = True Then
            MsgBox("Data berhasil disimpan")
        End If
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            'PrintOutPO()
            PrintPurchaseOrder()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class