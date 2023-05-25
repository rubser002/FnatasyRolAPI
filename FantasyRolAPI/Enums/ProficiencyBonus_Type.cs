using System.ComponentModel;

namespace FantasyRolAPI.Enums
{
    public enum ProficiencyBonus_Type
    {
        [Description("No proficiency")]
        NoProficiency = 1,

        [Description("Proficiency")]
        Proficiency = 2,
        
        [Description("Double Proficiency")]
        DoubleProficiency = 2,

        [Description("Half Proficiency")]
        HalfProficciency = 3,
    }
}
