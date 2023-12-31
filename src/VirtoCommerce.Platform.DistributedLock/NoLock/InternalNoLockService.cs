using System;
using Microsoft.Extensions.Logging;

namespace VirtoCommerce.Platform.DistributedLock
{
    /// <summary>
    /// Distributed lock provider that implements bypass mode (no distributed lock)
    /// </summary>
    public class InternalNoLockService : IInternalDistributedLockService
    {
        private readonly ILogger<InternalNoLockService> _logger;

        /// <summary>
        /// Construct the provider
        /// </summary>
        /// <param name="logger"></param>
        public InternalNoLockService(ILogger<InternalNoLockService> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Run payload with no lock
        /// </summary>
        /// <param name="resourceId"></param>
        /// <param name="payload"></param>
        public virtual void ExecuteSynchronized(string resourceId, Action<DistributedLockCondition> payload)
        {
            _logger.LogInformation("Distributed lock: run payload for resource {resourceId} without lock.", resourceId);
            payload(DistributedLockCondition.NoLock);
        }
    }
}
