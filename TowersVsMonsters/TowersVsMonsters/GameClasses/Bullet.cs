using TowersVsMonsters.GameClasses.Interfaces;

namespace TowersVsMonsters.GameClasses
{
    public class Bullet: ILaneObject
    {
        public int LanePosition { get; set; } = -1;
    }
}