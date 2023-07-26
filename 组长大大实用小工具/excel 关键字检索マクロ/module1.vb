Option Explicit

Const START_ROW = 20
Const START_ROW_LOG = 2

Const COLOR_RED = -16776961 '赤
'****************************************************************
'複数ブック内の検索マクロ（対象：セルとオブジェクト）
'****************************************************************
Sub main()
    Dim cInputKeys As Collection
    Dim rInputKeys As Excel.Range
    Dim likeKey() As String, key() As String
    Dim iRow As Long, iLog As Long
    Dim sPath As String
    Dim lastRow As Long, lastCol As Long
    Dim j As Long, i As Long, m As Long, n As Long, x As Long
    Dim targetSheet As Excel.Worksheet
    Dim targetRange As Variant
    Dim targetValue As String
    Dim targetCell As String
    Dim rowRow As Long
    Dim rowCol As Long
    Dim targetCount As Long
    Dim sp As Excel.Shapes, txt As String
    Dim objectSearchFlag As String
    Dim bFound As Boolean
    
    Dim sht As Excel.Worksheet
    Set sht = ThisWorkbook.Worksheets("対象ブック")
    
    'ONOFFフラグ
    objectSearchFlag = sht.Range("B5").Value
    
    '検索キー
    Set cInputKeys = New Collection
    For Each rInputKeys In sht.Range("B8:B17")
        If rInputKeys.Value <> "" Then
            cInputKeys.Add rInputKeys.Value
        End If
    Next
    
    '検索文字の大文字、全角化
    ReDim likeKey(1 To cInputKeys.Count)
    ReDim key(1 To cInputKeys.Count)
    
    Dim k As Integer
    For k = 1 To cInputKeys.Count
        'セル用検索文字
        likeKey(k) = "*" & StrConv(cInputKeys(k), vbWide + vbUpperCase) & "*"
        
        'オブジェクト内用検索文字
        key(k) = StrConv(cInputKeys(k), vbWide + vbUpperCase)
    Next
    
    '対象パス用行
    Dim nTotal As Integer
    nTotal = 0
    
    iRow = START_ROW
    While sht.Cells(iRow, 1).Value <> "" Or _
          sht.Cells(iRow, 2).Value <> ""
        nTotal = nTotal + 1
        iRow = iRow + 1
    Wend
    sht.Range("20:" & CStr(iRow)).Font.ColorIndex = xlColorIndexAutomatic
    
    '結果シート初期化
    Dim objSht As Excel.Worksheet
    Set objSht = ThisWorkbook.Worksheets("結果")
    objSht.Activate
    objSht.Cells(1, 1).Select
    
    '結果シート用の行カウンタ
    iLog = START_ROW_LOG
    While objSht.Cells(iLog, 1).Value <> ""
        iLog = iLog + 1
    Wend
    
    Dim nYesNo As Integer
    nYesNo = MsgBox("Excelブック内の検索を行います。" & vbLf & _
                    "対象ブック数：" & Format(nTotal, "#,##0") & "本" & vbLf & vbLf & _
                    "結果シートをクリアしますか？" & vbLf & _
                    "はい" & vbTab & "結果シートをクリアする" & vbLf & _
                    "いいえ" & vbTab & "クリアせずに追記する" & vbLf & _
                    "キャンセル" & vbTab & "検索を中止する", _
                    vbQuestion + vbYesNoCancel, _
                    "文字列検索")
    If nYesNo = vbCancel Then Exit Sub
    If nYesNo = vbYes Then
        With objSht
            'オートフィルタを解除
            If .AutoFilterMode Then .AutoFilterMode = False
            
            '全件削除
            .Range("2:" & CStr(.UsedRange.Rows.Count)).Delete shift:=xlShiftUp
            
            '結果シートのタイトルを設定
            .Cells(1, 1).Value = "ブック名"
            .Cells(1, 2).Value = "シート名"
            .Cells(1, 3).Value = "一致箇所"
            .Cells(1, 4).Value = "文字列"
            .Cells(1, 5).Value = "グループ内名称"
            .Cells(1, 6).Value = "パス"
            With .Range(.Cells(1, 1), .Cells(1, 6)).Borders(xlEdgeBottom)
                .LineStyle = XlLineStyle.xlContinuous
                .Weight = XlBorderWeight.xlThin
                .ColorIndex = XlColorIndex.xlColorIndexAutomatic
            End With
        End With
    End If
            
            
    '開始日時設定、終了に日時クリア
    sht.Activate
    sht.Range("D11").Value = Date + Time
    sht.Range("D13").Value = Empty
    
    Call SCREEN_UP_CONTROLL(False)
    Application.DisplayAlerts = False
    
    Dim nCount As Integer
    nCount = 0
    
    '対象ブックが無くなるまでループ（空白セルが存在したらループ終了）
    iRow = START_ROW
    While sht.Cells(iRow, 1).Value <> "" Or _
          sht.Cells(iRow, 2).Value <> ""
        
        nCount = nCount + 1
        sPath = sht.Cells(iRow, 2).Value
        
        Application.StatusBar = CStr(nCount) & "/" & CStr(nTotal) & " - " & sPath
        
        '対象○以外はスキップする
        If sht.Cells(iRow, 1).Value <> "○" Then GoTo SKIP_THIS_BOOK
        
        '読み取り専用で対象ブックを開く
        Dim objBook As Excel.Workbook
        Set objBook = Nothing
        
        On Error Resume Next
        Set objBook = Workbooks.Open(Filename:=sPath, ReadOnly:=True, UpdateLinks:=False)
        On Error GoTo 0
        
        If objBook Is Nothing Then
            sht.Cells(iRow, 2).Font.Color = COLOR_RED
            GoTo SKIP_THIS_BOOK
        End If
        
        'シート分処理を繰り返す
        For j = 1 To objBook.Sheets.Count
            Set targetSheet = objBook.Worksheets(j)
            
            objBook.Activate
            targetSheet.Activate
            
            'セル内検索
            targetRange = targetSheet.UsedRange
            targetCount = targetSheet.UsedRange.Count
            rowRow = targetSheet.UsedRange.Row - 1
            rowCol = targetSheet.UsedRange.Column - 1
            
            If targetCount = 1 Then
                targetValue = IIf(IsError(targetRange), "", targetRange)
                targetCell = Trim(targetValue)
                targetCell = Replace(targetCell, vbCr, "")
                targetCell = Replace(targetCell, vbLf, "")
                targetCell = StrConv(StrConv(targetCell, vbWide), vbUpperCase)
                bFound = False
                For k = LBound(likeKey) To UBound(likeKey)
                    If targetCell Like likeKey(k) Then bFound = True: Exit For
                Next
                If bFound = True Then
                    With objSht
                        .Cells(iLog, 1).Value = targetSheet.Parent.Name
                        .Cells(iLog, 2).Value = targetSheet.Name
                        .Cells(iLog, 3).Value = "行" & 1 + rowRow & " 列" & 1 + rowCol
                        .Cells(iLog, 4).Value = "'" & targetValue
                        .Cells(iLog, 5).Value = "-"
                        .Cells(iLog, 6).Value = sPath
                        .Hyperlinks.Add anchor:=.Cells(iLog, 1), _
                            Address:=sPath & "#'" & targetSheet.Name & "'!" & targetSheet.Cells(1, 1).Address, _
                            TextToDisplay:=targetSheet.Parent.Name
                    End With
                    iLog = iLog + 1
                End If
            Else
                '最大行までループ
                For m = 1 To UBound(targetRange, 1)
                    '最大行までループ
                    For n = 1 To UBound(targetRange, 2)
                        targetValue = IIf(IsError(targetRange(m, n)), "", targetRange(m, n))
                        targetCell = Trim(targetValue)
                        targetCell = Replace(targetCell, vbCr, "")
                        targetCell = Replace(targetCell, vbLf, "")
                        targetCell = StrConv(StrConv(targetCell, vbWide), vbUpperCase)
                        bFound = False
                        For k = LBound(likeKey) To UBound(likeKey)
                            If targetCell Like likeKey(k) Then bFound = True: Exit For
                        Next
                        If bFound = True Then
                            With objSht
                                .Cells(iLog, 1).Value = targetSheet.Parent.Name
                                .Cells(iLog, 2).Value = targetSheet.Name
                                .Cells(iLog, 3).Value = "行" & m + rowRow & " 列" & n + rowCol
                                .Cells(iLog, 4).Value = "'" & targetValue
                                .Cells(iLog, 5).Value = "-"
                                .Cells(iLog, 6).Value = sPath
                                .Hyperlinks.Add anchor:=.Cells(iLog, 1), _
                                    Address:=sPath & "#'" & targetSheet.Name & "'!" & targetSheet.Cells(m, n).Address, _
                                    TextToDisplay:=targetSheet.Parent.Name
                            End With
                            iLog = iLog + 1
                        End If
                    Next n
                Next m
            End If
            
            'オブジェクト内検索
            If objectSearchFlag = "ON" Then
                Set sp = targetSheet.Shapes
                For i = 1 To sp.Count
                    '単一オブジェクト用
                    If (sp.Item(i).Type = msoAutoShape Or sp.Item(i).Type = msoTextBox) Then
                        targetValue = ""
                        On Error Resume Next
                        targetValue = sp.Item(i).DrawingObject.Caption
                        On Error GoTo 0
                        txt = Trim(targetValue)
                        txt = Replace(txt, vbCr, "")
                        txt = Replace(txt, vbLf, "")
                        txt = StrConv(txt, vbWide + vbUpperCase)
                        If txt <> "" Then
                            bFound = False
                            For k = LBound(key) To UBound(key)
                                If InStr(txt, key(k)) > 0 Then bFound = True: Exit For
                            Next
                            If bFound = True Then
                                With objSht
                                    .Cells(iLog, 1).Value = targetSheet.Parent.Name
                                    .Cells(iLog, 2).Value = targetSheet.Name
                                    .Cells(iLog, 3).Value = sp.Item(i).Name
                                    .Cells(iLog, 4).Value = "'" & targetValue
                                    .Cells(iLog, 5).Value = "-"
                                    .Cells(iLog, 6).Value = sPath
                                    .Hyperlinks.Add anchor:=.Cells(iLog, 1), _
                                        Address:=sPath & "#'" & targetSheet.Name & "'!" & sp.Item(i).TopLeftCell.Address, _
                                        TextToDisplay:=targetSheet.Parent.Name
                                End With
                                iLog = iLog + 1
                            End If
                        End If
                    End If
                    
                    'グループ化しているオブジェクト用
                    If (sp.Item(i).Type = msoGroup) Then
                        For x = 1 To sp.Item(i).GroupItems.Count
                            targetValue = ""
                            On Error Resume Next
                            targetValue = sp.Item(i).GroupItems(x).AlternativeText
                            On Error GoTo 0
                            txt = Trim(targetValue)
                            txt = Replace(txt, vbCr, "")
                            txt = Replace(txt, vbLf, "")
                            txt = StrConv(txt, vbWide + vbUpperCase)
                            If txt <> "" Then
                                bFound = False
                                For k = LBound(key) To UBound(key)
                                    If InStr(txt, key(k)) > 0 Then bFound = True: Exit For
                                Next
                                If bFound = True Then
                                    With objSht
                                        .Cells(iLog, 1).Value = targetSheet.Parent.Name
                                        .Cells(iLog, 2).Value = targetSheet.Name
                                        .Cells(iLog, 3).Value = sp.Item(i).Name
                                        .Cells(iLog, 4).Value = "'" & targetValue
                                        .Cells(iLog, 5).Value = sp.Item(i).GroupItems(x).Name
                                        .Cells(iLog, 6).Value = sPath
                                        .Hyperlinks.Add anchor:=.Cells(iLog, 1), _
                                            Address:=sPath & "#'" & targetSheet.Name & "'!" & sp.Item(i).GroupItems(x).TopLeftCell.Address, _
                                            TextToDisplay:=targetSheet.Parent.Name
                                    End With
                                    iLog = iLog + 1
                                End If
                            End If
                        Next x
                    End If
                Next i
            End If
            
        Next j
        
        '保存せずに閉じる
        objBook.Saved = True
        objBook.Close
        
        sht.Cells(iRow, 1).Value = "済"

SKIP_THIS_BOOK:
        iRow = iRow + 1
    Wend
    Application.StatusBar = ""
    
    With objSht
        .Parent.Activate
        .Activate
        .Cells.Select
        .Cells.EntireColumn.AutoFit
        .Cells.EntireRow.AutoFit
        .Range("1:1").Select
        .Range("1:1").AutoFilter
        .Range("A1").Select
    End With
    
    '終了日時設定
    sht.Range("D13").Value = Date + Time
    
    Call SCREEN_UP_CONTROLL(True)
    
    Dim nLaps As Long
    nLaps = DateDiff("s", sht.Range("D11").Value, sht.Range("D13").Value)
    
    MsgBox "終了しました" & vbLf & _
            "検索結果：" & Format(iLog - 2, "#,##0") & "件" & vbLf & _
            "所要時間：" & Format(nLaps, "#,##0") & "秒", _
            vbInformation + vbOKOnly, _
            "文字列検索"
End Sub

Sub make_Summary()
    Const ORIGINAL_SHEET = "結果"
    Const SUMMARY_SHEET = "結果（サマリ）"
    
    Dim bFound As Boolean
    bFound = False
    
    Dim i As Integer
    For i = 1 To Worksheets.Count
        If Worksheets(i).Name = SUMMARY_SHEET Then
            bFound = True
            Exit For
        End If
    Next
    
    If bFound Then
        Dim nYesNo As Integer
        nYesNo = MsgBox("[" & SUMMARY_SHEET & "] シートがすでに存在しています。" & vbLf & _
                        "削除して続行してもよろしいですか？" & vbLf & _
                        "はい" & vbTab & "削除して続行" & vbLf & _
                        "いいえ" & vbTab & "処理を中断", _
                        vbQuestion + vbYesNo, SUMMARY_SHEET & "の作成")
        If nYesNo <> vbYes Then Exit Sub
        
        Dim bDisplayAlerts As Boolean
        bDisplayAlerts = Application.DisplayAlerts
        
        Application.DisplayAlerts = False
        
        Worksheets(SUMMARY_SHEET).Delete
        
        Application.DisplayAlerts = bDisplayAlerts
    End If
    
    
    Dim sht As Excel.Worksheet
    Set sht = Worksheets(ORIGINAL_SHEET)
    
    sht.Copy after:=sht
    
    Set sht = ActiveSheet
    sht.Name = SUMMARY_SHEET
    sht.Activate
    
    Dim nRow As Long
    nRow = 2
    
    While sht.Cells(nRow, 1).Value <> ""
        Dim nRowCount As Long
        nRowCount = 0
        While sht.Cells(nRow, 1).Value = sht.Cells(nRow + nRowCount, 1).Value And _
              sht.Cells(nRow, 6).Value = sht.Cells(nRow + nRowCount, 6).Value
            nRowCount = nRowCount + 1
        Wend
        
        sht.Rows(nRow).Insert shift:=XlInsertShiftDirection.xlShiftDown
        sht.Rows(nRow + 1).Copy Destination:=sht.Rows(nRow)
        sht.Cells(nRow, 2).Value = Empty
        sht.Cells(nRow, 3).Value = CStr(nRowCount) & "箇所"
        sht.Cells(nRow, 4).Value = Empty
        sht.Cells(nRow, 5).Value = Empty
        
        With sht.Range(CStr(nRow + 1) & ":" & CStr(nRow + nRowCount))
            .Group
            .Font.Color = &H808080
        End With
        
        nRow = nRow + nRowCount + 1
        DoEvents
    Wend
    
    sht.Outline.ShowLevels RowLevels:=1
    
    MsgBox "検索結果のサマリが終了しました", _
            vbInformation + vbOKOnly, SUMMARY_SHEET & "の作成"
End Sub






