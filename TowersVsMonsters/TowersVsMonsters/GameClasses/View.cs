using System;
using TowersVsMonsters.GameClasses.Interfaces;

namespace TowersVsMonsters.GameClasses
{
    public class View
    {
        private readonly Level level;

        public View(Level level)
        {
            this.level = level;
        }

        public void Draw()
        {
            PrepareScreen();
            DrawMenu();
            DrawLevel();
        }

        private void PrepareScreen()
        {
            Console.ResetColor();
            Console.Clear();
        }

        private void DrawMenu()
        {
            var menuPositionY = 1;

            // Draw Socre
            var scoreMenuPart = string.Format(
                "Score: {0}",
                Score.ScorePoints);

            var scoreScreenBorderPadding = 3;

            Console.SetCursorPosition(
                left: scoreScreenBorderPadding,
                top: menuPositionY);

            Console.Write(scoreMenuPart);
            Console.ResetColor();

            // Draw BulletBar
            var barStartPositionX = 20;
            Console.SetCursorPosition(
                left: barStartPositionX,
                top: menuPositionY);
            Console.BackgroundColor = ConsoleColor.DarkGray;
            foreach (var bullet in level.Menu.BulletsPreview)
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = bullet.Color;
                Console.Write(bullet.Symbol);
                Console.Write(" ");
            }
            Console.ResetColor();

            // Draw Difficulty
            var difficultyMenuPart = string.Format(
                "Difficulty: {0}",
                level.DifficultyLevel);

            var difficultyScreenBorderPadding = 3;
            var difficultyMenuPartPositionX =
                Game.WINDOW_WIDTH -
                difficultyMenuPart.Length -
                difficultyScreenBorderPadding;

            Console.SetCursorPosition(
                left: difficultyMenuPartPositionX,
                top: menuPositionY);

            Console.Write(difficultyMenuPart);
            Console.ResetColor();

            // Draw Menu separator
            Console.SetCursorPosition(0, menuPositionY + 1);
            DrawHorizontalLine('=', Game.WINDOW_WIDTH);
            Console.ResetColor();
        }

        private void DrawLevel()
        {
            int laneX = 20;
            int laneY = 10;
            const int laneOffsetX = 0;
            const int laneOffsetY = 5;
            const ConsoleColor laneColor =
                ConsoleColor.DarkGray;

            foreach (var lane in level.Lanes)
            {
                DrawLane(laneX, laneY, laneColor);

                DrawGameObject(lane.Tower, laneX, laneY);

                foreach (var monster in lane.Monsters)
                {
                    DrawGameObject(monster, laneX, laneY);
                }

                foreach (var bullet in lane.Bullets)
                {
                    DrawGameObject(bullet, laneX, laneY);
                }

                laneX += laneOffsetX;
                laneY += laneOffsetY;
            }

            Console.ResetColor();
        }

        private void DrawLane(int laneX, int laneY, ConsoleColor laneColor)
        {
            Console.ResetColor();
            Console.SetCursorPosition(
                left: laneX,
                top: laneY);

            Console.BackgroundColor = laneColor;
            DrawHorizontalLine(
                symbol: ' ',
                length: Lane.Length);
            Console.ResetColor();
        }

        private void DrawGameObject(ILaneObject gameObject, int laneX, int laneY)
        {
            Console.CursorLeft = laneX + gameObject.LanePosition;
            Console.ForegroundColor = gameObject.Color;
            Console.Write(gameObject.Symbol);
            Console.ResetColor();
        }

        private void DrawHorizontalLine(char symbol, int length)
        {
            var line = new string(symbol, length);
            Console.Write(line);
        }
    }
}