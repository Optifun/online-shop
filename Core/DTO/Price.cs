using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Core.DTO
{
    public record Price(long Id, float Value, float Discount)
    {
        public static Price Convert(PriceMutable mutable) =>
            new Price(mutable.Id ?? -1, mutable.Value, mutable.Discount);
    }

    public class PriceMutable
    {
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

        public long? Id { get; set; }
        [Required, Range(0, 9_999_999.99)] public float Value { get; set; }

        [Required, Range(0, 99.99)] public float Discount { get; set; }
    }
}