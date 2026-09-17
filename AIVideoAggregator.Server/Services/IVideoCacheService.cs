using AIVideoAggregator.Shared.Models;

namespace AIVideoAggregator.Server.Services;

public interface IVideoCacheService
{
    Task<VideoSummary?> GetSummaryByVideoIdAsync(string videoId, CancellationToken cancellationToken = default);
    Task SaveSummaryAsync(VideoSummary summary, CancellationToken cancellationToken = default);
}
