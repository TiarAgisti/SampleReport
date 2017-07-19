<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSampleReportUsingTable
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
        Me.rdbAll = New System.Windows.Forms.RadioButton()
        Me.rdbNik = New System.Windows.Forms.RadioButton()
        Me.btnPrev = New System.Windows.Forms.Button()
        Me.txtNik = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'rdbAll
        '
        Me.rdbAll.AutoSize = True
        Me.rdbAll.Location = New System.Drawing.Point(12, 12)
        Me.rdbAll.Name = "rdbAll"
        Me.rdbAll.Size = New System.Drawing.Size(71, 17)
        Me.rdbAll.TabIndex = 0
        Me.rdbAll.TabStop = True
        Me.rdbAll.Text = "Report All"
        Me.rdbAll.UseVisualStyleBackColor = True
        '
        'rdbNik
        '
        Me.rdbNik.AutoSize = True
        Me.rdbNik.Location = New System.Drawing.Point(12, 45)
        Me.rdbNik.Name = "rdbNik"
        Me.rdbNik.Size = New System.Drawing.Size(91, 17)
        Me.rdbNik.TabIndex = 1
        Me.rdbNik.TabStop = True
        Me.rdbNik.Text = "Report By Nik"
        Me.rdbNik.UseVisualStyleBackColor = True
        '
        'btnPrev
        '
        Me.btnPrev.Location = New System.Drawing.Point(12, 80)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(91, 23)
        Me.btnPrev.TabIndex = 2
        Me.btnPrev.Text = "Print Preview"
        Me.btnPrev.UseVisualStyleBackColor = True
        '
        'txtNik
        '
        Me.txtNik.Location = New System.Drawing.Point(109, 45)
        Me.txtNik.Name = "txtNik"
        Me.txtNik.Size = New System.Drawing.Size(198, 20)
        Me.txtNik.TabIndex = 3
        '
        'FrmSampleReportUsingTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(407, 126)
        Me.Controls.Add(Me.txtNik)
        Me.Controls.Add(Me.btnPrev)
        Me.Controls.Add(Me.rdbNik)
        Me.Controls.Add(Me.rdbAll)
        Me.Name = "FrmSampleReportUsingTable"
        Me.Text = "Sample Report Using Table"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents rdbAll As RadioButton
    Friend WithEvents rdbNik As RadioButton
    Friend WithEvents btnPrev As Button
    Friend WithEvents txtNik As TextBox
End Class
