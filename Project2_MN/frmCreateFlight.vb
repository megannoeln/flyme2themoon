Public Class frmCreateFlight
    'close form
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    'validate data and enter flight into db
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strInsert As String
        Dim cmdInsert As OleDb.OleDbCommand
        Dim intNextPrimaryKey As Integer
        Dim dtmFlightDate As DateTime
        Dim strFlightNumber As String
        Dim dtmDepartureTime As DateTime
        Dim dtmArrivalTime As DateTime
        Dim intFromAirportId As Integer
        Dim intToAirportId As Integer
        Dim intFlightMiles As Integer
        Dim intPlaneId As Integer

        Dim drsourcetable As OleDb.OleDbDataReader

        Try
            Dim blnValidated As Boolean = True
            Call ValidateData(dtmFlightDate, strFlightNumber, dtmDepartureTime, dtmArrivalTime, intFromAirportId, intToAirportId, intFlightMiles, intPlaneId, blnValidated)
            If blnValidated = True Then

                If OpenDatabaseConnectionSQLServer() = False Then


                    MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                            "The application will now close.",
                                            Me.Text + " Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error)


                    Me.Close()

                End If

                strInsert = "SELECT MAX(intFlightId) + 1 AS intNextPrimaryKey " &
                                " FROM TFlights"


                cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)
                drsourcetable = cmdInsert.ExecuteReader


                drsourcetable.Read()


                If drSourceTable.IsDBNull(0) = True Then


                    intNextPrimaryKey = 1

                Else


                    intNextPrimaryKey = CInt(drsourcetable("intNextPrimaryKey"))

                End If

                strInsert = "Insert into TFlights (intFlightID, dtmFlightDate, strFlightNumber,  dtmTimeofDeparture, dtmTimeOfLanding, intFromAirportID, intToAirportID, intMilesFlown, intPlaneID)" &
                           " Values (" & intNextPrimaryKey & ",'" & dtmFlightDate & "','" & strFlightNumber & "','" & dtmDepartureTime.ToString("HH:mm") & "','" & dtmArrivalTime.ToString("HH:mm") & "'," & intFromAirportId & "," & intToAirportId & "," & intFlightMiles & "," & intPlaneId & ")"

                cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)


                Dim intRowsAffected As Integer

                intRowsAffected = cmdInsert.ExecuteNonQuery()


                If intRowsAffected > 0 Then
                    MessageBox.Show("Flight Created")

                End If

                drsourcetable.Close()

                CloseDatabaseConnection()
                Close()




            End If







        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'call validation procedures
    Private Sub ValidateData(ByRef dtmFlightDate As DateTime, ByRef strFlightNumber As String, ByRef dtmDepartureTime As DateTime, ByRef dtmArrivalTime As DateTime, ByRef intFromAirportId As Integer, ByRef intToAirportId As Integer, ByRef intFlightMiles As Integer, ByRef intPlaneId As Integer, ByRef blnValidated As Boolean)
        Call ValidateFlightDate(dtmFlightDate, blnValidated) '
        If blnValidated = True Then
            Call ValidateFlightNumber(strFlightNumber, blnValidated)
            If blnValidated = True Then
                Call ValidateDepartureTime(dtmDepartureTime, blnValidated)
                If blnValidated = True Then
                    Call ValidateArrivalTime(dtmArrivalTime, blnValidated)
                    If blnValidated = True Then
                        Call ValidateFromAirport(intFromAirportId, blnValidated)
                        If blnValidated = True Then
                            Call ValidateToAirport(intToAirportId, blnValidated)
                            If blnValidated = True Then
                                Call ValidateFlightMiles(intFlightMiles, blnValidated)
                                If blnValidated = True Then
                                    Call ValidatePlane(intPlaneId, blnValidated)
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    'validate plane id
    Private Sub Validateplane(ByRef intPlaneId As Integer, ByRef blnvalidated As Boolean)
        If cboPlaneID.SelectedIndex < 0 Then
            MessageBox.Show("Plane must be selected")
            blnvalidated = False
        Else
            intPlaneId = cboPlaneID.SelectedValue
        End If
    End Sub

    'validate flight miles
    Private Sub ValidateFlightMiles(ByRef intFlightMiles As Integer, ByRef blnValidated As Boolean)
        If Integer.TryParse(txtFlightMiles.Text, intFlightMiles) Then
            If intFlightMiles < 0 Then
                MessageBox.Show("Flight miles must be greater than 0")
                blnValidated = False
            End If
        Else
            MessageBox.Show("Flight miles must be numeric")
            blnValidated = False
        End If

    End Sub


    'validate arrival airport code
    Private Sub ValidateToAirport(ByRef intToAirportId As Integer, ByRef blnValidated As Boolean)
        If cboArrivalAirport.SelectedIndex < 0 Then
            MessageBox.Show("Arrival airport must be selected")
            blnValidated = False
        Else
            intToAirportId = cboArrivalAirport.SelectedValue
        End If
    End Sub

    'validate departing airport code
    Private Sub ValidateFromAirport(ByRef intFromAirportID As Integer, ByRef blnValidated As Boolean)
        If cboDepartingAirport.SelectedIndex < 0 Then
            MessageBox.Show("Departing airport must be selected")
            blnValidated = False
        Else
            intFromAirportID = cboDepartingAirport.SelectedValue
        End If
    End Sub

    'validate arrival time
    Private Sub ValidateArrivalTime(ByRef dtmArrivalTime As DateTime, ByRef blnValidated As Boolean)
        If cboArrivalTime.SelectedIndex < 0 Then
            MessageBox.Show("Arrival time must be selected")
            blnValidated = False
        Else
            dtmArrivalTime = cboArrivalTime.SelectedItem
        End If
    End Sub

    'validate departure time
    Private Sub ValidateDepartureTime(ByRef dtmDepartureTime As DateTime, ByRef blnValidated As Boolean)
        If cboDepartureTime.SelectedIndex < 0 Then
            MessageBox.Show("Departure time must be selected")
            blnValidated = False
        Else
            dtmDepartureTime = cboDepartureTime.SelectedItem
        End If
    End Sub

    'validate flight number
    Private Sub ValidateFlightNumber(ByRef strFlightNumber As String, ByRef blnValidated As Boolean)
        If txtFlightNumber.Text = "" Then
            MessageBox.Show("Flight number must be entered")
            blnValidated = False
        Else
            strFlightNumber = txtFlightNumber.Text
        End If

    End Sub

    'validate flight date
    Private Sub ValidateFlightDate(ByRef dtmFlightDate As DateTime, ByRef blnValidated As Boolean)
        If dtFlightDate.Value < DateTime.Now Then
            MessageBox.Show("Flight date must be a future date")
            blnValidated = False
        Else
            dtmFlightDate = dtFlightDate.Value
        End If
    End Sub

    'populate combo boxes
    Private Sub frmCreateFlight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String
        Dim cmdSelect As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dt As DataTable = New DataTable
        Dim dts As DataTable = New DataTable
        Dim dp As DataTable = New DataTable

        Try



            If OpenDatabaseConnectionSQLServer() = False Then


                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)


                Me.Close()

            End If


            strSelect = "SELECT intAirportID, strAirportCode FROM TAirports"


            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dts.Load(drSourceTable)



            cboDepartingAirport.ValueMember = "intAirportID"
            cboDepartingAirport.DisplayMember = "strAirportCode"
            cboDepartingAirport.DataSource = dts

            strSelect = "SELECT intAirportID, strAirportCode FROM TAirports"


            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dt.Load(drSourceTable)

            cboArrivalAirport.ValueMember = "intAirportID"
            cboArrivalAirport.DisplayMember = "strAirportCode"
            cboArrivalAirport.DataSource = dt


            strSelect = "SELECT intPlaneID, strPlaneNumber FROM TPlanes"


            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dp.Load(drSourceTable)

            cboPlaneID.ValueMember = "intPlaneID"
            cboPlaneID.DisplayMember = "strPlaneNumber"
            cboPlaneID.DataSource = dp


            drSourceTable.Close()

            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class