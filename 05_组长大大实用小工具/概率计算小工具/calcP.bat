@echo off
rem java -cp C:\pleiades\workspace\yabai\bin\yUtils yUtils\CalProbability 6 6 0.166666666
rem cd C:\pleiades\workspace\yabai\bin\
setlocal enabledelayedexpansion

set "file=in3p.txt"
set "lineNumber=0"
set "content="

for /f "usebackq delims=" %%i in ("%file%") do (
    set /a "lineNumber+=1"
    if !lineNumber! equ 2 (
        set "PRA1=%%i"
    )
    if !lineNumber! equ 4 (
        set "PRA2=%%i"
    )
    if !lineNumber! equ 6 (
        set "PRA3=%%i"
    )
)

java -cp C:\pleiades\workspace\yabai\bin yUtils.CalProbability %PRA1% %PRA2% %PRA3%
pause
