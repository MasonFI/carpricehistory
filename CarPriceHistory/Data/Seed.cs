using CarPriceHistory.Data;
using CarPriceHistory.Domain;

namespace CarPriceHistory.API.Data
{
    public class Seed
    {
        public void SeedData(DataContext context)
        {
            //Seeding car makers

            context.CarMakers.Add(new CarMaker
            {
                Id = 1,
                Name = "Toyota",
            });

            context.CarMakers.Add(new CarMaker
            {
                Id = 2,
                Name = "Skoda",
            });

            //Seeding cars

            context.Cars.Add(new Car
            {
                Id = 10,
                CarMakerId = 1,
                Created = DateTime.Now,
                CarModelId = 1,
                FirstRegistrationYear = 2007,
                LastSeen = DateTime.Now,
                ModelYear = 2007,
                RegisterNumber = "ABC-123",
            });

            context.Cars.Add(new Car
            {
                Id = 11,
                CarMakerId = 2,
                Created = DateTime.Now,
                CarModelId = 2,
                FirstRegistrationYear = 2001,
                LastSeen = DateTime.Now,
                ModelYear = 2001,
                RegisterNumber = "DEF-456",
            });

            context.SaveChanges();
        }
    }
}
