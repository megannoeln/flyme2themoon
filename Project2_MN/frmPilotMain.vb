Public Class frmPilotMain

    'close form
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub


    'open update info form
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim frmPilotUpdate As New frmPilotUpdate
        frmPilotUpdate.ShowDialog()
    End Sub


    'open pilot past flight info form
    Private Sub btnShowPastFlights_Click(sender As Object, e As EventArgs) Handles btnShowPastFlights.Click
        Dim frmPilotPastFlights As New frmPilotPastFlights
        frmPilotPastFlights.ShowDialog()
    End Sub

    'open pilot future flights form
    Private Sub btnShowFutureFlights_Click(sender As Object, e As EventArgs) Handles btnShowFutureFlights.Click
        Dim frmPilotFutureFlights As New frmPilotFutureFlights
        frmPilotFutureFlights.ShowDialog()
    End Sub
End Class