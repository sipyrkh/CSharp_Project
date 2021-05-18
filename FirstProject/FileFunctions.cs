using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace FirstProject
{
    public class FileFunctions
    {
        private static readonly int differenceInSeconds = 10;
        private static readonly string pathRegex = @"(\/)([a-zA-Z]+)\.(\S+)";
        private static readonly string additionalPrefixToFile = "res_";

        public static List<FileInfo> GetLastCreatedFiles(string filePath, string fileExtension)
        {
            string[] files = Directory.GetFiles(filePath);
            var fileList = new List<FileInfo>();
            foreach(string filename in files)
            {
                FileInfo file = new(filename);
                if(file.Extension.ToLower().Contains(fileExtension.ToLower()))
                {
                    fileList.Add(file);
                }
            }
            fileList.Sort((x, y) => y.CreationTime.CompareTo(x.CreationTime));

            var finalFiles = new List<FileInfo>()
            {
                fileList[0]
            };
            for (int i = 0; i < fileList.Count; i++)
            {
                if (i + 1 < fileList.Count)
                {
                    long lastCreationTimeInSeconds = new DateTimeOffset(fileList[0].CreationTime).ToUnixTimeSeconds();
                    long nextCreationTimeInSeconds = new DateTimeOffset(fileList[i + 1].CreationTime).ToUnixTimeSeconds();
                    if (lastCreationTimeInSeconds - nextCreationTimeInSeconds <= differenceInSeconds)
                    {
                        finalFiles.Add(fileList[i + 1]);
                    }
                }
            }
            return finalFiles;
        }

        public static string RewriteFilesWithLinesCount(string filePath, int lineCount)
        {
            var dataList = new List<string>();
            var resultList = new List<string>();
            using (StreamReader sr = new(filePath, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    dataList.Add(line);
                }
            }
            resultList.Add(dataList[0]);
            for(int i = 1; i <= lineCount; i++)
            {
                resultList.Add(dataList[i]);
            }
            dataList.RemoveRange(1, lineCount);
            WriteFile(filePath, dataList);
            Regex regex = new(pathRegex);
            string fileName = regex.Match(filePath).Groups[2].Value;
            return WriteFile(filePath.Replace(fileName, additionalPrefixToFile + fileName), resultList);
        }

        private static string WriteFile(string filePath, List<string> list)
        {
            try
            {
                using StreamWriter sw = new(filePath, false, System.Text.Encoding.Default);
                foreach (string str in list)
                {
                    sw.WriteLine(str);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return filePath;
        }
    }
}
