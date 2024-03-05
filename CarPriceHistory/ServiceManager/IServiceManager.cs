using CarPriceHistory.API.Features.Cars;

namespace CarPriceHistory.ServiceManager
{
    public interface IServiceManager
    {
        ICarMakerService CarMaker { get; }
        ICarService Car { get; }
        Task SaveAsync();
    }
}
