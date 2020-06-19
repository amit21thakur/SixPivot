using StackExchange.Redis;
using System;
using Serilog;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SixPivotApp.Services.Interfaces;

namespace SixPivotApp.Services
{
    public class CacheService : ICacheService
    {
        private readonly ConnectionMultiplexer redisConnection;
        private readonly ILogger logger;

        public CacheService(ConnectionMultiplexer connectionMultiplexer)
        {
            redisConnection = connectionMultiplexer;
            logger = Log.ForContext(typeof(CacheService));
        }

        private IDatabase Database 
        { 
            get 
            { 
                return redisConnection.GetDatabase(); 
            } 
        }

        public async void CacheDataAsync<TD, TK>(TK key, TD data, int timeToLiveMins) where TD : class
        {
            try
            {
                await Database.StringSetAsync(
                    GetSerializedJson(key),
                    GetSerializedJson(data),
                    new TimeSpan(0, timeToLiveMins, 0));
            }
            catch(Exception ex)
            {
                logger.Error(ex, $"Failed while Caching Data. " + typeof(TK).ToString());
                logger.Information("Key: " + GetSerializedJson(key));
            }
        }

        public async Task<bool> CacheExistsAsync<TK>(TK key)
        {
            try
            {
                return await Database.KeyExistsAsync(GetSerializedJson(key));
            }
            catch(Exception ex)
            {
                logger.Error(ex, $"Failed while executing KeyExistsAsync. " + typeof(TK).ToString());
                logger.Information("Key: " + GetSerializedJson(key));
                return false;
            }
        }

        public async Task<TD> GetCachedDataAsync<TD, TK>(TK key) where TD: class
        {
            TD result = null;
            try
            {
                if (await CacheExistsAsync(key))
                {
                    string data = await Database.StringGetAsync(GetSerializedJson(key));
                    result = GetDeserializedObj<TD>(data);
                }
            }
            catch(Exception ex)
            {
                logger.Error(ex, "Failed to get cached data");
                logger.Information("Key: " + GetSerializedJson(key));
            }
            return result;
        }

        private string GetSerializedJson<T>(T key)
        {
            return JsonConvert.SerializeObject(key);
        }
        private T GetDeserializedObj<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }

    }
}
