using TowersVsMonsters.GameClasses.Interfaces;

namespace TowersVsMonsters.GameClasses
{
    public class Monster: ILaneObject
    {
        public int LanePosition { get; set; } = -1;
    }
}