<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAttendantMain
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
        Me.btnShowFutureFlights = New System.Windows.Forms.Button()
        Me.btnShowPastFlights = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(175, 92)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(86, 23)
        Me.btnExit.TabIndex = 13
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnShowFutureFlights
        '
        Me.btnShowFutureFlights.Location = New System.Drawing.Point(312, 35)
        Me.btnShowFutureFlights.Name = "btnShowFutureFlights"
        Me.btnShowFutureFlights.Size = New System.Drawing.Size(86, 35)
        Me.btnShowFutureFlights.TabIndex = 12
        Me.btnShowFutureFlights.Text = "Show Future Flights"
        Me.btnShowFutureFlights.UseVisualStyleBackColor = True
        '
        'btnShowPastFlights
        '
        Me.btnShowPastFlights.Location = New System.Drawing.Point(175, 34)
        Me.btnShowPastFlights.Name = "btnShowPastFlights"
        Me.btnShowPastFlights.Size = New System.Drawing.Size(86, 36)
        Me.btnShowPastFlights.TabIndex = 11
        Me.btnShowPastFlights.Text = "Show Past Flights"
        Me.btnShowPastFlights.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(40, 36)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(86, 36)
        Me.btnUpdate.TabIndex = 10
        Me.btnUpdate.Text = "Update Info"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'frmAttendantMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(446, 150)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnShowFutureFlights)
        Me.Controls.Add(Me.btnShowPastFlights)
        Me.Controls.Add(Me.btnUpdate)
        Me.Name = "frmAttendantMain"
        Me.Text = "Attendant Main Menu"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnExit As Button
    Friend WithEvents btnShowFutureFlights As Button
    Friend WithEvents btnShowPastFlights As Button
    Friend WithEvents btnUpdate As Button
End Class
