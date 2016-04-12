using System;
using TowersVsMonsters.GameClasses.Interfaces;

namespace TowersVsMonsters.GameClasses
{
    public class Tower: ILaneObject
    {
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
    }
}