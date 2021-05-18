using System;
using System.IO;

namespace FirstProject
{
    public class PathUtilities
    {
        public static string GetPath(string filePath)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);
        }
    }
}
