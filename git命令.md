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
- git rebase 一键清空本地仓库所有版本，merge为一个待提交的版本（慎用）
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