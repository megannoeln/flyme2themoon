<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageAttendants
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
        Me.btnAddAttendantFlight = New System.Windows.Forms.Button()
        Me.btnDeleteAttendant = New System.Windows.Forms.Button()
        Me.btnAddAttendant = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(215, 108)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(86, 32)
        Me.btnExit.TabIndex = 7
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnAddAttendantFlight
        '
        Me.btnAddAttendantFlight.Location = New System.Drawing.Point(357, 43)
        Me.btnAddAttendantFlight.Name = "btnAddAttendantFlight"
        Me.btnAddAttendantFlight.Size = New System.Drawing.Size(115, 39)
        Me.btnAddAttendantFlight.TabIndex = 6
        Me.btnAddAttendantFlight.Text = "Add Attendant to Flight"
        Me.btnAddAttendantFlight.UseVisualStyleBackColor = True
        '
        'btnDeleteAttendant
        '
        Me.btnDeleteAttendant.Location = New System.Drawing.Point(202, 43)
        Me.btnDeleteAttendant.Name = "btnDeleteAttendant"
        Me.btnDeleteAttendant.Size = New System.Drawing.Size(115, 39)
        Me.btnDeleteAttendant.TabIndex = 5
        Me.btnDeleteAttendant.Text = "Delete Attendant"
        Me.btnDeleteAttendant.UseVisualStyleBackColor = True
        '
        'btnAddAttendant
        '
        Me.btnAddAttendant.Location = New System.Drawing.Point(45, 43)
        Me.btnAddAttendant.Name = "btnAddAttendant"
        Me.btnAddAttendant.Size = New System.Drawing.Size(115, 39)
        Me.btnAddAttendant.TabIndex = 4
        Me.btnAddAttendant.Text = "Add Attendant"
        Me.btnAddAttendant.UseVisualStyleBackColor = True
        '
        'frmManageAttendants
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(528, 179)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnAddAttendantFlight)
        Me.Controls.Add(Me.btnDeleteAttendant)
        Me.Controls.Add(Me.btnAddAttendant)
        Me.Name = "frmManageAttendants"
        Me.Text = "Attendant Management Menu"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnExit As Button
    Friend WithEvents btnAddAttendantFlight As Button
    Friend WithEvents btnDeleteAttendant As Button
    Friend WithEvents btnAddAttendant As Button
End Class
