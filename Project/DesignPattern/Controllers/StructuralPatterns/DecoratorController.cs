using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Runtime.Serialization;
using static DesignPattern.Controllers.StructuralPatterns.DecoratorController;

namespace DesignPattern.Controllers.StructuralPatterns
{
    /// <summary>
    /// Decorator is a structural design pattern that lets you attach new behaviors to objects by placing these objects inside special wrapper objects that contain the behaviors.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DecoratorController : ControllerBase
    {
        /// <summary>
        /// Pros:
        ///     You can extend an object’s behavior without making a new subclass.
        ///     You can add or remove responsibilities from an object at runtime.
        ///     You can combine several behaviors by wrapping an object into multiple decorators.
        ///     Single Responsibility Principle. You can divide a monolithic class that implements many possible variants of behavior into several smaller classes.
        ///     
        /// Cons:
        ///     It’s hard to remove a specific wrapper from the wrappers stack.
        ///     It’s hard to implement a decorator in such a way that its behavior doesn’t depend on the order in the decorators stack.
        ///     The initial configuration code of layers might look pretty ugly.
        ///         
        /// Reference:
        ///     https://refactoring.guru/design-patterns/decorator
        /// </summary>

        // For example:
        // First time we have table Product. However, after your shop have some discount events.
        // So we have 2 table Product and CouponCode
        // Product will save info and price
        // CouponCode will save ID, ProductID, TypeID and DiscountPrice

        // The first time we have
        public class ProductModel
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }

            public virtual string Description => $"{Name} and {Price}";
        }

        // After we have
        public class CouponCodeModel
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int ProductID { get; set; }
            public int TypeID { get; set; }
            public int DiscountPrice { get; set; }
        }

        public abstract class DecoratorProduct : ProductModel
        {
            protected ProductModel _product;
            protected CouponCodeModel _couponCode;
            public DecoratorProduct(ProductModel product, CouponCodeModel couponCode) : base()
            {
                _product = product;
                _couponCode = couponCode;
            }
        }

        public class DiscountProduct1 : DecoratorProduct
        {
            public DiscountProduct1(ProductModel product, CouponCodeModel couponCode) : base(product, couponCode)
            {
                ID = product.ID;
                Name = product.Name;
                Price = product.Price * couponCode.DiscountPrice;
            }

            public override string Description => $"{_product.Name}, {_product.Price}, {_couponCode.Name} {_couponCode.DiscountPrice} and {Price}";
        }

        public class DiscountProduct2 : DecoratorProduct
        {
            public DiscountProduct2(ProductModel product, CouponCodeModel couponCode) : base(product, couponCode)
            {
                ID = product.ID;
                Name = product.Name;
                Price = product.Price - couponCode.DiscountPrice;
            }

            public override string Description => $"{_product.Name}, {_product.Price}, {_couponCode.Name} {_couponCode.DiscountPrice} and {Price}";
        }

        // so we can change business code
        public class ProductService
        {
            public IEnumerable<ProductModel> GetProducts()
            {
                var products = new List<ProductModel>(); // get business...

                // changes
                var couponCodes = new List<CouponCodeModel>(); // get business...

                var result = from product in products
                             join coupon in couponCodes on product.ID equals coupon.ProductID into pc
                             from pcComplie in pc.DefaultIfEmpty()
                             select CreateNewProductModel(product, pcComplie);
                // end changes

                return result;
            }

            private ProductModel CreateNewProductModel(ProductModel product, CouponCodeModel coupon)
            {
                if (coupon == null)
                    return product;

                switch (coupon.TypeID)
                {
                    case 1:
                        return new DiscountProduct1(product, coupon);
                    case 2:
                        return new DiscountProduct2(product, coupon);
                    default:
                        return product;
                }
            }
        }
    }
}
