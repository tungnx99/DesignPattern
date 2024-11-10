using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace DesignPattern.Controllers.StructuralPatterns
{
    /// <summary>
    /// Flyweight is a structural design pattern that lets you fit more objects into
    ///     the available amount of RAM by sharing common parts of state between
    ///     multiple objects instead of keeping all of the data in each object.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FlyweightController : ControllerBase
    {
        /// <summary>
        /// Pros:
        ///     You can save lots of RAM, assuming your program has tons of similar objects.
        ///     
        /// Cons:
        ///     You might be trading RAM over CPU cycles when some of the context data needs to be recalculated each time somebody calls a flyweight method.
        ///     The code becomes much more complicated. New team members will always be wondering why the state of an entity was separated in such a way.
        ///     
        /// Reference:
        ///     https://refactoring.guru/design-patterns/flyweight
        /// </summary>
        ///

        [HttpGet]
        public IActionResult GetCarsNoPattern()
        {
            DateTime time1 = DateTime.Now;
            var colors = new string[] { "black", "white", "red", "yellow", "blue" };
            var types = new string[] { "meceder", "toyota", "honda" };

            var cars = new List<Car>();

            for (int i = 0; i < 100000; i++)
            {
                cars.Add(new Car
                {
                    Description = new CarDescription
                    {
                        Color = colors[i % 5],
                        Type = types[i % 3]
                    },
                    Name = "Car" + i,
                    Price = new Random().Next(9999, 999999)
                });
            }

            DateTime time2 = DateTime.Now;
            return Ok(time2 - time1);
        }

        [HttpGet]
        public IActionResult GetCarsWithPattern()
        {
            DateTime time1 = DateTime.Now;
            var colors = new string[] { "black", "white", "red", "yellow", "blue" };
            var types = new string[] { "meceder", "toyota", "honda" };

            var carFlyweightPattern = new CarFlyweightPattern();

            for (int i = 0; i < 100000; i++)
            {
                carFlyweightPattern.AddCar("Car" + i, new Random().Next(9999, 999999), colors[i % 5], types[i % 3]);
            }

            DateTime time2 = DateTime.Now;
            return Ok(time2 - time1);
        }

        public class CarFlyweightPattern
        {
            private Dictionary<string, CarDescription> _carDescriptions;

            private List<Car> _cars;

            public CarFlyweightPattern()
            {
                _cars = new List<Car>();
                _carDescriptions = new Dictionary<string, CarDescription>();
            }

            public void AddCar(string name, decimal price, string color, string type)
            {
                var carDescription = default(CarDescription);
                var isCarDescription = _carDescriptions.TryGetValue($"{color}_{type}", out carDescription);

                if (!isCarDescription)
                {
                    carDescription = _carDescriptions[$"{color}_{type}"] = new CarDescription { Color = color, Type = type };
                }

                _cars.Add(new Car
                {
                    Name = name,
                    Price = price,
                    Description = carDescription
                });
            }

            public List<Car> GetCars => _cars;
        }

        public class Car
        {
            public string Name { get; set; }

            public decimal Price { get; set; }

            public CarDescription Description { get; set; }
        }

        public class CarDescription
        {
            public string Color { get; set; }

            public string Type { get; set; }
        }
    }
}
