using System;
namespace EventSales.Data
{
    public class NextItemDiscount : BaseDiscount
    {
        public decimal DiscountPercent { get; set; }


        public NextItemDiscount(string name,string desc, decimal discountPercent, int numberForDiscount) : base(name,desc,numberForDiscount)
        {
            DiscountPercent = discountPercent;

        }

        public override decimal CalculateDiscountAmount(int numberOfEvent, decimal unitPrice)
        {
            int valid = numberOfEvent / (NumberHaveToBuy + 1);
            return valid * DiscountPercent * unitPrice;
        }

        public override bool IsEligible(int numberOfEvent)
        {
            return numberOfEvent > NumberHaveToBuy;
        }
    }
}
