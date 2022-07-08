using System.ComponentModel.DataAnnotations.Schema;

namespace BlogCommon;

public class BaseModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Column(TypeName = "timestamp without time zone")]
    public DateTime DateCreated { get; set; } = DateTime.Now;
}