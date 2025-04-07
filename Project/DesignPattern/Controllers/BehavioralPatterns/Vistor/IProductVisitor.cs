namespace DesignPattern.Controllers.BehavioralPatterns.Vistor
{
    public interface IProductHandler<in T> where T : IProduct
    {
        void Handle(T product);
    }

    public class PhysicalProductHandler : IProductHandler<PhysicalProduct>
    {
        public void Handle(PhysicalProduct product)
        {
            Console.WriteLine($"[SHIP] Ship item: {product.Name}");
        }
    }

    public class DigitalProductHandler : IProductHandler<DigitalProduct>
    {
        public void Handle(DigitalProduct product)
        {
            Console.WriteLine($"[EMAIL] Send link: {product.DownloadLink}");
        }
    }

    public class MembershipProductHandler : IProductHandler<MembershipProduct>
    {
        public void Handle(MembershipProduct product)
        {
            Console.WriteLine($"[ACCOUNT] Activate for: {product.Email}");
        }
    }

}
