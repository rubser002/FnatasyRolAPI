using System.ComponentModel;

namespace FantasyRolAPI.Enums
{
    public enum Characteristics_Type
    {
        [Description("Strength")]
        Str = 1,

        [Description("Dexterity")]
        Dex = 2,

        [Description("Constitution")]
        Con = 21,

        [Description("Intelligence")]
        Int = 3,

        [Description("Wisdom")]
        Wis = 4,

        [Description("Charisma")]
        Cha = 5,

        [Description("Acrobatics")]
        Acrobatics = 6,

        [Description("Athletics")]
        Athletics = 7,

        [Description("Perception")]
        Perception = 8,

        [Description("Persuasion")]
        Persuasion = 9,

        [Description("Arcana")]
        Arcana = 10,

        [Description("History")]
        History = 11,

        [Description("Investigation")]
        Investigation = 12,

        [Description("Nature")]
        Nature = 13,

        [Description("Religion")]
        Religion = 14,

        [Description("Insight")]
        Insight = 15,

        [Description("Medicine")]
        Medicine = 16,

        [Description("Survival")]
        Survival = 17,

        [Description("Deception")]
        Deception = 18,

        [Description("Intimidation")]
        Intimidation = 19,

        [Description("Performance")]
        Performance = 20,


    }
}
