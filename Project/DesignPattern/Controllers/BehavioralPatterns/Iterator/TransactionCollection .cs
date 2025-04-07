using System;

namespace DesignPattern.Controllers.BehavioralPatterns.Iterator
{
    public class TransactionCollection : ITransactionCollection
    {
        public ITransactionIterator CreateIterator(int externalBatchSize, int internalBatchSize)
        {
            return new TransactionIterator(externalBatchSize, internalBatchSize);
        }
    }
}
