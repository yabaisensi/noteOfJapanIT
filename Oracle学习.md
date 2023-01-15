#### 2023年1月10日

com/oracle/xmlns

com/sun/accessibility/internal

com/sun/activation

com/sun/awt

com/sun/activation

com/sun/awt

com/sun/beans

com/sun/codemodel

com/sun/corba

HTTPClient

java/awt/dnd

#### 2023年1月12日

##### ResultSet

Statment 里放TYPE_SCROLL_SENSITIVE 受影响，TYPE_SCROLL_INSENSITIVE 不受影响，TYPE_FORWARD_ONLY这三种

默认是 TYPE_FORWARD_ONLY  索引只有rs.next()能使用 ，其他两种连接需要数据库驱动支持

此外还有first()，last()，previous(),afterLast(),beforeFirst(),relative(), relative(int rows), absolute(int row)

statment 还有addBatch操作 可以insert 和update 操作

