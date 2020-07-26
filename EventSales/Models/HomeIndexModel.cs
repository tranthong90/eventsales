using System;
using System.Collections.Generic;

namespace EventSales.Models
{
    public class HomeIndexModel
    {
        public string SearchQuery { get; set; }
        public IEnumerable<EventListingModel> EventList { get; set; }
    }
}
