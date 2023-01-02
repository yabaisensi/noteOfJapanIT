@echo off
git log -1 | findstr version > tb
FOR /F "tokens=9" %%g IN (tb) do (
SET v_num=%%g
SET /a v_num+=1
)
echo  %v_num%
git add .
git commit -m "Save on %date% %time% by xu version %v_num%"
::git push
git log -5
::git reset --soft head~1
pause