using DatingSite.Data;
using DatingSite.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingSite.Services
{
    public class ProfileService : IProfileService
    {
        private readonly DatingContext _context;
        public ProfileService(DatingContext context)
        {
            _context = context;
        }

        public async Task CreateProfile(Profile profile)
        {
            _context.profiles.Add(profile);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProfile(int id)
        {
            var profile = await _context.profiles.FindAsync(id);
            if (profile != null)
            {
                profile.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Profile> GetProfileById(int id)
        {
            var profile = await _context.profiles.FindAsync(id);
            return profile;
        }

        public async Task<List<Profile>> GetAllProfiles()
        {
            var result = await _context.profiles.ToListAsync();
            return result;
        }

        public async Task UpdateProfile(Profile profile, int id)
        {
            var dbProfile = await _context.profiles.FindAsync(id);
            if (dbProfile != null)
            {
                dbProfile.Height = profile.Height;
                dbProfile.Weight = profile.Weight;
                dbProfile.Birthdate = profile.Birthdate;
                dbProfile.Picture = profile.Picture;
                dbProfile.Nickname= profile.Nickname;
                dbProfile.Gender = profile.Gender;

                await _context.SaveChangesAsync();
            }
        }
    }
}
