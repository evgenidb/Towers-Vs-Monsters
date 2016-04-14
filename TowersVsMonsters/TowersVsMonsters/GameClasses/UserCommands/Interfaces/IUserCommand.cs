using TowersVsMonsters.GameClasses.UserCommands.Enums;

namespace TowersVsMonsters.GameClasses.UserCommands.Interfaces
{
    public interface IUserCommand
    {
        UserCommandType CommandType { get; }
    }
}
