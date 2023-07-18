using System;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Drawing.Imaging;

namespace Multithreading
{
    public class MainClass
    {
        public MainClass()
        {
        }



        public static async Task Main(string[] args)
        {   //---Task1
            //PrintFromFiles("/Users/jivanshmavonyan/Desktop/Tasks/ExceptionHandling/text.txt",
            //    "/Users/jivanshmavonyan/Desktop/Tasks/ExceptionHandling/t.txt");
            //Console.ReadKey();
            //---Task2
            //var task =  ChangePictures("C:\\Users\\jivan\\Source\\Repos\\GivenShy\\VivaTasks\\Multithreading\\Pictures\\");
            //Console.WriteLine("Something happened + " + task.ToString());
            //await task;
            // does not supported on mac

            //---Task3
            Console.WriteLine("Start");
            MyPlanner planner = new MyPlanner();
            planner.timer(TimeSpan.FromSeconds(1), () =>
            {
                Console.WriteLine("Hello");
                Thread.Sleep(2000);
                Console.WriteLine("ancav jamanaky");
            });
            Thread.Sleep(10000);
            planner.Dispose();
            Thread.Sleep(2000);
            Console.WriteLine("Main finished its job");

        }

        //public static async Task ChangePictures(string path)
        //{
        //    string[] files = Directory.GetFiles(path);
        //    List<Task> tasks = new List<Task>();
        //    foreach (string file in files)
        //    {
        //        tasks.Add(Task.Run(() => { Reformat(file); })); 
        //    }
        //    await Task.WhenAll(tasks);
        //} 

        //public static async void Reformat(string path)
        //{
        //    var image = Task<Bitmap>.Run(() => { return ChangeSize(path); });
        //    await image;
        //    Console.WriteLine("Hello");
        //    var color = Task.Run(() => { return ChangeColor(image.Result); });
        //    await color;

        //    string[] results = path.Split('.');
        //    Console.WriteLine("Saving");
        //    color.Result.Save(results[0] + "_new." + results[1], ImageFormat.Jpeg);
        //}

        //public static Bitmap ChangeSize(string path)
        //{
        //    Console.WriteLine("Changing the size");
        //    Image image = Image.FromFile(path); ;


        //    var rectangle = new Rectangle(0, 0, 256, image.Height);
        //    var bit = new Bitmap(256, image.Height);

        //    bit.SetResolution(image.HorizontalResolution, image.VerticalResolution);
        //    using (var gr = Graphics.FromImage(bit))
        //    {
        //        gr.CompositingMode = CompositingMode.SourceCopy;
        //        gr.CompositingQuality = CompositingQuality.HighQuality;
        //        gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //        gr.SmoothingMode = SmoothingMode.HighQuality;
        //        gr.PixelOffsetMode = PixelOffsetMode.HighQuality;


        //        using (var wrapMode = new ImageAttributes())
        //        {
        //            wrapMode.SetWrapMode(WrapMode.TileFlipXY);
        //            gr.DrawImage(image, rectangle, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
        //        }
        //    }
        //    image.Dispose();

        //    return bit;
        //}

        //public static Bitmap ChangeColor(Bitmap img)
        //{
        //    Console.WriteLine("Changing the color");
        //    int width = img.Width;
        //    int height = img.Height;

        //    Color p;

        //    for (int y = 0; y < height; y++)
        //    {
        //        for (int x = 0; x < width; x++)
        //        {
        //            p = img.GetPixel(x, y);

        //            int a = p.A;
        //            int r = p.R;
        //            int g = p.G;
        //            int b = p.B;

        //            int avg = (r + g + b) / 3;

        //            img.SetPixel(x, y, Color.FromArgb(a, avg, avg, avg));
        //        }
        //    }
        //    return img;
        //    //bit.Save("C:\\Users\\jivan\\Source\\Repos\\GivenShy\\VivaTasks\\Multithreading\\Pictures\\image.jpg", ImageFormat.Jpeg);
        //}
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

