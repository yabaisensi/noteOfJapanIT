# git 具体情况的对应方法

### 发生过的情况

#### 结束git 正在使用的进程

```bash
jobs
fg 1
结束进程
ps
kill 17781
```

#### 还原删除的版本

```bash
git reflog
git reset --hard commit的哈希值
```

#### 快速merge别人修改的东西并不提交版本的方法
在如bm004的文件夹里 打开git bash

```bash
git add .   添加到索引
git stash   快存命令 或者 git stash save 'xxx' 打标记保存
git pull    拉去远程代码
git stash pop 将缓存代码和pull下来的代码进行merge 并且不提交版本
              （ git stash pop 可以实现merge效果）
```

#### 远程分支退回版本

```bash
git reset --hard <commit-hash>  
git push -f <remote> <local branch>:<remote branch>
```

#### 删除分支和恢复分支

```bash
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

