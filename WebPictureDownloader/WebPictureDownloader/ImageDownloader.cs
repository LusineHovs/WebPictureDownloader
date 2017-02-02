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
            File.WriteAllBytes(@"C:\Users\L.Hovsepyan\Desktop\img{i}.jpg", data);
        }


        public static void AllImgSaver(string finalPath)
        {
            
            StreamReader swr = new StreamReader(finalPath);
            string line = swr.ReadLine();
            int i = 1;


            while (string.IsNullOrEmpty(line) /*&& line.Contains(".jpg")*/)
            {
                ImgSaver(line, i);
                i++;
            }

            //for (int j = 0; j < i; j++)
            //{
            //    ImgSaver(line, j);
            //}



            swr.Close();
        }
    }
}
