using AIVideoAggregator.Shared.Models;

namespace AIVideoAggregator.Client.Services;

public interface IVideoMetadataFetcher
{
    Task<IReadOnlyList<VideoMetadata>> FetchAsync(string query, CancellationToken cancellationToken = default);
}
