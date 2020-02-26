using SixPivotApp.ApiClients.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixPivotApp.ApiClients
{
    public abstract class ApiClientBase
    {
        public ApiClientBase(IApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        protected readonly IApiClient apiClient;
    }
}
