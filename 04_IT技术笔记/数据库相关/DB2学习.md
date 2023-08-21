抽取数据库的表数据 输出到csv 的command命令

`db2 "export to /root/Desktop/sale.csv of del SELECT * from SMAPLE.EMP_SALES_S"`



先是 `su db2inst1`

再是`db2 list active databases`

```bash
db2inst1@infosrvr:/root> db2 list active databases

                           Active Databases

Database name                              = XMETA
Applications connected currently           = 4
Database path                              = /opt/IBM/InformationServer/Repos/xmeta/db2inst1/NODE0000/SQL00001/

db2inst1@infosrvr:/root>
```

环境变量追加db2路径（暂时的）

`export PATH=$PATH:/opt/IBM/db2/V9/bin`



2023年8月2日

连接到数据库

```sql
db2 connect to <DB> user <username> using <password>
db2
select * from IDPDWB00 fetch first 10 rows only
quit
```

db2 connect to XMETA user db2admin using inf0server





db2 create schema SAMPLE authorization db2inst1 

