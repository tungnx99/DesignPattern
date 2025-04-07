namespace DesignPattern.Controllers.BehavioralPatterns.ChainOfResponsibility
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Chain of Responsibility is a behavioral design pattern that lets you pass requests along a chain of handlers.
    ///     Upon receiving a request, each handler decides either to process the request or to pass it to the next handler in the chain.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChainOfResponsibilityController : ControllerBase
    {
        /// <summary>
        /// Pros:
        ///     You can control the order of request handling.
        ///     Single Responsibility Principle.You can decouple classes that invoke operations from classes that perform operations.
        ///     Open/Closed Principle. You can introduce new handlers into the app without breaking the existing client code.
        ///     
        /// Cons:
        ///     Some requests may end up unhandled.
        ///     
        /// Reference:
        ///     https://refactoring.guru/design-patterns/chain-of-responsibility
        /// </summary>
        ///

        [HttpGet]
        [HRCalling]
        [Interviewer]
        [HeadOfDeparment]
        [HRHiringManager]
        public IActionResult InterView(int lv)
        {
            return Ok($"Pass interview {lv}");
        }

        [HttpGet]
        public IActionResult ApproveByLv(int lv)
        {
            var result = ApproveStatus.NO_PERMISSION;
            var typeApprove = string.Empty;

            var approveHandlers = new List<IApproveHandler>
            {
                new StaffHandler(),
                new LeadHandler(),
                new ManagerHandler()
            };

            foreach (var handler in approveHandlers)
            {
                var status = handler.IApprove(lv);

                typeApprove = handler.GetType().Name;
                result = status;

                if (status == ApproveStatus.APPROVE)
                {
                    break;
                }
            }

            return Ok($"{typeApprove} {result} {lv}");

        }

        public enum ApproveStatus
        {
            APPROVE,
            REJECT,
            NO_PERMISSION
        }

        public interface IApproveHandler
        {
            public ApproveStatus IApprove(int lv);
        }

        public class StaffHandler : IApproveHandler
        {
            public ApproveStatus IApprove(int lv)
            {
                if (lv <= 1)
                {
                    return ApproveStatus.APPROVE;
                }
                else
                {
                    return ApproveStatus.NO_PERMISSION;
                }
            }
        }

        public class LeadHandler : IApproveHandler
        {
            public ApproveStatus IApprove(int lv)
            {
                if (lv <= 2)
                {
                    return ApproveStatus.APPROVE;
                }
                else
                {
                    return ApproveStatus.NO_PERMISSION;
                }
            }
        }

        public class ManagerHandler : IApproveHandler
        {
            public ApproveStatus IApprove(int lv)
            {
                if (lv <= 3)
                {
                    return ApproveStatus.APPROVE;
                }
                else
                {
                    return ApproveStatus.NO_PERMISSION;
                }
            }
        }
    }
}
