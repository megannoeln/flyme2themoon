<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomerBookFlight
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
        Me.cboFutureFlights = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSeatNumber = New System.Windows.Forms.TextBox()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.radReservedSeat = New System.Windows.Forms.RadioButton()
        Me.radDesignatedSeat = New System.Windows.Forms.RadioButton()
        Me.lblReservedSeat = New System.Windows.Forms.Label()
        Me.lblDesignatedSeat = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cboFutureFlights
        '
        Me.cboFutureFlights.FormattingEnabled = True
        Me.cboFutureFlights.Location = New System.Drawing.Point(147, 31)
        Me.cboFutureFlights.Name = "cboFutureFlights"
        Me.cboFutureFlights.Size = New System.Drawing.Size(146, 21)
        Me.cboFutureFlights.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Choose Flight Date:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(40, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Seat Number:"
        '
        'txtSeatNumber
        '
        Me.txtSeatNumber.Location = New System.Drawing.Point(147, 83)
        Me.txtSeatNumber.Name = "txtSeatNumber"
        Me.txtSeatNumber.Size = New System.Drawing.Size(100, 20)
        Me.txtSeatNumber.TabIndex = 3
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(55, 208)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(75, 23)
        Me.btnSubmit.TabIndex = 4
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(218, 208)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 5
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'radReservedSeat
        '
        Me.radReservedSeat.AutoSize = True
        Me.radReservedSeat.Location = New System.Drawing.Point(40, 126)
        Me.radReservedSeat.Name = "radReservedSeat"
        Me.radReservedSeat.Size = New System.Drawing.Size(96, 17)
        Me.radReservedSeat.TabIndex = 6
        Me.radReservedSeat.Text = "Reserved Seat"
        Me.radReservedSeat.UseVisualStyleBackColor = True
        Me.radReservedSeat.Visible = False
        '
        'radDesignatedSeat
        '
        Me.radDesignatedSeat.AutoSize = True
        Me.radDesignatedSeat.Checked = True
        Me.radDesignatedSeat.Location = New System.Drawing.Point(40, 162)
        Me.radDesignatedSeat.Name = "radDesignatedSeat"
        Me.radDesignatedSeat.Size = New System.Drawing.Size(137, 17)
        Me.radDesignatedSeat.TabIndex = 7
        Me.radDesignatedSeat.TabStop = True
        Me.radDesignatedSeat.Text = "Designated at Check-In"
        Me.radDesignatedSeat.UseVisualStyleBackColor = True
        Me.radDesignatedSeat.Visible = False
        '
        'lblReservedSeat
        '
        Me.lblReservedSeat.Location = New System.Drawing.Point(190, 126)
        Me.lblReservedSeat.Name = "lblReservedSeat"
        Me.lblReservedSeat.Size = New System.Drawing.Size(100, 23)
        Me.lblReservedSeat.TabIndex = 8
        '
        'lblDesignatedSeat
        '
        Me.lblDesignatedSeat.Location = New System.Drawing.Point(193, 162)
        Me.lblDesignatedSeat.Name = "lblDesignatedSeat"
        Me.lblDesignatedSeat.Size = New System.Drawing.Size(100, 23)
        Me.lblDesignatedSeat.TabIndex = 9
        '
        'frmCustomerBookFlight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(374, 243)
        Me.Controls.Add(Me.lblDesignatedSeat)
        Me.Controls.Add(Me.lblReservedSeat)
        Me.Controls.Add(Me.radDesignatedSeat)
        Me.Controls.Add(Me.radReservedSeat)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.txtSeatNumber)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboFutureFlights)
        Me.Name = "frmCustomerBookFlight"
        Me.Text = "Book Flight"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboFutureFlights As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSeatNumber As TextBox
    Friend WithEvents btnSubmit As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents radReservedSeat As RadioButton
    Friend WithEvents radDesignatedSeat As RadioButton
    Friend WithEvents lblReservedSeat As Label
    Friend WithEvents lblDesignatedSeat As Label
End Class
