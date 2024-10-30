using SnakeConsoleApp.Enums;
using SnakeConsoleApp.Factory;
using SnakeConsoleApp.Helpers;
using SnakeConsoleApp.Installers;
using SnakeConsoleApp.Lines;
using SnakeConsoleApp.UI;
using System;

namespace SnakeConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            UIService uiService = new UIService();
            uiService.GetMenu();

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                uiService.GetCommand(key.Key);
            }

        }
    }
}