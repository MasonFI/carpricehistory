namespace CarPriceHistory.API.Features.Cars.Exceptions
{
    public class NoCarExistsException : Exception
    {
        public int CarMakerId { get; set; }
        public int CarId { get; set; }

        public NoCarExistsException(int carMakerId, int carId) : base($"Car with id: {carId} doesn't exist for car maker id {carMakerId}")
        {
            CarMakerId = carMakerId;
            CarId = carId;
        }
    }
}
