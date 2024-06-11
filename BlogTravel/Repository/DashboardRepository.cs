using BlogTravel.Data;
using BlogTravel.Interfaces;
using BlogTravel.Models;

namespace BlogTravel.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DashboardRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<Holiday>> GetAllUserHolidays()
        {
            var curUser = _httpContextAccessor.HttpContext?.User;
            var userHolidays = _context.Holidays.Where(r => r.AppUser.Id == curUser.ToString());
            return userHolidays.ToList();
        }

        public async Task<List<Adventure>> GetAllUserAdventures()
        {
            var curUser = _httpContextAccessor.HttpContext?.User;
            var userAdventures = _context.Adventures.Where(r => r.AppUser.Id == curUser.ToString());
            return userAdventures.ToList();
        }
    }
}
