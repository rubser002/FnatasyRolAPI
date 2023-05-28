using FantasyRolAPI.Data;
using FantasyRolAPI.DTOs;
using FantasyRolAPI.Enums;
using FantasyRolAPI.Models;
using FantasyRolAPI.Services.UserServices;
using Microsoft.EntityFrameworkCore;

namespace FantasyRolAPI.Services.CharacteristicsServices
{
    public class CharacteristicsService: ICharacteristicsService
    {
        private readonly AppDbContext _db;
        private readonly IUserService userService;
        private readonly IConfiguration _configuration;

        public CharacteristicsService(IConfiguration configuration, AppDbContext dbContext, IUserService userService)
        {
            _db = dbContext;
            this.userService = userService;
            _configuration = configuration;
        }


        public async Task<List<Ability>> getAbilityByClassLevel(Guid classId, int classLevel)
        {
            var abilities = new List<Ability>();

            abilities = await _db.ClassAbility
                                    .Where(w=>w.ClassId ==  classId)
                                    .Select(w=>w.Ability)
                                    .Where(a=>a.Level == classLevel)
                                    .ToListAsync();
            var e = await _db.ClassAbility.ToListAsync();
            var f = await _db.ClassAbility.Where(w => w.ClassId == classId).Select(w => w.Ability).ToListAsync();

            return abilities;
        }

        public async Task<List<LabelAndValue>> getClassAutocomplete()
        {
            var result = await _db.Class
                    .Select(w => new LabelAndValue { Value = w.Id, Label = w.Name })
                    .ToListAsync();

            return result;

        }

        public async Task<List<LabelAndValue>> getRaceAutocomplete()
        {
            var result = await _db.Race
                    .Select(w => new LabelAndValue { Value = w.Id, Label = w.Name })
                    .ToListAsync();

            return result;
        }


        public async Task generateData()
        {
            // Create the Fighter class
            var fighterClass = new Class
            {
                Name = "Fighter",
                Description = "Fighters share an unparalleled mastery with weapons and armor, and a thorough knowledge of the skills of combat. They are well acquainted with death, both meting it out and staring it defiantly in the face.",
                HitDice = Dice_Type.d10
            };

            
            var fightingStyle = new Ability
            {
                Name = "Fighting Style",
                Level = 1,
                Description = "You adopt a particular style of fighting as your specialty. Choose one of the following options. You can't take a Fighting Style option more than once, even if you later get to choose again.\r\n\r\nArchery. You gain a +2 bonus to attack rolls you make with ranged weapons.\r\nBlind Fighting. You have blindsight with a range of 10 feet. Within that range, you can effectively see anything that isn't behind total cover, even if you're blinded or in darkness. Moreover, you can see an invisible creature within that range, unless the creature successfully hides from you.\r\nDefense. While you are wearing armor, you gain a +1 bonus to AC.\r\nDueling. When you are wielding a melee weapon in one hand and no other weapons, you gain a +2 bonus to damage rolls with that weapon.\r\nGreat Weapon Fighting. When you roll a 1 or 2 on a damage die for an attack you make with a melee weapon that you are wielding with two hands, you can reroll the die and must use the new roll, even if the new roll is a 1 or a 2. The weapon must have the two-handed or versatile property for you to gain this benefit.\r\nInterception. When a creature you can see hits a target, other than you, within 5 feet of you with an attack, you can use your reaction to reduce the damage the target takes by 1d10 + your proficiency bonus (to a minimum of 0 damage). You must be wielding a shield or a simple or martial weapon to use this reaction.\r\nProtection. When a creature you can see attacks a target other than you that is within 5 feet of you, you can use your reaction to impose disadvantage on the attack roll. You must be wielding a shield.\r\nSuperior Technique. You learn one maneuver of your choice from among those available to the Battle Master archetype. If a maneuver you use requires your target to make a saving throw to resist the maneuver's effects, the saving throw DC equals 8 + your proficiency bonus + your Strength or Dexterity modifier (your choice.)\r\nYou gain one superiority die, which is a d6 (this die is added to any superiority dice you have from another source). This die is used to fuel your maneuvers. A superiority die is expended when you use it. You regain your expended superiority dice when you finish a short or long rest.\r\nThrown Weapon Fighting. You can draw a weapon that has the thrown property as part of the attack you make with the weapon.\r\nIn addition, when you hit with a ranged attack using a thrown weapon, you gain a +2 bonus to the damage roll.\r\nTwo-Weapon Fighting. When you engage in two-weapon fighting, you can add your ability modifier to the damage of the second attack.\r\nUnarmed Fighting. Your unarmed strikes can deal bludgeoning damage equal to 1d6 + your Strength modifier on a hit. If you aren't wielding any weapons or a shield when you make the attack roll, the d6 becomes a d8.\r\nAt the start of each of your turns, you can deal 1d4 bludgeoning damage to one creature grappled by you.\r\nClose Quarters Shooter (UA). When making a ranged attack while you are within 5 feet of a hostile creature, you do not have disadvantage on the attack roll. Your ranged attacks ignore half cover and three-quarters cover against targets within 30 feet of you. You have a +1 bonus to attack rolls on ranged attacks.\r\nMariner (UA). As long as you are not wearing heavy armor or using a shield, you have a swimming speed and a climbing speed equal to your normal speed, and you gain a +1 bonus to armor class.\r\nTunnel Fighter (UA). As a bonus action, you can enter a defensive stance that lasts until the start of your next turn. While in your defensive stance, you can make opportunity attacks without using your reaction, and you can use your reaction to make a melee attack against a creature that moves more than 5 feet while within your reach."
            };

            var secondWind = new Ability
            {
                Name = "Second Wind",
                Level = 1,
                Description = "You have a limited well of stamina that you can draw on to protect yourself from harm. On your turn, you can use a bonus action to regain hit points equal to 1d10 + your fighter level.\r\n\r\nOnce you use this feature, you must finish a short or long rest before you can use it again."
            };
            var actionSurge = new Ability
            {
                Name = "Action Surge",
                Level = 2,
                Description = "Starting at 2nd level, you can push yourself beyond your normal limits for a moment. On your turn, you can take one additional action.\r\n\r\nOnce you use this feature, you must finish a short or long rest before you can use it again. Starting at 17th level, you can use it twice before a rest, but only once on the same turn."
            };
            
            var martialArchetype = new Ability
            {
                Name = "Action Surge",
                Level = 3,
                Description = "Martial Archetype\r\nAt 3rd level, you choose an archetype that you strive to emulate in your combat styles and techniques. The archetype you choose grants you features at 3rd level and again at 7th, 10th, 15th, and 18th level."
            };
            var abilityScoreImporv = new Ability
            {
                Name = "Action Surge",
                Level = 4,
                Description = "Ability Score Improvement\r\nWhen you reach 4th level, and again at 6th, 8th, 12th, 14th, 16th, and 19th level, you can increase one ability score of your choice by 2, or you can increase two ability scores of your choice by 1. As normal, you can't increase an ability score above 20 using this feature."
            };
            


            var a = new ClassAbility
            {
                Class = fighterClass,
                Ability = fightingStyle
            };

            var c = new ClassAbility
            {
                Class = fighterClass,
                Ability = secondWind
            };
            var b = new ClassAbility
            {
                Class = fighterClass,
                Ability = actionSurge
            };
            var d = new ClassAbility
            {
                Class = fighterClass,
                Ability = martialArchetype
            };
            var e = new ClassAbility
            {
                Class = fighterClass,
                Ability = abilityScoreImporv
            };

            _db.Class.Add(fighterClass);
            _db.Ability.AddRange(fightingStyle, secondWind, actionSurge, martialArchetype, abilityScoreImporv);
            _db.ClassAbility.AddRange(a,b,c,d,e);
            await _db.SaveChangesAsync();
        }

    }
}
