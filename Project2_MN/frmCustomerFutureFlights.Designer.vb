<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomerFutureFlights
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
        Me.btnExit = New System.Windows.Forms.Button()
        Me.lblFutureMiles = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lstFutureFlights = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(145, 312)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 38)
        Me.btnExit.TabIndex = 7
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'lblFutureMiles
        '
        Me.lblFutureMiles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFutureMiles.Location = New System.Drawing.Point(188, 30)
        Me.lblFutureMiles.Name = "lblFutureMiles"
        Me.lblFutureMiles.Size = New System.Drawing.Size(100, 23)
        Me.lblFutureMiles.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(66, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Total Miles Planned:"
        '
        'lstFutureFlights
        '
        Me.lstFutureFlights.FormattingEnabled = True
        Me.lstFutureFlights.Location = New System.Drawing.Point(38, 78)
        Me.lstFutureFlights.Name = "lstFutureFlights"
        Me.lstFutureFlights.Size = New System.Drawing.Size(302, 212)
        Me.lstFutureFlights.TabIndex = 4
        '
        'frmCustomerFutureFlights
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(379, 375)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.lblFutureMiles)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lstFutureFlights)
        Me.Name = "frmCustomerFutureFlights"
        Me.Text = "Customer Planned Flights Information"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnExit As Button
    Friend WithEvents lblFutureMiles As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lstFutureFlights As ListBox
End Class
