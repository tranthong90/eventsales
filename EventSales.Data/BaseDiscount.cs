using System;
namespace EventSales.Data
{
    public abstract class BaseDiscount
    {
        public string Name { get; }
        protected string Description { get; set; }
        protected int NumberHaveToBuy { get; set; }

        public BaseDiscount( string name,string desc,int number)
        {
            this.Name = name;
            this.Description = desc;
            this.NumberHaveToBuy = number;
        }

        public abstract decimal CalculateDiscountAmount(int numberOfEvent, decimal unitPrice);

        public abstract bool IsEligible(int numberOfEvent);
        

    }
}
