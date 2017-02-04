using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace WebPictureDownloader
{
    class ImageDownloader
    {
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
    }
}
