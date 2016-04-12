using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowersVsMonsters.GameClasses
{
    public class Level
    {
        public List<Lane> Lanes { get; private set; }
        public int LanesLength
        {
            get { return Lane.Length; }
        }

        public Level()
        {
            Lanes = new List<Lane>();
            AddLane();
            AddLane();
        }

        public void AddLane()
        {
            var lane = new Lane();
            Lanes.Add(lane);
        }

        public void ChangeLanesLength(int newLength)
        {
            foreach (var lane in Lanes)
            {
                lane.ChangeLanesLength(newLength);
            }
        }
    }
}
