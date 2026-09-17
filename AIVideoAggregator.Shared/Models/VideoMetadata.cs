namespace AIVideoAggregator.Shared.Models;

public class VideoMetadata
{
    public string Id { get; set; } = string.Empty;
    public string SourceUrl { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Platform { get; set; } = string.Empty;
    public DateTime PublishedAt { get; set; }
}
