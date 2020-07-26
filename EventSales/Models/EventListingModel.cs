using System;
using System.Globalization;
using EventSales.Data;

namespace EventSales.Models
{
    public class EventListingModel
    {
        public Event Event { get; set; }
        public int Amount { get; set; }
        public string Total { get => (Event.CalculateAmount(Amount)).ToString("c", CultureInfo.CreateSpecificCulture("en-US")); }
    }
}
