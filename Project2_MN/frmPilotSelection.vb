Public Class frmPilotSelection

    'load combo box with pilot names
    Private Sub frmPilotSelection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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


            strSelect = "SELECT intPilotID, strFirstName + ' ' + strLastName as PilotName FROM TPilots"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dtp.Load(drSourceTable)

            cboPilotName.ValueMember = "intPilotID"
            cboPilotName.DisplayMember = "PilotName"
            cboPilotName.DataSource = dtp






            drSourceTable.Close()



            CloseDatabaseConnection()

        Catch excError As Exception


            MessageBox.Show(excError.Message)

        End Try


    End Sub


    'close form
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    'save pilot pk and open pilot main form
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        modStandardMod.intPilotID = CInt(cboPilotName.SelectedValue)

        Dim frmPilotMain As New frmPilotMain
        frmPilotMain.ShowDialog()


    End Sub
End Class