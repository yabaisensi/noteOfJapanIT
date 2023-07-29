# git 小工具

##### commit.bat

```cmd
REM 一个版本自动递增的bat脚本 第一版
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
git log -5
pause

```

```cmd
REM 一个版本自动递增的bat脚本 第二版
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
```

##### 好用的log format

alias别名的意思,用法 git lg1  或 git lg2

```properties
[alias]
        lg1 = !"git log --graph --oneline --raw --decorate=full -5 --date=short --format='%C(yellow)%h%C(reset) %C(magenta)[%ad]%C(reset)%C(auto)%d%C(reset) %C(brightred)%s%C(reset) %C(cyan)@%an%C(reset)'"
        lg2 = !"git log --oneline --raw --decorate=full -5 --date=short --format='%C(yellow)%h%C(reset) %C(auto)%d%C(reset)  %C(brightred)%s%C(reset)'"
```

