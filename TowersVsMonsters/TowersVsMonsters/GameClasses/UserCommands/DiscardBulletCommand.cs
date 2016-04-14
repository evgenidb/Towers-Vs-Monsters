using TowersVsMonsters.GameClasses.UserCommands.Enums;
using TowersVsMonsters.GameClasses.UserCommands.Interfaces;

namespace TowersVsMonsters.GameClasses.UserCommands
{
    public class DiscardBulletCommand: IUserCommand
    {
        public UserCommandType CommandType
        {
            get
            {
                return UserCommandType.DiscardBullet;
            }
        }

        public Bullet ReplacementBullet { get; private set; }

        public DiscardBulletCommand(Bullet replacementBullet)
        {
            ReplacementBullet = replacementBullet;
        }
    }
}
