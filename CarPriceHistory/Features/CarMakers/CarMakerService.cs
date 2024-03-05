using CarPriceHistory.Data;
using CarPriceHistory.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarPriceHistory.API.Features.Cars
{
    public class CarMakerService : ICarMakerService
    {
        private readonly DataContext _context;

        public CarMakerService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CarMaker>> GetAllCarMakersAsync()
        {
            return await _context.CarMakers
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<CarMaker?> GetCarMakerByIdAsync(int carId)
        {
            return await _context.CarMakers
                .FirstOrDefaultAsync(x => x.Id == carId);
        }
    }
}
