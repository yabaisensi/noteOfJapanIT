---------start------------

##### 结束进程

find port 

netstat -ano|findstr "PID :5432"

kill proccess on port

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

