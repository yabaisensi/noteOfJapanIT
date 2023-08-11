@echo off
cd C:\temp\03_tool\サーバーファイル一覧
rem get datetime string
set dstr1=%date%_%time%
for /F "tokens=1,2,3 delims=/" %%a in ("%dstr1%") do set "dstr2=%%a %%b %%c"
for /F "tokens=1,2,3 delims=:" %%a in ("%dstr2%") do set "dstr3=%%a %%b %%c"
for /F "tokens=1,2,3,4,5,6" %%a in ("%dstr3%") do set "dstr4=%%a%%b%%c%%d%%e%%f"
for /F "tokens=1 delims=." %%a in ("%dstr4%") do set "dstr5=%%a"
set "dstr=%dstr5%"

rem create file name
set "out_nm=%dstr%_all_path_d2.txt"

echo "output name : %out_nm%"
echo start to find d2 server files
rem run find command
dir C:\ /s /w  > "%out_nm%"
echo finish to find d2 server files
rem show output path
echo file path: %cd%\%out_nm%
pause

