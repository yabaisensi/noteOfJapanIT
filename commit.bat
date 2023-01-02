@echo off
git add .
v_num=$(git log -1 --format='%s' | grep -oP '(?<=version ).*')
v_num=$(($v_num+1))
git commit -m "Save on %date%-%time% by xu version $v_num"
::git push
pause