using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TowersVsMonsters.Game;

namespace TowersVsMonsters
{
    class TowersVsMonsters
    {
        
        public const int FRAME_DURATION = 50;   // In milliseconds
        public static int CurrentFrame { get; set; } = 1;


        static void Main(string[] args)
        {
            // Game Init


            // Game Loop
            while (true)
            {
                var frameStart = DateTime.Now;
                // Change Level (?) - if there is time

                // User Input

                // Update
                //      Move Objects
                //      Update BulletBar
                //      Spawn Enemies, Bullets, Etc.
                //      Collision Check
                //      Remove Objetcs

                var frameEnd = DateTime.Now;
                var frameDuration = frameEnd - frameStart;
                var frameDurationLeft = FRAME_DURATION - frameDuration.Milliseconds;

                Thread.Sleep(frameDurationLeft);

                // Clear Screen (?)
                // Draw

                // Game Over Check
                var isGameOver = GameOverCheck();
                if (isGameOver)
                {
                    break;
                }

                CurrentFrame++;
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

        private static bool GameOverCheck()
        {
            throw new NotImplementedException();
        }
    }
}
