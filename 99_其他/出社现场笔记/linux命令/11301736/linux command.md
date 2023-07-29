2022年10月12日

- 清屏

`clear`

`Ctrl + L`

- cat 文件操作

`cat [-AbeEnstTuV] [--help] [--version] fileName `

> 把textfile1的文档内容加上行号后输入textfile2这个文档里

`cat textfile1 > textfile2`

> 把textfile1 和 textfile2 的文档内容加上行号后输入textfile3这个文档里

`cat textfile1 textfile2 >> textfile3`

> 显示带行号的内容，不显示空行

`cat -n textfile1` 

> 显示行号的内容，显示空行

`cat -b textfile1`

- 文件或文件夹重命名

`mv oldFileName newFileName`

- 创建文件

`touch fileName.md`

- 查看用户id

`whoami`

- 查看系统状态

`uptime`

`w`

- 进入vim编辑模式

`vim fileName`

- 退出vim编辑模式

`shift zz` （两个大写的Z）（保存退出） 或者 `:wq` 或者 `:q` 加叹号强制执行 `:wq!`

shift zq (ZQ) 不保存退出

---

2022年10月14日

- 光标左右移动

`Ctrl + A`     最左

`Ctrl + E`    最右

`Ctrl + B `   左

`Ctrl + F `   右

- 删除文字

`Ctrl + D`   删除光标中间的的内容

`Ctrl + H`   删除光标前面的内容

`Ctrl + U`   删除当前行光标左侧的所有文字

`Ctrl + K`   删除当前行光标右侧的所有文字

- 前一次删除的文字进行粘贴

`Ctrl + Y`   

- 停止命令

`Ctrl + C`

- 中断命令

`Ctrl + Z`  就是任务跑起来的过程中可以暂时停止命令

- 往jobs里面添加任务

`ping 1.1.1.1`

- 重开任务

`fg 任务号`

eval 执行变量

```
cat file

[] hello bit

myfile="cat file"

echo $myfile

[] cat file

eval $myfile

[] hello bit

eval $myfile相当于cat file

myfile 是变量
```

#### if else fi

```shell
if condition
then
	command1
	command2
	...
	commandN
fi
```

写成一行 (适用于终端命令提示符) :

`if [$(ps -ef | grep -c "ssh") -gt 1 ]; then echo "true"; fi`

#### if  else

```shell
if condition
then
	command1
	command2
	...
	commandN
else
	command
fi
```

if else-if else

```shell
if condition1
then
	command1
elif condition2
then
	command2
else
	commandN
fi
```

if else的[...]判断语句中大于使用-gt, 小于使用 -lt。

```shell
if[ "$a" -gt "$b" ]; then
	...
fi
```

如果使用((...))作为判断语句，大于和小于可以直接使用 > 和 <

```shell
if ((a > b)); then
	...
fi
```

####  if else 语句经常和test命令结合使用

```shell
num1 = $[2*3]
num2 = $[1+5]
if test $[num1] - eq $[num2]
then
	echo ’两个数字相等’
	echo '两个数字不相等'
```

#### for循环

```shell
for var in item1 item2 ... itemN
do 
	command1
	command2
	...
	commandN
done
```

写成一行

`for var in item1 item2 ... itemN; do command1; command2... done;`

```shell
# 当变量值在列表里，for 循环即执行一次所有命令。in列表可以包含替换，字符串和文件名
for loop in 1 2 3 4 5
do
	echo "The value is: $loop"
done
```

#### 无限循环

```shell
while :
do
	command
done
```

或者

```shell
while :
do 
	command
done
```

或者

```shell
for(( ; ; ))
```

#### until循环

```shell
until [ ! $a -lt 10]
do
	echo $a
	a=`expr $a + 1`
done
```

#### case ... esac

```shell
case 值 in
模式1)
	command1
	command2
	...
	commandN
	;;
模式2)
	command1
	command2
	...
	commandN
	;;
esac
```

```shell
# 实例
echo '输入1到4之间的数字:'
echo '你输入的数字为:'
read aNum
case $aNum in
	1) echo '你选择了 1'
	;;
	2) echo '你选择了 2'
	;;
	3) echo '你选择了 3'
	;;
	4) echo '你选择了 4'
	;;
	*) echo '你没有输入 1 到 4 之间的数字'
	;;
esac				
```

```shell
#!/bin/sh

```

2022年11月29日

whoami

date

pwd 显示当前所在路径

ls -l 显示文件权限等信息

ls -a 显示所有包含.开头的文件

ls -la 显示所有文件权限等信息

file banana.jpg 查看文件属性类型

cat 

:recover

vim -r birdfile

`> file_name` 清空一个文件

`less file_name`  部分显示文本内容 q 退出 g 开头 G文末 h帮助

```
SUMMARY OF LESS COMMANDS
^ represent ctrl
* can add number
---------------
MOVING
e ^E j ^N CR   *Forward one line (or N lines).
y ^Y k ^K ^P   *Backward one line ..
f ^F ^V SPACE  *Forward one window ..
b ^B ESC-v     *Backward one window ..
z 			   *Forward window (and set window to N).
w			   *Backward one window ..
ESC-SPACE	   *Forward one window, but don't stop at end-of-file.
d ^D 	       *Forward one half-window (and set half-window -to N).
u ^U		   *Backward one half-window ..
ESC-)  RightArrow  *Right one half screen width (or N positions).
ESC-(  LeftArrow   *Left one half screen width (or N positions).
ESC-}  ^RightArrow Right to last column displayed
ESC-{  ^LeftArrow  Left to first column.
F              Forward forever; like "tail -f"
ESC-F          Like F but stop when search pattern is found.
r ^R ^L        Repaint screen.
R              Repaint screen, discarding buffered input.
---------------
SEARCHING
/pattern       *Search forward for (N-th)matching line.
?pattern   	   *Search backward for (N-th)matching line.
n 			   *Repeat previous search (for N-th occurrence).
N              *Repeat previous search in reverse direction.
ESC-n          *Repeat previous search, spanning files.
ESC-N          *Repeat previous search, reverse dir. & spanning files.
ESC-u 		    Undo (toggle) search highlighting.
&pattern	   *Display only matching lines.
-----------
A search pattern may begin with one or more of:
^N or ! Search for NON-matching lines.
^E or * Search multiple files (pass thru END OF FILE).
^F or @ Start search at FIRST file,(for /) or last file (for ?).
^K      Highlight matches, but don't move(KEEP position).
^R      Don't use REGULAR EXPRESSIONS.
---------------
JUMPING
g < ESC-<      *Go to first line in file (or line N).
G > ESC->      *GO to last line in file..
p %            *Go to beginning of file (or N percent into file).
t              *Go to the (N-th) next tag.
T              *Go to the (N-th) previous tag.
{ ( [          *Find close bracket } ) ]
] ) }		   *Find open bracket  { ( [
ESC-^F <c1> <c2> *Find close bracket <c2>.
ESC-^B <c1> <c2> *Find open bracket <c1>
----------
m<letter>      Mark the current top line with <letter>.
M<letter>      Mark the current bottom line with <letter>.
'<letter>      Go to a previously marked position.
''             Go to the previous position.
^X^X           Same as '.
ESC-M<letter>  Clear a mark.
---------
CHANGING FILES
:e [file]      Examine a new file.
^X^V           Same as :e.
:n            *Examine the (N-th) next file from the command line.
:p            *Examine the (N-th) previous file from the command line.
:x            *Examine the first (or N-th) file from the command line.
:d             Delete the current file from the command line list.
= ^G :f        Print current file name.
-------------
MISCELLANEOUS COMMANDS
-<flag>       Toggle a command line option [see OPTIONS below].
--<name>      Toggle a command line option, by name.
_<flag>       Display the setting of a command line option.
__<name>      Display the setting of an option, by name.
+cmd          Execute the less cmd each time a new file is examined.

!command      Execute the shell command with $SHELL.
|Xcommand     Pipe file between current pos & mark X to shell command.
s file        Save input to a file.
v             Edit the current file with $VISUAL or $EDITOR.
V             Print version number of "less".
--------------------
OPTIONS
character -
name --
-?  --help       Display help (from command line).
-a  --search-skip-screen  Search skips current screen.
-A  --SEARCH-SKIP-SCREEN  Search starts just after target line.
-b [N]  --buffers=[N]         Number of buffers.
-B  --auto-buffers
-c  --clear-screen
-d  --dumb
-D [xn.n] . --color=xn.n
-e -E  --quit-at-eof  --QUIT-AT-EOF
-f     --force
-F     --quit-if-one-screen
-g  --hilite-search
-G  --HILITE-SEARCH
-h [N]  --max-back-scroll=[N]
-i  --ignore-case
-I  --IGNORE-CASE
-j [N]  --jump-target=[N]
-J  --status-column
-k [file]  --lesskey-file=[file]
-K  -- quit-on-intr
-L  --no-lessopen
-m -M  --long-prompt  --LONG-PROMPT
-n -N  --line-numbers  --LINE-NUMBERS
-o  --log-file=[file]
-O  --Log-FILE=[file]
-p  --pattern=[pattern]
-P  --prompt=[prompt]
-q -Q  --quiet  --QUIET --silent --SILENT
-r -R  --raw-control-chars  --RAW-CONTROL-CHARS
-s  --squeeze-blank-lines
-S  --chop-long-lines
-t [tag]  --tag=[tag]
-T [tagsfile]  --tag-file=[tagsfile]
-u -U   --underline-special --UNDERLINE-SPECIAL
-V  --version
-w  --hilite-unread
-W  --HILITE-UNREAD
-x [N[,...]]  --tabs=[N[,...]]
-X  --no-init
-y  --max-forw-scroll=[N]
-z [N]  --window=[N]
-" [c[c]]  --quotes=[c[c]]
-~  --tilde
-# [N]  --shift=[N]
		--follow-name
		--mouse
		--no-keypad
		--no-histdups
		--rscroll=C
		--save-marks
		--use-backslash
		--wheel-lines=N
----------------------------
LINE EDITING
RightArrow  
LeftArrow
ctrl-RightArrow ESC-RightArrow
ctrl-LeftArrow ESC-LeftArrow
HOME
BACKSPACE
DELETE
ctrl-BACKSPACE  ESC-BACKSPACE
ctrl-DELETE  ESC-DELETE   ESC-x
ctrl-U
UpArrow
DownArrow
TAB
SHIFT-TAB
ctrl-L

```

2022年11月30日

ctrl + R  模糊搜寻最近使用过的命令

`history`  显示最近使用过的命令

`cp mycoolfile /home/pete/Document/cooldocs` 拷贝

`cp *.jpg /home/pete/Pictures` 拷贝所有同类型的文件

`cp -r Pumpkin/ /home/pete/Documents` 拷贝整个文件夹及内容

`cp -i mycoolfile /home/pete/Pictures` 重写文件前提醒是否重写

`mv oldfile newfile` 重命名文件

`mv file2 /home/pete/Documents` 移动文件

`mv file_1 file_2 /somedirectory` 移动多个文件

`mv directory1 directory2` 重命名文件夹

`mv -i directory1 directory2` 重命名前询问

`mv -b directory1 directory2` 移动文件夹到指定路径 如果重写了，那么原先的文件夹以~结尾保留下来

`mkdir book1 book2` 创建多个目录

`mkdir -p book1/aaa/bbb/ccc` 创建多级目录

`rm file1`

`rm -f file1` 强制删除有保护权限的文件

`rm -i file` 删除操作前询问

`rm -r directory` 删除整个文件夹和内容

`rmdir directory` 

 `mkdir ./-file` 创建-file的文件夹

`rmdir ./-file` 删除-file的文件夹

`find /path -type d -name folder` 查询文件夹 

`find /path -name xxx.jpg` 查询文件

*任意0-N个数字字母

?一个数字字母

`help echo`

`echo --help`

`man ls` 查看命令使用说明

`whatis cat` 查看命令的简单叙述

`alias foobar='ls -la'` 给变量取别名

`~/.bashrc`

`unalias foobar`

`exit `   ，  `logout` 退出bash

`cd ~`  home 文件夹

`cd -` 上一个文件夹
`echo HelloWorld > peanuts.txt`  创建新文件并传内容进去

`history -c ` 删除历史操作记录