@echo off
set CURRENT_DIR="%~dp0"
cd %CURRENT_DIR%

set dstr1=%date% %time%
for /F "tokens=1,2,3 delims=/" %%a in ("%dstr1%") do set "dstr2=%%a%%b%%c"
for /F "tokens=1,2,3 delims=:" %%a in ("%dstr2%") do set "dstr3=%%a%%b%%c"
for /F "tokens=1 delims=." %%a in ("%dstr3%") do set "dstr4=%%a"
for /F "tokens=1,2,3 delims=." %%a in ("%dstr4%") do set "dstr5=%%a"
set "dstr=%dstr5%"

set MYFILE_PATH="myfile"
set MYFILE_BACK_PATH="myfile_bk\myfile_%dstr%_bk\"

mkdir %MYFILE_BACK_PATH%
xcopy /E /Y %MYFILE_PATH% %MYFILE_BACK_PATH%
explorer %MYFILE_BACK_PATH%
