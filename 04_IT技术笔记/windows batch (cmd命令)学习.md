设备管理器 devmgmt.msc

```cmd
rem 创建快捷方式
mklink /J "C:\Users\Administrator\Desktop\ttt\01github仓库1" "C:\Users\Administrator\Desktop\01github仓库"
```



当cmd  cd进入某个路径的时候，这个文件夹就被占用了，无法被删除

---------start------------

##### 结束进程

find port 

netstat -ano|findstr "PID :5432"

kill process on port

taskkill /pid 18264 /f
-----------end------------

ls file_path/     横向展示文件
ls file_path/ -1  竖直展示文件

vi file_name      编辑文本文件

cd ../ 回退一层文件夹
shutdown -r -t 0 立即重启系统
shutdown -h 睡眠 
shutdown -s -t 0 立即关机

windows快捷键：（
win + E 打开资源管理器
win + D 显示桌面
win + L 锁屏
win + 方向键 分屏
Ctrl + W 关闭当前窗口
Ctrl + Shift + Del 调出缓存清除窗口
Shift + Del 彻底删除文件
win + Shift + S 调出屏幕截图窗口
Alt + Esc 在未最小化的窗口之间切换
Alt + Tab 在窗口之间切换
win + Tab 新开一个桌面
win + X 相当于右键点击win图标
win + + 缩小屏幕
win + - 放大屏幕
win + I 打开设置
shift + F10 相当于单击右键
Alt + space，C 关闭窗口
Alt + space, M 移动窗口
Alt + space, S 调整窗口大小
Alt + space, N 最小化窗口
Alt + space, X 最大化窗口
win + Q 查找框查找
win + S 查找框查找
win + W 屏幕截图相关 调出工具
win + R 运行
win + T 定位到程序栏
win + U 显示器设置
win + P 投影相关
win + A 通知
win + F 反馈
win + G Xbox
win + H 语音输入
win + K 设备连接
win + ; windows表情符
win + C corna
win + V 剪贴板
win + B 定位到任务栏
win + M 最小化所有窗口
win + , 暂时显示桌面
win + . windows表情符
win + Pause 显示系统·信息
）

rmdir 删除文件夹
del 删除文件
del /f /q 强制删除文件无确认提示

**22:12 2023/1/1**

dir /ad 只显示所有文件夹
dir /ah 只显示所有隐藏文件
dir /ar 只显示所有可读

notepad 打开记事本   ps( notepad里面的快捷键 ：ctrl + g 跳转指定行   F5 时间戳   ctrl + e 用必应搜选中的内容)
type nul> file_name 创建空文件
notepad file_name 用记事本打开文件

**2023年1月2日**

##### 分割字符串

```powershell
echo %temp%
set v_num=%temp:*version =%
echo %v_num%
```

##### 开启延迟变量赋值

setlocal enabledelayedexpansion

**2023年1月4日**

lusrmgr.msc 开启本地用户和组

net user administrator /active:yes 给与管理者权限

rmdir /S /Q  强制删除文件夹

自动保存文件的bat脚本

```cmd
echo %date% %time% > temp_d
type temp_d
for /f "tokens=1,2,3 delims=/" %%a in (temp_d) do @echo %%a%%b%%c>temp_l
type temp_l
for /f "tokens=1,2,3 delims=:" %%a in (temp_l) do @echo %%a%%b%%c>temp_k
type temp_k
for /f "tokens=1 delims=." %%a in (temp_k) do @echo %%a>temp_o
type temp_o
for /f "tokens=1,2,3" %%a in (temp_o) do @echo %%a_%%b_%%c>temp_p
type temp_p
set /P dstr=<temp_p
setlocal enabledelayexpansion
for /f "tokens=1" %%a in (temp_l) do @echo %%a>temp_z
type temp_z
set /p tstr=<temp_z
mkdir "myself_file_bak\%dstr%"
xcopy /E /Y myself_file "myself_file_bak\%dstr%"
set /a rstr=%tstr%-1
dir myself_file_bak  | findstr /c:%tstr% /c:%rstr%
del temp_d temp_l temp_k temp_o temp_p temp_z
dir "myself_file_bak\%dstr%"
pause
```

#### 2023年1月8日

date /t 查看时间

shortcut 启动慢  1.关掉SysMain的服务 2.打开设置

prompt str$g 用str替换cd的路径

prompt  退出str 用cd路径

```
prompt 可用功能符
$g > 不等号
$l < 
$q = 等号
$$ $ 美元符
$t 现在的时刻
$d 现在的日期
$p 现在的驱动或者路径
$v windows版本号
$n 现在的驱动
$_ 换行
```

F7 查看历史命令 F9 输入命令编号 执行命令

Alt + F7 清除历史命令

doskey v=ver 给指令取别名

ver 显示系统版本

#### 2023年1月9日

ctrl ← /ctrl → 向左或向右移一个单词

alt space 调出窗口操作

alt enter 全画面

ctrl ↑ /ctrl ↓ 移动窗口定位

建议编辑模式 

help | more 只显示一页

文件名最长255字节

path最长259字节

dir /w 横排列 dir /b 竖排列

dir /a:d   d文件夹  r只读文件 h隐藏文件 a压缩文件 s系统文件 -d不显示文件夹  -r不显示。。。  -h -a -s

dir /ad 同上 :可省略  

dir /a:d /o:-s   n按名字升序 -n降序  s大小升序 -s降序   e扩展名升序 -e降序  d从旧到新排列 -d降序  g按组排序 -g

dir /o:ge

#### 2023年1月29日

rem 和 : 一样都是.bat的注解

shift 让.bat文件 所有外部参数往前挪一位 

本来%1-%9 最多使用到9个  用shift 一位一位往前挪 可以用10个以上的参数

#### 2023年2月13日

set v_num=%temp:*version =% win bat 往一个变量里面取出一部分赋给另一个变量

attrib +h "file name"  /s /d  修改文件夹为隐藏文件夹

attrib -h "file name"  /s /d  修改文件夹为不隐藏文件夹

/s 为 遍历文件夹

/d 为 只适用于文件夹

#### 2023年2月18日

fc file1 file2 比较两个文件的文本差异

chcp 65001  cmd命令窗更改为UTF-8编码

#### 2023年2月21日

findstr /s /m /l /c:"JST" "C:\Users\Administrator\Desktop\noteOfJapanIT\*.md" 寻找指定字符串在哪个文件

#### 2023年2月27日

```cmd
// 修改文件夹内所有文件名的batch
cd img
set /a Index=1

setlocal enabledelayedexpansion

for /r %%i in (*.*) do ( 
    rename "%%i" "wuzhi!Index!.jpg"
    set /a Index+=1
)

dir 
pause
```

#### 2023年3月3日

`break>test.txt` 清空文件内容

```
type nul > demo.txt
copy /y nul demo.txt
```

```cmd
::去重复行的batch文件
@echo off
setlocal ENABLEDELAYEDEXPANSION
set RESULT=
type nul>output.txt
for /f "tokens=* delims=" %%a in (input.txt) do (
  set RESULT=%%a
  findstr /ixc:"!RESULT:"=\"!" output.txt || >>output.txt echo.%%a
)
pause
```

```cmd
@echo off
setlocal EnableDelayedExpansion

set "infile=in.txt"
set "outfile=out.txt"
type nul > "%outfile%"

for /f "usebackq tokens=*" %%a in ("%infile%") do (
    set "line=%%a"
    rem 去掉空格和制表符
    set "line=!line: =!"
    set "line=!line:  =!"
    set "line=!line:      =!"
    rem 判断是否是空行或者已经存在于输出文件中的行
    if not "!line!"=="" (
        findstr /x /c:"!line!" "%outfile%" >nul || (
            echo !line!>> "%outfile%"
        )
    )
)
```

#### 2023年4月19日

几种编码

GBK 936

SJIS 932

ascii 20127

euc-jp 51932

utf-8 65001


7月5日
dir /b 只显示当前文件夹内文件名字

set /p selnum=
设置变量为控制台输入的数

if selnum EQU '' do (
explorer ''
)

#### 2023年7月10日

抽出当前目录的所有文件路径，写到文件里

```cmd
dir /s > file.txt
```

#### 2023年7月24日

regedit /e c:\regedit.txt  抽出注册表



(Get-FileHash SRV2003.zip -Algorithm MD5).Hash >> 1.txt



