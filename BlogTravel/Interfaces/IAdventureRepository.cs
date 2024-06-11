using BlogTravel.Models;

namespace BlogTravel.Interfaces
{
    public interface IAdventureRepository
    {
        Task<IEnumerable<Adventure>> GetAll();
        Task<Adventure> GetByIdAsync(int id);

        Task<Adventure> GetByIdAsyncNoTracking(int id);

        Task<IEnumerable<Adventure>> GetAllAdventuresByCity(string city);
        bool Add(Adventure adventure);
        bool Update(Adventure adventure);
        bool Delete(Adventure adventure);
        bool Save();
    }
}
