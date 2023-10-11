#!/bin/bash

csvFilePath="your_file2.csv"  # 替换为你要保存的文件路径
numRows=400

# 写入CSV文件的列头
echo "列1,列2" > "$csvFilePath"

# 生成并写入数据
for i in $(seq 1 $numRows); do
  echo "\"数据$i\",\"数据$i\"" >> "$csvFilePath"
  # 继续为每一列添加数据
done

echo "CSV文件生成成功: $csvFilePath"
