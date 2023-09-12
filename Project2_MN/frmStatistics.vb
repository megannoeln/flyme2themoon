Public Class frmStatistics

    'close form
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub


    'load controls with all statistics
    Private Sub frmStatistics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String
        Dim cmdSelect As OleDb.OleDbCommand
        Dim drsourcetable As OleDb.OleDbDataReader
        Dim dc As DataTable = New DataTable
        Dim df As DataTable = New DataTable
        Dim dav As DataTable = New DataTable
        Dim dp As DataTable = New DataTable
        Dim da As DataTable = New DataTable

        Try


            If OpenDatabaseConnectionSQLServer() = False Then


                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                "The application will now close.",
                                Me.Text + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)


                Me.Close()

            End If

            'get results for total customers
            strSelect = "SELECT COUNT(TPassengers.intPassengerID) as TotalPassengers from TPassengers"
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drsourcetable = cmdSelect.ExecuteReader


            drsourcetable.Read()


            If drsourcetable.IsDBNull(0) = True Then
                lblTotalNumCustomers.Text = 0
            Else
                lblTotalNumCustomers.Text = CInt(drsourcetable("TotalPassengers"))
            End If

            'get results for total flights
            strSelect = "SELECT COUNT(TFlights.intFlightID) as TotalFlights from TFlights"
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drsourcetable = cmdSelect.ExecuteReader


            drsourcetable.Read()


            If drsourcetable.IsDBNull(0) = True Then
                lblTotalNumFlights.Text = 0
            Else
                lblTotalNumFlights.Text = CInt(drsourcetable("TotalFlights"))
            End If

            'get results for average miles flown across all flights
            strSelect = "SELECT AVG(intMilesFlown) AS AverageMilesFlown FROM TFlights"
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drsourcetable = cmdSelect.ExecuteReader


            drsourcetable.Read()


            If drsourcetable.IsDBNull(0) = True Then
                lblAvgMiles.Text = 0
            Else
                lblAvgMiles.Text = CInt(drsourcetable("AverageMilesFlown"))
            End If

            'get results for total miles flown per pilot
            strSelect = "Select TPilots.strFirstName, TPilots.strLastName, Coalesce(Sum(intMilesFlown), 0) As TotalMilesFlown" &
                       " From TFlights Join TPilotFlights" &
                       " On TFlights.intFlightID = TPilotFlights.intFlightID" &
                        " Right Join TPilots" &
                        " On TPilots.intPilotID = TPilotFlights.intPilotID" &
                       " Group By TPilots.strFirstName, TPilots.strLastName"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drsourcetable = cmdSelect.ExecuteReader

            lstPilotStats.Items.Add("===========================")

            While drsourcetable.Read()
                lstPilotStats.Items.Add("            ")
                lstPilotStats.Items.Add("First Name: " & drsourcetable("strFirstName"))
                lstPilotStats.Items.Add("Last Name: " & drsourcetable("strLastName"))
                lstPilotStats.Items.Add("Has Flown " & drsourcetable("TotalMilesFlown") & " Miles")
                lstPilotStats.Items.Add("       ")
                lstPilotStats.Items.Add("=======================")
            End While


            'get results for total miles flown per attendant

            strSelect = "Select TAttendants.strFirstName, TAttendants.strLastName, coalesce(Sum(intMilesFlown), 0) as TotalMilesFlown" &
                       " From TFlights Join TAttendantFlights" &
                       " On TFlights.intFlightID = TAttendantFlights.intFlightID" &
                        " Right Join TAttendants" &
                        " On TAttendants.intAttendantID = TAttendantFlights.intAttendantID" &
                        " group by TAttendants.strFirstName, TAttendants.strLastName"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drsourcetable = cmdSelect.ExecuteReader

            lstAttendantStats.Items.Add("===========================")

            While drsourcetable.Read()
                lstAttendantStats.Items.Add("            ")
                lstAttendantStats.Items.Add("First Name: " & drsourcetable("strFirstName"))
                lstAttendantStats.Items.Add("Last Name: " & drsourcetable("strLastName"))
                lstAttendantStats.Items.Add("Has Flown " & drsourcetable("TotalMilesFlown") & " Miles")
                lstAttendantStats.Items.Add("       ")
                lstAttendantStats.Items.Add("=======================")
            End While



            drsourcetable.Close()
            CloseDatabaseConnection()





        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class