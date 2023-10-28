package yUtils;

import java.math.BigDecimal;
import java.math.MathContext;

public class CalProbability {
	
	public static void main(String[] args) {
		
		if (args.length == 0 ) {
			System.out.println("no param");
			System.exit(1);
		}
		if (args[2].contains("/")) {
			String[] parts = args[2].split("/");
			args[2]=String.valueOf(new BigDecimal(parts[0]).divide(new BigDecimal(parts[1]),MathContext.DECIMAL128).doubleValue()); 
		}
		
		// all count 
		Integer n;
		// success count
		Integer k;
		// will happen probability
		BigDecimal p;
		// will not happen probability
		BigDecimal q;
		n = Integer.valueOf(args[0]) ;
		k = Integer.valueOf(args[1]);
		p = new BigDecimal(args[2]);
		q =BigDecimal.ONE.subtract(p);
		
		System.out.println("--------------------------------------------------------------------");
		System.out.println("all count = "+ n);
		System.out.println("success count = "+ k);
		System.out.println("will happen probability = "+ p);
		System.out.println("will not happen probability = "+ q);
		Integer tmp=n-k;
		
		
		BigDecimal work1=BigDecimal.ONE;
		for (int i=0;i<k;i++) {
			work1 =work1.multiply(p);
		}
		BigDecimal work2=BigDecimal.ONE;
		for (int i=0;i<(n-k);i++) {
			work2 =work2.multiply(q);
		}
		
		
		Integer work31=1;
		Integer work32=1;
		Integer work33=1;
		BigDecimal work34;
		
		for (;n>1;n--) {
			work31*=n;
		}
		for (;k>0;k--) {
			work32*=k;
		}
		for (;tmp>0;tmp--) {
			work33*=tmp;
		}
		work34=new BigDecimal(work31).divide(new BigDecimal(work32)).divide(new BigDecimal(work33));
		
		BigDecimal rtn = work1.multiply(work2).multiply(work34) ;
		System.out.println("--------------------------------------------------------------------");
		System.out.println("Probability RESULT = "+ rtn.doubleValue());
		System.out.println("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
	}
}
