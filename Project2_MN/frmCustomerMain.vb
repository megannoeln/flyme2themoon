Public Class frmCustomerMain

    'open customer update form
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim frmUpdateCustomer As New frmUpdateCustomer
        frmUpdateCustomer.ShowDialog()
    End Sub

    'close form
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub



    'open customer book flight form
    Private Sub btnBookFlight_Click(sender As Object, e As EventArgs) Handles btnBookFlight.Click
        Dim frmCustomerBookFlight As New frmCustomerBookFlight
        frmCustomerBookFlight.ShowDialog()
    End Sub

    'open past flights form
    Private Sub btnShowPastFlights_Click(sender As Object, e As EventArgs) Handles btnShowPastFlights.Click
        Dim frmCustomerPastFlights As New frmCustomerPastFlights
        frmCustomerPastFlights.ShowDialog()
    End Sub

    'open future flights form
    Private Sub btnShowFutureFlights_Click(sender As Object, e As EventArgs) Handles btnShowFutureFlights.Click
        Dim frmCustomerFutureFlights As New frmCustomerFutureFlights
        frmCustomerFutureFlights.ShowDialog()
    End Sub
End Class