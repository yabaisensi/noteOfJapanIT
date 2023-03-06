package test;

import java.io.IOException;
import java.net.URISyntaxException;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Scanner;

public class Test {

    	public static void main(String[] args) throws InterruptedException, IOException, URISyntaxException {
    		int index=0;
    		while(index<4) {
    			index++;
    			Scanner sc = new Scanner(System.in);
    			String cstr = sc.nextLine();
    			cstr=cstr.replaceAll("\"", "");
    			Path path = Paths.get(cstr);
    			String pstr = path.getParent().toString();
    			ProcessBuilder pb = new ProcessBuilder("cmd");
    			pb.start();
    			Runtime rt = Runtime.getRuntime();
    			rt.exec("explorer "+ pstr);
    		}
  }
}