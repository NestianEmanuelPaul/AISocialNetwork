using AIVideoAggregator.Shared.Models;

namespace AIVideoAggregator.Client.Services;

public class YouTubeApiFetcher : IVideoMetadataFetcher
{
    public Task<IReadOnlyList<VideoMetadata>> FetchAsync(string query, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var mockResults = new List<VideoMetadata>
        {
            new()
            {
                Id = "yt_123",
                SourceUrl = "https://www.youtube.com/watch?v=yt_123",
                Title = "Mock YouTube recommendation: Sci-Fi gems this week",
                Description = "A curated list of sci-fi movie recommendations recently published and relevant to the user criteria.",
                Platform = "YouTube",
                PublishedAt = DateTime.UtcNow.AddDays(-1)
            }
        };

        if (string.IsNullOrWhiteSpace(query))
        {
            return Task.FromResult<IReadOnlyList<VideoMetadata>>(mockResults);
        }

        return Task.FromResult<IReadOnlyList<VideoMetadata>>(
            mockResults
                .Where(item =>
                    item.Title.Contains(query, StringComparison.OrdinalIgnoreCase)
                    || item.Description.Contains(query, StringComparison.OrdinalIgnoreCase))
                .ToList());
    }
}
