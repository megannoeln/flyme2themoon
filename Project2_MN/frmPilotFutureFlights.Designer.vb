<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPilotFutureFlights
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
        Me.lstPilotFutureFlights = New System.Windows.Forms.ListBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lstPilotFutureFlights
        '
        Me.lstPilotFutureFlights.FormattingEnabled = True
        Me.lstPilotFutureFlights.Location = New System.Drawing.Point(43, 34)
        Me.lstPilotFutureFlights.Name = "lstPilotFutureFlights"
        Me.lstPilotFutureFlights.Size = New System.Drawing.Size(319, 264)
        Me.lstPilotFutureFlights.TabIndex = 0
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(164, 332)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 37)
        Me.btnExit.TabIndex = 1
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmPilotFutureFlights
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(408, 404)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.lstPilotFutureFlights)
        Me.Name = "frmPilotFutureFlights"
        Me.Text = "Pilot Scheduled Flight Information"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lstPilotFutureFlights As ListBox
    Friend WithEvents btnExit As Button
End Class
