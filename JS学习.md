2022年9月12日

## jquery

```
<div id="notMe"><p>id="notMe"</p></div>

<div id="myDiv">id="myDiv"</div>

```
$("#myDiv") id选择器选择

```
<div>DIV1</div>
<div>DIV2</div>
<span>SPAN</span>
```
$("div") 标签选择器

```
<div class="notMe">div class="notMe"</div>
<div class="myClass">div class="myClass"</div>
<span class="myClass">span class="myClass"</span>
```
$(".myClass") 类选择器

## js

js区分大小写

document.write() 感觉会刷新页面

js是一行一行执行的 如果行和行断开，可以用\ 反斜杠衔接

new对象属性

var carname = new String; new  Number; new Boolean; new Array; new Object;

对象car 属性 var car = {name:"Fiat", model:500, color:"white"};

给对象添加属性

var obj =new Object();

obj.userName = "admin";

obj.passWord = "123456";

移除对象属性

delete obj.passWord;

console.log(obj);



