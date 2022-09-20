9/20

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
