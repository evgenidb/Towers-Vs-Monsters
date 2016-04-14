using System;
using System.Collections.Generic;
using System.Linq;
using TowersVsMonsters.Utils;
using static System.ConsoleColor;

namespace TowersVsMonsters.GameClasses
{
    public static class GameObjectFactory
    {
        private static IReadOnlyList<ConsoleColor> monsterColors =
            new List<ConsoleColor>()
            {
                Red,
                Cyan,
                Yellow,
                Green,
            };
        private static int monsterVariantsCount = 1;

        public static int MonsterVariantsCount
        {
            get
            {
                return monsterVariantsCount;
            }
            set
            {
                if (0 < monsterVariantsCount && monsterVariantsCount < monsterColors.Count)
                {
                    monsterVariantsCount = value;
                }
            }
        }

        public static Monster RandomMonster()
        {
            var color = RandomColor();
            var monster = new Monster(color);
            monster.LanePosition = -1;

            return monster;
        }

        public static Bullet RandomBullet()
        {
            var color = RandomColor();
            var bullet = new Bullet(color);
            bullet.LanePosition = -1;

            return bullet;
        }

        private static ConsoleColor RandomColor()
        {
            var colors =
                monsterColors.Take(MonsterVariantsCount);

            var color = Util.RandomElement<ConsoleColor>(
                collection: colors,
                randomGenerator: Game.RandomGenerator);
            return color;
        }
    }
}