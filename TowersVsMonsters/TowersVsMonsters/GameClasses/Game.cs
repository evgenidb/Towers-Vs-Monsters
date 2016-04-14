using System;
using System.Collections.Generic;
using TowersVsMonsters.GameClasses.UserCommands;
using TowersVsMonsters.GameClasses.UserCommands.Interfaces;
using static TowersVsMonsters.GameClasses.Enums.DifficultyLevel;
using static TowersVsMonsters.GameClasses.GameObjectFactory;
using static TowersVsMonsters.Utils.Util;

namespace TowersVsMonsters.GameClasses
{
    public class Game
    {
        public int FrameDuration { get; } = 50; // In milliseconds
        private int CurrentFrame { get; set; } = 1;

        private Level Level { get; set; }
        private View View { get; set; }

        private IUserCommand UserCommand { get; set; }
        public static Random RandomGenerator { get; private set; }

        public const int WINDOW_WIDTH = 100;
        public const int WINDOW_HEIGHT = 30;

        public Game()
        {
            RandomGenerator = new Random();
            Level = new Level();
            View = new View(Level);
            UserCommand = null;
            Score.Init();
        }

        public void ChangeDifficultyLevel()
        {
            int easyScoreUpperBound = 100;
            int normalScoreUpperBound = 200;

            if (Score.CurrentBestScore < easyScoreUpperBound && Level.DifficultyLevel != Easy)
            {
                Level.SetDifficulty(Easy);
            }
            else if (easyScoreUpperBound <= Score.CurrentBestScore && Score.CurrentBestScore < normalScoreUpperBound && Level.DifficultyLevel != Normal)
            {
                Level.SetDifficulty(Normal);
            }
            else if(normalScoreUpperBound <= Score.CurrentBestScore && Level.DifficultyLevel != Hard)
            {
                Level.SetDifficulty(Hard);
            }
        }

        public void UserInput()
        {
            // Clear the previous command
            UserCommand = null;

            if (Console.KeyAvailable)
            {
                // Catch key event but don't display it
                var key = Console.ReadKey(intercept: true).Key;

                // Hold key fix
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(intercept: true);
                }

                // Keys for lanes
                var laneKeys = new List<ConsoleKey>()
                {
                    ConsoleKey.D1,
                    ConsoleKey.D2,
                    ConsoleKey.D3,
                    ConsoleKey.D4,
                    ConsoleKey.D5,
                    ConsoleKey.D6,
                    ConsoleKey.D7,
                    ConsoleKey.D8,
                    ConsoleKey.D9,
                    ConsoleKey.D0,
                };

                var laneIndex = laneKeys.IndexOf(key);

                IUserCommand command = null;

                if (0 <= laneIndex && laneIndex < Level.Lanes.Count)
                {
                    if (!Level.Menu.IsMenuLocked)
                    {
                        var replacementBullet = RandomBullet();
                        var bullet =
                            Level.Menu.UseBullet(
                                replacementBullet);

                        command = new ShootCommand(
                            laneIndex, bullet);
                    }
                }
                else
                {
                    // Handle the other keys
                    switch (key)
                    {
                        case ConsoleKey.Spacebar:
                            var replacementBullet =
                                RandomBullet();
                            command =
                                new DiscardBulletCommand(
                                    replacementBullet);
                            break;
                        default:
                            break;
                    }
                }

                // Set the new command,
                // null if no command
                UserCommand = command;
            }
        }

        public void Update()
        {
            Level.Update(
                currentFrame: CurrentFrame,
                command: UserCommand);
        }

        public void Draw()
        {
            View.Draw();
        }


        public void NextFrame()
        {
            CurrentFrame += 1;
        }

        public bool GameOverCheck()
        {
            foreach (var lane in Level.Lanes)
            {
                var tower = lane.Tower;
                foreach (var monster in lane.Monsters)
                {
                    if (HasCollision(monster, tower))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
