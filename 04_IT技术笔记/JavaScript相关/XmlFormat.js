// XML整形マクロ
//   選択範囲のテキストをXMLとみなして整形します。
//   以下の機能があります。
//     ・階層構造をインデントで出力
//     ・インデント、改行文字の指定
//     ・コメント、CDATAに対応
//     ・テキストノードの前後に無駄な改行・空白を入れません
//   以下の制限があります。
//     ・XML宣言、DOCTYPE未対応（削除される）
//     ・msxmlが必要
//     ・XML形式エラーがあった場合はなにもしません
// 
//   2010/04/04 ver 1.0  syat 新規作成

//文字参照をエスケープする
String.prototype.escape = function() {
	return this.replace("<", "&lt;")
	           .replace(">", "&gt;")
	           .replace("\"", "&quot;")
	           .replace("'", "&apos;")
	           .replace("&", "&amp;");
}

//ノードを整形する
function format(node, indent, indentUnit, crlf) {
	var s = "";
	if (node.nodeName == "#comment") {
		s += "<!--" + node.nodeValue.escape() + "-->";
	} else if (node.nodeName == "#cdata-section") {
		s += "<![CDATA[" + node.nodeValue + "]]>";	//CDATAはエスケープしない
	} else if (node.nodeName == "#text") {
		s += node.nodeValue.escape();
	} else {
		s += indent + "<" + node.nodeName;
		var ats = node.attributes;
		if (ats != null) {
			for (var i=0; i<ats.length; i++) {
				s += " " + ats[i].name + "=\"" + ats[i].value.escape() + "\"";
			}
		}
		var childs = node.childNodes;
		if (childs == null || childs.length == 0) {
			s += " />";
		} else {
			s += ">";
			if (childs[0].nodeName != "#text") {
				s += crlf;
			}
			for (var i=0; i<childs.length; i++) {
				if (childs[i].nodeName != "#text" && !(i>0 && childs[i-1].nodeName == "#text")) {
					s += indent + indentUnit;
				}
				s += format(childs[i], indent + indentUnit, indentUnit, crlf).replace(/^\s+/, "").replace(/\s+$/, "");
				if (childs[i].nodeName != "#text" && !(i<childs.length-1 && childs[i+1].nodeName == "#text")) {
					s += crlf;
				}
			}
			if (! (childs.length == 0 || (childs[childs.length-1].nodeName == "#text")) ) {
				s += indent;
			}
			s += "</" + node.nodeName + ">" + crlf;
		}
	}
	return s;
}

function main() {
	var raw = Editor.GetSelectedString();
	var xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
	xmlDoc.async = false;
	xmlDoc.loadXML(raw);
	if (xmlDoc.documentElement == null) return;
	
	var s = "";
	s += format(xmlDoc.documentElement, "", "  ", "\r\n");
	Editor.InsText(s);
}

main();
