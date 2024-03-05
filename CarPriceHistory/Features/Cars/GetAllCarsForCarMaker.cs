using CarPriceHistory.API.Features.Cars.Exceptions;
using CarPriceHistory.ServiceManager;
using MediatR;

namespace CarPriceHistory.API.Features.Cars
{
    /// <summary>
    /// Query class contains query, result and handler classes
    /// </summary>
    public class GetAllCarsForCarMaker
    {
        public class GetCarsQuery : IRequest<IEnumerable<CarResult>>
        {
            public int CarMakerId { get; set; }
        }

        public class CarResult(int id, string registrationNumber, int modelYear)
        {
            public int Id { get; set; } = id;
            public string RegistrationNumber { get; set; } = registrationNumber;
            public int ModelYear { get; set; } = modelYear;
        }

        public class Handler : IRequestHandler<GetCarsQuery, IEnumerable<CarResult>>
        {
            private readonly IServiceManager _serviceManager;

            public Handler(IServiceManager serviceManager)
            {
                _serviceManager = serviceManager;
            }

            public async Task<IEnumerable<CarResult>> Handle(GetCarsQuery request, CancellationToken cancellationToken)
            {
                var carMaker = await _serviceManager.CarMaker.GetCarMakerByIdAsync(request.CarMakerId) ?? 
                    throw new NoCarMakerExistsException(request.CarMakerId);

                var cars = await _serviceManager.Car.GetAllCarsAsync(carMaker.Id);

                var result = cars.Select(x => new CarResult(x.Id, x.RegisterNumber, x.ModelYear));

                return result;
            }
        }
    }
}
