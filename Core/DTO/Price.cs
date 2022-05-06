using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace OnlineShop.Core.DTO
{
    public interface IPrice
    {
        float Value { get; }
        float Discount { get; }
        public float ApplyDiscount();
    }

    public record Price(long Id, float Value, float Discount) : IPrice
    {
        public static Price Convert(PriceMutable mutable) => 
            new Price(mutable.Id ?? -1, mutable.Value, mutable.Discount);
        
        public float ApplyDiscount() => 
            Value * (100 - Discount) / 100;
    }

    public class PriceMutable : IPrice
    {
        public long? Id { get; set; }
        [Required, Range(0, 9_999_999.99)] public float Value { get; set; }

        [Required, Range(0, 99.99)] public float Discount { get; set; }
        
        public PriceMutable(long Id, float Value, float Discount)
        {
            this.Id = Id;
            this.Value = Value;
            this.Discount = Discount;
        }

        public PriceMutable(Price price) : this(price.Id, price.Value, price.Discount)
        {
        }

        public PriceMutable()
        {
        }

        public float ApplyDiscount() => 
            Value * (100 - Discount) / 100;
    }
}