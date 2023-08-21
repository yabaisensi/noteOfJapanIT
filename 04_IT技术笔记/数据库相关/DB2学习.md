

`export PATH=$PATH:/opt/IBM/db2/V9/bin`



2023年8月2日

连接到数据库

```sql
db2 connect to <DB> user <username> using <password>
db2
select * from IDPDWB00 fetch first 10 rows only
quit
```



