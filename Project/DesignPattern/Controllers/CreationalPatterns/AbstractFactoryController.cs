using Applications.Implement.Interfaces.Senders;
using DesignPattern.Model.Models.Senders;
using Infrastructures.Share.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace DesignPattern.Controllers.CreationalPatterns
{
    /// <summary>
    /// Factory Method is a creational design pattern that provides an interface for creating objects in a superclass,
    /// but allows subclasses to alter the type of objects that will be created.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AbstractFactoryController : ControllerBase
    {
        /// <summary>
        /// Pros:
        ///     You can be sure that the products you’re getting from a factory are compatible with each other.
        ///     You avoid tight coupling between concrete products and client code.
        ///     Single Responsibility Principle. You can extract the product creation code into one place, making the code easier to support.
        ///     Open/Closed Principle. You can introduce new variants of products without breaking existing client code.
        ///     
        /// Cons:
        ///     The code may become more complicated than it should be, since a lot of new interfaces and classes are introduced along with the pattern.
        ///     
        /// Reference:
        ///     https://refactoring.guru/design-patterns/factory-method
        /// </summary>
        private readonly ISenderFactory _senderFactory;
        private readonly ISenderAbstractFactory _senderBossFactory;
        private readonly ISenderAbstractFactory _senderVIPFactory;

        public AbstractFactoryController(
            ISenderFactory senderFactory,
            [FromKeyedServices(NotifySenderType.BOSS)]  ISenderAbstractFactory senderBossFactory,
            [FromKeyedServices(NotifySenderType.VIP)]  ISenderAbstractFactory senderVIPFactory)
        {
            _senderFactory = senderFactory;
            _senderBossFactory = senderBossFactory;
            _senderVIPFactory = senderVIPFactory;
        }

        [HttpPost]
        public IActionResult BossMailSender(SenderCreateRequest request)
        {
            var sender = _senderFactory.GetFactory(NotifySenderType.BOSS);

            // or
            //var sender = _senderBossFactory;

            sender.CreateMailSender(new Applications.Model.Models.MailSenderDTO());

            return Ok();
        }

        [HttpPost]
        public IActionResult BossSMSSender(SenderCreateRequest request)
        {
            var sender = _senderFactory.GetFactory(NotifySenderType.BOSS);

            // or
            //var sender = _senderBossFactory;

            sender.CreateSMSSender(new Applications.Model.Models.SMSSenderDTO());

            return Ok();
        }

        [HttpPost]
        public IActionResult VIPMailSender(SenderCreateRequest request)
        {
            var sender = _senderFactory.GetFactory(NotifySenderType.VIP);

            // or
            //var sender = _senderVIPFactory;

            sender.CreateMailSender(new Applications.Model.Models.MailSenderDTO());

            return Ok();
        }

        [HttpPost]
        public IActionResult VIPSMSSender(SenderCreateRequest request)
        {
            var sender = _senderFactory.GetFactory(NotifySenderType.VIP);

            // or
            //var sender = _senderVIPFactory;

            sender.CreateSMSSender(new Applications.Model.Models.SMSSenderDTO());

            return Ok();
        }

    }
}
