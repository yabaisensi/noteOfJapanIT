@echo off
set "CLSPATH=C:¥ProjectName¥src¥main¥java¥"
set "MVNPATH=C:users¥myAccount¥.m2¥repository"

javac -cp "%MVNPATH%junit\junit\4.13.2.jar;%MVNPATH%org\mockito\mockito-core-4.2.0.jar" %CLSPATH%com\xxx\controller\AnswerTest.java %CLSPATH%com\xxx\controller\ClassA.java %CLSPATH%com\xxx\controller\ClassB.java
java -javaagent:%MVNPATH%net\bytebuddy\byte-buddy-agent\1.12.18\byte-buddy-agent.1.12.18.jar -cp "%%"
