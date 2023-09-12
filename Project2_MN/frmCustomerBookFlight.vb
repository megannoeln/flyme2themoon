Public Class frmCustomerBookFlight

    'close form
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub



    'load combo box with future flights
    Private Sub frmCustomerBookFlight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String
        Dim cmdselect As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dt As DataTable = New DataTable

        Try



            If OpenDatabaseConnectionSQLServer() = False Then


                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)


                Me.Close()

            End If

            strSelect = "Select TFlights.intFlightID, TFlights.dtmFlightDate From TFlights Where dtmFlightDate > GETDATE()"

            cmdselect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdselect.ExecuteReader
            dt.Load(drSourceTable)


            cboFutureFlights.ValueMember = "intFlightID"
            cboFutureFlights.DisplayMember = "dtmFlightDate"
            cboFutureFlights.DataSource = dt


            drSourceTable.Close()



            CloseDatabaseConnection()



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub


    'add flight to database for customer
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strInsert As String
        Dim cmdSelect As OleDb.OleDbCommand
        Dim cmdInsert As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dt As DataTable = New DataTable
        Dim strSeatNumber As String
        Dim result As DialogResult
        Dim strSelect As String
        Dim intNextPrimaryKey As Integer
        Dim intRowsAffected As Integer

        Dim decFlightCost As Decimal





        Try

            Dim blnValidated As Boolean = True
            Call ValidateSeatNumber(strSeatNumber, blnValidated)
            If blnValidated = True Then


                If OpenDatabaseConnectionSQLServer() = False Then


                    MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)


                    Me.Close()

                End If

                result = MessageBox.Show("Are you sure you want to book this flight?", "Flight Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

                If radDesignatedSeat.Checked = True Then
                    decFlightCost = lblDesignatedSeat.Text.Remove(0, 1)
                Else
                    decFlightCost = lblReservedSeat.Text.Remove(0, 1)
                End If


                Select Case result
                    Case DialogResult.No
                        MessageBox.Show("Action cancelled")
                    Case DialogResult.Cancel
                        MessageBox.Show("Action Cancelled")
                    Case DialogResult.Yes

                        strSelect = "Select Max(intFlightPassengerID) + 1 as intNextPrimaryKey From TFlightPassengers"

                        cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                        drSourceTable = cmdSelect.ExecuteReader


                        drSourceTable.Read()


                        If drSourceTable.IsDBNull(0) = True Then
                            intNextPrimaryKey = 1
                        Else
                            intNextPrimaryKey = CInt(drSourceTable("intNextPrimaryKey"))
                        End If



                        strInsert = "Insert into TFlightPassengers ( intFlightPassengerID, intFlightID, intPassengerID, strSeat, decFlightCost)" &
                                    " Values (" & intNextPrimaryKey & "," & cboFutureFlights.SelectedValue & "," & intCustomerID & ",'" & strSeatNumber & "'," & decFlightCost & ")"

                        cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)

                        intRowsAffected = cmdInsert.ExecuteNonQuery()

                        If intRowsAffected > 0 Then
                            MessageBox.Show("Flight booking successful")

                        End If

                        CloseDatabaseConnection()
                        Close()


                End Select

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    'validate seat number
    Private Sub ValidateSeatNumber(ByRef strSeatNumber As String, ByRef blnValidated As Boolean)
        If txtSeatNumber.Text = "" Then
            MessageBox.Show("Please Enter a Seat Number")
            blnValidated = False
        Else
            strSeatNumber = txtSeatNumber.Text
        End If
    End Sub


    'get seat prices
    Private Sub cboFutureFlights_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFutureFlights.SelectedIndexChanged
        Dim decReserved As Decimal
        Dim decDesignated As Decimal
        Dim strSelect As String
        Dim cmdSelect As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader


        radReservedSeat.Visible = True
        radDesignatedSeat.Visible = True




        Try

            If OpenDatabaseConnectionSQLServer() = False Then


                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                "The application will now close.",
                                Me.Text + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)


                Me.Close()

            End If

            strSelect = "Select TFlights.intMilesFlown, TAirports.strAirportCode, TPlaneTypes.strPlaneType, coalesce(Count(TFlightPassengers.intPassengerID), 0 ) as TotalPassengers" &
                      " From TFlights left Join TAirports" &
                      " On TFlights.intToAirportID = TAirports.intAirportID" &
                      " Left Join TPlanes on TPlanes.intPlaneID = TFlights.intPlaneID" &
                      " Left Join TPlaneTypes on TPlaneTypes.intPlaneTypeID = TPlanes.intPlaneTypeID" &
                      " Left Join TFlightPassengers on TFlightPassengers.intFlightID = TFlights.intFlightID" &
                      " Left Join TPassengers on TPassengers.intPassengerID = TFlightPassengers.intFlightPassengerID" &
                      " Where TFlights.intFlightID = " & cboFutureFlights.SelectedValue &
                                  " group by TFlights.intMilesFlown, TAirports.strAirportCode, TPlaneTypes.strPlaneType"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            decDesignated = 250

            While drSourceTable.Read()
                If drSourceTable("intMilesFlown") > 750 Then
                    decDesignated = decDesignated + 50
                End If
                If drSourceTable("TotalPassengers") < 4 Then
                    decDesignated = decDesignated - 50
                Else
                    If drSourceTable("TotalPassengers") > 8 Then
                        decDesignated = decDesignated + 100
                    End If
                End If
                If drSourceTable("strPlaneType") = "Airbus A350" Then
                    decDesignated = decDesignated + 35
                Else
                    If drSourceTable("strPlaneType") = "Boeing 747-8" Then
                        decDesignated = decDesignated - 25
                    End If
                End If
                If drSourceTable("strAirportCode") = "MIA" Then
                    decDesignated = decDesignated + 15
                End If
            End While

            decReserved = decDesignated + 125

            strSelect = "Select DATEDIFF(YEAR, TPassengers.dtmDateOfBirth, GETDATE()) AS Age, Count(TFlightPassengers.intPassengerID) As TotalPrevFlights" &
                          " From TPassengers Join TFlightPassengers On TPassengers.intPassengerID = TFlightPassengers.intPassengerID" &
                          " Join TFlights On TFlights.intFlightID = TFlightPassengers.intFlightID" &
                          " Where TPassengers.intPassengerID = " & intCustomerID &
                               " And TFlights.dtmFlightDate < GetDate()" &
                               " group by TPassengers.dtmDateOfBirth"


            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            While drSourceTable.Read()
                If drSourceTable("Age") < 5 Then
                    decDesignated = decDesignated * 0.35
                    decReserved = decReserved * 0.35
                Else
                    If drSourceTable("age") > 65 Then
                        decDesignated = decDesignated * 0.8
                        decReserved = decReserved * 0.8
                    End If
                End If
                If drSourceTable("TotalPrevFlights") > 10 Then
                    decDesignated = decDesignated * 0.8
                    decReserved = decReserved * 0.8
                Else
                    If drSourceTable("TotalPrevFlights") > 5 Then
                        decDesignated = decDesignated * 0.9
                        decReserved = decReserved * 0.9
                    End If
                End If
            End While

            lblDesignatedSeat.Text = decDesignated.ToString("c")
            lblReservedSeat.Text = decReserved.ToString("c")



            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub
End Class