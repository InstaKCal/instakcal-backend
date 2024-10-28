namespace InstaKcalWebApi.Application.Image.Queries.GetImages;

public record GetImagesQuery : IRequest<IEnumerable<Image>>;

public class GetImagesQueryHandler : IRequestHandler<GetImagesQuery, IEnumerable<Image>>
{
    

    public async Task<IEnumerable<Image>> Handle(GetImagesQuery request, CancellationToken cancellationToken)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    {
        var rng = new Random();
        
        await Task.Delay(1000);
        
        return Enumerable.Range(1, 5).Select(index => new Image
        {
            Date = DateTime.Now.AddDays(index), 
            Id = rng.Next(-20, 55),
            Url = "url"
        });
    }
}
