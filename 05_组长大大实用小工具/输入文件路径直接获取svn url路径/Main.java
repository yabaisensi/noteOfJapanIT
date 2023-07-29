
import java.net.URLDecoder;

public class Main {
    public static void main(String[] args) {
    			String svnUrl = args[0];
    	        try {
    	            String decodedStr = URLDecoder.decode(svnUrl, "UTF-8");
    	            System.out.println(decodedStr);
    	        } catch (Exception e) {
    	            e.printStackTrace();
    	    }

    }
}
