Imports DAL
Public Class BLL_Load

    Public Sub CheckTableDate(ByVal _Mach As String)
        Dim DB As DB = New DB
        Dim _SQL As String = "SELECT name From sys.tables WHERE name = 'C" & _Mach & Format(Now, "yyyyMMdd") & "'"
        Dim Dt As DataTable = New DataTable
        If _Mach >= 700 Then
            Dt = DB.SelectSQL(_SQL, "Curing_B")
        Else
            Dt = DB.SelectSQL(_SQL, "Curing_A")
        End If
        If Dt.Rows.Count > 0 Then
            AddTable(_Mach)
        End If
    End Sub

    Private Sub AddTable(ByVal _Mach As String)

    End Sub

    Public Function GetAdr(ByVal _Mach As String) As DataTable
        Dim DB As DB = New DB
        Dim _SQL As String = "SELECT * FROM MachPLC WHERE machno ='" & _Mach & "' AND PLC_Enabled = '1' ORDER BY machno ASC"
        If _Mach >= 700 Then
            Return DB.SelectSQL(_SQL, "Curing_B")
        Else
            Return DB.SelectSQL(_SQL, "Curing_A")
        End If
    End Function

    Public Sub UpdateData(ByVal Barcode As String, ByVal _Mach As String, ByVal Size As String, ByVal Spec As String, ByVal Item As String, ByVal Mold As String)
        Dim DB As DB = New DB
        Dim _SQL As String = "SELECT * FROM CuringRun WHERE Status = 0 AND MachCuring = '" & _Mach & "'"
        Dim Dt As DataTable = DB.SelectSQL(_SQL, "DataCuring")
        Dim ItemRead As String = String.Empty
        If Dt.Rows.Count > 0 Then
            ItemRead = Dt.Rows(0).Item("Item")
            If ItemRead <> Item Then
                Dim _SEQ As Integer = Dt.Rows(0).Item("SEQ")
                _SQL = "UPDATE CuringRun SET Status = 1 WHERE SEQ = " & _SEQ
                DB.ExecuteSQL(_SQL, "DataCuring")
                ItemRead = String.Empty
            End If
        End If
        If ItemRead = String.Empty Then
            _SQL = "INSERT INTO CuringRun (Barcode, Size, Spec, CreateDate, Status, MachCuring, Item, UPDATEDATE, Mold) VALUES ('" & Barcode & "', '" & Size & "', '" & Spec & "', GETDATE(), 0, '" & _Mach & "', '" & Item & "', GETDATE(), '" & Mold & "')"
            DB.ExecuteSQL(_SQL, "DataCuring")
        End If
    End Sub

    Public Sub UpdateDate(ByVal _Mach As String)
        Dim DB As DB = New DB
        Dim _SQL As String = "SELECT * FROM CuringRun WHERE Status = 0 AND MachCuring = '" & _Mach & "'"
        Dim Dt As DataTable = DB.SelectSQL(_SQL, "DataCuring")
        If Dt.Rows.Count > 0 Then
            Dim _SEQ As Integer = Dt.Rows(0).Item("SEQ")
            _SQL = "UPDATE CuringRun SET UpdateDate = GETDATE() WHERE SEQ = " & _SEQ
            DB.ExecuteSQL(_SQL, "DataCuring")
        End If
    End Sub

    'Public Sub UpdateMore(ByVal _Mach As String)
    '    Dim DB As DB = New DB
    '    Dim _SQL As String = "SELECT * FROM CuringRun WHERE Status = 0 AND MachCuring = '" & _Mach & "'"
    '    Dim Dt As DataTable = DB.SelectSQL(_SQL, "DataCuring")
    '    If Dt.Rows.Count > 0 Then
    '        Dim DateCuring As DateTime = Dt.Rows(0).Item("UpdateDate")
    '        Dim MoreMin As Integer = DateDiff(DateInterval.Minute, DateCuring, Now)
    '        If MoreMin > 30 Then
    '            Dim _SEQ As Integer = Dt.Rows(0).Item("SEQ")
    '            _SQL = "UPDATE CuringRun SET Status = 1 WHERE SEQ = " & _SEQ
    '            DB.ExecuteSQL(_SQL, "DataCuring")
    '        End If
    '    End If
    'End Sub

    Public Function GetData1(ByVal BARCODE As String) As DataTable
        Dim DB As DB = New DB
        Dim _SQL As String = "SELECT SPEC_KIND, YEARS FROM BARCODE_DATA_ALL WHERE BARCODE = '" & BARCODE & "'"
        Dim DtAll As DataTable = DB.SelectSQL(_SQL, "Tracking")
        If DtAll.Rows.Count > 0 Then
            Dim _tb As String = "BARCODE_DATA1_" & DtAll.Rows(0).Item("SPEC_KIND").ToString & "_" & DtAll.Rows(0).Item("YEARS").ToString
            _SQL = "SELECT TOP 1 SPEC, SPEC_NO, GREEN_PART_NO FROM " & _tb & " WHERE BARCODE = '" & BARCODE & "' ORDER BY UPDATE_TIME DESC"
            Dim DtData1 As DataTable = DB.SelectSQL(_SQL, "Tracking")
            Return DtData1
        Else
            Return DtAll
        End If
    End Function

    Public Function InsertLog(ByVal Barcode As String, ByVal Remark As String) As Boolean
        Dim DB As DB = New DB
        Dim _SQL As String = "INSERT INTO LogNG (Barcode, Remark, CreateDate) VALUES ('" & Barcode & "', '" & Remark & "', GETDATE())"
        Return DB.ExecuteSQL(_SQL, "DataCuring")
    End Function

End Class
