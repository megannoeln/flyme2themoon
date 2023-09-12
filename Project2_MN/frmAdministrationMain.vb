Public Class frmAdministrationMain
    'close form
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    'open manage pilots form
    Private Sub btnManagePilots_Click(sender As Object, e As EventArgs) Handles btnManagePilots.Click
        Dim frmManagePilots As New frmManagePilots
        frmManagePilots.ShowDialog()
    End Sub

    'open manage attendants form
    Private Sub btnManageAttendants_Click(sender As Object, e As EventArgs) Handles btnManageAttendants.Click
        Dim frmManageAttendants As New frmManageAttendants
        frmManageAttendants.ShowDialog()
    End Sub

    'open statistics form
    Private Sub btnStatistics_Click(sender As Object, e As EventArgs) Handles btnStatistics.Click
        Dim frmStatistics As New frmStatistics
        frmStatistics.ShowDialog()
    End Sub

    'open create flight form
    Private Sub btnCreateFlight_Click(sender As Object, e As EventArgs) Handles btnCreateFlight.Click
        Dim frmCreateFlight As New frmCreateFlight
        frmCreateFlight.ShowDialog()
    End Sub
End Class