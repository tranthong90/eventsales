using System;
namespace EventSales.Data
{
    public class GroupDiscount : BaseDiscount
    {
        public decimal DiscountedAmount { get; set; }

        public GroupDiscount(string name,string desc, decimal amount, int numberHaveToBuy): base(name,desc,numberHaveToBuy)
        {
            this.DiscountedAmount = amount;
        }

        public override decimal CalculateDiscountAmount(int numberOfEvent, decimal unitPrice)
        {
            decimal discountPerValid = (NumberHaveToBuy * unitPrice) - DiscountedAmount;
            int valid = numberOfEvent / NumberHaveToBuy;
            
            return valid * discountPerValid;
        }

        public override bool IsEligible(int numberOfEvent)
        {
            return numberOfEvent >= NumberHaveToBuy;
        }
    }
}
