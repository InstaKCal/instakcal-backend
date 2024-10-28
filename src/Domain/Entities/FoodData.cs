namespace InstaKcalWebApi.Domain.Entities;

public class FoodData : BaseAuditableEntity
{
    public string? Name { get; set; }
    
    public string? ImageId { get; set; }
    
    public int? Calories { get; set; }
    
    public float? Proteins { get; set; }

    public float? Carbohydrates { get; set; }
    
    public float? Sugars { get; set; }
    
    public float? Fiber { get; set; }
    
    public float? Fats { get; set; }
    
    public float? SaturateFats { get; set; }
    
    public float? TransFats { get; set; }
    
    public float? UnsaturateFats { get; set; }
    
    public float? Sodium { get; set; }
    
    public double? Cholesterol { get; set; }
}
