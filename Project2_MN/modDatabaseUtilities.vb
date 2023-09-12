

Option Explicit On

Public Module modDatabaseUtilities





    Public m_conAdministrator As OleDb.OleDbConnection


    Private m_strDatabaseConnectionStringSQLServerV1 As String = "Provider=SQLOLEDB;" &
                                                                 "Server=(Local);" &
                                                                 "Database=dbFlyMe2theMoon;" &
                                                                 "Integrated Security=SSPI;"



#Region "Open/Close Connection"


    Public Function OpenDatabaseConnectionSQLServer() As Boolean

        Dim blnResult As Boolean = False

        Try


            m_conAdministrator = New OleDb.OleDbConnection
            m_conAdministrator.ConnectionString = m_strDatabaseConnectionStringSQLServerV1
            m_conAdministrator.Open()



            blnResult = True

        Catch excError As Exception


            MessageBox.Show(excError.Message)

        End Try

        Return blnResult

    End Function




    Public Function CloseDatabaseConnection() As Boolean

        Dim blnResult As Boolean = False

        Try


            If m_conAdministrator IsNot Nothing Then


                If m_conAdministrator.State <> ConnectionState.Closed Then


                    m_conAdministrator.Close()

                End If


                m_conAdministrator = Nothing

            End If


            blnResult = True

        Catch excError As Exception


            MessageBox.Show(excError.Message)

        End Try

        Return blnResult

    End Function

#End Region





End Module






