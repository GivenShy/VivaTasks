using System;
using System.IO;
using System.Drawing;

namespace Multithreading
{
    public class MainClass
    {
        public MainClass()
        {
        }

        public static void Main()
        {   //---Task1
            //PrintFromFiles("/Users/jivanshmavonyan/Desktop/Tasks/ExceptionHandling/text.txt",
            //    "/Users/jivanshmavonyan/Desktop/Tasks/ExceptionHandling/t.txt");
            //Console.ReadKey();
            //string[] files = Directory.GetFiles("/Users/jivanshmavonyan/Desktop/Tasks/Multithreading/Pictures");
            //foreach (string str in files)
            //{
            //    Console.WriteLine(str);
            //}
            //Image img = Image.FromFile(files[0]);


            //var rectangle = new Rectangle(0, 0, 256, img.Height);
            //var bit = new Bitmap(256, img.Height);
            // does not supported on mac

            Console.ReadKey();

        }

        public static void PrintFromFiles(string path1, string path2)
        {
            int elapsedSeconds = 0;
            Timer timer = new Timer(state =>
            {
                elapsedSeconds++;
                Console.WriteLine("Elapsed seconds: " + elapsedSeconds);
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
            Task<int> task1 = new Task<int>(() => readLineByLine(path1));
            Task<int> task2 = new Task<int>(() => readLineByLine(path2));
            task1.Start();
            Console.WriteLine("started");
            task2.Start();
            Console.WriteLine("started");
            task1.Wait();
            task2.Wait();

            int sum = task1.Result + task2.Result;
            Console.WriteLine(sum);
            timer.Dispose();
        }



        public static int readLineByLine(string path)
        {
            int counter = 0;

            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    counter++;
                }
            }
            return counter;
        }

    }
}

