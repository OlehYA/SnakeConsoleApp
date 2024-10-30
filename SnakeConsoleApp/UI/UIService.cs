using SnakeConsoleApp.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SnakeConsoleApp.UI
{
    public class UIService
    {
        private GamePlay _gamePlay = new GamePlay();
        private UserService _userService = new UserService();
        private User _user = new User();


        public void GetMenu()
        {
            Console.Clear();

            // Фон та кольори джунглів
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;

            // Верхня частина екрана з гілками дерев
            Console.SetCursorPosition(20, 2);
            Console.WriteLine(" ████████████████████████████████████████████████████████████████████████████████");
            Console.SetCursorPosition(20, 3);
            Console.WriteLine(" █   ██        ██        ██         ██     ██         ██        ██         ██  █");
            Console.SetCursorPosition(20, 4);
            Console.WriteLine(" ████████████████████████████████████████████████████████████████████████████████");

            // Заголовок у вигляді ASCII-арту
            Console.SetCursorPosition(27, 6);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("    ___      _      ___  ___  _   _  _  _   _ ");
            Console.SetCursorPosition(27, 7);
            Console.WriteLine("   / __|    /_\\    | __|| _ \\| | | || \\| | | | ");
            Console.SetCursorPosition(27, 8);
            Console.WriteLine("   \\__ \\   / _ \\   | _| |  _/| |_| || .` | |_| ");
            Console.SetCursorPosition(27, 9);
            Console.WriteLine("   |___/  /_/ \\_\\  |___||_|   \\___/ |_|\\_| (_) ");
            Console.SetCursorPosition(27, 11);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("    ~~~~~~~~~~~~~~~~ Welcome to Snake Game ~~~~~~~~~~~~~~~~");

            // Інструкції гри в стилі джунглів
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(34, 13);
            Console.WriteLine("<< Press Enter to Start the Game >>");
            Console.SetCursorPosition(34, 15);
            Console.WriteLine("<< Use Arrow Keys to Guide the Snake >>");
            Console.SetCursorPosition(34, 17);
            Console.WriteLine("<< Press C to Create a User >>");
            Console.SetCursorPosition(34, 19);
            Console.WriteLine("<< Press S to View Scores >>");
            Console.SetCursorPosition(34, 21);
            Console.WriteLine("<< Press ESC to Exit >>");

            // Анімація змії, яка пробирається через ліани
            Console.ForegroundColor = ConsoleColor.DarkRed;
            string snakeBody = "~ ~ ~ O";
            for (int i = 0; i < 30; i++)
            {
                Console.SetCursorPosition(30 + i, 25);
                Console.Write(snakeBody);
                Thread.Sleep(150); // Ефект руху змійки
                Console.SetCursorPosition(30 + i, 25);
                Console.Write(new string(' ', snakeBody.Length)); // Стираємо попереднє положення
            }

            Console.SetCursorPosition(60, 25);
            Console.WriteLine(snakeBody);


        }

        public void GetCommand(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.Enter:
                    StartGame();
                    break;
                case ConsoleKey.C:
                    CreateUserForm();
                    break;
                case ConsoleKey.S:
                    ScoreBoard();
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                default:
                    GetMenu();
                    break;

            }
        }

        private void StartGame()
        {
            Console.Clear();
            _gamePlay.StartGame(_user);
            Concede();
        }

        private void CreateUserForm()
        {
            Console.Clear();
            Console.WriteLine("Create User Form ");

        Label:

            Console.Write("Enter your name please:");
            string userNme = Console.ReadLine();

            try
            {
                _user = _userService.CreateUser(userNme);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto Label;
            }

            Console.WriteLine("The user was saved ");
            Console.WriteLine("Press Backspace to back");
        }


        private void ScoreBoard()
        {
            Console.Clear();
            Console.WriteLine("Score Board");

            var users = _userService.GetAllUsers();

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Name} with score {user.Sroce}");
            }

            Console.WriteLine("Press Backspace to back");
        }

        private void Concede()
        {
            Console.Clear();
            Console.WriteLine("Game over");
            Console.WriteLine("To try again press Enter");
            Console.WriteLine("Back to menu press Backspase");

        }

    }
}
