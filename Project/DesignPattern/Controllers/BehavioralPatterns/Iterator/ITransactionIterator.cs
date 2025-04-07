using System.Transactions;

namespace DesignPattern.Controllers.BehavioralPatterns.Iterator
{
    public interface ITransactionIterator
    {
        bool HasNext();

        Task<List<Transaction>> GetNextBatchAsync();
    }

}
