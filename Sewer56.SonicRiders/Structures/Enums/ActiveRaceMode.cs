namespace Sewer56.SonicRiders.Structures.Enums
{
    /// <summary>
    /// A variant of <see cref="RaceMode"/> that is actively used during gameplay
    /// </summary>
    public enum ActiveRaceMode : int
    {
        Story = 100,
        Mission = 200,
        TagMode = 300,
        RaceStage = 400,
        BattleStage = 500,
        TimeTrial = 600,
        NormalRace = 700,
        GrandPrix = 800,
        Cutscene = 1000
    }
}