Imports Utility
Public Class PL_Load
    Dim uscMach() As MachCuring
    Dim AllMach As Integer
    Dim StMach As Integer
    Private Sub PL_Load_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim cmd() As String = Split(Command, "-")
        Me.Text = "CuringMach " & cmd(0) & "-" & cmd(1)
        AllMach = cmd(1) - cmd(0) + 1   '720-701+1 = 20
        StMach = cmd(0) '701
        lbStart.Text = Now.ToString("yyyy-MM-dd hh:mm:ss")
        Config()
    End Sub

    Private Sub Config()
        Dim AtColNew As Integer = 10
        Dim AtCol As Integer = 10
        ReDim uscMach(AllMach - 1)
        Dim _c As Integer = 0
        For _r As Integer = 0 To uscMach.Length - 1
            uscMach(_r) = New MachCuring
            If _r = AtColNew Then
                _c += 1
                AtColNew += AtCol
            End If
            With uscMach(_r)
                .lbHead = StMach + _r
                .Location = New Point((Me.Width - .Width) - (_c * .Width) - (_c * 10) - 5, ((_r Mod AtCol) * .Height) + ((_r Mod AtCol) * 10) + 5)
            End With
            Me.Controls.Add(uscMach(_r))
        Next
    End Sub
End Class
