using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic;
using System.IO;

namespace TestApp
{
    class Program
    {        
        static void Main(string[] args)
        {
            string pathFile = AppDomain.CurrentDomain.BaseDirectory + "data.txt";

            ProcessFileBL processFile = new ProcessFileBL();
            processFile.ReadFile(pathFile);
            foreach (string result in processFile.lstResultProcess)
            {
                Console.WriteLine(result);
            }
            Console.ReadLine();
        }
    }
}
