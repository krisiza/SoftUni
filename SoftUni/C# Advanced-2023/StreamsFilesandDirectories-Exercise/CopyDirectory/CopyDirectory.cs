namespace CopyDirectory
{
    using System;
    using System.IO;

    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath = @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string sourceDir, string destinationDir)
        {
            if (Directory.Exists(destinationDir))
            {
                Directory.Delete(destinationDir, true);
            }

            Directory.CreateDirectory(destinationDir);

            string[] files = Directory.GetFiles(sourceDir);

            foreach (string file in files) 
            {
                string fileName = Path.GetFileName(file);

                string destination = Path.Combine(destinationDir, fileName);

                File.Copy(file, destination);
            }
        }
    }
}
