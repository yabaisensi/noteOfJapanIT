- git reset --hard origin/XXX 重置版本
- git add -A 提交所有修改
- git commit -a 提交
- git commit -m '提交信息' 带信息提交
- git push 推送本地版本到远程
- git fetch 获取远程最新版本
- git pull 拉取远程最新版本至本地
- git branch 查看所有可获取版本
- git branch -d XXX 删除merge完的版本（无新改动）
- git branch -D 强制删除本地分支
- git switch XXX 切换到新分支
- git switch -c XXX 创建并切换到新分支
- git checkout -t <remote_name>/<branch_name>
- git merge之前要把改动的文件commit一个版本再merge，不然会报错
- git merge <remote_name>
- git rebase 嫁接自己本地版本到远程版本上，从产生分歧的第一版开始commitID全都会变 相当于重新提交 想要进阶玩法的人可以尝试，挺方便的
- git 的reset可以实现增文件，改内容，改文件名，但不能实现删文件。这是競合（冲突)的原因。
- git reset --hard <commit ID>

9/20

```
删除merge完的分支 
git branch -d develop 
（Deleted branch develop (was 36464c4)（哈希值）.） 
恢复删除掉的分支（强删也可恢复 
git checkout 36464c4 -b develop 
强制删除本地分支 
git branch -D localBranchName 
删除远程分支 
git push origin --delete remoteBranchName

working区 就是eclipse 直接编辑的区域 
staging区 就是index里的区域，可以区别于working区和head区，暂存一些修改，用来选择需要commit的文件 
head区 就是本地的仓库的head版本，是指本地的最新版本 
reset 有三种形式 
--soft 只回退head区版本，不回退（相当于保存）现有的staging区缓存内容，working区修改内容 
--mixed 回退head区版本和staging区缓存内容，不回退working区修改内容 
--hard 回退head区版本，staging区缓存内容和working区修改内容
显示提交版本的log
git log 

```
9／21
- git push -u origin xxx 往远程创建新分支
- git init 创建空仓库
- git log --pretty=oneline 简洁化提交log
- git log -oneline
- git push origin --delete xxx 删除远程分支
- git push -f xxx 强制推某分支
- git fetch prune 修剪分支
- git tag -a xxx 给版本打上标签有注解
- git tag xxx 打上标签 无注解
- git tag -d xxx 删除标签
- git show xxx 展示某标签
- git log -decorate 展示带标签的log信息
- git tag -a tagname -m commitmessage 指定标签信息
- git tag -s tagname -m commitmessage PGP签名标签命令
- mkdir xxx 创建文件夹
- cd xxx 进入文件夹
- touch README
- git add README
- ls 查看当前路径全部目录和文件
- git rm test.txt 删除文件

9/24

- git push --set-upstream origin master 将本地分支的推送和远程分支绑定

9/27

- git clone https://xxx  克隆本地仓库

- git 还原删除的版本

  - git  log --reflog

  - git reset --hard commit的哈希值

- git 快速merge别人修改的东西并不提交版本的方法

  - git stash 快存命令 或者 git stash save 'xxx' 打标记保存
  - git pull 拉去远程代码
  - git stash pop 将暂存代码和pull下来的代码进行merge 并且不提交版本

- 本地修改文件后 用 git add 命令缓存后 直接 git stash pop 也可以实现merge

9/29

- git diff branch1...branch2 比较两个分支的不同
- git main new_branch ./xxx/aaa.txt

- 远程分支退回版本
  - git reset --hard <commit-hash>  
  - git push -f <remote> <local branch>:<remote branch>
- git checkout <commit-hash>
  git checkout <commit-hash> -- file_name
  git add .
  git commit -m 'file brought from previous time'
  git push

2023年1月2日

```
git reset --hard origin/XXX 重置版本
git add -A 整个分支的所有修改追加到索引
git add . 当前文件夹所有修改追加到索引
git reset 取消所有文件的索引
git reset . 取消当前文件夹的所有索引
git commit -a 提交
git commit -m '提交信息' 带信息提交
git push 推送本地版本到远程


git fetch 获取远程最新版本


git pull 拉取远程最新版本至本地
git branch 查看本地所有分支
git branch -d XXX 删除merge完的版本（无新改动）
git branch -D 强制删除本地分支
git switch XXX 切换到新分支
git switch -c XXX 创建并切换到新分支
git checkout -t <remote_name>/<branch_name>
git merge之前要把改动的文件commit一个版本再merge，不然会报错
git merge <remote_name>
git rebase 一键清空本地仓库所有版本，merge为一个待提交的版本（慎用）
git 的reset可以实现增文件，改内容，改文件名，但不能实现删文件。这是競合（冲突)的原因。
git branch -d xxx 删除merge完的分支 
（Deleted branch develop (was 36464c4)（哈希值）.） 
git checkout 36464c4 -b develop 恢复删除掉的分支（强删也可恢复 
git branch -D localBranchName 强制删除本地分支 
git push origin --delete remoteBranchName 删除远程分支 

working区 就是eclipse 直接编辑的区域 
staging区 就是index里的区域，可以区别于working区和head区，暂存一些修改，用来选择需要commit的文件 
head区 就是本地的仓库的head版本，是指本地的最新版本 
reset 有三种形式 
--soft 只回退head区版本，不回退（相当于保存）现有的staging区缓存内容，working区修改内容 
--mixed 回退head区版本和staging区缓存内容，不回退working区修改内容 
--hard 回退head区版本，staging区缓存内容和working区修改内容

git log 显示提交版本的log
git push -u origin xxx 往远程创建新分支
git init 创建空仓库
git clone http://...  拷贝远程仓库
git push origin --delete xxx 删除远程分支
git push -f xxx 强制推某分支
git fetch prune 修剪分支
git tag -a xxx 给版本打上标签有注解
git tag xxx 打上标签 无注解
git tag -d xxx 删除标签
git show xxx 展示某标签
git log --decorate 展示带标签的log信息
git tag -a tagname -m commitmessage 指定标签信息
git tag -s tagname -m commitmessage PGP签名标签命令
mkdir xxx 创建文件夹
cd xxx 进入文件夹
touch README
git add README
ls 查看当前路径全部目录和文件
git rm test.txt 删除文件
git push --set-upstream origin master 将本地分支的推送和远程分支绑定
git checkout 查看当前分支跟踪(track)的远程分支是啥
git remote show -n origin 显示远程所有的分支


还原删除的版本
git reflog
git reset --hard commit的哈希值
git config --global --add safe.directory '%(prefix)///tmhf/(R05)ディスコ学生統合管理システム/99 個人用/xu.yuan/git命令'

git diff head 与head版本比较差异

---------------------------------------
・快速merge别人修改的东西并不提交版本的方法
在如bm004的文件夹里 打开git bash
git add .   添加到索引
git stash 快存命令 或者 git stash save 'xxx' 打标记保存
git pull 拉去远程代码
git stash pop 将缓存代码和pull下来的代码进行merge 并且不提交版本
（ git stash pop 可以实现merge效果）
---------------------------------------

git checkout head或者哈希值 -- 文件路径如bs057/*  ./*
(示例 git checkout c039feb671e52cbe0f8066799781ac04fe9c86d6 -- bs057/*)


git branch --set-upstream-to=origin/bmxxx 将本地分支的推送和远程分支绑定
git rev-parse --abbrev-ref bm000@{upstream}　显示绑定信息
git rev-parse --abbrev-ref @{upstream} 显示当前分支绑定信息
git remote show origin　显示远程的所有分支

git diff file_path 比较特定的路径的文件和head版本的区别

git config --global user.name "user_name" 添加配置信息
git config --unset name 或 git config --local --unset name  删除本地配置
git config --global --unset name 删除全局配置
git config --system --unset name 删除系统配置
git config --remove-section name 
git config --global --remove-section name
git merge bsxxx --no-commit  不提交版本进行merge
git config 有三个区 --system --local 和 --global 默认是local 进去system或者global 才可以删除对应的config变量

git commit --amend 修改提交过的commit 信息
git commit --amend -c <commit ID> 用指定id的message
git remote add [リモートリポジトリの呼び名] [リモートリポジトリのURL]  追加remote仓库
git remote rm [リモートリポジトリの呼び名]  删除remote仓库
git remote -v 查看远程分支名字 和fetch 和push 地址
git branch -m old_name new_name 修改分支名字

git clean

git bash 右键单击 Option 可以调字体
git bash 鼠标选中的内容 按滚轮可以实现粘贴

git merge --abort 取消merge
git reset --merge

git log --pretty=format:'%h : %s'
git log --pretty=oneline 简洁化提交log
git log -oneline
git log --pretty=oneline --abbrev-commit
git log --pretty=oneline | awk '{print $1}' 只显示哈希值

git log --pretty=format:"%h   %s %C(yellow)(%cr)"
git log --oneline | awk '{print $1 " "  $2}' 显示第一个提交版本
git log --pretty=format:"%s" 只显示commit信息
git log --pretty=format:"%s" 9bceb9255c..HEAD  显示 两个版本之间的版本
git log --pretty=format:"- %s" 9bceb9255c..HEAD  显示 两个版本之间的版本 开头带 - 
git log --format="%H" -n 1 显示最近版本的哈希值

git log --grep xxx 查找对应的信息

git diff [<options>] [--] [<path>…​]
git diff [<options>] --no-index [--] <path> <path>
git diff [<options>] --cached [--merge-base] [<commit>] [--] [<path>…​]
git diff --cached --merge-base A
git diff --cached $(git merge-base A HEAD)
git diff --raw
git diff --compact-summary 总结修改的内容
git diff --numstat
git diff --shortstat
git diff --dirtstat 改动分布
git diff --name-status
git diff --word-diff  逐字显示修改 而不是默认的逐行

1:36 2023/1/2
git reflog --grep-reflog="message"  在历史记录里查找指定的关键词
git switch -c main2 && git reset --hard HEAD~3 && git merge --squash main && git commit --no-edit && git switch main && git reset --hard main2 && git branch -D main2  整合多个版本为一个版本
git blame file 查看文件内部所有的修改记录

14:09 2023/1/2
git log --graph --oneline --decorate=full -20 --date=short --format='%h %d %s @%an'       log的自定义显示
git log --graph --oneline --raw --decorate=full -5 --date=short --format='%C(yellow)%h%C(reset) %C(magenta)[%ad]%C(reset)%C(auto)%d%C(reset) %s %C(cyan)@%an%C(reset)'
git prune git gc 垃圾清理相关
git log -1 --format='%s'  | grep  -oP '(?<=version ).*' 查找指定内容
```

##### commit.bat

```cmd
::一个版本自动递增的bat脚本 第一版
@echo off
git log -1 | findstr version > temp.txt
FOR /F "tokens=9" %%g IN (temp.txt) do (
SET v_num=%%g
SET /a v_num+=1
)
del temp.txt
echo  %v_num%
git add .
git commit -m "Saved on %date% %time% by xu version %v_num%"
git push
git log -5
pause

```

```cmd
::一个版本自动递增的bat脚本 第一版
@echo off
git log -20 | findstr version > temp.txt 
set /p  temp=<temp.txt 
echo %temp%
set v_num=%temp:*version =%
SET /a v_num+=1
echo %v_num%
pause
del temp.txt
git add .
git commit -m "Saved on %date% %time% by xu version %v_num%"
git push
git lg1
git reset --soft head~1
pause
```



##### 好用的log format

```
[alias]
        lg1 = !"git log --graph --oneline --raw --decorate=full -5 --date=short --format='%C(yellow)%h%C(reset) %C(magenta)[%ad]%C(reset)%C(auto)%d%C(reset) %C(brightred)%s%C(reset) %C(cyan)@%an%C(reset)'"
        lg2 = !"git log --oneline --raw --decorate=full -5 --date=short --format='%C(yellow)%h%C(reset) %C(auto)%d%C(reset)  %C(brightred)%s%C(reset)' "
```

```bash
jobs
fg 1
结束进程
ps
kill 17781
```

2023年2月13日

set v_num=%temp:*version =%           win bat 往一个变量里面取出一部分赋给另一个变量