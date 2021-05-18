using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FirstProject
{
    class Program
    {
        private static readonly int numberOfLines = 10;
        private static readonly string pathForTaskOne = PathUtilities.GetPath(@"Resources/task1");
        private static readonly string pathForTaskThree = PathUtilities.GetPath(@"Resources/task3/cases.txt");

        static void Main(string[] args)
        {
            // First task
            var filesInfo = FileFunctions.GetLastCreatedFiles(pathForTaskOne, "txt");
            foreach(FileInfo file in filesInfo)
            {
                Console.WriteLine("File name: " + file.Name);
            }

            // Second task
            string[] firstMass = { "Alex", "Dima", "Kate", "Galina", "Ivan" };
            string[] secondMass = { "Dima", "Ivan", "Kate" };
            var massResult = ArrayFunctions.GetUniqueArray(firstMass, secondMass);
            foreach (string str in massResult)
                Console.WriteLine(str);

            var firstList = new List<string>() { "Alex", "Dima", "Kate", "Galina", "Ivan" };
            var secondList = new List<string>() { "Dima", "Ivan", "Kate" };
            var listResult = firstList.Except(secondList);

            foreach (string str in listResult)
                Console.WriteLine(str);

            //Third task
            var resFile = FileFunctions.RewriteFilesWithLinesCount(pathForTaskThree, numberOfLines);
            Console.WriteLine(resFile);
        }
    }
}
