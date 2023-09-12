Public Class frmManagePilots
    'close form
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    'open add pilot form
    Private Sub btnAddPilot_Click(sender As Object, e As EventArgs) Handles btnAddPilot.Click
        Dim frmAddPilot As New frmAddPilot
        frmAddPilot.ShowDialog()
    End Sub

    'open delete pilot form
    Private Sub btnDeletePilot_Click(sender As Object, e As EventArgs) Handles btnDeletePilot.Click
        Dim frmDeletePilot As New frmDeletePilot
        frmDeletePilot.ShowDialog()
    End Sub

    'open add pilot to flight form
    Private Sub btnAddPilotFlight_Click(sender As Object, e As EventArgs) Handles btnAddPilotFlight.Click
        Dim frmAddPilotFlight As New frmAddPilotFlight
        frmAddPilotFlight.ShowDialog()
    End Sub
End Class