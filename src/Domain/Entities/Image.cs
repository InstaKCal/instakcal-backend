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
        public string originalUrl { get; set; }

        [Required]
        public string processedUrl { get; set; }
        
    }
}