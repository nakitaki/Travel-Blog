using BlogTravel.Models;

namespace BlogTravel.Interfaces
{
    public interface IHolidayRepository
    {
        Task<IEnumerable<Holiday>> GetAll();
        Task<Holiday> GetByIdAsync(int id);
        Task<Holiday> GetByIdAsyncNoTracking(int id);
        Task<IEnumerable<Holiday>> GetHolidayByCity(string city);

        bool Add(Holiday holiday);
        bool Update(Holiday holiday);
        bool Delete(Holiday holiday);
        bool Save();
    }
}
