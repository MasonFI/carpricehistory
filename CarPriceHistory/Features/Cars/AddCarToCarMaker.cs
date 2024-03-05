using CarPriceHistory.API.Features.Cars.Exceptions;
using CarPriceHistory.Domain;
using CarPriceHistory.ServiceManager;
using MediatR;

namespace CarPriceHistory.API.Features.Cars
{
    /// <summary>
    /// Command contains command, result and handler classes
    /// </summary>
    public class AddCarToCarMaker
    {
        //Input
        public class AddCarCommand : IRequest<CarResult>
        {
            public string RegistrationNumber { get; set; } = String.Empty;
            public int ModelYear { get; set; }
            public int CarMakerId { get; set; }
        }

        //Output
        public class CarResult(int id, string registrationNumber, int modelYear, int CarMakerId)
        {
            public int Id { get; set; } = id;
            public string RegistrationNumber { get; set; } = registrationNumber;
            public int ModelYear { get; set; } = modelYear;
            public int CarMakerId { get; set; } = CarMakerId;
        }

        //Handler
        public class Handler : IRequestHandler<AddCarCommand, CarResult>
        {
            private readonly IServiceManager _serviceManager;

            public Handler(IServiceManager serviceManager)
            {
                _serviceManager = serviceManager;
            }

            public async Task<CarResult> Handle(AddCarCommand request, CancellationToken cancellationToken)
            {
                var carMaker = await _serviceManager.CarMaker.GetCarMakerByIdAsync(request.CarMakerId) ??
                    throw new NoCarMakerExistsException(request.CarMakerId);

                var car = new Car()
                {
                    RegisterNumber = request.RegistrationNumber,
                    CarMakerId = carMaker.Id,
                    ModelYear = request.ModelYear,
                };

                _serviceManager.Car.AddCarToCarMaker(request.CarMakerId, car);

                await _serviceManager.SaveAsync();

                var result = new CarResult(car.Id, car.RegisterNumber, car.ModelYear, request.CarMakerId);

                return result;
            }
        }
    }
}
