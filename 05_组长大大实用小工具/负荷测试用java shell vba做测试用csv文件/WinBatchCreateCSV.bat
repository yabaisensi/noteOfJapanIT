@echo off
setlocal enabledelayedexpansion
REM 设置要生成的行数
set rows=40000

REM 创建CSV文件并写入标题行
echo "Column1","Column2","Column3">output.csv

REM 生成随机数据并写入CSV文件
for /l %%i in (1, 1, %rows%) do (
    set "col1=data1_%%i"
    set "col2=data2_%%i"
    set "col3=data3_%%i"
    echo "!col1!","!col2!","!col3!" >> output.csv
)
pause
endlocal
