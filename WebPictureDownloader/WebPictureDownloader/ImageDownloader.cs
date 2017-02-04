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
            byte[] data;
            using (var client = new WebClient())
            {
                data = client.DownloadData(url);
            }
            var desktop1 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var path1 = Path.Combine(desktop1,"img{i}.svg");
            File.WriteAllBytes(path1, data);   //"C:\Users\L.Hovsepyan\Desktop\img{i}.svg"
        }


        public static void AllImgSaver(string finalPath)
        {
            
            StreamReader swr = new StreamReader(finalPath);
            string line = swr.ReadLine();
            int i = 1;


            while (line!=null && line.Contains(".svg"))
            {
                ImgSaver(line, i);
                i++;
            }

            swr.Close();
        }
    }
}
