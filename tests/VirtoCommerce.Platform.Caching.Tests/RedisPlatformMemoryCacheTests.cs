using System;
using System.Net;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using StackExchange.Redis;
using VirtoCommerce.Platform.Core.Caching;
using VirtoCommerce.Platform.Redis;
using Xunit;

namespace VirtoCommerce.Platform.Caching.Tests
{
    [Trait("Category", "Unit")]
    [Collection(nameof(NotThreadSafeCollection))]
    public class RedisPlatformMemoryCacheTests : MemoryCacheTestsBase
    {
        private readonly Mock<IOptions<RedisCachingOptions>> _redisCachingOptionsMock = new Mock<IOptions<RedisCachingOptions>>();
        private readonly Mock<IConnectionMultiplexer> _connectionMock = new Mock<IConnectionMultiplexer>();
        private readonly Mock<ISubscriber> _subscriberMock = new Mock<ISubscriber>();
        private readonly Mock<ILogger<RedisPlatformMemoryCache>> _logMock = new Mock<ILogger<RedisPlatformMemoryCache>>();

        private const string CacheKey = "test";

        private readonly ConnectionFailedEventArgs _getConnectionFailedEvenArgs = new ConnectionFailedEventArgs(null,
            new DnsEndPoint("test.com", 8080), ConnectionType.Subscription,
            ConnectionFailureType.SocketFailure, new Exception(), "test");

        public RedisPlatformMemoryCacheTests()
        {
            _connectionMock.Setup(x => x.GetSubscriber(null)).Returns(_subscriberMock.Object);
        }

        public RedisPlatformMemoryCache GetRedisPlatformMemoryCache()
        {
            _redisCachingOptionsMock.Setup(x => x.Value).Returns(new RedisCachingOptions { ChannelName = "TestChannel" });
            return new RedisPlatformMemoryCache(CreateCache(), _connectionMock.Object, _subscriberMock.Object, CachingOptions, _redisCachingOptionsMock.Object, _logMock.Object);
        }

        [Fact]
        public void Should_Use_Cache_On_ConnectionFailed()
        {
            var redisPlatformMemoryCache = GetRedisPlatformMemoryCache();

            var firstValue = GetSampleValueWithCache(redisPlatformMemoryCache);
            var secondValue = GetSampleValueWithCache(redisPlatformMemoryCache);

            Assert.Equal(firstValue, secondValue);

            _connectionMock.Raise(x => x.ConnectionFailed += null, _getConnectionFailedEvenArgs);

            var thirdValue = GetSampleValueWithCache(redisPlatformMemoryCache);
            var fourthValue = GetSampleValueWithCache(redisPlatformMemoryCache);

            Assert.Equal(firstValue, thirdValue);
            Assert.Equal(thirdValue, fourthValue);
        }

        [Fact]
        public void Should_Reset_Cache()
        {
            var redisPlatformMemoryCache = GetRedisPlatformMemoryCache();

            _connectionMock.Raise(x => x.ConnectionFailed += null, _getConnectionFailedEvenArgs);

            var firstValue = GetSampleValueWithCache(redisPlatformMemoryCache);

            _connectionMock.Raise(x => x.ConnectionRestored += null, _getConnectionFailedEvenArgs);

            var secondValue = GetSampleValueWithCache(redisPlatformMemoryCache);
            var thirdValue = GetSampleValueWithCache(redisPlatformMemoryCache);

            Assert.NotEqual(firstValue, secondValue);
            Assert.Equal(secondValue, thirdValue);
        }

        private DateTime GetSampleValueWithCache(IPlatformMemoryCache platformMemoryCache)
        {
            return platformMemoryCache.GetOrCreateExclusive(CacheKey, x => DateTime.Now);
        }
    }
}
