using System.ComponentModel;

namespace FantasyRolAPI.Enums
{
    public enum Dice_Type
    {
        [Description("d4")]
        d4=1,
            
        [Description("d6")]
        d6=2,
    
        [Description("d8")]
        d8=3,
    
        [Description("d10")]
        d10=4,
    
        [Description("d12")]
        d12=5,
    
        [Description("d20")]
        d20=6,

        [Description("d100")]
        d100=7,
    }
}
