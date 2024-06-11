using BlogTravel.Data;
using BlogTravel.Interfaces;
using BlogTravel.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogTravel.Repository
{
    public class AdventureRepository : IAdventureRepository
    {
        ApplicationDbContext _context;
        public AdventureRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Adventure adventure)
        {
            _context.Add(adventure);
            return Save();
        }

        public bool Delete(Adventure adventure)
        {
            _context.Remove(adventure);
            return Save();
        }

        public async Task<IEnumerable<Adventure>> GetAll()
        {
            return await _context.Adventures.ToListAsync();
        }

        public async Task<IEnumerable<Adventure>> GetAllAdventuresByCity(string city)
        {
            return await _context.Adventures.Where(c => c.Address.City.Contains(city)).ToListAsync();
        }

        public async Task<Adventure> GetByIdAsync(int id)
        {
            return await _context.Adventures.Include(i => i.Address).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Adventure> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Adventures.Include(i => i.Address).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }


        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Adventure adventure)
        {
            _context.Update(adventure);
            return Save();
        }
    }
}
