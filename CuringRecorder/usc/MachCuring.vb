Imports Utility
Imports BLL
Imports ProEasyDotNet.ProEasy

Public Class MachCuring

#Region "Valiable"
    Public Property lbHead As String
        Get
            Return lbMach.Text
        End Get
        Set(value As String)
            lbMach.Text = value
        End Set
    End Property

    Structure DataGP
        Dim _Bit() As Short
        Dim _16() As Short
        Dim _32() As Integer
        Dim _Str As String
    End Structure

    Dim _Status As Boolean
    Dim DtAdr As DataTable
    Dim Mach As String
    Dim Barcode_Old_L As String
    Dim Barcode_Old_R As String
    Dim ItemOld As String
#End Region

#Region "Worker"
    Private Sub bw_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bw.DoWork
        Dim GP As DataGP = New DataGP
        SGP.BackColor = IIf(SGP.BackColor = Color.Gainsboro, Color.LimeGreen, Color.Gainsboro)
        Dim BLL_Load As BLL_Load = New BLL_Load
        '' Mold L
        pb.Value = GetRandom(1, 100)
        GP = ReadGP(Mach, DtAdr.Rows(0).Item("AdrBar_Mold_L"), 11, 4)
        Dim Barcode_L As String = GP._Str
        If Barcode_L <> Barcode_Old_L And Len(Barcode_L) = 11 Then
            Barcode_Old_L = Barcode_L
            Dim DtData1 As DataTable = BLL_Load.GetData1(Barcode_L)
            If DtData1.Rows.Count > 0 Then
                Dim Size As String = DtData1.Rows(0).Item("SPEC")
                Dim Spec As String = DtData1.Rows(0).Item("SPEC_NO")
                Dim Item As String = DtData1.Rows(0).Item("GREEN_PART_NO")
                If Item <> ItemOld Then
                    ItemOld = Item
                    BLL_Load.UpdateData(Barcode_L, Mach, Size, Spec, Item, "L")
                    lv.Items.Add(Item)
                End If
                BLL_Load.UpdateDate(Mach)
            Else
                BLL_Load.InsertLog(Barcode_L, "No BD")
                lv.Items.Clear()
                lv.Items.Add(Barcode_L & " NO BD")
            End If
        End If
        '' Mold R
        'GP = ReadGP(Mach, DtAdr.Rows(0).Item("AdrBar_Mold_R"), 11, 4)
        'Dim Barcode_R As String = GP._Str
        'If Barcode_R <> Barcode_Old_R And Len(Barcode_R) = 11 Then
        '    Barcode_Old_R = Barcode_R
        '    Dim DtData1 As DataTable = BLL_Load.GetData1(Barcode_R)
        '    If DtData1.Rows.Count > 0 Then
        '        Dim Size As String = DtData1.Rows(0).Item("SPEC")
        '        Dim Spec As String = DtData1.Rows(0).Item("SPEC_NO")
        '        Dim Item As String = DtData1.Rows(0).Item("GREEN_PART_NO")
        '        If Item <> ItemOld Then
        '            ItemOld = Item
        '            BLL_Load.UpdateData(Barcode_R, Mach, Size, Spec, Item, "R")
        '            lv.Items.Add(Item)
        '        End If
        '        BLL_Load.UpdateDate(Mach)
        '    Else
        '        BLL_Load.InsertLog(Barcode_R, "No BD")
        '        lv.Items.Clear()
        '        lv.Items.Add(Barcode_R & " NO BD")
        '    End If
        'End If
        '' More
        'BLL_Load.UpdateMore(Mach)
        '' End 
        Threading.Thread.Sleep(100)
        GC.Collect()
    End Sub

    Private Sub bw_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw.RunWorkerCompleted
        If _Status Then
            bw.RunWorkerAsync()
        Else
            SGP.BackColor = Color.Crimson
        End If
    End Sub

    ' ''' <summary>
    ' ''' 1 = Bit, 2 = 16Bit, 3 = 32Bit, 4 = String
    ' ''' </summary>
    ' ''' <param name="_Node"></param>
    ' ''' <param name="Adr"></param>
    ' ''' <param name="wCount"></param>
    ' ''' <param name="wType"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    Private Function ReadGP(ByVal _Node As String, ByVal Adr As String, ByVal wCount As Integer, ByVal wType As Integer) As DataGP
        Dim hPro As System.IntPtr
        hPro = ProEasyDotNet.ProEasy.CreateProServerHandle
        Dim Err As Integer = 0
        Dim Data As DataGP = New DataGP
        ReDim Data._Bit(wCount - 1)
        ReDim Data._16(wCount - 1)
        ReDim Data._32(wCount - 1)
        Dim DataStr As System.Text.StringBuilder = Nothing
        If wType = 1 Then
            Err = ReadDeviceBitM(hPro, _Node, Adr, Data._Bit, wCount)
        ElseIf wType = 2 Then
            Err = ReadDevice16M(hPro, _Node, Adr, Data._16, wCount)
        ElseIf wType = 3 Then
            Err = ReadDevice32M(hPro, _Node, Adr, Data._32, wCount)
        ElseIf wType = 4 Then
            Err = ReadDeviceStrM(hPro, _Node, Adr, DataStr, wCount)
            Data._Str = DataStr.ToString
        End If
        If Err <> 0 Then
            lv.Items.Clear()
            lv.Items.Add("Error read " & Adr)
        End If
        ProEasyDotNet.ProEasy.DeleteProServerHandle(hPro)
        Return Data
    End Function

#End Region

#Region "Tool Box"
    Private Sub MachCuring_Load(sender As Object, e As EventArgs) Handles Me.Load
        Control.CheckForIllegalCrossThreadCalls = False
        _Status = True
        Barcode_Old_L = String.Empty
        Barcode_Old_R = String.Empty
        ItemOld = String.Empty
        Mach = "C" & lbMach.Text
        Dim BLL_Load As BLL_Load = New BLL_Load
        DtAdr = BLL_Load.GetAdr(lbMach.Text)
        If DtAdr.Rows.Count > 0 Then
            bw.RunWorkerAsync()
        End If
    End Sub

    Private Sub btStatus_Click(sender As Object, e As EventArgs) Handles btStatus.Click
        If _Status Then
            _Status = False
            btStatus.BackgroundImage = My.Resources.play
        Else
            _Status = True
            btStatus.BackgroundImage = My.Resources.player_stop
            MachCuring_Load(sender, e)
        End If
    End Sub
#End Region

    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Dim Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function

End Class
