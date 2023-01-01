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

写成一行 终端命令提示符

