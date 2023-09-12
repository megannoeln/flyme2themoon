<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStatistics
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTotalNumCustomers = New System.Windows.Forms.Label()
        Me.lblAvgMiles = New System.Windows.Forms.Label()
        Me.lblTotalNumFlights = New System.Windows.Forms.Label()
        Me.lstPilotStats = New System.Windows.Forms.ListBox()
        Me.lstAttendantStats = New System.Windows.Forms.ListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(138, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Total Number of Customers:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(291, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Total Number of Flights:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(547, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Average Miles Flown:"
        '
        'lblTotalNumCustomers
        '
        Me.lblTotalNumCustomers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalNumCustomers.Location = New System.Drawing.Point(170, 37)
        Me.lblTotalNumCustomers.Name = "lblTotalNumCustomers"
        Me.lblTotalNumCustomers.Size = New System.Drawing.Size(100, 23)
        Me.lblTotalNumCustomers.TabIndex = 3
        '
        'lblAvgMiles
        '
        Me.lblAvgMiles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAvgMiles.Location = New System.Drawing.Point(661, 37)
        Me.lblAvgMiles.Name = "lblAvgMiles"
        Me.lblAvgMiles.Size = New System.Drawing.Size(100, 23)
        Me.lblAvgMiles.TabIndex = 4
        '
        'lblTotalNumFlights
        '
        Me.lblTotalNumFlights.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalNumFlights.Location = New System.Drawing.Point(416, 37)
        Me.lblTotalNumFlights.Name = "lblTotalNumFlights"
        Me.lblTotalNumFlights.Size = New System.Drawing.Size(100, 23)
        Me.lblTotalNumFlights.TabIndex = 5
        '
        'lstPilotStats
        '
        Me.lstPilotStats.FormattingEnabled = True
        Me.lstPilotStats.Location = New System.Drawing.Point(55, 118)
        Me.lstPilotStats.Name = "lstPilotStats"
        Me.lstPilotStats.Size = New System.Drawing.Size(302, 251)
        Me.lstPilotStats.TabIndex = 6
        '
        'lstAttendantStats
        '
        Me.lstAttendantStats.FormattingEnabled = True
        Me.lstAttendantStats.Location = New System.Drawing.Point(459, 118)
        Me.lstAttendantStats.Name = "lstAttendantStats"
        Me.lstAttendantStats.Size = New System.Drawing.Size(302, 251)
        Me.lstAttendantStats.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(136, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(134, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Total Miles Flown Per Pilot:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(525, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(160, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Total Miles Flown Per Attendant:"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(359, 395)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(97, 39)
        Me.btnExit.TabIndex = 10
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmStatistics
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(812, 455)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lstAttendantStats)
        Me.Controls.Add(Me.lstPilotStats)
        Me.Controls.Add(Me.lblTotalNumFlights)
        Me.Controls.Add(Me.lblAvgMiles)
        Me.Controls.Add(Me.lblTotalNumCustomers)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmStatistics"
        Me.Text = "FlyMe2theMoon Statistics"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblTotalNumCustomers As Label
    Friend WithEvents lblAvgMiles As Label
    Friend WithEvents lblTotalNumFlights As Label
    Friend WithEvents lstPilotStats As ListBox
    Friend WithEvents lstAttendantStats As ListBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnExit As Button
End Class
