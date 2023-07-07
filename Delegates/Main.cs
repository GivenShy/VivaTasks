using System;
namespace Delegates
{
	public class MainClass
	{
		public static void Main()
		{
			Button button = new Button();
			button.ConsoleReadEvent += () => Console.WriteLine("The button that I created was clicked");
			button.Click();
			Console.ReadKey();
		}
	}
}

