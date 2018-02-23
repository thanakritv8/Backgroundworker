Imports System.Data.SqlClient

Public Class DB
    Public Function SelectSQL(ByVal _SQL As String, ByVal _DB As String) As DataTable
        Dim conDb As String = String.Empty
        If _DB = "Curing_A" Then
            conDb = My.Settings.Curing_A
        ElseIf _DB = "Curing_B" Then
            conDb = My.Settings.Curing_B
        ElseIf _DB = "DataCuring" Then
            conDb = My.Settings.DataCuring
        ElseIf _DB = "Tracking" Then
            conDb = My.Settings.Tracking
        End If
        Dim conn As New SqlConnection(conDb)
        Dim cmd As New SqlCommand(_SQL, conn)
        cmd.CommandTimeout = 600
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable()
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        da.Fill(dt)
        conn.Close()
        Return dt
    End Function

    Public Function ExecuteSQL(ByVal _SQL As String, ByVal _DB As String) As Boolean
        Try
            Dim conDb As String = String.Empty
            If _DB = "DataCuring" Then
                conDb = My.Settings.DataCuring
            ElseIf _DB = "QC1" Then
                'conDb = My.Settings.QC1
            End If
            Dim conn As New SqlConnection(conDb)
            Dim cmd As New SqlCommand(_SQL, conn)
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            cmd.ExecuteNonQuery()
            conn.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
