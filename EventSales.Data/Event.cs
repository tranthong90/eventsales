using System;
using System.Collections.Generic;
using System.Linq;

namespace EventSales.Data
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ShortDescription { get; set; }
        public List<BaseDiscount> Discounts { get; set; }

        public decimal CalculateAmount(int amountPurchased)
        {
            var validDiscount = Discounts.Where(x => x.IsEligible(amountPurchased));
            decimal discount = 0;
            foreach(var dis in validDiscount)
            {
                discount += dis.CalculateDiscountAmount(amountPurchased, Price);
            }

            return amountPurchased * Price - discount;
        }
    }
}
