Public Class frmDeletePilot
    'close form
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    'load combo box with pilots
    Private Sub frmDeletePilot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String
        Dim cmdSelect As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dtp As DataTable = New DataTable


        Try



            If OpenDatabaseConnectionSQLServer() = False Then


                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                "The application will now close.",
                                Me.Text + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)


                Me.Close()

            End If


            strSelect = "SELECT intPilotID, strFirstName + ' ' + strLastName as PilotName FROM TPilots"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dtp.Load(drSourceTable)

            cboPilots.ValueMember = "intPilotID"
            cboPilots.DisplayMember = "PilotName"
            cboPilots.DataSource = dtp






            drSourceTable.Close()



            CloseDatabaseConnection()

        Catch excError As Exception


            MessageBox.Show(excError.Message)

        End Try

    End Sub

    'confirm and proceed with pilot deletion
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strDelete As String
        Dim intRowsAffected As Integer
        Dim cmdDeletePilot As New OleDb.OleDbCommand
        Dim dt As DataTable = New DataTable
        Dim result As DialogResult

        Try
            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine & "the application will now close.", Me.Text + " Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If

            result = MessageBox.Show("Are you sure you want to Delete Pilot: " & cboPilots.Text & "?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Cancelled")
                Case DialogResult.No
                    MessageBox.Show("Action Cancelled")
                Case DialogResult.Yes


                    cmdDeletePilot.CommandText = "EXECUTE uspDeletePilot '" & cboPilots.SelectedValue.ToString & "'"
                    cmdDeletePilot.CommandType = CommandType.StoredProcedure


                    cmdDeletePilot = New OleDb.OleDbCommand(cmdDeletePilot.CommandText, m_conAdministrator)



                    intRowsAffected = cmdDeletePilot.ExecuteNonQuery()


                    If intRowsAffected > 0 Then
                        MessageBox.Show("Delete Successful")
                        frmDeletePilot_Load(sender, e)
                        Me.Close()
                    End If
            End Select
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class