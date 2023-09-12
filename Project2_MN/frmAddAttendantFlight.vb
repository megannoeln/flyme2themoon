Public Class frmAddAttendantFlight
    'close form
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    'load form with attendants and flights in cmobo boxes
    Private Sub frmAddAttendantFlight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String
        Dim cmdSelect As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dtp As DataTable = New DataTable
        Dim dt As DataTable = New DataTable

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

            strSelect = "Select TFlights.intFlightID, TFlights.dtmFlightDate From TFlights Where dtmFlightDate > GETDATE()"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dt.Load(drSourceTable)


            cboFlights.ValueMember = "intFlightID"
            cboFlights.DisplayMember = "dtmFlightDate"
            cboFlights.DataSource = dt




            drSourceTable.Close()



            CloseDatabaseConnection()

        Catch excError As Exception


            MessageBox.Show(excError.Message)

        End Try
    End Sub

    'add attendant to future flight
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strInsert As String
        Dim cmdSelect As OleDb.OleDbCommand
        Dim cmdInsert As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dt As DataTable = New DataTable
        Dim result As DialogResult
        Dim strSelect As String
        Dim intNextPrimaryKey As Integer
        Dim intRowsAffected As Integer
        Try





            If OpenDatabaseConnectionSQLServer() = False Then


                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                "The application will now close.",
                                Me.Text + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)


                Me.Close()

            End If

            result = MessageBox.Show("Are you sure you want to assign Attendant to flight?", "Flight Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            Select Case result
                Case DialogResult.No
                    MessageBox.Show("Action cancelled")
                Case DialogResult.Cancel
                    MessageBox.Show("Action Cancelled")
                Case DialogResult.Yes

                    strSelect = "Select Max(intAttendantFlightID) + 1 as intNextPrimaryKey From TAttendantFlights"

                    cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                    drSourceTable = cmdSelect.ExecuteReader


                    drSourceTable.Read()


                    If drSourceTable.IsDBNull(0) = True Then
                        intNextPrimaryKey = 1
                    Else
                        intNextPrimaryKey = CInt(drSourceTable("intNextPrimaryKey"))
                    End If


                    strInsert = "Insert into TAttendantFlights ( intAttendantFlightID, intAttendantID, intFlightID )" &
                                    " Values (" & intNextPrimaryKey & "," & cboAttendants.SelectedValue & "," & cboFlights.SelectedValue & ")"

                    cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)

                    intRowsAffected = cmdInsert.ExecuteNonQuery()

                    If intRowsAffected > 0 Then
                        MessageBox.Show("Flight assignment successful")

                    End If

                    CloseDatabaseConnection()
                    Close()


            End Select



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class