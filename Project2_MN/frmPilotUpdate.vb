Public Class frmPilotUpdate
    'close form
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub


    'load form with pilot info based on pk 
    Private Sub frmPilotUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String

        Dim cmdSelect As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dt As DataTable = New DataTable
        Dim dts As DataTable = New DataTable


        Try



            If OpenDatabaseConnectionSQLServer() = False Then


                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)


                Me.Close()

            End If

            'load pilot role combo box
            strSelect = "SELECT intPilotRoleID, strPilotRole FROM TPilotRoles"


            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dts.Load(drSourceTable)



            cboPilotRole.ValueMember = "intPilotRoleID"
            cboPilotRole.DisplayMember = "strPilotRole"
            cboPilotRole.DataSource = dts



            'get all pilot info

            strSelect = "Select TPilots.intPilotID, TPilots.strFirstName, TPilots.strLastName, TPilots.strEmployeeID, TPilots.dtmDateOfHire, TPilots.dtmDateOfLicense, TPilots.dtmDateOfTermination, TPilotRoles.intPilotRoleID" &
                      " From TPilots Join TPilotRoles" &
                      " On TPilots.intPilotRoleID = TPilotRoles.intPilotRoleID" &
                      " Where TPilots.intPilotID = " & intPilotID


            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            drSourceTable.Read()


            cboPilotRole.SelectedValue = drSourceTable("intPilotRoleID")
            txtFirstName.Text = drSourceTable("strFirstName")
            txtLastName.Text = drSourceTable("strLastName")
            txtEmployeeId.Text = drSourceTable("strEmployeeID")
            dtmDateOfHire.Value = drSourceTable("dtmDateOfHire")
            dtmDateOfLicense.Value = drSourceTable("dtmDateOfLicense")
            dtmDateOfTermination.Value = drSourceTable("dtmDateOfTermination")

            strSelect = "Select strEmployeeLoginId, strEmployeePassword From TEmployees Where intEmployeeID = " & intPilotID & " And strEmployeeRole = 'Pilot'"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            drSourceTable.Read()

            txtLoginId.Text = drSourceTable("strEmployeeLoginID")
            txtPassword.Text = drSourceTable("strEmployeePassword")





            drSourceTable.Close()

            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'validate pilot info and update
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strInsert As String
        Dim intRowsAffected As Integer
        Dim cmdUpdate As OleDb.OleDbCommand
        Dim strFirstName As String
        Dim strLastName As String
        Dim strEmployeeId As String
        Dim intPilotRole As Integer
        Dim dtmDateHire As Date
        Dim dtmDateLicense As Date
        Dim dtmDateTerminated As Date
        Dim strLoginId As String
        Dim strPassword As String


        Try

            Dim blnValidated As Boolean = True
            Call ValidateData(strFirstName, strLastName, strEmployeeId, intPilotRole, dtmDateHire, dtmDateLicense, dtmDateTerminated, strLoginId, strPassword, blnValidated)



            If OpenDatabaseConnectionSQLServer() = False Then


                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                        "The application will now close.",
                                        Me.Text + " Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error)


                Me.Close()

            End If




            If blnValidated = True Then


                strInsert = "Update TPilots Set " &
                        "strFirstName = '" & strFirstName & "'," &
                        "strLastName = '" & strLastName & "'," &
                        "strEmployeeID = '" & strEmployeeId & "', " &
                        "dtmDateofHire = '" & dtmDateHire & "', " &
                        "dtmDateofTermination = '" & dtmDateTerminated & "', " &
                        "dtmDateofLicense = '" & dtmDateLicense & "', " &
                        "intPilotRoleID = " & intPilotRole &
                        "Where intPilotID = " & intPilotID








                cmdUpdate = New OleDb.OleDbCommand(strInsert, m_conAdministrator)


                intRowsAffected = cmdUpdate.ExecuteNonQuery()


                If intRowsAffected = 1 Then
                    MessageBox.Show("Update successful")
                Else
                    MessageBox.Show("Update failed")
                End If


                strInsert = "Update TEmployees Set " &
                        "strEmployeeLoginID = '" & strLoginId & "'," &
                        "strEmployeePassword = '" & strPassword & "'" &
                        "Where intEmployeeId = " & intPilotID &
                        "And strEmployeeRole = 'Pilot' "


                cmdUpdate = New OleDb.OleDbCommand(strInsert, m_conAdministrator)


                intRowsAffected = cmdUpdate.ExecuteNonQuery()


                If intRowsAffected = 1 Then
                    MessageBox.Show("Update successful")
                Else
                    MessageBox.Show("Update failed")
                End If






                CloseDatabaseConnection()

                Close()


            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    'call validation procedures
    Private Sub ValidateData(ByRef strFirstName As String, ByRef strLastName As String, ByRef strEmployeeId As String, ByRef intPilotRole As Integer, ByRef dtmDateHire As Date, ByRef dtmDateLicense As Date, ByRef dtmDateTerminated As Date, ByRef strLoginId As String, ByRef strPassword As String, ByRef blnValidated As Boolean)
        Call ValidateFirstName(strFirstName, blnValidated)
        If blnValidated = True Then
            Call ValidateLastName(strLastName, blnValidated)
            If blnValidated = True Then
                Call ValidateEmpId(strEmployeeId, blnValidated)
                If blnValidated = True Then
                    Call ValidatePilotRole(intPilotRole, blnValidated)
                    If blnValidated = True Then
                        Call ValidateDateHire(dtmDateHire, blnValidated)
                        If blnValidated = True Then
                            Call ValidateLicenseDate(dtmDateLicense, blnValidated)
                            If blnValidated = True Then
                                Call ValidateTerminationdate(dtmDateTerminated, blnValidated)
                                If blnValidated = True Then
                                    Call ValidateLogin(strLoginId, blnValidated)
                                    If blnValidated = True Then
                                        Call ValidatePassword(strPassword, blnValidated)
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub


    'validate login id
    Private Sub ValidateLogin(ByRef strLoginId As String, ByRef blnValidated As Boolean)
        If txtLoginId.Text = "" Then
            MessageBox.Show("Please enter a login id")
            blnValidated = False
            txtLoginId.Focus()
        Else
            strLoginId = txtLoginId.Text
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



    'validate first name
    Private Sub ValidateFirstName(ByRef strFirstName As String, ByRef blnValidated As Boolean)
        If txtFirstName.Text = "" Then
            MessageBox.Show("First name must be entered")
            blnValidated = False
        Else
            strFirstName = txtFirstName.Text
        End If
    End Sub

    'validate last name
    Private Sub ValidateLastName(ByRef strLastName As String, ByRef blnValidated As Boolean)
        If txtLastName.Text = "" Then
            MessageBox.Show("Last name must be entered")
            blnValidated = False
        Else
            strLastName = txtLastName.Text
        End If
    End Sub

    'validate employee id
    Private Sub ValidateEmpId(ByRef strEmployeeId As String, ByRef blnValidated As Boolean)
        If txtEmployeeId.Text = "" Then
            MessageBox.Show("Employee ID must be entered")
            blnValidated = False
        Else
            strEmployeeId = txtEmployeeId.Text
        End If
    End Sub

    'validate hire date
    Private Sub ValidateDateHire(ByRef dtmDateHire As Date, ByRef blnValidated As Boolean)
        If dtmDateOfHire.Value = dtmDateOfHire.MinDate Then
            MessageBox.Show("Please enter a valid hire date")
            blnValidated = False
        Else
            dtmDateHire = dtmDateOfHire.Value
        End If
    End Sub

    'valiate license date
    Private Sub ValidateLicenseDate(ByRef dtmDateLicense As Date, ByRef blnValidated As Boolean)
        If dtmDateOfLicense.Value = dtmDateOfLicense.MinDate Then
            MessageBox.Show("Please enter a valid licensure date")
            blnValidated = False
        Else
            dtmDateLicense = dtmDateOfLicense.Value
        End If
    End Sub

    'validate termination date
    Private Sub ValidateTerminationdate(ByRef dtmDateTerminated As Date, ByRef blnValidated As Boolean)
        If dtmDateOfTermination.Value = dtmDateOfTermination.MinDate Then
            MessageBox.Show("Please enter a valid termination date")
            blnValidated = False
        Else
            dtmDateTerminated = dtmDateOfTermination.Value
        End If
    End Sub

    'validate pilot role
    Private Sub ValidatePilotRole(ByRef intPilotRole As Integer, ByRef blnValidated As Boolean)
        If cboPilotRole.SelectedIndex < 0 Then
            MessageBox.Show("Pilot role must be selected")
            blnValidated = False
        Else
            intPilotRole = cboPilotRole.SelectedValue
        End If
    End Sub
End Class