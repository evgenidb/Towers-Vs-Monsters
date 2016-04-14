using System;
using TowersVsMonsters.GameClasses.Interfaces;
using static System.ConsoleColor;

namespace TowersVsMonsters.GameClasses
{
    public class Tower: ILaneObject
    {
        #region Fields
        private const char SYMBOL = 'T';
        private const ConsoleColor color = Magenta;
        #endregion

        public int LanePosition
        {
            get
            {
                return 0;
            }
            set
            {
                var exceptionMessage = string.Join(" ",
                    "Tower's position is always 0",
                    "and it cannot be set",
                    "to another number.");

                throw new NotSupportedException(
                    exceptionMessage);
            }
        }

        public char Symbol
        {
            get
            {
                return SYMBOL;
            }
        }

        public ConsoleColor Color
        {
            get
            {
                return color;
            }
        }
    }
}