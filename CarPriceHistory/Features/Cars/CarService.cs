using CarPriceHistory.Data;
using CarPriceHistory.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarPriceHistory.API.Features.Cars
{
    public class CarService : ICarService
    {
        private readonly DataContext _context;

        public CarService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Car>> GetAllCarsAsync(int carMakerId)
        {
            return await _context.Cars
                .Where(x => x.CarMakerId == carMakerId)
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<Car?> GetCarByIdAsync(int carMakerId, int carId)
        {
            return await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == carId && x.CarMakerId == carMakerId);
        }

        public void AddCarToCarMaker(int carMakerId, Car car)
        {
            car.CarMakerId = carMakerId;
            _context.Cars.Add(car);
        }
    }
}
