# WebPictureDownloader

The *WebPictureDownloader* application solves very common problem.

#What does is solve?
It downloads all the images of the webpage you want. Below I will explain the steps of the whole porcess.
 - **HTMLDownLoader** - first it downloads the html code of the webpage(implementing IDisposable interface),
 - **ImageAddressExtractor** - then extracts image sources using Regular Expressions,
 ```C#
public static void ImgCodeExtractor(string fromPath, string toPath)
  {
      string data = File.ReadAllText(fromPath);
      Regex imgRegex = new Regex("<img.+?src=[\"'](.+?)[\"'].*?>");
      MatchCollection imgMatches = imgRegex.Matches(data);
      string s = string.Empty;
      foreach (Match imgMatch in imgMatches)
      {
          s += imgMatch.Value + "\r\n";
      }
      File.WriteAllText(toPath, s.ToString());
  }


  public static string ImgCodeCorrector(string toPath, string finalPath)
  {
      string finalLine = "";
      string line;
      StreamReader file = new StreamReader(toPath);
      while ((line = file.ReadLine()) != null)
      {
          finalLine += "http://www.micarmenia.am" + Regex.Match(line, "<img.+?src=[\"'](.+?)[\"'].+?>", RegexOptions.IgnoreCase).Groups[1] + "\r\n";
      }
      File.WriteAllText(finalPath, finalLine.ToString());
      return finalLine;
  }
  ```
 - **ImageDownloader** - after extracting images' codes, downloads all the images of the webpage using WebClient.
 ```c#
public static void ImgSaver(string url, int i)
 {
     var desktop1 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
     var path1 = Path.Combine(desktop1, $"img{i}.svg");

     using (var client = new WebClient())
     {
         Console.WriteLine(url);
         Uri uri = new Uri(url);
         client.DownloadFileAsync(uri, path1);
         i++;
     }
 }


 public static void AllImgSaver(string finalPath)
 {
   Console.WriteLine(finalPath);
    StreamReader swr = new StreamReader(finalPath);
   string line = string.Empty;
   int i = 1;
   Console.WriteLine(line);
  while ((line = swr.ReadLine()) != null)
   {
       Console.WriteLine(line);

       ImgSaver(line, i);
       i++;

   }

 swr.Close();
}
```


