@echo off
set dstr1=%date% %time%
for /F "tokens=1,2,3 delims=/" %%a in ("%dstr1%") do set "dstr2=%%a %%b %%c"
for /F "tokens=1,2,3 delims=:" %%a in ("%dstr2%") do set "dstr3=%%a %%b %%c"
for /F "tokens=1,2,3,4,5,6" %%a in ("%dstr3%") do set "dstr4=%%a%%b%%c %%d%%e%%f"
for /F "tokens=1 delims=." %%a in ("%dstr4%") do set "dstr5=%%a"
set "dstr=%dstr5%"
mkdir "bk\myfile_%dstr%_bk\"
xcopy /E /Y myfile "bk\myfile_%dstr%_bk\"
explorer "bk\myfile_%dstr%_bk\" 