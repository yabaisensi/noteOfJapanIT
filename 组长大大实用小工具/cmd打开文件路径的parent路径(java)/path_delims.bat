@echo off
REM 自己修改java类的路径（package之前的路径）
set CLASSPATH=C:\Users\Administrator\Documents\pleiades-2021-12-java-win-64bit-jre_20220106\pleiades\workspace\YDemo\src\main\java
cd %CLASSPATH%
javac test\Test.java
cls
java  test.Test
