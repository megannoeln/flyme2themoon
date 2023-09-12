<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreateFlight
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtFlightDate = New System.Windows.Forms.DateTimePicker()
        Me.txtFlightNumber = New System.Windows.Forms.TextBox()
        Me.txtFlightMiles = New System.Windows.Forms.TextBox()
        Me.cboDepartingAirport = New System.Windows.Forms.ComboBox()
        Me.cboArrivalAirport = New System.Windows.Forms.ComboBox()
        Me.cboPlaneID = New System.Windows.Forms.ComboBox()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.cboDepartureTime = New System.Windows.Forms.ComboBox()
        Me.cboArrivalTime = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(40, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Flight Date:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(39, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Flight Number:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(39, 137)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Time of Departure:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(40, 178)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Time of Landing:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(40, 222)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Departing Airport Code:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(39, 263)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Arrival Airport Code:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(39, 310)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Flight Miles:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(39, 348)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Plane ID:"
        '
        'dtFlightDate
        '
        Me.dtFlightDate.Location = New System.Drawing.Point(187, 42)
        Me.dtFlightDate.Name = "dtFlightDate"
        Me.dtFlightDate.Size = New System.Drawing.Size(200, 20)
        Me.dtFlightDate.TabIndex = 8
        '
        'txtFlightNumber
        '
        Me.txtFlightNumber.Location = New System.Drawing.Point(187, 86)
        Me.txtFlightNumber.Name = "txtFlightNumber"
        Me.txtFlightNumber.Size = New System.Drawing.Size(100, 20)
        Me.txtFlightNumber.TabIndex = 9
        '
        'txtFlightMiles
        '
        Me.txtFlightMiles.Location = New System.Drawing.Point(187, 302)
        Me.txtFlightMiles.Name = "txtFlightMiles"
        Me.txtFlightMiles.Size = New System.Drawing.Size(100, 20)
        Me.txtFlightMiles.TabIndex = 12
        '
        'cboDepartingAirport
        '
        Me.cboDepartingAirport.FormattingEnabled = True
        Me.cboDepartingAirport.Location = New System.Drawing.Point(187, 222)
        Me.cboDepartingAirport.Name = "cboDepartingAirport"
        Me.cboDepartingAirport.Size = New System.Drawing.Size(121, 21)
        Me.cboDepartingAirport.TabIndex = 13
        '
        'cboArrivalAirport
        '
        Me.cboArrivalAirport.FormattingEnabled = True
        Me.cboArrivalAirport.Location = New System.Drawing.Point(187, 254)
        Me.cboArrivalAirport.Name = "cboArrivalAirport"
        Me.cboArrivalAirport.Size = New System.Drawing.Size(121, 21)
        Me.cboArrivalAirport.TabIndex = 14
        '
        'cboPlaneID
        '
        Me.cboPlaneID.FormattingEnabled = True
        Me.cboPlaneID.Location = New System.Drawing.Point(187, 339)
        Me.cboPlaneID.Name = "cboPlaneID"
        Me.cboPlaneID.Size = New System.Drawing.Size(121, 21)
        Me.cboPlaneID.TabIndex = 15
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(82, 401)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(75, 23)
        Me.btnSubmit.TabIndex = 16
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(250, 401)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 17
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'cboDepartureTime
        '
        Me.cboDepartureTime.FormattingEnabled = True
        Me.cboDepartureTime.Items.AddRange(New Object() {"01:00:00", "02:00:00", "03:00:00", "04:00:00", "05:00:00", "06:00:00", "07:00:00", "08:00:00", "09:00:00", "10:00:00", "11:00:00", "12:00:00", "13:00:00", "14:00:00", "15:00:00", "16:00:00", "17:00:00", "18:00:00", "19:00:00", "20:00:00", "21:00:00", "22:00:00", "23:00:00", "24:00:00"})
        Me.cboDepartureTime.Location = New System.Drawing.Point(187, 128)
        Me.cboDepartureTime.Name = "cboDepartureTime"
        Me.cboDepartureTime.Size = New System.Drawing.Size(121, 21)
        Me.cboDepartureTime.TabIndex = 18
        '
        'cboArrivalTime
        '
        Me.cboArrivalTime.FormattingEnabled = True
        Me.cboArrivalTime.Items.AddRange(New Object() {"01:00:00", "02:00:00", "03:00:00", "04:00:00", "05:00:00", "06:00:00", "07:00:00", "08:00:00", "09:00:00", "10:00:00", "11:00:00", "12:00:00", "13:00:00", "14:00:00", "15:00:00", "16:00:00", "17:00:00", "18:00:00", "19:00:00", "20:00:00", "21:00:00", "22:00:00", "23:00:00", "24:00:00"})
        Me.cboArrivalTime.Location = New System.Drawing.Point(187, 169)
        Me.cboArrivalTime.Name = "cboArrivalTime"
        Me.cboArrivalTime.Size = New System.Drawing.Size(121, 21)
        Me.cboArrivalTime.TabIndex = 19
        '
        'frmCreateFlight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(424, 450)
        Me.Controls.Add(Me.cboArrivalTime)
        Me.Controls.Add(Me.cboDepartureTime)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.cboPlaneID)
        Me.Controls.Add(Me.cboArrivalAirport)
        Me.Controls.Add(Me.cboDepartingAirport)
        Me.Controls.Add(Me.txtFlightMiles)
        Me.Controls.Add(Me.txtFlightNumber)
        Me.Controls.Add(Me.dtFlightDate)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmCreateFlight"
        Me.Text = "Create Future Flight"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents dtFlightDate As DateTimePicker
    Friend WithEvents txtFlightNumber As TextBox
    Friend WithEvents txtFlightMiles As TextBox
    Friend WithEvents cboDepartingAirport As ComboBox
    Friend WithEvents cboArrivalAirport As ComboBox
    Friend WithEvents cboPlaneID As ComboBox
    Friend WithEvents btnSubmit As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents cboDepartureTime As ComboBox
    Friend WithEvents cboArrivalTime As ComboBox
End Class
