using AIVideoAggregator.Shared.Models;

namespace AIVideoAggregator.Server.Services;

public class VideoCacheService : IVideoCacheService
{
    private readonly Dictionary<string, VideoSummary> _cache = new(StringComparer.OrdinalIgnoreCase);

    public Task<VideoSummary?> GetSummaryByVideoIdAsync(string videoId, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var exists = _cache.TryGetValue(videoId, out var summary);
        return Task.FromResult(exists ? summary : null);
    }

    public Task SaveSummaryAsync(VideoSummary summary, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        ArgumentNullException.ThrowIfNull(summary);

        _cache[summary.VideoId] = summary;
        return Task.CompletedTask;
    }
}
