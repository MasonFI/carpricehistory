using CarPriceHistory.Domain;

namespace CarPriceHistory.API.Features.Cars
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> GetAllCarsAsync(int carMakerId);
        Task<Car> GetCarByIdAsync(int carMakerId, int carId);
        void AddCarToCarMaker(int carMakerId, Car car);
        //void DeleteCar(Car car);
    }
}