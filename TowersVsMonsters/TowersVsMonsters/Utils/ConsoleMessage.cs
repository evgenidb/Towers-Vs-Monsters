using System;
using System.Collections.Generic;
using static System.ConsoleColor;

namespace TowersVsMonsters.Utils
{
    /// <summary>
    /// Class for displaying messages and error
    /// </summary>
    public class ConsoleMessage
    {
        public const int DEFAULT_MESSAGE_POSITION_X = 20;
        public const int DEFAULT_MESSAGE_POSITION_Y = 10;

        public const ConsoleColor MESSAGE_COLOR = White;
        public const ConsoleColor ERROR_COLOR = Red;


        public static void Message(string message)
        {
            Message(
                message: message,
                x: DEFAULT_MESSAGE_POSITION_X,
                y: DEFAULT_MESSAGE_POSITION_Y);
        }

        public static void Message(string format, params object[] args)
        {
            Message(
                message: Format(format, args),
                x: DEFAULT_MESSAGE_POSITION_X,
                y: DEFAULT_MESSAGE_POSITION_Y);
        }

        public static void Message(int x, int y, string message)
        {
            DisplayText(
                text: message,
                color: MESSAGE_COLOR,
                x: x,
                y: y);
        }

        public static void Message(int x, int y, string format, params object[] args)
        {
            Message(
                message: Format(format, args),
                x: x,
                y: y);
        }

        public static void MultilineMessage(IEnumerable<string> lines)
        {
            MultilineMessage(
                lines: lines,
                x: DEFAULT_MESSAGE_POSITION_X,
                y: DEFAULT_MESSAGE_POSITION_Y);
        }

        public static void MultilineMessage(int x, int y, IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                Message(
                    message: line,
                    x: x,
                    y: y);
                y++;
            }
        }

        public static void MultilineMessage(params string[] lines)
        {
            MultilineMessage(
                lines: lines,
                x: DEFAULT_MESSAGE_POSITION_X,
                y: DEFAULT_MESSAGE_POSITION_Y);
        }

        public static void MultilineMessage(int x, int y, params string[] lines)
        {
            MultilineMessage(
                lines: lines,
                x: x,
                y: y);
        }

        public static void Error(string message)
        {
            Error(
                message: message,
                x: DEFAULT_MESSAGE_POSITION_X,
                y: DEFAULT_MESSAGE_POSITION_Y);
        }

        public static void Error(string format, params object[] args)
        {
            Error(
                message: Format(format, args),
                x: DEFAULT_MESSAGE_POSITION_X,
                y: DEFAULT_MESSAGE_POSITION_Y);
        }

        public static void Error(int x, int y, string message)
        {
            DisplayText(
                text: message,
                color: ERROR_COLOR,
                x: x,
                y: y);
        }

        public static void Error(int x, int y, string format, params object[] args)
        {
            Error(
                message: Format(format, args),
                x: x,
                y: y);
        }

        public static void MultilineError(IEnumerable<string> lines)
        {
            MultilineError(
                lines: lines,
                x: DEFAULT_MESSAGE_POSITION_X,
                y: DEFAULT_MESSAGE_POSITION_Y);
        }

        public static void MultilineError(int x, int y, IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                Error(
                    message: line,
                    x: x,
                    y: y);
                y++;
            }
        }

        public static void MultilineError(params string[] lines)
        {
            MultilineError(
                lines: lines,
                x: DEFAULT_MESSAGE_POSITION_X,
                y: DEFAULT_MESSAGE_POSITION_Y);
        }

        public static void MultilineError(int x, int y, params string[] lines)
        {
            MultilineError(
                lines: lines,
                x: x,
                y: y);
        }

        private static void DisplayText(string text, ConsoleColor color, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        private static string Format(string format, params object[] args)
        {
            return string.Format(format, args);
        }
    }
}
