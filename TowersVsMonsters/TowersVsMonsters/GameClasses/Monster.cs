using System;
using TowersVsMonsters.GameClasses.Interfaces;

namespace TowersVsMonsters.GameClasses
{
    public class Monster: ILaneObject
    {
        #region Fields
        private const char SYMBOL = 'M';
        private readonly ConsoleColor color;
        #endregion
        public int LanePosition { get; set; } = -1;

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

        public Monster(ConsoleColor color)
        {
            this.color = color;
        }
    }
}