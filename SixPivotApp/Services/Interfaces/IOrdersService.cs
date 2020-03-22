using SixPivotApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixPivotApp.Services.Interfaces
{
    public interface IOrdersService
    {
        Task SubmitOrderAsync(Order order);
        
    }
}
