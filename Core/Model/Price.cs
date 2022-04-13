using System;

namespace OnlineShop.Core.Model
{
    public record Price
    {
        public long Id { get; set; }
        public float Value { get; set; }
        public float Discount { get; set; }
        public DateTime SettingDate { get; set; }
    }
}