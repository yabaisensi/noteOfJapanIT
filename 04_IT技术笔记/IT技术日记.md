#### 2022年9月7日

- 学习笔记仓库
https://github.com/yabaisensi/NoteOfJapanIT.git

- Object类有Object()、getClass()、hashCode()、equals()、clone()、toString()、notify()、notifyAll()、wait(long)、wait(long,int)、wait()、finalize()共十二个方法。

- git pull 其实就是 git fetch 和 git merge FETCH_HEAD 的简写。
- git reset --hard origin/bs005 重置本地代码为远程bs005分支的head版本

- postgreSQL 相关
    - select now()  -> with timezone
    - select now()::timestamp -> without timezone 

- xml文件 sql语句全设置字符串的表达形式（避免歧义）

\<![CDATA[

]]>

- like用法 postgreSQL版

SELECT
  name
FROM
  users
WHERE
  name LIKE '%' || #{keyword} || '%'

前端学好三件套 html css js
在此之上学一门js框架如 angular react vue

好好管理变量的内存分配 尽量避免出现空指针异常。

#### 2022年9月13日

要件定义 然后伦理设计 然后物理设计到PG到UT到结合测试
这个现场伦理设计就包含了基本设计和机能设计

'${@company.common.core.constant.ClsConst$AccountLockExistFg@ON}'

#### 2023年1月11日

e.printStackTrace();


java 8 stream流，是处理集合的方法。对集合进行筛选，排序，聚合等操作。

#### 2023年2月26日

elipse Maven选web的包

“**maven-archetype-webapp**“. Select “**org.apache.maven.archetypes**

```
java 编译版本
　<properties>
    <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
    <java.version>1.8</java.version>
    <maven.compiler.source>${java.version}</maven.compiler.source>
    <maven.compiler.target>${java.version}</maven.compiler.target>
  </properties>
```

问题

pom.xml第一行   meta-inf manifest.mf (指定されたパスが見つかりません。)

解决方法

maven 更新

#### 2023年2月27日

配系统变量的时候 把变量加进系统变量里的作用是

直接用 %变量名% 可以直接使用 用来cd 等任何命令 

比如 cd %JAVA_HOME%

typora  使用 

```
​```js 按下回车就可以创建js语言的代码块
```

 