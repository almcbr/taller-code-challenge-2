using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taller.Car.Domain.Interfaces;

namespace Taller.Car.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        // GET: Cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Domain.Entities.Car>>> Get()
        {
              return Ok(await _carService.GetAll());
        }

        // GET: Cars/Details/5
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Domain.Entities.Car>> Get(Guid? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var car = await _carService.GetById(id.Value);

            return Ok(car);
        }



        [HttpPost]
        public async Task<IActionResult> Post([Bind("Make,Model,Year,Doors,Color,Price")] Domain.Entities.Car car)
        {
            if (ModelState.IsValid)
            {
                car.Id = Guid.NewGuid();
                _carService.Add(car);
 
            }
            return Ok(car);
        }


        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]
        public async Task<IActionResult> Put(Guid id, Domain.Entities.Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _carService.Update(car);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
               
            }
            return Ok(car);
        }

        // POST: Cars/Delete/5
        [HttpDelete]
       public async Task<IActionResult> Delete(Guid id)
        {

            var car = await _carService.GetById(id);
            if (car != null)
            {
                _carService.Delete(car);
                return Ok();
            }

            return NotFound();
        }

        private bool CarExists(Guid id)
        {
            var car = _carService.GetById(id);
            
          return car is not { Result: { } };
        }
    }
}
