using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Threading.Tasks;
using System.Threading;
using System;
using Applications.Implement.Services.Configs;
using Infrastructures.Models.Configs;
using Microsoft.Extensions.Options;

namespace DesignPattern.Controllers.CreationalPatterns
{
    /// <summary>
    /// Singleton is a creational design pattern that lets you ensure that a class has only one instance, while providing a global access point to this instance.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SingletonController : ControllerBase
    {
        /// <summary>
        /// Pros:
        ///     You can be sure that a class has only a single instance.
        ///     You gain a global access point to that instance.
        ///     The singleton object is initialized only when it’s requested for the first time.
        ///     
        /// Cons:
        ///     Violates the Single Responsibility Principle. The pattern solves two problems at the time.
        ///     The Singleton pattern can mask bad design, for instance, when the components of the program know too much about each other.
        ///     The pattern requires special treatment in a multithreaded environment so that multiple threads won’t create a singleton object several times.
        ///     It may be difficult to unit test the client code of the Singleton because many test frameworks rely on inheritance when producing mock objects.
        ///         Since the constructor of the singleton class is private and overriding static methods is impossible in most languages,
        ///         you will need to think of a creative way to mock the singleton.Or just don’t write the tests. Or don’t use the Singleton pattern.
        ///         
        /// Reference:
        ///     https://refactoring.guru/design-patterns/singleton
        /// </summary>
        private readonly CloudConfigService _cloudConfigService;
        private readonly CloudConfig _cloudConfig;

        /// <summary>
        /// 3 case get singleton configs
        /// 1 case manual
        /// 2 case using extension from Net
        /// </summary>
        /// <param name="cloudConfig"></param>

        //public SingletonController(CloudConfigService cloudConfigService)
        //{
        //    _cloudConfigService = cloudConfigService;
        //}

        //public SingletonController(IOptions<CloudConfig> cloudConfig)
        //{
        //    // other handle case of Net
        //    _cloudConfig = cloudConfig.Value;
        //}

        public SingletonController(CloudConfig cloudConfig)
        {
            _cloudConfig = cloudConfig;
        }

        [HttpGet]
        public IActionResult GetCloudConfig()
        {
            //return Ok(_cloudConfigService.GetConfig());
            return Ok(_cloudConfig);
        }
    }
}
