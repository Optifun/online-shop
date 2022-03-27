using System;

namespace OnlineShop.Core.Model
{
    public record Price
    {
        public long Id { get; set; }
        public decimal Value { get; set; }
        public decimal Discount { get; set; }
        public DateTime SettingDate { get; set; }
    }
}