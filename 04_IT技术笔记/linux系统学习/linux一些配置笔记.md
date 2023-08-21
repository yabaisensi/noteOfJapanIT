环境变量的配置

写在 etc/profile里

`export PATH=$PATH:/opt/IBM/db2/v9/bin`



2023年8月12日

ubuntu 默认的root密码是随机的 如果没设置过的话 需要手动设置



```shell
sudo passwd
#先输入普通用户密码
#然后输入你要设的root用户密码 重复设置两次
#然后再登入root用户
sudo - root
```

