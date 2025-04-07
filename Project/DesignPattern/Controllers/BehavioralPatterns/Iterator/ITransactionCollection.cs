namespace DesignPattern.Controllers.BehavioralPatterns.Iterator
{
    public interface ITransactionCollection
    {
        ITransactionIterator CreateIterator(int externalBatchSize, int internalBatchSize);
    }
}
