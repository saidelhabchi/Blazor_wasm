using Shared.Dtos;
namespace FormulaOne.Services.DriverService
{
    public interface IDriverService
    {
        IEnumerable<DriverDto> GetDrivers();
        DriverDto GetDriver(int id);
        void UpdateDriver(int id,DriverDto driver);
        DriverDto CreateDriver(DriverDto driver);
        void DeleteDriver(int id);
    }
}
