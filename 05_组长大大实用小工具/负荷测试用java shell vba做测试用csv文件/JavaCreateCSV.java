import java.io.FileWriter;
import java.io.IOException;

public class GenerateAndExportCSV {
    public static void main(String[] args) {
        String csvFilePath = "your_file.csv"; // 替换为你要保存的文件路径
        int numRows = 40000;

        try (FileWriter fileWriter = new FileWriter(csvFilePath)) {
            // 写入CSV文件的列头
            fileWriter.append("列1");
            fileWriter.append(",");
            fileWriter.append("列2");
            fileWriter.append("\n");

            // 生成并写入数据
            for (int i = 1; i <= numRows; i++) {
                fileWriter.append("\"数据" + i + "\"");
                fileWriter.append(",");
                fileWriter.append("\"数据" + i + "\"");
                fileWriter.append("\n");
                // 继续为每一列添加数据
            }

            System.out.println("CSV文件生成成功：" + csvFilePath);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
