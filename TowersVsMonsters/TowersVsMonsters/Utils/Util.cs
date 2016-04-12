using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowersVsMonsters.GameClasses.Interfaces;

namespace TowersVsMonsters.Utils
{
    public static class Util
    {
        public static bool HasCollision(ILaneObject obj1, ILaneObject obj2)
        {
            return obj1.LanePosition == obj1.LanePosition;
        }
    }
}
