@echo off
chcp 65001
echo please enter the svn file path 
set /p tmps=
set st1=call C:\Users\Administrator\Desktop\sss\新しいフォルダーwc\新幹線\ttt.bat %tmps%
chcp 932
for /f "tokens=*" %%a in ( 
'%st1%' 
) do ( 
set mystr=%%a
) 
cd "C:\Users\Administrator\Documents\pleiades-2021-12-java-win-64bit-jre_20220106\pleiades\workspace\student_crud\student-crud\src\main\java\com\qizegao\controller"
javac Main.java
java Main %mystr% | clip
echo clip completed!!!
pause