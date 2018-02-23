<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MachCuring
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.lbMach = New System.Windows.Forms.Label()
        Me.SGP = New System.Windows.Forms.Button()
        Me.bw = New System.ComponentModel.BackgroundWorker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lv = New System.Windows.Forms.ListView()
        Me.btStatus = New System.Windows.Forms.Button()
        Me.pb = New System.Windows.Forms.ProgressBar()
        Me.SuspendLayout()
        '
        'lbMach
        '
        Me.lbMach.AutoSize = True
        Me.lbMach.Font = New System.Drawing.Font("Verdana", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMach.Location = New System.Drawing.Point(83, 5)
        Me.lbMach.Name = "lbMach"
        Me.lbMach.Size = New System.Drawing.Size(35, 16)
        Me.lbMach.TabIndex = 0
        Me.lbMach.Text = "101"
        '
        'SGP
        '
        Me.SGP.BackColor = System.Drawing.Color.Gray
        Me.SGP.Enabled = False
        Me.SGP.Font = New System.Drawing.Font("Verdana", 5.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SGP.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.SGP.Location = New System.Drawing.Point(128, 1)
        Me.SGP.Name = "SGP"
        Me.SGP.Size = New System.Drawing.Size(29, 22)
        Me.SGP.TabIndex = 2
        Me.SGP.Text = "GP"
        Me.SGP.UseVisualStyleBackColor = False
        '
        'bw
        '
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Machine :"
        '
        'lv
        '
        Me.lv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lv.Location = New System.Drawing.Point(9, 37)
        Me.lv.Name = "lv"
        Me.lv.Size = New System.Drawing.Size(173, 40)
        Me.lv.TabIndex = 5
        Me.lv.UseCompatibleStateImageBehavior = False
        Me.lv.View = System.Windows.Forms.View.SmallIcon
        '
        'btStatus
        '
        Me.btStatus.BackColor = System.Drawing.Color.Transparent
        Me.btStatus.BackgroundImage = Global.CuringRecorder.My.Resources.Resources.player_stop
        Me.btStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btStatus.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btStatus.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.btStatus.Location = New System.Drawing.Point(160, 1)
        Me.btStatus.Name = "btStatus"
        Me.btStatus.Size = New System.Drawing.Size(22, 22)
        Me.btStatus.TabIndex = 6
        Me.btStatus.UseVisualStyleBackColor = False
        '
        'pb
        '
        Me.pb.Location = New System.Drawing.Point(9, 25)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(173, 10)
        Me.pb.TabIndex = 7
        '
        'MachCuring
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.pb)
        Me.Controls.Add(Me.btStatus)
        Me.Controls.Add(Me.lv)
        Me.Controls.Add(Me.lbMach)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SGP)
        Me.Name = "MachCuring"
        Me.Size = New System.Drawing.Size(190, 85)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbMach As System.Windows.Forms.Label
    Friend WithEvents SGP As System.Windows.Forms.Button
    Friend WithEvents bw As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lv As System.Windows.Forms.ListView
    Friend WithEvents btStatus As System.Windows.Forms.Button
    Friend WithEvents pb As System.Windows.Forms.ProgressBar

End Class
