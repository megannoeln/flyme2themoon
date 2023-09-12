<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMainMenu
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
        Me.btnCustomerLogin = New System.Windows.Forms.Button()
        Me.btnEmployeeLogin = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(81, 157)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(112, 35)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnCustomerLogin
        '
        Me.btnCustomerLogin.Location = New System.Drawing.Point(81, 35)
        Me.btnCustomerLogin.Name = "btnCustomerLogin"
        Me.btnCustomerLogin.Size = New System.Drawing.Size(112, 35)
        Me.btnCustomerLogin.TabIndex = 4
        Me.btnCustomerLogin.Text = "Customer Login"
        Me.btnCustomerLogin.UseVisualStyleBackColor = True
        '
        'btnEmployeeLogin
        '
        Me.btnEmployeeLogin.Location = New System.Drawing.Point(81, 96)
        Me.btnEmployeeLogin.Name = "btnEmployeeLogin"
        Me.btnEmployeeLogin.Size = New System.Drawing.Size(112, 35)
        Me.btnEmployeeLogin.TabIndex = 5
        Me.btnEmployeeLogin.Text = "Employee Login"
        Me.btnEmployeeLogin.UseVisualStyleBackColor = True
        '
        'frmMainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(278, 242)
        Me.Controls.Add(Me.btnEmployeeLogin)
        Me.Controls.Add(Me.btnCustomerLogin)
        Me.Controls.Add(Me.btnExit)
        Me.Name = "frmMainMenu"
        Me.Text = "FlyMe2theMoon Main Menu"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnExit As Button
    Friend WithEvents btnCustomerLogin As Button
    Friend WithEvents btnEmployeeLogin As Button
End Class
