<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManagePilots
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
        Me.btnAddPilot = New System.Windows.Forms.Button()
        Me.btnDeletePilot = New System.Windows.Forms.Button()
        Me.btnAddPilotFlight = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnAddPilot
        '
        Me.btnAddPilot.Location = New System.Drawing.Point(41, 38)
        Me.btnAddPilot.Name = "btnAddPilot"
        Me.btnAddPilot.Size = New System.Drawing.Size(115, 32)
        Me.btnAddPilot.TabIndex = 0
        Me.btnAddPilot.Text = "Add Pilot"
        Me.btnAddPilot.UseVisualStyleBackColor = True
        '
        'btnDeletePilot
        '
        Me.btnDeletePilot.Location = New System.Drawing.Point(198, 38)
        Me.btnDeletePilot.Name = "btnDeletePilot"
        Me.btnDeletePilot.Size = New System.Drawing.Size(115, 32)
        Me.btnDeletePilot.TabIndex = 1
        Me.btnDeletePilot.Text = "Delete Pilot"
        Me.btnDeletePilot.UseVisualStyleBackColor = True
        '
        'btnAddPilotFlight
        '
        Me.btnAddPilotFlight.Location = New System.Drawing.Point(353, 38)
        Me.btnAddPilotFlight.Name = "btnAddPilotFlight"
        Me.btnAddPilotFlight.Size = New System.Drawing.Size(115, 32)
        Me.btnAddPilotFlight.TabIndex = 2
        Me.btnAddPilotFlight.Text = "Add Pilot to Flight"
        Me.btnAddPilotFlight.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(211, 103)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(86, 32)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmManagePilots
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(505, 172)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnAddPilotFlight)
        Me.Controls.Add(Me.btnDeletePilot)
        Me.Controls.Add(Me.btnAddPilot)
        Me.Name = "frmManagePilots"
        Me.Text = "Pilot Management Menu"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnAddPilot As Button
    Friend WithEvents btnDeletePilot As Button
    Friend WithEvents btnAddPilotFlight As Button
    Friend WithEvents btnExit As Button
End Class
