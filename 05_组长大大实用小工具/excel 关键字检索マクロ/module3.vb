Option Explicit

'****************************************************************
'ブック一覧削除
'****************************************************************
Public Function BOOK_LIST_CLEAR()
    Dim sht As Excel.Worksheet
    Set sht = ThisWorkbook.Sheets("対象ブック")
    
    Dim nRow As Long
    nRow = 20
    
    While sht.Cells(nRow, 1).Value <> "" Or _
          sht.Cells(nRow, 2).Value <> ""
        nRow = nRow + 1
    Wend
    
    sht.Range("20:" & CStr(nRow)).Delete
End Function


