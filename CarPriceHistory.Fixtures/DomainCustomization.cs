using AutoFixture;
using Bogus;
using Bogus.Extensions.UnitedKingdom;
using CarPriceHistory.Domain;

namespace CarPriceHistory.Fixtures
{
    public class DomainCustomization : CompositeCustomization
    {
        public DomainCustomization() : base(
            new CarMakerCustomization(),
            new CarModelCustomization(),
            new CarCustomization()
            )
        {
        }
    }

    public class CarMakerCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            var faker = new Faker();

            fixture.Customize<CarMaker>(ob => ob
              .With(cm => cm.Name, faker.Vehicle.Manufacturer())
              .With(cm => cm.Created, faker.Date.Past(5))
              .Without(cm => cm.CarModels)
            );
        }
    }

    public class CarModelCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            var faker = new Faker();

            fixture.Customize<CarModel>(ob => ob
              .With(cm => cm.Name, faker.Vehicle.Model())
              .With(cm => cm.Created, faker.Date.Past(5))
              .Without(cm => cm.Cars)
            );
        }
    }

    public class CarCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            var faker = new Faker();

            fixture.Customize<Car>(ob => ob
                .With(c => c.Created, faker.Date.Past(3))
                .With(c => c.FirstRegistrationYear, faker.Random.Int(1970, DateTime.Now.Year))
                .With(c => c.RegisterNumber, faker.Vehicle.GbRegistrationPlate(DateTime.Now.AddYears(-50), DateTime.Now))
            );
        }
    }

}
