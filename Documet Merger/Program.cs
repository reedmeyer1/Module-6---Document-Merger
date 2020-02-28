using System;
using System.IO;

namespace Documet_Merger
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Write("Document Merger\r\n");
                Console.Write("\r\n");
                Console.Write("What is the name of your file?: ");
                Console.Write(Program.GetUserInput());
                Console.Write("\r\n");
                Console.Write("What is the name of your second file?: ");
                Console.Write(Program.GetUserInput());
                Console.Write("\r\n");
                Console.Write("Your new merged file says:\r\n");
                Console.Write(Program.ReadMergedFile());
                Console.Write("Would you like to do another? (y/n): ");
            } while (Console.ReadLine().ToLower().Equals("y"));
            
        }
        static string GetUserInput()
        {
            string input = "";
            try
            {
                input = Console.ReadLine();
                string row;
                StreamReader sr = new StreamReader(input);
                row = sr.ReadLine();
                sr.Close();
                string filePath = System.IO.Path.GetFullPath("MergedDocument");
                StreamWriter sw = new StreamWriter(filePath, append: true);
                sw.WriteLine(row);
                sw.Close();
                return input;
            }
            catch(Exception e)
            {
                string except = "Exception: " + e.Message;
                return except;
            }
        }
        static string ReadMergedFile()
        {
            string row;
            StreamReader sr = new StreamReader("MergedDocument");
            row = sr.ReadLine();
            while (row != null)
            {
                Console.WriteLine(row);
                row = sr.ReadLine();
            }
            sr.Close();
            return row;
        }
    }
}
