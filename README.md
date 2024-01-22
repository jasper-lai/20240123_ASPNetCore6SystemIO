## 靜態元素 (Static Elements) 的單元測試, 以 System.IO.File.ReadAllText 為例
Unit Test for Static Elements (System.IO.File.ReadAllText) in ASP.NET Core 6 MVC   

## 前言

接續前一篇 <a href="https://www.jasperstudy.com/2024/01/static-elements-datetimenow.html" target="_blank">樂透開獎(含日期限制)</a> 的例子, 假設有一個新的需求:   "樂透開奬有一個前置作業, 必須由主辦人員按下[開始]按鈕, 才能開獎".  

本文假設按下[開始]按鈕, 會在主機端產生一個檔案 (start.txt), 內含主辦人員的姓名.  

因此, 程式要增加一個讀取檔案內容的動作.  
* 若可讀到 start.txt, 才可開獎, 並回傳開獎的結果, 要再加上主辦人員的姓名.  
* 若讀不到 start.txt, 則不可開獎, 並回傳警告訊息.  
  * "", -2, "主辦人員尚未按下[開始]按鈕".   // 第1個空字串, 代表主辦人員的姓名

這裡很單純的想法, 是用 File.ReadAllText() 的方法, 因為是 static class + static method 要如何建立測試呢?  

以下係採 參考文件1..及2.. 方式進行演練及實作.  

完整範例可由 GitHub 下載.

<!--more-->

## 演練細節

### 步驟_1: 安裝以下套件
* TestableIO.System.IO.Abstractions.Wrappers 20.0.4: 
  * 用以將 System.IO 的類別, 以 interface 的方式進行打包. 以 System.IO.File 為例, 會有 IFile 介面及 FileWrapper 類別.  
* TestableIO.System.IO.Abstractions.TestingHelpers 20.0.4
  * 主要有一些現成的 mock 類別, 以利測試之用.  



### 步驟_6: 檢查測試的結果



## 結論


## 參考文件

* <a href="https://www.nuget.org/packages/System.IO.Abstractions" target="_blank">1.. (Nuget) System.IO.Abstractions</a>  
* <a href="https://github.com/TestableIO/System.IO.Abstractions" target="_blank">2.. 上述 nuget 套件的原始程式碼</a>  
* <a href="https://learn.microsoft.com/en-us/dotnet/api/system.io.file?view=net-6.0" target="_blank">3.. (Microsoft Learn) File Class</a>  
> public static class File
* <a href="https://learn.microsoft.com/en-us/dotnet/api/system.io.file.readalltext?view=net-6.0" target="_blank">4.. (Microsoft Learn) File.ReadAllText Method</a>  
> public static string ReadAllText (string path);
* <a href="https://www.ruyut.com/2023/05/testableio.system-io-abstractions.html" target="_blank">5.. (Ruyut 鹿遊) C# 使用 System.IO.Abstractions 套件來模擬檔案</a>




