namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = @$"{Console.ReadLine()}";
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            SortedDictionary<string, List<FileInfo>> extFiles = new ();

            string[] files = Directory.GetFiles(inputFolderPath);

            foreach (string file in files) 
            {
                FileInfo fileInfo= new FileInfo(file);

                if(!extFiles.ContainsKey(fileInfo.Extension))
                {
                    extFiles.Add(fileInfo.Extension, new List<FileInfo>());
                }

                extFiles[fileInfo.Extension].Add(fileInfo);
            }

            StringBuilder sb = new StringBuilder();

            foreach(var item in extFiles.OrderByDescending(ef => ef.Value.Count)) 
            {
                sb.AppendLine(item.Key);

                foreach(var file in item.Value.OrderBy(f => f.Length))
                {
                    sb.AppendLine($"--{file.Name} - {(double)file.Length/1024:f3}kb");
                }
            }

            return sb.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + reportFileName;

            File.WriteAllText(filePath, textContent);
        }
    }
}
