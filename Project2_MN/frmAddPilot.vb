﻿Public Class frmAddPilot
    'close form
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    'populate pilot role combo box
    Private Sub frmAddPilot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dtpr As DataTable = New DataTable

        Try
            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine & "The application will now close.", Me.Text + " Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ' close the form/application
                Me.Close()
            End If
            strSelect = "SELECT TPilotRoles.intPilotRoleID, TPilotRoles.strPilotRole FROM TPilotRoles"
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dtpr.Load(drSourceTable)

            cboPilotRole.ValueMember = "intPilotRoleID"
            cboPilotRole.DisplayMember = "strPilotRole"
            cboPilotRole.DataSource = dtpr
            drSourceTable.Close()
            CloseDatabaseConnection()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'validate pilot info and insert into database
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strSelect As String
        Dim strInsert As String
        Dim strFirstName As String
        Dim strLastName As String
        Dim strEmployeeId As String
        Dim intPilotRole As Integer
        Dim dtmDateHire As Date
        Dim dtmDateLicense As Date
        Dim dtmDateTerminated As Date
        Dim strLoginId As String
        Dim strPassword As String


        Dim cmdSelect As OleDb.OleDbCommand
        Dim cmdInsert As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim intNextPrimaryKey As Integer
        Dim intRowsAffected As Integer

        Try
            Dim blnValidated As Boolean = True
            Call ValidateData(strFirstName, strLastName, strEmployeeId, intPilotRole, dtmDateHire, dtmDateLicense, dtmDateTerminated, strLoginId, strPassword, blnValidated)

            If blnValidated = True Then

                If OpenDatabaseConnectionSQLServer() = False Then


                    MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                            "The application will now close.",
                                            Me.Text + " Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error)


                    Me.Close()

                End If

                strSelect = "SELECT MAX(intPilotID) + 1 AS intNextPrimaryKey " &
                                " FROM TPilots"


                cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                drSourceTable = cmdSelect.ExecuteReader


                drSourceTable.Read()


                If drSourceTable.IsDBNull(0) = True Then


                    intNextPrimaryKey = 1

                Else


                    intNextPrimaryKey = CInt(drSourceTable("intNextPrimaryKey"))

                End If


                strInsert = "INSERT INTO TPilots (intPilotID, strFirstName, strLastName, strEmployeeID, dtmDateOfHire, dtmDateOfTermination, dtmDateOfLicense, intPilotRoleID)" &
                    " VALUES (" & intNextPrimaryKey & ",'" & strFirstName & "','" & strLastName & "','" & strEmployeeId & "','" & dtmDateHire & "','" & dtmDateTerminated & "','" & dtmDateLicense & "'," & intPilotRole & ")"

                ' MessageBox.Show(strInsert)


                cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)


                intRowsAffected = cmdInsert.ExecuteNonQuery()


                If intRowsAffected > 0 Then
                    MessageBox.Show("Pilot has been added")

                End If

                Dim intNextEmpPrimaryKey As Integer

                strSelect = "SELECT MAX(intEmpPrimaryKeyId) + 1 AS intNextEmpPrimaryKey " &
                                " FROM TEmployees"


                cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                drSourceTable = cmdSelect.ExecuteReader


                drSourceTable.Read()


                If drSourceTable.IsDBNull(0) = True Then


                    intNextEmpPrimaryKey = 1

                Else


                    intNextEmpPrimaryKey = CInt(drSourceTable("intNextEmpPrimaryKey"))

                End If


                strInsert = "Insert into TEmployees (intEmpPrimaryKeyId, strEmployeeLoginID, strEmployeePassword, strEmployeeRole, intEmployeeID )" &
                            " Values (" & intNextEmpPrimaryKey & ",'" & strLoginId & "','" & strPassword & "','" & "Pilot" & "'," & intNextPrimaryKey & ")"

                cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)

                intRowsAffected = cmdInsert.ExecuteNonQuery()


                If intRowsAffected > 0 Then
                    MessageBox.Show("Employee Information Confirmed")

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