Public Class frmCustomerSelection

    'close form
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub




    'load combo box of names upon form load
    Private Sub frmCustomerSelection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String
        Dim cmdSelect As OleDb.OleDbCommand
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


            strSelect = "SELECT intPassengerID, strFirstName + ' ' + strLastName as PassengerName FROM TPassengers"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dtp.Load(drSourceTable)

            cboCustomerName.ValueMember = "intPassengerID"
            cboCustomerName.DisplayMember = "PassengerName"
            cboCustomerName.DataSource = dtp






            drSourceTable.Close()



            CloseDatabaseConnection()

        Catch excError As Exception


            MessageBox.Show(excError.Message)

        End Try






    End Sub


    'save customerid and open customer main menu
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        modStandardMod.intCustomerID = CInt(cboCustomerName.SelectedValue)

        Dim frmCustomerMain As New frmCustomerMain
        frmCustomerMain.ShowDialog()

    End Sub


    'open add customer form
    Private Sub btnAddCustomer_Click(sender As Object, e As EventArgs) Handles btnAddCustomer.Click
        Dim frmAddNewCustomer As New frmAddCustomer
        frmAddCustomer.ShowDialog()

        Call OpenCustomerMain()

    End Sub

    'open customer main form from add customer form
    Private Sub OpenCustomerMain()
        Dim frmCustomerMain As New frmCustomerMain
        frmCustomerMain.ShowDialog()
    End Sub
End Class