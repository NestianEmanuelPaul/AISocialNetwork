using AIVideoAggregator.Server.Services;
using AIVideoAggregator.Shared.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IVideoCacheService, VideoCacheService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/videos/{videoId}/summary", async (string videoId, IVideoCacheService cache, CancellationToken cancellationToken) =>
{
    var cachedSummary = await cache.GetSummaryByVideoIdAsync(videoId, cancellationToken);
    return cachedSummary is null
        ? Results.NotFound()
        : Results.Ok(cachedSummary);
})
.WithName("GetCachedVideoSummary")
.WithOpenApi();

app.MapPost("/videos/summary", async (VideoSummary summary, IVideoCacheService cache, CancellationToken cancellationToken) =>
{
    await cache.SaveSummaryAsync(summary, cancellationToken);
    return Results.Ok();
})
.WithName("StoreVideoSummary")
.WithOpenApi();

app.Run();
