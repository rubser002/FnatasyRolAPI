using FantasyRolAPI.DTOs;
using FantasyRolAPI.Models;

namespace FantasyRolAPI.Services.CharacteristicsServices
{
    public interface ICharacteristicsService
    {
        Task<List<Ability>> getAbilityByClassLevel(Guid classId, int classLevel);
        Task generateData();

        Task<List<LabelAndValue>> getClassAutocomplete();
        Task<List<LabelAndValue>> getRaceAutocomplete();
    }
}
