using System;
using System.Collections.Generic;
using EventSales.Data;
using EventSales.Models;

namespace EventSales.Services
{
    public interface IDataMapper
    {
        EventListingModel Map(Event e);
    }
}
