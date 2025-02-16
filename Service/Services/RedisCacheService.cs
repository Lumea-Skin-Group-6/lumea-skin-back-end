using System.Text.Json;
using StackExchange.Redis;

namespace Service.Services;

public class RedisCacheService
{
    private readonly ConnectionMultiplexer _redis;
    private readonly IDatabase _cache;

    public RedisCacheService(string redisConnectionString)
    {
        _redis = ConnectionMultiplexer.Connect(redisConnectionString);
        _cache = _redis.GetDatabase();
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan expiration)
    {
        var jsonData = JsonSerializer.Serialize(value);
        await _cache.StringSetAsync(key, jsonData, expiration);
    }

    public async Task<T> GetAsync<T>(string key)
    {
        var jsonData = await _cache.StringGetAsync(key);
        return jsonData.IsNullOrEmpty ? default : JsonSerializer.Deserialize<T>(jsonData);
    }
}