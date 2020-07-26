using System;
using EventSales.Data;
using EventSales.Models;

namespace EventSales.Services
{
    public class DataMapper : IDataMapper
    {
        public EventListingModel Map(Event e)
        {
            return new EventListingModel
            {
                Event = e
            };
        }
    }
}
