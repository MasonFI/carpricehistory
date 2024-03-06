using CarPriceHistory.Domain;

namespace CarPriceHistory.CarUpdater
{
    internal interface ICarUpdaterService
    {
        ICollection<Car> RetrieveCarData(ICarSellerService carSellerService);
        void UpdateCarData(ICollection<Car> cars);
    }
}
