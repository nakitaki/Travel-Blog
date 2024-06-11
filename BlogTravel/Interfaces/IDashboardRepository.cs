using BlogTravel.Models;

namespace BlogTravel.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<Adventure>> GetAllUserAdventures();
        Task<List<Holiday>> GetAllUserHolidays();

    }
}
