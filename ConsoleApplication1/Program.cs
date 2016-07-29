using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(@"C:\Temp\WriteLines2.txt");

                Console.WriteLine("Devuelve true si es un rss valido ");

                foreach (var item in lines)
                {
                    var test = HelperRss.RssUrlIsValid(item);
                    Console.WriteLine("\t" + test + "\t" + item);
                }

                Console.WriteLine("Press any key to exit.");
                System.Console.ReadKey();

            }
            catch (Exception e) {
                Console.WriteLine("el archivo C:/Temp/WriteLines2.txt no existe");
                System.Console.ReadKey();
            }

          
        }
    }
}
