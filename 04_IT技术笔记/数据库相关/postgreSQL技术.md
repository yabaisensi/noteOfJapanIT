2022年9月20日

```
<insert id="upsertStudent" parameterType="com.xxx.entity.StudentDto"> 
INSERT INTO t_student ( 
s_id 
<if test="sName != null"> 
, s_name </if> <if test="sScore != null"> 
,s_score </if>
 )　VALUES ( 
#{sId} 
<if test="sName != null"> 
,#{sName} </if> 
<if test="sName != null"> 
,#{sScore} </if> ) 
ON COFLICT(s_id) 
DO UPDATE SET 
s_name = #{sName} 
,s_score = #{sName} 
</insert>
```

2022年10月2日

- Oracle 数据库不能用 `insert into xxxtable (id,name,score) value (1,jo,10),(2,ra,20),(3,ka,40);`得用insert all into 

- SQL server pgSQL开启事务BEGIN TRANSACTION; mysql 开启事务 START TRANSACTION;

- ABS(number)   绝对值

- MOD(n，p) 余数 n/pの余り　　割り算　　（SQLserver 不能用

- ROUND(m,n)  m:対象数 n:丸め桁数 （小数点后位数） 四舍五入保留　ししゃごにゅう

- 拼接字符串

  ```
  
  - Oracle DB2 PostgreSQL      str1 || str2   拼接两个字符串  str1str2
  
  - SQL server str1+ str2 
  
  - mysql   concat(str1,str2,str3)
  
    
  ```

- LENGTH(文字列)　文字列長
- LOWER(文字列)　小文字化
- UPPER(文字列) 　大文字化
- REPLACE(対象文字列、置換前の文字列、置換後の文字列)   abcらららabc    abc   ABC  ->     ABCらららABC
- SUBSTRING 文字列の切り出し SUBSTRING(str1 FROM 3 FOR 2)   抽出字符串的从第三个开始2位的字符串
- CURRENT＿DATE　現在の日付
- CURRENT＿TIME　現在の時間
- CURRENT＿TIMESTAMP　現在の日時
- EXTRACT(日付要素の切り出し)
- CAST('0001' AS INTERGER) 转型函数  変換関数
- COALESCE(s1,s2,s3) 直到第一个数不为null

述語

- LIKE               LIKE '%xxx%'
- BETWEEN     BETWEEN 100 AND 1000
- IS NULL ,  IS NOT NULL
- IN 
- EXISTS          WHERE EXISTS(条件)

CASE式

```
CASE
	WHEN  ID = 1
	THEN  01,
	WHEN  ID = 2
	THEN  02,
	ELSE  0
END

```

UNION（和） EXCEPT（差） INTERSERT（交差） CROSS JOIN（直積）

```
SELECT commodityId,commodityName from commodity
INTERSERT
SELECT commodityId,commodityName from commodity2
两个表的公共交集

SELECT commodityId,commodityName from commodity
EXCEPT
SELECT commodityId,commodityName from commodity2
第一个表减去两个表的公共交集

SELECT commodityId,commodityName from commodity
UNION
SELECT commodityId,commodityName from commodity2
两个表的和集去重

SELECT commodityId,commodityName from commodity
UNION ALL
SELECT commodityId,commodityName from commodity2
两个表的和集
```

INNER JOIN, LEFT JOIN, RIGHT JOIN

集約関数（SUM, AVG, COUNT, MAX, MIN）

ウィンドウ関数　RANK, DENSE_RANK, ROW_NUMBER

PARTITION BY

移動平均

GROUPING演算子

ROLLUP

CUBE

GROUPING SETS

ODBC

JDBC

2022年12月8日

```
-- 顧客テーブルの複製テーブルを作成する
SELECT * INTO [顧客コピー1] FROM [顧客];
-- 複製したテーブルのプライマリキーを追加する
ALTER TABLE [顧客コピー1] ADD CONSTRAINT  [PK_顧客コピー1]PRIMARY KEY ([顧客ID]);
```

