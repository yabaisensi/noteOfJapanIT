Sub CollapseCode()
    Dim cell As Range
    Dim startRow As Long
    Dim endRow As Long
    Dim depth As Integer
    Dim startRowArray() As Integer
    ReDim startRowArray(1 To 10)
    
    depth = 0
    'ActiveSheet.UsedRange.Select
    For Each cell In ActiveSheet.UsedRange.Cells
      If Not IsEmpty(cell.Value) Then
        If (InStr(cell.Value, "}")) > 0 Then
          endRow = cell.Row
          Rows((startRowArray(depth) + 1) & ":" & (endRow - 1)).Group
          depth = depth - 1
          Rows(cell.Row).Interior.Color = RGB(125, 255, 245)
        End If
        
        If (InStr(cell.Value, "{")) > 0 Then
          startRow = cell.Row
          depth = depth + 1
          startRowArray(depth) = startRow
          Rows(cell.Row).Interior.Color = RGB(189, 255, 189)
        End If
      End If
    Next cell
End Sub
