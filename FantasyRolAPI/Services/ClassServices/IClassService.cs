using FantasyRolAPI.DTOs.ClassDTOs;

namespace FantasyRolAPI.Services.ClassServices
{
    public interface IClassService
    {
        Task<ClassMiniDTO> getClassById(Guid classId);
    }
}
