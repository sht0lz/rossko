using Domain;
using Domain.Interfaces;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Infrastructure
{
    public class PermutationsCache : IPermutationsCache
    {
        private readonly IDatabase _database;

        public PermutationsCache(string redisConnectionString)
        {
            var redis = ConnectionMultiplexer.Connect(redisConnectionString);
            _database = redis.GetDatabase();
        }

        public Permutations Get(string key)
        {
            var serializedObj = _database.StringGet(key);
            return serializedObj.IsNullOrEmpty ? null : JsonConvert.DeserializeObject<Permutations>(serializedObj);
        }

        public void Set(string key, Permutations value)
        {
            _database.StringSet(key, JsonConvert.SerializeObject(value));
        }
    }
}