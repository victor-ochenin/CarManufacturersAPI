using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarManufacturersAPI.Data;
using CarManufacturersAPI.Models;

namespace CarManufacturersAPI.Api
{
    [Route("api/car")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public CarsController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET http://localhost:5217/api/car
        [HttpGet]
        public async Task<List<CarHeaderMessage>> ListAll()
        {
            List<Car> cars = await _db.Cars.ToListAsync();

            List<CarHeaderMessage> carHeaders = cars.Select(car => new CarHeaderMessage(
                Model: car.Model,
                Uri: $"{Request.Scheme}://{Request.Host}/api/car/{car.Id}"
            )).ToList();

            return carHeaders;
        }

        // GET http://localhost:5217/api/car/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            Car? car = await _db.Cars
                .Include(c => c.Manufacturer)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (car == null)
            {
                return NotFound(new StringMessage($"car '{id}' not found"));
            }

            CarMessage message = new CarMessage(
                Id: id,
                Model: car.Model,
                Year: car.Year,
                Price: car.Price,
                Color: car.Color,
                manufacturer: new ManufacturerMessage(
                    Id: car.Manufacturer!.Id,
                    Name: car.Manufacturer!.Name,
                    Country: car.Manufacturer!.Country
                )
            );
            return Ok(message);
        }

        // POST http://localhost:5217/api/car
        [HttpPost]
        public async Task<IActionResult> Create(CarFormMessage message)
        {
            if (string.IsNullOrEmpty(message.Model))
            {
                return BadRequest(new StringMessage("model cannot be empty"));
            }

            bool isManufacturerExists = await _db.Manufacturers
                .Where(m => m.Id == message.ManufacturerId)
                .AnyAsync();
            if (!isManufacturerExists)
            {
                return NotFound(new StringMessage($"manufacturer '{message.ManufacturerId}' not found"));
            }

            Car car = new Car()
            {
                Model = message.Model,
                Year = message.Year,
                Price = message.Price,
                Color = message.Color,
                ManufacturerId = message.ManufacturerId
            };

            await _db.Cars.AddAsync(car);
            await _db.SaveChangesAsync();

            CarHeaderMessage header = new CarHeaderMessage(
                Model: car.Model,
                Uri: $"{Request.Scheme}://{Request.Host}/api/car/{car.Id}"
            );
            return Ok(header);
        }

        // PATCH http://localhost:5217/api/car/{id}
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> Edit(int id, CarFormMessage message)
        {
            Car? car = await _db.Cars.FirstOrDefaultAsync(c => c.Id == id);
            if (car == null)
            {
                return NotFound(new StringMessage($"car '{id}' not found"));
            }

            if (string.IsNullOrEmpty(message.Model))
            {
                return BadRequest(new StringMessage("model cannot be empty"));
            }

            bool isManufacturerExists = await _db.Manufacturers
                .Where(m => m.Id == message.ManufacturerId)
                .AnyAsync();
            if (!isManufacturerExists)
            {
                return NotFound(new StringMessage($"manufacturer '{message.ManufacturerId}' not found"));
            }

            car.Model = message.Model;
            car.Year = message.Year;
            car.Price = message.Price;
            car.Color = message.Color;
            car.ManufacturerId = message.ManufacturerId;

            await _db.SaveChangesAsync();

            CarHeaderMessage header = new CarHeaderMessage(
                Model: car.Model,
                Uri: $"{Request.Scheme}://{Request.Host}/api/car/{car.Id}"
            );
            return Ok(header);
        }

        // DELETE http://localhost:5217/api/car/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            Car? car = await _db.Cars.FirstOrDefaultAsync(c => c.Id == id);
            if (car == null)
            {
                return NotFound(new StringMessage($"car '{id}' not found"));
            }

            _db.Cars.Remove(car);
            await _db.SaveChangesAsync();

            return Ok(new StringMessage($"car '{id}' deleted"));
        }
    }
} 