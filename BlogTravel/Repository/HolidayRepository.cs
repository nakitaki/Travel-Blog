using BlogTravel.Data;
using BlogTravel.Interfaces;
using BlogTravel.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogTravel.Repository
{
    public class HolidayRepository : Interfaces.IHolidayRepository
    {
        private readonly ApplicationDbContext _context;
        public HolidayRepository(ApplicationDbContext contex) 
        { 
            _context = contex;
        }
        public bool Add(Holiday holiday)
        {
           _context.Add(holiday);
            return Save();
        }

        public bool Delete(Holiday holiday)
        {
            _context.Remove(holiday);
            return Save();
        }

        public async Task<IEnumerable<Holiday>> GetAll()
        {
            return await _context.Holidays.ToListAsync();
        }

        public async Task<Holiday> GetByIdAsync(int id)
        {
            return await _context.Holidays.Include(i => i.Address).FirstOrDefaultAsync(i => i.Id == id);
        }
        
        public async Task<Holiday> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Holidays.Include(i => i.Address).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Holiday>> GetHolidayByCity(string city)
        {
            return await _context.Holidays.Where(c => c.Address.City.Contains(city)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Holiday holiday)
        {
            _context.Update(holiday);      
            return Save();
        }
    }
}
