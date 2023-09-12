Public Class frmEmployeeLogin
    'exit form
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub


    'validate loginid and password and open corresponding main menu based on employee role
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


                strSelect = "Select intEmployeeID, strEmployeeRole From TEmployees Where strEmployeeLoginID = '" & strLoginId & "' And strEmployeePassword = '" & strPassword & "'"
                cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                drSourceTable = cmdSelect.ExecuteReader

                If drSourceTable.HasRows Then
                    drSourceTable.Read()
                    Select Case drSourceTable("strEmployeeRole")
                        Case "Admin"
                            Dim frmAdministrationMain As New frmAdministrationMain
                            frmAdministrationMain.ShowDialog()
                        Case "Pilot"
                            modStandardMod.intPilotID = drSourceTable("intEmployeeID")
                            Dim frmPilotMain As New frmPilotMain
                            frmPilotMain.ShowDialog()
                        Case "Attendant"
                            modStandardMod.intAttendantID = drSourceTable("intEmployeeID")
                            Dim frmAttendantMain As New frmAttendantMain
                            frmAttendantMain.ShowDialog()
                    End Select
                Else
                    MessageBox.Show("Invalid login ID and/or password")
                End If





                drSourceTable.Close()

                CloseDatabaseConnection()




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