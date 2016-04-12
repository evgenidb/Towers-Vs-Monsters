using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowersVsMonsters.GameClasses.Interfaces
{
    public interface ILaneObject
    {
        /// <summary>
        /// The position on the lane: [1, LaneLength];
        /// Zero is reserved for the Tower.
        /// </summary>
        int LanePosition { get; set; }
    }
}
