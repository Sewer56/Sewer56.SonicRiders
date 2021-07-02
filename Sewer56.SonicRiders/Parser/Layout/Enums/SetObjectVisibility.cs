using System;
using Sewer56.SonicRiders.Structures.Enums;

namespace Sewer56.SonicRiders.Parser.Layout.Enums
{
    [Flags]
    public enum SetObjectVisibility : int
    {
        GameCube = 1 << 0,
        PlayStation = 1 << 1,

        /// <summary>
        /// And PC
        /// </summary>
        Xbox = 1 << 2,

        Race     = 1 << 3,
        Tag      = 1 << 4,
        Survival = 1 << 5,

        Mission1 = 1 << 6,
        Mission2 = 1 << 7,
        Mission3 = 1 << 8,
        Mission4 = 1 << 9,
        Mission5 = 1 << 10,
        Mission6 = 1 << 11,
        Mission7 = 1 << 12,
    }

    public static class SetObjectVisibilityExtensions
    {
        /// <summary>
        /// Determines if the object will be loaded.
        /// </summary>
        /// <param name="visibility">The visibility.</param>
        /// <param name="mode">The current mode the game is set to.</param>
        public static bool IsVisible(this SetObjectVisibility visibility, ActiveRaceMode mode)
        {
            if ((visibility & SetObjectVisibility.Xbox) == 0)
                return false;

            switch (mode)
            {
                case ActiveRaceMode.Mission:
                    var missionMask = SetObjectVisibility.Mission1 | SetObjectVisibility.Mission2 | SetObjectVisibility.Mission3 | 
                                      SetObjectVisibility.Mission4 | SetObjectVisibility.Mission5 | SetObjectVisibility.Mission6 | 
                                      SetObjectVisibility.Mission7;

                    return (visibility & missionMask) != 0;

                case ActiveRaceMode.TagMode:
                    return (visibility & SetObjectVisibility.Tag) != 0;

                case ActiveRaceMode.RaceStage:
                case ActiveRaceMode.BattleStage:
                    return (visibility & SetObjectVisibility.Survival) != 0;

                default:
                    return (visibility & SetObjectVisibility.Race) != 0;
            }
        }
    }
}