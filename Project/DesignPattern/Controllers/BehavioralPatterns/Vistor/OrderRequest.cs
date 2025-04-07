namespace DesignPattern.Controllers.BehavioralPatterns.Vistor
{
    public class OrderRequest
    {
        public PhysicalProduct PhysicalProduct { get; set; }
        public DigitalProduct DigitalProduct { get; set; }
        public MembershipProduct MembershipProduct { get; set; }
    }

    public interface IProduct {
        ProductType Type { get; }
    }
    public enum ProductType
    {
        PHYSICAL,
        DIGITAL,
        MEMBERSHIP
    }

    public class PhysicalProduct : IProduct
    {
        public ProductType Type => ProductType.PHYSICAL;
        public string Name { get; set; }
    }

    public class DigitalProduct : IProduct
    {
        public ProductType Type => ProductType.DIGITAL;
        public string DownloadLink { get; set; }
    }

    public class MembershipProduct : IProduct
    {
        public ProductType Type => ProductType.MEMBERSHIP;
        public string Email { get; set; }
    }
}
