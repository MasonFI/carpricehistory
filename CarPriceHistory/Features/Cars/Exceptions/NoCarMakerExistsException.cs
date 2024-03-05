namespace CarPriceHistory.API.Features.Cars.Exceptions
{
    public class NoCarMakerExistsException : Exception
    {
        public NoCarMakerExistsException(int carMakerId) : base($"Car maker with id: {carMakerId} doesn't exist.") { }

    }
}
