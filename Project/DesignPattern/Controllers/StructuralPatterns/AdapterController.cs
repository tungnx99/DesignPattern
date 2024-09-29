namespace DesignPattern.Controllers.StructuralPatterns
{
    using Applications.Implement.Interfaces.ConvertXMLToObject;
    using Microsoft.AspNetCore.Mvc;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// Adapter is a structural design pattern that allows objects with incompatible interfaces to collaborate.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AdapterController : ControllerBase
    {
        /// <summary>
        /// Pros:
        ///     Single Responsibility Principle. You can separate the interface or
        ///         data conversion code from the primary business logic of the program.
        ///     Open/Closed Principle.You can introduce new types of adapters into
        ///         the program without breaking the existing client code, as long as
        ///         they work with the adapters through the client interface.
        ///     
        /// Cons:
        ///     The overall complexity of the code increases because you need to introduce a set of new interfaces and classes.
        ///         Sometimes it’s simpler just to change the service class so that it matches the rest of your code.
        ///         
        /// Reference:
        ///     https://refactoring.guru/design-patterns/adapter
        /// </summary>

        private readonly IConvertXMLToObject _convertXMLToObject;

        public AdapterController(IConvertXMLToObject convertXMLToObject)
        {
            _convertXMLToObject = convertXMLToObject;
        }

        /// <summary>
        /// Need start project XMLProject
        /// </summary>

        [HttpGet]
        public IActionResult GetProduct()
        {
            var products = new List<IProduct>();

            products.Add(new ProductDirectly());
            products.Add(new ProductFromXML(_convertXMLToObject));

            var result = products.SelectMany(dataSource =>
            {
                var productList = dataSource.GetProduct().Result;

                return productList.WeatherForecasts;
            });

            return Ok(result);
        }

        private interface IProduct
        {
            Task<ArrayOfWeatherForecast> GetProduct();
        }

        private class ProductDirectly : IProduct
        {
            public Task<ArrayOfWeatherForecast> GetProduct()
            {
                var result = new ArrayOfWeatherForecast()
                {
                    WeatherForecasts = new List<WeatherForecast> {
                        new WeatherForecast()
                        {
                            Date = DateTime.Now,
                            Summary = string.Empty,
                            TemperatureC = 32,
                        }
                    }
                };

                return Task.FromResult(result);
            }
        }

        private class ProductFromXML : IProduct
        {
            private IConvertXMLToObject _convertXMLToObject;
            public ProductFromXML(IConvertXMLToObject convertXMLToObject)
            {
                _convertXMLToObject = convertXMLToObject;
            }

            public async Task<ArrayOfWeatherForecast> GetProduct()
            {
                string xmlString = string.Empty;
                HttpResponseMessage response = await new HttpClient().GetAsync("https://localhost:7160/WeatherForecast");
                if (response.IsSuccessStatusCode)
                {
                    xmlString = await response.Content.ReadAsStringAsync();
                }

                var result = _convertXMLToObject.Convert<ArrayOfWeatherForecast>(xmlString);

                // handle something logic code

                return result;
            }
        }

        [XmlRoot(ElementName = "ArrayOfWeatherForecast", Namespace = "http://schemas.datacontract.org/2004/07/XMLProject")]
        public class ArrayOfWeatherForecast
        {
            [XmlElement(ElementName = "WeatherForecast", Namespace = "http://schemas.datacontract.org/2004/07/XMLProject")]
            public List<WeatherForecast> WeatherForecasts { get; set; }
        }

        public class WeatherForecast
        {
            [XmlElement(ElementName = "Date", Namespace = "http://schemas.datacontract.org/2004/07/XMLProject")]
            public DateTime? Date { get; set; }

            [XmlElement(ElementName = "Summary", Namespace = "http://schemas.datacontract.org/2004/07/XMLProject")]
            public string Summary { get; set; }

            [XmlElement(ElementName = "TemperatureC", Namespace = "http://schemas.datacontract.org/2004/07/XMLProject")]
            public int TemperatureC { get; set; }
        }
    }
}
