Public Class frmAttendantSelection
    'close attendant selection form
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    'load combo box with attendant names
    Private Sub frmAttendantSelection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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


            strSelect = "SELECT intAttendantID, strFirstName + ' ' + strLastName as AttendantName FROM TAttendants"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dtp.Load(drSourceTable)

            cboAttendantName.ValueMember = "intAttendantID"
            cboAttendantName.DisplayMember = "AttendantName"
            cboAttendantName.DataSource = dtp






            drSourceTable.Close()



            CloseDatabaseConnection()

        Catch excError As Exception


            MessageBox.Show(excError.Message)

        End Try

    End Sub


    'save attendant pk and open attendant main menu
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        modStandardMod.intAttendantID = CInt(cboAttendantName.SelectedValue)

        Dim frmAttendantMain As New frmAttendantMain
        frmAttendantMain.ShowDialog()

    End Sub
End Class