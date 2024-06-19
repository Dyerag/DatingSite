using DatingSite.Data;
using DatingSite.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingSite.Services
{
    public class CityService
    {
        private readonly DatingContext _context;
        public CityService(DatingContext context)
        {
            _context = context;
        }

        public async Task<City> GetCityById(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            return city;
        }
    }
}
