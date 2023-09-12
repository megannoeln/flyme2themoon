Public Class frmCustomerFutureFlights
    'close form
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub frmCustomerFutureFlights_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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





            cmdSelect = New OleDb.OleDbCommand("uspCustomerFutureFlights", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure

            objParam = cmdSelect.Parameters.Add("@customer_id", OleDb.OleDbType.Integer)
            objParam.Direction = ParameterDirection.Input
            objParam.Value = intCustomerID




            drSourceTable = cmdSelect.ExecuteReader




            If Not drSourceTable.HasRows Then
                lstFutureFlights.Items.Add("No planned flight information to display")
            Else
                lstFutureFlights.Items.Add("Planned Flight Information")
                lstFutureFlights.Items.Add("=============================")


                While drSourceTable.Read()

                    lstFutureFlights.Items.Add("  ")

                    lstFutureFlights.Items.Add("Flight ID: " & vbTab & drSourceTable("intFlightID"))
                    lstFutureFlights.Items.Add("Flight Date: " & vbTab & drSourceTable("dtmFlightDate"))
                    lstFutureFlights.Items.Add("Time of Departure: " & vbTab & drSourceTable("dtmTimeofDeparture"))
                    lstFutureFlights.Items.Add("Time of Landing: " & vbTab & drSourceTable("dtmTimeOfLanding"))
                    lstFutureFlights.Items.Add("Departing From: " & vbTab & drSourceTable("DepartureCity"))
                    lstFutureFlights.Items.Add("Arriving To: " & vbTab & drSourceTable("ArrivalCity"))
                    lstFutureFlights.Items.Add("Plane ID: " & vbTab & drSourceTable("intPlaneID"))
                    lstFutureFlights.Items.Add("Flight Number: " & vbTab & drSourceTable("strFlightNumber"))
                    lstFutureFlights.Items.Add("Seat Number: " & vbTab & drSourceTable("strSeat"))
                    lstFutureFlights.Items.Add("Miles Planned: " & vbTab & drSourceTable("intMilesFlown"))
                    lstFutureFlights.Items.Add("Flight Cost: " & vbTab & drSourceTable("decFlightCost"))

                    lstFutureFlights.Items.Add("  ")
                    lstFutureFlights.Items.Add("=============================")

                End While
            End If




            cmdSelect = New OleDb.OleDbCommand("uspCustomerFutureFlightMiles", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure

            objParam = cmdSelect.Parameters.Add("@customer_id", OleDb.OleDbType.Integer)
            objParam.Direction = ParameterDirection.Input
            objParam.Value = intCustomerID


            drSourceTable = cmdSelect.ExecuteReader
            drSourceTable.Read()

            lblFutureMiles.Text = drSourceTable("TotalMilesFlown").ToString()


            drSourceTable.Close()
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class