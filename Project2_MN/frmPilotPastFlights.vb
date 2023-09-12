Public Class frmPilotPastFlights
    'close form
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    'load all past flight information for pilot
    Private Sub frmPilotPastFlights_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String
        Dim cmdSelect As OleDb.OleDbCommand
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



            strSelect = "SELECT TFlights.intFlightID, TFlights.dtmFlightDate, TFlights.dtmTimeofDeparture, TFlights.dtmTimeOfLanding, DepartureAirport.strAirportCity AS DepartureCity, ArrivalAirport.strAirportCity AS ArrivalCity,TPlaneTypes.strPlaneType, TFlights.strFlightNumber, TFlights.intMilesFlown" &
                        " From TFlights Join TAirports As DepartureAirport On TFlights.intFromAirportID = DepartureAirport.intAirportID" &
                       " Join TAirports As ArrivalAirport On TFlights.intToAirportID = ArrivalAirport.intAirportID" &
                       " Join TPilotFlights On TFlights.intFlightID = TPilotFlights.intFlightID" &
                       " Join TPilots On TPilots.intPilotID = TPilotFlights.intPilotID" &
                        " Join TPlanes On TPlanes.intPlaneID = TFlights.intPlaneID" &
                        " Join TPlaneTypes On TPlaneTypes.intPlaneTypeID = TPlanes.intPlaneTypeID" &
                        " Where TPilots.intPilotID = " & intPilotID &
                       " And TFlights.dtmFlightDate < GetDate()"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader




            If Not drSourceTable.HasRows Then
                lstPastFlights.Items.Add("No past flight information to display")
            Else
                lstPastFlights.Items.Add("Past Flight Information")
                lstPastFlights.Items.Add("=============================")


                While drSourceTable.Read()

                    lstPastFlights.Items.Add("  ")

                    lstPastFlights.Items.Add("Flight ID: " & vbTab & drSourceTable("intFlightID"))
                    lstPastFlights.Items.Add("Flight Date: " & vbTab & drSourceTable("dtmFlightDate"))
                    lstPastFlights.Items.Add("Time of Departure: " & vbTab & drSourceTable("dtmTimeofDeparture"))
                    lstPastFlights.Items.Add("Time of Landing: " & vbTab & drSourceTable("dtmTimeOfLanding"))
                    lstPastFlights.Items.Add("Departed From: " & vbTab & drSourceTable("DepartureCity"))
                    lstPastFlights.Items.Add("Arrived To: " & vbTab & drSourceTable("ArrivalCity"))
                    lstPastFlights.Items.Add("Plane Type: " & vbTab & drSourceTable("strPlaneType"))
                    lstPastFlights.Items.Add("Flight Number: " & vbTab & drSourceTable("strFlightNumber"))
                    lstPastFlights.Items.Add("Miles Flown: " & vbTab & drSourceTable("intMilesFlown"))


                    lstPastFlights.Items.Add("  ")
                    lstPastFlights.Items.Add("=============================")

                End While
            End If



            strSelect = "SELECT COALESCE(SUM(TFlights.intMilesFlown), 0) AS TotalMilesFlown" &
            " FROM TFlights" &
            " LEFT JOIN TPilotFlights ON TFlights.intFlightID = TPilotFlights.intFlightID" &
            " LEFT JOIN TPilots ON TPilotFlights.intPilotID = TPilots.intPilotID" &
            " WHERE TPilots.intPilotID = " & intPilotID &
            " AND TFlights.dtmFlightDate < GETDATE()"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            drSourceTable.Read()

            lblPastMiles.Text = drSourceTable("TotalMilesFlown").ToString()


            drSourceTable.Close()
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class