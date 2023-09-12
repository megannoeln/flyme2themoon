Public Class frmMainMenu


    'close form
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    'open customer login form
    Private Sub btnCustomerLogin_Click(sender As Object, e As EventArgs) Handles btnCustomerLogin.Click
        Dim frmCustomerLogin As New frmCustomerLogin
        frmCustomerLogin.ShowDialog()
    End Sub

    'open employee login form
    Private Sub btnEmployeeLogin_Click(sender As Object, e As EventArgs) Handles btnEmployeeLogin.Click
        Dim frmEmployeeLogin As New frmEmployeeLogin
        frmEmployeeLogin.ShowDialog()
    End Sub
End Class
