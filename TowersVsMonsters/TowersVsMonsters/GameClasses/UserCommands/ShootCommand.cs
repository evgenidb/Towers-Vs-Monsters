using TowersVsMonsters.GameClasses.UserCommands.Enums;
using TowersVsMonsters.GameClasses.UserCommands.Interfaces;

namespace TowersVsMonsters.GameClasses.UserCommands
{
    public class ShootCommand : IUserCommand
    {
        public int LaneIndex { get; set; }

        public UserCommandType CommandType
        {
            get
            {
                return UserCommandType.Shoot;
            }
        }

        public Bullet Bullet { get; private set; }

        public ShootCommand(int laneIndex, Bullet bullet)
        {
            LaneIndex = laneIndex;
            Bullet = bullet;
        }
    }
}
