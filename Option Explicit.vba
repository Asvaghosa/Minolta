Option Explicit
Sub ColorScatterPoints()
    Dim cht As Chart
    Dim srs As Series
    Dim pt As Point
    Dim p As Long
    Dim Vals$, lTrim#, rTrim#
    Dim valRange As Range, cl As Range
    Dim myColor As Long

    Set cht = ActiveSheet.ChartObjects(1).Chart
    Set srs = cht.SeriesCollection(1)
    
    
   '## Get the series Y-Values range address:
    lTrim = InStrRev(srs.Formula, ",", InStrRev(srs.Formula, ",") - 1, vbBinaryCompare) + 1
    rTrim = InStrRev(srs.Formula, ",")
    Vals = Mid(srs.Formula, lTrim, rTrim - lTrim)
    Set valRange = Range(Vals)
    Set srs = cht.SeriesCollection(4)
    For p = 1 To srs.Points.Count
        Set pt = srs.Points(p)
        Set cl = valRange(p).Offset(0, -4) '## assume color is in the next column.
        Select Case cl
                Case "White a*"
                    myColor = RGB(255, 255, 255)
                Case "Red a*"
                    myColor = RGB(255, 0, 0)
                Case "Green a*"
                    myColor = RGB(0, 255, 0)
                Case "Blue a*"
                    myColor = RGB(0, 176, 240)
                Case "Orange a*"
                    myColor = RGB(255, 192, 0)
                Case "Yellow a*"
                    myColor = RGB(200, 200, 0)
                Case "Black a*"
                    myColor = RGB(0, 0, 0)
        End Select
        With pt.Format.Fill
            .Visible = msoTrue
            '.Solid  'I commented this out, but you can un-comment and it should still work
            '## Assign Long color value based on the cell value
            '## Add additional cases as needed.
            .ForeColor.RGB = myColor
        End With
        
        pt.MarkerForegroundColor = myColor
        If cl = "White a*" Then pt.MarkerForegroundColor = RGB(0, 0, 0)
    Next

End Sub

