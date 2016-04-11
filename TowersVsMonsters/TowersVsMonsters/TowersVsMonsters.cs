using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TowersVsMonsters.GameClasses;

namespace TowersVsMonsters
{
    class TowersVsMonsters
    {
        static void Main(string[] args)
        {
            // Game Init
            InitScreen();
            var game = new Game();

            // Game Loop
            while (true)
            {
                var frameStart = DateTime.Now;
                // Change Difficulty Level (?) - if there is time

                // User Input

                // Update
                //      Move Objects
                //      Update BulletBar
                //      Spawn Enemies, Bullets, Etc.
                //      Collision Check
                //      Remove Objetcs

                var frameEnd = DateTime.Now;
                var frameDuration = frameEnd - frameStart;
                var frameDurationLeft = game.FrameDuration - frameDuration.Milliseconds;

                Thread.Sleep(frameDurationLeft);

                // Clear Screen (?)
                // Draw

                // Game Over Check
                var isGameOver = GameOverCheck();
                if (isGameOver)
                {
                    break;
                }

                game.NextFrame();
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

        private static void InitScreen()
        {
            Console.BufferWidth = Console.WindowWidth = 80;
            Console.BufferHeight = Console.WindowHeight = 60;

            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.Clear();
        }

        private static bool GameOverCheck()
        {
            throw new NotImplementedException();
        }
    }
}
