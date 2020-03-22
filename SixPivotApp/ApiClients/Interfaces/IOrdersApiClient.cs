using SixPivotApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixPivotApp.ApiClients.Interfaces
{
    public interface IOrdersApiClient
    {
        Task SubmitOrderAsync(Order order);
    }
}
