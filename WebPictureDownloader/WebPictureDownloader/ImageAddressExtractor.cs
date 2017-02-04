using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebPictureDownloader
{
    class ImageAddressExtractor
    {
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
    }
}
