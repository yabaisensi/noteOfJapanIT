@echo off
git log -1 | findstr version > tb
FOR /F "tokens=9" %%g IN (tb) do (
SET v_num=%%g
SET /a v_num+=1
)
del tb
echo  %v_num%
git add .
git commit -m "Saved on %date% %time% by xu version %v_num%"
git push
git log -5
pause