2022年9月13日
- document.getElementById('#demo').innerHTML = 'hello world';
- 字面量 3.14  1001 123e5
- 字面量 3*4 3+4
- Array字面量 ［1,2,3,4,5］
- Object字面量 {firstname:"zhu",lastname:"gou",age:"18",hobby:"sleep"}
- Function字面量 function myFunction(a,b){return a*b;}
- document.write*()

2022年9月14日
- Js只有一种数字类型，可以放小数也可以不放
  - var x=31.1；var y=31；var z=31e5；var a= 3.12e-5；
- js Boolean只有true或false
- js创建数组 var arr = new Array（）
- var s= new String()
- var n = new Number()
- var b = new Boolean()
- var person =new Object()
- 类对象两种赋值方法
  - var car=｛name="fiat",model=500,color="red"｝
```
var car=｛
fname="fiat",
lname="ss"
model=500,
color="red"
fullname: function()｛
  return this.fname + " " + this.lname;
｝
｝
```
  - var car.name="fiat";
  - var car.model=500;
  - var car.color="red";
- document.getElementById("#demo").innerHTML = car.fullname();
- car.fullname 不加() 则返回方法定义

9月15日
```
<script>
function myFunction()｛
alert("lalala");
｝
</script>
<button onclick="myFunction()">点我</button>

<script>
function myF(name1,name2)｛
alert("名"+name1+"字"+name2);
｝
</script>
<button onclick="myF("组","长")">显示名字</button>
将返回值作为参数
<script>
function myF2()｛
return 5;
｝
</script>
var nuk = myF2();




```
- 在script函数内定义的变量是局部变量
- 在script函数外定义的变量是全局变量，支持所有当前网页的函数或脚本调用它
- 局部变量在函数调用后被销毁
- 全局变量在网页关闭后被销毁
- delete var1 删除未写死的全局变量

```
HTML事件 
1 
<p id="demo"></p> 
<button onclick="getElementById('demo').innerHTML=Date()">现在的时间是？</button> 
2 
<button onclick="this.innerHTML=Date()">现在的时间是？</button> 
3 
<p><em>displayDate()</em></p> 
<button onclick="displayDate()">现在的时间是？</button> 
onchange HTML元素改变 
onclick 用户点击HTML元素 
onmouseover 鼠标指针移动到指定的元素上时发生 
onmouseout 用户从一个HTML元素上移开鼠标时发生 
onkeydown 用户按下键盘按键 
onload 浏览器已完成页面的加载 
https://www.runoob.com/jsref/dom-obj-event.html
```

9／20

```
var text = 'hello "li"';
var text = "hello 'wang'";
var text = "hello \"li\"";
var text = 'hello \'wang\'';
var textt = text[5];
var lgtn = text.length;
\r 回车 回到行首
\n 换行
\t 制表
\f 分页
\b 退格
var text1 = "john";
var text2 = new String("john");对象
text1 === text2; //false
length
constructor
prototype
```
