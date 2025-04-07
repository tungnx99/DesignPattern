namespace DesignPattern.Controllers.BehavioralPatterns.Iterator
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using System.Transactions;

    /// <summary>
    /// Iterator is a behavioral design pattern that lets you traverse elements of a collection without exposing its underlying representation (list, stack, tree, etc.).
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IteratorController : ControllerBase
    {
        /// <summary>
        /// Pros:
        ///     Single Responsibility Principle. You can clean up the client code and the collections by extracting bulky traversal algorithms into separate classes.
        ///     Open/Closed Principle.You can implement new types of collections and iterators and pass them to existing code without breaking anything.
        ///     You can iterate over the same collection in parallel because each iterator object contains its own iteration state.
        ///     For the same reason, you can delay an iteration and continue it when needed.
        ///     
        /// Cons:
        ///     Applying the pattern can be an overkill if your app only works with simple collections.
        ///     Using an iterator may be less efficient than going through elements of some specialized collections directly.
        ///     
        /// Reference:
        ///     https://refactoring.guru/design-patterns/iterator
        /// </summary>

        private readonly ITransactionCollection _transactionCollection;

        public IteratorController()
        {
            _transactionCollection = new TransactionCollection();
        }

        [HttpGet]
        public async Task<IActionResult> GetTransactions(int externalBatchSize, int internalBatchSize)
        {
            var result = new List<Transaction>();

            var iterator = _transactionCollection.CreateIterator(externalBatchSize, internalBatchSize);

            while (iterator.HasNext())
            {
                var batch = await iterator.GetNextBatchAsync();

                result.AddRange(batch);
            }

            return Ok(result);
        }
    }
}
