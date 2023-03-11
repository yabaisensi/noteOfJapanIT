package test;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.Scanner;

public class TestSnack {
	private static final String IN_FILE = "C:\\Users\\Administrator\\Documents\\pleiades-2021-12-java-win-64bit-jre_20220106\\pleiades\\workspace\\YDemo\\src\\main\\java\\test\\snack_in.txt";
	private static final String OUT_FILE = "C:\\Users\\Administrator\\Documents\\pleiades-2021-12-java-win-64bit-jre_20220106\\pleiades\\workspace\\YDemo\\src\\main\\java\\test\\snack_out.txt";
	public static void main(String[] args) throws IOException {
		File file = new File(IN_FILE);
        Scanner scanner = new Scanner(file);
        StringBuffer sb = new StringBuffer();
        try {
        	ProcessBuilder pb = new ProcessBuilder("cmd");
        	Runtime rt = Runtime.getRuntime();
        	rt.exec("notepad \""+IN_FILE+"\"");
        	System.out.println("press any key to continue while write completely!");
        	new java.util.Scanner(System.in).nextLine();
                while (scanner.hasNextLine()){
            	String line = scanner.nextLine();
        		while (line.contains("_")) {
    			line = line.replaceFirst("_[a-z]",
    					String.valueOf(Character.toUpperCase(line.charAt(line.indexOf("_") + 1))));
    		}
                if (line.equals("##")) {
                    scanner.close();
                    break;
                }
                line = line+"\r\n";
                sb.append(line);
            }
        } finally {
        	scanner.close();
			BufferedWriter bwr = new BufferedWriter(new FileWriter(new File(OUT_FILE)));
			bwr.write(sb.toString());
			bwr.flush();
			bwr.close();
			ProcessBuilder pb = new ProcessBuilder("cmd");
			Runtime rt = Runtime.getRuntime();
			pb.start();
		    String staStr = "notepad \""+OUT_FILE+"\"";
			rt.exec(staStr);
        }
	}

}
