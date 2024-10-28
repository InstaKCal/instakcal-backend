namespace InstaKcalWebApi.Domain.Entities;

public class Images : BaseAuditableEntity
{
    public string? UserId { get; set; }
    
    public string? OriginalUrl { get; set; }

    public string? ProcessedUrl { get; set; }

}
