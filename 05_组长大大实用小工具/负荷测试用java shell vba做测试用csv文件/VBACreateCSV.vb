Sub GenerateAndExportCSV()
    Dim ws As Worksheet
    Dim i As Long
    Dim numRows As Long
    Dim filePath As String
    
    ' 设置要填充数据的工作表
    Set ws = ActiveWorkbook.Sheets("Sheet1")
    
    ' 设置要生成的行数
    numRows = 40000
    
    ' 设置CSV文件保存路径
    filePath = "C:\Temp\lib\Test_data2.csv" ' 替换为你想要保存的文件路径
    
    ' 清空工作表的内容
    ws.UsedRange.Clear
    
    ' 在第一行创建表头
    ws.Cells(1, 1).Value = "列1"
    ws.Cells(1, 2).Value = "列2"
    ' 继续为每一列添加表头
    
    ' 从第二行开始生成数据
    For i = 2 To numRows + 1
        ws.Cells(i, 1).Value = Chr(34) & 数据 & i - 1 & Chr(34)
        ws.Cells(i, 2).Value = Chr(34) & 数据 & i - 1 & Chr(34)
        ' 继续为每一列添加数据
    Next i
    
    ' 保存工作表数据为CSV文件
    'ws.SaveAs filePath, xlCSV
    
    ' 关闭工作表
    'ws.Parent.Close False
End Sub
