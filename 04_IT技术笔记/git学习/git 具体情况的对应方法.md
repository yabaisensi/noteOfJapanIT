# git 具体情况的对应方法

### 发生过的情况

#### 工作做完了，怎么merge分支到远程的主分支上

```bash
git fetch  #同步远程端的分支（其实远程端的分支也在本地，只是要定期手动和远程端分支同步）
git switch branch_name #切到你自己的工作分支
git merge origin/develop #merge远程端develop分支到本地的branch_name分支上
git push #更新自己的远程端的分支branch_name

#如果竞合 在git merge这一步会把所有竞合的文件git status 显示出来在本地改好保存后
git add file
git merge --continue
git push

#以上是把远程端分支develop的source合并到自己的分支branch_name里面了

#还需要做的是用git命令在主分支develop上合并自己的代码进去
git fetch 
git switch develop
git merge branch_name
#如果报竞合 则回到开头 切到自己的分支git switch branch_name 继续git merge origin/develop 直到解决竞合。然后再切回 develop分支，执行上面三行代码，继续往下做

#接下来是提source review请求给leader
git diff #查看develop上面merge完更新了啥内容


git push #更新远程端，这一步是leader做的 自己不要做！！
```

#### 还原删除的版本

```bash
git reflog
git reset --hard commit的哈希值
```

#### 快速merge别人修改的东西并不提交版本的方法
在如bm004的文件夹里 打开git bash

```bash
git add .   #添加到索引
git stash   #快存命令 或者 git stash save 'xxx' 打标记保存
git pull    #拉去远程代码
git stash pop #将缓存代码和pull下来的代码进行merge 并且不提交版本
              #（ git stash pop 可以实现merge效果）
```

#### 远程分支退回版本

```bash
git reset --hard <commit-hash>  
git push -f <remote> <local branch>:<remote branch>
```

#### 删除分支和恢复分支

```bash
#删除merge完的分支 
git branch -d develop 
#（Deleted branch develop (was 36464c4)（哈希值）.） 
#恢复删除掉的分支（强删也可恢复 
git checkout 36464c4 -b develop 
#强制删除本地分支 
git branch -D localBranchName 
#删除远程分支 
git push origin --delete remoteBranchName
```

#### 结束git 正在使用的进程

```bash
#获取进程
jobs
fg 1
#结束进程
ps
kill 17781
```

#### 还原本地的代码为HEAD版本，并且把所有当前文件的修改保存到git reflog里去

```bash
git add -A && git commit -m "record %date%%time%" && git reset --hard HEAD~1
```

