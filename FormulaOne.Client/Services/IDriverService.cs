using Shared.Models;

namespace FormulaOne.Client.Services
{
    public interface IDriverService
    {
        Task<IEnumerable<Driver>?> All();
        Task<Driver?> GetDriver(int id);
        Task<Driver?> AddDriver(Driver driver);
        Task<bool> UpdateDriver(Driver driver);
        Task<bool> DeleteDriver(int id);
    }
}
