<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNik = New System.Windows.Forms.TextBox()
        Me.txtNama = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbJk = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpTglLahir = New System.Windows.Forms.DateTimePicker()
        Me.btnTambah = New System.Windows.Forms.Button()
        Me.btnHapus = New System.Windows.Forms.Button()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.collNik = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.collNama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.collJk = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.collTglLahir = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnPrev = New System.Windows.Forms.Button()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nik"
        '
        'txtNik
        '
        Me.txtNik.Location = New System.Drawing.Point(88, 25)
        Me.txtNik.Name = "txtNik"
        Me.txtNik.Size = New System.Drawing.Size(209, 20)
        Me.txtNik.TabIndex = 1
        '
        'txtNama
        '
        Me.txtNama.Location = New System.Drawing.Point(88, 51)
        Me.txtNama.Name = "txtNama"
        Me.txtNama.Size = New System.Drawing.Size(209, 20)
        Me.txtNama.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nama"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Jenis Kelamin"
        '
        'cmbJk
        '
        Me.cmbJk.FormattingEnabled = True
        Me.cmbJk.Items.AddRange(New Object() {"Pria", "Wanita"})
        Me.cmbJk.Location = New System.Drawing.Point(88, 77)
        Me.cmbJk.Name = "cmbJk"
        Me.cmbJk.Size = New System.Drawing.Size(121, 21)
        Me.cmbJk.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 110)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Tanggal Lahir"
        '
        'dtpTglLahir
        '
        Me.dtpTglLahir.Location = New System.Drawing.Point(88, 104)
        Me.dtpTglLahir.Name = "dtpTglLahir"
        Me.dtpTglLahir.Size = New System.Drawing.Size(209, 20)
        Me.dtpTglLahir.TabIndex = 7
        '
        'btnTambah
        '
        Me.btnTambah.Location = New System.Drawing.Point(13, 154)
        Me.btnTambah.Name = "btnTambah"
        Me.btnTambah.Size = New System.Drawing.Size(157, 23)
        Me.btnTambah.TabIndex = 8
        Me.btnTambah.Text = "Tambahkan dalam daftar"
        Me.btnTambah.UseVisualStyleBackColor = True
        '
        'btnHapus
        '
        Me.btnHapus.Location = New System.Drawing.Point(176, 154)
        Me.btnHapus.Name = "btnHapus"
        Me.btnHapus.Size = New System.Drawing.Size(157, 23)
        Me.btnHapus.TabIndex = 9
        Me.btnHapus.Text = "Hapus dari daftar"
        Me.btnHapus.UseVisualStyleBackColor = True
        '
        'dgv
        '
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.collNik, Me.collNama, Me.collJk, Me.collTglLahir})
        Me.dgv.Location = New System.Drawing.Point(12, 200)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(514, 201)
        Me.dgv.TabIndex = 10
        '
        'collNik
        '
        Me.collNik.HeaderText = "NIK"
        Me.collNik.Name = "collNik"
        Me.collNik.ReadOnly = True
        '
        'collNama
        '
        Me.collNama.HeaderText = "Nama"
        Me.collNama.Name = "collNama"
        Me.collNama.ReadOnly = True
        '
        'collJk
        '
        Me.collJk.HeaderText = "Jenis Kelamin"
        Me.collJk.Name = "collJk"
        Me.collJk.ReadOnly = True
        '
        'collTglLahir
        '
        Me.collTglLahir.HeaderText = "Tanggal Lahir"
        Me.collTglLahir.Name = "collTglLahir"
        Me.collTglLahir.ReadOnly = True
        '
        'btnPrev
        '
        Me.btnPrev.Location = New System.Drawing.Point(369, 407)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(157, 23)
        Me.btnPrev.TabIndex = 11
        Me.btnPrev.Text = "Print Preview"
        Me.btnPrev.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(543, 441)
        Me.Controls.Add(Me.btnPrev)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.btnHapus)
        Me.Controls.Add(Me.btnTambah)
        Me.Controls.Add(Me.dtpTglLahir)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbJk)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNama)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNik)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtNik As TextBox
    Friend WithEvents txtNama As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbJk As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents dtpTglLahir As DateTimePicker
    Friend WithEvents btnTambah As Button
    Friend WithEvents btnHapus As Button
    Friend WithEvents dgv As DataGridView
    Friend WithEvents collNik As DataGridViewTextBoxColumn
    Friend WithEvents collNama As DataGridViewTextBoxColumn
    Friend WithEvents collJk As DataGridViewTextBoxColumn
    Friend WithEvents collTglLahir As DataGridViewTextBoxColumn
    Friend WithEvents btnPrev As Button
End Class
