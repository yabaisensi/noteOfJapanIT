Option Explicit

Dim gFSO As New Scripting.FileSystemObject

'****************************************************************
'BOOK_LIST
'  BOOKにより作成されたファイルの一覧を取得する
'****************************************************************
Public Sub BOOK_LIST()
    Dim sht As Excel.Worksheet
    Set sht = ThisWorkbook.Sheets("対象ブック")
    
    Dim strDir As String
    strDir = sht.Range("D8").Value
    
    Dim subFlg As Integer
    subFlg = 0
    If (sht.Range("D5").Value = "ON") Then
        subFlg = 1
    End If
        
    Dim nRow As Long
    nRow = 20
    While sht.Cells(nRow, 1).Value <> "" Or _
          sht.Cells(nRow, 2).Value <> ""
        nRow = nRow + 1
    Wend
    
    Call SCREEN_UP_CONTROLL(False)
    Call GetBook(sht, nRow, strDir, subFlg)
    Call SCREEN_UP_CONTROLL(True)
End Sub

Private Function GetBook(ByRef sht As Excel.Worksheet, ByRef nRow As Long, wkDir As String, wkSubFlg As Integer)
    GetBook = False
    Application.StatusBar = ""
    
    Dim objFolder As Scripting.Folder
    Set objFolder = gFSO.GetFolder(wkDir)
    
    Dim objFile As Scripting.File
    For Each objFile In objFolder.Files
        Application.StatusBar = objFile.Path
        If InStr(objFile.Name, ".xls") > 0 Then
            sht.Cells(nRow, 1).Value = "○"
            sht.Cells(nRow, 2).Value = objFile.Path
            nRow = nRow + 1
        End If
    Next
    
    If wkSubFlg = 1 Then
        Dim objSubFolder As Scripting.Folder
        For Each objSubFolder In objFolder.SubFolders
            Dim sFolderName As String
            sFolderName = LCase(objSubFolder.Name)
            
            Select Case sFolderName
            Case ".svn"
                ' NOP
            Case "bak", "@bak", "_bak"
                ' NOP
            Case "old", "@old", "_old"
                ' NOP
            Case "tmp", "@tmp", "_tmp"
                ' NOP
            Case Else
                Call GetBook(sht, nRow, objSubFolder.Path, wkSubFlg)
            End Select
        Next
    End If
    
    Application.StatusBar = ""
    GetBook = True
End Function


