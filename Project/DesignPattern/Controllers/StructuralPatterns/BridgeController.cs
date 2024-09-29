namespace DesignPattern.Controllers.StructuralPatterns
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Bridge is a structural design pattern that lets you split a large class or
    ///     a set of closely related classes into two separate hierarchies—abstraction and
    ///     implementation—which can be developed independently of each other.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BridgeController : ControllerBase
    {
        /// <summary>
        /// Pros:
        ///     You can create platform-independent classes and apps.
        ///     The client code works with high-level abstractions.It isn’t exposed to the platform details.
        ///     Open/Closed Principle. You can introduce new abstractions and implementations independently from each other.
        ///     Single Responsibility Principle.You can focus on high-level logic in the abstraction and on platform details
        ///         in the implementation.
        ///     
        /// Cons:
        ///     You might make the code more complicated by applying the pattern to a highly cohesive class.
        ///         
        /// Reference:
        ///     https://refactoring.guru/design-patterns/bridge
        /// </summary>

        [HttpPost]
        public IActionResult GetStaffs()
        {
            var staffs = new List<Staff>
            {
                new CEO { Info = new Senior () { Level = "A" } },
                new Manager { Info = new Senior () { Level = "B" } },
                new Manager { Info = new Junior () { Level = "C" } },
            };
            return Ok(staffs);
        }

        private abstract class StaffInfo
        {
            public string Level { get; set; }

            public virtual string GetInfo => string.Empty;
        }

        private class Junior : StaffInfo
        {
            public override string GetInfo => "Junior " + Level;
        }

        private class Senior : StaffInfo
        {
            public override string GetInfo => "Senior " + Level;
        }

        private abstract class Staff
        {
            public StaffInfo Info { get; set; }

            public virtual string GetInfo => string.Empty;
        }

        private class CEO : Staff
        {
            public override string GetInfo => "CEO";
        }

        private class Manager : Staff
        {
            public override string GetInfo => "Manager";
        }
    }
}
