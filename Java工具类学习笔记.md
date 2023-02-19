Java工具类学习笔记

#### 2023年2月18日

lambda表达式

1. インターフェース名 オブジェクト名 = (引数1, 引数2, ・・・) -> {**return** 処理内容};
2. インターフェース名 オブジェクト名 = 引数 -> 処理;
3. クラス名 :: メソッド名

注意点：

- 参数类型可以省略
- 假如只有一个参数，()括号可以省略
- 如果方法体只有一条语句，{}大括号可以省略
- 如果方法体中唯一的语句是return返回语句，那省略大括号的同时return也要省略

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







