using System;
namespace Delegates
{
	public class Button
	{
        public delegate void ClickHandler();
        public event ClickHandler ConsoleReadEvent;

        public void Click()
        {
            if(ConsoleReadEvent!=null)
                ConsoleReadEvent.Invoke();
            Console.WriteLine("The button is clicked");
        }
    }
}

