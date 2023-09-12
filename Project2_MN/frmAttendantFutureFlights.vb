Public Class frmAttendantFutureFlights
    'close form
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    'load list box with attendant future flight info
    Private Sub frmAttendantFutureFlights_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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


            cmdSelect = New OleDb.OleDbCommand("uspAttendantFutureFlights", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure

            objParam = cmdSelect.Parameters.Add("@attendant_id", OleDb.OleDbType.Integer)
            objParam.Direction = ParameterDirection.Input
            objParam.Value = intAttendantID

            drSourceTable = cmdSelect.ExecuteReader




            If Not drSourceTable.HasRows Then
                lstFutureFlights.Items.Add("No scheduled flight information to display")
            Else
                lstFutureFlights.Items.Add("Scheduled Flight Information")
                lstFutureFlights.Items.Add("=============================")


                While drSourceTable.Read()

                    lstFutureFlights.Items.Add("  ")

                    lstFutureFlights.Items.Add("Flight ID: " & vbTab & drSourceTable("intFlightID"))
                    lstFutureFlights.Items.Add("Flight Date: " & vbTab & drSourceTable("dtmFlightDate"))
                    lstFutureFlights.Items.Add("Time of Departure: " & vbTab & drSourceTable("dtmTimeofDeparture"))
                    lstFutureFlights.Items.Add("Time of Landing: " & vbTab & drSourceTable("dtmTimeOfLanding"))
                    lstFutureFlights.Items.Add("Departing From: " & vbTab & drSourceTable("DepartureCity"))
                    lstFutureFlights.Items.Add("Arriving To: " & vbTab & drSourceTable("ArrivalCity"))
                    lstFutureFlights.Items.Add("Plane Type: " & vbTab & drSourceTable("strPlaneType"))
                    lstFutureFlights.Items.Add("Flight Number: " & vbTab & drSourceTable("strFlightNumber"))
                    lstFutureFlights.Items.Add("Miles: " & vbTab & drSourceTable("intMilesFlown"))


                    lstFutureFlights.Items.Add("  ")
                    lstFutureFlights.Items.Add("=============================")

                End While
            End If




            drSourceTable.Close()
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class