namespace DesignPattern.Implement.Implement
{
    using DesignPattern.Implement.Interface;

    public class RealDocumentService : IDocumentService
    {
        private readonly Guid ID;
        public RealDocumentService() {
            ID = Guid.NewGuid();
        }

        public Guid Display()
        {
            return ID;
        }
    }
}
