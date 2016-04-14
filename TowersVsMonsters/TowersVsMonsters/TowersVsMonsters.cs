using System;
using System.Text;
using System.Threading;
using TowersVsMonsters.GameClasses;
using TowersVsMonsters.Utils;

namespace TowersVsMonsters
{
    class TowersVsMonsters
    {
        static void Main(string[] args)
        {
            // Game Init
            InitScreen();
            var game = new Game();
            
            // Wait for the user before starting the game
            WaitForUser();


            // Game Loop
            while (true)
            {
                var frameStart = DateTime.Now;


                game.ChangeDifficultyLevel();

                game.UserInput();

                game.Update();

                game.Draw();

                // Game Over Check
                var isGameOver = game.GameOverCheck();
                if (isGameOver)
                {
                    break;
                }

                game.NextFrame();

                // Handle FPS
                var frameEnd = DateTime.Now;
                var frameDuration = frameEnd - frameStart;
                var frameDurationLeft =
                    game.FrameDuration - frameDuration.Milliseconds;

                Thread.Sleep(Math.Max(0, frameDurationLeft));
            }

            // Sleep for a second or two (?)
            Thread.Sleep(1000);

            // Clear Screen
            Console.Clear();

            // Display Final Score
            Score.DisplayFinalSocre(10, 10);

            // Sleep for a four-five seconds
            // or press any key to exit
            Thread.Sleep(4000);

            // Close the game
            Environment.Exit(0);
        }

        private static void WaitForUser()
        {
            Console.Clear();
            ConsoleMessage.Message("Press any key to start.");
            Console.ReadKey(intercept: true);
            while (Console.KeyAvailable)
            {
                Console.ReadKey(intercept: true);
            }
            Console.Clear();
        }

        private static void InitScreen()
        {
            Console.BufferWidth = Console.WindowWidth =
                Game.WINDOW_WIDTH;

            Console.BufferHeight = Console.WindowHeight =
                Game.WINDOW_HEIGHT;

            Console.CursorVisible = false;

            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.Clear();
        }
    }
}
