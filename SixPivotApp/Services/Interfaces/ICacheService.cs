using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixPivotApp.Services.Interfaces
{
    public interface ICacheService
    {
        void CacheDataAsync<TD, TK>(TK key, TD data, int timeToLiveMins) where TD : class;

        Task<TD> GetCachedDataAsync<TD, TK>(TK key) where TD : class;

        Task<bool> CacheExistsAsync<TK>(TK key);

    }
}
