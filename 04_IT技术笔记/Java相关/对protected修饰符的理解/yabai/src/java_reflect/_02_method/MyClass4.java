package java_reflect._02_method;

import java_reflect._01_GetClass.MyClass;

public class MyClass4 extends MyClass{

    public MyClass4() {
    }
    
    @Override
	public String toString() {
		// TODO 自動生成されたメソッド・スタブ
		return super.address;
	}
	public String toString2() {
		
		return super.toString();
	}


	public static void main(String[] args) {
		MyClass4 m4 =new MyClass4();
    	System.out.println(m4.toString());
    	System.out.println(m4.toString2());
	}

}
