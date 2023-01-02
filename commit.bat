@echo off
git log -20 | findstr version > temp.txt 
set /p  temp=<temp.txt 
echo %temp%
set v_num=%temp:*version =%
SET /a v_num+=1
echo %v_num%
pause
del temp.txt
git add .
git commit -m "Saved on %date% %time% by xu version %v_num%"
git push
git lg1
git reset --soft head~1
pause