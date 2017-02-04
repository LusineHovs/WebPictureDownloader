using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPictureDownloader
{
    class Program
    {
        static void Main(string[] args)
        {
            //HtmlDownloader class execution
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var path = Path.Combine(desktop, "file1.html");
            var hd = new HtmlDownLoader(path);
            hd.Save("http://mic.am");
            hd.Dispose();


            //ImageAddressExtractor class execution
            
            // Image address extraction process

            string fromPath = path;
            string toPath = Path.Combine(desktop, "imglinks1.txt");      //"C:/Users/L.Hovsepyan/Desktop/imglinks1.txt";
            string finalPath = Path.Combine(desktop, "imgfinlinkes1.txt");             //"C:/Users/L.Hovsepyan/Desktop/imgfinallinkes1.txt";
            ImageAddressExtractor.ImgCodeExtractor(fromPath, toPath);

            // Image address's final extraction process
            ImageAddressExtractor.ImgCodeCorrector(toPath, finalPath);
            Console.WriteLine(ImageAddressExtractor.ImgCodeCorrector(toPath, finalPath));
            string str = ImageAddressExtractor.ImgCodeCorrector(toPath, finalPath);
            

            ImageDownloader.AllImgSaver(finalPath);
            Console.ReadKey();

        }
    }
}
