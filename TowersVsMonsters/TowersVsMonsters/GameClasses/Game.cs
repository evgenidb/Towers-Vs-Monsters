using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TowersVsMonsters.Utils.Util;

namespace TowersVsMonsters.GameClasses
{
    public class Game
    {
        public int FrameDuration { get; } = 50; // In milliseconds
        public int CurrentFrame { get; private set; } = 1;

        public Level Level { get; private set; }
        public View View { get; private set; }

        public Game()
        {
            Level = new Level();
            View = new View(Level);
        }

        public void Update()
        {
            throw new NotImplementedException();
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
