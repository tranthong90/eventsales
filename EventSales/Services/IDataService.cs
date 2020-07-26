using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventSales.Data;

namespace EventSales.Services
{
    public interface IDataService
    {
        Task<List<Event>> GetAllEvents();

        Task<Event> GetEventByID(int eventID);
    }
}
