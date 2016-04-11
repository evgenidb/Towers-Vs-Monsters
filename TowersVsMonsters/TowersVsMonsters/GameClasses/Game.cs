using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowersVsMonsters.GameClasses
{
    public class Game
    {
        public int FrameDuration { get; } = 50; // In milliseconds
        public int CurrentFrame { get; private set; } = 1;


        public void NextFrame()
        {
            CurrentFrame += 1;
        }
    }
}
