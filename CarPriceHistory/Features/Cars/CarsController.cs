using CarPriceHistory.API.Features.Cars.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static CarPriceHistory.API.Features.Cars.GetAllCarsForCarMaker;

namespace CarPriceHistory.API.Features.Cars
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetCarsForCarMaker")]
        public async Task<ActionResult<IEnumerable<CarResult>>> GetCarsForCarMaker(int carMakerId)
        {
            try
            {
                var query = new GetCarsQuery
                {
                    CarMakerId = carMakerId
                };

                var result = await _mediator.Send(query);

                return Ok(result);
            }
            catch (NoCarExistsException ex)
            {
                return Conflict(new
                {
                    ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddCar(AddCarToCarMaker.AddCarCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);

                return CreatedAtRoute("GetCarsForCarMaker", new { carMakerId = result.CarMakerId }, result);
            }
            catch (NoCarMakerExistsException ex)
            {
                return Conflict(new
                {
                    ex.Message
                });
            }
        }

        //[HttpPut]
        //public async Task<ActionResult> UpdateCarForCarMaker(int carMakerId, UpdateCarCommand command)
        //{
        //    try
        //    {
        //        command.CarMakerId = carMakerId;

        //        var result = await _mediator.Send(command);

        //        return NoContent();
        //    }
        //    catch (NoCarMakerExistsException ex)
        //    {
        //        return Conflict(new
        //        {
        //            ex.Message
        //        });
        //    }
        //    catch (NoCarExistsException ex)
        //    {
        //        return Conflict(new
        //        {
        //            ex.Message,
        //            ex.CarMakerId,
        //            ex.CarId
        //        });
        //    }
        //}

        //[HttpDelete]
        //public async Task<ActionResult> RemoveCarFromCarMaker(int carMakerId, RemoveCarCommand command)
        //{
        //    try
        //    {
        //        command.CarMakerId = carMakerId;

        //        await _mediator.Send(command);

        //        return NoContent();
        //    }
        //    catch (NoCarMakerExistsException ex)
        //    {
        //        return Conflict(new
        //        {
        //            ex.Message
        //        });
        //    }
        //    catch (NoCarExistsException ex)
        //    {
        //        return Conflict(new
        //        {
        //            ex.Message,
        //            ex.CarMakerId,
        //            ex.CarId
        //        });
        //    }
        //}
    }
}
