Public Class frmAttendantPastFlights
    'close form
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    'load past flight info based on attendant pk
    Private Sub frmAttendantPastFlights_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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




            cmdSelect = New OleDb.OleDbCommand("uspAttendantPastFlights", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure

            objParam = cmdSelect.Parameters.Add("@attendant_id", OleDb.OleDbType.Integer)
            objParam.Direction = ParameterDirection.Input
            objParam.Value = intAttendantID

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




            cmdSelect = New OleDb.OleDbCommand("uspAttendantPastFlightMiles", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure

            objParam = cmdSelect.Parameters.Add("@attendant_id", OleDb.OleDbType.Integer)
            objParam.Direction = ParameterDirection.Input
            objParam.Value = intAttendantID

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