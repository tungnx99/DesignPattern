namespace DesignPattern.Controllers.BehavioralPatterns.Iterator
{
    using System.Transactions;

    public class TransactionIterator : ITransactionIterator
    {
        private int _currentIndex = 0;
        private bool _isCompleted = false;
        private readonly int _externalBatchSize;
        private readonly int _internalBatchSize;

        public TransactionIterator(int externalBatchSize, int internalBatchSize)
        {
            _externalBatchSize = externalBatchSize;
            _internalBatchSize = internalBatchSize;
        }

        public async Task<List<Transaction>> GetNextBatchAsync()
        {
            var transactions = new List<Transaction>();

            // business logic to get transactions with batchSize

            _currentIndex += _internalBatchSize;
            // _isCompleted = true;

            return transactions;
        }

        public bool HasNext()
        {
            // condition
            return _currentIndex <= _externalBatchSize || _isCompleted;
        }
    }

}
