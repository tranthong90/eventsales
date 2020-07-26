using System;
using System.Collections.Generic;
using EventSales.Data;
using EventSales.Models;
using Xunit;


namespace EventSales.Data.Test
{
    public class EventTest
    {
        [Theory]
        [InlineData(2,"$880")]
        [InlineData(4,"$1320")]
        [InlineData(5,"$1672")]
        public void TestEvent(int amount, string total)
        {
            var buy5Get20Percent = new NextItemDiscount("Buy 5, Get 20% off the 5th experience",
            "Buy 5, Get 20% off the 5th experience", (decimal)0.2, 4);

            var orderLine = new EventListingModel
            {
                Event = new Event()
                {
                    Name = "Wine Tour",
                    ShortDescription = "Wine Tour",
                    Id = 2,
                    Price = 440,
                    Discounts = new List<BaseDiscount>
                    {
                        buy5Get20Percent,
                        new NextItemDiscount("Buy 4, ONLY Pay for 3","Buy 4, ONLY Pay for 3",1,3)

                    }
                },
                Amount = amount
            };

            Assert.Equal(total, orderLine.Total);

        }
    }
}