using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.Controllers.StructuralPatterns
{
    /// <summary>
    /// Facade is a structural design pattern that provides a simplified interface to a library,
    ///     a framework, or any other complex set of classes.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FacadeController : ControllerBase
    {
        /// <summary>
        /// Pros:
        ///     You can isolate your code from the complexity of a subsystem.
        ///     
        /// Cons:
        ///     A facade can become a god object coupled to all classes of an app.
        ///     
        /// Reference:
        ///     https://refactoring.guru/design-patterns/decorator
        /// </summary>
        ///

        [HttpPost]
        public IActionResult BuyProductByCashWithFreeShipping(string email)
        {
            ShopFacade.GetInstance().BuyProductByCashWithFreeShipping(email);

            return Ok();
        }

        [HttpPost]
        public IActionResult BuyProductByPaypalWithStandardShipping(string email, string phone)
        {
            ShopFacade.GetInstance().BuyProductByPaypalWithStandardShipping(email, phone);

            return Ok();
        }

        public interface IAccountService
        {
            void GetAccout(string email);
        }

        public interface IEmailService
        {
            void SendMail(string mailTo);
        }

        public interface IPaymentService
        {
            void PaymentByPaypal();

            void PaymentByCreditCard();

            void PaymentByEBankingAccount();

            void PaymentByCash();
        }

        public interface IShippingService
        {
            void FreeShipping();

            void StandardShipping();

            void ExpressShipping();
        }

        public interface ISmsService
        {
            void SendSMS(string mobilePhone);
        }

        public class ShopFacade
        {
            private static ShopFacade _instance;

            private IAccountService accountService;
            private IPaymentService paymentService;
            private IShippingService shippingService;
            private IEmailService emailService;
            private ISmsService smsService;


            public static ShopFacade GetInstance()
            {
                if (_instance == null)
                    _instance = new ShopFacade();
                return _instance;
            }

            public void BuyProductByCashWithFreeShipping(string email)
            {
                accountService.GetAccout(email);
                paymentService.PaymentByCash();
                shippingService.FreeShipping();
                emailService.SendMail(email);
                Console.WriteLine("Done\n");
            }

            public void BuyProductByPaypalWithStandardShipping(string email, string mobilePhone)
            {
                accountService.GetAccout(email);
                paymentService.PaymentByPaypal();
                shippingService.StandardShipping();
                emailService.SendMail(email);
                smsService.SendSMS(mobilePhone);
                Console.WriteLine("Done\n");
            }
        }

    }
}
