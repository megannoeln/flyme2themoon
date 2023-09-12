<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAttendantFutureFlights
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
        Me.lstFutureFlights = New System.Windows.Forms.ListBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lstFutureFlights
        '
        Me.lstFutureFlights.FormattingEnabled = True
        Me.lstFutureFlights.Location = New System.Drawing.Point(65, 27)
        Me.lstFutureFlights.Name = "lstFutureFlights"
        Me.lstFutureFlights.Size = New System.Drawing.Size(270, 212)
        Me.lstFutureFlights.TabIndex = 0
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(167, 260)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 34)
        Me.btnExit.TabIndex = 1
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmAttendantFutureFlights
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(389, 319)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.lstFutureFlights)
        Me.Name = "frmAttendantFutureFlights"
        Me.Text = "Attendant Scheduled Flights Information"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lstFutureFlights As ListBox
    Friend WithEvents btnExit As Button
End Class
