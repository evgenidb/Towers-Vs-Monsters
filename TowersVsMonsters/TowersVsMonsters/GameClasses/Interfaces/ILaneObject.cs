using System;

namespace TowersVsMonsters.GameClasses.Interfaces
{
    public interface ILaneObject
    {
        /// <summary>
        /// The position on the lane: [1, LaneLength];
        /// Zero is reserved for the Tower.
        /// The real X, Y screen coordinates
        /// of the Game Obejct
        /// can be inferred from the Lane's coordinates
        /// </summary>
        int LanePosition { get; set; }

        // Graphics for the Game Object
        char Symbol { get; }
        ConsoleColor Color { get; }
    }
}
