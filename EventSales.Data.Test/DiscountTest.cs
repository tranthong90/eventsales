using System;
using EventSales.Data;
using Xunit;

namespace EventSales.Data.Test
{
    public class DiscountTest
    {
        [Theory]
        [InlineData(1500,2,800,2,100)]
        [InlineData(1500,2,800,3,100)]
        public void TestGroupDiscount(decimal amount, int number, decimal unitPrice,int numberBought, decimal want)
        {
            var groupDiscount = new GroupDiscount("test", "test", amount, number);
            decimal actual = groupDiscount.CalculateDiscountAmount(numberBought, unitPrice);

            Assert.Equal(want, actual);

        }

        [Theory]
        [InlineData(0.2, 4, 100, 6, 20)]
        [InlineData(1, 3, 100, 4, 100)]
        [InlineData(1, 2, 100, 3, 100)]
        [InlineData(1, 3, 440, 2, 0)]
        [InlineData(1, 3, 440, 4, 440)]
        public void TestNextItemDiscount(decimal percent, int number, decimal unitPrice, int numberBought, decimal want)
        {
            var nextItem = new NextItemDiscount("test", "test", percent, number);
            decimal actual = nextItem.CalculateDiscountAmount(numberBought, unitPrice);

            Assert.Equal(want, actual);

        }
    }
}
