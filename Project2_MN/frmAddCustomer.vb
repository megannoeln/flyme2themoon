Public Class frmAddCustomer

    'close form
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    'load combo boxes
    Private Sub frmAddCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String
        Dim cmdSelect As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dts As DataTable = New DataTable




        Try



            If OpenDatabaseConnectionSQLServer() = False Then


                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                "The application will now close.",
                                Me.Text + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)


                Me.Close()

            End If



            strSelect = "SELECT intStateID, strState FROM TStates"






            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dts.Load(drSourceTable)



            cboStates.ValueMember = "intStateID"
            cboStates.DisplayMember = "strState"
            cboStates.DataSource = dts





            drSourceTable.Close()



            CloseDatabaseConnection()

        Catch excError As Exception


            MessageBox.Show(excError.Message)

        End Try
    End Sub

    'insert new customer data into database
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        Dim strFirstName As String
        Dim strLastName As String
        Dim strAddress As String
        Dim strCity As String
        Dim intState As Integer
        Dim strZip As String
        Dim strPhone As String
        Dim strEmail As String
        Dim strLoginID As String
        Dim strPassword As String
        Dim dtmDateOfBirth As Date
        Dim intNextPrimaryKey As Integer



        Dim cmdAddCustomer As New OleDb.OleDbCommand()


        Dim intRowsAffected As Integer
        Dim strSelect As String
        Dim cmdSelect As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Try
            Dim blnValidated As Boolean = True
            Call ValidateData(strFirstName, strLastName, strAddress, strCity, intState, strZip, strPhone, strEmail, strLoginID, strPassword, dtmDateOfBirth, blnValidated)

            If blnValidated = True Then

                If OpenDatabaseConnectionSQLServer() = False Then


                    MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                            "The application will now close.",
                                            Me.Text + " Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error)


                    Me.Close()

                End If




                cmdAddCustomer.CommandText = "EXECUTE uspAddCustomer '" & intNextPrimaryKey & "','" & strFirstName & "','" & strLastName & "','" & strAddress & "','" & strCity & "','" & intState & "','" & strZip & "','" & strPhone & "','" & strEmail & "','" & dtmDateOfBirth & "','" & strLoginID & "','" & strPassword & "'"
                cmdAddCustomer.CommandType = CommandType.StoredProcedure


                cmdAddCustomer = New OleDb.OleDbCommand(cmdAddCustomer.CommandText, m_conAdministrator)



                intRowsAffected = cmdAddCustomer.ExecuteNonQuery()



                If intRowsAffected > 0 Then
                    MessageBox.Show("Customer has been added")

                    strSelect = "Select MAX(intPassengerID) as intNextPrimaryKey From TPassengers"
                    cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                    drSourceTable = cmdSelect.ExecuteReader
                    drSourceTable.Read()


                    modStandardMod.intCustomerID = drSourceTable("intNextPrimaryKey")

                    drSourceTable.Close()
                End If



                CloseDatabaseConnection()
                Close()




            End If




        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    'call validation procedures
    Private Sub ValidateData(ByRef strFirstName As String, ByRef strLastName As String, ByRef strAddress As String, ByRef strCity As String, ByRef intState As Integer, ByRef strZip As String, ByRef strPhone As String, ByRef strEmail As String, ByRef strLoginID As String, ByRef strPassword As String, ByRef dtmDateOfBirth As Date, ByRef blnValidated As Boolean)
        ValidateFirstName(strFirstName, blnValidated)
        If blnValidated = True Then
            ValidateLastName(strLastName, blnValidated)
            If blnValidated = True Then
                ValidateAddress(strAddress, blnValidated)
                If blnValidated = True Then
                    ValidateCity(strCity, blnValidated)
                    If blnValidated = True Then
                        ValidateState(intState, blnValidated)
                        If blnValidated = True Then
                            ValidateZip(strZip, blnValidated)
                            If blnValidated = True Then
                                ValidatePhone(strPhone, blnValidated)
                                If blnValidated = True Then
                                    ValidateEmail(strEmail, blnValidated)
                                    If blnValidated = True Then
                                        ValidateLoginID(strLoginID, blnValidated)
                                        If blnValidated = True Then
                                            ValidatePassword(strPassword, blnValidated)
                                            If blnValidated = True Then
                                                ValidateDateOfBirth(dtmDateOfBirth, blnValidated)
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

    End Sub


    'validate date of birth
    Private Sub ValidateDateOfBirth(ByRef dtmDateOfBirth As Date, ByRef blnValidated As Boolean)
        If dtDateOfBirth.Value.Date = DateTime.Now.Date Then
            MessageBox.Show("Please enter a valid birth date")
            blnValidated = False
        Else
            dtmDateOfBirth = dtDateOfBirth.Value
        End If

    End Sub


    'validate login id
    Private Sub ValidateLoginID(ByRef strLoginID As String, ByRef blnValidated As Boolean)
        If txtLoginID.Text = "" Then
            MessageBox.Show("Login ID must be entered")
            blnValidated = False
        Else
            strLoginID = txtLoginID.Text
        End If
    End Sub

    'validate password
    Private Sub ValidatePassword(ByRef strPassword As String, ByRef blnValidated As Boolean)
        If txtPassword.Text = "" Then
            MessageBox.Show("Password must be entered")
            blnValidated = False
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

    'validate address
    Private Sub ValidateAddress(ByRef strAddress As String, ByRef blnValidated As Boolean)
        If txtAddress.Text = "" Then
            MessageBox.Show("Address must be entered")
            blnValidated = False
        Else
            strAddress = txtAddress.Text
        End If
    End Sub

    'validate city
    Private Sub ValidateCity(ByRef strCity As String, ByRef blnValidated As Boolean)
        If txtCity.Text = "" Then
            MessageBox.Show("City must be entered")
            blnValidated = False
        Else
            strCity = txtCity.Text
        End If
    End Sub

    'validate state
    Private Sub ValidateState(ByRef intState As Integer, ByRef blnValidated As Boolean)
        If cboStates.SelectedIndex = -1 Then
            MessageBox.Show("Please select a state")
            blnValidated = False
        Else
            intState = cboStates.SelectedValue
        End If
    End Sub

    'validate zip
    Private Sub ValidateZip(ByRef strZip As String, ByRef blnValidated As Boolean)
        If txtZip.Text = "" Then
            MessageBox.Show("Zip code must be entered")
            blnValidated = False
        Else
            strZip = txtZip.Text
        End If
    End Sub

    'validate phone number
    Private Sub ValidatePhone(ByRef strPhone As String, ByRef blnValidated As Boolean)
        If txtPhone.Text = "" Then
            MessageBox.Show("Phone number must be entered")
            blnValidated = False
        Else
            strPhone = txtPhone.Text
        End If
    End Sub

    'validate email
    Private Sub ValidateEmail(ByRef strEmail As String, ByRef blnValidated As Boolean)
        If txtEmail.Text = "" Then
            MessageBox.Show("Email must be entered")
            blnValidated = False
        Else
            strEmail = txtEmail.Text
            If strEmail.IndexOf("@", 0) = -1 Then
                MessageBox.Show("Please enter a valid email address")
                blnValidated = False
            End If
        End If
    End Sub
End Class