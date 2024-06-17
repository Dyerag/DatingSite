using DatingSite.Models;

namespace DatingSite.Services
{
    public interface IProfileService
    {
        Task<List<Profile>> GetAllProfiles();
        Task<Profile> GetProfileById(int id);
        Task CreateProfile(Profile profile);
        Task UpdateProfile(Profile profile, int id);
        Task DeleteProfile(int id);
    }
}

