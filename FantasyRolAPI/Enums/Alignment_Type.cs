using System.ComponentModel;

namespace FantasyRolAPI.Enums
{
    public enum Alignment_Type
    {
        [Description("Lawful Good")]
        LawfulGood = 1,
        [Description("Neutral Good")]
        NeutralGood = 2,
        [Description("Chaotic Good")]
        ChaoticGood = 3,
        [Description("Lawful Neutral")]
        LawfulNeutral = 4,
        [Description("True Neutral")]
        TrueNeutral = 5,
        [Description("Chaotic Neutral")]
        ChaoticNeutral = 6,
        [Description("Lawful Evil")]
        LawfulEvil = 7,
        [Description("Neutral Evil")]
        NeutralEvil = 8,
        [Description("Chaotic Evil")]
        ChaoticEvil = 9
    }

}
