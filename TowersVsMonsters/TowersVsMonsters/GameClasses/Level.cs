using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowersVsMonsters.GameClasses
{
    public class Level
    {
        #region Private Properties
        private List<Lane> LaneCollection { get; set; }
        #endregion

        public MenuBar Menu { get; set; }

        public IReadOnlyList<Lane> Lanes
        {
            get
            {
                return LaneCollection;
            }
        }

        public int LanesLength
        {
            get { return Lane.Length; }
        }

        public Level()
        {
            Menu = new MenuBar();
            LaneCollection = new List<Lane>();
            AddLane();
            AddLane();
        }

        public void AddLane()
        {
            var lane = new Lane();
            LaneCollection.Add(lane);
        }

        public void ChangeLanesLength(int newLength)
        {
            foreach (var lane in LaneCollection)
            {
                lane.ChangeLanesLength(newLength);
            }
        }
    }
}
