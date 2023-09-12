Public Class frmPilotFutureFlights
    'close form
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    'load future flight data for pilot
    Private Sub frmPilotFutureFlights_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String
        Dim cmdSelect As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dt As DataTable = New DataTable
        Dim objParam As OleDb.OleDbParameter
        Try


            If OpenDatabaseConnectionSQLServer() = False Then


                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                "The application will now close.",
                                Me.Text + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)


                Me.Close()

            End If





            cmdSelect = New OleDb.OleDbCommand("uspPilotFutureFlights", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure

            objParam = cmdSelect.Parameters.Add("@pilot_id", OleDb.OleDbType.Integer)
            objParam.Direction = ParameterDirection.Input
            objParam.Value = intPilotID


            drSourceTable = cmdSelect.ExecuteReader




            If Not drSourceTable.HasRows Then
                lstPilotFutureFlights.Items.Add("No scheduled flight information to display")
            Else
                lstPilotFutureFlights.Items.Add("Scheduled Flight Information")
                lstPilotFutureFlights.Items.Add("=============================")


                While drSourceTable.Read()

                    lstPilotFutureFlights.Items.Add("  ")

                    lstPilotFutureFlights.Items.Add("Flight ID: " & vbTab & drSourceTable("intFlightID"))
                    lstPilotFutureFlights.Items.Add("Flight Date: " & vbTab & drSourceTable("dtmFlightDate"))
                    lstPilotFutureFlights.Items.Add("Time of Departure: " & vbTab & drSourceTable("dtmTimeofDeparture"))
                    lstPilotFutureFlights.Items.Add("Time of Landing: " & vbTab & drSourceTable("dtmTimeOfLanding"))
                    lstPilotFutureFlights.Items.Add("Departing From: " & vbTab & drSourceTable("DepartureCity"))
                    lstPilotFutureFlights.Items.Add("Arriving To: " & vbTab & drSourceTable("ArrivalCity"))
                    lstPilotFutureFlights.Items.Add("Plane Type: " & vbTab & drSourceTable("strPlaneType"))
                    lstPilotFutureFlights.Items.Add("Flight Number: " & vbTab & drSourceTable("strFlightNumber"))
                    lstPilotFutureFlights.Items.Add("Miles: " & vbTab & drSourceTable("intMilesFlown"))


                    lstPilotFutureFlights.Items.Add("  ")
                    lstPilotFutureFlights.Items.Add("=============================")

                End While
            End If


            drSourceTable.Close()
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class