using CarPriceHistory.Domain;

namespace CarPriceHistory.API.Features.Cars
{
    public interface ICarMakerService
    {
        Task<IEnumerable<CarMaker>> GetAllCarMakersAsync();
        Task<CarMaker?> GetCarMakerByIdAsync(int carId);
    }
}