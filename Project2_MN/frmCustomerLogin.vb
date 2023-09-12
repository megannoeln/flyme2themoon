Public Class frmCustomerLogin
    'close form
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    'open new customer form
    Private Sub btnAddCustomer_Click(sender As Object, e As EventArgs) Handles btnAddCustomer.Click
        Dim frmAddCustomer As New frmAddCustomer
        frmAddCustomer.ShowDialog()
    End Sub

    'validate login and password and open customer main menu upon correct entry
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strLoginId As String
        Dim strPassword As String
        Dim blnValidated As Boolean = True
        Dim strSelect As String
        Dim cmdSelect As New OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim intRows As Integer

        Try

            Call ValidateData(strLoginId, strPassword, blnValidated)
            If blnValidated = True Then

                If OpenDatabaseConnectionSQLServer() = False Then


                    MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                        "The application will now close.",
                                        Me.Text + " Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error)


                    Me.Close()

                End If


                strSelect = "Select intPassengerID From TPassengers Where strLoginID = '" & strLoginId & "' And strPassword = '" & strPassword & "'"
                cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                drSourceTable = cmdSelect.ExecuteReader



                If drSourceTable.Read() Then

                    modStandardMod.intCustomerID = drSourceTable("intPassengerID")

                    Dim frmCustomerMain As New frmCustomerMain
                    frmCustomerMain.ShowDialog()
                Else
                    MessageBox.Show("ID and/or Password are not valid")

                End If




                CloseDatabaseConnection()
                Close()



            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try



    End Sub

    'call validation procedures
    Private Sub ValidateData(ByRef strLoginId As String, ByRef strPassword As String, ByRef blnValidated As Boolean)
        Call ValidateLogin(strLoginId, blnValidated)
        If blnValidated = True Then
            Call ValidatePassword(strPassword, blnValidated)
        End If
    End Sub

    'validate login id
    Private Sub ValidateLogin(ByRef strLoginId As String, ByRef blnValidated As Boolean)
        If txtLoginID.Text = "" Then
            MessageBox.Show("Please enter a login id")
            blnValidated = False
            txtLoginID.Focus()
        Else
            strLoginId = txtLoginID.Text
        End If
    End Sub

    'validate password
    Private Sub ValidatePassword(ByRef strPassword As String, ByRef blnValidated As Boolean)
        If txtPassword.Text = "" Then
            MessageBox.Show("Please enter a password")
            blnValidated = False
            txtPassword.Focus()
        Else
            strPassword = txtPassword.Text
        End If
    End Sub

End Class