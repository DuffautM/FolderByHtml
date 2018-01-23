using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
 
namespace Perso
{
    public class Downloader
    {
        string path = @"D:\";
        int count = 0;
        int nbr = 0;
 
        public Downloader()
        {
        }
 
        public void throughFiles()
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            nbr = dir.GetFiles().Length;
 
            foreach (FileInfo file in dir.GetFiles())
            {
                string nameOfFile = file.Name;
                var url = "https:website.com/id/" + nameOfFile;
                var web = new HtmlWeb();
                var doc = web.Load(url);
 
                string value = doc.DocumentNode.SelectNodes(@"/div/div/tag").First().Attributes["name_tag"].Value;
 
                moveToNewDirectory(file, value);
 
            }
        }
 
        public void moveToNewDirectory(FileInfo file, string value)
        {
            DirectoryInfo dr = new DirectoryInfo(path);
            string newPath = path + "/" + value;
 
            try
            {
                dr.CreateSubdirectory(newPath);
                file.MoveTo(dr.FullName);
            }
            catch
            {
                Console.WriteLine("Error with the file : " + file + " for the folder : " + newPath);
            }
 
            Console.WriteLine(((((count++) / nbr) * 100)) + "%");
        }
    }
 
}
