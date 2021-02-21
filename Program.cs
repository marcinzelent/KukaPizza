using System;
using KukaPizza.Controllers;

namespace KukaPizza
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Kuka Pizza";
            Console.CursorVisible = false;
            Console.Clear();

            new MainController();
        }
    }
}
