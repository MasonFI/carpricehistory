
using CarPriceHistory.Domain;

namespace CarPriceHistory.CarUpdater
{
    internal interface ICarSellerService
    {
        ICollection<Car> SearchCars(string? maker = null, string? model = null, int? year = null);
    }
}
