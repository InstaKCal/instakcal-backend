using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace instakcal_backend.Domain.Entities
{
    public class Image : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = Guid.NewGuid();
        
        [Required]
        public string UserId { get; set; }
        
        [Required]
        public string OriginalUrl { get; set; }

        [Required]
        public string ProcessedUrl { get; set; }
        
    }
}