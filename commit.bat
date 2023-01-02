@echo off
git log -1 | findstr version > temp.txt
FOR /F "tokens=9" %%g IN (temp.txt) do (
SET v_num=%%g
SET /a v_num+=1
)
del temp.txt
echo  %v_num%
git add .
git commit -m "Saved on %date% %time% by xu version %v_num%"
git push
git lg1
pause