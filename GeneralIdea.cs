using System;
using System.IO;
 
public class Downloader
{
	string path = @"D:\";
 
	public Downloader()
	{
	}
 
  public void throughFiles()
  {
  	DirectoryInfo dir = new DirectoryInfo(path);
  	int nbr = Directory.EnumerateDirectories(path);
  	int count = 0;
 
  	foreach (FileInfo file in dir)
  	{
      	string nameOfFile = file.Name;
     	 var url = "https:website.com/id/" + nameOfFile;
      	var web = new HtmlWeb();
      	var doc = web.Load(url);
 
      	string value = doc.DocumentNode.SelectNodes(@"/div/div/tag").First().Attributes["name_tag"].Value;
 
      	moveToNewDirectory(value);
            
  	}
  }
 
	public void moveToNewDirectory(string value)
	{
    	using (DirectoryInfo dr = new DirectoryInfo())
    	{
        	dr.Create(path + "\\" + value);
        	file.MoveTo(dr.Path);
    	}
    	Console.WriteLine(((((count++) / nbr) * 100)) + "%");
	}
}
