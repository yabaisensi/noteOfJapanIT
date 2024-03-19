@echo off
set "CLSPATH=C:¥ProjectName¥src¥main¥java¥"
set "MVNPATH=C:users¥myAccount¥.m2¥repository"

javac -cp "%MVNPATH%junit\junit\4.13.2.jar;%MVNPATH%org\mockito\mockito-core-4.2.0.jar" %CLSPATH%com\xxx\controller\AnswerTest.java %CLSPATH%com\xxx\controller\ClassA.java %CLSPATH%com\xxx\controller\ClassB.java
java -javaagent:%MVNPATH%net\bytebuddy\byte-buddy-agent\1.12.18\byte-buddy-agent.1.12.18.jar -cp "%MVNPATH%junit\junit\4.13.2.jar;%MVNPATH%org\mockito\mockito-core\4.2.0\mockito-core-4.2.0.jar;%MVNPATH%org\hamcrest\hamcrest-core\1.3\hamcrest-core-1.3.jar;%MVNPATH%org\mockito\mockito-inline-4.2.0.jar;%MVNPAHT%net\bytebuddy\1.12.18\byte-buddy-1.12.18.jar;%CLSPATH%." com.xxx.controller.TestRunner
pause
