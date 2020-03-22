using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SixPivotApp.ApiClients.Interfaces;
using SixPivotApp.Common;
using SixPivotApp.Models;
using SixPivotApp.Services.Interfaces;

namespace SixPivotApp.Services
{
    public class OrdersService : IOrdersService
    {
        public OrdersService(IOrdersApiClient ordersApiClient) => _ordersApiClient = ordersApiClient;


        private readonly IOrdersApiClient _ordersApiClient;

        public async Task SubmitOrderAsync(Order order)
        {
            await _ordersApiClient.SubmitOrderAsync(order);
        }
    }
}
