using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using EventSales.Data;

namespace EventSales.Services
{
    public class DiscountData
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberHaveToBuy { get; set; }
        public decimal DiscountedAmount { get; set; }
        public decimal DiscountPercent { get; set; }
    }

    public class EventData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ShortDescription { get; set; }
        public List<DiscountData> Discounts { get; set; }
    }

    public class EventSource
    {
        public List<EventData> Events { get; set; }
    }

    public class DataGenerator : IDataService
    {
        private List<Event> _events = new List<Event>();
        public DataGenerator()
        {
            var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), $"App_Data{Path.DirectorySeparatorChar}Data.json");
            var JSON = System.IO.File.ReadAllText(folderDetails);

            var myJsonObject = JsonConvert.DeserializeObject<EventSource>(JSON);
            foreach(var e in myJsonObject.Events)
            {
                var eve = new Event
                {
                    Id = e.Id,
                    Name = e.Name,
                    Price = e.Price,
                    ShortDescription = e.ShortDescription,
                    Discounts = new List<BaseDiscount>()
                    
                };

                foreach(var dis in e.Discounts)
                {
                    if (dis.DiscountedAmount != 0)
                    {
                        eve.Discounts.Add(new GroupDiscount(dis.Name, dis.Description, dis.DiscountedAmount, dis.NumberHaveToBuy));
                        continue;
                    }

                    if(dis.DiscountPercent != 0)
                    {
                        eve.Discounts.Add(new NextItemDiscount(dis.Name, dis.Description, dis.DiscountPercent, dis.NumberHaveToBuy));
                        continue;
                    }
                }

                _events.Add(eve);
            }


        /*    var buy5Get20Percent = new NextItemDiscount("Buy 5, Get 20% off the 5th experience",
    "Buy 5, Get 20% off the 5th experience", (decimal)0.2, 4);

            _events.Add(new Event()
            {
                Name = "Kids Party",
                ShortDescription = "Party for Kids",
                Id = 1,
                Price = 220,
                Discounts = new List<BaseDiscount>
                    {
                        buy5Get20Percent
                    }
            });

            _events.Add(new Event()
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
            });

            _events.Add(new Event()
            {
                Name = "Team Building",
                ShortDescription = "Team Building",
                Id = 3,
                Price = 800,
                Discounts = new List<BaseDiscount>
                    {
                        buy5Get20Percent,
                        new GroupDiscount("Buy 2 for $1500","Buy 2 for $1500",1500,2)

                    }
            });

            _events.Add(new Event()
            {
                Name = "Picnic",
                ShortDescription = "Picnic",
                Id = 4,
                Price = 110,
                Discounts = new List<BaseDiscount>
                    {
                        buy5Get20Percent,
                        new NextItemDiscount("Buy 2, get 1 free","Buy 2, get 1 free",1,2)

                    }
            });*/
        }

        public Task<List<Event>> GetAllEvents()
        {

            return Task.FromResult(_events);
        }

        public Task<Event> GetEventByID(int eventID)
        {
            return Task.FromResult(this._events.FirstOrDefault(e => e.Id == eventID));
        }
    }
}
