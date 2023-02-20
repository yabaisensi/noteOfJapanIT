# Java工具类学习笔记

#### 2023年2月18日

lambda表达式

1. インターフェース名 オブジェクト名 = (引数1, 引数2, ・・・) -> {**return** 処理内容};
2. インターフェース名 オブジェクト名 = 引数 -> 処理;
3. クラス名 :: メソッド名

#### 2023年2月19日

lambda 就是在一个类里写内部匿名实现类

匿名实现类 实现方法，重写方法。用来给对象进行实现。被实现完的对象可以直接调用被实现的方法。

注意点：

- 参数类型可以省略
- 假如只有一个参数，()括号可以省略
- 如果方法体只有一条语句，{}大括号可以省略
- 如果方法体中唯一的语句是return返回语句，那省略大括号的同时return也要省略

```java
		Cal c = new Cal() {
			@Override
			public int add(int a, int b) {
				return a+b;
			}
		};
```

```java
	public staitic void main(String[] args){
		If5 if5= a->a; // lambda最简单表达式
	int c =if5.test(7);
	System.out.println(c+"f5");
	}

	interface If5{
		int test(int a);
	}
```
```java
		/** lambda表达式省略版写法 */
		If5 if5= a->a; // 适用于参数一个，实现只有return返回
		If5 if5= a->{return a;};// 适用于参数一个
		If5 if5= (a)->a; // 适用于参数一个，实现只有return返回
		If5 if5= (a)->{return a;}; // 适用于参数一个
		If5 if5= (int a)->a; // 适用于实现只有return返回
		If5 if5= (int a)->{return a;};// lambda正常表达式

```

```java
		If6 if6=(int a,int b)->{
			return a+b;
		}; // 正常

		If6 if6=(a,b)->{
			return a+b;
		}; // 省略

		If6 if6=(int a,int b)->a+b; // 省略

		If6 if6=(a,b)->a+b; // 省略

```

::的使用方法

```java
package com.yabai;

// 非静态
public class MainTest3 {
	public static void main(String[] args) {
		MainTest3 mainTest3 = new MainTest3();
		If6 if6=mainTest3::test;
		int d =if6.test(6,7);
		System.out.println(d+"f6");
		
	}
	public int test(int a, int b){
		return a*b;
	}
	
	interface If6{
		int test(int a, int b);
	}

}
```

```java
package com.yabai;

// 静态
public class MainTest3 {
	public static void main(String[] args) {
		If6 if6=MainTest3::test;
		int d =if6.test(6,7);
		System.out.println(d+"f6");
		
	}
	public static int test(int a, int b){
		return a*b;
	}
	
	interface If6{
		int test(int a, int b);
	}

}
```

重写了toString后代码就可以输出对象信息了

```
无参
Dog [name=null, age=0]
```

`DogService dogService=Dog::new;`



```java
package com.yabai;

public class MainTest4 {
	public static void main(String[] args) {
		DogService dogService=()->{
            return new Dog();
        }
		System.out.println(dogService.getDog());
	}
	interface DogService{
		Dog getDog();
	}
	
}
```



```java
package com.yabai;

public class MainTest4 {
	public static void main(String[] args) {
		DogService dogService=Dog::new;
		System.out.println(dogService.getDog());
	}
	interface DogService{
		Dog getDog();
	}
	
}
```

```java
// 解析内部实现类 lambda表达式
	list.sort((o1,o2)->{return o1.getAge()-o2.getAge();});
	System.out.println(list);
```
```java
// 上面方法等同于下面
		list.sort(new Comparator<Dog>() {
			@Override
			public 	int compare(Dog o1,Dog o2){
				return  o1.getAge()-o2.getAge();
			}
		});
		System.out.println(list);
```

// 遍历集合

```
		list.forEach(System.out::println);
```

@FunctionalInterface

这个注解只允许类只有一个抽象方法  函数式接口



##### 接口实现

```java
package com.yabai;

public class MainTest7 {
	public static void main(String[] args) {
		A b = new B();
		String sb = b.test3();
		System.out.println(sb);
		A c = new C();
		String sa = c.test3();
		System.out.println(sa);
	}
	
}

interface A{
	void test1();
	void test2();
	public default String test3() {
		System.out.println("默认");
		return "test3 ok moren";
	}
}

class B implements A{
	
	@Override
	public void test1() {
		
	}
	
	@Override
	public void test2() {
		
	}
	
}
class C implements A{
	
	@Override
	public void test1() {
		
	}
	
	@Override
	public void test2() {
		
	}
	
	@Override
	public String test3() {
		return "C no over";
	}
}
```

接口允许有默认的实现方法

#### 2023年2月21日

Runnable类

正常重写线程类

```java
		new Thread(new Runnable() {
			@Override
			public void run(){
				System.out.println("i am god");
			}
		}).start();
```
lambda表达式写线程类

```java
		new Thread(()-> System.out.println("i am god")).start();
```



```java
	// 线程不安全
	// 无法处理时区
	SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
	for(int i=0;i<50;i++) {
		new Thread(()->{
			try {
				System.out.println(sdf.parse("2021-05-06"));
			} catch (Exception e) {
				e.printStackTrace();
			}
		}).start();
	}
```
日期时间API

- LocalDate：日期

- LocalTime：时间                LocalTime time = LocalTime.of(5, 26,33,2315);
- LocalDateTime：日期时间
- DateTimeFormatter：时间格式化类
- Instant：时间戳           Instant.now()
- Duration：计算时分秒差   Duration.between(time1,time2) .toDays();  .toHours(); .toMinutes(); .toMillis();
- Period：计算年月日差        Duration.between(date1,date2) .getYears(); .getMonths(); .getDays();
- ZonedDateTime：包含时区的时间

```java
ZonedDateTime utc = ZonedDateTime.parse(target); 
ZonedDateTime jst = utc.withZoneSameLocal(ZoneId.of("Asia/Tokyo")); 
System.out.println(jst.toLocalDate());
```

LocalDateTime转为String

```java
DateTimeFormatter dateTimeFormatter = DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss");
String format1 = LocalDateTime.now().format(dateTimeFormatter);
```

String 转为 LocalDateTime

```java
DateTimeFormatter dateTimeFormatter = DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss");
		// String 转为LocalDateTime
		LocalDateTime parse = LocalDateTime.parse("1997-05-06 22:45:16",dateTimeFormatter);
```

- TemporalAdjuster 接口   时间校正器

```java
	LocalDateTime now = LocalDateTime.now();
	TemporalAdjuster adJuster = (temporal)->{
		LocalDateTime dateTime = (LocalDateTime) temporal;
		LocalDateTime nextMonth = dateTime.plusMonths(1).withDayOfMonth(15);
		System.out.println("nextMon = " + nextMonth);
		return nextMonth;
	};
	
	LocalDateTime nextMo = now.with(adJuster);
	System.out.println("nextMonth = "+nextMo );
```
- TemporalAdjusters 工具类 静态方法调用