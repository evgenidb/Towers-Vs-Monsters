using System;
using System.Collections.Generic;
using System.Linq;
using TowersVsMonsters.GameClasses.Interfaces;

namespace TowersVsMonsters.Utils
{
    public static class Util
    {
        public static bool HasCollision(ILaneObject obj1, ILaneObject obj2)
        {
            return obj1.LanePosition == obj2.LanePosition;
        }

        public static T RandomElement<T>(IEnumerable<T> collection, Random randomGenerator = null)
        {
            var list = collection as IList<T>;
            list = list ?? collection.ToList();

            if (list.Count < 1)
            {
                return default(T);
            }

            randomGenerator = randomGenerator ?? new Random();

            var randomIndex =
                randomGenerator.Next(maxValue: list.Count);

            return list[randomIndex];
        }
    }
}
