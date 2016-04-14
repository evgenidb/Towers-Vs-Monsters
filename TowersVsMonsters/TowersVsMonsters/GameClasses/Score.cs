using System;
using System.IO;
using static TowersVsMonsters.Utils.ConsoleMessage;

namespace TowersVsMonsters.GameClasses
{
    public static class Score
    {
        #region Fields
        private static int scorePoints = 0;
        private static int currentBestScore = 0;
        #endregion

        // Scores
        public static int MonsterKilledPoints { get; set; } = 20;
        public static int BulletDiscardedPoints { get; set; } = -10;

        // Other
        public const string HIGHSCORE_FILE = @"Contents/Highscore/Highscore.txt";
        

        public static int BestScore { get; private set; } = 0;

        public static int ScorePoints
        {
            get
            {
                return scorePoints;
            }
            set
            {
                scorePoints = Math.Max(0, value);
            }
        }

        public static int CurrentBestScore
        {
            get
            {
                return currentBestScore;
            }
            set
            {
                currentBestScore = Math.Max(currentBestScore, value);
            }
        }

        public static void Init()
        {
            ScorePoints = 0;
            BestScore = LoadScore();
        }

        public static void UpdateScore(int score)
        {
            ScorePoints += score;
            CurrentBestScore = ScorePoints;
        }

        public static void DisplayScore()
        {
            Console.Write("Score: {0}", ScorePoints);
        }

        public static void DisplayFinalSocre(int x, int y)
        {
            if (ScorePoints <= BestScore)
            {
                Message("Your Score: {0}", ScorePoints);
                Message("Best Score: {0}", ScorePoints);
            }
            else
            {
                BestScore = ScorePoints;

                Message("Congrats!");
                Message("New Best score: {0}", ScorePoints);

                SaveScore();
            }
        }

        private static int LoadScore()
        {
            try
            {
                using (var file = new StreamReader(HIGHSCORE_FILE))
                {
                    var fileText = file.ReadLine();

                    int highscore = 0;
                    if (int.TryParse(fileText, out highscore))
                    {
                        return highscore;
                    }
                    else
                    {
                        MultilineError(
                            "Could not read Highscore file:",
                            "Failed file text to integer conversion");

                        return 0;
                    }
                }
            }
            catch (Exception e)
            {
                MultilineError(
                    "Could not read Highscore file:",
                    e.Message);

                return 0;
            }

        }

        private static void SaveScore()
        {
            try
            {
                using (var file = new StreamWriter(HIGHSCORE_FILE))
                {
                    file.WriteLine(ScorePoints);
                }
            }
            catch (Exception e)
            {
                MultilineError(
                    "Could not read Highscore file:",
                    e.Message);
            }
        }
    }
}
