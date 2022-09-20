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
```
