Public Class frmManageAttendants
    'close form
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    'open add attendant form
    Private Sub btnAddAttendant_Click(sender As Object, e As EventArgs) Handles btnAddAttendant.Click
        Dim frmAddAttendant As New frmAddAttendant
        frmAddAttendant.ShowDialog()
    End Sub

    'open delete attendant form
    Private Sub btnDeleteAttendant_Click(sender As Object, e As EventArgs) Handles btnDeleteAttendant.Click
        Dim frmDeleteAttendant As New frmDeleteAttendant
        frmDeleteAttendant.ShowDialog()
    End Sub

    'open add attendant to flight form
    Private Sub btnAddAttendantFlight_Click(sender As Object, e As EventArgs) Handles btnAddAttendantFlight.Click
        Dim frmAddAttendantFlight As New frmAddAttendantFlight
        frmAddAttendantFlight.ShowDialog()
    End Sub
End Class