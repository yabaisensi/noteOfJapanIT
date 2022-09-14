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


```
