using System;
using KukaPizza.Controllers;

namespace KukaPizza.Views
{
    public class MainView : View
    {
        private MainController _controller;
        public MainView(MainController controller)
        {
            _controller = controller;
            Init(_controller);
            
        }
        protected override void Draw()
        {
            Console.Write(@"



 __  __           __                   ____                                   
/\ \/\ \         /\ \                 /\  _`\   __                            
\ \ \/'/'  __  __\ \ \/'\      __     \ \ \L\ \/\_\  ____    ____      __     
 \ \ , <  /\ \/\ \\ \ , <    /'__`\    \ \ ,__/\/\ \/\_ ,`\ /\_ ,`\  /'__`\   
  \ \ \\`\\ \ \_\ \\ \ \\`\ /\ \L\.\_   \ \ \/  \ \ \/_/  /_\/_/  /_/\ \L\.\_ 
   \ \_\ \_\ \____/ \ \_\ \_\ \__/.\_\   \ \_\   \ \_\/\____\ /\____\ \__/.\_\
    \/_/\/_/\/___/   \/_/\/_/\/__/\/_/    \/_/    \/_/\/____/ \/____/\/__/\/_/




    1. Order a pizza
    2. Check orders
    
    0. Exit         



================================================================================
                 Copyright © 2019 Marcin Zelent & Paulius Klezys
================================================================================");
        }

        protected override void Interact()
        {
            int choice = 0;

            do
            {
                choice = Console.ReadKey(true).KeyChar;

                switch (choice)
                {
                    case '1':
                        _controller.OpenOrderPizza();
                        break;
                    case '2':
                        _controller.OpenCheckOrders();
                        break;
                }

                Draw();
            } while (choice != '0');

            if (choice == '0') _controller.Close();
        }
    }
}