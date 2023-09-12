Public Class frmDeleteAttendant
    'load combo box with attendant names upon form load
    Private Sub frmDeleteAttendant_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String
        Dim cmdselect As OleDb.OleDbCommand
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


            strSelect = "SELECT intAttendantID, strFirstName + ' ' + strLastName as AttendantName FROM TAttendants"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dtp.Load(drSourceTable)

            cboAttendants.ValueMember = "intAttendantID"
            cboAttendants.DisplayMember = "AttendantName"
            cboAttendants.DataSource = dtp





            drSourceTable.Close()



            CloseDatabaseConnection()

        Catch excError As Exception


            MessageBox.Show(excError.Message)

        End Try
    End Sub

    'close form
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    'confirm deletion and proceed
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strDelete As String
        Dim intRowsAffected As Integer
        Dim cmdDeleteAttendant As New OleDb.OleDbCommand
        Dim dt As DataTable = New DataTable
        Dim result As DialogResult

        Try
            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine & "the application will now close.", Me.Text + " Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If

            result = MessageBox.Show("Are you sure you want to Delete Attendant: " & cboAttendants.Text & "?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Cancelled")
                Case DialogResult.No
                    MessageBox.Show("Action Cancelled")
                Case DialogResult.Yes

                    cmdDeleteAttendant.CommandText = "EXECUTE uspDeleteAttendant '" & cboAttendants.SelectedValue.ToString & "'"
                    cmdDeleteAttendant.CommandType = CommandType.StoredProcedure


                    cmdDeleteAttendant = New OleDb.OleDbCommand(cmdDeleteAttendant.CommandText, m_conAdministrator)



                    intRowsAffected = cmdDeleteAttendant.ExecuteNonQuery()


                    If intRowsAffected > 0 Then
                        MessageBox.Show("Delete Successful")
                        frmDeleteAttendant_Load(sender, e)
                        Me.Close()
                    End If

            End Select
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class