Public Class frmAttendantMain
    'close attendant main menu
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    'open attendant update form
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim frmAttendantUpdate As New frmAttendantUpdate
        frmAttendantUpdate.ShowDialog()
    End Sub

    'open attendant past flight information form
    Private Sub btnShowPastFlights_Click(sender As Object, e As EventArgs) Handles btnShowPastFlights.Click
        Dim frmAttendantPastFlights As New frmAttendantPastFlights
        frmAttendantPastFlights.ShowDialog()
    End Sub

    'open attendant future flights information form
    Private Sub btnShowFutureFlights_Click(sender As Object, e As EventArgs) Handles btnShowFutureFlights.Click
        Dim frmAttendantFutureFlights As New frmAttendantFutureFlights
        frmAttendantFutureFlights.ShowDialog()
    End Sub
End Class