Public Class frmUpdateCustomer

    'load form with customers info
    Private Sub frmUpdateCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            'load state combo box
            strSelect = "SELECT intStateID, strState FROM TStates"


            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dts.Load(drSourceTable)



            cboStates.ValueMember = "intStateID"
            cboStates.DisplayMember = "strState"
            cboStates.DataSource = dts



            'retreive all customer data

            strSelect = "SELECT strFirstName, strLastName, strAddress, strCity, intStateID, strZip, strPhoneNumber, strEmail, strLoginID, strPassword " &
                        " FROM TPassengers Where intPassengerID = " & intCustomerID


            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            drSourceTable.Read()



            txtFirstName.Text = drSourceTable("strFirstName")
            txtLastName.Text = drSourceTable("strLastName")

            txtAddress.Text = drSourceTable("strAddress")
            txtCity.Text = drSourceTable("strCity")
            cboStates.SelectedValue = drSourceTable("intStateID")

            txtZip.Text = drSourceTable("strZip")
            txtPhone.Text = drSourceTable("strPhoneNumber")
            txtEmail.Text = drSourceTable("strEmail")

            txtLoginID.Text = drSourceTable("strLoginID")
            txtPassword.Text = drSourceTable("strPassword")




            drSourceTable.Close()

            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'validate new info and update in database
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim strSelect As String
        Dim strInsert As String

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

        Dim intRowsAffected As Integer


        Dim cmdUpdateCustomer As New OleDb.OleDbCommand

        Try

            Dim blnValidated As Boolean = True
            Call ValidateData(strFirstName, strLastName, strAddress, strCity, intState, strZip, strPhone, strEmail, strLoginID, strPassword, blnValidated)

            If blnValidated = True Then

                If OpenDatabaseConnectionSQLServer() = False Then


                    MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                        "The application will now close.",
                                        Me.Text + " Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error)


                    Me.Close()

                End If



                cmdUpdateCustomer.CommandText = "EXECUTE uspUpdateCustomer '" & intCustomerID & "','" & strFirstName & "','" & strLastName & "','" & strAddress & "','" & strCity & "','" & intState & "','" & strZip & "','" & strPhone & "','" & strEmail & "','" & strLoginID & "','" & strPassword & "'"
                cmdUpdateCustomer.CommandType = CommandType.StoredProcedure


                cmdUpdateCustomer = New OleDb.OleDbCommand(cmdUpdateCustomer.CommandText, m_conAdministrator)



                intRowsAffected = cmdUpdateCustomer.ExecuteNonQuery()


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
    Private Sub ValidateData(ByRef strFirstName As String, ByRef strLastName As String, ByRef strAddress As String, ByRef strCity As String, ByRef intState As Integer, ByRef strZip As String, ByRef strPhone As String, ByRef strEmail As String, ByRef strLoginID As String, ByRef strPassword As String, ByRef blnValidated As Boolean)

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
                                        ValidateLogin(strLoginID, blnValidated)
                                        If blnValidated = True Then
                                            ValidatePassword(strPassword, blnValidated)
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


    'validate login id
    Private Sub ValidateLogin(ByRef strLoginID As String, ByRef blnValidated As Boolean)
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

    'close form
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class