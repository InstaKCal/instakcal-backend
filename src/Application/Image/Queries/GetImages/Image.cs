namespace InstaKcalWebApi.Application.Image.Queries.GetImages;

public class Image
{
    public DateTime Date { get; init; }

    public int Id { get; init; }
    
    public string? originalUrl { get; init; }
    
    public string? modifiedUrl { get; init; }
}
