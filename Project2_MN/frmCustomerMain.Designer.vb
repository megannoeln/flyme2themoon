<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomerMain
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
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnBookFlight = New System.Windows.Forms.Button()
        Me.btnShowPastFlights = New System.Windows.Forms.Button()
        Me.btnShowFutureFlights = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(31, 47)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(86, 36)
        Me.btnUpdate.TabIndex = 0
        Me.btnUpdate.Text = "Update Info"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnBookFlight
        '
        Me.btnBookFlight.Location = New System.Drawing.Point(141, 47)
        Me.btnBookFlight.Name = "btnBookFlight"
        Me.btnBookFlight.Size = New System.Drawing.Size(86, 36)
        Me.btnBookFlight.TabIndex = 1
        Me.btnBookFlight.Text = "Book Flight"
        Me.btnBookFlight.UseVisualStyleBackColor = True
        '
        'btnShowPastFlights
        '
        Me.btnShowPastFlights.Location = New System.Drawing.Point(254, 47)
        Me.btnShowPastFlights.Name = "btnShowPastFlights"
        Me.btnShowPastFlights.Size = New System.Drawing.Size(86, 36)
        Me.btnShowPastFlights.TabIndex = 2
        Me.btnShowPastFlights.Text = "Show Past Flights"
        Me.btnShowPastFlights.UseVisualStyleBackColor = True
        '
        'btnShowFutureFlights
        '
        Me.btnShowFutureFlights.Location = New System.Drawing.Point(363, 47)
        Me.btnShowFutureFlights.Name = "btnShowFutureFlights"
        Me.btnShowFutureFlights.Size = New System.Drawing.Size(86, 35)
        Me.btnShowFutureFlights.TabIndex = 3
        Me.btnShowFutureFlights.Text = "Show Future Flights"
        Me.btnShowFutureFlights.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(197, 98)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmCustomerMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(485, 133)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnShowFutureFlights)
        Me.Controls.Add(Me.btnShowPastFlights)
        Me.Controls.Add(Me.btnBookFlight)
        Me.Controls.Add(Me.btnUpdate)
        Me.Name = "frmCustomerMain"
        Me.Text = "Customer Main Menu"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnBookFlight As Button
    Friend WithEvents btnShowPastFlights As Button
    Friend WithEvents btnShowFutureFlights As Button
    Friend WithEvents btnExit As Button
End Class
