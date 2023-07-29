#### 2023年1月29日

本身默认index网页在tomcat文件下的

webapps\ROOT

┗index.jsp



既に「src/main/webapp」で作成した場合の「WebContent」への変更方法

1. プロジェクトを右クリックし、[新規]-[フォルダ]で WebContentフォルダを作成
2. プロジェクトを右クリックし、プロパティを表示
3. 「デプロイメント・アセンブリー」を選択
4. /src/main/webapp を選択し、「除去」を押す
5. 「追加」を押し、「フォルダ」を選び、「次へ」を押し、「WebContent」を選び「完了」を押す
6. 「適用して閉じる」を押す

WEB-INF是个隐藏目录 放进去是访问不到的

##### web.xml的替换优先级

最优先 project里的web.xml

第二优先 eclipse的 Server/web.xml

最后是tomcat文件包里的 web.xml