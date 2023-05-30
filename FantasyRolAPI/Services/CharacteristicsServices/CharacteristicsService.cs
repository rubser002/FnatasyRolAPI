using FantasyRolAPI.Data;
using FantasyRolAPI.DTOs;
using FantasyRolAPI.Enums;
using FantasyRolAPI.Models;
using FantasyRolAPI.Services.UserServices;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;
using System.Reflection;

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
            var human = new Race
            {
                Name = "human",
                AgeInterval = "80 years",
                Description = "",
                Weight = "100",
                Height = "7 feet",
                DescAlignment= "",
                Bonuses = new List<Bonus>()
                {
                    new Bonus()
                    {
                        bonusValue = 1,
                        characteristic= Characteristics_Type.Wis,
                    },
                    new Bonus()
                    {
                        bonusValue = 1,
                        characteristic= Characteristics_Type.Str,
                    },
                    new Bonus()
                    {
                        bonusValue = 1,
                        characteristic= Characteristics_Type.Dex,
                    },
                    new Bonus()
                    {
                        bonusValue = 1,
                        characteristic= Characteristics_Type.Int,
                    },new Bonus()
                    {
                        bonusValue = 1,
                        characteristic= Characteristics_Type.Cha,
                    }
                }
            };
            var elf = new Race
            {
                Name = "elf",
                AgeInterval = "750 years",
                Description = "Elves are a magical and graceful race known for their keen senses and longevity.",
                Weight = "120",
                Height = "6 feet",
                DescAlignment = "Elves tend to be chaotic in nature, valuing personal freedom and expression.",
                Bonuses = new List<Bonus>()
                 {
                new Bonus()
                    {
                    bonusValue = 2,
                    characteristic = Characteristics_Type.Dex,
                    },
                new Bonus()
                    {
                    bonusValue = 1,
                    characteristic = Characteristics_Type.Int,
                    },
                 }
            };
            var dwarf = new Race
            {
                Name = "dwarf",
                AgeInterval = "350 years",
                Description = "Dwarves are known for their stout and sturdy physique, as well as their skill in craftsmanship and mining.",
                Weight = "150",
                Height = "4 feet",
                DescAlignment = "Dwarves are typically lawful and value tradition, honor, and hard work.",
                Bonuses = new List<Bonus>()
                {
                    new Bonus()
                    {
                        bonusValue = 2,
                        characteristic = Characteristics_Type.Con,
                    },
                    new Bonus()
                    {
                        bonusValue = 1,
                        characteristic = Characteristics_Type.Str,
                    },
                }
            };
            var halfling = new Race
            {
                Name = "halfling",
                AgeInterval = "150 years",
                Description = "Halflings are small, nimble, and often have a jovial disposition. They are known for their luck and resourcefulness.",
                Weight = "40",
                Height = "3 feet",
                DescAlignment = "Halflings tend to be good-natured, easy-going, and value simple pleasures.",
                Bonuses = new List<Bonus>()
                {
                    new Bonus()
                    {
                        bonusValue = 2,
                        characteristic = Characteristics_Type.Dex,
                    },
                    new Bonus()
                    {
                        bonusValue = 1,
                        characteristic = Characteristics_Type.Cha,
                    },
                }
            };
            var dragonborn = new Race
            {
                Name = "dragonborn",
                AgeInterval = "80 years",
                Description = "Dragonborn are a race with draconic ancestry, known for their scales and breath weapons.",
                Weight = "200",
                Height = "6.5 feet",
                DescAlignment = "Dragonborn can have various alignments, but their dragon heritage often influences their personality and behavior.",
                Bonuses = new List<Bonus>()
                {
                    new Bonus()
                    {
                        bonusValue = 2,
                        characteristic = Characteristics_Type.Str,
                    },
                    new Bonus()
                    {
                        bonusValue = 1,
                        characteristic = Characteristics_Type.Cha,
                    },
                }
            };


            List<Spell> spellList = new List<Spell>
{
    new Spell
    {
        Name = "Magic Missile",
        Description = "Spell description",
        School = School_Type.evocation,
        Components = "",
        SComponents = "V S",
        SpellLevel = 1
    },
    new Spell
    {
        Name = "Fireball",
        Description = "A fiery explosion erupts at a target location, damaging all creatures in the area.",
        School = School_Type.evocation,
        Components = "V, S, M (a tiny ball of bat guano and sulfur)",
        SComponents = null,
        SpellLevel = 3
    },
    new Spell
    {
        Name = "Cure Wounds",
        Description = "A healing spell that restores a target's hit points.",
        School = School_Type.conjuration,
        Components = "V, S",
        SComponents = null,
        SpellLevel = 1
    },
    new Spell
    {
        Name = "Lightning Bolt",
        Description = "A bolt of lightning streaks towards a target, damaging all creatures in its path.",
        School = School_Type.evocation,
        Components = "V, S, M (a bit of fur and a rod of amber, crystal, or glass)",
        SComponents = null,
        SpellLevel = 3
    },
    new Spell
    {
        Name = "Shield",
        Description = "Creates a magical shield that provides a bonus to AC (Armor Class) until the start of your next turn.",
        School = School_Type.abjuration,
        Components = "V, S",
        SComponents = null,
        SpellLevel = 1
    },
    new Spell
    {
        Name = "Counterspell",
        Description = "Interrupts another spell being cast, preventing its effects.",
        School = School_Type.abjuration,
        Components = "S",
        SComponents = "None",
        SpellLevel = 3
    },
    new Spell
    {
        Name = "Fly",
        Description = "Grants the ability to fly to a target creature.",
        School = School_Type.transmutation,
        Components = "V, S, M (a wing feather from any bird)",
        SComponents = null,
        SpellLevel = 3
    },
    new Spell
    {
        Name = "Dispel Magic",
        Description = "Cancels out magical effects or dispels ongoing spells.",
        School = School_Type.abjuration,
        Components = "V, S",
        SComponents = null,
        SpellLevel = 3
    },
    new Spell
    {
        Name = "Teleportation Circle",
        Description = "Creates a magical circle that allows for instant teleportation between two linked locations.",
        School = School_Type.conjuration,
        Components = "V, M (rare chalks and inks infused with precious gems worth 50 gp)",
        SComponents = null,
        SpellLevel = 5
    }
};

            var clases = new List<Class>()
            {
                new Class
                {
                    Name = "Fighter",
                    Description= "Fighters share an unparalleled mastery with weapons and armor, and a thorough knowledge of the skills of combat. They are well acquainted with death, both meting it out and staring it defiantly in the face.",
                    HitDice = Dice_Type.d10,
                    ClassAbilities = new List<ClassAbility>()
                    {
                        new ClassAbility()
                        {
                            Ability = new Ability()
                            {
                                Name= "Second Wind",
                                Description="You have a limited well of stamina that you can draw on to protect yourself from harm. On your turn, you can use a bonus action to regain hit points equal to 1d10 + your fighter level.\r\n\r\nOnce you use this feature, you must finish a short or long rest before you can use it again.",
                                Level = 1,
                            }

                        },
                        new ClassAbility()
                        {
                            Ability = new Ability()
                            {
                                Name= "Fighting Style",
                                Description="You adopt a particular style of fighting as your specialty. Choose one of the following options. You can't take a Fighting Style option more than once, even if you later get to choose again.",
                                Level = 1,
                            }

                        },
                        new ClassAbility()
                        {
                            Ability = new Ability()
                            {
                                Name= "Action Surge",
                                Description="Starting at 2nd level, you can push yourself beyond your normal limits for a moment. On your turn, you can take one additional action.\r\n\r\nOnce you use this feature, you must finish a short or long rest before you can use it again. Starting at 17th level, you can use it twice before a rest, but only once on the same turn.",
                                Level = 2,
                            }

                        },

                    }

                },
                new Class
                {
                    Name = "Wizard",
                    Description= "Wizards are supreme magic-users, defined and united as a class by the spells they cast. Drawing on the subtle weave of magic that permeates the cosmos, wizards cast spells of explosive fire, arcing lightning, subtle deception, brute-force mind control, and much more.",
                    HitDice = Dice_Type.d6,
                    ClassAbilities = new List<ClassAbility>()
                    {
                        new ClassAbility()
                        {
                            Ability = new Ability()
                            {
                                Name= "Spellcasting",
                                Description="As a student of arcane magic, you have a spellbook containing spells that show the first glimmerings of your true power.\r\n\r\nCantrips\r\nAt 1st level, you know three cantrips of your choice from the wizard spell list. You learn additional wizard cantrips of your choice at higher levels, as shown in the Cantrips Known column of the Wizard table.\r\n\r\nSpellbook\r\nAt 1st level, you have a spellbook containing six 1st-level wizard spells of your choice. Your spellbook is the repository of the wizard spells you know, except your cantrips, which are fixed in your mind.\r\n\r\nThe spells that you add to your spellbook as you gain levels reflect the arcane research you conduct on your own, as well as intellectual breakthroughs you have had about the nature of the multiverse. You might find other spells during your adventures. You could discover a spell recorded on a scroll in an evil wizard's chest, for example, or in a dusty tome in an ancient library.\r\n\r\nCopying a Spell into the Book. When you find a wizard spell of 1st level or higher, you can add it to your spellbook if it is of a spell level you can prepare and if you can spare the time to decipher and copy it.\r\n\r\nCopying a spell into your spellbook involves reproducing the basic form of the spell, then deciphering the unique system of notation used by the wizard who wrote it. You must practice the spell until you understand the sounds or gestures required, then transcribe it into your spellbook using your own notation.\r\n\r\nFor each level of the spell, the process takes 2 hours and costs 50 gp. The cost represents material components you expend as you experiment with the spell to master it, as well as the fine inks you need to record it. Once you have spent this time and money, you can prepare the spell just like your other spells.\r\n\r\nReplacing the Book. You can copy a spell from your own spellbook into another book-for example, if you want to make a backup copy of your spellbook. This is just like copying a new spell into your spellbook, but faster and easier, since you understand your own notation and already know how to cast the spell. You need spend only 1 hour and 10 gp for each level of the copied spell.\r\n\r\nIf you lose your spellbook, you can use the same procedure to transcribe the spells that you have prepared into a new spellbook. Filling out the remainder of your spellbook requires you to find new spells to do so, as normal. For this reason, many wizards keep backup spellbooks in a safe place.\r\n\r\nThe Book's Appearance. Your spellbook is a unique compilation of spells, with its own decorative flourishes and margin notes. It might be a plain, functional leather volume that you received as a gift from your master, a finely bound gilt-edged tome you found in an ancient library or even a loose collection of notes scrounged together after you lost your previous spellbook in a mishap.\r\n\r\nPreparing and Casting Spells\r\nThe Wizard table shows how many spell slots you have to cast your wizard spells of 1st level and higher. To cast one of these spells, you must expend a slot of the spell's level or higher. You regain all expended spell slots when you finish a long rest.\r\n\r\nYou prepare the list of wizard spells that are available for you to cast. To do so, choose a number of wizard spells from your spellbook equal to your Intelligence modifier + your wizard level (minimum of one spell). The spells must be of a level for which you have spell slots.\r\n\r\nFor example, if you're a 3rd-level wizard, you have four 1st-level and two 2nd-level spell slots. With an Intelligence of 16, your list of prepared spells can include six spells of 1st or 2nd level, in any combination, chosen from your spellbook. If you prepare the 1st-level spell magic missile, you can cast it using a 1st-level or a 2nd-level slot. Casting the spell doesn't remove it from your list of prepared spells.\r\n\r\nYou can change your list of prepared spells when you finish a long rest. Preparing a new list of wizard spells requires time spent studying your spellbook and memorizing the incantations and gestures you must make to cast the spell: at least 1 minute per spell level for each spell on your list.\r\n\r\nSpellcasting Ability\r\nIntelligence is your spellcasting ability for your wizard spells, since you learn your spells through dedicated study and memorization. You use your Intelligence whenever a spell refers to your spellcasting ability. In addition, you use your Intelligence modifier when setting the saving throw DC for a wizard spell you cast and when making an attack roll with one.\r\n\r\nSpell save DC = 8 + your proficiency bonus + your Intelligence modifier\r\n\r\nSpell attack modifier = your proficiency bonus + your Intelligence modifier\r\n\r\nRitual Casting\r\nYou can cast a wizard spell as a ritual if that spell has the ritual tag and you have the spell in your spellbook. You don't need to have the spell prepared.\r\n\r\nSpellcasting Focus\r\nYou can use an arcane focus as a spellcasting focus for your wizard spells.\r\n\r\nLearning Spells of 1st Level and Higher\r\nEach time you gain a wizard level, you can add two wizard spells of your choice to your spellbook. Each of these spells must be of a level for which you have spell slots, as shown on the Wizard table. On your adventures, you might find other spells that you can add to your spellbook.",
                                Level = 1,
                            }

                        },
                        new ClassAbility()
                        {
                            Ability = new Ability()
                            {
                                Name= "Arcane Tradition",
                                Description="When you reach 2nd level, you choose an arcane tradition, shaping your practice of magic through one of the following schools. Your choice grants you features at 2nd level and again at 6th, 10th, and 14th level.",
                                Level = 2,
                            }

                        },

                    }

                },
                new Class
                {
                    Name = "Rogue",
                    Description= "Rogues rely on skill, stealth, and their foes' vulnerabilities to get the upper hand in any situation. They have a knack for finding the solution to just about any problem, demonstrating a resourcefulness and versatility that is the cornerstone of any successful adventuring party.",
                    HitDice = Dice_Type.d8,
                    ClassAbilities = new List<ClassAbility>()
                    {
                        new ClassAbility()
                        {
                            Ability = new Ability()
                            {
                                Name= "Expertise",
                                Description="At 1st level, choose two of your skill proficiencies, or one of your skill proficiencies and your proficiency with thieves' tools. Your proficiency bonus is doubled for any ability check you make that uses either of the chosen proficiencies.\r\n\r\nAt 6th level, you can choose two more of your proficiencies (in skills or with thieves' tools) to gain this benefit.",
                                Level = 1,
                            }

                        },
                        new ClassAbility()
                        {
                            Ability = new Ability()
                            {
                                Name= "Sneak Attack",
                                Description="Beginning at 1st level, you know how to strike subtly and exploit a foe's distraction. Once per turn, you can deal an extra 1d6 damage to one creature you hit with an attack if you have advantage on the attack roll. The attack must use a finesse or a ranged weapon.\r\n\r\nYou don't need advantage on the attack roll if another enemy of the target is within 5 feet of it, that enemy isn't incapacitated, and you don't have disadvantage on the attack roll.\r\n\r\nThe amount of the extra damage increases as you gain levels in this class, as shown in the Sneak Attack column of the Rogue table.",
                                Level = 1,
                            }

                        },
                        new ClassAbility()
                        {
                            Ability = new Ability()
                            {
                                Name= "Cunning Action",
                                Description="Starting at 2nd level, your quick thinking and agility allow you to move and act quickly. You can take a bonus action on each of your turns in combat. This action can be used only to take the Dash, Disengage, or Hide action.",
                                Level = 2,
                            }

                        },

                    }

                },

            };
            
            _db.AddRange( clases );
            _db.AddRange(spellList);
            _db.Add(human);
            _db.Add(dragonborn);
            _db.Add(halfling);
            _db.Add(elf);
            _db.Add(dwarf);
            await _db.SaveChangesAsync();
        }

    }
}
