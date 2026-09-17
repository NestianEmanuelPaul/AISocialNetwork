namespace AIVideoAggregator.Shared.Models;

public class VideoSummary
{
    public string VideoId { get; set; } = string.Empty;
    public string AICuratedSummary { get; set; } = string.Empty;
    public bool IsRecommended { get; set; }
    public string Justification { get; set; } = string.Empty;
}
