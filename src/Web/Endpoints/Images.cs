using InstaKcalWebApi.Application.Image.Queries.GetImages;

namespace InstaKcalWebApi.Web.Endpoints;

public class Images : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetImages);
    }

    public async Task<IEnumerable<Image>>GetImages(ISender sender, String userId)
    {
        return await sender.Send(new GetImagesQuery());
    }
}
