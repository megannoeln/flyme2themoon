<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdministrationMain
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
        Me.btnManagePilots = New System.Windows.Forms.Button()
        Me.btnManageAttendants = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnStatistics = New System.Windows.Forms.Button()
        Me.btnCreateFlight = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnManagePilots
        '
        Me.btnManagePilots.Location = New System.Drawing.Point(57, 33)
        Me.btnManagePilots.Name = "btnManagePilots"
        Me.btnManagePilots.Size = New System.Drawing.Size(106, 34)
        Me.btnManagePilots.TabIndex = 0
        Me.btnManagePilots.Text = "Manage Pilots"
        Me.btnManagePilots.UseVisualStyleBackColor = True
        '
        'btnManageAttendants
        '
        Me.btnManageAttendants.Location = New System.Drawing.Point(57, 85)
        Me.btnManageAttendants.Name = "btnManageAttendants"
        Me.btnManageAttendants.Size = New System.Drawing.Size(106, 37)
        Me.btnManageAttendants.TabIndex = 1
        Me.btnManageAttendants.Text = "Manage Attendants"
        Me.btnManageAttendants.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(57, 261)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(106, 35)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnStatistics
        '
        Me.btnStatistics.Location = New System.Drawing.Point(57, 144)
        Me.btnStatistics.Name = "btnStatistics"
        Me.btnStatistics.Size = New System.Drawing.Size(106, 37)
        Me.btnStatistics.TabIndex = 3
        Me.btnStatistics.Text = "Statistics"
        Me.btnStatistics.UseVisualStyleBackColor = True
        '
        'btnCreateFlight
        '
        Me.btnCreateFlight.Location = New System.Drawing.Point(57, 200)
        Me.btnCreateFlight.Name = "btnCreateFlight"
        Me.btnCreateFlight.Size = New System.Drawing.Size(106, 37)
        Me.btnCreateFlight.TabIndex = 4
        Me.btnCreateFlight.Text = "Create Future Flight"
        Me.btnCreateFlight.UseVisualStyleBackColor = True
        '
        'frmAdministrationMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(232, 317)
        Me.Controls.Add(Me.btnCreateFlight)
        Me.Controls.Add(Me.btnStatistics)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnManageAttendants)
        Me.Controls.Add(Me.btnManagePilots)
        Me.Name = "frmAdministrationMain"
        Me.Text = "Admin Main Menu"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnManagePilots As Button
    Friend WithEvents btnManageAttendants As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnStatistics As Button
    Friend WithEvents btnCreateFlight As Button
End Class
