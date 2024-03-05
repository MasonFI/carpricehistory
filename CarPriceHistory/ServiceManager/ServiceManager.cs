using CarPriceHistory.API.Features.Cars;
using CarPriceHistory.Data;

namespace CarPriceHistory.ServiceManager
{
    public class ServiceManager : IServiceManager
    {
        private readonly DataContext _context;
        private ICarMakerService _carMakerService;
        private ICarService _carService;

        public ServiceManager(DataContext context)
        {
            _context = context;
        }

        public ICarMakerService CarMaker => _carMakerService ??= new CarMakerService(_context);
        public ICarService Car => _carService ??= new CarService(_context);

        public Task SaveAsync() => _context.SaveChangesAsync();
    }
}
