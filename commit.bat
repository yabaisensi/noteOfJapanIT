@echo off
git log -20 | findstr version > temp.txt 
set /p  temp=<temp.txt 
set v_num=%temp:*version =%
SET /a v_num+=1
del temp.txt
git add .
git commit -m "Saved on %date% %time% by xu version %v_num%"
git push
git lg1
pause